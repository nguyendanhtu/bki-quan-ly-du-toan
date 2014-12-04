<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F208_nhap_giao_ke_hoach_ns.aspx.cs" Inherits="QuanLyDuToan.DuToan.F208_nhap_giao_ke_hoach_ns" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
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
			<table cellspacing="0" cellpadding="2" style="width: 900px; margin:auto" class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG">
						<asp:Label ID="m_lbl_title_nhap_giao_ke_hoach" runat="server" Text="Nhập Giao kế hoạch - Nguồn Ngân sách Nhà nước" CssClass="cssPageTitle"></asp:Label>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Panel ID="m_pnl_thong_tin_qd_ve_ke_hoach" GroupingText="Thông tin chung" runat="server" ForeColor="Black">
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
										<asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" Width="21%" Visible="false" CssClass="cssDorpdownlist"
											OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true">
										</asp:DropDownList>
										<asp:Button ID="m_cmd_chon_qd_da_nhap" Text="Chọn QĐ" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											OnClick="m_cmd_chon_qd_da_nhap_Click" />
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
						<asp:Panel ID="m_pnl_chi_tiet" GroupingText="Nội dung chi tiết" runat="server" ForeColor="Black">
							<table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
								<tr>
									<td style="width: 15%"></td>
									<td>
										<asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" CssClass="cssManField" ForeColor="Black" Text="KH đầu năm" GroupName="loai" Checked="true" />
										<asp:RadioButton ID="m_rdb_bo_sung" runat="server" CssClass="cssManField" ForeColor="Black" Text="Bổ sung" GroupName="loai" />
										<asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" CssClass="cssManField" ForeColor="Black" Text="Điều chỉnh" GroupName="loai" />
									</td>
								</tr>
								<tr>
									<td colspan="3">
										<asp:Panel ID="m_pnl_chon_muc_khoan_chi" GroupingText="Chọn mục khoản chi" runat="server" ForeColor="Blue">
											<table style="width: 99%">
												<tr>
													<td colspan="4">
														<asp:Label ID="m_lbl_mess_detail" runat="server" CssClass="cssManField"></asp:Label></td>
												</tr>
												<tr>
													<td style="width: 15%" align="right">
														<span class="cssManField">Chương</span>
													</td>
													<td style="width: 35%">
														<asp:DropDownList ID="m_ddl_chuong" runat="server" Width="90%" CssClass="cssDorpdownlist"></asp:DropDownList>
													</td>
													<td style="width: 15%" align="right"><span class="cssManField">Loại</span></td>

													<td style="width: 35%" align="left">
														<asp:DropDownList ID="m_ddl_loai" Width="90%" runat="server" CssClass="cssDorpdownlist"
															OnSelectedIndexChanged="m_ddl_loai_SelectedIndexChanged" AutoPostBack="true">
														</asp:DropDownList>
													</td>

												</tr>
												<tr>
													<td align="right">
														<span class="cssManField">Khoản</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_khoan" Width="90%" runat="server" CssClass="cssDorpdownlist"></asp:DropDownList>
													</td>
													<td align="right">
														<span class="cssManField">Mục</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_muc" Width="90%" runat="server" CssClass="cssDorpdownlist" OnSelectedIndexChanged="m_ddl_muc_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
													</td>
												</tr>
												<tr>

													<td align="right">
														<span class="cssManField">Tiểu mục</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_tieu_muc" Width="90%" runat="server" CssClass="cssDorpdownlist">
														</asp:DropDownList>
													</td>
												</tr>
												<tr>
													<td align="right">
														<span class="cssManField">Số tiền</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_so_tien" runat="server" CssClass="cssTextBox csscurrency" placeholder="Số tiền" Width="50%"></asp:TextBox>
													</td>
													<td align="right">
														<span class="cssManField">Nội dung</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_ghi_chu" Width="89%" runat="server" CssClass="cssTextBox" TextMode="MultiLine"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td></td>

													<td>

														<asp:Button ID="m_cmd_insert" runat="server" CssClass="cssButton" Height="24px" Text="Thêm" Width="98px" OnClick="m_cmd_insert_Click" />
														<asp:Button ID="m_cmd_update" runat="server" CssClass="cssButton" Height="24px" Text="Cập nhật" Width="98px" OnClick="m_cmd_update_Click" />
														<asp:Button ID="m_cmd_cancel" runat="server" CssClass="cssButton" Height="24px" Text="Xóa trắng" Width="98px" OnClick="m_cmd_cancel_Click" />
														<asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
													</td>
												</tr>
											</table>

										</asp:Panel>
									</td>
								</tr>
								<tr>
									<td colspan="2">
										<asp:Label ID="m_lbl_mess_grid" runat="server" CssClass="cssManField"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="4" align="center">
										<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
											DataKeyNames="ID"
											CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
											AllowSorting="True" PageSize="30" ShowHeader="true"
											EmptyDataText="Không có dữ liệu phù hợp"
											OnRowCommand="m_grv_RowCommand"
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
												<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
													<ItemTemplate>
														<%# Container.DataItemIndex + 1 %>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
													<ItemTemplate>
														<asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
															CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
														</asp:LinkButton>
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="2%">
													<ItemTemplate>
														<asp:LinkButton ID="m_lbl_update" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
															CommandName="Sua" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
														</asp:LinkButton>
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateField>
												<asp:BoundField DataField="display" HeaderText="Công trình, dự án" />
												<asp:BoundField DataField="ghi_chu" HeaderText="Nội dung" />
												<asp:TemplateField HeaderText="Kinh phí năm trước chuyển sang" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_nam_truoc_chuyen_sang_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_NAM_TRUOC_CHUYEN_SANG).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Kinh phí Ngân sách" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_NS).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Kinh phí Quỹ bảo trì" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_QUY_BT).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<%--<asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_tong_so_tien" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval("TONG").ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>--%>
												<asp:BoundField DataField="ten" HeaderText="Loại" HeaderStyle-Width="60px"/>
											</Columns>
										</asp:GridView>
									</td>
								</tr>
							</table>
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


