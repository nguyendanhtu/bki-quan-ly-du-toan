﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="F530Grid.ascx.cs" Inherits="QuanLyDuToan.UserControls.F530Grid" %>

<%@ Import Namespace="QuanLyDuToan.Function" %>

<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="QuanLyDuToan.App_Code" %>
<style type="text/css">
		.stt {
			width: 25px;
			text-align: center;
		}

		.noi_dung {
			width: 222px;
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
		th {
			text-align: center !important;
			background: gray;
			border-color: #000;
		}
		.lb {
			width: 100px;
			float: left;
			text-align: right;
			line-height: 20px;
		}

		.control {
			width: 240px;
			float: left;
		}

		.datepicker {
			z-index: 999999 !important;
		}
	</style>
<table class="table-striped table-bordered" border="1" id="m_grv" style="color:Black;width:3900px;border-collapse:collapse;width: 4139px">
							<thead style="background-color:gray;text-align:center">
								<tr>
									<!-----------STT------------>
									<th rowspan="3">STT</th>
									<!-----------NoiDung------------>
									<th rowspan="3" class="noi_dung">Nội dung</th>
									<!-----------SoKmQuanLy------------>
									<th rowspan="3" class="so_km">Số km quản lý</th>
									<!-----------TongMucDauTu/TongDuToan------------>
									<th rowspan="3" style="width: 122px" >TMĐT/ TDT </th>
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
									<th class="so_km" style="text-align:center">3</th>
									<!-----------TongMucDauTu/TongDuToan-------------------------->
									<th style="width: 122px;">4</th>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<th style="width: 122px;">5</th>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<th style="width: 122px;">6</th>
									<!-----------KeHoach _ QuyBaoTri _ Cong------------>
									<th style="width: 122px;">7=5+6</th>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<th style="width: 122px;">8</th>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<th style="width: 122px;">9</th>
									<!-----------KeHoach _ NganSach _ Cong------------>
									<th style="width: 122px;">10=8+9</th>
									<!-----------KeHoach _ NganSach _ Cong------------>
									<th style="width: 122px;">11=7+10</th>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<th style="width: 122px;">12</th>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<th style="width: 122px;">13</th>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<th style="width: 122px;">14</th>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<th style="width: 122px;">15</th>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<th style="width: 122px;">16=13+15</th>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<th style="width: 122px;">17</th>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<th style="width: 122px;">18</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<th style="width: 122px;">19</th>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<th style="width: 122px;">20</th>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<th style="width: 122px;">21=18+20</th>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<th style="width: 122px;">22=13-18</th>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<th style="width: 122px;">23=15-20</th>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<th style="width: 122px;">24=22+23</th>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<th style="width: 122px;">25=7-13</th>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<th style="width: 122px;">26=10-20</th>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<th style="width: 122px;">27=25+26</th>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<th style="width: 122px;">28</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<th style="width: 122px;">29</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<th style="width: 122px;">30</th>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<th style="width: 122px;">31=28+30</th>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<th style="width: 122px;">32=28-18</th>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<th style="width: 122px;">33=28-19</th>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<th style="width: 122px;">34=32+33</th>

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
									<td style="width: 122px;text-align: right;">
										<%=v_dc_tong_muc_dau_tu %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs%>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_ns_ntcs %>
									</td>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_giao%>
									</td>
									<!-----------KeHoach _ NganSach _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>
									<!------------KeHoach _ TongCong--------------------------------------->
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
									</td>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
									</td>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_nhu_cau_von_ky_tiep_theo %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
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
									<td class="noi_dung"><%=item.groupText %></td>
									<!-----------SoKmQuanLy------------>
									<td class="so_km">
										<%=v_dc_so_km %>
									</td>
									<!-----------TongMucDauTu/TongDuToan------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_tong_muc_dau_tu %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs%>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
									</td>
									<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_ns_ntcs %>
									</td>
									<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_giao%>
									</td>
									<!-----------KeHoach _ NganSach _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>
									<!------------KeHoach _ TongCong--------------------------------------->
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
									</td>

									<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaNhan _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
									</td>

									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_ns_trong_thang %>
									</td>
									<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiDaThanhToan _ TongCong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
									</td>

									<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------KinhPhiChuaGN _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>
									<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
									</td>

									<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_nhu_cau_von_ky_tiep_theo %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>
									<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
									</td>

									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
									<td style="width: 122px;text-align: right;">
										<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
									<td style="width: 122px;text-align: right;">
										<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
									</td>
									<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
									<td style="width: 122px;text-align: right;">
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
									---<%=don_vi.TEN_DON_VI %>
								</td>
								<!-----------SoKmQuanLy------------>
								<td class="so_km">
									<%=v_dc_so_km %>
								</td>
								<!-----------TongMucDauTu/TongDuToan------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_tong_muc_dau_tu %>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_ntcs%>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_giao %>
								</td>
								<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
								</td>
								<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_ns_ntcs %>
								</td>
								<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
								<td style="width: 122px;text-align: right;">
									<%= v_dc_kh_ns_giao%>
								</td>
								<!-----------KeHoach _ NganSach _ TongCong------------>
								<td style="width: 122px;text-align: right;">
									<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
								</td>
								<!------------KeHoach _ TongCong--------------------------------------->
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
								</td>

								<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_qbt_trong_thang %>
								</td>
								<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_qbt_luy_ke%>
								</td>
								<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_ns_trong_thang %>
								</td>
								<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_ns_luy_ke %>
								</td>
								<!-----------KinhPhiDaNhan _ TongCong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
								</td>

								<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_da_thanh_toan_qbt_trong_thang %>
								</td>
								<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_da_thanh_toan_qbt_luy_ke %>
								</td>
								<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_da_thanh_toan_ns_trong_thang %>
								</td>
								<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------KinhPhiDaThanhToan _ TongCong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
								</td>

								<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
								</td>
								<!-----------KinhPhiChuaGN _ NganSach------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------KinhPhiChuaGN _ Tong_cong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>

								<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
								</td>
								<!-----------KinhPhiConDuocNhan _ NganSach------------>
								<td style="width: 122px;text-align: right;">
									<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>
								<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
								</td>

								<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_nhu_cau_von_ky_tiep_theo %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
								</td>
								<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
								</td>

								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
								<td style="width: 122px;text-align: right;">
									<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
								</td>
								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
								<td style="width: 122px;text-align: right;">
									<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
								</td>
								<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
								<td style="width: 122px;text-align: right;">
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
			<td class="noi_dung">
				<%=don_vi.TEN_DON_VI %>
			</td>
			<!-----------SoKmQuanLy------------>
			<td class="so_km">
				<%=v_dc_so_km %>
			</td>
			<!-----------TongMucDauTu/TongDuToan------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_tong_muc_dau_tu %>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ SoDuNamTruocChuyenSang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_ntcs%>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ GiaoTrongNam------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_giao %>
			</td>
			<!-----------KeHoach _ QuyBaoTri _ TongCong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao %>
			</td>
			<!-----------KeHoach _ NganSach _ SoDuNamTruocChuyenSang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_ns_ntcs %>
			</td>
			<!-----------KeHoach _ NganSach _ GiaoTrongNam------------>
			<td style="width: 122px;text-align: right;">
				<%= v_dc_kh_ns_giao%>
			</td>
			<!-----------KeHoach _ NganSach _ TongCong------------>
			<td style="width: 122px;text-align: right;">
				<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
			</td>
			<!------------KeHoach _ TongCong--------------------------------------->
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao%>
			</td>

			<!-----------KinhPhiDaNhan _ QuyBaoTri_TrongThang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_qbt_trong_thang %>
			</td>
			<!-----------KinhPhiDaNhan _ QuyBaoTri_LuyKe------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_qbt_luy_ke%>
			</td>
			<!-----------KinhPhiDaNhan _ NganSach_TrongThang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_ns_trong_thang %>
			</td>
			<!-----------KinhPhiDaNhan _ NganSach_LuyKe------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_ns_luy_ke %>
			</td>
			<!-----------KinhPhiDaNhan _ TongCong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_qbt_luy_ke+v_dc_giao_von_ns_luy_ke%>
			</td>

			<!-----------KinhPhiDaThanhToan _ QuyBaoTri_TrongThang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_da_thanh_toan_qbt_trong_thang %>
			</td>
			<!-----------KinhPhiDaThanhToan _ QuyBaoTri_LuyKe------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_da_thanh_toan_qbt_luy_ke %>
			</td>
			<!-----------KinhPhiDaThanhToan _ NganSach_TrongThang------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_da_thanh_toan_ns_trong_thang %>
			</td>
			<!-----------KinhPhiDaThanhToan _ NganSach_LuyKe------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------KinhPhiDaThanhToan _ TongCong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_da_thanh_toan_qbt_luy_ke +v_dc_da_thanh_toan_ns_luy_ke %>
			</td>

			<!-----------KinhPhiChuaGN _ QuyBaoTri------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke %>
			</td>
			<!-----------KinhPhiChuaGN _ NganSach------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------KinhPhiChuaGN _ Tong_cong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_giao_von_qbt_luy_ke-v_dc_da_thanh_toan_qbt_luy_ke 
					+v_dc_giao_von_ns_luy_ke-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>

			<!-----------KinhPhiConDuocNhan _ QuyBaoTri------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke%>
			</td>
			<!-----------KinhPhiConDuocNhan _ NganSach------------>
			<td style="width: 122px;text-align: right;">
				<%= v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>
			<!-----------KinhPhiConDuocNhan _ Tong_cong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_kh_qbt_ntcs+v_dc_kh_qbt_giao -v_dc_giao_von_qbt_luy_ke
				 +v_dc_kh_ns_ntcs+v_dc_kh_ns_giao-v_dc_da_thanh_toan_ns_luy_ke%>
			</td>

			<!-----------GiaTriThucHienDaNghiemThuAB _ QuyBaoTri------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ NhuCauVonKyTiepTheo------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_nhu_cau_von_ky_tiep_theo %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ NganSach------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
			</td>
			<!-----------GiaTriThucHienDaNghiemThuAB _ Tong_cong------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt+v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns %>
			</td>

			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ QuyBaoTri------------>
			<td style="width: 122px;text-align: right;">
				<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke%>
			</td>
			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ NganSach------------>
			<td style="width: 122px;text-align: right;">
				<%=v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
			<!-----------SoChuaGNChoNhaThauTheoNghiemThuAB _ Tong_cong------------>
			<td style="width: 122px;text-align: right;">
				<%= v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt-v_dc_da_thanh_toan_qbt_luy_ke
				+ v_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns-v_dc_da_thanh_toan_ns_luy_ke %>
			</td>
		</tr>
		<%}%>
		</tbody>
	</table>