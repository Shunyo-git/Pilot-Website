<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Manager_Index"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b> 網站管理後台首頁</b> </td>
        </tr>
        <tr>
            <td align="left" class="Forumrow" style="height: 28px">
                 說明事項<br />
                <ul>
                 <li>管理資料庫連線帳號與密碼變更，請於 web.config檔案中設定．<br /><br /> </li>
                 <li>管理者密碼變更，請點選<asp:LinkButton ID="lbtnChangPwd" runat="server" OnClick="lbtnChangPwd_Click" ForeColor="#ff3333"><b>這裡</b></asp:LinkButton>進行設定．</li>
                 </ul>
                </td>
        </tr>
        <tr>
            <td class="Forumrow" align="center">
                <font face="新細明體">
                   
                    &nbsp;<asp:ChangePassword ID="ChangePassword1" runat="server" Visible="false" NewPasswordRequiredErrorMessage="必須輸入新密碼。" OnContinueButtonClick="ChangePassword1_ContinueButtonClick" PasswordLabelText="請輸入現在的密碼:" SuccessText="您的密碼已變更完成，下次登入時請使用密碼!" UserNameRequiredErrorMessage="必須輸入使用者名稱。" OnCancelButtonClick="ChangePassword1_CancelButtonClick">
                </asp:ChangePassword>
                </font></td>
        </tr>
        <tr>
            <td class="Forumrow" style="height: 30px">
                <font face="新細明體"></font><font face="新細明體" style="background-color: #ffffff"></font>
                &nbsp;<br />
            </td>
        </tr>
    </table>
</asp:Content>

