using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using System.Web.Script.Serialization;
using WebUS;
using System.Data;
using IP.Core.IPCommon;
using Framework.Extensions;
using QuanLyDuToan.App_Code;
using QuanLyDuToan.UserControls;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for F104
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	[System.Web.Script.Services.ScriptService]
	public class F104 : System.Web.Services.WebService
	{
		#region Data Structure

		#endregion

		#region Public Function
		public string genClassCSS(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT == "-1")
			{
				//tong
				v_str_op = "tong ";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = " lnv " + ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = " ct " + ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = "da " + ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSo(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "0";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT + ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSoParent(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = "0";
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT;
			}
			return v_str_op;
		}
		#endregion

		#region WebMethods

		[WebMethod]
		public void UpdateGiaoDich(
					decimal ip_dc_ID
					, decimal ip_dc_ID_QUYET_DINH
					, decimal ip_dc_ID_DON_VI
					, string ip_str_CONG_TRINH
					, decimal ip_dc_TONG_MUC_DAU_TU
					, decimal ip_dc_THOI_GIAN_THUC_HIEN
					, decimal ip_dc_SO_TIEN_QUY_BT
					, decimal ip_dc_SO_TIEN_NS
					, decimal ip_dc_ID_CHUONG
					, decimal ip_dc_ID_KHOAN
					, decimal ip_dc_ID_MUC
					, string ip_str_GHI_CHU
					, decimal ip_dc_ID_TIEU_MUC
					, decimal ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_QBT
					, decimal ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS
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
			gd.TONG_MUC_DAU_TU = ip_dc_TONG_MUC_DAU_TU;
			gd.THOI_GIAN_THUC_HIEN = ip_dc_THOI_GIAN_THUC_HIEN;
			if (ip_dc_ID_CHUONG == -1) gd.ID_CHUONG = null;
			else gd.ID_CHUONG = ip_dc_ID_CHUONG;
			if (ip_dc_ID_KHOAN == -1) gd.ID_KHOAN = null;
			else gd.ID_KHOAN = ip_dc_ID_KHOAN;
			if (ip_dc_ID_MUC == -1) gd.ID_MUC = null;
			else gd.ID_MUC = ip_dc_ID_MUC;
			gd.GHI_CHU = ip_str_GHI_CHU.Equals("-1") ? null : ip_str_GHI_CHU;
			if (ip_dc_ID_TIEU_MUC == -1) gd.ID_TIEU_MUC = null;
			else gd.ID_TIEU_MUC = ip_dc_ID_TIEU_MUC;
			gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_QBT;
			gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS = ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS;
			gd.ID_LOAI_NHIEM_VU = ip_dc_ID_LOAI_NHIEM_VU;

			if (!ip_str_CONG_TRINH.Trim().Equals(""))
			{
				//Xu ly du lieu, lay id cong trinh, id du an
				DM_CONG_TRINH_DU_AN_GOI_THAU v_cong_trinh = db.DM_CONG_TRINH_DU_AN_GOI_THAU
					.FirstOrDefault(x => x.TEN.Trim() == ip_str_CONG_TRINH.Trim());
				//&& x.DM_CONG_TRINH_DU_AN_GOI_THAU_CHILDREN.Where(y => y.TEN == ip_str_DU_AN
				//).Count() > 0)
				;


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
				DM_CONG_TRINH_DU_AN_GOI_THAU v_du_an = db.DM_CONG_TRINH_DU_AN_GOI_THAU
					.FirstOrDefault(x => x.TEN.Trim() == ip_str_DU_AN.Trim()
						&& x.ID_CHA == v_cong_trinh.ID
						);
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
				//Xu ly du lieu so KM
				decimal v_so_km = 0;
				decimal.TryParse(ip_str_GHI_CHU_2.Replace(",", ""), out v_so_km);
				gd.GHI_CHU_2 = v_so_km.ToString();

				gd.GHI_CHU_3 = (ip_str_GHI_CHU_3.Equals("-1") ? null : ip_str_GHI_CHU_3);
				gd.GHI_CHU_4 = (ip_str_GHI_CHU_4.Equals("-1") ? null : ip_str_GHI_CHU_4);
				if (ip_dc_ID == -1)
				{
					db.GD_CHI_TIET_GIAO_KH.Add(gd);
				}
				db.SaveChanges();
			}
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
			, decimal ip_dc_ID_DON_VI
			, string ip_str_nguon)
		{
			List<DBClassModel.GD_CHI_TIET_GIAO_KH> m_lst_gd;

			string grid = "";
			//load data to list giao dich
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var v_lst_gd = db.GD_CHI_TIET_GIAO_KH
				.Where(x => x.ID_DON_VI == ip_dc_ID_DON_VI
					&& x.ID_QUYET_DINH == ip_dc_ID_QUYET_DINH)
				.ToList();
			m_lst_gd = v_lst_gd
				.Select(x => x.CopyAs<DBClassModel.GD_CHI_TIET_GIAO_KH>())
				.ToList();
			grid = F104Grid.RenderToString(v_lst_gd);
			string result = "";
			result += grid + "||||||||||";
			result += Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_gd);
			Context.Response.Output.Write(result);
		}

		public class ItemF104
		{
			public decimal ID { get; set; }
			public string SO_KM { get; set; }
			public string KP_NAM_TRUOC_CHUYEN_SANG_QBT { get; set; }
			public string KP_NAM_TRUOC_CHUYEN_SANG_NS { get; set; }
			public string KP_NGAN_SACH { get; set; }
			public string KP_QUY_BT { get; set; }
			public string TONG_MUC_DAU_TU { get; set; }
			public string THOI_GIAN_THUC_HIEN { get; set; }
		}

		[WebMethod]
		public void UpdateAll(string ip_str_arr)
		{
			try
			{
				JavaScriptSerializer js = new JavaScriptSerializer();
				ItemF104[] ip_arr = js.Deserialize<ItemF104[]>(ip_str_arr);
				BKI_QLDTEntities db = new BKI_QLDTEntities();
				for (int i = 0; i < ip_arr.Length; i++)
				{
					decimal id_gd = ip_arr[i].ID;
					var gd = db.GD_CHI_TIET_GIAO_KH.FirstOrDefault(x => x.ID == id_gd);
					if (gd == null) continue;
					//xu ly du lieu so km
					decimal v_so_km = 0;
					decimal.TryParse(ip_arr[i].SO_KM.Replace(",", ""), out v_so_km);
					gd.GHI_CHU_2 = v_so_km.ToString();

					gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = Convert.ToDecimal(ip_arr[i].KP_NAM_TRUOC_CHUYEN_SANG_QBT.Trim().Replace(",", "").Replace(".", ""));
					gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS = Convert.ToDecimal(ip_arr[i].KP_NAM_TRUOC_CHUYEN_SANG_NS.Trim().Replace(",", "").Replace(".", ""));
					gd.SO_TIEN_NS = Convert.ToDecimal(ip_arr[i].KP_NGAN_SACH.Trim().Replace(",", "").Replace(".", ""));
					gd.SO_TIEN_QUY_BT = Convert.ToDecimal(ip_arr[i].KP_QUY_BT.Trim().Replace(",", "").Replace(".", ""));
					gd.TONG_MUC_DAU_TU = Convert.ToDecimal(ip_arr[i].TONG_MUC_DAU_TU.Trim().Replace(",", "").Replace(".", ""));
					gd.THOI_GIAN_THUC_HIEN = Convert.ToDecimal(ip_arr[i].THOI_GIAN_THUC_HIEN.Trim().Replace(",", "").Replace(".", ""));

					db.SaveChanges();
				}
			}
			catch (Exception v_e)
			{
				Context.Response.Write(v_e.Message);
			}

		}

		[WebMethod]
		public void CopyItemFromQuyetDinh(
			decimal ip_dc_id_don_vi
			, decimal ip_dc_id_quyet_dinh_1
			, decimal ip_dc_id_quyet_dinh_2)
		{
			/*Copy Cong trinh/Du an (Khoan/Muc, Tieu muc) tu 'Quyet dinh 1' sang 'Quyet dinh 2'*/
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var lst_gd_qd_1 = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh_1
									&& x.ID_DON_VI == ip_dc_id_don_vi)
								.ToList();
			var lst_gd_qd_2 = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh_2
									&& x.ID_DON_VI == ip_dc_id_don_vi)
								.ToList();
			//Duyet tung du an, muc-tieu muc cua Quyet dinh 1
			foreach (var gd_qd1 in lst_gd_qd_1)
			{
				//Neu la cong trinh
				if (gd_qd1.ID_CONG_TRINH != null)
				{
					//Kiem tra xem da co trong Giao Ke hoach cua Quyet dinh 2 chua
					if (lst_gd_qd_2.Where(x => x.ID_CONG_TRINH == gd_qd1.ID_CONG_TRINH
											&& x.ID_DU_AN == gd_qd1.ID_DU_AN
											&& x.ID_LOAI_NHIEM_VU == gd_qd1.ID_LOAI_NHIEM_VU)
											.ToList()
											.Count == 0)
					//Neu chua co thi them vao Giao Ke hoach voi so tien NS, QBT, NTCS =0
					{
						GD_CHI_TIET_GIAO_KH v_gd = new GD_CHI_TIET_GIAO_KH();
						v_gd.ID_DON_VI = ip_dc_id_don_vi;
						v_gd.ID_QUYET_DINH = ip_dc_id_quyet_dinh_2;
						v_gd.ID_LOAI_NHIEM_VU = gd_qd1.ID_LOAI_NHIEM_VU;
						v_gd.ID_CONG_TRINH = gd_qd1.ID_CONG_TRINH;
						v_gd.ID_DU_AN = gd_qd1.ID_DU_AN;
						//so km
						v_gd.GHI_CHU_2 = gd_qd1.GHI_CHU_2;

						v_gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = 0;
						v_gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS = 0;
						v_gd.SO_TIEN_NS = 0;
						v_gd.SO_TIEN_QUY_BT = 0;
						v_gd.TONG_MUC_DAU_TU = 0;
						v_gd.THOI_GIAN_THUC_HIEN = 0;
						db.GD_CHI_TIET_GIAO_KH.Add(v_gd);
						db.SaveChanges();
						lst_gd_qd_2 = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh_2
									&& x.ID_DON_VI == ip_dc_id_don_vi)
								.ToList();
					}
					//Neu da co roi thi bo qua
					else
					{
					}
				}
				//Neu la muc-tieu muc
				else
				{
					//Kiem tra xem da co trong Giao Ke hoach cua Quyet dinh 2 chua
					if (lst_gd_qd_2.Where(x => x.ID_KHOAN == gd_qd1.ID_KHOAN
											&& x.ID_MUC == gd_qd1.ID_MUC
											&& x.ID_TIEU_MUC == gd_qd1.ID_TIEU_MUC
											&& x.ID_LOAI_NHIEM_VU == gd_qd1.ID_LOAI_NHIEM_VU)
											.ToList()
											.Count == 0)
					//Neu chua co thi them vao Giao Ke hoach voi so tien NS, QBT, NTCS =0
					{
						GD_CHI_TIET_GIAO_KH v_gd = new GD_CHI_TIET_GIAO_KH();
						v_gd.ID_DON_VI = ip_dc_id_don_vi;
						v_gd.ID_QUYET_DINH = ip_dc_id_quyet_dinh_2;
						v_gd.ID_LOAI_NHIEM_VU = gd_qd1.ID_LOAI_NHIEM_VU;
						v_gd.ID_KHOAN = gd_qd1.ID_KHOAN;
						v_gd.ID_MUC = gd_qd1.ID_MUC;
						v_gd.ID_TIEU_MUC = gd_qd1.ID_TIEU_MUC;

						//noi dung du toan
						v_gd.GHI_CHU_1 = gd_qd1.GHI_CHU_1;

						v_gd.TU_CHU_YN = gd_qd1.TU_CHU_YN;
						v_gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = 0;
						v_gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS = 0;
						v_gd.SO_TIEN_NS = 0;
						v_gd.SO_TIEN_QUY_BT = 0;
						v_gd.TONG_MUC_DAU_TU = 0;
						v_gd.THOI_GIAN_THUC_HIEN = 0;
						db.GD_CHI_TIET_GIAO_KH.Add(v_gd);
						db.SaveChanges();
						lst_gd_qd_2 = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh_2
									&& x.ID_DON_VI == ip_dc_id_don_vi)
								.ToList();
					}
					//Neu da co roi thi bo qua
					else
					{
					}
				}

			}

		}

		#endregion

	}
}
