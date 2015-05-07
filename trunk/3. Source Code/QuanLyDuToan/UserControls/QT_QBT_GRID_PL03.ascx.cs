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
	public partial class QT_QBT_GRID_PL03 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_pl03;

		public static string RenderToString(List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_pl03
			)
		{
			return UIUtil.RenderUserControl<QT_QBT_GRID_PL03>("~/UserControls/QT_QBT_GRID_PL03.ascx",
				uc =>
				{
					uc.lst_pl03 = lst_pl03;
				});
		}
	}
}