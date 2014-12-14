using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.DanhMuc
{
    public partial class F004_Danh_sach_chuong_loai_khoan_muc : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_data_2_grid();   
            }
        }

        private void load_data_2_grid()
        {
            US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC v_us = new US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC();
            DS_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC v_ds = new DS_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC();
            v_us.FilterAndFillDataset(v_ds, m_txt_tu_khoa_tim_kiem.Text);
            m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC;
            m_grv_bao_cao_giao_von.DataBind();
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
        }

        protected void m_grv_bao_cao_giao_von_DataBound(object sender, EventArgs e)
        {
            for (int rowIndex = m_grv_bao_cao_giao_von.Rows.Count - 2; rowIndex >= 0; rowIndex--)
            {
                GridViewRow row = m_grv_bao_cao_giao_von.Rows[rowIndex];
                GridViewRow previousRow = m_grv_bao_cao_giao_von.Rows[rowIndex + 1];
                for (int i = 0; i < 3; i++)
                {
                    if (row.Cells[i].Text == previousRow.Cells[i].Text)
                    {
                        if (previousRow.Cells[i].RowSpan < 2)
                        {
                            row.Cells[i].RowSpan = 2;
                        }
                        else
                        {
                            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan + 1;
                        }
                        previousRow.Cells[i].Visible = false;
                    }
                }                
                //row.Cells[0].CssClass = "HeaderStyle"; // This is to just give header color, font style
            }
        }
    }
}