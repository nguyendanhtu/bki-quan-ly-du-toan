<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F405_giao_von_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.F405_giao_von_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .cssFontBold {
            font-weight: bold;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 900px; margin: auto" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" Width="100%" Text="Nhập Giao vốn - Nguồn Quỹ bảo trì" CssClass="cssPageTitle"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="m_pnl_thong_tin_ve_qd_giao_ke_hoach" GroupingText="Thông tin quyết định" runat="server">
                            <table style="width: 99%;" border="0">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="m_lbl_mess_qd" runat="server" CssClass="cssManField"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="text-align: right"><span>Loại quyết định</span></td>
                                    <td>
                                        <asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" Text="KH đầu năm" GroupName="loai" Checked="true" AutoPostBack="true" />
                                        <asp:RadioButton ID="m_rdb_bo_sung" runat="server" Text="Bổ sung" GroupName="loai" AutoPostBack="true" />
                                        <asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" Text="Điều chỉnh" GroupName="loai" AutoPostBack="true" />
                                        <asp:HiddenField ID="HiddenField1" runat="server" />
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%; text-align: right">
                                        <span>Số QĐ</span>
                                    </td>
                                    <td style="width: 35%">
                                        <asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="cssTextBox" Width="150px" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
                                        <asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" Width="156px" Visible="false" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:Button ID="m_cmd_chon_qd_da_nhap" Text="Chọn QĐ" OnClick="m_cmd_chon_qd_da_nhap_Click" runat="server" />
                                    </td>
                                    <td style="width: 15%; text-align: right">
                                        <span>Ngày tháng</span>
                                    </td>
                                    <td style="width: 35%">
                                        <asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox" Width="100px" placeholder="dd/MM/yyyy"></asp:TextBox></td>
                                </tr>
                                <tr>
                                    <td style="text-align: right"><span>Nội dung</span></td>
                                    <td colspan="3">
                                        <asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" Width="528px"></asp:TextBox>
                                    </td>
                                </tr>

                                <tr>
                                    <td></td>
                                    <td colspan="1">
                                        <asp:Button ID="m_cmd_luu_qd" Text="Lưu QĐ" runat="server" OnClick="m_cmd_luu_qd_Click" />
                                        <asp:Button ID="m_cmd_nhap_qd_moi" Text="Nhập QĐ mới" runat="server" OnClick="m_cmd_nhap_qd_moi_Click" />
                                        <asp:HiddenField ID="m_hdf_id_quyet_dinh" runat="server" />
                                        <asp:HiddenField ID="m_hdf_form_mode" runat="server" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="m_pnl" runat="server" GroupingText="Nội dung chi tiết">
                            <table style="width: 100%;">
                                <tr>
                                    <td style="width: 20%">Loại nhiệm vụ</td>
                                    <td>
                                        <asp:DropDownList ID="m_ddl_loai_nhiem_vu" runat="server" Width="250px" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_loai_nhiem_vu_SelectedIndexChanged">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="2">
                                        <table style="width: 99%;" border="0">
                                            <tr>
                                                <td colspan="2">
                                                    <asp:Label ID="m_lbl_mess_detail" CssClass="cssManField" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">
                                                    <asp:Label ID="m_lbl_mess_grid" CssClass="cssManField" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3">
                                                    <asp:GridView ID="m_grv" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                                                        CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                                                        AllowSorting="True" PageSize="30" ShowHeader="true"
                                                        DataKeyNames="ID"
                                                        EmptyDataText="Không có dữ liệu phù hợp"
                                                        OnRowCommand="m_grv_RowCommand"
                                                        OnPageIndexChanging="m_grv_PageIndexChanging"
														OnRowDataBound="m_grv_RowDataBound"
                                                        HeaderStyle-Height="70px">
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%" Visible="false">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                                                                        CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>
                                                            <asp:BoundField DataField="NOI_DUNG" HeaderText="Nhiệm vụ chi" />
                                                            <asp:TemplateField HeaderText="Kế hoạch chi" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="m_lbl_so_tien_ke_hoach_grid" runat="server" Style="text-align: right"
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.KE_HOACH_CHI).ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                          <%--  <asp:TemplateField HeaderText="Kinh phí Ngân sách" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="m_txt_so_tien_ngan_sach_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.NS).ToString()) %>' Visible='<%# !visible_label_so_tien(Eval("ID").ToString()) %>'></asp:TextBox>
                                                                    <asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
                                                                        Visible='<%# visible_label_so_tien(Eval("ID").ToString()) %>' Text='<%#format_so_tien(Eval(GRID_GIAO_VON.NS).ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
                                                            <asp:TemplateField HeaderText="Kinh phí Quỹ bảo trì" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:TextBox ID="m_txt_so_tien_quy_bao_tri_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
                                                                        Visible='<%# !visible_label_so_tien(Eval("ID").ToString()) %>'
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.QUY).ToString()) %>'></asp:TextBox>
                                                                    <asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
                                                                        Visible='<%# visible_label_so_tien(Eval("ID").ToString()) %>'
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.QUY).ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="m_lbl_so_tien_tong_grid" runat="server" Style="text-align: right"
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.TONG).ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                           <%-- <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="m_link_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                                                                        CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>--%>
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="3" style="text-align: center">
                                                    <asp:Button ID="m_cmd_cap_nhat" runat="server" Text="Ghi dữ liệu" OnClick="m_cmd_cap_nhat_Click" />
                                                    <asp:Button ID="m_cmd_xoa_trang" runat="server" Text="Huỷ thao tác" OnClick="m_cmd_xoa_trang_Click" />
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                            </div>
                            
                        </asp:Panel>
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


