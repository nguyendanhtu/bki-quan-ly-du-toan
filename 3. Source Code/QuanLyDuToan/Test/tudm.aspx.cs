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
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_chuong = db.DM_CHUONG_LOAI_KHOAN_MUC
							.Where(x => x.ID_LOAI == ID_CHUONG_LOAI_KHOAN_MUC.CHUONG)
							.ToList()
							.Select(x => x.CopyAs<DBClassModel.DM_CHUONG_LOAI_KHOAN_MUC>())
							.ToList();
		}

		public List<DBClassModel.DM_CHUONG_LOAI_KHOAN_MUC> m_lst_chuong;

	}
}