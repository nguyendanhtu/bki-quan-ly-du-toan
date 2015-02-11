﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;
using System.Data;
using IP.Core.IPUserService;
using IP.Core.IPData;
//using IP.Core.IPExcelWebReport;

namespace QuanLyDuToan.DanhMuc
{
	public partial class F190_danh_sach_quyet_dinh_giao_kh : System.Web.UI.Page
	{
        US_V_DM_QUYET_DINH_KH m_us = new US_V_DM_QUYET_DINH_KH();
        
		#region Private Methods
		private bool check_validate_data_is_ok()
		{
			if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập ngày tháng!";
				m_txt_tu_ngay.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập ngày tháng!";
				m_txt_den_ngay.Focus();
				return false;
			}
			return true;
		}

		private void load_data_to_grid()
		{
			m_lbl_info.Text = "";
			if (!check_validate_data_is_ok()) return;

			DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
			DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy");

			decimal v_dc_id_loai_nhiem_vu = -1, v_dc_id_id_cong_trinh = -1, v_dc_id_du_an = -1;

			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
			{
				v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
				if (v_dc_id_loai_nhiem_vu != -1)
				{
					US_CM_DM_TU_DIEN v_us_loai_nhiem_vu = new US_CM_DM_TU_DIEN(v_dc_id_loai_nhiem_vu);
					m_lbl_info.Text = "Loại nhiệm vụ: " + v_us_loai_nhiem_vu.strTEN;
				}

			}
			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_dc_id_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
				if (v_dc_id_id_cong_trinh != -1)
				{
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_cong_trinh = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(v_dc_id_id_cong_trinh);
					m_lbl_info.Text += "- Công trình/Quốc lộ: " + v_us_cong_trinh.strTEN;
				}
			}
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
				if (v_dc_id_id_cong_trinh != -1)
				{
					US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_du_an = new US_DM_CONG_TRINH_DU_AN_GOI_THAU(v_dc_id_du_an);
					m_lbl_info.Text += "- Dự án: " + v_us_du_an.strTEN;
				}
			}
            US_V_DM_QUYET_DINH_KH v_us = new US_V_DM_QUYET_DINH_KH();
            DS_V_DM_QUYET_DINH_KH v_ds = new DS_V_DM_QUYET_DINH_KH();
            v_ds.EnforceConstraints = false;
            v_us.FillDatasetGiaoKHByIdDonVi(
                v_ds,
                CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                m_txt_tu_khoa_tim_kiem.Text
                );
            m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_QUYET_DINH_KH;
			m_grv_bao_cao_giao_von.DataBind();

		}

		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
			m_grv_bao_cao_giao_von, "[" + v_us.strTEN_DON_VI + "]BaoCaoGiaoKeHoachTheoQuyetDinh.xls");
		}

        private void us_2_form(){
            m_txt_noi_dung.Text = m_us.strNOI_DUNG;
            m_txt_so_quyet_dinh.Text = m_us.strSO_QUYET_DINH;
            m_txt_ngay_thang.Text = CIPConvert.ToStr(m_us.datNGAY_THANG, c_configuration.DEFAULT_DATETIME_FORMAT);
            m_ddl_loai_quyet_dinh_giao.SelectedValue = m_us.dcID_LOAI_QUYET_DINH_GIAO.ToString();
        }

        private void form_2_us() {
            m_us.strNOI_DUNG = m_txt_noi_dung.Text;
            m_us.strSO_QUYET_DINH = m_txt_so_quyet_dinh.Text;
            m_us.datNGAY_THANG = CIPConvert.ToDatetime(m_txt_ngay_thang.Text, c_configuration.DEFAULT_DATETIME_FORMAT);
            m_us.dcID_LOAI_QUYET_DINH_GIAO = CIPConvert.ToDecimal(m_ddl_loai_quyet_dinh_giao.SelectedValue);
            m_us.dcID_LOAI_QUYET_DINH = 647;//id giao ke hoach
        }

        private void load_data_2_ddl_loai_quyet_dinh_giao() {
            US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
            DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
            v_us.fill_tu_dien_cung_loai_ds("LOAI_GIAO_DICH", v_ds);
            m_ddl_loai_quyet_dinh_giao.DataSource = v_ds.CM_DM_TU_DIEN;
            m_ddl_loai_quyet_dinh_giao.DataValueField = CM_DM_TU_DIEN.ID;
            m_ddl_loai_quyet_dinh_giao.DataTextField = CM_DM_TU_DIEN.TEN;
            m_ddl_loai_quyet_dinh_giao.DataBind();
        }

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
                    if (Request.QueryString["ip_dat_tu_ngay"] != null)
                    {
                        m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_tu_ngay.Text = CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(DateTime.Now), "dd/MM/yyyy");
                    }
                    if (Request.QueryString["ip_dat_den_ngay"] != null)
                    {
                        m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
                    }
                    if (Request.QueryString["ip_dc_id_don_vi"] != null)
                    {
                        m_ddl_don_vi.SelectedValue = Request.QueryString["ip_dc_id_don_vi"].ToString();
                    }
                    WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
                    load_data_2_ddl_loai_quyet_dinh_giao();
					load_data_to_grid();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
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
		#endregion

        protected void m_cmd_insert_Click(object sender, EventArgs e)
        {
            try
            {
                form_2_us();
                if (check_us())
                {
                    m_us.Insert();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
        private bool check_us()
        {
            if (m_us.strSO_QUYET_DINH.Trim() == "")
            {
                return false;
            }
            if (m_us.strNOI_DUNG.Trim() == "")
            {
                return false;
            }
            return true;
        }
	}
}