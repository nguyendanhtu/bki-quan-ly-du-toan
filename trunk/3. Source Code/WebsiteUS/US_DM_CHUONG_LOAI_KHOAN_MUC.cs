///************************************************
/// Generated by: TuDM
/// Date: 21/11/2014 03:59:38
/// Goal: Create User Service Class for DM_CHUONG_LOAI_KHOAN_MUC
///************************************************
/// <summary>
/// Create User Service Class for DM_CHUONG_LOAI_KHOAN_MUC
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_DM_CHUONG_LOAI_KHOAN_MUC : US_Object
{
	private const string c_TableName = "DM_CHUONG_LOAI_KHOAN_MUC";
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

	public bool IsID_CHANull()	{
		return pm_objDR.IsNull("ID_CHA");
	}

	public void SetID_CHANull() {
		pm_objDR["ID_CHA"] = System.Convert.DBNull;
	}

	public string strTEN 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN"] = value;
		}
	}

	public bool IsTENNull() 
	{
		return pm_objDR.IsNull("TEN");
	}

	public void SetTENNull() {
		pm_objDR["TEN"] = System.Convert.DBNull;
	}

	public string strMA_SO 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "MA_SO", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["MA_SO"] = value;
		}
	}

	public bool IsMA_SONull() 
	{
		return pm_objDR.IsNull("MA_SO");
	}

	public void SetMA_SONull() {
		pm_objDR["MA_SO"] = System.Convert.DBNull;
	}

	public decimal dcID_LOAI 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_LOAI"] = value;
		}
	}

	public bool IsID_LOAINull()	{
		return pm_objDR.IsNull("ID_LOAI");
	}

	public void SetID_LOAINull() {
		pm_objDR["ID_LOAI"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_DM_CHUONG_LOAI_KHOAN_MUC() 
	{
		pm_objDS = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_DM_CHUONG_LOAI_KHOAN_MUC(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_DM_CHUONG_LOAI_KHOAN_MUC(decimal i_dbID) 
	{
		pm_objDS = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
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