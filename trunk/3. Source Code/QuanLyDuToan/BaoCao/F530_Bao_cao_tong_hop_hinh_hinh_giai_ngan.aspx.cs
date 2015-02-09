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
using IP.Core.IPExcelReport;
using QuanLyDuToan.App_Code;
using System.Data;


namespace QuanLyDuToan.BaoCao
{
	public partial class F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan : System.Web.UI.Page
	{
		#region Public Functions
		public string get_query_string(string ip_str_id_don_vi)
		{
			return
				FormInfo.FormName.F530
				+ "?" + FormInfo.QueryString.ID_DON_VI + "= "
				+ ip_str_id_don_vi
				+ "&" + FormInfo.QueryString.TU_NGAY + "="
				+ m_txt_tu_ngay.Text
				+ "&" + FormInfo.QueryString.DEN_NGAY + "="
				+ m_txt_den_ngay.Text;
		}
		#endregion

		#region Member
		public class CellInfoHeader
		{
			public int RowSpan;
			public int ColumnSpan;
			public string Text;

			public CellInfoHeader(string Text, int RowSpan, int ColumnSpan)
			{
				this.Text = Text;
				this.RowSpan = RowSpan;
				this.ColumnSpan = ColumnSpan;
			}
		}

		#endregion

		#region Private Method

		private void load_data_to_grid()
		{
			US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);
			v_ds.EnforceConstraints = false;
			v_us.bc_tinh_hinh_giai_ngan_tong_cuc(v_ds
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy"))
				, Person.get_user_id()
				);
			m_grv.DataSource = v_dt;
			m_grv.DataBind();

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
			WinformReport.export_gridview_2_excel(
			 m_grv
			 , FormInfo.ExportExcelReportName.F530
			 );
		}
		private void set_inital_form_load()
		{
			//Đặt giá trị mặc định cho control khi chưa được chọn
			m_txt_tu_ngay.Text = CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy");
			m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			load_data_to_grid();
		}
		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
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

		private TableHeaderCell getHeaderCell(
			string ip_str_text
			, HorizontalAlign ip_horizontal_align
			, int ip_i_row_span
			, int ip_i_col_span
			, string ip_str_css_class)
		{
			TableHeaderCell v_hc = new TableHeaderCell();
			v_hc.Text = "Nội dung";
			v_hc.HorizontalAlign = HorizontalAlign.Center;
			if (ip_i_row_span != -1) v_hc.RowSpan = 3;
			if (ip_i_col_span != -1) v_hc.ColumnSpan = 3;
			v_hc.CssClass = ip_str_css_class;
			return v_hc;
		}
		private void addSecondRow_to_grid_view(
			GridView op_grv
			, int ip_i_row_number
			, string ip_str_const_css_class
			, CellInfoHeader[] ip_arr_cell_header)
		{
			GridViewRow v_gvr = new GridViewRow(ip_i_row_number, 0, DataControlRowType.Header, DataControlRowState.Insert);
			for (int i = 0; i < ip_arr_cell_header.Length; i++)
			{
				TableHeaderCell v_hc = new TableHeaderCell();
				v_hc.Text = ip_arr_cell_header[i].Text;
				v_hc.HorizontalAlign = HorizontalAlign.Center;
				if (ip_arr_cell_header[i].RowSpan != -1) v_hc.RowSpan = ip_arr_cell_header[i].RowSpan;
				if (ip_arr_cell_header[i].ColumnSpan != -1) v_hc.RowSpan = ip_arr_cell_header[i].ColumnSpan;
				v_hc.CssClass = ip_str_const_css_class;
				v_gvr.Cells.Add(v_hc);
			}
			op_grv.Controls[0].Controls.AddAt(ip_i_row_number, v_gvr);

		}

		protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e)
		{
			const string v_c_str_header_css_class = "HeaderStyle";
			if (e.Row.RowType == DataControlRowType.Header) // If header created
			{
				GridView v_grv = (GridView)sender;
				// Creating a Row
				
				addSecondRow_to_grid_view(v_grv
					, 0
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("STT",3,-1)
						,new CellInfoHeader("Nội dung",3,-1)
						,new CellInfoHeader("Số km",3,-1)
						,new CellInfoHeader("Kế hoạch(dự toán) được chi cả năm",-1,4)
						,new CellInfoHeader("Kinh phí đã nhận",-1,5)
						,new CellInfoHeader("Kinh phí đã thanh toán, giải ngân",-1,5)
						,new CellInfoHeader("Số kinh phí chưa giải ngân",3,-1)
						,new CellInfoHeader("Kinh phí còn được nhận",2,2)
						,new CellInfoHeader("Giá trị thực hiện đã nghiệm thu A-",3,-1)
						,new CellInfoHeader("Số chưa GN cho nhà thầu theo nghiệm thu A-B",3,-1)
				});

				addSecondRow_to_grid_view(
					v_grv
					, 1
					, v_c_str_header_css_class
					, new CellInfoHeader[] 
					{ 
						new CellInfoHeader("Từ quỹ bảo trì",2,-1)
						,new CellInfoHeader("Từ Ngân sách",2,-1)
						,new CellInfoHeader("Số dư năm trước chuyển sang",2,-1)
						,new CellInfoHeader("Tổng số",2,-1)
						,new CellInfoHeader("Từ quỹ bảo trì",-1,2)
						,new CellInfoHeader("Từ Ngân sách",-1,2)
						,new CellInfoHeader("Tổng số",2,-1)
						,new CellInfoHeader("Từ quỹ bảo trì",-1,2)
						,new CellInfoHeader("Từ Ngân sách",-1,2)
						,new CellInfoHeader("Tổng số",2,-1)
					});

				// Creating a Row thứ 3
				addSecondRow_to_grid_view(
					v_grv
					, 2
					, v_c_str_header_css_class
					, new CellInfoHeader[] 
					{ 
						new CellInfoHeader("Trong tháng",1,-1)
						,new CellInfoHeader("Luỹ kế từ đấu năm",1,-1)
						,new CellInfoHeader("Trong tháng",1,-1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,-1)
						,new CellInfoHeader("Trong tháng",1,-1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,-1)
						,new CellInfoHeader("Trong tháng",1,-1)
						,new CellInfoHeader("Luỹ kế từ đầu năm",1,-1)
						,new CellInfoHeader("Từ quỹ bảo trì",-1,1)
						,new CellInfoHeader("Từ Ngân sách",-1,1)
					});
				

				//Adding  cell
				//TableHeaderCell HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Trong tháng";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1; // For merging first, second row cells to one
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				////Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Luỹ kế từ đấu năm";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);
				//Adding  cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Trong tháng";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);
				////Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Luỹ kế từ đầu năm";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				//////Adding  cell
				////HeaderCell3 = new TableHeaderCell();
				////HeaderCell3.Text = "Trong tháng";
				////HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				////HeaderCell3.RowSpan = 1;
				////HeaderCell3.CssClass = "HeaderStyle";
				////HeaderRow3.Cells.Add(HeaderCell3);
				//////Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Luỹ kế từ đầu năm";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				//Adding  cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Trong tháng";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);
				////Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Luỹ kế từ đầu năm";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.RowSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				//Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Từ quỹ bảo trì";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.ColumnSpan = 1;
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				////Adding cell
				//HeaderCell3 = new TableHeaderCell();
				//HeaderCell3.Text = "Từ Ngân sách";
				//HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
				//HeaderCell3.ColumnSpan = 1; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
				//HeaderCell3.CssClass = "HeaderStyle";
				//HeaderRow3.Cells.Add(HeaderCell3);

				////Adding the Row at the 0th position (first row) in the Grid
				//v_grv.Controls[0].Controls.AddAt(2, HeaderRow3);
			}
		}
		#endregion
	}
}