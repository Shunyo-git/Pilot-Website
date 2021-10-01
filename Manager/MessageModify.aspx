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
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">�x�s��s</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">������^</asp:LinkButton></td>
        </tr>
    </table>
    <table id="table4" align="center" border="0" cellpadding="3" cellspacing="1" class="tableBorder"
        width="95%">
        <tr>
            <td id="tabletitlelink" align="left" class="TH" height="25" style="width: 759px">
                �ȪA�H��</td>
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
                                <asp:Label ID="lblID" runat="server">�s�W��۰ʲ���</asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                �B�z���A�G</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsDone" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">�w�B�z</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">�ݳB�z</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �ӫH�ɶ��G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblCreationDate" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �ӫHIP��}�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblIP" runat="server"></asp:Label></td>
                        </tr>
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �̫�B�z�ɶ��G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblUpdateDate" runat="server"></asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>�H�󤺮e</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <font face="�s�ө���">
                    <table id="Table1" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                        border-collapse: collapse" width="100%">
                        <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �m�W�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblName" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                Gender�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblGender" runat="server"> </asp:Label></td>
                        </tr>
                            <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                Birthday�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblBirthday" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                E-mail�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblEmail" runat="server"> </asp:Label></td>
                        </tr>
                             <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �p���q�ܡG</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblTelephone" runat="server"> </asp:Label></td>
                        </tr>
                          <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                ����G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblMobile" runat="server"> </asp:Label></td>
                        </tr>
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �Ʊ�^�Ф覡�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblContact" runat="server"> </asp:Label></td>
                        </tr>
                         
                         <tr>
                            <td align="right" class="ColumnTD" height="20" width="15%">
                                �N�����e�G</td>
                            <td align="left" height="20">
                                <asp:Label ID="lblContent" runat="server"> </asp:Label></td>
                        </tr>
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>�B�z�O�n</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                    
                    <tr>
                        <td align="right" class="ColumnTD" width="15%" style="height: 83px">
                            �ȪA�B�z�O���G</td>
                        <td align="left" style="height: 83px">
                            <asp:TextBox ID="txtNote" runat="server" Width="80%" Rows="5" TextMode="MultiLine"></asp:TextBox>
                            
                        </td>
                    </tr>
                     
                </table>
                <p>
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="�x�s���ѡA���ˬd�z����ƫ᭫�s�A�դ@���C"></asp:CustomValidator></p>
            </td>
        </tr>
    </table>
</asp:Content>
