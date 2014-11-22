<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f206_nhap_uy_nhiem_chi_qbt.aspx.cs" Inherits="DuToan_f206_nhap_uy_nhiem_chi" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
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
                                    <td colspan="2">
                                        <asp:Label ID="m_lbl_mess_master" runat="server" CssClass="cssManField"></asp:Label></td>
                                </tr>
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
                                        <asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn UNC" 
                                            CssClass="cssButton" Width="98px" Height="24px" 
                                            OnClick="m_cmd_chon_unc_Click"/>
                                        <asp:DropDownList ID="m_ddl_unc" Visible="false" runat="server" Width="20%"
                                            OnSelectedIndexChanged="m_ddl_unc_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
                                        <asp:Button ID="m_cmd_luu_unc" runat="server" Text="Lưu UNC" CssClass="cssButton" Width="98px" Height="24px"
                                            OnClick="m_cmd_luu_unc_Click" />
                                        <asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới UNC" CssClass="cssButton" Width="98px" Height="24px"
                                            OnClick="m_cmd_nhap_moi_unc_Click" />
                                        <asp:HiddenField ID="m_hdf_id_dm_uy_nhiem_chi" runat="server" />
                                        <asp:HiddenField ID="m_hdf_form_mode" runat="server" />
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
                                    <td colspan="2">
                                        <asp:Label ID="m_lbl_mess_detail" runat="server" CssClass="cssManField"></asp:Label></td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:RadioButton ID="m_rdb_chi_thuong_xuyen" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Chi thường xuyên"
                                             GroupName="loai" Checked="true" OnCheckedChanged="m_rdb_chi_thuong_xuyen_CheckedChanged" AutoPostBack="true"/>
                                        <asp:RadioButton ID="m_rdb_chi_khong_thuong_xuyen" runat="server" CssClass="cssManField" AutoPostBack="true"
                                            ForeColor="Blue" Text="Chi không thường xuyên" GroupName="loai" OnCheckedChanged="m_rdb_chi_khong_thuong_xuyen_CheckedChanged"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <span class="cssManField">Nội dung</span>
                                    </td>
                                    <td style="width: 75%">

                                        <asp:DropDownList ID="m_ddl_quoc_lo" runat="server" CssClass="cssDorpdownlist" Width="21%"
                                            AutoPostBack="true" OnSelectedIndexChanged="m_ddl_quoc_lo_SelectedIndexChanged"></asp:DropDownList>
                                         <asp:DropDownList ID="m_ddl_du_an" runat="server" CssClass="cssDorpdownlist" Width="21%"
                                             AutoPostBack="true" OnSelectedIndexChanged="m_ddl_du_an_SelectedIndexChanged"></asp:DropDownList>

                                    </td>
                                </tr>
                                
                                <tr>
                                    <td style="width: 25%" align="right">
                                        <span class="cssManField">Số tiền</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="m_txt_so_tien" runat="server" CssClass="cssTextBox" Width="20%" placeholder="Số tiền"></asp:TextBox>
                                    </td>
                                </tr>
                                  <tr>
                                    <td style="width: 25%" align="right">
                                        <span class="cssManField">Ghi chú</span>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="m_txt_ghi_chu" runat="server" CssClass="cssTextBox" Width="40%" placeholder="Ghi rõ nội dung thanh toán"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td>
                                        <asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" 
                                            OnClick="m_cmd_ctx_insert_Click"/>
                                        <asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" 
                                            OnClick="m_cmd_ctx_update_Click"/>
                                        <asp:Button ID="m_cmd_ctx_cancel" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px"
                                            OnClick="m_cmd_ctx_cancel_Click" />
                                        <asp:HiddenField ID="m_hdf_id_gd_uy_nhiem_chi" runat="server" />
                                        <asp:HiddenField ID="m_hdf_id_du_an_cong_trinh" runat="server" />
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
                        <asp:Label ID="m_lbl_grid_title" runat="server" Text="Danh sách khoản thanh toán" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:Label ID="m_lbl_mess_grid" runat="server" CssClass="cssManField"></asp:Label></td>
                </tr>
                <tr>
                    <td align="right" style="width: 20%">
                        <span class="cssManField">Từ khóa</span>
                    </td>
                    <td style="width: 50%">
                        <asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="40%" placeholder="Nội dung chi"></asp:TextBox>
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" CssClass="cssButton" Height="24px" Text="Tìm kiếm" Width="98px" />

                    </td>
                    <td style="width: 30%" align="right">
                        <asp:Button ID="m_cmd_ds_uy_nhiem_chi" runat="server" CssClass="cssButton" Height="24px" Text="Danh sách ủy nhiệm chi" />
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
                                <asp:BoundField DataField="so_unc" HeaderText="Số UNC" />
                                <asp:BoundField DataField="ten_du_an_cong_trinh" HeaderText="Nội dung" />
                                <asp:TemplateField  HeaderText="Số tiền" ItemStyle-HorizontalAlign="Right">
                                    <ItemTemplate>
                                        <asp:Label ID="m_lbl_so_tien_grid" runat="server" 
                                            CssClass="cssManField" ForeColor="Blue"
                                            Text='<%#CIPConvert.ToStr(Eval("SO_TIEN"),"#,###,##") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="NOI_DUNG" HeaderText="Ghi chú" />
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

