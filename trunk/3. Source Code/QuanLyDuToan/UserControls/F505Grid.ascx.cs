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
	public partial class F505Grid : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		#region Members
		public List<GD_DU_TOAN_THU_CHI_PHI_PHA> m_lst_du_toan_thu_chi_phi_pha;
		#endregion

		public static string RenderToString(List<GD_DU_TOAN_THU_CHI_PHI_PHA> ip_lst_gd)
		{
			return UIUtil.RenderUserControl<F505Grid>("~/UserControls/F505Grid.ascx",
				uc =>
				{
					uc.m_lst_du_toan_thu_chi_phi_pha = ip_lst_gd;
				});
		}
	}
}