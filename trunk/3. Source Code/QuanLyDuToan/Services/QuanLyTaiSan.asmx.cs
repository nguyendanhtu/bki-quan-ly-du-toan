using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SqlDataAccessQuanLyTaiSan;
using Newtonsoft.Json;

namespace QuanLyDuToan.Services
{
	/// <summary>
	/// Summary description for QuanLyTaiSan
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class QuanLyTaiSan : System.Web.Services.WebService
	{

		[WebMethod]
		public void getInfo()
		{
			QuanLyTaiSanInfo info = new QuanLyTaiSanInfo();
			using (BKI_QLTSEntities db=new BKI_QLTSEntities())
			{
				info.dcSoNha = db.DM_NHA.Count(x => x.ID_TRANG_THAI == 580);//Trang thai 1-Đang sử dụng
				info.dcSoOto = db.DM_OTO.Count(x => x.ID_TRANG_THAI == 584);//Trang thai 1-Đang sử dụng
				info.dcSoTaiSanKhac = db.DM_TAI_SAN_KHAC.Count(x => x.ID_TRANG_THAI == 588);//Trang thai 1-Đang sử dụng
				info.dcSoDat = db.DM_DAT.Count(x => x.ID_TRANG_THAI == 597);//Trang thai 1-Đang sử dụng
			}
			Context.Response.Write(JsonConvert.SerializeObject(info));
		}
	}

	public class QuanLyTaiSanInfo
	{
		public decimal dcSoNha { get; set; }
		public decimal dcSoOto { get; set; }
		public decimal dcSoTaiSanKhac { get; set; }
		public decimal dcSoDat { get; set; }
	}
}
