using IP.Core.IPCommon;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for PL01
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL01 : System.Web.Services.WebService
	{

		[WebMethod]
		public void update_giao_dich(decimal ip_dc_id_giao_dich, string ip_str_so_bao_cao, string ip_str_so_xet_duyet)
		{
			try
			{
				using (BKI_QLDTEntities db = new BKI_QLDTEntities())
				{
					GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI gd =
						db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI.Where(x => x.ID == ip_dc_id_giao_dich).FirstOrDefault();
					if (gd != null)
					{
						gd.SO_BAO_CAO = CIPConvert.ToDecimal(ip_str_so_bao_cao.Replace(",", "").Replace(".", ""));
						gd.SO_XET_DUYET = CIPConvert.ToDecimal(ip_str_so_xet_duyet.Replace(",", "").Replace(".", ""));
						db.SaveChanges();
						Context.Response.Output.Write("true");
					}
					else Context.Response.Output.Write("false");
				}
			}
			catch (Exception)
			{
				Context.Response.Output.Write("false");
			}
		}

		
	}
}
