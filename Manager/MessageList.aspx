<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="MessageList.aspx.cs" Inherits="Manager_MessageListList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table id="table1" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="790">
        <tr>
            <td id="tabletitlelink" align="left" class="TH">
                <b>�ȪA�H��C��</b>
            </td>
        </tr>
     <tr>
            <td align="right" class="Forumrow" style="height: 28px">
                <DIV align="left">�j�M�G 
                <asp:TextBox ID="txtKeyword" runat="server"></asp:TextBox><asp:Button ID="btnSearch"
                    runat="server" Text="�j�M" OnClick="btnSearch_Click" />
                    </DIV>
                �@<asp:Label ID="lblTotalCount" runat="server" Text="0"></asp:Label>��&nbsp;</td>
        </tr>
        <tr>
            <td class="Forumrow">
                <font face="�s�ө���">
                    <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True"
                        AutoGenerateColumns="False" BorderColor="White" BorderStyle="None" BorderWidth="0px"
                        CellPadding="1" CellSpacing="1" CssClass="tableBorder1" DataKeyNames="MsgID"
                        OnPageIndexChanging="GridView_PageIndexChanging" OnRowDataBound="GridView_RowDataBound"
                        OnSorting="GridView_Sorting" PageSize="15" Width="100%" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting">
                        <Columns>
                         <asp:TemplateField HeaderText="�w�B�z"  SortExpression="IsDone" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# DisplayBooleanIcon(Convert.ToBoolean(Eval("IsDone")))%>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField  HeaderText="�۰ʽs��" SortExpression="MsgID" >
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                                    <%# Eval("MsgID")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                          
                            <asp:BoundField DataField="Name" HeaderText="�m�W" SortExpression="Name">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="E-Mail" SortExpression="Email">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreationDate" HeaderText="�ӫH�ɶ�" SortExpression="CreationDate">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Left" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                            </asp:BoundField>
                            
                           
                          
                            <asp:TemplateField HeaderText="�\ ��">
                                <ItemStyle CssClass="Forumrow" HorizontalAlign="Center" />
                                <HeaderStyle CssClass="grid-header" ForeColor="#336600" />
                                <ItemTemplate>
                               
                                    <img alt="" src="image/icon-edit.gif" width="17" height="15" /><asp:HyperLink ID="linkModify" runat="server">�˵��s��</asp:HyperLink> 
                                    <img alt="" src="image/icon-delete.gif" width="14" height="15" /><asp:LinkButton ID="lbtnDelete" CommandName="Delete" runat="server" CommandArgument='<%# Eval("MsgID") %>' >�R��</asp:LinkButton>
                                     
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <RowStyle CssClass="ForumrowHighLight" />
                        <EmptyDataTemplate>
                            <asp:Label ID="Label10" runat="server" Text="Label">�L�ȪA�H���ơI</asp:Label>
                        </EmptyDataTemplate>
                        <HeaderStyle CssClass="ItemHeader" />
                        <PagerSettings FirstPageText="�̫e��" LastPageText="�̥���" Mode="NumericFirstLast"
                            NextPageText="�U�@��" PreviousPageText="�W�@��" />
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

