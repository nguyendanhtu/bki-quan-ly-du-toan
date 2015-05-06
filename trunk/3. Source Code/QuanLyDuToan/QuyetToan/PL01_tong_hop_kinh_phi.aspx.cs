using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using WebUS;
using System.Web.Services;
using WebDS;
using Framework.Extensions;
using QuanLyDuToan.App_Code;

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
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		#endregion

		#region Private Methods
		
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				BKI_QLDTEntities db = new BKI_QLDTEntities();
				load_data_to_lst_don_vi(db,245);
				load_data_to_lst_loai(db);
				load_data_to_lst_pl01(db, 245, 2014);
				load_data_to_lst_don_vi(db, Person.get_id_don_vi());
				
			}
		}
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db, decimal ip_dc_id_don_vi)
		{
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(ip_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}
		private void load_data_to_lst_loai(BKI_QLDTEntities ip_db)
		{
			lst_loai = ip_db.DM_CHUONG_LOAI_KHOAN_MUC
					.Where(x => x.ID_LOAI == ID_CHUONG_LOAI_KHOAN_MUC.LOAI)
					.Select(x => new ItemCLKM { MaSo = x.MA_SO, Ten = x.TEN })
					.ToList();
		}
		private void load_data_to_lst_pl01(BKI_QLDTEntities ip_db
			, decimal ip_dc_id_don_vi
			, int ip_dc_nam)
		{
			lst_pl01 = ip_db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
					.Where(x => x.NAM == ip_dc_nam && x.ID_DON_VI == ip_dc_id_don_vi).ToList();
		}
		#endregion

		
	}
}