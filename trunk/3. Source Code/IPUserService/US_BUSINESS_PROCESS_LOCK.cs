// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPBusinessService;

//NHIỆM VỤ CỦA CLASS
//
//
//
//
//
//



namespace IP.Core.IPUserService
{
	public class US_BUSINESS_PROCESS_LOCK
	{
		
		private CBusinessProcessLock m_bp_Lock;
		
#region PUBLIC INTERFACE
		public US_BUSINESS_PROCESS_LOCK(string i_strLockName)
		{
			Debug.Assert(i_strLockName != "", "CSUNG - lock phai co ten chu");
			m_bp_Lock = new CBusinessProcessLock(i_strLockName);
		}
		
		public void releaseLock()
		{
			m_bp_Lock.releaseLock();
		}
#endregion
		
		
	}
	
}
