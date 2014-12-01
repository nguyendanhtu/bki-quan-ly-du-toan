<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="F600_print_unc_qbt.aspx.cs" Inherits="QuanLyDuToan.ChucNang.F600_print_unc_qbt" %>

<!DOCTYPE html>

<%@ Import Namespace="WebDS.CDBNames" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery-1.4.1.min.js")%>'></script>
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery-ui.min.js")%>'></script>
	<title></title>
	<style type="text/css">
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
			height: 13px;
			font-size: 11px;
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
	<form id="Form1" runat="server">
		<table style="width: 100%">
			<tr>
				<td style="width: 800px">
					<table style="width: 800px; margin: auto"  id="m_tbl">
						<tr>
							<td style="width: 100px; text-align: center; border: 1px solid">Không ghi gì vào khu vực này</td>
							<td style="width: 500px; text-align: center">
								<p style="font-weight: bold">UỶ NHIỆM CHI</p>
								<p>CHUYỂN KHOẢN, CHUYỂN TIỀN ĐIỆN TỬ</p>
								<p>
									Lập ngày
					<asp:Label ID="m_lbl_ngay_thang" Text=" 01 tháng 01 năm 2014" runat="server"></asp:Label>
								</p>
							</td>
							<td style="width: 200px; text-align: center; vertical-align: top">
								<p style="font-weight: bold">Mấu số C4-02/KB</p>
								<p>
									(TT số 08/2013/TT-BTC ngày 10/01/2013 của Bộ Tài chính)
					Số: &nbsp;<asp:Label ID="m_lbl_so_unc" Text="59Qtu" runat="server"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<p style="font-weight: bold">
									Đơn vị trả tiền:
					<asp:Label ID="m_lbl_don_vi_tra_tien" Text="Sở Giao thông vận tải Hải Dương" runat="server"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">Địa chỉ:
				<asp:Label ID="m_lbl_dia_chi" Text="79 Bạch Đằng - TP Hải Dương" runat="server"></asp:Label></td>
						</tr>
						<tr>
							<td colspan="3">Tại Kho bạc Nhà nước (NH):
				<asp:Label ID="m_lbl_tai_kho_bac_nha_nuoc" Text="Kho Bạc Nhà nước tỉnh Hải Dương" runat="server"></asp:Label></td>
						</tr>
						<tr>
							<td colspan="3">
								<p>
									Mã TKKT:
					<asp:Label ID="m_lbl_ma_tkkt" Text="3741.0.1044548" runat="server"></asp:Label>&nbsp;&nbsp;&nbsp;&nbsp; Mã ĐVQHNS:
					<asp:Label ID="m_lbl_ma_dvqhns" Text="1044548" runat="server"></asp:Label>
									&nbsp;&nbsp;&nbsp;&nbsp; Mã CTMT, DA và HTCT:
					<asp:Label ID="m_lbl_ma_ctmt_da_htct" Text="91057" runat="server"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="false" Style="width: 800px">
									<RowStyle BorderStyle="Solid" BorderWidth="1px" />
									<Columns>
										<asp:TemplateField ItemStyle-Width="400px">
											<HeaderTemplate>
												<table style="text-align: center; border: 0px; width: 100%" cellspacing="0" cellpadding="0">
													<tr>
														<td style="border-bottom: 1px solid gray; height: 60px">Nội dung thanh toán</td>
													</tr>
													<tr>
														<td>(1)</td>
													</tr>
												</table>
											</HeaderTemplate>
											<ItemTemplate><%#Eval(V_DM_UY_NHIEM_CHI.DISPLAY)%></ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Right">
											<HeaderTemplate>
												<table style="text-align: center; border: 0px; width: 100%;" cellspacing="0" cellpadding="0">
													<tr>
														<td style="border-bottom: 1px solid gray; width: 100%; height: 60px">Tổng số tiền</td>
													</tr>
													<tr>
														<td>(2)=(3)+(4)</td>
													</tr>
												</table>
											</HeaderTemplate>
											<ItemTemplate><%# get_tong_tien(Eval(V_DM_UY_NHIEM_CHI.SO_TIEN_NOP_THUE).ToString(),Eval(V_DM_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG).ToString())%></ItemTemplate>
										</asp:TemplateField>
										<asp:TemplateField ItemStyle-Width="280px">
											<HeaderTemplate>
												<table style="text-align: center; width: 100%; border: 0px" cellspacing="0" cellpadding="0">
													<tr>
														<td colspan="2" style="border-bottom: 1px solid gray; height: 30px">Chia ra</td>
													</tr>
													<tr>
														<td style="border-bottom: 1px solid gray; border-right: 1px solid gray; width: 50%; height: 30px">Nộp thuế</td>
														<td style="border-bottom: 1px solid gray; height: 30px">TT cho ĐV hưởng</td>
													</tr>
													<tr>
														<td style="border-right: 1px solid gray;">(3)</td>
														<td>(4)</td>
													</tr>
												</table>
											</HeaderTemplate>
											<ItemTemplate>
												<table style="width: 100%; height: 100%;" cellspacing="0" cellpadding="0">
													<tr>
														<td style="width: 50%; height: 100%; border-right: 1px solid gray; text-align: right"><%#format_so_tien(Eval(V_DM_UY_NHIEM_CHI.SO_TIEN_NOP_THUE).ToString())  %></td>
														<td style="width: 50%; height: 100%; text-align: right"><%#format_so_tien(Eval(V_DM_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG).ToString()) %></td>
													</tr>
												</table>
											</ItemTemplate>
										</asp:TemplateField>
									</Columns>
								</asp:GridView>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<p>
									Số tiền ghi bằng chữ:
						<asp:Label ID="m_lbl_so_tien_ghi_bang_chu" runat="server"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<table>
									<tr>
										<td style="width: 580px; vertical-align: top">
											<table style="width: 100%">
												<tr>
													<td colspan="3">
														<p style="font-weight: bold">Trong đó:</p>
													</td>
												</tr>
												<tr>
													<td></td>
												</tr>
												<tr>
													<td colspan="3">
														<p style="font-weight: bold">NỘP THUẾ:</p>
													</td>
												</tr>
												<tr>
													<td colspan="3">
														<p>
															Tên đơn vị (Người nộp thuế):
						<asp:Label ID="m_lbl_nt_ten_don_vi" runat="server" Text="......"></asp:Label>
														</p>
													</td>
												</tr>
												<tr>
													<td colspan="3">
														<p>
															Mã số thuế:
						<asp:Label ID="m_lbl_nt_ma_so_thue" runat="server" Text="......"></asp:Label>&nbsp;
					Mã NDKT:
						<asp:Label ID="m_lbl_nt_ma_ndkt" runat="server" Text="......"></asp:Label>
															&nbsp; Mã chương:
						<asp:Label ID="m_lbl_nt_ma_chuong" runat="server" Text="......"></asp:Label>
														</p>
													</td>
												</tr>
												<tr>
													<td colspan="3">
														<p>
															Cơ quan quản lý thu:<asp:Label ID="m_lbl_nt_co_quan_quan_ly_thu" runat="server" Text="........"></asp:Label>
															&nbsp;Mã CQ thu:<asp:Label ID="m_lbl_nt_ma_cq_thu" runat="server" Text="......"></asp:Label>

														</p>
													</td>
												</tr>
												<tr>
													<td colspan="3">
														<p>
															Số tiền nộp thuế (ghi bằng chữ):
						<asp:Label ID="m_lbl_nt_so_tien_nop_thue" runat="server" Text="......"></asp:Label>
														</p>
													</td>
												</tr>
												<tr>
													<td></td>
												</tr>

												<tr>
													<td colspan="3">
														<p style="font-weight: bold">THANH TOÁN CHO ĐƠN VỊ HƯỞNG:</p>
													</td>
												</tr>
												<tr>
													<td colspan="3">
														<p>
															Đơn vị nhận tiền:
						<asp:Label ID="m_lbl_ttdvh_don_vi_nhan_tien" runat="server" Text="......"></asp:Label>
														</p>
													</td>
												</tr>
											</table>
										</td>
										<td style="width: 220px; vertical-align: top; border: 1px solid gray; font-size: smaller">
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
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>

						<tr>
							<td colspan="3">
								<p>
									Mã ĐVQHNS:
						<asp:Label ID="m_lbl_ttdvh_ma_dvqhns" runat="server" Text="1057534"></asp:Label>
									&nbsp;&nbsp;Địa chỉ:<asp:Label ID="m_lbl_ttdvh_dia_chi" runat="server" Text="......"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<p>
									Tài khoản:
						<asp:Label ID="m_lbl_ttdvh_tai_khoan" runat="server" Text="3511"></asp:Label>
									&nbsp;&nbsp;Mã CTMT, DA và HTCT:<asp:Label ID="m_lbl_ttdvh_ma_ctmt_da_htct" runat="server" Text="......"></asp:Label>
									&nbsp;&nbsp;Tại KBNN:<asp:Label ID="m_lbl_ttdvh_tai_kbnn" runat="server" Text="Kho bạc nhà nước Hà Nội"></asp:Label>
								</p>
							</td>
						</tr>
						<tr>
							<td colspan="3">
								<p>
									Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):
						<asp:Label ID="m_lbl_ttdvh_so_tien_thanh_toan_dvh" runat="server" Text="Mười tám triệu sáu trăm chín mươi nghìn đồng chẵn"></asp:Label>

								</p>
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
					</table>
				</td>
				<%--<td><input type="button" id="m_cmd_print" onclick="ExportToExcel()" value="Print" /><//td>--%>
			</tr>
		</table>


	</form>
</body>
</html>
