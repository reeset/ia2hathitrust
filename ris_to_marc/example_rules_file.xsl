<xsl:stylesheet version="2.0"
    xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xpath-default-namespace="">
    <xsl:output omit-xml-declaration="yes" indent="yes"/>    
    <xsl:strip-space elements="*"/>
    <!-- Note: I set a default namespace of blank because the plugin removes the namespace
         from the fragment and moves it up to the collection element added to the generated 
         header of the finished file.-->
    <xsl:template match="node()|@*">
        <xsl:copy>
            <xsl:apply-templates select="node()|@*" />
        </xsl:copy>
    </xsl:template>
    
   
    <!--XSLT 1.0 would require using the local-name syntax-->
    <!--<xsl:template match="*[local-name()='record']/*[local-name()='datafield'][@tag='925']">-->
    <xsl:template match="datafield[@tag='925']">
        <!--<datafield namespace="http://www.loc.gov/MARC21/slim" tag="925" ind1=" " ind2=" ">-->
        <xsl:element name="datafield">
            <xsl:attribute name="tag">925</xsl:attribute>
            <xsl:attribute name="ind1"><xsl:text> </xsl:text></xsl:attribute>
            <xsl:attribute name="ind2"><xsl:text> </xsl:text></xsl:attribute>
            <xsl:choose>
                <xsl:when test="subfield[@code='k']">
                    <xsl:if test="subfield[@code='c']">
                        <subfield code="c"><xsl:value-of select="subfield[@code='c']" /><xsl:text> </xsl:text>
                        <xsl:value-of select="subfield[@code='k']" /></subfield>
                        <xsl:for-each select="subfield">
                            <xsl:if test="not(@code='c') and 
                                          not(@code='k')">
                                <subfield>
                                    <xsl:attribute name="code"><xsl:value-of select="@code" />
                                    </xsl:attribute><xsl:value-of select="." />
                                </subfield>
                            </xsl:if>
                        </xsl:for-each>
                    </xsl:if>
                    
                    <xsl:if test="not(subfield[@code='c']) and subfield[@code='k']">
                        <subfield code="c"><xsl:value-of select="subfield[@code='k']" /></subfield>
                        <xsl:for-each select="subfield">
                            <xsl:if test="not(@code='c') and
                                not(@code='k')">
                                <subfield>
                                    <xsl:attribute name="code"><xsl:value-of select="@code" />
                                    </xsl:attribute><xsl:value-of select="." />
                                </subfield>
                            </xsl:if>
                        </xsl:for-each>                    
                    </xsl:if>
                </xsl:when>
                <xsl:otherwise>
                    <xsl:for-each select="subfield">
                        <subfield>
                            <xsl:attribute name="code"><xsl:value-of select="@code" />
                            </xsl:attribute><xsl:value-of select="." />
                        </subfield>                        
                    </xsl:for-each>
                </xsl:otherwise>
            </xsl:choose>
        </xsl:element>
    </xsl:template>
</xsl:stylesheet>
