using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using WebDS;
using WebUS;
using Framework.Extensions;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			//InsertFromTemplate(145, 2014);
			//load_data_to_list(Person.get_id_don_vi(), 2014, db);
			load_data_to_lst_don_vi(db, Person.get_id_don_vi()); 
		}


		#region Members
		public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_pl03;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		#endregion

		#region Private Methods
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db, decimal ip_dc_id_don_vi)
		{
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(ip_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}

		private void load_data_to_list(decimal ip_dc_id_don_vi, decimal ip_dc_nam, BKI_QLDTEntities ip_db)
		{
			lst_pl03 = ip_db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
				.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
					&& x.NAM == ip_dc_nam)
				.ToList()
				.OrderBy(x => int.Parse(x.MA_SO))
				.ToList();
		}
		
		#endregion
	}
}