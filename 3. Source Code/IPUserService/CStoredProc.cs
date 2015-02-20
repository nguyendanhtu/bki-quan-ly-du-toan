// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPCommon;

//
//
//
//

namespace IP.Core.IPUserService
{
	public class CStoredProc
	{
		private System.Data.SqlClient.SqlCommand m_SqlCommand = new System.Data.SqlClient.SqlCommand();
		
		public CStoredProc(string i_strProcName)
		{
			m_SqlCommand.CommandText = i_strProcName;
			m_SqlCommand.CommandType = CommandType.StoredProcedure;
		}
		public System.Data.SqlClient.SqlParameter addDecimalInputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getDecimalInputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addNVarcharInputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getNVarcharInputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addDatetimeInputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getDateTimeInputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addImageInputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getImageInputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public void ExecuteCommand(US_Object i_UsObject)
		{
			i_UsObject.ExecCommand(this.m_SqlCommand);
		}
		
		public System.Data.SqlClient.SqlParameter addDecimalOutputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getDecimalOutputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addNVarcharOutputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getNVarcharOutputParam(ip_name, ip_value, 100));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addDatetimeOutputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getDateTimeOutputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public System.Data.SqlClient.SqlParameter addImageOutputParam(string ip_name, 
			object ip_value)
		{
			
			System.Data.SqlClient.SqlParameter v_sqlPara = 
				m_SqlCommand.Parameters.Add(CDBUtils.getImageOutputParam(ip_name, ip_value));
			return v_sqlPara;
		}
		
		public void fillDataSetByCommand(US_Object i_us, DataSet i_ds)
		{
			Debug.Assert(!(i_ds == null), "DS chua khoi tao");
			Debug.Assert(!(i_us == null), "US chua khoi tao");
			i_us.FillDatasetByCommand(i_ds, this.m_SqlCommand);
		}
	}
	
}
