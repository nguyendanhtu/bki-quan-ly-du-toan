///************************************************
/// Generated by: TuDM
/// Date: 29/11/2014 11:18:56
/// Goal: Create User Service Class for DM_THONG_TIN_DON_VI
///************************************************
/// <summary>
/// Create User Service Class for DM_THONG_TIN_DON_VI
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_DM_THONG_TIN_DON_VI : US_Object
	{
		private const string c_TableName = "DM_THONG_TIN_DON_VI";
		#region "Public Properties"
		public decimal dcID
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID"] = value;
			}
		}

		public bool IsIDNull()
		{
			return pm_objDR.IsNull("ID");
		}

		public void SetIDNull()
		{
			pm_objDR["ID"] = System.Convert.DBNull;
		}

		public decimal dcID_DON_VI
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_DON_VI", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_DON_VI"] = value;
			}
		}

		public bool IsID_DON_VINull()
		{
			return pm_objDR.IsNull("ID_DON_VI");
		}

		public void SetID_DON_VINull()
		{
			pm_objDR["ID_DON_VI"] = System.Convert.DBNull;
		}

		public string strDIA_CHI
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "DIA_CHI", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["DIA_CHI"] = value;
			}
		}

		public bool IsDIA_CHINull()
		{
			return pm_objDR.IsNull("DIA_CHI");
		}

		public void SetDIA_CHINull()
		{
			pm_objDR["DIA_CHI"] = System.Convert.DBNull;
		}

		public string strKHO_BAC
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "KHO_BAC", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["KHO_BAC"] = value;
			}
		}

		public bool IsKHO_BACNull()
		{
			return pm_objDR.IsNull("KHO_BAC");
		}

		public void SetKHO_BACNull()
		{
			pm_objDR["KHO_BAC"] = System.Convert.DBNull;
		}

		public string strMA_TKKT
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "MA_TKKT", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["MA_TKKT"] = value;
			}
		}

		public bool IsMA_TKKTNull()
		{
			return pm_objDR.IsNull("MA_TKKT");
		}

		public void SetMA_TKKTNull()
		{
			pm_objDR["MA_TKKT"] = System.Convert.DBNull;
		}

		public string strMA_DVQHNS
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "MA_DVQHNS", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["MA_DVQHNS"] = value;
			}
		}

		public bool IsMA_DVQHNSNull()
		{
			return pm_objDR.IsNull("MA_DVQHNS");
		}

		public void SetMA_DVQHNSNull()
		{
			pm_objDR["MA_DVQHNS"] = System.Convert.DBNull;
		}

		#endregion
		#region "Init Functions"
		public US_DM_THONG_TIN_DON_VI()
		{
			pm_objDS = new DS_DM_THONG_TIN_DON_VI();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_DM_THONG_TIN_DON_VI(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_DM_THONG_TIN_DON_VI(decimal i_dbID)
		{
			pm_objDS = new DS_DM_THONG_TIN_DON_VI();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

		#region Additional
		public US_DM_THONG_TIN_DON_VI(decimal i_dbID, decimal i_dbID_DON_VI)
		{
			pm_objDS = new DS_DM_THONG_TIN_DON_VI();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID_DON_VI", i_dbID_DON_VI, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion
	}
}