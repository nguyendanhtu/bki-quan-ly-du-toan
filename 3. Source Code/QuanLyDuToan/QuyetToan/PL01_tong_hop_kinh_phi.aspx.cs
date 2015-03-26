using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using WebUS;
using System.Web.Services;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL01_tong_hop_kinh_phi : System.Web.UI.Page
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
		public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_pl01;
		public List<ItemCLKM> lst_loai;
		#endregion

		#region Private Methods
		
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BKI_QLDTEntities db = new BKI_QLDTEntities();
				lst_pl01 = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
					.Where(x => x.NAM == 2014&&x.ID_DON_VI==145).ToList();
				lst_loai = db.DM_CHUONG_LOAI_KHOAN_MUC
					.Where(x => x.ID_LOAI == ID_CHUONG_LOAI_KHOAN_MUC.LOAI)
					.Select(x => new ItemCLKM { MaSo = x.MA_SO, Ten = x.TEN })
					.ToList();
			}
		}
		#endregion

		
	}
}