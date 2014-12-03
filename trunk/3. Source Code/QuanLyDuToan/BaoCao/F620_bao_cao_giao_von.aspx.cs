using System;
using System.Collections.Generic;
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
    public partial class F620_bao_cao_giao_von : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            set_init();
            load_data_2_grid(m_txt_tu_ngay.Text,m_txt_den_ngay.Text,m_txt_so_quyet_dinh.Text);
        }

        private void set_init()
        {
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToShortDateString();
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToShortDateString();
        }

        private void load_data_2_grid(string ip_date_start, string ip_date_end, string ip_so_quyet_dinh)
        {
            US_V_RPT_GD_GIAO_VON v_us = new US_V_RPT_GD_GIAO_VON();
            DS_V_RPT_GD_GIAO_VON v_ds = new DS_V_RPT_GD_GIAO_VON();
            v_us.FillDataset(v_ds, "where SO_QUYET_DINH like '%"+ip_so_quyet_dinh+"%'");//, "where ngay_thang > " + CIPConvert.ToDatetime(m_txt_tu_ngay.Text) + "and ngay_thang < " + CIPConvert.ToDatetime(m_txt_den_ngay.Text));
            m_grv.DataSource = v_ds.V_RPT_GD_GIAO_VON;
            m_grv.DataBind();
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            load_data_2_grid(m_txt_tu_ngay.Text, m_txt_den_ngay.Text, m_txt_so_quyet_dinh.Text);
        }
    }
}