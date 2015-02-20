// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	namespace CommonMsgNumber
	{
		public enum eDatabaseMsg
		{
			Not_null_field = 1,
			Have_unique_code = 2,
			Have_reference = 3,
			Not_have_parent_data = 4,
			Not_connect_to_db_server = 7,
			Not_update_because_have_ref = 15
		}
		
		public enum eConfirmMsg
		{
			Sure_to_delete = 8,
			Sure_to_update = 11,
			Continue_to_update = 16
		}
		
		public enum eDatatypeMsg
		{
			Not_valid_number = 12,
			Not_valid_date = 14
		}
		
		public enum eLabelMsg
		{
			All = 18
		}
	}
	
}
