﻿using System;
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
    public partial class F530_bao_cao_tong_cuc : System.Web.UI.Page
    {
        #region Public
        #endregion

        #region Data Member
        decimal m_dc_id_cong_trinh_du_an;
        DateTime m_dat_tu_ngay;
        DateTime m_dat_den_ngay;
        string m_str_is_nguon_ngan_sach;
        string m_str_ten_du_an;
        #endregion

        #region Private Method

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

        private void load_data_to_grid()
        {
            DS_V_GD_GIAI_NGAN_QBT v_us = new DS_V_GD_GIAI_NGAN_QBT();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
			//v_us.bc_tra_cuu_uy_nhiem_chi_theo_du_an(v_ds
			//	,m_dc_id_cong_trinh_du_an
			//	,m_str_ten_du_an
			//	,m_str_is_nguon_ngan_sach
			//	, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
			//	, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
			//	);
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

        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {

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
        #endregion
    }
}