using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using IP.Core.IPUserService;
using IP.Core.IPData;

namespace QuanLyDuToan.DuToan
{
	public partial class f205_nhap_giao_ke_hoach_qbt : System.Web.UI.Page
	{


		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				bool v_b_is_nguon_ns=false;
				if (Request.QueryString["ip_nguon_ns"]!=null)
				{
					if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
					{
						v_b_is_nguon_ns = true;
					}
				}
				if (v_b_is_nguon_ns) m_lbl_kinh_phi.Text = "Kinh phí Ngân sách (*)";
				else
				{
					m_lbl_kinh_phi.Text = "Kinh phí Quỹ BT (*)";
				}
				load_data_2_ddl();
				load_data_to_grid();
			}
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

				//kiem tra xem dang nhap Nguon nao
				string v_str_is_nguon_ns = "N";
				if (Request.QueryString["ip_nguon_ns"] == "Y")
				{
					v_str_is_nguon_ns = "Y";
				}
				v_us.get_grid_giao_kh_qbt(v_ds, v_dc_id_quyet_dinh, v_str_is_nguon_ns);
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
		private void load_data_2_ddl()
		{
			load_data_2_ddl_so_qd();
			load_data_2_ddl_loai_nhiem_vu();
			load_data_2_ddl_loai_nhiem_vu_lkm();
			load_data_to_ddl_quoc_lo();
			load_data_to_ddl_chuong();
			load_data_to_ddl_loai();
			load_data_to_ddl_muc();
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
		private void load_data_to_ddl_quoc_lo()
		{
			WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von1(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH, m_ddl_cong_trinh_quoc_lo);
		}
		private void load_data_to_ddl_du_an()
		{
			WinFormControls.load_data_to_cbo_du_an_cong_trinh_from_giao_von2(ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN, CIPConvert.ToDecimal(m_ddl_cong_trinh_quoc_lo.SelectedValue), m_ddl_du_an);
		}

		private void load_data_2_ddl_loai_nhiem_vu()
		{
			WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu);
		}

		private void load_data_2_ddl_loai_nhiem_vu_lkm()
		{
			var v_str_ns_yn = Request.QueryString["ip_nguon_ns"].ToString();
			if (v_str_ns_yn.Contains("Y"))
			{
				WinFormControls.load_data_to_ddl_loai_nhiem_vu_ns(m_ddl_loai_nhiem_vu_lkm);
			}
			else
			{
				WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nhiem_vu_lkm);
			}
		}

		private void load_data_2_ddl_so_qd()
		{
			WinFormControls.load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(WinFormControls.LOAI_QUYET_DINH.GIAO_KE_HOACH, m_ddl_so_qd);
		}

		protected void m_cmd_them_moi_quyet_dinh_Click(object sender, EventArgs e)
		{
			try
			{
				m_hdf_id_quyet_dinh.Value = insert_quyet_dinh().ToString();
				edit_label_grid();
			}
			catch (Exception)
			{
				throw;
			}
		}

		private void edit_label_grid()
		{
			m_lbl_grid_ngay.Text = m_txt_ngay_thang.Text;
			m_lbl_grid_so_quyet_dinh.Text = m_txt_so_qd.Text;
			m_lbl_grid_ve_viec.Text = m_txt_ghi_chu.Text;
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
			v_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text.Trim(), c_configuration.DEFAULT_DATETIME_FORMAT);
			v_us.Insert();
			return v_us.dcID;
		}

		protected void m_cmd_ghi_chi_tiet_qd_Click(object sender, EventArgs e)
		{
			try
			{
				US_GD_CHI_TIET_GIAO_KH v_us = new US_GD_CHI_TIET_GIAO_KH();
				form_2_us(v_us, chiTheoQuocLoDuAn.Checked);
				v_us.Insert();
				load_data_to_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		private void form_2_us(US_GD_CHI_TIET_GIAO_KH v_us, bool ip_b_chi_theo_ql_da)
		{
			v_us.dcID_QUYET_DINH = CIPConvert.ToDecimal(m_hdf_id_quyet_dinh.Value);
			v_us.dcID_DON_VI = Person.get_id_don_vi();

			v_us.dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG = CIPConvert.ToDecimal(m_txt_kinh_phi_nam_truoc_chuyen_sang.Text.Replace(",", "").Replace(".", ""));
			v_us.strGHI_CHU_1 = m_txt_noi_dung_du_toan.Text.Trim();
			var v_str_ns_yn = Request.QueryString["ip_nguon_ns"].ToString();
			if (v_str_ns_yn.Contains("Y"))
			{
				v_us.dcSO_TIEN_NS = CIPConvert.ToDecimal(m_txt_kinh_phi_quy_bao_tri.Text.Trim().Replace(",", "").Replace(".", ""));
				v_us.dcSO_TIEN_QUY_BT = 0;
			}
			else
			{
				v_us.dcSO_TIEN_QUY_BT = CIPConvert.ToDecimal(m_txt_kinh_phi_quy_bao_tri.Text.Trim().Replace(",", "").Replace(".", ""));
				v_us.dcSO_TIEN_NS = 0;
			}
			v_us.strGHI_CHU = m_txt_ghi_chu.Text;
			if (ip_b_chi_theo_ql_da)
			{
				v_us.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue);

				if (m_ddl_cong_trinh_quoc_lo.Visible)
				{
					v_us.dcID_CONG_TRINH = CIPConvert.ToDecimal(m_ddl_cong_trinh_quoc_lo.SelectedValue);
				}
				else
				{
					v_us.dcID_CONG_TRINH = insert_cong_trinh();
					if (v_us.dcID_CONG_TRINH == -1)//insert cong trinh bi loi
					{
						return;
					}
					else
					{
						v_us.dcID_DU_AN = insert_du_an(v_us.dcID_CONG_TRINH);
					}
				}

				v_us.strGHI_CHU_1 = m_txt_ten_du_an.Text;

				v_us.strGHI_CHU_2 = m_txt_so_km.Text;
			}
			else
			{

				v_us.dcID_LOAI_NHIEM_VU = CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu_lkm.SelectedValue);

				if (m_rad_thuong_xuyen.Checked)
				{
					v_us.strTU_CHU_YN = "Y";
				}
				else
				{
					v_us.strTU_CHU_YN = "N";
				}

				v_us.dcID_CHUONG = CIPConvert.ToDecimal(m_ddl_chuong.SelectedValue);
				v_us.dcID_KHOAN = CIPConvert.ToDecimal(m_ddl_khoan.SelectedValue);
				v_us.dcID_MUC = CIPConvert.ToDecimal(m_ddl_muc.SelectedValue);
				v_us.dcID_TIEU_MUC = CIPConvert.ToDecimal(m_ddl_tieu_muc.SelectedValue);
				if (v_us.dcID_CHUONG == -1)
				{
					v_us.SetID_CHUONGNull();
				}
				if (v_us.dcID_KHOAN == -1)
				{
					v_us.SetID_KHOANNull();
				}
				if (v_us.dcID_MUC == -1)
				{
					v_us.SetID_MUCNull();
				}
				if (v_us.dcID_TIEU_MUC == -1)
				{
					v_us.SetID_TIEU_MUCNull();
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
					v_us.FillDataset(v_ds, "where " + DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + "= N'" + m_txt_ten_du_an.Text.Trim() + "'" +
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
						v_us.strTEN = m_txt_ten_du_an.Text.Trim();
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

		protected void m_ddl_loai_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_khoan();
		}

		protected void m_ddl_muc_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_tieu_muc();
		}

		protected void m_ddl_loai_nhiem_vu_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (CIPConvert.ToDecimal(m_ddl_loai_nhiem_vu.SelectedValue) != 660)
			{
				m_txt_so_km.Text = "0";
				m_txt_so_km.Enabled = false;
			}
			else
			{
				m_txt_so_km.Enabled = true;
			}
		}

		protected void m_ddl_so_qd_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ddl_so_qd.SelectedValue == null) return;
			//m_ddl_so_qd.Visible = false;
			m_hdf_id_quyet_dinh.Value = m_ddl_so_qd.SelectedValue;
			load_data_when_quyet_dinh_is_selected();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_so_qd.SelectedValue));
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
			load_data_to_grid();
		}

		private void load_data_when_quyet_dinh_is_selected()
		{
			//m_txt_so_qd.Visible = true;
			//m_txt_noi_dung.Visible = true;
			//m_txt_ngay_thang.Visible = true;

			disable_edit_quyet_dinh();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(m_ddl_so_qd.SelectedValue)); ;
			m_txt_so_qd.Text = v_us.strSO_QUYET_DINH;
			m_txt_noi_dung.Text = v_us.strNOI_DUNG;
			m_txt_ngay_thang.Text = CIPConvert.ToStr(v_us.datNGAY_THANG, "dd/MM/yyyy");

			//reload_data_to_ddl();            
			//load_data_to_cbo_quoc_lo();
			//load_data_to_du_an();
			//load_data_to_ddl_loai_nhiem_vu();
			load_data_to_grid();
		}

		private void disable_edit_quyet_dinh()
		{
			m_txt_so_qd.Enabled = false;
			m_txt_noi_dung.Enabled = false;
			m_txt_ngay_thang.Enabled = false;
			m_cmd_them_moi_quyet_dinh.Visible = false;
			m_cmd_cho_them_qd.Visible = true;
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

		protected void m_cmd_them_cong_trinh_block_Click(object sender, EventArgs e)
		{
			m_txt_cong_trinh.Visible = true;
			m_ddl_cong_trinh_quoc_lo.Visible = false;
			m_cmd_them_cong_trinh.Visible = true;
			m_cmd_them_cong_trinh_block.Visible = false;
		}

		protected void m_cmd_them_cong_trinh_Click(object sender, EventArgs e)
		{
			m_txt_cong_trinh.Visible = false;
			m_ddl_cong_trinh_quoc_lo.Visible = true;
			m_cmd_them_cong_trinh_block.Visible = true;
			m_cmd_them_cong_trinh.Visible = false;
		}

		private decimal insert_cong_trinh()
		{
			decimal v_dc_id_cong_trinh = -1;
			//kiem tra xem nguoi dung dang Chon Cong trinh hay dang nhap
			//Neu dang chon -> lay ra id cong trinh
			if (m_ddl_cong_trinh_quoc_lo.Visible == true)
			{
				return CIPConvert.ToDecimal(m_ddl_cong_trinh_quoc_lo.SelectedValue);
			}
			else
			{
				//Neu dang nhap ->insert 1 cong trinh moi
				try
				{
					//0. khi chi nhap ten quoc lo vd: 1A thì lưu lại thành 'Quốc lộ 1A'
					if (m_txt_cong_trinh.Text.Trim().Length < 5)
					{
						m_txt_cong_trinh.Text = "Quốc lộ " + m_txt_cong_trinh.Text.Trim();
					}
					//1. kiểm tra xem đã có tên quốc lộ trong bản DM_CONG_TRINH_DU_AN_GOI_THAU chưa 
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
					DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
					v_us.FillDataset(v_ds, "where " + DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + "= N'" + m_txt_cong_trinh.Text + "'" +
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
						v_us.strTEN = m_txt_cong_trinh.Text.Trim();
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

		protected void m_cmd_cho_them_qd_Click(object sender, EventArgs e)
		{
			m_cmd_them_moi_quyet_dinh.Visible = true;
			m_txt_so_qd.Enabled = true;
			m_txt_so_qd.Text = "";
			m_txt_noi_dung.Text = "";
			m_txt_ngay_thang.Text = "";
			m_txt_noi_dung.Enabled = true;
			m_txt_ngay_thang.Enabled = true;
			m_cmd_cho_them_qd.Visible = false;
		}

		protected void m_cmd_them_du_an_block_Click(object sender, EventArgs e)
		{
			m_txt_ten_du_an.Visible = true;
			m_ddl_du_an.Visible = false;
			m_cmd_them_du_an.Visible = true;
			m_cmd_them_du_an_block.Visible = false;
		}

		protected void m_cmd_them_du_an_Click(object sender, EventArgs e)
		{
			m_txt_ten_du_an.Visible = false;
			m_ddl_du_an.Visible = true;
			m_cmd_them_du_an_block.Visible = true;
			m_cmd_them_du_an.Visible = false;
		}

		protected void m_ddl_cong_trinh_quoc_lo_SelectedIndexChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_du_an();
		}
	}
}