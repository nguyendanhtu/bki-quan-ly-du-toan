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
	public partial class F350_tinh_hinh_giai_ngan : System.Web.UI.Page
	{

		#region Refactory by Huytd ngày 12/02/2015 7:30pm
		/*
         * còn chưa refactory format_link_to_chi_tiet() & format_link_to_chi_tiet_trong_thang
         */
		#endregion

		#region Public Function
		public string getSTT(string ip_str_noi_dung)
		{
			if (ip_str_noi_dung.Contains("Tổng cộng")) return "";
			m_i_stt++;
			return m_i_stt.ToString();
		}
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		public decimal format_so_tien(object ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien == DBNull.Value)
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
			return op_dc_so_tien;
		}

		public string format_link_to_chi_tiet(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns)
		{
			string v_dat_tu_ngay = CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy");
			string v_dat_den_ngay = m_txt_den_ngay.Text;
			string v_str_link = "";
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
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy")
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
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy")
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
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy")
									  + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
				v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns;
			}
			return v_str_link;
		}

		public string format_link_to_chi_tiet_trong_thang(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns)
		{
			if (ip_id_don_vi == DBNull.Value) ip_id_don_vi = -1;
			if (ip_id_loai_nhiem_vu == DBNull.Value) ip_id_loai_nhiem_vu = -1;
			if (ip_id_cong_trinh == DBNull.Value) ip_id_cong_trinh = -1;
			if (ip_id_du_an == DBNull.Value) ip_id_du_an = 10;
			string v_str_link = "";
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
									 + "&ip_dat_tu_ngay=" + m_txt_tu_ngay.Text
									 + "&ip_dat_den_ngay=" + m_txt_den_ngay.Text
									 + "&ip_dc_id_quyet_dinh=" + "-1";

						break;
					//lv2: get link theo cong trinh 
					case "2":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + m_txt_tu_ngay.Text
									 + "&ip_dat_den_ngay=" + m_txt_den_ngay.Text
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//lv1: get link theo lv du an
					case "1":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + m_txt_den_ngay.Text
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//get link theo du an
					default:
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + m_txt_den_ngay.Text
									  + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
			}
			v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns;
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
		private int m_i_stt = 0;
		decimal m_dc_id_don_vi = -1;
		DateTime m_dat_tu_ngay;
		DateTime m_dat_den_ngay;
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
			App_Code.WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, m_dc_id_don_vi);
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, m_dc_id_don_vi);
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

			// load data to grid
			US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
			DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
			v_ds.EnforceConstraints = false;
			v_us.bc_tinh_hinh_giai_ngan_theo_don_vi(v_ds
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy"))
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
				, get_random_id_session()    // tránh xóa dữ liệu của 2 người cùng đăng nhập một user
				, CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
				, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_txt_tim_kiem.Text.Trim()
				, STR_NGUON.QUY_BAO_TRI);
			m_grv.DataSource = v_ds.RPT_BC_TINH_HINH_GIAI_NGAN;
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
				US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
				WebformReport.export_gridview_2_excel(
				m_grv
				, "[" + ConvertToUnsign3(v_us.strTEN_DON_VI) + "]" + FormInfo.ExportExcelReportName.F350
				);
			}
			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (m_ddl_don_vi.SelectedValue.Equals(""))
				{
					CSystemLog_301.ExceptionHandle(this, new Exception("Không có Đơn vị để thực hiện truy vấn"));
				}
				App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
											CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
											, m_ddl_cong_trinh
											, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
											);
			}

			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				if (m_ddl_don_vi.SelectedValue.Equals(""))
				{
					CSystemLog_301.ExceptionHandle(this, new Exception("Không có Đơn vị để thực hiện truy vấn"));
				}
				App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(
												CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue)
												, CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
												, m_ddl_du_an
												, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
												);
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
				m_ddl_loai_nv_SelectedIndexChanged(null, null);
				load_data_to_grid();
			}
			catch (Exception v_e)
			{

				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e)
		{
			//Tao header cua grid
			const string v_c_str_header_css_class = "HeaderStyle";
			if (e.Row.RowType == DataControlRowType.Header) // If header created
			{
				GridView v_grv = (GridView)sender;
				//Tao dong 1
				WebformFunctions.addHeaderRow_to_grid_view(v_grv
					, 0
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("STT",3,1)
						,new CellInfoHeader("Nội dung",3,1)
						,new CellInfoHeader("Số km",3,1)
						,new CellInfoHeader("Kế hoạch(dự toán) được chi cả năm",1,4)
						,new CellInfoHeader("Kinh phí đã nhận",1,5)
						,new CellInfoHeader("Kinh phí đã thanh toán, giải ngân",1,5)
						,new CellInfoHeader("Số kinh phí chưa giải ngân",3,1)
						,new CellInfoHeader("Kinh phí còn được nhận",2,2)
						,new CellInfoHeader("Giá trị thực hiện đã nghiệm thu A-B",3,1)
						,new CellInfoHeader("Số chưa GN cho nhà thầu theo nghiệm thu A-B",3,1)
				});
				//Tao dong 2
				WebformFunctions.addHeaderRow_to_grid_view(
					v_grv
					, 1
					, v_c_str_header_css_class
					, new CellInfoHeader[] 
					{ 
						new CellInfoHeader("Từ quỹ bảo trì",2,1)
						,new CellInfoHeader("Từ Ngân sách",2,1)
						,new CellInfoHeader("Số dư năm trước chuyển sang",2,1)
						,new CellInfoHeader("Tổng số",2,1)
						,new CellInfoHeader("Từ quỹ bảo trì",1,2)
						,new CellInfoHeader("Từ Ngân sách",1,2)
						,new CellInfoHeader("Tổng số",2,1)
						,new CellInfoHeader("Từ quỹ bảo trì",1,2)
						,new CellInfoHeader("Từ Ngân sách",1,2)
						,new CellInfoHeader("Tổng số",2,1)
					});
				//Tao dong 3
				WebformFunctions.addHeaderRow_to_grid_view(
					v_grv
					, 2
					, v_c_str_header_css_class
					, new CellInfoHeader[] 
					{ 
						new CellInfoHeader("Trong tháng",1,1)
						,new CellInfoHeader("Luỹ kế từ đấu năm",1,1)
						,new CellInfoHeader("Trong tháng",1,1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,1)
						,new CellInfoHeader("Trong tháng",1,1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,1)
						,new CellInfoHeader("Trong tháng",1,1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,1)
						,new CellInfoHeader("Từ quỹ bảo trì",1,1)
						,new CellInfoHeader("Từ Ngân sách",1,1)
					});
			}

		}
	}

		#endregion
}
