<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan" %>

<%@ Import Namespace="QuanLyDuToan.Function" %>

<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="QuanLyDuToan.App_Code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.stt {
			width: 25px !important;
			text-align: center;
		}

		.noi_dung {
			width: 222px !important;
			padding:2px;
		}

		.so_km {
			width: 85px;
			text-align: right;
		}

		.so_lieu {
			width: 122px;
			text-align: right;
		}

		.table {
			margin-top: 0px;
			margin-bottom: 0px;
		}

		.lb {
			width: 100px;
			float: left;
			text-align: right;
			line-height: 20px;
		}
		.table > thead > tr > th, .table > tbody > tr > td {
				padding-right: 0px !important;
				padding-left: 0px !important;
			}
		.control {
			width: 240px;
			float: left;
		}

		.datepicker {
			z-index: 999999 !important;
		}
	</style>
	<%--<script src="../Scripts/jquery.doubleScroll.js"></script>
	<script src="../Scripts/fixHeader.js"></script>--%>
	<script src="../Scripts/jquery.dataTables.js"></script>
	<script src="../Scripts/dataTables.fixedColumns.js"></script>
	<%--<script src="../Scripts/ExportExcel.js"></script>--%>
	<link href="../Styles/dataTables.fixedColumns.css" rel="stylesheet" />

	<script type="text/javascript">
		$(document).ready(function () {

			$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
			$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

			var v_lst_so_lieu = $('.so_lieu');
			for (var i = 0; i < v_lst_so_lieu.length; i++) {
				var value = $(v_lst_so_lieu[i]).text();
				if (!isNaN(value)) {
					$(v_lst_so_lieu[i]).text(getFormatedNumberStringWithDot(value));
				}
			}
			var v_lst_so_km = $('.so_km');
			for (var i = 0; i < v_lst_so_km.length; i++) {
				var value = $(v_lst_so_km[i]).text();
				if (!isNaN(value)) {
					$(v_lst_so_km[i]).text(value.replace(".", ","));
				}
			}

			var table = $('#m_grv').DataTable({
				"scrollY": "400px",
				"scrollX": "4139px",
				"scrollCollapse": true,
				"paging": false,
				"sDom": 'T<"clear"><"top">rt<"bottom">',
				"bSort": false

			});
			new $.fn.dataTable.FixedColumns(table, {
				leftColumns: 2,
			});

			$(window).resize(function () {
				location.reload();
				$('#m_grv_wrapper').hide(30000);
				CCommon.thong_bao('Giao diện báo cáo bị lỗi hiển thị, Website đang TẠO LẠI BÁO CÁO cho bạn! Xin vui lòng đợi 30s!', 'error');
			})
		});
		
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>--%>

	<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>--%>
	<table id="main_table" style="width: 1200px; margin: auto" class="cssTable table" border="0">
		<tr>
			<td colspan="4" style="text-align: center">

				<h4>BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString()%></h4>
			</td>
		</tr>
		<tr>
			<td colspan="4">
				<div style="margin: 0 auto; width: 700px !important">
					<div style="margin-top: 10px; width: 700px !important;">
						<div class="lb" style="margin-right: 23px; float: left">Từ ngày</div>
						<div id="datetimepicker1" class="input-group date" style="width: 200px; float: left">
							<asp:TextBox ClientIDMode="Static" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-start " Height="30px" Width="164px"></asp:TextBox>
							<span class="input-group-addon">
								<span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
						<div class="lb" style="margin-right: 23px; float: left">Đến ngày</div>
						<div id="datetimepicker2" class="input-group date" style="width: 200px; float: left">
							<asp:TextBox ClientIDMode="Static" ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox  date-start" Height="30px" Width="164px"></asp:TextBox>
							<span class="input-group-addon">
								<span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
					</div>
				</div>
			</td>

		</tr>
		<tr>
			<td colspan="4">
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
			</td>
		</tr>

		<tr>

			<td colspan="4" style="text-align: center">
				<div style="margin: 0px auto; width: 200px;">
					<div style="width: 100px; margin: 0px auto; float: left;">
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" CssClass="btn btn-sm btn-primary" />
					</div>
					<%--<div id="downloadify" style="width: 100px; margin: 0px auto; float: left;">
						You must have Flash 10 installed to download this file.
					</div>--%>
					<asp:Button  runat="server" ID="m_cmd_xuat_excel" Text="Xuất file excel" CssClass="btn btn-sm btn-success" OnClick="m_cmd_xuat_excel_Click" />
				</div>

			</td>
		</tr>
		<tr>
			<td colspan="4">
					<div style="width: 1200px; margin: auto;" id="double-scroll">
						<table class="table-striped table-bordered" id="m_grv" style="width: 4139px">
							<thead>
								<tr>
									<!-----------STT------------>
									<th rowspan="3">STT</th>
									<!-----------NoiDung------------>
									<th rowspan="3" class="noi_dung">Nội dung</th>
									<!-----------SoKmQuanLy------------>
									<th rowspan="3" class="so_km">Số km quản lý</th>
									<!-----------TongMucDauTu/TongDuToan------------>
									<th rowspan="3" class="so_lieu">TMĐT/ TDT </th>
									<th colspan="7">Kế hoạch(dự toán) được sử dụng trong năm</th>
									<th colspan="5">Kinh phí đã nhận</th>
									<th colspan="5">Kinh phí đã thanh toán, giải ngân</th>
									<th colspan="3">Số kinh phí chưa GN</th>
									<th colspan="3">Kinh phí còn được nhận</th>
									<th colspan="4">Giá trị thực hiện đã nghiệm thu A-B</th>
									<th colspan="3">Số chưa GN cho nhà thầu theo nghiệm thu A-B</th>
								</tr>
								<tr>
									<!--------------------Kế hoạch(dự toán) được sử dụng trong năm------------------------------>
									<th colspan="3">Quỹ bảo trì</th>
									<th colspan="3">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
									<!----------------------Kinh phí đã nhận---------------------------------->
									<th colspan="2">Quỹ bảo trì</th>
									<th colspan="2">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
									<!----------------------Kinh phí đã thanh toán, giải ngân--------------------------------->
									<th colspan="2">Quỹ bảo trì</th>
									<th colspan="2">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
									<!---------------------- Số kinh phí chưa GN---------------------------------->
									<th rowspan="2">Quỹ bảo trì</th>
									<th rowspan="2">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
									<!----------------------Kinh phí còn được nhận---------------------------------->
									<th rowspan="2">Quỹ bảo trì</th>
									<th rowspan="2">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
									<!-----------------------Giá trị thực hiện đã nghiệm thu A-B--------------------------------->
									<th rowspan="2">Quỹ bảo trì</th>
									<th rowspan="2">Nhu cầu vốn kỳ tiếp theo</th>
									<th rowspan="2">Ngân sách</th>
									<th rowspan="2">Tổng giá trị nghiệm thu AB</th>
									<!------------------------Số chưa GN cho nhà thầu theo nghiệm thu A-B-------------------------------->
									<th rowspan="2">Quỹ bảo trì</th>
									<th rowspan="2">Ngân sách</th>
									<th rowspan="2">Tổng cộng</th>
								</tr>
								<tr>


									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<th>Số dư năm trước chuyển sang</th>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<th>Kế hoạch giao trong năm</th>
									<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
									<th>Cộng</th>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<th>Số dư năm trước chuyển sang</th>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<th>Kế hoạch giao trong năm</th>
									<!-----------KeHoach _ NganSach _ TongCong------------>
									<th>Cộng</th>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<th>Trong tháng</th>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<th>Luỹ kế từ đầu năm</th>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<th>Trong tháng</th>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<th>Luỹ kế từ đầu năm</th>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<th>Trong tháng</th>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<th>Luỹ kế từ đầu năm</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<th>Trong tháng</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<th>Luỹ kế từ đầu năm</th>
								</tr>
								<tr>

									<!-----------STT-------------------------->
									<th class="stt">1</th>
									<!-----------NoiDung-------------------------->
									<th class="noi_dung">2</th>
									<!-----------SoKM-------------------------->
									<th class="so_km">3</th>
									<!-----------TongMucDauTu/TongDuToan-------------------------->
									<th class="so_lieu">4</th>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<th class="so_lieu">5</th>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<th class="so_lieu">6</th>
									<!-----------KeHoach _ QuyBaoTri _ Cong------------>
									<th class="so_lieu">7=5+6</th>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<th class="so_lieu">8</th>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<th class="so_lieu">9</th>
									<!-----------KeHoach _ NganSach _ Cong------------>
									<th class="so_lieu">10=8+9</th>
									<!-----------KeHoach _ NganSach _ Cong------------>
									<th class="so_lieu">11=7+10</th>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<th class="so_lieu">12</th>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<th class="so_lieu">13</th>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<th class="so_lieu">14</th>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<th class="so_lieu">15</th>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<th class="so_lieu">16=13+15</th>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<th class="so_lieu">17</th>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<th class="so_lieu">18</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<th class="so_lieu">19</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<th class="so_lieu">20</th>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<th class="so_lieu">21=18+20</th>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<th class="so_lieu">22=13-18</th>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<th class="so_lieu">23=15-20</th>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<th class="so_lieu">24=22+23</th>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<th class="so_lieu">25=7-13</th>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<th class="so_lieu">26=10-20</th>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<th class="so_lieu">27=25+26</th>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<th class="so_lieu">28</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<th class="so_lieu">29</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<th class="so_lieu">30</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<th class="so_lieu">31=28+30</th>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<th class="so_lieu">32=28-18</th>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<th class="so_lieu">33=28-19</th>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<th class="so_lieu">34=32+33</th>

								</tr>
							</thead>
							<tbody>
								<!------------------------Khai bao bien dung de tinh toan so lieu------------------------------------->
								<%double v_dc_so_km, v_dc_tong_muc_dau_tu, v_dc_kh_qbt_ntcs, v_dc_kh_qbt_giao, v_dc_kh_ns_ntcs, v_dc_kh_ns_giao, v_dc_giao_von_qbt_trong_thang, v_dc_giao_von_ns_trong_thang, v_dc_giao_von_qbt_luy_ke, v_dc_giao_von_ns_luy_ke, v_dc_da_thanh_toan_qbt_trong_thang, v_dc_da_thanh_toan_qbt_luy_ke, v_dc_da_thanh_toan_ns_trong_thang, v_dc_da_thanh_toan_ns_luy_ke, v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt, v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns, v_dc_nhu_cau_von_ky_tiep_theo; %>
								<!-------------------Dòng Tổng cộng---------------------------->
								<% Fn.F530.get_so_lieu_by_row(m_lst_giao_kh
											  , m_lst_giao_von
											  , m_lst_giai_ngan
											  , m_lst_khoi_luong
											  , -1
											  , m_dat_dau_nam
											  , m_dat_tu_ngay
											  , m_dat_den_ngay
											  , Fn.para_F530_Group.Cuc
											  , ""
											  , out v_dc_so_km
											  , out v_dc_tong_muc_dau_tu
											  , out v_dc_kh_qbt_ntcs
											  , out v_dc_kh_qbt_giao
											  , out v_dc_kh_ns_ntcs
											  , out v_dc_kh_ns_giao
											  , out v_dc_giao_von_qbt_trong_thang
											  , out v_dc_giao_von_qbt_luy_ke
											  , out v_dc_giao_von_ns_trong_thang
											  , out v_dc_giao_von_ns_luy_ke
											  , out v_dc_da_thanh_toan_qbt_trong_thang
											  , out v_dc_da_thanh_toan_qbt_luy_ke
											  , out v_dc_da_thanh_toan_ns_trong_thang
											  , out v_dc_da_thanh_toan_ns_luy_ke
											  , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
											  , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
											  , out v_dc_nhu_cau_von_ky_tiep_theo);%>
								<tr style="font-weight: bold; color: maroon; font-style: italic">
									<td class="stt"></td>
									<td class="noi_dung" style="text-align: center">Tổng cộng</td>
									<!-----------SoKmQuanLy------------>
									<td class="so_km">
										<%=v_dc_so_km %>
									</td>
									<!-----------TongMucDauTu/TongDuToan------------>
									<td class="so_lieu">
										<%=v_dc_tong_muc_dau_tu %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs%>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<td class="so_lieu">
										<%=v_dc_kh_ns_ntcs %>
									</td>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_giao%>
									</td>
									<!-----------KeHoach _ NganSach _ TongCong------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>
									<!------------KeHoach _ TongCong--------------------------------------->
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
									</td>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
									</td>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<td class="so_lieu">
										<%=v_dc_nhu_cau_von_ky_tiep_theo %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<td class="so_lieu">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<td class="so_lieu">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
				+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
								</tr>
								<!------------------Tạo dòng Group by Cuc QLDB----------------------->
								<%int v_i_stt = 1; %>
								<%foreach (var item in m_lst_group_by)%>
								<%{%>
								<%var v_lst_don_vi_group_by = m_lst_don_vi
					.Where(x => x.TEN_DON_VI.ToUpper().Contains(item.groupKey.ToUpper())
					|| x.TEN_DON_VI.ToUpper().Contains((item.groupKey + ".").ToUpper())
					|| (x.TEN_DON_VI + " - Văn phòng").ToUpper().Contains(item.groupKey.Replace(".", " - Văn phòng").ToUpper())
					)
					.ToList();
		  if (v_lst_don_vi_group_by != null)
		  {
			  m_lst_don_vi_group_by.AddRange(v_lst_don_vi_group_by);
		  }
								%>
								<!----------------Cuc QLDBx---------------------------------->
								<%Fn.F530.get_so_lieu_by_row(m_lst_giao_kh
									  , m_lst_giao_von
									  , m_lst_giai_ngan
									  , m_lst_khoi_luong
									  , -1
									  , m_dat_dau_nam
									  , m_dat_tu_ngay
									  , m_dat_den_ngay
									  , Fn.para_F530_Group.Cuc
									  , item.groupKey
									  , out v_dc_so_km
									  , out v_dc_tong_muc_dau_tu
									  , out v_dc_kh_qbt_ntcs
									  , out v_dc_kh_qbt_giao
									  , out v_dc_kh_ns_ntcs
									  , out v_dc_kh_ns_giao
									  , out v_dc_giao_von_qbt_trong_thang
									  , out v_dc_giao_von_qbt_luy_ke
									  , out v_dc_giao_von_ns_trong_thang
									  , out v_dc_giao_von_ns_luy_ke
									  , out v_dc_da_thanh_toan_qbt_trong_thang
									  , out v_dc_da_thanh_toan_qbt_luy_ke
									  , out v_dc_da_thanh_toan_ns_trong_thang
									  , out v_dc_da_thanh_toan_ns_luy_ke
									  , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
									  , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
									  , out v_dc_nhu_cau_von_ky_tiep_theo); %>
								<tr style="font-weight: bold; font-style: italic">
									<td class="stt"></td>
									<td><div class="noi_dung"><%=item.groupText %></div></td>
									<!-----------SoKmQuanLy------------>
									<td class="so_km">
										<%=v_dc_so_km %>
									</td>
									<!-----------TongMucDauTu/TongDuToan------------>
									<td class="so_lieu">
										<%=v_dc_tong_muc_dau_tu %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs%>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<td class="so_lieu">
										<%=v_dc_kh_ns_ntcs %>
									</td>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_giao%>
									</td>
									<!-----------KeHoach _ NganSach _ TongCong------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>
									<!------------KeHoach _ TongCong--------------------------------------->
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
									</td>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<td class="so_lieu">
										<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
									</td>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<td class="so_lieu">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<td class="so_lieu">
										<%=v_dc_nhu_cau_von_ky_tiep_theo %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<td class="so_lieu">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<td class="so_lieu">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<td class="so_lieu">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
				+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
								</tr>
								<!-------------------Chi cuc, van phong cuc--------------------->
								<%foreach (var don_vi in v_lst_don_vi_group_by)%>
								<%{%>
								<%
			  Fn.F530.get_so_lieu_by_row(m_lst_giao_kh
					   , m_lst_giao_von
					   , m_lst_giai_ngan
					   , m_lst_khoi_luong
					   , don_vi.ID
					   , m_dat_dau_nam
					   , m_dat_tu_ngay
					   , m_dat_den_ngay
					   , Fn.para_F530_Group.DonVi
					   , ""
					   , out v_dc_so_km
					   , out v_dc_tong_muc_dau_tu
					   , out v_dc_kh_qbt_ntcs
					   , out v_dc_kh_qbt_giao
					   , out v_dc_kh_ns_ntcs
					   , out v_dc_kh_ns_giao
					   , out v_dc_giao_von_qbt_trong_thang
					   , out v_dc_giao_von_qbt_luy_ke
					   , out v_dc_giao_von_ns_trong_thang
					   , out v_dc_giao_von_ns_luy_ke
					   , out v_dc_da_thanh_toan_qbt_trong_thang
					   , out v_dc_da_thanh_toan_qbt_luy_ke
					   , out v_dc_da_thanh_toan_ns_trong_thang
					   , out v_dc_da_thanh_toan_ns_luy_ke
					   , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
					   , out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
					   , out v_dc_nhu_cau_von_ky_tiep_theo);
			
								%>
								<td class="stt"><%=v_i_stt++ %></td>
								<td class="noi_dung">
									<a href="F350_tinh_hinh_giai_ngan.aspx?ip_dc_id_don_vi=<%=don_vi.ID %>&ip_dat_tu_ngay=<%=m_txt_tu_ngay.Text %>&ip_dat_den_ngay=<%=m_txt_den_ngay.Text %>" title="Xem chi tiết">---<%=don_vi.TEN_DON_VI %></a>
								</td>
								<!-----------SoKmQuanLy------------>
								<td class="so_km">
									<%=v_dc_so_km %>
								</td>
								<!-----------TongMucDauTu/TongDuToan------------>
								<td class="so_lieu">
									<%=v_dc_tong_muc_dau_tu %>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
								<td class="so_lieu">
									<%=v_dc_kh_qbt_ntcs%>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
								<td class="so_lieu">
									<%=v_dc_kh_qbt_giao %>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
								<td class="so_lieu">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
								</td>
								<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
								<td class="so_lieu">
									<%=v_dc_kh_ns_ntcs %>
								</td>
								<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
								<td class="so_lieu">
									<%= v_dc_kh_ns_giao%>
								</td>
								<!-----------KeHoach _ NganSach _ TongCong------------>
								<td class="so_lieu">
									<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
								</td>
								<!------------KeHoach _ TongCong--------------------------------------->
								<td class="so_lieu">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
								</td>

								<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_qbt_trong_thang %>
								</td>
								<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_qbt_luy_ke%>
								</td>
								<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_ns_trong_thang %>
								</td>
								<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_ns_luy_ke %>
								</td>
								<!-----------KinhPhiDaNhan _ TongCong------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
								</td>

								<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
								<td class="so_lieu">
									<%=v_dc_da_thanh_toan_qbt_trong_thang %>
								</td>
								<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
								<td class="so_lieu">
									<%=v_dc_da_thanh_toan_qbt_luy_ke %>
								</td>
								<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
								<td class="so_lieu">
									<%=v_dc_da_thanh_toan_ns_trong_thang %>
								</td>
								<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
								<td class="so_lieu">
									<%=v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------KinhPhiDaThanhToan _ TongCong------------>
								<td class="so_lieu">
									<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
								</td>

								<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
								</td>
								<!-----------KinhPhiChuaGN _ NganSach------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------KinhPhiChuaGN _ Tong_cong------------>
								<td class="so_lieu">
									<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>

								<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
								<td class="so_lieu">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
								</td>
								<!-----------KinhPhiConDuocNhan _ NganSach------------>
								<td class="so_lieu">
									<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>
								<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
								<td class="so_lieu">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>

								<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
								<td class="so_lieu">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
								<td class="so_lieu">
									<%=v_dc_nhu_cau_von_ky_tiep_theo %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
								<td class="so_lieu">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
								<td class="so_lieu">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
								</td>

								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
								<td class="so_lieu">
									<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
								</td>
								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
								<td class="so_lieu">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
								<td class="so_lieu">
									<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
				+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
		</tr>
		<%}%>
		<%}%>
		<!------------------Ban, Sở,...----------------------->
		<%var v_lst_don_vi_not_group_by = m_lst_don_vi
											 .Where(x => !m_lst_don_vi_group_by.Exists(y => y.ID == x.ID))
											 .ToList();%>
		<%foreach (var don_vi in v_lst_don_vi_not_group_by)%>
		<%{%>
		<tr>
			<%
		Fn.F530.get_so_lieu_by_row(m_lst_giao_kh
					, m_lst_giao_von
					, m_lst_giai_ngan
					, m_lst_khoi_luong
					, don_vi.ID
					, m_dat_dau_nam
					, m_dat_tu_ngay
					, m_dat_den_ngay
					  , Fn.para_F530_Group.DonVi
					 , ""
					, out v_dc_so_km
					, out v_dc_tong_muc_dau_tu
					, out v_dc_kh_qbt_ntcs
					, out v_dc_kh_qbt_giao
					, out v_dc_kh_ns_ntcs
					, out v_dc_kh_ns_giao
					, out v_dc_giao_von_qbt_trong_thang
					, out v_dc_giao_von_qbt_luy_ke
					, out v_dc_giao_von_ns_trong_thang
					, out v_dc_giao_von_ns_luy_ke
					, out v_dc_da_thanh_toan_qbt_trong_thang
					, out v_dc_da_thanh_toan_qbt_luy_ke
					, out v_dc_da_thanh_toan_ns_trong_thang
					, out v_dc_da_thanh_toan_ns_luy_ke
					, out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
					, out v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
					, out v_dc_nhu_cau_von_ky_tiep_theo);
			
			%>
			<td class="stt"><%=v_i_stt++ %></td>
			<td>
				<div class="noi_dung"><a href="F350_tinh_hinh_giai_ngan.aspx?ip_dc_id_don_vi=<%=don_vi.ID %>&ip_dat_tu_ngay=<%=m_txt_tu_ngay.Text %>&ip_dat_den_ngay=<%=m_txt_den_ngay.Text %>" title="Xem chi tiết"><%=don_vi.TEN_DON_VI %></a></div>
			</td>
			<!-----------SoKmQuanLy------------>
			<td class="so_km">
				<%=v_dc_so_km %>
			</td>
			<!-----------TongMucDauTu/TongDuToan------------>
			<td class="so_lieu">
				<%=v_dc_tong_muc_dau_tu %>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
			<td class="so_lieu">
				<%=v_dc_kh_qbt_ntcs%>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
			<td class="so_lieu">
				<%=v_dc_kh_qbt_giao %>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
			<td class="so_lieu">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
			</td>
			<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
			<td class="so_lieu">
				<%=v_dc_kh_ns_ntcs %>
			</td>
			<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
			<td class="so_lieu">
				<%= v_dc_kh_ns_giao%>
			</td>
			<!-----------KeHoach _ NganSach _ TongCong------------>
			<td class="so_lieu">
				<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
			</td>
			<!------------KeHoach _ TongCong--------------------------------------->
			<td class="so_lieu">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
			</td>

			<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_qbt_trong_thang %>
			</td>
			<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_qbt_luy_ke%>
			</td>
			<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_ns_trong_thang %>
			</td>
			<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_ns_luy_ke %>
			</td>
			<!-----------KinhPhiDaNhan _ TongCong------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
			</td>

			<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
			<td class="so_lieu">
				<%=v_dc_da_thanh_toan_qbt_trong_thang %>
			</td>
			<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
			<td class="so_lieu">
				<%=v_dc_da_thanh_toan_qbt_luy_ke %>
			</td>
			<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
			<td class="so_lieu">
				<%=v_dc_da_thanh_toan_ns_trong_thang %>
			</td>
			<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
			<td class="so_lieu">
				<%=v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------KinhPhiDaThanhToan _ TongCong------------>
			<td class="so_lieu">
				<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
			</td>

			<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
			</td>
			<!-----------KinhPhiChuaGN _ NganSach------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------KinhPhiChuaGN _ Tong_cong------------>
			<td class="so_lieu">
				<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>

			<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
			<td class="so_lieu">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
			</td>
			<!-----------KinhPhiConDuocNhan _ NganSach------------>
			<td class="so_lieu">
				<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>
			<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
			<td class="so_lieu">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>

			<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
			<td class="so_lieu">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
			<td class="so_lieu">
				<%=v_dc_nhu_cau_von_ky_tiep_theo %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
			<td class="so_lieu">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
			<td class="so_lieu">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
			</td>

			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
			<td class="so_lieu">
				<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
			</td>
			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
			<td class="so_lieu">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
			<td class="so_lieu">
				<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
				+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
		</tr>
		<%}%>
		</tbody>
	</table>
				</div>
			</td>
		</tr>
	</table>
	<%--</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
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
	</asp:UpdateProgress>--%>
</asp:Content>
