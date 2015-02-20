// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	namespace MessageForms
	{
		public class Msgs
		{
#region Khai báo biến
			public enum MsgBtnType
			{
				MsgBtnOK = 0,
				MsgBtnYes_No = 1,
				MsgBtnYes_No_Cancel = 2
			}
			public enum MsgIconType
			{
				InfomationIcon = 0,
				ErrorIcon = 1,
				QuestionIcon = 2,
				WarningIcon = 3
			}
			private static System.Windows.Forms.DialogResult m_MsgResult;
#endregion
			public static System.Windows.Forms.DialogResult Show(string i_StrMsg, string i_Title, MsgBtnType i_ButtonStyle, MsgIconType i_IconMessage)
			{
				switch (i_ButtonStyle)
				{
					case MsgBtnType.MsgBtnOK:
						MsgBoxForm_OK v_MyFormMsgOK = new MsgBoxForm_OK();
						m_MsgResult = v_MyFormMsgOK.Display(i_StrMsg, i_Title, i_IconMessage);
						break;
					case MsgBtnType.MsgBtnYes_No:
						MsgBoxForm_Yes_No v_MyFormMsgYN = new MsgBoxForm_Yes_No();
						m_MsgResult = v_MyFormMsgYN.Display(i_StrMsg, i_Title, i_IconMessage);
						break;
					case MsgBtnType.MsgBtnYes_No_Cancel:
						MsgBoxFormYes_No_Cancel v_MyFormMsgYNC = new MsgBoxFormYes_No_Cancel();
						m_MsgResult = v_MyFormMsgYNC.Display(i_StrMsg, i_Title, i_IconMessage);
						break;
				}
				return m_MsgResult;
			}
		}
	}
}
