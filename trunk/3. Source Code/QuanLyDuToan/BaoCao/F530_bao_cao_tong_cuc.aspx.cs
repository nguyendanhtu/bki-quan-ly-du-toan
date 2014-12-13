using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using QuanLyDuToan.App_Code;
using System.Data;


namespace QuanLyDuToan.BaoCao
{
    public partial class F530_bao_cao_tong_cuc : System.Web.UI.Page
    {
       
        #region Data Member
        decimal m_dc_id_loai_don_vi = 0;
        DateTime m_dat_tu_ngay;
        DateTime m_dat_den_ngay;
        #endregion

        #region Private Method
        private void load_data_to_cbo_loai_don_vi()
        {
            DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
            US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
            v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(
                MA_LOAI_TU_DIEN.LOAI_DON_VI
                , v_ds_cm_dm_tu_dien);
            m_cbo_loai_don_vi.Items.Add(new ListItem("Tất cả", "0"));
            m_cbo_loai_don_vi.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
            m_cbo_loai_don_vi.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loai_don_vi.DataTextField = CM_DM_TU_DIEN.TEN;
            m_cbo_loai_don_vi.DataBind();
            m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(m_dc_id_loai_don_vi);
        }

        public decimal format_so_tien(object ip_str_so_tien)
        {
            decimal op_dc_so_tien = 0;
            if (ip_str_so_tien == DBNull.Value)
            {
                op_dc_so_tien = 0;
            }
            else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
            return op_dc_so_tien;
        }
       

        private void load_data_to_grid()
        {
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.bc_tinh_hinh_giai_ngan_tong_cuc(v_ds
                , CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
                , CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
                , Person.get_user_id()
                );
            m_grv.DataSource = v_ds.RPT_BC_TINH_HINH_GIAI_NGAN;
            m_grv.DataBind();

        }
        private bool check_validate_data_is_ok()
        {
            if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
            {
                m_lbl_mess.Text = "Bạn phải nhập Từ ngày, dạng dd/MM/yyyy";
                m_txt_tu_ngay.Focus();
                return false;
            }
            if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
            {
                m_lbl_mess.Text = "Bạn phải nhập Đến ngày, dạng dd/MM/yyyy";
                m_txt_den_ngay.Focus();
                return false;
            }

            return true;
        }

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime v_dat_now = DateTime.Now;
                DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
                v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                if (Request.QueryString["don_vi"] != null)
                {
                    m_dc_id_loai_don_vi = CIPConvert.ToDecimal(Request.QueryString["loai_don_vi"]);                    
                }
                if (Request.QueryString["tu_ngay"] != null)
                    m_dat_tu_ngay = CIPConvert.ToDatetime(Request.QueryString["tu_ngay"]);
                if (Request.QueryString["den_ngay"] != null)
                    m_dat_den_ngay = CIPConvert.ToDatetime(Request.QueryString["den_ngay"]);
                load_data_to_cbo_loai_don_vi();
                load_data_to_grid();
            }
        }
        
        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
        {
            try
            {
                if (check_validate_data_is_ok())
                {
                    load_data_to_grid();
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
        #endregion
    }
}