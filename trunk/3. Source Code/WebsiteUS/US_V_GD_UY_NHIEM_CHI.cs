///************************************************
/// Generated by: TuDM
/// Date: 22/11/2014 02:04:12
/// Goal: Create User Service Class for V_GD_UY_NHIEM_CHI
///************************************************
/// <summary>
/// Create User Service Class for V_GD_UY_NHIEM_CHI
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_V_GD_UY_NHIEM_CHI : US_Object
	{
		private const string c_TableName = "V_GD_UY_NHIEM_CHI";
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

		public decimal dcID_DU_AN_CONG_TRINH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_DU_AN_CONG_TRINH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_DU_AN_CONG_TRINH"] = value;
			}
		}

		public bool IsID_DU_AN_CONG_TRINHNull()
		{
			return pm_objDR.IsNull("ID_DU_AN_CONG_TRINH");
		}

		public void SetID_DU_AN_CONG_TRINHNull()
		{
			pm_objDR["ID_DU_AN_CONG_TRINH"] = System.Convert.DBNull;
		}

		public decimal dcSO_TIEN_NOP_THUE
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_NOP_THUE", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_NOP_THUE"] = value;
			}
		}

		public bool IsSO_TIEN_NOP_THUENull()
		{
			return pm_objDR.IsNull("SO_TIEN_NOP_THUE");
		}

		public void SetSO_TIEN_NOP_THUENull()
		{
			pm_objDR["SO_TIEN_NOP_THUE"] = System.Convert.DBNull;
		}

		public string strIS_NGUON_NS_YN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "IS_NGUON_NS_YN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["IS_NGUON_NS_YN"] = value;
			}
		}

		public bool IsIS_NGUON_NS_YNNull()
		{
			return pm_objDR.IsNull("IS_NGUON_NS_YN");
		}

		public void SetIS_NGUON_NS_YNNull()
		{
			pm_objDR["IS_NGUON_NS_YN"] = System.Convert.DBNull;
		}

		public decimal dcID_UNC
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_UNC", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_UNC"] = value;
			}
		}

		public bool IsID_UNCNull()
		{
			return pm_objDR.IsNull("ID_UNC");
		}

		public void SetID_UNCNull()
		{
			pm_objDR["ID_UNC"] = System.Convert.DBNull;
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

		public decimal dcID_CHUONG
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_CHUONG", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_CHUONG"] = value;
			}
		}

		public bool IsID_CHUONGNull()
		{
			return pm_objDR.IsNull("ID_CHUONG");
		}

		public void SetID_CHUONGNull()
		{
			pm_objDR["ID_CHUONG"] = System.Convert.DBNull;
		}

		public decimal dcID_KHOAN
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_KHOAN", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_KHOAN"] = value;
			}
		}

		public bool IsID_KHOANNull()
		{
			return pm_objDR.IsNull("ID_KHOAN");
		}

		public void SetID_KHOANNull()
		{
			pm_objDR["ID_KHOAN"] = System.Convert.DBNull;
		}

		public decimal dcID_MUC
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_MUC", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_MUC"] = value;
			}
		}

		public bool IsID_MUCNull()
		{
			return pm_objDR.IsNull("ID_MUC");
		}

		public void SetID_MUCNull()
		{
			pm_objDR["ID_MUC"] = System.Convert.DBNull;
		}

		public decimal dcID_TIEU_MUC
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_TIEU_MUC", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_TIEU_MUC"] = value;
			}
		}

		public bool IsID_TIEU_MUCNull()
		{
			return pm_objDR.IsNull("ID_TIEU_MUC");
		}

		public void SetID_TIEU_MUCNull()
		{
			pm_objDR["ID_TIEU_MUC"] = System.Convert.DBNull;
		}

		public decimal dcSO_TIEN_TT_CHO_DV_HUONG
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_TT_CHO_DV_HUONG", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_TT_CHO_DV_HUONG"] = value;
			}
		}

		public bool IsSO_TIEN_TT_CHO_DV_HUONGNull()
		{
			return pm_objDR.IsNull("SO_TIEN_TT_CHO_DV_HUONG");
		}

		public void SetSO_TIEN_TT_CHO_DV_HUONGNull()
		{
			pm_objDR["SO_TIEN_TT_CHO_DV_HUONG"] = System.Convert.DBNull;
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

		public string strKHO_BAC_NHA_NUOC
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "KHO_BAC_NHA_NUOC", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["KHO_BAC_NHA_NUOC"] = value;
			}
		}

		public bool IsKHO_BAC_NHA_NUOCNull()
		{
			return pm_objDR.IsNull("KHO_BAC_NHA_NUOC");
		}

		public void SetKHO_BAC_NHA_NUOCNull()
		{
			pm_objDR["KHO_BAC_NHA_NUOC"] = System.Convert.DBNull;
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

		public decimal dcID_LOAI_DU_AN_CONG_TRINH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_DU_AN_CONG_TRINH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_LOAI_DU_AN_CONG_TRINH"] = value;
			}
		}

		public bool IsID_LOAI_DU_AN_CONG_TRINHNull()
		{
			return pm_objDR.IsNull("ID_LOAI_DU_AN_CONG_TRINH");
		}

		public void SetID_LOAI_DU_AN_CONG_TRINHNull()
		{
			pm_objDR["ID_LOAI_DU_AN_CONG_TRINH"] = System.Convert.DBNull;
		}

		public string strDISPLAY
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "DISPLAY", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["DISPLAY"] = value;
			}
		}

		public bool IsDISPLAYNull()
		{
			return pm_objDR.IsNull("DISPLAY");
		}

		public void SetDISPLAYNull()
		{
			pm_objDR["DISPLAY"] = System.Convert.DBNull;
		}

		#endregion
		#region "Init Functions"
		public US_V_GD_UY_NHIEM_CHI()
		{
			pm_objDS = new DS_V_GD_UY_NHIEM_CHI();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_V_GD_UY_NHIEM_CHI(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_V_GD_UY_NHIEM_CHI(decimal i_dbID)
		{
			pm_objDS = new DS_V_GD_UY_NHIEM_CHI();
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
