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
	public partial class F404_nhap_khoi_luong : System.Web.UI.Page
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


		private void load_data_to_grid()
		{
			m_lbl_mess_qd.Text = "";
			decimal v_dc_id_quyet_dinh = -1;
	
			var v_id_loai_nv = string.IsNullOrEmpty(m_ddl_loai_nhiem_vu.SelectedValue) ? -1 : CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);
	
			load_data_to_grid(v_dc_id_quyet_dinh, v_id_loai_nv, -1, -1);
		}

		private void load_data_to_grid(decimal ip_id_quyet_dinh, decimal ip_id_loai_nhiem_vu = -1,
			decimal ip_id_cong_trinh = -1, decimal ip_id_du_an = -1)
		{
			if (!CValidateTextBox.IsValid(m_txt_ngay_thang, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập ngày tháng (dd/MM/yyyy)";
				return;
			}
			var v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy"); ;
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
			US_GD_KHOI_LUONG v_us_khoi_luong = new US_GD_KHOI_LUONG();
			v_us_khoi_luong.update_noi_dung_chi_from_giao_kh_sang_khoi_luong(
				v_dat_dau_nam
				, v_dat_cuoi_nam
				, v_dat_now
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));

			//2. Load data tu grid_giao_von len luoi de sua thong tin
			DS_GRID_GIAO_VON v_ds = new DS_GRID_GIAO_VON();
			US_GRID_GIAO_VON v_us = new US_GRID_GIAO_VON();

			v_us.get_grid_khoi_luong(
				v_ds
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
				, v_dat_now
				, CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue));

			m_grv.DataSource = v_ds.Tables[0];
			m_grv.DataBind();
			//an nut cap nhat neu khong phai la don vi duoc sua du lieu
			if (m_ddl_don_vi.SelectedValue != Person.get_id_don_vi().ToString())
			{
				m_cmd_cap_nhat.Visible = false;
				m_cmd_xoa_trang.Visible = false;
			}
			else
			{
				m_cmd_cap_nhat.Visible = true;
				m_cmd_xoa_trang.Visible = true;
			}
		}
		private void set_inital_form_mode()
		{
			//load dropdownlist danh sach don vi ma don vi X duoc xem du lieu
			WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
				Person.get_id_don_vi()
				, m_ddl_don_vi);
			xoa_trang();
			load_data_to_cbo();
			load_data_to_grid();
		}
		private void xoa_trang()
		{
			m_grv.SelectedIndex = -1;

			m_hdf_id_giao_kh.Value = "";

		}
		private void save_data_in_grid(GridView ip_grv)
		{
			GridViewRow[] v_arr_gvr = new GridViewRow[ip_grv.Rows.Count];
			System.Web.UI.WebControls.TextBox v_txt_so_chua_giai_ngan_cho_nha_thau;
			System.Web.UI.WebControls.TextBox v_txt_gia_tri_thuc_hien_da_nghiem_thu;
			LinkButton v_lb_id_gd;

			ip_grv.Rows.CopyTo(v_arr_gvr, 0);

			for (int i = 0; i < v_arr_gvr.Length; i++)
			{
				//1. Duyet tung dong cua gridview, lay du lieu tu textbox
				v_txt_gia_tri_thuc_hien_da_nghiem_thu = (System.Web.UI.WebControls.TextBox)v_arr_gvr[i].FindControl("m_txt_so_tien_ngan_sach_grid");
				v_txt_so_chua_giai_ngan_cho_nha_thau = (System.Web.UI.WebControls.TextBox)v_arr_gvr[i].FindControl("m_txt_so_tien_quy_bao_tri_grid");
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
						US_GD_KHOI_LUONG v_us = new US_GD_KHOI_LUONG(CIPConvert.ToDecimal(v_lb_id_gd.CommandArgument.ToString()));
						v_us.dcSO_TIEN_DA_NGHIEM_THU = WinFormControls.get_so_tien(v_txt_gia_tri_thuc_hien_da_nghiem_thu.Text);
						v_us.dcSO_TIEN_CHUA_GIAI_NGAN = WinFormControls.get_so_tien(v_txt_so_chua_giai_ngan_cho_nha_thau.Text);
						v_us.Update();
					}
					catch (Exception)
					{
						m_lbl_mess_grid.Text = "Đã có lỗi xảy ra, Xin vui lòng thực hiện lại thao tác";
						m_lbl_mess_grid.Focus();
						return;
					}

				}
			}
			m_lbl_mess_grid.Text = "Đã ghi dữ liệu thành công!";

			load_data_to_grid();
			m_lbl_mess_grid.Focus();
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
			//WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_VON, m_ddl_quyet_dinh);
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu);

		}



		#endregion

		//# Event...
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
					load_data_to_cbo();
					set_inital_form_mode();
					if (Request.QueryString["ip_dc_id_quyet_dinh"] != null)
					{
						//decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_quyet_dinh"]);


					}
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

				}
				else if (e.CommandName == "Xoa")
				{
					m_lbl_mess_grid.Text = "";
					//set_form_mode(LOAI_FORM.XOA);
					//m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					//if (!check_validate_is_ok("")) return;
					////delete_dm_han_muc_by_ID();
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

		protected void m_cmd_xem_khoi_luong_Click(object sender, EventArgs e)
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



	}
}