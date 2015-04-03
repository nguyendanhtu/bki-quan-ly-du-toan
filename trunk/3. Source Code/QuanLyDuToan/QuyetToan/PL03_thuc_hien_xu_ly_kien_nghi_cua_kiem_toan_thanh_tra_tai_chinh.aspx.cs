using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			InsertFromTemplate(145, 2014);
			load_data_to_list(145, 2014, db);
		}


		#region Members
		public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_pl03;
		#endregion

		#region Private Methods
		private void load_data_to_list(decimal ip_dc_id_don_vi, decimal ip_dc_nam, BKI_QLDTEntities ip_db)
		{
			lst_pl03 = ip_db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
				.Where(x => x.ID_DON_VI == ip_dc_id_don_vi
					&& x.NAM == ip_dc_nam)
				.ToList()
				.OrderBy(x => int.Parse(x.MA_SO))
				.ToList();
		}
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
		#endregion
	}
}