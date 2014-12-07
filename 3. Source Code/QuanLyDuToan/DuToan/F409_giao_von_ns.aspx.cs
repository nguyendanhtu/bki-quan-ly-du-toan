using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;
using System.Data;
namespace QuanLyDuToan.DuToan
{
	public partial class F409_giao_von_ns : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				set_inital_form_load();
			}
		}

		#region Public Interface
		public string format_so_tien(string ip_str_so_tien)
		{
			string op_str_so_tien = "";
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_str_so_tien = "";
			}
			else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
			return op_str_so_tien;
		}
		#endregion

		private void set_inital_form_load()
		{
			load_data_to_cbo_muc_tieu_muc();

			xoa_trang();
		}

		private void load_data_to_cbo_muc_tieu_muc()
		{
			if (m_hdf_id_quyet_dinh.Value.Equals("") | m_hdf_id_quyet_dinh.Value.Trim().Equals("-1"))
			{
				m_ddl_muc.Items.Clear();
				m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
				return;
			}
			US_GD_QUYET_DINH v_us_qd = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
			DateTime v_dat_dau_nam = v_us_qd.datNGAY_THANG;
			v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DataSet v_ds_muc_tieu_muc = WinFormControls.get_dataset_muc_tieu_muc_giao_kh(v_dat_dau_nam, v_dat_cuoi_nam);
			m_ddl_muc.DataTextField = GET_MUC_TIEU_MUC.DISPLAY;
			m_ddl_muc.DataValueField = GET_MUC_TIEU_MUC.ID;
			m_ddl_muc.DataSource = v_ds_muc_tieu_muc.Tables[0];
			m_ddl_muc.DataBind();
			m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
		}

		#region Quyet dinh
		private void load_data_to_cbo_quyet_dinh()
		{
			WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_VON, m_ddl_quyet_dinh);
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
			try
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

				disable_edit_quyet_dinh();
				load_data_to_cbo_muc_tieu_muc();
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

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

			load_data_to_cbo_muc_tieu_muc();
			load_data_to_grid();
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
		DS_GD_GIAO_VON m_ds = new DS_GD_GIAO_VON();
		US_GD_GIAO_VON m_us = new US_GD_GIAO_VON();
		#endregion //Members

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
				//v_us.FillDataset(v_ds, "where id = " + m_hdf_id_giao_von.Value);
				//if (v_ds.GD_GIAO_VON.Count > 0)
				//{
				//	m_lbl_mess_grid.Text = "Bạn không thể xoá bản ghi này, dữ liệu này đang được sử dụng!";
				//	v_b_result = false;
				//}
			}
			else
			{
				if (m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập QĐ giao Kế hoạch hoặc Chọn QĐ đã nhập!";
					return false;
				}

				if (m_txt_so_tien.Text == "")
				{
					m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
					m_txt_so_tien.Focus();
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
					m_us.dcID = CIPConvert.ToDecimal(this.m_hdf_id_giao_von.Value);
					break;
				case LOAI_FORM.THEM:
					m_us = new US_GD_GIAO_VON();
					break;
			}

			//if (m_rdb_kh_dau_nam.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
			//else if (m_rdb_dieu_chinh.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.DIEU_CHINH;
			//else if (m_rdb_bo_sung.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.BO_SUNG;
			//m_us.strIS_NGUON_NS_YN = "Y";//Nguon mac dinh la Ngan sach
			m_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_so_tien.Text.Trim());

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

			m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
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
		}
		private void us_object_to_form()
		{
			m_us = new US_GD_GIAO_VON(CIPConvert.ToDecimal(m_hdf_id_giao_von.Value));
			//US_DM_DU_AN_CONG_TRINH v_us_du_an_cong_trinh = new US_DM_DU_AN_CONG_TRINH(m_us.dcID_DU_AN_CONG_TRINH);
			load_data_to_cbo_muc_tieu_muc();
			//set id_mix cua ddl_muce
			m_ddl_muc.SelectedValue = get_id_mix_from_id_gd(m_us.dcID);
			load_info_chuong_loai_khoan_muc_from_id_gd(m_ddl_muc.SelectedValue);
			//chua lam
			m_txt_so_tien.Text = m_us.dcSO_TIEN_NS.ToString();
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
			US_GD_QUYET_DINH v_us_quyet_dinh = new US_GD_QUYET_DINH(m_us.dcID_QUYET_DINH);
			m_txt_so_qd.Text = v_us_quyet_dinh.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us_quyet_dinh.strNOI_DUNG;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
			m_hdf_id_quyet_dinh.Value = v_us_quyet_dinh.dcID.ToString();

			disable_edit_quyet_dinh();

		}
		private void xoa_trang()
		{
			//m_lbl_mess_qd.Text = "";
			//m_lbl_mess.Text = "";
			//m_lbl_mess_detail.Text = "";

			set_form_mode(LOAI_FORM.THEM);
			m_grv.SelectedIndex = -1;

			m_hdf_id_giao_von.Value = "";
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_quyet_dinh.Value = "";
			//m_hdf_id_du_an.Value = "";

			m_txt_so_tien.Text = "";
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
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_von.Value));
			load_data_to_grid();
			m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
		}

		private string get_id_mix_from_id_gd(decimal ip_dc_id_giao_von)
		{
			US_GD_GIAO_VON v_us = new US_GD_GIAO_VON(ip_dc_id_giao_von);
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
				CSystemLog_301.ExceptionHandle(this, v_e);
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
			m_lbl_mess_qd.Text = "";
		}

		#endregion

		private void load_data_to_grid()
		{
			US_V_GD_GIAO_VON v_us = new US_V_GD_GIAO_VON();
			DS_V_GD_GIAO_VON v_ds = new DS_V_GD_GIAO_VON();
			if (m_hdf_id_quyet_dinh.Value.Trim().Equals("") | m_hdf_id_quyet_dinh.Value.Trim().Equals("-1"))
			{
				m_grv.DataSource = v_ds.V_GD_GIAO_VON;
				m_grv.DataBind();
				return;
			}
			v_us.FillDataset(v_ds, "where id_chuong is not null and id_quyet_dinh=" + m_hdf_id_quyet_dinh.Value);
			m_grv.DataSource = v_ds.V_GD_GIAO_VON;
			m_grv.DataBind();
		}
		protected void m_grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			m_grv.PageIndex = e.NewPageIndex;
			m_grv.SelectedIndex = -1;
			load_data_to_grid();
			if (!m_hdf_id_giao_von.Value.Equals(""))
			{
				m_grv.SelectedIndex = -1;
				for (int i = 0; i < m_grv.Rows.Count; i++)
					if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_von.Value)) m_grv.SelectedIndex = i;
			}
		}

		protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				m_hdf_id_giao_von.Value = CIPConvert.ToStr(e.CommandArgument);
				GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
				if (e.CommandName == "Sua")
				{
					m_lbl_mess_grid.Text = "";
					xoa_trang();
					m_hdf_id_giao_von.Value = CIPConvert.ToStr(e.CommandArgument);
					//format button by form mode - update
					m_cmd_update.Visible = true;
					m_cmd_insert.Visible = false;
					//reset control

					m_grv.SelectedIndex = gvr.RowIndex;
					set_form_mode(LOAI_FORM.SUA);
					us_object_to_form();
				}
				else if (e.CommandName == "Xoa")
				{
					m_hdf_id_giao_von.Value = CIPConvert.ToStr(e.CommandArgument);
					m_lbl_mess_grid.Text = "";
					set_form_mode(LOAI_FORM.XOA);
					if (!check_validate_is_ok()) return;
					delete_by_ID();
				}
			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
			}
		}
	}
}