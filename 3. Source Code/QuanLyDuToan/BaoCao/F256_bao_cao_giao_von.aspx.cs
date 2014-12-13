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
using IP.Core.IPCommon;

namespace QuanLyDuToan.BaoCao
{
    public partial class F256_bao_cao_giao_von : System.Web.UI.Page
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
                dt.Columns.Add("TONG_KH", typeof(decimal));
                dt.Columns.Add("TONG_VON_QBT", typeof(decimal));
                dt.Columns.Add("TONG_VON_NS", typeof(decimal));
                dt.Columns.Add("TONG_VON", typeof(decimal));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = "Chi sửa quốc lộ 31";
            NewRow[1] = 3000000000;
            NewRow[2] = 1000000000;
            NewRow[3] = 1000000000;
            NewRow[4] = 2000000000;
            dt.Rows.Add(NewRow);
            m_grv_bao_cao_giao_von.DataSource = dt;
            m_grv_bao_cao_giao_von.DataBind();
            //-------------------------------------------------------
            #endregion
            set_default_input();
            //load_data_2_grid();
        }

        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }

        private void load_data_2_grid()
        {
            US_RPT_BAO_CAO_GIAO_VON v_us = new US_RPT_BAO_CAO_GIAO_VON();
            DS_RPT_BAO_CAO_GIAO_VON v_ds = new DS_RPT_BAO_CAO_GIAO_VON();
            v_us.bc_giao_von_theo_don_vi(
                v_ds,
                1,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                m_txt_tu_khoa_tim_kiem.Text
            );
            m_grv_bao_cao_giao_von.DataSource = v_ds.RPT_BAO_CAO_GIAO_VON;
            m_grv_bao_cao_giao_von.DataBind();
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
        }
    }
}