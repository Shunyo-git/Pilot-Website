<%@ Page Language="C#"  ValidateRequest="false" MasterPageFile="~/Manager/MasterPage/Admin_1.master" AutoEventWireup="true"
    CodeFile="WallpaperModify.aspx.cs" Inherits="Manager_WallpaperModify" %>
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
                <asp:LinkButton ID="lbtnSave" runat="server" OnClick="lbtnSave_Click">�x�s</asp:LinkButton>&nbsp;
                <img src="/Manager/image/icon-cancel.gif" width="18" height="18" />
                <asp:LinkButton ID="lbtnCancel" runat="server" OnClick="lbtnCancel_Click" CausesValidation="False">����</asp:LinkButton></td>
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
                                <asp:Label ID="lblID" runat="server">�s�W��۰ʲ���</asp:Label></td>
                        </tr>
                          
                        <tr>
                            <td align="right" class="ColumnTD" height="20">
                                ������ܡG</td>
                            <td align="left" height="20" class="ColumnTD">
                                <asp:RadioButtonList ID="rbtnIsApproved" runat="server" BorderStyle="None" RepeatDirection="Horizontal">
                                    <asp:ListItem Value="True">���</asp:ListItem>
                                    <asp:ListItem Selected="True" Value="False">�����</asp:ListItem>
                                </asp:RadioButtonList></td>
                        </tr>
                        
                    </table>
                    &nbsp;</font></td>
        </tr>
        <tr>
            <td class="TH" style="width: 759px" align="left">
                <b>�U�����e</b></td>
        </tr>
        <tr>
            <td align="right" class="Forumrow" style="width: 759px">
                <table id="Table6" border="1" cellspacing="0" class="Forumrow" rules="all" style="width: 100%;
                    border-collapse: collapse" width="100%">
                     
                    <tr>
                        <td align="right" class="ColumnTD" width="15%">
                            �W�١G</td>
                        <td align="left">
                            <asp:TextBox ID="txtName" runat="server" Width="70%" MaxLength="100"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValSubTitle" runat="server" ControlToValidate="txtName"
                                ErrorMessage="�W�٤���ť�" ToolTip="�W�٤���ť�"><img src="image/icon_validate_cross.gif" align="absmiddle" width="12" height="12" /></asp:RequiredFieldValidator><span
                                    style="color: #336600">(50�r�H��)</span></td>
                    </tr>
                     <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            �ʭ��Ϥ��G</td>
                        <td align="left">
                            
                                <asp:Image ID="imgLogo" runat="server"  /> <br />
                            �W�ǹϤ��G<uc1:UploadControl  ID="UploadControl1" runat="server" FileTypeRange="gif"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif"   MaxWidth="240"
                                 FileControlWidth="60%" />
                           <br />
                                �����ɮ榡GIF�C <br /><br />
                         
                        </td>
                    </tr>
                       <tr>
                        <td align="right" class="ColumnTD" width="15%" valign="top">
                            �U���ɮסG</td>
                        <td align="left">
                            
                                 <asp:HyperLink ID="link800" runat="server" Target="_blank">800x600</asp:HyperLink> | <asp:HyperLink ID="link1024" runat="server" Target="_blank">1024x768</asp:HyperLink> <br /> <br />
                            800x600�Ϥ��W�ǡG<uc1:UploadControl  ID="UploadControl2" runat="server" FileTypeRange="jpg,jpeg"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif"  MaxWidth="800" MinWidth="800"  MaxHeight="600" MinHeight="600" 
                                 FileControlWidth="60%" />
                           <br />
                              1024x768�Ϥ��W�ǡG<uc1:UploadControl  ID="UploadControl3" runat="server" FileTypeRange="jpg,jpeg"
                                Icon_Validate_Cross="image/icon_validate_cross.gif" Icon_Validate_Spacer="image/icon_validate_Spacer.gif"
                                Icon_Validate_Tick="image/icon_validate_Tick.gif"   MaxWidth="1024" MinWidth="1024"  MaxHeight="768" MinHeight="768" 
                                 FileControlWidth="60%" />
                           <br />
                               �����ɮ榡JPG��GIF�C <br /><br />
                         
                        </td>
                    </tr>
                </table>
                <p>
                    
                    <asp:CustomValidator ID="ValidatorResult" runat="server" ErrorMessage="�x�s���ѡA���ˬd�z����ƫ᭫�s�A�դ@���C"></asp:CustomValidator>&nbsp;</p>
            </td>
        </tr>
    </table>
</asp:Content>