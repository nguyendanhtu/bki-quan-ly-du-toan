using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using QuanLyDuToan.App_Code;
using IP.Core.IPCommon;

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
			var m_lst_du_toan_thu_chi_phi_pha = db.GD_DU_TOAN_THU_CHI_PHI_PHA
											.Where(x => x.ID_DON_VI == ip_dc_id_don_vi &&x.ID_QUYET_DINH==ip_dc_id_quyet_dinh)
											.OrderBy(x => x.MA_SO.Substring(0, 4))
											.ThenBy(x => x.MA_SO_PARENT)
											.ThenBy(x => x.TT)
											.ToList();
			var result = "";
			result += @"<tbody>";
			foreach (var gd in m_lst_du_toan_thu_chi_phi_pha)
			{
				result += @"<tr>
						<td>
							<input type='text' class='form-control tt text-center " + (gd.IS_FIX ? "text-bold disable" : "") + @"' value='" + gd.TT + @"' style='width:50px' />
						</td>
						<td style='width:550px'>
							<input type='text' value='" + gd.HANG_MUC + "' class='hang_muc form-control " + (gd.IS_FIX ? "text-bold disable" : "") + @"' style='width:500px;height:50px;word-break:break-word'  />
							<button type='button' title='Thêm hạng mục con' class='glyphicon glyphicon-plus btn btn-xs btn-success ' onclick='F505.addSubItem(this," + gd.MA_SO + @")' style='margin-left:10px;vertical-align: top;
  margin-top: 13px;'></button>
						</td>
						<td >
							<input type='text' class='text-right form-control kinh_phi_giao " + (gd.IS_FIX ? "text-bold disable" : "") + "' value='" + gd.KINH_PHI_GIAO_KH + @"' style='width:150px' ma_so='" + gd.MA_SO + @"' ma_so_parent='" + gd.MA_SO_PARENT + @"' /></td>
						<td class='text-center' style='width:150px'>
							
							"; if (m_lst_du_toan_thu_chi_phi_pha
									 .Where(x => x.MA_SO_PARENT == gd.MA_SO || gd.MA_SO_PARENT == null).ToList()
									 .Count() == 0 && gd.IS_FIX == false)
				{
					result += @"<input type='button' value='Xoá' class='btn btn-sm btn-danger' onclick='F505.deleteItem(this," + gd.ID + @")' />";
				}
				result += @"<input type='button' style='display:none' value='Cập nhật' class='btn btn-sm btn-primary cap_nhat' onclick='F505.saveItem(this," + gd.ID + @")' />
							
						</td>
					</tr>";
			}
			result += "</tbody>";
			Context.Response.Output.Write(result);
		}

		[WebMethod]
		public void InsertItem(decimal ip_dc_id_quyet_dinh
			, decimal ip_dc_id_don_vi
			, string ip_str_ma_so_parent
			, string ip_str_ma_so
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
			, string ip_str_GHI_CHU_QUY_IV)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var qd = db.DM_QUYET_DINH.First(x => x.ID == ip_dc_id_quyet_dinh);
			int v_i_ma_so = db.GD_DU_TOAN_THU_CHI_PHI_PHA
					.Where(x => x.ID_QUYET_DINH == ip_dc_id_quyet_dinh
						&& x.ID_DON_VI == ip_dc_id_don_vi
						&& (x.MA_SO_PARENT == ip_str_ma_so_parent || x.MA_SO == ip_str_ma_so_parent))
						.ToList()
						.Select(x => new { MaSo = Convert.ToInt16(x.MA_SO) })
						.Max(x => x.MaSo);
			GD_DU_TOAN_THU_CHI_PHI_PHA gd = new GD_DU_TOAN_THU_CHI_PHI_PHA();
			gd.ID_DON_VI = ip_dc_id_don_vi;
			gd.ID_QUYET_DINH = ip_dc_id_quyet_dinh;
			gd.MA_SO = (v_i_ma_so + 1).ToString();
			gd.MA_SO_PARENT = ip_str_ma_so_parent;
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
			gd.NAM = (decimal)qd.NGAY_THANG.Year;
			gd.IS_FIX = false;
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
			, string ip_str_GHI_CHU_GIAO_KH)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			var gd = db.GD_DU_TOAN_THU_CHI_PHI_PHA.First(x => x.ID == ip_dc_id_giao_dich);
			if (gd == null) return;
			gd.TT = ip_str_tt;
			gd.HANG_MUC = ip_str_hang_muc;
			gd.KINH_PHI_GIAO_KH = getMoney_number(ip_str_kinh_phi_giao.Replace(",", "").Replace(".", ""));
			gd.GHI_CHU_GIAO_KH = ip_str_GHI_CHU_GIAO_KH;
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
	}
}
