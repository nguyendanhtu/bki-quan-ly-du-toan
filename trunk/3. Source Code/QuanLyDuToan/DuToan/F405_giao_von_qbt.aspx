﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F405_giao_von_qbt.aspx.cs" Inherits="DuToan_F405_giao_von" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" Text="Cập nhật thông tin dự án, quốc lộ" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="m_pnl_thong_tin_ve_qd_giao_von" GroupingText="Thông tin về QĐ giao vốn" runat="server">
                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                <tr>
                                    <td style="width: 15%" align="right">
                                        <span class="cssManField">Số QĐ</span>
                                    </td>
                                    <td style="width: 85%">
                                        <asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="cssTextBox" Width="20%"></asp:TextBox>
                                        <asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" Width="30%"></asp:DropDownList>
                                        <asp:Button ID="m_cmd_chon_qd_da_nhap" Text="Chọn QĐ đã nhập" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><span class="cssManField">Nội dung</span></td>
                                    <td>
                                        <asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" Width="50%" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><span class="cssManField">Ngày tháng</span></td>
                                    <td>
                                        <asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox" Width="20%" placeholder="dd/MM/yyyy"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="1" align="left">
                                        <asp:Button ID="m_cmd_luu_qd" Text="Lưu QĐ" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                        <asp:Button ID="m_cmd_nhap_qd_moi" Text="Nhập QĐ mới" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="m_pnl" runat="server" GroupingText="Chi tiết">
                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                <tr>
                                    <td style="width: 15%"></td>
                                    <td colspan="2" align="left">
                                        <asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" CssClass="cssManField" ForeColor="Blue" Text="KH đầu năm" GroupName="loai" Checked="true" />
                                        <asp:RadioButton ID="m_rdb_bo_sung" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Bổ sung" GroupName="loai" />
                                        <asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Điều chỉnh" GroupName="loai" />
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td style="width: 42.5%">
                                        <asp:Panel ID="m_pnl_chi_thuong_xuyen" runat="server" GroupingText="Chi thường xuyên">
                                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Tuyến quốc lộ</span>
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:DropDownList ID="m_ddl_ctx_tuyen_quoc_lo" runat="server" Width="50%"></asp:DropDownList>
                                                        <asp:Button ID="m_cmd_ctx_them_ql" Text="Thêm QL" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                    </td>
                                                </tr>
                                                
                                                    <tr><td style="width: 30%" align="right">
                                                    <span class="cssManField">Số tiền</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="TextBox1" runat="server" CssClass="cssTextBox" Width="60%" placeholder="Số tiền"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr> <td style="width: 30%" align="right">
                                                    <span class="cssManField">Số tiền KH giao</span>
                                                    </td>
                                                    <td><asp:Label ID="m_lbl_ctx_so_tien_kh_giao" runat="server" ForeColor="blue"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Nguồn</span>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="m_rdb_ctx_quy_bao_tri" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Quỹ bảo trì" GroupName="loai1" Checked="true" />
                                                        <asp:RadioButton ID="m_rdb_ctx_ngan_sach" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Ngân sách" GroupName="loai1" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="m_cmd_ctx_them" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                        <asp:Button ID="m_cmd_ctx_cap_nhat" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                        <asp:Button ID="m_cmd_ctx_xoa_trang" Text="Xóa Trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                    </td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 42.5%">
                                        <asp:Panel ID="m_pnl_chi_khong_thuong_xuyen" runat="server" GroupingText="Chi không thường xuyên">
                                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Tên dự án</span>
                                                    </td>
                                                    <td style="width: 70%">
                                                        <asp:DropDownList ID="m_ddl_cktx_du_an" runat="server" Width="50%"></asp:DropDownList>


                                                    </td>
                                                </tr>
                                                <tr><td style="width: 30%" align="right">
                                                    <span class="cssManField">Số tiền</span>
                                                    </td>
                                                    <td>
                                                        <asp:TextBox ID="m_txt_cktx_so_tien" runat="server" CssClass="cssTextBox" Width="50%" placeholder="Số tiền" ></asp:TextBox>
                                                    </td>
                                                </tr>
                                                <tr> <td style="width: 30%" align="right">
                                                    <span class="cssManField">Số tiền KH giao</span>
                                                    </td>
                                                    <td><asp:Label ID="m_lbl_cktx_so_tien_KH_giao" runat="server" ForeColor="blue"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Nguồn</span>
                                                    </td>
                                                    <td>
                                                        <asp:RadioButton ID="m_rdb_cktx_quy_bao_tri" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Quỹ bảo trì" GroupName="loai2" checked="true"/>
                                                        <asp:RadioButton ID="m_rdb_cktx_ngan_sach" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Ngân sách" GroupName="loai2" />
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="m_cmd_cktx_them" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                        <asp:Button ID="m_cmd_cktx_cap_nhat" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                                        <asp:Button ID="m_cmd_cktx_xoa_trang" Text="Xóa Trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
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
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_grid_title" runat="server" Text="Danh sách dự án, quốc lộ" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td style="width:30%" align="right">
                        <span class="cssManField">Từ khóa</span>
                    </td>
                    <td style="width:40%">    
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="60%" ></asp:TextBox>
                    </td><td align="left">
                        <asp:Button ID="m_cmd_tim_kiem" Text="Tìm kiếm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                    </td>
                    <td style="width=20%" align="right">
                        <asp:Button ID="m_cmd_xem_bao_cao_du_toan" Text="Xem báo cáo dự toán" runat="server" CssClass="cssButton" Height="24px" Width="130px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
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
                                <asp:TemplateField HeaderText="Xóa"  HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbt_delete" runat="server" CausesValidation="false"
                                            CommandName="Delete" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sửa"  HeaderStyle-Width="2%">
                                    <ItemTemplate>
                                        <asp:LinkButton ID="lbt_delete" runat="server" CausesValidation="false"
                                            CommandName="Update" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
                                        </asp:LinkButton>
                                    </ItemTemplate>
                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ten_don_vi" HeaderText="Đơn vị" />
                                <asp:BoundField DataField="ten_du_an" HeaderText="Tên dự án, công trình" />
                                <asp:BoundField DataField="ghi_chu" HeaderText="Ghi chú" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />--%>
        </Triggers>
    </asp:UpdatePanel>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
        <ProgressTemplate>
            <div class="cssLoadWapper">
                <div class="cssLoadContent">
                    <img src="../Images/loadingBar.gif" alt="" />
                    <p>
                        Đang gửi yêu cầu, hãy đợi ...
                    </p>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
