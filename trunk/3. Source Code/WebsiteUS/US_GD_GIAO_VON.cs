///************************************************
/// Generated by: TuDM
/// Date: 10/11/2014 07:19:53
/// Goal: Create User Service Class for GD_GIAO_VON
///************************************************
/// <summary>
/// Create User Service Class for GD_GIAO_VON
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

    public class US_GD_GIAO_VON : US_Object
    {
        private const string c_TableName = "GD_GIAO_VON";
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

        public decimal dcSO_TIEN
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "SO_TIEN", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["SO_TIEN"] = value;
            }
        }

        public bool IsSO_TIENNull()
        {
            return pm_objDR.IsNull("SO_TIEN");
        }

        public void SetSO_TIENNull()
        {
            pm_objDR["SO_TIEN"] = System.Convert.DBNull;
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

        public decimal dcID_LOAI_GIAO_DICH
        {
            get
            {
                return CNull.RowNVLDecimal(pm_objDR, "ID_LOAI_GIAO_DICH", IPConstants.c_DefaultDecimal);
            }
            set
            {
                pm_objDR["ID_LOAI_GIAO_DICH"] = value;
            }
        }

        public bool IsID_LOAI_GIAO_DICHNull()
        {
            return pm_objDR.IsNull("ID_LOAI_GIAO_DICH");
        }

        public void SetID_LOAI_GIAO_DICHNull()
        {
            pm_objDR["ID_LOAI_GIAO_DICH"] = System.Convert.DBNull;
        }
        #endregion
        #region "Init Functions"
        public US_GD_GIAO_VON()
        {
            pm_objDS = new DS_GD_GIAO_VON();
            pm_strTableName = c_TableName;
            pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
        }

        public US_GD_GIAO_VON(DataRow i_objDR)
            : this()
        {
            this.DataRow2Me(i_objDR);
        }

        public US_GD_GIAO_VON(decimal i_dbID)
        {
            pm_objDS = new DS_GD_GIAO_VON();
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
