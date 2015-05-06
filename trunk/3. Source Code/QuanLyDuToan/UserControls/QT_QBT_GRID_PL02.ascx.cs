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
	public partial class QT_QBT_GRID_PL02 : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

		#region Members
		public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
		public List<string> lst_NDC = new List<string>();
		public List<QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM> lst_clkm;
		public decimal m_dc_id_don_vi;
		#endregion

		public static string RenderToString(List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02
			, List<string> lst_NDC, List<QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM> lst_clkm)
		{
			return UIUtil.RenderUserControl<QT_QBT_GRID_PL02>("~/UserControls/QT_QBT_GRID_PL02.ascx",
				uc =>
				{
					uc.lst_pl02 = lst_pl02;
					uc.lst_NDC = lst_NDC;
					uc.lst_clkm = lst_clkm;
				});
		}
	}


}