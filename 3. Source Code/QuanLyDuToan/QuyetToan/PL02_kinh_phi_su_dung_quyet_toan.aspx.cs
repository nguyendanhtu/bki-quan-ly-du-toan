using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL02_kinh_phi_su_dung_quyet_toan : System.Web.UI.Page
	{
		#region Public Function
		public string formatClass(string className)
		{
			if (string.IsNullOrEmpty(className)) return "";
			return className.ToString().Replace('.', '_');
		}
		public string formatCongThuc(string className)
		{
			if (string.IsNullOrEmpty(className)) return "";
			return className.ToString().Replace('|', '\0');
		}

		#endregion

		#region Data Structures
		public class ItemCLKM
		{
			public string MaSo;
			public string Ten;
		}
		#endregion

		#region Members
		public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
		public List<ItemCLKM> lst_clkm;
		public List<string> lst_NDC ;
		

		#endregion

		#region Private Methods
		
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			lst_NDC = new List<string>();
			lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
			lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
							.Where(x => x.ID_DON_VI == 145 && x.NAM == 2014)
							.ToList();
				lst_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.Select(x => new ItemCLKM { MaSo = x.MA_SO, Ten = x.TEN }).ToList();
			}
		}
		#endregion
	}
}