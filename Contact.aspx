<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true" CodeFile="Contact.aspx.cs" Inherits="contact"  %>
<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" Runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/contact/title_con.gif" width="239" /></td>
            <td align="left" background="img/contact/title_bg.jpg" class="deepgray12" valign="bottom"
                width="530">
                <table border="0" cellspacing="0" cellpadding="0">
              <tr>
                <td><span class="deepgray12"><strong>此版面僅限台灣地區使用  非台灣地區消費者請上：</strong></span><BR /><span class="blue12_ud"><a href="http://www.pilotpen.com" target="_blank" class="blue12_ud"><strong>http://www.pilotpen.com</strong></a></span>
              </tr>
            </table></td>
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
                        <td background="img/frame/bgline.jpg" height="10">
                        </td>
                    </tr>
                    <tr>
                        <td background="img/frame/bg.jpg">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                ※姓名<asp:RequiredFieldValidator ID="ValidatorName" runat="server" ControlToValidate="txtName"
                                                                    ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator></td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td>
                                                                <input class="blue12_h18" name="textfield" size="40" type="text" id="txtName" runat="server" maxlength="100" /></td>
                                                            <td width="10">&nbsp;
                                                                </td>
                                                            <td class="red12">
                                                                ※為必填欄位</td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                性別</td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td colspan="3">
                                                                <asp:RadioButtonList ID="rbtnGender" runat="server" CssClass="deepgray12_h18" RepeatDirection="Horizontal"
                                                                    Width="157px">
                                                                    <asp:ListItem Value="男">男</asp:ListItem>
                                                                    <asp:ListItem Value="女">女</asp:ListItem>
                                                                </asp:RadioButtonList></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                ※生日</td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td>
                                                                <table border="0" cellpadding="2" cellspacing="1">
                                                                    <tr class="deepgray12_h18">
                                                                        <td>
                                                                            西元</td>
                                                                        <td>
                                                                            <input class="blue12_h18" name="textfield" size="4" type="text" id="txtYear" runat="server" maxlength="4" />
                                                                            <asp:RequiredFieldValidator ID="ValidatorY" runat="server" ControlToValidate="txtYear"
                                                                                ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator></td>
                                                                        <td>
                                                                            年</td>
                                                                        <td>
                                                                            <input class="blue12_h18" name="textfield" size="2" type="text" id="txtMonth" runat="server" maxlength="2" />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMonth"
                                                                                ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator></td>
                                                                        <td>
                                                                            月</td>
                                                                        <td>
                                                                            <input class="blue12_h18" name="textfield" size="2" type="text" id="txtDay" runat="server" maxlength="2"   />
                                                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtDay"
                                                                                ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator></td>
                                                                        <td>
                                                                            日</td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                ※E-Mail<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="Email"
                                                                    ErrorMessage="*" Font-Size="Small"></asp:RequiredFieldValidator></td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td>
                                                                <input class="blue12_h18" name="textfield" size="45" type="text" id="Email" runat="server" maxlength="200" />
                                                                <asp:RegularExpressionValidator ID="valEmail1" runat="server" ControlToValidate="Email"
                                                                    CssClass="red12" Display="Dynamic" ErrorMessage="Email 不是正確的格式." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                    ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                手機</td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td>
                                                                <input class="blue12_h18" name="textfield" size="45" type="text" id="Mobile" runat="server" maxlength="100" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <table border="0" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td width="20">&nbsp;
                                                                </td>
                                                            <td class="blue12" width="90">
                                                                聯絡電話</td>
                                                            <td>
                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                            <td>
                                                                <input class="blue12_h18" name="textfield" size="45" type="text" id="Teltphone" runat="server" maxlength="100" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="left" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td align="left" valign="top">
                                        <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td width="20">&nbsp;
                                                                            </td>
                                                                        <td class="blue12_h18" height="31" width="90">
                                                                            希望回覆方式</td>
                                                                        <td>
                                                                            <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                        <td colspan="5">
                                                                            <asp:RadioButtonList ID="rbtnContact" runat="server" CssClass="deepgray12_h18" RepeatDirection="Horizontal"
                                                                                Width="157px">
                                                                                <asp:ListItem Value="E-Mail">E-Mail</asp:ListItem>
                                                                                <asp:ListItem Value="電話">電話</asp:ListItem>
                                                                                <asp:ListItem>皆可</asp:ListItem>
                                                                            </asp:RadioButtonList></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img height="6" src="img/contact/line2.jpg" width="558" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                        <tr>
                                                            <td>
                                                                <table border="0" cellpadding="0" cellspacing="0">
                                                                    <tr>
                                                                        <td width="20">&nbsp;
                                                                            </td>
                                                                        <td align="left" class="blue12_h18" height="31" valign="top" width="90">
                                                                            ※意見內容</td>
                                                                        <td align="left" valign="top">
                                                                            <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                        <td>
                                                                            <textarea class="deepgray12_h18" cols="80" name="textarea" rows="8" id="txtContent" runat="server"></textarea></td>
                                                                    </tr>
                                                                </table>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td>
                                                                <img height="6" src="img/contact/line2.jpg" width="558" /></td>
                                                        </tr>
                                                    </table>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                    <td width="111">
                                        <img height="191" src="img/contact/contact_pct.gif" width="111" /></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" valign="top">
                            <table border="0" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:ImageButton
                                                ID="ibtnSubmit" runat="server" ImageUrl="img/contact/send1.gif" OnClick="ibtnSubmit_Click" /></td>
                                    <td width="30">&nbsp;
                                        </td>
                                    <td>
                                        <a href="javascript:document.forms[0].reset();" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image33','','img/contact/clean2.gif',1)">
                                            <img border="0" height="35" name="Image33" src="img/contact/clean1.gif" width="111" /></a></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" height="10">&nbsp;
                            </td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">&nbsp;
                </td>
        </tr>
    </table>
</asp:Content>

