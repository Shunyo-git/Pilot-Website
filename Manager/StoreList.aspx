<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="StoreList.aspx.cs" Inherits="Admin_StoreList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>店家列表</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
           
                 <table border="0" cellpadding="0" cellspacing="0" class="Forumrow" style="width: 100%">
                     <tr>
                         <td>
                             地區分類：
                    <asp:DropDownList ID="ddlArea" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlArea_SelectedIndexChanged">
                     <asp:ListItem Value="0">所有地區</asp:ListItem>
                     <asp:ListItem Value="1">台北市</asp:ListItem>
                    
                                <asp:ListItem Value="2">台北縣基隆</asp:ListItem>
                                <asp:ListItem Value="3">桃竹苗地區</asp:ListItem>
                                <asp:ListItem Value="4">中彰投雲地區</asp:ListItem>
                                <asp:ListItem Value="5">嘉南高屏</asp:ListItem>
                                <asp:ListItem Value="6">宜花東</asp:ListItem>
                    </asp:DropDownList></td>
                         <td align="right" style="height: 16px">
                             <img height="9" src="image/nav.gif" width="9" />
                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">新增店家</asp:LinkButton></td>
                     </tr>
                     <tr>
                         <td>
                         </td>
                         <td align="right">
                             共
                             <asp:Label ID="lblRowCount" runat="server"></asp:Label>
                             筆</td>
                     </tr>
                 </table>
           
            
                </td>
        </tr>
        <tr>
            <td class="Forumrow">
                <font face="新細明體">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="ID"
                        OnPageIndexChanging="GridView_PageIndexChanging" OnRowDataBound="GridView_RowDataBound"
                        OnSorting="GridView_Sorting" PageSize="15" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="自動編號" SortExpression="ID">
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                          
                             <asp:TemplateField HeaderText="區域"  SortExpression="AreaID">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# Eval("AreaName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="StoreName" HeaderText="名稱" SortExpression="StoreName">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                           
                            <asp:TemplateField HeaderText="網站顯示"  SortExpression="IsDisplay" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# IsWebDisplay(Convert.ToBoolean(Eval("IsDisplay")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="排列序號">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                
                                    <asp:ImageButton ID="ibtnUP"  AlternateText="往上移動" CommandName="SortUp" ImageUrl="image/icon-up.gif"  runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                     <%# Eval("SortID")%>
                                    <asp:ImageButton ID="ibtnDOWN" AlternateText="往下移動"  CommandName="SortDown" ImageUrl="image/icon-down.gif" runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="功 能">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                
                                    <img alt="" src="image/icon-view.gif" width="15" height="15" /><asp:HyperLink ID="linkView" runat="server">檢視</asp:HyperLink>  
                                    <img alt="" src="image/icon-edit.gif" width="17" height="15" /><asp:HyperLink ID="linkModify" runat="server">編輯</asp:HyperLink> 
                                    <img alt="" src="image/icon-delete.gif" width="14" height="15" /><asp:LinkButton ID="lbtnDelete" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID") %>' >刪除</asp:LinkButton>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">無資料！</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="最前頁" LastPageText="最末頁" Mode="NumericFirstLast"
                            NextPageText="下一頁" PreviousPageText="上一頁" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </font>
            </td>
        </tr>
        <tr>
            <td class="Forumrow" style="height: 30px">
                <font face="新細明體"></font><font face="新細明體" style="background-color: #ffffff"></font>
                &nbsp;<br />
            </td>
        </tr>
    </table>
</asp:Content>

