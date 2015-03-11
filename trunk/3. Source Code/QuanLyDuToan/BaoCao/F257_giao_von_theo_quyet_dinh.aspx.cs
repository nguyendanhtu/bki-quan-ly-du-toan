using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.BaoCao
{
	public partial class F257_giao_von_theo_quyet_dinh : System.Web.UI.Page
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
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		private void load_data_to_grid()
		{
			if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) == -1)
			{
				BoundField field = (BoundField)this.m_grv.Columns[1];
				field.DataField = "tong_tien";
			}
			else
			{
				BoundField field = (BoundField)this.m_grv.Columns[1];
				field.DataField = "tong_tien_qd";
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
											"N",
											CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue),
											"pr_F257_giao_von_theo_quyet_dinh");
			m_grv.DataSource = v_ds.Tables[0];
			m_grv.DataBind();
		}

		private void load_data_to_ddl_quyet_dinh()
		{
			WebformControls.load_data_to_cbo_quyet_dinh(
								CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
								, CONST_GIAO_DICH.ID_TAT_CA
								, CONST_GIAO_DICH.ID_TAT_CA
								, CONST_GIAO_DICH.ID_TAT_CA
								, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
								CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
								m_txt_tim_kiem.Text.Trim(),
								WebformControls.eTAT_CA.YES,
								"pr_A290_danh_sach_quyet_dinh_giao_von",
								m_ddl_quyet_dinh
								);
		}
		private void load_data_to_ddl_don_vi()
		{
			decimal v_dc_id_don_vi = WebformFunctions.getValue_from_query_string<decimal>(
															this
															, FormInfo.QueryString.ID_DON_VI
															, Person.get_id_don_vi()
															);
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(v_dc_id_don_vi, m_ddl_don_vi);
		}

		private void set_initial_form_load()
		{
			//1. Lấy giá trị từ query string
			DateTime ip_dat_dau_nam = WebformFunctions.getValue_from_query_string<DateTime>(
												this
												, FormInfo.QueryString.TU_NGAY
												, DateTime.Now.Date
												);
			DateTime ip_dat_now = WebformFunctions.getValue_from_query_string<DateTime>(
												this
												, FormInfo.QueryString.DEN_NGAY
												, DateTime.Now.Date.AddDays(-DateTime.Now.Day + 1)
												);
			decimal ip_dc_du_an = WebformFunctions.getValue_from_query_string<decimal>(
												this
												, FormInfo.QueryString.ID_DU_AN
												, CONST_GIAO_DICH.ID_TAT_CA
												);
			decimal ip_dc_cong_trinh = WebformFunctions.getValue_from_query_string<decimal>(
													this
													, FormInfo.QueryString.ID_CONG_TRINH
													, CONST_GIAO_DICH.ID_TAT_CA
													);
			decimal ip_dc_loai_nhiem_vu = WebformFunctions.getValue_from_query_string<decimal>(
													this
													, FormInfo.QueryString.ID_LOAI_NHIEM_VU
													, CONST_GIAO_DICH.ID_TAT_CA
													);
			decimal ip_dc_id_quyet_dinh = WebformFunctions.getValue_from_query_string<decimal>(
																this
																, FormInfo.QueryString.ID_QUYET_DINH
																, CONST_GIAO_DICH.ID_TAT_CA
																);

			ip_dat_dau_nam = ip_dat_dau_nam.AddMonths(-ip_dat_dau_nam.Month + 1);
			m_txt_tu_ngay.Text = CIPConvert.ToStr(ip_dat_dau_nam, "dd/MM/yyyy");
			m_txt_den_ngay.Text = CIPConvert.ToStr(ip_dat_now, "dd/MM/yyyy");

			/*
			 * 2. load data to dropdownlists: 
			 * 2.1. Đơn vị
			 * 2.2. Quyết định
			 * 2.3. Loại nhiệm vụ
			 * 2.4. Công trình
			 * 2.5. Dự án
			 */

			//2.1. Đơn vị
			load_data_to_ddl_don_vi();

			//2.2. Quyết định
			load_data_to_ddl_quyet_dinh();
			m_ddl_quyet_dinh.SelectedValue = ip_dc_id_quyet_dinh.ToString();

			//2.3. Loại nhiệm vụ
			WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(ip_dc_loai_nhiem_vu);

			//2.4. Công trình
			App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
										CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
										, m_ddl_cong_trinh
										, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
										);
			m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(ip_dc_cong_trinh);

			//2.5. Dự án
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
										CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
										, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
										, m_ddl_du_an, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
										);
			m_ddl_du_an.SelectedValue = CIPConvert.ToStr(ip_dc_du_an);

			//3. Đổ dữ liệu lên lưới
			load_data_to_grid();
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
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

		protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
												CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
												, m_ddl_cong_trinh
												, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
												);
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
				App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
												CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
												, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
												, m_ddl_du_an
												, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
												);
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
				US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
				WebformReport.export_gridview_2_excel(
								m_grv
								, "[" + v_us.strTEN_DON_VI + "]" + FormInfo.ExportExcelReportName.F257
								);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		protected void m_txt_tu_ngay_TextChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_quyet_dinh();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_txt_den_ngay_TextChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_quyet_dinh();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		#endregion
	}
}