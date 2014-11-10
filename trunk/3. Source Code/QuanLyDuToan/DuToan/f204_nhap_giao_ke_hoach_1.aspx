<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f204_nhap_giao_ke_hoach_1.aspx.cs" Inherits="DuToan_f204_nhap_giao_ke_hoach_1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" Runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" Runat="Server">
    <contentTemplate>
        <table cellpadding="2" cellspacing="0" style="width:99%" class="cssTable">
            <tr>
                <td class="cssPageTitleBG" colspan="4">
                    <asp:Label ID="m_lbl_title" runat="server" Text="Nhập Giao dự án" CssClass="cssPageTitle"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td class="cssPageTitleBG" colspan="4">
                    <asp:Label ID="m_lbl_title_chi_tiet_giao_ke_hoach" runat="server" Text="Chi tiết Giao kế hoạch" CssClass="cssPageTitle"></asp:Label>
                    
                </td>
            </tr>
            <tr>
                <td style="width:10%"></td>
                <td colspan="3">
                    <asp:Panel ID="m_pnl_gd_ke_hoach" runat="server" GroupingText="Thông tin về GD giao kế hoạch" Width="90%">
                        <table>
                            <tr>
                                <td style="width:20%" align="right">
                                    <span class="cssManField">Số QĐ</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="m_txt_so_qd" CssClass="cssTextBox" runat="server" Text="VD: 371/QĐ-BGTVT" Width="258px"></asp:TextBox>
                                    <asp:DropDownList ID="m_ddl_so_qd" runat="server"></asp:DropDownList>
                                    <asp:Button ID="m_cmd_chon_gd_da_cap_nhat" runat="server" Text="Chọn QĐ đã cập nhật" Width="157px"></asp:Button>
                                 </td>
                               
                            </tr>
                            <tr>
                                <td align="right" style="width:25%">
                                    <span class="cssManField">Nội dung</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="m_txt_noi_dung" CssClass="cssTextBox" runat="server" Text="VD: 371/QĐ-BGTVT"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width:25%">
                                    <span class="cssManField">Ngày tháng</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="TextBox3" CssClass="cssTextBox" runat="server" Text="VD: 371/QĐ-BGTVT"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:25%"></td>
                                <td>
                                    <asp:Button ID="m_cmd_update" Text="Lưu QĐ" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                   <asp:Button ID="m_cmd_insert" Text="Nhập QĐ mới" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                </td>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td style="width:10%"></td>
                <td colspan="3">
                    <asp:Panel ID="m_pnl_chi_tiet" runat="server" GroupingText="Chi tiết" Width="80%">
                        <asp:RadioButton ID="m_rdo_kh_dau_nam" runat="server" Text="KH đầu năm" />
                        <asp:RadioButton ID="m_rdo_bo_sung" runat="server" Text="Bổ sung" />
                        <asp:RadioButton ID="m_rdo_dieu_chinh" runat="server" Text="Điều chỉnh" />
                        
                        <asp:Panel ID="m_pnl_chi_thuong_xuyen" runat="server" GroupingText="Chi thường xuyên" Width="45%">
                            <table>
                            <tr>
                                <td style="width:20%" align="right">
                                    <span class="cssManField">Tuyến quốc lộ</span>
                                </td>
                                <td>
                                    
                                    <asp:DropDownList ID="m_ddl_tuyen_quoc_lo" CssClass="cssDorpdownlist" runat="server"></asp:DropDownList>
                                    <asp:Button ID="m_cmd_them_quoc_lo" runat="server" Text="Thêm QL" CssClass="cssButton" Width="98px"></asp:Button>
                                 </td>
                               
                            </tr>
                            <tr>
                                <td align="right" style="width:25%">
                                    <span class="cssManField">Số tiền</span>
                                </td>
                                <td>
                                    <asp:TextBox ID="m_txt_so_tien" CssClass="cssTextBox" runat="server" Text="Số tiền"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td align="right" style="width:25%">
                                    <span class="cssManField">Nguồn</span>
                                </td>
                                <td>
                                    <asp:RadioButton ID="m_rdo_quy_bao_tri" CssClass="cssTextBox" runat="server" Text="Quỹ bảo trì"></asp:RadioButton>
                                    <asp:RadioButton ID="m_rdo_ngan_sach" CssClass="cssTextBox" runat="server" Text="Ngân sách"></asp:RadioButton>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:25%"></td>
                                <td>
                                    <asp:Button ID="m_cmd_them" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                   <asp:Button ID="m_cmd_cap_nhat" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                     <asp:Button ID="m_cmd_xoa" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                </td>
                            </table>
                        </asp:Panel>
                        <asp:Panel ID="m_pnl_chi_khong_thuong_xuyen1" runat="server" GroupingText="Chi không thường xuyên" Width="45%">

                        </asp:Panel>
                        
                        <asp:DropDownList ID="DropDownList1" runat="server"></asp:DropDownList><br />
                        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
                    </asp:Panel>
                </td>
                
            </tr>
        </table>
        <table cellpadding="2" cellspacing="0" style="width:99%" class="cssTable">
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
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="" HeaderText="Xóa" />
                                <asp:BoundField DataField="noi_dung" HeaderText="Sửa" />
                                <asp:BoundField DataField="loai" HeaderText="Năm dự toán" />
                                <asp:BoundField DataField="ngay_thang" HeaderText="Công trình, dự án" />
                                <asp:BoundField DataField="ngay_thang" HeaderText="Số tiền" />
                                <asp:BoundField DataField="ngay_thang" HeaderText="Loại dự án" />
                                <asp:BoundField DataField="ngay_thang" HeaderText="Quyết định" />
                
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
        </table>
    </contentTemplate>
</asp:Content>

