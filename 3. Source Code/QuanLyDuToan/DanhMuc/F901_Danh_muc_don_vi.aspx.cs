using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using IP.Core;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using IP.Core.WinFormControls;

public partial class DanhMuc_F901_danh_muc_don_vi : System.Web.UI.Page
{
    #region public methods
    public string get_ten_loai_hinh_don_vi(string ip_str_loai_hinh_don_vi)
    {
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN(MA_LOAI_TU_DIEN.LOAI_HINH_DON_VI, ip_str_loai_hinh_don_vi);
        return v_us_cm_dm_tu_dien.strTEN;
    }
    public string get_ten_don_vi_cap_tren(object ip_obj_id_don_vi)
    {
        if (ip_obj_id_don_vi.ToString().Equals("")) return "Không có cấp trên";
        US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(ip_obj_id_don_vi));
        return v_us_dm_don_vi.strTEN_DON_VI;
    }
    #endregion

    #region Members
    US_DM_DON_VI m_us_don_vi = new US_DM_DON_VI();
    DS_DM_DON_VI m_ds_don_vi = new DS_DM_DON_VI();
    #endregion

    #region Data Struct
    public class LOAI_DON_VI
    {
        public const string BO_TINH = "BO_TINH";
        public const string DV_CHU_QUAN = "DON_VI_CHU_QUAN";
        public const string DV_SU_DUNG = "DON_VI_SU_DUNG";
    }

    public class LOAI_FORM
    {
        public const string THEM = "THEM";
        public const string SUA = "SUA";
        public const string XOA = "XOA";
    }
    #endregion

    #region Private Methods
    private string check_form_mode(HiddenField ip_hdf_form_mode)
    {
        if (ip_hdf_form_mode.Value.Equals("0"))
        {
            return LOAI_FORM.THEM;
        }
        if (ip_hdf_form_mode.Value.Equals("1"))
        {
            return LOAI_FORM.SUA;
        }
        if (ip_hdf_form_mode.Value.Equals("2"))
        {
            return LOAI_FORM.XOA;
        }
        return LOAI_FORM.THEM;
    }
    private bool check_validate()
    {
        if (!CValidateTextBox.IsValid(m_txt_ma_don_vi, DataType.StringType, allowNull.NO))
        {
            thong_bao("Bạn chưa Nhập đúng Mã Đơn Vị!");
            return false;
        }
        if (!CValidateTextBox.IsValid(m_txt_ten_don_vi, DataType.StringType, allowNull.NO))
        {
            thong_bao ( "Bạn chưa Nhập đúng Tên Đơn Vị!");
            return false;
        }
        if ((check_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.SUA))
            && m_hdf_id_don_vi.Value.Equals(""))
        {
            thong_bao("Bạn phải chọn Đơn Vị cần sửa!");
            return false;
        }
        if (check_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.THEM))
        {
            if (m_us_don_vi.check_is_having_ma_don_vi(m_txt_ma_don_vi.Text))
            {
                thong_bao("Mã tài sản này đã tồn tại! "+check_form_mode(m_hdf_form_mode));
                return false;
            }
        }
        if (check_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.SUA))
        {
            US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_hdf_id_don_vi.Value));
            if (!m_txt_ma_don_vi.Text.Equals(v_us_dm_don_vi.strMA_DON_VI))
            {
                if (m_us_don_vi.check_is_having_ma_don_vi(m_txt_ma_don_vi.Text))
                {
                    thong_bao("Mã tài sản này đã tồn tại! "+check_form_mode(m_hdf_form_mode));
                    return false;
                }
            }
        }
        return true;
    }
    private void load_data_to_cbo_loai_don_vi()
    {
        DS_CM_DM_TU_DIEN v_ds_cm_dm_tu_dien = new DS_CM_DM_TU_DIEN();
        US_CM_DM_TU_DIEN v_us_cm_dm_tu_dien = new US_CM_DM_TU_DIEN();
        v_us_cm_dm_tu_dien.fill_tu_dien_cung_loai_ds(
            MA_LOAI_TU_DIEN.LOAI_DON_VI
            , v_ds_cm_dm_tu_dien);
        m_cbo_loai_don_vi.DataSource = v_ds_cm_dm_tu_dien.CM_DM_TU_DIEN;
        m_cbo_loai_don_vi.DataValueField = CM_DM_TU_DIEN.ID;
        m_cbo_loai_don_vi.DataTextField = CM_DM_TU_DIEN.TEN;
        m_cbo_loai_don_vi.DataBind();
        m_cbo_loai_don_vi.Enabled = false;
    }
    private void load_cbo_don_vi_cap_tren()
    {
        try
        {
            m_us_don_vi.FillDataset(m_ds_don_vi);
            m_cbo_don_vi_cap_tren.DataSource = m_ds_don_vi.DM_DON_VI;
            m_cbo_don_vi_cap_tren.DataTextField = DM_DON_VI.TEN_DON_VI;
            m_cbo_don_vi_cap_tren.DataValueField = DM_DON_VI.ID;
            m_cbo_don_vi_cap_tren.DataBind();
            m_cbo_don_vi_cap_tren.Items.Add("Không có cấp trên");
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_cbo_loai_don_vi()
    {
        try
        {
            US_CM_DM_TU_DIEN m_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN m_ds = new DS_CM_DM_TU_DIEN();
            m_us.FillDataset(m_ds, "WHERE ID_LOAI_TU_DIEN = 4");
            m_cbo_loai_hinh_don_vi.DataSource = m_ds.CM_DM_TU_DIEN;
            m_cbo_loai_hinh_don_vi.DataTextField = CM_DM_TU_DIEN.TEN_NGAN;
            m_cbo_loai_hinh_don_vi.DataValueField = CM_DM_TU_DIEN.ID;
            m_cbo_loai_hinh_don_vi.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_data_2_grid()
    {
        try
        {
            if (Request.QueryString["LOAI_DON_VI"].Equals("")) return;
            string v_str_user_name = Person.get_user_name();
            if (v_str_user_name.Equals(null)) return;
            m_ds_don_vi.Clear();
            string v_str_loai_don_vi = Request.QueryString["LOAI_DON_VI"].ToString();
            string v_str_dc_id_loai_don_vi = "";
            switch (v_str_loai_don_vi)
            {
                case LOAI_DON_VI.BO_TINH:
                    v_str_dc_id_loai_don_vi = CIPConvert.ToStr(ID_LOAI_DON_VI.BO_TINH);
                    break;
                case LOAI_DON_VI.DV_CHU_QUAN:
                    v_str_dc_id_loai_don_vi = CIPConvert.ToStr(ID_LOAI_DON_VI.DV_CHU_QUAN);
                    break;
                case LOAI_DON_VI.DV_SU_DUNG:
                    v_str_dc_id_loai_don_vi = CIPConvert.ToStr(ID_LOAI_DON_VI.DV_SU_DUNG);
                    break;
            }
            m_ds_don_vi.Clear();
            m_us_don_vi.FillDataSet_Load_data_to_grid_danh_muc_don_vi_by_key_word(
                m_ds_don_vi
                , CIPConvert.ToDecimal(v_str_dc_id_loai_don_vi)
                , v_str_user_name
                , m_txt_tim_kiem.Text.Trim()
                );
            m_grv_dm_don_vi.DataSource = m_ds_don_vi.DM_DON_VI;
            load_title(v_str_loai_don_vi);
            string v_str_thong_tin = " (Có " + m_ds_don_vi.DM_DON_VI.Rows.Count + " bản ghi)";
            m_lbl_thong_tin_don_vi.Text += v_str_thong_tin;
            m_grv_dm_don_vi.DataBind();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void delete_dm_don_vi(int i_int_row_index)
    {
        try
        {
            decimal dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
            m_us_don_vi.DeleteByID(dc_id_don_vi);
            load_data_2_grid();
            m_lbl_mess.Text = "Xóa bản ghi thành công.";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình xóa bản ghi.";
            throw v_e;
        }
    }
    private void load_update_don_vi(int i_int_row_index)
    {
        try
        {
            decimal dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
            US_DM_DON_VI us_dm_don_vi = new US_DM_DON_VI(dc_id_don_vi);
            m_hdf_id_don_vi.Value = CIPConvert.ToStr(dc_id_don_vi);
            us_object_2_form(us_dm_don_vi);
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void us_object_2_form(US_DM_DON_VI i_us_don_vi)
    {
        if (i_us_don_vi.dcID_DON_VI_CAP_TREN != 0)
        {
            m_cbo_don_vi_cap_tren.SelectedValue = CIPConvert.ToStr(i_us_don_vi.dcID_DON_VI_CAP_TREN);
        }
        else
        {
            m_cbo_don_vi_cap_tren.DataSource = null;
            m_cbo_don_vi_cap_tren.Items.Clear();
            m_cbo_don_vi_cap_tren.Items.Insert(0, new ListItem("Không có cấp trên", "Không có cấp trên"));
        }
        m_cbo_don_vi_cap_tren.DataBind();
        m_txt_ma_don_vi.Text = i_us_don_vi.strMA_DON_VI.Trim();
        m_txt_ten_don_vi.Text = i_us_don_vi.strTEN_DON_VI.Trim();
        m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(i_us_don_vi.dcID_LOAI_DON_VI);
        m_cbo_loai_don_vi.DataBind();
        m_cbo_loai_hinh_don_vi.SelectedValue = CIPConvert.ToStr(i_us_don_vi.strLOAI_HINH_DON_VI);
        m_cbo_loai_hinh_don_vi.DataBind();
    }
    private void thong_bao(string ip_str_thong_bao)
    {
        m_lbl_mess.Text = ip_str_thong_bao;
    }
    private void form_2_us_object()
    {

        if (m_cbo_don_vi_cap_tren.SelectedValue.Equals("Không có cấp trên"))
        //m_us_don_vi.dcID_DON_VI_CAP_TREN =null;
        {

        }
        else
        {
            m_us_don_vi.dcID_DON_VI_CAP_TREN = CIPConvert.ToDecimal(m_cbo_don_vi_cap_tren.SelectedValue);
        }
        switch (check_form_mode(m_hdf_form_mode))
        {
            case LOAI_FORM.THEM:
                // m_us_don_vi.dcSTT = null;
                string v_str_loai_don_vi = Request.QueryString["LOAI_DON_VI"];
                if (v_str_loai_don_vi.Equals(LOAI_DON_VI.BO_TINH))
                {
                    m_us_don_vi.dcLEVEL_MODE = LEVEL_MODE.BO_TINH;
                }
                if (v_str_loai_don_vi.Equals(LOAI_DON_VI.DV_CHU_QUAN))
                {
                    m_us_don_vi.dcLEVEL_MODE = LEVEL_MODE.DV_CHU_QUAN;
                }
                if (v_str_loai_don_vi.Equals(LOAI_DON_VI.DV_SU_DUNG))
                {
                    m_us_don_vi.dcLEVEL_MODE = LEVEL_MODE.DV_SU_DUNG;
                }
                break;
            case LOAI_FORM.SUA:
                US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_hdf_id_don_vi.Value));
                m_us_don_vi.dcSTT = v_us_dm_don_vi.dcSTT;
                m_us_don_vi.dcLEVEL_MODE = v_us_dm_don_vi.dcLEVEL_MODE;
                m_us_don_vi.dcID = CIPConvert.ToDecimal(this.m_hdf_id_don_vi.Value);
                break;
        }

        m_us_don_vi.strMA_DON_VI = m_txt_ma_don_vi.Text.Trim();
        m_us_don_vi.strTEN_DON_VI = m_txt_ten_don_vi.Text.Trim();
        m_us_don_vi.dcID_LOAI_DON_VI = CIPConvert.ToDecimal(m_cbo_loai_don_vi.SelectedValue);
        m_us_don_vi.strLOAI_HINH_DON_VI = m_cbo_loai_hinh_don_vi.SelectedValue;
    }
    private void reset_thong_bao()
    {
        m_lbl_mess.Text = "";
    }
    private void xoa_trang()
    {
        reset_thong_bao();
        m_txt_ten_don_vi.Text = "";
        m_txt_ma_don_vi.Text = "";
        this.m_hdf_id_don_vi.Value = "";
        m_hdf_form_mode.Value = LOAI_FORM.THEM;
        //m_cbo_don_vi_cap_tren.Items.Clear();
        m_cbo_don_vi_cap_tren.DataSource = null;
        m_cbo_don_vi_cap_tren.DataBind();
        m_cbo_loai_hinh_don_vi.DataSource = null;
        //m_cbo_loai_hinh_don_vi.Items.Clear();
        m_cbo_loai_hinh_don_vi.DataBind();
    }
    private void update_don_vi()
    {
        reset_thong_bao();
        if (Page.IsValid)
        {
            if (!check_validate()) return;
            form_2_us_object();
            m_us_don_vi.Update();
            load_data_2_grid();
            xoa_trang();
            thong_bao("Đã cập nhật đơn vị thành công!");
        }
    }
    private void insert_user()
    {
        reset_thong_bao();
        if (Page.IsValid)
        {
            if (!check_validate()) return;
            form_2_us_object();
            m_us_don_vi.Insert();
            load_data_2_grid();
            xoa_trang();
            thong_bao("Đã tạo mới Đơn Vị thành công!");
        }
    }
    private void load_title(string ip_str_loai_don_vi)
    {
        switch (ip_str_loai_don_vi)
        {
            case LOAI_DON_VI.BO_TINH:
                m_lbl_title.Text = "THÔNG TIN ĐƠN VỊ BỘ TỈNH";
                m_lbl_thong_tin_don_vi.Text = "DANH SÁCH ĐƠN VỊ BỘ TỈNH";
                break;
            case LOAI_DON_VI.DV_CHU_QUAN:
                m_lbl_title.Text = "THÔNG TIN ĐƠN VỊ CHỦ QUẢN";
                m_lbl_thong_tin_don_vi.Text = "DANH SÁCH ĐƠN VỊ CHỦ QUẢN";
                break;
            case LOAI_DON_VI.DV_SU_DUNG:
                m_lbl_title.Text = "THÔNG TIN ĐƠN VỊ SỬ DỤNG";
                m_lbl_thong_tin_don_vi.Text = "DANH SÁCH ĐƠN VỊ SỬ DỤNG";
                break;
        }
    }
    private void set_inital_form_mode()
    {
        string v_str_loai_don_vi = "";
        if (Request.QueryString["LOAI_DON_VI"].Equals("")) return;
        v_str_loai_don_vi = Request.QueryString["LOAI_DON_VI"];
        load_title(v_str_loai_don_vi);
        load_data_to_cbo_loai_don_vi();
        switch (v_str_loai_don_vi)
        {
            case LOAI_DON_VI.BO_TINH:
                m_cbo_don_vi_cap_tren.DataSource = null;
                m_cbo_don_vi_cap_tren.Items.Insert(0, new ListItem("Không có cấp trên", "Không có cấp trên"));
                m_cbo_don_vi_cap_tren.DataBind();
                m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(ID_LOAI_DON_VI.BO_TINH);
                m_lbl_don_vi_cap_tren.Visible = false;
                m_cbo_don_vi_cap_tren.Visible = false;
                break;
            case LOAI_DON_VI.DV_CHU_QUAN:
                WinFormControls.load_data_to_cbo_bo_tinh(
                    WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_cap_tren
                    );
                m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(ID_LOAI_DON_VI.DV_CHU_QUAN);
                m_lbl_don_vi_cap_tren.Visible = true;
                m_cbo_don_vi_cap_tren.Visible = true;
                break;
            case LOAI_DON_VI.DV_SU_DUNG:
                WinFormControls.load_data_to_cbo_don_vi_chu_quan(
                    CONST_QLDB.ID_TAT_CA.ToString()
                    , WinFormControls.eTAT_CA.NO
                    , m_cbo_don_vi_cap_tren
                    );
                m_cbo_loai_don_vi.SelectedValue = CIPConvert.ToStr(ID_LOAI_DON_VI.DV_SU_DUNG);
                m_lbl_don_vi_cap_tren.Visible = true;
                m_cbo_don_vi_cap_tren.Visible = true;
                break;

        }
        m_cmd_cap_nhat.Visible = false;
        m_cmd_tao_moi.Visible = true;
        

        WinFormControls.load_data_to_cbo_loai_hinh_don_vi(
            WinFormControls.eLOAI_TU_DIEN.LOAI_HINH_DON_VI
            , WinFormControls.eTAT_CA.NO
            , m_cbo_loai_hinh_don_vi);
        load_data_2_grid();
    }
    private void set_form(string ip_loai_form)
    {
        if (ip_loai_form.Equals(LOAI_FORM.THEM))
        {
            m_hdf_form_mode.Value = "0";
        }
        if (ip_loai_form.Equals(LOAI_FORM.SUA))
        {
            m_hdf_form_mode.Value = "1";
        }
        if (ip_loai_form.Equals(LOAI_FORM.XOA))
        {
            m_hdf_form_mode.Value = "2";
        }
    }
    #endregion

    #region Events
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
    protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
    {
        try
        {
            set_form(LOAI_FORM.SUA);
            update_don_vi();
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
            
            set_form(LOAI_FORM.THEM);
            insert_user();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
    {
        try
        {
            m_cmd_tao_moi.Visible = true;
            m_cmd_cap_nhat.Visible = false;
            xoa_trang();
            
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_don_vi_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            reset_thong_bao();
            delete_dm_don_vi(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_grv_dm_don_vi_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        load_data_2_grid();
        m_grv_dm_don_vi.PageIndex = e.NewPageIndex;
        m_grv_dm_don_vi.DataBind();
    }
    protected void m_cbo_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {

            throw v_e;
        }
    }
    protected void m_grv_dm_don_vi_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        try
        {
            reset_thong_bao();
            m_cmd_tao_moi.Visible = false;
            m_cmd_cap_nhat.Visible = true;
            
            xoa_trang();
            load_update_don_vi(e.RowIndex);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }

    }
    protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
    {
        try
        {
            load_data_2_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    #endregion
    
}