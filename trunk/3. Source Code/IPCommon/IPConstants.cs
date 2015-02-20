// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



//Dua ra ngoai de C# nhin thay
namespace IP.Core.IPCommon
{
	public enum DataEntryFormMode
	{
		// các giá trị dùng cho Form nhập dữ liệu
		UpdateDataState,
		InsertDataState,
		ViewDataState,
		SelectDataState
	}
	
	public class IPConstants
	{
		
#region Nhiệm vụ của class
		//****************************************************************************
		//*  Created by: Csung, 2003-11
		//*  Chứa các constants cho hệ thống eschool
		//*  Chú ý: phải là tầng thấp nhất ( không reference tới các class khác của hệ thống)
		//****************************************************************************
#endregion
		
#region Các giá trị kiểu Enum
		
		public enum DataEntryFormMode
		{
			// các giá trị dùng cho Form nhập dữ liệu
			UpdateDataState,
			InsertDataState,
			ViewDataState
		}
		
		public enum HowUserWantTo_Exit_MainForm
		{
			Login_As_DifferentUser,
			ExitFromSystem
		}
		
		public enum FormMode
		{
			//Phai chuyen ra ngoai de C# con tu dong thay
			ViewMode,
			MaintainMode,
			SelectMode
		}
#endregion
		
#region Các giá trị Constants
		public readonly static DateTime c_DefaultDate = DateTime.Parse("1/1/1900");
		public const decimal c_DefaultDecimal = 0;
		public const string c_DefaultString = "";
		
		// USER này lúc nào cũng phải có trong hệ thống
		public const string c_TenUserMacDinh = "ADMIN";
		
		// các giá trị liên quan đến runmode
		public const string C_RUNMODE_RUNTIME = "RUNTIME";
		public const string C_RUNMODE_TEST = "TEST";
		public const string C_RUNMODE_DEVELOP = "DEVELOP";
		public const string C_RUNMODE_NOT_LOADED = "NOT_IDENTIFIED";
		
		//special characters
		public const string C_DOUBLE_QUOTE = "\u0022";
		public const string C_SINGLE_QUOTE = "\'";
		//
public static System.Type C_StringType
		{
			get
			{
				return System.Type.GetType("System.String");
			}
		}
		
public static System.Type C_DecimalType
		{
			get
			{
				return System.Type.GetType("System.Decimal");
			}
		}
		
		
#endregion
		
#region Public Interface
		
		
#endregion
		
	}
	
	public enum DirectoryFormMode
	{
		ViewMode,
		MaintainMode,
		SelectMode
	}
	
	public enum DataEntryFileMode
	{
		UploadFile,
		EditFile,
		DeleteFile
	}
}
