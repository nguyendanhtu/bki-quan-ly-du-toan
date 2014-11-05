using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using System.Threading;

public partial class DanhMuc_Dictionary : System.Web.UI.Page
{
    #region Members
    US_CM_DM_TU_DIEN m_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
    DS_CM_DM_TU_DIEN m_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
    private DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Data Structures

    #endregion

    #region Private Methods
    private void set_form_mode() {
        switch (m_e_form_mode) {
            case DataEntryFormMode.InsertDataState:
                m_cmd_tao_moi.Visible = true;
                m_cmd_cap_nhat.Visible = false;
                break;
            case DataEntryFormMode.SelectDataState:
                break;
            case DataEntryFormMode.UpdateDataState:
                m_cmd_tao_moi.Visible = false;
                m_cmd_cap_nhat.Visible = true;
                break;
            case DataEntryFormMode.ViewDataState:
                break;
            default:
                break;
        }
    }

    
    private void load_data_2_grid()
    {
            m_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(CIPConvert.ToStr(m_cbo_loai_tu_dien_grv.SelectedValue), m_ds_dm_tu_dien);
            m_grv_dm_tu_dien.DataSource = m_ds_dm_tu_dien.CM_DM_TU_DIEN;
            m_grv_dm_tu_dien.DataBind();
            if (m_ds_dm_tu_dien.CM_DM_TU_DIEN.Rows.Count == 0)
            {
                m_lbl_thong_bao.Text = "Chưa có từ điển cho lọai từ điển này";
                m_lbl_thong_bao.Visible = true;
            }
            else m_lbl_thong_bao.Visible = false;
    }
    private void load_cbo_loai_tu_dien()
    {
            US_CM_DM_LOAI_TD v_us_loai_tu_dien = new US_CM_DM_LOAI_TD();
            DS_CM_DM_LOAI_TD v_ds_loai_tu_dien = new DS_CM_DM_LOAI_TD();
            v_us_loai_tu_dien.FillDataset(v_ds_loai_tu_dien);
            m_cbo_loai_tu_dien.DataSource = v_ds_loai_tu_dien.CM_DM_LOAI_TD;
            m_cbo_loai_tu_dien.DataTextField = CM_DM_LOAI_TD.TEN_LOAI;
            m_cbo_loai_tu_dien.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_loai_tu_dien.DataBind();
    }
    private void load_cbo_loai_tu_dien_grv()
    {
            US_CM_DM_LOAI_TD v_us_loai_tu_dien = new US_CM_DM_LOAI_TD();
            DS_CM_DM_LOAI_TD v_ds_loai_tu_dien = new DS_CM_DM_LOAI_TD();
            v_us_loai_tu_dien.FillDataset(v_ds_loai_tu_dien);
            m_cbo_loai_tu_dien_grv.DataSource = v_ds_loai_tu_dien.CM_DM_LOAI_TD;
            m_cbo_loai_tu_dien_grv.DataTextField = CM_DM_LOAI_TD.TEN_LOAI;
            m_cbo_loai_tu_dien_grv.DataValueField = CM_DM_LOAI_TD.MA_LOAI;
            m_cbo_loai_tu_dien_grv.DataBind();
    }
    private void delete_dm_tu_dien(int i_int_row_index) {
            decimal v_dc_id_dm_tu_dien = CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i_int_row_index].Value);
            m_us_dm_tu_dien.DeleteByID(v_dc_id_dm_tu_dien);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
    }
    private void load_update_dm_tu_dien(int i_int_row_index)
    {
            decimal v_dc_id_dm_tu_dien = CIPConvert.ToDecimal(m_grv_dm_tu_dien.DataKeys[i_int_row_index].Value);
            US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN(v_dc_id_dm_tu_dien);
            m_hdf_id_dm_tu_dien.Value = CIPConvert.ToStr(v_dc_id_dm_tu_dien);
            us_object_2_form(v_us_dm_tu_dien);
    }
    private void reset_control_in_form()
    {
        
            m_lbl_mess.Text = "";
            m_grv_dm_tu_dien.EditIndex = -1;
            m_txt_ma_tu_dien.Text = "";
            m_txt_ten.Text = "";
            m_txt_ten_ngan.Text = "";
            m_txt_ghi_chu.Text = "";
            this.m_hdf_id_dm_tu_dien.Value = "";
       
    }
    private bool check_validate_is_ok() {
        if (this.m_cbo_loai_tu_dien.SelectedItem ==null)
        {
            this.m_ctv_ma_tu_dien.IsValid = false;
            return false;
        }
        if (this.m_txt_ma_tu_dien.Text.Trim().Equals(""))
        {
            this.m_ctv_ma_tu_dien.IsValid = false;
            return false;
        }
        if (this.m_txt_ten_ngan.Text.Trim().Equals(""))
        {
            this.m_ctv_ten_tu_ngan.IsValid = false;
            return false;
        }
        if (this.m_txt_ten.Text.Trim().Equals(""))
        {
            this.m_ctv_ten.IsValid = false;
            return false;
        }
        if ((m_e_form_mode == DataEntryFormMode.InsertDataState)&&(!check_ma_tu_dien_is_valided_for_insert())) { 
            m_lbl_mess.Text = "Mã từ điển này đã tồn tại, nhập mã khác!"; 
            return false; 
        }
        if ((m_e_form_mode  == DataEntryFormMode.UpdateDataState)&&(this.m_hdf_id_dm_tu_dien.Value == "")) { 
            m_lbl_mess.Text = "Bạn phải chọn Từ điển cần Cập nhật!"; 
            return false; 
        }
        return true;
    }
    private bool check_ma_tu_dien_is_valided_for_insert() {
       
             if(m_us_dm_tu_dien.check_exist_ma_tu_dien(m_txt_ma_tu_dien.Text.TrimEnd())) return false;
             return true;
        
    }
    private void insert_dm_tu_dien()
    {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            m_lbl_mess.Text = "";
            m_grv_dm_tu_dien.EditIndex = -1;
            if (Page.IsValid) {
                if (!check_validate_is_ok()) return;
                
                form_2_us_object();
                m_us_dm_tu_dien.Insert();
                
                reset_control_in_form();
                set_form_mode();
                m_lbl_mess.Text = "Đã thêm mới thành công!";
                load_data_2_grid();
            }
    }
    private void update_dm_tu_dien()
    {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_lbl_mess.Text = "";
            m_grv_dm_tu_dien.EditIndex = -1;
            if (Page.IsValid)
            {
                
                if (!check_validate_is_ok()) return;
                form_2_us_object();
                m_us_dm_tu_dien.dcID = CIPConvert.ToDecimal(this.m_hdf_id_dm_tu_dien.Value);
                m_us_dm_tu_dien.Update();
                
                reset_control_in_form();
                m_lbl_mess.Text = "Đã cập nhật bản ghi thành công!";
                m_e_form_mode = DataEntryFormMode.InsertDataState;
                set_form_mode();
                m_grv_dm_tu_dien.EditIndex = -1;
                load_data_2_grid();
            }
    }
    private void us_object_2_form(US_CM_DM_TU_DIEN i_us_dm_tu_dien) {
        m_cbo_loai_tu_dien.SelectedValue = CIPConvert.ToStr(i_us_dm_tu_dien.dcID_LOAI_TU_DIEN);
        m_txt_ma_tu_dien.Text = i_us_dm_tu_dien.strMA_TU_DIEN;
        m_txt_ten.Text = i_us_dm_tu_dien.strTEN;
        m_txt_ten_ngan.Text = i_us_dm_tu_dien.strTEN_NGAN;
        m_txt_ghi_chu.Text = i_us_dm_tu_dien.strGHI_CHU;
    }
    private void form_2_us_object() {
        m_us_dm_tu_dien.dcID_LOAI_TU_DIEN = CIPConvert.ToDecimal(m_cbo_loai_tu_dien.SelectedValue);
        m_us_dm_tu_dien.strMA_TU_DIEN = m_txt_ma_tu_dien.Text.TrimEnd();
        m_us_dm_tu_dien.strTEN = m_txt_ten.Text.TrimEnd();
        m_us_dm_tu_dien.strTEN_NGAN = m_txt_ten_ngan.Text.TrimEnd();
        m_us_dm_tu_dien.strGHI_CHU = m_txt_ghi_chu.Text.TrimEnd();
    }
    private decimal get_id_from_ma(string ip_str_ma)
    {
        US_CM_DM_LOAI_TD v_us_cm_loai_tu_dien = new US_CM_DM_LOAI_TD(ip_str_ma);
        return v_us_cm_loai_tu_dien.dcID;
    }
    #endregion

    //
    //
    // events
    //
    //
    protected void Page_Load(object sender, EventArgs e) {
        try {
            if (!this.IsPostBack) {
                load_cbo_loai_tu_dien();
                load_cbo_loai_tu_dien_grv();
                load_data_2_grid();
                set_form_mode();
            }

        }
        catch (Exception v_e) {
            this.Response.Write(v_e.ToString());
        }

    }

    protected void m_cbo_loai_tu_dien_grv_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_cbo_loai_tu_dien.SelectedValue =CIPConvert.ToStr(get_id_from_ma(m_cbo_loai_tu_dien_grv.SelectedValue));
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_tu_dien_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            delete_dm_tu_dien(e.RowIndex);
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_tu_dien_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            m_lbl_mess.Text = "";
            load_update_dm_tu_dien(e.NewSelectedIndex);
            set_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            Thread.Sleep(2000);
            insert_dm_tu_dien();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        try
        {
            m_e_form_mode = DataEntryFormMode.InsertDataState;
            Thread.Sleep(2000);
            reset_control_in_form();
            set_form_mode();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            Thread.Sleep(2000);
            update_dm_tu_dien();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_grv_dm_tu_dien_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            load_update_dm_tu_dien(e.RowIndex);
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            us_object_2_form(m_us_dm_tu_dien);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
        
    }
}