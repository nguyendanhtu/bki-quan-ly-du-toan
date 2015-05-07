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
	public partial class QT_QBT_GRID_PL04 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04;
		public List<GD_CHI_TIET_GIAO_KH> lst_giao_kh;

		public static string RenderToString(
			List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_pl04
			,List<GD_CHI_TIET_GIAO_KH> lst_giao_kh
			)
		{
			return UIUtil.RenderUserControl<QT_QBT_GRID_PL04>("~/UserControls/QT_QBT_GRID_PL04.ascx",
				uc =>
				{
					uc.lst_pl04 = lst_pl04;
					uc.lst_giao_kh = lst_giao_kh;
				});
		}
	}
}