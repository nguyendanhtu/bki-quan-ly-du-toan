using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.UserControls
{
	public partial class TableGiaoKH : System.Web.UI.UserControl
	{
		public List<pr_F104_nhap_du_toan_ke_hoach_Result> m_lst_gd;

		//public TableGiaoKH(List<pr_F104_nhap_du_toan_ke_hoach_Result> ip_lst_gd)
		//{
		//	m_lst_gd = ip_lst_gd;
		//}

		protected void Page_Load(object sender, EventArgs e)
		{

		}

		#region Public Functions
		public string genClassCSS(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT == "-1")
			{
				//tong
				v_str_op = "tong ";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = " lnv " + ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = " ct " + ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = "da " + ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSo(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "0";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT + ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSoParent(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = "0";
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT;
			}
			return v_str_op;
		}
		#endregion

		public static string RenderToString(List<pr_F104_nhap_du_toan_ke_hoach_Result> ip_lst_gd)
		{
			return UIUtil.RenderUserControl<TableGiaoKH>("~/UserControls/TableGiaoKH.ascx",
				uc =>
				{
					uc.m_lst_gd = ip_lst_gd;
				});
		}
	}
}