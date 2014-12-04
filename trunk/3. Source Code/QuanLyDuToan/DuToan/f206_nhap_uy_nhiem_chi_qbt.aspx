<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f206_nhap_uy_nhiem_chi_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.f206_nhap_uy_nhiem_chi_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.radioButtonList {
			list-style: none;
			margin: 0;
			padding: 0;
		}

			.radioButtonList.horizontal li {
				display: inline-block;
			}

			.radioButtonList label {
				display: inline-block;
			}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table style="margin: auto">
				<tr>
					<td align="center" style="font-weight: bold; font-size: 24px">UỶ NHIỆM CHI</td>
				</tr>
				<tr>
					<td align="center">CHUYỂN KHOẢN, CHUYỂN TIỀN ĐIỆN TỬ</td>
				</tr>
				<tr>
					<td align="center">
						<p>Lập ngày: &nbsp;<asp:TextBox ID="m_txt_ngay_thang" runat="server" placeholder="dd/mm/yyyy" CssClass="cssTextBox" Width="100px"></asp:TextBox></p>
					</td>
				</tr>
				<tr>
					<td style="width: 900px;">
						<table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
							<tr>
								<td>

									<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
										<tr>
											<td colspan="2">
												<asp:Label ID="m_lbl_mess_master" runat="server" CssClass="cssManField"></asp:Label></td>
										</tr>
										<tr>
											<td style="width: 20%; text-align: right">
												<span>Đơn vị trả tiền</span>
											</td>
											<td style="width: 30%">
												<asp:Label ID="m_lbl_don_vi_tra_tien" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
											</td>
											<td style="width: 25%"></td>
											<td style="width: 25%"></td>
										</tr>
										<tr>
											<td style="text-align: right">
												<span>Địa chỉ</span>
											</td>
											<td>
												<asp:Label ID="m_lbl_dia_chi" runat="server" ForeColor="Black"></asp:Label>
											</td>

										</tr>
										<tr>
											<td style="text-align: right">
												<span>Số UNC</span>
											</td>
											<td colspan="2">
												<asp:TextBox ID="m_txt_so_unc" runat="server" placeholder="59Qtu" CssClass="cssTextBox" Width="150px"></asp:TextBox>
												<asp:DropDownList ID="m_ddl_unc" Visible="false" runat="server" Width="152px"
													OnSelectedIndexChanged="m_ddl_unc_SelectedIndexChanged" AutoPostBack="true">
												</asp:DropDownList>
												<asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn UNC"
													CssClass="cssButton" Width="98px" Height="24px"
													OnClick="m_cmd_chon_unc_Click" />
												<asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới UNC" CssClass="cssButton" Width="98px" Height="24px"
													OnClick="m_cmd_nhap_moi_unc_Click" />

											</td>

										</tr>
										<tr>
											<td style="text-align: right">
												<span>Tại kho bạc Nhà nước (NH)</span>
											</td>
											<td>
												<asp:Label ID="m_lbl_tai_kho_bac_nha_nuoc" runat="server" ForeColor="Black"></asp:Label>
											</td>
										</tr>
										<tr>
											<td style="text-align: right">
												<span>Mã TKKT</span>
											</td>
											<td>
												<asp:RadioButtonList ID="m_rbl_ma_tkkt" runat="server" RepeatDirection="Horizontal" CssClass="radioButtonList">
												</asp:RadioButtonList>

											</td>
											<td style="text-align: right"><span>&nbsp;&nbsp; Mã ĐVQHNS:</span><asp:Label ID="m_lbl_ma_dvqhns" runat="server" ForeColor="Black"></asp:Label><span>&nbsp;&nbsp; Mã CTMT, DA và HTCT:</span></td>
											<td>

												<asp:TextBox ID="m_txt_ma_ctmt_da_htct" Width="40%" runat="server" CssClass="cssTextBox"></asp:TextBox>
												<asp:Button ID="m_cmd_luu_unc" runat="server" CssClass="cssButton" Height="24px" OnClick="m_cmd_luu_unc_Click" Text="Lưu UNC" Width="98px" />
											</td>
										</tr>
										<tr>
											<td></td>
											<td>


												<asp:HiddenField ID="m_hdf_id_dm_uy_nhiem_chi" runat="server" />
												<asp:HiddenField ID="m_hdf_form_mode" runat="server" />
											</td>
										</tr>
									</table>

								</td>
							</tr>
							<tr>
								<td>

									<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">

										<asp:Panel ID="m_pnl" runat="server" Visible="false">
											<tr>
												<td></td>
												<td>
													<asp:RadioButton ID="m_rdb_chi_thuong_xuyen" runat="server" ForeColor="Black" Text="Chi thường xuyên"
														GroupName="loai" Checked="true" OnCheckedChanged="m_rdb_chi_thuong_xuyen_CheckedChanged" AutoPostBack="true" />
													<asp:RadioButton ID="m_rdb_chi_khong_thuong_xuyen" runat="server" AutoPostBack="true"
														ForeColor="Black" Text="Chi không thường xuyên" GroupName="loai" OnCheckedChanged="m_rdb_chi_khong_thuong_xuyen_CheckedChanged" />
												</td>
											</tr>
											<tr>
												<td style="text-align: right">
													<span>Nội dung</span>
												</td>
												<td colspan="1">

													<asp:DropDownList ID="m_ddl_quoc_lo" runat="server" CssClass="cssDorpdownlist" Width="89.5%"
														AutoPostBack="true" OnSelectedIndexChanged="m_ddl_quoc_lo_SelectedIndexChanged">
													</asp:DropDownList>
													<asp:DropDownList ID="m_ddl_du_an" runat="server" CssClass="cssDorpdownlist" Width="89.5%"
														AutoPostBack="true" OnSelectedIndexChanged="m_ddl_du_an_SelectedIndexChanged">
													</asp:DropDownList>

												</td>
											</tr>

											<tr>
												<td style="text-align: right" style="width: 10%">
													<span>Số tiền nộp thuế</span>
												</td>
												<td style="width: 30%">
													<asp:TextBox ID="m_txt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="40%"></asp:TextBox>
												</td>
												<td style="text-align: right" style="width: 15%">
													<span>Số tiền thanh toán cho đơn vị hưởng</span>
												</td>
												<td style="width: 20%">
													<asp:TextBox ID="m_txt_so_tien_thanh_toan_cho_dv_huong" runat="server" CssClass="cssTextBox" Width="40%"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td style="text-align: right">
													<span>Ghi chú</span>
												</td>
												<td colspan="1">
													<asp:TextBox ID="m_txt_ghi_chu" runat="server" TextMode="MultiLine" CssClass="cssTextBox" Width="89%" placeholder="Ghi rõ nội dung thanh toán"></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td></td>
												<td>
													<asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px"
														OnClick="m_cmd_ctx_insert_Click" />
													<asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px"
														OnClick="m_cmd_ctx_update_Click" />
													<asp:Button ID="m_cmd_ctx_cancel" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px"
														OnClick="m_cmd_ctx_cancel_Click" />
													<asp:HiddenField ID="m_hdf_id_gd_uy_nhiem_chi" runat="server" />
													<asp:HiddenField ID="m_hdf_id_du_an_cong_trinh" runat="server" />
												</td>
											</tr>
										</asp:Panel>
										<tr>
											<td>
												<asp:Label ID="m_lbl_mess_detail" CssClass="cssManField" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td>
												<asp:GridView ID="m_grv_unc" runat="server" ShowFooter="true" AutoGenerateColumns="false"
													DataKeyNames="ID"
													OnRowDataBound="m_grv_unc_RowDataBound"
													OnRowCancelingEdit="m_grv_unc_RowCancelingEdit"
													OnRowEditing="m_grv_unc_RowEditing"
													OnRowDeleting="m_grv_unc_RowDeleting"
													OnRowUpdating="m_grv_unc_RowUpdating"
													OnRowCommand="m_grv_unc_RowCommand">
													<Columns>
														<asp:TemplateField HeaderText="Loại" HeaderStyle-Width="100px">
															<EditItemTemplate>
																<asp:RadioButton ID="m_rdb_grid_edit_ctx" Checked="true" AutoPostBack="true" runat="server" Text="Chi TX" GroupName="grid_loai" OnCheckedChanged="m_rdb_grid_edit_ctx_CheckedChanged" />
																<br />
																<asp:RadioButton ID="m_rdb_grid_edit_cktx" AutoPostBack="true" runat="server" Text="Chi không TX" GroupName="grid_loai" OnCheckedChanged="m_rdb_grid_edit_cktx_CheckedChanged" />
															</EditItemTemplate>
															<FooterTemplate>
																<asp:RadioButton ID="m_rdb_grid_ctx" Checked="true" AutoPostBack="true" runat="server" Text="Chi TX" GroupName="grid_loai" OnCheckedChanged="m_rdb_grid_ctx_CheckedChanged" />
																<br />
																<asp:RadioButton ID="m_rdb_grid_cktx" AutoPostBack="true" runat="server" Text="Chi không TX" GroupName="grid_loai" OnCheckedChanged="m_rdb_grid_cktx_CheckedChanged" />
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Quốc lộ/Dự án" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_quoc_lo_du_an" Text='<%#Eval(V_GD_UY_NHIEM_CHI.DISPLAY) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList ID="m_ddl_grid_edit_du_an_quoc_lo" runat="server"></asp:DropDownList>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:DropDownList ID="m_ddl_grid_du_an_quoc_lo" runat="server"></asp:DropDownList>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Nội dung thanh toán" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ghi_chu" Text='<%#Eval(V_GD_UY_NHIEM_CHI.GHI_CHU).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ghi_chu" runat="server" TextMode="MultiLine" Width="96%"
																	Text='<%#Eval(V_GD_UY_NHIEM_CHI.GHI_CHU) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ghi_chu" runat="server" TextMode="MultiLine" Width="96%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền nộp thuế" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_nop_thue" Text='<%#format_so_tien(Eval(V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE).ToString()) %>'
																	runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_nop_thue" runat="server" Style="text-align: right"
																	Text='<%#Eval(V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_nop_thue" runat="server" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền thanh toán cho đơn vị hưởng" ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_tt_cho_dv_huong" Text='<%#format_so_tien(Eval(V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG).ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_tt_cho_dv_huong" runat="server" Style="text-align: right"
																	Text='<%#Eval(V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_thanh_toan_cho_don_vi_huong" runat="server" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>

														<asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="150px" FooterStyle-HorizontalAlign="Center">
															<EditItemTemplate>
																<table style="width:100%">
																	<tr>
																		<td style="width:50%;text-align:center">
																			<asp:LinkButton ID="lbtnUpdate" runat="server" CommandName="Update" CssClass="cssManField"
																				Text="Cập nhật" /></td>
																		<td style="width:50%;text-align:center">
																			<asp:LinkButton ID="lbtnCancel" runat="server" CommandName="Cancel" CssClass="cssManField"
																				Text="Huỷ thao tác" /></td>
																	</tr>
																</table>


															</EditItemTemplate>
															<ItemTemplate>
																<table style="width:100%">
																	<tr>
																		<td style="width:50%;text-align:center">
																			<asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="cssButton"
																				Text="Sửa" Visible='<%#thao_tac_visible(Eval(V_GD_UY_NHIEM_CHI.ID).ToString()) %>' /></td>
																		<td style="width:50%;text-align:center">
																			<asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" CssClass="cssButton"
																				OnClientClick="return confirm('Are you sure you want to delete this record?')"
																				Text="Xoá" CausesValidation="false" Visible='<%#thao_tac_visible(Eval(V_GD_UY_NHIEM_CHI.ID).ToString()) %>' />
																		</td>
																	</tr>

																</table>


															</ItemTemplate>
															<FooterTemplate>
																<asp:LinkButton ID="lbtnAdd" runat="server" CommandName="Add" CssClass="cssManField"
																	Text="Thêm mới" />
															</FooterTemplate>
														</asp:TemplateField>
													</Columns>
												</asp:GridView>
											</td>
										</tr>
									</table>
								</td>
							</tr>

							<tr>
								<td colspan="3">
									<asp:Label ID="m_lbl_mess_grid" runat="server"></asp:Label></td>
							</tr>

							<tr>
								<td colspan="3">
									<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
										<tr>
											<td colspan="6">
												<asp:Label ID="m_lbl_mess_info_unc" CssClass="cssManField" runat="server"></asp:Label>
											</td>
										</tr>
										<tr>
											<td><span style="font-weight: bold">NỘP THUẾ</span></td>
											<td colspan="5" style="text-align: right"></asp:HyperLink>
											</td>
										</tr>
										<tr>
											<td colspan="1">
												<span>Tên đơn vị (Người nộp thuế):  </span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_nt_ten_don_vi" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Mã số thuế:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_so_thue" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã NDKT:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_ndkt" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã chương:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_chuong" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Cơ quan quản lý thu:</span>
											</td>
											<td colspan="3">
												<asp:TextBox ID="m_txt_nt_co_quan_quan_ly_thu" runat="server" CssClass="cssTextBox" Width="92.2%"></asp:TextBox>
											</td>
											<td>
												<span>Mã CQ thu:</span>
											</td>
											<td>
												<asp:TextBox ID="m_txt_nt_ma_cq_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>KBNN hạch toán thu:</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_nt_kbnn_hach_toan_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền nộp thuế (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_nt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td><span style="font-weight: bold">THANH TOÁN CHO ĐƠN VỊ HƯỞNG</span></td>
										</tr>
										<tr>
											<td>
												<span>Đơn vị nhận tiền:</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_ttdvh_don_vi_nhan_tien" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Mã ĐVQHNS:</span>
											</td>
											<td>
												<asp:TextBox ID="m_txt_ttdvh_ma_dvqhns" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
											</td>
											<td>
												<span>Địa chỉ:</span>
											</td>
											<td colspan="3">
												<asp:TextBox ID="m_txt_ttdvh_dia_chi" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Tài khoản:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_tai_khoan" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã CTMT, DA, và HTCT:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_ma_ctmt_da_htct" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Tại KBNN:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_tai_kbnn" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_ttdvh_so_tien_thanh_toan" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
											</td>
										</tr>

									</table>
								</td>

							</tr>
							<tr>
								<td colspan="3">
									<table style="border: 1px solid; width: 100%; border-right: hidden; border-left: hidden; border-bottom: hidden">
										<tr>
											<td style="width: 30%; text-align: center; vertical-align: top; border-right: 1px solid gray; border-left: hidden">
												<p style="font-weight: bold">Đơn vị trả tiền</p>
												<br />
												<br />
												<p style="font-size: 13px">&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Chủ tài khoản</p>

											</td>
											<td style="width: 70%; vertical-align: top">
												<table style="width: 100%">
													<tr>
														<td colspan="2" style="text-align: center; font-weight: bold">KBNN A</td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray; width: 50%">
															<p style="text-align: center; font-weight: bold" class="para">BỘ PHẬN KIỂM SOÁT CHI NGÀY:................</p>
															<br />
															<p style="font-size: 13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kiểm soát&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Phụ trách</p>
														</td>
														<td>
															<p style="text-align: center; font-weight: bold;" class="para">BỘ PHẬN KẾ TOÁN GHI SỔ NGÀY:................</p>
															<br />
															<p style="font-size: 13px">&nbsp;&nbsp;&nbsp;&nbsp; Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;&nbsp; Giám đốc&nbsp; </p>
														</td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray"></td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray"></td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray"></td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<table style="width: 100%; border-top: 1px solid gray">
										<tr>
											<td style="width: 50%; text-align: center; border-right: 1px solid gray; border-bottom: hidden">
												<p>NGÂN HÀNG A GHI SỐ NGÀY........</p>
												<br />
												<p class="para" style="font-weight: bold; text-align: center">Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Giám đốc</p>
											</td>
											<td style="text-align: center">
												<p>KBNN B, NGÂN HÀNG B GHI SỐ NGÀY........</p>
												<br />
												<p class="para" style="font-weight: bold; text-align: center">Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;Giám đốc</p>
											</td>
										</tr>
										<tr>
											<td style="border-right: 1px solid gray; border-bottom: hidden"></td>
										</tr>
										<tr>
											<td style="border-right: 1px solid gray"></td>
										</tr>
										<tr>
											<td style="border-right: 1px solid gray"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="6" style="text-align: center">
									<asp:Button ID="m_cmd_save_info_unc" Text="Lưu thông tin" runat="server" CssClass="cssButton" Height="24px" Width="98px"
										OnClick="m_cmd_save_info_unc_Click" />
									<asp:HyperLink ID="m_cmd_print" runat="server" CssClass="cssButton" Height="24px" Width="98px"
										Target="_blank" Text="Xem bản in" Visible="false"></asp:HyperLink></td>
							</tr>
						</table>
					</td>
					<%--<td><input type="button" id="m_cmd_print" onclick="ExportToExcel()" value="Print" /><//td>--%>
				</tr>
			</table>
			</td>
				</tr>
			
			</table>


		</ContentTemplate>
		<Triggers>
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

