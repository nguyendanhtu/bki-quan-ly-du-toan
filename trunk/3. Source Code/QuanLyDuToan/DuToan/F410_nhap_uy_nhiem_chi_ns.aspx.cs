using IP.Core.IPCommon;
using IP.Core.WinFormControls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

public partial class DuToan_F410_nhap_uy_nhiem_chi_ns : System.Web.UI.Page
{
	protected void Page_Load(object sender, EventArgs e)
	{
		try
		{
			if (!IsPostBack)
			{
				load_thong_tin_don_vi();
				set_inital_form_load();
				if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
					m_cmd_save_info_unc.Visible = false;
				else
				{
					m_cmd_save_info_unc.Visible = true;
					m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
					m_cmd_print.Visible = true;
				}
			}
		}
		catch (Exception v_e)
		{
			CSystemLog_301.ExceptionHandle(this, v_e);
		}
	}
	private void set_inital_form_load()
	{
		load_data_to_cbo_muc_tieu_muc();

		xoa_trang();
	}

	#region Public Interface
	public string format_so_tien(string ip_str_so_tien)
	{
		string op_str_so_tien = "";
		if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1") || ip_str_so_tien.Trim().Equals("0"))
		{
			op_str_so_tien = "0";
		}
		else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
		return op_str_so_tien;
	}
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
	#endregion //Members


	private void disable_control_unc()
	{
		m_txt_so_unc.Enabled = false;
		m_txt_ngay_thang.Enabled = false;
		m_txt_ma_ctmt_da_htct.Enabled = false;
	}

	private void enable_control_unc()
	{
		m_txt_so_unc.Enabled = true;
		m_txt_ngay_thang.Enabled = true;
		m_txt_ma_ctmt_da_htct.Enabled = true;
	}

	private void xoa_trang_control_unc()
	{
		US_DM_THONG_TIN_DON_VI v_us = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
		m_lbl_dia_chi.Text = v_us.strDIA_CHI;
		m_lbl_tai_kho_bac_nha_nuoc.Text = v_us.strKHO_BAC;
		m_lbl_ma_tkkt.Text = v_us.strMA_TKKT;
		m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
		m_txt_so_unc.Text = "";
		m_txt_ngay_thang.Text = "";

		m_txt_ma_ctmt_da_htct.Text = "";

		m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
		m_ddl_unc.Visible = false;
		m_txt_so_unc.Visible = true;
		m_cmd_luu_unc.Visible = true;
		//info dm unc
		m_txt_nt_ten_don_vi.Text = "";
		m_txt_nt_ma_so_thue.Text = "";
		m_txt_nt_ma_ndkt.Text = "";
		m_txt_nt_ma_chuong.Text = "";
		m_txt_nt_co_quan_quan_ly_thu.Text = "";
		m_txt_nt_ma_cq_thu.Text = "";
		m_txt_nt_kbnn_hach_toan_thu.Text = "";
		m_txt_nt_so_tien_nop_thue.Text = "";

		m_txt_ttdvh_don_vi_nhan_tien.Text = "";
		m_txt_ttdvh_ma_dvqhns.Text = "";
		m_txt_ttdvh_dia_chi.Text = "";
		m_txt_ttdvh_tai_khoan.Text = "";
		m_txt_ttdvh_ma_ctmt_da_htct.Text = "";
		m_txt_ttdvh_tai_kbnn.Text = "";
		m_txt_ttdvh_so_tien_thanh_toan.Text = "";
	}
	private void xoa_trang_khoan_thanh_toan()
	{
		//load_data_du_an_cong_trinh_by_loai();
		//m_txt_so_tien_nop_thue.Text = "";
		//m_txt_so_tien_thanh_toan_cho_dv_huong.Text = "";
		//m_txt_ghi_chu.Text = "";
		//m_cmd_ctx_insert.Visible = true;
		//m_cmd_ctx_update.Visible = false;
		//m_cmd_ctx_cancel.Visible = true;

		//set_form_mode(LOAI_FORM.THEM);
		//m_hdf_id_gd_uy_nhiem_chi.Value = "-1";
	}
	protected void m_ddl_muc_SelectedIndexChanged(object sender, EventArgs e)
	{
		xoa_thong_tin_ve_muc_tieu_muc();
		if (m_ddl_muc.SelectedValue.Equals("") | m_ddl_muc.SelectedValue.Trim().Equals("-1"))
			return;
		load_info_chuong_loai_khoan_muc_from_id_gd(m_ddl_muc.SelectedValue);
	}

	private void xoa_thong_tin_ve_muc_tieu_muc()
	{
		m_lbl_chuong.Text = "";
		m_lbl_loai.Text = "";
		m_lbl_khoan.Text = "";
		m_lbl_muc.Text = "";
	}

	#region Save Data
	//private methods
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
	private bool check_validate_is_ok()
	{
		bool v_b_result = true;
		if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.XOA))
		{

			//US_GD_UY_NHIEM_CHI v_us = new US_GD_UY_NHIEM_CHI();
			//DS_GD_UY_NHIEM_CHI v_ds = new DS_GD_UY_NHIEM_CHI();
			//v_us.FillDataset(v_ds, "where id = " + m_hdf_id_gd_uy_nhiem_chi.Value);
			//if (v_ds.GD_GIAO_VON.Count > 0)
			//{
			//	m_lbl_mess_grid.Text = "Bạn không thể xoá bản ghi này, dữ liệu này đang được sử dụng!";
			//	v_b_result = false;
			//}
		}
		else
		{
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals(""))
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập QĐ giao Kế hoạch hoặc Chọn QĐ đã nhập!";
				return false;
			}

			if (!CValidateTextBox.IsValid(m_txt_so_tien_nop_thue, DataType.NumberType,allowNull.NO))
			{
				m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền nộp thuế!";
				m_txt_so_tien_nop_thue.Focus();
				v_b_result = false;
			}
			if (!CValidateTextBox.IsValid(m_txt_so_tien_thanh_toan_don_vi_huong, DataType.NumberType, allowNull.NO))
			{
				m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền thanh toán đơn vị hưởng!";
				m_txt_so_tien_thanh_toan_don_vi_huong.Focus();
				v_b_result = false;
			}

			if (m_ddl_muc.SelectedValue == "-1")
			{
				m_lbl_mess_detail.Text += "\n Bạn phải chọn Mục/Tiểu mục!";
				m_ddl_muc.Focus();
				v_b_result = false;
			}

		}

		return v_b_result;
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

		m_us.strIS_NGUON_NS_YN = "Y";//Nguon mac dinh la Ngan sach
		m_us.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(m_txt_so_tien_nop_thue.Text.Trim());
		m_us.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan_don_vi_huong.Text.Trim());

		//get id chuong, loai, khoan, muc from ddl_muc - id_mix
		string v_str_mix = m_ddl_muc.SelectedValue;
		string[] v_arr_id = v_str_mix.Split('|');
		decimal v_dc_id_chuong = 0;
		decimal v_dc_id_loai = 0;
		decimal v_dc_id_khoan = 0;
		decimal v_dc_id_muc = 0;
		decimal v_dc_id_tieu_muc = 0;
		v_dc_id_chuong = CIPConvert.ToDecimal(v_arr_id[0]);
		v_dc_id_loai = CIPConvert.ToDecimal(v_arr_id[1]);
		v_dc_id_khoan = CIPConvert.ToDecimal(v_arr_id[2]);
		v_dc_id_muc = CIPConvert.ToDecimal(v_arr_id[3]);
		if (v_arr_id[4].Trim().Equals(""))
		{
			v_dc_id_tieu_muc = -1;
		}
		else v_dc_id_tieu_muc = CIPConvert.ToDecimal(v_arr_id[4]);

		m_us.dcID_UNC = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
		m_us.dcID_CHUONG = v_dc_id_chuong;
		m_us.dcID_KHOAN = v_dc_id_khoan;
		m_us.dcID_MUC = v_dc_id_muc;
		if (v_dc_id_tieu_muc == -1)
		{
			m_us.SetID_TIEU_MUCNull();
		}
		else m_us.dcID_TIEU_MUC = v_dc_id_tieu_muc;
		m_us.strGHI_CHU = m_txt_ghi_chu.Text.Trim();
		m_us.dcID_DON_VI = Person.get_id_don_vi();
		m_us.SetID_DU_AN_CONG_TRINHNull();
		m_us.strNOI_DUNG = m_txt_ghi_chu.Text;
	}
	private void load_data_to_cbo_muc_tieu_muc()
	{
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
		{
			m_ddl_muc.Items.Clear();
			m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
			return;
		}
		US_DM_UY_NHIEM_CHI v_us_qd = new US_DM_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
		DateTime v_dat_dau_nam = v_us_qd.datNGAY_THANG;
		v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
		v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
		DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
		DataSet v_ds_muc_tieu_muc = WinFormControls.get_dataset_muc_tieu_muc_giao_von(v_dat_dau_nam, v_dat_cuoi_nam);
		m_ddl_muc.DataTextField = GET_MUC_TIEU_MUC.DISPLAY;
		m_ddl_muc.DataValueField = GET_MUC_TIEU_MUC.ID;
		m_ddl_muc.DataSource = v_ds_muc_tieu_muc.Tables[0];
		m_ddl_muc.DataBind();
		m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
	}
	private void us_object_to_form()
	{
		m_us = new US_GD_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value));
		////US_DM_DU_AN_CONG_TRINH v_us_du_an_cong_trinh = new US_DM_DU_AN_CONG_TRINH(m_us.dcID_DU_AN_CONG_TRINH);
		load_data_to_cbo_muc_tieu_muc();
		//set id_mix cua ddl_muce
		m_ddl_muc.SelectedValue = get_id_mix_from_id_gd(m_us.dcID);
		load_info_chuong_loai_khoan_muc_from_id_gd(m_ddl_muc.SelectedValue);
		//chua lam
		m_txt_so_tien_nop_thue.Text = m_us.dcSO_TIEN_NOP_THUE.ToString();
		m_txt_so_tien_thanh_toan_don_vi_huong.Text = m_us.dcSO_TIEN_TT_CHO_DV_HUONG.ToString();
		m_txt_ghi_chu.Text = m_us.strGHI_CHU;

		//if (m_us.dcID_LOAI_GIAO_DICH == ID_LOAI_GIAO_DICH.KH_DAU_NAM)
		//{
		//	m_rdb_kh_dau_nam.Checked = true;
		//	m_rdb_dieu_chinh.Checked = false;
		//	m_rdb_bo_sung.Checked = false;
		//}
		//else if (m_us.dcID_LOAI_GIAO_DICH == ID_LOAI_GIAO_DICH.BO_SUNG)
		//{
		//	m_rdb_kh_dau_nam.Checked = false;
		//	m_rdb_dieu_chinh.Checked = false;
		//	m_rdb_bo_sung.Checked = true;
		//}
		//else
		//{
		//	m_rdb_kh_dau_nam.Checked = false;
		//	m_rdb_dieu_chinh.Checked = true;
		//	m_rdb_bo_sung.Checked = false;
		//}

		//set quyet dinh
		//US_GD_QUYET_DINH v_us_quyet_dinh = new US_GD_QUYET_DINH(m_us.dcID_QUYET_DINH);
		//m_txt_so_qd.Text = v_us_quyet_dinh.strSO_QUYET_DINH;
		//m_txt_noi_dung.Text = v_us_quyet_dinh.strNOI_DUNG;
		//m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
		//m_hdf_id_dm_uy_nhiem_chi.Value = v_us_quyet_dinh.dcID.ToString();

		//disable_edit_quyet_dinh();

	}
	private void xoa_trang()
	{
		//m_lbl_mess_qd.Text = "";
		//m_lbl_mess.Text = "";
		//m_lbl_mess_detail.Text = "";

		set_form_mode(LOAI_FORM.THEM);
		m_grv.SelectedIndex = -1;

		m_hdf_id_gd_uy_nhiem_chi.Value = "";
		//m_hdf_id_quoc_lo.Value = "";
		//m_hdf_id_dm_uy_nhiem_chi.Value = "";
		//m_hdf_id_du_an.Value = "";

		m_txt_so_tien_nop_thue.Text = "";
		m_txt_so_tien_thanh_toan_don_vi_huong.Text = "";
		m_txt_ghi_chu.Text = "";

		//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
		//m_ddl_du_an.SelectedValue = "-1";

		m_cmd_update.Visible = false;
		m_cmd_insert.Visible = true;

		load_data_to_cbo_muc_tieu_muc();
		//m_ddl_tieu_muc.SelectedValue = "-1";

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
				break;
		}
		xoa_trang();
		load_data_to_grid();
	}
	private void delete_by_ID()
	{
		m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value));
		load_data_to_grid();
		m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
	}
	private void load_data_to_grid()
	{
		try
		{
			DS_V_GD_UY_NHIEM_CHI v_ds = new DS_V_GD_UY_NHIEM_CHI();
			US_V_GD_UY_NHIEM_CHI v_us = new US_V_GD_UY_NHIEM_CHI();
			if (!m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals(""))
			{
				v_us.FillDataset(v_ds, "where id_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value + " and id_don_vi=" + Person.get_id_don_vi() +
					 " and id_chuong is not null");
			}
			//DataSet v_ds_view = get_tree_dataset(v_ds);
			m_grv.DataSource = v_ds.V_GD_UY_NHIEM_CHI;
			m_grv.DataBind();
			if (!m_hdf_id_gd_uy_nhiem_chi.Value.Equals("") && !m_hdf_id_gd_uy_nhiem_chi.Value.Equals("-1"))
			{
				m_grv.SelectedIndex = -1;
				for (int i = 0; i < m_grv.Rows.Count; i++)
					if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value)) m_grv.SelectedIndex = i;
			}
			//WinFormControls.get_cout_grid_row(m_lbl_grid_title, "Danh sách khoản thanh toán", v_ds.V_GD_UY_NHIEM_CHI.Count);

		}
		catch (Exception v_e)
		{
			m_lbl_mess_grid.Text = v_e.ToString();
		}
	}
	private string get_id_mix_from_id_gd(decimal ip_dc_id_giao_von)
	{
		US_GD_UY_NHIEM_CHI v_us = new US_GD_UY_NHIEM_CHI(ip_dc_id_giao_von);
		US_DM_CHUONG_LOAI_KHOAN_MUC v_us_khoan = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_us.dcID_KHOAN);
		string v_str_id_mix = "";
		v_str_id_mix += v_us.dcID_CHUONG + "|";//chuong
		v_str_id_mix += v_us_khoan.dcID_CHA + "|";//loai
		v_str_id_mix += v_us.dcID_KHOAN + "|";//khoan
		v_str_id_mix += v_us.dcID_MUC + "|";//muc
		if (!v_us.IsID_TIEU_MUCNull())
		{
			v_str_id_mix += v_us.dcID_TIEU_MUC;//tieu muc
		}
		return v_str_id_mix;
	}
	private void load_info_chuong_loai_khoan_muc_from_id_gd(string ip_str_id_mix)
	{
		string v_str_mix = ip_str_id_mix;
		string[] v_arr_id = v_str_mix.Split('|');
		decimal v_dc_id_chuong = 0;
		decimal v_dc_id_loai = 0;
		decimal v_dc_id_khoan = 0;
		decimal v_dc_id_muc = 0;
		decimal v_dc_id_tieu_muc = 0;
		v_dc_id_chuong = CIPConvert.ToDecimal(v_arr_id[0]);
		v_dc_id_loai = CIPConvert.ToDecimal(v_arr_id[1]);
		v_dc_id_khoan = CIPConvert.ToDecimal(v_arr_id[2]);
		v_dc_id_muc = CIPConvert.ToDecimal(v_arr_id[3]);
		if (v_arr_id[4].Trim().Equals(""))
		{
			v_dc_id_tieu_muc = -1;
		}
		else v_dc_id_tieu_muc = CIPConvert.ToDecimal(v_arr_id[4]);
		US_DM_CHUONG_LOAI_KHOAN_MUC v_us_chuong = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_dc_id_chuong);
		US_DM_CHUONG_LOAI_KHOAN_MUC v_us_loai = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_dc_id_loai);
		US_DM_CHUONG_LOAI_KHOAN_MUC v_us_khoan = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_dc_id_khoan);
		US_DM_CHUONG_LOAI_KHOAN_MUC v_us_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_dc_id_muc);

		m_lbl_chuong.Text = v_us_chuong.strMA_SO + " " + v_us_chuong.strTEN;
		m_lbl_loai.Text = v_us_loai.strMA_SO + " " + v_us_loai.strTEN;
		m_lbl_khoan.Text = v_us_khoan.strMA_SO + " " + v_us_khoan.strTEN;
		m_lbl_muc.Text = v_us_muc.strMA_SO + " " + v_us_muc.strTEN;
	}
	//event
	protected void m_cmd_insert_Click(object sender, EventArgs e)
	{
		try
		{
			set_form_mode(LOAI_FORM.THEM);
			save_data();
		}
		catch (Exception v_e)
		{
			m_lbl_mess_detail.Text = v_e.ToString();
		}
	}
	protected void m_cmd_update_Click(object sender, EventArgs e)
	{
		try
		{
			set_form_mode(LOAI_FORM.SUA);
			save_data();
		}
		catch (Exception v_e)
		{
			CSystemLog_301.ExceptionHandle(this, v_e);
		}
	}
	protected void m_cmd_cancel_Click(object sender, EventArgs e)
	{
		xoa_trang();
		m_lbl_mess_detail.Text = "";
		m_lbl_mess_grid.Text = "";
		//m_lbl_mess_qd.Text = "";
	}

	#endregion
	private void load_thong_tin_don_vi()
	{
		US_DM_DON_VI v_us_dv = new US_DM_DON_VI(Person.get_id_don_vi());
		m_lbl_don_vi_tra_tien.Text = v_us_dv.strTEN_DON_VI;
		US_DM_THONG_TIN_DON_VI v_us_ttdv = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
		m_lbl_dia_chi.Text = v_us_ttdv.strDIA_CHI;
		m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_ttdv.strKHO_BAC;
		m_lbl_ma_tkkt.Text = v_us_ttdv.strMA_TKKT;
		m_lbl_ma_dvqhns.Text = v_us_ttdv.strMA_DVQHNS;
	}
	private void load_data_to_cbo_dm_uy_nhiem_chi()
	{
		WinFormControls.load_data_to_cbo_dm_uy_nhiem_chi(m_ddl_unc);
	}
	protected void m_cmd_chon_unc_Click(object sender, EventArgs e)
	{
		m_txt_so_unc.Visible = false;
		m_ddl_unc.Visible = true;
		load_data_to_cbo_dm_uy_nhiem_chi();
		//load_data_du_an_cong_trinh_by_loai();
	}
	protected void m_ddl_unc_SelectedIndexChanged(object sender, EventArgs e)
	{
		m_txt_so_unc.Visible = true;
		if (m_ddl_unc.SelectedValue == "-1" | m_ddl_unc.SelectedValue == "")
		{
			m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
		}
		else
		{
			m_hdf_id_dm_uy_nhiem_chi.Value = m_ddl_unc.SelectedValue;
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
				m_cmd_save_info_unc.Visible = false;
			else
			{
				m_cmd_save_info_unc.Visible = true;
				m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
				m_cmd_print.Visible = true;
			}
			US_DM_UY_NHIEM_CHI v_us = new US_DM_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
			m_lbl_dia_chi.Text = v_us.strDIA_CHI;
			m_txt_so_unc.Text = v_us.strSO_UNC;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
			m_lbl_tai_kho_bac_nha_nuoc.Text = v_us.strKHO_BAC_NHA_NUOC;
			m_lbl_ma_tkkt.Text = v_us.strMA_TKKT;
			m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
			m_txt_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;
			//info dm unc
			m_txt_nt_ten_don_vi.Text = v_us.strNT_TEN_DON_VI;
			m_txt_nt_ma_so_thue.Text = v_us.strNT_MA_SO_THUE;
			m_txt_nt_ma_ndkt.Text = v_us.strNT_MA_NDKT;
			m_txt_nt_ma_chuong.Text = v_us.strNT_MA_CHUONG;
			m_txt_nt_co_quan_quan_ly_thu.Text = v_us.strNT_CQ_QL_THU;
			m_txt_nt_ma_cq_thu.Text = v_us.strNT_MA_CQ_THU;
			m_txt_nt_kbnn_hach_toan_thu.Text = v_us.strNT_KBNN_HACH_TOAN_KHOAN_THU;
			m_txt_nt_so_tien_nop_thue.Text = v_us.strNT_SO_TIEN_NOP_THUE;

			m_txt_ttdvh_don_vi_nhan_tien.Text = v_us.strTTDVH_DON_VI_NHAN_TIEN;
			m_txt_ttdvh_ma_dvqhns.Text = v_us.strTTDVH_MA_DVQHNS;
			m_txt_ttdvh_dia_chi.Text = v_us.strTTDVH_DIA_CHI;
			m_txt_ttdvh_tai_khoan.Text = v_us.strTTDVH_TAI_KHOAN;
			m_txt_ttdvh_ma_ctmt_da_htct.Text = v_us.strTTDVH_MA_CTMT_DA_VA_HTCT;
			m_txt_ttdvh_tai_kbnn.Text = v_us.strTTDVH_KHO_BAC;
			m_txt_ttdvh_so_tien_thanh_toan.Text = v_us.strTTDVH_SO_TIEN;


			m_cmd_luu_unc.Visible = false;
			m_cmd_nhap_moi_unc.Visible = true;

			disable_control_unc();
			m_ddl_unc.Visible = false;
			load_data_to_grid();
			load_data_to_cbo_muc_tieu_muc();
		}
	}
	protected void m_cmd_nhap_moi_unc_Click(object sender, EventArgs e)
	{
		enable_control_unc();
		xoa_trang_control_unc();
		load_data_to_grid();
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			m_cmd_save_info_unc.Visible = false;
		else m_cmd_save_info_unc.Visible = true;
	}
	protected void m_cmd_luu_unc_Click(object sender, EventArgs e)
	{
		US_DM_UY_NHIEM_CHI v_us = new US_DM_UY_NHIEM_CHI();
		m_hdf_id_dm_uy_nhiem_chi.Value = "";
		//check validate luu quyet dinh

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


		// insert gd quyet dinh
		v_us.dcID_DON_VI = Person.get_id_don_vi();
		v_us.strDIA_CHI = m_lbl_dia_chi.Text.Trim();
		v_us.strKHO_BAC_NHA_NUOC = m_lbl_tai_kho_bac_nha_nuoc.Text.Trim();
		v_us.strMA_CTMT_DA_HTCT = m_txt_ma_ctmt_da_htct.Text.Trim();
		v_us.strMA_DVQHNS = m_lbl_ma_dvqhns.Text.Trim();
		v_us.strMA_TKKT = m_lbl_ma_tkkt.Text.Trim();
		v_us.strSO_UNC = m_txt_so_unc.Text.Trim();
		v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
		v_us.Insert();
		//do not edit
		disable_control_unc();
		m_lbl_mess_master.Text = "Lưu QĐ thành công!";
		//set id to hiddenfield
		m_hdf_id_dm_uy_nhiem_chi.Value = v_us.dcID.ToString();
		//load_data_du_an_cong_trinh_by_loai();
		//get_so_tien_kh_giao();
		load_data_to_grid();
		if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			m_cmd_save_info_unc.Visible = false;
		else
		{
			m_cmd_save_info_unc.Visible = true;
			m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
			m_cmd_print.Visible = true;
		}
	}
	protected void m_cmd_save_info_unc_Click(object sender, EventArgs e)
	{
		try
		{
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			{
				return;
			}
			US_DM_UY_NHIEM_CHI v_us_dm_unc = new US_DM_UY_NHIEM_CHI(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
			v_us_dm_unc.strNT_TEN_DON_VI = m_txt_nt_ten_don_vi.Text;
			v_us_dm_unc.strNT_MA_SO_THUE = m_txt_nt_ma_so_thue.Text;
			v_us_dm_unc.strNT_MA_NDKT = m_txt_nt_ma_ndkt.Text;
			v_us_dm_unc.strNT_MA_CHUONG = m_txt_nt_ma_chuong.Text;
			v_us_dm_unc.strNT_CQ_QL_THU = m_txt_nt_co_quan_quan_ly_thu.Text;
			v_us_dm_unc.strNT_MA_CQ_THU = m_txt_nt_ma_cq_thu.Text;
			v_us_dm_unc.strNT_KBNN_HACH_TOAN_KHOAN_THU = m_txt_nt_kbnn_hach_toan_thu.Text;
			v_us_dm_unc.strNT_SO_TIEN_NOP_THUE = m_txt_nt_so_tien_nop_thue.Text;

			v_us_dm_unc.strTTDVH_DON_VI_NHAN_TIEN = m_txt_ttdvh_don_vi_nhan_tien.Text;
			v_us_dm_unc.strTTDVH_MA_DVQHNS = m_txt_ttdvh_ma_dvqhns.Text;
			v_us_dm_unc.strTTDVH_DIA_CHI = m_txt_ttdvh_dia_chi.Text;
			v_us_dm_unc.strTTDVH_TAI_KHOAN = m_txt_ttdvh_tai_khoan.Text;
			v_us_dm_unc.strTTDVH_MA_CTMT_DA_VA_HTCT = m_txt_ttdvh_ma_ctmt_da_htct.Text;
			v_us_dm_unc.strTTDVH_KHO_BAC = m_txt_ttdvh_tai_kbnn.Text;
			v_us_dm_unc.strTTDVH_SO_TIEN = m_txt_ttdvh_so_tien_thanh_toan.Text;

			v_us_dm_unc.Update();
			m_lbl_mess_info_unc.Text = "Đã cập nhật thông tin thành công!";
		}
		catch (Exception v_e)
		{
			m_lbl_mess_info_unc.Text = v_e.ToString();
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
	
	protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
	{
		try
		{
			if (e.CommandName == "Sua")
			{
				m_lbl_mess_grid.Text = "";
				//format button by form mode - update
				m_cmd_update.Visible = true;
				m_cmd_insert.Visible = false;
				//reset control
				load_data_to_cbo_muc_tieu_muc();
				m_txt_so_tien_nop_thue.Text = "";
				m_txt_so_tien_thanh_toan_don_vi_huong.Text = "";
				m_txt_ghi_chu.Text = "";
				GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
				m_grv.SelectedIndex = gvr.RowIndex;
				m_hdf_id_gd_uy_nhiem_chi.Value = CIPConvert.ToStr(e.CommandArgument);
				set_form_mode(LOAI_FORM.SUA);
				us_object_to_form();
			}

			else if (e.CommandName == "Xoa")
			{
				m_lbl_mess_grid.Text = "";
				set_form_mode(LOAI_FORM.XOA);
				GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
				m_hdf_id_gd_uy_nhiem_chi.Value = CIPConvert.ToStr(e.CommandArgument);

				delete_by_ID();
				xoa_trang_khoan_thanh_toan();
				xoa_trang();
			}
		}
		catch (Exception v_e)
		{
			m_lbl_mess_grid.Text = v_e.ToString();
		}
	}


}