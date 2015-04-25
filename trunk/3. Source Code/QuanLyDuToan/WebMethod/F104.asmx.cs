using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for F104
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	//[System.Web.Script.Services.ScriptService]
	public class F104 : System.Web.Services.WebService
	{

		[WebMethod]
		public void UpdateGiaoDich(
					decimal ip_dc_ID
					, decimal ip_dc_ID_QUYET_DINH
					, decimal ip_dc_ID_DON_VI
					, string ip_str_CONG_TRINH
					, decimal ip_dc_SO_TIEN_QUY_BT
					, decimal ip_dc_SO_TIEN_NS
					, decimal ip_dc_ID_CHUONG
					, decimal ip_dc_ID_KHOAN
					, decimal ip_dc_ID_MUC
					, string ip_str_GHI_CHU
					, decimal ip_dc_ID_TIEU_MUC
					, decimal ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG
					, decimal ip_dc_ID_LOAI_NHIEM_VU
					, string ip_str_DU_AN
					, string ip_str_TU_CHU_YN
					, string ip_str_GHI_CHU_1
					, string ip_str_GHI_CHU_2
					, string ip_str_GHI_CHU_3
					, string ip_str_GHI_CHU_4
			)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			GD_CHI_TIET_GIAO_KH gd;
			if (ip_dc_ID == -1)
			{
				gd = new GD_CHI_TIET_GIAO_KH();
			}
			else
				gd = db.GD_CHI_TIET_GIAO_KH.FirstOrDefault(x => x.ID == ip_dc_ID);
			if (gd == null) return;
			gd.ID_QUYET_DINH = ip_dc_ID_QUYET_DINH;
			gd.ID_DON_VI = ip_dc_ID_DON_VI;
			gd.SO_TIEN_QUY_BT = ip_dc_SO_TIEN_QUY_BT;
			gd.SO_TIEN_NS = ip_dc_SO_TIEN_NS;
			if (ip_dc_ID_CHUONG == -1) gd.ID_CHUONG = null;
			else gd.ID_CHUONG = ip_dc_ID_CHUONG;
			if (ip_dc_ID_KHOAN == -1) gd.ID_KHOAN = null;
			else gd.ID_KHOAN = ip_dc_ID_KHOAN;
			if (ip_dc_ID_MUC == -1) gd.ID_MUC = null;
			else gd.ID_MUC = ip_dc_ID_MUC;
			gd.GHI_CHU = ip_str_GHI_CHU.Equals("-1")?null:ip_str_GHI_CHU;
			if (ip_dc_ID_TIEU_MUC == -1) gd.ID_TIEU_MUC = null;
			else gd.ID_TIEU_MUC = ip_dc_ID_TIEU_MUC;
			gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG;
			gd.ID_LOAI_NHIEM_VU = ip_dc_ID_LOAI_NHIEM_VU;

			//Xu ly du lieu, lay id cong trinh, id du an
			DM_CONG_TRINH_DU_AN_GOI_THAU v_cong_trinh = db.DM_CONG_TRINH_DU_AN_GOI_THAU
				.FirstOrDefault(x => x.TEN.Trim() == ip_str_CONG_TRINH.Trim());
			DM_CONG_TRINH_DU_AN_GOI_THAU v_du_an = db.DM_CONG_TRINH_DU_AN_GOI_THAU
				.FirstOrDefault(x => x.TEN.Trim() == ip_str_DU_AN.Trim()
					&& x.ID_CHA == v_cong_trinh.ID);

			//Neu cong trinh khong co trong csdl thi insert vao 
			if (v_cong_trinh == null)
			{
				v_cong_trinh = new DM_CONG_TRINH_DU_AN_GOI_THAU();
				v_cong_trinh.ID_DON_VI = ip_dc_ID_DON_VI;
				v_cong_trinh.ID_LOAI = WebUS.ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH;
				v_cong_trinh.TEN = ip_str_CONG_TRINH;
				db.DM_CONG_TRINH_DU_AN_GOI_THAU.Add(v_cong_trinh);
				db.SaveChanges();
				v_cong_trinh = db.DM_CONG_TRINH_DU_AN_GOI_THAU.FirstOrDefault(x => x.TEN.Trim() == ip_str_CONG_TRINH.Trim());
			}
			if (v_du_an == null)
			{
				v_du_an = new DM_CONG_TRINH_DU_AN_GOI_THAU();
				v_du_an.ID_CHA = v_cong_trinh.ID;
				v_du_an.TEN = ip_str_DU_AN;
				v_du_an.ID_LOAI = WebUS.ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN;
				db.DM_CONG_TRINH_DU_AN_GOI_THAU.Add(v_du_an);
				db.SaveChanges();
				v_du_an = db.DM_CONG_TRINH_DU_AN_GOI_THAU.FirstOrDefault(x => x.TEN.Trim() == ip_str_DU_AN.Trim());
			}
			gd.ID_CONG_TRINH = v_cong_trinh.ID;
			gd.ID_DU_AN = v_du_an.ID;
			gd.TU_CHU_YN = (ip_str_TU_CHU_YN.Equals("-1") ? null : ip_str_TU_CHU_YN);
			gd.GHI_CHU_1 = (ip_str_GHI_CHU_1.Equals("-1") ? null : ip_str_GHI_CHU_1);
			gd.GHI_CHU_2 = (ip_str_GHI_CHU_2.Equals("-1") ? null : ip_str_GHI_CHU_2);
			gd.GHI_CHU_3 = (ip_str_GHI_CHU_3.Equals("-1") ? null : ip_str_GHI_CHU_3);
			gd.GHI_CHU_4 = (ip_str_GHI_CHU_4.Equals("-1") ? null : ip_str_GHI_CHU_4);
			if (ip_dc_ID == -1)
			{
				db.GD_CHI_TIET_GIAO_KH.Add(gd);
			}
			db.SaveChanges();
		}
		[WebMethod]
		public void DeleteGiaoDich(decimal ip_dc_ID)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var gd = db.GD_CHI_TIET_GIAO_KH.FirstOrDefault(x => x.ID == ip_dc_ID);
			if (gd == null) return;
			db.GD_CHI_TIET_GIAO_KH.Remove(gd);
			db.SaveChanges();
		}
		[WebMethod]
		public void GenGrid(
			decimal ip_dc_ID_QUYET_DINH
			, decimal ip_dc_ID_DON_VI)
		{
			string grid = "";

			Context.Response.Output.Write(grid);
		}

		public class ItemF104
		{
			public decimal ID { get; set; }
			public string SO_KM { get; set; }
			public string KP_NAM_TRUOC_CHUYEN_SANG { get; set; }
			public string KP_NGAN_SACH { get; set; }
			public string KP_QUY_BT { get; set; }
		}

		[WebMethod]
		public void UpdateAll(ItemF104[] ip_arr)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			for (int i = 0; i < ip_arr.Length; i++)
			{
				var gd = db.GD_CHI_TIET_GIAO_KH.FirstOrDefault(x => x.ID == ip_arr[i].ID);
				if (gd == null) continue;
				gd.GHI_CHU_2 = ip_arr[i].SO_KM;
				gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = Convert.ToDecimal(ip_arr[i].KP_NAM_TRUOC_CHUYEN_SANG.Trim().Replace(",", "").Replace(".", ""));
				gd.SO_TIEN_NS = Convert.ToDecimal(ip_arr[i].KP_NGAN_SACH.Trim().Replace(",", "").Replace(".", ""));
				gd.SO_TIEN_QUY_BT = Convert.ToDecimal(ip_arr[i].KP_QUY_BT.Trim().Replace(",", "").Replace(".", ""));
				db.SaveChanges();
			}
		}
	}
}
