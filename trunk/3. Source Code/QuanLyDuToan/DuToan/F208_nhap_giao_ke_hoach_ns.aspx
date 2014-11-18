﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F208_nhap_giao_ke_hoach_ns.aspx.cs" Inherits="DuToan_f209_giao_von_ns" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 76%;
        }
        .auto-style2 {
            width: 133%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG">
                <asp:Label ID="m_lbl_title_nhap_giao_ke_hoach" runat="server" Text="Nhập Giao kế hoạch" CssClass="cssPageTitle"></asp:Label>
                <span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="m_pnl_thong_tin_qd_ve_ke_hoach" GroupingText="Thông tin về QĐ giao kế hoạch" runat="server" ForeColor="Black">
                    <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                        <tr>
                            <td style="width: 25%" align="right">
                                <span class="cssManField">Số QĐ</span>
                            </td>
                            <td style="width: 75%">
                                <asp:TextBox ID="m_txt_so_qd" runat="server" placeholder="Vd: 371/QĐ-BGTVT" CssClass="cssTextBox" Width="31%"></asp:TextBox>
                                <asp:DropDownList ID="m_ddl_so_qd" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
                                <asp:Button ID="m_cmd_chon_qd_da_nhap" runat="server" CssClass="cssButton" Text="Chọn QĐ đã nhập" Height="24px" Width="98px" />

                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Nội dung</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_noi_dung" runat="server" placeholder="Vd: 371/QĐ-BGTVT" CssClass="cssTextBox" Width="50%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Ngày tháng</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_ngay_thang" runat="server" placeholder="Vd: 371/QĐ-BGTVT" CssClass="cssTextBox" Width="31%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="m_cmd_luu_qd" runat="server" CssClass="cssButton" Text="Lưu QĐ" Height="24px" Width="98px" />
                                <asp:Button ID="m_cmd_nhap_qd_moi" runat="server" CssClass="cssButton" Text="Nhập QĐ mới" Height="24px" Width="98px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="m_pnl_chi_tiet" GroupingText="Chi tiết" runat="server" ForeColor="Black">
                    <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                        <tr>
                            <td style="width:15%"></td>
                            <td>
                             <asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" CssClass="cssManField" ForeColor="Black" Text="KH đầu năm" GroupName="loai" Checked="true" />
                             <asp:RadioButton ID="m_rdb_bo_sung" runat="server" CssClass="cssManField" ForeColor="Black" Text="Bổ sung" GroupName="loai" />
                             <asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" CssClass="cssManField" ForeColor="Black" Text="Điều chỉnh" GroupName="loai"  />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Panel ID="m_pnl_chon_muc_khoan_chi" GroupingText="Chọn mục khoản chi" runat="server" ForeColor="Blue">
                                    <table style="width:99%">
                                        <tr>
                                            <td style="width:30%" align="right" >
                                                <span class="cssManField">Chương</span>
                                            </td>
                                            <td style="width:30%">
                                                <asp:DropDownList ID="m_ddl_chuong" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
                                            </td>
                                            <td style="width:10%" align="right">
                                                <span class="cssManField">Loại</span>
                                            </td>
                                            <td style="width:35%">
                                                <asp:DropDownList ID="m_ddl_loai" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%" align="right" >
                                                <span class="cssManField">Khoản</span>
                                            </td>
                                            <td style="width:30%">
                                                <asp:DropDownList ID="m_ddl_khoan" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
                                            </td>
                                            <td style="width:10%" align="right">
                                                <span class="cssManField">Mục</span>
                                            </td>
                                            <td style="width:30%">
                                                <asp:DropDownList ID="m_ddl_muc" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%" align="right">
                                                <span class="cssManField">Số tiền</span>
                                            </td>
                                            <td >

                                                <asp:TextBox ID="m_txt_so_tien" runat="server" CssClass="cssTextBox" placeholder="Số tiền" Width="50%"></asp:TextBox>

                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%" align="right">
                                                <span class="cssManField">Nguồn</span>
                                            </td>
                                            <td>
                                                <asp:RadioButton ID="m_cmd_quy_bao_tri" runat="server" CssClass="cssManField" ForeColor="Black" Text="Quỹ bảo trì" GroupName="loai" Checked="true" />
                                                <asp:RadioButton ID="m_cmd_ngan_sach" runat="server" CssClass="cssManField" ForeColor="Black" Text="Ngân sách" GroupName="loai" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:30%"></td>
                                            
                                            <td >

                                                <asp:Button ID="m_cmd_them" runat="server" CssClass="cssButton" Height="24px" Text="Thêm" Width="98px" />
                                                <asp:Button ID="m_cmd_cap_nhat" runat="server" CssClass="cssButton" Height="24px" Text="Cập nhật" Width="98px" />
                                                <asp:Button ID="m_cmd_xoa_trang" runat="server" CssClass="cssButton" Height="24px" Text="Xóa trắng" Width="98px" />

                                            </td>
                                        </tr>
                                    </table>
                                    
                                </asp:Panel>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="m_lbl_title_chi_tiet_giao_ke_hoach" runat="server" Text="Chi tiết Giao kế hoạch" CssClass="cssPageTitle"></asp:Label>
                <span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width:20%">
                <span class="cssManField">Từ khóa</span>
            </td >
            <td style="width:50%">
                <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="40%" placeholder="Nội dung chi"></asp:TextBox>
                <asp:Button ID="m_cmd_tim_kiem" runat="server" CssClass="cssButton" Height="24px" Text="Tìm kiếm" Width="98px" />

            </td>
            <td style="width:30%" align="right">
                <asp:Button ID="m_cmd_xem_bao_cao_du_toan" runat="server" CssClass="cssButton" Height="24px" Text="Xem báo cáo dự toán"  />
            </td>
        </tr>
        <tr>
            <td colspan="3" align="center">
                <asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                            AllowSorting="True" PageSize="30" ShowHeader="true"
                            EmptyDataText="Không có dữ liệu phù hợp">
                            <AlternatingRowStyle BackColor="White" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                            <PagerSettings Position="TopAndBottom" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                            <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                                ForeColor="#333333"></SelectedRowStyle>
                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbt_delete" runat="server" CausesValidation="false"
                                            CommandName="Delete" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbt_delete" runat="server" CausesValidation="false"
                                            CommandName="Update" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="nam_du_toan" HeaderText="Năm dự toán" />
                                <asp:BoundField DataField="lan" HeaderText="Lần" />
                                <asp:BoundField DataField="du_an_cong_trinh" HeaderText="Công trình, dự án" />
                                <asp:BoundField DataField="so_tien" HeaderText="Số tiền" />
                                <asp:BoundField DataField="loai_du_an" HeaderText="Loại dự án" />
                                <asp:BoundField DataField="quyet_dinh" HeaderText="Quyết định" />
                            </Columns>
                        </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>
