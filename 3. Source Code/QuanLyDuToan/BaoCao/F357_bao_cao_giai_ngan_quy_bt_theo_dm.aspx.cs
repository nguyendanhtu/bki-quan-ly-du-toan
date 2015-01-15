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
    public partial class F357_bao_cao_giai_ngan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                WinFormControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
                DateTime v_dat_now = DateTime.Now;
                DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
                v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
                m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
                m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");
                load_data_2_ddl();
                load_data_2_grid();
            }
        }

        private void load_data_2_grid()
        {
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            v_ds.EnforceConstraints = false;
            new US_V_GD_GIAI_NGAN_QBT().FillData2DatasetGiaiNgan(
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
                "pr_A357_bao_cao_giai_ngan");
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
            US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN();
            DS_DM_GIAI_NGAN v_ds = new DS_DM_GIAI_NGAN();
            v_us.FillDataset(v_ds, " where ID_DON_VI = " + Person.get_id_don_vi().ToString());
            m_ddl_quyet_dinh.DataSource = v_ds.DM_GIAI_NGAN;
            m_ddl_quyet_dinh.DataValueField = DM_GIAI_NGAN.ID;
            m_ddl_quyet_dinh.DataTextField = DM_GIAI_NGAN.SO_UNC;
            m_ddl_quyet_dinh.DataBind();
        }

        private void load_data_2_ddl_don_vi()
        {
            WinFormControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
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
            load_data_2_grid();
        }
    }
}