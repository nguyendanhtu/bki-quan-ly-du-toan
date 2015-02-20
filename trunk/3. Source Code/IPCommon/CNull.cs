// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using IP.Core.IPCommon;


namespace IP.Core.IPCommon
{
	public class CNull
	{
		public static decimal RowNVLDecimal(DataRow i_DataRow, string i_FieldName, decimal i_DefaultValue = 0)
		{
			if (i_DataRow.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDecimal(i_DataRow[i_FieldName]);
			}
		}
		
		public static DateTime RowNVLDate(DataRow i_DataRow, string i_FieldName, DateTime i_DefaultValue = default(DateTime))
		{
			// VBConversions Note: i_DefaultValue assigned to default value below, since optional parameter values must be static and C# doesn't support date literals.
			if (i_DefaultValue == default(DateTime))
				i_DefaultValue = DateTime.Parse("1/1/1900");
			if (i_DataRow.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDateTime(i_DataRow[i_FieldName]);
			}
		}
		
		public static string RowNVLString(DataRow i_DataRow, string i_FieldName, string i_DefaultValue = "")
		{
			if (i_DataRow.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToString(i_DataRow[i_FieldName]);
			}
		}
		
		public static decimal NVLDecimal(object i_Object, decimal i_DefaultValue = 0)
		{
			if (i_Object == null)
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDecimal(i_Object);
			}
		}
		
		public static DateTime NVLDate(object i_Object, DateTime i_DefaultValue = default(DateTime))
		{
			// VBConversions Note: i_DefaultValue assigned to default value below, since optional parameter values must be static and C# doesn't support date literals.
			if (i_DefaultValue == default(DateTime))
				i_DefaultValue = DateTime.Parse("1/1/1900");
			if (i_Object == null)
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDateTime(i_Object);
			}
		}
		
		public static string NVLString(object i_Object, string i_DefaultValue = "")
		{
			if (i_Object == null)
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToString(i_Object);
			}
		}
		public static string NVLSqlParameter(System.Data.SqlClient.SqlParameter i_SqlPara, 
			string i_DefaultValue)
		{
			string v_ReturnValue = "";
			if (System.Convert.IsDBNull(i_SqlPara.Value))
			{
				v_ReturnValue = i_DefaultValue;
			}
			else
			{
				v_ReturnValue = System.Convert.ToString(i_SqlPara.Value);
			}
			return v_ReturnValue;
		}
		
		public static decimal NVLSqlParameter(System.Data.SqlClient.SqlParameter i_SqlPara, 
			decimal i_DefaultValue)
		{
			decimal v_ReturnValue = new decimal();
			if (System.Convert.IsDBNull(i_SqlPara.Value))
			{
				v_ReturnValue = i_DefaultValue;
			}
			else
			{
				v_ReturnValue = System.Convert.ToDecimal(i_SqlPara.Value);
			}
			return v_ReturnValue;
		}
		
		public static DateTime NVLSqlParameter(System.Data.SqlClient.SqlParameter i_SqlPara, 
			DateTime i_DefaultValue)
		{
			DateTime v_ReturnValue = default(DateTime);
			if (System.Convert.IsDBNull(i_SqlPara.Value))
			{
				v_ReturnValue = i_DefaultValue;
			}
			else
			{
				v_ReturnValue = System.Convert.ToDateTime(i_SqlPara.Value);
			}
			return v_ReturnValue;
		}
		
		
	}
	
}
