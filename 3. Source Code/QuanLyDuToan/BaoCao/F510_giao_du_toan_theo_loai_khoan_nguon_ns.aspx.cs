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
	public partial class F510_giao_du_toan_theo_loai_khoan_nguon_ns : System.Web.UI.Page {

        #region Public Function
        public string ConvertToUnsign3(string str) {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = str.Normalize(System.Text.NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty)
                        .Replace('\u0111', 'd').Replace('\u0110', 'D');
            //return str;
        }
        public override void VerifyRenderingInServerForm(Control control) {
            //base.VerifyRenderingInServerForm(control);
        }
        #endregion

        #region Data Structure
        #endregion

        #region Data Member
        List<string> m_lst_str_header = new List<string>();
        #endregion

        #region Private Method
        private void load_data_to_grid() {
            xoaCotDong();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.FillDatasetByProc(
                v_ds,
                "pr_F510_giao_du_toan_theo_loai_khoan_nguon_ns",
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                m_txt_tu_khoa_tim_kiem.Text);
            addNewColumnToGridView(v_ds);
            v_dt = v_ds.Tables[0];
            v_dt.Columns.Add("TONG_SO");
            v_dt.Columns.Add("THUONG_XUYEN");
            v_dt.Columns.Add("KHONG_THUONG_XUYEN");
            v_dt.Columns.Add("CMMTQG");
            groupData(v_ds);
            updateCell(v_dt);
            m_grv_bao_cao_giao_von.DataSource = v_dt;
            m_grv_bao_cao_giao_von.DataBind();
        }
        private void groupData(DataSet v_ds) {
            List<int> v_lst = new List<int>();
            for (int i = 0; i < v_ds.Tables[0].Rows.Count - 1; i++) {
                var index = i + 1;
                while (v_ds.Tables[0].Rows[i][3].ToString().Trim() == v_ds.Tables[0].Rows[index][3].ToString().Trim() && v_ds.Tables[0].Rows[i][3].ToString().Trim() != "") {
                    for (int j = 6; j < v_ds.Tables[0].Columns.Count; j++) {
                        var value1 = (v_ds.Tables[0].Rows[i][j].ToString() == "" ? 0 : CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][j].ToString()));
                        var value2 = (v_ds.Tables[0].Rows[index][j].ToString() == "" ? 0 : CIPConvert.ToDecimal(v_ds.Tables[0].Rows[index][j].ToString()));
                        v_ds.Tables[0].Rows[i][j] = value1 + value2;
                    }
                    v_lst.Add(index);
                    index += 1;
                }
                i = index - 1;
            }
            for (int i = v_lst.Count - 1; i >= 0; i--) {
                v_ds.Tables[0].Rows.RemoveAt(v_lst[i]);
            }
        }
        private void xoaCotDong() {
            var v_count_column = m_grv_bao_cao_giao_von.Columns.Count;
            for (int i = v_count_column - 1; i >= 5; i--) {
                m_grv_bao_cao_giao_von.Columns.RemoveAt(i);
            }
            m_lst_str_header.Clear();
        }
        private void updateCell(DataTable ip_dt) {
            decimal ts = 0;
            decimal ktx = 0;
            decimal tx = 0;
            for (int i = 0; i < ip_dt.Rows.Count; i++) {
                for (int j = 6; j < ip_dt.Columns.Count; j++) {
                    string v_str = ip_dt.Rows[i][j].ToString();
                    if (v_str == "" || v_str == null) {
                        continue;
                    }
                    if (ip_dt.Columns[j].ColumnName.Contains("KTC")) {
                        ktx += CIPConvert.ToDecimal(v_str);
                    }
                    else if (ip_dt.Columns[j].ColumnName.Contains("TC")) {
                        tx += CIPConvert.ToDecimal(v_str);
                    }
                    else {
                        ts += CIPConvert.ToDecimal(v_str);
                    }
                }
                ip_dt.Rows[i]["KHONG_THUONG_XUYEN"] = formatString(ktx.ToString());
                ip_dt.Rows[i]["THUONG_XUYEN"] = formatString(tx.ToString());
                ip_dt.Rows[i]["TONG_SO"] = formatString(ts.ToString());
                ktx = 0;
                tx = 0;
                ts = 0;
            }
        }
        private void addNewColumnToGridView(DataSet ip_ds) {
            var v_index = 0;
            DataTable v_dt = ip_ds.Tables[0];
            if (v_dt.Columns.Count == 6) {
                m_grv_bao_cao_giao_von.Visible = false;
				m_lbl_mess.Text = "Không tìm thấy dữ liệu phù hợp!!!";
                m_lbl_mess.Visible = true;
            }
            for (int i = 6; i < v_dt.Columns.Count; i++) {
                m_lbl_mess.Visible = false;
                m_grv_bao_cao_giao_von.Visible = true;
                BoundField bfield = new BoundField();
                bfield.HeaderText = get_header_text(v_dt.Columns[i].ColumnName, v_index);
                bfield.DataField = v_dt.Columns[i].ColumnName;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                bfield.DataFormatString = "{0:N0}";
                m_grv_bao_cao_giao_von.Columns.Add(bfield);
                v_index += 1;
            }
        }
        private string formatString(string str) {
            var index = 0;
            var str2 = "";
            for (int i = str.Length - 1; i >= 0; i--) {
                str2 = str[i] + str2;
                index += 1;
                if (index % 3 == 0 && index != str.Length) {
                    str2 = "," + str2;
                }
            }
            return str2;
        }
        private string get_header_text(string p, int ip_index) {
            string v_res = "";
            var v_arr = p.Split('_');
            if (v_arr[0].Contains("KTC")) {
                v_res += "Không T.Chủ";
            }
            else if (v_arr[0].Contains("TC")) {
                v_res += "T.Chủ";
            }
            else {
                v_res += "Tổng";
            }
            if (ip_index % 3 == 0) {
                US_DM_QUYET_DINH v_us_quyet_dinh = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(v_arr[1]));
                m_lst_str_header.Add(v_us_quyet_dinh.strSO_QUYET_DINH);
            }
            return v_res;
        }
        private void set_default_input() {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                set_default_input();
                load_data_to_grid();
            }
        }
        protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
            US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
            WebformReport.export_gridview_2_excel(
            m_grv_bao_cao_giao_von
            , "BaoCaoTongHopDaGiaoDuToan-DaoTao.xls"
            );
        }
        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e) {
            load_data_to_grid();
        }
        #endregion
        
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
	
        #region Merge header
        //vẽ header cho gridview
        protected void m_grv_bao_cao_giao_von_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {
                GridView ProductGrid = (GridView)sender;
                // Creating a Row
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding  Nội dung
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Nội dung";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.CssClass = "pinned merge1";
                HeaderRow.Cells.Add(HeaderCell);

                ////Adding  Tổng số đã giao
                //HeaderCell = new TableCell();
                //HeaderCell.Text = "Tổng số đã giao";
                //HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                //HeaderCell.RowSpan = 2;
                //HeaderCell.CssClass = "HeaderStyle";
                //HeaderRow.Cells.Add(HeaderCell);

                //Adding Cộng
                HeaderCell = new TableCell();
                HeaderCell.Text = "Cộng";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell.CssClass = "pinned2 merge4";
                HeaderRow.Cells.Add(HeaderCell);


                foreach (var item in m_lst_str_header)
                {
                    HeaderCell = new TableCell();
                    HeaderCell.Text = item;
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.ColumnSpan = 3; // For merging three columns (tso, chitx, chiktx)
                    HeaderCell.CssClass = "merge3";
                    HeaderRow.Cells.Add(HeaderCell);
                }
                //Adding QĐ
                

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }

        protected void m_grv_bao_cao_giao_von_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
            }
        }
        #endregion  
    }
}