using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace IP.Core.IPBusinessService
{
	public class BS_Object
	{

		#region Nhiệm vụ của Class
		// Trực tiếp thực hiện các lệnh Select, DDL, cũng như các lệnh
		// vào cơ sở dữ liệu

		#endregion

		#region Data structures
		private enum DMLCommandType
		{
			InsertCommand,
			UpdateCommand,
			DeleteCommand,
			DeleteByIDCommand
		}

		private const int C_COMMAND_TIME_OUT = 10000;
		#endregion

		#region Private Member
		private System.Data.SqlClient.SqlConnection m_Connection;
		private System.Data.SqlClient.SqlTransaction m_Trans;
		private bool m_HaveTrans = false;
		#endregion

		#region Public Interface
		public bool HaveTransaction
		{
			get
			{
				return m_HaveTrans;
			}
		}

		public void FillDataset(
						DataSet i_ds
						, string i_TableName
						, string i_strDieuKien
						)
		{
			// Lấy một dataset từ csdl dựa trên điều kiện cho trước
			System.Data.SqlClient.SqlDataAdapter v_da = CProvider.getAdapter();
			CCommandBuilder v_cb = default(CCommandBuilder);
			if (!m_HaveTrans) //Csung update
			{
				// Tạo ra connection
				System.Data.SqlClient.SqlConnection v_cn = CProvider.getConnection();
				v_cb = new CCommandBuilder(v_cn, i_ds, i_TableName);
				// Tạo ra adapter
				v_da.SelectCommand = v_cb.getSelectCommand(i_strDieuKien);
			}
			else
			{
				v_cb = new CCommandBuilder(this.m_Connection, i_ds, i_TableName);
				v_da.SelectCommand = v_cb.getSelectCommand(i_strDieuKien);
				v_da.SelectCommand.Transaction = m_Trans;
				v_da.SelectCommand.Connection = this.m_Connection;
			}
			v_da.SelectCommand.CommandTimeout = C_COMMAND_TIME_OUT;
			// Lấy dữ liệu từ DB
			try
			{
				v_da.Fill(i_ds, i_TableName);
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
			finally
			{
				v_cb = null;
				v_da = null;
				GC.Collect();
			}
		}

		public void FillDatasetByCommand(
						DataSet i_ds
						, System.Data.SqlClient.SqlCommand i_SelectCmd
						)
		{
			//*****************************************************
			// Lấy một dataset từ csdl dựa COMMAND cho trước
			// COMMAND đã phải có :
			//  - Tên của stored -function, procedure
			//  - các tham số
			//*****************************************************
			// Tạo ra adapter
			System.Data.SqlClient.SqlDataAdapter v_da = CProvider.getAdapter();
			// Tạo ra connection

			if (!m_HaveTrans) //Csung update
			{
				// Tạo ra connection
				System.Data.SqlClient.SqlConnection v_cn = CProvider.getConnection();
				// Tạo ra adapter
				v_da.SelectCommand = i_SelectCmd;
				v_da.SelectCommand.Connection = v_cn;
			}
			else
			{
				v_da.SelectCommand = i_SelectCmd;
				v_da.SelectCommand.Transaction = m_Trans;
				v_da.SelectCommand.Connection = this.m_Connection;
			}
			v_da.SelectCommand.CommandTimeout = C_COMMAND_TIME_OUT;
			// Lấy dữ liệu từ DB
			try
			{
				v_da.Fill(i_ds, i_ds.Tables[0].TableName);
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
			finally
			{
				v_da = null;
				GC.Collect();
			}
		}

		public void Update(
						DataSet i_ds
						, string i_TableName
						)
		{
			ExecuteCommand(i_ds, i_TableName, DMLCommandType.UpdateCommand);
		}

		public void Update_GhiLog(
						DataSet i_ds
						, string i_TableName
						, decimal i_dcNguoiDung
						, string i_strTenThamSo
						)
		{
			ExecuteCommandInsertLog(i_ds, i_TableName, DMLCommandType.UpdateCommand, i_dcNguoiDung, i_strTenThamSo, 0);
		}

		public decimal Insert(
						DataSet i_ds
						, string i_TableName
						)
		{
			return ExecuteCommand(i_ds, i_TableName, DMLCommandType.InsertCommand);
		}

		public decimal Insert_GhiLog(
						DataSet i_ds
						, string i_TableName
						, decimal i_dcNguoiDung
						, string i_strTenThamSo
						)
		{
			return ExecuteCommandInsertLog(i_ds, i_TableName, DMLCommandType.InsertCommand, i_dcNguoiDung, i_strTenThamSo, 0);
		}

		public void Delete(
						DataSet i_ds
						, string i_TableName
						)
		{
			ExecuteCommand(i_ds, i_TableName, DMLCommandType.DeleteCommand);
		}

		public void DeleteByID(
						DataSet i_ds
						, string i_TableName
						, decimal i_dcID
						)
		{
			ExecuteCommand(i_ds, i_TableName, DMLCommandType.DeleteByIDCommand, i_dcID);
		}

		public void DeleteByID_GhiLog(
						DataSet i_ds
						, string i_TableName
						, decimal i_dcID
						, decimal i_dcNguoiDung
						, string i_strTenThamSo
						)
		{
			ExecuteCommandInsertLog(i_ds, i_TableName, DMLCommandType.DeleteByIDCommand, i_dcNguoiDung, i_strTenThamSo, i_dcID);
		}

		public void ExecCommand(System.Data.SqlClient.SqlCommand i_cmd)
		{
			i_cmd.CommandType = CommandType.StoredProcedure;
			if (m_HaveTrans)
			{
				i_cmd.Connection = m_Connection;
				i_cmd.Transaction = m_Trans;
			}
			else
			{
				i_cmd.Connection = CProvider.getConnection();
				i_cmd.Connection.Open();
			}
			i_cmd.CommandTimeout = C_COMMAND_TIME_OUT;
			i_cmd.ExecuteScalar();
			if (!m_HaveTrans)
			{
				i_cmd.Connection.Close();
			}
		}

		//Trả về ID cho đối tượng mới
		public decimal getObjectID()
		{
			// tạo connection và command
			System.Data.SqlClient.SqlConnection v_cn = CProvider.getConnection();
			System.Data.SqlClient.SqlCommand v_cmd = new System.Data.SqlClient.SqlCommand();

			// thực hiện lệnh DML
			v_cmd.Connection = v_cn;
			v_cmd.CommandType = CommandType.StoredProcedure;
			v_cmd.CommandText = "pr_ht_get_object_id";
			decimal v_dbID = new decimal();
			v_cmd.Parameters.Add(new System.Data.SqlClient.SqlParameter("@op_next_object_id", v_dbID));
			v_cmd.Parameters["@op_next_object_id"].Direction = ParameterDirection.Output;
			v_cmd.Parameters["@op_next_object_id"].SqlDbType = SqlDbType.Decimal;
			try
			{
				v_cmd.Connection.Open();
				v_cmd.ExecuteScalar();
				return System.Convert.ToDecimal(v_cmd.Parameters["@op_next_object_id"].Value);
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
			finally
			{
				v_cmd.Connection.Close();
			}
		}

		public bool isUpdatable(DataSet i_ds, string i_TableName)
		{
			Debug.Assert(!(m_Connection == null), "Ban chua viet BeginTranaction");
			CCommandBuilder v_cb = new CCommandBuilder(m_Connection, i_ds, i_TableName);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			v_cmd = v_cb.getUpdatableCommand();
			v_cmd.Connection = m_Connection;
			v_cmd.Transaction = m_Trans;
			v_cmd.CommandType = CommandType.StoredProcedure;
			try
			{
				v_cmd.ExecuteNonQuery();
				return true;
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
		}

		public System.Data.SqlClient.SqlTransaction BeginTransaction()
		{
			if (!m_HaveTrans)
			{
				m_Connection = CProvider.getConnection();
				m_Connection.Open();
				m_HaveTrans = true;
			}
			m_Trans = m_Connection.BeginTransaction(IsolationLevel.ReadCommitted);
			return m_Trans;
		}

		public void CommitTransaction()
		{
			m_HaveTrans = false;
			m_Trans.Commit();
			m_Connection.Close();
		}

		public void CommitTransWithoutCloseConnection()
		{
			m_HaveTrans = true;
			m_Trans.Commit();
			m_Trans = m_Connection.BeginTransaction();
		}

		public void Rollback()
		{
			m_HaveTrans = false;

			//m_Trans.Rollback()
			m_Connection.Close();
		}

		public System.Data.SqlClient.SqlTransaction getTransaction()
		{
			Debug.Assert(!(m_Trans == null), "BSObject nay chua co transaction - tuanqt BS_Object.vb");
			return m_Trans;
		}

		public void setTransaction(System.Data.SqlClient.SqlTransaction i_Trans)
		{
			m_Trans = i_Trans;
			m_Connection = i_Trans.Connection;
			m_HaveTrans = true;
		}

		public void setSavePoint(string i_str_save_point_name)
		{
			Debug.Assert(m_HaveTrans, "Chi duoc dat SavePoint khi US_Object co transaction - tuanqt");
			m_Trans.Save(i_str_save_point_name);
		}

		public void rollbackToSavePoint(string i_str_save_point_name)
		{
			Debug.Assert(m_HaveTrans, "Chi duoc dat SavePoint khi US_Object co transaction - tuanqt");
			try
			{
				m_Trans.Rollback(i_str_save_point_name);
			}
			catch (Exception v_e)
			{
				if (v_e.Message.IndexOf("No transaction or savepoint of that name was found") > 0)
				{
					Debug.Assert(false, "Khong tim thay save point co ten la " + i_str_save_point_name + " - tuanqt");
				}
				else
				{
					//Khong biet la loi gi thi phai nem exception ra ngoai de xu ly
					throw (v_e);
				}
			}
		}
		#endregion

		#region Private method
		private decimal ExecuteCommand(DataSet i_ds,
			string i_TableName, DMLCommandType
			i_DMLCommandType, decimal i_dcID = 0)
		{
			// Đây là lệch excecute các command
			// tạo connection và command
			System.Data.SqlClient.SqlConnection v_cn = default(System.Data.SqlClient.SqlConnection);
			if (m_HaveTrans)
			{
				v_cn = m_Connection;
			}
			else
			{
				v_cn = CProvider.getConnection();
			}

			CCommandBuilder v_cb = new CCommandBuilder(v_cn, i_ds, i_TableName);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			SqlParameter v_out_para = default(SqlParameter);
			v_out_para = null;
			switch (i_DMLCommandType)
			{
				case DMLCommandType.DeleteCommand:
					v_cmd = v_cb.getDeleteCommand();
					break;
				case DMLCommandType.InsertCommand:
					v_cmd = v_cb.getInsertCommand();
					v_out_para = v_cmd.Parameters["@ID"];
					break;
				case DMLCommandType.UpdateCommand:
					v_cmd = v_cb.getUpdateCommand();
					break;
				case DMLCommandType.DeleteByIDCommand:
					v_cmd = v_cb.getDeleteByIDCommand(i_dcID);
					break;
			}

			v_cmd.CommandTimeout = C_COMMAND_TIME_OUT;

			// thực hiện lệnh DML

			if (m_HaveTrans)
			{
				v_cmd.Transaction = m_Trans;
				v_cmd.Connection = m_Trans.Connection;
			}
			else
			{
				//Trai lai thi phai tao mo connection da co
				v_cmd.Connection.Open();
			}
			//Bien luu id vua insert vao trong truong hop insert
			decimal v_dc_new_id = 0;

			try
			{
				v_cmd.ExecuteNonQuery();
				//Neu trong truong hop insert thi phai tra lai id vua moi insert vao
				if (i_DMLCommandType == DMLCommandType.InsertCommand)
				{
					v_dc_new_id = System.Convert.ToDecimal(v_out_para.Value);
				}
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
			finally
			{
				//Neu khong co transaction thi phai dong connection lai
				if (!m_HaveTrans)
				{
					v_cmd.Connection.Close();
				}
			}
			//Trong truong hop Insert thi tra ve id vua insert
			//Nguoc lai tra ve 0
			return v_dc_new_id;
		}

		//' 12/09/2013: LinhDH thêm
		private decimal ExecuteCommandInsertLog(DataSet i_ds, string i_TableName, DMLCommandType i_DMLCommandType, decimal i_dcIdNguoiDung, string i_strTenThamSo, decimal i_dcID)
		{
			// Đây là lệch excecute các command
			// tạo connection và command
			System.Data.SqlClient.SqlConnection v_cn = default(System.Data.SqlClient.SqlConnection);
			if (m_HaveTrans)
			{
				v_cn = m_Connection;
			}
			else
			{
				v_cn = CProvider.getConnection();
			}

			CCommandBuilder v_cb = new CCommandBuilder(v_cn, i_ds, i_TableName);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			SqlParameter v_out_para = default(SqlParameter);
			v_out_para = null;
			switch (i_DMLCommandType)
			{
				case DMLCommandType.DeleteCommand:
					v_cmd = v_cb.getDeleteCommand();
					break;
				case DMLCommandType.InsertCommand:
					v_cmd = v_cb.getInsertCommandInsertLog(i_dcIdNguoiDung, i_strTenThamSo);
					v_out_para = v_cmd.Parameters["@ID"];
					break;
				case DMLCommandType.UpdateCommand:
					v_cmd = v_cb.getUpdateCommandInsertLog(i_dcIdNguoiDung, i_strTenThamSo);
					break;
				case DMLCommandType.DeleteByIDCommand:
					v_cmd = v_cb.getDeleteByIDCommandInsertLog(i_dcID, i_dcIdNguoiDung, i_strTenThamSo);
					break;
			}

			v_cmd.CommandTimeout = C_COMMAND_TIME_OUT;

			// thực hiện lệnh DML

			if (m_HaveTrans)
			{
				v_cmd.Transaction = m_Trans;
				v_cmd.Connection = m_Trans.Connection;
			}
			else
			{
				//Trai lai thi phai tao mo connection da co
				v_cmd.Connection.Open();
			}
			//Bien luu id vua insert vao trong truong hop insert
			decimal v_dc_new_id = 0;

			try
			{
				v_cmd.ExecuteNonQuery();
				//Neu trong truong hop insert thi phai tra lai id vua moi insert vao
				if (i_DMLCommandType == DMLCommandType.InsertCommand)
				{
					v_dc_new_id = System.Convert.ToDecimal(v_out_para.Value);
				}
			}
			catch (System.Exception v_e)
			{
				throw (v_e);
			}
			finally
			{
				//Neu khong co transaction thi phai dong connection lai
				if (!m_HaveTrans)
				{
					v_cmd.Connection.Close();
				}
			}
			//Trong truong hop Insert thi tra ve id vua insert
			//Nguoc lai tra ve 0
			return v_dc_new_id;
		}
		#endregion

	}


}
