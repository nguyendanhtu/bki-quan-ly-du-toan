using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.WebMethod
{
	/// <summary>
	/// Summary description for PL02
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class PL02 : System.Web.Services.WebService
	{
		[WebMethod]
		public void genGrid(decimal ip_dc_id_don_vi, int ip_i_nam)
		{
			List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
			List<QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM> lst_clkm;
			List<string> lst_NDC;
			lst_NDC = new List<string>();
			lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
			lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			//load list Chuong loai khoan muc tieu muc
			lst_clkm = db
					   .DM_CHUONG_LOAI_KHOAN_MUC
					   .Select(x => new
					   QuanLyDuToan.QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM
					   {
						   MaSo = x.MA_SO
						   ,
						   Ten = x.TEN
						   ,
						   IdLoai = x.ID_LOAI
						   ,
						   MaSoParent = x.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
					   })
					   .ToList();

			//Sao chep du lieu Muc, Tieu muc tu GD_GIAO_KH sang
			DateTime v_dat_dau_nam = new DateTime(ip_i_nam, 1, 1);
			DateTime v_dat_cuoi_nam = new DateTime(ip_i_nam + 1, 1, 1);
			var lst_gd_giao_kh = db.GD_CHI_TIET_GIAO_KH
									.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
										&& x.DM_QUYET_DINH.NGAY_THANG >= v_dat_dau_nam
										&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_cuoi_nam
										&& x.ID_CHUONG != null)
									.ToList();
			lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
						.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_i_nam)
						.ToList();
			//Sao chep muc, tieu muc KHONG co trong PL02
			foreach (var kh in lst_gd_giao_kh)
			{
				if (!lst_pl02.Exists(x=>x.MA_KHOAN==kh.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO
					&&x.MA_MUC==kh.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO
					&&x.MA_TIEU_MUC==kh.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO))
				{
					GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN gd = new GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN();
					gd.ID_DON_VI = ip_dc_id_don_vi;
					gd.LOAI = lst_NDC[0];
					gd.MA_KHOAN = kh.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO;
					gd.MA_LOAI = kh.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO;
					gd.MA_MUC = kh.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO;
					gd.MA_TIEU_MUC = kh.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO;
					gd.NAM = ip_i_nam;
					gd.SO_BAO_CAO = 0;
					gd.SO_XET_DUYET = 0;
					db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.Add(gd);
					db.SaveChanges();
					//reload list PL02
					lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
						.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_i_nam)
						.ToList();
				}
			}
			//Xoa nhung muc, tieu muc KHONG co trong GD_GIAO_KH
			foreach (var pl02 in lst_pl02.Where(x => x.LOAI.Contains("I. Kinh phí năm quyết toán năm nay")).ToList())
			{
				if (!lst_gd_giao_kh.Exists(x=>x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO==pl02.MA_KHOAN
					&&x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO==pl02.MA_MUC
					&&x.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO==pl02.MA_TIEU_MUC))
				{
					db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.Remove(pl02);
					db.SaveChanges();
				}
			}
			//reload list PL02
			lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
				.Where(x => x.ID_DON_VI == ip_dc_id_don_vi && x.NAM == ip_i_nam)
				.ToList();
			string v_str_grid = "";
			v_str_grid = UserControls.QT_QBT_GRID_PL02.RenderToString(lst_pl02, lst_NDC, lst_clkm);
			Context.Response.Output.Write(v_str_grid);
		}

		[WebMethod]
		public void UpdateGiaoDich(
			decimal ip_dc_id_giao_dich
			, string ip_str_ma_loai
			, string ip_str_ma_khoan
			, string ip_str_ma_muc
			, string ip_str_ma_tieu_muc
			, string ip_str_so_bao_cao
			, string ip_str_so_xet_duyet
			, string ip_str_noi_dung_chi
			, string ip_str_loai
			, decimal ip_dc_id_don_vi
			, decimal ip_dc_nam)
		{
			try
			{
				using (BKI_QLDTEntities db = new BKI_QLDTEntities())
				{
					GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN gd;
					if (ip_dc_id_giao_dich < 0)
					{
						gd = new GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN();
					}
					else
					{
						gd = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.Where(x => x.ID == ip_dc_id_giao_dich).FirstOrDefault();
					}
					gd.MA_LOAI = ip_str_ma_loai;
					gd.MA_KHOAN = ip_str_ma_khoan;
					gd.MA_MUC = ip_str_ma_muc;
					gd.MA_TIEU_MUC = ip_str_ma_tieu_muc;
					gd.NOI_DUNG_CHI = ip_str_noi_dung_chi;
					gd.ID_DON_VI = ip_dc_id_don_vi;
					gd.NAM = ip_dc_nam;
					gd.LOAI = ip_str_loai;
					gd.SO_BAO_CAO = CIPConvert.ToDecimal(ip_str_so_bao_cao.Replace(",", "").Replace(".", ""));
					gd.SO_XET_DUYET = CIPConvert.ToDecimal(ip_str_so_xet_duyet.Replace(",", "").Replace(".", ""));
					if (ip_dc_id_giao_dich < 0)
					{
						db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.Add(gd);
					}
					db.SaveChanges();
				}
			}
			catch (Exception)
			{

				throw;
			}
		}
		[WebMethod]
		public void DeleteGiaoDich(decimal ip_dc_id_giao_dich)
		{
			try
			{
				using (BKI_QLDTEntities db = new BKI_QLDTEntities())
				{
					GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN gd = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.First(x => x.ID == ip_dc_id_giao_dich);
					if (gd != null)
					{
						db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN.Remove(gd);
						db.SaveChanges();
						Context.Response.Output.Write("true");
					}
					else
					{
						Context.Response.Output.Write("false");
					}
				}
			}
			catch (Exception)
			{
				Context.Response.Output.Write("false");
			}

		}


	}
}