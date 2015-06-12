using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.UserControls
{
	public partial class F530Grid : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			load_data_to_grid();
		}
		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;
		public List<DM_DON_VI> m_lst_don_vi;
		public List<QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi> m_lst_group_by;
		public List<DM_DON_VI> m_lst_don_vi_group_by;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;

		private void load_data_to_grid()
		{
			//m_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
			//m_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy");
			m_dat_dau_nam = WebUS.CCommonFunction.getDate_dau_nam_from_date(m_dat_tu_ngay);

			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_don_vi = db.DM_DON_VI
							.ToList()
							.OrderBy(x => x.TEN_DON_VI)
							.ToList();

			m_lst_group_by = new List<QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi>{
							new QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi("cục quản lý đường bộ I.","Cục QLĐB I")
							,new QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi("cục quản lý đường bộ II.","Cục QLĐB II")
							,new QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi("cục quản lý đường bộ III.","Cục QLĐB III")
							,new QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.GroupDonVi("cục quản lý đường bộ IV.","Cục QLĐB IV")
			};

			m_lst_don_vi_group_by = new List<SQLDataAccess.DM_DON_VI>();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
		}
		

		public static string RenderToString(DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay)
		{
			return UIUtil.RenderUserControl<F530Grid>("~/UserControls/F530Grid.ascx",
				uc =>
				{
					uc.m_dat_tu_ngay = ip_dat_tu_ngay;
					uc.m_dat_den_ngay = ip_dat_den_ngay;
				});
		}
	}
}