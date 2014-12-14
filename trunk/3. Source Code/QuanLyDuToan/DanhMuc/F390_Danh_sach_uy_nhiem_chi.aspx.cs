using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using QuanLyDuToan.App_Code;
using System.Data;
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
                    set_inital_form_mode();
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
        #endregion
        //
        //Events
        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            try
            {
                if (!check_validate_is_ok())
                    return;
                //load data to grid
                DataSet v_ds = new DataSet();
                DataTable v_dt = new DataTable();
                v_ds.Tables.Add(v_dt);
                v_ds.AcceptChanges();
                US_V_DM_GIAI_NGAN v_us = new US_V_DM_GIAI_NGAN();
                v_us.FillDatasetByProc(v_ds, m_txt_tu_ngay.Text.Trim(), m_txt_den_ngay.Text.Trim(), Person.get_id_don_vi(), m_txt_tu_khoa_tim_kiem.Text.Trim());

                m_grv_bao_cao_giao_von.DataSource = v_ds.Tables[0];
                m_grv_bao_cao_giao_von.DataBind();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
} 