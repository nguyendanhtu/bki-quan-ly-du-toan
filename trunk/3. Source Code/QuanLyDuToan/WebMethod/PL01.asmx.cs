using IP.Core.IPCommon;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using QuanLyDuToan.UserControls;

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
		public void insertFormTemplateToGdPL01(BKI_QLDTEntities ip_db, decimal ip_dc_id_don_vi, int ip_i_nam)
		{
			var lst_temp_pl01 = ip_db.TP_PL01.OrderBy(x=>x.ID).ToList();
			foreach (var tp in lst_temp_pl01)
			{
				GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI gd = new GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI();
				gd.CAP = tp.CAP;
				gd.CHI_TIEU = tp.CHI_TIEU;
				gd.CONG_THUC = tp.CONG_THUC;
				gd.ID_DON_VI =ip_dc_id_don_vi;
				gd.MA_SO = tp.MA_SO;
				gd.MA_SO_PARENT = tp.MA_SO_PARENT;
				gd.NAM = ip_i_nam;
				gd.SO_BAO_CAO = 0;
				gd.SO_XET_DUYET = 0;
				ip_db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI.Add(gd);
				ip_db.SaveChanges();
			}
		}
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

		[WebMethod]
		public void genGrid(decimal ip_dc_id_don_vi, int ip_i_nam)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var lst_pl01 = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
							.Where(x => x.NAM == ip_i_nam && x.ID_DON_VI == ip_dc_id_don_vi)
							.ToList();
			if (lst_pl01.Count==0)
			{
				insertFormTemplateToGdPL01(db, ip_dc_id_don_vi, ip_i_nam);
				//reload list
				lst_pl01 = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
							.Where(x => x.NAM == ip_i_nam && x.ID_DON_VI == ip_dc_id_don_vi)
							.ToList();
			}
			string op_str_grid = "";
			op_str_grid = QT_QBT_GRID_PL01.RenderToString(lst_pl01);
			Context.Response.Write(op_str_grid);
		}

		
	}
}
