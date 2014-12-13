///************************************************
/// Generated by: HuyTD
/// Date: 09/12/2014 10:16:55
/// Goal: Create User Service Class for RPT_BAO_CAO_GIAO_VON
///************************************************
/// <summary>
/// Create User Service Class for RPT_BAO_CAO_GIAO_VON
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_RPT_BAO_CAO_GIAO_VON : US_Object
	{
		private const string c_TableName = "RPT_BAO_CAO_GIAO_VON";
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

		public string strNHIEM_VU_CHI
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NHIEM_VU_CHI", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NHIEM_VU_CHI"] = value;
			}
		}

		public bool IsNHIEM_VU_CHINull()
		{
			return pm_objDR.IsNull("NHIEM_VU_CHI");
		}

		public void SetNHIEM_VU_CHINull()
		{
			pm_objDR["NHIEM_VU_CHI"] = System.Convert.DBNull;
		}

		public decimal dcTONG_KH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_KH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_KH"] = value;
			}
		}

		public bool IsTONG_KHNull()
		{
			return pm_objDR.IsNull("TONG_KH");
		}

		public void SetTONG_KHNull()
		{
			pm_objDR["TONG_KH"] = System.Convert.DBNull;
		}

		public decimal dcTONG_VON_QBT
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_VON_QBT", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_VON_QBT"] = value;
			}
		}

		public bool IsTONG_VON_QBTNull()
		{
			return pm_objDR.IsNull("TONG_VON_QBT");
		}

		public void SetTONG_VON_QBTNull()
		{
			pm_objDR["TONG_VON_QBT"] = System.Convert.DBNull;
		}

		public decimal dcTONG_VON_NS
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_VON_NS", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_VON_NS"] = value;
			}
		}

		public bool IsTONG_VON_NSNull()
		{
			return pm_objDR.IsNull("TONG_VON_NS");
		}

		public void SetTONG_VON_NSNull()
		{
			pm_objDR["TONG_VON_NS"] = System.Convert.DBNull;
		}

		public decimal dcTONG_VON
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_VON", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_VON"] = value;
			}
		}

		public bool IsTONG_VONNull()
		{
			return pm_objDR.IsNull("TONG_VON");
		}

		public void SetTONG_VONNull()
		{
			pm_objDR["TONG_VON"] = System.Convert.DBNull;
		}

		public decimal dcKH_NAM_TRUOC_CHUYEN_SANG
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "KH_NAM_TRUOC_CHUYEN_SANG", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["KH_NAM_TRUOC_CHUYEN_SANG"] = value;
			}
		}

		public bool IsKH_NAM_TRUOC_CHUYEN_SANGNull()
		{
			return pm_objDR.IsNull("KH_NAM_TRUOC_CHUYEN_SANG");
		}

		public void SetKH_NAM_TRUOC_CHUYEN_SANGNull()
		{
			pm_objDR["KH_NAM_TRUOC_CHUYEN_SANG"] = System.Convert.DBNull;
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

		#endregion
		#region "Init Functions"
		public US_RPT_BAO_CAO_GIAO_VON()
		{
			pm_objDS = new DS_RPT_BAO_CAO_GIAO_VON();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_RPT_BAO_CAO_GIAO_VON(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_RPT_BAO_CAO_GIAO_VON(decimal i_dbID)
		{
			pm_objDS = new DS_RPT_BAO_CAO_GIAO_VON();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

        public void bc_giao_von_theo_don_vi(DataSet v_ds, decimal v_dc_id_don_vi, DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay, string ip_str_nhiem_vu_chi)
		{
			CStoredProc v_prc = new CStoredProc("pr_RPT_BAO_CAO_GIAO_VON");
			v_prc.addDecimalInputParam("@ip_id_dc_id_don_vi", v_dc_id_don_vi);
			v_prc.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_prc.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_prc.addNVarcharInputParam("@ip_str_nhiem_vu_chi", ip_str_nhiem_vu_chi);
			v_prc.fillDataSetByCommand(this, v_ds);
		}
	}
}
