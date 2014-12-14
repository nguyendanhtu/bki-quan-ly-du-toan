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

namespace QuanLyDuToan.DanhMuc
{
    public partial class F290_Danh_sach_quyet_dinh_giao_von : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                set_default_input();
                load_data_2_grid();    
            }            
        }

        private void load_data_2_grid()
        {
            US_V_DM_QUYET_DINH v_us = new US_V_DM_QUYET_DINH();
            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            v_ds.EnforceConstraints = false;
            v_us.FillDatasetByIdLoaiQuyetDinh(
                v_ds, 
                ID_LOAI_QUYET_DINH.GIAO_VON,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                m_txt_tu_khoa_tim_kiem.Text
                );
            m_grv.DataSource = v_ds.V_DM_QUYET_DINH;
            m_grv.DataBind();
        }
        
        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
        }
    }
}