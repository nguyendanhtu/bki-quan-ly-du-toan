<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="t.aspx.cs" Inherits="QuanLyDuToan.Test.t" %>

<%@ Import Namespace="QuanLyDuToan.Function" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.stt {
			width: 25px !important;
			text-align: center;
		}

		.noi_dung {
			width: 300px !important;
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

			.table > thead > tr > th, .table > tbody > tr > td {
				padding-right: 0px !important;
				padding-left: 0px !important;
			}

		.level_cong_trinh_khoan, .level_loai_nhiem_vu {
			font-weight: bold;
			color: #027;
		}
	</style>
	<script src="../Scripts/jquery.dataTables.js"></script>
	<script src="../Scripts/dataTables.fixedColumns.js"></script>
	<script src="../Scripts/script.js"></script>
	<link href="../Styles/dataTables.fixedColumns.css" rel="stylesheet" />
	<%--<link href="../Styles/jquery.dataTables.css" rel="stylesheet" />--%>
	<script type="text/javascript">
		$(document).ready(function () {

			var table = $('#m_grv').DataTable({
				"scrollY": "400px",
				"scrollX": "1200px",
				"scrollCollapse": true,
				"paging": false,
				"sDom": 'T<"clear"><"top">rt<"bottom">',
				"bSort": false

			});
			new $.fn.dataTable.FixedColumns(table, {
				leftColumns: 2,
			});

			$(window).resize(function () {
				//Khi kich thuoc man hinh bi thay doi thi fix column bi loi css, hien chua tim duoc cach giai quyet, phai load lai trai de khong bi loi css
				location.reload();
				$('#m_grv_wrapper').hide(30000);
				CCommon.thong_bao('Giao diện báo cáo bị lỗi hiển thị, Website đang TẠO LẠI BÁO CÁO cho bạn! Xin vui lòng đợi 30s!', 'error');
			})
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<!------------------------Khai bao bien dung de tinh toan so lieu------------------------------------->
	<%double v_dc_stt, v_dc_so_km, v_dc_tong_muc_dau_tu, v_dc_kh_qbt_ntcs, v_dc_kh_qbt_giao, v_dc_kh_ns_ntcs, v_dc_kh_ns_giao, v_dc_giao_von_qbt_trong_thang, v_dc_giao_von_ns_trong_thang, v_dc_giao_von_qbt_luy_ke, v_dc_giao_von_ns_luy_ke, v_dc_da_thanh_toan_qbt_trong_thang, v_dc_da_thanh_toan_qbt_luy_ke, v_dc_da_thanh_toan_ns_trong_thang, v_dc_da_thanh_toan_ns_luy_ke, v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt, v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns, v_dc_nhu_cau_von_ky_tiep_theo;
   v_dc_stt = 1; %>
	<div id="grid_wrap" style="width: 1200px">
		<table class="table-bordered table table-striped" id="m_grv" style="width: 4217px">
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
				<!--------------Level 0: Tong cong ----------------->
				<%
					Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
							 , m_lst_giao_von
							 , m_lst_giai_ngan
							 , m_lst_khoi_luong
							 , m_dat_dau_nam
							 , m_dat_tu_ngay
							 , m_dat_den_ngay
							 , -1
							 , -1
							 , -1
							 , Fn.para_Level.TongCong
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
				<tr style="font-weight: bold; color: maroon; font-style: italic">
					<!-----------STT------------>
					<td class="stt"></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung" style="text-align: center"><%="Tổng cộng" %></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_giao_von_qbt_trong_thang,"#,##0") %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_giao_von_ns_trong_thang,"#,##0") %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_da_thanh_toan_qbt_trong_thang,"#,##0") %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_da_thanh_toan_ns_trong_thang,"#,##0") %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<%foreach (var lnv in m_lst_loai_nhiem_vu)%>
				<%{%>
				<!--------------Level 1: Loai nhiem vu LNV ----------------->
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
				   , m_lst_giao_von
				   , m_lst_giai_ngan
				   , m_lst_khoi_luong
				   , m_dat_dau_nam
				   , m_dat_tu_ngay
				   , m_dat_den_ngay
				   , lnv.ID
				   , -1
				   , -1
				   , Fn.para_Level.LoaiNhiemVu
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
				<tr class="level_loai_nhiem_vu">
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung"><%=lnv.GHI_CHU+" - " +lnv.TEN %></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(1,m_dc_id_don_vi,lnv.ID,-1,-1,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(1,m_dc_id_don_vi,lnv.ID,-1,-1,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(1,m_dc_id_don_vi,lnv.ID,-1,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(1,m_dc_id_don_vi,lnv.ID,-1,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(1,m_dc_id_don_vi,lnv.ID,-1,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(1,m_dc_id_don_vi,lnv.ID,-1,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(1,m_dc_id_don_vi,lnv.ID,-1,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(1,m_dc_id_don_vi,lnv.ID,-1,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(1,m_dc_id_don_vi,lnv.ID,-1,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(1,m_dc_id_don_vi,lnv.ID,-1,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<%foreach (var ct in m_lst_giao_kh.Where(ct => ct.ID_LOAI_NHIEM_VU == lnv.ID && ct.ID_CONG_TRINH != null).Select(x => new { ID_CONG_TRINH = x.ID_CONG_TRINH, TEN_CONG_TRINH = x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN }).ToList().Distinct().OrderBy(x => x.TEN_CONG_TRINH))%>
				<%{%>
				<!--------------Level 2.1: Cong trinh CT ----------------->
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
					  , m_lst_giao_von
					  , m_lst_giai_ngan
					  , m_lst_khoi_luong
					  , m_dat_dau_nam
					  , m_dat_tu_ngay
					  , m_dat_den_ngay
					  , lnv.ID
					  , ct.ID_CONG_TRINH
					  , -1
					  , Fn.para_Level.CongTrinh
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
				<tr class="level_cong_trinh_khoan">
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung"><%=ct.TEN_CONG_TRINH %></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<!--------------Level 2.1.1: Du an DA ----------------->
				<%foreach (var da in m_lst_giao_kh.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID && x.ID_CONG_TRINH == ct.ID_CONG_TRINH).ToList().Select(x => new { ID_DU_AN = x.ID_DU_AN, TEN_DU_AN = x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN }).Distinct().OrderBy(x => x.TEN_DU_AN))%>
				<%{%>
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
					  , m_lst_giao_von
					  , m_lst_giai_ngan
					  , m_lst_khoi_luong
					  , m_dat_dau_nam
					  , m_dat_tu_ngay
					  , m_dat_den_ngay
					  , lnv.ID
					  , ct.ID_CONG_TRINH
					  , da.ID_DU_AN
					  , Fn.para_Level.DuAn
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
				<tr>
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung">- <%=da.TEN_DU_AN %></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,ct.ID_CONG_TRINH,da.ID_DU_AN,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<%}//end du an%>
				<%}//end Cong trinh%>

				<%foreach (var k in m_lst_giao_kh.Where(k => k.ID_LOAI_NHIEM_VU == lnv.ID && k.ID_KHOAN != null).ToList().Select(x => new { ID_KHOAN = x.ID_KHOAN, MA_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO, MA_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO }).Distinct().OrderBy(x => x.MA_LOAI))%>
				<%{%>
				<!--------------Level 2.2: Khoan K----------------->
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
					  , m_lst_giao_von
					  , m_lst_giai_ngan
					  , m_lst_khoi_luong
					  , m_dat_dau_nam
					  , m_dat_tu_ngay
					  , m_dat_den_ngay
					  , lnv.ID
					  , k.ID_KHOAN
					  , -1
					  , Fn.para_Level.Khoan
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
				<tr class="level_cong_trinh_khoan">
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung"><%="Loại "+k.MA_LOAI+" - "+k.MA_KHOAN%></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(2,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,-1,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<!--------------Level 2.2.1: Muc M----------------->
				<%foreach (var m in m_lst_giao_kh.Where(m => m.ID_LOAI_NHIEM_VU == lnv.ID && m.ID_KHOAN == k.ID_KHOAN && m.ID_TIEU_MUC == null).ToList().Select(x => new { ID_MUC = x.ID_MUC, MA_MUC = x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO, TEN_MUC = x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.TEN }).Distinct().OrderBy(x => x.MA_MUC))%>
				<%{%>
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
					  , m_lst_giao_von
					  , m_lst_giai_ngan
					  , m_lst_khoi_luong
					  , m_dat_dau_nam
					  , m_dat_tu_ngay
					  , m_dat_den_ngay
					  , lnv.ID
					  , k.ID_KHOAN
					  , m.ID_MUC
					  , Fn.para_Level.Muc
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
				<tr>
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung">- <%="Mục "+m.MA_MUC+": "+m.TEN_MUC%></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,m.ID_MUC,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<%}//end Muc%>
				<!--------------Level 2.2.2: Tieu muc TM ----------------->
				<%foreach (var tm in m_lst_giao_kh.Where(tm => tm.ID_LOAI_NHIEM_VU == lnv.ID && tm.ID_KHOAN == k.ID_KHOAN && tm.ID_TIEU_MUC != null).ToList().Select(x => new { ID_TIEU_MUC = x.ID_TIEU_MUC, MA_TIEU_MUC = x.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO, TEN_TIEU_MUC = x.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.TEN, MA_MUC = x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO }).Distinct().OrderBy(x => x.MA_TIEU_MUC))%>
				<%{%>
				<%
		  Fn.F350.set_so_lieu_by_row(m_lst_giao_kh
					  , m_lst_giao_von
					  , m_lst_giai_ngan
					  , m_lst_khoi_luong
					  , m_dat_dau_nam
					  , m_dat_tu_ngay
					  , m_dat_den_ngay
					  , lnv.ID
					  , k.ID_KHOAN
					  , tm.ID_TIEU_MUC
					  , Fn.para_Level.TieuMuc
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
				<tr>
					<!-----------STT------------>
					<td class="stt"><%=v_dc_stt++ %></td>
					<!-----------Noidung------------>
					<td>
						<div class="noi_dung">- <%="Mục "+tm.MA_MUC+", Tiểu mục "+tm.MA_TIEU_MUC+": "+tm.TEN_TIEU_MUC%></div>
					</td>
					<!-----------SoKM------------>
					<td class="so_km">
						<%=v_dc_so_km %>
					</td>
					<!-----------TongMucDauTu/TongDuToan------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_tong_muc_dau_tu,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"N",WebUS.FormInfo.FormName.F157,v_dc_kh_qbt_giao) %>
					</td>
					<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr( v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs,"#,##0") %>
					</td>
					<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"Y",WebUS.FormInfo.FormName.F157,v_dc_kh_ns_giao) %>
					</td>
					<!-----------KeHoach _ NganSach _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>
					<!------------KeHoach _ TongCong--------------------------------------->
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao,"#,##0") %>
					</td>

					<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"N",WebUS.FormInfo.FormName.F257,v_dc_giao_von_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"Y",WebUS.FormInfo.FormName.F257,v_dc_giao_von_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaNhan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"N",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_qbt_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet_trong_thang(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_trong_thang) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
					<td class="so_lieu">
						<%=format_link_to_chi_tiet(3,m_dc_id_don_vi,lnv.ID,k.ID_KHOAN,tm.ID_TIEU_MUC,"Y",WebUS.FormInfo.FormName.F357,v_dc_da_thanh_toan_ns_luy_ke) %>
					</td>
					<!-----------KinhPhiDaThanhToan _ TongCong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiChuaGN _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
+v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>

					<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_nhu_cau_von_ky_tiep_theo,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>
					<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns,"#,##0") %>
					</td>

					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
					<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
					<td class="so_lieu">
						<%=CIPConvert.ToStr(v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke,"#,##0") %>
					</td>
				</tr>
				<%}//end Muc%>
				<%}//end Khoan%>
				<%}//end Loai nhiem vu%>
			</tbody>
		</table>
	</div>

</asp:Content>
