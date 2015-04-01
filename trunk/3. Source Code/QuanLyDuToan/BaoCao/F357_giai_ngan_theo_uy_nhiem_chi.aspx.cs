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
	public partial class F357_giai_ngan_theo_uy_nhiem_chi : System.Web.UI.Page
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

		private void set_initial_form_load()
		{
			//1. Lấy giá trị từ Query string
			//1.1. Đặt lại tiêu đề
			if (WebformFunctions.getValue_from_query_string<string>(
										this
										, FormInfo.QueryString.NGUON_NGAN_SACH
										, STR_NGUON.NGAN_SACH).Equals(STR_NGUON.NGAN_SACH)
					)
				m_lbl_nguon.Text = " - NGUỒN NGÂN SÁCH ";
				else m_lbl_nguon.Text = " - QUỸ BẢO TRÌ ";

			//1.2. Đặt lại textbox ngày tháng
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<string>
														(this
														, FormInfo.QueryString.TU_NGAY
														, CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy")
														);
			m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<string>
														(this
														, FormInfo.QueryString.DEN_NGAY
														, CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy")
														);
			//1.3. Lấy dữ liệu decimal
			decimal ip_dc_id_don_vi = WebformFunctions.getValue_from_query_string<decimal>(
															this
															, FormInfo.QueryString.ID_DON_VI
															, Person.get_id_don_vi()
															);
			decimal ip_dc_id_loai_nhiem_vu = WebformFunctions.getValue_from_query_string<decimal>(
																this
																, FormInfo.QueryString.ID_LOAI_NHIEM_VU
																, CONST_GIAO_DICH.ID_TAT_CA
																);
			decimal ip_dc_id_du_an = WebformFunctions.getValue_from_query_string<decimal>(
															this
															, FormInfo.QueryString.ID_DU_AN
															, CONST_GIAO_DICH.ID_TAT_CA
															);
			decimal ip_dc_id_cong_trinh = WebformFunctions.getValue_from_query_string<decimal>(
															this
															, FormInfo.QueryString.ID_CONG_TRINH
															, CONST_GIAO_DICH.ID_TAT_CA
															);
			string ip_str_nguon_ns = WebformFunctions.getValue_from_query_string<string>(
															this
															, FormInfo.QueryString.NGUON_NGAN_SACH
															, STR_NGUON.QUY_BAO_TRI
															);

			//2. Đổ dữ liệu vào các dropdownlist:
			//2.1. Đơn vị
			this.load_data_to_ddl_don_vi();
			m_ddl_don_vi.SelectedValue = ip_dc_id_don_vi.ToString();

			//2.2. Loại nhiệm vụ
			if (ip_str_nguon_ns==STR_NGUON.NGAN_SACH)
			{
				App_Code.WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv, true, false);
			}
			else
				App_Code.WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv,false, true);
			m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(ip_dc_id_loai_nhiem_vu);

			//2.3. Công trình
			App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
										CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
										, m_ddl_cong_trinh
										, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
										);
			m_ddl_cong_trinh.SelectedValue = ip_dc_id_cong_trinh.ToString();

			//2.4. Dự án
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
										CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
										, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
										, m_ddl_du_an
										, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
										);
			m_ddl_du_an.SelectedValue = ip_dc_id_du_an.ToString();

			//2.5. Uỷ nhiệm chi
			load_data_to_ddl_uy_nhiem_chi();

			//3. Đổ dữ liệu lên lưới
			this.load_data_to_grid();

		}

		private void load_data_to_ddl_uy_nhiem_chi()
		{
			bool v_str_nguon_ns = false;
			if (Request.QueryString[FormInfo.QueryString.NGUON_NGAN_SACH] != null)
				if (Request.QueryString[FormInfo.QueryString.NGUON_NGAN_SACH].ToString().Equals(STR_NGUON.NGAN_SACH))
				{
					v_str_nguon_ns = true;
				}

			WebformControls.load_data_to_cbo_dm_uy_nhiem_chi(
								m_ddl_quyet_dinh
								, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
								, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
								, v_str_nguon_ns
								, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
								, "Tổng hợp các uỷ nhiệm chi"
								);
		}
		private void load_data_to_ddl_don_vi()
		{
			decimal v_dc_id_don_vi = WebformFunctions.getValue_from_query_string<decimal>(
															this
															, FormInfo.QueryString.ID_DON_VI
															, Person.get_id_don_vi()
															);
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
								v_dc_id_don_vi
								, m_ddl_don_vi
								);
		}

		private void load_data_to_grid()
		{
			try
			{
				if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) == CONST_GIAO_DICH.ID_TAT_CA)
				{
					BoundField field = (BoundField)this.m_grv.Columns[1];
					field.DataField = "Tổng cộng";
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
				string v_str_is_nguon_ns = WebformFunctions.getValue_from_query_string<string>(
																this
																, FormInfo.QueryString.NGUON_NGAN_SACH
																, STR_NGUON.QUY_BAO_TRI
																);
				new US_V_GD_GIAI_NGAN_QBT().FillData2DatasetGiaiNgan(
												v_ds
												, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
												, CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
												, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
												, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue.Trim() == "" ? CONST_GIAO_DICH.STR_VALUE_TAT_CA : m_ddl_loai_nv.SelectedValue.Trim())
												, CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue.Trim() == "" ? CONST_GIAO_DICH.STR_VALUE_TAT_CA : m_ddl_cong_trinh.SelectedValue.Trim())
												, CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue.Trim() == "" ? CONST_GIAO_DICH.STR_VALUE_TAT_CA : m_ddl_du_an.SelectedValue.Trim())
												, m_txt_tim_kiem.Text.Trim()
												, v_str_is_nguon_ns
												, CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)
												, "pr_F357_giai_ngan_theo_uy_nhiem_chi"
												);

				m_grv.DataSource = v_ds.Tables[0];
				m_grv.DataBind();
			}
			catch (Exception ex)
			{
				CSystemLog_301.ExceptionHandle(this, ex);
			}

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
		protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_uy_nhiem_chi();
				m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
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
									, "[" + v_us.strTEN_DON_VI + "]" + FormInfo.ExportExcelReportName.F357
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
				load_data_to_ddl_uy_nhiem_chi();
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
				load_data_to_ddl_uy_nhiem_chi();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		#endregion
	}
}