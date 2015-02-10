<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F304_nhap_giai_ngan_theo_unc.aspx.cs" Inherits="QuanLyDuToan.DuToan.F304_nhap_giai_ngan_theo_unc" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebUS" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.radioButtonList {
			list-style: none;
			margin: 0px 0px 0px 12px;
			padding: 0;
		}

			.radioButtonList.horizontal li {
				display: list-item;
			}

			.radioButtonList label {
				display: inline-block;
			}

		.cssTextBox {
			display: inline;
		}

		.radio-inline tr td {
			width: 169px;
			padding-left: 8px;
		}
	</style>
	<script>
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {
                <%-- $("#<%=m_ddl_loai_nv.ClientID%>").select2();
                $("#<%=m_ddl_cong_trinh.ClientID%>").select2();--%>

				$(".select2").select2();
				$("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy', language: 'vi' });

			 }
		 }
		 $(document).ready(function () {
            <%--  $("#<%=m_ddl_loai_nv.ClientID%>").select2();
            $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            $("#<%=m_ddl_du_an.ClientID%>").select2();--%>
		 	$(".select2").select2();
		 	$("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy', language: 'vi' });
		 }
       )
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table style="margin: auto">
				<tr>
					<td style="font-weight: bold; font-size: 24px; text-align: center">UỶ NHIỆM CHI</td>
				</tr>
				<tr>
					<td style="text-align: center">CHUYỂN KHOẢN, CHUYỂN TIỀN ĐIỆN TỬ</td>
				</tr>
				<tr>
					<td style="text-align: center">
						<div id="datetimepicker1" class="input-group date datepicker" style="white-space: nowrap; margin: 0 auto;">
							<label for="m_txt_ngay_thang" style="float: left; width: 95px; margin-top: 4px;">Lập ngày (*): </label>
							<asp:TextBox ID="m_txt_ngay_thang" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control" Height="30px" Width="164px">
							</asp:TextBox>
							<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
					</td>
				</tr>
				<tr>
					<td style="width: 900px;">
						<table id="main_table" style="width: 100%; border-collapse: separate;" class="cssTable table" border="0">
							<tr>
								<td>

									<table style="width: 100%;" class="table bordertop0" border="0">

										<tr>
											<td colspan="2">
												<asp:Label ID="m_lbl_mess_master" runat="server" CssClass="cssManField"></asp:Label></td>
										</tr>

										<tr>
											<td style="width: 25%; text-align: right">
												<span>Đơn vị trả tiền</span>
											</td>
											<td style="width: 30%">
												<asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" Width="200px" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
											</td>
											<td style="width: 25%"></td>
											<td style="width: 25%"></td>
										</tr>
										<tr>
											<td style="text-align: right">
												<span>Địa chỉ</span>
											</td>
											<td colspan="2">
												<asp:Label ID="m_lbl_dia_chi" runat="server" ForeColor="Black"></asp:Label>
											</td>

										</tr>
										<tr>
											<td style="text-align: right">
												<span>Số UNC (*)</span>
											</td>
											<td colspan="2">
												<asp:TextBox ID="m_txt_so_unc" runat="server" placeholder="59Qtu" CssClass="cssTextBox form-control" Width="200px"></asp:TextBox>
												<asp:DropDownList ID="m_ddl_unc" CssClass="select2" Visible="false" runat="server" Width="200px"
													OnSelectedIndexChanged="m_ddl_unc_SelectedIndexChanged" AutoPostBack="true">
												</asp:DropDownList>
												<asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn UNC" CssClass="btn btn-sm btn-primary"
													OnClick="m_cmd_chon_unc_Click" />
												<asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới UNC" CssClass="btn btn-sm btn-primary"
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
											<td colspan="2">
												<asp:RadioButtonList ID="m_rbl_ma_tkkt" runat="server" RepeatDirection="Horizontal" Enabled="false" CssClass="radioButtonList radio-inline">
												</asp:RadioButtonList>
											</td>

										</tr>
										<tr>
											<td style="text-align: right">
												<span>&nbsp;&nbsp; Mã CTMT, DA và HTCT (*):</span>
											</td>
											<td>
												<asp:TextBox ID="m_txt_ma_ctmt_da_htct" Width="150px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="text-align: right">
												<span>&nbsp;&nbsp; Mã ĐVQHNS:</span>
											</td>
											<td>
												<asp:Label ID="m_lbl_ma_dvqhns" runat="server" ForeColor="Black"></asp:Label>
											</td>
										</tr>
										<tr>
											<td></td>
											<td style="margin: auto;">
												<asp:Button ID="m_cmd_luu_unc" runat="server" CssClass="btn btn-sm btn-success" OnClick="m_cmd_luu_unc_Click" Text="Lưu Uỷ nhiệm chi" />
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

														<asp:TemplateField HeaderText="Quốc lộ/Dự án" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_quoc_lo_du_an" Text='<%#Eval(GRID_GIAI_NGAN.NOI_DUNG) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:RadioButton ID="m_rdb_grid_edit_theo_quoc_lo_cong_trinh" CssClass="radio-inline" GroupName="edit_loai_chi" Checked="true" runat="server" Text="Theo Quốc lộ/Công trình" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_edit_theo_quoc_lo_cong_trinh_CheckedChanged" />
																<br />
																<asp:RadioButton ID="m_rdb_grid_edit_theo_chuong_loai_khoan_muc" CssClass="radio-inline" GroupName="edit_loai_chi" runat="server" Text="Chi theo Loại khoản mục" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_edit_theo_chuong_loai_khoan_muc_CheckedChanged" />
																<br />
																<asp:DropDownList ID="m_ddl_grid_edit_loai_nhiem_vu" CssClass="select2" OnSelectedIndexChanged="m_ddl_grid_edit_loai_nhiem_vu_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="200px"></asp:DropDownList>
																<br />
																<asp:DropDownList ID="m_ddl_grid_edit_du_an_quoc_lo" CssClass="select2" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="m_ddl_grid_edit_du_an_quoc_lo_SelectedIndexChanged"></asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_edit_du_an" runat="server" CssClass="select2" Width="200px" AutoPostBack="true"></asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_edit_muc_tieu_muc" CssClass="select2" runat="server" Width="200px"></asp:DropDownList>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:RadioButton ID="m_rdb_grid_theo_quoc_lo_cong_trinh" CssClass="radio-inline" GroupName="loai_chi" Checked="true" runat="server" Text="Theo Quốc lộ/Công trình" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_theo_quoc_lo_cong_trinh_CheckedChanged" />
																<br />
																<asp:RadioButton ID="m_rdb_grid_theo_chuong_loai_khoan_muc" CssClass="radio-inline" GroupName="loai_chi" runat="server" Text="Chi theo Loại khoản mục" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_theo_chuong_loai_khoan_muc_CheckedChanged" />
																<br />
																<asp:DropDownList ID="m_ddl_grid_loai_nhiem_vu" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true" OnSelectedIndexChanged="m_ddl_grid_loai_nhiem_vu_SelectedIndexChanged">
																</asp:DropDownList>
																<br />
																<asp:DropDownList ID="m_ddl_grid_du_an_quoc_lo" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true" OnSelectedIndexChanged="m_ddl_grid_du_an_quoc_lo_SelectedIndexChanged">
																</asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_du_an" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true">
																</asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_muc_tieu_muc" CssClass="select2" runat="server" Width="200px"></asp:DropDownList>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Nội dung thanh toán" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ghi_chu" Text='<%#Eval(GRID_GIAI_NGAN.GHI_CHU).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ghi_chu" CssClass="form-control" runat="server" TextMode="MultiLine" Width="96%" Height="100%"
																	Text='<%#Eval(GRID_GIAI_NGAN.GHI_CHU) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ghi_chu" runat="server" CssClass="form-control" TextMode="MultiLine" Width="96%" Height="100%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền nộp thuế" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_nop_thue" Width="120px" Text='<%# CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.SO_TIEN_NT).ToString()) %>'
																	runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_nop_thue" Width="120px" runat="server" Style="text-align: right" CssClass="csscurrency form-control format_so_tien"
																	Text='<%#Eval(GRID_GIAI_NGAN.SO_TIEN_NT) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_nop_thue" Width="120px" runat="server" CssClass="csscurrency  format_so_tien  form-control" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền thanh toán cho đơn vị hưởng" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_tt_cho_dv_huong" Width="100px" Text='<%#CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.SO_TIEN_TTCDVH).ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_tt_cho_dv_huong" Width="120px" runat="server" CssClass="csscurrency form-control  format_so_tien" Style="text-align: right"
																	Text='<%#Eval(GRID_GIAI_NGAN.SO_TIEN_TTCDVH) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_thanh_toan_cho_don_vi_huong" Width="120px" CssClass="csscurrency  format_so_tien form-control" runat="server" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Tổng" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_tong_tien" Text='<%#CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.TONG).ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="200px" FooterStyle-HorizontalAlign="Center">
															<EditItemTemplate>
																<table class="table bordertop0" style="width: 100%">
																	<tr>
																		<td style="width: 50%; text-align: center">
																			<asp:Button ID="lbtnUpdate" CssClass="btn btn-success btn-sm" runat="server" CommandName="Update" ForeColor="White"
																				Text="Cập nhật" /></td>
																		<td style="width: 50%; text-align: center">
																			<asp:Button ID="lbtnCancel" CssClass="btn btn-sm" runat="server" CommandName="Cancel"
																				Text="Huỷ thao tác" /></td>
																	</tr>
																</table>


															</EditItemTemplate>
															<ItemTemplate>
																<table style="width: 100%">
																	<tr>
																		<td style="width: 50%; text-align: center">
																			<asp:LinkButton ID="lbtnEdit" runat="server" CommandName="Edit" CssClass="btn btn-sm"
																				Text="Sửa" Visible='<%#isVisible_thao_tac(Eval(GRID_GIAI_NGAN.ID).ToString()) %>' ForeColor="White">   <img alt="Sửa" src="../Images/Button/edit.png" /></asp:LinkButton></td>
																		<td style="width: 50%; text-align: center">
																			<asp:LinkButton ID="lbtnDelete" runat="server" CommandName="Delete" CssClass="btn btn-sm btn-"
																				OnClientClick="return confirm('Bạn có chắc chắn muốn xoá mục chi này không?')"
																				Text="Xoá" CausesValidation="false" Visible='<%#isVisible_thao_tac(Eval(GRID_GIAI_NGAN.ID).ToString()) %>'
																				ForeColor="White"><img alt="Xóa" src="../Images/Button/deletered.png" /> </asp:LinkButton>

																		</td>
																	</tr>

																</table>


															</ItemTemplate>
															<FooterTemplate>
																<asp:LinkButton ID="lbtnAdd" runat="server" CssClass="btn btn-sm btn-success" CommandName="Add" ForeColor="White"
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
									<table class="table bordertop0" cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
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
												<asp:TextBox ID="m_txt_nt_ten_don_vi" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Mã số thuế:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_so_thue" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã NDKT:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_ndkt" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã chương:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_nt_ma_chuong" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Cơ quan quản lý thu:</span>
											</td>
											<td colspan="3">
												<asp:TextBox ID="m_txt_nt_co_quan_quan_ly_thu" runat="server" CssClass="cssTextBox form-control" Width="92.2%"></asp:TextBox>
											</td>
											<td>
												<span>Mã CQ thu:</span>
											</td>
											<td>
												<asp:TextBox ID="m_txt_nt_ma_cq_thu" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>KBNN hạch toán thu:</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_nt_kbnn_hach_toan_thu" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền nộp thuế (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_nt_so_tien_nop_thue" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
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
												<asp:TextBox ID="m_txt_ttdvh_don_vi_nhan_tien" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Mã ĐVQHNS:</span>
											</td>
											<td>
												<asp:TextBox ID="m_txt_ttdvh_ma_dvqhns" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td>
												<span>Địa chỉ:</span>
											</td>
											<td colspan="3">
												<asp:TextBox ID="m_txt_ttdvh_dia_chi" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Tài khoản:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_tai_khoan" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Mã CTMT, DA, và HTCT:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_ma_ctmt_da_htct" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Tại KBNN:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_ttdvh_tai_kbnn" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_ttdvh_so_tien_thanh_toan" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>

									</table>
								</td>

							</tr>
							<tr>
								<td colspan="3">
									<table class="table bordertop0" style="border: 1px solid; width: 100%; border-right: hidden; border-left: hidden; border-bottom: hidden">
										<tr>
											<td style="width: 30%; text-align: center; vertical-align: top; border-right: 1px solid gray; border-left: hidden">
												<p style="font-weight: bold">Đơn vị trả tiền</p>
												<br />
												<br />
												<p style="font-size: 13px">&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp;Chủ tài khoản</p>

											</td>
											<td style="width: 70%; vertical-align: top">
												<table class="table bordertop0" style="width: 100%; margin-bottom: 0px;">
													<tr>
														<td colspan="2" style="text-align: center; font-weight: bold">KBNN A</td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray; width: 50%">
															<p style="text-align: center; font-size: 13px; font-weight: bold; width: 293px;" class="para">BỘ PHẬN KIỂM SOÁT CHI NGÀY:..............</p>
															<br />
															<p style="font-size: 13px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kiểm soát&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp;&nbsp;Phụ trách</p>
														</td>
														<td>
															<p style="text-align: center; font-size: 13px; font-weight: bold;" class="para">BỘ PHẬN KẾ TOÁN GHI SỔ NGÀY:................</p>
															<br />
															<p style="font-size: 13px; width: 305px;">&nbsp;&nbsp;&nbsp;&nbsp; Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Giám đốc&nbsp; </p>
														</td>
													</tr>

												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<table class="table bordertop0" style="width: 100%; border-top: 1px solid gray;">
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

									</table>
								</td>
							</tr>
							<tr>
								<td colspan="6" style="text-align: center">
									<asp:Button ID="m_cmd_save_info_unc" Text="Lưu thông tin" runat="server" CssClass="btn btn-sm btn-success"
										OnClick="m_cmd_save_info_unc_Click" />
									<asp:HyperLink ID="m_cmd_print" runat="server" CssClass="btn btn-sm btn-primary" ForeColor="White"
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

