// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPException
{
	public interface IDBExceptionInterpret
	{
		IPException.CDBExceptionHandler.DBErrorIndex getDBErrorIndex(System.Exception i_ExceptionToHandler);
	}
	
}
