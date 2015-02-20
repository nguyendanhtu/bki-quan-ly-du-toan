// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPCommon
{
	public class CDateTime
	{
		
		private static System.Globalization.CultureInfo m_obj_culture = new System.Globalization.CultureInfo("vi-VN", true);
		
		public static string GetDateFormatString()
		{
			return "dd/MM/yyyy";
		}
		public static bool isValidDateString(string i_strDate, string i_strFormat = "dd/MM/yyyy")
		{
			try
			{
				if (i_strFormat != "")
				{
					Str2Date(i_strDate, i_strFormat);
				}
				else
				{
					Str2Date(i_strDate);
				}
				//chuoi ngay hop le tra ve true
				return true;
			}
			catch (System.Exception)
			{
				//Co exception => chuoi ngay khong hop le
				return false;
			}
			
		}
		
		//Chuyển từ xâu sang ngày với định dạng cho trước
		public static DateTime Str2Date(string i_strDate, string i_strFormat = "dd/MM/yyyy")
		{
			System.Globalization.CultureInfo v_format = new System.Globalization.CultureInfo("vi-VN");
			System.DateTime v_myDateTime = default(System.DateTime);
			
			//Neu khong truyen vao format thi lay format ngam dinh
			string v_strFormat = "";
			if (i_strFormat == "")
			{
				v_strFormat = GetDateFormatString();
			}
			else
			{
				v_strFormat = i_strFormat;
			}
			
			v_myDateTime = System.DateTime.ParseExact(i_strDate, 
				v_strFormat, 
				v_format);
			return v_myDateTime;
		}
		// chuyển sang sâu ngày vn
		public static string Date2Str_VNFormat(DateTime i_date)
		{
			return Strings.Format(i_date, GetDateFormatString());
		}
		//
		public static string Date_fromUs_toDisplayStr(DateTime i_date)
		{
			if (i_date == IPConstants.c_DefaultDate)
			{
				return string.Empty;
			}
			else
			{
				return Date2Str_VNFormat(i_date);
			}
		}
	}
	
}
