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
			System.Threading.Thread.Sleep(500);
			Context.Response.Output.Write("true");
		}
	}
}
