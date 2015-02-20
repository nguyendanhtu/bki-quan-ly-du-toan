// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports




namespace IP.Core.IPException
{
	public class CDBSoapDBExceptionInterpret : IPException.IDBExceptionInterpret
	{
		public IPException.CDBExceptionHandler.DBErrorIndex getDBErrorIndex(System.Exception i_ExceptionToHandler)
		{
			CDBExceptionHandler.DBErrorIndex v_ErrorIndex = default(CDBExceptionHandler.DBErrorIndex);
			if (i_ExceptionToHandler.Message.IndexOf("UNIQUE") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.DuplicateIndex;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("CONNECT") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.NoDBConnection;
			}
			else
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.OtherDBException;
			}
			return v_ErrorIndex;
		}
	}
	
	public class CDBClientDBExceptionInterpret : IPException.IDBExceptionInterpret
	{
		public IPException.CDBExceptionHandler.DBErrorIndex getDBErrorIndex(System.Exception i_ExceptionToHandler)
		{
			CDBExceptionHandler.DBErrorIndex v_ErrorIndex = default(CDBExceptionHandler.DBErrorIndex);
			if (i_ExceptionToHandler.Message.IndexOf("UNIQUE") > -1 
				|| i_ExceptionToHandler.Message.IndexOf("PRIMARY KEY") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.DuplicateIndex;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("FOREIGN KEY") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.NoParentFound;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("PARENT") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.NoParentFound;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("NULL") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.NullValueNotAllowed;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("REFERENCE") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.ChildRecordFound;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("CONNECT") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.NoDBConnection;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("Lock request") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.LockTimeOut;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("RECORD_DELETED") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.RecordDeleted;
			}
			else if (i_ExceptionToHandler.Message.IndexOf("RECORD_CHANGED") > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.RecordChanged;
			}
			else if (i_ExceptionToHandler.Message.IndexOf(CBSProcessLockException.C_BSLockProcess_Exception_Name) > -1)
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.BusinessProcessLock;
			}
			else
			{
				v_ErrorIndex = CDBExceptionHandler.DBErrorIndex.OtherDBException;
			}
			return v_ErrorIndex;
		}
	}
	
	
}
