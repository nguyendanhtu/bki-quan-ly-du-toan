﻿using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;

public partial class BaoCao_F601_bao_cao_tinh_hinh_giai_ngan : System.Web.UI.Page
{
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
	protected void Page_Load(object sender, EventArgs e)
	{
		if (!IsPostBack)
		{
			//if (check_validate_data_is_ok())
			//{
			//	load_data_to_grid();
			//}
		}
	}

	private void load_data_to_grid()
	{
		US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
		DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
		v_us.bc_tinh_hinh_giai_ngan(v_ds
			, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
			, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
			, Person.get_id_don_vi());
		m_grv.DataSource = v_ds.RPT_BC_TINH_HINH_GIAI_NGAN;
		m_grv.DataBind();

	}
	private bool check_validate_data_is_ok()
	{
		if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
		{
			m_lbl_mess.Text = "Bạn phải nhập Từ ngày, dạng dd/MM/yyyy";
			m_txt_tu_ngay.Focus();
			return false;
		}
		if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
		{
			m_lbl_mess.Text = "Bạn phải nhập Đến ngày, dạng dd/MM/yyyy";
			m_txt_den_ngay.Focus();
			return false;
		}

		return true;
	}
	protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
	{
		try
		{
			if (check_validate_data_is_ok())
			{
				load_data_to_grid();
			}
		}
		catch (Exception v_e)
		{
			m_lbl_mess.Text = v_e.ToString();
		}

	}
}