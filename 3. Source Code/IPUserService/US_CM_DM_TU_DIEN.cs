// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPData;
using IP.Core.IPBusinessService;
using IP.Core.IPCommon;

//************************************************
//* Generated by: IPC
//* Date: 18/11/2003
//* Goal: Create User Service Class for CM_DM_TU_DIEN
//************************************************



namespace IP.Core.IPUserService
{
	public class US_CM_DM_TU_DIEN : US_Object
	{
		
		private const string c_TableName = "CM_DM_TU_DIEN";
		
#region Public Property
		
public decimal dcID
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID", 0);
			}
			set
			{
				pm_objDR["ID"] = value;
			}
		}
		
public string strMA_TU_DIEN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "MA_TU_DIEN", "");
			}
			set
			{
				pm_objDR["MA_TU_DIEN"] = value;
			}
		}
		
public decimal dcID_LOAI_TU_DIEN
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_TU_DIEN", 0);
			}
			set
			{
				pm_objDR["ID_LOAI_TU_DIEN"] = value;
			}
		}
		
public string strTEN_NGAN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_NGAN", "");
			}
			set
			{
				pm_objDR["TEN_NGAN"] = value;
			}
		}
		
public string strTEN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN", "");
			}
			set
			{
				pm_objDR["TEN"] = value;
			}
		}
public string strGHI_CHU
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU", "");
			}
			set
			{
				pm_objDR["GHI_CHU"] = value;
			}
		}
		
#endregion
		
		public US_CM_DM_TU_DIEN()
		{
			pm_objDS = new DS_CM_DM_TU_DIEN();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}
		
		public US_CM_DM_TU_DIEN(DataRow i_objDR) : this()
		{
			this.DataRow2Me(i_objDR);
		}
		
		public US_CM_DM_TU_DIEN(decimal i_dbID)
		{
			pm_objDS = new DS_CM_DM_TU_DIEN();
			pm_strTableName = c_TableName;
			this.FillDataset(pm_objDS, "Where ID = " + Conversion.Str(i_dbID));
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		
		public US_CM_DM_TU_DIEN(string i_strMaLoaiTD, string i_strMaTuDien)
		{
			//Tim ID loai tu dien
			US_CM_DM_LOAI_TD v_objLoaiTD = new US_CM_DM_LOAI_TD(i_strMaLoaiTD);
			pm_objDS = new DS_CM_DM_TU_DIEN();
			pm_strTableName = c_TableName;
			this.FillDataset(pm_objDS, "Where ID_LOAI_TU_DIEN = " + System.Convert.ToString(v_objLoaiTD.dcID) 
				+ " and MA_TU_DIEN = N\'" + i_strMaTuDien + "\'");
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		
		public DS_CM_DM_TU_DIEN getLoaiTuDienDS(string i_strMaLoaiTD)
		{
			DS_CM_DM_TU_DIEN v_dsTuDien = new DS_CM_DM_TU_DIEN();
			US_CM_DM_LOAI_TD v_usLoaiTD = new US_CM_DM_LOAI_TD(i_strMaLoaiTD);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			IMakeSelectCmd v_MakeSelCommand = default(IMakeSelectCmd);
			v_MakeSelCommand = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			v_cmd = v_MakeSelCommand.getSelectCmd();
			this.FillDatasetByCommand(v_dsTuDien, v_cmd);
			return v_dsTuDien;
		}
		
		public void fill_tu_dien_cung_loai_ds(string i_strMaLoaiTD, 
			DS_CM_DM_TU_DIEN i_ds_tu_dien)
		{
			US_CM_DM_LOAI_TD v_usLoaiTD = new US_CM_DM_LOAI_TD(i_strMaLoaiTD);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			IMakeSelectCmd v_MakeSelCommand = default(IMakeSelectCmd);
			v_MakeSelCommand = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			v_cmd = v_MakeSelCommand.getSelectCmd();
			this.FillDatasetByCommand(i_ds_tu_dien, v_cmd);
		}
		
		public void fill_tu_dien_cung_loai_ds(string i_strMaLoaiTD, string i_strSortField, DS_CM_DM_TU_DIEN i_ds_tu_dien)
		{
			US_CM_DM_LOAI_TD v_usLoaiTD = new US_CM_DM_LOAI_TD(i_strMaLoaiTD);
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			IMakeSelectCmd v_MakeSelCommand = default(IMakeSelectCmd);
			v_MakeSelCommand = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_MakeSelCommand.AddCondition("ID_LOAI_TU_DIEN", v_usLoaiTD.dcID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			v_cmd = v_MakeSelCommand.getSelectCmd();
			v_cmd.CommandText += " ORDER BY " + i_strSortField;
			this.FillDatasetByCommand(i_ds_tu_dien, v_cmd);
		}
		
		public bool check_exist_ma_tu_dien(string i_strMaTuDien)
		{
			DS_CM_DM_TU_DIEN i_ds_tu_dien = new DS_CM_DM_TU_DIEN();
			System.Data.SqlClient.SqlCommand v_cmd = default(System.Data.SqlClient.SqlCommand);
			IMakeSelectCmd v_MakeSelCommand = default(IMakeSelectCmd);
			v_MakeSelCommand = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_MakeSelCommand.AddCondition("MA_TU_DIEN", i_strMaTuDien, eKieuDuLieu.KieuString, eKieuSoSanh.Bang);
			v_cmd = v_MakeSelCommand.getSelectCmd();
			this.FillDatasetByCommand(i_ds_tu_dien, v_cmd);
			if (i_ds_tu_dien.CM_DM_TU_DIEN.Rows.Count > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
	}
	
}
