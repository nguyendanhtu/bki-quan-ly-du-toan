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
	public class CCommandBuilder
	{
		//*--------------------------------------------------------------
		//*Tạo  ra các câu lệnh cập nhật CSDL thích hợp
		//*
		//*--------------------------------------------------------------
		//* Dinh nghia cac hang so
		private const string c_PRPrefix = "pr_";
		
		private DataSet m_ds;
		private string m_TableName;
		private System.Data.SqlClient.SqlConnection m_cnn;
		
		public CCommandBuilder(System.Data.SqlClient.SqlConnection i_cnn, 
			DataSet i_ds, 
			string i_TableName)
		{
			m_cnn = i_cnn;
			m_ds = i_ds;
			m_TableName = i_TableName;
		}
		
		public System.Data.SqlClient.SqlCommand getSelectCommand(string i_sDieuKien = "")
		{
			System.Data.SqlClient.SqlCommand v_Cmd = default(System.Data.SqlClient.SqlCommand);
			v_Cmd = new System.Data.SqlClient.SqlCommand(getSelectString(i_sDieuKien), m_cnn);
			v_Cmd.CommandType = CommandType.Text;
			return v_Cmd;
		}
		
		private string getSelectString(string i_sDieuKien = "")
		{
			string v_strSelect = " Select ";
			System.Data.DataColumn v_DataColumn = default(System.Data.DataColumn);
			foreach (System.Data.DataColumn tempLoopVar_v_DataColumn in m_ds.Tables[m_TableName].Columns)
			{
				v_DataColumn = tempLoopVar_v_DataColumn;
				v_strSelect += v_DataColumn.ColumnName + ", ";
			}
			v_strSelect = v_strSelect.Substring(0, v_strSelect.Length - 2);
			v_strSelect += " from " + m_TableName;
			v_strSelect += " " + i_sDieuKien;
			return v_strSelect;
		}
		
		public System.Data.SqlClient.SqlCommand getUpdateCommand()
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandType = CommandType.StoredProcedure;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Update";
			setParaCollection4Cmd(v_Cmd);
			return v_Cmd;
		}
		
		public System.Data.SqlClient.SqlCommand getInsertCommand()
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Insert";
			v_Cmd.CommandType = CommandType.StoredProcedure;
			setParaCollection4Cmd(v_Cmd);
			v_Cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
			return v_Cmd;
		}
		public System.Data.SqlClient.SqlCommand getInsertCommandInsertLog(decimal i_dcID, 
			string i_strTenThamSo)
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Insert";
			v_Cmd.CommandType = CommandType.StoredProcedure;
			setParaCollection4CmdInsertLog(v_Cmd, i_dcID, i_strTenThamSo);
			v_Cmd.Parameters["@ID"].Direction = ParameterDirection.Output;
			return v_Cmd;
		}
		public System.Data.SqlClient.SqlCommand getUpdateCommandInsertLog(decimal i_dcID, 
			string i_strTenThamSo)
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandType = CommandType.StoredProcedure;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Update";
			setParaCollection4CmdInsertLog(v_Cmd, i_dcID, i_strTenThamSo);
			return v_Cmd;
		}
		public System.Data.SqlClient.SqlCommand getDeleteByIDCommandInsertLog(decimal i_dcID, decimal i_dcIDNguoiDung, string i_strTenThamSo)
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			
			System.Data.SqlClient.SqlParameter v_Para = new System.Data.SqlClient.SqlParameter("@ID", SqlDbType.Decimal);
			
			v_Para.Value = i_dcID;
			v_Cmd.Parameters.Add(v_Para);
			
			System.Data.SqlClient.SqlParameter v_Para_NguoiDung = new System.Data.SqlClient.SqlParameter("@" + i_strTenThamSo, SqlDbType.Decimal);
			
			v_Para_NguoiDung.Value = i_dcIDNguoiDung;
			v_Cmd.Parameters.Add(v_Para_NguoiDung);
			
			//Gan cac thuoc tinh cua command
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandType = CommandType.StoredProcedure;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Delete";
			
			return v_Cmd;
		}
		
		public System.Data.SqlClient.SqlCommand getDeleteCommand()
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			System.Data.DataColumn v_Column = default(System.Data.DataColumn);
			System.Data.DataRow v_Row = default(System.Data.DataRow);
			System.Data.SqlClient.SqlParameter v_Para = default(System.Data.SqlClient.SqlParameter);
			
			v_Row = m_ds.Tables[m_TableName].Rows[0];
			
			CProperty v_Property = new CProperty();
			
			foreach (System.Data.DataColumn tempLoopVar_v_Column in m_ds.Tables[m_TableName].PrimaryKey)
			{
				v_Column = tempLoopVar_v_Column;
				v_Property.SetValues(v_Column.DataType, v_Column.ColumnName);
				v_Para = v_Property.CreateSQLValuePara();
				v_Para.Value = v_Row[v_Property.getName()];
				v_Cmd.Parameters.Add(v_Para);
			}
			
			//Gan cac thuoc tinh cua command
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandType = CommandType.StoredProcedure;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Delete";
			return v_Cmd;
		}
		
		public System.Data.SqlClient.SqlCommand getDeleteByIDCommand(decimal i_dcID)
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			
			System.Data.SqlClient.SqlParameter v_Para = new System.Data.SqlClient.SqlParameter("@ID", SqlDbType.Decimal);
			
			v_Para.Value = i_dcID;
			v_Cmd.Parameters.Add(v_Para);
			
			//Gan cac thuoc tinh cua command
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandType = CommandType.StoredProcedure;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_Delete";
			
			return v_Cmd;
		}
		
		public System.Data.SqlClient.SqlCommand getUpdatableCommand()
		{
			System.Data.SqlClient.SqlCommand v_Cmd = new System.Data.SqlClient.SqlCommand();
			v_Cmd.Connection = m_cnn;
			v_Cmd.CommandText = c_PRPrefix + m_TableName + "_isupdatable";
			v_Cmd.CommandType = CommandType.StoredProcedure;
			setParaCollection4Cmd(v_Cmd);
			SqlParameter v_Para = new SqlParameter();
			v_Para.ParameterName = "@op_Error_Code";
			v_Para.Direction = ParameterDirection.Output;
			v_Para.SqlDbType = SqlDbType.Int;
			v_Cmd.Parameters.Add(v_Para);
			return v_Cmd;
		}
		
		//Lay ve tham so dung de chua loi do sql server tra ve
		//Protected Function getErrorParameter() As SqlClient.SqlParameter
		//    Dim v_sqlPara As New SqlClient.SqlParameter()
		//    v_sqlPara = New SqlClient.SqlParameter("@ErrorCode", System.Data.SqlDbType.Int)
		//    v_sqlPara.Direction = ParameterDirection.Output
		//    Return v_sqlPara
		//End Function
		
		//Dat cac gia tri cho cac thuoc tinh
		protected void set_value_4_para(SqlParameter i_obj_sqlpara, 
			CProperty i_obj_property, 
			DataRow i_dr_value)
		{
			Type v_obj_type = i_dr_value.Table.Columns[i_obj_property.getName()].DataType;
			
			switch (v_obj_type.ToString())
			{
				case "System.String":
					if (i_dr_value.IsNull(i_obj_property.getName()))
					{
						i_obj_sqlpara.Value = System.Convert.DBNull;
					}
					else
					{
						if (i_dr_value[i_obj_property.getName()].ToString().Trim().Length == 0)
						{
							i_obj_sqlpara.Value = System.Convert.DBNull;
						}
						else
						{
							i_obj_sqlpara.Value = i_dr_value[i_obj_property.getName()];
						}
					}
					break;
				case "System.DateTime":
					if (i_dr_value.IsNull(i_obj_property.getName()))
					{
						i_obj_sqlpara.Value = System.Convert.DBNull;
					}
					else
					{
						if (Convert.ToDateTime(i_dr_value[i_obj_property.getName()]) 
							== Convert.ToDateTime("01/01/1900"))
						{
							i_obj_sqlpara.Value = System.Convert.DBNull;
						}
						else
						{
							i_obj_sqlpara.Value = i_dr_value[i_obj_property.getName()];
						}
					}
					break;
				default:
					i_obj_sqlpara.Value = i_dr_value[i_obj_property.getName()];
					break;
			}
		}
		
		//' 12/09/2013 LinhDH thêm để insert được Log
		protected void set_value_4_paraInsertLog(SqlParameter i_obj_sqlpara, 
			CProperty i_obj_property, 
			decimal i_dc_id_nguoi_dung)
		{
			i_obj_sqlpara.Value = i_dc_id_nguoi_dung;
		}
		
		protected void setParaCollection4Cmd(System.Data.SqlClient.SqlCommand i_Cmd)
		{
			System.Data.DataColumn v_Column = default(System.Data.DataColumn);
			System.Data.DataRow v_Row = default(System.Data.DataRow);
			System.Data.SqlClient.SqlParameter v_Para = default(System.Data.SqlClient.SqlParameter);
			v_Row = m_ds.Tables[m_TableName].Rows[0];
			
			CProperty v_Property = new CProperty();
			foreach (System.Data.DataColumn tempLoopVar_v_Column in m_ds.Tables[m_TableName].Columns)
			{
				v_Column = tempLoopVar_v_Column;
				v_Property.SetValues(v_Column.DataType, v_Column.ColumnName);
				//tao cac tham so truyen vao cho Stored Procedure
				v_Para = v_Property.CreateSQLValuePara();
				//v_Para.Value = v_Row(v_Property.getName())
				set_value_4_para(v_Para, v_Property, v_Row);
				i_Cmd.Parameters.Add(v_Para);
			}
			//i_Cmd.Parameters.Add(getErrorParameter())
		}
		
		protected void setParaCollection4CmdInsertLog(System.Data.SqlClient.SqlCommand i_Cmd, 
			decimal i_dc_id_nguoi_dung, 
			string i_str_ten_tham_so)
		{
			System.Data.DataColumn v_Column = default(System.Data.DataColumn);
			System.Data.DataRow v_Row = default(System.Data.DataRow);
			System.Data.SqlClient.SqlParameter v_Para = default(System.Data.SqlClient.SqlParameter);
			v_Row = m_ds.Tables[m_TableName].Rows[0];
			
			CProperty v_Property = new CProperty();
			foreach (System.Data.DataColumn tempLoopVar_v_Column in m_ds.Tables[m_TableName].Columns)
			{
				v_Column = tempLoopVar_v_Column;
				v_Property.SetValues(v_Column.DataType, v_Column.ColumnName);
				//tao cac tham so truyen vao cho Stored Procedure
				v_Para = v_Property.CreateSQLValuePara();
				//v_Para.Value = v_Row(v_Property.getName())
				set_value_4_para(v_Para, v_Property, v_Row);
				i_Cmd.Parameters.Add(v_Para);
			}
			
			//' LinhDH 09/12/2012: Add parameter có insert Log
			v_Property.SetValues(Type.GetType("Decimal"), i_str_ten_tham_so);
			//tao cac tham so truyen vao cho Stored Procedure
			v_Para = v_Property.CreateSQLValuePara();
			//v_Para.Value = v_Row(v_Property.getName())
			set_value_4_paraInsertLog(v_Para, v_Property, i_dc_id_nguoi_dung);
			i_Cmd.Parameters.Add(v_Para);
		}
		
	}
	
}
