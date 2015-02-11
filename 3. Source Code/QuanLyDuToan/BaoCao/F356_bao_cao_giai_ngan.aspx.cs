using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPCommon;

namespace QuanLyDuToan.BaoCao
{
    public partial class F356_bao_cao_giai_ngan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region dữ liệu demo, khi nào code thì xóa đi
            //-------------------------------------------------------
            DataTable dt = new DataTable();
            DataColumn dc = new DataColumn();

            if (dt.Columns.Count == 0)
            {
                dt.Columns.Add("NHIEM_VU_CHI", typeof(string));
                dt.Columns.Add("TONG_SO_KE_HOACH", typeof(decimal));
                dt.Columns.Add("TONG_SO_VON_GIAO", typeof(decimal));
                dt.Columns.Add("SO_TIEN_QUY_BT", typeof(decimal));
                dt.Columns.Add("SO_TIEN_NS", typeof(decimal));
                dt.Columns.Add("TONG", typeof(decimal));
            }

            DataRow NewRow = dt.NewRow();
            NewRow[0] = "Chi sửa quốc lộ 31";
            NewRow[1] = 3000000000;
            NewRow[2] = 2500000000;
            NewRow[3] = 1000000000;
            NewRow[4] = 1000000000;
            NewRow[5] = 2000000000;
            dt.Rows.Add(NewRow);
            m_grv_bao_cao_giai_ngan.DataSource = dt;
            m_grv_bao_cao_giai_ngan.DataBind();
            //-------------------------------------------------------
            #endregion
            set_default_input();
            //load_data_2_grid();
        }

        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }

        private void load_data_2_grid()
        {
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            DS_RPT_BC_TINH_HINH_GIAI_NGAN v_ds = new DS_RPT_BC_TINH_HINH_GIAI_NGAN();
            //v_us.bc_tinh_hinh_giai_ngan_tong_cuc(
            //    v_ds,
            //    CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
            //    CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
            //    m_txt_tu_khoa_tim_kiem.Text
            //);
            m_grv_bao_cao_giai_ngan.DataSource = v_ds.RPT_BC_TINH_HINH_GIAI_NGAN;
            m_grv_bao_cao_giai_ngan.DataBind();
        }

        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {

        }

        protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            WebformReport.export_gridview_2_excel(
            m_grv_bao_cao_giai_ngan
            , "BaoCaoTinhHinhGiaiNgan.xls"
            );
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            
        }
    }
}