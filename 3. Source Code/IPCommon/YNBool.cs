// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


//NHIỆM VỤ:
//
//   Thực hiện BOOL Algebra trên giá trị Y/N
//


namespace IP.Core.IPCommon
{
	public class YNBool
	{
		private const string C_YES = "Y";
		private const string C_NO = "N";
		
		//Chuyển từ Boolean sang Y_N
		public static string Boolean2YN(bool i_bBoolean)
		{
			if (i_bBoolean)
			{
				return C_YES;
			}
			else
			{
				return C_NO;
			}
		}
		//Chuyển từ Y_N sang Boolean
		public static bool YN2Boolean(string i_strYN)
		{
			if (i_strYN == C_YES)
			{
				return true;
			}
			else
			{
				if (i_strYN == C_NO)
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
		//
		public static string Negalt(string i_strYN)
		{
			if (i_strYN == C_YES)
			{
				return C_NO;
			}
			else if (i_strYN == C_NO)
			{
				return C_YES;
			}
			else
			{
				Debug.Assert(false, "Khong phai la YN string");
			}
			return "";
		}
	}
	
}
