// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Data.SqlClient;


namespace IP.Core.IPCommon
{
	public class CDateCondition : ICondition
	{
		private string m_strFieldName;
		private DateTime m_Value;
		private eKieuSoSanh m_LoaiSoSanh;
		
		public CDateCondition(string i_strFieldName, DateTime i_Value, eKieuSoSanh i_LoaiSoSanh)
		{
			m_strFieldName = i_strFieldName;
			m_Value = i_Value;
			m_LoaiSoSanh = i_LoaiSoSanh;
		}
		
		public string GetConditionStr()
		{
			switch (m_LoaiSoSanh)
			{
				case eKieuSoSanh.Bang:
					return " " + m_strFieldName + " = @" + m_strFieldName;
				case eKieuSoSanh.LonHonHoacBang:
					return " " + m_strFieldName + " >= @" + m_strFieldName;
				case eKieuSoSanh.LonHon:
					return " " + m_strFieldName + " > @" + m_strFieldName;
				case eKieuSoSanh.NhoHon:
					return " " + m_strFieldName + " < @" + m_strFieldName;
				case eKieuSoSanh.NhoHonHoacBang:
					return " " + m_strFieldName + " <= @" + m_strFieldName;
				case eKieuSoSanh.NhoHonHoacBangOrIsNull:
					return " (" + m_strFieldName + " <= @" + m_strFieldName 
						+ " or " + m_strFieldName + " is null )";
				default:
					Debug.Assert(false, "Kieu ngay khong cung loai so sanh nay trong cdateCondition - tuanqt");
					break;
			}
			return "";
		}
		public SqlParameter GetParameter()
		{
			SqlParameter v_para = new SqlParameter();
			v_para.ParameterName = "@" + m_strFieldName;
			v_para.SqlDbType = SqlDbType.DateTime;
			v_para.Value = m_Value;
			v_para.Direction = ParameterDirection.Input;
			return v_para;
		}
	}
	
}
