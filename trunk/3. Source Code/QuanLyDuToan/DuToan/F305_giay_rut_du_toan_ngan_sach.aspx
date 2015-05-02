<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F305_giay_rut_du_toan_ngan_sach.aspx.cs" Inherits="QuanLyDuToan.DuToan.F305_giay_rut_du_toan_ngan_sach" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebUS" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		label {
			white-space: nowrap;
			width: 200px;
			padding-right: 3px;
		}

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
				if ($("#<%=m_ddl_don_vi.ClientID%> option").length < 2) {
					$("#<%=m_ddl_don_vi.ClientID%>").parent().find('.select2-selection__arrow').addClass('hidden');
				}

				function getMaCLKM(selectText, CLKM) {
					strCLKM = $.grep(arr_str, function (e) {
						e = e + '';
						if (e.indexOf(CLKM + '') != -1)
							return e.trim();
					}) + '';
					return strCLKM.replace(CLKM + '', '').trim();
				}
				$('.ddl_footer_tieu_muc').change(function () {
					textddl = $(this).children("option").filter(":selected").text() + '';
					arr_str = textddl.split(',');
					strLoaiKhoan = getMaCLKM(arr_str, 'Loại');
					strLoai = strLoaiKhoan.split(" - ")[0];
					strKhoan = strLoaiKhoan.split(" - ")[1];
					$(this).parent().parent().find('.txt_footer_ma_chuong').val('021');
					$(this).parent().parent().find('.txt_footer_ma_loai').val(strLoai);
					//$(this).parent().parent().find('.txt_footer_ma_khoan').val(strKhoan);
					$(this).parent().parent().find('.txt_footer_noi_dung_thanh_toan').focus();
				});
				$('.ddl_edit_tieu_muc').change(function () {
					textddl = $(this).children("option").filter(":selected").text() + '';
					arr_str = textddl.split(',');
					strLoaiKhoan = getMaCLKM(arr_str, 'Loại');
					strLoai = strLoaiKhoan.split(" - ")[0];
					strKhoan = strLoaiKhoan.split(" - ")[1];
					$(this).parent().parent().find('.txt_edit_ma_chuong').val('021');
					$(this).parent().parent().find('.txt_edit_ma_loai').val(strLoai);
					//$(this).parent().parent().find('.txt_edit_ma_khoan').val(strKhoan);
					$(this).parent().parent().find('.txt_edit_noi_dung_thanh_toan').focus();
				});

			}
		}
		$(document).ready(function () {
            <%--  $("#<%=m_ddl_loai_nv.ClientID%>").select2();
            $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            $("#<%=m_ddl_du_an.ClientID%>").select2();--%>
			$(".select2").select2();
			$("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy', language: 'vi' });
			if ($("#<%=m_ddl_don_vi.ClientID%> option").length < 2) {
				$("#<%=m_ddl_don_vi.ClientID%>").parent().find('.select2-selection__arrow').addClass('hidden');
			}
			function getMaCLKM(selectText, CLKM) {
				strCLKM = $.grep(arr_str, function (e) {
					e = e + '';
					if (e.indexOf(CLKM + '') != -1)
						return e.trim();
				}) + '';
				return strCLKM.replace(CLKM + '', '').trim();
			}
			$('.ddl_footer_tieu_muc').change(function () {
				textddl = $(this).children("option").filter(":selected").text() + '';
				arr_str = textddl.split(',');
				strLoaiKhoan = getMaCLKM(arr_str, 'Loại');
				strLoai = strLoaiKhoan.split(" - ")[0];
				strKhoan = strLoaiKhoan.split(" - ")[1];
				$(this).parent().parent().find('.txt_footer_ma_chuong').val('021');
				$(this).parent().parent().find('.txt_footer_ma_loai').val(strLoai);
				//$(this).parent().parent().find('.txt_footer_ma_khoan').val(strKhoan);
				$(this).parent().parent().find('.txt_footer_noi_dung_thanh_toan').focus();
			});

			$('.ddl_edit_tieu_muc').change(function () {
				textddl = $(this).children("option").filter(":selected").text() + '';
				arr_str = textddl.split(',');
				strLoaiKhoan = getMaCLKM(arr_str, 'Loại');
				strLoai = strLoaiKhoan.split(" - ")[0];
				strKhoan = strLoaiKhoan.split(" - ")[1];
				$(this).parent().parent().find('.txt_edit_ma_chuong').val('021');
				$(this).parent().parent().find('.txt_edit_ma_loai').val(strLoai);
				//$(this).parent().parent().find('.txt_edit_ma_khoan').val(strKhoan);
				$(this).parent().parent().find('.txt_edit_noi_dung_thanh_toan').focus();
			});
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
					<td style="border: 1px solid gray; width: 20%">Không ghi vào khu vực này</td>
					<td style="font-weight: bold; font-size: 24px; text-align: center; width: 60%">GIẤY RÚT DỰ TOÁN NGÂN SÁCH</td>
					<td style="border: 1px solid gray; width: 20%; text-align: center">Mẫu C2-02/NS		
						<br />
					(Thông tư số 08/2013/TT-BTC ngày
10/01/2013 của Bộ Tài chính)
				</tr>
				<tr>
					<td style="text-align: center" colspan="3">
						<div id="datetimepicker1" class="input-group date datepicker" style="white-space: nowrap; margin: 0 auto;">
							<label for="m_txt_ngay_thang" style="float: left; width: 95px; margin-top: 4px;">Lập ngày (*): </label>
							<asp:TextBox ID="m_txt_ngay_thang" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Height="30px" Width="164px">
							</asp:TextBox>
							<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
					</td>
				</tr>
				<tr>
					<td></td>
					<td style="text-align: right">
						<div class="col-sm-12">
							<div class="col-sm-7" style="border-right: 1px solid gray">
								<div class="col-sm-12">
									<asp:CheckBox ID="m_ckb_thuc_chi" runat="server" Text="Thực chi" TextAlign="Left" />
									<asp:CheckBox ID="m_ckb_tam_ung" runat="server" Text="Tạm ứng" TextAlign="Left" />
								</div>
								<div class="col-sm-12">
									<asp:CheckBox ID="m_ckb_ung_truoc_du_dk_thanh_toan" runat="server" Text="Ứng trước đủ ĐK thanh toán" TextAlign="Left" />
									<asp:CheckBox ID="m_ckb_ung_truoc_chua_du_dk_thanh_toan" runat="server" Text="Ứng trước chưa đủ ĐK thanh toán" TextAlign="Left" />
								</div>

							</div>
							<div class="col-sm-5">
								<div class="col-sm-12">
									<asp:CheckBox ID="m_ckb_chuyen_khoan" runat="server" Text="Chuyển khoản" TextAlign="Left" />
								</div>
								<div class="col-sm-12">
									<asp:CheckBox ID="m_ckb_tien_mat" runat="server" Text="Tiền mặt" TextAlign="Left" />
								</div>
							</div>
						</div>
					</td>
					<td></td>
				</tr>

				<tr>
					<td style="width: 900px;" colspan="3">
						<table id="main_table" style="width: 100%; border-collapse: separate;" class="cssTable " border="0">
							<tr>
								<td>

									<table style="width: 100%;" class="table bordertop0" border="0">

										<tr>
											<td colspan="2">
												<asp:Label ID="m_lbl_mess_master" runat="server" CssClass="cssManField"></asp:Label></td>
										</tr>

										<tr>
											<td colspan="4">
												<div class="col-sm-12">
													<div class="col-sm-3 text-right">
														<span>Đơn vị rút dự toán:</span>
													</div>
													<div class="col-sm-3">
														<asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" Width="200px" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
													</div>
													<div class="col-sm-3 text-right">Mã ĐVQHNS:</span></div>
													<div class="col-sm-3">
														<asp:TextBox ID="m_lbl_ma_dvqhns" ForeColor="Black" Width="150px" runat="server" CssClass="cssTextBox form-control" Enabled="false"></asp:TextBox>
													</div>
												</div>
											</td>
										</tr>
										<tr>
											<td colspan="3">
												<div class="col-sm-12">
													<div class="col-sm-3 text-right"><span>Số chứng từ(*)</span></div>

													<div class="col-sm-3">
														<asp:TextBox ID="m_txt_so_unc" runat="server" placeholder="59Qtu" CssClass="cssTextBox form-control" Width="200px"></asp:TextBox>
														<asp:DropDownList ID="m_ddl_dm_giai_ngan" CssClass="select2" Visible="false" runat="server" Width="200px"
															OnSelectedIndexChanged="m_ddl_dm_giai_ngan_SelectedIndexChanged" AutoPostBack="true">
														</asp:DropDownList>
													</div>
													<div class="col-sm-6">
														<asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn chứng từ đã nhập" CssClass="btn btn-sm btn-primary"
															OnClick="m_cmd_chon_unc_Click" />
														<asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới chứng từ" CssClass="btn btn-sm btn-primary"
															OnClick="m_cmd_nhap_moi_unc_Click" />
													</div>

												</div>
											</td>
										</tr>
										<tr>
											<td colspan="3">
												<div class="col-sm-12">
													<div class="col-sm-3 text-right">
														<span>Tài khoản:
														</span>
													</div>
													<div class="col-sm-3">
														<asp:RadioButton ID="m_rdb_ma_tkkt_ns" Checked="true" runat="server" GroupName="ma_tkkt" />
														<asp:RadioButton ID="m_rdb_ma_tkkt_ns_2" runat="server" GroupName="ma_tkkt" /><br />
														<asp:RadioButton ID="m_rdb_ma_tkkt_ns_3" runat="server" GroupName="ma_tkkt" />
														<asp:RadioButton ID="m_rdb_ma_tkkt_ns_4" runat="server" GroupName="ma_tkkt" />
													</div>
													<div class="col-sm-3 text-right">
														<span>Tại KBNN:	

														</span>
													</div>
													<div class="col-sm-3">
														<asp:TextBox ID="m_txt_tai_kho_bac_nha_nuoc" ForeColor="Black" Width="150px" runat="server" CssClass="cssTextBox form-control" Enabled="false"></asp:TextBox>
													</div>
												</div>
											</td>
										</tr>

										<tr>
											<td colspan="3">
												<div class="col-sm-12">
													<div class="col-sm-3 text-right">
														<span>Mã cấp NS:

														</span>
													</div>
													<div class="col-sm-3">
														<asp:TextBox ID="m_txt_ma_cap_ns" ForeColor="Black" Width="200px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>
													<div class="col-sm-6">
														<span>Tên CTMT, DA:</span>
														<asp:TextBox ID="m_txt_ten_ctmt_da" ForeColor="Black" Width="283px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>
												</div>
											</td>
										</tr>
										<tr>
											<td colspan="3">
												<div class="col-sm-12">
													<div class="col-sm-3"></div>
													<div class="col-sm-3"></div>
													<div class="col-sm-3 text-right">
														<span>Mã CTMT, DA(*):</span>
													</div>
													<div class="col-sm-3">
														<asp:TextBox ID="m_txt_ma_ctmt_da_htct" ForeColor="Black" Width="150px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>
												</div>
											</td>
										</tr>
										<tr>
											<td colspan="3">
												<div class="col-sm-12">
													<div class="col-sm-3 text-right">
														<span>Năm NS:  
														</span>
														<asp:TextBox ID="m_txt_nam_ns" ForeColor="Black" Width="60px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>

													<div class="col-sm-3">
														<span>Số CKC, HĐK:  
														</span>
														<asp:TextBox ID="m_txt_so_ckc_hdk" ForeColor="Black" Width="118px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>
													<div class="col-sm-6">
														<span>Số CKC, HĐTH:	
 
														</span>
														<asp:TextBox ID="m_txt_so_ckc_hdth" ForeColor="Black" Width="279px" runat="server" CssClass="cssTextBox form-control"></asp:TextBox>
													</div>

												</div>
											</td>
										</tr>

										<tr>
											<td colspan="3">
												<div class="col-sm-12 text-center">
													<asp:Button ID="m_cmd_luu_unc" runat="server" CssClass="btn btn-sm btn-success" OnClick="m_cmd_luu_unc_Click" Text="Lưu Giấy rút dự toán Ngân sách" />
												</div>
											</td>
										</tr>
										<tr>
											<td></td>
											<td>
												<asp:HiddenField ID="m_hdf_id_dm_giai_ngan" runat="server" />
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
													HeaderStyle-BackColor="LightGray"
													DataKeyNames="ID"
													EditRowStyle-Height="80px"
													FooterRowStyle-Height="80px"
													OnRowDataBound="m_grv_unc_RowDataBound"
													OnRowCancelingEdit="m_grv_unc_RowCancelingEdit"
													OnRowEditing="m_grv_unc_RowEditing"
													OnRowDeleting="m_grv_unc_RowDeleting"
													OnRowUpdating="m_grv_unc_RowUpdating"
													OnRowCommand="m_grv_unc_RowCommand">
													<Columns>
														<asp:TemplateField HeaderText="Mã NDKT" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_quoc_lo_du_an" Text='<%#Eval(GRID_GIAI_NGAN.NOI_DUNG) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:DropDownList ID="m_ddl_grid_edit_muc_tieu_muc" CssClass="select2 ddl_edit_tieu_muc" runat="server" Width="200px"></asp:DropDownList>
																<asp:RadioButton ID="m_rdb_grid_edit_theo_quoc_lo_cong_trinh" Visible="false" CssClass="radio-inline" GroupName="edit_loai_chi" Checked="false" runat="server" Text="Chi theo dự án" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_edit_theo_quoc_lo_cong_trinh_CheckedChanged" />
																<asp:RadioButton ID="m_rdb_grid_edit_theo_chuong_loai_khoan_muc" Visible="false" Checked="true" CssClass="radio-inline" GroupName="edit_loai_chi" runat="server" Text="Chi theo mục lục Ngân sách" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_edit_theo_chuong_loai_khoan_muc_CheckedChanged" />
																<asp:DropDownList ID="m_ddl_grid_edit_loai_nhiem_vu" Visible="false" CssClass="select2" OnSelectedIndexChanged="m_ddl_grid_edit_loai_nhiem_vu_SelectedIndexChanged" AutoPostBack="true" runat="server" Width="200px"></asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_edit_du_an_quoc_lo" CssClass="select2" runat="server" AutoPostBack="true" Width="200px" OnSelectedIndexChanged="m_ddl_grid_edit_du_an_quoc_lo_SelectedIndexChanged"></asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_edit_du_an" runat="server" CssClass="select2" Width="200px" AutoPostBack="true"></asp:DropDownList>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:DropDownList ID="m_ddl_grid_muc_tieu_muc" CssClass="select2 ddl_footer_tieu_muc" runat="server" Width="200px"></asp:DropDownList>
																<asp:RadioButton ID="m_rdb_grid_theo_quoc_lo_cong_trinh" CssClass="radio-inline" GroupName="loai_chi" Checked="false" runat="server" Text="Chi theo dự án" AutoPostBack="true" Visible="false" OnCheckedChanged="m_rdb_grid_theo_quoc_lo_cong_trinh_CheckedChanged" />
																<asp:RadioButton ID="m_rdb_grid_theo_chuong_loai_khoan_muc" Visible="false" CssClass="radio-inline" Checked="true" GroupName="loai_chi" runat="server" Text="Chi theo mục lục Ngân sách" AutoPostBack="true" OnCheckedChanged="m_rdb_grid_theo_chuong_loai_khoan_muc_CheckedChanged" />
																<asp:DropDownList ID="m_ddl_grid_loai_nhiem_vu" Visible="false" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true" OnSelectedIndexChanged="m_ddl_grid_loai_nhiem_vu_SelectedIndexChanged">
																</asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_du_an_quoc_lo" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true" OnSelectedIndexChanged="m_ddl_grid_du_an_quoc_lo_SelectedIndexChanged">
																</asp:DropDownList>
																<asp:DropDownList ID="m_ddl_grid_du_an" CssClass="select2" runat="server" Width="200px"
																	AutoPostBack="true">
																</asp:DropDownList>

															</FooterTemplate>
														</asp:TemplateField>

														<asp:TemplateField HeaderText="Nội dung thanh toán" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ghi_chu" Text='<%#Eval(GRID_GIAI_NGAN.GHI_CHU).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ghi_chu" CssClass="form-control txt_edit_noi_dung_thanh_toan" runat="server" TextMode="MultiLine" Width="96%" Height="100%"
																	Text='<%#Eval(GRID_GIAI_NGAN.GHI_CHU) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ghi_chu" runat="server" CssClass="form-control txt_footer_noi_dung_thanh_toan" TextMode="MultiLine" Width="96%" Height="100%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Mã Chương" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_chuong" Text='<%#Eval(GRID_GIAI_NGAN.MA_CHUONG).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ma_chuong" CssClass="form-control txt_edit_ma_chuong" runat="server" Width="96%"
																	Text='<%#Eval(GRID_GIAI_NGAN.MA_CHUONG) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ma_chuong" runat="server" CssClass="form-control txt_footer_ma_chuong" Width="96%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Mã ngành KT" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_nganh_kt" Text='<%#Eval(GRID_GIAI_NGAN.MA_LOAI).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ma_nganh_kt" CssClass="form-control txt_edit_ma_loai" runat="server" Width="96%"
																	Text='<%#Eval(GRID_GIAI_NGAN.MA_LOAI) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ma_nganh_kt" runat="server" CssClass="form-control txt_footer_ma_loai" Width="96%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Mã nguồn NSNN" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_nguon_nsnn" Text='<%#Eval("MA_NGUON_NSNN") %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_ma_nguon_nsnn" CssClass="form-control txt_edit_ma_khoan" runat="server" Width="96%"
																	Text='<%#Eval("MA_NGUON_NSNN") %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_ma_nguon_nsnn" runat="server" CssClass="form-control txt_footer_ma_khoan" Width="96%" Style="text-align: left"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền nộp thuế" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_nop_thue" Width="90px" Text='<%# CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.SO_TIEN_NT).ToString()) %>'
																	runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_nop_thue" Width="90px" runat="server" Style="text-align: right" CssClass="csscurrency form-control format_so_tien"
																	Text='<%#Eval(GRID_GIAI_NGAN.SO_TIEN_NT) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_nop_thue" Width="90px" runat="server" CssClass="csscurrency  format_so_tien  form-control" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Số tiền thanh toán cho đơn vị hưởng" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_tt_cho_dv_huong" Width="90px" Text='<%#CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.SO_TIEN_TTCDVH).ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:TextBox ID="m_txt_grid_edit_so_tien_tt_cho_dv_huong" Width="90px" runat="server" CssClass="csscurrency form-control  format_so_tien" Style="text-align: right"
																	Text='<%#Eval(GRID_GIAI_NGAN.SO_TIEN_TTCDVH) %>'></asp:TextBox>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:TextBox ID="m_txt_grid_so_tien_thanh_toan_cho_don_vi_huong" Width="90px" CssClass="csscurrency  format_so_tien form-control" runat="server" Style="text-align: right"></asp:TextBox>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Tổng" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_tong_tien" Text='<%#CCommonFunction.getMoney_string_format(Eval(GRID_GIAI_NGAN.TONG).ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<EditItemTemplate>
																<asp:Label ID="m_lbl_edit_tong_tien" runat="server" CssClass="lbl_edit_tong_tien"></asp:Label>
															</EditItemTemplate>
															<FooterTemplate>
																<asp:Label ID="m_lbl_footer_tong_tien" runat="server" CssClass="lbl_footer_tong_tien"></asp:Label>
															</FooterTemplate>
														</asp:TemplateField>
														<asp:TemplateField HeaderText="Thao tác" HeaderStyle-Width="100px" FooterStyle-HorizontalAlign="Center">
															<EditItemTemplate>
																<table class="table bordertop0" style="width: 100%">
																	<tr>
																		<td style="text-align: center">
																			<asp:Button ID="lbtnUpdate" CssClass="btn btn-success btn-sm" runat="server" CommandName="Update" ForeColor="White"
																				Text="Cập nhật" />
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
												<span>Địa chỉ:</span>
											</td>
											<td colspan="5">
												<asp:TextBox ID="m_txt_ttdvh_dia_chi" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
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
												<span>Mã CTMT, DA, và HTCT:</span>
											</td>
											<td colspan="1">
												<asp:TextBox ID="m_txt_ttdvh_ma_ctmt_da_htct" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
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
												<span>Tại KBNN:</span>
											</td>
											<td colspan="3">
												<asp:TextBox ID="m_txt_ttdvh_tai_kbnn" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td>Hoặc người nhận tiền:</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>CMND số:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_cmnd_so" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Cấp ngày:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_cap_ngay" runat="server" CssClass="cssTextBox form-control" Width="80%"></asp:TextBox>
											</td>
											<td style="width: 5%">
												<span>Nơi cấp:</span>
											</td>
											<td style="width: 10%">
												<asp:TextBox ID="m_txt_noi_cap" runat="server" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
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
									<table class="table bordertop0" style="width: 100%; border-top: 1px solid gray;">
										<tr>
											<td style="width: 50%; text-align: center; border-right: 1px solid gray; border-bottom: hidden">
												<p style="font-weight: bold">
													Bộ phận kiểm soát của KBNN			
												</p>
												<p>Ngày.....tháng.....năm.........</p>
												<p class="para" style="font-weight: bold; text-align: center">Kiểm toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Phụ trách</p>
												<br />
												<br />
											</td>
											<td style="text-align: center">
												<p style="font-weight: bold">
													Đơn vị sử dụng ngân sách						
												</p>

												<p>Ngày.....tháng.....năm.........</p>
												<p class="para" style="font-weight: bold; text-align: center">Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Thủ trưởng đơn vị</p>
												<br />
												<br />
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
												<p style="font-weight: bold">
													Người nhận tiền	
		
												</p>
												<p>
													(Ký, ghi rõ họ, tên)	
												</p>


												<br />
												<br />

											</td>
											<td style="width: 70%; vertical-align: top">
												<table class="table bordertop0" style="width: 100%; margin-bottom: 0px;">
													<tr>
														<td style="border-right: 1px solid gray; width: 50%">
															<p style="text-align: center; font-size: 13px; font-weight: bold; width: 293px;" class="para">
																KBNN A ghi sổ và thanh toán ngày..../..../......      				
															</p>
															<p style="font-size: 13px; width: 305px;">&nbsp;&nbsp;&nbsp;&nbsp; Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Giám đốc&nbsp; </p>
															<br />
															<br />
														</td>
														<td>
															<p style="text-align: center; font-size: 13px; font-weight: bold;" class="para">KBNN B, NH B ghi sổ ngày..../..../......</p>
															<p style="font-size: 13px; width: 305px;">&nbsp;&nbsp;&nbsp;&nbsp; Kế toán&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Kế toán trưởng&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; Giám đốc&nbsp; </p>
															<br />
															<br />
														</td>
													</tr>

												</table>
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
										Target="_blank" Text="Xem bản in" Visible="false"></asp:HyperLink>
									<asp:Button Visible="true" ID="m_cmd_export_excel" runat="server" Text="Xuất excel" CssClass="btn btn-sm btn-success" OnClick="m_cmd_export_excel_Click" />
								</td>
							</tr>
						</table>
					</td>
					<%--<td><input type="button" id="m_cmd_print" onclick="ExportToExcel()" value="Print" /><//td>--%>
				</tr>
			</table>


		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="m_cmd_export_excel" />
		</Triggers>
	</asp:UpdatePanel>
	<%--<asp:UpdateProgress ID="UpdateProgress1" runat="server">
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
	</asp:UpdateProgress>--%>
</asp:Content>

