///************************************************
/// Generated by: TuDM
/// Date: 16/11/2014 03:44:04
/// Goal: Create User Service Class for DM_UY_NHIEM_CHI
///************************************************
/// <summary>
/// Create User Service Class for DM_UY_NHIEM_CHI
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_DM_UY_NHIEM_CHI : US_Object
	{
		private const string c_TableName = "DM_UY_NHIEM_CHI";
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

		public DateTime datNGAY_THANG
		{
			get
			{
				return CNull.RowNVLDate(pm_objDR, "NGAY_THANG", IPConstants.c_DefaultDate);
			}
			set
			{
				pm_objDR["NGAY_THANG"] = value;
			}
		}

		public bool IsNGAY_THANGNull()
		{
			return pm_objDR.IsNull("NGAY_THANG");
		}

		public void SetNGAY_THANGNull()
		{
			pm_objDR["NGAY_THANG"] = System.Convert.DBNull;
		}

		public string strSO_UNC
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "SO_UNC", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["SO_UNC"] = value;
			}
		}

		public bool IsSO_UNCNull()
		{
			return pm_objDR.IsNull("SO_UNC");
		}

		public void SetSO_UNCNull()
		{
			pm_objDR["SO_UNC"] = System.Convert.DBNull;
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

		public string strMA_CTMT_DA_HTCT
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "MA_CTMT_DA_HTCT", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["MA_CTMT_DA_HTCT"] = value;
			}
		}

		public bool IsMA_CTMT_DA_HTCTNull()
		{
			return pm_objDR.IsNull("MA_CTMT_DA_HTCT");
		}

		public void SetMA_CTMT_DA_HTCTNull()
		{
			pm_objDR["MA_CTMT_DA_HTCT"] = System.Convert.DBNull;
		}

		public string strNT_TEN_DON_VI
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_TEN_DON_VI", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_TEN_DON_VI"] = value;
			}
		}

		public bool IsNT_TEN_DON_VINull()
		{
			return pm_objDR.IsNull("NT_TEN_DON_VI");
		}

		public void SetNT_TEN_DON_VINull()
		{
			pm_objDR["NT_TEN_DON_VI"] = System.Convert.DBNull;
		}

		public string strNT_MA_SO_THUE
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_MA_SO_THUE", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_MA_SO_THUE"] = value;
			}
		}

		public bool IsNT_MA_SO_THUENull()
		{
			return pm_objDR.IsNull("NT_MA_SO_THUE");
		}

		public void SetNT_MA_SO_THUENull()
		{
			pm_objDR["NT_MA_SO_THUE"] = System.Convert.DBNull;
		}

		public string strNT_MA_NDKT
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_MA_NDKT", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_MA_NDKT"] = value;
			}
		}

		public bool IsNT_MA_NDKTNull()
		{
			return pm_objDR.IsNull("NT_MA_NDKT");
		}

		public void SetNT_MA_NDKTNull()
		{
			pm_objDR["NT_MA_NDKT"] = System.Convert.DBNull;
		}

		public string strNT_MA_CHUONG
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_MA_CHUONG", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_MA_CHUONG"] = value;
			}
		}

		public bool IsNT_MA_CHUONGNull()
		{
			return pm_objDR.IsNull("NT_MA_CHUONG");
		}

		public void SetNT_MA_CHUONGNull()
		{
			pm_objDR["NT_MA_CHUONG"] = System.Convert.DBNull;
		}

		public string strNT_CQ_QL_THU
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_CQ_QL_THU", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_CQ_QL_THU"] = value;
			}
		}

		public bool IsNT_CQ_QL_THUNull()
		{
			return pm_objDR.IsNull("NT_CQ_QL_THU");
		}

		public void SetNT_CQ_QL_THUNull()
		{
			pm_objDR["NT_CQ_QL_THU"] = System.Convert.DBNull;
		}

		public string strNT_MA_CQ_THU
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_MA_CQ_THU", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_MA_CQ_THU"] = value;
			}
		}

		public bool IsNT_MA_CQ_THUNull()
		{
			return pm_objDR.IsNull("NT_MA_CQ_THU");
		}

		public void SetNT_MA_CQ_THUNull()
		{
			pm_objDR["NT_MA_CQ_THU"] = System.Convert.DBNull;
		}

		public string strNT_KBNN_HACH_TOAN_KHOAN_THU
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_KBNN_HACH_TOAN_KHOAN_THU", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_KBNN_HACH_TOAN_KHOAN_THU"] = value;
			}
		}

		public bool IsNT_KBNN_HACH_TOAN_KHOAN_THUNull()
		{
			return pm_objDR.IsNull("NT_KBNN_HACH_TOAN_KHOAN_THU");
		}

		public void SetNT_KBNN_HACH_TOAN_KHOAN_THUNull()
		{
			pm_objDR["NT_KBNN_HACH_TOAN_KHOAN_THU"] = System.Convert.DBNull;
		}

		public string strNT_SO_TIEN_NOP_THUE
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "NT_SO_TIEN_NOP_THUE", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["NT_SO_TIEN_NOP_THUE"] = value;
			}
		}

		public bool IsNT_SO_TIEN_NOP_THUENull()
		{
			return pm_objDR.IsNull("NT_SO_TIEN_NOP_THUE");
		}

		public void SetNT_SO_TIEN_NOP_THUENull()
		{
			pm_objDR["NT_SO_TIEN_NOP_THUE"] = System.Convert.DBNull;
		}

		public string strTTDVH_DON_VI_NHAN_TIEN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_DON_VI_NHAN_TIEN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_DON_VI_NHAN_TIEN"] = value;
			}
		}

		public bool IsTTDVH_DON_VI_NHAN_TIENNull()
		{
			return pm_objDR.IsNull("TTDVH_DON_VI_NHAN_TIEN");
		}

		public void SetTTDVH_DON_VI_NHAN_TIENNull()
		{
			pm_objDR["TTDVH_DON_VI_NHAN_TIEN"] = System.Convert.DBNull;
		}

		public string strTTDVH_MA_DVQHNS
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_MA_DVQHNS", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_MA_DVQHNS"] = value;
			}
		}

		public bool IsTTDVH_MA_DVQHNSNull()
		{
			return pm_objDR.IsNull("TTDVH_MA_DVQHNS");
		}

		public void SetTTDVH_MA_DVQHNSNull()
		{
			pm_objDR["TTDVH_MA_DVQHNS"] = System.Convert.DBNull;
		}

		public string strTTDVH_DIA_CHI
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_DIA_CHI", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_DIA_CHI"] = value;
			}
		}

		public bool IsTTDVH_DIA_CHINull()
		{
			return pm_objDR.IsNull("TTDVH_DIA_CHI");
		}

		public void SetTTDVH_DIA_CHINull()
		{
			pm_objDR["TTDVH_DIA_CHI"] = System.Convert.DBNull;
		}

		public string strTTDVH_TAI_KHOAN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_TAI_KHOAN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_TAI_KHOAN"] = value;
			}
		}

		public bool IsTTDVH_TAI_KHOANNull()
		{
			return pm_objDR.IsNull("TTDVH_TAI_KHOAN");
		}

		public void SetTTDVH_TAI_KHOANNull()
		{
			pm_objDR["TTDVH_TAI_KHOAN"] = System.Convert.DBNull;
		}

		public string strTTDVH_MA_CTMT_DA_VA_HTCT
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_MA_CTMT_DA_VA_HTCT", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_MA_CTMT_DA_VA_HTCT"] = value;
			}
		}

		public bool IsTTDVH_MA_CTMT_DA_VA_HTCTNull()
		{
			return pm_objDR.IsNull("TTDVH_MA_CTMT_DA_VA_HTCT");
		}

		public void SetTTDVH_MA_CTMT_DA_VA_HTCTNull()
		{
			pm_objDR["TTDVH_MA_CTMT_DA_VA_HTCT"] = System.Convert.DBNull;
		}

		public string strTTDVH_KHO_BAC
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_KHO_BAC", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_KHO_BAC"] = value;
			}
		}

		public bool IsTTDVH_KHO_BACNull()
		{
			return pm_objDR.IsNull("TTDVH_KHO_BAC");
		}

		public void SetTTDVH_KHO_BACNull()
		{
			pm_objDR["TTDVH_KHO_BAC"] = System.Convert.DBNull;
		}

		public string strTTDVH_SO_TIEN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TTDVH_SO_TIEN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TTDVH_SO_TIEN"] = value;
			}
		}

		public bool IsTTDVH_SO_TIENNull()
		{
			return pm_objDR.IsNull("TTDVH_SO_TIEN");
		}

		public void SetTTDVH_SO_TIENNull()
		{
			pm_objDR["TTDVH_SO_TIEN"] = System.Convert.DBNull;
		}

		#endregion
		#region "Init Functions"
		public US_DM_UY_NHIEM_CHI()
		{
			pm_objDS = new DS_DM_UY_NHIEM_CHI();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_DM_UY_NHIEM_CHI(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_DM_UY_NHIEM_CHI(decimal i_dbID)
		{
			pm_objDS = new DS_DM_UY_NHIEM_CHI();
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
