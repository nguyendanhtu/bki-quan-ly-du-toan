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
	public partial class f204_nhap_giao_ke_hoach_qbt : System.Web.UI.Page
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
		private void reload_data_to_ddl()
		{
			if (m_rdb_kh_dau_nam.Checked == true)
			{
				m_txt_ten_du_an.Visible = true;
				m_ddl_du_an.Visible = false;
				m_txt_ten_du_an.Enabled = true;
				m_txt_ten_du_an.Text = "";
				m_hdf_id_du_an.Value = "";
				load_data_to_cbo_quoc_lo();
				load_data_to_du_an();
			}
			else
			{
				m_txt_ten_du_an.Visible = false;
				m_ddl_du_an.Visible = true;
				load_data_cong_trinh_du_an_giao_kh_to_ddl(m_ddl_du_an, WinFormControls.LOAI_DU_AN.KHAC);
				load_data_cong_trinh_du_an_giao_kh_to_ddl(m_ddl_tuyen_quoc_lo, WinFormControls.LOAI_DU_AN.QUOC_LO);
			}
		}
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
					m_lbl_mess_grid.Text = "Bạn không thể xoá bản ghi này, dữ liệu này đang được sử dụng!";
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
					if (m_txt_ctx_so_tien_ns.Text == "")
					{
						m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
						m_txt_ctx_so_tien_ns.Focus();
						v_b_result = false;
					}
					if (m_ddl_tuyen_quoc_lo.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text += "\n Bạn phải chọn Tuyến quốc lộ!";
						m_ddl_tuyen_quoc_lo.Focus();
						v_b_result = false;
					}
					if (!CValidateTextBox.IsValid(m_txt_ctx_noi_dung, DataType.StringType, allowNull.NO))
					{
						m_lbl_mess_detail.Text += "\n Bạn phải Nhập nội dung!";
						m_txt_ctx_noi_dung.Focus();
						v_b_result = false;
					}
				}
				else if (ip_str_ctx_yn.Trim().ToUpper() == "N")
				{
					if (m_txt_ten_du_an.Text == "")
					{
						m_lbl_mess_detail.Text += "\n Bạn phải nhập Tên dự án!";
						m_txt_ten_du_an.Focus();
						v_b_result = false;
					}
					if (m_txt_cktx_so_tien_ns.Text == "")
					{
						m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
						m_txt_cktx_so_tien_ns.Focus();
						v_b_result = false;
					}
					if (!CValidateTextBox.IsValid(m_txt_cktx_noi_dung, DataType.StringType, allowNull.NO))
					{
						m_lbl_mess_detail.Text += "\n Bạn phải Nhập nội dung!";
						m_txt_cktx_noi_dung.Focus();
						v_b_result = false;
					}
				}

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
			else if (m_rdb_dieu_chinh.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.DIEU_CHINH;
			else if (m_rdb_bo_sung.Checked == true) m_us.dcID_LOAI_GIAO_DICH = ID_LOAI_GIAO_DICH.BO_SUNG;
			m_us.strIS_NGUON_NS_YN = "N";//Nguon mac dinh la Quy bao tri
			if (ip_str_ctx_yn.Trim().ToUpper() == "Y")
			{
				m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_tuyen_quoc_lo.SelectedValue);
				m_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_ctx_so_tien_ns.Text.Trim());
                m_us.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_ctx_so_tien_qbt.Text.Trim());
				m_us.strGHI_CHU = m_txt_ctx_noi_dung.Text;
			}
			else
			{
				m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue);
				m_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_cktx_so_tien_ns.Text.Trim());
                m_us.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_cktx_so_tien_qbt.Text.Trim());
				m_us.strGHI_CHU = m_txt_cktx_noi_dung.Text;
			}
			m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			m_us.dcID_DON_VI = Person.get_id_don_vi();
			m_us.SetID_CHUONGNull();
			m_us.SetID_KHOANNull();
			m_us.SetID_MUCNull();
			m_us.SetID_TIEU_MUCNull();
		}
		private void us_object_to_form()
		{
			m_us = new US_GD_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			US_DM_DU_AN_CONG_TRINH v_us_du_an_cong_trinh = new US_DM_DU_AN_CONG_TRINH(m_us.dcID_DU_AN_CONG_TRINH);
			if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
			{
				m_ddl_tuyen_quoc_lo.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
				m_txt_ctx_so_tien_ns.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NS);
                m_txt_ctx_so_tien_qbt.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_QUY_BT);
				m_txt_ctx_noi_dung.Text = m_us.strGHI_CHU;

			}
			else
			{
				m_ddl_du_an.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
				m_txt_ten_du_an.Text = m_ddl_du_an.SelectedItem.Text;
				m_txt_cktx_so_tien_ns.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NS);
                m_txt_cktx_so_tien_qbt.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_QUY_BT);
				m_ddl_du_an.Visible = true;
				m_txt_ten_du_an.Visible = false;
				m_txt_cktx_noi_dung.Text = m_us.strGHI_CHU;

			}
			//set quyet dinh
			US_GD_QUYET_DINH v_us_quyet_dinh = new US_GD_QUYET_DINH(m_us.dcID_QUYET_DINH);
			m_txt_so_qd.Text = v_us_quyet_dinh.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us_quyet_dinh.strNOI_DUNG;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
			m_hdf_id_quyet_dinh.Value = v_us_quyet_dinh.dcID.ToString();

			disable_edit_quyet_dinh();

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
			try
			{
				DS_V_GD_GIAO_KH v_ds = new DS_V_GD_GIAO_KH();
				US_V_GD_GIAO_KH v_us = new US_V_GD_GIAO_KH();
				if (!m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
				{
					v_us.FillDataset(v_ds, "where id_quyet_dinh=" + m_hdf_id_quyet_dinh.Value +
						" and id_don_vi=" + Person.get_id_don_vi() +
						"and is_nguon_ns_yn='N'");
				}
				DataSet v_ds_tree_new = get_tree_dataset(v_ds);
				m_grv.DataSource = v_ds_tree_new.Tables[0];
				m_grv.DataBind();
				if (!m_hdf_id_giao_kh.Value.Equals(""))
				{
					m_grv.SelectedIndex = -1;
					for (int i = 0; i < m_grv.Rows.Count; i++)
						if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
				}
				//WinFormControls.get_cout_grid_row(m_lbl_grid_title, "Chi tiết giao kế hoạch", v_ds.V_GD_GIAO_KH.Count);

			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
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
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_quyet_dinh.Value = "";
			//m_hdf_id_du_an.Value = "";

			m_txt_ctx_so_tien_ns.Text = "";
			m_txt_cktx_so_tien_ns.Text = "";

			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";

			m_cmd_ctx_update.Visible = false;
			m_cmd_ctx_insert.Visible = true;

			m_txt_cktx_noi_dung.Text = "";
			m_txt_ctx_noi_dung.Text = "";

			m_cmd_cktx_update.Visible = false;
			m_cmd_cktx_insert.Visible = true;

		}
		private void save_data(string ip_str_ctx_yn)
		{
			m_lbl_mess_detail.Text = "";
			if (!check_validate_is_ok(ip_str_ctx_yn)) return;
			form_to_us_object(ip_str_ctx_yn);

			switch (get_form_mode(m_hdf_form_mode))
			{
				case LOAI_FORM.THEM:
					if (ip_str_ctx_yn == "N")
					{
						if (insert_du_an())
						{
							m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_hdf_id_du_an.Value);
							m_us.Insert();
						}
					}
					else
						m_us.Insert();
					m_lbl_mess_detail.Text = "Bạn đã tạo mới thành công!";
					break;
				case LOAI_FORM.SUA:
					m_us.Update();
					m_lbl_mess_detail.Text = "Bạn đã cập nhật thành công!";
					break;
			}
			xoa_trang();
			m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			m_ddl_du_an.SelectedValue = "-1";
			load_data_to_grid();
		}
		private void delete_dm_han_muc_by_ID()
		{
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			load_data_to_grid();
			m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
		}
		private bool insert_du_an()
		{
			bool v_b_result = false;
			try
			{
				US_DM_DU_AN_CONG_TRINH v_us = new US_DM_DU_AN_CONG_TRINH();
				v_us.dcID_DON_VI = Person.get_id_don_vi();
				v_us.dcID_LOAI_DU_AN_CONG_TRINH = ID_LOAI_DU_AN.KHAC;
				v_us.strGHI_CHU = "";
				v_us.strTEN_DU_AN_CONG_TRINH = m_txt_ten_du_an.Text.Trim();
				v_us.Insert();
				m_hdf_id_du_an.Value = v_us.dcID.ToString();
				v_b_result = true;
			}
			catch (Exception)
			{
				v_b_result = false;
			}
			return v_b_result;
		}
		private DataSet get_tree_dataset(DS_V_GD_GIAO_KH ip_ds)
		{
			DataSet op_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_dt.Columns.Add(V_GD_GIAO_KH.ID);
			v_dt.Columns.Add(V_GD_GIAO_KH.DISPLAY);
			v_dt.Columns.Add(V_GD_GIAO_KH.SO_TIEN);
			v_dt.Columns.Add(V_GD_GIAO_KH.TEN);
			v_dt.Columns.Add(V_GD_GIAO_KH.GHI_CHU);
			op_ds.Tables.Add(v_dt);
			op_ds.AcceptChanges();

			//chi thuong xuyen
			DataRow v_dr_chi_tx = v_dt.NewRow();
			v_dr_chi_tx[V_GD_GIAO_KH.ID] = "-1";
			v_dr_chi_tx[V_GD_GIAO_KH.DISPLAY] = "I - Chi thường xuyên";
			v_dr_chi_tx[V_GD_GIAO_KH.SO_TIEN] = "-1";
			v_dr_chi_tx[V_GD_GIAO_KH.TEN] = "";
			v_dr_chi_tx[V_GD_GIAO_KH.GHI_CHU] = "";
			op_ds.Tables[0].Rows.Add(v_dr_chi_tx);
			op_ds.AcceptChanges();
			for (int i = 0; i < ip_ds.V_GD_GIAO_KH.Count; i++)
			{
				if (CIPConvert.ToDecimal(ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.ID_LOAI_DU_AN_CONG_TRINH]) == ID_LOAI_DU_AN.QUOC_LO)
				{
					DataRow v_dr = v_dt.NewRow();
					v_dr[V_GD_GIAO_KH.ID] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.ID].ToString();
					v_dr[V_GD_GIAO_KH.DISPLAY] = ".............." + ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.DISPLAY].ToString();
					v_dr[V_GD_GIAO_KH.SO_TIEN] = CIPConvert.ToStr(ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.SO_TIEN], "#,###,##");
					v_dr[V_GD_GIAO_KH.TEN] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.TEN].ToString();
					v_dr[V_GD_GIAO_KH.GHI_CHU] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.GHI_CHU].ToString();
					op_ds.Tables[0].Rows.Add(v_dr);
					op_ds.AcceptChanges();
				}

			}
			//chi khong thuong xuyen
			DataRow v_dr_chi_ktx = v_dt.NewRow();
			v_dr_chi_ktx[V_GD_GIAO_KH.ID] = "-1";
			v_dr_chi_ktx[V_GD_GIAO_KH.DISPLAY] = "II - Chi không thường xuyên";
			v_dr_chi_ktx[V_GD_GIAO_KH.SO_TIEN] = "-1";
			v_dr_chi_ktx[V_GD_GIAO_KH.TEN] = "";
			op_ds.Tables[0].Rows.Add(v_dr_chi_ktx);
			op_ds.AcceptChanges();
			for (int i = 0; i < ip_ds.V_GD_GIAO_KH.Count; i++)
			{
				if (CIPConvert.ToDecimal(ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.ID_LOAI_DU_AN_CONG_TRINH]) == ID_LOAI_DU_AN.KHAC)
				{
					DataRow v_dr = v_dt.NewRow();
					v_dr[V_GD_GIAO_KH.ID] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.ID].ToString();
					v_dr[V_GD_GIAO_KH.DISPLAY] = ".............." + ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.DISPLAY].ToString();
					v_dr[V_GD_GIAO_KH.SO_TIEN] = CIPConvert.ToStr(ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.SO_TIEN], "#,###,##");
					v_dr[V_GD_GIAO_KH.TEN] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.TEN].ToString();
					v_dr[V_GD_GIAO_KH.GHI_CHU] = ip_ds.Tables[0].Rows[i][V_GD_GIAO_KH.GHI_CHU].ToString();
					op_ds.Tables[0].Rows.Add(v_dr);
					op_ds.AcceptChanges();
				}

			}

			return op_ds;
		}

		public string format_so_tien(string ip_str_so_tien)
		{
			string op_str_so_tien = "";
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_str_so_tien = "";
			}
			else op_str_so_tien = CIPConvert.ToStr(ip_str_so_tien, "#,###,##");
			return op_str_so_tien;
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
		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			if (e.Row.RowType == DataControlRowType.DataRow)
			{
				LinkButton m_lbl_delete = (LinkButton)e.Row.FindControl("m_lbl_delete");
				LinkButton m_lbl_update = (LinkButton)e.Row.FindControl("m_lbl_update");
				if (m_lbl_delete != null)
				{
					if (m_lbl_delete.CommandArgument.Trim().Equals("-1"))
					{
						m_lbl_delete.Visible = false;
					}
					else
					{
						m_lbl_delete.Visible = true;
					}
				}
				if (m_lbl_update != null)
				{
					if (m_lbl_update.CommandArgument.Trim().Equals("-1"))
					{
						m_lbl_update.Visible = false;
					}
					else
					{
						m_lbl_update.Visible = true;
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
					//format button by form mode - update
					m_cmd_ctx_update.Visible = true;
					m_cmd_cktx_update.Visible = true;
					m_cmd_ctx_insert.Visible = false;
					m_cmd_cktx_insert.Visible = false;
					//reset control
					m_ddl_du_an.SelectedValue = "-1";
					m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
					m_txt_cktx_so_tien_ns.Text = "";
					m_txt_ctx_so_tien_ns.Text = "";

					//set select row in gridview
					GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
					m_grv.SelectedIndex = gvr.RowIndex;

					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					//m_grv.SelectedIndex = m_grv.SelectedRow.RowIndex;
					set_form_mode(LOAI_FORM.SUA);
					us_object_to_form();
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

		protected void m_cmd_ctx_insert_Click(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_detail.Text = "";
				set_form_mode(LOAI_FORM.THEM);
				save_data("Y");

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
				m_lbl_mess_detail.Text = "";
				set_form_mode(LOAI_FORM.SUA);
				save_data("Y");
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
				m_lbl_mess_detail.Text = "";
				m_lbl_mess_qd.Text = "";
				xoa_trang();
				m_txt_ctx_so_tien_ns.Text = "";
				m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
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
				m_lbl_mess_detail.Text = "";
				set_form_mode(LOAI_FORM.THEM);
				save_data("N");
				m_txt_ten_du_an.Text = "";
				m_txt_cktx_so_tien_ns.Text = "";
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
				m_lbl_mess_detail.Text = "";
				set_form_mode(LOAI_FORM.SUA);
				save_data("N");
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
				m_lbl_mess_qd.Text = "";
				m_txt_ten_du_an.Text = "";
				m_txt_ten_du_an.Enabled = true;
				m_txt_ten_du_an.Visible = true;
				m_ddl_du_an.Visible = false;
				m_txt_cktx_so_tien_ns.Text = "";

				m_hdf_id_du_an.Value = "";
				xoa_trang();
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

			reload_data_to_ddl();

		}
		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
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

			reload_data_to_ddl();
			load_data_to_grid();
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

			reload_data_to_ddl();
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

			reload_data_to_ddl();
			load_data_to_grid();
		}

		protected void m_cmd_chon_du_an_Click(object sender, EventArgs e)
		{
			m_hdf_id_du_an.Value = m_ddl_du_an.SelectedValue;
			m_txt_ten_du_an.Visible = false;
			load_data_to_du_an();
			m_ddl_du_an.Visible = true;
		}
		protected void m_rdb_kh_dau_nam_CheckedChanged(object sender, EventArgs e)
		{
			reload_data_to_ddl();
		}
		protected void m_rdb_bo_sung_CheckedChanged(object sender, EventArgs e)
		{
			reload_data_to_ddl();
		}
		protected void m_rdb_dieu_chinh_CheckedChanged(object sender, EventArgs e)
		{
			reload_data_to_ddl();
		}
		#endregion
	}
}