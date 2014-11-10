///************************************************
/// Generated by: TuDM
/// Date: 10/11/2014 07:19:33
/// Goal: Create User Service Class for DM_LOAI_DON_VI
///************************************************
/// <summary>
/// Create User Service Class for DM_LOAI_DON_VI
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_DM_LOAI_DON_VI : US_Object
{
	private const string c_TableName = "DM_LOAI_DON_VI";
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

	public bool IsIDNull()	{
		return pm_objDR.IsNull("ID");
	}

	public void SetIDNull() {
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

	public bool IsID_DON_VINull()	{
		return pm_objDR.IsNull("ID_DON_VI");
	}

	public void SetID_DON_VINull() {
		pm_objDR["ID_DON_VI"] = System.Convert.DBNull;
	}

	public string strIS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN"] = value;
		}
	}

	public bool IsIS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YNNull() 
	{
		return pm_objDR.IsNull("IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN");
	}

	public void SetIS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YNNull() {
		pm_objDR["IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_DM_LOAI_DON_VI() 
	{
		pm_objDS = new DS_DM_LOAI_DON_VI();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_DM_LOAI_DON_VI(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_DM_LOAI_DON_VI(decimal i_dbID) 
	{
		pm_objDS = new DS_DM_LOAI_DON_VI();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion
	}
}
