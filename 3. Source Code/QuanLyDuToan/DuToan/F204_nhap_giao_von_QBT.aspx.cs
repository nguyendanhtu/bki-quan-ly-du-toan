using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPException;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System.Data;
namespace QuanLyDuToan.DuToan
{
	public partial class F204_nhap_giao_von_QBT : System.Web.UI.Page
	{
		DS_GD_CHI_TIET_GIAO_VON m_ds = new DS_GD_CHI_TIET_GIAO_VON();
		US_GD_CHI_TIET_GIAO_VON m_us = new US_GD_CHI_TIET_GIAO_VON();

		public class LOAI_FORM
		{
			public const string THEM = "THEM";
			public const string SUA = "SUA";
			public const string XOA = "XOA";
		}

		#region Private Methods

		private bool check_validate_is_ok(string ip_str_ctx_yn)
		{
			bool v_b_result = true;

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

		private void disable_edit_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			//m_txt_ngay_thang.Enabled = false;
			//m_cmd_luu_qd.Visible = false;
		}

		private void load_data_to_grid()
		{
			decimal v_dc_id_quyet_dinh = -1;
			if (!m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
			{
				v_dc_id_quyet_dinh = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			}

			var v_id_loai_nv = string.IsNullOrEmpty(m_ddl_loai_nhiem_vu.SelectedValue) ? -1 : CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);
			//var v_id_cong_trinh = string.IsNullOrEmpty(m_ddl_cong_trinh.SelectedValue) ? -1 : CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue);
			//var v_id_du_an = string.IsNullOrEmpty(m_ddl_du_an.SelectedValue) ? -1 : CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue);

			load_data_to_grid(v_dc_id_quyet_dinh, v_id_loai_nv, -1, -1);
			//Neu khong phai don vi minh, thi khong duoc sua du lieu
			if (m_ddl_don_vi.SelectedValue != Person.get_id_don_vi().ToString())
			{
				m_cmd_cap_nhat.Visible = false;
				m_cmd_xoa_trang.Visible = false;
				m_grv.Columns[0].Visible = false;
			}
			else
			{
				m_cmd_cap_nhat.Visible = true;
				m_cmd_xoa_trang.Visible = true;
				m_grv.Columns[0].Visible = true;
			}
		}

		private void load_data_to_grid(decimal ip_id_quyet_dinh, decimal ip_id_loai_nhiem_vu = -1,
			decimal ip_id_cong_trinh = -1, decimal ip_id_du_an = -1)
		{

			var v_dat_now = DateTime.Now;
			//0. Chuan bi du lieu input
			if (ip_id_quyet_dinh != -1)
			{
				US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH(ip_id_quyet_dinh);
				v_dat_now = v_us_qd.datNGAY_THANG;
			}
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);

			//1. Update noi dung chi tu Giao kh sang Giao von
			US_GD_CHI_TIET_GIAO_VON v_us_giao_von = new US_GD_CHI_TIET_GIAO_VON();
			v_us_giao_von.update_noi_dung_chi_from_giao_kh_sang_giao_von(v_dat_dau_nam,
				v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue), ip_id_quyet_dinh);

			//2. Load data tu grid_giao_von len luoi de sua thong tin
			DS_GRID_GIAO_VON v_ds = new DS_GRID_GIAO_VON();
			US_GRID_GIAO_VON v_us = new US_GRID_GIAO_VON();

			v_us.get_grid_giao_von_qbt(
				v_ds
				, ip_id_quyet_dinh
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
				, v_dat_dau_nam
				, v_dat_cuoi_nam
				, ip_id_loai_nhiem_vu
				, ip_id_cong_trinh
				, ip_id_du_an);

			m_grv.DataSource = v_ds.Tables[0];
			m_grv.DataBind();

			//if (!m_hdf_id_giao_kh.Value.Equals(""))
			//{
			//	m_grv.SelectedIndex = -1;
			//	for (int i = 0; i < m_grv.Rows.Count; i++)
			//		if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
			//}




		}
		private void set_inital_form_mode()
		{
			xoa_trang();
			decimal v_dc_id_quyet_dinh = -1;
			decimal v_dc_id_don_vi = Person.get_id_don_vi(); ;
			if (Request.QueryString["ip_dc_id_quyet_dinh"] != null)
			{

				v_dc_id_quyet_dinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_quyet_dinh"]);

			}
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}


			//load dropdownlist danh sach don vi ma don vi X duoc xem du lieu
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
			load_data_to_cbo();
			m_ddl_quyet_dinh.SelectedValue = v_dc_id_quyet_dinh.ToString();
			m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
			m_ddl_don_vi.SelectedValue = v_dc_id_don_vi.ToString();
			load_data_to_grid();
		}
		private void xoa_trang()
		{
			set_form_mode(LOAI_FORM.THEM);
			m_grv.SelectedIndex = -1;

			m_hdf_id_giao_kh.Value = "";

		}
		private void save_data_in_grid(GridView ip_grv)
		{
			GridViewRow[] v_arr_gvr = new GridViewRow[ip_grv.Rows.Count];
			System.Web.UI.WebControls.TextBox v_txt_so_tien_ns;
			System.Web.UI.WebControls.TextBox v_txt_so_tien_quy;
			LinkButton v_lb_id_gd;

			ip_grv.Rows.CopyTo(v_arr_gvr, 0);
			bool v_b_is_update_data = false;

			for (int i = 0; i < v_arr_gvr.Length; i++)
			{
				//1. Duyet tung dong cua gridview, lay du lieu tu textbox
				//v_txt_so_tien_ns = (System.Web.UI.WebControls.TextBox)v_arr_gvr[i].FindControl("m_txt_so_tien_ngan_sach_grid");
				v_txt_so_tien_quy = (System.Web.UI.WebControls.TextBox)v_arr_gvr[i].FindControl("m_txt_so_tien_quy_bao_tri_grid");
				v_lb_id_gd = (LinkButton)v_arr_gvr[i].FindControl("m_lbl_delete");
				if (v_lb_id_gd.CommandArgument.ToString().Equals("") | v_lb_id_gd.CommandArgument.ToString().Equals("-1"))
				{
					continue;
				}
				else
				{
					try
					{
						//update du lieu vao csdl
						US_GD_CHI_TIET_GIAO_VON v_us = new US_GD_CHI_TIET_GIAO_VON(CIPConvert.ToDecimal(v_lb_id_gd.CommandArgument.ToString()));
						//v_us.dcSO_TIEN_NS = WinFormControls.get_so_tien(v_txt_so_tien_ns.Text);
						v_us.dcSO_TIEN_QUY_BT = WebformControls.get_so_tien(v_txt_so_tien_quy.Text);
						v_us.Update();
						v_b_is_update_data = true;
					}
					catch (Exception)
					{
						m_lbl_mess_grid.Text = "Đã có lỗi xảy ra, Xin vui lòng thực hiện lại thao tác";
						return;
					}

				}
			}
			if (v_b_is_update_data)
			{
				m_lbl_mess_grid.Text = "Đã ghi dữ liệu thành công!";
				m_ddl_loai_nhiem_vu.Focus();
			}
			load_data_to_grid();
		}
		private void delete_gd_chi_tiet_giao_kh_by_ID()
		{
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			WebformControls.ghiLogDuToan("Xoá bản ghi Giao vốn ở Quyết định số " + new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)).strSO_QUYET_DINH);
			load_data_to_grid();
			m_lbl_mess_detail.Text = "Xoá bản ghi thành công!";
		}
		protected string format_so_tien(string ip_str_so_tien)
		{
			string op_str_so_tien = "";
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_str_so_tien = "";
			}
			else if (ip_str_so_tien.Trim().Equals("0"))
			{
				op_str_so_tien = "0";
			}
			else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
			return op_str_so_tien;
		}
		protected bool visible_label_so_tien(string ip_str)
		{
			if (ip_str.Trim().Equals("") || ip_str.Trim().Equals("-1"))
			{
				return true;
			}
			return false;
		}


		#endregion

		#region Quyet dinh
		private void load_data_to_cbo()
		{
			WebformControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WebformControls.LOAI_QUYET_DINH.GIAO_VON, m_ddl_quyet_dinh);
			WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu);

		}

		private decimal insert_quyet_dinh()
		{
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			//if (m_rdb_kh_dau_nam.Checked == true)
			//{
			//	v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
			//}
			//else if (m_rdb_bo_sung.Checked == true)
			//{
			//	v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.BO_SUNG;
			//}
			//else v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.DIEU_CHINH;
			v_us.dcID_DON_VI = Person.get_id_don_vi();
			v_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_VON;
			v_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
			v_us.strSO_QUYET_DINH = m_txt_so_qd.Text.Trim();
			//v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
			v_us.Insert();
			return v_us.dcID;
		}

		private void disable_info_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			//m_txt_ngay_thang.Enabled = false;
		}

		private bool check_data_quyet_dinh_is_ok()
		{
			if (m_txt_so_qd.Text.Trim().Equals(""))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Số quyết định!";
				m_txt_so_qd.Focus();
				return false;
			}
			if (m_txt_noi_dung.Text.Trim().Equals(""))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Nội dung quyết định!";
				m_txt_noi_dung.Focus();
				return false;
			}
			//if (m_txt_ngay_thang.Text.Trim().Equals(""))
			//{
			//	m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
			//	m_txt_ngay_thang.Focus();
			//	return false;
			//}
			DateTime v_dat_ngay_thang = DateTime.Now;
			//try
			//{
			//	v_dat_ngay_thang = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim());
			//}
			//catch (Exception)
			//{
			//	m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
			//	m_txt_ngay_thang.Focus();
			//	return false;
			//}
			return true;
		}

		protected void m_cmd_chon_qd_da_nhap_Click(object sender, EventArgs e)
		{
			m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
			load_data_to_cbo();
			m_ddl_quyet_dinh.Visible = true;
			m_txt_so_qd.Visible = false;
			m_txt_noi_dung.Visible = false;
			//m_txt_ngay_thang.Visible = false;
			//m_cmd_luu_qd.Visible = false;
		}

		private void load_data_when_quyet_dinh_is_selected()
		{
			m_txt_so_qd.Visible = false;
			m_txt_noi_dung.Visible = true;
			//m_txt_ngay_thang.Visible = true;

			disable_edit_quyet_dinh();
			if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) < 0) return;
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
			m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us.strNOI_DUNG;
			//m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
			m_lbl_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

			//reload_data_to_ddl();
			load_data_to_grid();
		}

		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ddl_quyet_dinh.SelectedValue == null) return;
			m_ddl_quyet_dinh.Visible = true;
			m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
			load_data_when_quyet_dinh_is_selected();
			if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) < 0) return;
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue));
			if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.KH_DAU_NAM)
			{
				//m_rdb_kh_dau_nam.Checked = true;
				//m_rdb_dieu_chinh.Checked = false;
				//m_rdb_bo_sung.Checked = false;
				//m_lbl_loai_quyet_dinh.Text = "Đầu năm";
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.BO_SUNG)
			{
				//m_rdb_kh_dau_nam.Checked = false;
				//m_rdb_dieu_chinh.Checked = false;
				//m_rdb_bo_sung.Checked = true;
				//m_lbl_loai_quyet_dinh.Text = "Bổ sung";
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.DIEU_CHINH)
			{
				//m_rdb_kh_dau_nam.Checked = false;
				//m_rdb_dieu_chinh.Checked = true;
				//m_rdb_bo_sung.Checked = false;
				//m_lbl_loai_quyet_dinh.Text = "Điều chỉnh";
			}

		}
		protected void m_cmd_nhap_qd_moi_Click(object sender, EventArgs e)
		{
			m_hdf_id_quyet_dinh.Value = "";

			m_ddl_quyet_dinh.Visible = true;
			m_txt_so_qd.Enabled = true;
			m_txt_noi_dung.Enabled = true;
			//m_txt_ngay_thang.Enabled = true;

			m_txt_so_qd.Visible = false;
			m_txt_noi_dung.Visible = true;
			//m_txt_ngay_thang.Visible = true;

			//m_cmd_luu_qd.Visible = true;

			m_txt_so_qd.Text = "";
			m_txt_noi_dung.Text = "";
			//m_txt_ngay_thang.Text = "";

		}
		protected void m_cmd_luu_qd_Click(object sender, EventArgs e)
		{
			try
			{
				m_hdf_id_quyet_dinh.Value = "";
				//check validate luu quyet dinh
				if (check_data_quyet_dinh_is_ok())
				{
					m_hdf_id_quyet_dinh.Value = insert_quyet_dinh().ToString();
					m_lbl_mess_qd.Text = "Lưu QĐ thành công!";
					disable_info_quyet_dinh();
				}
				// insert gd quyet dinh
				//do not edit


				//set id to hiddenfield
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		#endregion

		//# Event...
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_detail.Text = "";
				m_lbl_mess_grid.Text = "";
				m_lbl_mess_qd.Text = "";
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
				m_lbl_mess_grid.Text = "";
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
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
		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton m_lbl_delete = (LinkButton)e.Row.FindControl("m_lbl_delete");
				TextBox m_txt_so_tien_ngan_sach_grid = (TextBox)e.Row.FindControl("m_txt_so_tien_ngan_sach_grid");
				TextBox m_txt_so_tien_quy_bao_tri_grid = (TextBox)e.Row.FindControl("m_txt_so_tien_quy_bao_tri_grid");
				if (m_lbl_delete != null)
				{
					if (m_lbl_delete.CommandArgument.Trim().Equals("-1") | m_lbl_delete.CommandArgument.Trim().Equals(""))
					{
						e.Row.CssClass = "cssFontBold";
						m_lbl_delete.Visible = false;
					}
					else
					{
						m_lbl_delete.Visible = true;
					}
				}
			}
		}
		protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "Sua")
				{
					m_lbl_mess_grid.Text = "";
					xoa_trang();

					//set select row in gridview
					GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
					m_grv.SelectedIndex = gvr.RowIndex;

					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					//m_grv.SelectedIndex = m_grv.SelectedRow.RowIndex;
					set_form_mode(LOAI_FORM.SUA);

				}
				else if (e.CommandName == "Xoa")
				{
					m_lbl_mess_grid.Text = "";
					set_form_mode(LOAI_FORM.XOA);
					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					if (!check_validate_is_ok("")) return;
					delete_gd_chi_tiet_giao_kh_by_ID();
				}
			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
			}

		}

		protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
		{
			try
			{
				save_data_in_grid(m_grv);
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
				m_lbl_mess_grid.Text = "";
				m_lbl_mess_qd.Text = "";
				m_lbl_mess_detail.Text = "";
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_ddl_loai_nhiem_vu_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				// Load danh mục công trình theo loại nhiệm vụ đã được giao kế hoạch
				//WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(decimal.Parse(m_ddl_loai_nhiem_vu.SelectedValue)
				//	, m_ddl_cong_trinh);
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		private void load_data_cong_trinh_du_an_giao_kh_to_ddl(DropDownList op_ddl, WebformControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_quyet_dinh.Value.Trim().Equals("") | m_hdf_id_quyet_dinh.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
				DateTime v_dat_dau_nam = v_us_quyet_dinh.datNGAY_THANG;
				v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				WebformControls.load_data_to_cbo_du_an_cong_trinh_from_giao_kh(ip_loai_du_an
					, op_ddl);
			}
		}

		protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
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

        protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e) {
			const string v_c_str_header_css_class = "HeaderStyle";
            if (e.Row.RowType == DataControlRowType.Header) // If header created
			{
				GridView v_grv = (GridView)sender;
				//Tao dong 1
				if (m_ddl_don_vi.SelectedValue == Person.get_id_don_vi().ToString())
				WebformFunctions.addHeaderRow_to_grid_view(v_grv
					,0
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("Xoá",2,1)
						,new CellInfoHeader("Nhiệm vụ chi",1,1)
						,new CellInfoHeader("Kế hoạch chi",1,1)
						,new CellInfoHeader("Còn thiếu so với kế hoạch",1,1)
						,new CellInfoHeader("Kinh phí đã nhận kỳ này",1,1)
						,new CellInfoHeader("Tổng kinh phí đã nhận",1,1)
						
				});
				else WebformFunctions.addHeaderRow_to_grid_view(v_grv
					, 0
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("Nhiệm vụ chi",1,1)
						,new CellInfoHeader("Kế hoạch chi",1,1)
						,new CellInfoHeader("Còn thiếu so với kế hoạch",1,1)
						,new CellInfoHeader("Kinh phí đã nhận kỳ này",1,1)
						,new CellInfoHeader("Tổng kinh phí đã nhận",1,1)
						
				});
				//GridView ProductGrid = (GridView)sender;
				// Creating a Row
				//GridViewRow HeaderRow = new GridViewRow(0,0, DataControlRowType.Header, DataControlRowState.Insert);

				//Adding  Xoa
				//TableHeaderCell HeaderCell ;
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Xóa";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.RowSpan = 1;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding  Nội dung
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Nhiệm vụ chi";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding  Kế hoạch(dự toán) được chi cả năm
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Kế hoạch chi";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding Kinh phí đã nhân
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Còn thiếu so với kế hoạch";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding Kinh phí đã chi
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Kinh phí đã nhận kì này";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding 
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Số kinh phí chưa giải ngân";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.RowSpan = 2; // For merging three columns (tso, chitx)
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//Adding 
				//HeaderCell = new TableHeaderCell();
				//HeaderCell.Text = "Tổng kinh phí đã nhận";
				//HeaderCell.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell.CssClass = "HeaderStyle";
				//HeaderRow.Cells.Add(HeaderCell);

				//ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }

	}
}