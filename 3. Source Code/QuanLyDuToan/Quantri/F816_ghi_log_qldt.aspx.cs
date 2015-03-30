using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using SQLDataAccess;
using WebUS;

namespace QuanLyDuToan.Quantri
{
	public partial class F816_ghi_log_qldt : System.Web.UI.Page
	{
		public List<HT_LICH_SU_QLDT> lst_history;
		public List<HT_NGUOI_SU_DUNG> lst_nguoi_su_dung;
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
				DateTime v_dat = CCommonFunction.getDate_dau_nam_from_date(DateTime.Now.AddYears(-1));
				lst_history = db.HT_LICH_SU_QLDT
								.Where(x => x.THOI_GIAN >= v_dat)
								.OrderByDescending(x => x.THOI_GIAN)
								.ToList();
				lst_nguoi_su_dung=db.HT_NGUOI_SU_DUNG
								.ToList();
		}
	}
}