﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using QuanLyDuToan.App_Code;
using IP.Core.IPCommon;
using System.Web.Script.Serialization;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for F505
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class F505 : System.Web.Services.WebService
	{
		public string getMaSoChildrenByMaSoParent(string ip_str_ma_so_parent, List<GD_DU_TOAN_THU_CHI_PHI_PHA> ip_lst_children)
		{
			string v_str_ma_so = "";
			Int32 v_i_max_sufix;
			//Neu chua co children
			if (ip_lst_children.Count() == 0)
			{
				v_i_max_sufix = 101;
			}
			else
			{
				//Neu da co children
				v_i_max_sufix = ip_lst_children.Select(x => Convert.ToInt32(x.MA_SO.Replace(ip_str_ma_so_parent, ""))).Max() + 1;
			}
			v_str_ma_so = ip_str_ma_so_parent + v_i_max_sufix.ToString();
			return v_str_ma_so;
		}

		public static decimal getMoney_number(object ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien == DBNull.Value)
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
			return op_dc_so_tien;
		}

		[WebMethod]
		public void genGrid(decimal ip_dc_id_quyet_dinh, decimal ip_dc_id_don_vi)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var v_lst_du_toan_thu_chi_phi_pha = db.GD_DU_TOAN_THU_CHI_PHI_PHA
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.ID_QUYET_DINH == ip_dc_id_quyet_dinh)
											.OrderBy(x => x.MA_SO.Substring(0, 4))
											.ThenBy(x => x.MA_SO_PARENT)
											.ThenBy(x => x.TT)
											.ToList();
			var result = "";
			result = UserControls.F505Grid.RenderToString(v_lst_du_toan_thu_chi_phi_pha);
			Context.Response.Output.Write(result);
		}

		[WebMethod]
		public void InsertItem(decimal ip_dc_id_quyet_dinh
			, decimal ip_dc_id_don_vi
			, decimal ip_dc_id_parent
			, string ip_str_tt
			, string ip_str_hang_muc
			, string ip_str_kinh_phi_giao
			, string ip_str_KLTH_QUY_I
			, string ip_str_KLTH_QUY_II
			, string ip_str_KLTH_QUY_III
			, string ip_str_KLTH_QUY_IV
			, string ip_str_GHI_CHU_GIAO_KH
			, string ip_str_GHI_CHU_QUY_I
			, string ip_str_GHI_CHU_QUY_II
			, string ip_str_GHI_CHU_QUY_III
			, string ip_str_GHI_CHU_QUY_IV
			, string ip_str_PHAN_BO_QUI_I
			, string ip_str_PHAN_BO_QUY_II
			, string ip_str_PHAN_BO_QUY_III
			, string ip_str_PHAN_BO_QUY_IV
			, string ip_str_GHI_CHU_PHAN_BO_QUY_I
			, string ip_str_GHI_CHU_PHAN_BO_QUY_II
			, string ip_str_GHI_CHU_PHAN_BO_QUY_III
			, string ip_str_GHI_CHU_PHAN_BO_QUY_IV
)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var qd = db.DM_QUYET_DINH.FirstOrDefault(x => x.ID == ip_dc_id_quyet_dinh);
			var gd_parent = db.GD_DU_TOAN_THU_CHI_PHI_PHA.FirstOrDefault(x => x.ID == ip_dc_id_parent);
			var lst_children = db.GD_DU_TOAN_THU_CHI_PHI_PHA
									.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh
											&& x.ID_DON_VI == ip_dc_id_don_vi
											&& x.MA_SO_PARENT == gd_parent.MA_SO)
									.ToList();
			GD_DU_TOAN_THU_CHI_PHI_PHA gd = new GD_DU_TOAN_THU_CHI_PHI_PHA();
			gd.ID_DON_VI = ip_dc_id_don_vi;
			gd.ID_QUYET_DINH = ip_dc_id_quyet_dinh;
			gd.MA_SO = getMaSoChildrenByMaSoParent(gd_parent.MA_SO, lst_children);
			gd.MA_SO_PARENT = gd_parent.MA_SO; ;
			gd.TT = ip_str_tt;
			gd.HANG_MUC = ip_str_hang_muc;
			gd.KINH_PHI_GIAO_KH = getMoney_number(ip_str_kinh_phi_giao.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_I = getMoney_number(ip_str_KLTH_QUY_I.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_II = getMoney_number(ip_str_KLTH_QUY_II.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_III = getMoney_number(ip_str_KLTH_QUY_III.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_IV = getMoney_number(ip_str_KLTH_QUY_IV.Replace(",", "").Replace(".", ""));
			gd.GHI_CHU_GIAO_KH = ip_str_GHI_CHU_GIAO_KH;
			gd.GHI_CHU_QUY_I = ip_str_GHI_CHU_QUY_I;
			gd.GHI_CHU_QUY_II = ip_str_GHI_CHU_QUY_II;
			gd.GHI_CHU_QUY_III = ip_str_GHI_CHU_QUY_III;
			gd.GHI_CHU_QUY_IV = ip_str_GHI_CHU_QUY_IV;

			gd.PHAN_BO_QUI_I = getMoney_number(ip_str_PHAN_BO_QUI_I.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_II = getMoney_number(ip_str_PHAN_BO_QUY_II.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_III = getMoney_number(ip_str_PHAN_BO_QUY_III.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_IV = getMoney_number(ip_str_PHAN_BO_QUY_IV.Replace(",", "").Replace(".", "")); ;
			gd.GHI_CHU_PHAN_BO_QUY_I = ip_str_GHI_CHU_PHAN_BO_QUY_I;
			gd.GHI_CHU_PHAN_BO_QUY_II = ip_str_GHI_CHU_PHAN_BO_QUY_II;
			gd.GHI_CHU_PHAN_BO_QUY_III = ip_str_GHI_CHU_PHAN_BO_QUY_III;
			gd.GHI_CHU_PHAN_BO_QUY_IV = ip_str_GHI_CHU_PHAN_BO_QUY_IV;


			gd.NAM = (decimal)qd.NGAY_THANG.Year;
			gd.IS_FIX = false;
			//gd.ID_PHA==?;
			db.GD_DU_TOAN_THU_CHI_PHI_PHA.Add(gd);
			db.SaveChanges();
		}

		[WebMethod]
		public void SaveItem(decimal ip_dc_id_quyet_dinh
			, decimal ip_dc_id_don_vi
			, decimal ip_dc_id_giao_dich
			, string ip_str_tt
			, string ip_str_hang_muc
			, string ip_str_kinh_phi_giao
			, string ip_str_KLTH_QUY_I
			, string ip_str_KLTH_QUY_II
			, string ip_str_KLTH_QUY_III
			, string ip_str_KLTH_QUY_IV
			, string ip_str_GHI_CHU_GIAO_KH
			, string ip_str_GHI_CHU_QUY_I
			, string ip_str_GHI_CHU_QUY_II
			, string ip_str_GHI_CHU_QUY_III
			, string ip_str_GHI_CHU_QUY_IV
			, string ip_str_PHAN_BO_QUI_I
			, string ip_str_PHAN_BO_QUY_II
			, string ip_str_PHAN_BO_QUY_III
			, string ip_str_PHAN_BO_QUY_IV
			, string ip_str_GHI_CHU_PHAN_BO_QUY_I
			, string ip_str_GHI_CHU_PHAN_BO_QUY_II
			, string ip_str_GHI_CHU_PHAN_BO_QUY_III
			, string ip_str_GHI_CHU_PHAN_BO_QUY_IV)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var gd = db.GD_DU_TOAN_THU_CHI_PHI_PHA.First(x => x.ID == ip_dc_id_giao_dich);
			if (gd == null) return;
			gd.TT = ip_str_tt;
			gd.HANG_MUC = ip_str_hang_muc;
			gd.KINH_PHI_GIAO_KH = getMoney_number(ip_str_kinh_phi_giao.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_I = getMoney_number(ip_str_KLTH_QUY_I.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_II = getMoney_number(ip_str_KLTH_QUY_II.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_III = getMoney_number(ip_str_KLTH_QUY_III.Replace(",", "").Replace(".", ""));
			gd.KLTH_QUY_IV = getMoney_number(ip_str_KLTH_QUY_IV.Replace(",", "").Replace(".", ""));
			gd.GHI_CHU_GIAO_KH = ip_str_GHI_CHU_GIAO_KH;
			gd.GHI_CHU_QUY_I = ip_str_GHI_CHU_QUY_I;
			gd.GHI_CHU_QUY_II = ip_str_GHI_CHU_QUY_II;
			gd.GHI_CHU_QUY_III = ip_str_GHI_CHU_QUY_III;
			gd.GHI_CHU_QUY_IV = ip_str_GHI_CHU_QUY_IV;

			gd.PHAN_BO_QUI_I = getMoney_number(ip_str_PHAN_BO_QUI_I.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_II = getMoney_number(ip_str_PHAN_BO_QUY_II.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_III = getMoney_number(ip_str_PHAN_BO_QUY_III.Replace(",", "").Replace(".", "")); ;
			gd.PHAN_BO_QUY_IV = getMoney_number(ip_str_PHAN_BO_QUY_IV.Replace(",", "").Replace(".", "")); ;
			gd.GHI_CHU_PHAN_BO_QUY_I = ip_str_GHI_CHU_PHAN_BO_QUY_I;
			gd.GHI_CHU_PHAN_BO_QUY_II = ip_str_GHI_CHU_PHAN_BO_QUY_II;
			gd.GHI_CHU_PHAN_BO_QUY_III = ip_str_GHI_CHU_PHAN_BO_QUY_III;
			gd.GHI_CHU_PHAN_BO_QUY_IV = ip_str_GHI_CHU_PHAN_BO_QUY_IV;
			db.SaveChanges();
		}

		[WebMethod]
		public void deleteItem(decimal ip_dc_id_giao_dich)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var gd = db.GD_DU_TOAN_THU_CHI_PHI_PHA.First(x => x.ID == ip_dc_id_giao_dich);
			if (gd == null) return;
			db.GD_DU_TOAN_THU_CHI_PHI_PHA.Remove(gd);
			db.SaveChanges();
		}

		[WebMethod]
		public void UpdateAll(string ip_str_arr)
		{
			try
			{
				JavaScriptSerializer js = new JavaScriptSerializer();
				ItemF505[] ip_arr = js.Deserialize<ItemF505[]>(ip_str_arr);
				BKI_QLDTEntities db = new BKI_QLDTEntities();
				for (int i = 0; i < ip_arr.Length; i++)
				{
					decimal id_gd = ip_arr[i].ip_dc_id_giao_dich;
					var gd = db.GD_DU_TOAN_THU_CHI_PHI_PHA.FirstOrDefault(x => x.ID == id_gd);
					if (gd == null) continue;
					gd.TT = ip_arr[i].ip_str_tt;
					gd.HANG_MUC = ip_arr[i].ip_str_hang_muc;
					gd.KINH_PHI_GIAO_KH = convertToDecimal(ip_arr[i].ip_str_kinh_phi_giao);
					gd.KLTH_QUY_I = convertToDecimal(ip_arr[i].ip_str_KLTH_QUY_I);
					gd.KLTH_QUY_II = convertToDecimal(ip_arr[i].ip_str_KLTH_QUY_II);
					gd.KLTH_QUY_III = convertToDecimal(ip_arr[i].ip_str_KLTH_QUY_III);
					gd.KLTH_QUY_IV = convertToDecimal(ip_arr[i].ip_str_KLTH_QUY_IV);
					gd.GHI_CHU_GIAO_KH = ip_arr[i].ip_str_GHI_CHU_GIAO_KH;
					gd.GHI_CHU_QUY_I = ip_arr[i].ip_str_GHI_CHU_QUY_I;
					gd.GHI_CHU_QUY_II = ip_arr[i].ip_str_GHI_CHU_QUY_II;
					gd.GHI_CHU_QUY_III = ip_arr[i].ip_str_GHI_CHU_QUY_III;
					gd.GHI_CHU_QUY_IV = ip_arr[i].ip_str_GHI_CHU_QUY_IV;

					gd.PHAN_BO_QUI_I = convertToDecimal(ip_arr[i].ip_str_PHAN_BO_QUY_I); ;
					gd.PHAN_BO_QUY_II = convertToDecimal(ip_arr[i].ip_str_PHAN_BO_QUY_II); ;
					gd.PHAN_BO_QUY_III = convertToDecimal(ip_arr[i].ip_str_PHAN_BO_QUY_III); ;
					gd.PHAN_BO_QUY_IV = convertToDecimal(ip_arr[i].ip_str_PHAN_BO_QUY_IV); ;
					gd.GHI_CHU_PHAN_BO_QUY_I = ip_arr[i].ip_str_GHI_CHU_PHAN_BO_QUY_I;
					gd.GHI_CHU_PHAN_BO_QUY_II = ip_arr[i].ip_str_GHI_CHU_PHAN_BO_QUY_II;
					gd.GHI_CHU_PHAN_BO_QUY_III = ip_arr[i].ip_str_GHI_CHU_PHAN_BO_QUY_III;
					gd.GHI_CHU_PHAN_BO_QUY_IV = ip_arr[i].ip_str_GHI_CHU_PHAN_BO_QUY_IV;
					db.SaveChanges();
				}
			}
			catch (Exception v_e)
			{
				Context.Response.Write(v_e.Message);
			}
		}

		public class ItemF505
		{
			public decimal ip_dc_id_giao_dich { get; set; }
			public string ip_str_tt { set; get; }
			public string ip_str_hang_muc { get; set; }
			public string ip_str_kinh_phi_giao { get; set; }
			public string ip_str_KLTH_QUY_I { get; set; }
			public string ip_str_KLTH_QUY_II { get; set; }
			public string ip_str_KLTH_QUY_III{get;set;}
			public string ip_str_KLTH_QUY_IV { get; set; }
			public string ip_str_GHI_CHU_GIAO_KH { get; set; }
			public string ip_str_GHI_CHU_QUY_I { get; set; }
			public string ip_str_GHI_CHU_QUY_II { get; set; }
			public string ip_str_GHI_CHU_QUY_III { get; set; }
			public string ip_str_GHI_CHU_QUY_IV { get; set; }
			public string ip_str_PHAN_BO_QUY_I { get; set; }
			public string ip_str_PHAN_BO_QUY_II { get; set; }
			public string ip_str_PHAN_BO_QUY_III { get; set; }
			public string ip_str_PHAN_BO_QUY_IV { get; set; }
			public string ip_str_GHI_CHU_PHAN_BO_QUY_I { get; set; }
			public string ip_str_GHI_CHU_PHAN_BO_QUY_II { get; set; }
			public string ip_str_GHI_CHU_PHAN_BO_QUY_III { get; set; }
			public string ip_str_GHI_CHU_PHAN_BO_QUY_IV { get; set; }

		}

		public decimal convertToDecimal(string ip_str)
		{
			decimal op = 0;
			if (!string.IsNullOrEmpty(ip_str))
			{
				op=CIPConvert.ToDecimal(ip_str.Trim().Replace(",", "").Replace(".", ""));
			}
			return op;
		}
	}
}