<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F410_nhap_uy_nhiem_chi_ns.aspx.cs" Inherits="DuToan_F410_nhap_uy_nhiem_chi_ns" %>

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
						<asp:Label ID="m_lbl_nhap_uy_nhiem_chi_ngan_sach_nha_nuoc" runat="server" Text="Nhập ủy nhiệm chi-Ngân sách Nhà nước" CssClass="cssPageTitle"></asp:Label>
						<span class="expand-collapse-text"></span>
					</td>
				</tr>
				<tr>
					<td colspan="3" style="width:80%">
						<asp:Panel ID="m_pnl_thong_tin_uy_nhiem_chi" GroupingText="Thông tin ủy nhiệm chi" runat="server">
							<table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
								<tr>
									<td align="left">
										<span class="cssManField">Đơn vị trả tiền:  </span>
									</td>
									<td colspan="5">
										<asp:Label ID="m_lbl_don_vi_tra_tien" runat="server" ForeColor="blue"></asp:Label>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Địa chỉ:  </span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_dia_chi" runat="server" CssClass="cssTextBox" Width="100%" placeholder="Nhập địa chỉ"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Tại Kho bạc Nhà nước(NH):  </span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_tai_kho_bac_nha_nuoc" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td align="left" style="width: 10%">
										<span class="cssManField">Mã TKKT:  </span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_tkkt" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã ĐVQHNS:  </span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_dvqhns" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã CTMT, DA và HTCT:  </span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_ctmt_da_va_htct" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
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
					<td></td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_danh_sach_khoan_thanh_toan" runat="server" Text="Danh sách khoản thanh toán" CssClass="cssPageTitle"></asp:Label>
						<span class="expand-collapse-text"></span>
					</td>
				</tr>
				<tr>
					<td style="width: 30%" align="right">
						<span class="cssManField">Từ khóa</span>
					</td>
					<td style="width: 40%">
						<asp:TextBox ID="m_txt_tu_khoa" runat="server" CssClass="cssTextBox" Width="60%" placeholder="Nội dung chi"></asp:TextBox>
					</td>
					<td align="left">
						<asp:Button ID="m_cmd_tim_kiem" Text="Tìm kiếm" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
					</td>
					<td style="width:20%" align="right">
						<asp:Button ID="m_cmd_danh_sach_uy_nhiem_chi" Text="Danh sách ủy nhiệm chi" runat="server" CssClass="cssButton" Height="24px" Width="150px" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td></td>
					<td align="right">
						<span class="cssManField">Tổng</span>
					</td>
					<td align="center">
						<asp:Label ID="m_lbl_tong" runat="server" ForeColor="Blue"></asp:Label>
					</td>
					<td></td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="Label1" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center" style="margin-left: 40px">
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
								<asp:BoundField DataField="noi_dung" HeaderText="Nội Dung" />
								<asp:BoundField DataField="loai" HeaderText="Loại" />
								<asp:BoundField DataField="ghi_chu" HeaderText="Ghi chú" />
								<asp:BoundField DataField="so_tien" HeaderText="Số tiền" />
								<asp:BoundField DataField="nguon" HeaderText="Nguồn" />
							</Columns>
						</asp:GridView>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<asp:Panel ID="m_pnl_trong_do" runat="server" GroupingText="Trong đó">
							<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
								<tr>
									<td>NỘP THUẾ</td>
								</tr>
								<tr>
									<td colspan="1">
										<span class="cssManField">Tên đơn vị (Người nộp thuế):  </span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_ten_don_vi" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 10%">
										<span class="cssManField">Mã số thuế:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_so_thue" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã NDKT:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_ndkt" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã chương:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_chuong" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Cơ quan quản lý thu:</span>
									</td>
									<td colspan="3">
										<asp:TextBox ID="m_txt_co_quan_quan_ly_thu" runat="server" CssClass="cssTextBox" Width="92.2%"></asp:TextBox>
									</td>
									<td>
										<span class="cssManField">Mã CQ thu:</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_ma_cq_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">KBNN hạch toán thu:</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_kbnn_hach_toan_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Số tiền nộp thuế (ghi bằng chữ):</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>THANH TOÁN CHO ĐƠN VỊ HƯỞNG</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Đơn vị nhận tiền:</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_don_vi_nhan_tien" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Mã ĐVQHNS:</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_ma_dvqhns_1" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td>
										<span class="cssManField">Địa chỉ:</span>
									</td>
									<td colspan="3">
										<asp:TextBox ID="m_txt_dia_chi_1" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 10%">
										<span class="cssManField">Tài khoản:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_tai_khoan" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã CTMT, DA, và HTCT:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ma_ctmt_da_va_htct_1" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Tại KBNN:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_tai_kbnn" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_so_tien_thanh_toan_cho_don_vi_huong_ghi_bang_chu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
							</table>
						</asp:Panel>


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
