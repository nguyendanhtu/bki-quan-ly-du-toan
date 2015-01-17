///************************************************
/// Generated by: ThaiPH
/// Date: 14/12/2014 05:18:52
/// Goal: Create User Service Class for V_DM_QUYET_DINH
///************************************************
/// <summary>
/// Create User Service Class for V_DM_QUYET_DINH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

    public class US_V_DM_QUYET_DINH : US_Object
    {
        private const string c_TableName = "V_DM_QUYET_DINH";
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

        public string strTEN_LOAI_QUYET_DINH
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_LOAI_QUYET_DINH", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_LOAI_QUYET_DINH"] = value;
            }
        }

        public bool IsTEN_LOAI_QUYET_DINHNull()
        {
            return pm_objDR.IsNull("TEN_LOAI_QUYET_DINH");
        }

        public void SetTEN_LOAI_QUYET_DINHNull()
        {
            pm_objDR["TEN_LOAI_QUYET_DINH"] = System.Convert.DBNull;
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

        public string strTEN_LOAI_QUYET_DINH_GIAO
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_LOAI_QUYET_DINH_GIAO", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_LOAI_QUYET_DINH_GIAO"] = value;
            }
        }

        public bool IsTEN_LOAI_QUYET_DINH_GIAONull()
        {
            return pm_objDR.IsNull("TEN_LOAI_QUYET_DINH_GIAO");
        }

        public void SetTEN_LOAI_QUYET_DINH_GIAONull()
        {
            pm_objDR["TEN_LOAI_QUYET_DINH_GIAO"] = System.Convert.DBNull;
        }

        public string strTEN_DON_VI
        {
            get
            {
                return CNull.RowNVLString(pm_objDR, "TEN_DON_VI", IPConstants.c_DefaultString);
            }
            set
            {
                pm_objDR["TEN_DON_VI"] = value;
            }
        }

        public bool IsTEN_DON_VINull()
        {
            return pm_objDR.IsNull("TEN_DON_VI");
        }

        public void SetTEN_DON_VINull()
        {
            pm_objDR["TEN_DON_VI"] = System.Convert.DBNull;
        }

        public decimal dcQBT
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "QBT", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["QBT"] = value;
            }
        }

        public bool IsQBTNull()
        {
            return pm_objDR.IsNull("QBT");
        }

        public void SetQBTNull()
        {
            pm_objDR["QBT"] = System.Convert.DBNull;
        }

        public decimal dcNS
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "NS", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["NS"] = value;
            }
        }

        public bool IsNSNull()
        {
            return pm_objDR.IsNull("NS");
        }

        public void SetNSNull()
        {
            pm_objDR["NS"] = System.Convert.DBNull;
        }

        public decimal dcTONG
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "TONG", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["TONG"] = value;
            }
        }

        public bool IsTONGNull()
        {
            return pm_objDR.IsNull("TONG");
        }

        public void SetTONGNull()
        {
            pm_objDR["TONG"] = System.Convert.DBNull;
        }

        #endregion
        #region "Init Functions"
        public US_V_DM_QUYET_DINH()
        {
            pm_objDS = new DS_V_DM_QUYET_DINH();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_V_DM_QUYET_DINH(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_V_DM_QUYET_DINH(decimal i_dbID)
        {
            pm_objDS = new DS_V_DM_QUYET_DINH();
            pm_strTableName = c_TableName;
            IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
            v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
            SqlCommand v_cmdSQL;
            v_cmdSQL = v_objMkCmd.getSelectCmd();
            this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
            pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
        }
        #endregion
        public void FillDatasetByIdLoaiQuyetDinh(DS_V_DM_QUYET_DINH ip_ds, decimal ip_dc_id_loai_quyet_dinh, DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay, string ip_str_filter)
        {
            CStoredProc v_prc = new CStoredProc("pr_V_DM_QUYET_DINH_filter_by_id_loai_quyet_dinh");
            v_prc.addDecimalInputParam("@ID_LOAI_QUYET_DINH", ip_dc_id_loai_quyet_dinh);
            v_prc.addDatetimeInputParam("@DAT_TU_NGAY", ip_dat_tu_ngay);
            v_prc.addDatetimeInputParam("@DAT_DEN_NGAY", ip_dat_den_ngay);
            v_prc.addNVarcharInputParam("@STR_FILTER", ip_str_filter);
            v_prc.fillDataSetByCommand(this, ip_ds);
        }
        public void FillDatasetByIdDonVi(DS_V_DM_QUYET_DINH ip_ds, decimal ip_dc_id_don_vi, DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay, string ip_str_filter)
        {
            CStoredProc v_prc = new CStoredProc("pr_A291_danh_sach_quyet_dinh_giao_von");
            v_prc.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
            v_prc.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
            v_prc.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
            v_prc.addNVarcharInputParam("@ip_str_tu_khoa", ip_str_filter);
            v_prc.fillDataSetByCommand(this, ip_ds);
        }
    }
}
