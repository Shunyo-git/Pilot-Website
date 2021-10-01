<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="JoinForm.aspx.cs" Inherits="JoinForm"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="HtmlHead" runat="Server">

    <script language="javascript" src="/chk_address.js"></script>

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
                            <a href="ModifyMember.aspx" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image16','','img/join/change2.gif',1)">
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
           <asp:CreateUserWizard ID="CreateUserWizard1" runat="server" CreateUserButtonText="Sign Up" PasswordRegularExpressionErrorMessage="Please enter a more secure password."  Width="100%" OnCreatedUser="CreateUserWizard1_CreatedUser">
                                <WizardSteps>
                                    <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                                        <CustomNavigationTemplate>
                                        </CustomNavigationTemplate>
                                        <ContentTemplate>
                                            <asp:Panel ID="panFocus" runat="server" DefaultButton="StepNextButton">
                                             
                                               
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※帳號<asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="帳號不能空白." ToolTip="帳號不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="UserName" runat="server" CssClass="blue12_h18" Width="220px"></asp:TextBox></td>
                                                                            <td width="10">
                                                                                &nbsp;</td>
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
                                                                            <td width="20">
                                                                                &nbsp;</td>
                                                                            <td class="blue12" width="90">
                                                                                ※密碼<asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password"
                                                                                    CssClass="pink11_ff9b9b" ErrorMessage="密碼不能空白." ToolTip="密碼不能空白." ValidationGroup="CreateUserWizard">*</asp:RequiredFieldValidator></td>
                                                                            <td>
                                                                                <img height="23" src="img/contact/between.jpg" width="29" /></td>
                                                                            <td>
                                                                                &nbsp;<asp:TextBox ID="Password" runat="server" CssClass="blue12_h18" TextMode="Password"
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
                                                                                ※密碼確認</td>
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
                                                                                <select name="city" cssclass="blue12_h18" onchange="todistrict(this.selectedIndex);">
                                                                                    <option value="" selected>請選擇</option>
                                                                                    <option value="102">台北市</option>
                                                                                    <option value="101">基隆市</option>
                                                                                    <option value="103">台北縣</option>
                                                                                    <option value="401">宜蘭縣</option>
                                                                                    <option value="104">桃園縣</option>
                                                                                    <option value="105">新竹市</option>
                                                                                    <option value="106">新竹縣</option>
                                                                                    <option value="201">苗栗縣</option>
                                                                                    <option value="202">台中市</option>
                                                                                    <option value="203">台中縣</option>
                                                                                    <option value="204">彰化縣</option>
                                                                                    <option value="205">南投縣</option>
                                                                                    <option value="301">嘉義市</option>
                                                                                    <option value="302">嘉義縣</option>
                                                                                    <option value="206">雲林縣</option>
                                                                                    <option value="303">台南市</option>
                                                                                    <option value="304">台南縣</option>
                                                                                    <option value="305">高雄市</option>
                                                                                    <option value="306">高雄縣</option>
                                                                                    <option value="501">澎湖縣</option>
                                                                                    <option value="307">屏東縣</option>
                                                                                    <option value="403">台東縣</option>
                                                                                    <option value="402">花蓮縣</option>
                                                                                    <option value="502">金門縣</option>
                                                                                    <option value="503">連江縣</option>
                                                                                    <option value="601">南海諸島</option>
                                                                                    <option value="602">釣魚台列嶼</option>
                                                                                </select>
                                                                                <select name="district" size="1" cssclass="blue12_h18" onchange="tozipcode(this.selectedIndex);">
                                                                                    <option value="">先選擇縣市</option>
                                                                                </select>
                                                                                <asp:TextBox ID="txtAddress" runat="server" CssClass="blue12_h18" Width="250px"></asp:TextBox>
                                                                                <input type="hidden" name="zip_code0">
                                                                                <input type="hidden" name="district0">
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
                                                    <td>
                                                        <asp:LinkButton ID="StepNextButton" runat="server" CommandName="MoveNext" CssClass="signinButton"
                                                            Text="Sign Up" ValidationGroup="CreateUserWizard">
                                            <img src="img/join/send1.gif" alt="確認送出" name="Image40" width="111" height="35" border="0"
                                                            id="Image40" onmouseout="MM_swapImgRestore()" onmouseover="MM_swapImage('Image40','','img/join/send2.gif',1)"/></asp:LinkButton></td>
                                                    <td width="30">
                                                        &nbsp;</td>
                                                    <td>
                                                        <a href="javascript:document.forms[0].reset();" onmouseout="MM_swapImgRestore()"
                                                            onmouseover="MM_swapImage('Image41','','img/join/clean2.gif',1)">
                                                            <img border="0" height="35" name="Image41" src="img/join/clean1.gif" width="111" /></a></td>
                                                </tr>
                                            </table>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center" height="15">
                                        </td>
                                    </tr>
                                </table>
                           
                                            </asp:Panel>
                                        </ContentTemplate>
                                    </asp:CreateUserWizardStep>
                                    <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                                        <ContentTemplate>
                                <table border="0" cellpadding="0" cellspacing="0" class="blue12" width="100%">
                                    <tr>
                                        <td height="100">
                                            &nbsp;</td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <strong>恭喜您註冊成功!</strong><br />
                                            <br />
                                            <a href="/index.aspx">回首頁</a></td>
                                    </tr>
                                </table>
                             
                                        </ContentTemplate>
                                    </asp:CompleteWizardStep>
                                </WizardSteps>
                            </asp:CreateUserWizard>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        
        </tr>
    </table>
</asp:Content>
