using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
using System.Xml;
using System.Windows.Forms;
using IP.Core.IPCommon.MessageForms;
namespace IP.Core.IPCommon
{
	public class BaseMessages
	{

		#region Nhiệm vụ của class
		//*************************************************************
		// Dùng để hiện thị các thông báo của hệ thống
		//
		//*************************************************************
		#endregion

		#region Vùng khai báo biến
		public enum IsDataCouldBeDeleted
		{
			CouldBeDeleted = 232,
			ShouldNotBeDeleted = 1111
		}

		private static DatasetMsg m_DataSet = new DatasetMsg();
		private static Users_DataSet m_dsUser = new Users_DataSet();
		private const string c_strUserFileName = "NumOfMessage.XML";
		private const string c_InfoMsgString = "Thông báo";
		private const string c_ErrorMsgString = "Thông báo lỗi";
		private const string c_ConfirmMsgString = "Xác nhận lại";
		private const string c_WarningMsgString = "Cảnh báo";
		private static bool m_IntialedClass;
		//Các thông số liên quan đến chế độ chạy
		private const string c_RunApp = "RUN";
		private const string c_DeburgMode = "DEBURG";

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

		#endregion

		#region Các hàm khởi tạo huỷ dữ liệu

		private static void InitClass(string i_UserFileName)
		{
			try
			{
				string v_UserFileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + i_UserFileName;
				m_dsUser.ReadXml(v_UserFileName);
				m_IntialedClass = true;

			}
			catch (Exception)
			{
				return;
			}
			finally
			{
			}
		}

		public static void Close()
		{
			m_DataSet = null;
		}
		private static void LoadMessagesData(decimal i_NumOFMsg)
		{
			string v_strWhere = "";
			string v_FileName = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
			v_strWhere = "(FromNum <= " + System.Convert.ToString(i_NumOFMsg) + ") and (" + System.Convert.ToString(i_NumOFMsg) + " < ToNum)";
			DataView v_dvUserData = new DataView(m_dsUser.Users_DataSet_Renamed, v_strWhere, "", DataViewRowState.CurrentRows);
			if (v_dvUserData.Count > 0)
			{
				v_FileName += System.Convert.ToString(v_dvUserData[0]["FileName"]);
				m_DataSet.ReadXml(v_FileName);
			}
		}
		#endregion

		#region Lấy dữ liệu thông báo
		//Lay lai cac thong bao trong database theo cac chi so cua thong bao
		public static string GetMsg(decimal i_MsgNumber)
		{
			string v_strValue = "";
			string v_strWhere = "ID=" + System.Convert.ToString(i_MsgNumber);
			if (!m_IntialedClass)
			{
				InitClass(c_strUserFileName);
			}
			LoadMessagesData(i_MsgNumber);
			DataView v_dvMessage = new DataView(m_DataSet.Message, v_strWhere, "", DataViewRowState.CurrentRows);
			if (v_dvMessage.Count > 0)
			{
				v_strValue = System.Convert.ToString(v_dvMessage[0]["Message"]);
			}
			else
			{
				v_strValue = "Thông báo này chưa đựơc định nghĩa đúng";
			}
			return v_strValue;
		}
		#endregion

		#region Public Interface

		//Hàm thông báo lỗi dùng chỉ số lỗi
		public static void MsgBox_Error(int MsgNumber)
		{
			string v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			MsgBox_Error(v_StrMsg);
		}
		//Hàm thông báo lỗi với một chuỗi
		public static void MsgBox_Error(string i_strMsg)
		{
			MsgBoxForm_OK v_FormMsg = new MsgBoxForm_OK();
			v_FormMsg.Display(i_strMsg, c_ErrorMsgString, IP.Core.IPCommon.MessageForms.Msgs.MsgIconType.ErrorIcon);
		}
		//Hàm thông báo Thông tin thông thường bằng chỉ số lỗi
		public static void MsgBox_Infor(int MsgNumber)
		{
			string v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			MsgBox_Infor(v_StrMsg);
		}
		//Hàm thông báo Thông tin thông thường bằng chuỗi
		public static void MsgBox_Infor(string i_strMsg)
		{
			MsgBoxForm_OK v_FormMsg = new MsgBoxForm_OK();
			v_FormMsg.Display(i_strMsg, c_InfoMsgString, IP.Core.IPCommon.MessageForms.Msgs.MsgIconType.InfomationIcon);
		}
		//Hàm xác nhận lại yêu cầu  dùng chuỗi
		//
		public static bool MsgBox_Confirm(string i_strMsg)
		{
			bool v_Result = default(bool);
			DialogResult v_confirm = default(DialogResult);
			IPCommon.MessageForms.MsgBoxForm_Yes_No v_FormMsg = new IPCommon.MessageForms.MsgBoxForm_Yes_No();
			v_confirm = v_FormMsg.Display(i_strMsg, c_ConfirmMsgString, IP.Core.IPCommon.MessageForms.Msgs.MsgIconType.QuestionIcon);
			switch (v_confirm)
			{
				case DialogResult.Yes:
					v_Result = true;
					break;
				case DialogResult.No:
					v_Result = false;
					break;
			}
			return v_Result;
		}
		//Hàm xác nhận lại yêu cầu  dùng chỉ sỗ chuỗi thông báo
		public static bool MsgBox_Confirm(int MsgNumber)
		{
			string v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			return MsgBox_Confirm(v_StrMsg);
		}

		//Hàm cảnh báo

		public static bool MsgBox_Warning(int MsgNumber)
		{
			string v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			MessageForms.MsgBoxForm_OK v_FormMsg = new MessageForms.MsgBoxForm_OK();
			v_FormMsg.Display(v_StrMsg, c_WarningMsgString, IP.Core.IPCommon.MessageForms.Msgs.MsgIconType.WarningIcon);
			return default(bool);
		}

		//Hàm confirm "Yes","No","Cancel"
		public static DialogResult MsgBox_YES_NO_CANCEL(int MsgNumber)
		{
			string v_StrMsg = MsgNumber + " - " + GetMsg(MsgNumber);
			DialogResult v_confirm = MsgBox_YES_NO_CANCEL(v_StrMsg);
			return v_confirm;
		}
		//Hàm confirm "Yes","No","Cancel"
		public static DialogResult MsgBox_YES_NO_CANCEL(string i_strMsg)
		{
			MsgBoxFormYes_No_Cancel v_FormMsg = new MsgBoxFormYes_No_Cancel();
			DialogResult v_confirm = v_FormMsg.Display(i_strMsg, c_ConfirmMsgString, IP.Core.IPCommon.MessageForms.Msgs.MsgIconType.QuestionIcon);
			return v_confirm;
		}
		// Hàm hỏi có xoá dữ liệu không
		public static IsDataCouldBeDeleted askUser_DataCouldBeDeleted(int i_MsgNumber = 8)
		{
			if (MsgBox_Confirm(i_MsgNumber))
			{
				return IsDataCouldBeDeleted.CouldBeDeleted;
			}
			else
			{
				return IsDataCouldBeDeleted.ShouldNotBeDeleted;
			}
		}

		#endregion

	}

}
