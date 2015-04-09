using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using SQLDataAccess;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL05_DanhMucGiaTriCongTrinhHoanThanhGiamTruThanhToan : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			load_danh_sach_cong_trinh(db, 241, 2014);

		}

		#region Members
		public List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04;
		public List<GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN> lst_pl05;

		#endregion

		#region Private Methods
		private void load_danh_sach_cong_trinh(
						BKI_QLDTEntities ip_db
						, decimal ip_dc_id_don_vi
						, decimal ip_dc_nam
						)
		{
			lst_pl04 = ip_db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
					.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
							&& x.NAM == ip_dc_nam)
					.ToList();
			lst_pl05=ip_db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN
					.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
							&& x.NAM == ip_dc_nam)
					.ToList();
		}

		#endregion
	}
}