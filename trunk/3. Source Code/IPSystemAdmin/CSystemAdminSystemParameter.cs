// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports


namespace IP.Core.IPSystemAdmin
{
	public enum eSystemAdminSysParaEnum
	{
		CHUA_DINH_NGHIA = 0
	}
	
	internal class CSystemAdminSystemParameter
	{
		public static string get_ma_tham_so(eSystemAdminSysParaEnum i_eMa)
		{
			switch (i_eMa)
			{
				default:
					Debug.Assert(false, "Khong ma tham so nay trong enum eSchoolSysParaEnum");
					break;
			}
			return "";
		}
	}
	
}
