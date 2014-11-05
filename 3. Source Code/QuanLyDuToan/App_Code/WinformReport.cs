using System;
using System.Drawing;
using System.Web.SessionState;
using System.Web;
using System.IO;    


using System.Web.UI.WebControls;


using System.Collections.Generic;
using System.Web.UI;






/// <summary>
/// Summary description for WinformReport
/// </summary>
public class WinformReport
{
    /*
* Chú ý khi xuất excel:
* thêm EnableEventValidation ="false" vào <%@ Page ở trang .aspx
* Hàm load dữ liệu lên lưới để là: load_data_to_grid();
*/

    /// <summary>
    /// Hàm này dùng để xuất dữ liệu từ Gridview ra Excel
    /// </summary>
    /// <param name="ip_grv">Gridview muốn xuất dữ liệu ra</param>
    /// <param name="ip_str_filename">Tên file excel xuất ra</param>
    /// <param name="ip_b_export_all_yn">Xuất tất cả dữ liệu hay chỉ xuất ở trang hiện tại</param>
    /// <param name="ip_i_invisible_columns">Danh sách các cột muốn ẩn đi khi xuất (lấy theo số thứ tự, bắt đầu từ 0)</param>
    public static void export_gridview_2_excel(GridView ip_grv
                               , string ip_str_filename
                               , params int[] ip_i_invisible_columns
                                )
    {
        if (ip_grv.Rows.Count == 0) return;
        HttpContext.Current.Response.Clear();
        //Response.Buffer = true;
        HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + ip_str_filename);
        HttpContext.Current.Response.Charset = "UTF-8";
        HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
        HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
        HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);
            //if (ip_b_export_all_yn) {
            //    //To Export all pages
            //    ip_grv.AllowPaging = false;
            //    load_data_to_grid();
            //}
            //ip_grv.DataBind();
            // Ẩn các cột phân trang ở cả đầu và cuối
            if(ip_grv.TopPagerRow != null) ip_grv.TopPagerRow.Visible = false;
            if (ip_grv.BottomPagerRow != null) ip_grv.BottomPagerRow.Visible = false;

            ip_grv.HeaderRow.BackColor = Color.White;
            foreach (TableCell cell in ip_grv.HeaderRow.Cells)
            {
                cell.BackColor = ip_grv.HeaderStyle.BackColor;
            }
            // Chỗ này để ẩn đi cột trên header
            if (ip_i_invisible_columns.Length > 0)
            {
                for (int v_i = 0; v_i < ip_i_invisible_columns.Length; v_i++)
                {
                    ip_grv.HeaderRow.Cells[v_i].Visible = false;
                }
            }

            foreach (GridViewRow row in ip_grv.Rows)
            {
                // Chỗ này để ẩn đi cột trên các dòng dữ liệu
                if (ip_i_invisible_columns.Length > 0)
                {
                    for (int v_i = 0; v_i < ip_i_invisible_columns.Length; v_i++)
                    {
                        row.Cells[v_i].Visible = false;
                    }
                }

                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = ip_grv.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = ip_grv.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";

                    List<Control> controls = new List<Control>();

                    //Add controls to be removed to Generic List
                    //foreach (Control control in cell.Controls)
                    //{
                    //    switch (control.GetType().Name)
                    //    {
                    //        case "HyperLink":
                    //            cell.Controls.Remove(control);
                    //            break;
                    //        case "TextBox":
                    //            break;
                    //        case "LinkButton":
                    //            cell.Controls.Remove(control);
                    //            break;
                    //        case "CheckBox":
                    //            cell.Controls.Remove(control);
                    //            break;
                    //        case "RadioButton":
                    //            //cell.Controls.Add(new Literal { Text = (control as RadioButton).Text });  // Chưa biết tại sao lỗi
                    //            cell.Controls.Remove(control);
                    //            break;
                    //    }
                    //}
                }
            }
            ip_grv.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            HttpContext.Current.Response.Write(style);
            HttpContext.Current.Response.Output.Write(sw.ToString());
            //Response.Write(sw.ToString());
            HttpContext.Current.Response.Flush();
            HttpContext.Current.Response.End();
        }
    }

    /*
    * Ví dụ dùng hàm
  
    protected void m_cmd_xuat_excel_Click(object sender, EventArgs e) {
        try {
            export_gridview_2_excel(m_grv_dm_tai_san
                        , "DS tai san.xls"
                        , true
                        , 0, 1); // 0 và 1 là số thứ tự 2 cột: Sửa, Xóa
        }
        catch (Exception v_e) {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
     *   */
}