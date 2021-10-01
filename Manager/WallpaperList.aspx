<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="WallpaperList.aspx.cs" Inherits="Admin_WallpaperList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>�U���C��</b>
            </td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="height: 28px">
           
                 <table border="0" cellpadding="0" cellspacing="0" class="Forumrow" style="width: 100%">
                     <tr>
                         <td>
                             </td>
                         <td align="right" style="height: 16px">
                             <img height="9" src="image/nav.gif" width="9" />
                <asp:LinkButton ID="lbtnNew" runat="server" OnClick="lbtnNew_Click">�s�W�U��</asp:LinkButton></td>
                     </tr>
                     <tr>
                         <td>
                         </td>
                         <td align="right">
                             �@
                             <asp:Label ID="lblRowCount" runat="server"></asp:Label>
                             ��</td>
                     </tr>
                 </table>
           
            
                </td>
        </tr>
        <tr>
            <td class="Forumrow">
                <font face="�s�ө���">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="ID"
                        OnPageIndexChanging="GridView_PageIndexChanging" OnRowDataBound="GridView_RowDataBound"
                        OnSorting="GridView_Sorting" PageSize="15" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="�۰ʽs��" SortExpression="ID">
                                <ItemStyle CssClass="Forumrow" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                          
                             <asp:TemplateField HeaderText="�ʭ�"  >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                  <img src="/Upload/Download/<%#Eval("ID")%>.gif" width="50">
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:BoundField DataField="Caption" HeaderText="�W��" SortExpression="Caption">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                           
                            <asp:TemplateField HeaderText="�������"  SortExpression="IsDisplay" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# IsWebDisplay(Convert.ToBoolean(Eval("IsDisplay")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                          <asp:TemplateField HeaderText="�ƦC�Ǹ�">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                
                                    <asp:ImageButton ID="ibtnUP"  AlternateText="���W����" CommandName="SortUp" ImageUrl="image/icon-up.gif"  runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                     <%# Eval("SortID")%>
                                    <asp:ImageButton ID="ibtnDOWN" AlternateText="���U����"  CommandName="SortDown" ImageUrl="image/icon-down.gif" runat="server" CommandArgument='<%# Eval("ID") %>'/>
                                   
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="�\ ��">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                
                                    <img alt="" src="image/icon-view.gif" width="15" height="15" /><asp:HyperLink ID="linkView" runat="server">�˵�</asp:HyperLink>  
                                    <img alt="" src="image/icon-edit.gif" width="17" height="15" /><asp:HyperLink ID="linkModify" runat="server">�s��</asp:HyperLink> 
                                    <img alt="" src="image/icon-delete.gif" width="14" height="15" /><asp:LinkButton ID="lbtnDelete" CommandName="Delete" runat="server" CommandArgument='<%# Eval("ID") %>' >�R��</asp:LinkButton>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">�L��ơI</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="�̫e��" LastPageText="�̥���" Mode="NumericFirstLast"
                            NextPageText="�U�@��" PreviousPageText="�W�@��" PageButtonCount="5" />
                        <PagerStyle HorizontalAlign="Center" />
                    </asp:GridView>
                </font>
            </td>
        </tr>
        <tr>
            <td class="Forumrow" style="height: 30px">
                <font face="�s�ө���"></font><font face="�s�ө���" style="background-color: #ffffff"></font>
                &nbsp;<br />
            </td>
        </tr>
    </table>
</asp:Content>

