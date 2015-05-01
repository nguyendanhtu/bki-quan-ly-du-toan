using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core.IPException;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System.Data;
using SQLDataAccess;
using System.Web.Script.Serialization;
using Framework.Extensions;

namespace QuanLyDuToan.DuToan
{
	public partial class F404_nhap_khoi_luong : System.Web.UI.Page
	{
		#region Members
		public List<GD_KHOI_LUONG> m_lst_gd;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		public string m_str_nguon = "N";
		public decimal m_dc_id_don_vi;
		#endregion

		#region Data Structures
		
		#endregion

		#region Private Methods

		#endregion

		#region Events

		#endregion

		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			DateTime v_dat_ngay_nhap = new DateTime(2015, 04, 18);
			//m_lst_gd = db.GD_KHOI_LUONG.Where(x => x.ID_DON_VI == 263
			//	&& x.NGAY_THANG == v_dat_ngay_nhap).ToList();
			load_data_to_lst_don_vi(db);
			m_str_nguon = WebformFunctions.getValue_from_query_string<string>(
								this
								, FormInfo.QueryString.NGUON_NGAN_SACH
								, STR_NGUON.QUY_BAO_TRI
								);
			m_dc_id_don_vi = Person.get_id_don_vi();
			//load_data_to_grid_by_nguon(m_str_nguon, 263, v_dat_ngay_nhap, db);
		}
		
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(v_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}

		
	}
}