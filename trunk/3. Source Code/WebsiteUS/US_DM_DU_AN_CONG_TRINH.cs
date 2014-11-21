///************************************************
/// Generated by: TuDM
/// Date: 10/11/2014 07:19:17
/// Goal: Create User Service Class for DM_DU_AN_CONG_TRINH
///************************************************
/// <summary>
/// Create User Service Class for DM_DU_AN_CONG_TRINH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

    public class US_DM_DU_AN_CONG_TRINH : US_Object
    {
        private const string c_TableName = "DM_DU_AN_CONG_TRINH";
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

        #endregion
        #region "Init Functions"
        public US_DM_DU_AN_CONG_TRINH()
        {
            pm_objDS = new DS_DM_DU_AN_CONG_TRINH();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_DM_DU_AN_CONG_TRINH(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_DM_DU_AN_CONG_TRINH(decimal i_dbID)
        {
            pm_objDS = new DS_DM_DU_AN_CONG_TRINH();
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
        public void getDuAnCongTrinhGiaoKHByDate(DS_DM_DU_AN_CONG_TRINH op_ds
            , decimal ip_dc_id_don_vi
            , decimal ip_dc_id_loai_cong_trinh
            , DateTime ip_dat_tu_ngay
            , DateTime ip_dat_den_ngay
            , string ip_str_tu_khoa)
        {
            CStoredProc v_sp = new CStoredProc("pr_dm_du_an_giao_kh_search_by_date");
            v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
            v_sp.addDecimalInputParam("@ip_dc_id_loai_du_an", ip_dc_id_loai_cong_trinh);
            v_sp.addNVarcharInputParam("@ip_str_tu_khoa", ip_str_tu_khoa);
            v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
            v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
            v_sp.fillDataSetByCommand(this, op_ds);
        }
        #endregion
    }
}
