using IP.Core.IPCommon;
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

namespace QuanLyDuToan.BaoCao
{
    public partial class F150_giao_von_du_toan_vp_tong_cuc : System.Web.UI.Page {

        #region Refactory by Huytd ngày 12/02/2015 7:30pm
        /*
         * còn chưa refactory format_link_to_chi_tiet() & format_link_to_chi_tiet_trong_thang
         */
        #endregion

        #region Public Function
        #endregion

        #region Data Member
        List<string> m_lst_str_header = new List<string>();
        #endregion

        #region Data Structure
        #endregion

        #region Private Method

        private void load_data_to_grid() {
            // xóa cột động
            xoaCotDong();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.FillDatasetByProc(
                 v_ds
                , "pr_F150_giao_du_toan_vp_tong_cuc"
                , CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
                , m_txt_tu_khoa_tim_kiem.Text
                , "Y");
            addNewColumnToGridView(v_ds);
            v_dt = v_ds.Tables[0];
            v_dt.Columns.Add("TONG_SO");
            v_dt.Columns.Add("TU_CHU");
            v_dt.Columns.Add("KHONG_TU_CHU");
            updateCell(v_dt);
            m_grv_bao_cao_giao_von.DataSource = v_dt;
            m_grv_bao_cao_giao_von.DataBind();
        }
        private void load_data_to_ddl_don_vi() {
            //get id don vi
            decimal v_dc_id_don_vi = WebformFunctions.getValue_from_query_string<Decimal>(
                                                                    this
                                                                    , FormInfo.QueryString.ID_DON_VI
                                                                    , Person.get_id_don_vi());
            //load cbo don vi
            WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(
                                                            v_dc_id_don_vi
                                                            , m_ddl_don_vi);
        }
       
        private void set_default_input() {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = WebformFunctions.getValue_from_query_string<String>(
                                                            this
                                                            , FormInfo.QueryString.TU_NGAY
                                                            , CIPConvert.ToStr(CCommonFunction.getDate_dau_nam_from_date(DateTime.Now), "dd/MM/yyyy"));
            m_txt_den_ngay.Text = WebformFunctions.getValue_from_query_string<String>(
                                                            this
                                                            , FormInfo.QueryString.DEN_NGAY
                                                            , CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy"));
        }

        private void addNewColumnToGridView(DataSet ip_ds) {
            var v_index = 0;
            DataTable v_dt = ip_ds.Tables[0];
            if (v_dt.Columns.Count == 4) {
                m_grv_bao_cao_giao_von.Visible = false;
                m_lbl_mess.Text = "Không tìm thấy dữ liệu phù hợp !!!";
                m_lbl_mess.Visible = true;
            }
            for (int i = 4; i < v_dt.Columns.Count; i++) {
                m_grv_bao_cao_giao_von.Visible = true;
                m_lbl_mess.Visible = false;
                BoundField bfield = new BoundField();
                bfield.HeaderText = get_header_text(v_dt.Columns[i].ColumnName, v_index);
                bfield.DataField = v_dt.Columns[i].ColumnName;
                bfield.ItemStyle.CssClass = "";
                bfield.HeaderStyle.CssClass = "";
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                bfield.DataFormatString = "{0:N0}";
                m_grv_bao_cao_giao_von.Columns.Add(bfield);
                v_index += 1;
            }
        }
        private string get_header_text(string p, int ip_index) {
            string v_res = "";
            var v_arr = p.Split('_');
            if (v_arr[1].Contains("ktc")) {
                v_res += "Không T.Chủ";
            }
            else if (v_arr[1].Contains("tc")) {
                v_res += "T.Chủ";
            }
            else {
                v_res += "Tổng";
            }
            if (ip_index % 3 == 0) {
                m_lst_str_header.Add(v_arr[0]);
            }
            return v_res;
        }
        private void updateCell(DataTable ip_dt) {
            decimal ts = 0;
            decimal ktx = 0;
            decimal tx = 0;
            for (int i = 0; i < ip_dt.Rows.Count; i++) {
                for (int j = 4; j < ip_dt.Columns.Count; j++) {
                    string v_str = ip_dt.Rows[i][j].ToString();
                    if (v_str == "" || v_str == null) {
                        continue;
                    }
                    if (ip_dt.Columns[j].ColumnName.Contains("ktc")) {
                        ktx += CIPConvert.ToDecimal(v_str);
                    }
                    else if (ip_dt.Columns[j].ColumnName.Contains("tc")) {
                        tx += CIPConvert.ToDecimal(v_str);
                    }
                    else {
                        ts += CIPConvert.ToDecimal(v_str);
                    }
                }
                ip_dt.Rows[i]["KHONG_TU_CHU"] = formatString(ktx.ToString());
                ip_dt.Rows[i]["TU_CHU"] = formatString(tx.ToString());
                ip_dt.Rows[i]["TONG_SO"] = formatString(ts.ToString());
                ktx = 0;
                tx = 0;
                ts = 0;
            }
        }
        private void xoaCotDong() {
            var v_count_column = m_grv_bao_cao_giao_von.Columns.Count;
            for (int i = v_count_column - 1; i >= 4; i--) {
                m_grv_bao_cao_giao_von.Columns.RemoveAt(i);
            }
            m_lst_str_header.Clear();
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
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e) {
            try {
                if (!IsPostBack) {
                    load_data_to_ddl_don_vi();
                    US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
                    set_default_input();
                    load_data_to_grid();
                }
            }
            catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(this, v_e);
            }
           
        }

        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e) {
            try {

                load_data_to_grid();
            }
            catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(this, v_e);
            }
            
        }
        protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
            try {

                WebformReport.export_gridview_2_excel(
                                    m_grv_bao_cao_giao_von
                                    , "BaoCaoTinhHinhGiaoKeHoachGiaoVonVPTongCuc.xls"
                );
            }
            catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }

        //vẽ header cho gridview
        protected void m_grv_bao_cao_giao_von_RowCreated(object sender, GridViewRowEventArgs e) {
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

                //Adding Cộng
                HeaderCell = new TableCell();
                HeaderCell.Text = "Cộng";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell.CssClass = "pinned2 merge3";
                HeaderRow.Cells.Add(HeaderCell);

                foreach (var item in m_lst_str_header) {
                    //Adding QĐ
                    HeaderCell = new TableCell();
                    HeaderCell.Text = item.ToString();
                    HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                    HeaderCell.ColumnSpan = 3; // For merging three columns (tso, chitx, chiktx)
                    HeaderCell.CssClass = "merge3";
                    HeaderRow.Cells.Add(HeaderCell);
                }

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }
        protected void m_grv_bao_cao_giao_von_RowDataBound(object sender, GridViewRowEventArgs e) {
            if (e.Row.RowType == DataControlRowType.Header) {
                e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
                //e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
                //e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
            }
        }
        public override void VerifyRenderingInServerForm(Control control) {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                load_data_to_grid();
            }
            catch (Exception v_e) {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
        #endregion   
    }
}