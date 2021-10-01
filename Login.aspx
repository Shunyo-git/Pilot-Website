<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="Login.aspx.cs" Inherits="Login"   %>

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
            <td align="center" background="img/frame/bg.jpg" bgcolor="#ebf0f3" valign="middle" width="669" style="height: 300px" class="blue12">
                &nbsp;
                <table border="0" cellpadding="0" cellspacing="0" width="200">
                    <tr>
                        <td align="left">
                            <asp:Login ID="Login1" runat="server" PasswordRequiredErrorMessage="請輸入密碼。" RememberMeText="記住密碼。"
                                TitleText="會員登入" UserNameLabelText="帳號:" UserNameRequiredErrorMessage="請輸入帳號。">
                            </asp:Login>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        
        </tr>
    </table>
</asp:Content>
