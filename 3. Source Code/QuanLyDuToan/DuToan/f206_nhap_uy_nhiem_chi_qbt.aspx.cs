using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.WinFormControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;

public partial class DuToan_f206_nhap_uy_nhiem_chi : System.Web.UI.Page
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
	DS_GD_UY_NHIEM_CHI m_ds = new DS_GD_UY_NHIEM_CHI();
	US_GD_UY_NHIEM_CHI m_us = new US_GD_UY_NHIEM_CHI();
	#endregion

	#region Private Methods
	private bool check_validate_is_ok()
	{
		bool v_b_result = true;
		if (m_rdb_chi_thuong_xuyen.Checked == true)
		{
			if (m_ddl_quoc_lo.SelectedValue == "-1" | m_ddl_quoc_lo.SelectedValue == null)
			{
				m_lbl_mess_detail.Text = "Bạn phải chọn Nội dung chi";
				m_ddl_quoc_lo.Focus();
				v_b_result = false;
			}
		}
		else
		{
			if (m_ddl_du_an.SelectedValue == "-1" | m_ddl_du_an.SelectedValue == null)
			{
				m_lbl_mess_detail.Text = "Bạn phải chọn Nội dung chi";
				m_ddl_du_an.Focus();
				v_b_result = false;
			}
		}
		if (m_txt_so_tien.Text.Trim().Equals(""))
		{
			m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền!";
			m_txt_so_tien.Focus();
			v_b_result = false;
		}
		decimal v_dc_so_tien = 0;
		try
		{
			v_dc_so_tien = CIPConvert.ToDecimal(m_txt_so_tien.Text.Trim());
		}
		catch (Exception)
		{
			m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền!";
			v_b_result = false;
			m_txt_so_tien.Focus();
			v_b_result = false;
		}
		if (m_txt_ghi_chu.Text.Trim().Equals(""))
		{
			m_lbl_mess_detail.Text = "Bạn phải Ghi rõ nội dung thanh toán!";
			m_txt_ghi_chu.Focus();
			v_b_result = false;
		}
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
	private void form_to_us_object()
	{
		switch (get_form_mode(m_hdf_form_mode))
		{
			case LOAI_FORM.SUA:
				m_us = new US_GD_UY_NHIEM_CHI(CIPConvert.ToDecimal(this.m_hdf_id_gd_uy_nhiem_chi.Value));
				break;
			case LOAI_FORM.THEM:
				m_us = new US_GD_UY_NHIEM_CHI();
				break;
		}

		m_us.strIS_NGUON_NS_YN = "N";//Nguon mac dinh la Quy bao tri
		m_us.strNOI_DUNG = m_txt_ghi_chu.Text.Trim();
		m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_hdf_id_du_an_cong_trinh.Value);
		m_us.dcSO_TIEN = CIPConvert.ToDecimal(m_txt_so_tien.Text.Trim());
		m_us.dcID_UNC = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
		m_us.dcID_DON_VI = Person.get_id_don_vi();
	}
	private void us_object_to_form()
	{
		m_us = new US_GD_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value));
		US_DM_DU_AN_CONG_TRINH v_us_du_an_cong_trinh = new US_DM_DU_AN_CONG_TRINH(m_us.dcID_DU_AN_CONG_TRINH);
		m_hdf_id_du_an_cong_trinh.Value = m_us.dcID_DU_AN_CONG_TRINH.ToString();
		if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
		{
			m_rdb_chi_thuong_xuyen.Checked = true;
			m_rdb_chi_khong_thuong_xuyen.Checked = false;
		}
		else
		{
			m_rdb_chi_thuong_xuyen.Checked = false;
			m_rdb_chi_khong_thuong_xuyen.Checked = true;
		}
		//load_data_du_an_cong_trinh_by_loai();
		//set khoan chi
		if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
		{
			m_ddl_quoc_lo.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
			m_ddl_du_an.Visible = false;
			m_ddl_quoc_lo.Visible = true;
		}
		else
		{
			m_ddl_du_an.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
			m_ddl_du_an.Visible = true;
			m_ddl_quoc_lo.Visible = false;

		}
		m_txt_so_tien.Text = m_us.dcSO_TIEN.ToString();
		m_txt_ghi_chu.Text = m_us.strNOI_DUNG;
		//set quyet dinh
		US_DM_UY_NHIEM_CHI v_us_dm_uy_nhiem_chi = new US_DM_UY_NHIEM_CHI(m_us.dcID_UNC);
		m_txt_dia_chi.Text = v_us_dm_uy_nhiem_chi.strDIA_CHI;
		m_txt_so_unc.Text = v_us_dm_uy_nhiem_chi.strSO_UNC;
		m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_dm_uy_nhiem_chi.datNGAY_THANG, "dd/MM/yyyy");
		m_txt_tai_kho_bac_nn.Text = v_us_dm_uy_nhiem_chi.strKHO_BAC_NHA_NUOC;
		m_txt_ma_dvqhns.Text = v_us_dm_uy_nhiem_chi.strMA_DVQHNS;
		m_txt_ma_ctmt_da_htct.Text = v_us_dm_uy_nhiem_chi.strMA_CTMT_DA_HTCT;
		m_txt_ma_tkkt.Text = v_us_dm_uy_nhiem_chi.strMA_TKKT;
		m_hdf_id_dm_uy_nhiem_chi.Value = v_us_dm_uy_nhiem_chi.dcID.ToString();
		//disable_edit_dm_uy_nhiem_chi();

	}
	private void load_data_to_grid()
	{
		try
		{
			DS_V_GD_UY_NHIEM_CHI v_ds = new DS_V_GD_UY_NHIEM_CHI();
			US_V_GD_UY_NHIEM_CHI v_us = new US_V_GD_UY_NHIEM_CHI();
			if (!m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals(""))
			{
				v_us.FillDataset(v_ds, "where id_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value + " and id_don_vi=" + Person.get_id_don_vi());
			}
			m_grv.DataSource = v_ds.V_GD_UY_NHIEM_CHI;
			m_grv.DataBind();
			if (!m_hdf_id_gd_uy_nhiem_chi.Value.Equals("") && !m_hdf_id_gd_uy_nhiem_chi.Value.Equals("-1"))
			{
				m_grv.SelectedIndex = -1;
				for (int i = 0; i < m_grv.Rows.Count; i++)
					if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value)) m_grv.SelectedIndex = i;
			}
			WinFormControls.get_cout_grid_row(m_lbl_grid_title, "Danh sách khoản thanh toán", v_ds.V_GD_UY_NHIEM_CHI.Count);

		}
		catch (Exception v_e)
		{
			CSystemLog_301.ExceptionHandle(this, v_e);
		}
	}
	private void set_inital_form_load()
	{
		xoa_trang();
		load_data_to_cbo_dm_uy_nhiem_chi();
		load_data_cong_trinh_du_an_giao_von_to_ddl(m_ddl_du_an, WinFormControls.LOAI_DU_AN.KHAC);
		load_data_cong_trinh_du_an_giao_von_to_ddl(m_ddl_quoc_lo, WinFormControls.LOAI_DU_AN.QUOC_LO);
		load_data_du_an_cong_trinh_by_loai();
		load_data_to_grid();
	}
	private void xoa_trang()
	{
		//m_lbl_mess_qd.Text = "";
		//m_lbl_mess.Text = "";
		//m_lbl_mess_detail.Text = "";

		set_form_mode(LOAI_FORM.THEM);
		m_grv.SelectedIndex = -1;

		m_hdf_id_dm_uy_nhiem_chi.Value = "";
		//m_hdf_id_quoc_lo.Value = "";
		//m_hdf_id_dm_uy_nhiem_chi.Value = "";
		//m_hdf_id_du_an.Value = "";

		m_txt_so_tien.Text = "";

		//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
		//m_ddl_du_an.SelectedValue = "-1";

		m_cmd_ctx_update.Visible = false;
		m_cmd_ctx_insert.Visible = true;

	}
	private void save_data()
	{
		m_lbl_mess_detail.Text = "";
		if (!check_validate_is_ok()) return;
		form_to_us_object();

		switch (get_form_mode(m_hdf_form_mode))
		{
			case LOAI_FORM.THEM:
				m_us.Insert();
				m_lbl_mess_detail.Text = "Bạn đã tạo mới thành công!";
				break;
			case LOAI_FORM.SUA:
				m_us.Update();
				m_lbl_mess_detail.Text = "Bạn đã cập nhật thành công!";
				m_grv.SelectedIndex = -1;
				break;
		}
		xoa_trang_khoan_thanh_toan();
		m_ddl_quoc_lo.SelectedValue = "-1";
		m_ddl_du_an.SelectedValue = "-1";
		load_data_to_grid();
	}
	private void delete_dm_han_muc_by_ID()
	{
		m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value));
		load_data_to_grid();
		m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
	}

	private void load_data_to_cbo_dm_uy_nhiem_chi()
	{
		WinFormControls.load_data_to_cbo_dm_uy_nhiem_chi(m_ddl_unc);
	}
	private void load_data_cong_trinh_du_an_giao_von_to_ddl(DropDownList op_ddl, WinFormControls.LOAI_DU_AN ip_loai_du_an)
	{
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
		{
			op_ddl.Items.Clear();
		}
		else
		{
			US_DM_UY_NHIEM_CHI v_us_dm_unc = new US_DM_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
			DateTime v_dat_dau_nam = v_us_dm_unc.datNGAY_THANG;
			v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von(ip_loai_du_an
			, v_dat_dau_nam
			, v_dat_cuoi_nam
			, ""
			, op_ddl);
		}
	}
	private void load_data_du_an_cong_trinh_by_loai()
	{
		load_data_cong_trinh_du_an_giao_von_to_ddl(m_ddl_du_an, WinFormControls.LOAI_DU_AN.KHAC);
		load_data_cong_trinh_du_an_giao_von_to_ddl(m_ddl_quoc_lo, WinFormControls.LOAI_DU_AN.QUOC_LO);
		if (m_rdb_chi_thuong_xuyen.Checked == true)
		{
			m_ddl_quoc_lo.Visible = true;
			m_ddl_du_an.Visible = false;

		}
		else
		{
			m_ddl_quoc_lo.Visible = false;
			m_ddl_du_an.Visible = true;
		}
	}
	private void disable_control_unc()
	{
		m_txt_dia_chi.Enabled = false;
		m_txt_so_unc.Enabled = false;
		m_txt_ngay_thang.Enabled = false;
		m_txt_tai_kho_bac_nn.Enabled = false;
		m_txt_ma_tkkt.Enabled = false;
		m_txt_ma_dvqhns.Enabled = false;
		m_txt_ma_ctmt_da_htct.Enabled = false;
	}

	private void enable_control_unc()
	{
		m_txt_dia_chi.Enabled = true;
		m_txt_so_unc.Enabled = true;
		m_txt_ngay_thang.Enabled = true;
		m_txt_tai_kho_bac_nn.Enabled = true;
		m_txt_ma_tkkt.Enabled = true;
		m_txt_ma_dvqhns.Enabled = true;
		m_txt_ma_ctmt_da_htct.Enabled = true;
	}

	private void xoa_trang_control_unc()
	{
		m_txt_dia_chi.Text = "";
		m_txt_so_unc.Text = "";
		m_txt_ngay_thang.Text = "";
		m_txt_tai_kho_bac_nn.Text = "";
		m_txt_ma_tkkt.Text = "";
		m_txt_ma_dvqhns.Text = "";
		m_txt_ma_ctmt_da_htct.Text = "";

		m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
		m_ddl_unc.Visible = false;
		m_cmd_luu_unc.Visible = true;
	}
	private void xoa_trang_khoan_thanh_toan()
	{
		load_data_du_an_cong_trinh_by_loai();
		m_txt_so_tien.Text = "";
		m_txt_ghi_chu.Text = "";
		m_cmd_ctx_insert.Visible = true;
		m_cmd_ctx_update.Visible = false;
		m_cmd_ctx_cancel.Visible = true;

		set_form_mode(LOAI_FORM.THEM);
		m_hdf_id_gd_uy_nhiem_chi.Value = "-1";
	}
	#endregion
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			set_inital_form_load();
		}
	}

	protected void m_cmd_chon_unc_Click(object sender, EventArgs e)
	{

		m_ddl_unc.Visible = true;
		load_data_to_cbo_dm_uy_nhiem_chi();
		load_data_du_an_cong_trinh_by_loai();
	}
	protected void m_rdb_chi_thuong_xuyen_CheckedChanged(object sender, EventArgs e)
	{
		load_data_du_an_cong_trinh_by_loai();
	}
	protected void m_rdb_chi_khong_thuong_xuyen_CheckedChanged(object sender, EventArgs e)
	{
		load_data_du_an_cong_trinh_by_loai();
	}
	protected void m_ddl_unc_SelectedIndexChanged(object sender, EventArgs e)
	{
		if (m_ddl_unc.SelectedValue == "-1" | m_ddl_unc.SelectedValue == "")
		{
			m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
		}
		else
		{
			m_hdf_id_dm_uy_nhiem_chi.Value = m_ddl_unc.SelectedValue;
			US_DM_UY_NHIEM_CHI v_us = new US_DM_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
			m_txt_dia_chi.Text = v_us.strDIA_CHI;
			m_txt_so_unc.Text = v_us.strSO_UNC;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
			m_txt_tai_kho_bac_nn.Text = v_us.strKHO_BAC_NHA_NUOC;
			m_txt_ma_tkkt.Text = v_us.strMA_TKKT;
			m_txt_ma_dvqhns.Text = v_us.strMA_DVQHNS;
			m_txt_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;

			m_cmd_luu_unc.Visible = false;
			m_cmd_nhap_moi_unc.Visible = true;

			disable_control_unc();
			m_ddl_unc.Visible = false;
			load_data_to_grid();
			load_data_du_an_cong_trinh_by_loai();
		}
	}
	protected void m_cmd_nhap_moi_unc_Click(object sender, EventArgs e)
	{
		enable_control_unc();
		xoa_trang_control_unc();
		load_data_to_grid();
	}
	protected void m_cmd_luu_unc_Click(object sender, EventArgs e)
	{
		US_DM_UY_NHIEM_CHI v_us = new US_DM_UY_NHIEM_CHI();
		m_hdf_id_dm_uy_nhiem_chi.Value = "";
		//check validate luu quyet dinh
		if (m_txt_dia_chi.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Địa chỉ!";
			m_txt_dia_chi.Focus();
			return;
		}
		if (m_txt_so_unc.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Số Uỷ nhiệm chi!";
			m_txt_so_unc.Focus();
			return;
		}
		if (m_txt_ngay_thang.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Ngày tháng!";
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
			m_lbl_mess_master.Text = "Bạn phải nhập Ngày tháng!";
			m_txt_ngay_thang.Focus();
			return;
		}

		if (m_txt_tai_kho_bac_nn.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập thông tin Kho bạc!";
			m_txt_tai_kho_bac_nn.Focus();
			return;
		}
		if (m_txt_ma_tkkt.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Mã TKKT!";
			m_txt_ma_tkkt.Focus();
			return;
		}
		if (m_txt_ma_dvqhns.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Mã ĐVQHNS!";
			m_txt_ma_dvqhns.Focus();
			return;
		}

		if (m_txt_ma_ctmt_da_htct.Text.Trim().Equals(""))
		{
			m_lbl_mess_master.Text = "Bạn phải nhập Mã CTMT, DA và HTCT!";
			m_txt_ma_ctmt_da_htct.Focus();
			return;
		}

		// insert gd quyet dinh
		v_us.dcID_DON_VI = Person.get_id_don_vi();
		v_us.strDIA_CHI = m_txt_dia_chi.Text.Trim();
		v_us.strKHO_BAC_NHA_NUOC = m_txt_tai_kho_bac_nn.Text.Trim();
		v_us.strMA_CTMT_DA_HTCT = m_txt_ma_ctmt_da_htct.Text.Trim();
		v_us.strMA_DVQHNS = m_txt_ma_dvqhns.Text.Trim();
		v_us.strMA_TKKT = m_txt_ma_tkkt.Text.Trim();
		v_us.strSO_UNC = m_txt_so_unc.Text.Trim();
		v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
		v_us.Insert();
		//do not edit
		disable_control_unc();
		m_lbl_mess_master.Text = "Lưu QĐ thành công!";
		//set id to hiddenfield
		m_hdf_id_dm_uy_nhiem_chi.Value = v_us.dcID.ToString();
		load_data_du_an_cong_trinh_by_loai();
		//get_so_tien_kh_giao();
		load_data_to_grid();
	}
	protected void m_ddl_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
	{
		m_hdf_id_du_an_cong_trinh.Value = "-1";
		m_hdf_id_du_an_cong_trinh.Value = m_ddl_quoc_lo.SelectedValue;
	}
	protected void m_ddl_du_an_SelectedIndexChanged(object sender, EventArgs e)
	{
		m_hdf_id_du_an_cong_trinh.Value = "-1";
		m_hdf_id_du_an_cong_trinh.Value = m_ddl_du_an.SelectedValue;
	}
	protected void m_cmd_ctx_insert_Click(object sender, EventArgs e)
	{
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "-1" | m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "")
		{
			m_lbl_mess_detail.Text = "Bạn phải Nhập thông tin uỷ nhiệm chi hoặc Chọn UNC!";
			return;
		}
		set_form_mode(LOAI_FORM.THEM);
		save_data();
	}
	protected void m_cmd_ctx_update_Click(object sender, EventArgs e)
	{
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "-1" | m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "")
		{
			m_lbl_mess_detail.Text = "Bạn phải Nhập thông tin uỷ nhiệm chi hoặc Chọn UNC!";
			return;
		}
		set_form_mode(LOAI_FORM.SUA);
		save_data();
	}
	protected void m_cmd_ctx_cancel_Click(object sender, EventArgs e)
	{
		xoa_trang_khoan_thanh_toan();
		m_lbl_mess_detail.Text = "";
	}
	protected void m_grv_RowDeleting(object sender, GridViewDeleteEventArgs e)
	{
		try
		{
			m_lbl_mess_grid.Text = "";
			set_form_mode(LOAI_FORM.XOA);
			m_hdf_id_gd_uy_nhiem_chi.Value = CIPConvert.ToStr(m_grv.DataKeys[e.RowIndex].Value);

			delete_dm_han_muc_by_ID();
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
		if (!m_hdf_id_gd_uy_nhiem_chi.Value.Equals("") && !m_hdf_id_gd_uy_nhiem_chi.Value.Equals("-1"))
		{
			m_grv.SelectedIndex = -1;
			for (int i = 0; i < m_grv.Rows.Count; i++)
				if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value)) m_grv.SelectedIndex = i;
		}
	}
	protected void m_grv_RowEditing(object sender, GridViewEditEventArgs e)
	{
		try
		{
			m_lbl_mess_grid.Text = "";
			//format button by form mode - update
			m_cmd_ctx_update.Visible = true;
			m_cmd_ctx_insert.Visible = false;
			//reset control
			m_ddl_du_an.SelectedValue = "-1";
			m_ddl_quoc_lo.SelectedValue = "-1";
			m_txt_so_tien.Text = "";
			m_txt_ghi_chu.Text = "";
			m_grv.SelectedIndex = e.NewEditIndex;
			m_hdf_id_gd_uy_nhiem_chi.Value = CIPConvert.ToStr(m_grv.DataKeys[e.NewEditIndex].Value);
			set_form_mode(LOAI_FORM.SUA);
			us_object_to_form();
		}
		catch (System.Exception v_e)
		{
			CSystemLog_301.ExceptionHandle(this, v_e);
		}
	}
}