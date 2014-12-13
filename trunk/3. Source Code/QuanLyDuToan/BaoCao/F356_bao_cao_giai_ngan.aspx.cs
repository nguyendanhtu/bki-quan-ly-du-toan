using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;

namespace QuanLyDuToan.BaoCao
{
    public partial class F356_bao_cao_giai_ngan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region dữ liệu demo, khi nào code thì xóa đi
            //-------------------------------------------------------
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("NHIEM_VU_CHI", typeof(string));
                dt.Columns.Add("TONG_SO_KE_HOACH", typeof(string));
                dt.Columns.Add("TONG_SO_VON_GIAO", typeof(string));
                dt.Columns.Add("SO_TIEN_QUY_BT", typeof(string));
                dt.Columns.Add("SO_TIEN_NS", typeof(string));
                dt.Columns.Add("TONG", typeof(string));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = "Chi sửa quốc lộ 31";
            NewRow[1] = "3,000,000,000";
            NewRow[2] = "2,500,000,000";
            NewRow[3] = "1,000,000,000";
            NewRow[4] = "1,000,000,000";
            NewRow[5] = "2,000,000,000";
            dt.Rows.Add(NewRow);
            m_grv_bao_cao_giai_ngan.DataSource = dt;
            m_grv_bao_cao_giai_ngan.DataBind();
            //-------------------------------------------------------
            #endregion

            //load_data_2_grid();
        }

        private void load_data_2_grid()
        {
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.FillDataset(v_ds);
            m_grv_bao_cao_giai_ngan.DataSource = v_ds.RPT_BC_TINH_HINH_GIAI_NGAN;
            m_grv_bao_cao_giai_ngan.DataBind();
        }
    }
}