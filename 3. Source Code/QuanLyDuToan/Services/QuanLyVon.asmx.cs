using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SQLDataAccess;
using Newtonsoft.Json;
using System.Web.Script.Services;

namespace QuanLyDuToan.Services
{
	/// <summary>
	/// Summary description for QuanLyVon
	/// </summary>
	[WebService(Namespace = "http://tempuri.org/")]
	[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
	[System.ComponentModel.ToolboxItem(false)]
	// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
	// [System.Web.Script.Services.ScriptService]
	public class QuanLyVon : System.Web.Services.WebService
	{

		[WebMethod]
		[ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
		public void getInfo(int ip_i_nam,string callback)
		{
			DateTime v_dat_tu_ngay = new DateTime((int)ip_i_nam, 1, 1);
			DateTime v_dat_den_ngay = DateTime.Now.Date;
			QuanLyVonInfo info = new QuanLyVonInfo();
			using (BKI_QLDTEntities db = new BKI_QLDTEntities())
			{
				//1. KH da giao
				//1.1 Tổng dự án, mục, tiểu mục theo qđ điều chỉnh
				var v_lst_kh_dieu_chinh = db.GD_CHI_TIET_GIAO_KH
					.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO == WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
					&& x.DM_QUYET_DINH.NGAY_THANG >= v_dat_tu_ngay
					&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_den_ngay)
					.ToList();
				decimal? v_dc_tong_kh_dieu_chinh = v_lst_kh_dieu_chinh.Sum(x =>
					(x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG ?? 0)
					+ (x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS ?? 0)
					+ (x.SO_TIEN_NS ?? 0)
					+ (x.SO_TIEN_QUY_BT ?? 0));
				//1.2 Tổng dự án, mục, tiểu mục theo qđ đầu năm, bổ sung
				var v_lst_kh_dau_nam_bo_sung = db.GD_CHI_TIET_GIAO_KH
					.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
					&& x.DM_QUYET_DINH.NGAY_THANG >= v_dat_tu_ngay
					&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_den_ngay
					)
					.ToList()
					//Loại trừ dự án, mục, tiểu mục điều chỉnh
					.Where(x => !v_lst_kh_dieu_chinh.Exists(y =>
						y.ID_DON_VI == x.ID_DON_VI
						&& y.ID_LOAI_NHIEM_VU == x.ID_LOAI_NHIEM_VU
						&& y.ID_CONG_TRINH == x.ID_CONG_TRINH
						&& y.ID_KHOAN == x.ID_KHOAN
						&& (y.ID_DU_AN == x.ID_DU_AN
						|| (x.ID_TIEU_MUC == null && y.ID_MUC == x.ID_MUC)
						|| (x.ID_TIEU_MUC != null && y.ID_TIEU_MUC == x.ID_TIEU_MUC))))
					.ToList();
				decimal? v_dc_tong_kh_dau_nam_bo_sung = v_lst_kh_dau_nam_bo_sung.Sum(x =>
					(x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG ?? 0)
					+ (x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS ?? 0)
					+ (x.SO_TIEN_NS ?? 0)
					+ (x.SO_TIEN_QUY_BT ?? 0));

				decimal? v_dc_kh = v_dc_tong_kh_dau_nam_bo_sung + v_dc_tong_kh_dieu_chinh;
				info.dcKeHoachDaGiao = v_dc_kh;
				//2. Vốn đã nhận
				//2.1 Ngân sách
				decimal? v_dc_da_nhan_ns = v_lst_kh_dieu_chinh
											.Sum(x =>
												+ (x.SO_TIEN_NS ?? 0))
											+ v_lst_kh_dau_nam_bo_sung
											.Sum(x =>
												+ (x.SO_TIEN_NS ?? 0));
				//2.2 Quỹ bảo trì
				decimal? v_dc_da_nhan_qbt = db.GD_CHI_TIET_GIAO_VON
											.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= v_dat_tu_ngay
													&& x.DM_QUYET_DINH.NGAY_THANG <= v_dat_den_ngay)
											.Sum(x => x.SO_TIEN_QUY_BT ?? 0);
				decimal? v_dc_da_nhan = v_dc_da_nhan_ns + v_dc_da_nhan_qbt;
				info.dcVonDaNhan = v_dc_da_nhan;
				//3. Đã giải ngân
				decimal? v_dc_da_giai_ngan_ns = db.GD_CHI_TIET_GIAI_NGAN
											.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= v_dat_tu_ngay
													&& x.DM_GIAI_NGAN.NGAY_THANG <= v_dat_den_ngay
													&&x.DM_GIAI_NGAN.IS_NGUON_NS_YN=="Y")
											.Sum(x => x.SO_TIEN_NOP_THUE
												+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0));
				decimal? v_dc_da_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
											.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= v_dat_tu_ngay
													&& x.DM_GIAI_NGAN.NGAY_THANG <= v_dat_den_ngay)
											.Sum(x => x.SO_TIEN_NOP_THUE
												+ (x.SO_TIEN_TT_CHO_DV_HUONG ?? 0));
				info.dcDaGiaiNgan = v_dc_da_giai_ngan;
				//4. Chua giai ngan = Da nhan - Da giai ngan
				decimal? v_dc_chua_giai_ngan = v_dc_da_nhan - v_dc_da_giai_ngan;
				info.dcChuaGianNgan = v_dc_chua_giai_ngan;
				//5. Kinh phi con duoc nhan = Ke hoach - Da nhan
				decimal? v_dc_con_duoc_nhan = v_dc_kh - v_dc_da_nhan_qbt-v_dc_da_giai_ngan_ns;
				info.dcVonConDuocNhan = v_dc_con_duoc_nhan;
				//6. Gia tri thuc hien da nghiem thu A-B
				decimal? v_dc_giai_tri_thuc_hien_da_nghiem_thu_A_B = db.GD_KHOI_LUONG
											.Where(x => x.NGAY_THANG >= v_dat_tu_ngay
												&& x.NGAY_THANG <= v_dat_den_ngay)
											.Sum(x => (x.SO_TIEN_DA_NGHIEM_THU ?? 0)
												+ (x.SO_TIEN_DA_NGHIEM_THU_NS ?? 0));
				info.dcGiaTriThucHienDaNghiemThuAB = v_dc_giai_tri_thuc_hien_da_nghiem_thu_A_B;
				//7. So chua GN cho nha thau theo nghiem thu A-B = Gia tri thuc hien da nhiem thu A-B - Kinh phi da thanh toan
				decimal? v_dc_so_chua_giai_ngan_cho_nha_thau_theo_nghiem_thu_A_B = v_dc_giai_tri_thuc_hien_da_nghiem_thu_A_B - v_dc_da_giai_ngan;
				info.dcSoChuaGNChoNhaThauTheoNghiemThuAB = v_dc_so_chua_giai_ngan_cho_nha_thau_theo_nghiem_thu_A_B;
				Context.Response.Clear();
				Context.Response.ContentType = "application/json";
				Context.Response.Write(callback+"("+JsonConvert.SerializeObject(info)+")");
				Context.Response.End();
			}

		}
	}
}

public class QuanLyVonInfo
{
	public decimal? dcKeHoachDaGiao { get; set; }
	public decimal? dcVonDaNhan { get; set; }
	public decimal? dcVonConDuocNhan { get; set; }
	public decimal? dcDaGiaiNgan { get; set; }
	public decimal? dcChuaGianNgan { get; set; }
	public decimal? dcGiaTriThucHienDaNghiemThuAB { get; set; }
	public decimal? dcSoChuaGNChoNhaThauTheoNghiemThuAB { get; set; }

}