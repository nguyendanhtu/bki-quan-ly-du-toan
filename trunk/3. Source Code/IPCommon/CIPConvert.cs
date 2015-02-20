// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class CIPConvert
	{
		public CIPConvert()
		{
			// VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
			m_obj_culture = System.Globalization.CultureInfo.CurrentCulture;

		}
		//Private Shared m_obj_culture As New System.Globalization.CultureInfo("vi-VN")
		//Private Shared m_obj_culture As New System.Globalization.CultureInfo("en_US")

		private static System.Globalization.CultureInfo m_obj_culture = System.Globalization.CultureInfo.CurrentCulture; 

		#region Convert from Boolean to YN and reversed
		public static string ToYNString(bool i_bBoolean)
		{
			if (i_bBoolean)
			{
				return "Y";
			}
			else
			{
				return "N";
			}
		}

		public static string ToYNString(object i_obj_Boolean)
		{
			Debug.Assert((i_obj_Boolean) is bool, "Doi tuong truyen vao ham ToYNString phai co kieu Boolean");
			if (System.Convert.ToBoolean(i_obj_Boolean))
			{
				return "Y";
			}
			else
			{
				return "N";
			}
		}

		public static bool ToBoolean(string i_str_YN)
		{
			switch (i_str_YN)
			{
				case "Y":
					return true;
				case "N":
					return false;
				default:
					Debug.Assert(false, "Xau truyen vao ham ToBoolean cua IPConvert khong hop le - tuanqt");
					break;
			}
			return default(bool);
		}

		public static bool ToBoolean(object i_obj_YN)
		{
			Debug.Assert(!(i_obj_YN == null), "doi tuong truyen vao CIPConvert.ToBoolean phai khac nothing - tuanqt");
			Debug.Assert((i_obj_YN) is string, "Doi tuong truyen vao CIPConvert.ToBoolean phai co kieu string - tuanqt");
			string v_str_temp = System.Convert.ToString(i_obj_YN);
			switch (v_str_temp)
			{
				case "Y":
					return true;
				case "N":
					return false;
				default:
					Debug.Assert(false, "Xau truyen vao ham ToBoolean cua IPConvert khong hop le - tuanqt");
					break;
			}
			return default(bool);
		}
		#endregion

		#region Convert to String from another type
		public static string ToStrInQuery(decimal i_dc_Input)
		{
			System.Globalization.NumberFormatInfo v_objFormat = new System.Globalization.NumberFormatInfo();
			v_objFormat.NumberDecimalSeparator = ".";
			return System.Convert.ToString(i_dc_Input, v_objFormat);
		}

		public static string ToStr(decimal i_dc_Input)
		{
			return Convert.ToString(i_dc_Input, m_obj_culture.NumberFormat);
		}

		public static string ToStr(decimal i_dc_input, string i_str_format)
		{
			return Convert.ToString(string.Format(
				m_obj_culture.NumberFormat
				, "{0:" + i_str_format + "}"
				, i_dc_input), m_obj_culture.NumberFormat);
		}

		public static string ToStr(DateTime i_dat_Input)
		{
			return Convert.ToString(
				string.Format("{0:dd/MM/yyyy}"
				, i_dat_Input)
				, m_obj_culture.DateTimeFormat);
		}

		public static string ToStr(DateTime i_dat_Input, string i_str_format)
		{
			return Convert.ToString(
				string.Format("{0:" + i_str_format + "}"
				, i_dat_Input)
				, m_obj_culture.DateTimeFormat);
		}

		public static string ToStr(object i_obj_Input)
		{
			Debug.Assert(!(i_obj_Input == null), "Tham so truyen vao ham ToStr phai khac nothing");
			switch (i_obj_Input.GetType().ToString())
			{
				case "System.Decimal":
					return ToStr(System.Convert.ToDecimal(i_obj_Input));
				case "System.DateTime":
					return ToStr(System.Convert.ToDateTime(i_obj_Input));
				default:
					return System.Convert.ToString(i_obj_Input);
			}
		}

		public static string ToStr(object i_obj_Input, string i_str_format)
		{
			Debug.Assert(!(i_obj_Input == null), "Tham so truyen vao ham ToStr phai khac nothing");
			Debug.Assert(!(i_obj_Input == null), "Tham so truyen vao ham ToStr phai khac nothing");
			switch (i_obj_Input.GetType().ToString())
			{
				case "System.Decimal":
					return ToStr(System.Convert.ToDecimal(i_obj_Input), i_str_format);
				case "System.DateTime":
					return ToStr(System.Convert.ToDateTime(i_obj_Input), i_str_format);
				default:
					return System.Convert.ToString(i_obj_Input);
			}
		}
		#endregion

		#region Convert to Decimal from another type
		public static decimal ToDecimal(string i_str_input)
		{
			return Convert.ToDecimal(i_str_input, m_obj_culture.NumberFormat);
		}

		public static decimal ToDecimal(object i_obj_input)
		{
			Debug.Assert(!(i_obj_input == null), "Doi tuong truyen vao ham ToDecimal phai khac nothing - tuanqt");
			return Convert.ToDecimal(i_obj_input, m_obj_culture.NumberFormat);
		}

		public static bool is_valid_number(string i_str_input)
		{
			try
			{
				ToDecimal(i_str_input);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool is_valid_number(object i_obj_input)
		{
			try
			{
				ToDecimal(i_obj_input);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string get_default_dec_format()
		{
			return "#,###";
		}
		#endregion

		#region Convert to Datetime from another type
		public static DateTime ToDatetime(string i_str_date)
		{
			System.DateTime v_myDateTime = default(System.DateTime);
			//Neu khong truyen vao format thi lay format ngam dinh
			string v_strFormat = m_obj_culture.DateTimeFormat.ShortDatePattern;
			v_myDateTime = System.DateTime.ParseExact(i_str_date,
				get_default_date_format(),
				m_obj_culture.DateTimeFormat);
			return v_myDateTime;
		}

		public static DateTime ToDatetime(string i_str_date, string i_str_format)
		{
			System.DateTime v_myDateTime = default(System.DateTime);
			//Neu truyen vao format thi lay format
			string v_strFormat = m_obj_culture.DateTimeFormat.ShortDatePattern;
			v_myDateTime = System.DateTime.ParseExact(i_str_date,
				i_str_format,
				m_obj_culture);
			return v_myDateTime;
		}

		public static DateTime ToDatetime(object i_obj_date)
		{
			Debug.Assert(!(i_obj_date == null), "Doi tuong truyen vao ham ToDecimal phai khac nothing - tuanqt");
			Debug.Assert((i_obj_date) is string, "Doi tuong truyen vao ham ToDate phai co kieu string - tuanqt");
			string v_str_temp_date = System.Convert.ToString(i_obj_date);
			return ToDatetime(v_str_temp_date);
		}

		public static DateTime ToDatetime(object i_obj_date, string i_str_format)
		{
			Debug.Assert(!(i_obj_date == null), "Doi tuong truyen vao ham ToDecimal phai khac nothing - tuanqt");
			Debug.Assert((i_obj_date) is string, "Doi tuong truyen vao ham ToDate phai co kieu string - tuanqt");
			string v_str_temp_date = System.Convert.ToString(i_obj_date);
			return ToDatetime(v_str_temp_date, i_str_format);
		}

		public static bool is_valid_datetime(string i_str_input)
		{
			try
			{
				ToDatetime(i_str_input);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool is_valid_datetime(object i_obj_input)
		{
			try
			{
				ToDatetime(i_obj_input);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static bool is_valid_datetime(object i_obj_input, string i_str_format)
		{
			try
			{
				ToDatetime(i_obj_input, i_str_format);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		public static string Date_fromUs_toDisplayStr(DateTime i_date)
		{
			if (i_date == IPConstants.c_DefaultDate)
			{
				return string.Empty;
			}
			else
			{
				return ToStr(i_date);
			}
		}

		public static string get_default_date_format()
		{
			return "dd/MM/yyyy";
		}
		#endregion

		#region  Encode & Deciphering
		private static string m_str_header = "usvndp";
		private static string m_str_footer = "iejrjk";
		public static string Encoding(string i_str)
		{
			string o_str_encode = "";
			int v_i = 0;
			int v_dc_len = i_str.Length;
			int v_dc_str = 0;
			o_str_encode = m_str_header;
			for (v_i = 1; v_i <= v_dc_len; v_i++)
			{
				v_dc_str = Convert.ToInt16(Convert.ToChar(i_str.Substring(v_i - 1, 1)));
				v_dc_str = v_dc_str + v_i;
				o_str_encode = o_str_encode + Convert.ToString(Convert.ToChar(v_dc_str));
			}
			o_str_encode = o_str_encode + m_str_footer;
			return o_str_encode;
		}
		public static string Deciphering(string i_str)
		{
			string o_str_deciphering = "";
			int v_i = 0;
			int v_dc_str = 0;
			i_str = i_str.Substring(0, i_str.Length - m_str_footer.Length);
			i_str = i_str.Substring(m_str_header.Length);
			int v_dc_len = i_str.Length;
			for (v_i = 1; v_i <= v_dc_len; v_i++)
			{
				v_dc_str = Convert.ToInt16(Convert.ToChar(i_str.Substring(v_i - 1, 1)));
				v_dc_str = v_dc_str - v_i;
				o_str_deciphering = o_str_deciphering + Convert.ToString(Convert.ToChar(v_dc_str));
			}
			return o_str_deciphering;
		}
		public static string Encoding(decimal i_dc)
		{
			string o_str_encoding = "";
			o_str_encoding = Encoding(ToStr(i_dc));
			return o_str_encoding;
		}
		public static string Encoding(DateTime i_dat)
		{
			string o_str_encoding = "";
			o_str_encoding = Encoding(ToStr(i_dat));
			return o_str_encoding;
		}
		#endregion

	}

}
