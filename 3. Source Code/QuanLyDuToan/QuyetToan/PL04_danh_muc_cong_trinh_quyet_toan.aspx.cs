using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using SQLDataAccess;
using QuanLyDuToan.App_Code;
using WebUS;
using WebDS;
using Framework.Extensions;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL04_danh_muc_cong_trinh_quyet_toan : System.Web.UI.Page
	{
		#region Public Function

		#endregion

		#region Data Structures
		public class ItemLNV
		{
			public string Value;
			public string Ten;
		}
		#endregion

		#region Members
		public List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04;
		public List<ItemLNV> lst_loai_nhiem_vu;
		public List<DM_CONG_TRINH_DU_AN_GOI_THAU> lst_du_an;
		public List<GD_CHI_TIET_GIAO_KH> lst_giao_kh;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		#endregion

		#region Private Methods
		private void InsertDataDuToanToQuyetToan(decimal ip_dc_id_don_vi, decimal ip_dc_nam_quyet_toan)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			DateTime v_dat_dau_nam = new DateTime(Int16.Parse(ip_dc_nam_quyet_toan.ToString()), 1, 1);
			DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(v_dat_dau_nam);
			lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
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
					.ToList()
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
					.ToList()
					.Count() < 1
					)
				{
					db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN.Remove(gd_pl04);
					db.SaveChanges();
				}
			}

		}

		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db, decimal ip_dc_id_don_vi)
		{
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(ip_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			//InsertDataDuToanToQuyetToan(Person.get_id_don_vi(),"2014");
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				InsertDataDuToanToQuyetToan(241, 2014);
				lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
						   .Where(x => x.ID_DON_VI == 241 && x.NAM == 2014)
						   .ToList();
				lst_loai_nhiem_vu = db.CM_DM_TU_DIEN
							.Where(x => x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU)
							.OrderBy(x => x.GHI_CHU)
							.Select(x => new ItemLNV { Ten = x.GHI_CHU + " - " + x.TEN, Value = x.TEN })
							.ToList();
				load_data_to_lst_don_vi(db, Person.get_id_don_vi());
			}
		}
		#endregion
	}
}