<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="CFList.aspx.cs" Inherits="CFList"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/cf/title_cf.gif" width="200" /></td>
            <td background="img/pro_bg.jpg" width="569">
                <img height="68" src="img/news/title_bg.jpg" width="569" /></td>
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
                         <asp:DataList ID="DataList1" runat="server" Width="669px" BorderWidth="0" CellPadding="0"
                                            CellSpacing="0" ShowFooter="False" ShowHeader="False" RepeatColumns="4" RepeatDirection="Horizontal">
                                            <FooterStyle Height="10px" />
                                            <ItemTemplate>
                                               <table border="0" cellspacing="0" cellpadding="0">
                    <tr>
                      <td><img src="img/cf/area1.gif" width="10" height="9"></td>
                      <td height="9" background="img/cf/area2.gif"></td>
                      <td><img src="img/cf/area3.gif" width="9" height="9"></td>
                    </tr>
                    <tr>
                      <td background="img/cf/area4.gif">&nbsp;</td>
                      <td bgcolor="#ffffff"><table border="1" cellpadding="0" cellspacing="0" bordercolor="#666666" style="border-collapse:collapse ">
                        <tr>
                          <td><img src="Upload/CF/<%#Eval("ID")%>.jpg" width="121" height="90"></td>
                        </tr>
                      </table>                        </td>
                      <td background="img/cf/area5.gif">&nbsp;</td>
                    </tr>
                    <tr>
                      <td background="img/cf/area4.gif">&nbsp;</td>
                      <td height="30" bgcolor="#ffffff" class="blue12_h18"><div align="center"><%#Eval("Caption")%></div></td>
                      <td background="img/cf/area5.gif">&nbsp;</td>
                    </tr>
                    <tr>
                      <td background="img/cf/area4.gif">&nbsp;</td>
                      <td bgcolor="#ffffff"><div align="center"><a href="Upload/CF/<%#Eval("ID")%>.mp4"  target="_blank" onMouseOut="MM_swapImgRestore()" onMouseOver="MM_swapImage('Image22','','img/cf/bt2.gif',1)"><img src="img/cf/bt1.gif" name="Image22" width="114" height="29" border="0"></a></div></td>
                      <td background="img/cf/area5.gif">&nbsp;</td>
                    </tr>
                    <tr>
                      <td><img src="img/cf/area6.gif" width="10" height="11"></td>
                      <td height="11" background="img/cf/area7.gif"></td>
                      <td><img src="img/cf/area8.gif" width="9" height="11"></td>
                    </tr>
                                                 
                  </table>
                  <p></p>
                                            </ItemTemplate>
                                            <HeaderStyle Height="1px" />
                                        </asp:DataList>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
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

