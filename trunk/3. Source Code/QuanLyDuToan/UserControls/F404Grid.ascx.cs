using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using Framework.Extensions;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.UserControls
{
	public partial class F404Grid : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		public List<GD_KHOI_LUONG> m_lst_gd;
		
		public static string RenderToString(List<GD_KHOI_LUONG> ip_lst_gd)
		{
			return UIUtil.RenderUserControl<F404Grid>("~/UserControls/F404Grid.ascx",
				uc =>
				{
					uc.m_lst_gd = ip_lst_gd;
				});
		}
	}
}