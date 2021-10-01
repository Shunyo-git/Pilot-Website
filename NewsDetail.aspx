<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="NewsDetail.aspx.cs" Inherits="NewsDetail"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <asp:Panel ID="PanelHotNewsTitle" runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img height="68" src="img/news/title_news.gif" width="200" /></td>
                <td background="img/news/title_bg.jpg" valign="bottom" width="569">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td width="20">
                                <img height="23" src="img/product/).gif" width="20" /></td>
                            <td align="left" class="lightblue12" valign="bottom">
                                <strong>最新消息</strong></td>
                            <td align="right" valign="bottom">
                                <a href="NewsList.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','img/news/history2.gif',1)">
                                    <img border="0" height="31" name="Image35" src="img/news/history1.gif" width="84" /></a></td>
                            <td width="55">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="PanelHistoryNewsTitle" runat="server">
        <table border="0" cellpadding="0" cellspacing="0">
            <tr>
                <td>
                    <img height="68" src="img/news/title_news.gif" width="200" /></td>
                <td background="img/news/title_bg.jpg" valign="bottom" width="569">
                    <table border="0" cellpadding="0" cellspacing="0" width="100%">
                        <tr>
                            <td style="height: 31px" width="20">
                                <img height="23" src="img/product/).gif" width="20" /></td>
                            <td align="left" class="lightblue12" style="height: 31px" valign="bottom">
                                <strong>歷史消息</strong></td>
                            <td align="right" style="height: 31px" valign="bottom">
                                <a href="NewsList.aspx?HotNews=y" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','img/news/hot2.gif',1)">
                                    <img border="0" height="31" name="Image35" src="img/news/hot1.gif" width="84" /></a></td>
                            <td style="height: 31px" width="55">
                                &nbsp;</td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        </asp:Panel>
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
                            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <img height="20" src="img/news/point.gif" width="20" /></td>
                                                <td class="blue15">
                                                    <strong>
                                                        <asp:Label ID="lblCaption" runat="server"></asp:Label></strong></td>
                                                <td>
                                                    <img height="20" src="img/news/point.gif" width="20" /></td>
                                                      <td>
                                                    &nbsp;&nbsp;<span style=" font-size:smaller; color:GrayText;" ><asp:Label ID="lblCreationDate" runat="server"></asp:Label></span></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="20">
                                                    &nbsp;</td>
                                                <td class="blue12">
                                                    <asp:Label ID="lblForeword" runat="server"></asp:Label></td>
                                            </tr>
                                        </table><br />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="20">
                                                    &nbsp;</td>
                                                <td align="left" valign="top">
                                                    <table id="TableImage" runat="server" border="0" cellpadding="0" cellspacing="0"
                                                        style="padding-right: 15px">
                                                        <tr>
                                                            <td height="26" valign="bottom">
                                                                <table border="0" cellpadding="0" cellspacing="0" height="15" width="100%">
                                                                    <tr>
                                                                        <td background="img/frame/x.gif">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img id="NewsImage" runat="server" src="img/news/pic_p1.jpg" width="234" height="349" /></td>
                                                        </tr>
                                                        <tr>
                                                            <td height="26" valign="top">
                                                                <table border="0" cellpadding="0" cellspacing="0" height="15" width="100%">
                                                                    <tr>
                                                                        <td background="img/frame/x.gif">
                                                                            &nbsp;</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                                <td class="deepgray12" valign="top">
                                                    <asp:Label ID="lblContent" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td height="10">
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" valign="top">
                            <asp:HyperLink ID="linkReturn" runat="server" NavigateUrl="NewsList.aspx"><img border="0" height="20" name="Image19" src="img/frame/back1.gif" width="84" /></asp:HyperLink></td>
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

