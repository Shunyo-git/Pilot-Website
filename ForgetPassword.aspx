<%@ Page Language="C#" MasterPageFile="~/Template01.master" AutoEventWireup="true"
    CodeFile="ForgetPassword.aspx.cs" Inherits="ForgetPassword"   %>

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
            <td align="center" background="img/frame/bg.jpg" bgcolor="#ebf0f3" valign="top" width="669" style="height: 300px" class="blue12">
                &nbsp;<table border="0" cellpadding="0" cellspacing="0" width="400">
                    <tr>
                        <td align="center">
                            &nbsp;<asp:PasswordRecovery ID="PasswordRecovery1" runat="server" SuccessText="�ڭ̤w�N�K�X�ǰe���z�A���ˬd�z��Email�H�c�C"
                                UserNameInstructionText="�п�J�z���U�ɪ��b���A�t�η|�۰ʱH�e�K�X�ܱz��Email�H�c�A<BR />�Y�z�|���]�w�b���A�п�J�z��Email�H�c�C"
                                UserNameLabelText="�b��:" UserNameRequiredErrorMessage="�п�J�b���C">
                                <MailDefinition From="service@pilot.com.tw" 
    Subject="�z�b�ʼ֤��ͪ��b���K�X"
    BodyFileName="PasswordMail.txt" />
                                <UserNameTemplate>
                                    <table border="0" cellpadding="1" cellspacing="0" style="border-collapse: collapse">
                                        <tr>
                                            <td>
                                                <table border="0" cellpadding="0">
                                                    <tr>
                                                        <td align="center" colspan="2">
                                                            �ѰO�K�X?</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="left" colspan="2">
                                                            �п�J�z���U�ɪ��b���A�t�η|�۰ʱH�e�K�X�ܱz��Email�H�c�A<br />
                                                            �Y�z�|���]�w�b���A�п�J�z��Email�H�c�C</td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right">
                                                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">�b��:</asp:Label></td>
                                                        <td align="left">
                                                            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName"
                                                                ErrorMessage="�п�J�b���C" ToolTip="�п�J�b���C" ValidationGroup="PasswordRecovery1">*</asp:RequiredFieldValidator>
                                                            <asp:Button ID="SubmitButton" runat="server" CommandName="Submit" Text="�e�X" ValidationGroup="PasswordRecovery1" /></td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" colspan="2" style="color: red">
                                                            <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="right" colspan="2">
                                                            &nbsp;</td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
                                </UserNameTemplate>

                            </asp:PasswordRecovery>
                        </td>
                    </tr>
                </table>
            </td>
            <td background="img/frame/bg_right.jpg" width="55">
                &nbsp;</td>
        
        </tr>
    </table>
</asp:Content>
