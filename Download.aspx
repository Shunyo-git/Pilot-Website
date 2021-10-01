<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/download/title_download.gif" width="290" /></td>
            <td>
                <img height="68" src="img/download/title_bg.jpg" width="479" /></td>
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
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td background="img/frame/bg.jpg">
                            <asp:DataList ID="DataList1" runat="server" BorderWidth="0" CellPadding="0" CellSpacing="0"
                                RepeatColumns="3" RepeatDirection="Horizontal" ShowFooter="False" ShowHeader="False"
                                Width="669px">
                                <FooterStyle Height="10px" />
                                <ItemTemplate>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td>
                                                <img height="24" src="img/download/top.gif" width="200" /></td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="img/download/bg_g.gif" height="10" valign="middle">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="img/download/bg_g.gif" valign="middle">
                                                <table border="1" bordercolor="#666666" cellpadding="0" cellspacing="0" style="border-collapse: collapse">
                                                    <tr>
                                                        <td>
                                                            <img height="130" src="Upload/Download/<%#Eval("ID")%>.gif" width="174" /></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="img/download/bg_g.gif" height="10" valign="middle">
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img height="5" src="img/download/line1.gif" width="200" /></td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="img/download/bg_w.gif">
                                                <a href="Upload/Download/wall<%#Eval("ID")%>_800x600.jpg"  target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image23','','img/download/bt800_2.gif',1)">
                                                    <img border="0" height="35" name="Image23" src="img/download/bt800_1.gif" width="140" /></a></td>
                                        </tr>
                                        <tr>
                                            <td background="img/download/bg_w.gif">
                                                <img height="5" src="img/download/line2.gif" width="200" /></td>
                                        </tr>
                                        <tr>
                                            <td align="center" background="img/download/bg_w.gif">
                                                <a href="Upload/Download/wall<%#Eval("ID")%>_1024x768.jpg"  target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image24','','img/download/bt1024_2.gif',1)">
                                                    <img border="0" height="35" name="Image24" src="img/download/bt1024_1.gif" width="140" /></a></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <img height="13" src="img/download/down.gif" width="200" /></td>
                                        </tr>
                                    </table>
                                     <p></p>
                                </ItemTemplate>
                                <HeaderStyle Height="1px" />
                            </asp:DataList></td>
                    </tr>
                    <tr>
                        <td align="center" height="50" valign="top">
                            &nbsp;</td>
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
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

