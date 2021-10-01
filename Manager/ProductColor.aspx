<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="ProductColor.aspx.cs" Inherits="Manager_ProductColor" %>
 <%@ Register Src="UploadControl.ascx" TagName="UploadControl" TagPrefix="uc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Manager/image/icon-edit.gif" width="17" height="15" />&nbsp;
                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">編輯</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-delete.gif" width="14" height="15" />
                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click">刪除</asp:LinkButton>
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" /><asp:LinkButton ID="lbtnCancel" runat="server"
                    OnClick="lbtnCancel_Click">取消</asp:LinkButton>&nbsp;</td>
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
                                &nbsp;<asp:Label ID="lblID" runat="server"></asp:Label></td>
                        </tr>
                       <tr>
                            <td align="right" class="ColumnTD" height="20">
                                產品類別：</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblCategory" runat="server"></asp:Label></td>
                        </tr>
                       
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                            名稱：</td>
                            <td align="left" height="20">
                            <asp:Label ID="lblName" runat="server"></asp:Label>&nbsp;
                            </td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td align="left" class="TH" style="width: 759px; height: 22px;">
                <b>產品顏色設定</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table border="0" cellpadding="0" cellspacing="0" style="width: 95%">
                    <tr>
                        <td align="right">
                            &nbsp;<img height="18" src="/Manager/image/icon-save.gif" width="14" />&nbsp;
                            <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click" ValidationGroup="AddColor">儲存</asp:LinkButton>&nbsp;</td>
                    </tr>
                </table>
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            顏色代碼：</td>
                        <td align="left">
                            &nbsp;<asp:DropDownList ID="ddlColor" runat="server">
                            </asp:DropDownList></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" valign="top" width="15%">
                            商品顏色圖檔：</td>
                        <td align="left">
                            &nbsp;<br />
                            上傳圖片：<uc1:uploadcontrol id="UploadControl1" runat="server" filecontrolwidth="60%"
                                filetyperange="jpg,gif" icon_validate_cross="image/icon_validate_cross.gif" icon_validate_spacer="image/icon_validate_Spacer.gif"
                                icon_validate_tick="image/icon_validate_Tick.gif" Required="true" ValidationGroup="AddColor"></uc1:uploadcontrol>
                            <br />
                            ◎圖檔格式JPG或GIF。
                            <br />
                            <br />
                        </td>
                    </tr>
                </table>
                <br />
                <p>
                    <asp:GridView ID="GridView1" runat="server"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="ColorID" OnRowCommand="GridView1_RowCommand"
                        OnRowDataBound="GridView_RowDataBound" OnRowDeleting="GridView1_RowDeleting" PageSize="15" Width="100%">
                        <Columns>
                            <asp:TemplateField HeaderText="顏色">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="20%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <img src="/img/product/color_<%# Eval("ColorCode") %>.gif">
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="圖檔">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="60%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# GetProductColorImage(Convert.ToString(Eval("ColorCode")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                           
                            <asp:TemplateField HeaderText="功 能">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" Width="20%" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    
                                    <img alt="" height="15" src="image/icon-delete.gif" width="14" /><asp:LinkButton
                                        ID="lbtnDelete" runat="server" CommandArgument='<%# Eval("ColorID") %>' CommandName="Delete">刪除</asp:LinkButton>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">尚無資料！</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="最前頁" LastPageText="最末頁" Mode="NumericFirstLast" NextPageText="下一頁"
                            PageButtonCount="5" PreviousPageText="上一頁" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </p>
            </td>
        </tr>
      
        <tr>
            <td align="center" class="Forumrow" style="width: 759px">
            </td>
        </tr>
    </table>
</asp:Content>

