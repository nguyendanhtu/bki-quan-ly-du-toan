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
	public class CProperty
	{
		protected System.Type p_DataType;
		protected string p_PropertyName;

		public CProperty()
		{

		}

		public void SetValues(System.Type i_DataType, string i_PropertyName)
		{
			p_DataType = i_DataType;
			p_PropertyName = i_PropertyName;
		}

		public string getName()
		{
			return p_PropertyName;
		}

		public virtual string getValueParaName()
		{
			return "@" + p_PropertyName;
		}

		public virtual System.Data.SqlClient.SqlParameter CreateSQLValuePara()
		{
			return DataType2Parameter(p_DataType, getValueParaName());
		}

		private System.Data.SqlClient.SqlParameter DataType2Parameter(System.Type i_DataType,
			string i_ParaName)
		{
			//Chuyen tu datatype voi ten tuong ung thanh sqlparameter
			System.Data.SqlClient.SqlParameter v_SqlPara = default(System.Data.SqlClient.SqlParameter);
			switch (p_DataType.ToString())
			{
				case "System.String":
					v_SqlPara = new System.Data.SqlClient.SqlParameter(i_ParaName, System.Data.SqlDbType.NVarChar);
					break;
				case "System.DateTime":
					v_SqlPara = new System.Data.SqlClient.SqlParameter(i_ParaName, System.Data.SqlDbType.DateTime);
					break;
				case "System.Decimal":
				case "System.Int32":
					v_SqlPara = new System.Data.SqlClient.SqlParameter(i_ParaName, System.Data.SqlDbType.Decimal);
					break;
				default:
					break;
				//Cac truong hop la so
				//Raise Error o day
			}
			return v_SqlPara;
		}

	}

}
