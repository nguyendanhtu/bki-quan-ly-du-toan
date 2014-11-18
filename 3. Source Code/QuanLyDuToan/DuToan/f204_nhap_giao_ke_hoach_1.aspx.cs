using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.WinFormControls;

public partial class DuToan_f204_nhap_giao_ke_hoach_1 : System.Web.UI.Page
{

    #region Public Interface

    #endregion

    #region Data Structure
    public class LOAI_FORM
    {
        public const string THEM = "THEM";
        public const string SUA = "SUA";
        public const string XOA = "XOA";
    }
    #endregion

    #region Members
    DS_GD_GIAO_KH m_ds = new DS_GD_GIAO_KH();
    US_GD_GIAO_KH m_us = new US_GD_GIAO_KH();
    #endregion //Members

    #region Private Methods
    private void load_data_to_cbo_quyet_dinh()
    {
        WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_KE_HOACH, m_ddl_quyet_dinh);
    }
    private void load_data_to_cbo_quoc_lo()
    {
        WinFormControls.load_data_to_cbo_du_an_cong_trinh(WinFormControls.LOAI_DU_AN.QUOC_LO, m_ddl_tuyen_quoc_lo);
    }
    private void load_data_to_du_an()
    {
        WinFormControls.load_data_to_cbo_du_an_cong_trinh(WinFormControls.LOAI_DU_AN.KHAC, m_ddl_du_an);
    }

    private bool check_validate_is_ok(string ip_str_ctx_yn)
    {
        bool v_b_result = true;
        if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.XOA))
        {

            US_GD_GIAO_VON v_us = new US_GD_GIAO_VON();
            DS_GD_GIAO_VON v_ds = new DS_GD_GIAO_VON();
            v_us.FillDataset(v_ds, "where id = " + m_hdf_id_giao_kh.Value);
            if (v_ds.GD_GIAO_VON.Count > 0)
            {
                m_lbl_mess.Text = "Bạn không thể xoá bản ghi này, dữ liệu này đang được sử dụng!";
                v_b_result = false;
            }
        }
        else
        {
            if (m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
            {
                m_lbl_mess_detail.Text = "Bạn phải nhập QĐ giao Kế hoạch hoặc Chọn QĐ đã nhập!";
                return false;
            }
            if (ip_str_ctx_yn.Trim().ToUpper() == "Y")
            {
                if (m_txt_ctx_so_tien.Text == "")
                {
                    m_lbl_mess.Text += "\n Bạn phải nhập Số tiền!";
                    v_b_result = false;
                }
            }
            else if (ip_str_ctx_yn.Trim().ToUpper() == "N")
            {
                if (m_txt_ten_du_an.Text == "")
                {
                    m_lbl_mess.Text += "\n Bạn phải nhập Tên dự án!";
                    v_b_result = false;
                }
                if (m_txt_cktx_so_tien.Text == "")
                {
                    m_lbl_mess.Text += "\n Bạn phải nhập Số tiền!";
                    v_b_result = false;
                }
            }

        }
        //if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.THEM))
        //{
        //    // Kiểm tra điều kiện trùng mã 
        //    US_DM_NHOM_NGHIEP_VU v_us_nhom_nghiep_vu = new US_DM_NHOM_NGHIEP_VU();
        //    DS_DM_NHOM_NGHIEP_VU v_ds_nhom_nghiep_vu = new DS_DM_NHOM_NGHIEP_VU();
        //    v_us_nhom_nghiep_vu.FillDatasetSearchMaNhom(v_ds_nhom_nghiep_vu, m_txt_ma_nhom.Text.Trim());
        //    if (v_ds_nhom_nghiep_vu.DM_NHOM_NGHIEP_VU.Count > 0)
        //    {
        //        m_lbl_mess.Text += "\n Mã nhóm đã tồn tại!";
        //        check = false;
        //    }
        //}
        //if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.SUA))
        //{
        //    // Kiểm tra điều kiện trùng mã 
        //    US_DM_NHOM_NGHIEP_VU v_us_nhom_nghiep_vu = new US_DM_NHOM_NGHIEP_VU(CIPConvert.ToDecimal(m_hdf_id_nhom_nghiep_vu.Value));
        //    DS_DM_NHOM_NGHIEP_VU v_ds_nhom_nghiep_vu = new DS_DM_NHOM_NGHIEP_VU();
        //    if (!m_txt_ma_nhom.Text.Trim().Equals(v_us_nhom_nghiep_vu.strMA_NHOM))
        //    {
        //        v_us_nhom_nghiep_vu.FillDatasetSearchMaNhom(v_ds_nhom_nghiep_vu, m_txt_ma_nhom.Text.Trim());
        //        if (v_ds_nhom_nghiep_vu.DM_NHOM_NGHIEP_VU.Count > 0)
        //        {
        //            m_lbl_mess.Text += "\n Mã nhóm đã tồn tại!";
        //            check = false;
        //        }
        //    }

        //}
        return v_b_result;
    }
    private string get_form_mode(HiddenField ip_hdf_form_mode)
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
    private void set_form_mode(string ip_loai_form)
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
    private void form_to_us_object(string ip_str_ctx_yn)
    {
        switch (get_form_mode(m_hdf_form_mode))
        {
            case LOAI_FORM.SUA:
                m_us.dcID = CIPConvert.ToDecimal(this.m_hdf_id_giao_kh.Value);
                break;
            case LOAI_FORM.THEM:
                m_us = new US_GD_GIAO_KH();
                break;
        }

        if (m_rdb_kh_dau_nam.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
        else if (m_rdb_dieu_chinh.Checked = true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.DIEU_CHINH;
        else if (m_rdb_bo_sung.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.BO_SUNG;
        if (ip_str_ctx_yn.Trim().ToUpper() == "Y")
        {
            m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_tuyen_quoc_lo.SelectedValue);
            m_us.dcSO_TIEN = CIPConvert.ToDecimal(m_txt_ctx_so_tien.Text.Trim());
            m_us.strIS_NGUON_NS_YN = m_rdb_ctx_quy_bao_tri.Checked == true ? "N" : "Y";
        }
        else
        {
            m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue);
            m_us.dcSO_TIEN = CIPConvert.ToDecimal(m_txt_cktx_so_tien.Text.Trim());
            m_us.strIS_NGUON_NS_YN = m_rdb_cktx_quy_bao_tri.Checked == true ? "N" : "Y";
        }
    }
    private void us_object_to_form()
    {
        m_us = new US_GD_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
        US_DM_DU_AN_CONG_TRINH v_us_du_an_cong_trinh = new US_DM_DU_AN_CONG_TRINH(m_us.dcID_DU_AN_CONG_TRINH);
        if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
        {
            m_ddl_tuyen_quoc_lo.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
            m_txt_ctx_so_tien.Text = CIPConvert.ToStr(m_us.dcSO_TIEN);
            if (m_us.strIS_NGUON_NS_YN.Trim().ToUpper() == "Y")
            {
                m_rdb_ctx_ngan_sach.Checked = true;
                m_rdb_ctx_quy_bao_tri.Checked = false;
            }
            else
            {
                m_rdb_ctx_ngan_sach.Checked = false;
                m_rdb_ctx_quy_bao_tri.Checked = true;
            }
        }
        else
        {
            m_ddl_du_an.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
            m_txt_ten_du_an.Text = m_ddl_du_an.SelectedItem.Text;
            m_txt_cktx_so_tien.Text = CIPConvert.ToStr(m_us.dcSO_TIEN);
            if (m_us.strIS_NGUON_NS_YN.Trim().ToUpper() == "Y")
            {
                m_rdb_cktx_ngan_sach.Checked = true;
                m_rdb_cktx_quy_bao_tri.Checked = false;
            }
            else
            {
                m_rdb_cktx_ngan_sach.Checked = false;
                m_rdb_cktx_quy_bao_tri.Checked = true;
            }
        }

    }
    private void load_data_to_grid()
    {
        try
        {
            m_ds.Clear();
            m_us.FillDataset(m_ds);
            m_grv.DataSource = m_ds.GD_GIAO_KH;
            m_grv.DataBind();
            if (!m_hdf_id_giao_kh.Value.Equals(""))
            {
                m_grv.SelectedIndex = -1;
                for (int i = 0; i < m_grv.Rows.Count; i++)
                    if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
            }
            WinFormControls.get_cout_grid_row(m_lbl_grid_title, "DANH SÁCH NHÓM NGHIỆP VỤ", m_ds.GD_GIAO_KH.Count);

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    private void set_inital_form_mode()
    {
        xoa_trang();
        load_data_to_cbo_quyet_dinh();
        load_data_to_cbo_quoc_lo();
        load_data_to_du_an();
        load_data_to_grid();
    }
    private void xoa_trang()
    {
        //m_lbl_mess_qd.Text = "";
        //m_lbl_mess.Text = "";
        //m_lbl_mess_detail.Text = "";

        set_form_mode(LOAI_FORM.THEM);
        m_grv.SelectedIndex = -1;

        m_hdf_id_giao_kh.Value = "";
        m_hdf_id_quoc_lo.Value = "";
        m_hdf_id_quyet_dinh.Value = "";
        m_hdf_id_du_an.Value = "";

        m_rdb_ctx_quy_bao_tri.Checked = true;
        m_rdb_ctx_ngan_sach.Checked = false;
        m_cmd_ctx_update.Visible = false;
        m_cmd_ctx_insert.Visible = true;

        m_rdb_cktx_quy_bao_tri.Checked = true;
        m_rdb_cktx_ngan_sach.Checked = false;
        m_cmd_cktx_update.Visible = false;
        m_cmd_cktx_insert.Visible = true;

    }
    private void save_data(string ip_str_ctx_yn)
    {
        if (!check_validate_is_ok(ip_str_ctx_yn)) return;
        form_to_us_object(ip_str_ctx_yn);
        switch (get_form_mode(m_hdf_form_mode))
        {
            case LOAI_FORM.THEM:
                m_us.Insert();
                m_lbl_mess.Text = "Bạn đã tạo mới thành công!";
                break;
            case LOAI_FORM.SUA:
                m_us.Update();
                m_lbl_mess.Text = "Bạn đã cập nhật thành công!";
                break;
        }
        xoa_trang();
        load_data_to_grid();
    }
    private void delete_dm_han_muc_by_ID()
    {
        m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
        load_data_to_grid();
        m_lbl_mess.Text = "Xoá bản ghi thành công!";
    }
    #endregion

    #region Event
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            this.Form.DefaultButton = m_cmd_tim_kiem.UniqueID;
            if (!IsPostBack)
            {
                set_inital_form_mode();
            }
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
            m_lbl_mess.Text = "";
            load_data_to_grid();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }


    protected void m_grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.XOA);
            m_hdf_id_giao_kh.Value = CIPConvert.ToStr(m_grv.DataKeys[e.RowIndex].Value);
            if (!check_validate_is_ok("")) return;
            //delete_dm_han_muc_by_ID();
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    protected void m_grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        m_grv.PageIndex = e.NewPageIndex;
        m_grv.SelectedIndex = -1;
        load_data_to_grid();
        if (!m_hdf_id_giao_kh.Value.Equals(""))
        {
            m_grv.SelectedIndex = -1;
            for (int i = 0; i < m_grv.Rows.Count; i++)
                if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
        }
    }
    protected void m_grv_RowEditing(object sender, GridViewEditEventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            xoa_trang();
            //format button by form mode - update
            m_cmd_ctx_update.Visible = true;
            m_cmd_cktx_update.Visible = true;
            m_cmd_ctx_insert.Visible = false;
            m_cmd_cktx_insert.Visible = false;

            m_grv.SelectedIndex = e.NewEditIndex;
            m_hdf_id_giao_kh.Value = CIPConvert.ToStr(m_grv.DataKeys[e.NewEditIndex].Value);
            set_form_mode(LOAI_FORM.SUA);
            us_object_to_form();
        }
        catch (System.Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_ctx_insert_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.THEM);
            save_data("Y");
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_ctx_update_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.SUA);
            save_data("Y");
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_ctx_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_cmd_cktx_insert_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.THEM);
            save_data("N");
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cktx_update_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess.Text = "";
            set_form_mode(LOAI_FORM.SUA);
            save_data("N");
            xoa_trang();
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_cktx_cancel_Click(object sender, EventArgs e)
    {
        try
        {
            m_lbl_mess_detail.Text = "";
            m_txt_ten_du_an.Text = "";
            m_txt_ten_du_an.Enabled = true;
            m_txt_ten_du_an.Visible = true;
            m_ddl_du_an.Visible = false;
            m_txt_cktx_so_tien.Text = "";
            m_hdf_id_du_an.Value = "";
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }

    protected void m_ddl_du_an_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            m_hdf_id_du_an.Value = m_ddl_du_an.SelectedValue;
            m_txt_ten_du_an.Text = m_ddl_du_an.SelectedItem.Text;
            m_txt_ten_du_an.Enabled = false;
            m_txt_ten_du_an.Visible = true;
            m_ddl_du_an.Visible = false;

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
    protected void m_cmd_chon_qd_da_nhap_Click(object sender, EventArgs e)
    {
        m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
        load_data_to_cbo_quyet_dinh();
        m_ddl_quyet_dinh.Visible = true;
        m_txt_so_qd.Visible = false;
        m_txt_noi_dung.Visible = false;
        m_txt_ngay_thang.Visible = false;
        m_cmd_luu_qd.Visible = false;
     
    }
    protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (m_ddl_quyet_dinh.SelectedValue == null) return;
        m_ddl_quyet_dinh.Visible = false;
        m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;

        m_txt_so_qd.Visible = true;
        m_txt_noi_dung.Visible = true;
        m_txt_ngay_thang.Visible = true;

        m_txt_so_qd.Enabled = false;
        m_txt_noi_dung.Enabled = false;
        m_txt_ngay_thang.Enabled = false;
        m_cmd_luu_qd.Visible = false;
        US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
        m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
        m_txt_noi_dung.Text = v_us.strNOI_DUNG;
        m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
    }
    protected void m_cmd_nhap_qd_moi_Click(object sender, EventArgs e)
    {
        m_hdf_id_quyet_dinh.Value = "";

        m_ddl_quyet_dinh.Visible = false;
        m_txt_so_qd.Enabled = true;
        m_txt_noi_dung.Enabled = true;
        m_txt_ngay_thang.Enabled = true;
        m_cmd_luu_qd.Visible = true;

        m_txt_so_qd.Text = "";
        m_txt_noi_dung.Text = "";
        m_txt_ngay_thang.Text = "";
    }
    protected void m_cmd_luu_qd_Click(object sender, EventArgs e)
    {
        US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH();
        m_hdf_id_quyet_dinh.Value = "";
        //check validate luu quyet dinh
        if (m_txt_so_qd.Text.Trim().Equals(""))
        {
            m_lbl_mess_qd.Text = "Bạn phải nhập Số quyết định!";
            m_txt_so_qd.Focus();
            return;
        }
        if (m_txt_noi_dung.Text.Trim().Equals(""))
        {
            m_lbl_mess_qd.Text = "Bạn phải nhập Nội dung quyết định!";
            m_txt_noi_dung.Focus();
            return;
        }
        if (m_txt_ngay_thang.Text.Trim().Equals(""))
        {
            m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
            m_txt_ngay_thang.Focus();
            return;
        }
        DateTime v_dat_ngay_thang = DateTime.Now;
        try
        {
            v_dat_ngay_thang = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim());
        }
        catch (Exception)
        {
            m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
            m_txt_ngay_thang.Focus();
            return;
        }

        // insert gd quyet dinh
        v_us.dcID_DON_VI = Person.get_id_don_vi();
        v_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
        v_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
        v_us.strSO_QUYET_DINH = m_txt_so_qd.Text.Trim();
        v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
        v_us.Insert();
        //do not edit
        m_txt_so_qd.Enabled = false;
        m_txt_noi_dung.Enabled = false;
        m_txt_ngay_thang.Enabled = false;
        m_lbl_mess_qd.Text = "Lưu QĐ thành công!";
        //set id to hiddenfield
        m_hdf_id_quyet_dinh.Value = v_us.dcID.ToString();
    }
    #endregion




    protected void m_cmd_chon_du_an_Click(object sender, EventArgs e)
    {
        m_hdf_id_du_an.Value = m_ddl_du_an.SelectedValue ;
        m_txt_ten_du_an.Visible = false;
        load_data_to_du_an();
        m_ddl_du_an.Visible = true;
    }
    protected void m_rdb_kh_dau_nam_CheckedChanged(object sender, EventArgs e)
    {
        if (m_rdb_kh_dau_nam.Checked==true)
        {
            
        }
    }
}