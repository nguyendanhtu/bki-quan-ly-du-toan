using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using IP.Core.IPException;
using IP.Core.IPCommon;
using WebUS;


namespace QuanLyDuToan.DanhMuc
{
	public partial class F003_DanhMucChuongLoaiKhoanMucTieuMuc : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					set_initial_form_load();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		#region Members
		public List<V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC> lst_clkm;
		BKI_QLDTEntities db = new BKI_QLDTEntities();
		#endregion

		#region Private Methods
		private void set_initial_form_load()
		{
			load_data_to_list_clkm();
		}

		private void load_data_to_list_clkm()
		{
			lst_clkm = db.V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.ToList();
		}

		private void load_data_to_cbo_loai_chuong_loai_khoan_muc()
		{
			//List<CM_DM_TU_DIEN> lst_loai_clkm=db.CM_DM_TU_DIEN.Where(
		}


		#endregion
	}
}