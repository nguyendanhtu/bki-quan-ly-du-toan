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
            //#region dữ liệu demo, khi nào code thì xóa đi
            ////-------------------------------------------------------
            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn();

            //if (dt.Columns.Count == 0)
            //{
            //    dt.Columns.Add("NHIEM_VU_CHI", typeof(string));
            //    dt.Columns.Add("TONG_SO_KE_HOACH", typeof(string));
            //    dt.Columns.Add("SO_TIEN_QUY_BT", typeof(string));
            //    dt.Columns.Add("SO_TIEN_NS", typeof(string));
            //    dt.Columns.Add("TONG", typeof(string));
            //}

            //DataRow NewRow = dt.NewRow();
            //NewRow[0] = "Chi sửa quốc lộ 31";
            //NewRow[1] = "3,000,000,000";
            //NewRow[2] = "1,000,000,000";
            //NewRow[3] = "1,000,000,000";
            //NewRow[4] = "2,000,000,000";
            //dt.Rows.Add(NewRow); 
            //m_grv_bao_cao_giao_von.DataSource = dt;
            //m_grv_bao_cao_giao_von.DataBind();
            ////-------------------------------------------------------
            //#endregion
            set_default_input();
            load_data_2_grid();
        }

        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToShortDateString();
            m_txt_tu_ngay.Text = (DateTime.Now.Date).ToShortDateString();
        }

        private void load_data_2_grid()
        {
            US_RPT_BAO_CAO_GIAO_VON v_us = new US_RPT_BAO_CAO_GIAO_VON();
            DS_RPT_BAO_CAO_GIAO_VON v_ds = new DS_RPT_BAO_CAO_GIAO_VON();
            v_us.bc_giao_von_theo_don_vi(
                v_ds,
                1,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text,"dd/MM/yyyy"),
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text,"dd/MM/yyyy"),
                m_txt_tu_khoa_tim_kiem.Text
            );
            m_grv_bao_cao_giao_von.DataSource = v_ds.RPT_BAO_CAO_GIAO_VON;
            m_grv_bao_cao_giao_von.DataBind();
        }
    }
}