// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


//Imports environment
namespace IP.Core.IPCommon
{
	public class CSystemLog_301
	{
		
#region Nhiệm vụ của Class
		//************************************************************************
		//* Created by: Csung, 2003-11
		//* Xử lý các exception của hệ thống
		//* - Chú ý: Class này thuộc lớp cuối cùng, sẽ không reference đến một lớp nào khác
		//*
		//************************************************************************
#endregion
		
#region Variables
		private static string m_strRunMode = IPConstants.C_RUNMODE_NOT_LOADED;
		static System.IO.StreamWriter m_stream_writer;
#endregion
		
#region class public interface
		public static void Initialize()
		{
			if (m_strRunMode == IPConstants.C_RUNMODE_NOT_LOADED)
			{
				System.Configuration.AppSettingsReader v_configReader = new System.Configuration.AppSettingsReader();
				m_strRunMode = System.Convert.ToString(v_configReader.GetValue("RUN_MODE", IPConstants.C_StringType).ToString());
			}
		}
		
		public static void ExceptionHandle(System.Exception i_exp)
		{
			try
			{
				Initialize();
				// xử lý lỗi theo các trường hợp khác nhau
				// tạm thời dùng theo kiểu select-case,
				// nếu có nhu cầu cụ thể sẽ chuyển sang dạng strategy
				switch (m_strRunMode)
				{
					case IPConstants.C_RUNMODE_TEST:
System.Windows.Forms.MessageBox.Show("environment-TEST: " + i_exp.Message, "IP-LOGGING ");
						break;
					case IPConstants.C_RUNMODE_DEVELOP:
System.Windows.Forms.MessageBox.Show("environment-DEVELOPE: " + i_exp.Message, "IP-LOGGING ");
						break;
					case IPConstants.C_RUNMODE_RUNTIME:
System.Windows.Forms.MessageBox.Show("environment-RUNTIME: " + i_exp.Message, "IP-LOGGING ");
						break;
				}
			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("environment- Không có file Ini");
			}
		}
		public static void ExceptionHandle(System.Web.UI.Page i_page, System.Exception i_exp)
		{
			
			try
			{
				Initialize();
				// xử lý lỗi theo các trường hợp khác nhau
				// tạm thời dùng theo kiểu select-case,
				// nếu có nhu cầu cụ thể sẽ chuyển sang dạng strategy
				WriteToLog(i_exp);
				string v_str_msg = i_exp.Message;
				v_str_msg = v_str_msg.Replace('\n', char.Parse(""));
				
				switch (m_strRunMode)
				{
					case IPConstants.C_RUNMODE_TEST:
						i_page.Response.Redirect("~/MessageError.aspx?Message= Error:" + v_str_msg);
						break;
					case IPConstants.C_RUNMODE_DEVELOP:
						i_page.Response.Redirect("~/MessageError.aspx?Message= Error:" + v_str_msg);
						break;
					case IPConstants.C_RUNMODE_RUNTIME:
						i_page.Response.Redirect("~/MessageError.aspx?Message= Đã xảy ra lỗi trong quá trình cập nhật dữ liệu!");
						break;
				}
			}
			catch (Exception)
			{
				//i_page.Response.Redirect("../MessageError.aspx?mess=Title Website: " + i_page.Title + ". Message: " + i_exp.Message + " Source: " + i_exp.Source)
			}
		}
		private static void WriteToLog(Exception i_exeption)
		{
			string v_str_path = "";
			v_str_path = AppDomain.CurrentDomain.BaseDirectory + "Logs\\";
			write_string_2_log_file(i_exeption.Message + Environment.NewLine + i_exeption.Source, v_str_path);
		}
		private static void write_string_2_log_file(string i_str_error, string i_str_path)
		{
			try
			{
				string v_str_filename = "";
				v_str_filename = i_str_path + DateTime.Now.ToString("yyyyMMddHHmm") + ".log";
				if (System.IO.File.Exists(v_str_filename))
				{
					m_stream_writer = System.IO.File.AppendText(v_str_filename);
				}
				else
				{
					m_stream_writer = System.IO.File.CreateText(v_str_filename);
				}
				m_stream_writer.WriteLine(DateTime.Now.ToString("yyyyMMdd HH:mm:ss ") + i_str_error);
			}
			finally
			{
				if (!(m_stream_writer == null))
				{
					m_stream_writer.Close();
				}
			}
		}
#endregion
	}
	
}
