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
using System.Globalization;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.UserControls
{
	public partial class F304Print : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			xoa_trang_info();

			load_content_print(m_dc_id_dm_unc);
		}
		public static string RenderToString(decimal ip_dc_id_dm_unc, decimal ip_dc_id_don_vi)
		{
			return UIUtil.RenderUserControl<F304Print>("~/UserControls/F304Print.ascx",
				uc =>
				{
					uc.m_dc_id_dm_unc = ip_dc_id_dm_unc;
					uc.m_dc_id_don_vi=ip_dc_id_don_vi;
				});
		}

		#region Members
		public decimal m_dc_tong_tien = 0;
		public decimal m_dc_tong_tien_nop_thue = 0;
		public decimal m_dc_tong_tien_thanh_toan_cho_don_vi_huong = 0;
		public decimal m_dc_id_dm_unc = 31;
		public decimal m_dc_id_don_vi = 264;
		public DS_V_DM_GIAI_NGAN m_ds;
		#endregion

		#region Private Methods

		private void load_content_print(decimal ip_dc_id_dm_unc)
		{
			if (ip_dc_id_dm_unc == 0 || m_dc_id_don_vi == 0) return;
			US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN(ip_dc_id_dm_unc);
			m_lbl_so_unc.Text = v_us.strSO_UNC;
			m_lbl_so_tien_ghi_bang_chu.Text = v_us.strTTDVH_SO_TIEN;
			US_V_DM_GIAI_NGAN v_us_v_giai_ngan = new US_V_DM_GIAI_NGAN();
			m_ds = new DS_V_DM_GIAI_NGAN();
			m_ds.EnforceConstraints = false;

			US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI();
			decimal v_dc_id_don_vi = m_dc_id_don_vi;

			v_us_thong_tin_don_vi.InitByID_DON_VI(v_dc_id_don_vi);
			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(v_dc_id_don_vi);
			v_us_v_giai_ngan.FillDataset(m_ds, "where " + V_DM_GIAI_NGAN.ID_DON_VI + "=" + v_dc_id_don_vi
				+ " and " + V_DM_GIAI_NGAN.ID + "=" + ip_dc_id_dm_unc);

			m_lbl_ngay_thang.Text = " " + CIPConvert.ToStr(v_us.datNGAY_THANG, "dd") +
				" tháng " + CIPConvert.ToStr(v_us.datNGAY_THANG, "MM") +
				" năm " + CIPConvert.ToStr(v_us.datNGAY_THANG, "yyyy");
			//load data to Noi dung thanh toan
			//m_grv.DataSource = v_ds.V_DM_GIAI_NGAN;
			//m_grv.DataBind();

			
			if (m_ds.Tables.Count > 0)
			{
				for (int i = 0; i < m_ds.V_DM_GIAI_NGAN.Count; i++)
				{
					m_dc_tong_tien += CIPConvert.ToDecimal(m_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE])
						+ CIPConvert.ToDecimal(m_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG]);
					m_dc_tong_tien_nop_thue += CIPConvert.ToDecimal(m_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE]);
					m_dc_tong_tien_thanh_toan_cho_don_vi_huong += CIPConvert.ToDecimal(m_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG]);
				}
			}
			//load info Don vi tra tien
			m_lbl_don_vi_tra_tien.Text = v_us_dm_don_vi.strTEN_DON_VI;
			m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
			m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;
			m_lbl_ma_tkkt.Text = v_us.strMA_TKKT;
			m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
			m_lbl_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;
			m_lbl_so_tien_ghi_bang_chu.Text = "...........................................................................................................";
			m_lbl_so_tien_ghi_bang_chu.Text = IP.Core.IPCommon.CRead.ChuyenSo(m_dc_tong_tien.ToString());
			//load info Nop thue
			m_lbl_nt_ten_don_vi.Text = v_us.strNT_TEN_DON_VI;
			m_lbl_nt_ma_so_thue.Text = v_us.strNT_MA_SO_THUE;
			m_lbl_nt_ma_ndkt.Text = v_us.strNT_MA_NDKT;
			m_lbl_nt_ma_chuong.Text = v_us.strNT_MA_CHUONG;
			m_lbl_nt_co_quan_quan_ly_thu.Text = v_us.strNT_CQ_QL_THU;
			m_lbl_nt_ma_cq_thu.Text = v_us.strNT_MA_CQ_THU;
			m_lbl_nt_so_tien_nop_thue.Text = IP.Core.IPCommon.CRead.ChuyenSo(m_dc_tong_tien_nop_thue.ToString());
			//load info Thanh toan cho don vi huong
			m_lbl_ttdvh_don_vi_nhan_tien.Text = v_us.strTTDVH_DON_VI_NHAN_TIEN;
			m_lbl_ttdvh_ma_dvqhns.Text = v_us.strTTDVH_MA_DVQHNS;
			m_lbl_ttdvh_dia_chi.Text = v_us.strTTDVH_DIA_CHI;
			m_lbl_ttdvh_tai_khoan.Text = v_us.strTTDVH_TAI_KHOAN;
			m_lbl_ttdvh_ma_ctmt_da_htct.Text = v_us.strTTDVH_MA_CTMT_DA_VA_HTCT;
			m_lbl_ttdvh_tai_kbnn.Text = v_us.strTTDVH_KHO_BAC;
			m_lbl_ttdvh_so_tien_thanh_toan_dvh.Text = IP.Core.IPCommon.CRead.ChuyenSo(m_dc_tong_tien_thanh_toan_cho_don_vi_huong.ToString());
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
		#endregion

		#region Public Functions


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
			else
			{
				CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
				op_str = String.Format(elGR, "{0:0,0}", v_dc_tt_cho_dv_huong + v_dc_nop_thue);
				//op_str = CIPConvert.ToStr(v_dc_nop_thue + v_dc_tt_cho_dv_huong, "{0:0,0}");
			}
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
				CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
				op_str = String.Format(elGR, "{0:0,0}", v_dc_so_tien);
				//op_str = CIPConvert.ToStr(v_dc_so_tien, "{0:0,0}");
			}

			return op_str;
		}
		#endregion

	}
}