// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;

//De enum nay ra ngoai de C# co`n nhi`n thay

namespace IP.Core.IPException
{
	public enum DBErrorIndex
	{
		DuplicateIndex = 0,
		NoParentFound = 1,
		ChildRecordFound = 2,
		NullValueNotAllowed = 3,
		CheckConstraintViolated = 4,
		NoDBConnection = 5,
		RecordChanged = 6,
		RecordDeleted = 7,
		LockTimeOut = 8,
		BusinessProcessLock = 9,
		OtherDBException = 10
	}

	public class CDBExceptionHandler
	{
		private const int NumberOfException = 11;

		#region Data Structure
		public enum DBErrorIndex
		{
			DuplicateIndex = 0,
			NoParentFound = 1,
			ChildRecordFound = 2,
			NullValueNotAllowed = 3,
			CheckConstraintViolated = 4,
			NoDBConnection = 5,
			RecordChanged = 6,
			RecordDeleted = 7,
			LockTimeOut = 8,
			BusinessProcessLock = 9,
			OtherDBException = 10
		}
		#endregion

		#region Các member của Class

		private System.Exception m_Exception;
		private string[] m_ErrorMsg;
		private DBErrorIndex m_ErrorIndex;

		#endregion

		#region Public Interface
		public CDBExceptionHandler(System.Exception i_ExceptionToHandle,
			IPException.IDBExceptionInterpret i_ExceptionInterpret)
		{
			m_Exception = i_ExceptionToHandle;
			InitErrorMsg();
			m_ErrorIndex = i_ExceptionInterpret.getDBErrorIndex(m_Exception);
			if (m_ErrorIndex == DBErrorIndex.OtherDBException)
			{
				setErrorMsg(DBErrorIndex.OtherDBException, "Lỗi sau đây xuất hiện " + m_Exception.Message);
			}
		}

		public void setErrorMsg(DBErrorIndex i_DBErrorIndex,
			string i_CustomizedErrorMessage)
		{
			// Dùng để định các thông báo mong muốn trước khi gọi showErrorMessage
			//
			//
			m_ErrorMsg[(int)i_DBErrorIndex] = i_CustomizedErrorMessage;
		}

		public void setErrorMsg(IP.Core.IPException.DBErrorIndex i_DBErrorIndex,
			string i_CustomizedErrorMessage)
		{
			// Dùng để định các thông báo mong muốn trước khi gọi showErrorMessage
			//
			//
			m_ErrorMsg[(int)i_DBErrorIndex] = i_CustomizedErrorMessage;
		}

		public DBErrorIndex getDBErrorIndex()
		{
			// nếu không muốn hiện  message báo lỗi thì dùng cái này
			// để định dạng lỗi. Và tiếp tục theo cách mong muốn
			return this.m_ErrorIndex;
		}

		public void showErrorMessage()
		{
			//
			// Hiện thị các error message
			//
			MessageBox.Show(m_ErrorMsg[(int)m_ErrorIndex]);

		}

		public string getErrorMsg()
		{
			return m_ErrorMsg[(int)m_ErrorIndex];
		}
		#endregion

		#region Các private methods
		private void InitErrorMsg()
		{
			m_ErrorMsg = new string[NumberOfException - 1 + 1];
			m_ErrorMsg[(int)DBErrorIndex.DuplicateIndex] = "Dữ liệu đã tồn tại. Điền dữ liệu khác";
			m_ErrorMsg[(int)DBErrorIndex.NoParentFound] = "Không có dữ liệu cơ sở. Tác vụ không thực hiện được";
			m_ErrorMsg[(int)DBErrorIndex.CheckConstraintViolated] = "Dữ liệu không hợp lệ";
			m_ErrorMsg[(int)DBErrorIndex.NullValueNotAllowed] = "Dữ liệu phải khác rỗng";
			m_ErrorMsg[(int)DBErrorIndex.ChildRecordFound] = "Đã dùng ở nơi khác. Tác vụ không thực hiện được";
			m_ErrorMsg[(int)DBErrorIndex.NoDBConnection] = "Không kết nối được với Cơ sở dữ liệu";
			m_ErrorMsg[(int)DBErrorIndex.RecordChanged] = "Bản ghi này đã bị thay đổi";
			m_ErrorMsg[(int)DBErrorIndex.RecordDeleted] = "Bản ghi này đã bị xóa";
			m_ErrorMsg[(int)DBErrorIndex.LockTimeOut] = "Bản ghi này đang có người sửa đổi";
			m_ErrorMsg[(int)DBErrorIndex.BusinessProcessLock] = "Người khác đang sử dụng chức năng này. Làm ơn thử lại sau.";
		}
		#endregion
	}


}
