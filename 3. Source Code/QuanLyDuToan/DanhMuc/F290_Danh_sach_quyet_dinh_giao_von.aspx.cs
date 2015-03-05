﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.DanhMuc
{
	public partial class F290_danh_sach_quyet_dinh_giao_von : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                set_default_input();
                //load dropdownlist danh sach don vi ma don vi X duoc xem du lieu
                WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
                load_data_to_grid();    
            }            
        }

        private void load_data_to_grid()
        {
            US_V_DM_QUYET_DINH v_us = new US_V_DM_QUYET_DINH();
            DS_V_DM_QUYET_DINH v_ds = new DS_V_DM_QUYET_DINH();
            v_ds.EnforceConstraints = false;
			v_us.FillDatasetByIdDonVi(
				v_ds,
				CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
				CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
				CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT),
				m_txt_tu_khoa_tim_kiem.Text
				);
            m_grv.DataSource = v_ds.V_DM_QUYET_DINH;
            m_grv.DataBind();
        }
        
        private void set_default_input()
        {
            m_txt_tu_khoa_tim_kiem.Text = "";
            if (Request.QueryString["ip_dat_tu_ngay"] != null)
            {
                m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
            }
            else
            {
                m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            }
            if (Request.QueryString["ip_dat_den_ngay"] != null)
            {
                m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
            }
            else
            {
                m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            }
            if (Request.QueryString["ip_dc_id_don_vi"] != null)
            {
                m_ddl_don_vi.SelectedValue = Request.QueryString["ip_dc_id_don_vi"].ToString();
            }
        }
		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
            m_grv, "[" + v_us.strTEN_DON_VI + "]BaoCaoGiaoVonTheoQuyetDinh.xls");
		}
        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception ex)
            {

                CSystemLog_301.ExceptionHandle(this,ex);
            }
            
        }
        protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }

		/* Để Xuất file excel
		 * 1. Dùng 
		 * WinformReport.export_gridview_2_excel(
			m_grv
			, "TenBaoCao.xls"
			);
		 * 2. Thêm 
		 * <Triggers>
			 <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
		</Triggers>
		 * Trong aspx
		 * 3. Thêm hàm VerifyRenderingInServerForm
		*/
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				export_excel();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
    }
}