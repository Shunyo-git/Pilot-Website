<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="Star.aspx.cs" Inherits="Star"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/product/title_product.jpg" width="158" /></td>
            <td background="img/pro_bg.jpg" width="611">
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                    height="68" width="611">
                    <param name="movie" value="product3.swf">
                    <param name="quality" value="high">
                    <param name="wmode" value="transparent">
                    <embed height="68" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                        quality="high" src="product3.swf" type="application/x-shockwave-flash" width="611"
                        wmode="transparent"></embed>
                </object>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" background="img/frame/bg_leftbg.jpg" valign="top" width="45">
                <img height="33" src="img/frame/bg_left.jpg" width="45" /></td>
            <td align="left" background="img/frame/bg.jpg" bgcolor="#ebf0f3" valign="top" width="669">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="img/frame/bgline.jpg">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <img height="23" src="img/product/@.gif" width="28" /></td>
                                    <td class="gray15">
                                        <strong>百樂主打星</strong></td>
                                    <td>
                                        <img height="23" src="img/product/).gif" width="20" /></td>
                                    <td class="lightblue12">
                                        <strong>
                                            <asp:Label ID="lblCaprion" runat="server"></asp:Label></strong></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" background="img/frame/bg.jpg">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td width="90">
                                        &nbsp;</td>
                                    <td>
                                        <img id="imgPilotStar" runat="server" height="519" src="img/product/start1.jpg" width="349" /></td>
                                    <td valign="bottom">
                                        <asp:HyperLink ID="hlinkMore" runat="server"><img border="0"
                                                height="23" name="Image18" src="img/product/more1.gif" width="113" /></asp:HyperLink> </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center" height="10">
                        </td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

