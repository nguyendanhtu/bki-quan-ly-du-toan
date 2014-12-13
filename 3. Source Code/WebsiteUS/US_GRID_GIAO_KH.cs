///************************************************
/// Generated by: TuDM
/// Date: 07/12/2014 08:15:24
/// Goal: Create User Service Class for GRID_GIAO_KH
///************************************************
/// <summary>
/// Create User Service Class for GRID_GIAO_KH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_GRID_GIAO_KH : US_Object
	{
		private const string c_TableName = "GRID_GIAO_KH";
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

		public string strNOI_DUNG
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NOI_DUNG", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NOI_DUNG"] = value;
			}
		}

		public bool IsNOI_DUNGNull()
		{
			return pm_objDR.IsNull("NOI_DUNG");
		}

		public void SetNOI_DUNGNull()
		{
			pm_objDR["NOI_DUNG"] = System.Convert.DBNull;
		}

		public decimal dcNTCT
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "NTCT", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["NTCT"] = value;
			}
		}

		public bool IsNTCTNull()
		{
			return pm_objDR.IsNull("NTCT");
		}

		public void SetNTCTNull()
		{
			pm_objDR["NTCT"] = System.Convert.DBNull;
		}

		public decimal dcQUY
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "QUY", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["QUY"] = value;
			}
		}

		public bool IsQUYNull()
		{
			return pm_objDR.IsNull("QUY");
		}

		public void SetQUYNull()
		{
			pm_objDR["QUY"] = System.Convert.DBNull;
		}

		public decimal dcNS
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "NS", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["NS"] = value;
			}
		}

		public bool IsNSNull()
		{
			return pm_objDR.IsNull("NS");
		}

		public void SetNSNull()
		{
			pm_objDR["NS"] = System.Convert.DBNull;
		}

		public decimal dcTONG
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG"] = value;
			}
		}

		public bool IsTONGNull()
		{
			return pm_objDR.IsNull("TONG");
		}

		public void SetTONGNull()
		{
			pm_objDR["TONG"] = System.Convert.DBNull;
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

		public string strSTT
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "STT", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["STT"] = value;
			}
		}

		public bool IsSTTNull()
		{
			return pm_objDR.IsNull("STT");
		}

		public void SetSTTNull()
		{
			pm_objDR["STT"] = System.Convert.DBNull;
		}

		public string strLEVEL
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "LEVEL", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["LEVEL"] = value;
			}
		}

		public bool IsLEVELNull()
		{
			return pm_objDR.IsNull("LEVEL");
		}

		public void SetLEVELNull()
		{
			pm_objDR["LEVEL"] = System.Convert.DBNull;
		}

		#endregion
		#region "Init Functions"
		public US_GRID_GIAO_KH()
		{
			pm_objDS = new DS_GRID_GIAO_KH();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_GRID_GIAO_KH(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_GRID_GIAO_KH(decimal i_dbID)
		{
			pm_objDS = new DS_GRID_GIAO_KH();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

		public void get_grid_giao_kh_qbt(DataSet op_ds, decimal ip_dc_id_quyet_dinh)
		{
			CStoredProc v_sp = new CStoredProc("pr_get_grid_giao_kh_qbt");
			v_sp.addDecimalInputParam("@ip_dc_id_quyet_dinh", ip_dc_id_quyet_dinh);
			v_sp.fillDataSetByCommand(this, op_ds);
		}

		
	}
}