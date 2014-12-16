using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.DanhMuc
{
	public partial class test : System.Web.UI.Page
	{
		#region Public Interfaces

		#endregion

		#region Data Structures

		#endregion

		#region Members

		#endregion

		#region Private Methods
		private void load_data_to_ddl_ten_don_vi()
		{
			US_DM_DON_VI v_us_don_vi = new US_DM_DON_VI();
			DS_DM_DON_VI v_ds_don_vi = new DS_DM_DON_VI();

			v_us_don_vi.FillDataset(v_ds_don_vi);
			m_ddl_ten_don_vi.DataTextField = DM_DON_VI.TEN_DON_VI;
			m_ddl_ten_don_vi.DataValueField = DM_DON_VI.ID;
			m_ddl_ten_don_vi.DataSource = v_ds_don_vi.DM_DON_VI;
			m_ddl_ten_don_vi.DataBind();
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{

		}
		#endregion
		
	}
}