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
using System.Data;
public partial class DuToan_f603_dm_du_an : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_to_cbo_don_vi();
            load_data_to_grid();
        }
        

    }

    private void load_data_to_grid()
    {
        DataSet v_ds = new DataSet();
        DataTable v_dt = new DataTable();
        v_dt.Columns.Add("ten_don_vi");
        v_dt.Columns.Add("ten_du_an");
        v_dt.Columns.Add("thoi_han");
        v_dt.Columns.Add("ghi_chu");
        for (int i = 0; i < 3; i++)
        {
            DataRow v_dr = v_dt.NewRow();
            v_dr["ten_don_vi"] = m_cbo_don_vi.Items[m_cbo_don_vi.SelectedIndex].Text;
            v_dr["ten_du_an"] = "Xây cầu xyz";
            v_dr["thoi_han"] = "12/2016";
            v_dr["ghi_chu"] = "Xây cầu xyz";
            v_dt.Rows.Add(v_dr);
        }
        v_ds.Tables.Add(v_dt);
        v_ds.AcceptChanges();
        m_grv.DataSource = v_ds;
        m_grv.DataBind();
        
    }
    private void load_data_to_cbo_don_vi()
    {
        US_DM_DON_VI v_us = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
        v_us.FillDataset(v_ds, "order by ten_don_vi");
        m_cbo_don_vi.DataTextField = DM_DON_VI.TEN_DON_VI;
        m_cbo_don_vi.DataValueField = DM_DON_VI.ID;
        m_cbo_don_vi.DataSource = v_ds.DM_DON_VI;
        m_cbo_don_vi.DataBind();
    }
    protected void m_cbo_don_vi_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_to_grid();
    }
}