// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


//NHI?M V? C?A CLASS
//
//
// tabPage
//
//
//

namespace IP.Core.IPCommon
{
	public class CTabPageUtils
	{
		public static void loadForm_2_TabPage(System.Windows.Forms.Form i_form, 
			System.Windows.Forms.TabPage i_tabpage)
		{
			Debug.Assert(!(i_form == null), "Khong khoi tao form");
			Debug.Assert(!(i_tabpage == null), "Khong khoi tao tabpage");
			i_form.TopLevel = false;
			i_form.Dock = System.Windows.Forms.DockStyle.Fill;
			i_form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			i_tabpage.Controls.Clear();
			i_tabpage.Controls.Add(i_form);
		}
	}
	
}
