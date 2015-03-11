using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.DanhMuc
{
	public partial class F290_danh_sach_quyet_dinh_giao_von : System.Web.UI.Page
    {
		#region Refactory_last_time_by_TuDM_2015_03_11
		/*
			* Bắt try catch ở sự kiện
			* Viết hàm set_initial_form_load
			*/
		#endregion

		#region Public Functions
		
		#endregion

		#region Data Structures
		
		#endregion

		#region Members

		#endregion

		#region Private Methods
		private void load_data_to_grid()
		{
			US_V_DM_QUYET_DINH v_us = new US_V_DM_QUYET_DINH();
			DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
			v_ds.EnforceConstraints = false;
			v_us.FillDatasetByIdDonVi(
						v_ds,
						CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
						CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
						CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
						m_txt_tu_khoa_tim_kiem.Text.Trim()
						);
			m_grv.DataSource = v_ds.V_DM_QUYET_DINH;
			m_grv.DataBind();
		}
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		private void set_initial_form_load()
		{
			//1. Lấy dữ liệu ngày tháng từ Query string
			m_txt_tu_khoa_tim_kiem.Text = "";
			m_txt_tu_ngay.Text=WebformFunctions.getValue_from_query_string<string>(
													this
													,FormInfo.QueryString.TU_NGAY
													,CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now),"dd/MM/yyyy")
												);
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
													this
													, FormInfo.QueryString.TU_NGAY
													, CIPConvert.ToStr(DateTime.Now.Date, "dd/MM/yyyy")
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
		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
							m_grv
							, "[" + v_us.strTEN_DON_VI + "]"+FormInfo.ExportExcelReportName.F290
							);
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				set_initial_form_load();
			}
		}

		protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
		{
			try
			{
				load_data_to_grid();
			}
			catch (Exception ex)
			{

				CSystemLog_301.ExceptionHandle(this, ex);
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