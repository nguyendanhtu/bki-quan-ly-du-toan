using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using IP.Core.IPCommon;
using WebUS;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for PL04
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL04 : System.Web.Services.WebService
	{

		[WebMethod]
		public void UpdateGiaoDich(
			decimal ip_dc_id_giao_dich
			, string ip_str_ten_loai_nhiem_vu
			, string ip_str_cong_trinh
			, string ip_str_du_an
			, string ip_str_GTDTCongTrinhDuocDuyet
			, string ip_str_GTCTHTNamTruocConNoChuyenSangNamNay
			, string ip_str_GTCTHTNamNay
			, string ip_str_GTDNQTTrongNam
			, string ip_str_GTCTHTDQTLKDenNamBaoCao
			)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var lst_lnv = db.CM_DM_TU_DIEN.Where(x => x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU || x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS).ToList();
			GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN gd = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN.FirstOrDefault(x => x.ID == ip_dc_id_giao_dich);
			gd.TT = lst_lnv.FirstOrDefault(x => x.TEN.ToUpper() == ip_str_ten_loai_nhiem_vu.Trim().ToUpper()).GHI_CHU;
			gd.TEN_LOAI_NHIEM_VU = ip_str_ten_loai_nhiem_vu.Trim();
			gd.CONG_TRINH = ip_str_cong_trinh.Trim();
			gd.DU_AN = ip_str_du_an.Trim();
			gd.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET = CIPConvert.ToDecimal(ip_str_GTDTCongTrinhDuocDuyet.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY = CIPConvert.ToDecimal(ip_str_GTCTHTNamTruocConNoChuyenSangNamNay.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_NAM_NAY = CIPConvert.ToDecimal(ip_str_GTCTHTNamNay.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM = CIPConvert.ToDecimal(ip_str_GTDNQTTrongNam.Trim().Replace(",", "").Replace(".", ""));
			gd.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO = CIPConvert.ToDecimal(ip_str_GTCTHTDQTLKDenNamBaoCao.Trim().Replace(",", "").Replace(".", ""));
			db.SaveChanges();

		}
	}
}
