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
using System.Globalization;
using System.Threading;

namespace QuanLyDuToan.ChucNang
{
	public partial class F600_print_unc_qbt : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				Session.Add(ExcelExport, Request.QueryString[ExcelExport]);
				xoa_trang_info();
				decimal v_dc_id_dm_giai_ngan=WebformFunctions.getValue_from_query_string<decimal>(
										this
										,FormInfo.QueryString.ID_GIAI_NGAN
										,CONST_GIAO_DICH.ID_TAT_CA
										);
				if (v_dc_id_dm_giai_ngan==CONST_GIAO_DICH.ID_TAT_CA) return;
				load_content_print(v_dc_id_dm_giai_ngan);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
			
		}
		const string ExcelExport = "ExcelExport";
		private void load_content_print(decimal ip_dc_id_dm_unc)
		{
			US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN(ip_dc_id_dm_unc);
			m_lbl_so_unc.Text = v_us.strSO_UNC;
			m_lbl_so_tien_ghi_bang_chu.Text = v_us.strTTDVH_SO_TIEN;
			US_V_DM_GIAI_NGAN v_us_v_giai_ngan = new US_V_DM_GIAI_NGAN();
			DS_V_DM_GIAI_NGAN v_ds = new DS_V_DM_GIAI_NGAN();
			v_ds.EnforceConstraints = false;

			US_DM_THONG_TIN_DON_VI v_us_thong_tin_don_vi = new US_DM_THONG_TIN_DON_VI();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"]!=null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			v_us_thong_tin_don_vi.InitByID_DON_VI(v_dc_id_don_vi);
			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(v_dc_id_don_vi);
			v_us_v_giai_ngan.FillDataset(v_ds, "where " + V_DM_GIAI_NGAN.ID_DON_VI + "=" + v_dc_id_don_vi
				+" and "+V_DM_GIAI_NGAN.ID+"="+ip_dc_id_dm_unc);

			m_lbl_ngay_thang.Text = " " + CIPConvert.ToStr(v_us.datNGAY_THANG, "dd") +
				" tháng " + CIPConvert.ToStr(v_us.datNGAY_THANG, "MM") +
				" năm " + CIPConvert.ToStr(v_us.datNGAY_THANG, "yyyy");
			//load data to Noi dung thanh toan
			m_grv.DataSource = v_ds.V_DM_GIAI_NGAN;
			m_grv.DataBind();

			decimal v_dc_tong_tien=0;
			for (int i = 0; i < v_ds.V_DM_GIAI_NGAN.Count; i++)
			{
			 v_dc_tong_tien+=CIPConvert.ToDecimal( v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE])
				 +CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG]);
			}
			//load info Don vi tra tien
			m_lbl_don_vi_tra_tien.Text = v_us_dm_don_vi.strTEN_DON_VI;
			m_lbl_dia_chi.Text = v_us_thong_tin_don_vi.strDIA_CHI;
			m_lbl_tai_kho_bac_nha_nuoc.Text = v_us_thong_tin_don_vi.strKHO_BAC;
			m_lbl_ma_tkkt.Text = "";
			m_lbl_ma_dvqhns.Text = v_us.strMA_DVQHNS;
			m_lbl_ma_ctmt_da_htct.Text = v_us.strMA_CTMT_DA_HTCT;
			m_lbl_so_tien_ghi_bang_chu.Text = "...........................................................................................................";
			m_lbl_so_tien_ghi_bang_chu.Text = IP.Core.IPCommon.CRead.ChuyenSo(v_dc_tong_tien.ToString());
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
			else 
			{
				CultureInfo elGR = CultureInfo.CreateSpecificCulture("el-GR");
				op_str = String.Format(elGR, "{0:0,0}", v_dc_tt_cho_dv_huong+v_dc_nop_thue);
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

		protected override void Render(HtmlTextWriter writer)
		{
			if (Session[ExcelExport] != null && bool.Parse(Session[ExcelExport].ToString()))
			{

				using (System.IO.StringWriter stringWrite = new System.IO.StringWriter())
				{
					using (HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite))
					{
						base.Render(htmlWrite);
						DownloadExcel(stringWrite.ToString());
					}
				}
			}
			else
			{
				base.Render(writer);
			}
		}

		public void DownloadExcel(string text)
		{
			try
			{
				HttpResponse response = Page.Response;
				response.Clear();
				HttpContext.Current.Response.AddHeader("content-disposition", "attachment;filename=" + "sdfsdfdsfds.xls");
				HttpContext.Current.Response.Charset = "UTF-8";
				HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.UTF8;
				HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
				HttpContext.Current.Response.Cache.SetCacheability(System.Web.HttpCacheability.NoCache);
				response.Write(text);
				response.Flush();
				response.End();
			}
			catch (ThreadAbortException)
			{
				//If the download link is pressed we will get a thread abort.
			}
		}
	}
}