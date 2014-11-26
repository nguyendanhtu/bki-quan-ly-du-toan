<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f204_nhap_giao_ke_hoach_qbt.aspx.cs" Inherits="DuToan_f204_nhap_giao_ke_hoach_1" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            color: red;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" Text="Nhập giao kế hoạch - Nguồn Quỹ bảo trì" CssClass="cssPageTitle"></asp:Label>
                        <%--<span class="expand-collapse-text"></span>--%>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Panel ID="m_pnl_thong_tin_ve_qd_giao_ke_hoach" GroupingText="Thông tin chung" runat="server">
                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="m_lbl_mess_qd" runat="server" CssClass="cssManField"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%" align="right">
                                        <span class="cssManField">Số QĐ</span>
                                    </td>
                                    <td style="width: 85%" align="left">
                                        <asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="cssTextBox" Width="20%"></asp:TextBox>
                                        <asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" Width="21%" Visible="false" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                        <asp:Button ID="m_cmd_chon_qd_da_nhap" Text="Chọn QĐ" OnClick="m_cmd_chon_qd_da_nhap_Click" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><span class="cssManField">Nội dung</span></td>
                                    <td align="left">
                                        <asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" Width="50%" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="right"><span class="cssManField">Ngày tháng</span></td>
                                    <td align="left">
                                        <asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox" Width="20%" placeholder="dd/MM/yyyy"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td colspan="1" align="left">
                                        <asp:Button ID="m_cmd_luu_qd" Text="Lưu QĐ" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_luu_qd_Click" />
                                        <asp:Button ID="m_cmd_nhap_qd_moi" Text="Nhập QĐ mới" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_nhap_qd_moi_Click" />
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
                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                <tr>
                                    <td colspan="2">
                                        <asp:Label ID="m_lbl_mess_detail" runat="server" CssClass="cssManField"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%"></td>
                                    <td colspan="2">
                                        <asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" CssClass="cssManField" ForeColor="Blue" Text="KH đầu năm" GroupName="loai" Checked="true" AutoPostBack="true" OnCheckedChanged="m_rdb_kh_dau_nam_CheckedChanged" />
                                        <asp:RadioButton ID="m_rdb_bo_sung" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Bổ sung" GroupName="loai" AutoPostBack="true" OnCheckedChanged="m_rdb_bo_sung_CheckedChanged"/>
                                        <asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Điều chỉnh" GroupName="loai" AutoPostBack="true" OnCheckedChanged="m_rdb_dieu_chinh_CheckedChanged"/>
                                        <asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
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
                                                    <td style="width: 70%" align="left">
                                                        <asp:DropDownList ID="m_ddl_tuyen_quoc_lo" runat="server" Width="51%"></asp:DropDownList>
                                                        <asp:Button ID="m_cmd_them_ql" Text="Thêm QL" runat="server" CssClass="cssButton" Height="24px" Width="98px" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Số tiền</span>
                                                    </td>
                                                    <td style="width: 70%" align="left">
                                                        <asp:TextBox ID="m_txt_ctx_so_tien" runat="server" CssClass="cssTextBox" Width="50%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>

                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_insert_Click" />
                                                        <asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_update_Click" />
                                                        <asp:Button ID="m_cmd_ctx_delete" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_cancel_Click" />
                                                        <asp:HiddenField ID="m_hdf_id_quoc_lo" runat="server" />
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
                                                    <td style="width: 70%" align="left">
                                                        <asp:TextBox ID="m_txt_ten_du_an" runat="server" CssClass="cssTextBox" placeholder="Dự án a" Width="50%"></asp:TextBox>
                                                        <asp:DropDownList ID="m_ddl_du_an" runat="server" Width="51%" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_du_an_SelectedIndexChanged"></asp:DropDownList>
                                                        <asp:Button ID="m_cmd_chon_du_an" runat="server" Text="Chọn dự án" OnClick="m_cmd_chon_du_an_Click"  Width="98px" Height="24px"  CssClass="cssButton" />

                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td style="width: 30%" align="right">
                                                        <span class="cssManField">Số tiền</span>
                                                    </td>
                                                    <td style="width: 70%" align="left">
                                                        <asp:TextBox ID="m_txt_cktx_so_tien" runat="server" CssClass="cssTextBox" Width="50%"></asp:TextBox>
                                                    </td>
                                                </tr>
                                                
                                                <tr>

                                                    <td colspan="2" align="center">
                                                        <asp:Button ID="m_cmd_cktx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_insert_Click" />
                                                        <asp:Button ID="m_cmd_cktx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_update_Click" />
                                                        <asp:Button ID="m_cmd_cktx_cancel" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_cancel_Click" />
                                                        <asp:HiddenField ID="m_hdf_id_du_an" runat="server" />
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
                        <asp:Label ID="m_lbl_grid_title" runat="server" Text="Chi tiết Giao kế hoạch" CssClass="cssPageTitle"></asp:Label>
                        <%--<span class="expand-collapse-text"></span>--%>
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Từ khóa</span>
                    </td>
                    <td style="width: 50%">
                        <asp:TextBox ID="m_txt_tu_khoa" CssClass="cssTextBox" Width="60%" runat="server"></asp:TextBox>
                        <asp:Button ID="m_cmd_tim_kiem" CssClass="cssButton" Width="98px" Height="24px" runat="server" Text="Tìm kiếm" />
                    </td>
                    <td style="width: 30%" align="right">
                        <asp:Button ID="m_cmd_xem_bao_cao_du_toan" runat="server" CssClass="cssButton" Height="24px" Text="Xem báo cáo dự toán" />
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="m_lbl_mess_grid" runat="server" CssClass="cssManField"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                            AllowSorting="True" PageSize="30" ShowHeader="true"
                            DataKeyNames="ID"
                            EmptyDataText="Không có dữ liệu phù hợp"
                            OnRowEditing="m_grv_RowEditing"
                            OnRowDeleting="m_grv_RowDeleting"
                            OnPageIndexChanging="m_grv_PageIndexChanging">
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

                                <asp:CommandField ItemStyle-Width="3%" EditText="Sửa" EditImageUrl="../Images/Button/edit.png"
                                    ShowEditButton="true" ButtonType="Image" HeaderText="Sửa" ItemStyle-HorizontalAlign="Center"
                                    HeaderStyle-HorizontalAlign="Center" />
                                <asp:BoundField DataField="ten_du_an_cong_trinh" HeaderText="Công trình, dự án" />
                                <asp:TemplateField  HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="m_lbl_so_tien_grid" runat="server" 
                                            CssClass="cssManField" ForeColor="Blue"
                                            Text='<%#CIPConvert.ToStr(Eval("SO_TIEN"),"#,###,##") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ten" HeaderText="Loại dự án" />
                                <asp:BoundField DataField="so_quyet_dinh" HeaderText="Quyết định" />
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

