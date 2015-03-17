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



namespace QuanLyDuToan.DanhMuc
{
	public partial class F390_v_danh_sach_uy_nhiem_chi : System.Web.UI.Page
	{

		#region Public Functions
		public string getLinkToUNC(string ip_dc_id_giai_ngan, string ip_nguon_ns)
		{
			string op_str_link = "";
			if (ip_nguon_ns == "N")
			{
				op_str_link = "../DuToan/" + FormInfo.FormName.F304
					+ "?" + FormInfo.QueryString.ID_DM_GIAI_NGAN + "=" + ip_dc_id_giai_ngan
					+ "&" + FormInfo.QueryString.NGUON_NGAN_SACH + "=" + ip_nguon_ns;
			}
			else
			{
				op_str_link = "../DuToan/" + FormInfo.FormName.F305
					+ "?" + FormInfo.QueryString.ID_DM_GIAI_NGAN + "=" + ip_dc_id_giai_ngan
					+ "&" + FormInfo.QueryString.NGUON_NGAN_SACH + "=" + ip_nguon_ns;
			}
			return op_str_link;
		}
		#endregion

		#region Data Structures

		#endregion

		#region Members

		#endregion

		#region Private Methods
		private void set_initial_form_load()
		{
			//1. Lấy dữ liệu ngày tháng từ Query string
			m_txt_tu_khoa_tim_kiem.Text = "";
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
													this
													, FormInfo.QueryString.TU_NGAY
													, CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy")
												);
			m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<string>(
													this
													, FormInfo.QueryString.DEN_NGAY
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
		private bool check_validate_input_report_is_ok()
		{
			if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải chọn Ngày tháng theo định dạng dd/MM/yyyy";
				m_txt_tu_ngay.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải chọn Ngày tháng theo định dạng dd/MM/yyyy";
				m_txt_den_ngay.Focus();
				return false;
			}
			return true;
		}
		private void load_data_to_grid()
		{
			if (!check_validate_input_report_is_ok()) return;
			US_V_DM_GIAI_NGAN v_us = new US_V_DM_GIAI_NGAN();
			DS_V_DM_GIAI_NGAN v_ds = new DS_V_DM_GIAI_NGAN();
			v_ds.EnforceConstraints = false;
			v_us.FillDatasetByProc(
						v_ds
						, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
						, CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
						, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
						, m_txt_tu_khoa_tim_kiem.Text.Trim()
						);

			//Edit dataset: Chỉ rõ Uỷ nhiệm chi là Nguồn nào?
			for (int i = 0; i < v_ds.V_DM_GIAI_NGAN.Count; i++)
			{
				if (v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.IS_NGUON_NS_YN].ToString().Equals(STR_NGUON.NGAN_SACH))
					v_ds.Tables[0].Rows[i]["NGUON_NS_YN"] = "Giấy rút dự toán Ngân sách";
				else v_ds.Tables[0].Rows[i]["NGUON_NS_YN"] = "Uỷ nhiệm chi Quỹ Bảo trì";
			}
			v_ds.AcceptChanges();

			m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_GIAI_NGAN;
			m_grv_bao_cao_giao_von.DataBind();

		}
		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
								m_grv_bao_cao_giao_von
								, "[" + v_us.strTEN_DON_VI + "]" + FormInfo.ExportExcelReportName.F390
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
				m_lbl_mess.Text = "";
				if (!IsPostBack)
				{
					set_initial_form_load();
				}
			}
			catch (Exception v_e)
			{
				this.Response.Write(v_e.ToString());
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

		protected void m_grv_bao_cao_giao_von_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName.ToUpper() == "XOA")
				{
					US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN();
					if (v_us_dm_giai_ngan.deleteAllDataOfUNC(CIPConvert.ToDecimal(e.CommandArgument)))
					{
						m_lbl_mess.Text = "Bạn đã xoá Uỷ nhiệm chi thành công";
						load_data_to_grid();
					}
					else m_lbl_mess.Text = "Đã có lỗi trong quá trình thực hiện, bạn hãy thực hiện lại thao tác";

				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		#endregion
	}
}