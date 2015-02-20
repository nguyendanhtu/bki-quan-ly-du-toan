// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class CNullOfRow
	{
		private DataRow m_dr;
		
		public void ReferenceToRow(DataRow i_dr)
		{
			m_dr = i_dr;
		}
		
		public bool IsNull(string i_FieldName)
		{
			return m_dr.IsNull(i_FieldName);
		}
		
		public decimal NVLDecimal(string i_FieldName, decimal i_DefaultValue = 0)
		{
			if (m_dr.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDecimal(m_dr[i_FieldName]);
			}
		}
		
		public DateTime NVLDate(string i_FieldName, DateTime i_DefaultValue = default(DateTime))
		{
			// VBConversions Note: i_DefaultValue assigned to default value below, since optional parameter values must be static and C# doesn't support date literals.
			if (i_DefaultValue == default(DateTime))
				i_DefaultValue = DateTime.Parse("1/1/1900");
			if (m_dr.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDateTime(m_dr[i_FieldName]);
			}
		}
		
		public string NVLString(string i_FieldName, string i_DefaultValue = "")
		{
			if (m_dr.IsNull(i_FieldName))
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToString(m_dr[i_FieldName]);
			}
		}
	}
}
