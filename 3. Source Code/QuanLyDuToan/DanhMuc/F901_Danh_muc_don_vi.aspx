<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F901_danh_muc_don_vi.aspx.cs" Inherits="DanhMuc_F901_danh_muc_don_vi" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .style1
        {
            height: 24px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 100%" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <asp:Label ID="m_lbl_title" runat="server" CssClass="cssManField" ForeColor="White" />
                        &nbsp;<span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_dm_don_vi" />
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Mã đơn vị:</span>
                    </td>
                    <td style="width: 34%">
                        <asp:TextBox ID="m_txt_ma_don_vi" CssClass="cssTextBox" runat="server" MaxLength="25"
                            Width="90%" />
                    </td>
                    <td style="width: 1%">
                        <asp:RequiredFieldValidator runat="Server" ID="m_rfv_ma_don_vi" Text="(*)" ControlToValidate="m_txt_ma_don_vi"
                            ErrorMessage="Bạn phải nhập Mã Đơn Vị!" ValidationGroup="m_vlg_dm_don_vi"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right" style="width: 15%">
                        <span class="cssManField">Loại đơn vị:</span>
                    </td>
                    <td style="width: 34%">
                        <asp:DropDownList ID="m_cbo_loai_don_vi" class="cssDorpdownlist" runat="server" Width="91%" />
                    </td>
                    <td style="width: 1%">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Tên đơn vị:</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_ten_don_vi" CssClass="cssTextBox" runat="server" MaxLength="50"
                            Width="90%" />
                    </td>
                    <td style="width: 1%">
                        <asp:RequiredFieldValidator ID="m_rfv_ten_don_vi" runat="Server" ControlToValidate="m_txt_ten_don_vi"
                            ValidationGroup="m_vlg_dm_don_vi" ErrorMessage="Bạn phải nhập Tên Đơn Vị!" Text="(*)"></asp:RequiredFieldValidator>
                    </td>
                    <td align="right">
                        <asp:Label ID="m_lbl_don_vi_cap_tren" class="cssManField" runat="Server" Text="Đơn vị cấp trên"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_cap_tren" runat="server" Width="91%" CssClass="cssDorpdownlist"
                            AutoPostBack="true" />
                    </td>
                    <td style="width: 1%">
                    </td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Loại hình đơn vị:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="server" Width="91%" CssClass="cssDorpdownlist"
                            AutoPostBack="false" />
                    </td>
                </tr>
                <tr>
                    <td align="center" colspan="4">
                        <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                            Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" Height="24px" />&nbsp;
                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                            Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" Height="24px" />&nbsp;
                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                            Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" Height="24px" />
                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="6">
                        <asp:Label ID="m_lbl_thong_tin_don_vi" runat="server" CssClass="cssManField" ForeColor="White" />
                        &nbsp;<span class="expand-collapse-text initial-expand"></span><span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td align="left">
                        <asp:Label ID="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
                    </td>
                    <td>
                        &nbsp;
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:TextBox ID="m_txt_tim_kiem" runat="server" Width="200px" CssClass="cssTextBox"></asp:TextBox>
                        &nbsp;
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" Text="Tìm kiếm" CssClass="cssButton"
                            Height="24px" Width="98px" CausesValidation="false" OnClick="m_cmd_tim_kiem_Click" />
                    </td>
                </tr>
                <tr>
                    <td colspan="2" align="center">
                        <asp:HiddenField ID="m_hdf_id_don_vi" runat="server" Visible="False" />
                        <asp:HiddenField ID="m_hdf_form_mode" runat="server" Visible="False" />
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:GridView ID="m_grv_dm_don_vi" runat="server" AutoGenerateColumns="False" Width="80%"
                            DataKeyNames="ID" AllowPaging="True" PageSize="50" CellPadding="4" ForeColor="#333333"
                            CssClass="cssGrid" OnRowDeleting="m_grv_dm_don_vi_RowDeleting" OnPageIndexChanging="m_grv_dm_don_vi_PageIndexChanging"
                            OnRowUpdating="m_grv_dm_don_vi_RowUpdating">
                            <PagerSettings Position="TopAndBottom" />
                            <AlternatingRowStyle BackColor="White" />
                            <Columns>
                                <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
                                            OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">



                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                

                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField SelectText="Sửa" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"
                                    Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:CommandField>
                                <asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="3%">
                                    <ItemTemplate>
                                        <asp:LinkButton ToolTip="Sửa" ID="m_lbt_edit" CommandName="Update" runat="server">

                                <img src="../Images/Button/edit.png" alt="Update" align="middle"/>
                                        

                                        </asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %></ItemTemplate>
                                    <HeaderStyle Width="15px" />
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="MA_DON_VI" ItemStyle-HorizontalAlign="Center" HeaderText="Mã đơn vị">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TEN_DON_VI" HeaderText="Tên đơn vị"></asp:BoundField>
                                <asp:TemplateField HeaderText="Loại hình đơn vị">
                                    <ItemTemplate>
                                        <%#get_ten_loai_hinh_don_vi(Eval("LOAI_HINH_DON_VI").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đơn vị cấp trên">
                                    <ItemTemplate>
                                        <%#get_ten_don_vi_cap_tren(Eval("ID_DON_VI_CAP_TREN"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center"
                                    Visible="False">
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:CommandField>
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
