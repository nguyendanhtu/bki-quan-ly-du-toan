// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports




namespace IP.Core.IPCommon
{
	public class CDBUtils
	{
		const string C_WRONG_PARAM_NAME = "CSUNG- TÊN Tham số không bắt đầu bằng @. Kiểm tra lại";
		const string C_PREFIX_OF_PARAM = "@";
		public static System.Data.SqlClient.SqlParameter getImageInputParam(string ip_name, 
			object ip_value)
		{
			try
			{
				Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
				System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
				v_sqlPara.SqlDbType = SqlDbType.Image;
				v_sqlPara.Direction = ParameterDirection.Input;
				v_sqlPara.Value = ip_value;
				v_sqlPara.ParameterName = ip_name;
				return v_sqlPara;
			}
			catch (Exception v_ex)
			{
				throw (v_ex);
			}
		}
		
		public static System.Data.SqlClient.SqlParameter getImageOutputParam(string ip_name, 
			object ip_value)
		{
			try
			{
				Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
				System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
				v_sqlPara.SqlDbType = SqlDbType.Image;
				v_sqlPara.Direction = ParameterDirection.Output;
				v_sqlPara.Value = ip_value;
				v_sqlPara.ParameterName = ip_name;
				return v_sqlPara;
			}
			catch (Exception v_ex)
			{
				throw (v_ex);
			}
		}
		public static System.Data.SqlClient.SqlParameter getDecimalInputParam(string ip_name, 
			object ip_value)
		{
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			v_sqlPara.SqlDbType = SqlDbType.Decimal;
			v_sqlPara.Direction = ParameterDirection.Input;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			return v_sqlPara;
		}
		
		
		public static System.Data.SqlClient.SqlParameter getDecimalOutputParam(string ip_name, 
			object ip_value)
		{
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			
			v_sqlPara.SqlDbType = SqlDbType.Decimal;
			v_sqlPara.Direction = ParameterDirection.Output;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			
			return v_sqlPara;
		}
		
		public static System.Data.SqlClient.SqlParameter getDateTimeInputParam(string ip_name, 
			object ip_value)
		{
			
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			v_sqlPara.SqlDbType = SqlDbType.DateTime;
			v_sqlPara.Direction = ParameterDirection.Input;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			return v_sqlPara;
		}
		
		public static System.Data.SqlClient.SqlParameter getDateTimeOutputParam(string ip_name, 
			object ip_value)
		{
			
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			
			v_sqlPara.SqlDbType = SqlDbType.DateTime;
			v_sqlPara.Direction = ParameterDirection.Output;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			return v_sqlPara;
		}
		
		public static System.Data.SqlClient.SqlParameter getNVarcharInputParam(string ip_name, 
			object ip_value)
		{
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			v_sqlPara.SqlDbType = SqlDbType.NVarChar;
			v_sqlPara.Direction = ParameterDirection.Input;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			return v_sqlPara;
		}
		
		public static System.Data.SqlClient.SqlParameter getNVarcharOutputParam(string ip_name, 
			object ip_value, int ip_size_of_value = 100)
		{
			Debug.Assert(ip_name.IndexOf(C_PREFIX_OF_PARAM) >= 0, C_WRONG_PARAM_NAME);
			System.Data.SqlClient.SqlParameter v_sqlPara = new System.Data.SqlClient.SqlParameter();
			
			v_sqlPara.SqlDbType = SqlDbType.NVarChar;
			v_sqlPara.Direction = ParameterDirection.Output;
			v_sqlPara.Value = ip_value;
			v_sqlPara.ParameterName = ip_name;
			v_sqlPara.Size = ip_size_of_value;
			return v_sqlPara;
		}
		
		public static void Rollback_Without_Closing_Connection(System.Data.SqlClient.SqlTransaction i_trans)
		{
			try
			{
				i_trans.Rollback();
			}
			catch
			{
				
			}
		}
	}
	
	
	
}
