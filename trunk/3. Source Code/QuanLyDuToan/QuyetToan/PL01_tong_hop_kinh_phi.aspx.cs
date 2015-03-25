using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL01_tong_hop_kinh_phi : System.Web.UI.Page
	{
		#region Public Function
		
		#endregion

		#region Data Structures
		
		#endregion

		#region Members
		public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_pl01;
		#endregion

		#region Private Methods
		
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				lst_pl01 = new BKI_QLDTEntities().GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
					.Where(x => x.NAM == 2014).ToList();
			}
		}
		#endregion

		
	}
}