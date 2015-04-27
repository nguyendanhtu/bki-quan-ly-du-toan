using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;

namespace QuanLyDuToan.App_Code
{
	public class UIUtil
	{
		public delegate void InitializeControlDelegate<T>(T ControlToUse);

		public static string RenderUserControl<T>(string ControlPath, InitializeControlDelegate<T> InitControlCallback) where T : UserControl
		{
			System.Web.UI.Page pageHolder = new Page();
			T ControlToRender = (T)pageHolder.LoadControl(ControlPath);
			pageHolder.Controls.Add(ControlToRender);
			InitControlCallback.Invoke(ControlToRender);
			StringWriter result = new StringWriter();
			System.Web.HttpContext.Current.Server.Execute(pageHolder, result, false);
			return result.ToString();
		}
	}
}