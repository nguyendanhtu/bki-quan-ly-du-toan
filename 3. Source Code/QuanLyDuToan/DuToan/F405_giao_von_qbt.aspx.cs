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
	public partial class F405_giao_von_qbt : System.Web.UI.Page
	{
		#region Public Interface
		public string format_so_tien(string ip_str_so_tien)
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

		#region Private Methods

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
			m_txt_ngay_thang.Enabled = false;
			m_cmd_luu_qd.Visible = false;
		}
		private void load_data_to_grid()
		{
			DS_GRID_GIAO_VON v_ds = new DS_GRID_GIAO_VON();
			US_GRID_GIAO_VON v_us = new US_GRID_GIAO_VON();
			DateTime v_dat_now=DateTime.Now;
			decimal v_dc_id_quyet_dinh = -1;
			if (m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
			{
				v_dc_id_quyet_dinh = -1;
			}
			else
			{
				v_dc_id_quyet_dinh = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
				US_GD_QUYET_DINH v_us_qd = new US_GD_QUYET_DINH(v_dc_id_quyet_dinh);
				v_dat_now = v_us_qd.datNGAY_THANG;
			}

			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);


			v_us.get_grid_giao_von_qbt(v_ds, v_dc_id_quyet_dinh, Person.get_id_don_vi(), v_dat_dau_nam, v_dat_cuoi_nam);
			m_grv.DataSource = v_ds.Tables[0];
			m_grv.DataBind();
			if (!m_hdf_id_giao_kh.Value.Equals(""))
			{
				m_grv.SelectedIndex = -1;
				for (int i = 0; i < m_grv.Rows.Count; i++)
					if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
			}
			// WinFormControls.get_cout_grid_row(m_lbl_grid_title, "Chi tiết giao vốn", v_ds.V_GD_GIAO_VON.Count);
		}
		//private void get_so_tien_kh_giao()
		//{
		//	if (m_hdf_id_quyet_dinh.Value.Trim().Equals("")) return;
		//	US_GD_QUYET_DINH v_us_quyet_dinh = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
		//	decimal v_dc_tong_tien_ctx = 0;
		//	decimal v_dc_tong_tien_cktx = 0;
		//	v_dc_tong_tien_ctx = WinFormControls.getTongTienKH(v_us_quyet_dinh.datNGAY_THANG, "N", ID_LOAI_DU_AN.QUOC_LO);
		//	v_dc_tong_tien_cktx = WinFormControls.getTongTienKH(v_us_quyet_dinh.datNGAY_THANG, "N", ID_LOAI_DU_AN.KHAC);
		//	m_hdf_ctx_so_tien_kh_giao.Value = CIPConvert.ToStr(v_dc_tong_tien_ctx);
		//	m_hdf_cktx_so_tien_kh_giao.Value = CIPConvert.ToStr(v_dc_tong_tien_cktx);

		//	m_lbl_ctx_so_tien_kh_giao.Text = CIPConvert.ToStr(v_dc_tong_tien_ctx, "#,###,##");
		//	m_lbl_cktx_so_tien_KH_giao.Text = CIPConvert.ToStr(v_dc_tong_tien_cktx, "#,###,##");
		//}
		private void set_inital_form_mode()
		{
			xoa_trang();
			load_data_to_cbo_quyet_dinh();
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
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_quyet_dinh.Value = "";
			//m_hdf_id_du_an.Value = "";

			

			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";

			
		}
		
		private void delete_dm_han_muc_by_ID()
		{
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			load_data_to_grid();
			m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
		}

		#endregion

		#region Event
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
			try
			{
				if (m_ddl_quyet_dinh.SelectedValue == null) return;
				m_ddl_quyet_dinh.Visible = false;
				m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;

				m_txt_so_qd.Visible = true;
				m_txt_noi_dung.Visible = true;
				m_txt_ngay_thang.Visible = true;

				disable_edit_quyet_dinh();
				US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
				m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
				m_txt_noi_dung.Text = v_us.strNOI_DUNG;
				m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

				//get_so_tien_kh_giao();
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
			m_cmd_luu_qd.Visible = true;

			m_txt_so_qd.Visible = true;
			m_txt_noi_dung.Visible = true;
			m_txt_ngay_thang.Visible = true;

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
			v_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_VON;
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
			//get_so_tien_kh_giao();
			load_data_to_grid();
		}

		
		



		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton m_lbl_delete = (LinkButton)e.Row.FindControl("m_lbl_delete");
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
					set_form_mode(LOAI_FORM.SUA);
					
				}
				else if (e.CommandName == "Xoa")
				{
					m_lbl_mess_grid.Text = "";
					set_form_mode(LOAI_FORM.XOA);
					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					if (!check_validate_is_ok("")) return;
					delete_dm_han_muc_by_ID();
				}
			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
			}

		}


		#endregion
	}
}