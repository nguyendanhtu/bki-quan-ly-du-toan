using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;
using System.Data;
using IP.Core.IPUserService;
using IP.Core.IPData;
//using IP.Core.IPExcelWebReport;

namespace QuanLyDuToan.DanhMuc
{
	public partial class F190_danh_sach_quyet_dinh_giao_kh : System.Web.UI.Page
	{
		#region Refactory_last_time_by_TuDM_2015_03_11
		/*
			* Bắt try catch ở sự kiện
			* Viết hàm set_initial_form_load
			*/
		#endregion

		#region Public Functions
		public bool isEnableSelectDropdownlist(DropDownList ip_ddl)
		{
			ip_ddl.Items.Remove("-1");
			if (ip_ddl.Items.Count > 1) return true;
			return false;
		}
		#endregion

		#region Data Structures
		
		#endregion

		#region Members
		US_V_DM_QUYET_DINH_KH m_us = new US_V_DM_QUYET_DINH_KH();

		#endregion

		#region Private Methods
		private void set_initial_form_load()
		{
			//1. Lấy dữ liệu ngày tháng từ query string
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
														this
														, FormInfo.QueryString.TU_NGAY
														, CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy")
														);
			m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
														this
														, FormInfo.QueryString.DEN_NGAY
														, CIPConvert.ToStr(CCommonFunction.getDate_cuoi_nam_form_date(DateTime.Now), "dd/MM/yyyy")
														);
			//2. Đổ dữ liệu vào dropdownlist Đơn vị
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
								Person.get_id_don_vi()
								, m_ddl_don_vi
								);
			m_ddl_don_vi.SelectedValue = WebformFunctions.getValue_from_query_string<string>(
																this
																, FormInfo.QueryString.ID_DON_VI
																, Person.get_id_don_vi().ToString()
																);

			
			//3. Đổ dữ liệu lên lưới
			load_data_to_grid();
		}
		private bool check_validate_input_report()
		{
			if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập ngày tháng!";
				m_txt_tu_ngay.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập ngày tháng!";
				m_txt_den_ngay.Focus();
				return false;
			}
			return true;
		}
		private void load_data_to_grid()
		{
			m_lbl_info.Text = "";
			if (!check_validate_input_report()) return;
			US_V_DM_QUYET_DINH_KH v_us = new US_V_DM_QUYET_DINH_KH();
			DS_V_DM_QUYET_DINH_KH v_ds = new DS_V_DM_QUYET_DINH_KH();
			v_ds.EnforceConstraints = false;
			v_us.FillDatasetGiaoKHByIdDonVi(
					v_ds,
					CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
					CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
					CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
					m_txt_tu_khoa_tim_kiem.Text.Trim()
					);
			m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_QUYET_DINH_KH;
			m_grv_bao_cao_giao_von.DataBind();
		}
		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
							m_grv_bao_cao_giao_von
							, "[" + v_us.strTEN_DON_VI + "]" + FormInfo.ExportExcelReportName.F190
							);
		}
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				m_lbl_info.Text = "";
				m_lbl_info.Text = "";
				if (!IsPostBack)
				{
					set_initial_form_load();
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
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				export_excel();
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
		#endregion

	}
}