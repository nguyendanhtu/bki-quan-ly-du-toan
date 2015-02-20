// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPException
{
	public class CBSProcessLockException : System.Exception
	{
		
		public const string C_BSLockProcess_Exception_Name = "IP_BUSINESS_PROCESS_LOCK_EXCEPTION";
		
		public CBSProcessLockException() : base(C_BSLockProcess_Exception_Name)
		{
		}
	}
	
}
