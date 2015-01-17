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

                if (Request.QueryString["ip_dat_tu_ngay"] != null)
                {
                    v_dat_dau_nam = CIPConvert.ToDatetime(Request.QueryString["ip_dat_tu_ngay"]);
                }
                if (Request.QueryString["ip_dat_den_ngay"] != null)
                {
                    v_dat_now = CIPConvert.ToDatetime(Request.QueryString["ip_dat_den_ngay"]);
                }
                v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                load_data_2_ddl();
                WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
                m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
                App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));

                m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(Request.QueryString["ip_dc_id_cong_trinh"]);
                App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
                m_ddl_du_an.SelectedValue = CIPConvert.ToStr(Request.QueryString["ip_dc_id_du_an"]);
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
                Person.get_id_don_vi(),
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
            decimal v_dc_id_don_vi = Person.get_id_don_vi();
            if (Request.QueryString["ip_dc_id_don_vi"] != null)
            {
                v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
            }
            App_Code.WinFormControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, v_dc_id_don_vi);
        }

        protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal v_dc_id_don_vi = Person.get_id_don_vi();
            if (Request.QueryString["ip_dc_id_don_vi"] != null)
            {
                v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
            }
            App_Code.WinFormControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, v_dc_id_don_vi);
        }

        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
        {
            load_data_2_ddl_quyet_dinh();
            load_data_2_grid();
        }
    }
}