using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using System.Data.SqlClient;
using IP.Core.IPBusinessService;
using System.Data;

namespace QuanLyDuToan.Quantri
{
	public partial class admin : System.Web.UI.Page
	{
		#region Members
		public DataSet m_ds = new DataSet();

		#endregion

		#region Private Methods
		private SqlConnection getConnection()
		{
			SqlConnection cn = new SqlConnection();
			string v_strServerName = System.Configuration.ConfigurationSettings.AppSettings["SERVER_HRM"];
			string v_strDatabase = System.Configuration.ConfigurationSettings.AppSettings["DATABASE_HRM"];
			string v_strUser = System.Configuration.ConfigurationSettings.AppSettings["USER_HRM"];
			string v_strPwd = System.Configuration.ConfigurationSettings.AppSettings["PASS_WORD_HRM"];
			string v_strDatabaseAccessMode = System.Configuration.ConfigurationSettings.AppSettings["DATABASE_ACCESS_MODE"];
			string v_strConnectionString = null;
			v_strConnectionString = "data source=" + v_strServerName + ";";
			v_strConnectionString += "initial catalog=" + v_strDatabase + ";";
			switch (v_strDatabaseAccessMode)
			{
				case "NO_USER_AND_PASSWORD":
					v_strConnectionString += "Persist Security Info=True;";
					break;
				case "USER_AND_PASSWORD":
					v_strConnectionString += "user id=" + v_strUser + ";";
					v_strConnectionString += "password=" + v_strPwd;
					break;
			}
			cn.ConnectionString = v_strConnectionString;
			return cn;
		}
		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			m_txt_command.Focus();
			if (!IsPostBack)
			{
				//m_txt_convert_encoding.Text = CIPConvert.Deciphering(m_txt_convert_encoding.Text.Trim());
			}
		}

		protected void m_cmd_excute_Click(object sender, EventArgs e)
		{
			try
			{
				m_ds = new DataSet();
				BS_Object v_bs = new BS_Object();
				DataTable v_dt = new DataTable();
				m_ds.Tables.Add(v_dt);
				m_ds.AcceptChanges();
				string v_str_command = "";
				if (m_rdb_excute.Checked == true) v_str_command = m_txt_command.Text;
				else if (m_rdb_tim_proc.Checked == true) v_str_command =
					"SELECT OBJECT_NAME(object_id)as 'procedure',definition as 'Script' FROM sys.sql_modules WHERE objectproperty(object_id,'IsProcedure') = 1 AND definition    like '%" + m_txt_command.Text + "%'";
				else if (m_rdb_tim_view.Checked == true) v_str_command =
						"Select table_name AS 'Table name', VIEW_DEFINITION AS 'Script' From INFORMATION_SCHEMA.VIEWS WHERE TABLE_NAME LIKE'%" + m_txt_command.Text + "%'";
				//else if (m_rdb_tckt.Checked == true)
				//{
				//	string v_str_cmd = m_txt_command.Text;
				//	SqlCommand i_SelectCmd = new SqlCommand(v_str_cmd);
				//	System.Data.SqlClient.SqlDataAdapter v_da = CProvider.getAdapter();
				//	const int C_COMMAND_TIME_OUT = 5;

				//	// Tạo ra connection
				//	System.Data.SqlClient.SqlConnection v_cn = getConnection();
				//	// Tạo ra adapter
				//	v_da.SelectCommand = i_SelectCmd;
				//	v_da.SelectCommand.Connection = v_cn;

				//	v_da.SelectCommand.CommandTimeout = C_COMMAND_TIME_OUT;
				//	// Lấy dữ liệu từ DB
				//	try
				//	{
				//		v_da.Fill(op_ds, op_ds.Tables[0].TableName);
				//	}
				//	catch (System.Exception v_e)
				//	{
				//		throw v_e;
				//	}
				//	finally
				//	{
				//		v_da = null;
				//		GC.Collect();
				//	}
				//	m_lbl_mess.Text = "Command(s) completed successfully.";
				//	m_grv.DataSource = op_ds.Tables[0];
				//	m_grv.DataBind();
				//	return;
				//}
				SqlCommand v_sql_cmd = new SqlCommand(v_str_command);
				m_txt_lst_command.Text = v_str_command + Environment.NewLine + m_txt_lst_command.Text;
				v_bs.FillDatasetByCommand(m_ds, v_sql_cmd);
				m_lbl_mess.Text = "Command(s) completed successfully.";
				m_grv.DataSource = m_ds.Tables[0];
				m_grv.DataBind();
			}
			catch (Exception v_e)
			{
				m_lbl_mess.Text = "Lỗi: " + v_e.ToString();
				m_grv.DataSource = null;
				m_grv.DataBind();

			}
		}
		protected void m_cmd_convert_Click(object sender, EventArgs e)
		{
			m_lbl_mess.Text = CIPConvert.Deciphering(m_txt_convert_encoding.Text.Trim());
		}
		#endregion
	}
}