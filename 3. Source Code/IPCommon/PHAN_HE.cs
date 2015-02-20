// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports




namespace IP.Core.IPCommon
{
	public enum SubSystemKey
	{
		QUAN_TRI_HE_THONG = 0,
		CO_SO_DAO_TAO = 1,
		TAI_CHINH = 2,
		HANH_CHINH = 3,
		KE_TOAN = 4
	}
	
	public class PHAN_HE
	{
		
		public class TEN_PHAN_HE
		{
			public const string CO_SO_DAO_TAO = "Cơ sở đào tạo";
			public const string QUAN_TRI_HE_THONG = "Quản trị hệ thống";
			public const string TAI_CHINH = "Tài chính";
			public const string HANH_CHINH = "Hành chính";
			public const string KE_TOAN = "Kế toán";
		}
		
		public class MA_PHAN_HE
		{
			public const string CO_SO_DAO_TAO = "CSDT";
			public const string QUAN_TRI_HE_THONG = "QH";
			public const string TAI_CHINH = "TC";
			public const string HANH_CHINH = "HC";
			public const string KE_TOAN = "KT";
		}
		
		public static string getTen(SubSystemKey i_subsystem)
		{
			switch (i_subsystem)
			{
				case SubSystemKey.CO_SO_DAO_TAO:
					return TEN_PHAN_HE.CO_SO_DAO_TAO;
				case SubSystemKey.HANH_CHINH:
					return TEN_PHAN_HE.HANH_CHINH;
				case SubSystemKey.QUAN_TRI_HE_THONG:
					return TEN_PHAN_HE.QUAN_TRI_HE_THONG;
				case SubSystemKey.TAI_CHINH:
					return TEN_PHAN_HE.TAI_CHINH;
				case SubSystemKey.KE_TOAN:
					return TEN_PHAN_HE.KE_TOAN;
			}
			return "";
		}
		
		public static string getTen(string i_strMaPhanHe)
		{
			if (i_strMaPhanHe == MA_PHAN_HE.CO_SO_DAO_TAO)
			{
				return getTen(SubSystemKey.CO_SO_DAO_TAO);
			}
			else if (i_strMaPhanHe == MA_PHAN_HE.QUAN_TRI_HE_THONG)
			{
				return getTen(SubSystemKey.QUAN_TRI_HE_THONG);
			}
			else if (i_strMaPhanHe == MA_PHAN_HE.HANH_CHINH)
			{
				return getTen(SubSystemKey.HANH_CHINH);
			}
			else if (i_strMaPhanHe == MA_PHAN_HE.TAI_CHINH)
			{
				return getTen(SubSystemKey.TAI_CHINH);
			}
			else if (i_strMaPhanHe == MA_PHAN_HE.KE_TOAN)
			{
				return getTen(SubSystemKey.KE_TOAN);
			}
			else
			{
				Debug.Assert(false, "");
			}
			return "";
		}
		
		public static string getMa(SubSystemKey i_subsystem)
		{
			switch (i_subsystem)
			{
				case SubSystemKey.CO_SO_DAO_TAO:
					return MA_PHAN_HE.CO_SO_DAO_TAO;
				case SubSystemKey.HANH_CHINH:
					return MA_PHAN_HE.HANH_CHINH;
				case SubSystemKey.QUAN_TRI_HE_THONG:
					return MA_PHAN_HE.QUAN_TRI_HE_THONG;
				case SubSystemKey.TAI_CHINH:
					return MA_PHAN_HE.TAI_CHINH;
			}
			return "";
		}
	}
	
}
