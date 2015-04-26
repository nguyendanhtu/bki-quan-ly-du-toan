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
			gd.GHI_CHU = ip_str_GHI_CHU.Equals("-1") ? null : ip_str_GHI_CHU;
			if (ip_dc_ID_TIEU_MUC == -1) gd.ID_TIEU_MUC = null;
			else gd.ID_TIEU_MUC = ip_dc_ID_TIEU_MUC;
			gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = ip_dc_SO_TIEN_NAM_TRUOC_CHUYEN_SANG;
			gd.ID_LOAI_NHIEM_VU = ip_dc_ID_LOAI_NHIEM_VU;

			//Xu ly du lieu, lay id cong trinh, id du an
			DM_CONG_TRINH_DU_AN_GOI_THAU v_cong_trinh = db.DM_CONG_TRINH_DU_AN_GOI_THAU
				.FirstOrDefault(x => x.TEN.Trim() == ip_str_CONG_TRINH.Trim()
				&& x.DM_CONG_TRINH_DU_AN_GOI_THAU1.Where(y => y.TEN == ip_str_DU_AN).Count() > 0);


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
			List<pr_F104_nhap_du_toan_ke_hoach_Result> m_lst_giao_kh;
			List<DBClassModel.GD_CHI_TIET_GIAO_KH> m_lst_gd;

			//load data to list to gen grid
			decimal v_id_dc_reported_user = 234234234;
			US_GRID_GIAO_KH v_us = new US_GRID_GIAO_KH();
			DataSet v_ds = new DataSet();
			v_ds.Tables.Add(new DataTable());
			v_us.get_grid_giao_kh_qbt(v_ds
				, ip_dc_ID_QUYET_DINH
				, ip_str_nguon
				, v_id_dc_reported_user
				, ip_dc_ID_DON_VI);
			m_lst_giao_kh = v_ds.Tables[0]
							.AsEnumerable()
							.Select(x => new pr_F104_nhap_du_toan_ke_hoach_Result
							{
								ID = (x.IsNull("ID") ? -1 : CIPConvert.ToDecimal(x["ID"])),
								ID_CHA = (x.IsNull("ID_CHA") ? -1 : CIPConvert.ToDecimal(x["ID_CHA"])),
								ID_DON_VI = (x.IsNull("ID_DON_VI") ? -1 : CIPConvert.ToDecimal(x["ID_DON_VI"])),
								ID_REPORTED_USER = (x.IsNull("ID_REPORTED_USER") ? -1 : CIPConvert.ToDecimal(x["ID_REPORTED_USER"])),
								NOI_DUNG = x["NOI_DUNG"].ToString(),
								NS = (x.IsNull("NS") ? 0 : CIPConvert.ToDecimal(x["NS"])),
								NTCT = (x.IsNull("NTCT") ? 0 : CIPConvert.ToDecimal(x["NTCT"])),
								QUY = (x.IsNull("QUY") ? 0 : CIPConvert.ToDecimal(x["QUY"])),
								REPORT_LEVEL = x["REPORT_LEVEL"].ToString(),
								So_KM = (x.IsNull("So_KM") ? 0 : CIPConvert.ToDecimal(x["So_KM"])),
								STT = x["STT"].ToString(),
								TONG = (x.IsNull("TONG") ? 0 : CIPConvert.ToDecimal(x["TONG"])),
							})
							.ToList();
			string grid = "";
			foreach (var gd in m_lst_giao_kh)
			{
				grid += @"<tr style='" + (gd.ID == -1 ? "font-weight:bold" : "") + @"'>
								<!--Xoá-->
								<td style='width: 90px' class='text-center delete'>
									";
				if (gd.ID != -1)
				{
					grid += @"<input type='button' class='xoa_giao_dich btn btn-xs btn-danger private_don_vi' value='Xoá' onclick='F104.deleteGiaoDich(" + gd.ID + ")' />";
				}

				if (gd.ID != -1)
				{
					grid += @"<input type='button' class='sua_giao_dich btn btn-xs btn-primary' value='Sửa' onclick='F104.editGiaoDich(" + gd.ID + @")' />";
				}
				grid += @"</td>
								<!--Nhiem vu chi-->
								<td ma_so='" + genMaSo(gd) + @"' id_giao_dich='" + gd.ID + @"' ma_so_parent='" + genMaSoParent(gd) + @"' class='lnv'>"
					+ gd.NOI_DUNG + @"
								</td>
								<!--Chiều dài tuyến-->
								<td class='text-right' style='width: 50px'>
									<input type='text' class='so_km form-control text-right' value='" + IP.Core.IPCommon.CIPConvert.ToStr(gd.So_KM, "#,##0.##") + @"' />
								</td>
								<!--Kinh phi Nam truoc chuyen sang-->
								<td class='text-right' style='width: 100px'>
									<input type='text' class='kinh_phi_nam_truoc_chuyen_sang form-control text-right format_so_tien' value='" + IP.Core.IPCommon.CIPConvert.ToStr(gd.NTCT, "#,##0.##") + @"' />
								</td>
								<!--Kinh phi Ngan sach-->
								<td class='text-right' style='width: 100px'>
									<input type='text' class='kinh_phi_ngan_sach form-control text-right format_so_tien' value='" + IP.Core.IPCommon.CIPConvert.ToStr(gd.NS, "#,##0.##") + @"' />
								</td>
								<!--Kinh phi Quy bao tri-->
								<td class='text-right' style='width: 100px'>
									<input type='text' class='kinh_phi_quy_bao_tri form-control text-right format_so_tien' value='" + IP.Core.IPCommon.CIPConvert.ToStr(gd.QUY, "#,##0.##") + @"' />
								</td>
								<!--Tổng-->
								<td class='text-right' style='width: 100px'>
									<input type='text' class='grid_tong form-control text-right' value='" + IP.Core.IPCommon.CIPConvert.ToStr(gd.TONG, "#,##0.##") + @"' />
								</td>
							</tr>";
			}

			//load data to list giao dich
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_gd = db.GD_CHI_TIET_GIAO_KH
				.Where(x => x.ID_DON_VI == ip_dc_ID_DON_VI
					&& x.ID_QUYET_DINH == ip_dc_ID_QUYET_DINH)
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.GD_CHI_TIET_GIAO_KH>())
				.ToList();
			string result = "";
			result += grid + "||||||||||";
			result += Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_gd);
			Context.Response.Output.Write(result);
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

					gd.SO_TIEN_NAM_TRUOC_CHUYEN_SANG = Convert.ToDecimal(ip_arr[i].KP_NAM_TRUOC_CHUYEN_SANG.Trim().Replace(",", "").Replace(".", ""));
					gd.SO_TIEN_NS = Convert.ToDecimal(ip_arr[i].KP_NGAN_SACH.Trim().Replace(",", "").Replace(".", ""));
					gd.SO_TIEN_QUY_BT = Convert.ToDecimal(ip_arr[i].KP_QUY_BT.Trim().Replace(",", "").Replace(".", ""));
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
											&&x.ID_LOAI_NHIEM_VU==gd_qd1.ID_LOAI_NHIEM_VU)
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
						v_gd.SO_TIEN_NS = 0;
						v_gd.SO_TIEN_QUY_BT = 0;
						db.GD_CHI_TIET_GIAO_KH.Add(v_gd);
						db.SaveChanges();
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
						v_gd.SO_TIEN_NS = 0;
						v_gd.SO_TIEN_QUY_BT = 0;
						db.GD_CHI_TIET_GIAO_KH.Add(v_gd);
						db.SaveChanges();
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
