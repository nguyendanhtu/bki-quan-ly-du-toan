using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SQLDataAccess;
using System.Linq.Expressions;

namespace QuanLyDuToan.Function
{
	public class Fn
	{
		public class F350
		{
			public static double getSoLieu(
				List<GD_CHI_TIET_GIAO_KH> ip_lst_giao_kh
				, List<GD_CHI_TIET_GIAO_VON> ip_lst_giao_von
				, List<GD_CHI_TIET_GIAI_NGAN> ip_lst_giai_ngan
				, List<GD_KHOI_LUONG> ip_lst_khoi_luong
				, DateTime ip_dat_dau_nam
				, DateTime ip_dat_tu_ngay
				, DateTime ip_dat_den_ngay
				, decimal ip_dc_id_loai_nhiem_vu
				, decimal? ip_dc_id_cong_trinh_khoan
				, decimal? ip_dc_id_du_an_muc_tieu_muc
				, para_bao_cao ip_para
				, para_Level ip_level
				)
			{
				double v_dc_result = 0;
				List<GD_CHI_TIET_GIAO_KH> v_lst_kh_dieu_chinh;
				List<GD_CHI_TIET_GIAO_KH> v_lst_kh_dau_nam_bo_sung;
				List<GD_CHI_TIET_GIAO_VON> v_lst_giao_von_dau_nam_bo_sung;
				List<GD_CHI_TIET_GIAO_VON> v_lst_giao_von_dieu_chinh;
				decimal? v_dc_dieu_chinh;
				decimal? v_dc_dau_nam_bo_sung;
				switch (ip_para)
				{
					case para_bao_cao.SoKM:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = ip_lst_giao_kh.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.CongTrinh:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
													&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.Khoan:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
													&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.DuAn:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
													&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
													&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.Muc:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
													&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
													&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							case para_Level.TieuMuc:
								v_dc_result = ip_lst_giao_kh
												.Where(x => x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
													&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
													&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
												.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KeHoachNamTruocChuyenSang_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KeHoachNamTruocChuyenSang_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KeHoachGiao_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KeHoachGiao_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaNhan_TrongThang_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaNhan_LuyKe_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_giao_von_dieu_chinh = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList();
								v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaNhan_TrongThang_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
									   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
									   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc
									   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
									   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc
									   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
									   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc
										&& x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc
									   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
									   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaNhan_LuyKe_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.LoaiNhiemVu:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.CongTrinh:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Khoan:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.DuAn:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.Muc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							case para_Level.TieuMuc:
								v_lst_kh_dieu_chinh = ip_lst_giao_kh
									.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.ToList();
								v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
								   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
									   && x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
									   && x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
									   && x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
								   .ToList()
									//Loại trừ dự án, mục, tiểu mục điều chỉnh
								   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
									   y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
									   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
									   && y.ID_KHOAN == x.ID_KHOAN
									   && (y.ID_DU_AN == x.ID_DU_AN
									   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
									   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
								   .ToList();
								v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
								v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
								v_dc_result = Convert.ToDouble(v_dc_dau_nam_bo_sung + v_dc_dieu_chinh);
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaThanhToan_TrongThang_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N")
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == x.ID_DU_AN)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaThanhToan_LuyKe_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N")
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == x.ID_DU_AN)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaThanhToan_TrongThang_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y")
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == x.ID_DU_AN)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.KinhPhiDaThanhToan_LuyKe_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y")
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
										&& x.ID_DU_AN == x.ID_DU_AN)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
									.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_dau_nam
										&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
										&& x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
										&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
										&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
										&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									.Sum(x => x.SO_TIEN_NOP_THUE + (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
								break;
							default:
								break;
						}
						break;
					case para_bao_cao.GiaTriThucHienDaNghiemThuAB_QuyBaoTri:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
											&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
											&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
											&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)));

								break;
							default:
								break;
						}
						break;
					case para_bao_cao.GiaTriThucHienDaNghiemThuAB_NganSach:
						switch (ip_level)
						{
							case para_Level.TongCong:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.LoaiNhiemVu:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.CongTrinh:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.Khoan:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.DuAn:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_CONG_TRINH == ip_dc_id_cong_trinh_khoan
											&& x.ID_DU_AN == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.Muc:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
											&& x.ID_MUC == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));
								break;
							case para_Level.TieuMuc:
								v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
									 .Where(x => x.NGAY_THANG >= ip_dat_dau_nam
											&& x.NGAY_THANG <= ip_dat_den_ngay
											&& x.ID_LOAI_NHIEM_VU == ip_dc_id_loai_nhiem_vu
											&& x.ID_KHOAN == ip_dc_id_cong_trinh_khoan
											&& x.ID_TIEU_MUC == ip_dc_id_du_an_muc_tieu_muc)
									 .Sum(x => (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0)));

								break;
							default:
								break;
						}
						break;
					default:
						break;
				}
				return v_dc_result;
			}



			public static void set_so_lieu_by_row(
				List<GD_CHI_TIET_GIAO_KH> ip_lst_giao_kh
				, List<GD_CHI_TIET_GIAO_VON> ip_lst_giao_von
				, List<GD_CHI_TIET_GIAI_NGAN> ip_lst_giai_ngan
				, List<GD_KHOI_LUONG> ip_lst_khoi_luong
				, DateTime ip_dat_dau_nam
				, DateTime ip_dat_tu_ngay
				, DateTime ip_dat_den_ngay
				, decimal ip_dc_id_loai_nhiem_vu
				, decimal? ip_dc_id_cong_trinh_khoan
				, decimal? ip_dc_id_du_an_muc_tieu_muc
				, para_Level ip_para
				, out double ip_dc_so_km
				, out double ip_dc_tong_muc_dau_tu
				, out double ip_dc_ke_hoach_qbt_ntcs
				, out double ip_dc_ke_hoach_qbt_giao
				, out double ip_dc_ke_hoach_ns_ntcs
				, out double ip_dc_ke_hoach_ns_giao
				, out double ip_dc_da_nhan_qbt_trong_thang
				, out double ip_dc_da_nhan_qbt_luy_ke
				, out double ip_dc_da_nhan_ns_trong_thang
				, out double ip_dc_da_nhan_ns_luy_ke
				, out double ip_dc_da_thanh_toan_qbt_trong_thang
				, out double ip_dc_da_thanh_toan_qbt_luy_ke
				, out double ip_dc_da_thanh_toan_ns_trong_thang
				, out double ip_dc_da_thanh_toan_ns_luy_ke
				, out double ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
				, out double ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
				, out double ip_dc_nhu_cau_von_ky_tiep_theo)
			{
				ip_dc_so_km = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.SoKM
									, ip_para);
				ip_dc_tong_muc_dau_tu = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.TongMucDauTu
									, ip_para);
				ip_dc_ke_hoach_qbt_ntcs = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KeHoachNamTruocChuyenSang_QuyBaoTri
									, ip_para);
				ip_dc_ke_hoach_qbt_giao = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KeHoachGiao_QuyBaoTri
									, ip_para);
				ip_dc_ke_hoach_ns_ntcs = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KeHoachNamTruocChuyenSang_NganSach
									, ip_para);
				ip_dc_ke_hoach_ns_giao = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KeHoachGiao_NganSach
									, ip_para);
				ip_dc_da_nhan_qbt_trong_thang = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaNhan_TrongThang_QuyBaoTri
									, ip_para);
				ip_dc_da_nhan_qbt_luy_ke = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaNhan_LuyKe_QuyBaoTri
									, ip_para);
				ip_dc_da_nhan_ns_trong_thang = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaNhan_TrongThang_NganSach
									, ip_para);
				ip_dc_da_nhan_ns_luy_ke = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaNhan_LuyKe_NganSach
									, ip_para);
				ip_dc_da_thanh_toan_qbt_trong_thang = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaThanhToan_TrongThang_QuyBaoTri
									, ip_para);
				ip_dc_da_thanh_toan_qbt_luy_ke = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaThanhToan_LuyKe_QuyBaoTri
									, ip_para);
				ip_dc_da_thanh_toan_ns_trong_thang = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaThanhToan_TrongThang_NganSach
									, ip_para);
				ip_dc_da_thanh_toan_ns_luy_ke = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.KinhPhiDaThanhToan_LuyKe_NganSach
									, ip_para);
				ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.GiaTriThucHienDaNghiemThuAB_QuyBaoTri
									, ip_para);
				ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.GiaTriThucHienDaNghiemThuAB_NganSach
									, ip_para);
				ip_dc_nhu_cau_von_ky_tiep_theo = F350.getSoLieu(ip_lst_giao_kh
									, ip_lst_giao_von
									, ip_lst_giai_ngan
									, ip_lst_khoi_luong
									, ip_dat_dau_nam
									, ip_dat_tu_ngay
									, ip_dat_den_ngay
									, ip_dc_id_loai_nhiem_vu
									, ip_dc_id_cong_trinh_khoan
									, ip_dc_id_du_an_muc_tieu_muc
									, para_bao_cao.NhuCauVonKyTiepTheo
									, ip_para);
			}
		}

		public class F530
		{
			public static double getSoLieu(
				List<GD_CHI_TIET_GIAO_KH> ip_lst_giao_kh
				, List<GD_CHI_TIET_GIAO_VON> ip_lst_giao_von
				, List<GD_CHI_TIET_GIAI_NGAN> ip_lst_giai_ngan
				, List<GD_KHOI_LUONG> ip_lst_khoi_luong
				, decimal ip_dc_id_don_vi
				, DateTime ip_dat_dau_nam
				, DateTime ip_dat_tu_ngay
				, DateTime ip_dat_den_ngay
				, para_F530_Group ip_group
				, string ip_str_group_key
				, para_bao_cao ip_para
				)
			{
				double v_dc_result = 0;
				List<GD_CHI_TIET_GIAO_KH> v_lst_kh_dieu_chinh;
				List<GD_CHI_TIET_GIAO_KH> v_lst_kh_dau_nam_bo_sung;
				List<GD_CHI_TIET_GIAO_VON> v_lst_giao_von_dau_nam_bo_sung;
				List<GD_CHI_TIET_GIAO_VON> v_lst_giao_von_dieu_chinh;
				decimal? v_dc_dieu_chinh;
				decimal? v_dc_dau_nam_bo_sung;

				switch (ip_para)
				{
					case para_bao_cao.SoKM:
						v_dc_result = ip_lst_giao_kh
							.Where(x =>
								(
									//Don vi
								x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
									//Nhom theo Cuc
								|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
										|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
										|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
											.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
									&& ip_group == para_F530_Group.Cuc)
									//Tong cong
								|| (ip_group == para_F530_Group.TongCong)
							)
							.Sum(x => Convert.ToDouble(x.GHI_CHU_2 ?? "0"));
						break;
					case para_bao_cao.TongMucDauTu:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && (
									(
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && (
									(
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
							   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
							   && y.ID_KHOAN == x.ID_KHOAN
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.TONG_MUC_DAU_TU);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.TONG_MUC_DAU_TU);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KeHoachNamTruocChuyenSang_QuyBaoTri:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && (
									(
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && (
									(
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
							   && y.ID_CONG_TRINH == x.ID_CONG_TRINH
							   && y.ID_KHOAN == x.ID_KHOAN
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KeHoachNamTruocChuyenSang_NganSach:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KeHoachGiao_QuyBaoTri:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KeHoachGiao_NganSach:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KinhPhiDaNhan_TrongThang_QuyBaoTri:
						v_lst_giao_von_dieu_chinh = ip_lst_giao_von
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
								   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
								   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KinhPhiDaNhan_LuyKe_QuyBaoTri:
						v_lst_giao_von_dieu_chinh = ip_lst_giao_von
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_dau_nam
								   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_giao_von_dau_nam_bo_sung = ip_lst_giao_von
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_dau_nam
								   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_giao_von_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_giao_von_dieu_chinh.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_dau_nam_bo_sung = v_lst_giao_von_dau_nam_bo_sung.Sum(x => x.SO_TIEN_QUY_BT);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KinhPhiDaNhan_TrongThang_NganSach:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
							   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
							   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_tu_ngay
								   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
								   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KinhPhiDaNhan_LuyKe_NganSach:
						v_lst_kh_dieu_chinh = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_dau_nam
							   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
							   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList();
						v_lst_kh_dau_nam_bo_sung = ip_lst_giao_kh
						   .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							   && x.DM_QUYET_DINH.NGAY_THANG >= ip_dat_dau_nam
							   && x.DM_QUYET_DINH.NGAY_THANG <= ip_dat_den_ngay
							   && ((
							   //Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
							   //Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
							   //Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
						   .ToList()
							//Loại trừ dự án, mục, tiểu mục điều chỉnh
						   .Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
							   y.ID_DON_VI == x.ID_DON_VI
							   && (y.ID_DU_AN == x.ID_DU_AN
							   || (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
							   || (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
						   .ToList();
						v_dc_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x => x.SO_TIEN_NS);
						v_dc_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x => x.SO_TIEN_NS);
						v_dc_result = Convert.ToDouble(v_dc_dieu_chinh + v_dc_dau_nam_bo_sung);
						break;
					case para_bao_cao.KinhPhiDaThanhToan_TrongThang_QuyBaoTri:
						v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
										.Where(x => x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
											&& x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
											&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
											&& ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_NOP_THUE
											+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
						break;
					case para_bao_cao.KinhPhiDaThanhToan_LuyKe_QuyBaoTri:
						v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
										.Where(x => x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "N"
											&& ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_NOP_THUE
											+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
						break;
					case para_bao_cao.KinhPhiDaThanhToan_TrongThang_NganSach:
						v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
										.Where(x => x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
											&& x.DM_GIAI_NGAN.NGAY_THANG >= ip_dat_tu_ngay
											&& x.DM_GIAI_NGAN.NGAY_THANG <= ip_dat_den_ngay
											&& ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_NOP_THUE
											+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
						break;
					case para_bao_cao.KinhPhiDaThanhToan_LuyKe_NganSach:
						v_dc_result = Convert.ToDouble(ip_lst_giai_ngan
										.Where(x => x.DM_GIAI_NGAN.IS_NGUON_NS_YN == "Y"
											&& ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_NOP_THUE
											+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0)));
						break;

					case para_bao_cao.GiaTriThucHienDaNghiemThuAB_QuyBaoTri:
						v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
										.Where(x => ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_DA_NGHIEM_THU) ?? 0);
						break;
					case para_bao_cao.GiaTriThucHienDaNghiemThuAB_NganSach:
						v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
										.Where(x => ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.Sum(x => x.SO_TIEN_DA_NGHIEM_THU_NS) ?? 0);
						break;
					case para_bao_cao.NhuCauVonKyTiepTheo:
						v_dc_result = Convert.ToDouble(ip_lst_khoi_luong
										.Where(x => ((
											//Don vi
									x.ID_DON_VI == ip_dc_id_don_vi && ip_group == para_F530_Group.DonVi)
											//Nhom theo Cuc
									|| ((x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains(ip_str_group_key.ToUpper())
											|| x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains((ip_str_group_key + ".").ToUpper())
											|| (x.DM_DON_VI.TEN_DON_VI + " - Văn phòng").ToUpper()
												.Contains(ip_str_group_key.Replace(".", " - Văn phòng").ToUpper()))
										&& ip_group == para_F530_Group.Cuc)
											//Tong cong
									|| (ip_group == para_F530_Group.TongCong)
								   ))
										.OrderByDescending(x => x.NGAY_THANG)
										.GroupBy(x => new { x.NGAY_THANG, x.ID })
										.Select(x => x.First())
										.Sum(x => x.NHU_CAU_VON_KY_TIEP_THEO) ?? 0);
						break;
					default:
						break;
				}
				return v_dc_result;
			}

			public static void get_so_lieu_by_row(
				List<GD_CHI_TIET_GIAO_KH> ip_lst_giao_kh
				, List<GD_CHI_TIET_GIAO_VON> ip_lst_giao_von
				, List<GD_CHI_TIET_GIAI_NGAN> ip_lst_giai_ngan
				, List<GD_KHOI_LUONG> ip_lst_khoi_luong
				, decimal ip_dc_id_don_vi
				, DateTime ip_dat_dau_nam
				, DateTime ip_dat_tu_ngay
				, DateTime ip_dat_den_ngay
				, para_F530_Group ip_group
				, string ip_str_group_key
				, out double ip_dc_so_km
				, out double ip_dc_tong_muc_dau_tu
				, out double ip_dc_ke_hoach_qbt_ntcs
				, out double ip_dc_ke_hoach_qbt_giao
				, out double ip_dc_ke_hoach_ns_ntcs
				, out double ip_dc_ke_hoach_ns_giao
				, out double ip_dc_da_nhan_qbt_trong_thang
				, out double ip_dc_da_nhan_qbt_luy_ke
				, out double ip_dc_da_nhan_ns_trong_thang
				, out double ip_dc_da_nhan_ns_luy_ke
				, out double ip_dc_da_thanh_toan_qbt_trong_thang
				, out double ip_dc_da_thanh_toan_qbt_luy_ke
				, out double ip_dc_da_thanh_toan_ns_trong_thang
				, out double ip_dc_da_thanh_toan_ns_luy_ke
				, out double ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt
				, out double ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns
				, out double ip_dc_nhu_cau_von_ky_tiep_theo
				)
			{
				ip_dc_so_km = Fn.F530.getSoLieu(ip_lst_giao_kh
										 , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										 , Fn.para_bao_cao.SoKM);
				ip_dc_tong_muc_dau_tu = Fn.F530.getSoLieu(ip_lst_giao_kh
													 , ip_lst_giao_von
													 , ip_lst_giai_ngan
													 , ip_lst_khoi_luong
													 , ip_dc_id_don_vi
													 , ip_dat_dau_nam
													 , ip_dat_tu_ngay
													 , ip_dat_den_ngay
													 , ip_group
													 , ip_str_group_key
													 , Fn.para_bao_cao.TongMucDauTu);
				ip_dc_ke_hoach_qbt_ntcs = Fn.F530.getSoLieu(ip_lst_giao_kh
											   , ip_lst_giao_von
											   , ip_lst_giai_ngan
											   , ip_lst_khoi_luong
											   , ip_dc_id_don_vi
											   , ip_dat_dau_nam
											   , ip_dat_tu_ngay
											   , ip_dat_den_ngay
											   , ip_group
											   , ip_str_group_key
											   , Fn.para_bao_cao.KeHoachNamTruocChuyenSang_QuyBaoTri);
				ip_dc_ke_hoach_qbt_giao = Fn.F530.getSoLieu(ip_lst_giao_kh
												  , ip_lst_giao_von
												  , ip_lst_giai_ngan
												  , ip_lst_khoi_luong
												  , ip_dc_id_don_vi
												  , ip_dat_dau_nam
												  , ip_dat_tu_ngay
												  , ip_dat_den_ngay
												  , ip_group
												  , ip_str_group_key
												   , Fn.para_bao_cao.KeHoachGiao_QuyBaoTri);
				ip_dc_ke_hoach_ns_ntcs = Fn.F530.getSoLieu(ip_lst_giao_kh
											   , ip_lst_giao_von
											   , ip_lst_giai_ngan
											   , ip_lst_khoi_luong
											   , ip_dc_id_don_vi
											   , ip_dat_dau_nam
											   , ip_dat_tu_ngay
											   , ip_dat_den_ngay
											   , ip_group
												 , ip_str_group_key
											   , Fn.para_bao_cao.KeHoachNamTruocChuyenSang_NganSach);
				ip_dc_ke_hoach_ns_giao = Fn.F530.getSoLieu(ip_lst_giao_kh
												  , ip_lst_giao_von
												  , ip_lst_giai_ngan
												  , ip_lst_khoi_luong
												  , ip_dc_id_don_vi
												  , ip_dat_dau_nam
												  , ip_dat_tu_ngay
												  , ip_dat_den_ngay
												  , ip_group
												  , ip_str_group_key
												   , Fn.para_bao_cao.KeHoachGiao_NganSach);
				ip_dc_da_nhan_qbt_trong_thang = Fn.F530.getSoLieu(ip_lst_giao_kh
												  , ip_lst_giao_von
												  , ip_lst_giai_ngan
												  , ip_lst_khoi_luong
												  , ip_dc_id_don_vi
												  , ip_dat_dau_nam
												  , ip_dat_tu_ngay
												  , ip_dat_den_ngay
												  , ip_group
												 , ip_str_group_key
												   , Fn.para_bao_cao.KinhPhiDaNhan_TrongThang_QuyBaoTri);
				ip_dc_da_nhan_ns_trong_thang = Fn.F530.getSoLieu(ip_lst_giao_kh
												  , ip_lst_giao_von
												  , ip_lst_giai_ngan
												  , ip_lst_khoi_luong
												  , ip_dc_id_don_vi
												  , ip_dat_dau_nam
												  , ip_dat_tu_ngay
												  , ip_dat_den_ngay
												  , ip_group
												, ip_str_group_key
												   , Fn.para_bao_cao.KinhPhiDaNhan_TrongThang_NganSach);
				ip_dc_da_nhan_qbt_luy_ke = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.KinhPhiDaNhan_LuyKe_QuyBaoTri);
				ip_dc_da_nhan_ns_luy_ke = Fn.F530.getSoLieu(ip_lst_giao_kh
												   , ip_lst_giao_von
												   , ip_lst_giai_ngan
												   , ip_lst_khoi_luong
												   , ip_dc_id_don_vi
												   , ip_dat_dau_nam
												   , ip_dat_tu_ngay
												   , ip_dat_den_ngay
												   , ip_group
												 , ip_str_group_key
													, Fn.para_bao_cao.KinhPhiDaNhan_LuyKe_NganSach);
				ip_dc_da_thanh_toan_qbt_trong_thang = Fn.F530.getSoLieu(ip_lst_giao_kh
										   , ip_lst_giao_von
										   , ip_lst_giai_ngan
										   , ip_lst_khoi_luong
										   , ip_dc_id_don_vi
										   , ip_dat_dau_nam
										   , ip_dat_tu_ngay
										   , ip_dat_den_ngay
										   , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.KinhPhiDaThanhToan_TrongThang_QuyBaoTri);
				ip_dc_da_thanh_toan_qbt_luy_ke = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.KinhPhiDaThanhToan_LuyKe_QuyBaoTri);
				ip_dc_da_thanh_toan_ns_trong_thang = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.KinhPhiDaThanhToan_TrongThang_NganSach);
				ip_dc_da_thanh_toan_ns_luy_ke = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.KinhPhiDaThanhToan_LuyKe_NganSach);
				ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_qbt = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.GiaTriThucHienDaNghiemThuAB_QuyBaoTri);
				ip_dc_gia_tri_thuc_hien_da_nghiem_thu_ab_ns = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.GiaTriThucHienDaNghiemThuAB_NganSach);
				ip_dc_nhu_cau_von_ky_tiep_theo = Fn.F530.getSoLieu(ip_lst_giao_kh
										  , ip_lst_giao_von
										  , ip_lst_giai_ngan
										  , ip_lst_khoi_luong
										  , ip_dc_id_don_vi
										  , ip_dat_dau_nam
										  , ip_dat_tu_ngay
										  , ip_dat_den_ngay
										  , ip_group
										  , ip_str_group_key
										   , Fn.para_bao_cao.NhuCauVonKyTiepTheo);
			}
		}

		public enum para_bao_cao
		{
			SoKM,

			KeHoachNamTruocChuyenSang_QuyBaoTri,
			KeHoachNamTruocChuyenSang_NganSach,
			KeHoachGiao_QuyBaoTri,
			KeHoachGiao_NganSach,
			TongMucDauTu,

			KinhPhiDaNhan_TrongThang_QuyBaoTri,
			KinhPhiDaNhan_LuyKe_QuyBaoTri,
			KinhPhiDaNhan_TrongThang_NganSach,
			KinhPhiDaNhan_LuyKe_NganSach,

			KinhPhiDaThanhToan_TrongThang_QuyBaoTri,
			KinhPhiDaThanhToan_LuyKe_QuyBaoTri,
			KinhPhiDaThanhToan_TrongThang_NganSach,
			KinhPhiDaThanhToan_LuyKe_NganSach,

			/*KinhPhiChuaGiaiNgan_QuyBaoTri,
			KinhPhiChuaGiaiNgan_NganSach,

			KinhPhiConDuocNhan_QuyBaoTri,
			KinhPhiConDuocNhan_NganSach,*/

			GiaTriThucHienDaNghiemThuAB_QuyBaoTri,
			GiaTriThucHienDaNghiemThuAB_NganSach,
			NhuCauVonKyTiepTheo

			/*SoChuaGiaiNganChoNhaThauTheoNghiemThuAB_QuyBaoTri,
			SoChuaGiaiNganChoNhaThauTheoNghiemThuAB_NganSach*/
		}
		public enum para_Level
		{
			TongCong,
			LoaiNhiemVu,
			CongTrinh,
			Khoan,
			DuAn,
			Muc,
			TieuMuc
		}

		public enum para_F530_Group
		{
			TongCong,
			Cuc,
			DonVi
		}
	}
}
