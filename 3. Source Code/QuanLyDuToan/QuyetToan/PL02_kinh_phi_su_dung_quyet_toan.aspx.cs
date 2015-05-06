using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using Framework.Extensions;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL02_kinh_phi_su_dung_quyet_toan : System.Web.UI.Page
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
			public decimal? IdLoai;
			public string MaSoParent;
		}
		#endregion

		#region Members
		public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
		public List<ItemCLKM> lst_clkm;
		public List<string> lst_NDC = new List<string>();
		public decimal m_dc_id_don_vi;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;

		#endregion

		#region Private Methods

		private void load_data_to_lst_clkm(BKI_QLDTEntities ip)
		{
			lst_clkm = ip
					   .DM_CHUONG_LOAI_KHOAN_MUC
					   .Select(x => new
					   ItemCLKM
					   {
						   MaSo = x.MA_SO
						   ,
						   Ten = x.TEN
						   ,
						   IdLoai = x.ID_LOAI
						   ,
						   MaSoParent = x.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
					   })
					   .ToList();

		}

		private void load_data_to_lst_noi_dung_chi()
		{
			lst_NDC = new List<string>();
			lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
			lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
		}

		private void load_data_to_lst_pl02(BKI_QLDTEntities ip_db)
		{
			lst_pl02 = ip_db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
							.Where(x => x.ID_DON_VI == 145 && x.NAM == 2014)
							.ToList();
		}
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db, decimal ip_dc_id_don_vi)
		{
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(ip_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			load_data_to_lst_noi_dung_chi();
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			load_data_to_lst_don_vi(db, Person.get_id_don_vi());
			load_data_to_lst_clkm(db);
		}

		#endregion
	}
}