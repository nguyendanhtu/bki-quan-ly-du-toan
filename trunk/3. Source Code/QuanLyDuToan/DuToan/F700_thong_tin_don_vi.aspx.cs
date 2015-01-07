﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPUserService;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.DuToan
{
	public partial class F700_thong_tin_don_vi : System.Web.UI.Page
	{
		private bool check_data_is_ok()
		{
			if (!CValidateTextBox.IsValid(m_txt_dia_chi,DataType.StringType,allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập thông tin Địa chỉ!";
				m_txt_dia_chi.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_kho_bac, DataType.StringType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập thông tin Kho bạc!";
				m_txt_kho_bac.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_ma_tkkt_nguon_ns, DataType.StringType, allowNull.NO)&&
				!CValidateTextBox.IsValid(m_txt_ma_tkkt_quy_bao_tri, DataType.StringType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập thông tin về Mã TKKT!";
				m_txt_ma_tkkt_quy_bao_tri.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_ma_dvqhns, DataType.StringType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập thông tin Mã ĐVQHNS!";
				m_txt_ma_dvqhns.Focus();
				return false;
			}
			return true;
		}
		private void get_thong_tin_don_vi(decimal ip_dc_id_don_vi)
		{
			US_DM_THONG_TIN_DON_VI v_us = new US_DM_THONG_TIN_DON_VI(ip_dc_id_don_vi, ip_dc_id_don_vi);
			m_txt_dia_chi.Text = v_us.strDIA_CHI;
			m_txt_kho_bac.Text = v_us.strKHO_BAC;
			m_txt_ma_tkkt_nguon_ns.Text = v_us.strMA_TKKT2;
			m_txt_ma_tkkt_quy_bao_tri.Text = v_us.strMA_TKKT1;
		}
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					get_thong_tin_don_vi(Person.get_id_don_vi());
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}


		protected void m_cmd_save_Click(object sender, EventArgs e)
		{
			try
			{
				if (check_data_is_ok())
				{
					US_DM_THONG_TIN_DON_VI v_us = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(),Person.get_id_don_vi());
					v_us.strDIA_CHI = m_txt_dia_chi.Text.Trim();
					v_us.strKHO_BAC = m_txt_kho_bac.Text.Trim();
					v_us.strMA_DVQHNS = m_txt_ma_dvqhns.Text.Trim();
					v_us.strMA_TKKT1 = m_txt_ma_tkkt_quy_bao_tri.Text.Trim();
					v_us.strMA_TKKT2 = m_txt_ma_tkkt_nguon_ns.Text.Trim();
					v_us.Update();
					m_lbl_mess.Text = "Cập nhật dữ liệu thành công!";
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
	}
}