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

namespace QuanLyDuToan.ChucNang
{
	public partial class F601_print_giay_rut_du_toan_ngan_sach : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				xoa_trang_info();
				decimal v_dc_id_dm_giai_ngan = WebformFunctions.getValue_from_query_string<decimal>(
										this
										, FormInfo.QueryString.ID_GIAI_NGAN
										, CONST_GIAO_DICH.ID_TAT_CA
										);
				if (v_dc_id_dm_giai_ngan == CONST_GIAO_DICH.ID_TAT_CA) return;
				load_content_print(v_dc_id_dm_giai_ngan);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

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
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			v_us_thong_tin_don_vi.InitByID_DON_VI(v_dc_id_don_vi);
			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI(v_dc_id_don_vi);
			v_us_v_giai_ngan.FillDataset(v_ds, "where " + V_DM_GIAI_NGAN.ID_DON_VI + "=" + v_dc_id_don_vi
				+ " and " + V_DM_GIAI_NGAN.ID + "=" + ip_dc_id_dm_unc);


			//load data to Noi dung thanh toan
			m_grv.DataSource = v_ds.V_DM_GIAI_NGAN;
			m_grv.DataBind();

			decimal v_dc_tong_tien = 0;
			for (int i = 0; i < v_ds.V_DM_GIAI_NGAN.Count; i++)
			{
				v_dc_tong_tien += CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_NOP_THUE])
					+ CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.SO_TIEN_TT_CHO_DV_HUONG]);
			}
			//load info Don vi tra tien
			m_lbl_don_vi_rut_du_toan.Text = v_us_dm_don_vi.strTEN_DON_VI;
			m_lbl_tai_kbns.Text = v_us_thong_tin_don_vi.strKHO_BAC;
			m_lbl_tai_khoan.Text = v_us.strMA_TKKT;
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
			m_lbl_ttdvh_so_tien_thanh_toan.Text = v_us.strTTDVH_SO_TIEN;
			m_lbl_cmnd_so.Text = v_us.strNGUOI_NHAN_TIEN_CMND_SO;
			m_lbl_cap_ngay.Text = v_us.strNGUOI_NHAN_TIEN_CAP_NGAY;
			m_lbl_noi_cap.Text = v_us.strNGUOI_NHAN_TIEN_NOI_CAP;
			m_lbl_ten_ctmt_da.Text = v_us.strTEN_CTMT_DA;
			m_lbl_ma_cap_ns.Text = v_us.strMA_CAP_NS;
			m_lbl_nam_ns.Text = v_us.datNGAY_THANG.Year.ToString();
			m_lbl_so_ckc_hdk.Text = v_us.strSO_CKC_HDK;
			m_lbl_so_ckc_hdth.Text = v_us.strSO_CKC_HDTH;
			if (v_us.strIS_NGUON_NS_YN == "N")
			{
				m_lbl_tai_khoan.Text = v_us_thong_tin_don_vi.strMA_TKKT1;
			}
			else
			{
				m_lbl_tai_khoan.Text = v_us_thong_tin_don_vi.strMA_TKKT2;
			}
			m_ckb_thuc_chi.Checked = getISCheck(v_us.strTHUC_CHI_YN);
			m_ckb_tam_ung.Checked = getISCheck(v_us.strTAM_UNG_YN);
			m_ckb_ung_truoc_chua_du_dk_thanh_toan.Checked = getISCheck(v_us.strUNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN);
			m_ckb_ung_truoc_du_dk_thanh_toan.Checked = getISCheck(v_us.strUNG_TRUOC_DU_DK_THANH_TOAN_YN);
			m_ckb_chuyen_khoan.Checked = getISCheck(v_us.strCHUYEN_KHOAN_YN);
			m_ckb_tien_mat.Checked = getISCheck(v_us.strTIEN_MAT_YN);
		}
		private bool getISCheck(string us_value)
		{
			if (us_value.Trim().ToUpper().Equals("N"))
			{
				return false;
			}
			return true;
		}
		private void xoa_trang_info()
		{
			//load info Don vi tra tien
			m_lbl_don_vi_rut_du_toan.Text = "";
			m_lbl_tai_kbns.Text = "";
			m_lbl_tai_khoan.Text = "";
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
			m_lbl_ttdvh_so_tien_thanh_toan.Text = "";
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

		protected void m_grv_RowCreated(object sender, GridViewRowEventArgs e)
		{
			try
			{
				//Tao header cua grid
				const string v_c_str_header_css_class = "HeaderStyle";
				if (e.Row.RowType == DataControlRowType.Header) // If header created
				{
					GridView v_grv = (GridView)sender;
					//Tao dong 1

					WebformFunctions.addHeaderRow_to_grid_view(v_grv
					, 0
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("Nội dung thanh toán",2,1)
						,new CellInfoHeader("Mã NDKT",2,1)
						,new CellInfoHeader("Mã Chương",2,1)
						,new CellInfoHeader("Mã ngành KT",2,1)
						,new CellInfoHeader("Mã nguồn NSNN",2,1)
						,new CellInfoHeader("Tổng số tiền",2,1)
						,new CellInfoHeader("Chia ra",1,2)
					});
					WebformFunctions.addHeaderRow_to_grid_view(v_grv
					, 1
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("Nộp thuế",1,1)
						,new CellInfoHeader("Thanh toán cho đơn vị hưởng",1,1)
						
					});
					WebformFunctions.addHeaderRow_to_grid_view(v_grv
					, 2
					, v_c_str_header_css_class
					, new CellInfoHeader[] { 
						new CellInfoHeader("(1)",1,1)
						,new CellInfoHeader("(2)",1,1)
						,new CellInfoHeader("(3)",1,1)
						,new CellInfoHeader("(4)",1,1)
						,new CellInfoHeader("(5)",1,1)
						,new CellInfoHeader("(6)=(7)+(8)",1,1)
						,new CellInfoHeader("(7)",1,1)
						,new CellInfoHeader("(8)",1,1)
					});
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
	}
}