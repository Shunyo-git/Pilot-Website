<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="NewsModify.aspx.cs" Inherits="Manager_NewsModify" %>
<%@ Register TagPrefix="FCKeditorV2" Namespace="FredCK.FCKeditorV2" Assembly="FredCK.FCKeditorV2" %>
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
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">儲存</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">取消</asp:LinkButton></td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                最新消息設定</td>
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
                                分類：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsHotNews" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Selected="True" Value="True">最新消息</asp:ListItem>
                                    <asp:ListItem  Value="False">歷史消息</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                網站顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsApproved" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">顯示</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">不顯示</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                首頁顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsMainPageDisplay" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">顯示</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">不顯示</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                板型顯示：</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsDisplayImage" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">圖片版型</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">文字版型</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>最新消息內容</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            標題：</td>
                        <td align="left">
                            <asp:TextBox ID="txtTitle" runat="server" Width="70%" MaxLength="54"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtTitle"
                                ErrorMessage="標題不能空白" ToolTip="標題不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span
                                    style="color: #336600">(50字以內)</span></td>
                    </tr>
                     <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            引言：</td>
                        <td align="left">
                            
                             <asp:TextBox ID="txtForeword" runat="server" Width="90%" Rows="3" TextMode="MultiLine"></asp:TextBox>
                             </td>
                    </tr>
                      
                     <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            內容：</td>
                        <td align="left"> <asp:TextBox ID="txtContent" runat="server" Width="90%" Rows="30" TextMode="MultiLine"></asp:TextBox>
                            
                             
                             </td>
                    </tr>
                       <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            圖片：</td>
                        <td align="left">
                            
                                <asp:Image ID="imgLogo" runat="server"  /> <br />
                            上傳圖片：<uc1:UploadControl  ID="UploadControl1" runat="server" FileTypeRange="jpg,gif"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif"  
                                 FileControlWidth="60%" />
                           <br />
                                ◎上傳圖片請先設定為圖片版型，圖檔格式JPG或GIF。 <br /><br />
                         
                        </td>
                    </tr>
                </table>
                <p>
                    
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="儲存失敗，請檢查您的資料後重新再試一次。"></asp:CustomValidator>&nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
