<%@ Page Language="C#" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true" CodeFile="WallpaperDetail.aspx.cs" Inherits="Manager_WallpaperDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<table border="0" cellpadding="0" cellspacing="0" style="width: 759px">
        <tr>
            <td style="height: 22px">
            </td>
            <td align="right" style="height: 22px">
                <img src="/Manager/image/icon-edit.gif" width="17" height="15" />&nbsp;
                <asp:LinkButton ID="lbtnEdit" runat="server" OnClick="lbtnEdit_Click">�s��</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-delete.gif" width="14" height="15" />
                <asp:LinkButton ID="lbtnDelete" runat="server" OnClick="lbtnDelete_Click">�R��</asp:LinkButton>
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" /><asp:LinkButton ID="lbtnCancel" runat="server"
                    OnClick="lbtnCancel_Click">����</asp:LinkButton>&nbsp;</td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                �U���]�w</td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="�s�ө���">
                    <table id="Table2" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �۰ʽs���G</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblID" runat="server"></asp:Label></td>
                        </tr>
                       
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                ������ܡG</td>
                            <td align="left" height="20">
                                &nbsp;<asp:Label ID="lblIsDisplay" runat="server"></asp:Label></td>
                        </tr>
                        
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td align="left" class="TH" style="width: 759px; height: 22px;">
                <b>�U�����e</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    
                     <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            �W�١G</td>
                        <td align="left">
                            <asp:Label ID="lblName" runat="server"></asp:Label></td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                           �ʭ��Ϥ��G</td>
                        <td align="left">
                          <asp:Image ID="imgLogo" runat="server"   /> 
                        </td>
                    </tr>
                    <tr>
                        <td align="right" class="ColumnTD" style="width: 15%">
                            �ɮסG</td>
                        <td align="left">
                     �@
                            <asp:HyperLink ID="link800" runat="server" Target="_blank">800x600</asp:HyperLink> | <asp:HyperLink ID="link1024" runat="server" Target="_blank">1024x768</asp:HyperLink></td>
                    </tr>
                      
                </table>
                <br />
                <p>
                </p>
            </td>
        </tr>
      
        <tr>
            <td align="center" class="Forumrow" style="width: 759px">
            </td>
        </tr>
    </table>
</asp:Content>

