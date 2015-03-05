using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS.CDBNames;
using WebDS;
using WebUS;
using IP.Core.IPCommon;
using QuanLyDuToan;
using System.Web.Services;
using QuanLyDuToan.App_Code;


namespace QuanLyDuToan.DanhMuc
{
	public partial class f604_dm_quyet_dinh : System.Web.UI.Page
	{


		#region Public Methods
		public string get_delete_client_script(string ip_str_so_don_vi)
		{
			return "return confirm('QĐ này hiện có " + ip_str_so_don_vi + " đơn vị nhập dữ liệu. Bạn có muốn xoá QĐ này và tất cả dữ liệu mà các đơn vị đã nhập không?')";
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
		US_DM_QUYET_DINH m_us = new US_DM_QUYET_DINH();
		DS_DM_QUYET_DINH m_ds = new DS_DM_QUYET_DINH();
		#endregion

		#region Private Methods
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
		private void load_rdb_loai_quyet_dinh_giao_from_select_loai_quyet_dinh()
		{
			if (m_rdb_giao_ke_hoach.Checked == true)
			{
				m_lbl_loai_quyet_dinh_giao.Visible = true;
				m_rdb_loai_quyet_dinh_giao_bo_sung.Visible = true;
				m_rdb_loai_quyet_dinh_giao_dau_nam.Visible = true;
				m_rdb_loai_quyet_dinh_giao_dieu_chinh.Visible = true;
			}
			else if (m_rdb_giao_von.Checked == true)
			{
				m_lbl_loai_quyet_dinh_giao.Visible = false;
				m_rdb_loai_quyet_dinh_giao_bo_sung.Visible = false;
				m_rdb_loai_quyet_dinh_giao_dau_nam.Visible = false;
				m_rdb_loai_quyet_dinh_giao_dieu_chinh.Visible = false;
			}
		}
		private void form_to_us_object()
		{
			if (m_rdb_giao_ke_hoach.Checked == true)
			{
				m_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
				if (m_rdb_loai_quyet_dinh_giao_dau_nam.Checked == true)
				{
					m_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
				}
				else if (m_rdb_loai_quyet_dinh_giao_bo_sung.Checked == true)
				{
					m_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.BO_SUNG;
				}
				else if (m_rdb_loai_quyet_dinh_giao_dieu_chinh.Checked == true)
				{
					m_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.DIEU_CHINH;
				}
			}
			else if (m_rdb_giao_von.Checked == true)
			{
				m_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_VON;
				m_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
			}

			m_us.strSO_QUYET_DINH = m_txt_so_quyet_dinh.Text.Trim();
			m_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
			m_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			m_us.dcID_DON_VI = App_Code.Person.get_id_don_vi();
		}
		private void us_object_to_form()
		{
			decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			if (v_dc_id_quyet_dinh <= 0)
			{
				m_lbl_mess.Text = "Có lỗi xảy ra trong quá trình xử lý, Bạn vui lòng thực hiện lại thao tác!";
				return;
			}
			m_us = new US_DM_QUYET_DINH(v_dc_id_quyet_dinh);
			m_txt_so_quyet_dinh.Text = m_us.strSO_QUYET_DINH;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(m_us.datNGAY_THANG, "dd/MM/yyyy");
			m_txt_noi_dung.Text = m_us.strNOI_DUNG;
			if (m_us.dcID_LOAI_QUYET_DINH == ID_LOAI_QUYET_DINH.GIAO_VON)
			{
				m_rdb_giao_von.Checked = true;
				m_rdb_giao_ke_hoach.Checked = false;
			}
			else if (m_us.dcID_LOAI_QUYET_DINH == ID_LOAI_QUYET_DINH.GIAO_KE_HOACH)
			{
				m_rdb_giao_ke_hoach.Checked = true;
				m_rdb_giao_von.Checked = false;
				if (m_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.KH_DAU_NAM)
				{
					m_rdb_loai_quyet_dinh_giao_dau_nam.Checked = true;
					m_rdb_loai_quyet_dinh_giao_bo_sung.Checked = false;
					m_rdb_loai_quyet_dinh_giao_dieu_chinh.Checked = false;
				}
				else if (m_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.BO_SUNG)
				{
					m_rdb_loai_quyet_dinh_giao_dau_nam.Checked = false;
					m_rdb_loai_quyet_dinh_giao_bo_sung.Checked = true;
					m_rdb_loai_quyet_dinh_giao_dieu_chinh.Checked = false;
				}
				else if (m_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.DIEU_CHINH)
				{
					m_rdb_loai_quyet_dinh_giao_dau_nam.Checked = false;
					m_rdb_loai_quyet_dinh_giao_bo_sung.Checked = false;
					m_rdb_loai_quyet_dinh_giao_dieu_chinh.Checked = true;
				}
			}
			load_rdb_loai_quyet_dinh_giao_from_select_loai_quyet_dinh();
			m_txt_so_quyet_dinh.Focus();
		}
		private int getCountQuyetDinhCoSo(string ip_str_so_quyet_dinh)
		{
			DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			v_us.FillDataset(v_ds, "where " + DM_QUYET_DINH.SO_QUYET_DINH + " = N'" + ip_str_so_quyet_dinh + "'");
			return v_ds.DM_QUYET_DINH.Count;
		}
		private bool check_validate_data_is_ok()
		{

			//Kiem tra trùng Số quyết định
			if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.THEM)
			{
				/*
				 * Kiem tra trung so quyet dinh
				 * Neu co quyet dinh co So quyet dinh thi return false
				 * 
				 */
				if (getCountQuyetDinhCoSo(m_txt_so_quyet_dinh.Text.Trim()) > 0)
				{
					m_lbl_mess.Text = "Đã có Số quyết định " + m_txt_so_quyet_dinh.Text + ", Bạn hãy nhập Số quyết định khác!";
					return false;
				}
			}
			else if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.SUA)
			{
				/*
				 *Kiem tra xem, So quyet dinh X
				 *Co the giong so hien tai va phai khac voi tat ca cac So quyet dinh
				 */
				//Nếu không thay đổi Số QĐ thì ok
				US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
				if (!v_us.strSO_QUYET_DINH.Equals(m_txt_so_quyet_dinh.Text.Trim()))
					//Nếu thay đổi Số QĐ thì phải kiểm tra xem có trùng với Số QĐ cũ không
					if (getCountQuyetDinhCoSo(m_txt_so_quyet_dinh.Text.Trim()) > 0)
					{
						m_lbl_mess.Text = "Đã có Số quyết định " + m_txt_so_quyet_dinh.Text + ", Bạn hãy nhập Số quyết định khác!";
						return false;
					}

			}
			else if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.XOA)
			{
				/*
				 * Thong bao: Co x don vi da nhap du lieu cua quyet dinh nay, ban co muon xoa du lieu
				 * Hoi nguoi dung co that su muon xoa khong, neu xoa thi se xoa het du lieu cua quyet dinh nay
				 */
				
				//return false;
			}

			if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.SUA || get_form_mode(m_hdf_form_mode) == LOAI_FORM.THEM)
			{
				if (!CValidateTextBox.IsValid(m_txt_so_quyet_dinh, DataType.StringType, allowNull.NO))
				{
					m_lbl_mess.Text = "Bạn phải nhập Số quyết định!";
					m_txt_so_quyet_dinh.Focus();
					return false;
				}
				if (!CValidateTextBox.IsValid(m_txt_noi_dung, DataType.StringType, allowNull.NO))
				{
					m_lbl_mess.Text = "Bạn phải nhập Nội dung!";
					m_txt_noi_dung.Focus();
					return false;
				}
				if (!CValidateTextBox.IsValid(m_txt_ngay_thang, DataType.DateType, allowNull.NO))
				{
					m_lbl_mess.Text = "Bạn phải nhập Ngày tháng định dạng dd/MM/yyyy!";
					m_txt_ngay_thang.Focus();
					return false;
				}
			}

			return true;
		}
		
		private void save_data()
		{
			if (check_validate_data_is_ok())
			{
				if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.THEM)
				{
					m_us = new US_DM_QUYET_DINH();
					form_to_us_object();
					m_us.Insert();
					m_lbl_mess.Text = "Bạn đã thêm mới Quyết định thành công!";
					load_data_to_grid();
					xoa_trang();
				}
				else if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.SUA)
				{
					decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
					if (v_dc_id_quyet_dinh <= 0)
					{
						m_lbl_mess.Text = "Có lỗi xảy ra trong quá trình xử lý, Bạn vui lòng thực hiện lại thao tác!";
						return;
					}
					else
					{
						m_us = new US_DM_QUYET_DINH(v_dc_id_quyet_dinh);
						form_to_us_object();
						m_us.Update();
						m_lbl_mess.Text = "Bạn đã cập nhật dữ liệu thành công!";
						load_data_to_grid();
						xoa_trang();
					}

				}

			}
		}
		private void delete_dm_quyet_dinh_by_id(decimal ip_dc_id_dm_quyet_dinh)
		{
			if (ip_dc_id_dm_quyet_dinh < 0)
			{
				m_lbl_mess.Text = "Đã có lỗi xảy ra trong quá trình xử lý, Bạn vui lòng thực hiện lại thao tác!";
			}
			else
			{
				m_us.DeleteByID(ip_dc_id_dm_quyet_dinh);
				m_lbl_mess.Text = "Bạn đã xoá Quyết định thành công!";
				load_data_to_grid();
			}

		}
		private void load_data_to_grid()
		{
			US_V_DM_QUYET_DINH_SO_DON_VI_NHAP_DU_LIEU v_us = new US_V_DM_QUYET_DINH_SO_DON_VI_NHAP_DU_LIEU();
			DS_V_DM_QUYET_DINH_SO_DON_VI_NHAP_DU_LIEU v_ds = new DS_V_DM_QUYET_DINH_SO_DON_VI_NHAP_DU_LIEU();
			string v_str_sub_query = "";
			if (m_rdb_giao_ke_hoach.Checked == true)
			{
				v_str_sub_query = "where " + DM_QUYET_DINH.ID_LOAI_QUYET_DINH + " = " + ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
			}
			else if (m_rdb_giao_von.Checked == true)
			{
				v_str_sub_query = "where " + DM_QUYET_DINH.ID_LOAI_QUYET_DINH + " = " + ID_LOAI_QUYET_DINH.GIAO_VON;

			}
			v_us.FillDataset(v_ds, v_str_sub_query + " order by ngay_thang desc");
			m_grv.DataSource = v_ds.v_dm_quyet_dinh_so_don_vi_nhap_du_lieu;
			m_grv.DataBind();
		}
		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			m_lbl_mess.Text = "";
			if (!IsPostBack)
			{
				xoa_trang();
				load_rdb_loai_quyet_dinh_giao_from_select_loai_quyet_dinh();
				load_data_to_grid();
			}
		}

		#endregion

		protected void m_rdb_giao_ke_hoach_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				load_rdb_loai_quyet_dinh_giao_from_select_loai_quyet_dinh();
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_rdb_giao_von_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				load_rdb_loai_quyet_dinh_giao_from_select_loai_quyet_dinh();
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "Sua")
				{
					m_hdf_id_quyet_dinh.Value = e.CommandArgument.ToString();
					set_form_mode(LOAI_FORM.SUA);
					us_object_to_form();
					//set select row in gridview
					GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
					m_grv.SelectedIndex = gvr.RowIndex;
					m_cmd_update.Visible = true;
					m_cmd_cancel.Visible = true;
					m_cmd_insert.Visible = false;
				}
				else if (e.CommandName == "Xoa")
				{
					m_hdf_id_quyet_dinh.Value = e.CommandArgument.ToString();
					set_form_mode(LOAI_FORM.XOA);
					if (check_validate_data_is_ok())
					{
						delete_dm_quyet_dinh_by_id(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
					}
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_cmd_insert_Click(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess.Text = "";
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
				m_lbl_mess.Text = "";
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
			try
			{
				xoa_trang();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		private void xoa_trang()
		{
			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			m_txt_so_quyet_dinh.Text = "";
			m_txt_noi_dung.Text = "";
			set_form_mode(LOAI_FORM.THEM);
			m_cmd_cancel.Visible = true;
			m_cmd_insert.Visible = true;
			m_cmd_update.Visible = false;
			m_hdf_id_quyet_dinh.Value = "-1";
			m_grv.SelectedIndex = -1;
		}
	}
}