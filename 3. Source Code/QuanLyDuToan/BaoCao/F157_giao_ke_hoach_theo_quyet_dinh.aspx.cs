using IP.Core.IPCommon;
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
			//1. gán liệu từ database vào combobox
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			decimal v_dc_id_loai_nhiem_vu;
			decimal v_dc_id_cong_trinh;
			decimal v_dc_id_du_an;


			//load ngay thang theo query string
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
														this
														, FormInfo.QueryString.TU_NGAY
														, CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy")
														);
			m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<String>(
														this
														, FormInfo.QueryString.DEN_NGAY
														, CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy")
														);

			//load id loai nhiem vu theo query string
			v_dc_id_loai_nhiem_vu = WebformFunctions.getValue_from_query_string<Decimal>(
														this
														, FormInfo.QueryString.ID_LOAI_NHIEM_VU
														, -1
														);

			v_dc_id_cong_trinh = WebformFunctions.getValue_from_query_string<Decimal>(
														this
														, FormInfo.QueryString.ID_CONG_TRINH
														, -1
														);

			v_dc_id_du_an = WebformFunctions.getValue_from_query_string<Decimal>(
														this
														, FormInfo.QueryString.ID_DU_AN
														, -1
														);
			//load dropdownlist
			//đơn vị
			load_data_2_ddl_don_vi();

			m_ddl_don_vi.SelectedValue = WebformFunctions.getValue_from_query_string<string>(
														this
														, FormInfo.QueryString.ID_DON_VI
														, -1
														);
			//loại nhiệm vụ
			//App_Code.WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			//m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(v_dc_id_loai_nhiem_vu);

			//loại công trình
			App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
				CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_ddl_cong_trinh
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(v_dc_id_cong_trinh);

			//loại dự án
			App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
				CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_ddl_du_an
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));

			m_ddl_du_an.SelectedValue = CIPConvert.ToStr(v_dc_id_du_an);
			load_data_2_ddl_quyet_dinh();
			load_data_to_grid();
		}
		private void load_data_to_grid()
		{
			BoundField field = (BoundField)this.m_grv.Columns[2];

			string v_str_nguon_ngan_sach;
			v_str_nguon_ngan_sach = WebformFunctions.getValue_from_query_string<String>(
														this
														, FormInfo.QueryString.NGUON_NGAN_SACH
														, STR_NGUON.QUY_BAO_TRI
														);
			if (v_str_nguon_ngan_sach == STR_NGUON.NGAN_SACH)
			{
				field.HeaderText = "Kinh phí Ngân sách";
			}
			else
			{
				field.HeaderText = "Kinh phí Quỹ bảo trì";
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
				v_str_nguon_ngan_sach,
				CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue),
				ProcInFo.pr_F157);
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
				ProcInFo.pr_A190,
				m_ddl_quyet_dinh);
		}
		private void load_data_2_ddl_don_vi()
		{
			//decimal v_dc_id_don_vi = Person.get_id_don_vi();
			//v_dc_id_don_vi = CIPConvert.ToDecimal(web);
			WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
				WebformFunctions.getValue_from_query_string<Decimal>(
									this
								   , FormInfo.QueryString.ID_DON_VI
								   , Person.get_id_don_vi()
								   )// id don vi
				, m_ddl_don_vi
				);
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