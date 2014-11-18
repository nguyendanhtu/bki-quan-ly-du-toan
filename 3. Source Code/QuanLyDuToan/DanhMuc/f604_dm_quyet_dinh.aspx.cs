using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS.CDBNames;
using WebDS;
using WebUS;
using IP.Core.IPCommon;

public partial class DanhMuc_f604_dm_quyet_dinh : System.Web.UI.Page
{
    private void load_data_to_grid()
    {
        US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH();
        DS_GD_QUYET_DINH v_ds = new DS_GD_QUYET_DINH();
        v_us.FillDataset(v_ds,"order by ngay_thang desc");
        m_grv.DataSource = v_ds.GD_QUYET_DINH;
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