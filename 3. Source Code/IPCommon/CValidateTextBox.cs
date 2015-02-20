// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;
using System.Web.UI;





namespace IP.Core.IPCommon
{
	public enum allowNull
	{
		YES = 0,
		NO = 1
	}
	
	public class CValidateTextBox
	{
		public static bool IsValid(System.Web.UI.WebControls.TextBox i_txtCtrl, DataType i_DataType, allowNull i_AllowNull)
		{
			
			
			bool v_textbox_is_valid = default(bool);
			string v_strText = i_txtCtrl.Text;
			
			
			if (string.IsNullOrEmpty(v_strText))
			{
				//Kiem tra dieu kien rong
				switch (i_AllowNull)
				{
					case allowNull.NO:
						//If i_displayDefaultMsg Then
						//    'BaseMessages.MsgBox_Warning(1)
						//    op_str_ErrMessage = "Trường dữ liệu yêu cầu phải nhập!"
						
						//End If
						v_textbox_is_valid = false;
						break;
					case allowNull.YES:
						v_textbox_is_valid = true;
						break;
				}
			}
			else //Trong truong hop khac rong
			{
				switch (i_DataType)
				{
					case DataType.NumberType:
						v_textbox_is_valid = CUtil.IsValidNumber(v_strText, false);
						break;
						//If i_displayDefaultMsg And Not v_textbox_is_valid Then
						//    op_str_ErrMessage = "Trường dữ liệu yêu cầu phải là số!"
						//End If
					case DataType.DateType:
						v_textbox_is_valid = CDateTime.isValidDateString(v_strText, CDateTime.GetDateFormatString());
						break;
						//If i_displayDefaultMsg And Not v_textbox_is_valid Then
						//    op_str_ErrMessage = "Trường dữ liệu yêu cầu phải có dạng ngày tháng!"
						//End If
					case DataType.StringType:
						v_textbox_is_valid = true;
						break;
				}
			}
			
			//If Not v_textbox_is_valid Then
			//    CErrorTextBoxHandler.markAsErrorTxtBox(i_txtCtrl)
			//End If
			return v_textbox_is_valid;
		}
		
		
		
		public static bool IsValid(TextBox i_txtCtrl, DataType i_DataType, allowNull i_AllowNull, bool i_displayDefaultMsg = true)
		{
			
			
			bool v_textbox_is_valid = default(bool);
			string v_strText = i_txtCtrl.Text;
			if (string.IsNullOrEmpty(v_strText))
			{
				//Kiem tra dieu kien rong
				switch (i_AllowNull)
				{
					case allowNull.NO:
						if (i_displayDefaultMsg)
						{
							BaseMessages.MsgBox_Warning(1);
						}
						v_textbox_is_valid = false;
						break;
					case allowNull.YES:
						v_textbox_is_valid = true;
						break;
				}
			}
			else //Trong truong hop khac rong
			{
				switch (i_DataType)
				{
					case DataType.NumberType:
						v_textbox_is_valid = CUtil.IsValidNumber(v_strText, false);
						if (i_displayDefaultMsg && !v_textbox_is_valid)
						{
							BaseMessages.MsgBox_Warning(12);
						}
						break;
					case DataType.DateType:
						v_textbox_is_valid = CDateTime.isValidDateString(v_strText, CDateTime.GetDateFormatString());
						if (i_displayDefaultMsg && !v_textbox_is_valid)
						{
							BaseMessages.MsgBox_Warning(14);
						}
						break;
					case DataType.StringType:
						v_textbox_is_valid = true;
						break;
				}
			}
			
			if (!v_textbox_is_valid)
			{
				CErrorTextBoxHandler.markAsErrorTxtBox(i_txtCtrl);
			}
			return v_textbox_is_valid;
		}
	}
	
	
	
}
