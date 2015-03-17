<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F601_print_giay_rut_du_toan_ngan_sach.aspx.cs" Inherits="QuanLyDuToan.ChucNang.F601_print_giay_rut_du_toan_ngan_sach" %>

<!DOCTYPE html>

<%@ Import Namespace="WebDS.CDBNames" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery-1.4.1.min.js")%>'></script>
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery-ui.min.js")%>'></script>
	<link href="~/Styles/jquery-ui.css" rel="stylesheet" type="text/css" />
	<link href="~/Styles/Site.css" rel="stylesheet" type="text/css" />
	<link href="~/Styles/Admin.css" rel="stylesheet" type="text/css" />
	<!--Bootstrap-->
	<link href="~/bootstrap-3.2.0-dist/css/bootstrap.css" rel="stylesheet" type="text/css" />
	<link href="~/bootstrap-3.2.0-dist/css/bootstrap-theme.css" rel="stylesheet" type="text/css" />
	<title></title>
	<style type="text/css">
		.col-xs-1, .col-sm-1, .col-md-1, .col-lg-1, .col-xs-2, .col-sm-2, .col-md-2, .col-lg-2, .col-xs-3, .col-sm-3, .col-md-3, .col-lg-3, .col-xs-4, .col-sm-4, .col-md-4, .col-lg-4, .col-xs-5, .col-sm-5, .col-md-5, .col-lg-5, .col-xs-6, .col-sm-6, .col-md-6, .col-lg-6, .col-xs-7, .col-sm-7, .col-md-7, .col-lg-7, .col-xs-8, .col-sm-8, .col-md-8, .col-lg-8, .col-xs-9, .col-sm-9, .col-md-9, .col-lg-9, .col-xs-10, .col-sm-10, .col-md-10, .col-lg-10, .col-xs-11, .col-sm-11, .col-md-11, .col-lg-11, .col-xs-12, .col-sm-12, .col-md-12, .col-lg-12 {
			position: relative;
			min-height: 1px;
			padding-right: 0px;
		}

		.table {
			margin-bottom: 0px;
		}

		.lbl_no_wrap {
			white-space: nowrap;
		}

		.HeaderStyle {
			background: white;
			border-color: #000;
			text-align: center;
		}

		.hiddenCell {
			display: none;
		}

		label {
			white-space: nowrap;
			width: 200px;
			padding-right: 3px;
		}

		p {
			height: 17px;
			margin: 0px;
		}

		td {
			height: 17px;
			border-color: gray;
			border-collapse: collapse;
		}

		.para {
			height: 19px;
			font-size: 11px;
		}

		th {
			text-align: center !important;
			background: white;
			/* border-color: #000; */
		}
	</style>
	<script type="text/javascript">
		function ExportToExcel() {
			var htmltable = document.getElementById('m_tbl');
			var html = htmltable.outerHTML;
			window.open('data:application/vnd.ms-excel,' + encodeURIComponent(html));
		}
	</script>
</head>
<body>
	<asp:Panel runat="server" ID="m_pnl_content" ToolTip="Ctrl+P để in Giấy rút dự toán Ngân sách">
		<form id="Form1" runat="server">

			<table style="width: 900px; margin: auto;">
				<tr>
					<td style="border: 1px solid gray; width: 20%">Không ghi vào khu vực này</td>
					<td style="font-weight: bold; font-size: 24px; text-align: center; width: 60%">GIẤY RÚT DỰ TOÁN NGÂN SÁCH</td>
					<td style="border: 1px solid gray; width: 20%; text-align: center">Mẫu C2-02/NS		
						<br />
						(Thông tư số 08/2013/TT-BTC ngày
10/01/2013 của Bộ Tài chính)
						<br />
						Số:
						<asp:Label ID="m_lbl_so_unc" runat="server"></asp:Label>
					</td>
				</tr>
				<tr>
					<td></td>
					<td style="text-align: right">
						<table class="col-sm-12">
							<tr>
								<td class="col-sm-7" style="border-right: 1px solid gray">
									<div class="col-sm-12">
										<asp:CheckBox ID="m_ckb_thuc_chi" runat="server" Text="Thực chi" TextAlign="Left" />
										<asp:CheckBox ID="m_ckb_tam_ung" runat="server" Text="Tạm ứng" TextAlign="Left" />
									</div>
									<div class="col-sm-12">
										<asp:CheckBox ID="m_ckb_ung_truoc_chua_du_dk_thanh_toan" runat="server" Text="Ứng trước đủ ĐK thanh toán" TextAlign="Left" />
										<asp:CheckBox ID="m_ckb_ung_truoc_du_dk_thanh_toan" runat="server" Text="Ứng trước chưa đủ ĐK thanh toán" TextAlign="Left" />
									</div>

								</td>
								<td class="col-sm-5" style="vertical-align: top">
									<div class="col-sm-12">
										<asp:CheckBox ID="m_ckb_chuyen_khoan" runat="server" Text="Chuyển khoản" TextAlign="Left" />
									</div>
									<div class="col-sm-12">
										<asp:CheckBox ID="m_ckb_tien_mat" runat="server" Text="Tiền mặt" TextAlign="Left" />
									</div>
								</td>
							</tr>
						</table>
					</td>
					<td></td>
				</tr>

				<tr>
					<td colspan="3">
						<table id="main_table" class="col-sm-12">
							<tr>
								<td colspan="2" class="col-sm-12">
									<table class="col-sm-12">
										<tr>
											<td>
												<table class="col-sm-12">
													<tr>
														<td class="col-sm-3 text-right">
															<span>Đơn vị rút dự toán:</span>
														</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_don_vi_rut_du_toan" runat="server"></asp:Label>
														</td>
														<td class="col-sm-3 text-right">Mã ĐVQHNS</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_ma_dvqhns" ForeColor="Black" runat="server"></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table class="col-sm-12">
													<tr>
														<td class="col-sm-3 text-right">
															<span>Tài khoản:
															</span>
														</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_tai_khoan" runat="server"></asp:Label>
														</td>
														<td class="col-sm-3 text-right">
															<span>Tại KBNN:	

															</span>
														</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_tai_kbns" ForeColor="Black" Width="150px" runat="server"></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>

										<tr>
											<td>
												<table class="col-sm-12">
													<tr>
														<td class="col-sm-3 text-right">
															<span>Mã cấp NS:

															</span>
														</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_ma_cap_ns" ForeColor="Black" Width="150px" runat="server"></asp:Label>
														</td>
														<td class="col-sm-6">
															<span>Tên CTMT, DA:</span>
															<asp:Label ID="m_lbl_ten_ctmt_da" ForeColor="Black" Width="273px" runat="server"></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table class="col-sm-12">
													<tr>
														<td class="col-sm-3"></td>
														<td class="col-sm-3"></td>
														<td class="col-sm-3 text-right">
															<span>Mã CTMT, DA(*):</span>
														</td>
														<td class="col-sm-3">
															<asp:Label ID="m_lbl_ma_ctmt_da_htct" ForeColor="Black" Width="150px" runat="server"></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td>
												<table class="col-sm-12">
													<tr>
														<td class="col-sm-3 text-right">
															<span>Năm NS:  
															</span>
															<asp:Label ID="m_lbl_nam_ns" ForeColor="Black" runat="server"></asp:Label>
														</td>

														<td class="col-sm-3 text-center">
															<span>Số CKC, HĐK:</span>
															<asp:Label ID="m_lbl_so_ckc_hdk" ForeColor="Black" runat="server"></asp:Label>
														</td>
														<td class="col-sm-6">
															<span>Số CKC, HĐTH:	
 
															</span>
															<asp:Label ID="m_lbl_so_ckc_hdth" ForeColor="Black" Width="271px" runat="server"></asp:Label>
														</td>
													</tr>
												</table>
											</td>
										</tr>

									</table>
								</td>
							</tr>
							<tr>
								<td colspan="2" class="col-sm-12">
									<table class="col-sm-12">
										<tr>
											<td>
												<asp:GridView ID="m_grv" runat="server"
													AutoGenerateColumns="false"
													HeaderStyle-BackColor="White"
													DataKeyNames="ID"
													EditRowStyle-Height="80px"
													OnRowCreated="m_grv_RowCreated">
													<Columns>
														<asp:TemplateField HeaderText="(1)" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ghi_chu" Text='<%# Eval(V_DM_GIAI_NGAN.NOI_DUNG_CHI) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(2)" HeaderStyle-Width="200px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_quoc_lo_du_an" Text='<%# Eval("TEN_DU_AN") %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>


														<asp:TemplateField HeaderText="(3)" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_chuong" Text='<%#Eval(GRID_GIAI_NGAN.MA_CHUONG).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(4)" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_nganh_kt" Text='<%#Eval(GRID_GIAI_NGAN.MA_LOAI).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(5)" HeaderStyle-Width="60px">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_ma_nguon_nsnn" Text='<%#Eval(GRID_GIAI_NGAN.MA_KHOAN).ToString() %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(6)=(7)+(8)" HeaderStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_tong_tien" Text='<%#format_so_tien( Eval("TONG").ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(7)" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_nop_thue" Width="90px" Text='<%#format_so_tien( Eval("SO_TIEN_NOP_THUE").ToString()) %>'
																	runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>
														<asp:TemplateField HeaderText="(8)" HeaderStyle-Width="90px" ItemStyle-HorizontalAlign="Right">
															<ItemTemplate>
																<asp:Label ID="m_lbl_grid_so_tien_tt_cho_dv_huong" Width="90px" Text='<%#format_so_tien( Eval("SO_TIEN_TT_CHO_DV_HUONG").ToString()) %>' runat="server"></asp:Label>
															</ItemTemplate>
															<HeaderStyle CssClass="hiddenCell" />
														</asp:TemplateField>


													</Columns>
												</asp:GridView>
											</td>
										</tr>
									</table>
								</td>
							</tr>

							<tr>
								<td>
									<p>
										Số tiền ghi bằng chữ:
						<asp:Label ID="m_lbl_so_tien_ghi_bang_chu" runat="server"></asp:Label>
									</p>
								</td>
							</tr>

							<tr>
								<td style="vertical-align: top">
									<table class="table" style="width: 100%;" border="0">
										<tr>
											<td>Trong đó:</td>
										</tr>
										<tr>
											<td><span style="font-weight: bold">NỘP THUẾ</span></td>
											<td colspan="5" style="text-align: right"></td>
										</tr>
										<tr>
											<td colspan="1">
												<span>Tên đơn vị (Người nộp thuế):  </span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_nt_ten_don_vi" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Mã số thuế:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_nt_ma_so_thue" runat="server" Width="80%"></asp:Label>
											</td>
											<td style="width: 5%">
												<span>Mã NDKT:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_nt_ma_ndkt" runat="server" Width="80%"></asp:Label>
											</td>
											<td style="width: 5%">
												<span>Mã chương:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_nt_ma_chuong" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>Cơ quan quản lý thu:</span>
											</td>
											<td colspan="3">
												<asp:Label ID="m_lbl_nt_co_quan_quan_ly_thu" runat="server" Width="92.2%"></asp:Label>
											</td>
											<td>
												<span>Mã CQ thu:</span>
											</td>
											<td>
												<asp:Label ID="m_lbl_nt_ma_cq_thu" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>KBNN hạch toán thu:</span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_nt_kbnn_hach_toan_thu" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền nộp thuế (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_nt_so_tien_nop_thue" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td><span style="font-weight: bold; white-space: nowrap">THANH TOÁN CHO ĐƠN VỊ HƯỞNG</span></td>
										</tr>
										<tr>
											<td>
												<span>Đơn vị nhận tiền:</span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_ttdvh_don_vi_nhan_tien" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>Địa chỉ:</span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_ttdvh_dia_chi" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>Mã ĐVQHNS:</span>
											</td>
											<td>
												<asp:Label ID="m_lbl_ttdvh_ma_dvqhns" runat="server" Width="80%"></asp:Label>
											</td>
											<td>
												<span class="lbl_no_wrap">Mã CTMT, DA, và HTCT:</span>
											</td>
											<td colspan="1">
												<asp:Label ID="m_lbl_ttdvh_ma_ctmt_da_htct" runat="server" Width="80%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td style="width: 10%">
												<span>Tài khoản:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_ttdvh_tai_khoan" runat="server" Width="80%"></asp:Label>
											</td>
											<td style="width: 5%">
												<span class="lbl_no_wrap">Tại KBNN:</span>
											</td>
											<td colspan="3">
												<asp:Label ID="m_lbl_ttdvh_tai_kbnn" runat="server" Width="100%"></asp:Label>
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
												<asp:Label ID="m_lbl_cmnd_so" runat="server" Width="80%"></asp:Label>
											</td>
											<td style="width: 5%">
												<span class="lbl_no_wrap">Cấp ngày:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_cap_ngay" runat="server" Width="80%"></asp:Label>
											</td>
											<td style="width: 5%">
												<span>Nơi cấp:</span>
											</td>
											<td style="width: 10%">
												<asp:Label ID="m_lbl_noi_cap" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>
										<tr>
											<td>
												<span>Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
											</td>
											<td colspan="5">
												<asp:Label ID="m_lbl_ttdvh_so_tien_thanh_toan" runat="server" Width="100%"></asp:Label>
											</td>
										</tr>

									</table>
								</td>
								<td style="width: 220px; vertical-align: top; border: 1px solid gray;">
									<table style="width: 100%">
										<tr>
											<td>
												<p style="font-weight: bold" class="para">&nbsp;&nbsp;KBNN A GHI</p>
											</td>
										</tr>
										<tr>
											<td>
												<p style="font-weight: bold">1. Nộp thuế</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Mã CQ thu:.................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Mã ĐBHC:...................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p style="font-weight: bold" class="para">2. Thanh toán cho ĐV hưởng</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Nợ TK:.......................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Có TK:........................................................</p>
											</td>
										</tr>
										<tr>
											<td>
												<p class="para">&nbsp;&nbsp;Mã ĐBHC:..................................................</p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<table class="table bordertop0" style="width: 100%">
										<tr>
											<td style="width: 50%; text-align: center; border-bottom: hidden">
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
								<td colspan="2">
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

						</table>
					</td>
					<%--<td><input type="button" id="m_cmd_print" onclick="ExportToExcel()" value="Print" /><//td>--%>
				</tr>
			</table>
		</form>
	</asp:Panel>
</body>
</html>
