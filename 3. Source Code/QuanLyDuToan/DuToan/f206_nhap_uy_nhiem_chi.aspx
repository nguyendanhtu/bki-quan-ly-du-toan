<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f206_nhap_uy_nhiem_chi.aspx.cs" Inherits="DuToan_f206_nhap_uy_nhiem_chi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG">
                <asp:Label ID="m_lbl_title_nhap_uy_nhiem_chi" runat="server" Text="Nhập ủy nhiệm chi" CssClass="cssPageTitle"></asp:Label>
                <span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="m_pnl_thong_tin_thong_tin_uy_nhiem_chi" GroupingText="Thông tin ủy nhiệm chi" runat="server" ForeColor="Blue">
                    <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                        <tr>
                            <td style="width: 25%" align="right">
                                <span class="cssManField">Đơn vị trả tiền</span>
                            </td>
                            <td style="width: 75%">
                                <span class="cssManField" style="color: blue">Sở giao thông vận tải Hải Dương</span>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Địa chỉ</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_dia_chi" runat="server" placeholder="Nhập địa chỉ" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                            </td>

                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Số UNC</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_so_unc" runat="server" placeholder="59Qtu" CssClass="cssTextBox" Width="18%"></asp:TextBox>
                                <asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn UNC" CssClass="cssButton" Width="9%" Height="24px" />
                                <asp:DropDownList ID="m_ddl_chon_unc" runat="server" Width="20%"></asp:DropDownList>
                                <span class="cssManField">Ngày tháng</span>
                                <asp:TextBox ID="m_txt_ngay_thang" runat="server" placeholder="dd/mm/yyyy" CssClass="cssTextBox" Width="14.5%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Tại kho bạc Nhà nước (NH)</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_tai_kho_bac_nn" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td align="right">
                                <span class="cssManField">Mã TKKT</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_ma_tkkt" runat="server" CssClass="cssTextBox" Width="15%"></asp:TextBox>
                                <span class="cssManField">Mã ĐVQHNS</span>
                                <asp:TextBox ID="m_txt_ma_dvqhns" runat="server" CssClass="cssTextBox" Width="15%"></asp:TextBox>
                                <span class="cssManField">Mã CTMT, DA và HTCT</span>
                                <asp:TextBox ID="m_txt_ma_ctmt_da_htct" runat="server" CssClass="cssTextBox" Width="14.5%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="m_cmd_luu_unc" runat="server" Text="Lưu UNC" CssClass="cssButton" Width="98px" Height="24px" />
                                <asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới UNC" CssClass="cssButton" Width="98px" Height="24px" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="m_pnl_Khoan_thanh_toan" GroupingText="Khoản thanh toán" runat="server" ForeColor="Blue">
                    <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                        <tr>
                            <td></td>
                            <td>
                                <asp:RadioButton ID="m_rdb_chi_thuong_xuyen" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Chi thường xuyên" GroupName="loai" Checked="true" />
                                <asp:RadioButton ID="m_rdb_chi_khong_thuong_xuyen" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Chi không thường xuyên" GroupName="loai" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width:25%" align="right">
                                <span class="cssManField">Nội dung</span>
                            </td>
                            <td style="width:75%">
                                <asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" placeholder="Thanh toán quý 3 SCTX" Width="25%"></asp:TextBox>
                                <asp:DropDownList ID="m_ddl_quoc_lo" runat="server" CssClass="cssDorpdownlist" Width="18%"></asp:DropDownList>
                                <asp:TextBox ID="m_txt_tt_lan_2" runat="server" CssClass="cssTextBox" placeholder="TT lần 2" Width="25%"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <label style="color:blue">Thanh toán quý 3 SCTX Quốc lộ 1 TT lần 2</label>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" align="right">
                                <span class="cssManField">Số tiền</span>
                            </td>
                            <td>
                                <asp:TextBox ID="m_txt_so_tien" runat="server" CssClass="cssTextBox" Width="40%" placeholder="Số tiền"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%" align="right">
                                <span class="cssManField">Nguồn</span>
                            </td>
                            <td>
                                <asp:RadioButton ID="m_rdb_quy_bao_tri" runat="server" CssClass="cssManField" ForeColor="Black" Text="Quỹ bảo trì" GroupName="loai_nguon" Checked="true" />
                                <asp:RadioButton ID="m_rdb_ngan_sach" runat="server" CssClass="cssManField" ForeColor="Black" Text="Ngân sách" GroupName="loai_nguon" />
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                <asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                <asp:Button ID="m_cmd_ctx_delete" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
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
                <asp:Label ID="m_lbl_title_ds_khoan_thanh_toan" runat="server" Text="Danh sách khoản thanh toán" CssClass="cssPageTitle"></asp:Label>
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
                <asp:Button ID="m_cmd_ds_uy_nhiem_chi" runat="server" CssClass="cssButton" Height="24px" Text="Danh sách ủy nhiệm chi"  />
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
                                <asp:BoundField DataField="so_unc" HeaderText="Số UNC" />
                                <asp:BoundField DataField="noi_dung" HeaderText="Nội dung" />
                                <asp:BoundField DataField="so_tien" HeaderText="Số tiền" />
                                <asp:BoundField DataField="nguon" HeaderText="Nguồn" />
                            </Columns>
                        </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

