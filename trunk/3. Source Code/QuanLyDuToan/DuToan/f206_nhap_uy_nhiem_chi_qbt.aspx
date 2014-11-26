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
                                    <td align="left" colspan="3">
                                          <span class="cssManField">Đơn vị trả tiền:  </span>
                                         <asp:Label ID="m_lbl_don_vi_tra_tien" runat="server" ForeColor="blue"></asp:Label>
                                     </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3">
                                        <span class="cssManField">Địa chỉ:  </span>
                                        <asp:TextBox ID="m_txt_dia_chi" runat="server" CssClass="cssTextBox" Width="95%" placeholder="Nhập địa chỉ"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="3">
                                        <span class="cssManField">Tại Kho bạc Nhà nước(NH):  </span>
                                        <asp:TextBox ID="m_txt_tai_kho_bac_nha_nuoc" runat="server" CssClass="cssTextBox" Width="86%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" style="width:30%">
                                        <span class="cssManField">Mã TKKT:  </span>
                                        <asp:TextBox ID="m_txt_ma_tkkt" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                                    </td> 
                                    <td align="left" style="width:30%">   
                                        <span class="cssManField">Mã ĐVQHNS:  </span>
                                        <asp:TextBox ID="m_txt_ma_dvqhns" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                                    </td>
                                    <td align="left" style="width:40%">
                                        <span class="cssManField">Mã CTMT, DA và HTCT:  </span>
                                        <asp:TextBox ID="m_txt_ma_ctmt_da_va_htct" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td></td>
                                    <td align="left" colspan="2">
                                        <asp:Button ID="m_cmd_unc" Text="Lưu UNC" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                                        <asp:Button ID="m_cmd_nhap_moi_unc" Text="Nhập mới UNC" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
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
                 <tr>
                    <td colspan="2">
                        <asp:Panel ID="m_pnl_trong_do" runat="server" GroupingText="Trong đó">
                        <asp:Panel ID="m_pnl_nop_thue" runat="server" GroupingText="Nộp thuế">
                        <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                            <tr>
                                <td colspan="3">
                                    <span class="cssManField">Tên đơn vị(Người nộp thuế):  </span>
                                    <asp:TextBox ID="m_txt_ten_don_vi" runat="server" CssClass="cssTextBox" Width="79%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td style="width:30%">
                                    <span class="cssManField">Mã số thuế:</span>
                                    <asp:TextBox ID="m_txt_ma_so_thue" runat="server" CssClass="cssTextBox" Width="60%"></asp:TextBox>
                                </td>
                                <td style="width:30%">
                                    <span class="cssManField">Mã NDKT:</span>
                                    <asp:TextBox ID="m_txt_ma_ndkt" runat="server" CssClass="cssTextBox" Width="65%"></asp:TextBox>
                                </td>
                                <td style="width:40%">
                                    <span class="cssManField">Mã chương:</span>
                                    <asp:TextBox ID="m_txt_ma_chuong" runat="server" CssClass="cssTextBox" Width="74%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <span class="cssManField">Cơ quan quản lý thu:</span>
                                    <asp:TextBox ID="m_txt_co_quan_quan_ly_thu" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                                </td>
                                <td>
                                    <span class="cssManField">Mã CQ thu:</span>
                                    <asp:TextBox ID="m_txt_ma_cq_thu" runat="server" CssClass="cssTextBox" Width="76%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <span class="cssManField">KBNN hạch toán thu:</span>
                                    <asp:TextBox ID="m_txt_kbnn_hach_toan_thu" runat="server" CssClass="cssTextBox" Width="84%"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="3">
                                    <span class="cssManField">Số tiền nộp thuế (ghi bằng chữ):</span>
                                    <asp:TextBox ID="m_txt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="76%"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                        </asp:Panel>
                        <asp:Panel ID="m_pnl_thanh_toan_cho_don_vi_huong" runat="server" GroupingText="Thanh toán cho đơn vị hưởng">
                            <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                <tr>
                                    <td colspan="3">
                                        <span class="cssManField">Đơn vị nhận tiền:</span>
                                        <asp:TextBox ID="m_txt_don_vi_nhan_tien" runat="server" CssClass="cssTextBox" Width="87%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:30%">
                                        <span class="cssManField">Mã ĐVQHNS:</span>
                                        <asp:TextBox ID="m_txt_ma_dvqhns_1" runat="server" CssClass="cssTextBox" Width="65%"></asp:TextBox>
                                    </td>
                                    <td colspan="2">
                                        <span class="cssManField">Địa chỉ:</span>
                                        <asp:TextBox ID="m_txt_dia_chi_1" runat="server" CssClass="cssTextBox" Width="91%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:30%">
                                        <span class="cssManField">Tài khoản:</span>
                                        <asp:TextBox ID="m_txt_tai_khoan" runat="server" CssClass="cssTextBox" Width="70%"></asp:TextBox>
                                    </td>
                                    <td style="width:35%">
                                        <span class="cssManField">Mã CTMT, DA, và HTCT:</span>
                                        <asp:TextBox ID="m_txt_ma_ctmt_da_va_htct_1" runat="server" CssClass="cssTextBox" Width="50%"></asp:TextBox>
                                    </td>
                                    <td style="width:35%">
                                        <span class="cssManField">Tại KBNN:</span>
                                        <asp:TextBox ID="m_txt_tai_kbnn" runat="server" CssClass="cssTextBox" Width="77%"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <span class="cssManField">Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
                                        <asp:TextBox ID="m_txt_so_tien_thanh_toan_cho_don_vi_huong_ghi_bang_chu" runat="server" CssClass="cssTextBox" Width="62%"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                        </asp:Panel>
                    </td>
                    <td colspan="2">
                        <asp:Panel ID="n_pnl_kbnn_a_ghi" runat="server" GroupingText="KBNN A GHI">
                            <asp:Panel ID="n_pnl_1_nop_thue" runat="server" GroupingText="1. Nộp thuế:">
                                <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                    <tr>
                                        <td>
                                            <span class="cssManField">Nợ TK:</span>
                                            <asp:TextBox ID="m_txt_no_tk_1" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Có TK:</span>
                                            <asp:TextBox ID="m_txt_co_tk_1" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Nợ TK:</span>
                                            <asp:TextBox ID="m_txt_no_tk_2" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Có TK:</span>
                                            <asp:TextBox ID="m_txt_co_tk_2" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Mã CQ thu:</span>
                                            <asp:TextBox ID="m_txt_ma_cq_thu_nop_thue" runat="server" CssClass="cssTextBox" Width="77%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Mã ĐBHC:</span>
                                            <asp:TextBox ID="m_txt_ma_dbhc" runat="server" CssClass="cssTextBox" Width="78%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                            <asp:Panel ID="m_pnl_2_thanh_toan_cho_dv_huong" runat="server" GroupingText="2. Thanh toán cho ĐV hưởng:">
                                <table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
                                     <tr>
                                        <td>
                                            <span class="cssManField">Nợ TK:</span>
                                            <asp:TextBox ID="m_txt_no_tk_3" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span class="cssManField">Có TK: </span>
                                            <asp:TextBox ID="m_txt_co_tk_3" runat="server" CssClass="cssTextBox" Width="85%"></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <table cellspacing="0" cellpadding="2" style="width: 99%;" border="1">
                            <tr>
                                <td style="width:40%" align="center">
                                    <table table cellspacing="0" cellpadding="1" style="width: 100%;" border="1">
                                        <tr>
                                            <td colspan="2" align="center">
                                                <span>ĐƠN VỊ TRẢ TIỀN</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:50%" align="center">
                                                <span class="cssManField">Kế toán trưởng</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                            <td style="width:50%" align="center">
                                                <span class="cssManField">Chủ tài khoản</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                        </tr>
                                      </table>
                                 </td>
                                <td style="width:60%" align="center">
                                    <table cellspacing="0" cellpadding="0" style="width: 100%;" border="1">
                                        <tr>
                                            <td colspan="5" align="center">
                                                <span>KBNN A</span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:50%" align="center" colspan="2" >
                                                <span class="cssManField">BỘ PHẬN KIỂM SOÁT CHI ngày</span>
                                            </td>
                                            <td style="width:50%" align="center" colspan="3">
                                                <span class="cssManField">BỘ PHẬN KIỂM SOÁT GHI SỔ ngày </span>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td style="width:25%" align="center">
                                                <span class="cssManField">Kiểm soát</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                            <td style="width:25%" align="center">
                                                <span class="cssManField">Phụ trách</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                            <td style="width:15%" align="center">
                                                <span class="cssManField">Kế toán</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                            <td style="width:20%" align="center">
                                                <span class="cssManField">Kế toán trưởng</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td><td style="width:15%" align="center">
                                                <span class="cssManField">Giám đốc</span>
                                                <br /><br /><br /><br /><br /><br /><br /><br /><br />
                                            </td>
                                        </tr>
                                      </table>
                                </td>     
                            </tr>
                            
                        </table>
                    </td>
                </tr>
                <tr>
                                <td colspan="4">
                                    <table cellspacing="0" cellpadding="0" style="width: 99%;" border="1">
                                        <tr>
                                            <td style="width:50%">
                                                <table cellspacing="0" cellpadding="0" style="width: 100%;" border="0">
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <span>NGÂN HÀNG A GHI SỔ NGÀY</span>
                                                            <asp:TextBox ID="m_txt_ngan_hang_a_ghi_so_ngay" runat="server" CssClass="cssTextBox" Width="30%" BorderColor="White"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width:30%">
                                                            <span>Kế toán</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                        <td align="center" style="width:40%">
                                                            <span>Kế toán trưởng</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                        <td align="center" style="width:30%">
                                                            <span>Giám đốc</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                            <td style="width:50%">
                                                <table cellspacing="0" cellpadding="0" style="width: 100%;" border="0">
                                                    <tr>
                                                        <td colspan="3" align="center">
                                                            <span>NGÂN HÀNG B GHI SỔ NGÀY</span>
                                                            <asp:TextBox ID="TextBox1" runat="server" CssClass="cssTextBox" Width="30%" BorderColor="White"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center" style="width:30%">
                                                            <span>Kế toán</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                        <td align="center" style="width:40%">
                                                            <span>Kế toán trưởng</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                        <td align="center" style="width:30%">
                                                            <span>Giám đốc</span>
                                                            <br /><br /><br /><br /><br /><br /><br />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                    </table>
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

