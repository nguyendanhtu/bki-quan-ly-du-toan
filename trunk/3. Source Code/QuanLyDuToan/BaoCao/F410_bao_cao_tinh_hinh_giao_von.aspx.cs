using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System.Data;

namespace QuanLyDuToan.BaoCao
{
	public partial class F410_bao_cao_tinh_hinh_giao_von : System.Web.UI.Page
	{
		#region Public
		public decimal get_so_tien(string ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_dc_so_tien = 0;
			}
			else if (ip_str_so_tien.Trim().Equals("0"))
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien.Replace(",", "").Replace(".", ""));
			return op_dc_so_tien;
		}
		#endregion

		#region Data Member
		decimal m_dc_id_cong_trinh_du_an;
		DateTime m_dat_tu_ngay;
		DateTime m_dat_den_ngay;
		string m_str_is_nguon_ngan_sach;
		string m_str_ten_du_an;
		#endregion

		#region Private Method
		public string ConvertToUnsign3(string str)
		{
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
			string temp = str.Normalize(System.Text.NormalizationForm.FormD);
			return regex.Replace(temp, String.Empty)
						.Replace('\u0111', 'd').Replace('\u0110', 'D');
			//return str;
		}
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

		private void load_data_to_grid()
		{
			US_RPT_BAO_CAO_GIAO_VON v_us = new US_RPT_BAO_CAO_GIAO_VON();
			DS_RPT_BAO_CAO_GIAO_VON v_ds = new DS_RPT_BAO_CAO_GIAO_VON();
			decimal v_dc_id_don_vi, v_dc_id_loai_nhiem_vu, v_dc_id_cong_trinh, v_dc_id_du_an;
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			else v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
			{
				v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
			}
			else v_dc_id_loai_nhiem_vu = -1;
			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_dc_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
			}
			else v_dc_id_cong_trinh = -1;
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
			}
			else v_dc_id_du_an = -1;
			v_us.bc_256_giao_von_theo_don_vi(v_ds
				, v_dc_id_don_vi
				, v_dc_id_loai_nhiem_vu
				, v_dc_id_cong_trinh
				, v_dc_id_du_an
				, Person.get_user_id()
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, "");
			m_grv.DataSource = v_ds.Tables[0];
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

		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					DateTime v_dat_now = DateTime.Now;
					DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
					v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
					m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
					m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                    App_Code.WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
					load_data_to_grid();
				}
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
				if (check_validate_data_is_ok())
				{
					load_data_to_grid();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		#endregion

		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					if (m_grv.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("") |
						m_grv.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("-1"))
					{
						e.Row.Font.Bold = true;
					}
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
			WinformReport.export_gridview_2_excel(
			m_grv
			, "[" + ConvertToUnsign3(v_us.strTEN_DON_VI) + "]BaoCaoTinhHinhGiaoVon.xls"
			);
		}
		/* Để xuất excel
		 * 1. Dùng 
		 * WinformReport.export_gridview_2_excel(
			m_grv
			, "TenBaoCao.xls"
			);
		 * 2. Thêm 
		 * <Triggers>
			 <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
        </Triggers>
		 * Trong aspx
		 * 3. Thêm hàm VerifyRenderingInServerForm
		*/
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

        protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
        {
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"]!=null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, v_dc_id_don_vi);
        }

        protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an);
        }
	}
}