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
    public partial class F150_giao_von_du_toan_vp_tong_cuc : System.Web.UI.Page
    {
        List<string> m_lst_str_header = new List<string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
                m_lbl_ten_don_vi.Text = v_us.strTEN_DON_VI.ToUpper();
                set_default_input();
                if (Request.QueryString["ip_dat_tu_ngay"] != null)
                {
                    m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
                }
                if (Request.QueryString["ip_dat_den_ngay"] != null)
                {
                    m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
                }
                load_data_2_grid();   
            }
        }

        private void load_data_2_grid()
        {
            xoaCotDong();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            v_us.FillDatasetByProc(
                v_ds,
                "pr_A150_giao_du_toan_vp_tong_cuc",
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
                Person.get_id_don_vi(),
                m_txt_tu_khoa_tim_kiem.Text,
                "Y");
            addNewColumnToGridView(v_ds);
            v_dt = v_ds.Tables[0];
            v_dt.Columns.Add("TONG_SO");
            v_dt.Columns.Add("TU_CHU");
            v_dt.Columns.Add("KHONG_TU_CHU");
            updateCell(v_dt);
            m_grv_bao_cao_giao_von.DataSource = v_dt;
            m_grv_bao_cao_giao_von.DataBind();
        }

        private void xoaCotDong()
        {
            var v_count_column = m_grv_bao_cao_giao_von.Columns.Count;
            for (int i = v_count_column - 1 ; i >= 4; i--)
            {
                m_grv_bao_cao_giao_von.Columns.RemoveAt(i);
            }
            m_lst_str_header.Clear();
        }

        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }

        private void addNewColumnToGridView(DataSet ip_ds)
        {
            var v_index = 0;
            DataTable v_dt = ip_ds.Tables[0];
            if (v_dt.Columns.Count == 4)
            {
                m_grv_bao_cao_giao_von.Visible = false;
                m_lbl_mess.Text = "Không tìm thấy dữ liệu phù hợp !!!";
                m_lbl_mess.Visible = true;
            }
            for (int i = 4; i < v_dt.Columns.Count; i++)
            {
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

        private string get_header_text(string p, int ip_index)
        {
            string v_res = "";
            var v_arr = p.Split('_');
            if (v_arr[1].Contains("ktc"))
            {
                v_res += "Không T.Chủ";
            }
            else if (v_arr[1].Contains("tc"))
            {
                v_res += "T.Chủ";
            }
            else
            {
                v_res += "Tổng";
            }
            if (ip_index % 3 == 0)
            {
                m_lst_str_header.Add(v_arr[0]);
            }
            return v_res;
        }

        private void updateCell(DataTable ip_dt)
        {
            decimal ts = 0;
            decimal ktx = 0;
            decimal tx = 0;
            for (int i = 0; i < ip_dt.Rows.Count; i++)
            {
                for (int j = 4; j < ip_dt.Columns.Count; j++)
                {
                    string v_str = ip_dt.Rows[i][j].ToString();
                    if (v_str == "" || v_str == null)
                    {
                        continue;
                    }
                    if (ip_dt.Columns[j].ColumnName.Contains("ktc"))
                    {
                        ktx += CIPConvert.ToDecimal(v_str);
                    }
                    else if (ip_dt.Columns[j].ColumnName.Contains("tc"))
                    {
                        tx += CIPConvert.ToDecimal(v_str);
                    }
                    else
                    {
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

        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
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

                foreach (var item in m_lst_str_header)
                {
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

        protected void m_grv_bao_cao_giao_von_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false; // Invisibiling Year Header Cell
                //e.Row.Cells[1].Visible = false; // Invisibiling Period Header Cell
                //e.Row.Cells[2].Visible = false; // Invisibiling Audited By Header Cell
            }
        }
        #endregion
    }
}