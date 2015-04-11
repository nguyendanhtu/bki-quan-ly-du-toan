// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;



//Imports eSchool.eSchoolData
//Imports eSchool.eSchoolUserService

namespace IP.Core.IPSystemAdmin
{
	#region Nhiệm vụ của Class
	//************************************************************************
	//* Phục vụ lấy dữ liệu đặc trưng cho ứng dụng
	//*
	//************************************************************************
	#endregion

	public class CAppContext_201 : IControlerControl
	{

		#region Variables
		private static US_HT_NGUOI_SU_DUNG m_us_user;
		private static string m_strRunMode;
		private static DS_HT_PHAN_QUYEN_DETAIL m_dsDecentralization = new DS_HT_PHAN_QUYEN_DETAIL();
		#endregion

		#region Public interface
		public static void LoadDecentralizationByUserLogin()
		{
			US_HT_PHAN_QUYEN_DETAIL v_us = new US_HT_PHAN_QUYEN_DETAIL();
			m_dsDecentralization.Clear();
			v_us.FillDatasetByUserLogin(m_dsDecentralization, CAppContext_201.getCurrentUserName());
		}
		public bool CanUseControl(string ip_strFormName, string ip_strControlName, string ip_strControlType)
		{
			return IP.Core.IPSystemAdmin.CAppContext_201.CanUseThisControl(ip_strFormName, ip_strControlName, ip_strControlType);
		}

		public static bool IsHavingQuyen(string i_str_ma_quyen)
		{
			return US_HT_NGUOI_SU_DUNG.IsHavingMA_QUYEN(
				CAppContext_201.getCurrentUserID()
				, i_str_ma_quyen);

		}



		public static void InitializeContext(CLoginInformation_302 i_LoginInfo)
		{
			//*****************************************************************
			//* Init context
			//* 1. các giá trị thường dùng trong hệ thống
			//* 2. load phân quyền hệ thống về
			//* 3. Các biến môi trường khác
			//****************************************************************
			//* 1. các giá trị thường dùng trong hệ thống
			//        Debug.Assert(m_strCurrentUserName <> "")
			try
			{

				m_us_user = i_LoginInfo.m_us_user;
				//* 2. load phân quyền hệ thống về
				//* 3. Các biến môi trường khác
				System.Configuration.AppSettingsReader v_configReader = new System.Configuration.AppSettingsReader();
				m_strRunMode = System.Convert.ToString(v_configReader.GetValue("RUN_MODE", IPConstants.C_StringType).ToString());
				v_configReader = null;
			}
			catch (Exception ex)
			{
				throw (ex);
			}
		}

		public static DateTime getCurentDate()
		{
			//*****************************************************************
			//*  Gọi để lấy ngày hiện tại
			//***********************************************************************
			return System.DateTime.Now.Date;
		}

		public static string getCurrentUserName()
		{
			return m_us_user.strTEN_TRUY_CAP;
		}

		public static string getCurrentUser()
		{
			return m_us_user.strTEN;
		}

		public static decimal getCurrentUserID()
		{
			return m_us_user.dcID;
		}

		public static string getRunMode()
		{
			return m_strRunMode;
		}

		public static string getAppPath()
		{
			return AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
		}

		public static string get_DefaultReportRootPath()
		{
			string v_strRootPath = "";
			v_strRootPath = Application.StartupPath;
			//v_strRootPath += "\..\.."
			v_strRootPath += "\\Reports";
			return v_strRootPath;
		}

		public static bool checkLicense()
		{

			return default(bool);
		}
		#endregion


		#region Private Methods
		private static void LoadDecentralization(DS_HT_PHAN_QUYEN_DETAIL ip_dsDecentralization)
		{
			m_dsDecentralization = ip_dsDecentralization;
		}

		private static bool CanUseThisControl(string
			ip_strFormName, string ip_strControlName, string ip_strControlType)
		{
			if (m_dsDecentralization.HT_PHAN_QUYEN_DETAIL.Select("FORM_NAME = \'" + ip_strFormName + "\' AND CONTROL_NAME =\'" + ip_strControlName + "\'").Length > 0)
			{
				return true;
			}
			return false;
		}
		#endregion
	}
	public class PHAN_QUYEN
	{
		public const string QLHT_NHOM_NGUOI_DUNG = "QLHT_nhom_nguoi_dung";
		public const string QLHT_NGUOI_SU_DUNG = "QLHT_nguoi_su_dung";
		public const string QLHT_NGAY_LAM_VIEC = "QLHT_ngay_lam_viec";
		public const string QLHT_THAM_SO_HE_THONG = "QLHT_tham_so_he_thong";
		public const string QLHT_THAM_SO_NHAC_VIEC = "QLHT_tham_so_nhac_viec";
		public const string QLHT_LICH_SU_TRUY_CAP = "QLHT_lich_su_truy_cap";
		public const string QLTD_TU_DIEN = "QLTD_tu_dien";
		public const string QLDM_DON_VI_CAP_CC = "QLDM_don_vi_cap_cc";
		public const string QLDM_DOT_CAP_CHUNG_CHI = "QLDM_dot_cap_chung_chi";
		public const string QLDM_PHOI_CHUNG_CHI = "QLDM_phoi";
		public const string QLDM_LOAI_PHOI = "QLDM_loai_phoi";
		public const string QLDM_DUOI_SO_VAO_SO = "QLDM_duoi_so_vao_so";
		public const string QLDM_THONG_TIN_PHOI = "QLDM_thong_tin_phoi";
		public const string QLNV_NHAP_THONG_TIN_CHUNG_CC = "QLNV_Nhap_thong_tin_chung_cc";
		public const string QLNV_NHAP_TT_TUNG_CHUNG_CHI = "QLNV_Nhap_tt_tung_chung_chi";
		public const string QLNV_IMPORT_CHUNG_CHI = "QLNV_Import_chung_chi";
		public const string QLNV_DUYET_CHUNG_CHI = "QLNV_Duyet_chung_chi";
		public const string QLNV_EXPORT_BAN_MEM_CC = "QLNV_Export_ban_mem_cc";
		public const string QLNV_GT_DM_GIAO_DICH = "QLNV_GT_dm_giao_dich";
		public const string QLNV_GT_BAO_CAO = "QLNV_GT_bao_cao";
		public const string QLNV_IMPORT_CHUNG_NHAN_CHUAN_TOPICA = "QLNV_Import_chung_nhan_chuan_Topica";
		public const string QLNV_IMPORT_CHUNG_NHAN_HD_NGOAI_KHOA_HOC_TAP = "QLNV_Import_chung_nhan_hd_ngoai_khoa_hoc_tap";
		public const string QLNV_CNLS_THOA_THUAN = "QLNV_cnls_thoa_thuan";
		public const string QLNV_TRA_LAI = "QLNV_tra_lai";
		public const string QLNV_TRA_VON = "QLNV_tra_von";
		public const string BC_DANH_SACH_CHUNG_CHI = "BC_Danh_sach_chung_chi";
		public const string BC_THONG_BAO_NGAY_CHOT_DANH_SACH = "BC_thong_bao_ngay_chot_danh_sach";
		public const string BC_THONG_BAO_THANH_TOAN_LAI = "BC_thong_bao_thanh_toan_lai";
		public const string BC_PHIEU_DE_NGHI_LAI_SUAT_KY_TIEP_THEO = "BC_phieu_de_nghi_lai_suat_ky_tiep_theo";
		public const string BC_DANH_SACH_TRA_LAI = "BC_danh_sach_tra_lai";
		public const string BC_DANH_SACH_NGUOI_SU_HUU_TRAI_PHIEU_IN_TIMES = "BC_danh_sach_nguoi_su_huu_trai_phieu_in_times";
		public const string BC_YEU_CAU_TO_CHUC_PHAT_HANH_TRA_LAI = "BC_yeu_cau_to_chuc_phat_hanh_tra_lai";
		public const string BC_LAI_SUAT_TRAI_PHIEU = "BC_lai_suat_trai_phieu";
		public const string BC_CHUYEN_NHUONG = "BC_chuyen_nhuong";
		public const string GIOI_THIEU = "Gioi_thieu";
		public const string QUY_TRINH_CAP_CC = "Quy_trinh_cap_cc";
		public const string IN_SO_SO_HUU_TRAI_PHIEU = "In_so_so_huu_trai_phieu";
	}

}
