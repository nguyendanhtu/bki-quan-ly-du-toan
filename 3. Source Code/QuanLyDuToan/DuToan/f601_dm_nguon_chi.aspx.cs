using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPUserService;
using IP.Core.IPData;

public partial class DuToan_f601_dm_nguon_chi : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        load_data_to_grid();
    }

    private void load_data_to_grid()
    {
        US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
        DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
        v_us.FillDataset(v_ds, "where id_loai_tu_dien=100 order by ten");
        m_grv.DataSource = v_ds.CM_DM_TU_DIEN;
        m_grv.DataBind();
    }
}