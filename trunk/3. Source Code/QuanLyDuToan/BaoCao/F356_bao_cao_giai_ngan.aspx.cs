using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}