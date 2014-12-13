using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS.CDBNames;
using WebDS;
using WebUS;
using IP.Core.IPCommon;
namespace QuanLyDuToan.DanhMuc
{
	public partial class f604_dm_quyet_dinh : System.Web.UI.Page
	{
		private void load_data_to_grid()
		{
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
			v_us.FillDataset(v_ds, "order by ngay_thang desc");
			m_grv.DataSource = v_ds.DM_QUYET_DINH;
			m_grv.DataBind();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				load_data_to_grid();
			}
		}
	}
}