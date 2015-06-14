using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

namespace QuanLyDuToan.UserControls
{
	public partial class F350Grid : System.Web.UI.UserControl
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			load_data_to_grid();
		}

		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;

		public decimal m_dc_id_don_vi;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;
		public List<SQLDataAccess.CM_DM_TU_DIEN> m_lst_loai_nhiem_vu;

		private void load_data_to_grid()
		{
			// kiem tra du lieu

			m_dat_dau_nam = CCommonFunction.getDate_dau_nam_from_date(m_dat_tu_ngay);
			//m_dc_id_don_vi = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);

			BKI_QLDTEntities db = new BKI_QLDTEntities();

			m_lst_loai_nhiem_vu = db.CM_DM_TU_DIEN
									.Where(x => x.ID_LOAI_TU_DIEN == WebUS.ID_LOAI_TU_DIEN.LOAI_NHIEM_VU
										|| x.ID == WebUS.ID_LOAI_NHIEM_VU_NS.DU_TOAN_CHI_NS_NN)
									.OrderBy(x => x.ID_LOAI_TU_DIEN)
									.ThenBy(x => x.GHI_CHU)
									.ToList();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay
											&& x.ID_DON_VI == m_dc_id_don_vi)
								.ToList();

		}

		public static string RenderToString(DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay, decimal ip_dc_don_vi)
		{
			return UIUtil.RenderUserControl<F350Grid>("~/UserControls/F350Grid.ascx",
				uc =>
				{
					uc.m_dat_tu_ngay = ip_dat_tu_ngay;
					uc.m_dat_den_ngay = ip_dat_den_ngay;
					uc.m_dc_id_don_vi = ip_dc_don_vi;
				});
		}
	}
}