using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using IP.Core.IPException;
//NHIỆM VỤ CỦA CLASS
//
//  Thực hiện các phép lock trên 1 business process
//  User có thể tạo ra 1 lock , và release nó
//
//
//
namespace IP.Core.IPBusinessService
{
	public class CBusinessProcessLock
	{
		
#region Members
		private string m_strLockName;
		private bool m_lock_granted = false;
		private BS_Object m_bs_object;
#endregion
		
		
#region PUBLIC INTERFACE
		
		public CBusinessProcessLock(string i_strLockName)
		{
			Debug.Assert(i_strLockName != "", "lock name khong duoc rong");
			m_strLockName = i_strLockName;
			m_bs_object = new BS_Object();
			System.Data.SqlClient.SqlTransaction v_tran;
			v_tran = m_bs_object.BeginTransaction();
			// tạo lock và commit
			check_and_make_Lock_in_DB(m_strLockName);
			m_bs_object.CommitTransWithoutCloseConnection();
			
			subcribe_lock_in_DB(m_strLockName);
			//không kết thúc tran và không commit tra
			m_lock_granted = true;
		}
		
		public void releaseLock()
		{
			Debug.Assert(m_lock_granted, "KHONG CO LOCK , KHONG THE RELEASE DUOC  - CSUNG");
			//release_Lock_in_DB(m_strLockName)
			m_lock_granted = false;
			m_bs_object.CommitTransaction();
		}
		
		
#endregion
		
#region PRIVATES
		
		
		private void check_and_make_Lock_in_DB(string i_strLockName)
		{
			Debug.Assert(i_strLockName != "", "LOCK NAME PHAI KHAC RONG - CSUNG");
			try
			{
				System.Data.SqlClient.SqlCommand v_sqlCommand = new System.Data.SqlClient.SqlCommand();
				v_sqlCommand.CommandType = CommandType.StoredProcedure;
				v_sqlCommand.CommandText = "pr_check_and_make_bp_lock_123";
				
				System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
				v_sqlPara.SqlDbType = SqlDbType.NChar;
				v_sqlPara.Direction = ParameterDirection.Input;
				v_sqlPara.ParameterName = "@ip_lock_name";
				v_sqlPara.Value = i_strLockName;
				v_sqlCommand.Parameters.Add(v_sqlPara);
				m_bs_object.ExecCommand(v_sqlCommand);
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_e_handler = new CDBExceptionHandler(
					v_e, 
					new CDBClientDBExceptionInterpret());
				if (v_e_handler.getDBErrorIndex() == CDBExceptionHandler.DBErrorIndex.DuplicateIndex)
				{
					throw (new CBSProcessLockException());
				}
				else
				{
					throw (v_e);
				}
			}
		}
		
		private void subcribe_lock_in_DB(string i_strLockName)
		{
			
			try
			{
				System.Data.SqlClient.SqlCommand v_sqlCommand = new System.Data.SqlClient.SqlCommand();
				v_sqlCommand.CommandType = CommandType.StoredProcedure;
				v_sqlCommand.CommandText = "pr_Lock_Business_Process_124";
				System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
				v_sqlPara.SqlDbType = SqlDbType.NChar;
				v_sqlPara.Direction = ParameterDirection.Input;
				v_sqlPara.ParameterName = "@ip_lock_name";
				v_sqlPara.Value = i_strLockName;
				v_sqlCommand.Parameters.Add(v_sqlPara);
				m_bs_object.ExecCommand(v_sqlCommand);
				
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_e_handler = new CDBExceptionHandler(
					v_e, 
					new CDBClientDBExceptionInterpret());
				if (v_e_handler.getDBErrorIndex() == CDBExceptionHandler.DBErrorIndex.DuplicateIndex)
				{
					throw (new CBSProcessLockException());
				}
				else
				{
					throw (v_e);
				}
			}
		}
		
#endregion
		
	}
	
}
