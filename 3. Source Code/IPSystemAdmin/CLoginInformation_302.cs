// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPUserService;

namespace IP.Core.IPSystemAdmin
{
	public class CLoginInformation_302
	{
#region Nhiệm vụ của Class
		//************************************************
		//* Chứa thông tin đăng nhập - dùng cho form login (f102)
		//*
		//************************************************
#endregion
		
		public US_HT_NGUOI_SU_DUNG m_us_user;
		//Public m_strMaPhanHe As String
		
		public CLoginInformation_302(US_HT_NGUOI_SU_DUNG i_us_user)
		{
			m_us_user = i_us_user;
			
			// m_strMaPhanHe = i_strMaPhanHe
		}
		
	}
	
	
	
}
