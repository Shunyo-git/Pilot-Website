<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="NewsList.aspx.cs" Inherits="NewsList"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="Server">
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
                                <a href="NewsList.aspx?HotNews=n" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','img/news/history2.gif',1)">
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
                                <a href="NewsList.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image35','','img/news/hot2.gif',1)">
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
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" background="img/frame/bg_leftbg.jpg" valign="top" width="45">
                <img height="33" src="img/frame/bg_left.jpg" width="45" /></td>
            <td align="left" background="img/frame/bg.jpg" bgcolor="#ebf0f3" valign="top" width="669">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td background="img/frame/bgline.jpg" style="height: 400px" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                              
                                <tr>
                                    <td height="10">
                                        <asp:DataList ID="DataList1" runat="server" Width="669px" BorderWidth="0" CellPadding="0"
                                            CellSpacing="0" ShowFooter="False" ShowHeader="False">
                                            <FooterStyle Height="10px" />
                                            <ItemTemplate>
                                                <table border="0" cellpadding="0" cellspacing="0" Width="100%">
                                                    <tr>
                                                        <td align="left" valign="top">
                                                            <table border="0" cellpadding="0" cellspacing="0" >
                                                                <tr>
                                                                    <td>
                                                                        <img height="20" src="img/news/point.gif" width="20" /></td>
                                                                    <td class="blue15">
                                                                        <strong><a href='NewsDetail.aspx?ID=<%#Eval("ID")%>'>
                                                                            <%#Eval("Caption")%>  
                                                                        </a></strong>
                                                                    </td>
                                                                    <td>
                                                                        <img height="20" src="img/news/point.gif" width="20" />
                                                                        </td>
                                                                        <td>
                                                                        &nbsp;&nbsp;<span style=" font-size:smaller; color:GrayText;" ><%#Eval("NewsDate")%></span></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left">
                                                            <table border="0" cellpadding="0" cellspacing="0" width="98%">
                                                                <tr>
                                                                    <td width="20">&nbsp;</td>
                                                                    
                                                                    <%# DisplayNewsImage(Convert.ToInt32(Eval("ID")), Convert.ToBoolean(Eval("IsDisplayImage")))%>
                                                                      
                                                                    <td class="deepgray12" valign="top" align="left" >
                                                                        <a href='NewsDetail.aspx?ID=<%#Eval("ID")%>'>
                                                                            <%#Eval("Foreword")%>
                                                                        </a> &nbsp;
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </ItemTemplate>
                                            <HeaderStyle Height="1px" />
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
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
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
