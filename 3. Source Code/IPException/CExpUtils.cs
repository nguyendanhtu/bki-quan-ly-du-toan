// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPException
{
	public class CExpUtils
	{
		public static CDBExceptionHandler get_CS_ExpHandler(Exception i_e)
		{
			return new CDBExceptionHandler(i_e, new CDBClientDBExceptionInterpret());
		}
	}
	
}
