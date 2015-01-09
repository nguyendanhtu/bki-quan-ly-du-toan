///************************************************
/// Generated by: TuDM
/// Date: 13/12/2014 02:23:41
/// Goal: Create User Service Class for GRID_GIAI_NGAN
///************************************************
/// <summary>
/// Create User Service Class for GRID_GIAI_NGAN
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_GRID_GIAI_NGAN : US_Object
	{
		private const string c_TableName = "GRID_GIAI_NGAN";
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

		public decimal dcSO_TIEN_NT
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_NT", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_NT"] = value;
			}
		}

		public bool IsSO_TIEN_NTNull()
		{
			return pm_objDR.IsNull("SO_TIEN_NT");
		}

		public void SetSO_TIEN_NTNull()
		{
			pm_objDR["SO_TIEN_NT"] = System.Convert.DBNull;
		}

		public decimal dcSO_TIEN_TTCDVH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_TTCDVH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_TTCDVH"] = value;
			}
		}

		public bool IsSO_TIEN_TTCDVHNull()
		{
			return pm_objDR.IsNull("SO_TIEN_TTCDVH");
		}

		public void SetSO_TIEN_TTCDVHNull()
		{
			pm_objDR["SO_TIEN_TTCDVH"] = System.Convert.DBNull;
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

		public string strREPORT_LEVEL
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "REPORT_LEVEL", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["REPORT_LEVEL"] = value;
			}
		}

		public bool IsREPORT_LEVELNull()
		{
			return pm_objDR.IsNull("REPORT_LEVEL");
		}

		public void SetREPORT_LEVELNull()
		{
			pm_objDR["REPORT_LEVEL"] = System.Convert.DBNull;
		}

		public decimal dcKE_HOACH_CHI
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "KE_HOACH_CHI", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["KE_HOACH_CHI"] = value;
			}
		}

		public bool IsKE_HOACH_CHINull()
		{
			return pm_objDR.IsNull("KE_HOACH_CHI");
		}

		public void SetKE_HOACH_CHINull()
		{
			pm_objDR["KE_HOACH_CHI"] = System.Convert.DBNull;
		}

		public string strGHI_CHU
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["GHI_CHU"] = value;
			}
		}

		public bool IsGHI_CHUNull()
		{
			return pm_objDR.IsNull("GHI_CHU");
		}

		public void SetGHI_CHUNull()
		{
			pm_objDR["GHI_CHU"] = System.Convert.DBNull;
		}

		public decimal dcID_REPORTED_USER
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_REPORTED_USER", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_REPORTED_USER"] = value;
			}
		}

		public bool IsID_REPORTED_USERNull()
		{
			return pm_objDR.IsNull("ID_REPORTED_USER");
		}

		public void SetID_REPORTED_USERNull()
		{
			pm_objDR["ID_REPORTED_USER"] = System.Convert.DBNull;
		}

		public decimal dcID_CHA
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_CHA", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_CHA"] = value;
			}
		}

		public bool IsID_CHANull()
		{
			return pm_objDR.IsNull("ID_CHA");
		}

		public void SetID_CHANull()
		{
			pm_objDR["ID_CHA"] = System.Convert.DBNull;
		}

		#endregion
		#region "Init Functions"
		public US_GRID_GIAI_NGAN()
		{
			pm_objDS = new DS_GRID_GIAI_NGAN();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_GRID_GIAI_NGAN(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_GRID_GIAI_NGAN(decimal i_dbID)
		{
			pm_objDS = new DS_GRID_GIAI_NGAN();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

		public void get_grid_uy_nhiem_chi_dataset(DS_GRID_GIAI_NGAN op_ds
				, decimal ip_dc_id_don_vi
				, decimal ip_dc_id_dm_uy_nhiem_chi)
		{
			CStoredProc v_sp = new CStoredProc("pr_get_grid_uy_nhiem_chi");
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_sp.addDecimalInputParam("@ip_dc_id_dm_uy_nhiem_chi", ip_dc_id_dm_uy_nhiem_chi);
			v_sp.fillDataSetByCommand(this, op_ds);
		}
		public void get_grid_giai_ngan(DS_GRID_GIAI_NGAN op_ds
			 , decimal ip_dc_id_don_vi
			 , decimal ip_dc_id_dm_uy_nhiem_chi
			, decimal ip_dc_id_user
			, string ip_str_is_nguon_ns)
		{
			CStoredProc v_sp = new CStoredProc("pr_get_grid_giai_ngan");
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_sp.addDecimalInputParam("@ip_dc_id_dm_uy_nhiem_chi", ip_dc_id_dm_uy_nhiem_chi);
			v_sp.addDecimalInputParam("@ip_dc_id_user", ip_dc_id_user);
			v_sp.addNVarcharInputParam("@ip_str_is_nguon_ns", ip_str_is_nguon_ns);
			v_sp.fillDataSetByCommand(this, op_ds);
		}

	}
}
