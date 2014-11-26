using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.WinFormControls;

public partial class DuToan_F409_giao_von_ns : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

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
		//reload_data_to_ddl();
		//load_data_to_grid();
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

		//reload_data_to_ddl();
		//load_data_to_grid();
	}
}