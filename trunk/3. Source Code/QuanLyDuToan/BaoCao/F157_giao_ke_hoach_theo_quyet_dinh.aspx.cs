﻿using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.BaoCao
{
	public partial class F157_giao_ke_hoach_theo_quyet_dinh : System.Web.UI.Page
	{
		#region Public Functions
		//Chua cac ham convert su dung trong file aspx cua form nay
		#endregion

		#region Data Structures
		//Chua kieu du lieu dinh nghia o form nay
		#endregion

		#region Members
		//Khai bao bien toan cuc
		#endregion

		#region Private Methods
		//Chua phuong thuc co muc truy cap private cua form nay
		private void set_inital_form_load()
		{
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			decimal v_dc_id_loai_nhiem_vu;
			decimal v_id_dc_id_cong_trinh = -1;
			decimal v_id_dc_id_du_an = -1;

			//load ngay thang theo query string
			m_txt_tu_ngay.Text = CIPConvert.ToStr(
				WebformFunctions.getValue_from_query_string(
				this
				, FormInfo.QueryString.TU_NGAY
				, CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy")
				, DataType.DateType), "dd/MM/yyyy");
			m_txt_den_ngay.Text = CIPConvert.ToStr(
				WebformFunctions.getValue_from_query_string(
				this
				, FormInfo.QueryString.DEN_NGAY
				, CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy")
				, DataType.DateType), "dd/MM/yyyy");


			v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(WebformFunctions.getValue_from_query_string(
				this
				, FormInfo.QueryString.ID_LOAI_NHIEM_VU
				, -1
				, DataType.NumberType));

			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_id_dc_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
			}
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_id_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
			}
			//load dropdownlisst
			//đơn vị
			load_data_2_ddl_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				var v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
				m_ddl_don_vi.SelectedValue = v_dc_id_don_vi.ToString();
			}
			//loại nhiệm vụ
			App_Code.WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(v_dc_id_loai_nhiem_vu);

			//loại công trình
			App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
				CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_ddl_cong_trinh
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(v_id_dc_id_cong_trinh);

			//loại dự án
			App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
				CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_ddl_du_an
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));

			m_ddl_du_an.SelectedValue = CIPConvert.ToStr(v_id_dc_id_du_an);
			load_data_2_ddl_quyet_dinh();
			load_data_to_grid();
		}
		private void load_data_to_grid()
		{
			BoundField field = (BoundField)this.m_grv.Columns[2];
			string v_str_nguon_ns = "N";
			if (Request.QueryString["ip_nguon_ns"] != null)
			{
				if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
				{
					field.HeaderText = "Kinh phí Ngân sách";
					v_str_nguon_ns = "Y";
				}
				else
				{
					field.HeaderText = "Kinh phí Quỹ bảo trì";
					v_str_nguon_ns = "N";
				}

			}
			else
			{
				field.HeaderText = "Kinh phí Quỹ bảo trì";
				v_str_nguon_ns = "N";
			}
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);
			v_ds.AcceptChanges();
			v_ds.EnforceConstraints = false;
			new US_V_GD_GIAI_NGAN_QBT().FillData2Dataset(
				v_ds,
				CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
				CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
				CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
				CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue.Trim() == "" ? "-1" : m_ddl_loai_nv.SelectedValue.Trim()),
				CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue.Trim() == "" ? "-1" : m_ddl_cong_trinh.SelectedValue.Trim()),
				CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue.Trim() == "" ? "-1" : m_ddl_du_an.SelectedValue.Trim()),
				m_txt_tim_kiem.Text.Trim(),
				v_str_nguon_ns,
				CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue),
				"pr_F157_giao_ke_hoach_theo_quyet_dinh");
			m_grv.DataSource = v_ds.Tables[0];
			m_grv.DataBind();
		}
		private void load_data_2_ddl_quyet_dinh()
		{
			WinFormControls.load_data_to_cbo_quyet_dinh(118, -1, -1, -1,
				CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
				CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
				m_txt_tim_kiem.Text.Trim(),
				WinFormControls.eTAT_CA.YES,
				"pr_A190_danh_sach_quyet_dinh_giao_kh",
				m_ddl_quyet_dinh);
		}
		private void load_data_2_ddl_don_vi()
		{
			decimal id_dc_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				id_dc_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(id_dc_don_vi, m_ddl_don_vi);
		}
		#endregion

		#region Events
		//Cac su kien cua form nay
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				set_inital_form_load();
			}
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
					CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
					, m_ddl_cong_trinh
					, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
				m_ddl_cong_trinh_SelectedIndexChanged(null, null);
			}
			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
					CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
					, m_ddl_du_an
					, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			}
			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
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

		protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
		{
			load_data_to_grid();
		}
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
				WinformReport.export_gridview_2_excel(
				m_grv, "[" + v_us.strTEN_DON_VI + "]BaoCaoTinhHinhGiaoKeHoach.xls");
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
			
		}

		protected void m_txt_tu_ngay_TextChanged(object sender, EventArgs e)
		{
			load_data_2_ddl_quyet_dinh();
		}
		protected void m_txt_den_ngay_TextChanged(object sender, EventArgs e)
		{
			load_data_2_ddl_quyet_dinh();
		}
		#endregion
	}
}