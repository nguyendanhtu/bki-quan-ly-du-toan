using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.WinFormControls;

public partial class DuToan_f209_giao_von_ns : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            set_inital_form_load();
        }
    }

    private void load_data_to_ddl_chuong()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.CHUONG+" order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_chuong.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_chuong.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_chuong.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_chuong.DataBind();
        m_ddl_chuong.Items.Insert(0, new ListItem("---Chọn Chương---", "-1"));
    }
    private void load_data_to_ddl_loai()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.LOAI + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_loai.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_loai.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_loai.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_loai.DataBind();
        m_ddl_loai.Items.Insert(0, new ListItem("---Chọn Loại---", "-1"));
    }
    private void load_data_to_ddl_khoan()
    {
        if (m_ddl_loai.SelectedValue == "-1" | m_ddl_loai.SelectedValue == "" | m_ddl_loai.SelectedValue == null)
        {
            m_ddl_khoan.Items.Clear();
            return;
        }
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();

        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, 
            "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.KHOAN 
            +" and id_cha="+m_ddl_loai.SelectedValue
            + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_khoan.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_khoan.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_khoan.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_khoan.DataBind();
        m_ddl_khoan.Items.Insert(0, new ListItem("---Chọn Khoản---", "-1"));
    }
    private void load_data_to_ddl_muc()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.MUC + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_muc.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_muc.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_muc.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_muc.DataBind();
        m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục---", "-1"));
    }

    private void set_inital_form_load()
    {
        load_data_to_ddl_chuong();
        load_data_to_ddl_loai();
        load_data_to_ddl_khoan();
        load_data_to_ddl_muc();
    }
    protected void m_ddl_loai_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_to_ddl_khoan();
    }

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
    //private void reload_data_to_ddl()
    //{
    //    if (m_rdb_kh_dau_nam.Checked == true)
    //    {
    //        m_txt_ten_du_an.Visible = true;
    //        m_ddl_du_an.Visible = false;
    //        m_txt_ten_du_an.Enabled = true;
    //        m_txt_ten_du_an.Text = "";
    //        m_hdf_id_du_an.Value = "";
    //        load_data_to_cbo_quoc_lo();
    //        load_data_to_du_an();
    //    }
    //    else
    //    {
    //        m_txt_ten_du_an.Visible = false;
    //        m_ddl_du_an.Visible = true;
    //        load_data_cong_trinh_du_an_giao_kh_to_ddl(m_ddl_du_an, WinFormControls.LOAI_DU_AN.KHAC);
    //        load_data_cong_trinh_du_an_giao_kh_to_ddl(m_ddl_tuyen_quoc_lo, WinFormControls.LOAI_DU_AN.QUOC_LO);
    //    }
    //}
    private void load_data_to_cbo_quyet_dinh()
    {
        WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_KE_HOACH, m_ddl_quyet_dinh);
    }
    private void load_data_cong_trinh_du_an_giao_kh_to_ddl(DropDownList op_ddl, WinFormControls.LOAI_DU_AN ip_loai_du_an)
    {
        if (m_hdf_id_quyet_dinh.Value.Trim().Equals("") | m_hdf_id_quyet_dinh.Value.Trim().Equals("-1"))
        {
            op_ddl.Items.Clear();
        }
        else
        {
            US_GD_QUYET_DINH v_us_quyet_dinh = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
            DateTime v_dat_dau_nam = v_us_quyet_dinh.datNGAY_THANG;
            v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
            v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
            DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
            WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_kh(ip_loai_du_an
                , v_dat_dau_nam
                , v_dat_cuoi_nam
                , ""
                , op_ddl);
        }
    }
    private void disable_edit_quyet_dinh()
    {
        m_txt_so_qd.Enabled = false;
        m_txt_noi_dung.Enabled = false;
        m_txt_ngay_thang.Enabled = false;
        m_cmd_luu_qd.Visible = false;
    }

    #endregion

    protected void m_cmd_chon_qd_da_nhap_Click(object sender, EventArgs e)
    {
        m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
        load_data_to_cbo_quyet_dinh();
        m_ddl_quyet_dinh.Visible = true;
        m_txt_so_qd.Visible = false;
        m_txt_noi_dung.Visible = false;
        m_txt_ngay_thang.Visible = false;
        m_cmd_luu_qd.Visible = false;

        //reload_data_to_ddl();

    }
    protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (m_ddl_quyet_dinh.SelectedValue == null) return;
        m_ddl_quyet_dinh.Visible = false;
        m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;

        m_txt_so_qd.Visible = true;
        m_txt_noi_dung.Visible = true;
        m_txt_ngay_thang.Visible = true;

        US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
        m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
        m_txt_noi_dung.Text = v_us.strNOI_DUNG;
        m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

        //reload_data_to_ddl();
        //load_data_to_grid();
    }
    protected void m_cmd_nhap_qd_moi_Click(object sender, EventArgs e)
    {
        m_hdf_id_quyet_dinh.Value = "";

        m_ddl_quyet_dinh.Visible = false;
        m_txt_so_qd.Enabled = true;
        m_txt_noi_dung.Enabled = true;
        m_txt_ngay_thang.Enabled = true;

        m_txt_so_qd.Visible = true;
        m_txt_noi_dung.Visible = true;
        m_txt_ngay_thang.Visible = true;

        m_cmd_luu_qd.Visible = true;

        m_txt_so_qd.Text = "";
        m_txt_noi_dung.Text = "";
        m_txt_ngay_thang.Text = "";

        //reload_data_to_ddl();
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

        //reload_data_to_ddl();
        //load_data_to_grid();
    }
}