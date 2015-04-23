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
		public void genGrid()
		{
			List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
			List<QuanLyDuToan.QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM> lst_clkm;
			List<string> lst_NDC;
			lst_NDC = new List<string>();
			lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
			lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
							.Where(x => x.ID_DON_VI == 145 && x.NAM == 2014)
							.ToList();
				lst_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.Select(x => new QuanLyDuToan.QuyetToan.PL02_kinh_phi_su_dung_quyet_toan.ItemCLKM { MaSo = x.MA_SO, Ten = x.TEN }).ToList();
			}
			/*
			 * Cac buoc de tao string result
			 * Copy thead, tbody, tfooter ben file .aspx vao notepad++
			 * Replace cac gia tri sau
			 * <%{%>             {
			 * .ToList())%>         .ToList())
			 * <%}%>              }
			 * <%=              "+
			 * <%foreach       ";foreach
			 * lst_NDC)%>       lst_NDC)
			 * %>              +@"
			 * Them result += @" vao cac doan truoc <tr>; tinh chinh mot chut (them ; () cho phep - 
			 * de hoan thien
			 */
			string result = "";
			result += @"<thead style='vertical-align: middle;'>
			<tr class='text-center'>
				<th rowspan='2' class='clkm'>Loại</th>
				<th rowspan='2' class='clkm'>Khoản</th>
				<th rowspan='2' class='clkm'>Mục</th>
				<th rowspan='2' class='clkm'>Tiểu mục</th>
				<th rowspan='2'  style='width: 300px'>Nội dung chi</th>
				<th colspan='3'>Tổng cộng</th>
				<th rowspan='2' style='width:160px'>Thao tác</th>
			</tr>
			<tr class='text-center'>
				<th rowspan='1' colspan='1' class='so_tien'>Số báo cáo</th>
				<th rowspan='1' colspan='1' class='so_tien'>Số phê duyệt</th>
				<th rowspan='1' colspan='1' class='so_tien'>Chênh lệch</th>
			</tr>
			<tr>
				<td>Nhập mới</td>
				<td></td>
				<td></td>
				<td></td>
				<td>
					<label>
						<input type='radio' checked='checked' name='loai_NDC' id='I' />I. Kinh phí năm quyết toán năm nay:</label>
					<br />
					<label>
						<input type='radio' name='loai_NDC' id='II' />II. KP năm trước chưa QT, quyết toán năm nay</label>
				</td>
			</tr>
			<tr>
				<td>
					<input type='text' id='txt_loai' class='clkm' /></td>
				<td>
					<input type='text' id='txt_khoan' class='clkm' /></td>
				<td>
					<input type='text' id='txt_muc' class='clkm' /></td>
				<td>
					<input type='text' id='txt_tieu_muc' class='clkm' /></td>
				<td>
					<span id='lbl_noi_dung_chi' style='width: 100%'></span>
				</td>
				<td class='text-right'>
					<input type='text' id='txt_so_bao_cao' value='0' class='so_tien format_so_tien text-right' /></td>
				<td class='text-right'>
					<input type='text' id='txt_so_xet_duyet' value='0' class='so_tien format_so_tien  text-right' /></td>
				<td class='text-right'><span id='lbl_chenh_lech' class='so_tien'>0</span></td>
				<td class='text-center'>
					<input type='button' id='btnCapNhat' style='width:91px' class='btn btn-sm btn-success' value='Ghi dữ liệu' onclick='gdPL02.update()' />
					<input type='button' id='btnCancel' class='btn btn-sm btn-default' value='Huỷ thao tác' onclick='gdPL02.cancel()' />
				</td>
			</tr>
		</thead>
		<tbody>
			"; foreach (var loai_ndc in lst_NDC)
			{
				result += @"<tr style='font-weight: bold; font-style: italic'>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>" + loai_ndc + @"</td>
				<td class='text-right str_money'>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_BAO_CAO))
								.ToList()
								.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_XET_DUYET))
								.ToList()
								.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
								.Where(x => x.LOAI == loai_ndc)
								.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
								.ToList()
								.Sum() + @"</td>
				<td></td>
			</tr>
			<!--Loai-->
			"; foreach (var ma_loai in lst_pl02
										 .Where(x => x.LOAI == loai_ndc)
										 .Select(x => x.MA_LOAI)
										 .Distinct()
										 .OrderBy(x => x)
										 .ToList())
				{
					result += @"<tr style='font-weight: bold'>
				<td class='text-center'>" + ma_loai + @"</td>
				<td></td>
				<td></td>
				<td></td>
				<td>" + lst_clkm
									.Where(x => x.MaSo == ma_loai)
									.Select(x => x.Ten)
									.FirstOrDefault() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
									.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									.Select(x => x.SO_BAO_CAO)
									.ToList()
									.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
									.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									.Select(x => x.SO_XET_DUYET)
									.ToList()
									.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
									.Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
									.ToList()
									.Sum() + @"</td>
				<td></td>
			</tr>
			<!--Khoan-->
			"; foreach (var ma_khoan in lst_pl02
									  .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									  .Select(x => x.MA_KHOAN)
									  .Distinct()
									  .OrderBy(x => x)
									  .ToList())
					{
						result += @"<tr style='font-weight: bold'>
				<td></td>
				<td class='text-center'>" + ma_khoan + @"</td>
				<td></td>
				<td></td>
				<td>" + lst_clkm.Where(x => x.MaSo == ma_khoan).Select(x => x.Ten).FirstOrDefault() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
										.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => x.SO_BAO_CAO)
										.ToList()
										.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
										.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => x.SO_XET_DUYET)
										.ToList()
										.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
										.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
										.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
										.ToList()
										.Sum() + @"</td>
				<td></td>
			</tr>
			<!--Muc-->
			"; foreach (var ma_muc in lst_pl02
									  .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									  .Select(x => x.MA_MUC)
									  .Distinct()
									  .OrderBy(x => x)
									  .ToList())
						{
							result += @"<tr style='font-weight: bold'>
				<td></td>
				<td></td>
				<td class='text-center'>" + ma_muc + @"</td>
				<td></td>
				<td>" + lst_clkm.Where(x => x.MaSo == ma_muc).Select(x => x.Ten).FirstOrDefault() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
											.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
											.Select(x => x.SO_BAO_CAO)
											.ToList()
											.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
											.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
											.Select(x => x.SO_XET_DUYET)
											.ToList()
											.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
											.Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
											.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
											.ToList()
											.Sum() + @"</td>
				<td></td>
			</tr>
			<!--Tieu Muc-->
			"; foreach (var ma_tieu_muc in lst_pl02
							  .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc).OrderBy(x => x.MA_TIEU_MUC)
							  .ToList())
							{
								result += @"<tr>
				<td></td>
				<td></td>
				<td></td>
				<td class='text-center'><span class='ma_tieu_muc' ma_loai='" + ma_loai + @"' ma_khoan='" + ma_khoan + @"' ma_muc='" + ma_muc + @"' id_giao_dich='" + ma_tieu_muc.ID + @"' loai='" + loai_ndc + @"'>" + ma_tieu_muc.MA_TIEU_MUC + @"</span></td>
				<td>" + lst_clkm.Where(x => x.MaSo == ma_tieu_muc.MA_TIEU_MUC.Trim()).Select(x => x.Ten).FirstOrDefault() + @"</td>
				<td class='text-right '><span class='so_bao_cao str_money'>" + ma_tieu_muc.SO_BAO_CAO + @"</span></td>
				<td class='text-right '><span class='so_xet_duyet str_money'>" + ma_tieu_muc.SO_XET_DUYET + @"</span></td>
				<td class='text-right '><span class='str_money'>" + (ma_tieu_muc.SO_BAO_CAO - ma_tieu_muc.SO_XET_DUYET) + @"</span></td>
				<td class='text-center'>
					<input type='button' value='Sửa thông tin' class='btn btn-sm btn-primary' onclick='gdPL02.editItem(this)' />
					<input type='button' value='Xoá' class='btn btn-sm btn-danger' onclick='gdPL02.deleteItem(this)'  />
				</td>
			</tr>";
							}
						}
					}
				}
			}
			result += @"<tr style='font-weight: bold; font-style: italic'>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>Tổng cộng</td>
				<td class='text-right str_money'>" + lst_pl02
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum() + @"</td>
				<td class='text-right str_money'>" + lst_pl02
							.Select(x => (x.SO_XET_DUYET))
							.ToList()
							.Sum() + @"</td>
				<td class='text-right  str_money'>" + lst_pl02
							.Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
							.ToList()
							.Sum() + @"</td>
				<td></td>
			</tr>
		</tbody>
		<tfoot>
		</tfoot>";
			Context.Response.Output.Write(result);
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