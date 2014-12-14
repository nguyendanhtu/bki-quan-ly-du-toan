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
	public partial class f204_nhap_giao_ke_hoach_qbt : System.Web.UI.Page
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
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien.Replace(",","").Replace(".",""));
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
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu);
		}

        private void load_data_to_cbo_quoc_lo()
        {
            WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von1(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH, m_ddl_quoc_lo);
        }

        private void load_data_to_du_an()
        {
            WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von2(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN, CIPConvert.ToDecimal(m_ddl_quoc_lo.SelectedValue), m_ddl_du_an);
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
					m_lbl_mess_detail.Text = "Bạn phải nhập QĐ giao Kế hoạch hoặc Chọn QĐ đã nhập!";
					m_txt_so_qd.Focus();
					return false;
				}

				if (!CValidateTextBox.IsValid(m_txt_quoc_lo, DataType.StringType, allowNull.NO) && CIPConvert.ToDecimal(m_ddl_quoc_lo.SelectedValue)== -1)
				{
					m_lbl_mess_detail.Text += "\n Bạn phải nhập Tên hạng mục!";
                    m_txt_quoc_lo.Focus();
					return false;
				}

                if (!CValidateTextBox.IsValid(m_txt_du_an, DataType.StringType, allowNull.NO) && CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue) == -1)
				{
					m_lbl_mess_detail.Text += "\n Bạn phải nhập Tên khoản chi!";
                    m_txt_du_an.Focus();
					return false;
				}
                if (!CValidateTextBox.IsValid(m_txt_so_tien_nam_truoc_chuyen_sang, DataType.NumberType, allowNull.NO)
                    && !CValidateTextBox.IsValid(m_txt_so_tien_ns, DataType.NumberType, allowNull.NO)
                    && !CValidateTextBox.IsValid(m_txt_so_tien_qbt, DataType.NumberType, allowNull.NO))
                {
                    m_lbl_mess_detail.Text += "\n Bạn phải nhập Số tiền!";
                    m_txt_so_tien_nam_truoc_chuyen_sang.Focus();
                    return false;
                }

                if (CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue) == -1)
                {
                    m_lbl_mess_detail.Text += "\n Bạn phải chọn loại nhiệm vụ!";
                    m_ddl_loai_nhiem_vu.Focus();
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
		private void form_to_us_object()
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
			m_us.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);
			m_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_so_tien_ns.Text.Trim());
			m_us.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_so_tien_qbt.Text.Trim());
			m_us.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG = CIPConvert.ToDecimal(m_txt_so_tien_nam_truoc_chuyen_sang.Text.Trim());
			//m_us.strTEN_DU_AN = m_txt_noi_dung_chi.Text.Trim();
			m_us.strGHI_CHU = m_txt_ghi_chu.Text; ;

			m_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			m_us.dcID_DON_VI = Person.get_id_don_vi();
			m_us.SetID_CHUONGNull();
			m_us.SetID_KHOANNull();
			m_us.SetID_MUCNull();
			m_us.SetID_TIEU_MUCNull();
			insert_du_an();
			//m_us.dcID_DU_AN_CONG_TRINH = CIPConvert.ToDecimal(m_hdf_id_du_an.Value);
		}
		private void us_object_to_form()
		{
			m_us = new US_GD_CHI_TIET_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an_cong_trinh = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(m_us.dcID_CONG_TRINH);


			//m_txt_noi_dung_chi.Text = m_us.strTEN_DU_AN;
			m_txt_so_tien_ns.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NS);
			m_txt_so_tien_qbt.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_QUY_BT);
			m_txt_so_tien_nam_truoc_chuyen_sang.Text = CIPConvert.ToStr(m_us.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG);
			m_txt_ghi_chu.Text = m_us.strGHI_CHU;
			//m_txt_ten_quoc_lo.Text = v_us_du_an_cong_trinh.strTEN_DU_AN_CONG_TRINH.Replace("Quốc lộ ","");
			m_txt_noi_dung.Text = m_us.strGHI_CHU;
			//m_ddl_loai_nhiem_vu.SelectedValue = m_us.dcID_LOAI_NHIEM_VU.ToString();
			m_ddl_loai_nhiem_vu.Enabled = false;


			//set quyet dinh
			US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(m_us.dcID_QUYET_DINH);
			m_txt_so_qd.Text = v_us_quyet_dinh.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us_quyet_dinh.strNOI_DUNG;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us_quyet_dinh.datNGAY_THANG, "dd/MM/yyyy");
			m_hdf_id_quyet_dinh.Value = v_us_quyet_dinh.dcID.ToString();

			disable_edit_quyet_dinh();

		}
		private void disable_edit_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			m_txt_ngay_thang.Enabled = false;
			m_cmd_luu_qd.Visible = false;
		}
		private void load_data_to_grid()
		{
			try
			{
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
				v_us.get_grid_giao_kh_qbt(v_ds, v_dc_id_quyet_dinh);
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
		private void set_inital_form_mode()
		{
			xoa_trang();
			load_data_to_cbo_quyet_dinh();

			//load_data_to_cbo_quoc_lo();
			//load_data_to_du_an();
			//load_data_to_ddl_loai_nhiem_vu();
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
			m_txt_so_tien_ns.Text = "0";

			//m_txt_ctx_so_tien_nam_truoc_chuyen_sang.Text = "0";
			m_txt_so_tien_nam_truoc_chuyen_sang.Text = "0";

			//m_txt_ctx_so_tien_qbt.Text = "0";
			m_txt_so_tien_qbt.Text = "0";
			//m_ddl_tuyen_quoc_lo.SelectedValue = "-1";
			//m_ddl_du_an.SelectedValue = "-1";

			//m_cmd_ctx_update.Visible = false;
			//m_cmd_ctx_insert.Visible = true;

			m_txt_du_an.Text = "";
			//m_txt_ctx_noi_dung.Text = "";

			m_cmd_update.Visible = false;
			m_ddl_loai_nhiem_vu.Enabled = true;
			m_cmd_insert.Visible = true;

		}
		private void save_data()
		{
			m_lbl_mess_detail.Text = "";
			if (!check_validate_data_gd_is_ok()) return;
			//form_to_us_object();

			switch (get_form_mode(m_hdf_form_mode))
			{
				case LOAI_FORM.THEM:
					// Cập nhật quốc lộ
                    decimal v_dc_id_quoc_lo = 0;
                    if (CIPConvert.ToDecimal(m_ddl_quoc_lo.SelectedValue) == -1)
                    {
                        US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_quoc_lo = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
                        v_us_quoc_lo.SetID_CHANull();
                        v_us_quoc_lo.strTEN = m_txt_quoc_lo.Text;
                        v_us_quoc_lo.dcID_LOAI = ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH;
                        v_us_quoc_lo.dcID_DON_VI = Person.get_id_don_vi();
                        v_us_quoc_lo.Insert();
                        if (v_us_quoc_lo.IsIDNull())
                        {
                            BaseMessages.MsgBox_Infor("Không thêm được hạng mục này!");
                            return;
                        }
                        v_dc_id_quoc_lo = v_us_quoc_lo.dcID;
                    }
                    else
                    {
                        v_dc_id_quoc_lo = CIPConvert.ToDecimal(m_ddl_quoc_lo.SelectedValue);
                    }
                    
                    // Cập nhật dự án
                    decimal v_dc_id_du_an = 0;
                    if (CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue) == -1)
                    {
                        US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
                        v_us_du_an.dcID_CHA= v_dc_id_quoc_lo;
                        v_us_du_an.strTEN = m_txt_du_an.Text;
                        v_us_du_an.dcID_LOAI = ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN;
                        v_us_du_an.dcID_DON_VI = Person.get_id_don_vi();
                        v_us_du_an.Insert();
                        if (v_us_du_an.IsIDNull())
                        {
                            BaseMessages.MsgBox_Infor("Không thêm được khoản chi này!");
                            return;
                        }
                        v_dc_id_du_an = v_us_du_an.dcID;
                    }
                    else
                    {
                        v_dc_id_du_an = CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue);
                    }
                    // Cập nhật kế hoạch
                    US_GD_CHI_TIET_GIAO_KH v_us_gd_kh = new US_GD_CHI_TIET_GIAO_KH();
                    v_us_gd_kh.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue);
                    v_us_gd_kh.dcID_DON_VI = Person.get_id_don_vi();
                    v_us_gd_kh.dcID_CONG_TRINH = v_dc_id_quoc_lo;
                    if (CValidateTextBox.IsValid(m_txt_so_tien_nam_truoc_chuyen_sang, DataType.NumberType, allowNull.NO))
                        v_us_gd_kh.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG = CIPConvert.ToDecimal(m_txt_so_tien_nam_truoc_chuyen_sang.Text);
                    if (CValidateTextBox.IsValid(m_txt_so_tien_ns, DataType.NumberType, allowNull.NO))
                        v_us_gd_kh.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_so_tien_ns.Text);
                    if (CValidateTextBox.IsValid(m_txt_so_tien_qbt, DataType.NumberType, allowNull.NO))
                        v_us_gd_kh.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_so_tien_qbt.Text);
                    v_us_gd_kh.strGHI_CHU = m_txt_ghi_chu.Text;
                    v_us_gd_kh.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);
                    v_us_gd_kh.dcID_DU_AN = v_dc_id_du_an;                    
                    v_us_gd_kh.Insert();
					m_lbl_mess_detail.Text = "Bạn đã tạo mới thành công!";

					break;
				case LOAI_FORM.SUA:
					try
					{
						//m_us.BeginTransaction();
						
						US_DM_QUYET_DINH v_us_quyet_dinh=new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value));
						US_GD_CHI_TIET_GIAO_KH v_us_ten_cu = new US_GD_CHI_TIET_GIAO_KH(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
						//m_us.update_ten_du_an_giao_kh_to_giao_von_va_unc(Person.get_id_don_vi()
						//	, v_us_ten_cu.dcID_LOAI_NHIEM_VU
						//	, v_us_ten_cu.dcID_DU_AN_CONG_TRINH
						//	, v_us_ten_cu.strTEN_DU_AN
						//	, m_us.strTEN_DU_AN
						//	, WinFormControls.get_dau_nam_form_date(v_us_quyet_dinh.datNGAY_THANG)
						//	, WinFormControls.get_cuoi_nam_form_date(v_us_quyet_dinh.datNGAY_THANG));
						m_us.Update();
						//m_us.CommitTransaction();
					}
					catch (Exception)
					{
						//m_us.Rollback();
						m_lbl_mess_detail.Text = "Quá trình cập nhật xảy ra lỗi, bạn vui lòng thực hiện lại thao tác!";
					}
					

					m_lbl_mess_detail.Text = "Bạn đã cập nhật thành công!";
					break;
			}
			xoa_trang();
			//m_ddl_du_an.SelectedValue = "-1";
			load_data_to_grid();
		}
		private void delete_dm_han_muc_by_ID()
		{
			m_us.DeleteByID(CIPConvert.ToDecimal(m_hdf_id_giao_kh.Value));
			load_data_to_grid();
			m_lbl_mess_grid.Text = "Xoá bản ghi thành công!";
		}
		private bool insert_du_an()
		{
			bool v_b_result = true;
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
				v_us.FillDataset(v_ds, "where " + DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + "= N'" + m_txt_quoc_lo.Text + "'");
				//1.1 Nếu có rồi thì không thêm nữa
				if (v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU.Count > 0)
				{
					v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(CIPConvert.ToDecimal(v_ds.Tables[0].Rows[0][DM_CONG_TRINH_DU_AN_GOI_THAU.ID]));
					v_b_result = true;
				}
				else
				{
					//1.2 Nếu chưa có thì thêm mới
					v_us.dcID_DON_VI = Person.get_id_don_vi();
					v_us.strTEN = m_txt_quoc_lo.Text.Trim();
					v_us.Insert();
				}
				m_hdf_id_du_an.Value = v_us.dcID.ToString();
				v_b_result = true;

			}
			catch (Exception)
			{
				v_b_result = false;
			}
			return v_b_result;
		}



		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					set_inital_form_mode();
					if (Request.QueryString["ip_dc_id_quyet_dinh"]!=null)
					{
						decimal v_dc_id_quyet_dinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_quyet_dinh"]);
						load_data_to_cbo_quyet_dinh();
						m_ddl_quyet_dinh.SelectedValue = v_dc_id_quyet_dinh.ToString();
						m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
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
					delete_dm_han_muc_by_ID();
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
			m_hdf_id_quyet_dinh.Value = m_ddl_quyet_dinh.SelectedValue;
			load_data_to_cbo_quyet_dinh();
			m_ddl_quyet_dinh.Visible = true;
			m_txt_so_qd.Visible = false;
			m_txt_noi_dung.Visible = false;
			m_txt_ngay_thang.Visible = false;
			m_cmd_luu_qd.Visible = false;

			//reload_data_to_ddl();

		}
		private void load_data_when_quyet_dinh_is_selected()
		{
			m_txt_so_qd.Visible = true;
			m_txt_noi_dung.Visible = true;
			m_txt_ngay_thang.Visible = true;

			disable_edit_quyet_dinh();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue)); ;
			m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us.strNOI_DUNG;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

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
				m_rdb_kh_dau_nam.Checked = true;
				m_rdb_dieu_chinh.Checked = false;
				m_rdb_bo_sung.Checked = false;
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.BO_SUNG)
			{
				m_rdb_kh_dau_nam.Checked = false;
				m_rdb_dieu_chinh.Checked = false;
				m_rdb_bo_sung.Checked = true;
			}
			else if (v_us.dcID_LOAI_QUYET_DINH_GIAO == ID_LOAI_GIAO_DICH.DIEU_CHINH)
			{
				m_rdb_kh_dau_nam.Checked = false;
				m_rdb_dieu_chinh.Checked = true;
				m_rdb_bo_sung.Checked = false;
			}

		}
		protected void m_cmd_nhap_qd_moi_Click(object sender, EventArgs e)
		{
			m_hdf_id_quyet_dinh.Value = "";

			m_ddl_quyet_dinh.Visible = false;
			m_txt_so_qd.Enabled = true;
			m_txt_noi_dung.Enabled = true;
			m_txt_ngay_thang.Enabled = true;

			m_txt_so_qd.Visible = true;
			m_txt_noi_dung.Visible = true;
			m_txt_ngay_thang.Visible = true;

			m_cmd_luu_qd.Visible = true;

			m_txt_so_qd.Text = "";
			m_txt_noi_dung.Text = "";
			m_txt_ngay_thang.Text = "";

		}
		protected void m_cmd_luu_qd_Click(object sender, EventArgs e)
		{
			try
			{
				m_hdf_id_quyet_dinh.Value = "";
				//check validate luu quyet dinh
				if (check_data_quyet_dinh_is_ok())
				{
					m_hdf_id_quyet_dinh.Value = insert_quyet_dinh().ToString();
				}
				// insert gd quyet dinh
				//do not edit
				disable_info_quyet_dinh();
				m_lbl_mess_qd.Text = "Lưu QĐ thành công!";
				//set id to hiddenfield
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
			if (m_rdb_kh_dau_nam.Checked == true)
			{
				v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.KH_DAU_NAM;
			}
			else if (m_rdb_bo_sung.Checked == true)
			{
				v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.BO_SUNG;
			}
			else v_us.dcID_LOAI_QUYET_DINH_GIAO = ID_LOAI_GIAO_DICH.DIEU_CHINH;
			v_us.dcID_DON_VI = Person.get_id_don_vi();
			v_us.dcID_LOAI_QUYET_DINH = ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
			v_us.strNOI_DUNG = m_txt_noi_dung.Text.Trim();
			v_us.strSO_QUYET_DINH = m_txt_so_qd.Text.Trim();
			v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), "dd/MM/yyyy");
			v_us.Insert();
			return v_us.dcID;
		}
		private void disable_info_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			m_txt_ngay_thang.Enabled = false;
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
			if (m_txt_ngay_thang.Text.Trim().Equals(""))
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
				m_txt_ngay_thang.Focus();
				return false;
			}
			DateTime v_dat_ngay_thang = DateTime.Now;
			try
			{
				v_dat_ngay_thang = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim());
			}
			catch (Exception)
			{
				m_lbl_mess_qd.Text = "Bạn phải nhập Ngày tháng!";
				m_txt_ngay_thang.Focus();
				return false;
			}
			return true;
		}
        // NinhVH viêt
        
        protected void m_cmd_them_quoc_lo_Click(object sender, EventArgs e)
        {
            // Chuyển ddl_quoc_lo về mặc định
            m_ddl_quoc_lo.Visible = false;
            m_ddl_quoc_lo.SelectedValue = "-1";
            // Hiển thị text nhập tên quốc lộ
            m_txt_quoc_lo.Visible = true;
            m_txt_quoc_lo.Text = "";

            m_cmd_them_quoc_lo.Visible = false;
            m_cmd_chon_quoc_lo.Visible = true;
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
            m_ddl_quoc_lo.Visible = true;
            m_ddl_quoc_lo.SelectedValue = "-1";
            // Hiển thị text nhập tên dự án
            m_txt_quoc_lo.Visible = false;
            m_txt_quoc_lo.Text = "";

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

        protected void m_ddl_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_data_to_du_an();
        }

        

        // End NinhVH

		#endregion


	}
}