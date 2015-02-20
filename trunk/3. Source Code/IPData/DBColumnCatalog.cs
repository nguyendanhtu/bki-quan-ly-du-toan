// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports



namespace IP.Core.IPData
{
	namespace DBNames
	{
		//********************** NAME OF TABLES
		public class TABLENAME
		{
			public const string HT_BACKUP_HISTORY = "HT_BACKUP_HISTORY";
			public const string HT_BUSINESS_PROCESS_LOCK = "HT_BUSINESS_PROCESS_LOCK";
			public const string HT_DON_VI = "HT_DON_VI";
			public const string HT_NGUOI_SU_DUNG = "HT_NGUOI_SU_DUNG";
			public const string HT_NHAT_KY_TRUY_NHAP = "HT_NHAT_KY_TRUY_NHAP";
			public const string HT_NHOM_DUOC_QUYEN_TRUY_NHAP = "HT_NHOM_DUOC_QUYEN_TRUY_NHAP";
			public const string HT_NHOM_NGUOI_SU_DUNG = "HT_NHOM_NGUOI_SU_DUNG";
			public const string HT_PHAN_QUYEN = "HT_PHAN_QUYEN";
			public const string HT_PHAN_QUYEN_CHO_NHOM = "HT_PHAN_QUYEN_CHO_NHOM";
			public const string HT_QUYEN_TRUY_CAP_CSDL_CUA_USER = "HT_QUYEN_TRUY_CAP_CSDL_CUA_USER";
			public const string HT_TEN_CSDL_CUA_DON_VI = "HT_TEN_CSDL_CUA_DON_VI";
			public const string HT_THAM_SO_HE_THONG = "HT_THAM_SO_HE_THONG";
		}
		public class HT_BACKUP_HISTORY
		{
			public const string ID = "ID";
			public const string NGUOI_BACKUP = "NGUOI_BACKUP";
			public const string NGAY_BACKUP = "NGAY_BACKUP";
			public const string NOI_LUU = "NOI_LUU";
			public const string TEN_FILE = "TEN_FILE";
			public const string GhI_CHU = "GhI_CHU";
		}
		//****************************
		public class HT_BUSINESS_PROCESS_LOCK
		{
			public const string LOCK_NAME = "LOCK_NAME";
			public const string GRANTED_SYS_DATETIME = "GRANTED_SYS_DATETIME";
		}
		
		//****************************
		public class HT_NGUOI_SU_DUNG
		{
			public const string ID = "ID";
			public const string TEN_TRUY_CAP = "TEN_TRUY_CAP";
			public const string TEN = "TEN";
			public const string MAT_KHAU = "MAT_KHAU";
			public const string NGAY_TAO = "NGAY_TAO";
			public const string NGUOI_TAO = "NGUOI_TAO";
			public const string TRANG_THAI = "TRANG_THAI";
			public const string ID_DON_VI = "ID_DON_VI";
			public const string BUILT_IN_YN = "BUILT_IN_YN";
			public const string MAIL = "MAIL";
		}
		//****************************
		public class HT_NHAT_KY_TRUY_NHAP
		{
			public const string ID = "ID";
			public const string ID_NGUOI_SU_DUNG = "ID_NGUOI_SU_DUNG";
			public const string NHOM_TRUY_NHAP = "NHOM_TRUY_NHAP";
			public const string THOI_GIAN_TRUY_NHAP = "THOI_GIAN_TRUY_NHAP";
			public const string THOI_GIAN_LOGOUT = "THOI_GIAN_LOGOUT";
			public const string DA_LOG_OUT_YN = "DA_LOG_OUT_YN";
			public const string GHI_CHU = "GHI_CHU";
			public const string MA_PHAN_HE = "MA_PHAN_HE";
		}
		
		//****************************
		public class CM_DM_LOAI_TD_LIST
		{
			public const string TRANG_THAI_GD = "TRANG_THAI_GD";
			public const string LOAI_TRAI_PHIEU = "LOAI_TRAI_PHIEU";
			public const string PHAN_QUYEN = "PHAN_QUYEN";
			public const string LOAI_TRAI_CHU = "LOAI_TRAI_CHU";
			public const string DON_VI_KY_HAN = "DON_VI_KY_HAN";
			public const string LOAI_NHAC_NHAC_VIEC = "LOAI_NHAC_NHAC_VIEC";
			public const string NGAN_HANG_DL_QUAN_LY_TK = "NGAN_HANG_DL_QUAN_LY_TK";
			public const string LOAI_NGAY_LAM_VIEC = "LOAI_NGAY_LAM_VIEC";
			public const string TRANG_THAI_DANH_MUC = "TRANG_THAI_DANH_MUC";
		}
		
		
		
	}
}
