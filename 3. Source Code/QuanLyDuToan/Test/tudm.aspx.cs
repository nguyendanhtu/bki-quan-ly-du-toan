using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using System.Globalization;
using SQLDataAccess;
using WebUS;
using DBClassModel;
using Framework.Extensions;

namespace QuanLyDuToan.Test
{
	public partial class tudm : System.Web.UI.Page
	{
		public class GroupDonVi
		{
			public string groupKey { get; set; }
			public string groupText { get; set; }

			public GroupDonVi(string groupKey, string groupText)
			{
				this.groupKey = groupKey;
				this.groupText = groupText;
			}

		}
		protected void Page_Load(object sender, EventArgs e)
		{
			m_dat_tu_ngay = new DateTime(2015, 06, 01);
			m_dat_den_ngay = new DateTime(2015, 06, 07);
			m_dat_dau_nam = new DateTime(2015, 01, 01);

			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_don_vi = db.DM_DON_VI
							.ToList()
							.Select(x => x.CopyAs<DBClassModel.DM_DON_VI>())
							.OrderBy(x => x.TEN_DON_VI)
							.ToList();

			m_lst_group_by = new List<GroupDonVi>{
							new GroupDonVi("cục quản lý đường bộ I.","Cục QLĐB I")
							,new GroupDonVi("cục quản lý đường bộ II.","Cục QLĐB II")
							,new GroupDonVi("cục quản lý đường bộ III.","Cục QLĐB III")
							,new GroupDonVi("cục quản lý đường bộ IV.","Cục QLĐB IV")
			};

			m_lst_don_vi_group_by = new List<DBClassModel.DM_DON_VI>();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giai_ngan= db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
		}
		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		public List<GroupDonVi> m_lst_group_by;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi_group_by;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;

	}
}