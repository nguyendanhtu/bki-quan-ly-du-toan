///************************************************
/// Generated by: TuDM
/// Date: 01/12/2014 03:25:48
/// Goal: Create User Service Class for RPT_BC_TINH_HINH_GIAI_NGAN
///************************************************
/// <summary>
/// Create User Service Class for RPT_BC_TINH_HINH_GIAI_NGAN
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_RPT_BC_TINH_HINH_GIAI_NGAN : US_Object
	{
		private const string c_TableName = "RPT_BC_TINH_HINH_GIAI_NGAN";
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

        public decimal dcKH_QBT
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "KH_QBT", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["KH_QBT"] = value;
            }
        }

        public bool IsKH_QBTNull()
        {
            return pm_objDR.IsNull("KH_QBT");
        }

        public void SetKH_QBTNull()
        {
            pm_objDR["KH_QBT"] = System.Convert.DBNull;
        }

        public decimal dcKH_NS
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "KH_NS", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["KH_NS"] = value;
            }
        }

        public bool IsKH_NSNull()
        {
            return pm_objDR.IsNull("KH_NS");
        }

        public void SetKH_NSNull()
        {
            pm_objDR["KH_NS"] = System.Convert.DBNull;
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

        public decimal dcKH_TONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "KH_TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["KH_TONG"] = value;
            }
        }

        public bool IsKH_TONGNull()
        {
            return pm_objDR.IsNull("KH_TONG");
        }

        public void SetKH_TONGNull()
        {
            pm_objDR["KH_TONG"] = System.Convert.DBNull;
        }

        public decimal dcDN_QBT_TRONG_THANG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_QBT_TRONG_THANG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_QBT_TRONG_THANG"] = value;
            }
        }

        public bool IsDN_QBT_TRONG_THANGNull()
        {
            return pm_objDR.IsNull("DN_QBT_TRONG_THANG");
        }

        public void SetDN_QBT_TRONG_THANGNull()
        {
            pm_objDR["DN_QBT_TRONG_THANG"] = System.Convert.DBNull;
        }

        public decimal dcDN_QBT_LUY_KE
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_QBT_LUY_KE", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_QBT_LUY_KE"] = value;
            }
        }

        public bool IsDN_QBT_LUY_KENull()
        {
            return pm_objDR.IsNull("DN_QBT_LUY_KE");
        }

        public void SetDN_QBT_LUY_KENull()
        {
            pm_objDR["DN_QBT_LUY_KE"] = System.Convert.DBNull;
        }

        public decimal dcDN_QBT_TONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_QBT_TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_QBT_TONG"] = value;
            }
        }

        public bool IsDN_QBT_TONGNull()
        {
            return pm_objDR.IsNull("DN_QBT_TONG");
        }

        public void SetDN_QBT_TONGNull()
        {
            pm_objDR["DN_QBT_TONG"] = System.Convert.DBNull;
        }

        public decimal dcDN_NS_TRONG_THANG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_NS_TRONG_THANG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_NS_TRONG_THANG"] = value;
            }
        }

        public bool IsDN_NS_TRONG_THANGNull()
        {
            return pm_objDR.IsNull("DN_NS_TRONG_THANG");
        }

        public void SetDN_NS_TRONG_THANGNull()
        {
            pm_objDR["DN_NS_TRONG_THANG"] = System.Convert.DBNull;
        }

        public decimal dcDN_NS_LUY_KE
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_NS_LUY_KE", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_NS_LUY_KE"] = value;
            }
        }

        public bool IsDN_NS_LUY_KENull()
        {
            return pm_objDR.IsNull("DN_NS_LUY_KE");
        }

        public void SetDN_NS_LUY_KENull()
        {
            pm_objDR["DN_NS_LUY_KE"] = System.Convert.DBNull;
        }

        public decimal dcDN_NS_TONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DN_NS_TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DN_NS_TONG"] = value;
            }
        }

        public bool IsDN_NS_TONGNull()
        {
            return pm_objDR.IsNull("DN_NS_TONG");
        }

        public void SetDN_NS_TONGNull()
        {
            pm_objDR["DN_NS_TONG"] = System.Convert.DBNull;
        }

        public decimal dcDTT_QBT_TRONG_THANG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_QBT_TRONG_THANG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_QBT_TRONG_THANG"] = value;
            }
        }

        public bool IsDTT_QBT_TRONG_THANGNull()
        {
            return pm_objDR.IsNull("DTT_QBT_TRONG_THANG");
        }

        public void SetDTT_QBT_TRONG_THANGNull()
        {
            pm_objDR["DTT_QBT_TRONG_THANG"] = System.Convert.DBNull;
        }

        public decimal dcDTT_QBT_LUY_KE
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_QBT_LUY_KE", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_QBT_LUY_KE"] = value;
            }
        }

        public bool IsDTT_QBT_LUY_KENull()
        {
            return pm_objDR.IsNull("DTT_QBT_LUY_KE");
        }

        public void SetDTT_QBT_LUY_KENull()
        {
            pm_objDR["DTT_QBT_LUY_KE"] = System.Convert.DBNull;
        }

        public decimal dcDTT_QBT_TONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_QBT_TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_QBT_TONG"] = value;
            }
        }

        public bool IsDTT_QBT_TONGNull()
        {
            return pm_objDR.IsNull("DTT_QBT_TONG");
        }

        public void SetDTT_QBT_TONGNull()
        {
            pm_objDR["DTT_QBT_TONG"] = System.Convert.DBNull;
        }

        public decimal dcDTT_NS_TRONG_THANG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_NS_TRONG_THANG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_NS_TRONG_THANG"] = value;
            }
        }

        public bool IsDTT_NS_TRONG_THANGNull()
        {
            return pm_objDR.IsNull("DTT_NS_TRONG_THANG");
        }

        public void SetDTT_NS_TRONG_THANGNull()
        {
            pm_objDR["DTT_NS_TRONG_THANG"] = System.Convert.DBNull;
        }

        public decimal dcDTT_NS_LUY_KE
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_NS_LUY_KE", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_NS_LUY_KE"] = value;
            }
        }

        public bool IsDTT_NS_LUY_KENull()
        {
            return pm_objDR.IsNull("DTT_NS_LUY_KE");
        }

        public void SetDTT_NS_LUY_KENull()
        {
            pm_objDR["DTT_NS_LUY_KE"] = System.Convert.DBNull;
        }

        public decimal dcDTT_NS_TONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "DTT_NS_TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["DTT_NS_TONG"] = value;
            }
        }

        public bool IsDTT_NS_TONGNull()
        {
            return pm_objDR.IsNull("DTT_NS_TONG");
        }

        public void SetDTT_NS_TONGNull()
        {
            pm_objDR["DTT_NS_TONG"] = System.Convert.DBNull;
        }

        public decimal dcCN_QBT
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "CN_QBT", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["CN_QBT"] = value;
            }
        }

        public bool IsCN_QBTNull()
        {
            return pm_objDR.IsNull("CN_QBT");
        }

        public void SetCN_QBTNull()
        {
            pm_objDR["CN_QBT"] = System.Convert.DBNull;
        }

        public decimal dcCN_NS
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "CN_NS", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["CN_NS"] = value;
            }
        }

        public bool IsCN_NSNull()
        {
            return pm_objDR.IsNull("CN_NS");
        }

        public void SetCN_NSNull()
        {
            pm_objDR["CN_NS"] = System.Convert.DBNull;
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

        public decimal dcGIA_TRI_THUC_HIEN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "GIA_TRI_THUC_HIEN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["GIA_TRI_THUC_HIEN"] = value;
            }
        }

        public bool IsGIA_TRI_THUC_HIENNull()
        {
            return pm_objDR.IsNull("GIA_TRI_THUC_HIEN");
        }

        public void SetGIA_TRI_THUC_HIENNull()
        {
            pm_objDR["GIA_TRI_THUC_HIEN"] = System.Convert.DBNull;
        }

        public decimal dcSO_CHUA_GN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "SO_CHUA_GN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["SO_CHUA_GN"] = value;
            }
        }

        public bool IsSO_CHUA_GNNull()
        {
            return pm_objDR.IsNull("SO_CHUA_GN");
        }

        public void SetSO_CHUA_GNNull()
        {
            pm_objDR["SO_CHUA_GN"] = System.Convert.DBNull;
        }

        #endregion
        #region "Init Functions"

        public void bc_tinh_hinh_giai_ngan_tong_cuc(DS_RPT_BC_TINH_HINH_GIAI_NGAN op_ds
            , DateTime ip_dat_tu_ngay
            , DateTime ip_dat_den_ngay
            , decimal ip_dc_user_id)
        {
            CStoredProc v_sp = new CStoredProc("pr_A530_Bao_cao_tong_hop_hinh_hinh_giai_ngan");
            v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
            v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
            v_sp.addDecimalInputParam("@ip_dc_id_don_vi", -1);
            v_sp.addDecimalInputParam("@ip_dc_id_user", ip_dc_user_id);
            v_sp.fillDataSetByCommand(this, op_ds);
        }

		public void bc_tinh_hinh_giai_ngan_don_vi(DS_RPT_BC_TINH_HINH_GIAI_NGAN op_ds
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, decimal ip_dc_id_don_vi
            , decimal ip_dc_user_id)
		{
            CStoredProc v_sp = new CStoredProc("pr_A350_Bao_cao_tinh_hinh_giai_ngan_cua_don_vi");
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
            v_sp.addDecimalInputParam("@ip_dc_id_user", ip_dc_user_id);
			v_sp.fillDataSetByCommand(this, op_ds);
		}
		public void bc_tinh_hinh_giai_ngan_tong_cuc(DataSet op_ds
		, DateTime ip_dat_tu_ngay
		, DateTime ip_dat_den_ngay
		)
		{
			CStoredProc v_sp = new CStoredProc("pr_RPT_TINH_HINH_GIAI_NGAN_VON");
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.fillDataSetByCommand(this, op_ds);
		}

    }
        #endregion
}
