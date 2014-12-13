///************************************************
/// Generated by: TuyenNT
/// Date: 05/12/2014 01:56:39
/// Goal: Create User Service Class for RPT_BAO_CAO_GIAO_VON_THEO_QD
///************************************************
/// <summary>
/// Create User Service Class for RPT_BAO_CAO_GIAO_VON_THEO_QD
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_RPT_BAO_CAO_GIAO_VON_THEO_QD : US_Object
	{
		private const string c_TableName = "RPT_BAO_CAO_GIAO_VON_THEO_QD";
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

		public string strSO_QUYET_DINH
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "SO_QUYET_DINH", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["SO_QUYET_DINH"] = value;
			}
		}

		public bool IsSO_QUYET_DINHNull()
		{
			return pm_objDR.IsNull("SO_QUYET_DINH");
		}

		public void SetSO_QUYET_DINHNull()
		{
			pm_objDR["SO_QUYET_DINH"] = System.Convert.DBNull;
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

		public bool IsID_LOAINull()
		{
			return pm_objDR.IsNull("ID_LOAI");
		}

		public void SetID_LOAINull()
		{
			pm_objDR["ID_LOAI"] = System.Convert.DBNull;
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

		public string strTEN_CLKM
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_CLKM", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TEN_CLKM"] = value;
			}
		}

		public bool IsTEN_CLKMNull()
		{
			return pm_objDR.IsNull("TEN_CLKM");
		}

		public void SetTEN_CLKMNull()
		{
			pm_objDR["TEN_CLKM"] = System.Convert.DBNull;
		}

		public string strTEN_DU_AN_CONG_TRINH
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_DU_AN_CONG_TRINH", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TEN_DU_AN_CONG_TRINH"] = value;
			}
		}

		public bool IsTEN_DU_AN_CONG_TRINHNull()
		{
			return pm_objDR.IsNull("TEN_DU_AN_CONG_TRINH");
		}

		public void SetTEN_DU_AN_CONG_TRINHNull()
		{
			pm_objDR["TEN_DU_AN_CONG_TRINH"] = System.Convert.DBNull;
		}

		public decimal dcTONG_TIEN_DACT_THEO_QD
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_TIEN_DACT_THEO_QD", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_TIEN_DACT_THEO_QD"] = value;
			}
		}

		public bool IsTONG_TIEN_DACT_THEO_QDNull()
		{
			return pm_objDR.IsNull("TONG_TIEN_DACT_THEO_QD");
		}

		public void SetTONG_TIEN_DACT_THEO_QDNull()
		{
			pm_objDR["TONG_TIEN_DACT_THEO_QD"] = System.Convert.DBNull;
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
		public US_RPT_BAO_CAO_GIAO_VON_THEO_QD()
		{
			pm_objDS = new DS_RPT_BAO_CAO_GIAO_VON_THEO_QD();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_RPT_BAO_CAO_GIAO_VON_THEO_QD(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_RPT_BAO_CAO_GIAO_VON_THEO_QD(decimal i_dbID)
		{
			pm_objDS = new DS_RPT_BAO_CAO_GIAO_VON_THEO_QD();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion


		public void FillDSTuNgayDenNgay(DS_RPT_BAO_CAO_GIAO_VON_THEO_QD v_ds
			, DateTime ip_dat_dau_nam
			, DateTime ip_dat_now
			, string ip_str_ma_quyet_dinh)
		{
			CStoredProc v_cstore = new CStoredProc("pr_bao_cao_giao_von_theo_qd_chuong_loai_khoan_muc");
			v_cstore.addDatetimeInputParam("@NGAY_DAU_NAM", ip_dat_dau_nam);
			v_cstore.addDatetimeInputParam("@NGAY_CUOI_NAM", ip_dat_now);
			v_cstore.addNVarcharInputParam("@ip_str_ma_quyet_dinh", ip_str_ma_quyet_dinh);
			v_cstore.fillDataSetByCommand(this, v_ds);
		}
	}
}
