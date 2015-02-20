// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports



namespace IP.Core.IPBusinessService
{
	public class CProvider
	{

		private const string C_HAS_NOT_BEEN_READ_FROM_CONFIG_FILE = "NOT LOADED";
		private static string m_strConnectionStringCurrent = C_HAS_NOT_BEEN_READ_FROM_CONFIG_FILE;
		private static string m_strConnectionStringCreateFromAppConfig = C_HAS_NOT_BEEN_READ_FROM_CONFIG_FILE;
		private static string m_strDBname = "";
		private static string m_strDBnameAdmin = "";

		#region Public interface
		public static void changeDataBase(string i_str_db_name)
		{
			m_strConnectionStringCurrent = getDBConnectionString(i_str_db_name);
		}
		public static string getDBname()
		{
			return m_strDBname;
		}
		public static void refreshDBSettings()
		{
			readConnectionString();
		}
		#endregion

		static public System.Data.SqlClient.SqlConnection getConnection()
		{
			System.Data.SqlClient.SqlConnection cn = new System.Data.SqlClient.SqlConnection();
			if (m_strConnectionStringCurrent == C_HAS_NOT_BEEN_READ_FROM_CONFIG_FILE)
			{
				m_strConnectionStringCurrent = readConnectionString();
				m_strConnectionStringCreateFromAppConfig = m_strConnectionStringCurrent;
			}
			cn.ConnectionString = m_strConnectionStringCurrent; //"data source=ACBNT;initial catalog=eSchool;user id=eSchool;password=eSchool"
			return cn;
		}
		private static string getDBConnectionString(string i_str_db_name)
		{
			//Dim v_configReader As New System.Configuration.AppSettingsReader
			string v_strServerName = System.Configuration.ConfigurationSettings.AppSettings["SERVER"];
			string v_strUser = System.Configuration.ConfigurationSettings.AppSettings["INITIAL_USER"];
			string v_strPwd = System.Configuration.ConfigurationSettings.AppSettings["PASS_WORD"];
			string v_strDatabaseAccessMode = System.Configuration.ConfigurationSettings.AppSettings["DATABASE_ACCESS_MODE"];


			string v_strConnectionString = "";
			v_strConnectionString = "data source=" + v_strServerName + ";";
			v_strConnectionString += "initial catalog= " + i_str_db_name + ";";
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
			m_strDBname = i_str_db_name;
			return v_strConnectionString;
		}
		static public System.Data.SqlClient.SqlDataAdapter getAdapter()
		{
			System.Data.SqlClient.SqlDataAdapter da = new System.Data.SqlClient.SqlDataAdapter();
			return da;
		}
		private static string readConnectionString()
		{
			string v_strServerName = System.Configuration.ConfigurationSettings.AppSettings["SERVER"];
			string v_strDatabase = System.Configuration.ConfigurationSettings.AppSettings["INITIAL_DATABASE"];
			string v_strUser = System.Configuration.ConfigurationSettings.AppSettings["INITIAL_USER"];
			string v_strPwd = System.Configuration.ConfigurationSettings.AppSettings["PASS_WORD"];
			string v_strDatabaseAccessMode = System.Configuration.ConfigurationSettings.AppSettings["DATABASE_ACCESS_MODE"];


			//Dim v_configReader As New System.Configuration.AppSettingsReader
			//Dim v_strServerName As String = v_configReader.GetValue("SERVER", System.Type.GetType("System.String")).ToString()
			//Dim v_strDatabase As String = v_configReader.GetValue("INITIAL_DATABASE", System.Type.GetType("System.String")).ToString()
			//Dim v_strUser As String = v_configReader.GetValue("INITIAL_USER", System.Type.GetType("System.String")).ToString()
			//Dim v_strPwd As String = v_configReader.GetValue("PASS_WORD", System.Type.GetType("System.String")).ToString()
			//Dim v_strDatabaseAccessMode As String = v_configReader.GetValue("DATABASE_ACCESS_MODE", System.Type.GetType("System.String")).ToString()
			//v_configReader = Nothing

			string v_strConnectionString = "";
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
			m_strDBname = v_strDatabase;
			m_strDBnameAdmin = v_strDatabase;

			return v_strConnectionString;
		}
		private static DataSet getDataSet()
		{
			DataSet op_ds=new DataSet();
			DataTable v_dt=new DataTable();
			op_ds.Tables.Add(v_dt);
			op_ds.AcceptChanges();
			return op_ds;
		}


	}

}
