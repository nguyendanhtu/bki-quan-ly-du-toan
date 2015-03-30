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
		#endregion

		#region Private Methods
		private void InsertDataDuToanToQuyetToan(decimal ip_dc_id_don_vi, string ip_str_nam_quyet_toan)
		{
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				DateTime v_dat_dau_nam = new DateTime(Int16.Parse(ip_str_nam_quyet_toan), 1, 1);
				DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(v_dat_dau_nam);
				List<GD_CHI_TIET_GIAO_KH> lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
											.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= v_dat_dau_nam
														&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_cuoi_nam
														&& x.ID_DON_VI == ip_dc_id_don_vi)
											.ToList();
				List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
											.Where(x => x.NAM == CIPConvert.ToDecimal(ip_str_nam_quyet_toan)
												&& x.ID_DON_VI == ip_dc_id_don_vi)
											.ToList();
				List<DM_CONG_TRINH_DU_AN_GOI_THAU> lst_cong_trinh = lst_giao_kh.Select(x => x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH).Distinct().ToList();
				//List<DM_CONG_TRINH_DU_AN_GOI_THAU> lst_du_an = lst_giao_kh.Select(x => x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH).Distinct().ToList();
				//foreach (var gd_kh in lst_giao_kh)
				//{
				//	if (lst_pl04.Where(x => x.CAP == 2
				//		&& x.CONG_TRINH_HANG_MUC == gd_kh.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN).ToList().Count < 1)
				//	{

				//	}
				//}
			}
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			//InsertDataDuToanToQuyetToan(Person.get_id_don_vi(),"2014");
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				lst_pl04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
						   .Where(x => x.ID_DON_VI == 145 && x.NAM == 2014)
						   .ToList();
				lst_loai_nhiem_vu = db.CM_DM_TU_DIEN
							.Where(x => x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU)
							.OrderBy(x=>x.GHI_CHU)
							.Select(x => new ItemLNV { Ten = x.GHI_CHU + " - " + x.TEN, Value = x.TEN })
							.ToList();
			}
		}
		#endregion

	}
}