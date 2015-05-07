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
		private void InsertFromTemplate(decimal ip_dc_id_don_vi, decimal ip_dc_nam)
		{
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				var lst_Pl03_template = db.TP_PL03.ToList();
				var lst_gdPL03 = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
					.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
								&& x.NAM == ip_dc_nam)
					.ToList();
				//Insert to GD_PL03 from Templete PL03 if do not have
				foreach (var temp in lst_Pl03_template)
				{
					if (lst_gdPL03
						.Where(x => x.MA_SO.Trim() == temp.MA_SO.Trim()
									&& x.NOI_DUNG.Trim() == temp.NOI_DUNG.Trim()
									&& x.MA_SO_PARENT == temp.MA_SO_PARENT)
						.ToList().Count < 1)
					{
						GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH gd = new GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH();
						gd.MA_SO = temp.MA_SO;
						gd.ID_DON_VI = ip_dc_id_don_vi;
						gd.MA_SO_PARENT = temp.MA_SO_PARENT;
						gd.NAM = ip_dc_nam;
						gd.NOI_DUNG = temp.NOI_DUNG;
						gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH = temp.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH;
						gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC = temp.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC;
						gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH = temp.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH;
						gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC = temp.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC;
						gd.TT = temp.TT;
						db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH.Add(gd);
						db.SaveChanges();
					}

					//Delete from GD_PL03 if not exist in Templete PL03
					foreach (var gd in lst_gdPL03)
					{
						if (lst_Pl03_template
							.Where(x => x.MA_SO.Trim() == gd.MA_SO.Trim()
									&& x.NOI_DUNG.Trim() == gd.NOI_DUNG.Trim()
									&& x.MA_SO_PARENT == gd.MA_SO_PARENT)
						.ToList().Count < 1)
						{
							lst_gdPL03.Remove(gd);
							db.SaveChanges();
						}
					}
				}


			}
		}

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

		[WebMethod]
		public void genGrid(decimal ip_dc_id_don_vi, int ip_i_nam)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			InsertFromTemplate(ip_dc_id_don_vi, ip_i_nam);
			var lst_pl03 = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
				.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_i_nam)
				.ToList();
			string v_str_grid = UserControls.QT_QBT_GRID_PL03.RenderToString(lst_pl03);
			Context.Response.Write(v_str_grid);
		}
	}
}
