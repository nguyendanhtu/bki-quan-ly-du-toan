using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using IP.Core.IPCommon;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for PL05
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL05 : System.Web.Services.WebService
	{
		[WebMethod]
		public void DeleteGiaoDich(decimal ip_dc_id_giao_dich)
		{
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN gd = new GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN();
				db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN.Remove(gd);
				db.SaveChanges();
			}
		}
		[WebMethod]
		public void UpdateGiaoDich(
				decimal ip_dc_id_giao_dich
				,string ip_str_ten_loai_nhiem_vu
				, string ip_str_cong_trinh
				, string ip_str_du_an
				, decimal ip_dc_id_don_vi
				, decimal ip_dc_nam
				, string ip_str_I_GTKLDQT
				, string ip_str_I_GTKLCTHTTN
				, string ip_str_II_GTKLDQT
				, string ip_str_II_GTKLCTHTTN
				, string ip_str_III_1_GTKLDQT
				, string ip_str_III_1_GTKLCTHTTN
				, string ip_str_III_2_GTKLDQT
				, string ip_str_III_2_GTKLCTHTTN
				, string ip_str_III_3_GTKLDQT
				, string ip_str_III_3_GTKLCTHTTN
				, string ip_str_IV_1_GTKLDQT
				, string ip_str_IV_1_GTKLCTHTTN
				, string ip_str_IV_2_GTKLDQT
				, string ip_str_IV_2_GTKLCTHTTN
				, string ip_str_IV_3_GTKLDQT
				, string ip_str_IV_3_GTKLCTHTTN
				, string ip_str_IV_4_GTKLDQT
				, string ip_str_IV_4_GTKLCTHTTN
				, string ip_str_V_GTKLDQT
				, string ip_str_V_GTKLCTHTTN
				)
		{
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN gd;
				if (ip_dc_id_giao_dich < 0)
				{
					gd = new GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN();
					gd.NAM = ip_dc_nam;
					gd.ID_DON_VI = ip_dc_id_don_vi;
					gd.CONG_TRINH = ip_str_cong_trinh.Trim();
					gd.DU_AN = ip_str_du_an.Trim();
					gd.TEN_LOAI_NHIEM_VU = ip_str_ten_loai_nhiem_vu.Trim();
				}
				else gd = db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN.FirstOrDefault(x => x.ID == ip_dc_id_giao_dich);
				gd.I_GTKLDQT = CIPConvert.ToDecimal(ip_str_I_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.I_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_I_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.II_GTKLDQT = CIPConvert.ToDecimal(ip_str_II_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.II_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_II_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.III_1_GTKLDQT = CIPConvert.ToDecimal(ip_str_III_1_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.III_1_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_III_1_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.III_2_GTKLDQT = CIPConvert.ToDecimal(ip_str_III_2_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.III_2_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_III_2_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.III_3_GTKLDQT = CIPConvert.ToDecimal(ip_str_III_3_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.III_3_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_III_3_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.IV_1_GTKLDQT = CIPConvert.ToDecimal(ip_str_IV_1_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.IV_1_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_IV_1_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.IV_2_GTKLDQT = CIPConvert.ToDecimal(ip_str_IV_2_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.IV_2_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_IV_2_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.IV_3_GTKLDQT = CIPConvert.ToDecimal(ip_str_IV_3_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.IV_3_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_IV_3_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.IV_4_GTKLDQT = CIPConvert.ToDecimal(ip_str_IV_4_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.IV_4_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_IV_4_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				gd.V_GTKLDQT = CIPConvert.ToDecimal(ip_str_V_GTKLDQT.Replace(",", "").Replace(".", ""));
				gd.V_GTKLCTHTTN = CIPConvert.ToDecimal(ip_str_V_GTKLCTHTTN.Replace(",", "").Replace(".", ""));
				if (ip_dc_id_giao_dich < 0)
				{
					db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN.Add(gd);
				}
				db.SaveChanges();

			}


		}
	}
}