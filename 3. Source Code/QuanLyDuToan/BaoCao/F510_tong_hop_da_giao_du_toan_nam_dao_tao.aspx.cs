﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.BaoCao
{
    public partial class F510_tong_hop_da_giao_du_toan_nam_dao_tao : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region dữ liệu demo, khi nào code thì xóa đi
            //-------------------------------------------------------
            m_lbl_nam.Text = "2014";

            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("A", typeof(string));
                dt.Columns.Add("B", typeof(string));
                dt.Columns.Add("C", typeof(string));
                dt.Columns.Add("D", typeof(string));
                dt.Columns.Add("E", typeof(string));
                dt.Columns.Add("F", typeof(string));
                dt.Columns.Add("G", typeof(string));
                dt.Columns.Add("H", typeof(string));
                dt.Columns.Add("I", typeof(string));
                dt.Columns.Add("J", typeof(string));
                dt.Columns.Add("K", typeof(string));
                dt.Columns.Add("L", typeof(string));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = "1";
            NewRow[1] = "Chi sửa quốc lộ 31";
            NewRow[2] = "2,000,000";
            NewRow[3] = "2,000,000";
            NewRow[4] = "1,000,000";
            NewRow[5] = "1,000,000";
            NewRow[6] = "0";
            NewRow[7] = "3,000,000";
            NewRow[8] = "1,000,000";
            NewRow[9] = "2,000,000";
            NewRow[10] = "2,000,000";
            NewRow[11] = "2,000,000";
            dt.Rows.Add(NewRow);
            m_grv_bao_cao_giao_von.DataSource = dt;
            m_grv_bao_cao_giao_von.DataBind();
            //-------------------------------------------------------
            #endregion
        }

        #region Merge header
        //vẽ header cho gridview
        protected void m_grv_bao_cao_giao_von_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header) // If header created
            {
                GridView ProductGrid = (GridView)sender;
                // Creating a Row
                GridViewRow HeaderRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);

                //Adding  STT
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "STT";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2; // For merging first, second row cells to one
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding  Nội dung
                HeaderCell = new TableCell();
                HeaderCell.Text = "Nội dung";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding  Tổng số đã giao
                HeaderCell = new TableCell();
                HeaderCell.Text = "Tổng số đã giao";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.RowSpan = 2;
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding Cộng
                HeaderCell = new TableCell();
                HeaderCell.Text = "Cộng";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 4; // For merging three columns (tso, txuyen, ktxuyen,ctmtqg)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding QĐ
                HeaderCell = new TableCell();
                HeaderCell.Text = "QĐ 371/BGTVT ngày 07/02/2014";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 3; // For merging three columns (tso, chitx, chiktx)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding QĐ
                HeaderCell = new TableCell();
                HeaderCell.Text = "QĐ hỗ trợ học phí theo NĐ 42 hỗ trợ cho học sinh";
                HeaderCell.HorizontalAlign = HorizontalAlign.Center;
                HeaderCell.ColumnSpan = 2; // For merging three columns (tso, chitx)
                HeaderCell.CssClass = "HeaderStyle";
                HeaderRow.Cells.Add(HeaderCell);

                //Adding the Row at the 0th position (first row) in the Grid
                ProductGrid.Controls[0].Controls.AddAt(0, HeaderRow);
            }
        }

        protected void m_grv_bao_cao_giao_von_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
                e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
                e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
            }
        }
        #endregion
    }
}