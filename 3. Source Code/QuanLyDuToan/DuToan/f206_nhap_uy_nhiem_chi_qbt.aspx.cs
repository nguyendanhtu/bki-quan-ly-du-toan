using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;
using System.Data;
using QuanLyDuToan.App_Code;
namespace QuanLyDuToan.DuToan
{
	public partial class f206_nhap_uy_nhiem_chi_qbt : System.Web.UI.Page
	{
		#region Public Interface
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

		public bool thao_tac_visible(string ip_str_id)
		{
			bool op_result = true;
			if (ip_str_id.Trim().Equals("") | ip_str_id.Trim().Equals("-1"))
			{
				op_result = false;
			}

			return op_result;
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
		DS_GD_CHI_TIET_GIAI_NGAN m_ds = new DS_GD_CHI_TIET_GIAI_NGAN();
		US_GD_CHI_TIET_GIAI_NGAN m_us = new US_GD_CHI_TIET_GIAI_NGAN();
		#endregion

		#region Private Methods
		private bool check_validate_is_ok()
		{
			bool v_b_result = true;

			decimal v_dc_so_tien = 0;

			return v_b_result;
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
		private void form_to_us_object()
		{
            //switch (get_form_mode(m_hdf_form_mode))
            //{
            //    case LOAI_FORM.SUA:
            //        m_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(this.m_hdf_id_gd_uy_nhiem_chi.Value));
            //        break;
            //    case LOAI_FORM.THEM:
            //        m_us = new US_GD_CHI_TIET_GIAI_NGAN();
            //        break;
            //}

            //m_us. = "N";//Nguon mac dinh la Quy bao tri
            //m_us.strNOI_DUNG_CHI = m_txt_ghi_chu.Text.Trim();
            //m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_hdf_id_du_an_cong_trinh.Value);
            //m_us.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(m_txt_so_tien_nop_thue.Text.Trim());
            //m_us.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(m_txt_so_tien_thanh_toan_cho_dv_huong.Text.Trim());
            //m_us.dcID_UNC = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
            //m_us.dcID_DON_VI = Person.get_id_don_vi();
            ////set null nguon ns
            //m_us.SetID_MUCNull();
            //m_us.SetID_KHOANNull();
            //m_us.SetID_CHUONGNull();
            //m_us.SetID_TIEU_MUCNull();
		}
		private void us_object_to_form()
		{
			//m_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_gd_uy_nhiem_chi.Value));
			//US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an_cong_trinh = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(m_us.dcID_DU_AN_CONG_TRINH);
			//m_hdf_id_du_an_cong_trinh.Value = m_us.dcID_DU_AN_CONG_TRINH.ToString();
			//if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
			//{
			//	m_rdb_chi_thuong_xuyen.Checked = true;
			//	m_rdb_chi_khong_thuong_xuyen.Checked = false;
			//}
			//else
			//{
			//	m_rdb_chi_thuong_xuyen.Checked = false;
			//	m_rdb_chi_khong_thuong_xuyen.Checked = true;
			//}
			////load_data_du_an_cong_trinh_by_loai();
			////set khoan chi
			//if (v_us_du_an_cong_trinh.dcID_LOAI_DU_AN_CONG_TRINH == ID_LOAI_DU_AN.QUOC_LO)
			//{
			//	m_ddl_quoc_lo.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
			//	m_ddl_du_an.Visible = false;
			//	m_ddl_quoc_lo.Visible = true;
			//}
			//else
			//{
			//	m_ddl_du_an.SelectedValue = m_us.dcID_DU_AN_CONG_TRINH.ToString();
			//	m_ddl_du_an.Visible = true;
			//	m_ddl_quoc_lo.Visible = false;

			//}
			//m_txt_so_tien_nop_thue.Text = m_us.dcSO_TIEN_NOP_THUE.ToString();
			//m_txt_so_tien_thanh_toan_cho_dv_huong.Text = m_us.dcSO_TIEN_TT_CHO_DV_HUONG.ToString();
			//m_txt_ghi_chu.Text = m_us.strNOI_DUNG_CHI;
			////set quyet dinh
			//US_DM_GIAI_NGAN v_US_DM_GIAI_NGAN = new US_DM_GIAI_NGAN(m_us.dcID_UNC);
			//US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
			//m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
			//m_txt_so_unc.Text = v_US_DM_GIAI_NGAN.strSO_UNC;
			//m_txt_ngay_thang.Text = CIPConvert.ToStr(v_US_DM_GIAI_NGAN.datNGAY_THANG, "dd/MM/yyyy");
			//m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;
			////m_rbl_ma_tkkt.Items.FindByText(v_US_DM_GIAI_NGAN.strMA_TKKT).Selected = true;
			//m_lbl_ma_dvqhns.Text = v_US_DM_GIAI_NGAN.strMA_DVQHNS;
			//m_txt_ma_ctmt_da_htct.Text = v_US_DM_GIAI_NGAN.strMA_CTMT_DA_HTCT;
			//m_hdf_id_dm_uy_nhiem_chi.Value = v_US_DM_GIAI_NGAN.dcID.ToString();
			////disable_edit_dm_uy_nhiem_chi();

		}


		private void set_inital_form_load()
		{
			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			load_thong_tin_don_vi();
			xoa_trang();
			load_data_to_cbo_dm_uy_nhiem_chi();
		}
		private void xoa_trang()
		{
			//m_lbl_mess_qd.Text = "";
			//m_lbl_mess.Text = "";
			//m_lbl_mess_detail.Text = "";

			set_form_mode(LOAI_FORM.THEM);
			//m_grv.SelectedIndex = -1;

			m_hdf_id_dm_uy_nhiem_chi.Value = "";
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_dm_uy_nhiem_chi.Value = "";
			//m_hdf_id_du_an.Value = "";



			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";



		}



		private void load_data_to_cbo_dm_uy_nhiem_chi()
		{
			WinFormControls.load_data_to_cbo_dm_uy_nhiem_chi(m_ddl_unc);
		}
		private void load_data_cong_trinh_du_an_giao_von_to_ddl(DropDownList op_ddl, WinFormControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				US_DM_GIAI_NGAN v_us_dm_unc = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
				DateTime v_dat_dau_nam = v_us_dm_unc.datNGAY_THANG;
				v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von(ip_loai_du_an
				, op_ddl);
			}
		}

		private void disable_control_unc()
		{
			m_txt_so_unc.Enabled = false;
			m_txt_ngay_thang.Enabled = false;
			m_txt_ma_ctmt_da_htct.Enabled = false;
		}

		private void enable_control_unc()
		{
			m_txt_so_unc.Enabled = true;
			m_txt_ngay_thang.Enabled = true;
			m_txt_ma_ctmt_da_htct.Enabled = true;
		}

		private void xoa_trang_control_unc()
		{

			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");

			m_txt_ma_ctmt_da_htct.Text = "";

			m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
			m_ddl_unc.Visible = false;
			m_txt_so_unc.Visible = true;
			m_cmd_luu_unc.Visible = true;
			//info dm unc
			load_thong_tin_don_vi();
		}

		private void load_thong_tin_don_vi()
		{
			US_DM_DON_VI v_us_dv = new US_DM_DON_VI(Person.get_id_don_vi());
			m_lbl_don_vi_tra_tien.Text = v_us_dv.strTEN_DON_VI;
			US_DM_THONG_TIN_DON_VI v_us_ttdv = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
			m_lbl_dia_chi.Text = v_us_ttdv.strDIA_CHI;
			m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_ttdv.strKHO_BAC;
			m_lbl_ma_dvqhns.Text = v_us_ttdv.strMA_DVQHNS;
			m_rbl_ma_tkkt.Items.Clear();
			if (v_us_ttdv.IsMA_TKKT1Null() && v_us_ttdv.IsMA_TKKT2Null()) return;
			if (v_us_ttdv.IsMA_TKKT2Null() | v_us_ttdv.strMA_TKKT2.Trim().Equals(""))
			{
				ListItem v_li_1 = new ListItem(v_us_ttdv.strMA_TKKT1);
				m_rbl_ma_tkkt.Items.Add(v_li_1);
				m_rbl_ma_tkkt.Items[0].Selected = true;
			}
			else
			{
				ListItem v_li_1 = new ListItem(v_us_ttdv.strMA_TKKT1);
				ListItem v_li_2 = new ListItem(v_us_ttdv.strMA_TKKT2);
				m_rbl_ma_tkkt.Items.Add(v_li_1);
				m_rbl_ma_tkkt.Items.Add(v_li_2);
				m_rbl_ma_tkkt.Items[0].Selected = true;
			}
		}
		#endregion


		protected void Page_Load(object sender, EventArgs e)
		{

			if (!IsPostBack)
			{
				m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
				m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
				data_to_grid_unc();
				load_thong_tin_don_vi();
				set_inital_form_load();
				if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
					m_cmd_save_info_unc.Visible = false;
				else
				{
					m_cmd_save_info_unc.Visible = true;
					m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
					m_cmd_print.Visible = true;
				}
			}
		}

		protected void m_cmd_chon_unc_Click(object sender, EventArgs e)
		{
			m_txt_so_unc.Visible = false;
			m_ddl_unc.Visible = true;
			load_data_to_cbo_dm_uy_nhiem_chi();
		}


		protected void m_ddl_unc_SelectedIndexChanged(object sender, EventArgs e)
		{
			m_txt_so_unc.Visible = true;
			if (m_ddl_unc.SelectedValue == "-1" | m_ddl_unc.SelectedValue == "")
			{
				m_hdf_id_dm_uy_nhiem_chi.Value = "-1";
			}
			else
			{
				m_hdf_id_dm_uy_nhiem_chi.Value = m_ddl_unc.SelectedValue;
				if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
					m_cmd_save_info_unc.Visible = false;
				else
				{
					m_cmd_save_info_unc.Visible = true;
					m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
					m_cmd_print.Visible = true;
				}
				US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
				US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
				m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
				m_txt_so_unc.Text = v_us.strSO_UNC;
				m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");
				m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;
				if (v_us.strIS_NGUON_NS_YN.Trim().ToUpper() == "N")
				{
					m_rbl_ma_tkkt.SelectedIndex = 0;
				}
				else m_rbl_ma_tkkt.SelectedIndex = 1;
				//if (m_rbl_ma_tkkt.Items.FindByText(v_us.strMA_TKKT) != null)
				//	m_rbl_ma_tkkt.Items.FindByText(v_us.strMA_TKKT).Selected = true;
				m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
				m_txt_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;
				//info dm unc
				m_txt_nt_ten_don_vi.Text = v_us.strNT_TEN_DON_VI;
				m_txt_nt_ma_so_thue.Text = v_us.strNT_MA_SO_THUE;
				m_txt_nt_ma_ndkt.Text = v_us.strNT_MA_NDKT;
				m_txt_nt_ma_chuong.Text = v_us.strNT_MA_CHUONG;
				m_txt_nt_co_quan_quan_ly_thu.Text = v_us.strNT_CQ_QL_THU;
				m_txt_nt_ma_cq_thu.Text = v_us.strNT_MA_CQ_THU;
				m_txt_nt_kbnn_hach_toan_thu.Text = v_us.strNT_KBNN_HACH_TOAN_KHOAN_THU;
				m_txt_nt_so_tien_nop_thue.Text = v_us.strNT_SO_TIEN_NOP_THUE;

				m_txt_ttdvh_don_vi_nhan_tien.Text = v_us.strTTDVH_DON_VI_NHAN_TIEN;
				m_txt_ttdvh_ma_dvqhns.Text = v_us.strTTDVH_MA_DVQHNS;
				m_txt_ttdvh_dia_chi.Text = v_us.strTTDVH_DIA_CHI;
				m_txt_ttdvh_tai_khoan.Text = v_us.strTTDVH_TAI_KHOAN;
				m_txt_ttdvh_ma_ctmt_da_htct.Text = v_us.strTTDVH_MA_CTMT_DA_VA_HTCT;
				m_txt_ttdvh_tai_kbnn.Text = v_us.strTTDVH_KHO_BAC;
				m_txt_ttdvh_so_tien_thanh_toan.Text = v_us.strTTDVH_SO_TIEN;


				m_cmd_luu_unc.Visible = false;
				m_cmd_nhap_moi_unc.Visible = true;

				disable_control_unc();
				m_ddl_unc.Visible = false;
				data_to_grid_unc();
			}
		}
		protected void m_cmd_nhap_moi_unc_Click(object sender, EventArgs e)
		{
			enable_control_unc();
			xoa_trang_control_unc();
			data_to_grid_unc();
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			{
				m_cmd_save_info_unc.Visible = false;
				m_cmd_print.Visible = false;
			}
			else
			{
				m_cmd_save_info_unc.Visible = true;
				m_cmd_print.Visible = true;
			}
		}
		protected void m_cmd_luu_unc_Click(object sender, EventArgs e)
		{
			try
			{
				US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN();
				m_hdf_id_dm_uy_nhiem_chi.Value = "";
				//check validate luu quyet dinh

				if (m_txt_so_unc.Text.Trim().Equals(""))
				{
					m_lbl_mess_master.Text = "Bạn phải nhập Số Uỷ nhiệm chi!";
					m_txt_so_unc.Focus();
					return;
				}
				if (m_txt_ngay_thang.Text.Trim().Equals(""))
				{
					m_lbl_mess_master.Text = "Bạn phải nhập Ngày tháng!";
					m_txt_ngay_thang.Focus();
					return;
				}
				if (!CValidateTextBox.IsValid(m_txt_ma_ctmt_da_htct, DataType.StringType, allowNull.NO))
				{
					m_lbl_mess_master.Text = "Bạn phải nhập Mã CTMT, DA và HTCT!";
					m_txt_ma_ctmt_da_htct.Focus();
					return;
				}
				DateTime v_dat_ngay_thang = DateTime.Now;
				try
				{
					v_dat_ngay_thang = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
				}
				catch (Exception)
				{
					m_lbl_mess_master.Text = "Bạn phải nhập Ngày tháng!";
					m_txt_ngay_thang.Focus();
					return;
				}


				// insert gd quyet dinh
				v_us.dcID_DON_VI = Person.get_id_don_vi();
				//v_us.strDIA_CHI = m_lbl_dia_chi.Text.Trim();
				//v_us.strKHO_BAC_NHA_NUOC = m_lbl_tai_kho_bac_nha_nuoc.Text.Trim();
				v_us.strMA_CTMT_DA_HTCT = m_txt_ma_ctmt_da_htct.Text.Trim();
				v_us.strMA_DVQHNS = m_lbl_ma_dvqhns.Text.Trim();
				if (m_rbl_ma_tkkt.SelectedIndex == 0)
				{
					v_us.strIS_NGUON_NS_YN = "N";
				}
				else v_us.strIS_NGUON_NS_YN = "Y";
				//v_us.strMA_TKKT = m_rbl_ma_tkkt.SelectedItem.Text;
				v_us.strSO_UNC = m_txt_so_unc.Text.Trim();
				v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
				v_us.Insert();
				//do not edit
				disable_control_unc();
				m_lbl_mess_master.Text = "Lưu QĐ thành công!";
				//set id to hiddenfield
				m_hdf_id_dm_uy_nhiem_chi.Value = v_us.dcID.ToString();
				data_to_grid_unc();
				//get_so_tien_kh_giao();
				if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
					m_cmd_save_info_unc.Visible = false;
				else
				{
					m_cmd_save_info_unc.Visible = true;
					m_cmd_print.NavigateUrl = "~/ChucNang/F600_print_unc_qbt.aspx?ip_dc_id_dm_unc=" + m_hdf_id_dm_uy_nhiem_chi.Value;
					m_cmd_print.Visible = true;
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_cmd_save_info_unc_Click(object sender, EventArgs e)
		{
			try
			{
				if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
				{
					return;
				}
				US_DM_GIAI_NGAN v_us_dm_unc = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value));
				v_us_dm_unc.strNT_TEN_DON_VI = m_txt_nt_ten_don_vi.Text;
				v_us_dm_unc.strNT_MA_SO_THUE = m_txt_nt_ma_so_thue.Text;
				v_us_dm_unc.strNT_MA_NDKT = m_txt_nt_ma_ndkt.Text;
				v_us_dm_unc.strNT_MA_CHUONG = m_txt_nt_ma_chuong.Text;
				v_us_dm_unc.strNT_CQ_QL_THU = m_txt_nt_co_quan_quan_ly_thu.Text;
				v_us_dm_unc.strNT_MA_CQ_THU = m_txt_nt_ma_cq_thu.Text;
				v_us_dm_unc.strNT_KBNN_HACH_TOAN_KHOAN_THU = m_txt_nt_kbnn_hach_toan_thu.Text;
				v_us_dm_unc.strNT_SO_TIEN_NOP_THUE = m_txt_nt_so_tien_nop_thue.Text;

				v_us_dm_unc.strTTDVH_DON_VI_NHAN_TIEN = m_txt_ttdvh_don_vi_nhan_tien.Text;
				v_us_dm_unc.strTTDVH_MA_DVQHNS = m_txt_ttdvh_ma_dvqhns.Text;
				v_us_dm_unc.strTTDVH_DIA_CHI = m_txt_ttdvh_dia_chi.Text;
				v_us_dm_unc.strTTDVH_TAI_KHOAN = m_txt_ttdvh_tai_khoan.Text;
				v_us_dm_unc.strTTDVH_MA_CTMT_DA_VA_HTCT = m_txt_ttdvh_ma_ctmt_da_htct.Text;
				v_us_dm_unc.strTTDVH_KHO_BAC = m_txt_ttdvh_tai_kbnn.Text;
				v_us_dm_unc.strTTDVH_SO_TIEN = m_txt_ttdvh_so_tien_thanh_toan.Text;
				if (m_rbl_ma_tkkt.SelectedIndex == 0)
				{
					v_us_dm_unc.strIS_NGUON_NS_YN = "N";
				}
				else v_us_dm_unc.strIS_NGUON_NS_YN = "Y";
				//v_us_dm_unc.strMA_TKKT = m_rbl_ma_tkkt.SelectedItem.Text;
				v_us_dm_unc.Update();
				m_lbl_mess_info_unc.Text = "Đã cập nhật thông tin thành công!";
			}
			catch (Exception v_e)
			{
				m_lbl_mess_info_unc.Text = v_e.ToString();
			}
		}

		protected void m_rdb_grid_ctx_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				RadioButton v_rdb = (RadioButton)sender;
				GridViewRow v_gr = (GridViewRow)v_rdb.Parent.Parent;
				GridView v_grv = (GridView)v_gr.NamingContainer;
				//DropDownList v_ddl = (DropDownList)v_gr.FindControl("m_ddl_grid_du_an_quoc_lo");
				DropDownList v_ddl = (DropDownList)v_grv.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
				data_to_ddl_du_an_cong_trinh_grid(v_ddl, "TX");


			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		protected void m_rdb_grid_cktx_CheckedChanged(object sender, EventArgs e)
		{
			RadioButton v_rdb = (RadioButton)sender;
			GridViewRow v_gr = (GridViewRow)v_rdb.Parent.Parent;
			GridView v_grv = (GridView)v_gr.NamingContainer;
			//DropDownList v_ddl = (DropDownList)v_gr.FindControl("m_ddl_grid_du_an_quoc_lo");
			DropDownList v_ddl = (DropDownList)v_grv.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
			data_to_ddl_du_an_cong_trinh_grid(v_ddl, "KTX");
		}

		private void data_to_grid_unc()
		{
			US_GRID_GIAI_NGAN v_us = new US_GRID_GIAI_NGAN();
			DS_GRID_GIAI_NGAN v_ds = new DS_GRID_GIAI_NGAN();
            v_ds.EnforceConstraints = false;
            v_us.get_grid_giai_ngan(v_ds, Person.get_id_don_vi(), CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value),Person.get_user_id());
			m_grv_unc.DataSource = v_ds.Tables[0];
			m_grv_unc.DataBind();
		}

		private void data_to_ddl_du_an_cong_trinh_grid(DropDownList op_ddl, string ip_str)
		{
			if (ip_str.Trim().ToUpper() == "TX")
			{
				grid_data_cong_trinh_du_an_giao_von_to_ddl(op_ddl, WinFormControls.LOAI_DU_AN.QUOC_LO);
			}
			else
			{
				grid_data_cong_trinh_du_an_giao_von_to_ddl(op_ddl, WinFormControls.LOAI_DU_AN.KHAC);
			}

		}

		private void grid_data_cong_trinh_du_an_giao_von_to_ddl(DropDownList op_ddl, WinFormControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("") | m_hdf_id_dm_uy_nhiem_chi.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				DateTime v_dat = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
				DateTime v_dat_dau_nam = v_dat;
				v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von(ip_loai_du_an
				, op_ddl);
			}

		}

		protected void m_grv_unc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			m_grv_unc.EditIndex = -1;
			data_to_grid_unc();
		}

		protected void m_grv_unc_RowEditing(object sender, GridViewEditEventArgs e)
		{
			m_grv_unc.EditIndex = e.NewEditIndex;
			data_to_grid_unc();
		}

		protected void m_grv_unc_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				decimal v_dc_id_gd = CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.RowIndex].Value);
				US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN();
				v_us.DeleteByID(v_dc_id_gd);
				m_lbl_mess_detail.Text = "Đã xoá thành công!";
				data_to_grid_unc();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_grv_unc_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.Rows[e.RowIndex].FindControl("m_ddl_grid_edit_du_an_quoc_lo");
				DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.Rows[e.RowIndex].FindControl("m_ddl_grid_edit_loai_nhiem_vu");
				DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.Rows[e.RowIndex].FindControl("m_ddl_grid_edit_du_an");
				TextBox v_txt_grid_edit_so_tien_nop_thue = (TextBox)m_grv_unc.Rows[e.RowIndex].FindControl("m_txt_grid_edit_so_tien_nop_thue");
				TextBox v_txt_grid_edit_so_tien_tt_cho_dv_huong = (TextBox)m_grv_unc.Rows[e.RowIndex].FindControl("m_txt_grid_edit_so_tien_tt_cho_dv_huong");
				TextBox v_txt_grid_edit_ghi_chu = (TextBox)m_grv_unc.Rows[e.RowIndex].FindControl("m_txt_grid_edit_ghi_chu");

				v_txt_grid_edit_so_tien_nop_thue.Text = v_txt_grid_edit_so_tien_nop_thue.Text.Trim().Replace(",", "").Replace(".", "");
				v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text = v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text.Trim().Replace(",", "").Replace(".", "");

				if (m_ddl_grid_edit_du_an_quoc_lo.SelectedValue == null)
				{
					m_lbl_mess_detail.Text = "Bạn chọn lại Loại nhiệm vụ! Trong mục này không có Quốc lộ/Dự án nào!";
					m_ddl_grid_edit_loai_nhiem_vu.Focus();
					return;
				}
				if (m_ddl_grid_edit_du_an.SelectedValue == null)
				{
					m_lbl_mess_detail.Text = "Bạn chọn lại Quốc lộ/Dự án! Trong mục này không mục chi nào!";
					m_ddl_grid_edit_du_an_quoc_lo.Focus();
					return;
				}
				if (!CValidateTextBox.IsValid(v_txt_grid_edit_ghi_chu, DataType.StringType, allowNull.NO))
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập Nội dung thanh toán!";
					v_txt_grid_edit_ghi_chu.Focus();
					return;
				}
				if (!CValidateTextBox.IsValid(v_txt_grid_edit_so_tien_nop_thue, DataType.NumberType, allowNull.NO))
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
					v_txt_grid_edit_so_tien_nop_thue.Focus();
					return;
				}
				if (CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_nop_thue.Text) < 0)
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
					v_txt_grid_edit_so_tien_nop_thue.Focus();
					return;
				}
				if (!CValidateTextBox.IsValid(v_txt_grid_edit_so_tien_tt_cho_dv_huong, DataType.NumberType, allowNull.NO))
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
					v_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
					return;
				}
				if (CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text) < 0)
				{
					m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
					v_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
					return;
				}
				

				decimal v_dc_id_gd = CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.RowIndex].Value);
				US_GD_CHI_TIET_GIAI_NGAN v_us_gd = new US_GD_CHI_TIET_GIAI_NGAN(v_dc_id_gd);
				v_us_gd.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue);
				v_us_gd.dcID_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue);
				//v_us_gd.strTEN_DU_AN = m_ddl_grid_edit_du_an.SelectedValue;
				v_us_gd.dcID_DON_VI = Person.get_id_don_vi();
				v_us_gd.dcID_GIAI_NGAN = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
				v_us_gd.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_nop_thue.Text);
				v_us_gd.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text);
				v_us_gd.strNOI_DUNG_CHI = v_txt_grid_edit_ghi_chu.Text.Trim();
				v_us_gd.Update();
				m_grv_unc.EditIndex = -1;
				data_to_grid_unc();
				m_lbl_mess_detail.Text = "Bạn đã cập nhật thành công!";
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
			
		}

		protected void m_grv_unc_RowDataBound(object sender, GridViewRowEventArgs e)
		{
			try
			{
				if (e.Row.RowType == DataControlRowType.Footer)
				{
					DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
					DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
					v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
					DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
					DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)e.Row.FindControl("m_ddl_grid_du_an_quoc_lo");
					DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)e.Row.FindControl("m_ddl_grid_loai_nhiem_vu");
					DropDownList m_ddl_grid_edit_du_an = (DropDownList)e.Row.FindControl("m_ddl_grid_du_an");
					if (m_ddl_grid_edit_du_an == null) return;

					WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu);
					if (m_ddl_grid_edit_loai_nhiem_vu.Items.Count > 0)
					{
						m_ddl_grid_edit_loai_nhiem_vu.SelectedIndex = 0;
						WinFormControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi()
							, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
							, m_ddl_grid_edit_du_an_quoc_lo);
						if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
						{
							m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
							WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
								CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
								, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
								, m_ddl_grid_edit_du_an);
						}
					}


				}
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					if (m_grv_unc.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("") |
						m_grv_unc.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("-1"))
					{
						e.Row.Font.Bold = true;
						return;
					}
					US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.Row.RowIndex].Value));
					DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
					DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
					v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
					DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
					DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
					DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
					DropDownList m_ddl_grid_edit_du_an = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_du_an");
					if (m_ddl_grid_edit_du_an == null) return;

					WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu);
					if (m_ddl_grid_edit_loai_nhiem_vu.Items.Count > 0)
					{
						m_ddl_grid_edit_loai_nhiem_vu.SelectedValue = v_us.dcID_LOAI_NHIEM_VU.ToString();
						WinFormControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi()
							, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
							, m_ddl_grid_edit_du_an_quoc_lo);
						if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
						{
							m_ddl_grid_edit_du_an_quoc_lo.SelectedValue = v_us.dcID_CONG_TRINH.ToString();
							WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
								CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
								, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
								, m_ddl_grid_edit_du_an);
							//m_ddl_grid_edit_du_an.SelectedValue = v_us.strte;
						}
					}
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		protected void m_grv_unc_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName == "Add")
				{
					DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
					DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
					DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
					TextBox v_txt_grid_edit_so_tien_nop_thue = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_so_tien_nop_thue");
					TextBox v_txt_grid_edit_so_tien_tt_cho_dv_huong = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_so_tien_thanh_toan_cho_don_vi_huong");
					TextBox v_txt_grid_edit_ghi_chu = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_ghi_chu");

					v_txt_grid_edit_so_tien_nop_thue.Text = v_txt_grid_edit_so_tien_nop_thue.Text.Trim().Replace(",", "").Replace(".", "");
					v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text = v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text.Trim().Replace(",", "").Replace(".", "");
					//1. Check validate data
					if (m_ddl_grid_edit_du_an_quoc_lo.SelectedValue ==null)
					{
						m_lbl_mess_detail.Text = "Bạn chọn lại Loại nhiệm vụ! Trong mục này không có Quốc lộ/Dự án nào!";
						m_ddl_grid_edit_loai_nhiem_vu.Focus();
						return;
					}
					if (m_ddl_grid_edit_du_an.SelectedValue == null)
					{
						m_lbl_mess_detail.Text = "Bạn chọn lại Quốc lộ/Dự án! Trong mục này không mục chi nào!";
						m_ddl_grid_edit_du_an_quoc_lo.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(v_txt_grid_edit_ghi_chu, DataType.StringType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Nội dung thanh toán!";
						v_txt_grid_edit_ghi_chu.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(v_txt_grid_edit_so_tien_nop_thue, DataType.NumberType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
						v_txt_grid_edit_so_tien_nop_thue.Focus();
						return;
					}
					if (CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_nop_thue.Text) < 0)
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
						v_txt_grid_edit_so_tien_nop_thue.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(v_txt_grid_edit_so_tien_tt_cho_dv_huong, DataType.NumberType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
						v_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
						return;
					}
					if (CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text) < 0)
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
						v_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
						return;
					}
					//2. Insert data
					US_GD_CHI_TIET_GIAI_NGAN v_us_gd = new US_GD_CHI_TIET_GIAI_NGAN();
					v_us_gd.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue);
					v_us_gd.dcID_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue);
					//v_us_gd.strTEN_DU_AN = m_ddl_grid_edit_du_an.SelectedValue;
					v_us_gd.dcID_DON_VI = Person.get_id_don_vi();
					v_us_gd.dcID_GIAI_NGAN = CIPConvert.ToDecimal(m_hdf_id_dm_uy_nhiem_chi.Value);
					v_us_gd.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_nop_thue.Text);
					v_us_gd.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(v_txt_grid_edit_so_tien_tt_cho_dv_huong.Text);
					v_us_gd.strGHI_CHU = "";
					v_us_gd.strNOI_DUNG_CHI = v_txt_grid_edit_ghi_chu.Text.Trim();
					v_us_gd.Insert();
					data_to_grid_unc();
					m_lbl_mess_detail.Text = "Bạn đã thêm mới thành công!";
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_ddl_grid_loai_nhiem_vu_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
			if (m_ddl_grid_edit_du_an == null) return;

			WinFormControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi()
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an_quoc_lo);
			if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
			{
				m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
				WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
				if (m_ddl_grid_edit_du_an.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an.SelectedIndex = 0;
				}
			}
			else m_ddl_grid_edit_du_an.Items.Clear();

		}

		protected void m_ddl_grid_du_an_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
			if (m_ddl_grid_edit_du_an == null) return;

			WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
				CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an);
		}

		protected void m_ddl_grid_edit_loai_nhiem_vu_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_edit_du_an");
			if (m_ddl_grid_edit_du_an == null) return;

			WinFormControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi()
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an_quoc_lo);
			if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
			{
				m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
				WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
				if (m_ddl_grid_edit_du_an.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an.SelectedIndex = 0;
				}
			}
			else m_ddl_grid_edit_du_an.Items.Clear();
		}

		protected void m_ddl_grid_edit_du_an_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
		{
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_edit_grid_du_an");
			if (m_ddl_grid_edit_du_an == null) return;

			WinFormControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, Person.get_id_don_vi(),
				CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an);
		}

		


	}
}