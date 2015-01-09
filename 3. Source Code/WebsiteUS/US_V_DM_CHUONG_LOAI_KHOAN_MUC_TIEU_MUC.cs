///************************************************
/// Generated by: ThaiPH
/// Date: 14/12/2014 10:05:06
/// Goal: Create User Service Class for V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC
///************************************************
/// <summary>
/// Create User Service Class for V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS{

public class US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC : US_Object
{
	private const string c_TableName = "V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC";
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

	public decimal dcID_KTM 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_KTM", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_KTM"] = value;
		}
	}

	public bool IsID_KTMNull()	{
		return pm_objDR.IsNull("ID_KTM");
	}

	public void SetID_KTMNull() {
		pm_objDR["ID_KTM"] = System.Convert.DBNull;
	}

	public string strTEN_KTM 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_KTM", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_KTM"] = value;
		}
	}

	public bool IsTEN_KTMNull() 
	{
		return pm_objDR.IsNull("TEN_KTM");
	}

	public void SetTEN_KTMNull() {
		pm_objDR["TEN_KTM"] = System.Convert.DBNull;
	}

	public string strMA_SO_KTM 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "MA_SO_KTM", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["MA_SO_KTM"] = value;
		}
	}

	public bool IsMA_SO_KTMNull() 
	{
		return pm_objDR.IsNull("MA_SO_KTM");
	}

	public void SetMA_SO_KTMNull() {
		pm_objDR["MA_SO_KTM"] = System.Convert.DBNull;
	}

	public string strTEN_LOAI_CLM 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_LOAI_CLM", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_LOAI_CLM"] = value;
		}
	}

	public bool IsTEN_LOAI_CLMNull() 
	{
		return pm_objDR.IsNull("TEN_LOAI_CLM");
	}

	public void SetTEN_LOAI_CLMNull() {
		pm_objDR["TEN_LOAI_CLM"] = System.Convert.DBNull;
	}

	public string strTEN_LOAI_KTM 
	{
		get 
		{
			return CNull.RowNVLString(pm_objDR, "TEN_LOAI_KTM", IPConstants.c_DefaultString);
		}
		set 
		{
			pm_objDR["TEN_LOAI_KTM"] = value;
		}
	}

	public bool IsTEN_LOAI_KTMNull() 
	{
		return pm_objDR.IsNull("TEN_LOAI_KTM");
	}

	public void SetTEN_LOAI_KTMNull() {
		pm_objDR["TEN_LOAI_KTM"] = System.Convert.DBNull;
	}

	public decimal dcID_LOAI_CLM 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_CLM", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_LOAI_CLM"] = value;
		}
	}

	public bool IsID_LOAI_CLMNull()	{
		return pm_objDR.IsNull("ID_LOAI_CLM");
	}

	public void SetID_LOAI_CLMNull() {
		pm_objDR["ID_LOAI_CLM"] = System.Convert.DBNull;
	}

	public decimal dcID_LOAI_KTM 
	{
		get
		{
			return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_KTM", IPConstants.c_DefaultDecimal);
		}
		set	
		{
			pm_objDR["ID_LOAI_KTM"] = value;
		}
	}

	public bool IsID_LOAI_KTMNull()	{
		return pm_objDR.IsNull("ID_LOAI_KTM");
	}

	public void SetID_LOAI_KTMNull() {
		pm_objDR["ID_LOAI_KTM"] = System.Convert.DBNull;
	}

#endregion
#region "Init Functions"
	public US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC() 
	{
		pm_objDS = new DS_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC();
		pm_strTableName = c_TableName;
		pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
	}

	public US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC(DataRow i_objDR): this()
	{
		this.DataRow2Me(i_objDR);
	}

	public US_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC(decimal i_dbID) 
	{
		pm_objDS = new DS_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC();
		pm_strTableName = c_TableName;
		IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
		v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
		SqlCommand v_cmdSQL;
		v_cmdSQL = v_objMkCmd.getSelectCmd();
		this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
		pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
	}
#endregion

    public void FilterAndFillDataset(DS_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC ip_ds, string ip_str_filter)
    {
        CStoredProc v_pr = new CStoredProc("pr_V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC_filter");
        v_pr.addNVarcharInputParam("@STR_FILTER", ip_str_filter);
        v_pr.fillDataSetByCommand(this, ip_ds);
    }
}
}