// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports




namespace IP.Core.IPCommon
{
	public class IPStr
	{
		public static string singleQuoteSTR(string i_str)
		{
			return IPConstants.C_SINGLE_QUOTE + i_str + IPConstants.C_SINGLE_QUOTE;
		}
	}
	
}
