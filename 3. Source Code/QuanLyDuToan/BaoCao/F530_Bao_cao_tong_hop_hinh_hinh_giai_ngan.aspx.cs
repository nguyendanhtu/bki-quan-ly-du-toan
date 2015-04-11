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
using IP.Core.IPUserService;
using IP.Core.IPData;
using QuanLyDuToan.App_Code;
using System.Data;
//using System.Collections;
//using System.Linq;


namespace QuanLyDuToan.BaoCao
{
	public partial class F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan : System.Web.UI.Page
	{
		#region Public Functions
		public string gen_query_string(string ip_str_id_don_vi)
		{
			return
				FormInfo.FormName.F350
				+ "?" + FormInfo.QueryString.ID_DON_VI + "= "
				+ ip_str_id_don_vi
				+ "&" + FormInfo.QueryString.TU_NGAY + "="
				+ m_txt_tu_ngay.Text
				+ "&" + FormInfo.QueryString.DEN_NGAY + "="
				+ m_txt_den_ngay.Text;
		}
		public string getSTT(string ip_str_noi_dung)
		{
			if (ip_str_noi_dung.Contains("Tổng cộng")) return "";
			m_i_stt++;
			return m_i_stt.ToString();
		}
		#endregion

		#region Member
		private int m_i_stt = 0;
		public DataSet m_ds = new DataSet();

		#endregion

		#region Private Method
		private void setPropertiesSumForRow(DataRow op_dr, string ip_str_propertieName, List<DataRow> ip_lstSum)
		{
			op_dr[ip_str_propertieName] = ip_lstSum.Select(x => x.Field<decimal?>(ip_str_propertieName) ?? 0).ToList().Sum();
		}
		private void addRowSum(DataTable op_dt, string ip_str_fillter_condition, string ip_str_content)
		{
			DataRow v_dr = op_dt.NewRow();
			var lstRowsHaveCondition = op_dt.AsEnumerable()
				.Where(x => x.Field<string>(WebDS.CDBNames.RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG).ToUpper().Contains(ip_str_fillter_condition.ToUpper())
					|| (x.Field<string>(WebDS.CDBNames.RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG) + ".").ToUpper().Contains(ip_str_fillter_condition.ToUpper())
					|| (x.Field<string>(WebDS.CDBNames.RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG) + " - Văn phòng").ToUpper().Contains(ip_str_fillter_condition.Replace(".", " - Văn phòng").ToUpper()))
				.ToList();
			foreach (var item in lstRowsHaveCondition)
			{
				item[RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG] = "-- " + item[RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG].ToString().Replace("-- ", "");
				item["HIEN_THI"] = ip_str_content + "-";
			}
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_CHA] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU] = -1;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.ID_REPORTED_USER] = -1;
			v_dr["HIEN_THI"] = ip_str_content;
			v_dr[RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG] = ip_str_content;
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.CN_NS, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.CN_QBT, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.SO_CHUA_GN, lstRowsHaveCondition);
			setPropertiesSumForRow(v_dr, RPT_BC_TINH_HINH_GIAI_NGAN.TONG_SO_KM, lstRowsHaveCondition);
			op_dt.Rows.Add(v_dr);
		}
		private void load_data_to_grid()
		{
			US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
			m_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_dt.Columns.Add("HIEN_THI");
			m_ds.Tables.Add(v_dt);
			m_ds.EnforceConstraints = false;
			v_us.bc_tinh_hinh_giai_ngan_tong_cuc(m_ds
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy"))
				, Person.get_user_id()
				);
			for (int i = 0; i < v_dt.Rows.Count; i++)
			{
				v_dt.Rows[i]["HIEN_THI"] = v_dt.Rows[i]["NOI_DUNG"];
			}
			addRowSum(v_dt, "cục quản lý đường bộ I.", "Cục I");
			addRowSum(v_dt, "cục quản lý đường bộ II.", "Cục II");
			addRowSum(v_dt, "cục quản lý đường bộ III.", "Cục III");
			addRowSum(v_dt, "cục quản lý đường bộ IV.", "Cục IV");
			v_dt = v_dt.AsEnumerable()
								   .OrderBy(x => x.Field<string>("HIEN_THI"))
				//.ThenBy(x => x.Field<string>(RPT_BC_TINH_HINH_GIAI_NGAN.NOI_DUNG))
								   .CopyToDataTable();
			m_grv.DataSource = v_dt;
			m_grv.DataBind();

			//List<DBClassModel.HT_NGUOI_SU_DUNG> v_lst_nsd = v_ds.Tables[0].ToList<DBClassModel.HT_NGUOI_SU_DUNG>().OrderBy(x => x.TEN_TRUY_CAP).ThenBy(x => x.TEN_TRUY_CAP).ToList();
		}
		private bool check_validate_input_data_is_ok()
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
		private void export_excel()
		{
			WebformReport.export_gridview_2_excel(
			 m_grv
			 , FormInfo.ExportExcelReportName.F530
			 );
		}
		private void set_inital_form_load()
		{
			//Đặt giá trị mặc định cho control khi chưa được chọn
			m_txt_tu_ngay.Text = CIPConvert.ToStr(WebUS.CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy");
			m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			load_data_to_grid();
		}
		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
			m_lbl_mess.Text = "";
			if (!IsPostBack)
			{
				set_inital_form_load();
			}
		}

		protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
		{
			try
			{
				if (check_validate_input_data_is_ok())
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
				if (check_validate_input_data_is_ok())
				{
					export_excel();
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



		protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e)
		{
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
		#endregion
	}
}