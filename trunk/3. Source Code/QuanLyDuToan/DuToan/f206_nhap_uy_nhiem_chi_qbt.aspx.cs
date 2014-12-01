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
using System.Data;

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
		if (m_txt_so_tien_thanh_toan_cho_dv_huong.Text.Trim().Equals(""))
		{
			m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
			m_txt_so_tien_thanh_toan_cho_dv_huong.Focus();
			v_b_result = false;
		}
		decimal v_dc_so_tien = 0;
		try
		{
			v_dc_so_tien = CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan_cho_dv_huong.Text.Trim());
		}
		catch (Exception)
		{
			m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
			v_b_result = false;
			m_txt_so_tien_thanh_toan_cho_dv_huong.Focus();
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
		m_us.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(m_txt_so_tien_nop_thue.Text.Trim());
		m_us.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan_cho_dv_huong.Text.Trim());
		m_us.dcID_UNC = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
		m_us.dcID_DON_VI = Person.get_id_don_vi();
		//set null nguon ns
		m_us.SetID_MUCNull();
		m_us.SetID_KHOANNull();
		m_us.SetID_CHUONGNull();
		m_us.SetID_TIEU_MUCNull();
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
		m_txt_so_tien_nop_thue.Text = m_us.dcSO_TIEN_NOP_THUE.ToString();
		m_txt_so_tien_thanh_toan_cho_dv_huong.Text = m_us.dcSO_TIEN_TT_CHO_DV_HUONG.ToString();
		m_txt_ghi_chu.Text = m_us.strNOI_DUNG;
		//set quyet dinh
		US_DM_UY_NHIEM_CHI v_us_dm_uy_nhiem_chi = new US_DM_UY_NHIEM_CHI(m_us.dcID_UNC);
		m_lbl_dia_chi.Text = v_us_dm_uy_nhiem_chi.strDIA_CHI;
		m_txt_so_unc.Text = v_us_dm_uy_nhiem_chi.strSO_UNC;
		m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_dm_uy_nhiem_chi.datNGAY_THANG, "dd/MM/yyyy");
		m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_dm_uy_nhiem_chi.strKHO_BAC_NHA_NUOC;
		m_lbl_ma_tkkt.Text = v_us_dm_uy_nhiem_chi.strMA_TKKT;
		m_lbl_ma_dvqhns.Text = v_us_dm_uy_nhiem_chi.strMA_DVQHNS;
		m_txt_ma_ctmt_da_htct.Text = v_us_dm_uy_nhiem_chi.strMA_CTMT_DA_HTCT;
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
				v_us.FillDataset(v_ds, "where id_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value + " and id_don_vi=" + Person.get_id_don_vi() +
					 " and id_chuong is null");
			}
			DataSet v_ds_view = get_tree_dataset(v_ds);
			m_grv.DataSource = v_ds_view.Tables[0];
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
			m_lbl_mess_grid.Text = v_e.ToString();
		}
	}
	private DataSet get_tree_dataset(DS_V_GD_UY_NHIEM_CHI ip_ds)
	{
		DataSet op_ds = new DataSet();
		DataTable v_dt = new DataTable();
		v_dt.Columns.Add(V_GD_UY_NHIEM_CHI.ID);
		v_dt.Columns.Add(V_GD_UY_NHIEM_CHI.DISPLAY);
		v_dt.Columns.Add(V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE);
		v_dt.Columns.Add(V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG);
		v_dt.Columns.Add("TONG_SO_TIEN");
		v_dt.Columns.Add(V_GD_UY_NHIEM_CHI.NOI_DUNG);
		op_ds.Tables.Add(v_dt);
		op_ds.AcceptChanges();
		//chi khong thuong xuyen
		DataRow v_dr_chi_ktx = v_dt.NewRow();
		v_dr_chi_ktx[V_GD_UY_NHIEM_CHI.ID] = "-1";
		v_dr_chi_ktx[V_GD_UY_NHIEM_CHI.DISPLAY] = "I - Chi không thường xuyên";
		v_dr_chi_ktx[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = "";
		v_dr_chi_ktx[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = "";
		v_dr_chi_ktx["TONG_SO_TIEN"] = "";
		op_ds.Tables[0].Rows.Add(v_dr_chi_ktx);
		op_ds.AcceptChanges();
		for (int i = 0; i < ip_ds.V_GD_UY_NHIEM_CHI.Count; i++)
		{
			if (CIPConvert.ToDecimal(ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.ID_LOAI_DU_AN_CONG_TRINH]) == ID_LOAI_DU_AN.KHAC)
			{
				DataRow v_dr = v_dt.NewRow();
				v_dr[V_GD_UY_NHIEM_CHI.ID] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.ID].ToString();
				v_dr[V_GD_UY_NHIEM_CHI.DISPLAY] = ".............." + ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.DISPLAY].ToString();
				if (ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] == null
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Trim() == ""
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Trim() == "0")
					v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = "0";
				else v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = CIPConvert.ToStr(ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE], "#,###,##");
				if (ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] == null
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Trim() == ""
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Trim() == "0")
					v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = "0";
				else v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString();
				if (v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG]=="0"&& v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE]=="0")
				{
					v_dr["TONG_SO_TIEN"]="0";
				}
				else v_dr["TONG_SO_TIEN"] = CIPConvert.ToStr(CIPConvert.ToDecimal(v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Replace(",", ""))
					+ CIPConvert.ToDecimal(v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Replace(",", "")), "#,###,##");
				v_dr[V_GD_UY_NHIEM_CHI.NOI_DUNG] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.NOI_DUNG];
				op_ds.Tables[0].Rows.Add(v_dr);
				op_ds.AcceptChanges();
			}

		}
		//chi thuong xuyen
		DataRow v_dr_chi_tx = v_dt.NewRow();
		v_dr_chi_tx[V_GD_UY_NHIEM_CHI.ID] = "-1";
		v_dr_chi_tx[V_GD_UY_NHIEM_CHI.DISPLAY] = "II - Chi thường xuyên";
		v_dr_chi_tx[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = "";
		v_dr_chi_tx[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = "";
		v_dr_chi_tx["TONG_SO_TIEN"] = "";
		op_ds.Tables[0].Rows.Add(v_dr_chi_tx);
		op_ds.AcceptChanges();
		for (int i = 0; i < ip_ds.V_GD_UY_NHIEM_CHI.Count; i++)
		{
			if (CIPConvert.ToDecimal(ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.ID_LOAI_DU_AN_CONG_TRINH]) == ID_LOAI_DU_AN.QUOC_LO)
			{
				DataRow v_dr = v_dt.NewRow();
				v_dr[V_GD_UY_NHIEM_CHI.ID] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.ID].ToString();
				v_dr[V_GD_UY_NHIEM_CHI.DISPLAY] = ".............." + ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.DISPLAY].ToString();
				if (ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] == null
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Trim() == ""
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Trim() == "0")
					v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = "0";
				else v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] = CIPConvert.ToStr(ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE], "#,###,##");
				if (ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] == null
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Trim() == ""
					| ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Trim() == "0")
					v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = "0";
				else v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString();
				if (v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG] == "0" && v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE] == "0")
				{
					v_dr["TONG_SO_TIEN"] = "0";
				}
				else v_dr["TONG_SO_TIEN"] = CIPConvert.ToStr(CIPConvert.ToDecimal(v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_NOP_THUE].ToString().Replace(",", ""))
					+ CIPConvert.ToDecimal(v_dr[V_GD_UY_NHIEM_CHI.SO_TIEN_TT_CHO_DV_HUONG].ToString().Replace(",", "")), "#,###,##");
				v_dr[V_GD_UY_NHIEM_CHI.NOI_DUNG] = ip_ds.Tables[0].Rows[i][V_GD_UY_NHIEM_CHI.NOI_DUNG];
				op_ds.Tables[0].Rows.Add(v_dr);
				op_ds.AcceptChanges();
			}

		}

		return op_ds;
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

		m_txt_so_tien_nop_thue.Text = "";
		m_txt_so_tien_thanh_toan_cho_dv_huong.Text = "";

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
		load_data_du_an_cong_trinh_by_loai();
		m_txt_so_tien_nop_thue.Text = "";
		m_txt_so_tien_thanh_toan_cho_dv_huong.Text = "";
		m_txt_ghi_chu.Text = "";
		m_cmd_ctx_insert.Visible = true;
		m_cmd_ctx_update.Visible = false;
		m_cmd_ctx_cancel.Visible = true;

		set_form_mode(LOAI_FORM.THEM);
		m_hdf_id_gd_uy_nhiem_chi.Value = "-1";
	}
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
	#endregion

	protected void Page_Load(object sender, EventArgs e)
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

	protected void m_cmd_chon_unc_Click(object sender, EventArgs e)
	{
		m_txt_so_unc.Visible = false;
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
			load_data_du_an_cong_trinh_by_loai();
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
		load_data_du_an_cong_trinh_by_loai();
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
		try
		{
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "-1" | m_hdf_id_dm_uy_nhiem_chi.Value.Trim() == "")
			{
				m_lbl_mess_detail.Text = "Bạn phải Nhập thông tin uỷ nhiệm chi hoặc Chọn UNC!";
				return;
			}
			set_form_mode(LOAI_FORM.THEM);
			save_data();
		}
		catch (Exception v_e)
		{
			m_lbl_mess_detail.Text = v_e.ToString();
		}

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
		m_grv.SelectedIndex = -1;
		m_lbl_mess_detail.Text = "";
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
				//format button by form mode - update
				m_cmd_ctx_update.Visible = true;
				m_cmd_ctx_insert.Visible = false;
				//reset control
				m_ddl_du_an.SelectedValue = "-1";
				m_ddl_quoc_lo.SelectedValue = "-1";
				m_txt_so_tien_nop_thue.Text = "";
				m_txt_so_tien_thanh_toan_cho_dv_huong.Text = "";
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

				delete_dm_han_muc_by_ID();
			}
		}
		catch (Exception v_e)
		{
			m_lbl_grid_title.Text = v_e.ToString();
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
}