using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebUS;
using SQLDataAccess;
using System.Web.Services;
using Framework.Extensions;


namespace QuanLyDuToan.Test
{
	public partial class Test : System.Web.UI.Page
	{

		#region Public Web Methos

		[WebMethod]
		public static List<GD_CHI_TIET_GIAO_KH> load_data_du_toan()
		{
			 return new BKI_QLDTEntities().GD_CHI_TIET_GIAO_KH.ToList();
		}

		#endregion

		#region Members

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