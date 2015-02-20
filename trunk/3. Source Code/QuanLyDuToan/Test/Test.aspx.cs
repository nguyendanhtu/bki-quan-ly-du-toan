using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebUS;
//using QLDT.SQLDataAccess;
using System.Web.Services;
//using Framework.Extensions;

namespace QuanLyDuToan.Test
{
	public partial class Test : System.Web.UI.Page
	{
		public class NguoiSuDungItem
		{
			public decimal ID { get; set; }
			public string TEN_TRUY_CAP { get; set; }
			public string TEN { get; set; }
			public string MAT_KHAU{get;set;}
		}
		#region Public Web Methos

		[WebMethod]
		public static NguoiSuDungItem[] getList_HT_NGUOI_SU_DUNG()
		{
			//BKI_QLDTEntities dbEntities = new BKI_QLDTEntities();
			//var data = (from item in dbEntities.HT_NGUOI_SU_DUNG
			//			orderby item.ID
			//			select item).Take(5).Select(x => new NguoiSuDungItem { ID = x.ID, TEN = x.TEN, TEN_TRUY_CAP = x.TEN_TRUY_CAP, MAT_KHAU=x.MAT_KHAU });
			//return data.ToArray();
			return null;
		}

		#endregion

		#region Members
		//private static BKI_QLDTEntities db = new BKI_QLDTEntities();
		#endregion

		#region Data Structures

		#endregion

		#region Private Methods
		private void showMessage()
		{
			UC_Message v_uc = new UC_Message();
			this.Form.Controls.Add(v_uc);
			//gen random eMessageType
			string[] names = Enum.GetNames(typeof(eMessageType));
			Random random = new Random();
			int randomEnum = random.Next(names.Length);
			eMessageType ret = (eMessageType)Enum.Parse(typeof(eMessageType), names[randomEnum]);

			m_uc_message.setMessage("Thông báo", "Đang test control", ret);
		}

		
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				if (!IsPostBack)
				{
					showMessage();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		

		protected void m_cmd_mess_click_Click(object sender, EventArgs e)
		{
			try
			{
				showMessage();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		#endregion
		
	}
}