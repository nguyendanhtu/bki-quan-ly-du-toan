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
using SQLDataAccess;


namespace QuanLyDuToan.BaoCao
{
	public partial class F350_tinh_hinh_giai_ngan : System.Web.UI.Page
	{

		#region Refactory by Huytd ngày 12/02/2015 7:30pm
		/*
         * còn chưa refactory format_link_to_chi_tiet() & format_link_to_chi_tiet_trong_thang
         */
		#endregion

		#region Public Function

		public string format_link_to_chi_tiet(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns
								, string ip_str_form_name
								, double value)
		{
			string v_dat_tu_ngay = CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay, "dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy");
			string v_dat_den_ngay = CIPConvert.ToStr(m_dat_den_ngay, "dd/MM/yyyy");
			string v_str_link = "<a href='" + ip_str_form_name;
			if (ip_level != DBNull.Value)
			{
				if (ip_id_don_vi == DBNull.Value) ip_id_don_vi = -1;
				if (ip_id_loai_nhiem_vu == DBNull.Value) ip_id_loai_nhiem_vu = -1;
				if (ip_id_cong_trinh == DBNull.Value) ip_id_cong_trinh = -1;
				if (ip_id_du_an == DBNull.Value) ip_id_du_an = -1;
				switch (CIPConvert.ToStr(ip_level))
				{
					//lv 1: get link theo loai nhiem vu
					case "1":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + "-1"
									 + "&ip_dc_id_du_an=" + "-1"
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									  + "&ip_dc_id_quyet_dinh =" + "-1";
						break;
					//lv2: get link theo cong trinh
					case "2":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//lv3: get link theo du an
					case "3":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									  + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					default:
						//get link theo du an
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									  + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
				v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns + "'>" + CIPConvert.ToStr(value, "#,##0");
			}
			return v_str_link;
		}

		public string format_link_to_chi_tiet_trong_thang(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns
								, string ip_str_form_name
								, double value)
		{
			if (ip_id_don_vi == DBNull.Value) ip_id_don_vi = -1;
			if (ip_id_loai_nhiem_vu == DBNull.Value) ip_id_loai_nhiem_vu = -1;
			if (ip_id_cong_trinh == DBNull.Value) ip_id_cong_trinh = -1;
			if (ip_id_du_an == DBNull.Value) ip_id_du_an = 10;
			string v_str_link = "<a href='" + ip_str_form_name;
			if (ip_level != DBNull.Value)
			{
				switch (CIPConvert.ToStr(ip_level))
				{
					//lv3: get link theo loai nhiem vu
					case "3":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + "-1"
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_tu_ngay, "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay, "dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";

						break;
					//lv2: get link theo cong trinh 
					case "2":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_tu_ngay, "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay, "dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//lv1: get link theo lv du an
					case "1":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_dau_nam, "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay, "dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//get link theo du an
					default:
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay, "dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay, "dd/MM/yyyy")
									  + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
			}
			v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns + "'>" + CIPConvert.ToStr(value, "#,##0");
			return v_str_link;
		}


		public decimal get_random_id_session()
		{
			Random no_random = new Random();
			return no_random.Next(1, 1000); //random a number in 1 - 1000
		}

		public string ConvertToUnsign3(string str)
		{
			// Convert từ "tiếng việt" sang "tieng viet" không dấu
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
			string temp = str.Normalize(System.Text.NormalizationForm.FormD);
			return regex.Replace(temp, String.Empty)
						.Replace('\u0111', 'd').Replace('\u0110', 'D');
			//return str;
		}

		#endregion

		#region Data Member
		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;

		public decimal m_dc_id_don_vi;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;
		public List<SQLDataAccess.CM_DM_TU_DIEN> m_lst_loai_nhiem_vu;

		#endregion

		#region Private Method
		private void set_value_from_query_string()
		{
			//load don vi
			m_dc_id_don_vi = WebformFunctions.getValue_from_query_string<Decimal>(
				this
				, FormInfo.QueryString.ID_DON_VI
				, Person.get_id_don_vi());
			//load ngay thang theo query string
			DateTime v_dat_dau_thang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<String>(
				this
				, FormInfo.QueryString.TU_NGAY
				, CIPConvert.ToStr(v_dat_dau_thang, "dd/MM/yyyy"));
			m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<String>(
				this
				, FormInfo.QueryString.DEN_NGAY
				, CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy"));

		}
		private void set_inital_form_load()
		{
			// get query string
			set_value_from_query_string();

			//load dll don vi
			load_data_to_ddl_don_vi();

			//load cac ddl
			//App_Code.WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			//App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, m_dc_id_don_vi);
			//App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, m_dc_id_don_vi);
			//load data grid
			load_data_to_grid();
		}

		private void load_data_to_ddl_don_vi()
		{
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
								Person.get_id_don_vi()
								, m_ddl_don_vi);
			if (m_dc_id_don_vi != -1)
			{
				m_ddl_don_vi.SelectedValue = m_dc_id_don_vi.ToString();
			}
			else
			{
				m_ddl_don_vi.SelectedValue = Person.get_id_don_vi().ToString();
			}
		}
		private void load_data_to_grid()
		{
			// kiem tra du lieu
			if (!check_validate_data_is_ok()) return;

			m_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text);
			m_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text);
			m_dat_dau_nam = CCommonFunction.getDate_dau_nam_from_date(m_dat_tu_ngay);
			m_dc_id_don_vi = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);

			BKI_QLDTEntities db = new BKI_QLDTEntities();

			m_lst_loai_nhiem_vu = db.CM_DM_TU_DIEN
									.Where(x => x.ID_LOAI_TU_DIEN == WebUS.ID_LOAI_TU_DIEN.LOAI_NHIEM_VU
										|| x.ID == WebUS.ID_LOAI_NHIEM_VU_NS.DU_TOAN_CHI_NS_NN)
									.OrderBy(x => x.ID_LOAI_TU_DIEN)
									.ThenBy(x => x.GHI_CHU)
									.ToList();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();

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
				m_lbl_mess.Text = ""; // reset thông báo
				if (!IsPostBack)
				{
					set_inital_form_load();
				}

			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
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
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				try
				{
					if (check_validate_data_is_ok())
					{
						WebformReport.F350ExportExcel(
							CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy"),
							CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy"),
							CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
					}
				}
				catch (Exception v_e)
				{
					CSystemLog_301.ExceptionHandle(this, v_e);
				}
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
				load_data_to_grid();
			}
			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}


	}

		#endregion
}
