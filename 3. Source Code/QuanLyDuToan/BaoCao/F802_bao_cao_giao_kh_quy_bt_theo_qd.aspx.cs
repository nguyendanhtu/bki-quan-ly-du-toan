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
	public partial class F802_bao_cao_giao_kh_quy_bt_theo_qd : System.Web.UI.Page
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

		private void load_data_to_grid()
		{
			US_V_GD_GIAI_NGAN_QBT v_us = new US_V_GD_GIAI_NGAN_QBT();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			decimal v_dc_id_loai_nhiem_vu, v_dc_id_cong_trinh, v_dc_id_du_an,v_dc_id_don_vi;
			v_dc_id_cong_trinh = v_dc_id_du_an = v_dc_id_loai_nhiem_vu = -1;
			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"]!=null)
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
				if (v_dc_id_don_vi==0|v_dc_id_don_vi==-1)
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
				);
			m_grv.DataSource = v_ds.Tables[0];

			m_grv.DataBind();
			//m_grv.Columns[1].HeaderText = "Nội dung";

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
							v_lbl.Text = CIPConvert.ToStr(WinFormControls.get_so_tien(e.Row.Cells[i].Text),"#,###,##");
							v_lbl.CssClass = "csscurrency";
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


	}
}