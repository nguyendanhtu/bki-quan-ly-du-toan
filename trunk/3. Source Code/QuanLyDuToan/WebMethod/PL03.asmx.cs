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
	/// Summary description for PL03
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL03 : System.Web.Services.WebService
	{

		[WebMethod]
		public void UpdateGiaoDich(
			decimal ip_dc_id_giao_dich
			, string ip_str_SKNKTNN
			, string ip_str_SKNCQTC
			, string ip_str_SDNKTNN
			, string ip_str_SDNCQTC
			)
		{
			try
			{
				using (BKI_QLDTEntities db = new BKI_QLDTEntities())
				{
					GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH gd
						= db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH.FirstOrDefault(x => x.ID == ip_dc_id_giao_dich);
					gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC = CIPConvert.ToDecimal(ip_str_SKNKTNN.Replace(",", "").Replace(".", "").Trim());
					gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH = CIPConvert.ToDecimal(ip_str_SKNCQTC.Replace(",", "").Replace(".", "").Trim());
					gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC = CIPConvert.ToDecimal(ip_str_SDNKTNN.Replace(",", "").Replace(".", "").Trim());
					gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH = CIPConvert.ToDecimal(ip_str_SDNCQTC.Replace(",", "").Replace(".", "").Trim());
					db.SaveChanges();
				}
			}
			catch (Exception v_e)
			{
				Context.Response.Output.Write("Loi: "+v_e.Message);
			}
			
		}
	}
}
