﻿using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

namespace QuanLyDuToan.QuyetToan
{
	public partial class PL02_kinh_phi_su_dung_quyet_toan : System.Web.UI.Page
	{
		#region Public Function
		public string formatClass(string className)
		{
			if (string.IsNullOrEmpty(className)) return "";
			return className.ToString().Replace('.', '_');
		}
		public string formatCongThuc(string className)
		{
			if (string.IsNullOrEmpty(className)) return "";
			return className.ToString().Replace('|', '\0');
		}

		#endregion

		#region Data Structures
		public class ItemCLKM
		{
			public string MaSo;
			public string Ten;
			public decimal? IdLoai;
			public string MaSoParent;
		}
		#endregion

		#region Members
		public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
		public List<ItemCLKM> lst_clkm;
		public List<string> lst_NDC = new List<string>();


		#endregion

		#region Private Methods
		public string genGrid()
		{
			string result = "";
			result += @"<table class='table table-hover' style='width:900px; margin:auto'>
						<thead style='vertical-align: middle'>
							<tr class='text-center'>
								<th rowspan='2' class='clkm'>Loại</th>
								<th rowspan='2' class='clkm'>Khoản</th>
								<th rowspan='2' class='clkm'>Mục</th>
								<th rowspan='2' class='clkm'>Tiểu mục</th>
								<th rowspan='2' style='width:200px'>Nội dung chi</th>
								<th colspan='3'>Tổng cộng</th>
							</tr>
							<tr class='text-center'>
								<th rowspan='1' colspan='1' class='so_tien'>Số báo cáo</th>
								<th rowspan='1' colspan='1'  class='so_tien'>Số phê duyệt</th>
								<th rowspan='1' colspan='1'  class='so_tien'>Chênh lệch</th>
							</tr>
							<tr>
								<td>Nhập mới</td>
								<td></td>
								<td></td>
								<td></td>
								<td><label><input type='radio' name='loai_NDC' />I. Kinh phí năm quyết toán năm nay:</label>
									<br />
									<label><input type='radio'  name='loai_NDC' />II. KP năm trước chưa QT, quyết toán năm nay</label>
									<br /></td>
							</tr>
							<tr>
								<td><input type='text' id='txt_loai' class='clkm'/></td>
								<td><input type='text' id='txt_khoan'  class='clkm'/></td>
								<td><input type='text' id='txt_muc'  class='clkm'/></td>
								<td><input type='text' id='txt_tieu_muc'  class='clkm'/></td>
								<td><span id='lbl_noi_dung_chi'  style='width:100%'></span></td>
								<td><input type='text' id='txt_so_bao_cao'  class='so_tien'/></td>
								<td><input type='text' id='txt_so_xet_duyet'  class='so_tien'/></td>
								<td><span id='lbl_chenh_lech' class='so_tien'>0</span></td>
							</tr>
						</thead>
						<tbody>";
			foreach (var loai_ndc in lst_NDC)
			{
				result += @"
							<tr style='font-weight:bold; font-style:italic'>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td>" + loai_ndc + @"</td>
								<td>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_BAO_CAO))
								.ToList()
								.Sum() + @"</td>
								<td>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_XET_DUYET))
								.ToList()
								.Sum() + @"</td>
								<td>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
								.ToList()
								.Sum() + @"</td>
							</tr>
							<!--Loai-->";
				foreach (var ma_loai in lst_pl02
										.Where(x => x.LOAI == loai_ndc)
										.Select(x => x.MA_LOAI)
										.Distinct()
										.ToList())
				{
					result +=
				@"<tr style='font-weight: bold'>
								<td>" + ma_loai + @"</td>
								<td></td>
								<td></td>
								<td></td>
								<td>" + lst_clkm
										.Where(x => x.MaSo == ma_loai)
										.Select(x => x.Ten)
										.FirstOrDefault() + @"</td>
								<td>" + lst_pl02
										.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => x.SO_BAO_CAO)
										.ToList()
										.Sum() + @"</td>
								<td>" + lst_pl02
										.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => x.SO_XET_DUYET)
										.ToList()
										.Sum() + @"</td>
								<td>" + lst_pl02
										.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
										.ToList()
										.Sum() + @"</td>
							</tr>
						<!--Khoan-->";
					foreach (var ma_khoan in lst_pl02
									 .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_KHOAN)
									 .Distinct()
									 .ToList())
					{
						result +=
						@"<tr style='font-weight: bold'>
							<td></td>
							<td>" + ma_khoan + @"</td>
							<td></td>
							<td></td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_khoan).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + lst_pl02
													.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
													.Select(x => x.SO_BAO_CAO)
													.ToList()
													.Sum() + @"</td>
							<td>" + lst_pl02
													.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
													.Select(x => x.SO_XET_DUYET)
													.ToList()
													.Sum() + @"</td>
							<td>" + lst_pl02
													.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
													.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
													.ToList()
													.Sum() + @"</td>
						</tr>
						<!--Muc-->";
						foreach (var ma_muc in lst_pl02
									 .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_MUC)
									 .Distinct()
									 .ToList())
						{
							result +=
							@"<tr style='font-weight: bold'>
							<td></td>
							<td></td>
							<td>" + ma_muc + @"</td>
							<td></td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_muc).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + lst_pl02
															.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
															.Select(x => x.SO_BAO_CAO)
															.ToList()
															.Sum() + @"</td>
							<td>" + lst_pl02
															.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
															.Select(x => x.SO_XET_DUYET)
															.ToList()
															.Sum() + @"</td>
							<td>" + lst_pl02
															.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
															.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
															.ToList()
															.Sum() + @"</td>
						</tr>
						<!--Tieu Muc-->";
							foreach (var ma_tieu_muc in lst_pl02
							 .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
							 .ToList())
							{
								result +=
						@"<tr>
							<td></td>
							<td></td>
							<td></td>
							<td>" + ma_tieu_muc.MA_TIEU_MUC + @"</td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_tieu_muc.MA_TIEU_MUC).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + ma_tieu_muc.SO_BAO_CAO + @"</td>
							<td>" + ma_tieu_muc.SO_XET_DUYET + @"</td>
							<td>" + (ma_tieu_muc.SO_BAO_CAO - ma_tieu_muc.SO_XET_DUYET) + @"</td>
						</tr>";
							}
						}
					}
				}
			}
			result +=
						@"<tr style='font-weight:bold; font-style:italic'>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td>Tổng cộng</td>
							<td>" + lst_pl02
										.Select(x => (x.SO_BAO_CAO))
										.ToList()
										.Sum() + @"</td>
							<td>" + lst_pl02
										.Select(x => (x.SO_XET_DUYET))
										.ToList()
										.Sum() + @"</td>
							<td>" + lst_pl02
										.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
										.ToList()
										.Sum() + @"</td>
						</tr>
					</tbody>
					<tfoot>
					</tfoot>
				</table>";
			return result;
		}
		public string getLoaiCLKM(object ip_obj_id_loai)
		{
			decimal v_dc_id_loai = Convert.ToDecimal(ip_obj_id_loai);
			if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.CHUONG)
			{
				return "C";
			}
			else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.KHOAN)
			{
				return "K";
			}
			else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.LOAI)
			{
				return "L";
			}
			else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.MUC)
			{
				return "M";
			}
			else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC)
			{
				return "TM";
			}
			return "C";
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			lst_NDC = new List<string>();
			lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
			lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
							.Where(x => x.ID_DON_VI == 145 && x.NAM == 2014)
							.ToList();
				var lst_dm_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.ToList();
				lst_clkm = db
					.DM_CHUONG_LOAI_KHOAN_MUC
					.Select(x => new
					ItemCLKM
					{
						MaSo = x.MA_SO
						,
						Ten = x.TEN
						,
						IdLoai =x.ID_LOAI
						,
						MaSoParent = x.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
					})
					.ToList();
					 
					
			}
		}
		#endregion
	}
}