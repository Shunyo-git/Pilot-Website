<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="index"   %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
        height="266" width="769">
        <param name="movie" value="mean.swf">
        <param name="quality" value="high">
        <embed height="266" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
            quality="high" src="mean.swf" type="application/x-shockwave-flash" width="769"></embed>
    </object>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td background="img/index/index_left.gif" width="29">
                &nbsp;</td>
            <td bgcolor="#ffffff">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <img height="28" src="img/index/title.gif" width="95" /></td>
                                </tr>
                                <tr>
                                    <td rowspan="4">
                                      
                                        <asp:DataList ID="HotNewsList" runat="server" Width="100%">
                                            <ItemTemplate>
                                                 <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td width="14">
                                                    <img height="43" src="img/index/index_bg1_l.gif" width="14" /></td>
                                                <td bgcolor="#fbe6d2">
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td align="left" width="10">
                                                                <img height="18" src="img/index/arrow_blue.gif" width="4" /></td>
                                                            <td class="index_blue12">
                                                                <a href="NewsDetail.aspx?ID=<%#Eval("ID") %>"><%# Eval("Caption")%></a></td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                &nbsp;</td>
                                                            <td class="gray12">
                                                                <a href="NewsDetail.aspx?ID=<%#Eval("ID") %>"> <%# Pilot.Web.StringHelper.SubstringByte(Convert.ToString(Eval("Foreword")),70)%>...  </a></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td bgcolor="#fbe6d2" valign="bottom" width="40">
                                                    <a href="NewsDetail.aspx?ID=<%#Eval("ID") %>" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('NewsImage<%#Eval("ID") %>','','img/index/index_bg1_more2.gif',1)">
                                                        <img border="0" height="12" name="NewsImage<%#Eval("ID") %>" src="img/index/index_bg1_more1.gif" width="40" /></a></td>
                                                <td width="22">
                                                    <img height="43" src="img/index/index_bg1_r.gif" width="22" /></td>
                                            </tr>
                                        </table>
                                            </ItemTemplate>
                                            <SeparatorTemplate>
                                               <br />
                                            </SeparatorTemplate>
                                        </asp:DataList></td>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                </tr>
                                <tr>
                                    <td>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="154">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <a href="http://www.pilot.co.jp/namiki/index.html"  target="_blank" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image13','','img/index/namiki2.gif',1)">
                                            <img border="0" height="71" name="Image13" src="img/index/namiki1.gif" width="154" /></a></td>
                                </tr>
                                <tr>
                                    <td>
                                        <a href="joinform.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image14','','img/index/join2.gif',1)">
                                            <img border="0" height="112" name="Image14" src="img/index/join1.gif" width="154" /></a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="img/index/index_right.gif" width="31">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

