// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class CConvert
	{
		//Ham chuyen tu so sang xau khong quan tam toi Culture
		public static string Decimal2String(decimal i_dcIn)
		{
			System.Globalization.NumberFormatInfo v_objFormat = new System.Globalization.NumberFormatInfo();
			v_objFormat.NumberDecimalSeparator = ".";
			return System.Convert.ToString(i_dcIn, v_objFormat);
		}
		
		//Hàm chuyển từ xâu ra số, Nếu là chuỗi rỗng thì trả về giá trị mặc định
		public static decimal Str2Number(string i_strNumber, decimal i_DefaultValue = 0)
		{
			if (i_strNumber == null || i_strNumber == "")
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDecimal(i_strNumber);
			}
		}
		
		//Chuyển từ Boolean sang Y_N
		public static string Boolean2YN(bool i_bBoolean)
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
		
		//Chuyển từ Y_N sang Boolean
		public static bool YN2Boolean(string i_strYN)
		{
			if (i_strYN == "Y")
			{
				return true;
			}
			else
			{
				if (i_strYN == "N")
				{
					return false;
				}
				else
				{
					Debug.Assert(false);
					//Nếu chương trình bị dừng ở đây
					//thì chuỗi truyền vào là không hợp lệ
				}
			}
			return default(bool);
		}
		
		
	}
	
}
