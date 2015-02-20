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
	public interface IMakeSelectCmd
	{
		void AddCondition(string i_strTenTruong, 
			object i_Value, 
			eKieuDuLieu i_KieuDuLieu, 
			eKieuSoSanh i_KieuSoSanh);
		string getConditionString();
		Collection getParameters();
		SqlCommand getSelectCmd();
	}
	
	public interface ICondition
	{
		string GetConditionStr();
		SqlParameter GetParameter();
	}
	
	public enum eKieuSoSanh
	{
		LonHon,
		LonHonHoacBang,
		NhoHon,
		NhoHonHoacBang,
		NhoHonHoacBangOrIsNull,
		Bang,
		CoChua,
		BatDauBang,
		KetThucBang
	}
	
	public enum eKieuDuLieu
	{
		KieuNumber,
		KieuString,
		KieuDate
	}
}
