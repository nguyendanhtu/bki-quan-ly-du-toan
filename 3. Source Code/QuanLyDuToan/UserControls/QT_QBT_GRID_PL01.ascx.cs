using QuanLyDuToan.App_Code;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.UserControls
{
	public partial class QT_QBT_GRID_PL01 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

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

		public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_pl01;

		public static string RenderToString(List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> ip_lst_gd)
		{
			return UIUtil.RenderUserControl<QT_QBT_GRID_PL01>("~/UserControls/QT_QBT_GRID_PL01.ascx",
				uc =>
				{
					uc.lst_pl01 = ip_lst_gd;
				});
		}
		
	}
}