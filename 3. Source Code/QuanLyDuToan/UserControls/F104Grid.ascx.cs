using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.UserControls
{
	public partial class F104Grid : System.Web.UI.UserControl
	{
		public List<GD_CHI_TIET_GIAO_KH> m_lst_gd;
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		public static string RenderToString(List<GD_CHI_TIET_GIAO_KH> ip_lst_gd)
		{
			return UIUtil.RenderUserControl<F104Grid>("~/UserControls/F104Grid.ascx",
				uc =>
				{
					uc.m_lst_gd = ip_lst_gd;
				});
		}
	}
}