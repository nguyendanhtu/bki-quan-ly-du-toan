using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;
using System.Data;
using IP.Core.IPUserService;
using IP.Core.IPData;



namespace QuanLyDuToan.DanhMuc
{
    public partial class F390_Danh_sach_uy_nhiem_chi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    if (Request.QueryString["ip_dat_tu_ngay"] != null)
                    {
                        m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_tu_ngay.Text = CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(DateTime.Now), "dd/MM/yyyy");
                    }
                    if (Request.QueryString["ip_dat_den_ngay"] != null)
                    {
                        m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
                    }
                    WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
                    load_data_to_grid();
                }
            }
            catch (Exception v_e)
            {
                this.Response.Write(v_e.ToString());
            }
        }
        #region Members
        
        #endregion
        #region Private Methods
        private void set_inital_form_mode()
        {
            
        }
        private bool check_validate_is_ok()
        {

            return true;
        }
        private void load_data_to_grid()
        {
          
            if (!check_validate_is_ok()) return;

            DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
            DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy");
            US_V_DM_GIAI_NGAN v_us = new US_V_DM_GIAI_NGAN();
            DS_V_DM_GIAI_NGAN v_ds = new DS_V_DM_GIAI_NGAN();
            v_ds.EnforceConstraints = false;
            v_us.FillDatasetByProc(
                v_ds,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
                m_txt_tu_khoa_tim_kiem.Text
                );
            m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_GIAI_NGAN;
            m_grv_bao_cao_giao_von.DataBind();

        }
        #endregion
        //
        //Events
        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
        protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
    }
} 