using System;
using System.Collections.Generic;
using System.Linq;
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
using QuanLyDuToan.App_Code;
namespace QuanLyDuToan.DanhMuc
{
	public partial class F901_Danh_muc_don_vi : System.Web.UI.Page
	{
		#region Public Methods
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
			string v_str_loai_don_vi = WebformFunctions.getValue_from_query_string<string>(
															this
															, FormInfo.QueryString.LOAI_DON_VI
															, ""
															);
			if (v_str_loai_don_vi.Equals("")) return;
			load_title(v_str_loai_don_vi);

			m_cmd_cap_nhat.Visible = false;
			m_cmd_tao_moi.Visible = true;
			load_data_to_grid();
		}

		private bool check_validate_data_is_ok()
		{
			if (!CValidateTextBox.IsValid(m_txt_ma_don_vi, DataType.StringType, allowNull.NO))
			{
				thong_bao("Bạn chưa Nhập đúng Mã Đơn Vị!");
				m_txt_ma_don_vi.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_ten_don_vi, DataType.StringType, allowNull.NO))
			{
				thong_bao("Bạn chưa Nhập đúng Tên Đơn Vị!");
				m_txt_ten_don_vi.Focus();
				return false;
			}
			if ((get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.SUA))
				&& m_hdf_id_don_vi.Value.Equals(""))
			{
				thong_bao("Bạn phải chọn Đơn Vị cần sửa!");
				return false;
			}
			if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.THEM))
			{
				if (m_us_don_vi.check_is_having_ma_don_vi(m_txt_ma_don_vi.Text))
				{
					thong_bao("Mã đơn vị này đã tồn tại! " + get_form_mode(m_hdf_form_mode));
					m_txt_ma_don_vi.Focus();
					return false;
				}
			}
			if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.SUA))
			{
				US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(CIPConvert.ToDecimal(m_hdf_id_don_vi.Value));
				if (!m_txt_ma_don_vi.Text.Equals(v_us_dm_don_vi.strMA_DON_VI))
				{
					if (m_us_don_vi.check_is_having_ma_don_vi(m_txt_ma_don_vi.Text))
					{
						thong_bao("Mã đơn vị này đã tồn tại! " + get_form_mode(m_hdf_form_mode));
						m_txt_ma_don_vi.Focus();
						return false;
					}
				}
			}
			return true;
		}

		private void load_data_to_grid()
		{
			try
			{
				string v_str_loai_don_vi = WebformFunctions.getValue_from_query_string<string>(
																this
																, FormInfo.QueryString.LOAI_DON_VI
																, ""
																);
				if (v_str_loai_don_vi.Equals("")) return;

				string v_str_user_name = Person.get_user_name();
				if (v_str_user_name.Equals(null)) return;


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

				m_ds_don_vi = new DS_DM_DON_VI();
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
				m_txt_tim_kiem.Focus();

			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		private void delete_all_data_of_don_vi(decimal ip_dc_id_don_vi)
		{
			m_us_don_vi.deleteAllDataOfDonVi(ip_dc_id_don_vi);
		}
		private void delete_dm_don_vi(int i_int_row_index)
		{
			decimal v_dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
			delete_all_data_of_don_vi(v_dc_id_don_vi);
			load_data_to_grid();
			m_lbl_mess.Text = "Xóa bản ghi thành công.";
		}

		private void edit_grid_row(int i_int_row_index)
		{
			try
			{
				decimal dc_id_don_vi = CIPConvert.ToDecimal(m_grv_dm_don_vi.DataKeys[i_int_row_index].Value);
				US_DM_DON_VI us_dm_don_vi = new US_DM_DON_VI(dc_id_don_vi);
				m_hdf_id_don_vi.Value = CIPConvert.ToStr(dc_id_don_vi);
				us_object_2_form(us_dm_don_vi);
				m_txt_ma_don_vi.Focus();
			}
			catch (Exception v_e)
			{
				throw v_e;
			}
		}

		private void us_object_2_form(US_DM_DON_VI i_us_don_vi)
		{
			m_txt_ma_don_vi.Text = i_us_don_vi.strMA_DON_VI.Trim();
			m_txt_ten_don_vi.Text = i_us_don_vi.strTEN_DON_VI.Trim();
		}
		private void form_2_us_object()
		{
			switch (get_form_mode(m_hdf_form_mode))
			{
				case LOAI_FORM.THEM:
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
			m_us_don_vi.dcID_LOAI_DON_VI = ID_LOAI_DON_VI.DV_SU_DUNG;
			m_us_don_vi.strLOAI_HINH_DON_VI = ID_LOAI_HINH_DON_VI.DON_VI_SU_NGHIEP_TCTC.ToString();
		}

		private void xoa_trang()
		{
			reset_thong_bao();

			m_txt_ten_don_vi.Text = "";
			m_txt_ma_don_vi.Text = "";

			this.m_hdf_id_don_vi.Value = "";
			m_hdf_form_mode.Value = LOAI_FORM.THEM;
			m_grv_dm_don_vi.SelectedIndex = -1;

			m_cmd_tao_moi.Visible = true;
			m_cmd_cap_nhat.Visible = false;
		}
		private void save_data()
		{
			if (Page.IsValid)
			{
				if (!check_validate_data_is_ok()) return;
				form_2_us_object();
				try
				{
					switch (get_form_mode(m_hdf_form_mode))
					{
						case LOAI_FORM.THEM:
							m_us_don_vi.Insert();
							xoa_trang();
							thong_bao("Đã tạo mới Đơn Vị thành công!");
							break;
						case LOAI_FORM.SUA:
							m_us_don_vi.Update();
							xoa_trang();
							thong_bao("Đã cập nhật đơn vị thành công!");
							break;
					}
				}
				catch (Exception)
				{
					thong_bao("Đã có lỗi trong quá trình thực hiện! Bạn vui lòng thực hiện lại thao tác!");
				}
				load_data_to_grid();
			}
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

		private void thong_bao(string ip_str_thong_bao)
		{
			m_lbl_mess.Text = ip_str_thong_bao;
		}
		private void reset_thong_bao()
		{
			m_lbl_mess.Text = "";
			m_lbl_thong_bao.Text = "";
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				this.Form.DefaultButton = m_cmd_tim_kiem.UniqueID;
				reset_thong_bao();

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

		protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
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
		protected void m_cmd_tao_moi_Click(object sender, EventArgs e)
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
		protected void m_cmd_xoa_trang_Click(object sender, EventArgs e)
		{
			try
			{
				xoa_trang();
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
				load_data_to_grid();
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
				delete_dm_don_vi(e.RowIndex);
			}
			catch (Exception v_e)
			{
				m_lbl_mess.Text = "Đã có lỗi trong quá trình thực hiện! Bạn vui lòng thực hiện lại thao tác!";
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_grv_dm_don_vi_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			try
			{
				m_grv_dm_don_vi.PageIndex = e.NewPageIndex;
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_grv_dm_don_vi_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				reset_thong_bao();
				m_cmd_tao_moi.Visible = false;
				m_cmd_cap_nhat.Visible = true;

				set_form_mode(LOAI_FORM.SUA);
				edit_grid_row(e.RowIndex);
				m_grv_dm_don_vi.SelectedIndex = e.RowIndex;
				m_cmd_cap_nhat.Visible = true;
				m_cmd_tao_moi.Visible = false;
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_cbo_don_vi_cap_tren_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		#endregion
	}
}