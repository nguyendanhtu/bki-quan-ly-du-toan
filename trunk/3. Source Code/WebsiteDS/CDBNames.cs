using System;
using System.Collections.Generic;
using System.Text;


namespace WebDS.CDBNames
{
    #region Quan ly du toan
    public class GD_QUYET_DINH
    {
        public const string ID = "ID";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string SO_QUYET_DINH = "SO_QUYET_DINH";
        public const string NOI_DUNG = "NOI_DUNG";
        public const string NGAY_THANG = "NGAY_THANG";
        public const string ID_LOAI_QUYET_DINH = "ID_LOAI_QUYET_DINH";
    }

    public class DM_DU_AN_CONG_TRINH
    {
        public const string ID = "ID";
        public const string TEN_DU_AN_CONG_TRINH = "TEN_DU_AN_CONG_TRINH";
        public const string ID_LOAI_DU_AN_CONG_TRINH = "ID_LOAI_DU_AN_CONG_TRINH";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class DM_LOAI_DON_VI
    {
        public const string ID = "ID";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN = "IS_DON_VI_SU_NGHIEP_TU_CHU_TAI_CHINH_YN";
    }
    public class DM_UY_NHIEM_CHI
    {
        public const string ID = "ID";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string NGAY_THANG = "NGAY_THANG";
        public const string SO_UNC = "SO_UNC";
        public const string NOI_DUNG = "NOI_DUNG";
        public const string GHI_CHU = "GHI_CHU";
    }
    public class GD_UY_NHIEM_CHI
    {
        public const string ID = "ID";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string ID_DU_AN_CONG_TRINH = "ID_DU_AN_CONG_TRINH";
        public const string SO_TIEN = "SO_TIEN";
        public const string IS_NGUON_NS_YN = "IS_NGUON_NS_YN";
        public const string ID_UNC = "ID_UNC";
        public const string NOI_DUNG = "NOI_DUNG";
        public const string GHI_CHU = "GHI_CHU";
    }

    public class GD_GIAO_KH
    {
        public const string ID = "ID";
        public const string ID_QUYET_DINH = "ID_QUYET_DINH";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string ID_DU_AN_CONG_TRINH = "ID_DU_AN_CONG_TRINH";
        public const string SO_TIEN = "SO_TIEN";
        public const string IS_NGUON_NS_YN = "IS_NGUON_NS_YN";
        public const string ID_LOAI_GIAO_DICH = "ID_LOAI_GIAO_DICH";
    }

    public class GD_GIAO_VON
    {
        public const string ID = "ID";
        public const string ID_DON_VI = "ID_DON_VI";
        public const string ID_QUYET_DINH = "ID_QUYET_DINH";
        public const string ID_DU_AN_CONG_TRINH = "ID_DU_AN_CONG_TRINH";
        public const string SO_TIEN = "SO_TIEN";
        public const string IS_NGUON_NS_YN = "IS_NGUON_NS_YN";
        public const string ID_LOAI_GIAO_DICH = "ID_LOAI_GIAO_DICH";
    }

    public class HT_LICH_SU_QLDT
    {
        public const string ID = "ID";
        public const string ID_NGUOI_SU_DUNG = "ID_NGUOI_SU_DUNG";
        public const string THOI_GIAN = "THOI_GIAN";
        public const string HANH_DONG = "HANH_DONG";
    }
    


    #endregion
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

    public class LOAI_TU_DIEN
    {
        public const string PHAN_QUYEN = "PHAN_QUYEN";


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

    /// <summary>
    /// 
    /// </summary>
    public class CM_COMPANY_INFO
    {
        public const string ID = "ID";
        public const string COMPANY_NAME = "COMPANY_NAME";
        public const string COMPANY_ADDRESS = "COMPANY_ADDRESS";
    }

}
