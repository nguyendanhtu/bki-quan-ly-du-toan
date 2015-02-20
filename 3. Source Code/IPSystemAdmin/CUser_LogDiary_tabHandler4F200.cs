// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using C1.Win.C1FlexGrid;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPSystemAdmin;
using IP.Core.IPException;
using IP.Core.IPBusinessService;

// NHI?M V? C?A CLASS
//
//
//
//
//
//


namespace IP.Core.IPSystemAdmin
{
	public class CUser_LogDiary_tabHandler4F200
	{
		
#region PUBLIC INTERFACE
		public CUser_LogDiary_tabHandler4F200(C1FlexGrid i_fg)
		{
			m_fg = i_fg;
			CControlFormat.setC1FlexFormat(m_fg);
			CGridUtils.AddSearch_Handlers(m_fg);
		}
		
		public void displayData(decimal i_dcID_NSD)
		{
			
			
		}
		
#endregion
		
#region CONSTANTS
		
#endregion
		
#region STRUCTURES
		
#endregion
		
#region MEMBERS
		private C1FlexGrid m_fg;
#endregion
		
#region PRIVATES
		
#endregion
		
		// **********************************************
		//*
		//*  EVENT HANDLERS
		//*
		// **********************************************
		
		
	}
	
}
