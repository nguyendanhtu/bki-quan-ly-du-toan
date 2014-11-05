<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F100_QuanLyNha.aspx.cs" Inherits="ChucNang_F100_QuanLyNha" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
<table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Quản lý nhà</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Bộ, tỉnh</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:DropDownList ID="m_ddl_bo_tinh" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Đơn vị chủ quản</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:DropDownList ID="m_ddl_don_vi_chu_quan" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Đơn vị sử dụng</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:DropDownList ID="DropDownList2" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Trạng thái nhà</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:DropDownList ID="m_ddl_trang_thai_nha" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Thuộc khu đất</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:DropDownList ID="DropDownList1" runat="server" Width="85%">
                            </asp:DropDownList>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Địa chỉ</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:Label ID="m_lbl_dia_chi" runat="server" Text=""></asp:Label>
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Tên tài sản</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_ten_dat" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_ten_dat" runat="server" ControlToValidate="m_txt_ten_dat"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Cấp hạng</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_cap_hang" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_cap_hang" runat="server" ControlToValidate="m_txt_cap_hang"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Năm xây dựng</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_nam_xd" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nam_xd" runat="server" ControlToValidate="m_txt_nam_xd"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Ngày, tháng, năm sử dụng</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_ngay_su_dung" runat="server" CssClass="cssTextBox" Width="85%"
                                TextMode="Date"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_ngay_su_dung" runat="server" ControlToValidate="m_txt_ngay_su_dung"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            GIÁ TRỊ THEO SỔ KẾ TOÁN
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Nguyên giá nguồn NS (VNĐ)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_nguyen_gia" runat="server" CssClass="cssTextBox csscurrency"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia" runat="server" ControlToValidate="m_txt_nguyen_gia"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Nguyên giá nguồn khác (VNĐ)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_nguyen_gia_nguon_khac" runat="server" CssClass="cssTextBox csscurrency"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_nguyen_gia_nguon_khac" runat="server" ControlToValidate="m_txt_nguyen_gia_nguon_khac"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Giá trị còn lại (VNĐ)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_gia_tri_con_lai" runat="server" CssClass="cssTextBox csscurrency"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_gia_tri_con_lai" runat="server" ControlToValidate="m_txt_gia_tri_con_lai"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 30%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <br />
                        </td>
                        <td style="width: 30%" align="left">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 30%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Số tầng</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_so_tang" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_so_tang" runat="server" ControlToValidate="m_txt_so_tang"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Diện tích xây dựng (m2)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_dien_tich_xay_dung" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_dien_tich_xay_dung" runat="server" ControlToValidate="m_txt_dien_tich_xay_dung"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Tổng diện tích sàn xây dựng (m2)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_tong_dien_tich_xay_dung" runat="server" CssClass="cssTextBox"
                                Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_tong_dien_tich_xay_dung" runat="server" ControlToValidate="m_txt_tong_dien_tich_xay_dung"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 30%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                        </td>
                        <td>
                            HIỆN TRẠNG SỬ DỤNG
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Trụ sở làm việc (m2)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_tru_so_lam_viec" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_tru_so_lam_viec" runat="server" ControlToValidate="m_txt_tru_so_lam_viec"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Cơ sở HĐSN (m2)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_co_so_hdsn" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_co_so_hdsn" runat="server" ControlToValidate="m_txt_co_so_hdsn"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Làm nhà ở (m2)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_lam_nha_o" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_lam_nha_o" runat="server" ControlToValidate="m_txt_lam_nha_o"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Cho thuê (m2)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_cho_thue" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_cho_thue" runat="server" ControlToValidate="m_txt_cho_thue"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Bỏ trống (m2)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_bo_trong" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_bo_trong" runat="server" ControlToValidate="m_txt_bo_trong"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Bị lấn chiếm (m2)</span>
                        </td>
                        <td align="left" style="width: 30%;">
                            <asp:TextBox ID="m_txt_bi_lan_chiem" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_bi_lan_chiem" runat="server" ControlToValidate="m_txt_bi_lan_chiem"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <span class="cssManField">Khác (m2)</span>
                        </td>
                        <td style="width: 30%" align="left">
                            <asp:TextBox ID="m_txt_khac" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                        </td>
                        <td align="left" style="width: 1%;">
                            (*)
                            <asp:RequiredFieldValidator ID="m_rfv_khac" runat="server" ControlToValidate="m_txt_khac"
                                ErrorMessage="Bạn phải nhập Mã Giảng viên" Text="*"></asp:RequiredFieldValidator>
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 30%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td align="right" style="width: 15%">
                            <br />
                        </td>
                        <td style="width: 30%" align="left">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                        <td align="right">
                        </td>
                        <td align="left" style="width: 30%;">
                        </td>
                        <td align="left" style="width: 1%;">
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                        <td colspan="4" align="left">
                            <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                                Width="98px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                            <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                                Width="98px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                            <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="cssButton" runat="server"
                                Width="98px" Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
                            <asp:HiddenField ID="hdf_id" runat="server" Value="" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <span class="cssPageTitle">Danh sách nhà</span> <span class="expand-collapse-text initial-expand">
                </span><span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%">
                <span class="cssManField">Từ khóa</span>
            </td>
            <td align="left" style="width: 30%">
                <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_tim_kiem" runat="server" AccessKey="s" CssClass="cssButton"
                    Height="24px" Text="Tìm kiếm" Width="98px" OnClick="m_cmd_tim_kiem_Click" />
            </td>
            <td align="left">
                <asp:Button ID="m_cmd_xuat_excel" runat="server" CausesValidation="False" CssClass="cssButton"
                    Height="25px" Text="Xuất Excel" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="right">
            </td>
            <td align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td align="left">
            </td>
            <td align="left">
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                <table border="1" cellspacing="0" cellpadding="0" width="100%" style="background-color: #810c15;
                    color: White; font-weight: bold; text-align: center; border-collapse: collapse;">
                    <tr>
                        <td rowspan="3" style="width: 2%;">
                            Xóa
                        </td>
                        <td rowspan="3" style="width: 2%;">
                            Sửa
                        </td>
                        <td rowspan="3" style="width: 14%;">
                            Tên tài sản
                        </td>
                        <td rowspan="3" style="width: 14%;">
                            Địa chỉ
                        </td>
                        <td rowspan="3" style="width: 4%;">
                            Cấp hạng
                        </td>
                        <td rowspan="3" style="width: 4%;">
                            Năm xây dựng
                        </td>
                        <td rowspan="3" style="width: 8%;">
                            Ngày, tháng, năm sử dụng
                        </td>
                        <td colspan="3" style="width: 12%;">
                            Giá trị theo sổ kế toán
                        </td>
                        <td rowspan="3" style="width: 4%;">
                            Số tầng
                        </td>
                        <td rowspan="3" style="width: 4%;">
                            Diện tích xây dựng (m2)
                        </td>
                        <td rowspan="3" style="width: 4%;">
                            Tổng diện tích xây dựng (m2)
                        </td>
                        <td colspan="7" style="width: 28%;">
                            Hiện trạng sử dụng (m2)
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2" style="width: 10%;">
                            Nguyên giá
                        </td>
                        <td rowspan="2" style="width: 4%;">
                            Giá trị còn lại
                        </td>
                        <td rowspan="2" style="width: 4%;">
                            Trụ sở làm việc
                        </td>
                        <td rowspan="2" style="width: 4%;">
                            Cơ sở HĐSN
                        </td>
                        <td colspan="5" style="width: 20%;">
                            Sử dụng khác
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 4%;">
                            Nguồn NS
                        </td>
                        <td style="width: 4%;">
                            Nguồn khác
                        </td>
                        <td style="width: 4%;">
                            Làm nhà ở
                        </td>
                        <td style="width: 4%;">
                            Cho thuê
                        </td>
                        <td style="width: 4%;">
                            Bỏ trống
                        </td>
                        <td style="width: 4%;">
                            Bị lấn chiếm
                        </td>
                        <td style="width: 4%;">
                            Khác
                        </td>
                    </tr>
                </table>
                <asp:GridView ID="m_grv_danh_sach_nha" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    Width="100%" DataKeyNames="ID" CellPadding="4" ForeColor="#333333" AllowSorting="True"
                    PageSize="15" ShowHeader="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Xóa" ItemStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
                                    OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img src="../Images/Button/deletered.png" alt="Delete" />
                                </asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Sửa" ImageUrl="../Images/Button/edit.png" ID="lbt_edit" runat="server"
                                    NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Chi tiết tài sản" Visible="false">
                            <ItemTemplate>
                                <asp:HyperLink ToolTip="Chi tiết tài sản" ImageUrl="../Images/Button/detail.png"
                                    ID="lbt_hop_dong_gv" runat="server" NavigateUrl=''></asp:HyperLink>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:HyperLinkField HeaderText="Tên tài sản" DataTextField="TEN_TAI_SAN" NavigateUrl=""/>
                        <asp:BoundField HeaderText="Địa chỉ" DataField=""/>
                        <asp:BoundField HeaderText="Cấp hạng" DataField="CAP_HANG"/>
                        <asp:BoundField HeaderText="Năm xây dựng" DataField="SO_NAM_DA_SU_DUNG"/>
                        <asp:BoundField HeaderText="Ngày, tháng, năm sử dụng" DataField="NAM_SU_DUNG"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%">
                                	<tr>
                                		<td colspan="3">Giá trị theo sổ kế toán</td>
                                	</tr>
                                    <tr>
                                        <td colspan="2">Nguyên giá</td>
                                        <td rowspan="2">Giá trị còn lại</td>
                                    </tr>
                                    <tr>
                                        <td>Nguồn NS</td>
                                        <td>Nguồn khác</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                            <HeaderStyle CssClass=""/>
                            <ItemTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td><%# Eval("NGUON_NS") %></td>
                                        <td><%# Eval("NGUON_KHAC") %></td>
                                        <td><%# Eval("GIA_TRI_CON_LAI") %></td>
                                	</tr>
                                </table>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Số tầng" DataField="SO_TANG"/>
                        <asp:BoundField HeaderText="DT xây dựng" DataField="DT_XAY_DUNG"/>
                        <asp:BoundField HeaderText="Tổng DT xây dựng" DataField="TONG_DT_SAN_XD"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="2" width="100%">
                                	<tr>
                                		<td colspan="7">Hiện trạng sử dụng (m2)</td>
                                	</tr>
                                    <tr>
                                        <td rowspan="2">Trụ sở làm việc</td>
                                        <td rowspan="2">Cơ sở HĐSN</td>
                                        <td colspan="5">Sử dụng khác</td>
                                    </tr>
                                    <tr>
                                        <td>Làm nhà ở</td>
                                        <td>Cho thuê</td>
                                        <td>Bỏ trống</td>
                                        <td>Bị lấn chiếm</td>
                                        <td>Khác</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

