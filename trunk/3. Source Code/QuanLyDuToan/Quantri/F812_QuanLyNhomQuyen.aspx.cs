using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;

using WebUS;
using WebDS;
using WebDS.CDBNames;
using System.Data;

public partial class Quantri_F812_QuanLyNhomQuyen : System.Web.UI.Page
{

    #region Public Interfaces
    public string mapping_yn(object ip_obj_str_yn) {
        if (CIPConvert.ToStr(ip_obj_str_yn).Equals("Y")) return "Có";
        return "Không";
    }

    public string mapping_chuc_nang_parrent_by_id(object ip_dc_chuc_nang_parrent_id) {

        return "";
    }


    #endregion
   
    #region Members
    US_HT_USER_GROUP m_us_ht_user_group= new US_HT_USER_GROUP();
    DS_HT_USER_GROUP m_ds_ht_user_group = new DS_HT_USER_GROUP();
    DataEntryFormMode m_e_form_mode = DataEntryFormMode.InsertDataState;
    #endregion

    #region Private Methods
    private void set_control_by_form_mode() {
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
        m_us_ht_user_group.FillDataset(m_ds_ht_user_group
            , " where "
                + HT_USER_GROUP.USER_GROUP_NAME 
                + " like N'%"
                + m_txt_search_key.Text 
                + "%' ORDER BY ID"); 
        m_grv_dm_nhom_quyen_he_thong.DataSource = m_ds_ht_user_group.HT_USER_GROUP;
        m_grv_dm_nhom_quyen_he_thong.DataBind();
    }
    private void load_data_2_us_by_id(int ip_i_row_index)
    {
        decimal v_dc_chuc_nang_id = CIPConvert.ToDecimal(m_grv_dm_nhom_quyen_he_thong.DataKeys[ip_i_row_index].Value);
        hdf_id.Value = CIPConvert.ToStr(v_dc_chuc_nang_id);
        m_us_ht_user_group = new US_HT_USER_GROUP(v_dc_chuc_nang_id);
        m_txt_ten_nhom_quyen.Text = m_us_ht_user_group.strUSER_GROUP_NAME;
        m_txt_mo_ta.Text = m_us_ht_user_group.strDESCRIPTION;
    }
    private void delete_dm_nhom_quyen(int ip_i_row_index)
    {
        decimal v_dc_nhom_quyen_id = CIPConvert.ToDecimal(m_grv_dm_nhom_quyen_he_thong.DataKeys[ip_i_row_index].Value);
        m_us_ht_user_group.DeleteByID(v_dc_nhom_quyen_id);
    }
    private void reset_control()
    {
        m_lbl_mess.Text = "";
        m_txt_mo_ta.Text = "";
        m_txt_ten_nhom_quyen.Text = "";
        m_txt_search_key.Text = "";
    }
    private void form_2_us_obj()
    {
        m_us_ht_user_group.strUSER_GROUP_NAME = m_txt_ten_nhom_quyen.Text.Trim();
        m_us_ht_user_group.strDESCRIPTION = m_txt_mo_ta.Text.Trim();
    }
    private void us_obj_2_form()
    {

    }
    private bool check_validate_is_ok() {
        if (!CValidateTextBox.IsValid(m_txt_ten_nhom_quyen, DataType.StringType, allowNull.NO)) {
            m_lbl_mess.Text = "Bạn phải nhập tên nhóm quyền!";
            return false;
        }
        return true;
    }
    private void insert_user_group() {
        if (!check_validate_is_ok()) return;
        // thu thập dữ liệu
        form_2_us_obj();
        // Insert
        m_us_ht_user_group.Insert_nhom_nguoi_dung();
        // Reset lại control
        reset_control();
        // hiển thị lại lên lưới
        m_txt_search_key.Text = m_us_ht_user_group.strUSER_GROUP_NAME;
        load_data_2_grid();

        // thong báo
        m_lbl_mess.Text = "Thêm bản ghi thành công!";
    }
    private void update_usser_group(){
        // thu thập dữ liệu
        if (!check_validate_is_ok()) return;
        form_2_us_obj();
        m_us_ht_user_group.dcID = CIPConvert.ToDecimal(hdf_id.Value);
        // Update
        m_us_ht_user_group.Update();
        
        // Reset lại control
        reset_control();
        // hiển thị lại lên lưới
        m_txt_search_key.Text = m_us_ht_user_group.strUSER_GROUP_NAME;
        load_data_2_grid();
        
        m_e_form_mode = DataEntryFormMode.InsertDataState;
        set_control_by_form_mode();
        m_lbl_mess.Text = "Cập nhật bản ghi thành công!";
       

    }
    #endregion

    #region Events
    protected void Page_Load(object sender, EventArgs e) {
        try {
            if (!IsPostBack) {
                set_control_by_form_mode();
                reset_control();
                load_data_2_grid();
            }
        }
        catch (Exception v_e) {
            
            CSystemLog_301.ExceptionHandle(v_e);
        }
        
    }    
    protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
    {
        try
        {
            insert_user_group();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cap_nhat_Click1(object sender, EventArgs e)
    {
        try
        {
            update_usser_group();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            // Xóa nhóm quyền kèm theo xóa các phần phân quyền cho nhóm quyền đó
            delete_dm_nhom_quyen(e.RowIndex);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công!";
        }
        catch (Exception v_e)
        {
            // de su dung CsystemLog_301 bat buoc Site phai dat trong thu muc cap 1. Vi du: DanhMuc/Dictionary.aspx
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            m_grv_dm_nhom_quyen_he_thong.PageIndex = e.NewPageIndex;
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_nhom_quyen_he_thong_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        try
        {
            m_e_form_mode = DataEntryFormMode.UpdateDataState;
            set_control_by_form_mode();
            reset_control();
            load_data_2_us_by_id(e.NewSelectedIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void btnCancel_Click(object sender, EventArgs e) {
        try {
            m_e_form_mode = DataEntryFormMode.InsertDataState;

            set_control_by_form_mode();
            reset_control();
            load_data_2_grid();
        }
        catch (Exception v_e) {
            
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e) {
        try {
            load_data_2_grid();
        }
        catch (Exception v_e) {
            
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion
}
    