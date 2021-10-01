<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="ProductList.aspx.cs" Inherits="ProductList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/product/title_product.jpg" width="158" /></td>
            <td background="img/pro_bg.jpg" width="611">
                <asp:Panel ID="Panel1" runat="server">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                        height="68" width="611">
                        <param name="movie" value="product1.swf">
                        <param name="quality" value="high">
                        <param name="wmode" value="transparent">
                        <embed height="68" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                            quality="high" src="product1.swf" type="application/x-shockwave-flash" width="611"
                            wmode="transparent"></embed>
                    </object>
                </asp:Panel>
                <asp:Panel ID="Panel2" runat="server">
                    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                        height="68" width="611">
                        <param name="movie" value="product2.swf">
                        <param name="quality" value="high">
                        <param name="wmode" value="transparent">
                        <embed height="68" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                            quality="high" src="product2.swf" type="application/x-shockwave-flash" width="611"
                            wmode="transparent"></embed>
                    </object>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
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
                                        <strong>
                                            <asp:Label ID="lblMainCategory" runat="server"></asp:Label></strong></td>
                                    <td>
                                        <img height="23" src="img/product/).gif" width="20" /></td>
                                    <td class="lightblue12">
                                        <strong>
                                            <asp:Label ID="lblCategory" runat="server"></asp:Label></strong></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td background="img/frame/bg.jpg">
                            <img height="6" src="img/product/_.........gif" width="669" /></td>
                    </tr>
                    <tr>
                        <td background="img/frame/bg.jpg">
                            <asp:DataList ID="DataList1" runat="server" Width="100%" BorderWidth="0" CellPadding="0"
                                CellSpacing="0" ShowFooter="False" ShowHeader="False">
                                <FooterStyle Height="10px" />
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                        <tr>
                                            <td colspan="4" style="width: 210px">
                                                &nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td width="30">
                                                &nbsp;</td>
                                            <td align="left" valign="top">
                                                <table border="0" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table border="0" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td>
                                                                        <img height="20" src="img/product/name.gif" width="71" /></td>
                                                                    <td class="blue12_h18">
                                                                        <strong>
                                                                            <%#Eval("Name")%>
                                                                        </strong>
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                         <%# DisplayColorImage(Convert.ToInt32(Eval("ProductID")))%>
                                                           
                                                           
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td>
                                                            <%# DisplayMainImage(Convert.ToInt32(Eval("ProductID")))%>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td height="10">
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td align="left" valign="top" width="30">
                                                &nbsp;</td>
                                            <td align="left" class="deepgray12_h18" valign="top" width="180">
                                                <span class="blue12_h18"><strong>建議售價：
                                                    <%#DisplayPrice(Convert.ToString(Eval("Price")))%>
                                                </strong></span>
                                                <br />
                                                <%# Pilot.Web.StringHelper.NewLineToBreak(Convert.ToString(Eval("Spec")))%>
                                              
                                            </td>
                                        </tr>
                                    </table>
                                    <img height="6" src="img/product/_.........gif" width="100%" />
                                </ItemTemplate>
                                <HeaderStyle Height="1px" />
                            </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td background="img/frame/bg.jpg" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <table border="0" cellpadding="4" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:HyperLink ID="lnkPrev" runat="server"><img border="0" height="20" name="Image31" src="img/frame/arrow_left1.gif" width="55" /></asp:HyperLink>
                                    </td>
                                    <td class="blue11">
                                        第
                                        <asp:Label ID="lblPageLink" runat="server"></asp:Label>
                                        頁</td>
                                    <td>
                                        <asp:HyperLink ID="lnkNext" runat="server"><img border="0" height="20" name="Image32" src="img/frame/arrow_right1.gif" width="57" /></asp:HyperLink>
                                    </td>
                                </tr>
                            </table>
                        </td>
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
