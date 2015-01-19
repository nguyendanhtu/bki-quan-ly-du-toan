using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.BaoCao
{
    public partial class F257_bao_cao_giao_von : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                DateTime v_dat_now = DateTime.Now;
                DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
                decimal v_dc_ip_cong_trinh = -1;
                decimal v_dc_ip_loai_nhiem_vu = -1;
                decimal v_dc_ip_du_an = -1;
                if (Request.QueryString["ip_dat_tu_ngay"] != null)
                {
                    v_dat_dau_nam = CIPConvert.ToDatetime(Request.QueryString["ip_dat_tu_ngay"]);
                }
                if (Request.QueryString["ip_dat_den_ngay"] != null)
                {
                    v_dat_now = CIPConvert.ToDatetime(Request.QueryString["ip_dat_den_ngay"]);
                }
                if (Request.QueryString["ip_dc_id_du_an"] != null) {
                    v_dc_ip_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
                }
                if (Request.QueryString["ip_dc_id_cong_trinh"] != null) {
                    v_dc_ip_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
                }
                if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null) {
                    v_dc_ip_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
                }
                v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                //load dropdownlist
                //load đơn vị & quyết định
                load_data_2_ddl();
                WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
                m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(v_dc_ip_loai_nhiem_vu);
                //load công trình
                App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
                m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(v_dc_ip_cong_trinh);
                App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
                m_ddl_du_an.SelectedValue = CIPConvert.ToStr(v_dc_ip_du_an);
                load_data_2_grid();
            }            
        }

        private void load_data_2_grid()
        {
            if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) == -1)
            {
                BoundField field = (BoundField)this.m_grv.Columns[1];
                field.DataField = "tong_tien";
            }
            else
            {
                BoundField field = (BoundField)this.m_grv.Columns[1];
                field.DataField = "tong_tien_qd";
            }
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            v_ds.EnforceConstraints = false;
            new US_V_GD_GIAI_NGAN_QBT ().FillData2Dataset(
                v_ds,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
                CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue.Trim() == "" ? "-1" : m_ddl_loai_nv.SelectedValue.Trim()),
                CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue.Trim() == "" ? "-1" : m_ddl_cong_trinh.SelectedValue.Trim()),
                CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue.Trim() == "" ? "-1" : m_ddl_du_an.SelectedValue.Trim()),
                m_txt_tim_kiem.Text.Trim(),
                "N",
                CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue),
                "pr_A257_giao_von_theo_quyet_dinh");
            m_grv.DataSource = v_ds.Tables[0];
            m_grv.DataBind();
        }

        private void load_data_2_ddl()
        {
            load_data_2_ddl_don_vi();
            load_data_2_ddl_quyet_dinh();
        }

        private void load_data_2_ddl_quyet_dinh()
        {
            WinFormControls.load_data_to_cbo_quyet_dinh(118, -1, -1, -1,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                m_txt_tim_kiem.Text.Trim(),
                WinFormControls.eTAT_CA.YES,
                "pr_A290_danh_sach_quyet_dinh_giao_von",
                m_ddl_quyet_dinh);
        }

        private void load_data_2_ddl_don_vi()
        {
            decimal v_dc_id_don_vi = Person.get_id_don_vi();
            if (Request.QueryString["ip_dc_id_don_vi"] != null)
            {
                v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
            }
            WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(v_dc_id_don_vi, m_ddl_don_vi);
        }

        protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
        {
            App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
        }

        protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
        }

        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
        {
            load_data_2_grid();
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }

        protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
            WinformReport.export_gridview_2_excel(
            m_grv
            , "[" + v_us.strTEN_DON_VI + "]BaoCaoTinhHinhGiaoVon.xls"
            );
        }

        protected void m_txt_tu_ngay_TextChanged(object sender, EventArgs e)
        {
            load_data_2_ddl_quyet_dinh();
        }

        protected void m_txt_den_ngay_TextChanged(object sender, EventArgs e)
        {
            load_data_2_ddl_quyet_dinh();
        }

		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_2_grid();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
    }
}