<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="ProductModify.aspx.cs" Inherits="Manager_ProductModify" %>
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
                產品設定</td>
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
                            <td align="right" class="ColumnTD" height="20" width="15%">
                               商品類別：</td>
                            <td align="left" height="20">
                                <asp:DropDownList ID="ddlCategory" runat="server">
                                </asp:DropDownList>
                                </td>
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
                                建議售價：</td>
                            <td align="left" height="20" class="ColumnTD">
                                 <asp:TextBox ID="txtPrice" runat="server" Width="70%" ></asp:TextBox> </td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>產品內容</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                     
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            名稱：</td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="70%" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtName"
                                ErrorMessage="名稱不能空白" ToolTip="名稱不能空白"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span
                                    style="color: #336600">(50字以內)</span></td>
                    </tr>
                     <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            主圖片：</td>
                        <td align="left">
                            
                                <asp:Image ID="imgLogo" runat="server"  /> <br />
                            上傳圖片：<uc1:UploadControl  ID="UploadControl1" runat="server" FileTypeRange="jpg,gif"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif"  
                                 FileControlWidth="60%" />
                           <br />
                                ◎圖檔格式JPG或GIF。 <br /><br />
                         
                        </td>
                    </tr>
                     <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            規格：</td>
                        <td align="left">
                             <asp:TextBox ID="txtSpec" runat="server" Width="70%" Rows="5" TextMode="MultiLine"  ></asp:TextBox>
                              
                             </td>
                    </tr>
                      <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            備註：</td>
                        <td align="left">
                            <asp:TextBox ID="txtDescription" runat="server" Width="70%" Rows="2" TextMode="MultiLine"  ></asp:TextBox>
                         </td>
                    </tr>
                </table>
                <p>
                    
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="儲存失敗，請檢查您的資料後重新再試一次。"></asp:CustomValidator>&nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>
