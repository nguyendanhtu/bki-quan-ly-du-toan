///************************************************
/// Generated by: TuDM
/// Date: 13/12/2014 02:22:27
/// Goal: Create User Service Class for DM_QUYET_DINH
///************************************************
/// <summary>
/// Create User Service Class for DM_QUYET_DINH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;


namespace WebUS
{

	public class US_DM_QUYET_DINH : US_Object
	{
		private const string c_TableName = "DM_QUYET_DINH";
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

		#endregion
		#region "Init Functions"
		public US_DM_QUYET_DINH()
		{
			pm_objDS = new DS_DM_QUYET_DINH();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_DM_QUYET_DINH(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_DM_QUYET_DINH(decimal i_dbID)
		{
			pm_objDS = new DS_DM_QUYET_DINH();
			pm_strTableName = c_TableName;
			IMakeSelectCmd v_objMkCmd = new CMakeAndSelectCmd(pm_objDS, c_TableName);
			v_objMkCmd.AddCondition("ID", i_dbID, eKieuDuLieu.KieuNumber, eKieuSoSanh.Bang);
			SqlCommand v_cmdSQL;
			v_cmdSQL = v_objMkCmd.getSelectCmd();
			this.FillDatasetByCommand(pm_objDS, v_cmdSQL);
			pm_objDR = getRowClone(pm_objDS.Tables[pm_strTableName].Rows[0]);
		}
		#endregion

		public void get_ds_quyet_dinh(
			DataSet op_ds
			, decimal ip_dc_id_don_vi
			, decimal ip_dc_id_loai_nhiem_vu
			, decimal ip_dc_id_cong_trinh
			, decimal ip_dc_id_du_an
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			,string ip_str_tu_khoa
            ,string ip_str_proc
			)
		{
            CStoredProc v_sp = new CStoredProc(ip_str_proc);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
			v_sp.addDecimalInputParam("@ip_dc_id_cong_trinh", ip_dc_id_cong_trinh);
			v_sp.addDecimalInputParam("@ip_dc_id_du_an", ip_dc_id_du_an);
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addNVarcharInputParam("@ip_str_tu_khoa", ip_str_tu_khoa);
			v_sp.fillDataSetByCommand(this, op_ds);
		}

        public void FillDatasetByLoaiQD(DS_DM_QUYET_DINH op_ds, DateTime ip_dat_tu_ngay, DateTime ip_dat_den_ngay, decimal ip_dc_id_loai_quyet_dinh, decimal ip_dc_id_loai_quyet_dinh_giao)
        {
            CStoredProc v_sp = new CStoredProc("pr_DM_QUYET_DINH_get_ds_by_loai_qd");
            v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
            v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
            v_sp.addDecimalInputParam("@ip_dc_id_loai_quyet_dinh", ip_dc_id_loai_quyet_dinh);
            v_sp.addDecimalInputParam("@ip_dc_id_loai_quyet_dinh_giao", ip_dc_id_loai_quyet_dinh_giao);
            v_sp.fillDataSetByCommand(this, op_ds);
        }
    }
}
