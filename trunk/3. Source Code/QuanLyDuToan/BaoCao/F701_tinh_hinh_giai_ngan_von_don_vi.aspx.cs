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
using QuanLyDuToan.App_Code;
using System.Data;

namespace QuanLyDuToan.BaoCao
{
    public partial class F701_tinh_hinh_giai_ngan_von_don_vi : System.Web.UI.Page
    {
        public string format_so_tien(string ip_str_so_tien)
        {
            string op_str_so_tien = "";
            if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
            {
                op_str_so_tien = "";
            }
            else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
            return op_str_so_tien;
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    DateTime v_dat_now = DateTime.Now;
                    DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
                    v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                    m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                    m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                    load_data_to_grid();
                }
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }

        }

        private void load_data_to_grid()
        {
            US_RPT_BC_TINH_HINH_GIAI_NGAN v_us = new US_RPT_BC_TINH_HINH_GIAI_NGAN();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            v_us.bc_tinh_hinh_giai_ngan_tong_cuc(v_ds
                , CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
                , CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
                );
            m_grv.DataSource = v_ds.Tables[0];
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
            WebformReport.export_gridview_2_excel(
            m_grv
            , "BaoCaoTinhHinhGiaiNganVonDonVi.xls"
            );
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}