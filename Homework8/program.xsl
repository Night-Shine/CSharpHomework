<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
<xsl:template match="/">
<HTML>
    <head>
        <title>html</title>
    </head>
<body>
    <table>
        <xsl:apply-templates/>
    </table>          
</body>  
</HTML>
</xsl:template>

<xsl:template match="ArrayOfOrder">
    <xsl:apply-templates select="Order"/>
</xsl:template>

<xsl:template match="Detail">
    <tr>
        <td>
            <xsl:value-of select="Num"/>
        </td>
        <td>
            <xsl:value-of select="CutomerName"/>
        </td>
        <td>
            <xsl:value-of select="ProductName"/>
        </td>
    </tr>
</xsl:template>

</xsl:stylesheet>