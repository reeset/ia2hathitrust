namespace ia2hathitrust
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_save = new System.Windows.Forms.TextBox();
            this.cmdProcess = new System.Windows.Forms.Button();
            this.cmdClose = new System.Windows.Forms.Button();
            this.cmdSave = new System.Windows.Forms.PictureBox();
            this.txt_inst = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_start = new System.Windows.Forms.TextBox();
            this.txt_end = new System.Windows.Forms.TextBox();
            this.lbStatus = new System.Windows.Forms.Label();
            this.rdContributor = new System.Windows.Forms.RadioButton();
            this.rdCollection = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lnkdebug = new System.Windows.Forms.LinkLabel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lb_custom = new System.Windows.Forms.Label();
            this.cmd_setcustom = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmd_setcustom)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(461, 115);
            this.label1.TabIndex = 0;
            this.label1.Text = resources.GetString("label1.Text");
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Description:";
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(12, 159);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(447, 1);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 193);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Group By:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 369);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Save File:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // txt_save
            // 
            this.txt_save.Location = new System.Drawing.Point(108, 366);
            this.txt_save.MaxLength = 3;
            this.txt_save.Name = "txt_save";
            this.txt_save.Size = new System.Drawing.Size(293, 26);
            this.txt_save.TabIndex = 7;
            this.txt_save.TextChanged += new System.EventHandler(this.txt_save_TextChanged);
            // 
            // cmdProcess
            // 
            this.cmdProcess.Location = new System.Drawing.Point(479, 51);
            this.cmdProcess.Name = "cmdProcess";
            this.cmdProcess.Size = new System.Drawing.Size(137, 40);
            this.cmdProcess.TabIndex = 8;
            this.cmdProcess.Text = "Process File";
            this.cmdProcess.UseVisualStyleBackColor = true;
            this.cmdProcess.Click += new System.EventHandler(this.cmdProcess_Click);
            // 
            // cmdClose
            // 
            this.cmdClose.Location = new System.Drawing.Point(479, 102);
            this.cmdClose.Name = "cmdClose";
            this.cmdClose.Size = new System.Drawing.Size(137, 40);
            this.cmdClose.TabIndex = 9;
            this.cmdClose.Text = "Close";
            this.cmdClose.UseVisualStyleBackColor = true;
            this.cmdClose.Click += new System.EventHandler(this.cmdClose_Click);
            // 
            // cmdSave
            // 
            this.cmdSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmdSave.Image = ((System.Drawing.Image)(resources.GetObject("cmdSave.Image")));
            this.cmdSave.Location = new System.Drawing.Point(412, 367);
            this.cmdSave.Name = "cmdSave";
            this.cmdSave.Size = new System.Drawing.Size(26, 26);
            this.cmdSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cmdSave.TabIndex = 11;
            this.cmdSave.TabStop = false;
            this.cmdSave.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // txt_inst
            // 
            this.txt_inst.Location = new System.Drawing.Point(22, 275);
            this.txt_inst.MaxLength = 3200;
            this.txt_inst.Name = "txt_inst";
            this.txt_inst.Size = new System.Drawing.Size(416, 26);
            this.txt_inst.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 321);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Start Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(239, 321);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 20);
            this.label6.TabIndex = 14;
            this.label6.Text = "End Date:";
            // 
            // txt_start
            // 
            this.txt_start.Location = new System.Drawing.Point(108, 318);
            this.txt_start.MaxLength = 25;
            this.txt_start.Name = "txt_start";
            this.txt_start.Size = new System.Drawing.Size(115, 26);
            this.txt_start.TabIndex = 15;
            // 
            // txt_end
            // 
            this.txt_end.Location = new System.Drawing.Point(322, 318);
            this.txt_end.MaxLength = 25;
            this.txt_end.Name = "txt_end";
            this.txt_end.Size = new System.Drawing.Size(117, 26);
            this.txt_end.TabIndex = 16;
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Location = new System.Drawing.Point(13, 469);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(62, 20);
            this.lbStatus.TabIndex = 17;
            this.lbStatus.Text = "Status:";
            // 
            // rdContributor
            // 
            this.rdContributor.AutoSize = true;
            this.rdContributor.Checked = true;
            this.rdContributor.Location = new System.Drawing.Point(22, 242);
            this.rdContributor.Name = "rdContributor";
            this.rdContributor.Size = new System.Drawing.Size(113, 24);
            this.rdContributor.TabIndex = 18;
            this.rdContributor.TabStop = true;
            this.rdContributor.Text = "Contributor";
            this.rdContributor.UseVisualStyleBackColor = true;
            // 
            // rdCollection
            // 
            this.rdCollection.AutoSize = true;
            this.rdCollection.Location = new System.Drawing.Point(22, 219);
            this.rdCollection.Name = "rdCollection";
            this.rdCollection.Size = new System.Drawing.Size(104, 24);
            this.rdCollection.TabIndex = 19;
            this.rdCollection.Text = "Collection";
            this.rdCollection.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(96, 189);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(28, 28);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lnkdebug
            // 
            this.lnkdebug.AutoSize = true;
            this.lnkdebug.Location = new System.Drawing.Point(13, 405);
            this.lnkdebug.Name = "lnkdebug";
            this.lnkdebug.Size = new System.Drawing.Size(97, 20);
            this.lnkdebug.TabIndex = 21;
            this.lnkdebug.TabStop = true;
            this.lnkdebug.Text = "Debug URL";
            this.lnkdebug.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkdebug_LinkClicked);
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(463, 25);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1, 477);
            this.groupBox2.TabIndex = 22;
            this.groupBox2.TabStop = false;
            // 
            // lb_custom
            // 
            this.lb_custom.AutoSize = true;
            this.lb_custom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_custom.Location = new System.Drawing.Point(49, 440);
            this.lb_custom.Name = "lb_custom";
            this.lb_custom.Size = new System.Drawing.Size(222, 20);
            this.lb_custom.TabIndex = 23;
            this.lb_custom.Text = "No custom rules file defined.";
            // 
            // cmd_setcustom
            // 
            this.cmd_setcustom.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cmd_setcustom.Image = ((System.Drawing.Image)(resources.GetObject("cmd_setcustom.Image")));
            this.cmd_setcustom.Location = new System.Drawing.Point(17, 434);
            this.cmd_setcustom.Name = "cmd_setcustom";
            this.cmd_setcustom.Size = new System.Drawing.Size(26, 26);
            this.cmd_setcustom.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cmd_setcustom.TabIndex = 24;
            this.cmd_setcustom.TabStop = false;
            this.cmd_setcustom.Click += new System.EventHandler(this.cmd_setcustom_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 527);
            this.Controls.Add(this.cmd_setcustom);
            this.Controls.Add(this.lb_custom);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.lnkdebug);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.rdCollection);
            this.Controls.Add(this.rdContributor);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.txt_end);
            this.Controls.Add(this.txt_start);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_inst);
            this.Controls.Add(this.cmdSave);
            this.Controls.Add(this.cmdClose);
            this.Controls.Add(this.cmdProcess);
            this.Controls.Add(this.txt_save);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Internet Archive to HathiTrust Packager";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmdSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmd_setcustom)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_save;
        private System.Windows.Forms.Button cmdProcess;
        private System.Windows.Forms.Button cmdClose;
        private System.Windows.Forms.PictureBox cmdSave;
        private System.Windows.Forms.TextBox txt_inst;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_start;
        private System.Windows.Forms.TextBox txt_end;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.RadioButton rdContributor;
        private System.Windows.Forms.RadioButton rdCollection;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.LinkLabel lnkdebug;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lb_custom;
        private System.Windows.Forms.PictureBox cmd_setcustom;
    }
}