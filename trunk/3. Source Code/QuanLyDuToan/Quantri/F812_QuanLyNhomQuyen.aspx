<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F812_QuanLyNhomQuyen.aspx.cs" Inherits="Quantri_F812_QuanLyNhomQuyen" %>

<%@ Register Assembly="eWorld.UI" Namespace="eWorld.UI" TagPrefix="ew" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 19px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Quản lý các nhóm người sử dụng" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                &nbsp;
            </td>
            <td style="width: 30%;">
                &nbsp;
            </td>
            <td style="width: 5%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <asp:Label ID="m_lbl_ten_nhom_quyen" CssClass="cssManField" runat="server" Text="Tên nhóm người sử dụng" />
            </td>
            <td style="width: 30%;">
                <asp:TextBox ID="m_txt_ten_nhom_quyen" CssClass="cssTextBox" CausesValidation="false"
                    runat="server" MaxLength="64" Width="495px" />
                &nbsp;
            </td>
            <td style="width: 5%;">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lbl_mo_ta" CssClass="cssManField" runat="server" Text="Mô tả" />
            </td>
            <td valign="top" colspan="2">
                <asp:TextBox ID="m_txt_mo_ta" runat="server" TextMode="MultiLine" Width="495px" Height="83px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td valign="top" colspan="2">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                    Width="98px" Height="25px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                    Width="98px" Height="25px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click1" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                    Height="25px" Text="Xóa trắng(r)" OnClick="btnCancel_Click" />
                <asp:HiddenField ID="hdf_id" runat="server" Value="" />
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" Text="Danh sách các nhóm người sử dụng" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label1" Visible="true" runat="server" CssClass="cssManField">Tìm kiếm nhóm người sử dụng</asp:Label>
            </td>
            <td>
                <asp:TextBox ID="m_txt_search_key" CssClass="cssTextBox" CausesValidation="false"
                    runat="server"  Width="495px" />
                <asp:Button ID="m_cmd_tim_kiem" AccessKey="c" CssClass="cssButton" runat="server" Width="98px"
                    Height="25px" Text="Tìm kiếm" OnClick="m_cmd_tim_kiem_Click" />
            </td>
            <td>
                
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                &nbsp;
                <asp:GridView ID="m_grv_dm_nhom_quyen_he_thong" AllowPaging="True" runat="server"
                    AutoGenerateColumns="False" Width="70%" DataKeyNames="ID" OnRowDeleting="m_grv_dm_nhom_quyen_he_thong_RowDeleting"
                    OnSelectedIndexChanging="m_grv_dm_nhom_quyen_he_thong_SelectedIndexChanging"
                    CellPadding="4" ForeColor="#333333" AllowSorting="True" OnPageIndexChanging="m_grv_dm_nhom_quyen_he_thong_PageIndexChanging">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
                                    CausesValidation="false" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                                    <img src="../Images/Button/deletered.png" alt="Delete" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbt_update" runat="server" CausesValidation="false" CommandName="Select"
                                    ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center" Width="10%"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="USER_GROUP_NAME" HeaderText="Tên nhóm ngưởi sử dụng" ItemStyle-Width="35%"
                            ItemStyle-HorizontalAlign="Left"></asp:BoundField>
                        <asp:BoundField DataField="DESCRIPTION" HeaderText="Mô tả" ItemStyle-Width="45%"
                            ItemStyle-HorizontalAlign="Left" />
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
