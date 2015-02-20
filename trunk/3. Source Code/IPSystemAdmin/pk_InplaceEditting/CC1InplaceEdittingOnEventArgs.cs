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
	public class CC1InplaceEdittingOnEventArgs : EventArgs
	{
		//Member
		protected e_CC1_inplace_editting_next_action m_e_result;
		
		public CC1InplaceEdittingOnEventArgs(e_CC1_inplace_editting_next_action i_e_next_action)
		{
			m_e_result = i_e_next_action;
		}
		
public e_CC1_inplace_editting_next_action next_action
		{
			get
			{
				return m_e_result;
			}
			set
			{
				m_e_result = value;
			}
		}
	}
	
	public enum e_CC1_inplace_editting_next_action
	{
		success_and_change_to_none_status = 0,
		continue_editting = 1,
		cancel_editting = 2
	}
	
}
