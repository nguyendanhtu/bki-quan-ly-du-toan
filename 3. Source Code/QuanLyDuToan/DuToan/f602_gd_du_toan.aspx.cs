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
public partial class DuToan_f602_gd_du_toan : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            load_data_to_grid();
        }


    }

    private void load_data_to_grid()
    {
        DataSet v_ds = new DataSet();
        DataTable v_dt = new DataTable();
        v_dt.Columns.Add("nam");
        v_dt.Columns.Add("lan");
        v_dt.Columns.Add("ma_ns");
        v_dt.Columns.Add("quyet_dinh");
        v_dt.Columns.Add("ghi_chu");
        int nam = 2015;
        for (int i = 0; i < 3; i++)
        {
            DataRow v_dr = v_dt.NewRow();
            v_dr["nam"] = (nam - i).ToString();
            v_dr["lan"] = "1";
            v_dr["ma_ns"] = "1057534";
            v_dr["quyet_dinh"] = "321/QĐ-BGTVT";
            v_dr["ghi_chu"] = "";
            v_dt.Rows.Add(v_dr);
        }
        v_ds.Tables.Add(v_dt);
        v_ds.AcceptChanges();
        m_grv.DataSource = v_ds;
        m_grv.DataBind();

    }

    protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
}