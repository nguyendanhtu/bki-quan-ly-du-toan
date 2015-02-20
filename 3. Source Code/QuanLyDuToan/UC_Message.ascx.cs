using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

namespace QuanLyDuToan
{
	public partial class UC_Message : System.Web.UI.UserControl
	{
		public string strClassMessage="alert alert-";
		public void setMessage(string ip_str_mess_title, string ip_str_mess_content, eMessageType eMessageType)
		{
			m_lbl_mess_title.Text = ip_str_mess_title;
			m_lbl_mess_content.Text = ip_str_mess_content;
			switch (eMessageType)
			{
				case eMessageType.Warning:
					strClassMessage += "warning";
					break;
				case eMessageType.Error:
					strClassMessage += "danger";
					break;
				case eMessageType.Success:
					strClassMessage += "success";
					break;
				case eMessageType.Info:
					strClassMessage += "info";
					break;
				default:
					break;
			}
		}

		#region Data Structures
		
		#endregion
		protected void Page_Load(object sender, EventArgs e)
		{
			
		}
	}
}