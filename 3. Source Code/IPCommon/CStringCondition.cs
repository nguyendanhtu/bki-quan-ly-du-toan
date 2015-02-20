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
	public class CStringCondition : ICondition
	{
		private string m_strFieldName;
		private string m_Value;
		private eKieuSoSanh m_LoaiSoSanh;
		
		public CStringCondition(string i_strFieldName, string i_Value, eKieuSoSanh i_LoaiSoSanh)
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
				case eKieuSoSanh.CoChua:
					return " " + m_strFieldName + " LIKE \'%\' + @" + m_strFieldName + " + \'%\'";
				case eKieuSoSanh.BatDauBang:
					return " " + m_strFieldName + " LIKE @" + m_strFieldName + " + \'%\'";
				case eKieuSoSanh.KetThucBang:
					return " " + m_strFieldName + " LIKE \'%\' + @" + m_strFieldName;
				default:
					Debug.Assert(false, "Kieu string khong co loai so sanh nay");
					break;
			}
			return "";
		}
		
		public SqlParameter GetParameter()
		{
			SqlParameter v_para = new SqlParameter();
			v_para.ParameterName = "@" + m_strFieldName;
			v_para.SqlDbType = SqlDbType.NVarChar;
			v_para.Value = m_Value;
			v_para.Direction = ParameterDirection.Input;
			
			return v_para;
		}
		
	}
	
}
