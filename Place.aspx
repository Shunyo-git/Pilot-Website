<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="Place.aspx.cs" Inherits="Place"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0"
                    height="98" width="769">
                    <param name="movie" value="place.swf">
                    <param name="quality" value="high">
                    <param name="wmode" value="transparent">
                    <embed height="98" pluginspage="http://www.macromedia.com/shockwave/download/index.cgi?P1_Prod_Version=ShockwaveFlash"
                        quality="high" src="place.swf" type="application/x-shockwave-flash" width="769"
                        wmode="transparent"></embed>
                </object>
            </td>
        </tr>
        
    </table>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentBody" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img id="imgArea" runat="server"   src="img/place/title_place1.jpg" width="186" height="23"  /></td>
            <td width="569">
                <img height="23" src="img/place/title_placebg.jpg" width="583" /></td>
        </tr>
    </table>
    <table border="0" cellpadding="0" cellspacing="0" width="100%">
        <tr>
            <td align="left" background="img/frame/bg_leftbg.jpg" valign="top" width="45">
                &nbsp;</td>
            <td align="left" background="img/frame/bg.jpg" bgcolor="#ebf0f3" valign="top" width="669">
                <table border="0" cellpadding="0" cellspacing="0" width="100%">
                    <tr>
                        <td align="left" background="img/frame/bgline.jpg">
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <asp:GridView ID="GridView1" runat="server" Width="669px"  ShowHeader="False" AutoGenerateColumns="False" ControlStyle-BorderStyle="None" ControlStyle-BorderWidth="0" ItemStyle-BorderStyle="None" ItemStyle-BorderWidth="0">
                                <Columns>
                                    <asp:TemplateField>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="25px" VerticalAlign="Top"  />
                                        <ItemTemplate>
                                           <img src="img/news/point.gif" width="20" height="20">
                                        </ItemTemplate>
                                   </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle  Width="140px"  CssClass="blue12" Font-Bold="True" HorizontalAlign="Left" />
                                         <ItemTemplate>
                                           <%# DisplayStore(Convert.ToString(Eval("StoreName")), Convert.ToString(Eval("Url")))%>
                                        </ItemTemplate>
                                     </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Tel">
                                        <ItemStyle Wrap="False" VerticalAlign="Top" CssClass="deepgray12" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="Address">
                                        <ItemStyle Wrap="False" VerticalAlign="Top"  CssClass="blue12" HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:TemplateField>
                                        <ItemStyle Width="25px" />
                                    </asp:TemplateField>
                                    
                                </Columns>
                            </asp:GridView>
                            &nbsp;&nbsp;</td>
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
