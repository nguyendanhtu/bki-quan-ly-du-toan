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
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.BaoCao
{
    public partial class F256_bao_cao_giao_von : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            set_default_input();
            load_data_2_grid();
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
			//v_us.bc_256_giao_von_theo_don_vi(
			//	v_ds,
			//	Person.get_id_don_vi(),
			//	Person.get_user_id(),
			//	CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
			//	CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
			//	m_txt_tu_khoa_tim_kiem.Text
			//);
            m_grv_bao_cao_giao_von.DataSource = v_ds.RPT_BAO_CAO_GIAO_VON;
            m_grv_bao_cao_giao_von.DataBind();
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
        }
    }
}