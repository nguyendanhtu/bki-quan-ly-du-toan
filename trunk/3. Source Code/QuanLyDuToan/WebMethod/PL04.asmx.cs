using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using Framework.Extensions;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for PL04
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL04 : System.Web.Services.WebService
	{
		public List<GD_CHI_TIET_GIAO_KH> InsertDataDuToanToQuyetToan(decimal ip_dc_id_don_vi, decimal ip_dc_nam_quyet_toan)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			DateTime v_dat_dau_nam = new DateTime(Int16.Parse(ip_dc_nam_quyet_toan.ToString()), 1, 1);
			DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(v_dat_dau_nam);
			var lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
										.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= v_dat_dau_nam
													&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_cuoi_nam
													&& x.ID_DON_VI == ip_dc_id_don_vi
													&& x.ID_CHUONG == null)
										.ToList();
			List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
										.Where(x => x.NAM == ip_dc_nam_quyet_toan
											&& x.ID_DON_VI == ip_dc_id_don_vi)
										.ToList();

			//Insert gd_pl04 từ gd_chi_tiet_giao
			foreach (var gd_giao_kh in lst_giao_kh)
			{
				if (lst_pl04
					.Where(x => x.TEN_LOAI_NHIEM_VU.Trim().ToUpper() == gd_giao_kh.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.Trim().ToUpper()
							&& x.CONG_TRINH.Trim().ToUpper() == gd_giao_kh.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()
							&& x.DU_AN.Trim().ToUpper() == gd_giao_kh.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim().ToUpper()
							)
					.Count() < 1
					)
				{
					GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN gd = new GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN();
					gd.CONG_TRINH = gd_giao_kh.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim();
					gd.TEN_LOAI_NHIEM_VU = gd_giao_kh.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.Trim();
					gd.DU_AN = gd_giao_kh.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim();
					gd.ID_DON_VI = ip_dc_id_don_vi;
					gd.NAM = ip_dc_nam_quyet_toan;
					gd.TT = gd_giao_kh.CM_DM_TU_DIEN_LOAI_NHIEM_VU.GHI_CHU.ToUpper();
					gd.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO = 0;
					gd.GIA_TRI_CTHT_NAM_NAY = 0;
					gd.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY = 0;
					gd.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM = 0;
					gd.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET = 0;
					db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN.Add(gd);
					db.SaveChanges();

					//refress list gd_pl04
					lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
										.Where(x => x.NAM == ip_dc_nam_quyet_toan
											&& x.ID_DON_VI == ip_dc_id_don_vi)
										.ToList();
				}
			}

			//Xoá gd_pl04 nếu không có trong gd_chi_tiet_giao_kh
			foreach (var gd_pl04 in lst_pl04)
			{
				if (lst_giao_kh
					.Where(x => x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.Trim().ToUpper() == gd_pl04.TEN_LOAI_NHIEM_VU.Trim().ToUpper()
							&& x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper() == gd_pl04.CONG_TRINH.Trim().ToUpper()
							&& x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim().ToUpper() == gd_pl04.DU_AN.Trim().ToUpper()
							)
					.Count() < 1
					)
				{
					db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN.Remove(gd_pl04);
					db.SaveChanges();
				}
			}

			return db.GD_CHI_TIET_GIAO_KH
										.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= v_dat_dau_nam
													&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_cuoi_nam
													&& x.ID_DON_VI == ip_dc_id_don_vi
													&& x.ID_CHUONG == null)
										.ToList();

		}


		[WebMethod]
		public void UpdateGiaoDich(
			decimal ip_dc_id_giao_dich
			, string ip_str_ten_loai_nhiem_vu
			, string ip_str_cong_trinh
			, string ip_str_du_an
			, string ip_str_GTDTCongTrinhDuocDuyet
			, string ip_str_GTCTHTNamTruocConNoChuyenSangNamNay
			, string ip_str_GTCTHTNamNay
			, string ip_str_GTDNQTTrongNam
			, string ip_str_GTCTHTDQTLKDenNamBaoCao
			)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var lst_lnv = db.CM_DM_TU_DIEN.Where(x => x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU || x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS).ToList();
			GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN gd = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN.FirstOrDefault(x => x.ID == ip_dc_id_giao_dich);
			gd.TT = lst_lnv.FirstOrDefault(x => x.TEN.ToUpper() == ip_str_ten_loai_nhiem_vu.Trim().ToUpper()).GHI_CHU;
			gd.TEN_LOAI_NHIEM_VU = ip_str_ten_loai_nhiem_vu.Trim();
			gd.CONG_TRINH = ip_str_cong_trinh.Trim();
			gd.DU_AN = ip_str_du_an.Trim();
			gd.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET = CIPConvert.ToDecimal(ip_str_GTDTCongTrinhDuocDuyet.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY = CIPConvert.ToDecimal(ip_str_GTCTHTNamTruocConNoChuyenSangNamNay.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_NAM_NAY = CIPConvert.ToDecimal(ip_str_GTCTHTNamNay.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM = CIPConvert.ToDecimal(ip_str_GTDNQTTrongNam.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO = CIPConvert.ToDecimal(ip_str_GTCTHTDQTLKDenNamBaoCao.Trim().Replace(",", "").Replace(".", ""));
			db.SaveChanges();

		}

		[WebMethod]
		public void genGrid(decimal ip_dc_id_don_vi, int ip_i_nam)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04;
			var lst_giao_kh = InsertDataDuToanToQuyetToan(ip_dc_id_don_vi, ip_i_nam);
			lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
					   .Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_i_nam)
					   .ToList();
			string v_str_grid = UserControls.QT_QBT_GRID_PL04.RenderToString(lst_pl04, lst_giao_kh);
			string MaxLNV = lst_pl04
								.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT })
								.OrderBy(x => x.TT)
								.Distinct()
								.ToList()
								.Count.ToString();
			string MaxCT = lst_pl04
				.Select(x => new { x.CONG_TRINH, x.TEN_LOAI_NHIEM_VU })
				.Distinct()
				.ToList()
				.Count.ToString();
			Context.Response.Write(v_str_grid+"*****"+MaxLNV+"*****"+MaxCT);
		}
	}
}
