using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.ChucNang
{
	public partial class F600_print_unc_qbt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				xoa_trang_info();
				if (Request.QueryString["ip_dc_id_dm_unc"] == null) return;
				load_content_print(CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_dm_unc"]));
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
			
		}

		private void load_content_print(decimal ip_dc_id_dm_unc)
		{
			US_V_DM_UY_NHIEM_CHI v_us = new US_V_DM_UY_NHIEM_CHI(ip_dc_id_dm_unc);
			DS_V_DM_UY_NHIEM_CHI v_ds = new DS_V_DM_UY_NHIEM_CHI();

			US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI(Person.get_id_don_vi(), Person.get_id_don_vi());
			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(Person.get_id_don_vi());
			v_us.FillDataset(v_ds, "where " + V_DM_UY_NHIEM_CHI.ID_DON_VI + "=" + Person.get_id_don_vi());

			m_lbl_ngay_thang.Text = " " + CIPConvert.ToStr(v_us.datNGAY_THANG, "dd") +
				" tháng " + CIPConvert.ToStr(v_us.datNGAY_THANG, "MM") +
				" năm " + CIPConvert.ToStr(v_us.datNGAY_THANG, "yyyy");
			//load data to Noi dung thanh toan
			m_grv.DataSource = v_ds.V_DM_UY_NHIEM_CHI;
			m_grv.DataBind();
			//load info Don vi tra tien
			m_lbl_don_vi_tra_tien.Text = v_us_dm_don_vi.strTEN_DON_VI;
			m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
			m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;
			m_lbl_ma_tkkt.Text = v_us.strMA_TKKT;
			m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
			m_lbl_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;
			m_lbl_so_tien_ghi_bang_chu.Text = "...........................................................................................................";
			//load info Nop thue
			m_lbl_nt_ten_don_vi.Text = v_us.strNT_TEN_DON_VI;
			m_lbl_nt_ma_so_thue.Text = v_us.strNT_MA_SO_THUE;
			m_lbl_nt_ma_ndkt.Text = v_us.strNT_MA_NDKT;
			m_lbl_nt_ma_chuong.Text = v_us.strNT_MA_CHUONG;
			m_lbl_nt_co_quan_quan_ly_thu.Text = v_us.strNT_CQ_QL_THU;
			m_lbl_nt_ma_cq_thu.Text = v_us.strNT_MA_CQ_THU;
			m_lbl_nt_so_tien_nop_thue.Text = v_us.strNT_SO_TIEN_NOP_THUE;
			//load info Thanh toan cho don vi huong
			m_lbl_ttdvh_don_vi_nhan_tien.Text = v_us.strTTDVH_DON_VI_NHAN_TIEN;
			m_lbl_ttdvh_ma_dvqhns.Text = v_us.strTTDVH_MA_DVQHNS;
			m_lbl_ttdvh_dia_chi.Text = v_us.strTTDVH_DIA_CHI;
			m_lbl_ttdvh_tai_khoan.Text = v_us.strTTDVH_TAI_KHOAN;
			m_lbl_ttdvh_ma_ctmt_da_htct.Text = v_us.strTTDVH_MA_CTMT_DA_VA_HTCT;
			m_lbl_ttdvh_tai_kbnn.Text = v_us.strTTDVH_KHO_BAC;
			m_lbl_ttdvh_so_tien_thanh_toan_dvh.Text = v_us.strTTDVH_SO_TIEN;
		}
		private void xoa_trang_info()
		{
			//load info Don vi tra tien
			m_lbl_don_vi_tra_tien.Text = "";
			m_lbl_dia_chi.Text = "";
			m_lbl_tai_kho_bac_nha_nuoc.Text = "";
			m_lbl_ma_tkkt.Text = "";
			m_lbl_ma_dvqhns.Text = "";
			m_lbl_ma_ctmt_da_htct.Text = "";
			m_lbl_so_tien_ghi_bang_chu.Text = "...........................................................................................................";
			//load info Nop thue
			m_lbl_nt_ten_don_vi.Text = "";
			m_lbl_nt_ma_so_thue.Text = "";
			m_lbl_nt_ma_ndkt.Text = "";
			m_lbl_nt_ma_chuong.Text = "";
			m_lbl_nt_co_quan_quan_ly_thu.Text = "";
			m_lbl_nt_ma_cq_thu.Text = "";
			m_lbl_nt_so_tien_nop_thue.Text = "";
			//load info Thanh toan cho don vi huong
			m_lbl_ttdvh_don_vi_nhan_tien.Text = "";
			m_lbl_ttdvh_ma_dvqhns.Text = "";
			m_lbl_ttdvh_dia_chi.Text = "";
			m_lbl_ttdvh_tai_khoan.Text = "";
			m_lbl_ttdvh_ma_ctmt_da_htct.Text = "";
			m_lbl_ttdvh_tai_kbnn.Text = "";
			m_lbl_ttdvh_so_tien_thanh_toan_dvh.Text = "";
		}

		public string get_tong_tien(string ip_str_nop_thue, string ip_str_tt_cho_dv_huong)
		{
			string op_str = "0";
			decimal v_dc_nop_thue = 0;
			decimal v_dc_tt_cho_dv_huong = 0;
			if (ip_str_nop_thue.Trim().Equals("") | ip_str_nop_thue.Trim().Equals("0"))
			{
				v_dc_nop_thue = 0;
			}
			else v_dc_nop_thue = CIPConvert.ToDecimal(ip_str_nop_thue);
			if (ip_str_tt_cho_dv_huong.Trim().Equals("") | ip_str_tt_cho_dv_huong.Trim().Equals("0"))
			{
				v_dc_tt_cho_dv_huong = 0;
			}
			else v_dc_tt_cho_dv_huong = CIPConvert.ToDecimal(ip_str_tt_cho_dv_huong);
			if (v_dc_nop_thue + v_dc_tt_cho_dv_huong == 0)
			{
				op_str = "0";
			}
			else op_str = CIPConvert.ToStr(v_dc_nop_thue + v_dc_tt_cho_dv_huong, "#,###,##");
			return op_str;
		}
		public string format_so_tien(string ip_str_so_tien)
		{
			string op_str = "0";
			decimal v_dc_so_tien = 0;
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("0"))
			{
				op_str = "0";
			}
			else
			{
				v_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
				op_str = CIPConvert.ToStr(v_dc_so_tien, "#,###,##");
			}

			return op_str;
		}
	}
}