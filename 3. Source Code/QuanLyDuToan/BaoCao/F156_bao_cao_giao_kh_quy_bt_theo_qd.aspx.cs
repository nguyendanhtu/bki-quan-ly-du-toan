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
using System.Diagnostics;

namespace QuanLyDuToan.BaoCao
{
	public partial class F156_bao_cao_giao_kh_quy_bt_theo_qd : System.Web.UI.Page
	{
		#region Public
		#endregion

		#region Data Member
		decimal m_dc_id_cong_trinh_du_an;
		DateTime m_dat_tu_ngay;
		DateTime m_dat_den_ngay;
		string m_str_is_nguon_ngan_sach;
		string m_str_ten_du_an;
		#endregion

		#region Private Method

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
		public string ConvertToUnsign3(string str)
		{
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
			string temp = str.Normalize(System.Text.NormalizationForm.FormD);
			return regex.Replace(temp, String.Empty)
						.Replace('\u0111', 'd').Replace('\u0110', 'D');
			//return str;
		}
		private void load_data_to_grid()
		{
			US_V_GD_GIAI_NGAN_QBT v_us = new US_V_GD_GIAI_NGAN_QBT();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			decimal v_dc_id_loai_nhiem_vu, v_dc_id_cong_trinh, v_dc_id_du_an, v_dc_id_don_vi;
			v_dc_id_cong_trinh = v_dc_id_du_an = v_dc_id_loai_nhiem_vu = -1;
            decimal v_dc_id_quyet_dinh = -1;
			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
			{
				v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
			}
			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_dc_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
			}
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
			}
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
				if (v_dc_id_don_vi == 0 | v_dc_id_don_vi == -1)
				{
					v_dc_id_don_vi = Person.get_id_don_vi();
				}
			}
			else v_dc_id_don_vi = Person.get_id_don_vi();
			v_ds.Tables.Add(v_dt);
			v_ds.AcceptChanges();

			v_us.bc_giao_kh_quy_bao_tri_theo_qd(v_ds
				, v_dc_id_don_vi
				, v_dc_id_loai_nhiem_vu
				, v_dc_id_cong_trinh
				, v_dc_id_du_an
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, m_txt_tim_kiem.Text.Trim()
				, "N"
                ,v_dc_id_quyet_dinh);
			formatData(v_ds);
			m_grv.DataSource = v_ds.Tables[0];

			m_grv.DataBind();
			//m_grv.Columns[1].HeaderText = "Nội dung";

		}

		private void formatData(DataSet v_ds)
		{
			for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
			{
				for (int j = 7; j < v_ds.Tables[0].Columns.Count; j++)
				{
					v_ds.Tables[0].Rows[i][j] = formatString(v_ds.Tables[0].Rows[i][j].ToString());
				}
			}
		}

		private string formatString(string str)
		{
			var index = 0;
			var str2 = "";
			for (int i = str.Length - 1; i >= 0; i--)
			{
				str2 = str[i] + str2;
				index += 1;
				if (index % 3 == 0 && index != str.Length)
				{
					str2 = "," + str2;
				}
			}
			if (str2.Length == 0)
			{
				str2 = "0";
			}
			return str2;
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

					//m_dc_id_cong_trinh_du_an = CIPConvert.ToDecimal(Request.QueryString["id_cong_trinh_du_an"]);
					//m_dat_tu_ngay = CIPConvert.ToDatetime(Request.QueryString["tu_ngay"]);
					//m_dat_den_ngay = CIPConvert.ToDatetime(Request.QueryString["den_ngay"]);
					//m_str_is_nguon_ngan_sach = Request.QueryString["is_nguon_ngan_sach"];
					//m_str_ten_du_an = Request.QueryString["ten_du_an"];
					App_Code.WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);

					//set value form query string
					decimal v_dc_id_don_vi = Person.get_id_don_vi();
					if (Request.QueryString["ip_dc_id_don_vi"] != null)
					{
						v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
					}
					US_DM_DON_VI v_us_don_vi = new US_DM_DON_VI(v_dc_id_don_vi);
					m_lbl_don_vi.Text = v_us_don_vi.strTEN_DON_VI;
					if (Request.QueryString["ip_dat_tu_ngay"] != null)
					{
						m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
					}
					if (Request.QueryString["ip_dat_tu_ngay"] != null)
					{
						m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
					}
					if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
					{
						if (CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"])>0)
						{
							m_ddl_loai_nv.SelectedValue = Request.QueryString["ip_dc_id_loai_nhiem_vu"].ToString();
							
						}
						
					}
					m_ddl_loai_nv_SelectedIndexChanged(null, null);
					if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
					{
						if (CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]) > 0)
						{
							m_ddl_cong_trinh.SelectedValue = Request.QueryString["ip_dc_id_cong_trinh"].ToString();
							
						}
						
					}
					m_ddl_cong_trinh_SelectedIndexChanged(null, null);
					if (Request.QueryString["ip_dc_id_du_an"] != null)
					{
						if (CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]) > 0)
						{
							m_ddl_du_an.SelectedValue = Request.QueryString["ip_dc_id_du_an"].ToString();
						}
					}
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
		protected void m_grv_OnRowCreated(object sender, GridViewRowEventArgs e)
		{
			try
			{
				e.Row.Cells[0].Visible = false; // hides the first column
				e.Row.Cells[2].Visible = false;
				e.Row.Cells[3].Visible = false;
				e.Row.Cells[4].Visible = false;
				e.Row.Cells[5].Visible = false;
				e.Row.Cells[6].Visible = false;
				e.Row.Cells[1].Text = "Nội dung";

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
			, "[" + ConvertToUnsign3(v_us.strTEN_DON_VI) + "]BaoCaoTinhHinhGiaoKeHoach.xls"
			);
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		#endregion

		//protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		//{
		//	try
		//	{
		//		if (e.Row.RowType == DataControlRowType.Header)
		//		{
		//			for (int i = 6; i < e.Row.Cells.Count; i++)
		//			{
		//				US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
		//				DS_DM_QUYET_DINH v_ds_qd = new DS_DM_QUYET_DINH();
		//				v_us_qd.FillDataset(v_ds_qd, "where " + DM_QUYET_DINH.SO_QUYET_DINH + " = N'" + e.Row.Cells[i].Text + "'");
		//				if (v_ds_qd.DM_QUYET_DINH.Count > 0)
		//				{
		//					e.Row.Cells[i].Text = "QĐ số " + v_ds_qd.Tables[0].Rows[0][DM_QUYET_DINH.SO_QUYET_DINH] + " ngày " +
		//						CIPConvert.ToStr(v_ds_qd.Tables[0].Rows[0][DM_QUYET_DINH.NGAY_THANG], "dd/MM/yyyy");
		//				}
		//			}
		//		}
		//	}
		//	catch (Exception v_e)
		//	{
		//		CSystemLog_301.ExceptionHandle(this, v_e);
		//	}
		//}

		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{

				if (e.Row.RowType == DataControlRowType.Header)
				{
					for (int i = 0; i < e.Row.Controls.Count; i++)
					{
						var headerCell = e.Row.Controls[i] as DataControlFieldHeaderCell;
						if (headerCell != null)
						{
							US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH();
							DS_DM_QUYET_DINH v_ds_qd = new DS_DM_QUYET_DINH();
							v_us_qd.FillDataset(v_ds_qd, "where " + DM_QUYET_DINH.SO_QUYET_DINH + " = N'" + headerCell.ContainingField.ToString().Trim() + "'");
							if (v_ds_qd.DM_QUYET_DINH.Count > 0)
							{
								headerCell.Text = "QĐ số " + v_ds_qd.Tables[0].Rows[0][DM_QUYET_DINH.SO_QUYET_DINH] + " ngày " +
									CIPConvert.ToStr(v_ds_qd.Tables[0].Rows[0][DM_QUYET_DINH.NGAY_THANG], "dd/MM/yyyy");

							}
						}
					}
				}
				else if (e.Row.RowType == DataControlRowType.DataRow)
				{
					if (m_grv.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals(""))
					{
						e.Row.Font.Bold = true;
					}
					e.Row.Cells[1].Width = 200;
					for (int i = 7; i < e.Row.Controls.Count; i++)
					{
						Label v_lbl = new Label();
						if (e.Row.Cells[i] == null)
							return;

						decimal v_i_so_tien = 0;
						bool v_b_is_number = decimal.TryParse(e.Row.Cells[i].Text, out v_i_so_tien);
						if (v_b_is_number)
						{
							v_lbl.Text = CIPConvert.ToStr(WinFormControls.get_so_tien(e.Row.Cells[i].Text), "#,###,##");
						}

						e.Row.Cells[i].Controls.Add(v_lbl);
						e.Row.Cells[i].CssClass = "csscurrency";
						e.Row.Cells[i].Width = 80;
					}

				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, v_dc_id_don_vi);
		}

		protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, v_dc_id_don_vi);
		}


	}
}