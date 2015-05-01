﻿using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using Framework.Extensions;
using QuanLyDuToan.App_Code;
using System.Web.Script.Serialization;

namespace QuanLyDuToan.Test
{
	public partial class tudm : System.Web.UI.Page
	{
		/*
		 * Gen grid Khoi luong
		 */
		public List<GD_KHOI_LUONG> m_lst_gd;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		public string m_str_nguon = "N";
		public decimal m_dc_id_don_vi;
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			DateTime v_dat_ngay_nhap = new DateTime(2015, 04, 18);
			//m_lst_gd = db.GD_KHOI_LUONG.Where(x => x.ID_DON_VI == 263
			//	&& x.NGAY_THANG == v_dat_ngay_nhap).ToList();
			load_data_to_lst_don_vi(db);
			m_str_nguon = WebformFunctions.getValue_from_query_string<string>(
								this
								, FormInfo.QueryString.NGUON_NGAN_SACH
								, STR_NGUON.QUY_BAO_TRI
								);
			m_dc_id_don_vi = Person.get_id_don_vi();
			load_data_to_grid_by_nguon(m_str_nguon, 263, v_dat_ngay_nhap, db);
		}
		private void load_data_to_grid_by_nguon(
			string ip_str_nguon_ns
			, decimal ip_dc_id_don_vi
			, DateTime ip_dat_ngay_nhap_khoi_luong
			, BKI_QLDTEntities ip_db)
		{
			//Tính toán các biến sử dụng
			DateTime v_dat_dau_nam = CCommonFunction.getDate_dau_nam_from_date(ip_dat_ngay_nhap_khoi_luong);
			DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(ip_dat_ngay_nhap_khoi_luong);

			//Get list GD_GIAO_KH của năm
			var v_lst_gd_giao_kh = ip_db.GD_CHI_TIET_GIAO_KH
										.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
											&& x.DM_QUYET_DINH.NGAY_THANG >= v_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_cuoi_nam)
										.ToList();

			//Get list GD_KHOI_LUONG cua ngày nhập
			var v_lst_gd_khoi_luong = ip_db.GD_KHOI_LUONG
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
												&& x.NGAY_THANG == ip_dat_ngay_nhap_khoi_luong.Date)
											.ToList();

			//Sao chép Công trình, dự án (Khoản, mục) từ GD_GIAO_KH sang GD_KHOI_LUONG
			foreach (var kh in v_lst_gd_giao_kh)
			{
				//Nếu chưa có trong GD_KHOI_LUONG thì insert vào GD_KHOI_LUONG
				if (kh.ID_CONG_TRINH != null)
				{
					if (v_lst_gd_khoi_luong
						.Where(x => x.ID_CONG_TRINH == kh.ID_CONG_TRINH
							&& x.ID_DU_AN == kh.ID_DU_AN).Count() == 0)
					{
						var gd_kl = new GD_KHOI_LUONG();
						gd_kl.ID_DON_VI = ip_dc_id_don_vi;
						gd_kl.ID_LOAI_NHIEM_VU = (decimal)kh.ID_LOAI_NHIEM_VU;
						gd_kl.NGAY_THANG = ip_dat_ngay_nhap_khoi_luong.Date;
						gd_kl.ID_CONG_TRINH = kh.ID_CONG_TRINH;
						gd_kl.ID_DU_AN = kh.ID_DU_AN;
						gd_kl.SO_TIEN_DA_NGHIEM_THU = 0;
						gd_kl.SO_TIEN_DA_NGHIEM_THU_NS = 0;
						ip_db.GD_KHOI_LUONG.Add(gd_kl);
						ip_db.SaveChanges();

						//reload list khối lượng
						v_lst_gd_khoi_luong = ip_db.GD_KHOI_LUONG
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
												&& x.NGAY_THANG == ip_dat_ngay_nhap_khoi_luong.Date)
											.ToList();
					}
				}
				else if (kh.ID_KHOAN != null)
				{
					if (v_lst_gd_khoi_luong
						.Where(x => x.ID_KHOAN == kh.ID_KHOAN
							&& x.ID_MUC == kh.ID_MUC
							&& x.ID_TIEU_MUC == x.ID_TIEU_MUC).Count() == 0)
					{
						var gd_kl = new GD_KHOI_LUONG();
						gd_kl.ID_LOAI_NHIEM_VU = (decimal)kh.ID_LOAI_NHIEM_VU;
						gd_kl.ID_DON_VI = ip_dc_id_don_vi;
						gd_kl.NGAY_THANG = ip_dat_ngay_nhap_khoi_luong.Date;
						gd_kl.ID_CHUONG = kh.ID_CHUONG;
						gd_kl.ID_KHOAN = kh.ID_KHOAN;
						gd_kl.ID_MUC = kh.ID_MUC;
						gd_kl.ID_TIEU_MUC = kh.ID_TIEU_MUC;
						gd_kl.SO_TIEN_DA_NGHIEM_THU = 0;
						gd_kl.SO_TIEN_DA_NGHIEM_THU_NS = 0;
						ip_db.GD_KHOI_LUONG.Add(gd_kl);
						ip_db.SaveChanges();

						//reload list khối lượng
						v_lst_gd_khoi_luong = ip_db.GD_KHOI_LUONG
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
												&& x.NGAY_THANG == ip_dat_ngay_nhap_khoi_luong.Date)
											.ToList();
					}
				}
			}

			//Xoá bỏ những Công trình, dự án (Khoản, mục) của GD_KHOI_LUONG mà không có trong GD_GIAO_KH
			foreach (var kl in v_lst_gd_khoi_luong)
			{
				if (kl.ID_CONG_TRINH != null)
				{
					if (v_lst_gd_giao_kh.Where(x => x.ID_CONG_TRINH == kl.ID_CONG_TRINH
						&& x.ID_DU_AN == kl.ID_DU_AN).Count() == 0)
					{
						ip_db.GD_KHOI_LUONG.Remove(kl);
						ip_db.SaveChanges();
					}
				}
				else if (kl.ID_KHOAN != null)
				{
					if (v_lst_gd_giao_kh.Where(x => x.ID_KHOAN == kl.ID_KHOAN
						&& x.ID_MUC == kl.ID_MUC
						&& x.ID_TIEU_MUC == kl.ID_TIEU_MUC).Count() == 0)
					{
						ip_db.GD_KHOI_LUONG.Remove(kl);
						ip_db.SaveChanges();
					}
				}
			}
			//reload list khối lượng
			v_lst_gd_khoi_luong = ip_db.GD_KHOI_LUONG
								.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
									&& x.NGAY_THANG == ip_dat_ngay_nhap_khoi_luong.Date)
								.ToList();
			//Load dữ liệu theo Nguồn: Ngân sách hoặc Quỹ bảo trì
			List<GD_CHI_TIET_GIAO_KH> v_lst_giao_kh_theo_nguon = new List<GD_CHI_TIET_GIAO_KH>() ;
			//Lấy list giao kh, chứa id_Cong_trinh/id_du_an (id_khoan/id_muc, id_tieu_muc) theo nguồn
			if (ip_str_nguon_ns=="N")
			{
				 v_lst_giao_kh_theo_nguon = v_lst_gd_giao_kh.Where(x => x.SO_TIEN_NS == 0).ToList();
				
			}
			else if (ip_str_nguon_ns=="Y")
			{
				 v_lst_giao_kh_theo_nguon = v_lst_gd_giao_kh.Where(x => x.SO_TIEN_QUY_BT == 0).ToList();
			}
			//Load những đầu mục GD_KHOI_LUONG theo nguồn
			m_lst_gd = v_lst_gd_khoi_luong
							.Where(x => (x.ID_KHOAN != null
										&& v_lst_giao_kh_theo_nguon.Where(y => y.ID_KHOAN == x.ID_KHOAN
																	&& y.ID_MUC == x.ID_MUC
																	&& y.ID_TIEU_MUC == x.ID_TIEU_MUC).Count() > 0)
										|| (x.ID_CONG_TRINH != null
										&& v_lst_giao_kh_theo_nguon.Where(y => y.ID_CONG_TRINH == x.ID_CONG_TRINH
																	&& y.ID_DU_AN == x.ID_DU_AN).Count() > 0)
							).ToList();
		}
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(v_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}

		public class KhoiLuongItem
		{
			public decimal ID { get; set; }
			public string GIA_TRI_THUC_HIEN_QBT { get; set; }
			public string GIA_TRI_THUC_HIEN_NS { get; set; }
		}

		public  void UpdateAll(string ip_str_arr)
		{
			JavaScriptSerializer js = new JavaScriptSerializer();
			KhoiLuongItem[] ip_arr = js.Deserialize<KhoiLuongItem[]>(ip_str_arr);
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			for (int i = 0; i < ip_arr.Length; i++)
			{
				decimal v_dc_id = ip_arr[i].ID;
				var gd = db.GD_KHOI_LUONG.FirstOrDefault(x => x.ID == v_dc_id);
				if (gd == null) continue;
				gd.SO_TIEN_DA_NGHIEM_THU = Convert.ToDecimal(ip_arr[i].GIA_TRI_THUC_HIEN_QBT.Replace(",", "").Replace(".", ""));
				gd.SO_TIEN_DA_NGHIEM_THU_NS = Convert.ToDecimal(ip_arr[i].GIA_TRI_THUC_HIEN_NS.Replace(",", "").Replace(".", ""));
				db.SaveChanges();
			}

		}
	}
}