// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class CIPKeys
	{
		public enum KeyMode
		{
			InsertState,
			UpdateState,
			DeleteState,
			ViewState,
			ExitState
		}
		public static string GetStringInsertKey()
		{
			return System.Windows.Forms.Keys.F3.ToString();
		}
		public static string GetStringUpdateKey()
		{
			return System.Windows.Forms.Keys.F4.ToString();
		}
		public static string GetStringDeleteKey()
		{
			return System.Windows.Forms.Keys.F5.ToString();
		}
		public static string GetStringViewKey()
		{
			return System.Windows.Forms.Keys.F6.ToString();
		}
		public static string GetStringExitKey()
		{
			return System.Windows.Forms.Keys.Escape.ToString();
		}
		
		public static KeyMode GetKeyStateEnum(System.Windows.Forms.KeyEventArgs ie)
		{
			KeyMode vKeyMode = default(KeyMode);
			switch (ie.KeyCode)
			{
				case System.Windows.Forms.Keys.F3:
					vKeyMode = KeyMode.InsertState;
					break;
				case System.Windows.Forms.Keys.F4:
					vKeyMode = KeyMode.UpdateState;
					break;
				case System.Windows.Forms.Keys.F5:
					vKeyMode = KeyMode.DeleteState;
					break;
				case System.Windows.Forms.Keys.F6:
					vKeyMode = KeyMode.ViewState;
					break;
				case System.Windows.Forms.Keys.Escape:
					vKeyMode = KeyMode.ExitState;
					break;
			}
			return vKeyMode;
		}
		
	}
	
}
