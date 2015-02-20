// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Data.SqlClient;
using Microsoft.VisualBasic.CompilerServices;

namespace IP.Core.IPCommon
{
	public class CMakeAndSelectCmd : IMakeSelectCmd
	{
		protected DataSet m_ds;
		protected object m_TableName;
		protected ICondition[] m_Conditions;
		
		public CMakeAndSelectCmd(DataSet i_ds, string i_strTableName)
		{
			m_ds = i_ds;
			m_TableName = i_strTableName;
		}
		
		private System.Data.SqlClient.SqlCommand getSelectCommand(string i_sDieuKien = "")
		{
			
			return default(System.Data.SqlClient.SqlCommand);
		}
		
		private string getSelectString(SqlCommand i_cmd)
		{
			string v_strSelect = " Select ";
			System.Data.DataColumn v_DataColumn = default(System.Data.DataColumn);
			foreach (System.Data.DataColumn tempLoopVar_v_DataColumn in m_ds.Tables[m_TableName.ToString()].Columns)
			{
				v_DataColumn = tempLoopVar_v_DataColumn;
				v_strSelect += v_DataColumn.ColumnName + ", ";
			}
			v_strSelect = v_strSelect.Substring(0, v_strSelect.Length - 2);
			v_strSelect += " from " + System.Convert.ToString(m_TableName) + " ";
			if (!(m_Conditions == null))
			{
				v_strSelect += " Where " + m_Conditions[0].GetConditionStr();
				i_cmd.Parameters.Add(m_Conditions[0].GetParameter());
				int v_iIndex = 0;
				for (v_iIndex = 1; v_iIndex <= (m_Conditions.Length - 1); v_iIndex++)
				{
					v_strSelect += " AND " + m_Conditions[v_iIndex].GetConditionStr();
					if (!i_cmd.Parameters.Contains(m_Conditions[v_iIndex].GetParameter().ParameterName))
					{
						i_cmd.Parameters.Add(m_Conditions[v_iIndex].GetParameter());
					}
					
				}
			}
			return v_strSelect;
		}
		
		public void AddCondition(string i_strTenTruong, 
			object i_Value, eKieuDuLieu i_KieuDuLieu, eKieuSoSanh i_KieuSoSanh)
		{
			if (!(m_Conditions == null))
			{
				Array.Resize(ref m_Conditions, (m_Conditions.Length - 1) + 1 + 1);
			}
			else
			{
				m_Conditions = new ICondition[1];
			}
			int v_iNewItem = 0;
			v_iNewItem = m_Conditions.Length - 1;
			switch (i_KieuDuLieu)
			{
				case eKieuDuLieu.KieuNumber:
					double v_iDouble = 0;
					try
					{
						v_iDouble = System.Convert.ToDouble(i_Value);
					}
					catch
					{
						Debug.Assert(false, "Sai kieu roi, phai la so - tuanqt trong CMakeAndSelectCmd");
					}
					m_Conditions[v_iNewItem] = new CNumberCondition(i_strTenTruong, v_iDouble, i_KieuSoSanh);
					break;
					
				case eKieuDuLieu.KieuString:
					string v_iStr = "";
					try
					{
						v_iStr = System.Convert.ToString(i_Value);
					}
					catch
					{
						Debug.Assert(false, "Sai kieu roi, phai la xau - tuanqt trong CMakeAndSelectCmd");
					}
					m_Conditions[v_iNewItem] = new CStringCondition(i_strTenTruong, v_iStr, i_KieuSoSanh);
					break;
				case eKieuDuLieu.KieuDate:
					DateTime v_iDate = default(DateTime);
					try
					{
						v_iDate = System.Convert.ToDateTime(i_Value);
					}
					catch
					{
						Debug.Assert(false, "Sai kieu roi, phai la so - tuanqt trong CMakeAndSelectCmd");
					}
					m_Conditions[v_iNewItem] = new CDateCondition(i_strTenTruong, v_iDate, i_KieuSoSanh);
					break;
					
				default:
					Debug.Assert(false, "Chua code kieu nay");
					break;
			}
		}
		
		public string getConditionString()
		{
			Debug.Assert(false, "Chua co code tuanqt");
			return "";
		}
		
		public Collection getParameters()
		{
			Debug.Assert(false, "Chua co code tuanqt");
			return default(Collection);
		}
		
		public SqlCommand getSelectCmd()
		{
			System.Data.SqlClient.SqlCommand v_Cmd = default(System.Data.SqlClient.SqlCommand);
			v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.CommandText = getSelectString(v_Cmd);
			v_Cmd.CommandType = CommandType.Text;
			return v_Cmd;
		}
	}
	
}
