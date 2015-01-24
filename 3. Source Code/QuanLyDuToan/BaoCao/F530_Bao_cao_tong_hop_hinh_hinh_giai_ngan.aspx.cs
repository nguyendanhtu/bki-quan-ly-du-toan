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
		#region Public Methods
		public string get_query_string(string ip_str_id_don_vi)
		{
			string v_str_query_string = "";
			v_str_query_string = "F350_tinh_hinh_giai_ngan.aspx?ip_dc_id_don_vi=" + ip_str_id_don_vi + "&ip_dat_tu_ngay=" + m_txt_tu_ngay.Text + "&ip_dat_den_ngay=" + m_txt_den_ngay.Text;
			return v_str_query_string;
		}
		#endregion
		#region Data Member
		decimal m_dc_id_loai_don_vi = 0;
        DateTime m_dat_tu_ngay;
        DateTime m_dat_den_ngay;
        #endregion

        #region Private Method

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
       

        private void load_data_to_grid()
        {
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
			//DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);
            v_ds.EnforceConstraints = false;
            v_us.bc_tinh_hinh_giai_ngan_tong_cuc(v_ds
                , CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
                , CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
                , WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy"))
                , 1//Person.get_user_id()
                );
            m_grv.DataSource = v_dt;
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
        private void export_excel()
        {
			WinformReport.export_gridview_2_excel(
			 m_grv
			 , "BaoCaoTinhHinhGiaiNganCacDonVi.xls"
			 );
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime v_dat_now = DateTime.Now;
                DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
                v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                if (Request.QueryString["don_vi"] != null)
                {
                    m_dc_id_loai_don_vi = CIPConvert.ToDecimal(Request.QueryString["loai_don_vi"]);                    
                }
                if (Request.QueryString["tu_ngay"] != null)
                    m_dat_tu_ngay = CIPConvert.ToDatetime(Request.QueryString["tu_ngay"]);
                if (Request.QueryString["den_ngay"] != null)
                    m_dat_den_ngay = CIPConvert.ToDatetime(Request.QueryString["den_ngay"]);
                //load_data_to_cbo_loai_don_vi();
                load_data_to_grid();
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
                if (check_validate_data_is_ok())
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
        #endregion

        #region Merge header
        //vẽ header cho gridview
        protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {
                GridView ProductGrid = (GridView)sender;
                // Creating a Row
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding  STT
               TableHeaderCell HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "STT";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3; // For merging first, second row cells to one
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding  Nội dung
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Nội dung";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding  Kế hoạch(dự toán) được chi cả năm
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Kế hoạch(dự toán) được chi cả năm";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding Kinh phí đã nhân
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Kinh phí đã nhân";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 5; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding Kinh phí đã chi
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Kinh phí đã thanh toán, giải ngân";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 5; // For merging three columns (tso, chitx, chiktx)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding 
                HeaderCell = new TableHeaderCell();
				HeaderCell.Text = "Số kinh phí chưa giải ngân";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3; // For merging three columns (tso, chitx)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding 
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Kinh phí còn được nhận";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2; // For merging three columns (tso, chitx)
                HeaderCell.RowSpan = 2;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding 
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Giá trị thực hiện đã nghiệm thu A-B";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);
                
                //Adding 
                HeaderCell = new TableHeaderCell();
                HeaderCell.Text = "Số chưa GN cho nhà thầu theo nghiệm thu A-B";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 3;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);

                // Creating a Row thứ 2
                GridViewRow HeaderRow2 = new GridViewRow(1, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding  cell
                TableHeaderCell HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ quỹ bảo trì";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2; // For merging first, second row cells to one
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ Ngân sách";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2;
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);
                //Adding  cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Số dư năm trước chuyển sang";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2;
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);
                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Tổng số";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2;
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ quỹ bảo trì";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.ColumnSpan = 2;
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ Ngân sách";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.ColumnSpan = 2; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Tổng số";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2; // For merging three columns (tso, chitx, chiktx)
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ quỹ bảo trì";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.ColumnSpan = 2;
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Từ Ngân sách";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.ColumnSpan = 2; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding cell
                HeaderCell1 = new TableHeaderCell();
                HeaderCell1.Text = "Tổng số";
                HeaderCell1.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell1.RowSpan = 2; // For merging three columns (tso, chitx, chiktx)
                HeaderCell1.CssClass = "HeaderStyle";
                HeaderRow2.Cells.Add(HeaderCell1);

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(1, HeaderRow2);

                // Creating a Row thứ 3
                GridViewRow HeaderRow3 = new GridViewRow(2, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding  cell
                TableHeaderCell HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Trong tháng";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1; // For merging first, second row cells to one
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Luỹ kế từ đấu năm";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);
                //Adding  cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Trong tháng";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);
                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Luỹ kế từ đầu năm";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding  cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Trong tháng";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);
                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Luỹ kế từ đầu năm";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding  cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Trong tháng";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);
                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Luỹ kế từ đầu năm";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.RowSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Từ quỹ bảo trì";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.ColumnSpan = 1;
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding cell
                HeaderCell3 = new TableHeaderCell();
                HeaderCell3.Text = "Từ Ngân sách";
                HeaderCell3.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell3.ColumnSpan = 1; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell3.CssClass = "HeaderStyle";
                HeaderRow3.Cells.Add(HeaderCell3);

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(2, HeaderRow3);
            }
        }
        #endregion
    }
}