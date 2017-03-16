using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ia2hathitrust

{
    public partial class frmMain : Form
    {
        System.Collections.Hashtable hash_assoc = new System.Collections.Hashtable();
        System.Collections.Hashtable hash_leaders = new System.Collections.Hashtable();
        public frmMain()
        {
            InitializeComponent();
        }




        public string GetURL(string url)
        {
            try
            {
                
                System.Net.WebRequest.DefaultWebProxy = null;
                System.Uri uri = new Uri(url);
                System.Net.HttpWebRequest objRequest =
                (System.Net.HttpWebRequest)System.Net.WebRequest.Create(uri);
                //System.Net.HttpWebRequest objRequest =
                //(System.Net.HttpWebRequest)System.Net.WebRequest.Create(MyUri(uri));
                objRequest.Proxy = null;

                //if (cglobal.PublicProxy != null)
                //{
                //    objRequest.Proxy = cglobal.PublicProxy;
                //}
                objRequest.UserAgent = "MarcEdit 6.2 Headings Retrieval (caching)";
                objRequest.Proxy = null;
                objRequest.Accept = "*/*";

                //Changing the default timeout from 100 seconds to 30 seconds.
                objRequest.Timeout = 30000;

                System.Net.WebResponse objResponse = objRequest.GetResponse();

                System.IO.StreamReader reader = new System.IO.StreamReader(objResponse.GetResponseStream(), System.Text.Encoding.UTF8);
                string tmpVal = reader.ReadToEnd().Trim();
                //System.Windows.Forms.MessageBox.Show(uri + "\n" + tmpVal);
                reader.Close();
                objResponse.Close();

                return tmpVal;
            }
            catch //(System.Exception xx)
            {
                //System.Windows.Forms.MessageBox.Show(uri + "\n" + xx.ToString());
                return "";
            }
        }
       

        private void cmdProcess_Click(object sender, EventArgs e)
        {

            ia2hathitrust.Properties.Settings.Default.institution = txt_inst.Text;
            ia2hathitrust.Properties.Settings.Default.end_date = txt_end.Text;
            ia2hathitrust.Properties.Settings.Default.start_date = txt_start.Text;
            ia2hathitrust.Properties.Settings.Default.save_file = txt_save.Text;
            
            if (rdCollection.Checked == true)
            {
                ia2hathitrust.Properties.Settings.Default.search_type = 0;
            } else
            {
                ia2hathitrust.Properties.Settings.Default.search_type = 1;
            }

            ia2hathitrust.Properties.Settings.Default.Save();


            //string url = "http://archive.org/advancedsearch.php?q=mediatype%3Atexts%20updatedate%3A%5B" + txt_start.Text + "%20TO%20" + txt_end.Text + "%5D%20collection%3A\"OhioStateUniversityLibrary\"&fl[]=identifier&rows=5000&indent=yes&fmt=xml&xmlsearch=Search#raw";
            string url = "";

            if (rdContributor.Checked == true)
            {
                url = "http://archive.org/advancedsearch.php?q=mediatype%3Atexts%20updatedate%3A%5B" + txt_start.Text + "%20TO%20" + txt_end.Text + "%5D%20contributor%3A\"" + txt_inst.Text + "\"&fl[]=identifier&rows=500&indent=yes&fmt=xml&xmlsearch=Search#raw";
            } else if (rdCollection.Checked == true)
            {
                url = "http://archive.org/advancedsearch.php?q=mediatype%3Atexts%20updatedate%3A%5B" + txt_start.Text + "%20TO%20" + txt_end.Text + "%5D%20collection%3A\"" + txt_inst.Text + "\"&fl[]=identifier&rows=500&indent=yes&fmt=xml&xmlsearch=Search#raw";
            }
            string xml_data = GetURL(url);
            string xml_buffer = "";
            if (!string.IsNullOrEmpty(xml_data))
            {
                System.Collections.ArrayList identifiers = new System.Collections.ArrayList();
                ProcessResults(url, ref identifiers);
                //now we iterate through the data file and process data
                string ia_stem = "http://www.archive.org/download/";

                int count = 0;
                foreach (string bookname in identifiers)
                {
                    string ia_meta_stem = ia_stem + bookname + "/" + bookname;
                    string ia_struct = GetURL(ia_meta_stem + "_meta.xml");
                    string ia_marc = GetURL(ia_meta_stem + "_marc.xml");

                    //if (string.IsNullOrEmpty(ia_marc))
                    //{
                    //    ia_marc = GetURL(ia_meta_stem + "_meta.mrc");
                        
                    //}

                    //System.Windows.Forms.MessageBox.Show(ia_struct);
                    //System.Windows.Forms.MessageBox.Show(ia_marc);

                    lbStatus.Text = "Processing " + (count + 1).ToString() + " of " + identifiers.Count.ToString();
                    System.Windows.Forms.Application.DoEvents();
                    if (!String.IsNullOrEmpty(ia_struct) && !string.IsNullOrEmpty(ia_marc))
                    {
                        string ark = GetArk(ia_struct);
                        string ia_record = JoinRecords(ark, ia_marc);
                        if (lb_custom.Text.Trim().Length > 0 &&
                            System.IO.File.Exists(lb_custom.Text))
                        {
                            ia_record = TransformRecord(ia_record, lb_custom.Text);
                            if (ia_record.Trim().Length ==0)
                            {
                                break;
                            }
                        }
                        xml_buffer += ia_record;
                        //System.Windows.Forms.MessageBox.Show(ia_record);                    
                    }
                    count++;

                }
            }

            string collection_header = "<?xml version=\"1.0\" encoding=\"UTF-8\" ?>" + System.Environment.NewLine +
                                       "<collection xmlns=\"http://www.loc.gov/MARC21/slim\"" + System.Environment.NewLine +
                                       "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\"" + System.Environment.NewLine +
                                       "xsi:schemaLocation=\"http://www.loc.gov/MARC21/slim http://www.loc.gov/standards/marcxml/schema/MARC21slim.xsd\">" + System.Environment.NewLine;

            string collection_footer = "</collection>";
            System.IO.StreamWriter writer = new System.IO.StreamWriter(txt_save.Text, false, new System.Text.UTF8Encoding(false));
            writer.Write(collection_header + xml_buffer + collection_footer);
            writer.Close();
            //System.Windows.Forms.MessageBox.Show("finished");
            lbStatus.Text = "Process has completed.";
        }

        private string TransformRecord(string stext, string sXSLT)
        {
            //use Saxon; which will be installed with MarcEdit; to allow xslt 1, 2, and 3

            System.IO.StringReader sreader = new System.IO.StringReader(stext);
            System.Xml.XmlReader xreader = System.Xml.XmlReader.Create(sreader);
            Saxon.Api.Processor processor = new Saxon.Api.Processor();
            Saxon.Api.XsltCompiler xsltCompiler = processor.NewXsltCompiler();
            Saxon.Api.XdmNode input = processor.NewDocumentBuilder().Build(xreader);
            

            // Create a transformer for the stylesheet.
            Saxon.Api.XsltTransformer transformer = null;
            if (System.IO.File.Exists(sXSLT))
            {
                System.IO.FileStream xstream = new System.IO.FileStream(sXSLT, System.IO.FileMode.Open);                
                xsltCompiler.BaseUri = new Uri(System.IO.Path.GetDirectoryName(sXSLT) + System.IO.Path.DirectorySeparatorChar.ToString(), UriKind.Absolute);             
                transformer = xsltCompiler.Compile(xstream).Load();                
            }
            else
            {
                lbStatus.Text = "ERROR applying the cutom rules file";
                return "";
            }



            // Set the root node of the source document to be the initial context node
            transformer.InitialContextNode = input;

            // Create a serializer
            Saxon.Api.Serializer serializer = new Saxon.Api.Serializer();            
            System.IO.TextWriter stringWriter = new System.IO.StringWriter();
            serializer.SetOutputWriter(stringWriter);            
            transformer.Run(serializer);
            
            string tmp = stringWriter.ToString();

            //System.Windows.Forms.MessageBox.Show(tmp);
            //****Remove these lines because all the white space was being removed on translation***
            //System.Text.RegularExpressions.Regex objRegEx = new System.Text.RegularExpressions.Regex(@"\n +=LDR ", System.Text.RegularExpressions.RegexOptions.None);
            //tmp = objRegEx.Replace(tmp, "\n" + @"=LDR ");

            return tmp;

        }

        private string GetArk(string ia_struct)
        {
            string marc_field = "<datafield tag=\"955\" ind1=\" \" ind2=\" \">"; 

            System.Xml.XmlTextReader rd;
            rd = new System.Xml.XmlTextReader(new System.IO.StringReader(ia_struct));
            try
            {
                //System.Windows.Forms.MessageBox.Show("here");
                while (rd.Read())
                {
                    //This is where we find the head of the record, 
                    //then process the values within the record.
                    //We also need to do character encoding here if necessary.

                    if (rd.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        //System.Windows.Forms.MessageBox.Show(rd.LocalName);
                        if (rd.LocalName == "identifier-ark")
                        {
                            marc_field += "<subfield code=\"b\">" + rd.ReadString() + "</subfield>";
                        }
                        else if (rd.LocalName == "identifier")
                        {
                            marc_field += "<subfield code=\"q\">" + rd.ReadString() + "</subfield>";
                        }
                    }
                }

                marc_field += "</datafield>";
            }
            catch { }
            rd.Close();
            return marc_field;
        }

        private string JoinRecords(string ark, string ia_marc)
        {

            int start_seek = ia_marc.IndexOf("<record");
            ia_marc = ia_marc.Substring(start_seek);
            int seek = ia_marc.IndexOf("</record>");
            string marc_string = "";
            if (seek > -1)
            {
                marc_string = ia_marc.Insert(seek - 1, ark);
                marc_string = marc_string.Substring(0, marc_string.IndexOf("</record>") + "</record>".Length);
                marc_string = marc_string.Replace("<record xmlns=\"http://www.loc.gov/MARC21/slim\">", "<record>");
            }

            return marc_string;
        }

        private void ProcessResults(string xml_data, ref System.Collections.ArrayList identifiers)
        {
            System.Xml.XmlTextReader rd;
            rd = new System.Xml.XmlTextReader(xml_data);
            try
            {
                //System.Windows.Forms.MessageBox.Show("here");
                while (rd.Read())
                {
                    //This is where we find the head of the record, 
                    //then process the values within the record.
                    //We also need to do character encoding here if necessary.

                    if (rd.NodeType == System.Xml.XmlNodeType.Element)
                    {
                        //System.Windows.Forms.MessageBox.Show(rd.LocalName);
                        if (rd.LocalName == "str" && rd.GetAttribute("name") == "identifier")
                        {
                            identifiers.Add(rd.ReadString());
                        }
                    }
                }
            }
            catch { }
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

       

        

        
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog sd = new SaveFileDialog();
            sd.Filter = "XML File|*.xml|All Files (*.*)|*.*";
            sd.FilterIndex = 0;
            sd.ShowDialog();
            if (sd.FileName != "")
            {
                txt_save.Text = sd.FileName;
            }
        }

        

        private void frmMain_Load(object sender, EventArgs e)
        {
            string sInstitution = ia2hathitrust.Properties.Settings.Default.institution;
            string sSaveFile = ia2hathitrust.Properties.Settings.Default.save_file;
            string sStart = ia2hathitrust.Properties.Settings.Default.end_date;
            string sEnd = DateTime.Now.ToString("yyyy-MM-dd");
            string scustom = ia2hathitrust.Properties.Settings.Default.custom;

            int search_type = ia2hathitrust.Properties.Settings.Default.search_type;

            if (sStart.Trim().Length > 0)
            {
                try
                {
                    
                    DateTime old = DateTime.ParseExact(sStart, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture);
                    //System.Convert.ToDateTime(sStart);
                    sStart = (old.Add(new TimeSpan(1, 0, 0, 0))).ToString("yyyy-MM-dd");
                } catch
                {
                    sStart = ia2hathitrust.Properties.Settings.Default.start_date;
                }
            }

            txt_save.Text = sSaveFile;
            txt_start.Text = sStart;
            txt_end.Text = sEnd;
            txt_inst.Text = sInstitution;

            if (scustom.Trim().Length > 0)
            {
                lb_custom.Text = scustom;
            }

            switch (search_type)
            {
                case 1:
                    rdContributor.Checked = true;
                    break;
                default:
                    rdCollection.Checked = true;
                    break;
            }
        }

        private void txt_ris_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_save_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lnkdebug_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "";

            if (rdContributor.Checked == true)
            {
                url = "http://archive.org/advancedsearch.php?q=mediatype%3Atexts%20updatedate%3A%5B" + txt_start.Text + "%20TO%20" + txt_end.Text + "%5D%20contributor%3A\"" + txt_inst.Text + "\"&fl[]=identifier&rows=500&indent=yes&fmt=xml&xmlsearch=Search#raw";
            }
            else if (rdCollection.Checked == true)
            {
                url = "http://archive.org/advancedsearch.php?q=mediatype%3Atexts%20updatedate%3A%5B" + txt_start.Text + "%20TO%20" + txt_end.Text + "%5D%20collection%3A\"" + txt_inst.Text + "\"&fl[]=identifier&rows=500&indent=yes&fmt=xml&xmlsearch=Search#raw";
            }

            System.Windows.Forms.Clipboard.SetText(url);
            System.Diagnostics.Process.Start(url);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //Open help
            System.Diagnostics.Process.Start("http://marcedit.reeset.net/internet-archivehathitrust-data-packager");
        }

        private void cmd_setcustom_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.OpenFileDialog sd = new System.Windows.Forms.OpenFileDialog();
            sd.Filter = "XSLT Rules File|*.xsl|All Files (*.*)|*.*";
            sd.FilterIndex = 0;
            sd.ShowDialog();
            if (sd.FileName != "")
            {
                lb_custom.Text = sd.FileName;
                ia2hathitrust.Properties.Settings.Default.custom = sd.FileName;
            }
        }
    }
}
