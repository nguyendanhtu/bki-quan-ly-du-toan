///************************************************
/// Generated by: TuDM
/// Date: 13/12/2014 02:21:47
/// Goal: Create User Service Class for GD_CHI_TIET_GIAO_KH
///************************************************
/// <summary>
/// Create User Service Class for GD_CHI_TIET_GIAO_KH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_GD_CHI_TIET_GIAO_KH : US_Object
	{
		private const string c_TableName = "GD_CHI_TIET_GIAO_KH";
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

		#endregion
		#region "Init Functions"
		public US_GD_CHI_TIET_GIAO_KH()
		{
			pm_objDS = new DS_GD_CHI_TIET_GIAO_KH();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_GD_CHI_TIET_GIAO_KH(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_GD_CHI_TIET_GIAO_KH(decimal i_dbID)
		{
			pm_objDS = new DS_GD_CHI_TIET_GIAO_KH();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

		#region Additional
		//public decimal getTongTienKH(
		//	decimal ip_dc_id_don_vi
		//	, DateTime ip_dat_tu_ngay
		//	, DateTime ip_dat_den_ngay
		//	, string ip_str_is_nguon_ns_yn
		//	, decimal ip_dc_id_loai_du_an)
		//{
		//	decimal op_dc_tong_tien = 0;
		//	DS_GD_GIAO_KH v_ds = new DS_GD_GIAO_KH();
		//	v_ds.Clear();
		//	v_ds.EnforceConstraints = false;
		//	CStoredProc v_sp = new CStoredProc("pr_GD_GIAO_KH_tong_so_tien");
		//	v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
		//	v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
		//	v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
		//	v_sp.addNVarcharInputParam("@ip_str_is_nguon_ns_yn", ip_str_is_nguon_ns_yn);
		//	v_sp.addDecimalInputParam("@ip_dc_id_loai_du_an", ip_dc_id_loai_du_an);
		//	v_sp.fillDataSetByCommand(this, v_ds);
		//	for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
		//	{
		//		if (v_ds.Tables[0].Rows[i][GD_GIAO_KH.SO_TIEN_NS] != null && v_ds.Tables[0].Rows[i][GD_GIAO_KH.SO_TIEN_QUY_BT] != null)
		//		{
		//			op_dc_tong_tien += CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][GD_GIAO_KH.SO_TIEN_NS]) + CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][GD_GIAO_KH.SO_TIEN_QUY_BT]);
		//		}

		//	}
		//	return op_dc_tong_tien;
		//}
		//public bool update_ten_du_an_giao_kh_to_giao_von_va_unc(
		//	decimal ip_dc_id_don_vi
		//	, decimal ip_dc_id_loai_nhiem_vu
		//	, decimal ip_dc_id_du_an_cong_trinh
		//	, string ip_str_ten_du_an_cu
		//	, string ip_str_ten_du_an_moi
		//	, DateTime ip_dat_tu_ngay
		//	, DateTime ip_dat_den_ngay)
		//{
		//	CStoredProc v_sp = new CStoredProc("pr_update_ten_du_an_from_gd_giao_kh");
		//	v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
		//	v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
		//	v_sp.addDecimalInputParam("@ip_dc_id_du_an_cong_trinh", ip_dc_id_du_an_cong_trinh);
		//	v_sp.addNVarcharInputParam("@ip_str_ten_du_an_cu", ip_str_ten_du_an_cu);
		//	v_sp.addNVarcharInputParam("@ip_str_ten_du_an_moi", ip_str_ten_du_an_moi);
		//	v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
		//	v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
		//	try
		//	{
		//		v_sp.ExecuteCommand(this);
		//	}
		//	catch (Exception)
		//	{
		//		return false;
		//	}
		//	return true;
		//}

		#endregion
	}
}
