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
	public class CC1InplaceEdittingEventArgs : EventArgs
	{
		//Member
		protected bool m_b_continue_2_edit;
		
		public CC1InplaceEdittingEventArgs(bool i_b_continue_2_edit)
		{
			m_b_continue_2_edit = i_b_continue_2_edit;
		}
		
public bool continue_editting
		{
			get
			{
				return m_b_continue_2_edit;
			}
			set
			{
				m_b_continue_2_edit = value;
			}
		}
	}
	
	public enum e_CC1InplaceEdittingMode
	{
		none = 0,
		insert_mode = 1,
		update_mode = 2,
		delete_mode = 3
	}
	
	public enum e_CC1InplaceEditting_NewRowPosition
	{
		next_row = 0,
		last_row = 1
	}
}
