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
	public partial class F190_Danh_sach_quyet_dinh_giao_ke_hoach : System.Web.UI.Page
	{
		#region Private Methods
		private bool check_validate_data_is_ok()
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
			if (!check_validate_data_is_ok()) return;

			DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
			DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy");

			decimal v_dc_id_loai_nhiem_vu = -1, v_dc_id_id_cong_trinh = -1, v_dc_id_du_an = -1;

			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
			{
				v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
				if (v_dc_id_loai_nhiem_vu != -1)
				{
					US_CM_DM_TU_DIEN v_us_loai_nhiem_vu = new US_CM_DM_TU_DIEN(v_dc_id_loai_nhiem_vu);
					m_lbl_info.Text = "Loại nhiệm vụ: " + v_us_loai_nhiem_vu.strTEN;
				}

			}
			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_dc_id_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
				if (v_dc_id_id_cong_trinh != -1)
				{
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_cong_trinh = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(v_dc_id_id_cong_trinh);
					m_lbl_info.Text += "- Công trình/Quốc lộ: " + v_us_cong_trinh.strTEN;
				}
			}
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
				if (v_dc_id_id_cong_trinh != -1)
				{
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(v_dc_id_du_an);
					m_lbl_info.Text += "- Dự án: " + v_us_du_an.strTEN;
				}
			}
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);
			v_us.get_ds_quyet_dinh(v_ds
				, Person.get_id_don_vi()
				, v_dc_id_loai_nhiem_vu
				, v_dc_id_id_cong_trinh
				, v_dc_id_du_an
				, v_dat_tu_ngay
				, v_dat_den_ngay,
				m_txt_tu_khoa_tim_kiem.Text.Trim(),
                "pr_A190_danh_sach_quyet_dinh_giao_kh");
			m_grv_bao_cao_giao_von.DataSource = v_ds.Tables[0];
			m_grv_bao_cao_giao_von.DataBind();

		}

		private void export_excel()
		{
			
		}

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
                    if (Request.QueryString["ip_dat_tu_ngay"].ToString().Trim() != "")
                    {
                        m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_tu_ngay.Text = CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(DateTime.Now), "dd/MM/yyyy");
                    }
                    if (Request.QueryString["ip_dat_den_ngay"].ToString().Trim() != "")
                    {
                        m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
                    }
					load_data_to_grid();
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
		#endregion
	}
}