using QuanLyDuToan.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;
namespace QuanLyDuToan.BaoCao
{
    public partial class F510_tong_hop_da_giao_du_toan_nam_dao_tao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //#region dữ liệu demo, khi nào code thì xóa đi
            ////-------------------------------------------------------
            //m_lbl_nam.Text = "2014";

            //DataTable dt = new DataTable();
            //DataColumn dc = new DataColumn();

            //if (dt.Columns.Count == 0)
            //{
            //    dt.Columns.Add("A", typeof(string));
            //    dt.Columns.Add("B", typeof(string));
            //    dt.Columns.Add("C", typeof(decimal));
            //    dt.Columns.Add("D", typeof(decimal));
            //    dt.Columns.Add("E", typeof(decimal));
            //    dt.Columns.Add("F", typeof(decimal));
            //    dt.Columns.Add("G", typeof(decimal));
            //    dt.Columns.Add("H", typeof(decimal));
            //    dt.Columns.Add("I", typeof(decimal));
            //    dt.Columns.Add("J", typeof(decimal));
            //    dt.Columns.Add("K", typeof(decimal));
            //    dt.Columns.Add("L", typeof(decimal));
            //}

            //DataRow NewRow = dt.NewRow();
            //NewRow[0] = "1";
            //NewRow[1] = "Chi sửa quốc lộ 31";
            //NewRow[2] = 2000000;
            //NewRow[3] = 2000000;
            //NewRow[4] = 1000000;
            //NewRow[5] = 1000000;
            //NewRow[6] = 0;
            //NewRow[7] = 3000000;
            //NewRow[8] = 1000000;
            //NewRow[9] = 2000000;
            //NewRow[10] = 2000000;
            //NewRow[11] = 2000000;
            //dt.Rows.Add(NewRow);
            //m_grv_bao_cao_giao_von.DataSource = dt;
            //m_grv_bao_cao_giao_von.DataBind();
            ////-------------------------------------------------------
            //#endregion
            set_default_input();
            load_data_2_grid();
        }

        private void load_data_2_grid()
        {
            DS_RPT_510_TONG_HOP_DA_GIAO v_ds = new DS_RPT_510_TONG_HOP_DA_GIAO();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.FillDatasetByProc(v_ds);
            addNewColumnToGridView(v_ds);
            v_dt = v_ds.Tables[0];
            v_dt.Columns.Add("TONG_SO");
            v_dt.Columns.Add("THUONG_XUYEN");
            v_dt.Columns.Add("KHONG_THUONG_XUYEN");
            v_dt.Columns.Add("CMMTQG");
            updateCell(v_dt);
            m_grv_bao_cao_giao_von.DataSource = v_dt;
            m_grv_bao_cao_giao_von.DataBind();
        }

        private void updateCell(DataTable ip_dt)
        {
            decimal ts = 0;
            decimal ktx = 0;
            decimal tx = 0;
            for (int i = 0; i < ip_dt.Rows.Count; i++)
            {
                for (int j = 6; j < ip_dt.Columns.Count; j++)
                {
                    string v_str = ip_dt.Rows[i][j].ToString();
                    if (v_str == "" || v_str == null)
                    {
                        continue;
                    }
                    if (ip_dt.Columns[j].ColumnName.Contains("KTC"))
                    {
                        ktx += CIPConvert.ToDecimal(v_str);
                    }
                    else if (ip_dt.Columns[j].ColumnName.Contains("TC"))
                    {
                        tx += CIPConvert.ToDecimal(v_str);
                    }
                    else
                    {
                        ts += CIPConvert.ToDecimal(v_str);
                    }
                }
                ip_dt.Rows[i]["KHONG_THUONG_XUYEN"] = ktx;
                ip_dt.Rows[i]["THUONG_XUYEN"] = tx;
                ip_dt.Rows[i]["TONG_SO"] = ts;
                ktx = 0;
                tx = 0;
                ts = 0;
            }
        }

        private void addNewColumnToGridView(DS_RPT_510_TONG_HOP_DA_GIAO ip_ds)
        {
            DataTable v_dt = ip_ds.Tables[0];
            for (int i = 6; i < v_dt.Columns.Count; i++)
            {
                BoundField bfield = new BoundField();
                bfield.HeaderText = get_header_text(v_dt.Columns[i].ColumnName);
                bfield.DataField = v_dt.Columns[i].ColumnName;
                bfield.DataFormatString = "{0:N0}";
                m_grv_bao_cao_giao_von.Columns.Add(bfield);
            }
        }

        private string get_header_text(string p)
        {
            string v_res = "";
            var v_arr = p.Split('_');
            if (v_arr[0].Contains("KTC"))
            {
                v_res += "Không T.Chủ";
            }
            else if (v_arr[0].Contains("TC"))
            {
                v_res += "T.Chủ";
            }
            else
            {
                v_res += "Tổng";
            }
            return v_res;
        }
        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }
		public string ConvertToUnsign3(string str)
		{
			System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
			string temp = str.Normalize(System.Text.NormalizationForm.FormD);
			return regex.Replace(temp, String.Empty)
						.Replace('\u0111', 'd').Replace('\u0110', 'D');
			//return str;
		}
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
			WinformReport.export_gridview_2_excel(
			m_grv_bao_cao_giao_von
			, "BaoCaoTongHopDaGiaoDuToan-DaoTao.xls"
			);
		}
		/* Để xuất excel
		 * 1. Dùng 
		 * WinformReport.export_gridview_2_excel(
			m_grv
			, "TenBaoCao.xls"
			);
		 * 2. Thêm 
		 * <Triggers>
			 <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
        </Triggers>
		 * Trong aspx
		 * 3. Thêm hàm VerifyRenderingInServerForm
		*/
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
        //#region Merge header
        ////vẽ header cho gridview
        //protected void m_grv_bao_cao_giao_von_RowCreated(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header) // If header created
        //    {
        //        GridView ProductGrid = (GridView)sender;
        //        // Creating a Row
        //        GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

        //        //Adding  STT
        //        TableCell HeaderCell = new TableCell();
        //        HeaderCell.Text = "STT";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.RowSpan = 2; // For merging first, second row cells to one
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding  Nội dung
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Nội dung";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding  Tổng số đã giao
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Tổng số đã giao";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.RowSpan = 2;
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding Cộng
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "Cộng";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 4; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding QĐ
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "QĐ 371/BGTVT ngày 07/02/2014";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 3; // For merging three columns (tso, chitx, chiktx)
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding QĐ
        //        HeaderCell = new TableCell();
        //        HeaderCell.Text = "QĐ hỗ trợ học phí theo NĐ 42 hỗ trợ cho học sinh";
        //        HeaderCell.HorizontalAlign = HorizontalAlign.Center;
        //        HeaderCell.ColumnSpan = 2; // For merging three columns (tso, chitx)
        //        HeaderCell.CssClass = "HeaderStyle";
        //        HeaderRow.Cells.Add(HeaderCell);

        //        //Adding the Row at the 0th position (first row) in the Grid
        //        ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
        //    }
        //}

        //protected void m_grv_bao_cao_giao_von_RowDataBound(object sender, GridViewRowEventArgs e)
        //{
        //    if (e.Row.RowType == DataControlRowType.Header)
        //    {
        //        e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
        //        e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
        //        e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
        //    }
        //}
        //#endregion
    }
}