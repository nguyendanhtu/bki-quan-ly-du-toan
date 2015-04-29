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
		public List<GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<GD_KHOI_LUONG> m_lst_khoi_luong;
		//public List<DM_CHUONG_LOAI_KHOAN_MUC> m_lst_clkm;
		protected void Page_Load(object sender, EventArgs e)
		{
			DateTime v_dat_dau_nam = new DateTime(2015, 01, 01);
			DateTime v_dat_cuoi_nam = DateTime.Now.Date;
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_gd = db.GD_CHI_TIET_GIAO_KH
			   .Where(x => x.ID_DON_VI == 83
				   && x.ID_QUYET_DINH == 200)
			   .ToList();
			//m_lst_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.ToList();

		}
	}
}