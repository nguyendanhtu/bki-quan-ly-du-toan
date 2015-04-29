///************************************************
/// Generated by: TuDM
/// Date: 13/12/2014 02:24:39
/// Goal: Create User Service Class for V_GD_GIAO_KH_QBT
///************************************************
/// <summary>
/// Create User Service Class for V_GD_GIAO_KH_QBT
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_V_GD_GIAO_KH_QBT : US_Object
	{
		private const string c_TableName = "V_GD_GIAO_KH_QBT";
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

		public decimal dcID_QUYET_DINH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_QUYET_DINH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_QUYET_DINH"] = value;
			}
		}

		public bool IsID_QUYET_DINHNull()
		{
			return pm_objDR.IsNull("ID_QUYET_DINH");
		}

		public void SetID_QUYET_DINHNull()
		{
			pm_objDR["ID_QUYET_DINH"] = System.Convert.DBNull;
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

		public decimal dcID_CONG_TRINH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_CONG_TRINH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_CONG_TRINH"] = value;
			}
		}

		public bool IsID_CONG_TRINHNull()
		{
			return pm_objDR.IsNull("ID_CONG_TRINH");
		}

		public void SetID_CONG_TRINHNull()
		{
			pm_objDR["ID_CONG_TRINH"] = System.Convert.DBNull;
		}

		public decimal dcSO_TIEN_QUY_BT
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_QUY_BT", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_QUY_BT"] = value;
			}
		}

		public bool IsSO_TIEN_QUY_BTNull()
		{
			return pm_objDR.IsNull("SO_TIEN_QUY_BT");
		}

		public void SetSO_TIEN_QUY_BTNull()
		{
			pm_objDR["SO_TIEN_QUY_BT"] = System.Convert.DBNull;
		}

		public decimal dcSO_TIEN_NS
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_NS", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_NS"] = value;
			}
		}

		public bool IsSO_TIEN_NSNull()
		{
			return pm_objDR.IsNull("SO_TIEN_NS");
		}

		public void SetSO_TIEN_NSNull()
		{
			pm_objDR["SO_TIEN_NS"] = System.Convert.DBNull;
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

		public decimal dcSO_TIEN_NAM_TRUOC_CHUYEN_SANG
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN_NAM_TRUOC_CHUYEN_SANG", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["SO_TIEN_NAM_TRUOC_CHUYEN_SANG"] = value;
			}
		}

		public bool IsSO_TIEN_NAM_TRUOC_CHUYEN_SANGNull()
		{
			return pm_objDR.IsNull("SO_TIEN_NAM_TRUOC_CHUYEN_SANG");
		}

		public void SetSO_TIEN_NAM_TRUOC_CHUYEN_SANGNull()
		{
			pm_objDR["SO_TIEN_NAM_TRUOC_CHUYEN_SANG"] = System.Convert.DBNull;
		}

		public decimal dcID_LOAI_NHIEM_VU
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_NHIEM_VU", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_LOAI_NHIEM_VU"] = value;
			}
		}

		public bool IsID_LOAI_NHIEM_VUNull()
		{
			return pm_objDR.IsNull("ID_LOAI_NHIEM_VU");
		}

		public void SetID_LOAI_NHIEM_VUNull()
		{
			pm_objDR["ID_LOAI_NHIEM_VU"] = System.Convert.DBNull;
		}

		public decimal dcID_DU_AN
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_DU_AN", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_DU_AN"] = value;
			}
		}

		public bool IsID_DU_ANNull()
		{
			return pm_objDR.IsNull("ID_DU_AN");
		}

		public void SetID_DU_ANNull()
		{
			pm_objDR["ID_DU_AN"] = System.Convert.DBNull;
		}

		public string strTU_CHU_YN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TU_CHU_YN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TU_CHU_YN"] = value;
			}
		}

		public bool IsTU_CHU_YNNull()
		{
			return pm_objDR.IsNull("TU_CHU_YN");
		}

		public void SetTU_CHU_YNNull()
		{
			pm_objDR["TU_CHU_YN"] = System.Convert.DBNull;
		}

		public string strGHI_CHU_1
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU_1", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["GHI_CHU_1"] = value;
			}
		}

		public bool IsGHI_CHU_1Null()
		{
			return pm_objDR.IsNull("GHI_CHU_1");
		}

		public void SetGHI_CHU_1Null()
		{
			pm_objDR["GHI_CHU_1"] = System.Convert.DBNull;
		}

		public string strGHI_CHU_2
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU_2", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["GHI_CHU_2"] = value;
			}
		}

		public bool IsGHI_CHU_2Null()
		{
			return pm_objDR.IsNull("GHI_CHU_2");
		}

		public void SetGHI_CHU_2Null()
		{
			pm_objDR["GHI_CHU_2"] = System.Convert.DBNull;
		}

		public string strGHI_CHU_3
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU_3", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["GHI_CHU_3"] = value;
			}
		}

		public bool IsGHI_CHU_3Null()
		{
			return pm_objDR.IsNull("GHI_CHU_3");
		}

		public void SetGHI_CHU_3Null()
		{
			pm_objDR["GHI_CHU_3"] = System.Convert.DBNull;
		}

		public string strGHI_CHU_4
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "GHI_CHU_4", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["GHI_CHU_4"] = value;
			}
		}

		public bool IsGHI_CHU_4Null()
		{
			return pm_objDR.IsNull("GHI_CHU_4");
		}

		public void SetGHI_CHU_4Null()
		{
			pm_objDR["GHI_CHU_4"] = System.Convert.DBNull;
		}

		public decimal dcTONG_MUC_DAU_TU
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "TONG_MUC_DAU_TU", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["TONG_MUC_DAU_TU"] = value;
			}
		}

		public bool IsTONG_MUC_DAU_TUNull()
		{
			return pm_objDR.IsNull("TONG_MUC_DAU_TU");
		}

		public void SetTONG_MUC_DAU_TUNull()
		{
			pm_objDR["TONG_MUC_DAU_TU"] = System.Convert.DBNull;
		}

		public decimal dcTHOI_GIAN_THUC_HIEN
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "THOI_GIAN_THUC_HIEN", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["THOI_GIAN_THUC_HIEN"] = value;
			}
		}

		public bool IsTHOI_GIAN_THUC_HIENNull()
		{
			return pm_objDR.IsNull("THOI_GIAN_THUC_HIEN");
		}

		public void SetTHOI_GIAN_THUC_HIENNull()
		{
			pm_objDR["THOI_GIAN_THUC_HIEN"] = System.Convert.DBNull;
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

		public decimal dcID_LOAI_QUYET_DINH
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_QUYET_DINH", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_LOAI_QUYET_DINH"] = value;
			}
		}

		public bool IsID_LOAI_QUYET_DINHNull()
		{
			return pm_objDR.IsNull("ID_LOAI_QUYET_DINH");
		}

		public void SetID_LOAI_QUYET_DINHNull()
		{
			pm_objDR["ID_LOAI_QUYET_DINH"] = System.Convert.DBNull;
		}

		public decimal dcID_LOAI_QUYET_DINH_GIAO
		{
			get
			{
				return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_QUYET_DINH_GIAO", IPConstants.c_DefaultDecimal);
			}
			set
			{
				pm_objDR["ID_LOAI_QUYET_DINH_GIAO"] = value;
			}
		}

		public bool IsID_LOAI_QUYET_DINH_GIAONull()
		{
			return pm_objDR.IsNull("ID_LOAI_QUYET_DINH_GIAO");
		}

		public void SetID_LOAI_QUYET_DINH_GIAONull()
		{
			pm_objDR["ID_LOAI_QUYET_DINH_GIAO"] = System.Convert.DBNull;
		}

		public string strTEN_CONG_TRINH
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_CONG_TRINH", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TEN_CONG_TRINH"] = value;
			}
		}

		public bool IsTEN_CONG_TRINHNull()
		{
			return pm_objDR.IsNull("TEN_CONG_TRINH");
		}

		public void SetTEN_CONG_TRINHNull()
		{
			pm_objDR["TEN_CONG_TRINH"] = System.Convert.DBNull;
		}

		public string strTEN_DU_AN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_DU_AN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TEN_DU_AN"] = value;
			}
		}

		public bool IsTEN_DU_ANNull()
		{
			return pm_objDR.IsNull("TEN_DU_AN");
		}

		public void SetTEN_DU_ANNull()
		{
			pm_objDR["TEN_DU_AN"] = System.Convert.DBNull;
		}

		public string strMA_LOAI_KHOAN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "MA_LOAI_KHOAN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["MA_LOAI_KHOAN"] = value;
			}
		}

		public bool IsMA_LOAI_KHOANNull()
		{
			return pm_objDR.IsNull("MA_LOAI_KHOAN");
		}

		public void SetMA_LOAI_KHOANNull()
		{
			pm_objDR["MA_LOAI_KHOAN"] = System.Convert.DBNull;
		}

		public string strTEN_NGAN
		{
			get
			{
				return CNull.RowNVLString(pm_objDR, "TEN_NGAN", IPConstants.c_DefaultString);
			}
			set
			{
				pm_objDR["TEN_NGAN"] = value;
			}
		}

		public bool IsTEN_NGANNull()
		{
			return pm_objDR.IsNull("TEN_NGAN");
		}

		public void SetTEN_NGANNull()
		{
			pm_objDR["TEN_NGAN"] = System.Convert.DBNull;
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

		#endregion
		#region "Init Functions"
		public US_V_GD_GIAO_KH_QBT()
		{
			pm_objDS = new DS_V_GD_GIAO_KH_QBT();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_V_GD_GIAO_KH_QBT(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_V_GD_GIAO_KH_QBT(decimal i_dbID)
		{
			pm_objDS = new DS_V_GD_GIAO_KH_QBT();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion


		public void bc_tra_cuu_giao_ke_hoach_theo_du_an(DataSet ip_ds, decimal ip_dc_id_cong_trinh_du_an, string ip_str_ten_du_an, decimal ip_dc_id_don_vi, DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay)
		{
			CStoredProc v_prc = new CStoredProc("pr_bao_cao_tra_cuu_giao_ke_hoach_theo_du_an");
			v_prc.addDecimalInputParam("@ip_dc_id_du_an_cong_trinh", ip_dc_id_cong_trinh_du_an);
			v_prc.addNVarcharInputParam("@ip_str_ten_du_an", ip_str_ten_du_an);
			v_prc.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_prc.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_prc.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_prc.fillDataSetByCommand(this, ip_ds);
		}
	}
}
