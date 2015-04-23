using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using QuanLyDuToan.App_Code;
using WebUS;

namespace QuanLyDuToan.DuToan
{
	public partial class F505_DuToanThuChiPhiPha : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				set_initial_form_load();
				m_dc_id_don_vi = Person.get_id_don_vi();
			}
		}

		#region Public Methods

		#endregion

		#region Members

		public List<GD_DU_TOAN_THU_CHI_PHI_PHA> m_lst_du_toan_thu_chi_phi_pha;
		public List<DM_QUYET_DINH> m_lst_quyet_dinh;
		public decimal m_dc_id_don_vi;

		#endregion

		#region Private Methods
		private void set_initial_form_load()
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			decimal v_dc_nam = 2015;
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			load_data_to_lst_du_toan_thu_chi_phi_pha(db, v_dc_id_don_vi, v_dc_nam);
			load_data_to_lst_quyet_dinh(db, v_dc_id_don_vi, (int)v_dc_nam);
		}
		private void load_data_to_lst_du_toan_thu_chi_phi_pha(
			BKI_QLDTEntities ip_db
			, decimal ip_dc_id_don_vi
			, decimal ip_dc_nam
			)
		{
			m_lst_du_toan_thu_chi_phi_pha = ip_db.GD_DU_TOAN_THU_CHI_PHI_PHA
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_dc_nam)
											.OrderBy(x => x.MA_SO)
											.ToList();
											
		}

		private void load_data_to_lst_quyet_dinh(
			BKI_QLDTEntities ip_db
			, decimal ip_dc_id_don_vi
			, int ip_dc_nam
			)
		{
			DateTime v_dat_dau_nam = new DateTime(ip_dc_nam, 1, 1);
			DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(v_dat_dau_nam);
			m_lst_quyet_dinh = ip_db.DM_QUYET_DINH
									.Where(x => x.NGAY_THANG>=v_dat_dau_nam&&x.NGAY_THANG<=v_dat_cuoi_nam)
									.OrderBy(x => x.NGAY_THANG)
									.ToList();
		}
		#endregion

		#region Data Structures

		#endregion

		#region Events

		#endregion
	}
}