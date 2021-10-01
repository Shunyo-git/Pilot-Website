<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="MessageModify.aspx.cs" Inherits="Manager_MessageModify" %>

<%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" CssClass="input-warn-content"
        ForeColor="" Width="758px" />
    <table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px; width: 8px;">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Manager/image/icon-save.gif" width="14" height="18" />&nbsp;
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">儲存更新</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">取消返回</asp:LinkButton></td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                客服信件</td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="新細明體">
                    <table id="Table2" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                自動編號：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblID" runat="server">新增後自動產生</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                處理狀態：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsDone" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">已處理</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">待處理</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                來信時間：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblCreationDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                來信IP位址：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblIP" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                最後處理時間：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblUpdateDate" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>信件內容</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="新細明體">
                    <table id="Table1" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                姓名：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblName" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                Gender：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblGender" runat="server"> </asp:Label></td>
                        </tr>
                            <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                Birthday：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblBirthday" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                E-mail：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblEmail" runat="server"> </asp:Label></td>
                        </tr>
                             <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                聯絡電話：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblTelephone" runat="server"> </asp:Label></td>
                        </tr>
                          <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                手機：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblMobile" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                希望回覆方式：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblContact" runat="server"> </asp:Label></td>
                        </tr>
                         
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                意見內容：</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblContent" runat="server"> </asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>處理記要</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" style="height: 83px">
                            客服處理記錄：</td>
                        <td align="left" style="height: 83px">
                            <asp:TextBox ID="txtNote" runat="server" Width="80%" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            
                        </td>
                    </tr>
                     
                </table>
                <p>
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="儲存失敗，請檢查您的資料後重新再試一次。"></asp:CustomValidator></p>
            </td>
        </tr>
    </table>
</asp:Content>
