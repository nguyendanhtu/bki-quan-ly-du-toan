///************************************************
/// Generated by: TuDM
/// Date: 10/11/2014 07:19:46
/// Goal: Create User Service Class for GD_GIAO_KH
///************************************************
/// <summary>
/// Create User Service Class for GD_GIAO_KH
/// </summary>

using System;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using System.Data.SqlClient;
using System.Data;
using WebDS;
using WebDS.CDBNames;

namespace WebUS
{

	public class US_GD_GIAO_KH : US_Object
	{
		private const string c_TableName = "GD_GIAO_KH";
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

		#endregion
		#region "Init Functions"
		public US_GD_GIAO_KH()
		{
			pm_objDS = new DS_GD_GIAO_KH();
			pm_strTableName = c_TableName;
			pm_objDR = pm_objDS.Tables[pm_strTableName].NewRow();
		}

		public US_GD_GIAO_KH(DataRow i_objDR)
			: this()
		{
			this.DataRow2Me(i_objDR);
		}

		public US_GD_GIAO_KH(decimal i_dbID)
		{
			pm_objDS = new DS_GD_GIAO_KH();
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
		public decimal getTongTienKH(
			decimal ip_dc_id_don_vi
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, string ip_str_is_nguon_ns_yn
			, decimal ip_dc_id_loai_du_an)
		{
			decimal op_dc_tong_tien = 0;
			DS_GD_GIAO_KH v_ds = new DS_GD_GIAO_KH();
			v_ds.Clear();
			v_ds.EnforceConstraints = false;
			CStoredProc v_sp = new CStoredProc("pr_GD_GIAO_KH_tong_so_tien");
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addNVarcharInputParam("@ip_str_is_nguon_ns_yn", ip_str_is_nguon_ns_yn);
			v_sp.addDecimalInputParam("@ip_dc_id_loai_du_an", ip_dc_id_loai_du_an);
			v_sp.fillDataSetByCommand(this, v_ds);
			for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
			{
				op_dc_tong_tien += CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][GD_GIAO_KH.SO_TIEN]);
			}
			return op_dc_tong_tien;
		}
		#endregion
	}
}
