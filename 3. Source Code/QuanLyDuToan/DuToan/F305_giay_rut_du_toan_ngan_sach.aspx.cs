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
using Framework.Extensions;
namespace QuanLyDuToan.DuToan
{
	public partial class F305_giay_rut_du_toan_ngan_sach : System.Web.UI.Page
	{
		#region Public Functions
		public bool isVisible_thao_tac(string ip_str_id)
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
		const string C_STR_LUU_THANH_CONG_UNC = "Lưu Uỷ nhiệm chi thành công!";
		const string C_STR_LUU_THANH_CONG = "Đã cập nhật thông tin thành công!";
		const string C_STR_XOA_THANH_CONG = "Đã xoá thành công!";
		public enum eCHI_TX_YN
		{
			YES, NO
		}

		#endregion

		#region Members
		DS_GD_CHI_TIET_GIAI_NGAN m_ds = new DS_GD_CHI_TIET_GIAI_NGAN();
		US_GD_CHI_TIET_GIAI_NGAN m_us = new US_GD_CHI_TIET_GIAI_NGAN();

		//Control ở gridview
		//1. Control Edit
		RadioButton m_rdb_grid_edit_theo_quoc_lo_cong_trinh;
		RadioButton m_rdb_grid_edit_theo_chuong_loai_khoan_muc;
		DropDownList m_ddl_grid_edit_du_an_quoc_lo;
		DropDownList m_ddl_grid_edit_loai_nhiem_vu;
		DropDownList m_ddl_grid_edit_du_an;
		DropDownList m_ddl_grid_edit_muc_tieu_muc;
		TextBox m_txt_grid_edit_so_tien_nop_thue;
		TextBox m_txt_grid_edit_so_tien_tt_cho_dv_huong;
		TextBox m_txt_grid_edit_ghi_chu;
		TextBox m_txt_grid_edit_ma_nguon_nsnn;

		//2. Control Add New

		#endregion

		#region Private Methods
		private void load_data_to_grid_chi_tiet_uy_nhiem_chi()
		{
			US_GRID_GIAI_NGAN v_us = new US_GRID_GIAI_NGAN();
			DataSet v_ds = new DataSet();
			v_ds.Tables.Add(new DataTable());
			v_ds.AcceptChanges();
			v_ds.EnforceConstraints = false;
			if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("")) return;
			v_us.get_grid_giay_rut_du_toan(
					v_ds
					, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
					, CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value)
					, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
					, STR_NGUON.NGAN_SACH
					);
			//Them Ma Chuong, Ma Loai, Ma Khoan vao dataset

			m_grv_unc.DataSource = v_ds.Tables[0];
			m_grv_unc.DataBind();

			//Nếu đang xem UNC của đơn vị khác thì không được sửa dữ liệu
			if (m_ddl_don_vi.SelectedValue != Person.get_id_don_vi().ToString())
			{
				m_grv_unc.Columns[5].Visible = false;//Cột thao tác
			}
			else
			{
				m_grv_unc.Columns[5].Visible = true;
			}
		}

		private void data_to_ddl_du_an_cong_trinh_grid(DropDownList op_ddl, eCHI_TX_YN ip_e_chi_tx_yn)
		{
			try
			{
				switch (ip_e_chi_tx_yn)
				{
					case eCHI_TX_YN.YES:
						grid_data_cong_trinh_du_an_giao_von_to_ddl(op_ddl, WebformControls.LOAI_DU_AN.QUOC_LO);
						break;
					case eCHI_TX_YN.NO:
						grid_data_cong_trinh_du_an_giao_von_to_ddl(op_ddl, WebformControls.LOAI_DU_AN.KHAC);
						break;
					default:
						break;
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		private void grid_data_cong_trinh_du_an_giao_von_to_ddl(DropDownList op_ddl, WebformControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("") | m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				WebformControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von(
									ip_loai_du_an
									, op_ddl
									);
			}
		}


		private void refControl_edit_in_select_row_to_members(int ip_i_row_index)
		{
			m_rdb_grid_edit_theo_quoc_lo_cong_trinh = WebformFunctions.getControl_in_template<RadioButton>(
																						m_grv_unc
																						, "m_rdb_grid_edit_theo_quoc_lo_cong_trinh"
																						, ip_i_row_index
																						, eGridItem.EditItem
																						);

			m_rdb_grid_edit_theo_chuong_loai_khoan_muc = WebformFunctions.getControl_in_template<RadioButton>(
																					   m_grv_unc
																					   , "m_rdb_grid_edit_theo_chuong_loai_khoan_muc"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_ddl_grid_edit_du_an_quoc_lo = WebformFunctions.getControl_in_template<DropDownList>(
																					   m_grv_unc
																					   , "m_ddl_grid_edit_du_an_quoc_lo"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_ddl_grid_edit_loai_nhiem_vu = WebformFunctions.getControl_in_template<DropDownList>(
																					   m_grv_unc
																					   , "m_ddl_grid_edit_loai_nhiem_vu"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_ddl_grid_edit_du_an = WebformFunctions.getControl_in_template<DropDownList>(
																					   m_grv_unc
																					   , "m_ddl_grid_edit_du_an"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_ddl_grid_edit_muc_tieu_muc = WebformFunctions.getControl_in_template<DropDownList>(
																					   m_grv_unc
																					   , "m_ddl_grid_edit_muc_tieu_muc"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_txt_grid_edit_so_tien_nop_thue = WebformFunctions.getControl_in_template<TextBox>(
																					   m_grv_unc
																					   , "m_txt_grid_edit_so_tien_nop_thue"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_txt_grid_edit_so_tien_tt_cho_dv_huong = WebformFunctions.getControl_in_template<TextBox>(
																					   m_grv_unc
																					   , "m_txt_grid_edit_so_tien_tt_cho_dv_huong"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_txt_grid_edit_ghi_chu = WebformFunctions.getControl_in_template<TextBox>(
																					   m_grv_unc
																					   , "m_txt_grid_edit_ghi_chu"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
			m_txt_grid_edit_ma_nguon_nsnn = WebformFunctions.getControl_in_template<TextBox>(
																					   m_grv_unc
																					   , "m_txt_grid_edit_ma_nguon_nsnn"
																					   , ip_i_row_index
																					   , eGridItem.EditItem
																					   );
		}
		private bool check_validate_input_gd_chi_tiet_giai_ngan_is_ok()
		{

			if (m_rdb_grid_edit_theo_quoc_lo_cong_trinh.Checked == true)
			{
				if (m_ddl_grid_edit_du_an_quoc_lo.SelectedValue == null | m_ddl_grid_edit_du_an_quoc_lo.SelectedValue == "-1" | m_ddl_grid_edit_du_an_quoc_lo.SelectedValue == "")
				{
					m_lbl_mess_detail.Text = "Bạn chọn lại Loại nhiệm vụ! Trong mục này không có Quốc lộ/Dự án nào!";
					m_ddl_grid_edit_loai_nhiem_vu.Focus();
					return false;
				}
				if (m_ddl_grid_edit_du_an.SelectedValue == "-1" | m_ddl_grid_edit_du_an.SelectedValue == null)
				{
					m_lbl_mess_detail.Text = "Bạn chọn lại Quốc lộ/Công trình! Trong mục này không mục chi nào!";
					m_ddl_grid_edit_du_an_quoc_lo.Focus();
					return false;
				}
			}
			else
			{
				if (m_ddl_grid_edit_muc_tieu_muc.SelectedValue == "-1")
				{
					m_lbl_mess_detail.Text = "Bạn chọn lại Mục/Tiểu mục";
					m_ddl_grid_edit_muc_tieu_muc.Focus();
					return false;
				}
			}
			if (!CValidateTextBox.IsValid(m_txt_grid_edit_ghi_chu, DataType.StringType, allowNull.NO))
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập Nội dung thanh toán!";
				m_txt_grid_edit_ghi_chu.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_grid_edit_so_tien_nop_thue, DataType.NumberType, allowNull.NO))
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
				m_txt_grid_edit_so_tien_nop_thue.Focus();
				return false;
			}
			if (CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_nop_thue.Text) < 0)
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
				m_txt_grid_edit_so_tien_nop_thue.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_grid_edit_so_tien_tt_cho_dv_huong, DataType.NumberType, allowNull.NO))
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
				m_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
				return false;
			}
			if (CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text) < 0)
			{
				m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
				m_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
				return false;
			}

			return true;
		}
		private bool check_validate_is_ok()
		{
			bool v_b_result = true;


			return v_b_result;
		}

		private bool getISCheck(string us_value)
		{
			if (us_value.Trim().ToUpper().Equals("N"))
			{
				return false;
			}
			return true;
		}

		private void form_to_us_object(US_DM_GIAI_NGAN op_us)
		{
			op_us.strNT_TEN_DON_VI = m_txt_nt_ten_don_vi.Text;
			op_us.strNT_MA_SO_THUE = m_txt_nt_ma_so_thue.Text;
			op_us.strNT_MA_NDKT = m_txt_nt_ma_ndkt.Text;
			op_us.strNT_MA_CHUONG = m_txt_nt_ma_chuong.Text;
			op_us.strNT_CQ_QL_THU = m_txt_nt_co_quan_quan_ly_thu.Text;
			op_us.strNT_MA_CQ_THU = m_txt_nt_ma_cq_thu.Text;
			op_us.strNT_KBNN_HACH_TOAN_KHOAN_THU = m_txt_nt_kbnn_hach_toan_thu.Text;
			op_us.strNT_SO_TIEN_NOP_THUE = m_txt_nt_so_tien_nop_thue.Text;

			op_us.strTTDVH_DON_VI_NHAN_TIEN = m_txt_ttdvh_don_vi_nhan_tien.Text;
			op_us.strTTDVH_MA_DVQHNS = m_txt_ttdvh_ma_dvqhns.Text;
			op_us.strTTDVH_DIA_CHI = m_txt_ttdvh_dia_chi.Text;
			op_us.strTTDVH_TAI_KHOAN = m_txt_ttdvh_tai_khoan.Text;
			op_us.strTTDVH_MA_CTMT_DA_VA_HTCT = m_txt_ttdvh_ma_ctmt_da_htct.Text;
			op_us.strTTDVH_KHO_BAC = m_txt_ttdvh_tai_kbnn.Text;
			op_us.strTTDVH_SO_TIEN = m_txt_ttdvh_so_tien_thanh_toan.Text;
			op_us.strIS_NGUON_NS_YN = STR_NGUON.NGAN_SACH;
			op_us.strMA_TKKT = m_rdb_ma_tkkt_ns.Checked ? m_rdb_ma_tkkt_ns.Text :
								m_rdb_ma_tkkt_ns_2.Checked ? m_rdb_ma_tkkt_ns_2.Text :
								m_rdb_ma_tkkt_ns_3.Checked ? m_rdb_ma_tkkt_ns_3.Text :
								m_rdb_ma_tkkt_ns_4.Checked ? m_rdb_ma_tkkt_ns_4.Text : "";
		}
		private void us_object_to_form(US_DM_GIAI_NGAN ip_us)
		{

			m_txt_ma_ctmt_da_htct.Text = ip_us.strMA_CTMT_DA_HTCT;
			m_ckb_thuc_chi.Checked = getISCheck(ip_us.strTHUC_CHI_YN);
			m_ckb_tam_ung.Checked = getISCheck(ip_us.strTAM_UNG_YN);
			m_ckb_ung_truoc_chua_du_dk_thanh_toan.Checked = getISCheck(ip_us.strUNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN);
			m_ckb_ung_truoc_du_dk_thanh_toan.Checked = getISCheck(ip_us.strUNG_TRUOC_DU_DK_THANH_TOAN_YN);
			m_ckb_chuyen_khoan.Checked = getISCheck(ip_us.strCHUYEN_KHOAN_YN);
			m_ckb_tien_mat.Checked = getISCheck(ip_us.strTIEN_MAT_YN);

			m_txt_ngay_thang.Text = CIPConvert.ToStr(ip_us.datNGAY_THANG, "dd/MM/yyyy");
			m_txt_ma_cap_ns.Text = ip_us.strMA_CAP_NS;
			m_txt_ten_ctmt_da.Text = ip_us.strTEN_CTMT_DA;
			m_txt_nam_ns.Text = ip_us.datNGAY_THANG.Year.ToString();
			m_txt_so_ckc_hdk.Text = ip_us.strSO_CKC_HDK;
			m_txt_so_ckc_hdth.Text = ip_us.strSO_CKC_HDTH;

			if (m_rdb_ma_tkkt_ns.Text == ip_us.strMA_TKKT) m_rdb_ma_tkkt_ns.Checked = true;
			else if (m_rdb_ma_tkkt_ns_2.Text == ip_us.strMA_TKKT) m_rdb_ma_tkkt_ns_2.Checked = true;
			else if (m_rdb_ma_tkkt_ns_3.Text == ip_us.strMA_TKKT) m_rdb_ma_tkkt_ns_3.Checked = true;
			else if (m_rdb_ma_tkkt_ns_4.Text == ip_us.strMA_TKKT) m_rdb_ma_tkkt_ns_4.Checked = true;
			else
				m_rdb_ma_tkkt_ns.Checked = true;

			m_lbl_ma_dvqhns.Text = ip_us.strMA_DVQHNS;

			m_txt_nt_ten_don_vi.Text = ip_us.strNT_TEN_DON_VI;
			m_txt_nt_ma_so_thue.Text = ip_us.strNT_MA_SO_THUE;
			m_txt_nt_ma_ndkt.Text = ip_us.strNT_MA_NDKT;
			m_txt_nt_ma_chuong.Text = ip_us.strNT_MA_CHUONG;
			m_txt_nt_co_quan_quan_ly_thu.Text = ip_us.strNT_CQ_QL_THU;
			m_txt_nt_ma_cq_thu.Text = ip_us.strNT_MA_CQ_THU;
			m_txt_nt_kbnn_hach_toan_thu.Text = ip_us.strNT_KBNN_HACH_TOAN_KHOAN_THU;
			m_txt_nt_so_tien_nop_thue.Text = ip_us.strNT_SO_TIEN_NOP_THUE;

			m_txt_ttdvh_don_vi_nhan_tien.Text = ip_us.strTTDVH_DON_VI_NHAN_TIEN;
			m_txt_ttdvh_ma_dvqhns.Text = ip_us.strTTDVH_MA_DVQHNS;
			m_txt_ttdvh_dia_chi.Text = ip_us.strTTDVH_DIA_CHI;
			m_txt_ttdvh_tai_khoan.Text = ip_us.strTTDVH_TAI_KHOAN;
			m_txt_ttdvh_ma_ctmt_da_htct.Text = ip_us.strTTDVH_MA_CTMT_DA_VA_HTCT;
			m_txt_ttdvh_tai_kbnn.Text = ip_us.strTTDVH_KHO_BAC;
			m_txt_ttdvh_so_tien_thanh_toan.Text = ip_us.strTTDVH_SO_TIEN;
			m_txt_cmnd_so.Text = ip_us.strNGUOI_NHAN_TIEN_CMND_SO;
			m_txt_cap_ngay.Text = ip_us.strNGUOI_NHAN_TIEN_CAP_NGAY;
			m_txt_noi_cap.Text = ip_us.strNGUOI_NHAN_TIEN_NOI_CAP;

		}

		private void xoa_trang()
		{
			//m_lbl_mess_qd.Text = "";
			//m_lbl_mess.Text = "";
			//m_lbl_mess_detail.Text = "";
			WebformFunctions.set_form_mode(FORM_MODE.THEM, m_hdf_form_mode);
			//m_grv.SelectedIndex = -1;

			m_hdf_id_dm_giai_ngan.Value = "";
			//m_hdf_id_quoc_lo.Value = "";
			//m_hdf_id_dm_giai_ngan.Value = "";
			//m_hdf_id_du_an.Value = "";



			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";



		}
		private void xoa_trang_control_lap_uy_nhiem_chi()
		{
			/*
			 * Mục tiêu: Thực hiện reset control khi click nút xoá trắng trong Lập danh mục Uỷ nhiệm chi
			 * Tóm tắt:
			 * 1. Đặt giá trị mặc định cho control
			 * 2. Hiển thị thông tin đơn vị Lập uỷ nhiệm chi
			 */
			//1. Đặt giá trị mặc định cho control
			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			//m_txt_ma_ctmt_da_htct.Text = "";
			m_hdf_id_dm_giai_ngan.Value = "-1";
			m_ddl_dm_giai_ngan.Visible = false;
			m_txt_so_unc.Visible = true;
			m_cmd_luu_unc.Visible = true;
			//2. Hiển thị thông tin đơn vị Lập uỷ nhiệm chi
			load_thong_tin_don_vi_lap_uy_nhiem_chi();
		}

		private void load_data_to_ddl_giai_ngan()
		{
			//1. Load data to dropdownlist giải ngân
			WebformControls.load_data_to_ddl_giai_ngan(
								m_ddl_dm_giai_ngan
								, STR_NGUON.NGAN_SACH
								, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
								, "---Chọn Giấy rút dự toán---"
								);
			//2. Đặt giá trị mặc định select cho dropdownlish Giải ngân
			//2.1 Đặt giá trị mặc đinh khi không có query string
			if (m_ddl_dm_giai_ngan.Items.Count > 0)
			{
				m_ddl_dm_giai_ngan.SelectedIndex = 0;
				m_hdf_id_dm_giai_ngan.Value = m_ddl_dm_giai_ngan.SelectedValue;
			}
			else m_hdf_id_dm_giai_ngan.Value = CONST_GIAO_DICH.STR_VALUE_TAT_CA;
			//2.2 Đặt giá trị theo query string
			m_ddl_dm_giai_ngan.SelectedValue = WebformFunctions.getValue_from_query_string<string>(
														this
														, FormInfo.QueryString.ID_GIAI_NGAN
														, CONST_GIAO_DICH.STR_VALUE_TAT_CA);
			//3. Load data vào các control khác khi thay đổi giá trị dropdownlist giải ngân
			m_ddl_dm_giai_ngan_SelectedIndexChanged(null, null);

		}
		private void load_data_to_cbo_cong_trinh_from_data_giao_von(
							DropDownList op_ddl
							, WebformControls.LOAI_DU_AN ip_loai_du_an)
		{
			if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("") | m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
			}
			else
			{
				US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value));
				WebformControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von(
					ip_loai_du_an
					, op_ddl);
			}
		}
		private void load_thong_tin_don_vi_lap_uy_nhiem_chi()
		{
			/*
			 * Mục tiêu: Hiển thị thông tin của đơn vị lập uỷ nhiệm chi
			 * Tóm tắt:
			 *	1. Khởi tạo các us cần thiết
			 *	2. Hiển thị thông tin đơn vị
			 *	2.1 Hiển thị thông tin cơ bản của đơn vị
			 *  2.2 Hiển thị số tài khoản của đơn vị thông qua control List Radio Button
			 */
			//1. Khởi tạo các us cần thiết
			US_DM_DON_VI v_us_dv = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			US_DM_THONG_TIN_DON_VI v_us_ttdv = new US_DM_THONG_TIN_DON_VI();
			v_us_ttdv.InitByID_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			//2. Hiển thị thông tin đơn vị
			//2.1 Hiển thị thông tin cơ bản của đơn vị
			//m_lbl_dia_chi.Text = v_us_ttdv.strDIA_CHI;
			m_txt_tai_kho_bac_nha_nuoc.Text = v_us_ttdv.strKHO_BAC;
			m_lbl_ma_dvqhns.Text = v_us_ttdv.strMA_DVQHNS;
			//2.2 Hiển thị số tài khoản của đơn vị thông qua control List Radio Button
			/*
			 * Mỗi đơn vị nhiều nhất có 2 tài khoản: 1 tài khoản NS và 1 tài khoản QBT
			 * Item 1: Lưu thông tin tài khoản QBT - tương ứng trường Ma_TKKT_1 trong CSDL
			 * Item 2: Lưu thông tin tài khoản NS - tương ứng với trường Ma_TKKT_2 trong CSDL
			 */
			//Xoá tất cả item cũ
			//m_rbl_ma_tkkt.Items.Clear();
			////Nếu đơn vị chưa nhập thông tin tài khoản -> Không thể lập UNC -> Trở về
			//if (v_us_ttdv.IsMA_TKKT1Null() && v_us_ttdv.IsMA_TKKT2Null()) return;
			////Nếu không có tài khoản 2 => Có tài khoản 1 => Hiển thị thông tin tài khoản 1
			//if (v_us_ttdv.IsMA_TKKT2Null() | v_us_ttdv.strMA_TKKT2.Trim().Equals(""))
			//{
			//	ListItem v_li_1 = new ListItem(v_us_ttdv.strMA_TKKT1);
			//	m_rbl_ma_tkkt.Items.Add(v_li_1);
			//	m_rbl_ma_tkkt.Items[0].Selected = true;
			//}
			//else//Trường hợp có cả 2 tài khoản
			//{
			//	ListItem v_li_1 = new ListItem(v_us_ttdv.strMA_TKKT1);
			//	ListItem v_li_2 = new ListItem(v_us_ttdv.strMA_TKKT2);
			//	m_rbl_ma_tkkt.Items.Add(v_li_1);
			//	m_rbl_ma_tkkt.Items.Add(v_li_2);
			//	//Đặt mặc định chọn Tài khoản NS - Ma_TKKT_1
			//	m_rbl_ma_tkkt.Items[1].Selected = true;
			//	m_rbl_ma_tkkt.Items[0].Attributes.Add("style", "display:none");
			//}
			m_rdb_ma_tkkt_ns.Text = v_us_ttdv.strMA_TKKT2 == "" ? "Mã TKKT NS 1" : v_us_ttdv.strMA_TKKT2;
			m_rdb_ma_tkkt_ns_2.Text = v_us_ttdv.strMA_TKKT_NS_2 == "" ? "Mã TKKT NS 2" : v_us_ttdv.strMA_TKKT_NS_2;
			m_rdb_ma_tkkt_ns_3.Text = v_us_ttdv.strMA_TKKT_NS_3 == "" ? "Mã TKKT NS 3" : v_us_ttdv.strMA_TKKT_NS_3;
			m_rdb_ma_tkkt_ns_4.Text = v_us_ttdv.strMA_TKKT_NS_4 == "" ? "Mã TKKT NS 4" : v_us_ttdv.strMA_TKKT_NS_4;
		}

		private void set_enable_control_giai_ngan(bool ip_b_is_enable)
		{
			/*
			 * Khi Chọn UNC thì không cho sửa thông tin -> enable=false
			 * Khi nhập mới UNC thì phải cho sửa thông tin -> enable=true
			 */
			m_txt_so_unc.Enabled = ip_b_is_enable;
			m_txt_ngay_thang.Enabled = ip_b_is_enable;
			//m_txt_ma_ctmt_da_htct.Enabled = ip_b_is_enable;
			//m_rbl_ma_tkkt.Enabled = ip_b_is_enable;
		}
		private void save_data_gd_chi_tiet_giai_ngan_in_grid(US_GD_CHI_TIET_GIAI_NGAN ip_us, FORM_MODE ip_form_mode)
		{
			ip_us.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue);
			if (m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Checked == true)
			{
				string v_str_mix = m_ddl_grid_edit_muc_tieu_muc.SelectedValue;
				string[] v_arr_id = v_str_mix.Split('|');

				ip_us.dcID_CHUONG = CIPConvert.ToDecimal(v_arr_id[0]);
				//v_dc_id_loai = CIPConvert.ToDecimal(v_arr_id[1]);
				ip_us.dcID_KHOAN = CIPConvert.ToDecimal(v_arr_id[2]);
				ip_us.dcID_MUC = CIPConvert.ToDecimal(v_arr_id[3]);
				if (!v_arr_id[4].Trim().Equals(""))
				{
					ip_us.dcID_TIEU_MUC = CIPConvert.ToDecimal(v_arr_id[4]);
				}
				ip_us.strMA_NGUON_NSNN = m_txt_grid_edit_ma_nguon_nsnn.Text.Trim();
				ip_us.SetID_CONG_TRINHNull();
				ip_us.SetID_DU_ANNull();

			}
			else
			{
				ip_us.dcID_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue);
				ip_us.dcID_DU_AN = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an.SelectedValue);
				ip_us.SetID_CHUONGNull();
				ip_us.SetID_KHOANNull();
				ip_us.SetID_MUCNull();
				ip_us.SetID_TIEU_MUCNull();
			}

			ip_us.dcID_DON_VI = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
			ip_us.dcID_GIAI_NGAN = CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value);
			ip_us.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_nop_thue.Text);
			ip_us.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text);
			ip_us.strNOI_DUNG_CHI = m_txt_grid_edit_ghi_chu.Text.Trim();
			switch (ip_form_mode)
			{
				case FORM_MODE.THEM:
					ip_us.Insert();
					break;
				case FORM_MODE.SUA:
					ip_us.Update();
					break;
				case FORM_MODE.XOA:
					break;
				default:
					break;
			}
		}
		private void load_data_to_ddl_muc_tieu_muc(DropDownList op_ddl, decimal ip_dc_id_loai_nhiem_vu)
		{
			/*
			 * Mục tiêu: Hiển thị dữ liệu có sẵn về Mục - Tiểu Mục để người dùng lựa chọn
			 * Tóm tắt:
			 */
			if (m_hdf_id_dm_giai_ngan.Value.Equals("") | m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
			{
				op_ddl.Items.Clear();
				op_ddl.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
				return;
			}
			US_DM_GIAI_NGAN v_us_qd = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value));
			DateTime v_dat_dau_nam = v_us_qd.datNGAY_THANG;
			v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			DataSet v_ds_muc_tieu_muc =
				WebformControls.get_dataset_muc_tieu_muc_from_data_giao_von(ip_dc_id_loai_nhiem_vu
									, v_dat_dau_nam
									, v_dat_cuoi_nam
									, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			op_ddl.DataTextField = GET_MUC_TIEU_MUC.DISPLAY;
			op_ddl.DataValueField = GET_MUC_TIEU_MUC.ID;
			op_ddl.DataSource = v_ds_muc_tieu_muc.Tables[0];
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem("---Chọn Mục hoặc Tiểu mục---", "-1"));
		}
		private string get_id_mix_from_id_gd(decimal ip_dc_id_giao_von)
		{
			US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(ip_dc_id_giao_von);
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us_khoan = new US_DM_CHUONG_LOAI_KHOAN_MUC(v_us.dcID_KHOAN);
			string v_str_id_mix = "";
			v_str_id_mix += v_us.dcID_CHUONG + "|";//chuong
			v_str_id_mix += v_us_khoan.dcID_CHA + "|";//loai
			v_str_id_mix += v_us.dcID_KHOAN + "|";//khoan
			v_str_id_mix += v_us.dcID_MUC + "|";//muc
			if (!v_us.IsID_TIEU_MUCNull())
			{
				v_str_id_mix += v_us.dcID_TIEU_MUC;//tieu muc
			}
			return v_str_id_mix;
		}
		private void reset_control()
		{

			//m_rbl_ma_tkkt.Enabled = false;
			m_lbl_mess_grid.Text = "";
			m_lbl_mess_detail.Text = "";
			m_lbl_mess_master.Text = "";
			m_txt_nam_ns.Text = DateTime.Now.Year.ToString();
		}

		private void format_control_print_and_save_info()
		{
			if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("") | m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
				m_cmd_save_info_unc.Visible = false;
			else
			{
				m_cmd_save_info_unc.Visible = true;
				m_cmd_print.NavigateUrl = CCommonFunction.genQueryString(
						FormInfo.FormRedirect.F601
						, new CParaQueryString[]{
										new CParaQueryString(FormInfo.QueryString.ID_GIAI_NGAN,m_hdf_id_dm_giai_ngan.Value)
										, new CParaQueryString(FormInfo.QueryString.ID_DON_VI,m_ddl_don_vi.SelectedValue)
												}
						);
				m_cmd_print.Visible = true;
			}
		}
		private void set_initial_form_load()
		{
			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			m_hdf_id_dm_giai_ngan.Value = "-1";
			xoa_trang();
			//load dropdownlist danh sach don vi ma don vi X duoc xem du lieu
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
			m_txt_ngay_thang.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");

			

			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				m_ddl_don_vi.SelectedValue = Request.QueryString["ip_dc_id_don_vi"].ToString();
			}
			else m_ddl_don_vi.SelectedValue = Person.get_id_don_vi().ToString();

			load_data_to_ddl_giai_ngan();
			format_control_print_and_save_info();

			if (Request.QueryString["ip_dc_id_dm_giai_ngan"] != null)
			{
				decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_dm_giai_ngan"]);

				m_ddl_dm_giai_ngan.SelectedValue = v_dc_id_quyet_dinh.ToString();
				m_ddl_dm_giai_ngan_SelectedIndexChanged(null, null);
			}

			
			load_thong_tin_don_vi_lap_uy_nhiem_chi();
			load_data_to_grid_chi_tiet_uy_nhiem_chi();


		}

		private void form_to_us_dm_giai_ngan(US_DM_GIAI_NGAN op_us)
		{
			if (m_ckb_chuyen_khoan.Checked == true) op_us.strCHUYEN_KHOAN_YN = "Y"; else op_us.strCHUYEN_KHOAN_YN = "N";
			if (m_ckb_thuc_chi.Checked == true) op_us.strTHUC_CHI_YN = "Y"; else op_us.strTHUC_CHI_YN = "N";
			if (m_ckb_tam_ung.Checked == true) op_us.strTAM_UNG_YN = "Y"; else op_us.strTAM_UNG_YN = "N";
			if (m_ckb_ung_truoc_chua_du_dk_thanh_toan.Checked == true) op_us.strUNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN = "Y"; else op_us.strUNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN = "N";
			if (m_ckb_ung_truoc_du_dk_thanh_toan.Checked == true) op_us.strUNG_TRUOC_DU_DK_THANH_TOAN_YN = "Y"; else op_us.strUNG_TRUOC_DU_DK_THANH_TOAN_YN = "N";
			if (m_ckb_tien_mat.Checked == true) op_us.strTIEN_MAT_YN = "Y"; else op_us.strTIEN_MAT_YN = "N";

			op_us.dcID_DON_VI = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
			op_us.strMA_CTMT_DA_HTCT = m_txt_ma_ctmt_da_htct.Text.Trim();
			op_us.strMA_CAP_NS = m_txt_ma_cap_ns.Text.Trim();
			op_us.strTEN_CTMT_DA = m_txt_ten_ctmt_da.Text.Trim();
			op_us.strSO_CKC_HDK = m_txt_so_ckc_hdk.Text.Trim();
			op_us.strSO_CKC_HDTH = m_txt_so_ckc_hdth.Text.Trim();
			op_us.strMA_DVQHNS = m_lbl_ma_dvqhns.Text.Trim();
			op_us.strIS_NGUON_NS_YN = STR_NGUON.NGAN_SACH;
			op_us.strSO_UNC = m_txt_so_unc.Text.Trim();
			op_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
			op_us.strNT_TEN_DON_VI = m_txt_nt_ten_don_vi.Text.Trim();
			op_us.strNT_MA_SO_THUE = m_txt_nt_ma_so_thue.Text.Trim();
			op_us.strNT_MA_NDKT = m_txt_nt_ma_ndkt.Text.Trim();
			op_us.strNT_MA_CHUONG = m_txt_nt_ma_chuong.Text.Trim();
			op_us.strNT_CQ_QL_THU = m_txt_nt_co_quan_quan_ly_thu.Text.Trim();
			op_us.strNT_MA_CQ_THU = m_txt_nt_ma_cq_thu.Text.Trim();
			op_us.strNT_KBNN_HACH_TOAN_KHOAN_THU = m_txt_nt_kbnn_hach_toan_thu.Text.Trim();
			op_us.strNT_SO_TIEN_NOP_THUE = m_txt_nt_so_tien_nop_thue.Text.Trim();

			op_us.strTTDVH_DON_VI_NHAN_TIEN = m_txt_ttdvh_don_vi_nhan_tien.Text.Trim();
			op_us.strTTDVH_MA_DVQHNS = m_txt_ttdvh_ma_dvqhns.Text.Trim();
			op_us.strTTDVH_DIA_CHI = m_txt_ttdvh_dia_chi.Text.Trim();
			op_us.strTTDVH_TAI_KHOAN = m_txt_ttdvh_tai_khoan.Text.Trim();
			op_us.strTTDVH_MA_CTMT_DA_VA_HTCT = m_txt_ttdvh_ma_ctmt_da_htct.Text.Trim();
			op_us.strTTDVH_KHO_BAC = m_txt_ttdvh_tai_kbnn.Text.Trim();
			op_us.strTTDVH_SO_TIEN = m_txt_ttdvh_so_tien_thanh_toan.Text.Trim();
			op_us.strNGUOI_NHAN_TIEN_CMND_SO = m_txt_cmnd_so.Text;
			op_us.strNGUOI_NHAN_TIEN_CAP_NGAY = m_txt_cap_ngay.Text;
			op_us.strNGUOI_NHAN_TIEN_NOI_CAP = m_txt_noi_cap.Text;
			op_us.strMA_TKKT = m_rdb_ma_tkkt_ns.Checked ? m_rdb_ma_tkkt_ns.Text :
								m_rdb_ma_tkkt_ns_2.Checked ? m_rdb_ma_tkkt_ns_2.Text :
								m_rdb_ma_tkkt_ns_3.Checked ? m_rdb_ma_tkkt_ns_3.Text :
								m_rdb_ma_tkkt_ns_4.Checked ? m_rdb_ma_tkkt_ns_4.Text : "";
		}
		private void us_dm_giai_ngan_to_form(US_DM_GIAI_NGAN ip_us)
		{

		}
		private bool check_validate_input_dm_giai_ngan_is_ok()
		{
			if (m_txt_so_unc.Text.Trim().Equals(""))
			{
				m_lbl_mess_master.Text = "Bạn phải nhập Số Uỷ nhiệm chi!";
				m_txt_so_unc.Focus();
				return false;
			}

			//Check trung so unc
			DS_DM_GIAI_NGAN v_ds_dm_giai_ngan = new DS_DM_GIAI_NGAN();
			US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN();
			v_us_dm_giai_ngan.get_dm_uy_nhiem_chi_by_don_vi_va_ngay_thang(
										v_ds_dm_giai_ngan
										, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
										, CCommonFunction.getDate_dau_nam_from_date(DateTime.Now)
										, CCommonFunction.getDate_cuoi_nam_form_date(DateTime.Now)
										, STR_NGUON.NGAN_SACH
										);

			List<DBClassModel.DM_GIAI_NGAN> v_lst_giai_ngan = v_ds_dm_giai_ngan.DM_GIAI_NGAN.ToList<DBClassModel.DM_GIAI_NGAN>();
			if (v_lst_giai_ngan.Where(x => x.SO_UNC == m_txt_so_unc.Text.Trim()).ToList().Count > 0)
			{
				m_lbl_mess_master.Text = "Bạn phải nhập Số Uỷ nhiệm chi, đã tồn tại Số uỷ nhiêm chi này!";
				m_txt_so_unc.Focus();
				return false;
			}


			if (!CValidateTextBox.IsValid(m_txt_ngay_thang, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess_master.Text = "Bạn phải nhập Ngày tháng!";
				m_txt_ngay_thang.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_ma_ctmt_da_htct, DataType.StringType, allowNull.NO))
			{
				m_lbl_mess_master.Text = "Bạn phải nhập Mã CTMT, DA!";
				m_txt_ma_ctmt_da_htct.Focus();
				return false;
			}


			return true;
		}

		private void insert_unc()
		{
			US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN();
			m_hdf_id_dm_giai_ngan.Value = "";
			//check validate luu quyet dinh
			if (!check_validate_input_dm_giai_ngan_is_ok()) return;

			// insert dm giai ngan
			form_to_us_dm_giai_ngan(v_us_dm_giai_ngan);
			v_us_dm_giai_ngan.Insert();
			WebformControls.ghiLogDuToan("Thêm mới Giấy rút dự toán số " + v_us_dm_giai_ngan.strSO_UNC);
			m_hdf_id_dm_giai_ngan.Value = v_us_dm_giai_ngan.dcID.ToString();
			m_lbl_mess_master.Text = C_STR_LUU_THANH_CONG_UNC;
			//reload data by form mode
			set_enable_control_giai_ngan(false);
			load_data_to_grid_chi_tiet_uy_nhiem_chi();
			format_control_print_and_save_info();
		}
		#endregion

		#region Events

		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				//Mỗi khi postback lên server - tương ứng với một hành động bên máy khách thì sẽ rết lại thông báo
				reset_control();

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
		protected void m_cmd_chon_unc_Click(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_giai_ngan();
				m_ddl_dm_giai_ngan.Visible = true;
				m_txt_so_unc.Visible = false;
				m_rdb_ma_tkkt_ns.Checked = true;
				//m_rbl_ma_tkkt.Items[0].Attributes.Add("style", "display:none");
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_ddl_dm_giai_ngan_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				m_txt_so_unc.Visible = true;
				if (m_ddl_dm_giai_ngan.SelectedValue == CONST_GIAO_DICH.STR_VALUE_TAT_CA | m_ddl_dm_giai_ngan.SelectedValue == "")
				{
					m_hdf_id_dm_giai_ngan.Value = CONST_GIAO_DICH.STR_VALUE_TAT_CA;
				}
				else
				{
					m_hdf_id_dm_giai_ngan.Value = m_ddl_dm_giai_ngan.SelectedValue;
					format_control_print_and_save_info();
					US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value));
					US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI();
					m_txt_so_unc.Text = v_us_dm_giai_ngan.strSO_UNC;
					v_us_thong_tin_don_vi.InitByID_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
					//m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
					m_txt_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;

					us_object_to_form(v_us_dm_giai_ngan);

					m_cmd_luu_unc.Visible = false;
					m_cmd_nhap_moi_unc.Visible = true;

					set_enable_control_giai_ngan(false);
					m_ddl_dm_giai_ngan.Visible = false;
					load_data_to_grid_chi_tiet_uy_nhiem_chi();
				}

				//Nếu không phải đơn vị của mình thì không được Nhập UNC,Thêm UNC
				//if (m_ddl_don_vi.SelectedValue==Person.get_id_don_vi().ToString())
				//{
				//	m_cmd_luu_unc.Visible = true;
				//	m_cmd_nhap_moi_unc.Visible = true;
				//	m_cmd_save_info_unc.Visible = true;
				//}
				//else
				//{
				//	m_cmd_luu_unc.Visible = false;
				//	m_cmd_nhap_moi_unc.Visible = false;
				//	m_cmd_save_info_unc.Visible = false;
				//}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_cmd_nhap_moi_unc_Click(object sender, EventArgs e)
		{
			try
			{
				set_enable_control_giai_ngan(true);
				xoa_trang_control_lap_uy_nhiem_chi();
				load_data_to_grid_chi_tiet_uy_nhiem_chi();
				format_control_print_and_save_info();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_cmd_luu_unc_Click(object sender, EventArgs e)
		{
			try
			{
				insert_unc();
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
				if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("") | m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
				{
					return;
				}
				US_DM_GIAI_NGAN v_us_dm_unc = new US_DM_GIAI_NGAN(CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value));
				//if (!check_validate_input_dm_giai_ngan_is_ok()) return;
				form_to_us_dm_giai_ngan(v_us_dm_unc);
				v_us_dm_unc.Update();
				WebformControls.ghiLogDuToan("Cập nhật thông tin Giấy rút dự toán số " + v_us_dm_unc.strSO_UNC);
				m_lbl_mess_info_unc.Text = C_STR_LUU_THANH_CONG;
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_rdb_grid_ctx_CheckedChanged(object sender, EventArgs e)
		{
			try
			{
				RadioButton v_rdb = (RadioButton)sender;
				GridViewRow v_gr = (GridViewRow)v_rdb.Parent.Parent;
				GridView v_grv = (GridView)v_gr.NamingContainer;
				DropDownList v_ddl = (DropDownList)v_grv.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
				data_to_ddl_du_an_cong_trinh_grid(v_ddl, eCHI_TX_YN.YES);
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
			DropDownList v_ddl = (DropDownList)v_grv.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
			data_to_ddl_du_an_cong_trinh_grid(v_ddl, eCHI_TX_YN.NO);
		}

		protected void m_grv_unc_RowUpdating(object sender, GridViewUpdateEventArgs e)
		{
			try
			{
				//Trỏ đến control ở lưới
				refControl_edit_in_select_row_to_members(e.RowIndex);

				//Format lại giá trị của textbox số tiền
				m_txt_grid_edit_so_tien_nop_thue.Text = m_txt_grid_edit_so_tien_nop_thue.Text.Trim().Replace(",", "").Replace(".", "");
				m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text = m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text.Trim().Replace(",", "").Replace(".", "");

				//Kiểm tra điều kiện trước khi Update dữ liệu vào csdl
				if (!check_validate_input_gd_chi_tiet_giai_ngan_is_ok()) return;

				//Cập nhật vào csdl
				decimal v_dc_id_gd = CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.RowIndex].Value);
				US_GD_CHI_TIET_GIAI_NGAN v_us_gd_chi_tiet_giai_ngan = new US_GD_CHI_TIET_GIAI_NGAN(v_dc_id_gd);
				save_data_gd_chi_tiet_giai_ngan_in_grid(v_us_gd_chi_tiet_giai_ngan, FORM_MODE.SUA);
				m_grv_unc.EditIndex = -1;
				load_data_to_grid_chi_tiet_uy_nhiem_chi();
				m_lbl_mess_detail.Text = "Bạn đã cập nhật thành công!";
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_grv_unc_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
		{
			try
			{
				m_grv_unc.EditIndex = -1;
				load_data_to_grid_chi_tiet_uy_nhiem_chi();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_grv_unc_RowEditing(object sender, GridViewEditEventArgs e)
		{
			try
			{
				m_grv_unc.EditIndex = e.NewEditIndex;
				load_data_to_grid_chi_tiet_uy_nhiem_chi();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_grv_unc_RowDeleting(object sender, GridViewDeleteEventArgs e)
		{
			try
			{
				decimal v_dc_id_gd = CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.RowIndex].Value);
				US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN();
				v_us.DeleteByID(v_dc_id_gd);
				WebformControls.ghiLogDuToan("Xoá bản ghi giải ngân ở Giấy rút dự toán ngân sách số " + new US_DM_GIAI_NGAN(v_us.dcID_GIAI_NGAN).strSO_UNC);
				m_lbl_mess_detail.Text = C_STR_XOA_THANH_CONG;
				load_data_to_grid_chi_tiet_uy_nhiem_chi();
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
					DateTime v_dat_dau_nam = CCommonFunction.getDate_dau_nam_from_date(v_dat_now);
					DateTime v_dat_cuoi_nam = CCommonFunction.getDate_cuoi_nam_form_date(v_dat_now);
					//dropdownlish cong trinh, du an
					m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)e.Row.FindControl("m_ddl_grid_du_an_quoc_lo");
					m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)e.Row.FindControl("m_ddl_grid_loai_nhiem_vu");
					m_ddl_grid_edit_du_an = (DropDownList)e.Row.FindControl("m_ddl_grid_du_an");
					m_ddl_grid_edit_du_an_quoc_lo.Visible = false;
					m_ddl_grid_edit_du_an.Visible = false;

					WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu);
					if (m_ddl_grid_edit_loai_nhiem_vu.Items.Count > 0)
					{
						m_ddl_grid_edit_loai_nhiem_vu.SelectedValue = ID_LOAI_NHIEM_VU_NS.DU_TOAN_CHI_NS_NN.ToString();
						//WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
						//	, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
						//	, m_ddl_grid_edit_du_an_quoc_lo);
						//if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
						//{
						//	m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
						//	WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
						//		CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
						//		, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
						//		, m_ddl_grid_edit_du_an);
						//}
					}
					//dropdownlist Loai khoan muc -tieu muc
					DropDownList m_ddl_grid_muc_tieu_muc = (DropDownList)e.Row.FindControl("m_ddl_grid_muc_tieu_muc");
					m_ddl_grid_muc_tieu_muc.Visible = true;

					load_data_to_ddl_muc_tieu_muc(
								m_ddl_grid_muc_tieu_muc
								, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
								);

				}
				if (e.Row.RowType == DataControlRowType.DataRow)
				{
					if (m_grv_unc.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("") |
						m_grv_unc.DataKeys[e.Row.RowIndex].Value.ToString().Trim().Equals("-1"))
					{
						e.Row.Font.Bold = true;
						return;
					}
					if (CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.Row.RowIndex].Value) > 20000)
					{
						return;
					}
					US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_grv_unc.DataKeys[e.Row.RowIndex].Value));
					DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
					DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
					v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
					//dropdownlist Cong trinh, du an
					DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
					m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
					m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
					m_ddl_grid_edit_du_an = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_du_an");
					m_ddl_grid_edit_muc_tieu_muc = (DropDownList)e.Row.FindControl("m_ddl_grid_edit_muc_tieu_muc");
					m_rdb_grid_edit_theo_quoc_lo_cong_trinh = (RadioButton)e.Row.FindControl("m_rdb_grid_edit_theo_quoc_lo_cong_trinh");
					m_rdb_grid_edit_theo_chuong_loai_khoan_muc = (RadioButton)e.Row.FindControl("m_rdb_grid_edit_theo_chuong_loai_khoan_muc");
					if (m_ddl_grid_edit_du_an == null) return;

					WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu);
					m_ddl_grid_edit_loai_nhiem_vu.SelectedValue = v_us.dcID_LOAI_NHIEM_VU.ToString();
					load_data_to_ddl_muc_tieu_muc(m_ddl_grid_edit_muc_tieu_muc
								, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
							);
					if (v_us.IsID_CHUONGNull())
					{
						m_rdb_grid_edit_theo_quoc_lo_cong_trinh.Checked = true;
						m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Checked = false;
						if (m_ddl_grid_edit_loai_nhiem_vu.Items.Count > 0)
						{
							m_ddl_grid_edit_loai_nhiem_vu.SelectedValue = v_us.dcID_LOAI_NHIEM_VU.ToString();
							WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
								, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
								, m_ddl_grid_edit_du_an_quoc_lo);
							if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
							{
								m_ddl_grid_edit_du_an_quoc_lo.SelectedValue = v_us.dcID_CONG_TRINH.ToString();
								WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
									CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
									, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
									, m_ddl_grid_edit_du_an);
								m_ddl_grid_edit_du_an.SelectedValue = v_us.dcID_DU_AN.ToString(); ;
							}
						}
						m_ddl_grid_edit_muc_tieu_muc.Visible = false;
						m_ddl_grid_edit_du_an_quoc_lo.Visible = true;
						m_ddl_grid_edit_du_an.Visible = true;
					}
					else
					{
						m_rdb_grid_edit_theo_quoc_lo_cong_trinh.Checked = false;
						m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Checked = true;
						//dropdownlist muc - tieu muc

						if (m_ddl_grid_edit_muc_tieu_muc != null)
						{
							string v_str_id_mix = get_id_mix_from_id_gd(v_us.dcID);

							m_ddl_grid_edit_muc_tieu_muc.SelectedValue = v_str_id_mix;
						}
						m_ddl_grid_edit_muc_tieu_muc.Visible = true;
						m_ddl_grid_edit_du_an_quoc_lo.Visible = false;
						m_ddl_grid_edit_du_an.Visible = false;
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
					RadioButton m_rdb_grid_edit_theo_quoc_lo_cong_trinh = (RadioButton)m_grv_unc.FooterRow.FindControl("m_rdb_grid_theo_quoc_lo_cong_trinh");
					RadioButton m_rdb_grid_edit_theo_chuong_loai_khoan_muc = (RadioButton)m_grv_unc.FooterRow.FindControl("m_rdb_grid_theo_chuong_loai_khoan_muc");
					DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
					DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
					DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
					DropDownList m_ddl_grid_muc_tieu_muc = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_muc_tieu_muc");
					TextBox m_txt_grid_edit_so_tien_nop_thue = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_so_tien_nop_thue");
					TextBox m_txt_grid_edit_so_tien_tt_cho_dv_huong = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_so_tien_thanh_toan_cho_don_vi_huong");
					TextBox m_txt_grid_ghi_chu = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_ghi_chu");
					TextBox m_txt_grid_ma_nsnn = (TextBox)m_grv_unc.FooterRow.FindControl("m_txt_grid_ma_nguon_nsnn");

					m_txt_grid_edit_so_tien_nop_thue.Text = m_txt_grid_edit_so_tien_nop_thue.Text.Trim().Replace(",", "").Replace(".", "");
					m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text = m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text.Trim().Replace(",", "").Replace(".", "");
					//1. Check validate data
					//1.1 Chi theo Cong trinh/Du an
					if (m_rdb_grid_edit_theo_quoc_lo_cong_trinh.Checked == true)
					{
						if (m_ddl_grid_edit_du_an_quoc_lo.SelectedValue.Equals(""))
						{
							m_lbl_mess_detail.Text = "Bạn chọn lại Loại nhiệm vụ! Trong mục này không có Quốc lộ/Dự án nào!";
							m_ddl_grid_edit_loai_nhiem_vu.Focus();
							return;
						}
						if (m_ddl_grid_edit_du_an.SelectedValue.Equals(""))
						{
							m_lbl_mess_detail.Text = "Bạn chọn lại Quốc lộ/Dự án! Trong mục này không mục chi nào!";
							m_ddl_grid_edit_du_an_quoc_lo.Focus();
							return;
						}
					}
					//1.2 Chi theo Loai khoan muc
					else if (m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Checked == true)
					{
						if (m_ddl_grid_muc_tieu_muc.SelectedValue.Equals(""))
						{
							m_lbl_mess_detail.Text = "Bạn chọn lại Mục/Tiểu mục!";
							m_ddl_grid_edit_muc_tieu_muc.Focus();
							return;
						}
						else
						{
							string v_str_mix_muc_tieu_muc = m_ddl_grid_muc_tieu_muc.SelectedValue;
							if (v_str_mix_muc_tieu_muc.Split('|').Count() < 3)
							{
								m_lbl_mess_detail.Text = "Bạn chọn lại Mục/Tiểu mục!";
								m_ddl_grid_muc_tieu_muc.Focus();
								return;
							}
						}

					}

					if (m_hdf_id_dm_giai_ngan.Value.Trim().Equals("") || m_hdf_id_dm_giai_ngan.Value.Trim().Equals("-1"))
					{
						m_lbl_mess_detail.Text = "Bạn phải chọn Uỷ nhiệm chi đã có hoặc Nhập mới một Uỷ nhiệm chi!";
						m_txt_so_unc.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(m_txt_grid_ghi_chu, DataType.StringType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Nội dung thanh toán!";
						m_txt_grid_ghi_chu.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(m_txt_grid_edit_so_tien_nop_thue, DataType.NumberType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
						m_txt_grid_edit_so_tien_nop_thue.Focus();
						return;
					}
					if (CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_nop_thue.Text) < 0)
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền nộp thuế!";
						m_txt_grid_edit_so_tien_nop_thue.Focus();
						return;
					}
					if (!CValidateTextBox.IsValid(m_txt_grid_edit_so_tien_tt_cho_dv_huong, DataType.NumberType, allowNull.NO))
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
						m_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
						return;
					}
					if (CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text) < 0)
					{
						m_lbl_mess_detail.Text = "Bạn phải nhập Số tiền thanh toán cho đơn vị hưởng!";
						m_txt_grid_edit_so_tien_tt_cho_dv_huong.Focus();
						return;
					}
					//2. Insert data
					US_GD_CHI_TIET_GIAI_NGAN v_us_gd = new US_GD_CHI_TIET_GIAI_NGAN();
					v_us_gd.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue);
					if (m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Checked == true)
					{
						string v_str_mix = m_ddl_grid_muc_tieu_muc.SelectedValue;
						string[] v_arr_id = v_str_mix.Split('|');

						v_us_gd.dcID_CHUONG = CIPConvert.ToDecimal(v_arr_id[0]);
						//v_dc_id_loai = CIPConvert.ToDecimal(v_arr_id[1]);
						v_us_gd.dcID_KHOAN = CIPConvert.ToDecimal(v_arr_id[2]);
						v_us_gd.dcID_MUC = CIPConvert.ToDecimal(v_arr_id[3]);
						if (!v_arr_id[4].Trim().Equals(""))
						{
							v_us_gd.dcID_TIEU_MUC = CIPConvert.ToDecimal(v_arr_id[4]);
						}
						v_us_gd.SetID_CONG_TRINHNull();
						v_us_gd.strMA_NGUON_NSNN = m_txt_grid_ma_nsnn.Text.Trim();
						v_us_gd.SetID_DU_ANNull();

					}
					else
					{
						v_us_gd.dcID_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue);
						v_us_gd.dcID_DU_AN = CIPConvert.ToDecimal(m_ddl_grid_edit_du_an.SelectedValue);
						v_us_gd.SetID_CHUONGNull();
						v_us_gd.SetID_KHOANNull();
						v_us_gd.SetID_MUCNull();
						v_us_gd.SetID_TIEU_MUCNull();
					}

					v_us_gd.strNOI_DUNG_CHI = m_txt_grid_ghi_chu.Text.Trim();
					v_us_gd.dcID_DON_VI = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
					v_us_gd.dcID_GIAI_NGAN = CIPConvert.ToDecimal(m_hdf_id_dm_giai_ngan.Value);
					v_us_gd.dcSO_TIEN_NOP_THUE = CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_nop_thue.Text);
					v_us_gd.dcSO_TIEN_TT_CHO_DV_HUONG = CIPConvert.ToDecimal(m_txt_grid_edit_so_tien_tt_cho_dv_huong.Text);
					v_us_gd.strGHI_CHU = "";
					v_us_gd.Insert();
					WebformControls.ghiLogDuToan("Thêm bản ghi Giải ngân ở Giấy rút dự toán ngân sách số " + new US_DM_GIAI_NGAN(v_us_gd.dcID_GIAI_NGAN).strSO_UNC);
					load_data_to_grid_chi_tiet_uy_nhiem_chi();
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
			try
			{
				DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
				DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
				DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
				DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
				if (m_ddl_grid_edit_du_an == null) return;

				WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an_quoc_lo);
				if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
					WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
						CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
						, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
						, m_ddl_grid_edit_du_an);
					if (m_ddl_grid_edit_du_an.Items.Count > 0)
					{
						m_ddl_grid_edit_du_an.SelectedIndex = 0;
					}
				}
				else m_ddl_grid_edit_du_an.Items.Clear();

				//dropdownlist Loai khoan muc -tieu muc
				DropDownList m_ddl_grid_muc_tieu_muc = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_muc_tieu_muc");
				//m_ddl_grid_muc_tieu_muc.Width = 300;

				load_data_to_ddl_muc_tieu_muc(m_ddl_grid_muc_tieu_muc
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue));
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}


		}
		protected void m_ddl_grid_du_an_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
				DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an_quoc_lo");
				DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
				DropDownList m_ddl_grid_edit_du_an = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_du_an");
				if (m_ddl_grid_edit_du_an == null) return;

				WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_ddl_grid_edit_loai_nhiem_vu_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
				DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				//get control in by grid sender events
				DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)sender;
				GridViewRow v_gr = (GridViewRow)m_ddl_grid_edit_loai_nhiem_vu.Parent.Parent;
				DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
				DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an");
				DropDownList m_ddl_grid_edit_muc_tieu_muc = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_muc_tieu_muc");
				if (m_ddl_grid_edit_du_an == null) return;

				WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an_quoc_lo);
				if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
					WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
						CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
						, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
						, m_ddl_grid_edit_du_an);
					if (m_ddl_grid_edit_du_an.Items.Count > 0)
					{
						m_ddl_grid_edit_du_an.SelectedIndex = 0;
					}
				}
				else m_ddl_grid_edit_du_an.Items.Clear();
				//dropdownlist muc - tieu muc
				//US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_grv_unc.DataKeys[m_grv_unc.fo].Value));

				if (m_ddl_grid_edit_muc_tieu_muc != null)
				{
					//string v_str_id_mix = get_id_mix_from_id_gd(v_us.dcID);
					load_data_to_ddl_muc_tieu_muc(m_ddl_grid_edit_muc_tieu_muc
						, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					);
					//m_ddl_grid_edit_muc_tieu_muc.SelectedValue = v_str_id_mix;
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_ddl_grid_edit_du_an_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{

				DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
				DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
				//get control in by grid sender events
				DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)sender;
				GridViewRow v_gr = (GridViewRow)m_ddl_grid_edit_du_an_quoc_lo.Parent.Parent;
				DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
				DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_edit_grid_du_an");
				if (m_ddl_grid_edit_du_an == null) return;

				WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_rdb_grid_edit_theo_chuong_loai_khoan_muc_CheckedChanged(object sender, EventArgs e)
		{
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			visiable_control_edit_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(sender, false);
			RadioButton m_rdb_grid_edit_theo_chuong_loai_khoan_muc = (RadioButton)sender;
			GridViewRow v_gr = (GridViewRow)m_rdb_grid_edit_theo_chuong_loai_khoan_muc.Parent.Parent;
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an");
			DropDownList m_ddl_grid_edit_muc_tieu_muc = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_muc_tieu_muc");

			bool v_b_is_nguon_ns = true;
			bool v_b_is_chi_theo_du_an = false;
			//if (Request.QueryString["ip_nguon_ns"] != null)
			//{
			//	if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
			//	{
			//		v_b_is_nguon_ns = true;
			//	}
			//}
			WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu, v_b_is_nguon_ns, v_b_is_chi_theo_du_an);

			if (m_ddl_grid_edit_du_an == null) return;

			WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an_quoc_lo);
			if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
			{
				m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
				WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
				if (m_ddl_grid_edit_du_an.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an.SelectedIndex = 0;
				}
			}
			else m_ddl_grid_edit_du_an.Items.Clear();
			//dropdownlist muc - tieu muc
			//US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_grv_unc.DataKeys[m_grv_unc.fo].Value));

			if (m_ddl_grid_edit_muc_tieu_muc != null)
			{
				//string v_str_id_mix = get_id_mix_from_id_gd(v_us.dcID);
				load_data_to_ddl_muc_tieu_muc(m_ddl_grid_edit_muc_tieu_muc
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				);
				//m_ddl_grid_edit_muc_tieu_muc.SelectedValue = v_str_id_mix;
			}

		}
		protected void m_rdb_grid_edit_theo_quoc_lo_cong_trinh_CheckedChanged(object sender, EventArgs e)
		{
			visiable_control_edit_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(sender, true);
			DateTime v_dat_now = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, "dd/MM/yyyy");
			DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			RadioButton m_rdb_grid_edit_theo_quoc_lo_cong_trinh = (RadioButton)sender;
			GridViewRow v_gr = (GridViewRow)m_rdb_grid_edit_theo_quoc_lo_cong_trinh.Parent.Parent;
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an");
			DropDownList m_ddl_grid_edit_muc_tieu_muc = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_muc_tieu_muc");

			bool v_b_is_nguon_ns = false;
			bool v_b_is_chi_theo_du_an = true;
			if (Request.QueryString["ip_nguon_ns"] != null)
			{
				if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
				{
					v_b_is_nguon_ns = true;
				}
			}
			WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_edit_loai_nhiem_vu, v_b_is_nguon_ns, v_b_is_chi_theo_du_an);
			if (m_ddl_grid_edit_du_an == null) return;

			WebformControls.load_data_to_ddl_quoc_lo_cong_trinh(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				, m_ddl_grid_edit_du_an_quoc_lo);
			if (m_ddl_grid_edit_du_an_quoc_lo.Items.Count > 0)
			{
				m_ddl_grid_edit_du_an_quoc_lo.SelectedIndex = 0;
				WebformControls.load_data_to_ddl_ten_du_an(v_dat_dau_nam, v_dat_cuoi_nam, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
					CIPConvert.ToDecimal(m_ddl_grid_edit_du_an_quoc_lo.SelectedValue)
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
					, m_ddl_grid_edit_du_an);
				if (m_ddl_grid_edit_du_an.Items.Count > 0)
				{
					m_ddl_grid_edit_du_an.SelectedIndex = 0;
				}
			}
			else m_ddl_grid_edit_du_an.Items.Clear();
			//dropdownlist muc - tieu muc
			//US_GD_CHI_TIET_GIAI_NGAN v_us = new US_GD_CHI_TIET_GIAI_NGAN(CIPConvert.ToDecimal(m_grv_unc.DataKeys[m_grv_unc.fo].Value));

			if (m_ddl_grid_edit_muc_tieu_muc != null)
			{
				//string v_str_id_mix = get_id_mix_from_id_gd(v_us.dcID);
				load_data_to_ddl_muc_tieu_muc(m_ddl_grid_edit_muc_tieu_muc
					, CIPConvert.ToDecimal(m_ddl_grid_edit_loai_nhiem_vu.SelectedValue)
				);
				//m_ddl_grid_edit_muc_tieu_muc.SelectedValue = v_str_id_mix;
			}

		}

		private void visiable_control_edit_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(Object sender, bool ip_b_is_cong_trinh_du_an)
		{
			//get control in by grid sender events
			RadioButton m_rdb_sender = (RadioButton)sender;
			GridViewRow v_gr = (GridViewRow)m_rdb_sender.Parent.Parent;
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_du_an");
			DropDownList m_ddl_grid_edit_muc_tieu_muc = (DropDownList)v_gr.FindControl("m_ddl_grid_edit_muc_tieu_muc");
			m_ddl_grid_edit_du_an.Visible = ip_b_is_cong_trinh_du_an;
			m_ddl_grid_edit_du_an_quoc_lo.Visible = ip_b_is_cong_trinh_du_an;
			m_ddl_grid_edit_muc_tieu_muc.Visible = !ip_b_is_cong_trinh_du_an;
		}
		private void visiable_control_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(Object sender, bool ip_b_is_cong_trinh_du_an)
		{
			//get control in by grid sender events
			RadioButton m_rdb_sender = (RadioButton)sender;
			GridViewRow v_gr = (GridViewRow)m_rdb_sender.Parent.Parent;
			DropDownList m_ddl_grid_edit_du_an_quoc_lo = (DropDownList)v_gr.FindControl("m_ddl_grid_du_an_quoc_lo");
			DropDownList m_ddl_grid_edit_loai_nhiem_vu = (DropDownList)v_gr.FindControl("m_ddl_grid_loai_nhiem_vu");
			DropDownList m_ddl_grid_edit_du_an = (DropDownList)v_gr.FindControl("m_ddl_grid_du_an");
			DropDownList m_ddl_grid_edit_muc_tieu_muc = (DropDownList)v_gr.FindControl("m_ddl_grid_muc_tieu_muc");
			m_ddl_grid_edit_du_an.Visible = ip_b_is_cong_trinh_du_an;
			m_ddl_grid_edit_du_an_quoc_lo.Visible = ip_b_is_cong_trinh_du_an;
			m_ddl_grid_edit_muc_tieu_muc.Visible = !ip_b_is_cong_trinh_du_an;
		}

		protected void m_rdb_grid_theo_quoc_lo_cong_trinh_CheckedChanged(object sender, EventArgs e)
		{
			bool v_b_is_nguon_ns = false;
			bool v_b_is_chi_theo_du_an = true;
			DropDownList m_ddl_grid_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
			if (Request.QueryString["ip_nguon_ns"] != null)
			{
				if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
				{
					v_b_is_nguon_ns = true;
				}
			}
			WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_grid_loai_nhiem_vu, v_b_is_nguon_ns, v_b_is_chi_theo_du_an);
			visiable_control_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(sender, true);
		}
		protected void m_rdb_grid_theo_chuong_loai_khoan_muc_CheckedChanged(object sender, EventArgs e)
		{
			//Nguon Ngan sach
			bool v_b_is_nguon_ns = true;
			bool v_b_is_chi_theo_du_an = false;
			DropDownList m_ddl_grid_loai_nhiem_vu = (DropDownList)m_grv_unc.FooterRow.FindControl("m_ddl_grid_loai_nhiem_vu");
			//if (Request.QueryString["ip_nguon_ns"] != null)
			//{
			//	if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
			//	{
			//		v_b_is_nguon_ns = true;
			//	}
			//}
			WebformControls.load_data_to_ddl_loai_nhiem_vu(
								m_ddl_grid_loai_nhiem_vu
								, v_b_is_nguon_ns
								, v_b_is_chi_theo_du_an
								);
			visiable_control_in_grid_cong_trinh_du_an_and_chuong_loai_khoan_muc(sender, false);
			m_ddl_grid_loai_nhiem_vu_SelectedIndexChanged(null, null);
		}
		protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				m_cmd_chon_unc_Click(null, null);
				load_thong_tin_don_vi_lap_uy_nhiem_chi();
				load_data_to_grid_chi_tiet_uy_nhiem_chi();

				//Nếu không phải đơn vị của mình thì không được Nhập UNC,Thêm UNC
				if (m_ddl_don_vi.SelectedValue.Equals(Person.get_id_don_vi().ToString()))
				{
					m_cmd_luu_unc.Visible = true;
					m_cmd_nhap_moi_unc.Visible = true;
					m_cmd_save_info_unc.Visible = true;
				}
				else
				{
					m_cmd_luu_unc.Visible = false;
					m_cmd_nhap_moi_unc.Visible = false;
					m_cmd_save_info_unc.Visible = false;
				}

			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		#endregion
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		protected void m_cmd_export_excel_Click(object sender, EventArgs e)
		{

			decimal v_dc_id_giai_ngan = CIPConvert.ToDecimal(m_ddl_dm_giai_ngan.SelectedValue);
			decimal v_dc_id_don_vi = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
			WebformReport.F305ExportExcel(v_dc_id_giai_ngan, v_dc_id_don_vi);
		}
	}
}