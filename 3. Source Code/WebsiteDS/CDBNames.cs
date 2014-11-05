using System;
using System.Collections.Generic;
using System.Text;


namespace WebDS.CDBNames
{
    public enum e_loai_tu_dien
    {
        PHAN_QUYEN = 1
       ,
        DIA_DIEM_QUAN_LY = 2
            ,
        DON_VI_QUAN_LY_CHINH = 3
            ,
        LEVEL_GIANG_VIEN = 4
            ,
        LOAI_HOP_DONG = 5
            ,
        NGANH_DAO_TAO = 6
            ,
        DON_VI_TINH = 7
            ,
        TRANG_THAI_HOP_DONG_KHUNG = 8
            ,
        TRANG_THAI_GIANG_VIEN = 9
            ,
        MA_TAN_SUAT = 10
            ,
        HOC_HAM = 11
            ,
        HOC_VI = 12
            ,
        HINH_THUC_CONG_TAC = 13
            ,
        TRANG_THAI_DOT_THANH_TOAN = 14
            ,
        TRANG_THAI_THANH_TOAN = 15
            ,
        TRANG_THAI_TT_HOP_DONG = 17
            ,
        VAI_TRO_GV = 18
            ,
        LOAI_SU_KIEN = 19
            ,
        TRANG_THAI_SU_KIEN = 20
            ,
        TRANG_THAI_CONG_VIEC_GV = 21
            ,
        TRANG_THAI_HO_SO_GV = 23
            ,
        TRANG_THAI_SU_KIEN_GV = 24
            ,
        LOAI_HO_SO_GV_CM = 25
            ,
        LOAI_HO_SO_GV_HD = 26
            , DV_TO_CHUC_SK = 27
    }

    public class DM_LOC_BAO_CAO
    {
        public const string ID = "ID";
        public const string TEN_BAO_CAO = "TEN_BAO_CAO";
        public const string DUONG_DAN = "DUONG_DAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_LOAI_BAO_CAO = "ID_LOAI_BAO_CAO";
        public const string GHI_CHU = "GHI_CHU";
    }

    public class V_DM_DAT
    {
        public const string TEN_DV_SU_DUNG = "TEN_DV_SU_DUNG";
        public const string TEN_DV_CHU_QUAN = "TEN_DV_CHU_QUAN";
        public const string TEN_DV_BO_TINH = "TEN_DV_BO_TINH";
        public const string TEN_TRANG_THAI = "TEN_TRANG_THAI";
        public const string TEN_TINH_TRANG = "TEN_TINH_TRANG";
        public const string ID = "ID";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string DIA_CHI = "DIA_CHI";
        public const string DT_KHUON_VIEN = "DT_KHUON_VIEN";
        public const string DT_TRU_SO_LAM_VIEC = "DT_TRU_SO_LAM_VIEC";
        public const string DT_CO_SO_HOAT_DONG_SU_NGHIEP = "DT_CO_SO_HOAT_DONG_SU_NGHIEP";
        public const string DT_LAM_NHA_O = "DT_LAM_NHA_O";
        public const string DT_CHO_THUE = "DT_CHO_THUE";
        public const string DT_BO_TRONG = "DT_BO_TRONG";
        public const string DT_BI_LAN_CHIEM = "DT_BI_LAN_CHIEM";
        public const string DT_SU_DUNG_MUC_DICH_KHAC = "DT_SU_DUNG_MUC_DICH_KHAC";
        public const string GT_THEO_SO_KE_TOAN = "GT_THEO_SO_KE_TOAN";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string SO_NAM_DA_SU_DUNG = "SO_NAM_DA_SU_DUNG";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }

    public class V_DM_OTO
    {
        public const string ID = "ID";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string NHAN_HIEU = "NHAN_HIEU";
        public const string NUOC_SAN_XUAT = "NUOC_SAN_XUAT";
        public const string BIEN_KIEM_SOAT = "BIEN_KIEM_SOAT";
        public const string SO_CHO_NGOI = "SO_CHO_NGOI";
        public const string CONG_SUAT_XE = "CONG_SUAT_XE";
        public const string CHUC_DANH_SU_DUNG = "CHUC_DANH_SU_DUNG";
        public const string NGUON_GOC_XE = "NGUON_GOC_XE";
        public const string NAM_SAN_XUAT = "NAM_SAN_XUAT";
        public const string NAM_SU_DUNG = "NAM_SU_DUNG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QLNN = "QLNN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string KHONG_KINH_DOANH = "KHONG_KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string TEN_LOAI_TAI_SAN = "TEN_LOAI_TAI_SAN";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }
    public class V_DM_TAI_SAN_KHAC
    {
        public const string ID = "ID";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string KY_HIEU = "KY_HIEU";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string NUOC_SAN_XUAT = "NUOC_SAN_XUAT";
        public const string NAM_SAN_XUAT = "NAM_SAN_XUAT";
        public const string NAM_SU_DUNG = "NAM_SU_DUNG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QLNN = "QLNN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string KHONG_KINH_DOANH = "KHONG_KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string TEN_LOAI_TAI_SAN = "TEN_LOAI_TAI_SAN";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }
    public class V_DM_NHA
    {
        public const string ID = "ID";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_DAT = "ID_DAT";
        public const string CAP_HANG = "CAP_HANG";
        public const string SO_TANG = "SO_TANG";
        public const string NGAY_THANG_NAM_SU_DUNG = "NGAY_THANG_NAM_SU_DUNG";
        public const string NAM_XAY_DUNG = "NAM_XAY_DUNG";
        public const string DT_XAY_DUNG = "DT_XAY_DUNG";
        public const string TONG_DT_SAN_XD = "TONG_DT_SAN_XD";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string TRU_SO_LAM_VIEC = "TRU_SO_LAM_VIEC";
        public const string CO_SO_HDSN = "CO_SO_HDSN";
        public const string LAM_NHA_O = "LAM_NHA_O";
        public const string CHO_THUE = "CHO_THUE";
        public const string BO_TRONG = "BO_TRONG";
        public const string BI_LAN_CHIEM = "BI_LAN_CHIEM";
        public const string KHAC = "KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string ID_DON_VI_DAU_TU = "ID_DON_VI_DAU_TU";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }

    public class LOAI_TU_DIEN
    {
        public const string PHAN_QUYEN = "PHAN_QUYEN";
        public const string DIA_DIEM_QUAN_LY = "DIA_DIEM_QUAN_LY";
        public const string DON_VI_QUAN_LY_CHINH = "DON_VI_QUAN_LY_CHINH";
        public const string LEVEL_GIANG_VIEN = "LEVEL_GIANG_VIEN";
        public const string LOAI_HOP_DONG = "LOAI_HOP_DONG";
        public const string TRANG_THAI_HOP_DONG_KHUNG = "TRANG_THAI_HOP_DONG_KHUNG";
        public const string TRANG_THAI_GIANG_VIEN = "TRANG_THAI_GIANG_VIEN";
        public const string HINH_THUC_CONG_TAC = "HINH_THUC_CONG_TAC";
        public const string TRANG_THAI_DOT_THANH_TOAN = "TRANG_THAI_DOT_THANH_TOAN";
        public const string TRANG_THAI_THANH_TOAN = "TRANG_THAI_THANH_TOAN";
        public const string TRANG_THAI_SU_KIEN = "TRANG_THAI_SU_KIEN";
        public const string TRANG_THAI_CONG_VIEC_GV = "TRANG_THAI_CONG_VIEC_GV";
        public const string TRANG_THAI_SU_KIEN_GV = "TRANG_THAI_SU_KIEN_GV";

    }

    public enum e_user_group
    {
        TESTER = 1
        ,
        PM_TD = 2
            ,
        TRUONG_NHOM_PO = 3
            ,
        PO = 4
            ,
        ADMIN = 5
            , GIANG_VIEN = 6
    }
    public class DM_DON_VI
    {
        public const string ID = "ID";
        public const string MA_DON_VI = "MA_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string ID_LOAI_DON_VI = "ID_LOAI_DON_VI";
        public const string ID_DON_VI_CAP_TREN = "ID_DON_VI_CAP_TREN";
        public const string STT = "STT";
        public const string LEVEL_MODE = "LEVEL_MODE";
    }

    public class DM_LOAI_TAI_SAN
    {
        public const string ID = "ID";
        public const string TEN_LOAI_TAI_SAN = "TEN_LOAI_TAI_SAN";
        public const string ID_LOAI_TAI_SAN_PARENT = "ID_LOAI_TAI_SAN_PARENT";
        public const string ID_PHAN_LOAI = "ID_PHAN_LOAI";
    }

    public class DM_OTO
    {
        public const string ID = "ID";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string NHAN_HIEU = "NHAN_HIEU";
        public const string NUOC_SAN_XUAT = "NUOC_SAN_XUAT";
        public const string BIEN_KIEM_SOAT = "BIEN_KIEM_SOAT";
        public const string SO_CHO_NGOI = "SO_CHO_NGOI";
        public const string CONG_SUAT_XE = "CONG_SUAT_XE";
        public const string CHUC_DANH_SU_DUNG = "CHUC_DANH_SU_DUNG";
        public const string NGUON_GOC_XE = "NGUON_GOC_XE";
        public const string NAM_SAN_XUAT = "NAM_SAN_XUAT";
        public const string NAM_SU_DUNG = "NAM_SU_DUNG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QLNN = "QLNN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string KHONG_KINH_DOANH = "KHONG_KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }


    public class SU_KIEN
    {
        public const string ID = "ID";
        public const string ID_LOAI_SU_KIEN = "ID_LOAI_SU_KIEN";
        public const string TEN_SU_KIEN = "TEN_SU_KIEN";
        public const string NGAY_DIEN_RA = "NGAY_DIEN_RA";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string MO_TA = "MO_TA";
    }


    public class CM_DM_TU_DIEN
    {
        public const string ID = "ID";
        public const string MA_TU_DIEN = "MA_TU_DIEN";
        public const string TEN_NGAN = "TEN_NGAN";
        public const string TEN = "TEN";
        public const string ID_LOAI_TU_DIEN = "ID_LOAI_TU_DIEN";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class CM_DM_LOAI_TD
    {
        public const string ID = "ID";
        public const string MA_LOAI = "MA_LOAI";
        public const string TEN_LOAI = "TEN_LOAI";
    }

    public class HT_NGUOI_SU_DUNG
    {
        public const string ID = "ID";
        public const string TEN_TRUY_CAP = "TEN_TRUY_CAP";
        public const string TEN = "TEN";
        public const string MAT_KHAU = "MAT_KHAU";
        public const string NGAY_TAO = "NGAY_TAO";
        public const string NGUOI_TAO = "NGUOI_TAO";
        public const string TRANG_THAI = "TRANG_THAI";
        public const string BUILT_IN_YN = "BUILT_IN_YN";
        public const string ID_USER_GROUP = "ID_USER_GROUP";
        public const string ID_TRAINING_PROJECT = "ID_TRAINING_PROJECT";
    }

    public class HT_CHUC_NANG
    {
        public const string ID = "ID";
        public const string TEN_CHUC_NANG = "TEN_CHUC_NANG";
        public const string URL_FORM = "URL_FORM";
        public const string TRANG_THAI_YN = "TRANG_THAI_YN";
        public const string VI_TRI = "VI_TRI";
        public const string CHUC_NANG_PARENT_ID = "CHUC_NANG_PARENT_ID";
        public const string HIEN_THI_YN = "HIEN_THI_YN";
    }
    public class HT_QUYEN_GROUP
    {
        public const string ID = "ID";
        public const string ID_USER_GROUP = "ID_USER_GROUP";
        public const string ID_QUYEN = "ID_QUYEN";
    }
    public class HT_USER_GROUP
    {
        public const string ID = "ID";
        public const string USER_GROUP_NAME = "USER_GROUP_NAME";
        public const string DESCRIPTION = "DESCRIPTION";
    }

    public class V_HT_USER_DV_QUAN_LY
    {
        public const string ID = "ID";
        public const string ID_NGUOI_SU_DUNG = "ID_NGUOI_SU_DUNG";
        public const string TEN_NGUOI_SU_DUNG = "TEN_NGUOI_SU_DUNG";
        public const string ID_DV_QUAN_LY = "ID_DV_QUAN_LY";
        public const string TEN_DV_QUAN_LY = "TEN_DV_QUAN_LY";
    }
    /// <summary>
    /// 
    /// </summary>
    public class CM_COMPANY_INFO
    {
        public const string ID = "ID";
        public const string COMPANY_NAME = "COMPANY_NAME";
        public const string COMPANY_ADDRESS = "COMPANY_ADDRESS";
    }

    public class DM_DAT
    {
        public const string ID = "ID";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string DIA_CHI = "DIA_CHI";
        public const string DT_KHUON_VIEN = "DT_KHUON_VIEN";
        public const string DT_TRU_SO_LAM_VIEC = "DT_TRU_SO_LAM_VIEC";
        public const string DT_CO_SO_HOAT_DONG_SU_NGHIEP = "DT_CO_SO_HOAT_DONG_SU_NGHIEP";
        public const string DT_LAM_NHA_O = "DT_LAM_NHA_O";
        public const string DT_CHO_THUE = "DT_CHO_THUE";
        public const string DT_BO_TRONG = "DT_BO_TRONG";
        public const string DT_BI_LAN_CHIEM = "DT_BI_LAN_CHIEM";
        public const string DT_SU_DUNG_MUC_DICH_KHAC = "DT_SU_DUNG_MUC_DICH_KHAC";
        public const string GT_THEO_SO_KE_TOAN = "GT_THEO_SO_KE_TOAN";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string SO_NAM_DA_SU_DUNG = "SO_NAM_DA_SU_DUNG";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }


    public class DM_NHA
    {
        public const string ID = "ID";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_DAT = "ID_DAT";
        public const string CAP_HANG = "CAP_HANG";
        public const string SO_TANG = "SO_TANG";
        public const string NGAY_THANG_NAM_SU_DUNG = "NGAY_THANG_NAM_SU_DUNG";
        public const string NAM_XAY_DUNG = "NAM_XAY_DUNG";
        public const string DT_XAY_DUNG = "DT_XAY_DUNG";
        public const string TONG_DT_SAN_XD = "TONG_DT_SAN_XD";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string TRU_SO_LAM_VIEC = "TRU_SO_LAM_VIEC";
        public const string CO_SO_HDSN = "CO_SO_HDSN";
        public const string LAM_NHA_O = "LAM_NHA_O";
        public const string CHO_THUE = "CHO_THUE";
        public const string BO_TRONG = "BO_TRONG";
        public const string BI_LAN_CHIEM = "BI_LAN_CHIEM";
        public const string KHAC = "KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string ID_DON_VI_DAU_TU = "ID_DON_VI_DAU_TU";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }

    public class DM_TAI_SAN_KHAC
    {
        public const string ID = "ID";
        public const string MA_TAI_SAN = "MA_TAI_SAN";
        public const string KY_HIEU = "KY_HIEU";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string NUOC_SAN_XUAT = "NUOC_SAN_XUAT";
        public const string NAM_SAN_XUAT = "NAM_SAN_XUAT";
        public const string NAM_SU_DUNG = "NAM_SU_DUNG";
        public const string SO_NAM_DA_SU_DUNG = "SO_NAM_DA_SU_DUNG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QLNN = "QLNN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string NGAY_CAP_NHAT_CUOI = "NGAY_CAP_NHAT_CUOI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI_SU_DUNG = "ID_DON_VI_SU_DUNG";
        public const string ID_DON_VI_CHU_QUAN = "ID_DON_VI_CHU_QUAN";
        public const string ID_TINH_TRANG = "ID_TINH_TRANG";
    }
    public class GD_DE_NGHI
    {
        public const string ID = "ID";
        public const string MA_PHIEU = "MA_PHIEU";
        public const string ID_LOAI_DE_NGHI = "ID_LOAI_DE_NGHI";
        public const string NGAY_LAP = "NGAY_LAP";
        public const string ID_TRANG_THAI = "ID_TRANG_THAI";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string GHI_CHU = "GHI_CHU";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string NGAY_DUYET = "NGAY_DUYET";
    }
    public class GD_DE_NGHI_TRANG_CAP_DETAILS
    {
        public const string ID = "ID";
        public const string MA_PHIEU = "MA_PHIEU";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string SO_LUONG = "SO_LUONG";
        public const string ID_DON_VI_TINH = "ID_DON_VI_TINH";
        public const string ID_PHUONG_THUC = "ID_PHUONG_THUC";
        public const string DU_TOAN = "DU_TOAN";
        public const string DU_TOAN_DUOC_DUYET = "DU_TOAN_DUOC_DUYET";
        public const string MO_TA = "MO_TA";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class GD_DE_XUAT_XU_LI_DETAILS
    {
        public const string ID = "ID";
        public const string MA_PHIEU = "MA_PHIEU";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_TAI_SAN = "ID_TAI_SAN";
        public const string NOI_DUNG = "NOI_DUNG";
    }
    public class GD_KHAU_HAO
    {
        public const string ID = "ID";
        public const string MA_PHIEU = "MA_PHIEU";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string NGAY_LAP = "NGAY_LAP";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_TAI_SAN = "ID_TAI_SAN";
        public const string GIA_TRI_KHAU_HAO = "GIA_TRI_KHAU_HAO";
        public const string NGAY_DUYET = "NGAY_DUYET";
    }
    public class GD_TANG_GIAM_TAI_SAN
    {
        public const string ID = "ID";
        public const string MA_PHIEU = "MA_PHIEU";
        public const string ID_NGUOI_LAP = "ID_NGUOI_LAP";
        public const string ID_NGUOI_DUYET = "ID_NGUOI_DUYET";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string NGAY_LAP = "NGAY_LAP";
        public const string NGAY_MUA = "NGAY_MUA";
        public const string NGAY_DUA_VAO_SU_DUNG = "NGAY_DUA_VAO_SU_DUNG";
        public const string NGAY_BAT_DAU_TINH_HAO_MON = "NGAY_BAT_DAU_TINH_HAO_MON";
        public const string ID_LOAI_TAI_SAN = "ID_LOAI_TAI_SAN";
        public const string ID_TAI_SAN = "ID_TAI_SAN";
        public const string TANG_GIA_TRI_YN = "TANG_GIA_TRI_YN";
        public const string GIA_TRI_HIEN_TAI = "GIA_TRI_HIEN_TAI";
        public const string GIA_TRI_TANG_GIAM = "GIA_TRI_TANG_GIAM";
        public const string ID_LY_DO_TANG_GIAM = "ID_LY_DO_TANG_GIAM";
        public const string NGAY_DUYET = "NGAY_DUYET";
    }

    public class RPT_TONG_HOP_HIEN_TRANG
    {
        public const string ID = "ID";
        public const string USER_NAME = "USER_NAME";
        public const string STT = "STT";
        public const string LEVEL_MODE = "LEVEL_MODE";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string SO_LUONG = "SO_LUONG";
        public const string TONG_DIEN_TICH = "TONG_DIEN_TICH";
        public const string DT_TRU_SO_LAM_VIEC = "DT_TRU_SO_LAM_VIEC";
        public const string DT_CO_SO_HDSN = "DT_CO_SO_HDSN";
        public const string DT_LAM_NHA_O = "DT_LAM_NHA_O";
        public const string DT_CHO_THUE = "DT_CHO_THUE";
        public const string DT_BO_TRONG = "DT_BO_TRONG";
        public const string DT_BI_LAN_CHIEM = "DT_BI_LAN_CHIEM";
        public const string DT_KHAC = "DT_KHAC";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
    }
    public class RPT_TONG_HOP_HIEN_TRANG_TSK
    {
        public const string ID = "ID";
        public const string USER_NAME = "USER_NAME";
        public const string STT = "STT";
        public const string LEVEL_MODE = "LEVEL_MODE";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string SO_LUONG = "SO_LUONG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QUAN_LY_NN = "QUAN_LY_NN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string KHONG_KINH_DOANH = "KHONG_KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
    }
    public class RPT_TONG_HOP_HIEN_TRANG_OTO
    {
        public const string ID = "ID";
        public const string USER_NAME = "USER_NAME";
        public const string STT = "STT";
        public const string LEVEL_MODE = "LEVEL_MODE";
        public const string TEN_TAI_SAN = "TEN_TAI_SAN";
        public const string SO_LUONG = "SO_LUONG";
        public const string NGUON_NS = "NGUON_NS";
        public const string NGUON_KHAC = "NGUON_KHAC";
        public const string GIA_TRI_CON_LAI = "GIA_TRI_CON_LAI";
        public const string QUAN_LY_NN = "QUAN_LY_NN";
        public const string KINH_DOANH = "KINH_DOANH";
        public const string KHONG_KINH_DOANH = "KHONG_KINH_DOANH";
        public const string HD_KHAC = "HD_KHAC";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
    }
   public class RPT_TANG_GIAM_TAI_SAN
    {
        public const string ID = "ID";
        public const string STT = "STT";
        public const string LEVEL_MODE = "LEVEL_MODE";
        public const string USER_NAME = "USER_NAME";
        public const string TAI_SAN = "TAI_SAN";
        public const string SO_DAU_KY_SO_LUONG = "SO_DAU_KY_SO_LUONG";
        public const string SO_DAU_KY_DIEN_TICH = "SO_DAU_KY_DIEN_TICH";
        public const string SO_DAU_KY_NGUYEN_GIA = "SO_DAU_KY_NGUYEN_GIA";
        public const string SO_TANG_TRONG_KY_SO_LUONG = "SO_TANG_TRONG_KY_SO_LUONG";
        public const string SO_TANG_TRONG_KY_DIEN_TICH = "SO_TANG_TRONG_KY_DIEN_TICH";
        public const string SO_TANG_TRONG_KY_NGUYEN_GIA = "SO_TANG_TRONG_KY_NGUYEN_GIA";
        public const string SO_GIAM_TRONG_KY_SO_LUONG = "SO_GIAM_TRONG_KY_SO_LUONG";
        public const string SO_GIAM_TRONG_KY_DIEN_TICH = "SO_GIAM_TRONG_KY_DIEN_TICH";
        public const string SO_GIAM_TRONG_KY_NGUYEN_GIA = "SO_GIAM_TRONG_KY_NGUYEN_GIA";
        public const string SO_CUOI_KY_SO_LUONG = "SO_CUOI_KY_SO_LUONG";
        public const string SO_CUOI_KY_DIEN_TICH = "SO_CUOI_KY_DIEN_TICH";
        public const string SO_CUOI_KY_NGUYEN_GIA = "SO_CUOI_KY_NGUYEN_GIA";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string TEN_DON_VI = "TEN_DON_VI";
    }

}

