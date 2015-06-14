using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using System.Globalization;
using SQLDataAccess;
using WebUS;
using DBClassModel;
using Framework.Extensions;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.Test
{
	public partial class t : System.Web.UI.Page
	{

		protected void Page_Load(object sender, EventArgs e)
		{
			m_dat_tu_ngay = new DateTime(2015, 06, 01);
			m_dat_den_ngay = new DateTime(2015, 06, 13);
			m_dat_dau_nam = new DateTime(2015, 01, 01);
			m_dc_id_don_vi = 5;

			BKI_QLDTEntities db = new BKI_QLDTEntities();

			m_lst_loai_nhiem_vu = db.CM_DM_TU_DIEN
									.Where(x => x.ID_LOAI_TU_DIEN == WebUS.ID_LOAI_TU_DIEN.LOAI_NHIEM_VU
										|| x.ID == WebUS.ID_LOAI_NHIEM_VU_NS.DU_TOAN_CHI_NS_NN)
									.OrderBy(x => x.ID_LOAI_TU_DIEN)
									.ThenBy(x => x.GHI_CHU)
									.ToList();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
		}
		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;

		public decimal m_dc_id_don_vi;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;
		public List<SQLDataAccess.CM_DM_TU_DIEN> m_lst_loai_nhiem_vu;

		public string format_link_to_chi_tiet(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns
								, string ip_str_form_name
								, double value)
		{
			string v_dat_tu_ngay = CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy");
			string v_dat_den_ngay = CIPConvert.ToStr(m_dat_den_ngay,"dd/MM/yyyy");
			string v_str_link = "<a href='" + ip_str_form_name;
			if (ip_level != DBNull.Value)
			{
				if (ip_id_don_vi == DBNull.Value) ip_id_don_vi = -1;
				if (ip_id_loai_nhiem_vu == DBNull.Value) ip_id_loai_nhiem_vu = -1;
				if (ip_id_cong_trinh == DBNull.Value) ip_id_cong_trinh = -1;
				if (ip_id_du_an == DBNull.Value) ip_id_du_an = -1;
				switch (CIPConvert.ToStr(ip_level))
				{
					//lv 1: get link theo loai nhiem vu
					case "1":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + "-1"
									 + "&ip_dc_id_du_an=" + "-1"
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									  + "&ip_dc_id_quyet_dinh =" + "-1";
						break;
					//lv2: get link theo cong trinh
					case "2":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//lv3: get link theo du an
					case "3":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									  + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					default:
						//get link theo du an
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
							//+ "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WinFormControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									  + "&ip_dat_tu_ngay=" + v_dat_tu_ngay
									 + "&ip_dat_den_ngay=" + v_dat_den_ngay
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
				v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns + "'>" + CIPConvert.ToStr(value, "#,##0");
			}
			return v_str_link;
		}

		public string format_link_to_chi_tiet_trong_thang(
								object ip_level
								, object ip_id_don_vi
								, object ip_id_loai_nhiem_vu
								, object ip_id_cong_trinh
								, object ip_id_du_an
								, string ip_str_nguon_ns
								, string ip_str_form_name
								, double value)
		{
			if (ip_id_don_vi == DBNull.Value) ip_id_don_vi = -1;
			if (ip_id_loai_nhiem_vu == DBNull.Value) ip_id_loai_nhiem_vu = -1;
			if (ip_id_cong_trinh == DBNull.Value) ip_id_cong_trinh = -1;
			if (ip_id_du_an == DBNull.Value) ip_id_du_an = 10;
			string v_str_link = "<a href='"+ip_str_form_name;
			if (ip_level != DBNull.Value)
			{
				switch (CIPConvert.ToStr(ip_level))
				{
					//lv3: get link theo loai nhiem vu
					case "3":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + "-1"
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay,"dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";

						break;
					//lv2: get link theo cong trinh 
					case "2":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + "-1"
									 + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay,"dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//lv1: get link theo lv du an
					case "1":
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(m_dat_dau_nam, "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay,"dd/MM/yyyy")
									 + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
					//get link theo du an
					default:
						v_str_link += "?ip_dc_id_don_vi=" + CIPConvert.ToStr(ip_id_don_vi)
									 + "&ip_dc_id_loai_nhiem_vu=" + CIPConvert.ToStr(ip_id_loai_nhiem_vu)
									 + "&ip_dc_id_cong_trinh=" + CIPConvert.ToStr(ip_id_cong_trinh)
									 + "&ip_dc_id_du_an=" + CIPConvert.ToStr(ip_id_du_an)
									  + "&ip_dat_tu_ngay=" + CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(CIPConvert.ToDatetime(CIPConvert.ToStr(m_dat_tu_ngay,"dd/MM/yyyy"), "dd/MM/yyyy")), "dd/MM/yyyy")
									 + "&ip_dat_den_ngay=" + CIPConvert.ToStr(m_dat_den_ngay,"dd/MM/yyyy")
									  + "&ip_dc_id_quyet_dinh=" + "-1";
						break;
				}
			}
			v_str_link += "&ip_nguon_ns=" + ip_str_nguon_ns+"'>"+CIPConvert.ToStr(value,"#,##0");
			return v_str_link;
		}


	}
}