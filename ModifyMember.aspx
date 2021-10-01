<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="ModifyMember.aspx.cs" Inherits="ModifyMember"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" runat="Server">

    <script language="javascript" src="/chk_address.js">function IMG1_onclick() {

}

</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentHead" runat="Server">
    <table border="0" cellpadding="0" cellspacing="0">
        <tr>
            <td>
                <img height="68" src="img/join/title_join.gif" width="239" /></td>
            <td align="left" background="img/join/title_bg.jpg" valign="bottom" width="530">
                <table border="0" cellpadding="0" cellspacing="0">
                    <tr>
                        <td width="250">
                            &nbsp;</td>
                        <td>
                            <img height="29" src="img/join/littleperson.gif" width="32" /></td>
                        <td>
                            <a href="#" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image16','','img/join/change2.gif',1)">
                                <img border="0" height="29" name="Image16" src="img/join/change1.gif" width="104" /></a></td>
                        <td>
                            <a href="ForgetPassword.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image17','','img/join/forget2.gif',1)">
                                <img border="0" height="29" name="Image17" src="img/join/forget1.gif" width="94" /></a></td>
                    </tr>
                </table>
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
                &nbsp;<table border="0" cellpadding="0" cellspacing="0" width="100%">
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                帳號</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;</td>
                                                                            <td width="10">
                                                                                &nbsp;<asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label></td>
                                                                            <td class="red12">
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                舊密碼</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="txtOldPassword" runat="server" CssClass="blue12_h18" TextMode="Password"
                                                                                    Width="220px"></asp:TextBox></td>
                                                                            <td class="red12">
                                                                                ※如需變更密碼時請輸入。</td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                新密碼</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="Password" runat="server" CssClass="blue12_h18" TextMode="Password"
                                                                                    Width="220px"></asp:TextBox></td>
                                                                            <td class="red12">
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                新密碼確認</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="ConfirmPassword" runat="server" CssClass="blue12_h18" TextMode="Password"
                                                                                    Width="220px"></asp:TextBox><asp:CompareValidator ID="PasswordCompare" runat="server"
                                                                                        ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic"
                                                                                        ErrorMessage="您輸入的密碼不一致" ValidationGroup="CreateUserWizard" CssClass="red12"></asp:CompareValidator><asp:RegularExpressionValidator
                                                                                            ID="valPasswordLength" runat="server" ControlToValidate="Password" ErrorMessage="密碼最少4個字元."
                                                                                            ValidationExpression="[a-zA-Z0-9]{4,16}" ValidationGroup="CreateUserWizard" CssClass="red12"></asp:RegularExpressionValidator></td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※E-Mail<asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="Email不能空白." ToolTip="Email不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="Email" runat="server" CssClass="blue12_h18" Width="350px"></asp:TextBox>
                                                                                <asp:RegularExpressionValidator ID="valEmail1" runat="server" ControlToValidate="Email"
                                                                                    CssClass="red12" Display="Dynamic" ErrorMessage="Email 不是正確的格式." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                                                                                    ValidationGroup="CreateUserWizard"></asp:RegularExpressionValidator></td>
                                                                        </tr>
                                                                    </table>
                                                                </td>
                                                            </tr>
                                                            <tr style="color: #000000">
                                                                <td>
                                                                    <img height="6" src="img/contact/line1.jpg" width="669" /></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                                <tr style="color: #000000">
                                                    <td>
                                                        <table border="0" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td>
                                                                    <table border="0" cellpadding="0" cellspacing="0">
                                                                        <tr>
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※姓名<asp:RequiredFieldValidator ID="valChineseName" runat="server" ControlToValidate="txtChineseName"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="姓名不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="txtChineseName" runat="server" CssClass="blue12_h18" MaxLength="20"
                                                                                    Width="220px"></asp:TextBox></td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                性別</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td colspan="3">
                                                                                <asp:RadioButtonList ID="rbtnGender" runat="server" CssClass="deepgray12_h18" RepeatDirection="Horizontal"
                                                                                    Width="157px">
                                                                                    <asp:ListItem Value="male">男</asp:ListItem>
                                                                                    <asp:ListItem Value="female">女</asp:ListItem>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
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
                                                                                            &nbsp;<asp:DropDownList ID="selYear" runat="server" CssClass="blue12_h18">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            年</td>
                                                                                        <td>
                                                                                            &nbsp;<asp:DropDownList ID="selMonth" runat="server" CssClass="blue12_h18">
                                                                                            </asp:DropDownList></td>
                                                                                        <td>
                                                                                            月</td>
                                                                                        <td>
                                                                                            &nbsp;<asp:DropDownList ID="selDay" runat="server" CssClass="blue12_h18">
                                                                                            </asp:DropDownList></td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                教育程度</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:DropDownList ID="ddlEducation" runat="server">
                                                                                </asp:DropDownList>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※聯絡電話<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtTelphone"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="連絡電話不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="txtTelphone" runat="server" CssClass="blue12_h18" MaxLength="30"
                                                                                    Width="220px"></asp:TextBox></td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※地址<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtAddress"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="地址不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;
                                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="blue12_h18" Width="350px"></asp:TextBox>
                                                                                &nbsp;
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12">
                                                                                希望PILOT舉辦何種活動</td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:RadioButtonList ID="rbtnWish" runat="server" CssClass="deepgray12_h18"
                                                                                    RepeatDirection="Horizontal" RepeatLayout="Flow">
                                                                                    <asp:ListItem Value="抽獎">抽獎</asp:ListItem>
                                                                                    <asp:ListItem Value="網路遊戲">網路遊戲</asp:ListItem>
                                                                                    <asp:ListItem>其他</asp:ListItem>
                                                                                </asp:RadioButtonList></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="txtOtherWish" runat="server" CssClass="deepgry11" MaxLength="50"
                                                                                    Width="100px"></asp:TextBox></td>
                                                                            <td>
                                                                            </td>
                                                                            <td>
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
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="15" valign="top" style="color: red" class="red12">
                                            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ValidationGroup="CreateUserWizard" />
                                            <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" valign="top" style="height: 54px">
                                            <table border="0" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td style="height: 35px">
                                                        </td>
                                                    <td width="30" style="height: 35px">
                                                        <asp:ImageButton ID="ibtnSave" runat="server" ToolTip="確認送出" ImageUrl="~/img/join/send1.gif" ValidationGroup="CreateUserWizard" OnClick="ibtnSave_Click" /></td>
                                                         
                                                    <td style="height: 35px">
                                                        <a href="javascript:document.forms[0].reset();" onmouseout="MM_swapImgRestore()"
                                                            onmouseover="MM_swapImage('Image41','','img/join/clean2.gif',1)">
                                                            <img border="0" height="35" name="Image41" src="img/join/clean1.gif" width="111" id="IMG1" onclick="return IMG1_onclick()" /></a></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="15">
                                        
                                        </td>
                                    </tr>
                                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        
        </tr>
    </table>
</asp:Content>
