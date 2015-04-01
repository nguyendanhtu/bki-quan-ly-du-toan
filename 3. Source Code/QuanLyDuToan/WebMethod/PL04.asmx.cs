using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

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
			,string ip_str_TT
			, string ip_str_ten_loai_nhiem_vu
			, string ip_str_cong_trinh
			, string ip_str_du_an)
		{

		}
	}
}
