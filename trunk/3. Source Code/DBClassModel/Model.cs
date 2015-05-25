using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace DBClassModel
{
	#region Addtionals
	public class DM_QUYET_DINHs
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public string str_NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

	}

	#endregion

	#region Gen class

	public class CM_COMPANY_INFO
	{
		public decimal ID { get; set; }

		public string COMPANY_NAME { get; set; }

		public string COMPANY_ADDRESS { get; set; }

	}
	public class CM_DM_LOAI_TD
	{
		public decimal ID { get; set; }

		public string MA_LOAI { get; set; }

		public string TEN_LOAI { get; set; }

	}
	public class CM_DM_TU_DIEN
	{
		public decimal ID { get; set; }

		public string MA_TU_DIEN { get; set; }

		public decimal ID_LOAI_TU_DIEN { get; set; }

		public string TEN_NGAN { get; set; }

		public string TEN { get; set; }

		public string GHI_CHU { get; set; }

	}
	public class DM_CHUONG_LOAI_KHOAN_MUC
	{
		public decimal ID { get; set; }

		public decimal ID_CHA { get; set; }

		public string TEN { get; set; }

		public string MA_SO { get; set; }

		public decimal ID_LOAI { get; set; }

	}
	public class DM_CONG_TRINH_DU_AN_GOI_THAU
	{
		public decimal ID { get; set; }

		public decimal ID_CHA { get; set; }

		public string TEN { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public decimal ID_LOAI { get; set; }

		public decimal ID_DON_VI { get; set; }

	}
	public class DM_DON_VI
	{
		public decimal ID { get; set; }

		public string MA_DON_VI { get; set; }

		public string TEN_DON_VI { get; set; }

		public string LOAI_HINH_DON_VI { get; set; }

		public decimal ID_LOAI_DON_VI { get; set; }

		public decimal ID_DON_VI_CAP_TREN { get; set; }

		public decimal STT { get; set; }

		public decimal LEVEL_MODE { get; set; }

	}
	public class DM_GIAI_NGAN
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public string SO_UNC { get; set; }

		public string IS_NGUON_NS_YN { get; set; }

		public string MA_DVQHNS { get; set; }

		public string MA_CTMT_DA_HTCT { get; set; }

		public string NT_TEN_DON_VI { get; set; }

		public string NT_MA_SO_THUE { get; set; }

		public string NT_MA_NDKT { get; set; }

		public string NT_MA_CHUONG { get; set; }

		public string NT_CQ_QL_THU { get; set; }

		public string NT_MA_CQ_THU { get; set; }

		public string NT_KBNN_HACH_TOAN_KHOAN_THU { get; set; }

		public string NT_SO_TIEN_NOP_THUE { get; set; }

		public string TTDVH_DON_VI_NHAN_TIEN { get; set; }

		public string TTDVH_MA_DVQHNS { get; set; }

		public string TTDVH_DIA_CHI { get; set; }

		public string TTDVH_TAI_KHOAN { get; set; }

		public string TTDVH_MA_CTMT_DA_VA_HTCT { get; set; }

		public string TTDVH_KHO_BAC { get; set; }

		public string TTDVH_SO_TIEN { get; set; }

		public string THUC_CHI_YN { get; set; }

		public string TAM_UNG_YN { get; set; }

		public string UNG_TRUOC_DU_DK_THANH_TOAN_YN { get; set; }

		public string UNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN { get; set; }

		public string CHUYEN_KHOAN_YN { get; set; }

		public string TIEN_MAT_YN { get; set; }

		public string MA_CAP_NS { get; set; }

		public string SO_CKC_HDK { get; set; }

		public string SO_CKC_HDTH { get; set; }

		public string TEN_CTMT_DA { get; set; }

		public string NGUOI_NHAN_TIEN_CMND_SO { get; set; }

		public string NGUOI_NHAN_TIEN_CAP_NGAY { get; set; }

		public string NGUOI_NHAN_TIEN_NOI_CAP { get; set; }

		public string MA_TKKT { get; set; }

	}
	public class DM_QUYET_DINH
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

	}
	public class DM_THONG_TIN_DON_VI
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string DIA_CHI { get; set; }

		public string KHO_BAC { get; set; }

		public string MA_TKKT1 { get; set; }

		public string MA_DVQHNS { get; set; }

		public string MA_TKKT2 { get; set; }

		public string MA_DVQHNS_1 { get; set; }

		public string MA_DVQHNS_2 { get; set; }

		public string MA_TKKT_QBT_2 { get; set; }

		public string MA_TKKT_QBT_3 { get; set; }

		public string MA_TKKT_QBT_4 { get; set; }

		public string MA_TKKT_NS_2 { get; set; }

		public string MA_TKKT_NS_3 { get; set; }

		public string MA_TKKT_NS_4 { get; set; }

	}
	public class DOC_COLUMN_COMMENT
	{
		public string COLUMN_NAME { get; set; }

		public string TABLE_NAME { get; set; }

		public string COLUMN_COMMENT { get; set; }

	}
	public class DOC_TABLE_COMMENT
	{
		public string TABLE_NAME { get; set; }

		public string TABLE_COMMENT { get; set; }

	}
	public class GD_CHI_TIET_GIAI_NGAN
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_NOP_THUE { get; set; }

		public decimal ID_GIAI_NGAN { get; set; }

		public string NOI_DUNG_CHI { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal SO_TIEN_TT_CHO_DV_HUONG { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public string MA_NGUON_NSNN { get; set; }

	}
	public class GD_CHI_TIET_GIAO_KH
	{
		public decimal ID { get; set; }

		public decimal ID_QUYET_DINH { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_QUY_BT { get; set; }

		public decimal SO_TIEN_NS { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal SO_TIEN_NAM_TRUOC_CHUYEN_SANG { get; set; }

		public decimal SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public decimal ID_DU_AN { get; set; }

		public string TU_CHU_YN { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public decimal TONG_MUC_DAU_TU { get; set; }

		public decimal THOI_GIAN_THUC_HIEN { get; set; }

		public string LOAI_CONG_TRINH { get; set; }

	}
	public class GD_CHI_TIET_GIAO_VON
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_QUYET_DINH { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_QUY_BT { get; set; }

		public decimal SO_TIEN_NS { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

	}
	public class GD_DU_TOAN_THU_CHI_PHI_PHA
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string MA_SO_PARENT { get; set; }

		public string TT { get; set; }

		public string HANG_MUC { get; set; }

		public decimal KINH_PHI_GIAO_KH { get; set; }

		public decimal KLTH_QUY_I { get; set; }

		public decimal KLTH_QUY_II { get; set; }

		public decimal KLTH_QUY_III { get; set; }

		public decimal KLTH_QUY_IV { get; set; }

		public string GHI_CHU_GIAO_KH { get; set; }

		public string GHI_CHU_QUY_I { get; set; }

		public string GHI_CHU_QUY_II { get; set; }

		public string GHI_CHU_QUY_III { get; set; }

		public string GHI_CHU_QUY_IV { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public string CONG_THUC { get; set; }

		public bool IS_FIX { get; set; }

		public decimal ID_QUYET_DINH { get; set; }

	}
	public class GD_KHOI_LUONG
	{
		public decimal ID { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal SO_TIEN_DA_NGHIEM_THU { get; set; }

		public decimal SO_TIEN_CHUA_GIAI_NGAN { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public decimal SO_TIEN_DA_NGHIEM_THU_NS { get; set; }

	}
	public class GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string CHI_TIEU { get; set; }

		public string MA_SO_PARENT { get; set; }

		public decimal CAP { get; set; }

		public decimal SO_BAO_CAO { get; set; }

		public decimal SO_XET_DUYET { get; set; }

		public string CONG_THUC { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

	}
	public class GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
	{
		public decimal ID { get; set; }

		public string MA_LOAI { get; set; }

		public string MA_KHOAN { get; set; }

		public string MA_MUC { get; set; }

		public string MA_TIEU_MUC { get; set; }

		public string NOI_DUNG_CHI { get; set; }

		public string NHOM { get; set; }

		public string LOAI { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public decimal SO_BAO_CAO { get; set; }

		public decimal SO_XET_DUYET { get; set; }

	}
	public class GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string TT { get; set; }

		public string NOI_DUNG { get; set; }

		public string MA_SO_PARENT { get; set; }

		public decimal CAP { get; set; }

		public decimal SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC { get; set; }

		public decimal SO_KIEN_NGHI_CO_QUAN_TAI_CHINH { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public decimal SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC { get; set; }

		public decimal SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH { get; set; }

	}
	public class GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
	{
		public decimal ID { get; set; }

		public string TT { get; set; }

		public string TEN_LOAI_NHIEM_VU { get; set; }

		public string CONG_TRINH { get; set; }

		public string DU_AN { get; set; }

		public decimal GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET { get; set; }

		public decimal GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY { get; set; }

		public decimal GIA_TRI_CTHT_NAM_NAY { get; set; }

		public decimal GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM { get; set; }

		public decimal GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public string CONG_THUC { get; set; }

		public string GHI_CHU { get; set; }

		public decimal GIA_TRI_QUYET_TOAN { get; set; }

	}
	public class GRID_GIAI_NGAN
	{
		public decimal ID { get; set; }

		public string NOI_DUNG { get; set; }

		public decimal SO_TIEN_NT { get; set; }

		public decimal SO_TIEN_TTCDVH { get; set; }

		public decimal TONG { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal STT { get; set; }

		public decimal REPORT_LEVEL { get; set; }

		public decimal KE_HOACH_CHI { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

		public decimal ID_CHA { get; set; }

		public string MA_CHUONG { get; set; }

		public string MA_LOAI { get; set; }

		public string MA_KHOAN { get; set; }

		public string MA_NGUON_NSNN { get; set; }

	}
	public class GRID_GIAO_KH
	{
		public decimal ID { get; set; }

		public string NOI_DUNG { get; set; }

		public decimal NTCT { get; set; }

		public decimal QUY { get; set; }

		public decimal NS { get; set; }

		public decimal TONG { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string STT { get; set; }

		public string REPORT_LEVEL { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

		public decimal ID_CHA { get; set; }

		public decimal So_KM { get; set; }

	}
	public class GRID_GIAO_VON
	{
		public decimal ID { get; set; }

		public string NOI_DUNG { get; set; }

		public decimal NTCT { get; set; }

		public decimal QUY { get; set; }

		public decimal NS { get; set; }

		public decimal TONG { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string STT { get; set; }

		public string REPORT_LEVEL { get; set; }

		public decimal KE_HOACH_CHI { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

		public decimal ID_CHA { get; set; }

	}
	public class HT_BACKUP_HISTORY
	{
		public decimal ID { get; set; }

		public string NGUOI_BACKUP { get; set; }

		public DateTime NGAY_BACKUP { get; set; }

		public string NOI_LUU { get; set; }

		public string TEN_FILE { get; set; }

		public string GhI_CHU { get; set; }

	}
	public class HT_BUSINESS_PROCESS_LOCK
	{
		public string LOCK_NAME { get; set; }

		public DateTime GRANTED_SYS_DATETIME { get; set; }

	}
	public class HT_CHUC_NANG
	{
		public decimal ID { get; set; }

		public string TEN_CHUC_NANG { get; set; }

		public string URL_FORM { get; set; }

		public string TRANG_THAI_YN { get; set; }

		public decimal VI_TRI { get; set; }

		public decimal CHUC_NANG_PARENT_ID { get; set; }

		public string HIEN_THI_YN { get; set; }

	}
	public class HT_LICH_SU_QLDT
	{
		public decimal ID { get; set; }

		public decimal ID_NGUOI_SU_DUNG { get; set; }

		public DateTime THOI_GIAN { get; set; }

		public string HANH_DONG { get; set; }

	}
	public class HT_LOG_LOGIN
	{
		public decimal ID { get; set; }

		public string USER_LOGIN { get; set; }

		public DateTime DATETIME_LOGIN { get; set; }

		public string STATUS_LOGIN { get; set; }

	}
	public class HT_NGUOI_SU_DUNG
	{
		public decimal ID { get; set; }

		public string TEN_TRUY_CAP { get; set; }

		public string TEN { get; set; }

		public string MAT_KHAU { get; set; }

		public DateTime NGAY_TAO { get; set; }

		public string NGUOI_TAO { get; set; }

		public string TRANG_THAI { get; set; }

		public string BUILT_IN_YN { get; set; }

		public decimal ID_USER_GROUP { get; set; }

		public decimal ID_TRAINING_PROJECT { get; set; }

	}
	public class HT_QUAN_HE_SU_DUNG_DU_LIEU
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_USER_GROUP { get; set; }

	}
	public class HT_QUYEN_GROUP
	{
		public decimal ID { get; set; }

		public decimal ID_USER_GROUP { get; set; }

		public decimal ID_QUYEN { get; set; }

	}
	public class HT_QUYEN_USER
	{
		public decimal ID { get; set; }

		public decimal ID_USER { get; set; }

		public decimal ID_QUYEN { get; set; }

	}
	public class HT_THAM_SO_HE_THONG
	{
		public decimal ID { get; set; }

		public string LOAI_THAM_SO { get; set; }

		public string MA_THAM_SO { get; set; }

		public string PHAN_HE { get; set; }

		public string GHI_CHU { get; set; }

		public string KIEU_DU_LIEU { get; set; }

		public string GIA_TRI { get; set; }

		public string CO_THE_NULL_YN { get; set; }

	}
	public class HT_USER_GROUP
	{
		public decimal ID { get; set; }

		public string USER_GROUP_NAME { get; set; }

		public string DESCRIPTION { get; set; }

		public decimal ID_DON_VI { get; set; }

	}
	public class RPT_BAO_CAO_GIAO_VON
	{
		public decimal ID { get; set; }

		public char STT { get; set; }

		public string NHIEM_VU_CHI { get; set; }

		public decimal TONG_KH { get; set; }

		public decimal TONG_VON_QBT { get; set; }

		public decimal TONG_VON_NS { get; set; }

		public decimal TONG_VON { get; set; }

		public decimal KH_NAM_TRUOC_CHUYEN_SANG { get; set; }

		public string REPORT_LEVEL { get; set; }

		public decimal ID_CHA { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

	}
	public class RPT_BAO_CAO_GIAO_VON_THEO_QD
	{
		public decimal ID { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public decimal ID_DU_AN_CONG_TRINH { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_LOAI { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public string TEN_CLKM { get; set; }

		public string TEN_DU_AN_CONG_TRINH { get; set; }

		public decimal TONG_TIEN_DACT_THEO_QD { get; set; }

		public decimal ID_CHA { get; set; }

		public string REPORT_LEVEL { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

	}
	public class RPT_BC_TINH_HINH_GIAI_NGAN
	{
		public decimal ID { get; set; }

		public string STT { get; set; }

		public string NOI_DUNG { get; set; }

		public decimal KH_QBT { get; set; }

		public decimal KH_NS { get; set; }

		public decimal KH_NAM_TRUOC_CHUYEN_SANG { get; set; }

		public decimal KH_TONG { get; set; }

		public decimal DN_QBT_TRONG_THANG { get; set; }

		public decimal DN_QBT_LUY_KE { get; set; }

		public decimal DN_QBT_TONG { get; set; }

		public decimal DN_NS_TRONG_THANG { get; set; }

		public decimal DN_NS_LUY_KE { get; set; }

		public decimal DN_NS_TONG { get; set; }

		public decimal DTT_QBT_TRONG_THANG { get; set; }

		public decimal DTT_QBT_LUY_KE { get; set; }

		public decimal DTT_QBT_TONG { get; set; }

		public decimal DTT_NS_TRONG_THANG { get; set; }

		public decimal DTT_NS_LUY_KE { get; set; }

		public decimal DTT_NS_TONG { get; set; }

		public decimal CN_QBT { get; set; }

		public decimal CN_NS { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string REPORT_LEVEL { get; set; }

		public decimal ID_CHA { get; set; }

		public decimal ID_REPORTED_USER { get; set; }

		public decimal GIA_TRI_THUC_HIEN { get; set; }

		public decimal SO_CHUA_GN { get; set; }

		public decimal TONG_SO_KM { get; set; }

		public decimal ID_CONG_TRINH_KHOAN { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public decimal ID_DU_AN_MUC_TIEU_MUC { get; set; }

		public string CONG_TRINH_KHOAN_YN { get; set; }

		public decimal KH_NTCS_QBT { get; set; }

		public decimal KH_NTCS_NS { get; set; }

		public decimal GIA_TRI_THUC_HIEN_QBT { get; set; }

		public decimal GIA_TRI_THUC_HIEN_NS { get; set; }

	}
	public class TP_DU_TOAN_THU_CHI_PHI_PHA_PHA
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string MA_SO_PARENT { get; set; }

		public string TT { get; set; }

		public string HANG_MUC { get; set; }

		public decimal KINH_PHI_GIAO_KH { get; set; }

		public decimal KLTH_QUY_I { get; set; }

		public decimal KLTH_QUY_II { get; set; }

		public decimal KLTH_QUY_III { get; set; }

		public decimal KLTH_QUY_IV { get; set; }

		public string GHI_CHU_GIAO_KH { get; set; }

		public string GHI_CHU_QUY_I { get; set; }

		public string GHI_CHU_QUY_II { get; set; }

		public string GHI_CHU_QUY_III { get; set; }

		public string GHI_CHU_QUY_IV { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public string CONG_THUC { get; set; }

		public bool IS_FIX { get; set; }

	}
	public class TP_PL01
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string CHI_TIEU { get; set; }

		public string MA_SO_PARENT { get; set; }

		public decimal CAP { get; set; }

		public decimal SO_BAO_CAO { get; set; }

		public decimal SO_XET_DUYET { get; set; }

		public string CONG_THUC { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

	}
	public class TP_PL02
	{
		public decimal ID { get; set; }

		public string MA_LOAI { get; set; }

		public string MA_KHOAN { get; set; }

		public string MA_MUC { get; set; }

		public string MA_TIEU_MUC { get; set; }

		public string NOI_DUNG_CHI { get; set; }

		public string NHOM { get; set; }

		public string LOAI { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public decimal SO_BAO_CAO { get; set; }

		public decimal SO_PHE_DUYET { get; set; }

		public decimal SO_XET_DUYET { get; set; }

	}
	public class TP_PL03
	{
		public decimal ID { get; set; }

		public string MA_SO { get; set; }

		public string TT { get; set; }

		public string NOI_DUNG { get; set; }

		public string MA_SO_PARENT { get; set; }

		public decimal CAP { get; set; }

		public decimal SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC { get; set; }

		public decimal SO_KIEN_NGHI_CO_QUAN_TAI_CHINH { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal NAM { get; set; }

		public decimal SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC { get; set; }

		public decimal SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH { get; set; }

	}
	public class UT_SEQUENCES
	{
		public string SEQ_NAME { get; set; }

		public decimal SEQ_VALUE { get; set; }

	}
	public class V_CM_DM_TU_DIEN
	{
		public decimal ID { get; set; }

		public string MA_TU_DIEN { get; set; }

		public decimal ID_LOAI_TU_DIEN { get; set; }

		public string TEN_NGAN { get; set; }

		public string TEN { get; set; }

		public string GHI_CHU { get; set; }

		public string MA_LOAI { get; set; }

		public string TEN_LOAI { get; set; }

	}
	public class V_DM_CHUONG_LOAI_KHOAN_MUC
	{
		public decimal ID { get; set; }

		public decimal ID_CHA { get; set; }

		public string TEN_CLKM { get; set; }

		public string MA_SO { get; set; }

		public decimal ID_LOAI { get; set; }

		public string TEN_LOAI { get; set; }

	}
	public class V_DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC
	{
		public decimal ID { get; set; }

		public string TEN { get; set; }

		public string MA_SO { get; set; }

		public decimal ID_KTM { get; set; }

		public string TEN_KTM { get; set; }

		public string MA_SO_KTM { get; set; }

		public string TEN_LOAI_CLM { get; set; }

		public string TEN_LOAI_KTM { get; set; }

		public decimal ID_LOAI_CLM { get; set; }

		public decimal ID_LOAI_KTM { get; set; }

	}
	public class V_DM_DON_VI
	{
		public decimal ID { get; set; }

		public string MA_DON_VI { get; set; }

		public string TEN_DON_VI { get; set; }

		public string LOAI_HINH_DON_VI { get; set; }

		public decimal ID_LOAI_DON_VI { get; set; }

		public decimal ID_DON_VI_CAP_TREN { get; set; }

		public decimal STT { get; set; }

		public decimal LEVEL_MODE { get; set; }

		public decimal ID_DON_VI_CHU_QUAN { get; set; }

		public string TEN_DON_VI_CHU_QUAN { get; set; }

		public decimal ID_BO_TINH { get; set; }

		public string TEN_DON_VI_BO_TINH { get; set; }

	}
	public class V_DM_GIAI_NGAN
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public string SO_UNC { get; set; }

		public string IS_NGUON_NS_YN { get; set; }

		public string MA_DVQHNS { get; set; }

		public string MA_CTMT_DA_HTCT { get; set; }

		public string NT_TEN_DON_VI { get; set; }

		public string NT_MA_SO_THUE { get; set; }

		public string NT_MA_NDKT { get; set; }

		public string NT_MA_CHUONG { get; set; }

		public string NT_CQ_QL_THU { get; set; }

		public string NT_MA_CQ_THU { get; set; }

		public string NT_KBNN_HACH_TOAN_KHOAN_THU { get; set; }

		public string NT_SO_TIEN_NOP_THUE { get; set; }

		public string TTDVH_DON_VI_NHAN_TIEN { get; set; }

		public string TTDVH_MA_DVQHNS { get; set; }

		public string TTDVH_DIA_CHI { get; set; }

		public string TTDVH_TAI_KHOAN { get; set; }

		public string TTDVH_MA_CTMT_DA_VA_HTCT { get; set; }

		public string TTDVH_KHO_BAC { get; set; }

		public string TTDVH_SO_TIEN { get; set; }

		public string THUC_CHI_YN { get; set; }

		public string TAM_UNG_YN { get; set; }

		public string UNG_TRUOC_DU_DK_THANH_TOAN_YN { get; set; }

		public string UNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN { get; set; }

		public string CHUYEN_KHOAN_YN { get; set; }

		public string TIEN_MAT_YN { get; set; }

		public string MA_CAP_NS { get; set; }

		public string SO_CKC_HDK { get; set; }

		public string SO_CKC_HDTH { get; set; }

		public string TEN_CTMT_DA { get; set; }

		public string NGUOI_NHAN_TIEN_CMND_SO { get; set; }

		public string NGUOI_NHAN_TIEN_CAP_NGAY { get; set; }

		public string NGUOI_NHAN_TIEN_NOI_CAP { get; set; }

		public string MA_TKKT { get; set; }

		public decimal SO_TIEN_NOP_THUE { get; set; }

		public string NOI_DUNG_CHI { get; set; }

		public string GHI_CHU { get; set; }

		public decimal SO_TIEN_TT_CHO_DV_HUONG { get; set; }

		public string DISPLAY { get; set; }

		public string MA_CHUONG { get; set; }

		public string MA_LOAI { get; set; }

		public string MA_KHOAN { get; set; }

		public string TEN_DU_AN { get; set; }

		public decimal TONG { get; set; }

	}
	public class V_DM_QUYET_DINH
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public string TEN_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_DON_VI { get; set; }

		public decimal QBT { get; set; }

		public decimal NS { get; set; }

		public decimal TONG { get; set; }

	}
	public class V_DM_QUYET_DINH_KH
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public string TEN_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_DON_VI { get; set; }

		public decimal QBT { get; set; }

		public decimal NS { get; set; }

		public decimal TONG { get; set; }

	}
	public class V_DM_QUYET_DINH_SO_DON_VI_NHAP_DU_LIEU
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

		public int SO_DON_VI { get; set; }

	}
	public class V_GD_CHI_TIET_GIAO_VON
	{
		public string SO_QUYET_DINH { get; set; }

		public decimal SO_TIEN_QUY_BT { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public string TEN { get; set; }

	}
	public class V_GD_GIAI_NGAN_QBT
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_NOP_THUE { get; set; }

		public decimal ID_GIAI_NGAN { get; set; }

		public string NOI_DUNG_CHI { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal SO_TIEN_TT_CHO_DV_HUONG { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public string MA_NGUON_NSNN { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public string SO_UNC { get; set; }

		public string IS_NGUON_NS_YN { get; set; }

		public string MA_DVQHNS { get; set; }

		public string MA_CTMT_DA_HTCT { get; set; }

		public string NT_TEN_DON_VI { get; set; }

		public string NT_MA_SO_THUE { get; set; }

		public string NT_MA_NDKT { get; set; }

		public string NT_MA_CHUONG { get; set; }

		public string NT_CQ_QL_THU { get; set; }

		public string NT_MA_CQ_THU { get; set; }

		public string NT_KBNN_HACH_TOAN_KHOAN_THU { get; set; }

		public string NT_SO_TIEN_NOP_THUE { get; set; }

		public string TTDVH_DON_VI_NHAN_TIEN { get; set; }

		public string TTDVH_MA_DVQHNS { get; set; }

		public string TTDVH_DIA_CHI { get; set; }

		public string TTDVH_TAI_KHOAN { get; set; }

		public string TTDVH_MA_CTMT_DA_VA_HTCT { get; set; }

		public string TTDVH_KHO_BAC { get; set; }

		public string TTDVH_SO_TIEN { get; set; }

		public string TEN_CONG_TRINH { get; set; }

		public string TEN_DU_AN { get; set; }

		public string MA_CHUONG { get; set; }

		public string MA_LOAI { get; set; }

		public string MA_KHOAN { get; set; }

		public string MA_TKKT { get; set; }

	}
	public class V_GD_GIAO_KH_QBT
	{
		public decimal ID { get; set; }

		public decimal ID_QUYET_DINH { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_QUY_BT { get; set; }

		public decimal SO_TIEN_NS { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal SO_TIEN_NAM_TRUOC_CHUYEN_SANG { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public decimal ID_DU_AN { get; set; }

		public string TU_CHU_YN { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public decimal TONG_MUC_DAU_TU { get; set; }

		public decimal THOI_GIAN_THUC_HIEN { get; set; }

		public string LOAI_CONG_TRINH { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_CONG_TRINH { get; set; }

		public string TEN_DU_AN { get; set; }

		public string MA_LOAI_KHOAN { get; set; }

		public string TEN_NGAN { get; set; }

		public string STT { get; set; }

	}
	public class V_GD_GIAO_VON_QBT
	{
		public decimal ID { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_QUYET_DINH { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal SO_TIEN_QUY_BT { get; set; }

		public decimal SO_TIEN_NS { get; set; }

		public decimal ID_CHUONG { get; set; }

		public decimal ID_KHOAN { get; set; }

		public decimal ID_MUC { get; set; }

		public string GHI_CHU { get; set; }

		public decimal ID_TIEU_MUC { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public string SO_QUYET_DINH { get; set; }

		public string NOI_DUNG { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_LOAI_QUYET_DINH { get; set; }

		public decimal ID_LOAI_QUYET_DINH_GIAO { get; set; }

		public string TEN_CONG_TRINH { get; set; }

		public string TEN_DU_AN { get; set; }

	}
	public class V_GD_KHOI_LUONG_QBT
	{
		public decimal ID { get; set; }

		public DateTime NGAY_THANG { get; set; }

		public decimal ID_DON_VI { get; set; }

		public decimal ID_LOAI_NHIEM_VU { get; set; }

		public decimal ID_CONG_TRINH { get; set; }

		public decimal ID_DU_AN { get; set; }

		public decimal SO_TIEN_DA_NGHIEM_THU { get; set; }

		public decimal SO_TIEN_CHUA_GIAI_NGAN { get; set; }

		public string GHI_CHU_1 { get; set; }

		public string GHI_CHU_2 { get; set; }

		public string GHI_CHU_3 { get; set; }

		public string GHI_CHU_4 { get; set; }

		public decimal SO_TIEN_DA_NGHIEM_THU_NS { get; set; }

		public string TEN_CONG_TRINH { get; set; }

		public string TEN_DU_AN { get; set; }

	}
	public class V_HT_NGUOI_SU_DUNG
	{
		public string TEN_DON_VI { get; set; }

		public string MA_DON_VI { get; set; }

		public string TEN_TRUY_CAP { get; set; }

		public string MAT_KHAU { get; set; }

	}

	
	#endregion
}