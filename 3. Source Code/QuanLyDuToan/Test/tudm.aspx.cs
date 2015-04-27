using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.Test
{
	public partial class tudm : System.Web.UI.Page
	{
		public List<GD_CHI_TIET_GIAO_KH> m_lst_gd;
		//public List<DM_CHUONG_LOAI_KHOAN_MUC> m_lst_clkm;
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_gd = db.GD_CHI_TIET_GIAO_KH
			   .Where(x => x.ID_DON_VI == 83
				   && x.ID_QUYET_DINH == 200)
			   .ToList();
			//m_lst_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.ToList();

		}
	}
}