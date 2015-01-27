using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPException;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System.Data;
namespace QuanLyDuToan.DuToan
{
	public partial class F104_nhap_du_toan_ke_hoach : System.Web.UI.Page
	{
		#region Public Interface
		public string format_so_tien(string ip_str_so_tien)
		{
			string op_str_so_tien = "";
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_str_so_tien = "";
			}
			else if (ip_str_so_tien.Trim().Equals("0"))
			{
				op_str_so_tien = "0";
			}
			else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
			return op_str_so_tien;
		}
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
		public string get_font_css(string ip_str)
		{
			string op_str = "";
			if (ip_str != "-1" && ip_str != "")
			{
				op_str = "cssFontBold";
			}
			return op_str;
		}
		#endregion

		#region Data Structure
		public class LOAI_FORM
		{
			public const string THEM = "THEM";
			public const string SUA = "SUA";
			public const string XOA = "XOA";
		}
		#endregion

		#region Members
		DS_GD_CHI_TIET_GIAO_KH m_ds = new DS_GD_CHI_TIET_GIAO_KH();
		US_GD_CHI_TIET_GIAO_KH m_us = new US_GD_CHI_TIET_GIAO_KH();
		#endregion //Members

		#region Private Methods

		private void load_data_to_cbo_quyet_dinh()
		{
			WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_KE_HOACH, m_ddl_quyet_dinh);
		}
		private void load_data_cong_trinh_du_an_giao_kh_to_ddl(DropDownList op_ddl, WinFormControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_quyet_dinh.Value.Trim().Equals("") | m_hdf_id_quyet_dinh.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
				DateTime v_dat_dau_nam = v_us_quyet_dinh.datNGAY_THANG;
				v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_kh(ip_loai_du_an
					, op_ddl);
			}
		}
		private void load_data_to_ddl_loai_nhiem_vu()
		{
			bool v_b_is_nguon_ns = false;
			bool v_b_is_chi_du_an = false;
			if (m_rdb_theo_quoc_lo.Checked == true) v_b_is_chi_du_an = true;
			else v_b_is_chi_du_an = false;
			if (Request.QueryString["ip_nguon_ns"] != null)
			{
				if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
				{
					v_b_is_nguon_ns = true;
				}
			}
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu, v_b_is_nguon_ns, v_b_is_chi_du_an);
		}
		private void load_data_to_cbo_quoc_lo()
		{
			WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von1(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH, m_ddl_cong_trinh);
		}
		private void load_data_to_du_an()
		{
			WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von2(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN, CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), m_ddl_du_an);
		}
		private void load_data_to_grid()
		{
			try
			{
				//Kiem tra neu khong phai la don vi nhap thi chi cho xem
				if (m_ddl_don_vi.SelectedValue != Person.get_id_don_vi().ToString())
				{
					m_grv.Columns[0].Visible = false;
					m_cmd_insert.Visible = false;
					m_cmd_update.Visible = false;
					m_cmd_cancel.Visible = false;
				}
				else
				{
					m_grv.Columns[0].Visible = true;
					if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.SUA)
					{
						m_cmd_update.Visible = true;
						m_cmd_cancel.Visible = true;
					}
					else if (get_form_mode(m_hdf_form_mode) == LOAI_FORM.THEM)
					{
						m_cmd_insert.Visible = true;
						m_cmd_cancel.Visible = true;
					}
				}
				//decimal v_id_dc_loai = 1;
				decimal v_id_dc_reported_user;
				// Chú thích: id_dc_loai = 1 - Loại dự án
				//            id_dc_loai = 2 - CLKM
				//Kiểm tra xem thuộc loại nào:
				//if (m_rdb_theo_quoc_lo.Checked == true)
				//{
				//	v_id_dc_loai = 1;
				//}
				//if (m_rdb_theo_chuong_loai_khoan_muc.Checked == true)
				//{
				//	v_id_dc_loai = 2;
				//}
				//Lấy id_reported_user
				v_id_dc_reported_user = Person.get_user_id();
				//1. Get dataset
				DS_GRID_GIAO_KH v_ds = new DS_GRID_GIAO_KH();
				//2. Lay du lieu
				US_GRID_GIAO_KH v_us = new US_GRID_GIAO_KH();
				decimal v_dc_id_quyet_dinh = -1;
				if (m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
				{
					v_dc_id_quyet_dinh = -1;
				}
				else
					v_dc_id_quyet_dinh = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);

				if (v_dc_id_quyet_dinh != -1)
				{
					US_DM_QUYET_DINH v_us_qd = new US_DM_QUYET_DINH(v_dc_id_quyet_dinh);
					m_lbl_grid_ngay.Text = CIPConvert.ToStr(v_us_qd.datNGAY_THANG, "dd/MM/yyyy");
					m_lbl_grid_so_quyet_dinh.Text = v_us_qd.strSO_QUYET_DINH;
					m_lbl_grid_ve_viec.Text = v_us_qd.strNOI_DUNG;
				}

				//kiem tra xem dang nhap Nguon nao
				string v_str_is_nguon_ns = "N";
				if (Request.QueryString["ip_nguon_ns"] == "Y")
				{
					v_str_is_nguon_ns = "Y";
				}

				if (v_dc_id_quyet_dinh < 0) return;
				
				v_us.get_grid_giao_kh_qbt(v_ds
					, v_dc_id_quyet_dinh
					, v_str_is_nguon_ns
					, v_id_dc_reported_user
					, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
				m_grv.DataSource = v_ds.Tables[0];
				m_grv.DataBind();
				if (!m_hdf_id_giao_kh.Value.Equals(""))
				{
					m_grv.SelectedIndex = -1;
					for (int i = 0; i < m_grv.Rows.Count; i++)
						if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
				}
				//get tong tien
				decimal v_dc_tong_tien = 0;
				for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
				{
					if (v_ds.Tables[0].Rows[i][GRID_GIAO_KH.ID].ToString() != "-1")
					{
						v_dc_tong_tien += get_so_tien(v_ds.Tables[0].Rows[i][GRID_GIAO_KH.NTCT].ToString()) +
							get_so_tien(v_ds.Tables[0].Rows[i][GRID_GIAO_KH.NS].ToString()) +
							get_so_tien(v_ds.Tables[0].Rows[i][GRID_GIAO_KH.QUY].ToString());
					}
				}
				m_lbl_grid_tong_tien.Text = CIPConvert.ToStr(v_dc_tong_tien, "#,###,##");

			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
			}
		}
		private void load_data_to_ddl_chuong()
		{
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
			v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.CHUONG + " order by ma_so");
			for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
			{
				v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
				v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
			}

			m_ddl_chuong.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			m_ddl_chuong.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			m_ddl_chuong.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
			m_ddl_chuong.DataBind();
			//m_ddl_chuong.Items.Insert(0, new ListItem("---Chọn Chương---", "-1"));
			m_ddl_chuong.SelectedValue = ID_CHUONG.BO_GIAO_THONG_VAN_TAI.ToString();
			m_ddl_chuong.Enabled = false;
		}
		private void load_data_to_ddl_loai()
		{
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
			v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.LOAI + " order by ma_so");
			for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
			{
				v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
				v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
			}

			m_ddl_loai.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			m_ddl_loai.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			m_ddl_loai.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
			m_ddl_loai.DataBind();
			m_ddl_loai.Items.Insert(0, new ListItem("---Chọn Loại---", "-1"));
		}
		private void load_data_to_ddl_khoan()
		{
			m_ddl_khoan.Items.Clear();
			m_ddl_khoan.ClearSelection();
			if (m_ddl_loai.SelectedValue == "-1" | m_ddl_loai.SelectedValue == "" | m_ddl_loai.SelectedValue == null)
			{
				m_ddl_khoan.Items.Clear();
				m_ddl_khoan.Items.Insert(0, new ListItem("---Chọn Khoản---", "-1"));
				return;
			}
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();

			v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc,
				"where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.KHOAN
				+ " and id_cha=" + m_ddl_loai.SelectedValue
				+ " order by ma_so");
			for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
			{
				v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
				v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
			}

			m_ddl_khoan.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			m_ddl_khoan.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			m_ddl_khoan.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
			m_ddl_khoan.DataBind();
			m_ddl_khoan.Items.Insert(0, new ListItem("---Chọn Khoản---", "-1"));

		}
		private void load_data_to_ddl_muc()
		{
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
			v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.MUC + " order by ma_so");
			for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
			{
				v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
				v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
			}

			m_ddl_muc.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			m_ddl_muc.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			m_ddl_muc.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
			m_ddl_muc.DataBind();
			m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục---", "-1"));
		}
		private void load_data_to_ddl_tieu_muc()
		{
			m_ddl_tieu_muc.ClearSelection();
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
			v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC
				+ " and id_cha = " + m_ddl_muc.SelectedValue
				+ " order by ma_so");
			for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
			{
				v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
					v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
				v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
			}

			m_ddl_tieu_muc.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			m_ddl_tieu_muc.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			m_ddl_tieu_muc.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
			m_ddl_tieu_muc.DataBind();
			m_ddl_tieu_muc.Items.Insert(0, new ListItem("---Chọn Tiểu mục---", "-1"));
		}

		private bool check_validate_data_gd_is_ok()
		{
			if (get_form_mode(m_hdf_form_mode).Equals(LOAI_FORM.XOA))
			{

				//US_GD_CHI_TIET_GIAO_VON v_us = new US_GD_CHI_TIET_GIAO_VON();
				//DS_GD_CHI_TIET_GIAO_VON v_ds = new DS_GD_CHI_TIET_GIAO_VON();
				//v_us.FillDataset(v_ds, "where id = " + m_hdf_id_giao_kh.Value);
				//if (v_ds.GD_GIAO_VON.Count > 0)
				//{
				//	m_lbl_mess_grid.Text = "Bạn không thể xoá bản ghi này, dữ liệu này đang được sử dụng!";
				//	return false;
				//}
			}
			else
			{
				if (m_hdf_id_quyet_dinh.Value.Trim().Equals(""))
				{
					m_lbl_mess_chon_qd.Text = "Bạn phải nhập QĐ giao Kế hoạch hoặc Chọn QĐ đã nhập!";
					m_txt_so_qd.Focus();
					return false;
				}
				if (CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue) == -1)
				{
					m_lbl_mess_detail.Text += "\n Bạn phải chọn Loại nhiệm vụ!";
					m_ddl_loai_nhiem_vu.Focus();
					m_lbl_mess_detail.Focus();
					return false;
				}
				if (m_pnl_chuong_loai_khoan_muc.Visible == true)// Chi theo Loai khoan muc
				{
					if (m_ddl_chuong.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Loại nhiệm vụ!";
						m_ddl_chuong.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					if (m_ddl_loai.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Loại!";
						m_ddl_loai.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					if (m_ddl_khoan.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Khoản!";
						m_ddl_khoan.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					if (m_ddl_muc.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Mục!";
						m_ddl_muc.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					if (m_ddl_tieu_muc.Items.Count > 1 && m_ddl_tieu_muc.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Tiểu mục!";
						m_ddl_tieu_muc.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					if (m_txt_noi_dung_du_toan.Text == "")
					{
						m_lbl_mess_noi_dung_du_toan.Text += "\n Bạn phải nhập Nội dung dự toán!";
						m_txt_noi_dung_du_toan.Focus();
						return false;
					}
				}
				else//Chi theo Cong trinh/Du an
				{
					//kiem tra Cong trinh
					if (m_ddl_cong_trinh.Visible == true && m_ddl_cong_trinh.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Quốc lộ/Công trình!";
						m_ddl_cong_trinh.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					else if (!CValidateTextBox.IsValid(m_txt_quoc_lo, DataType.StringType, allowNull.NO) && CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue) == -1)
					{
						m_lbl_mess_detail.Text += "\n Bạn phải nhập Tên quốc lộ/Công trình!";
						m_txt_quoc_lo.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					//kiem tra Du An
					if (m_ddl_du_an.Visible == true && m_ddl_du_an.SelectedValue == "-1")
					{
						m_lbl_mess_detail.Text += "\n Bạn phải chọn Dự án!";
						m_ddl_du_an.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					else if (!CValidateTextBox.IsValid(m_txt_du_an, DataType.StringType, allowNull.NO) && CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue) == -1)
					{
						m_lbl_mess_detail.Text += "\n Bạn phải nhập Tên dự án!";
						m_txt_du_an.Focus();
						m_ddl_loai_nhiem_vu.Focus();
						return false;
					}
					////bo dinh dang #,###,##
					//m_txt_so_tien_nam_truoc_chuyen_sang.Text = m_txt_so_tien_nam_truoc_chuyen_sang.Text.Trim().Replace(",", "").Replace(".", "");
					//m_txt_so_tien.Text = m_txt_so_tien.Text.Trim().Replace(",", "").Replace(".", "");
					////validate textbox so tien
					//if (!CValidateTextBox.IsValid(m_txt_so_tien_nam_truoc_chuyen_sang, DataType.NumberType, allowNull.NO)

					//    && !CValidateTextBox.IsValid(m_txt_so_tien, DataType.NumberType, allowNull.NO))
					//{
					//    m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
					//    m_txt_so_tien_nam_truoc_chuyen_sang.Focus();
					//    m_ddl_loai_nhiem_vu.Focus();
					//    return false;
					//}

					//if (CIPConvert.ToDecimal(m_txt_so_tien.Text) <= 0)
					//{
					//    m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
					//    m_txt_so_tien.Focus();
					//    m_ddl_loai_nhiem_vu.Focus();
					//    return false;
					//}
				}

				//bo dinh dang #,###,##
				m_txt_so_tien_nam_truoc_chuyen_sang.Text = m_txt_so_tien_nam_truoc_chuyen_sang.Text.Trim().Replace(",", "").Replace(".", "");
				m_txt_so_tien.Text = m_txt_so_tien.Text.Trim().Replace(",", "").Replace(".", "");
				//validate textbox so tien
				if (!CValidateTextBox.IsValid(m_txt_so_tien_nam_truoc_chuyen_sang, DataType.NumberType, allowNull.NO)

					&& !CValidateTextBox.IsValid(m_txt_so_tien, DataType.NumberType, allowNull.NO))
				{
					m_lbl_mess_so_tien.Text += "\n Bạn phải nhập Số tiền!";
					m_txt_so_tien_nam_truoc_chuyen_sang.Focus();
					return false;
				}

				if (CIPConvert.ToDecimal(m_txt_so_tien.Text) <= 0||m_txt_so_tien.Text.Count()>13)
				{
					m_lbl_mess_so_tien.Text += "\n Bạn phải nhập Số tiền mục này!";
					m_txt_so_tien.Focus();
					return false;
				}
			}

			return true;
		}
		private string get_form_mode(HiddenField ip_hdf_form_mode)
		{
			if (ip_hdf_form_mode.Value.Equals("0"))
			{
				return LOAI_FORM.THEM;
			}
			if (ip_hdf_form_mode.Value.Equals("1"))
			{
				return LOAI_FORM.SUA;
			}
			if (ip_hdf_form_mode.Value.Equals("2"))
			{
				return LOAI_FORM.XOA;
			}
			return LOAI_FORM.THEM;
		}
		private void set_form_mode(string ip_loai_form)
		{
			if (ip_loai_form.Equals(LOAI_FORM.THEM))
			{
				m_hdf_form_mode.Value = "0";
			}
			if (ip_loai_form.Equals(LOAI_FORM.SUA))
			{
				m_hdf_form_mode.Value = "1";
			}
			if (ip_loai_form.Equals(LOAI_FORM.XOA))
			{
				m_hdf_form_mode.Value = "2";
			}
		}
		private bool form_to_us_object()
		{
			switch (get_form_mode(m_hdf_form_mode))
			{
				case LOAI_FORM.SUA:
					m_us.dcID = CIPConvert.ToDecimal(this.m_hdf_id_giao_kh.Value);
					break;
				case LOAI_FORM.THEM:
					m_us = new US_GD_CHI_TIET_GIAO_KH();
					break;
			}

            m_us.strGHI_CHU_2 = m_txt_so_km.Text.Replace(",", "").Replace(".", "").Trim();//ghi vao ghi chu 2

			m_us.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);
			//neu form mode la Quy BT thi so_tien_ns=0
			if (Request.QueryString["ip_nguon_ns"] == "N")
			{
				m_us.dcSO_TIEN_NS = 0;
				m_us.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_so_tien.Text.Replace(",", "").Replace(".", "").Trim());
			}
			else
			{
				m_us.dcSO_TIEN_QUY_BT = 0;
				m_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_so_tien.Text.Trim());
			}
			m_us.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG = CIPConvert.ToDecimal(m_txt_so_tien_nam_truoc_chuyen_sang.Text.Replace(",", "").Replace(".", "").Trim());
			//m_us.strTEN_DU_AN = m_txt_noi_dung_chi.Text.Trim();
			m_us.strGHI_CHU = m_txt_ghi_chu.Text; ;

			m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			m_us.dcID_DON_VI = Person.get_id_don_vi();

			if (m_pnl_chuong_loai_khoan_muc.Visible == true)
			{
				m_us.dcID_CHUONG = CIPConvert.ToDecimal(m_ddl_chuong.SelectedValue);
				m_us.dcID_KHOAN = CIPConvert.ToDecimal(m_ddl_khoan.SelectedValue);
				m_us.dcID_MUC = CIPConvert.ToDecimal(m_ddl_muc.SelectedValue);
				m_us.dcID_TIEU_MUC = CIPConvert.ToDecimal(m_ddl_tieu_muc.SelectedValue);
				if (m_us.dcID_TIEU_MUC == -1)
				{
					m_us.SetID_TIEU_MUCNull();
				}
				m_us.SetID_CONG_TRINHNull();
				m_us.SetID_DU_ANNull();
				m_us.strGHI_CHU_1 = m_txt_noi_dung_du_toan.Text.Trim();
				if (m_rdb_chi_thuong_xuyen.Checked == true)
				{
					m_us.strTU_CHU_YN = "Y";
				}
				else m_us.strTU_CHU_YN = "N";
			}
			else
			{
				m_us.SetID_CHUONGNull();
				m_us.SetID_KHOANNull();
				m_us.SetID_MUCNull();
				m_us.SetID_TIEU_MUCNull();
				m_us.dcID_CONG_TRINH = insert_cong_trinh();
				if (m_us.dcID_CONG_TRINH == -1)//insert cong trinh bi loi
				{
					m_lbl_mess_detail.Text = "Đã có lỗi trong quá trình thực hiện. Bạn vui lòng thực hiện lại thao tác!";
					return false;
				}
				else
				{
					m_us.dcID_DU_AN = insert_du_an(m_us.dcID_CONG_TRINH);
				}
			}
			return true;
		}
		private void us_object_to_form()
		{
			m_us = new US_GD_CHI_TIET_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));


			if (!m_us.IsTU_CHU_YNNull())
			{
				if (m_us.strTU_CHU_YN == "Y")
				{
					m_rdb_chi_thuong_xuyen.Checked = true;
					m_rdb_chi_khong_thuong_xuyen.Checked = false;
				}
				else
				{
					m_rdb_chi_thuong_xuyen.Checked = false;
					m_rdb_chi_khong_thuong_xuyen.Checked = true;
				}
			}

            m_txt_so_km.Text = m_us.strGHI_CHU_2;

			if (Request.QueryString["ip_nguon_ns"] == "N")
			{
				m_txt_so_tien.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_QUY_BT);
			}
			else
			{
				m_txt_so_tien.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NS);
			}

			m_txt_so_tien_nam_truoc_chuyen_sang.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG);
			m_txt_ghi_chu.Text = m_us.strGHI_CHU;
			//m_txt_ten_quoc_lo.Text = v_us_du_an_cong_trinh.strTEN_DU_AN_CONG_TRINH.Replace("Quốc lộ ","");
			if (!m_us.IsID_CONG_TRINHNull())
			{
				m_rdb_theo_quoc_lo.Checked = true;
				m_rdb_theo_chuong_loai_khoan_muc.Checked = false;

				m_rdb_theo_quoc_lo_CheckedChanged(null, null);

				US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(m_us.dcID_DU_AN);
				US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_cong_trinh = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(v_us_du_an.dcID_CHA);
				//set cong trinh
				m_ddl_cong_trinh.SelectedValue = v_us_du_an.dcID_CHA.ToString();
				m_ddl_cong_trinh_SelectedIndexChanged(null, null);
				m_txt_quoc_lo.Text = v_us_cong_trinh.strTEN;
				m_ddl_cong_trinh.Visible = true;
				m_txt_quoc_lo.Visible = false;
				m_cmd_chon_quoc_lo.Visible = false;
				m_cmd_them_quoc_lo.Visible = true;
				//set du an
				m_txt_du_an.Text = v_us_du_an.strTEN;
				m_txt_du_an.Visible = false;
				m_ddl_du_an.Visible = true;
				m_cmd_chon_du_an.Visible = false;
				m_cmd_them_du_an.Visible = true;
				m_ddl_du_an.SelectedValue = v_us_du_an.dcID.ToString();
				m_rdb_theo_chuong_loai_khoan_muc.Checked = false;
				m_rdb_theo_quoc_lo.Checked = true;
			}
			else
			{
				m_rdb_theo_quoc_lo.Checked = false;
				m_rdb_theo_chuong_loai_khoan_muc.Checked = true;

				m_rdb_theo_chuong_loai_khoan_muc_CheckedChanged(null, null);
				m_ddl_chuong.SelectedValue = m_us.dcID_CHUONG.ToString();
				US_DM_CHUONG_LOAI_KHOAN_MUC v_us_khoan = new US_DM_CHUONG_LOAI_KHOAN_MUC(m_us.dcID_KHOAN);
				m_ddl_loai.SelectedValue = v_us_khoan.dcID_CHA.ToString();
				m_ddl_loai_SelectedIndexChanged(null, null);
				m_ddl_khoan.SelectedValue = m_us.dcID_KHOAN.ToString();
				m_ddl_muc.SelectedValue = m_us.dcID_MUC.ToString();
				m_ddl_muc_SelectedIndexChanged(null, null);
				if (!m_us.IsID_TIEU_MUCNull())
				{
					m_ddl_tieu_muc.SelectedValue = m_us.dcID_TIEU_MUC.ToString();
				}
				m_rdb_theo_chuong_loai_khoan_muc.Checked = true;
				m_rdb_theo_quoc_lo.Checked = false;
			}
			m_ddl_loai_nhiem_vu.Focus();
			m_ddl_loai_nhiem_vu.SelectedValue = m_us.dcID_LOAI_NHIEM_VU.ToString();
			load_panel_loai_chi();
			m_txt_noi_dung_du_toan.Text = m_us.strGHI_CHU_1;


			//set quyet dinh
			US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(m_us.dcID_QUYET_DINH);
			m_txt_so_qd.Text = v_us_quyet_dinh.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us_quyet_dinh.strNOI_DUNG;
			//m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
			m_lbl_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
			m_hdf_id_quyet_dinh.Value = v_us_quyet_dinh.dcID.ToString();

			disable_edit_quyet_dinh();

		}
		private void disable_edit_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			//m_txt_ngay_thang.Enabled = false;
			//m_cmd_luu_qd.Visible = false;
		}

		private void set_inital_form_mode()
		{
			//load dropdownlist danh sach don vi ma don vi X duoc xem du lieu
			WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
			xoa_trang();
			load_data_to_cbo_quyet_dinh();
			if (m_ddl_quyet_dinh.Visible==false)
			{
				if (m_ddl_quyet_dinh.Items.Count>=2)
				{
					m_ddl_quyet_dinh.SelectedIndex = 1;
				}
				m_cmd_chon_qd_da_nhap_Click(null, null);
				m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
			}
			load_data_to_ddl_chuong();
			load_data_to_ddl_loai();
			load_data_to_ddl_khoan();
			load_data_to_ddl_muc();
			load_data_to_ddl_tieu_muc();
			//load_data_to_cbo_quoc_lo();
			//load_data_to_du_an();
			//load_data_to_ddl_loai_nhiem_vu();
			load_panel_loai_chi();
			load_data_to_grid();

		}
		private void xoa_trang()
		{
			//m_lbl_mess_qd.Text = "";
			//m_lbl_mess.Text = "";
			//m_lbl_mess_detail.Text = "";

			set_form_mode(LOAI_FORM.THEM);
			m_grv.SelectedIndex = -1;

			m_hdf_id_giao_kh.Value = "";
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_quyet_dinh.Value = "";
			//m_hdf_id_du_an.Value = "";

			///m_txt_ctx_so_tien_ns.Text = "0";
			//m_txt_so_tien_ns.Text = "0";

			//m_txt_ctx_so_tien_nam_truoc_chuyen_sang.Text = "0";
			m_txt_so_tien_nam_truoc_chuyen_sang.Text = "0";

			//m_txt_ctx_so_tien_qbt.Text = "0";
			m_txt_so_tien.Text = "0";
			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";

			//m_cmd_ctx_update.Visible = false;
			//m_cmd_ctx_insert.Visible = true;

			m_txt_du_an.Text = "";
			m_txt_ghi_chu.Text = "";

			m_cmd_update.Visible = false;
			m_ddl_loai_nhiem_vu.Enabled = true;
			m_cmd_insert.Visible = true;

		}
		private void save_data()
		{
			m_lbl_mess_detail.Text = "";
			m_lbl_mess_detail.Visible = true;
			//m_lbl_mess_ghi_du_lieu.Text = "";
			if (!check_validate_data_gd_is_ok()) return;
			if (!form_to_us_object()) return;

			switch (get_form_mode(m_hdf_form_mode))
			{
				case LOAI_FORM.THEM:
					m_us.Insert();
					m_lbl_mess_detail.Text = "Bạn đã ghi dữ liệu thành công!";
					break;
				case LOAI_FORM.SUA:
					try
					{
						//m_us.BeginTransaction();

						US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
						US_GD_CHI_TIET_GIAO_KH v_us_ten_cu = new US_GD_CHI_TIET_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
						//m_us.update_ten_du_an_giao_kh_to_giao_von_va_unc(Person.get_id_don_vi()
						//	, v_us_ten_cu.dcID_LOAI_NHIEM_VU
						//	, v_us_ten_cu.dcID_DU_AN_CONG_TRINH 
						//	, v_us_ten_cu.strTEN_DU_AN
						//	, m_us.strTEN_DU_AN
						//	, WinFormControls.get_dau_nam_form_date(v_us_quyet_dinh.datNGAY_THANG)
						//	, WinFormControls.get_cuoi_nam_form_date(v_us_quyet_dinh.datNGAY_THANG));
						m_us.Update();
						m_lbl_mess_detail.Text = "Bạn đã cập nhật dữ liệu thành công!";
						//m_us.CommitTransaction();
					}
					catch (Exception)
					{
						//m_us.Rollback();
						m_lbl_mess_detail.Text = "Quá trình cập nhật xảy ra lỗi, bạn vui lòng thực hiện lại thao tác!";
					}
					break;
			}
			xoa_trang();
			//m_ddl_du_an.SelectedValue = "-1";
			load_data_to_grid();
		}
		private void delete_gd_chi_tiet_giao_kh_by_ID()
		{
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			load_data_to_grid();
			m_lbl_mess_detail.Text = "Xoá bản ghi thành công!";
		}
		private decimal insert_cong_trinh()
		{
			decimal v_dc_id_cong_trinh = -1;
			//kiem tra xem nguoi dung dang Chon Cong trinh hay dang nhap
			//Neu dang chon -> lay ra id cong trinh
			if (m_ddl_cong_trinh.Visible == true)
			{
				return CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue);
			}
			else
			{
				//Neu dang nhap ->insert 1 cong trinh moi
				try
				{
					//0. khi chi nhap ten quoc lo vd: 1A thì lưu lại thành 'Quốc lộ 1A'
					if (m_txt_quoc_lo.Text.Trim().Length < 5)
					{
						m_txt_quoc_lo.Text = "Quốc lộ " + m_txt_quoc_lo.Text.Trim();
					}
					//1. kiểm tra xem đã có tên quốc lộ trong bản DM_CONG_TRINH_DU_AN_GOI_THAU chưa 
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
					DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
					v_us.FillDataset(v_ds, "where " + DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + "= N'" + m_txt_quoc_lo.Text + "'" +
						"and " + DM_CONG_TRINH_DU_AN_GOI_THAU.ID_LOAI + "=" + ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH);
					//1.1 Nếu có rồi thì không thêm nữa
					if (v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU.Count > 0)
					{
						v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(CIPConvert.ToDecimal(v_ds.Tables[0].Rows[0][DM_CONG_TRINH_DU_AN_GOI_THAU.ID]));
					}
					else
					{
						//1.2 Nếu chưa có thì thêm mới
						v_us.dcID_DON_VI = Person.get_id_don_vi();
						v_us.strTEN = m_txt_quoc_lo.Text.Trim();
						v_us.SetID_CHANull();
						v_us.dcID_LOAI = ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH;
						v_us.Insert();
					}
					v_dc_id_cong_trinh = v_us.dcID;
					return v_dc_id_cong_trinh;
				}
				catch (Exception)
				{
					return v_dc_id_cong_trinh;
				}
			}

		}
		private decimal insert_du_an(decimal ip_dc_id_cong_trinh)
		{
			decimal v_dc_id_du_an = -1;
			//Kiem tra xem nguoi dung dang Chon du an hay dang nhap du an
			if (m_ddl_du_an.Visible == true)
			{
				//kiem tra xem du an da chon co cha la cong trinh khong
				//neu khong phai, ta phai them 1 du an moi
				US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue));
				if (v_us_du_an.dcID_CHA != ip_dc_id_cong_trinh)
				{
					v_us_du_an.dcID_CHA = ip_dc_id_cong_trinh;
					v_us_du_an.Insert();
					return v_us_du_an.dcID;
				}
				else return CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue);
			}
			else //neu nguoi dung dang Nhap 1 du an moi thi ta phai insert 1 du an moi
			{
				try
				{
					//1. kiểm tra xem đã có dự án trong bảng DM_CONG_TRINH_DU_AN_GOI_THAU chưa 
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
					DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
					v_us.FillDataset(v_ds, "where " + DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + "= N'" + m_txt_du_an.Text.Trim() + "'" +
						"and " + DM_CONG_TRINH_DU_AN_GOI_THAU.ID_LOAI + "=" + ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN +
						"and " + DM_CONG_TRINH_DU_AN_GOI_THAU.ID_CHA + "=" + ip_dc_id_cong_trinh);
					//1.1 Nếu có rồi thì không thêm nữa
					if (v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU.Count > 0)
					{
						v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(CIPConvert.ToDecimal(v_ds.Tables[0].Rows[0][DM_CONG_TRINH_DU_AN_GOI_THAU.ID]));
					}
					else
					{
						//1.2 Nếu chưa có thì thêm mới
						v_us.dcID_DON_VI = Person.get_id_don_vi();
						v_us.strTEN = m_txt_du_an.Text.Trim();
						v_us.dcID_LOAI = ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN;
						v_us.dcID_CHA = ip_dc_id_cong_trinh;
						v_us.Insert();
					}
					v_dc_id_du_an = v_us.dcID;
					return v_dc_id_du_an;

				}
				catch (Exception)
				{
					return v_dc_id_du_an;
				}
			}

		}
		#endregion

		#region Event
		protected void m_ddl_loai_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_khoan();
		}
		protected void m_ddl_muc_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_tieu_muc();
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_chon_qd.Text = "";
				m_lbl_mess_detail.Text = "";
				m_lbl_mess_grid.Text = "";
				if (!IsPostBack)
				{
					set_inital_form_mode();
					if (Request.QueryString["ip_dc_id_quyet_dinh"] != null)
					{
						decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_quyet_dinh"]);
						load_data_to_cbo_quyet_dinh();
						m_ddl_quyet_dinh.SelectedValue = v_dc_id_quyet_dinh.ToString();
						m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
					}

					if (Request.QueryString["ip_dc_id_don_vi"] != null)
					{
						decimal v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
						WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
						m_ddl_don_vi.SelectedValue = v_dc_id_don_vi.ToString();
						m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
					}
					else m_ddl_don_vi.SelectedValue = Person.get_id_don_vi().ToString();

					//kiem tra xem dang nhap Nguon nao
					if (Request.QueryString["ip_nguon_ns"] == "Y")
					{
						m_lbl_so_tien.Text = "KP Ngân sách (*)";
						m_lbl_title.Text = "Nhập giao kế hoạch - Nguồn Ngân sách";
						m_rdb_theo_chuong_loai_khoan_muc.Checked = true;
						m_rdb_theo_quoc_lo.Checked = false;
						m_rdb_theo_chuong_loai_khoan_muc_CheckedChanged(null, null);
					}
					else
					{
						m_lbl_so_tien.Text = "KP Quỹ bảo trì (*)";
						m_lbl_title.Text = "Nhập giao kế hoạch - Nguồn Quỹ bảo trì";
						m_rdb_theo_chuong_loai_khoan_muc.Checked = false;
						m_rdb_theo_quoc_lo.Checked = true;
						m_rdb_theo_quoc_lo_CheckedChanged(null, null);
					}
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
				m_lbl_mess_grid.Text = "";
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}



		protected void m_grv_PageIndexChanging(object sender, GridViewPageEventArgs e)
		{
			m_grv.PageIndex = e.NewPageIndex;
			m_grv.SelectedIndex = -1;
			load_data_to_grid();
			if (!m_hdf_id_giao_kh.Value.Equals(""))
			{
				m_grv.SelectedIndex = -1;
				for (int i = 0; i < m_grv.Rows.Count; i++)
					if (CIPConvert.ToDecimal(m_grv.DataKeys[i].Value) == CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value)) m_grv.SelectedIndex = i;
			}
		}
		protected void m_grv_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					LinkButton m_lbl_delete = (LinkButton)e.Row.FindControl("m_lbl_delete");
					LinkButton m_lbl_update = (LinkButton)e.Row.FindControl("m_lbl_update");
					if (m_lbl_delete != null)
					{
						if (m_lbl_delete.CommandArgument.Trim().Equals("-1"))
						{
							m_lbl_delete.Visible = false;
							e.Row.CssClass = "cssFontBold";
						}
						else
						{
							m_lbl_delete.Visible = true;
						}
					}
					if (m_lbl_update != null)
					{
						if (m_lbl_update.CommandArgument.Trim().Equals("-1"))
						{
							m_lbl_update.Visible = false;
						}
						else
						{
							m_lbl_update.Visible = true;
						}
					}

				}
			}
			catch (Exception ex)
			{

				CSystemLog_301.ExceptionHandle(this, ex);
			}

		}
		protected void m_grv_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "Sua")
				{
					m_lbl_mess_grid.Text = "";
					xoa_trang();
					//format button by form mode - update
					m_cmd_update.Visible = true;
					m_cmd_insert.Visible = false;
					if (m_ddl_don_vi.SelectedValue != Person.get_id_don_vi().ToString())
					{
						m_grv.Columns[0].Visible = false;
						m_cmd_insert.Visible = false;
						m_cmd_update.Visible = false;
						m_cmd_cancel.Visible = false;
					}

					//set select row in gridview
					GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
					m_grv.SelectedIndex = gvr.RowIndex;

					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					m_us = new US_GD_CHI_TIET_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));

					//m_grv.SelectedIndex = m_grv.SelectedRow.RowIndex;
					set_form_mode(LOAI_FORM.SUA);
					//reset control

					us_object_to_form();
				}
				else if (e.CommandName == "Xoa")
				{
					m_lbl_mess_grid.Text = "";
					set_form_mode(LOAI_FORM.XOA);
					m_hdf_id_giao_kh.Value = CIPConvert.ToStr(e.CommandArgument);
					if (!check_validate_data_gd_is_ok()) return;
					delete_gd_chi_tiet_giao_kh_by_ID();
				}
			}
			catch (Exception v_e)
			{
				m_lbl_mess_grid.Text = v_e.ToString();
			}

		}


		protected void m_cmd_insert_Click(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_detail.Text = "";
				m_lbl_mess_chon_qd.Text = "";
				m_lbl_mess_noi_dung_du_toan.Text = "";
				m_lbl_mess_so_tien.Text = "";
				set_form_mode(LOAI_FORM.THEM);
				save_data();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_update_Click(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_detail.Text = "";
				set_form_mode(LOAI_FORM.SUA);
				save_data();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_cancel_Click(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess_detail.Text = "";
				m_lbl_mess_qd.Text = "";
				m_hdf_id_du_an.Value = "";
				xoa_trang();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}


		protected void m_cmd_chon_qd_da_nhap_Click(object sender, EventArgs e)
		{
			m_lbl_mess_chon_qd.Text = "";
			m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
			load_data_to_cbo_quyet_dinh();
			m_ddl_quyet_dinh.Visible = true;
			m_txt_so_qd.Visible = false;
			m_txt_noi_dung.Visible = false;
			//m_txt_ngay_thang.Visible = false;
			//m_cmd_luu_qd.Visible = false;

			//reload_data_to_ddl();

		}
		private void load_data_when_quyet_dinh_is_selected()
		{
			m_txt_so_qd.Visible = true;
			m_txt_noi_dung.Visible = true;
			//m_txt_ngay_thang.Visible = true;

			disable_edit_quyet_dinh();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
			m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us.strNOI_DUNG;
			//m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
			m_lbl_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

			//reload_data_to_ddl();            
			load_data_to_cbo_quoc_lo();
			//load_data_to_du_an();
			load_data_to_ddl_loai_nhiem_vu();
			load_data_to_grid();
		}

		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ddl_quyet_dinh.SelectedValue == null) return;
			m_ddl_quyet_dinh.Visible = false;
			m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
			load_data_when_quyet_dinh_is_selected();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue));
			if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.KH_DAU_NAM)
			{
				//m_rdb_kh_dau_nam.Checked = true;
				//m_rdb_dieu_chinh.Checked = false;
				//m_rdb_bo_sung.Checked = false;
				m_lbl_loai_quyet_dinh.Text = "Đầu năm";
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.BO_SUNG)
			{
				//m_rdb_kh_dau_nam.Checked = false;
				//m_rdb_dieu_chinh.Checked = false;
				//m_rdb_bo_sung.Checked = true;
				m_lbl_loai_quyet_dinh.Text = "Bổ sung";
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.DIEU_CHINH)
			{
				//m_rdb_kh_dau_nam.Checked = false;
				//m_rdb_dieu_chinh.Checked = true;
				//m_rdb_bo_sung.Checked = false;
				m_lbl_loai_quyet_dinh.Text = "Điều chỉnh";
			}

		}
		protected void m_cmd_nhap_qd_moi_Click(object sender, EventArgs e)
		{
			m_hdf_id_quyet_dinh.Value = "";

			m_ddl_quyet_dinh.Visible = false;
			m_txt_so_qd.Enabled = true;
			m_txt_noi_dung.Enabled = true;
			//m_txt_ngay_thang.Enabled = true;

			m_txt_so_qd.Visible = true;
			m_txt_noi_dung.Visible = true;
			//m_txt_ngay_thang.Visible = true;

			//m_cmd_luu_qd.Visible = true;

			m_txt_so_qd.Text = "";
			m_txt_noi_dung.Text = "";
			//m_txt_ngay_thang.Text = "";

		}
		protected void m_cmd_luu_qd_Click(object sender, EventArgs e)
		{
			try
			{
				m_hdf_id_quyet_dinh.Value = "";
				//check validate luu quyet dinh
				if (check_data_quyet_dinh_is_ok() == true)
				{
					m_hdf_id_quyet_dinh.Value = insert_quyet_dinh().ToString();
				}
				else return;
				// insert gd quyet dinh
				//do not edit
				disable_info_quyet_dinh();
				m_lbl_mess_qd.Text = "Lưu QĐ thành công!";
				//set id to hiddenfield
				load_data_to_cbo_quyet_dinh();
				m_ddl_quyet_dinh.SelectedValue = m_hdf_id_quyet_dinh.Value;
				m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		private decimal insert_quyet_dinh()
		{
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			//if (m_rdb_kh_dau_nam.Checked == true)
			//{
			//	v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
			//}
			//else if (m_rdb_bo_sung.Checked == true)
			//{
			//	v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.BO_SUNG;
			//}
			//else v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.DIEU_CHINH;
			v_us.dcID_DON_VI = Person.get_id_don_vi();
			v_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
			v_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
			v_us.strSO_QUYET_DINH = m_txt_so_qd.Text.Trim();
			//v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");

			v_us.Insert();
			return v_us.dcID;
		}
		private void disable_info_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			//m_txt_ngay_thang.Enabled = false;
		}
		private bool check_data_quyet_dinh_is_ok()
		{
			if (m_txt_so_qd.Text.Trim().Equals(""))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Số quyết định!";
				m_txt_so_qd.Focus();
				return false;
			}
			if (m_txt_noi_dung.Text.Trim().Equals(""))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Nội dung quyết định!";
				m_txt_noi_dung.Focus();
				return false;
			}
			//if (m_txt_ngay_thang.Text.Trim().Equals(""))
			//{
			//	m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
			//	m_txt_ngay_thang.Focus();
			//	return false;
			//}
			DateTime v_dat_ngay_thang = DateTime.Now;
			try
			{
				//v_dat_ngay_thang = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim());
			}
			catch (Exception)
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
				//m_txt_ngay_thang.Focus();
				return false;
			}
			return true;
		}

		protected void m_cmd_them_quoc_lo_Click(object sender, EventArgs e)
		{
			// Chuyển ddl_quoc_lo về mặc định
			m_ddl_cong_trinh.Visible = false;
			m_ddl_cong_trinh.SelectedValue = "-1";
			// Hiển thị text nhập tên quốc lộ
			m_txt_quoc_lo.Visible = true;
			m_txt_quoc_lo.Text = "";

			m_cmd_them_quoc_lo.Visible = false;
			m_cmd_chon_quoc_lo.Visible = true;

			//hien thi text nhap ten du an
			m_cmd_them_du_an_Click(null, null);
		}
		protected void m_cmd_them_du_an_Click(object sender, EventArgs e)
		{
			// Chuyển m_ddl_du_an về mặc định
			m_ddl_du_an.Visible = false;
			m_ddl_du_an.SelectedValue = "-1";
			// Hiển thị text nhập tên dự án
			m_txt_du_an.Visible = true;
			m_txt_du_an.Text = "";

			m_cmd_them_du_an.Visible = false;
			m_cmd_chon_du_an.Visible = true;
		}

		protected void m_cmd_chon_quoc_lo_Click(object sender, EventArgs e)
		{
			// Chuyển m_ddl_du_an về mặc định
			m_ddl_cong_trinh.Visible = true;
			m_ddl_cong_trinh.SelectedValue = "-1";
			// Ẩn text nhập tên cong trinh
			m_txt_quoc_lo.Visible = false;
			m_txt_quoc_lo.Text = "";
			//Hien thi text nhap ten du an
			m_cmd_chon_du_an_Click(null, null);


			m_cmd_them_quoc_lo.Visible = true;
			m_cmd_chon_quoc_lo.Visible = false;
		}
		protected void m_cmd_chon_du_an_Click(object sender, EventArgs e)
		{
			// Chuyển m_ddl_du_an về mặc định
			m_ddl_du_an.Visible = true;
			m_ddl_du_an.SelectedValue = "-1";
			// Hiển thị text nhập tên dự án
			m_txt_du_an.Visible = false;
			m_txt_du_an.Text = "";

			m_cmd_them_du_an.Visible = true;
			m_cmd_chon_du_an.Visible = false;
		}

		protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_du_an();
		}

		protected void m_rdb_theo_chuong_loai_khoan_muc_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_loai_nhiem_vu();
				load_panel_loai_chi();
				//m_cmd_cancel_Click(null, null);
				//load_data_to_grid();
			}
			catch (Exception ex)
			{

				CSystemLog_301.ExceptionHandle(this, ex);
			}


		}

		protected void m_rdb_theo_quoc_lo_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_loai_nhiem_vu();
				load_panel_loai_chi();
				//m_cmd_cancel_Click(null, null);
				//load_data_to_grid();
			}
			catch (Exception ex)
			{

				CSystemLog_301.ExceptionHandle(this, ex);
			}

		}

		private void load_panel_loai_chi()
		{
			if (m_rdb_theo_chuong_loai_khoan_muc.Checked == true)
			{
				m_pnl_chuong_loai_khoan_muc.Visible = true;
				m_pnl_cong_trinh.Visible = false;
			}
			else
			{
				m_pnl_chuong_loai_khoan_muc.Visible = false;
				m_pnl_cong_trinh.Visible = true;
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