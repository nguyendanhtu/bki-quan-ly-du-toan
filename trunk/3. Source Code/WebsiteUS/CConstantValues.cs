using System;
using System.Collections.Generic;
using System.Text;

namespace WebUS
{
    public class TEN_BAO_CAO
    {
        //BAO CAO OTO
        public const string BCDM_OTO_KE_KHAI = "BC-02 BCDM-OTO-KK.xls";
        public const string BCDM_OTO_DE_NGHI_XU_LY = "BC-05 BCDM-OTO-DNXL.xls";
        public const string BCDM_OTO_THONG_KE = "BC-01 BCDM-OTO-TK.xls";
        public const string BCDM_OTO_GIAO_CHO_DON_VI_CONG_LAP_TU_CHU_TAI_CHINH = "BC-23 BCDM-OTO-DVTCTC.xls";
        //BAO CAO TRU SO LAM VIEC
        public const string BCDM_TSLM_KE_KHAI = "BC-18 BCDM-TSLM-KK.xls";
        public const string BCDM_TSLM_DE_NGHI_XU_LY = "BC-17 BCDM-TSLM-DNXL.xls";
        public const string BCDM_TSLM_THONG_KE = "BC-19 BCDM-TSLM-TK.xls";
        public const string BCDM_TSLM_GIAO_CHO_DON_VI_CONG_LAP_TU_CHU_TAI_CHINH = "BC-04 BCDM-TSLM-DVTCTC.xls";
        //BAO CAO TAI SAN KHAC
        public const string BCDM_TSK = "BC-26 BCDM-TSK.xls";
        public const string BCDM_TSK_DE_NGHI_XU_LY = "BC-24 BCDM-TSK-DNXL.xls";
        public const string BCDM_TST_TREN500TRIEU_KK = "BC-25 BCDM-TSKTREN500TRIEU-KK.xls";
        public const string BCDM_TSK_GIAO_CHO_DON_VI_CONG_LAP_TU_CHU_TAI_CHINH = "BC-28 BCDM-TSK-DVTCTC.xls";
    }
    public class LOAI_BAO_CAO
    {
        public const string KE_KHAI = "KE_KHAI";
        public const string DE_NGHI_XU_LY = "DE_NGHI_XU_LY";
        public const string THONG_KE = "THONG_KE";
    }

    public class TRANG_THAI_OTO
    {
        public const string DE_NGHI_XU_LY = "581";
        public const string DA_THANH_LY = "582";
        public const string DA_DIEU_CHUYEN = "583";
        public const string DANG_SU_DUNG = "584";
        public const string DIEU_CHUYEN_NOI_BO = "641";
    }
    public class CONST_QLDB
    {
        public const string KHONG_CO_DU_LIEU = "";
        public const decimal ID_TAT_CA = -1;
        public const string MA_TAT_CA = "-1";
        public const string TAT_CA = "--------------------Tất cả--------------------";



        public class MA_THAM_SO_URL
        {
            public const string LOAI_BAO_CAO = "ip_str_loai_bao_cao";
            public const string LOAI_TAI_SAN_KHAC = "ip_str_loai_ts_khac";
            public const string TRANG_THAI = "ip_id_trang_thai";
            public const string ID_DVSD = "ip_id_don_vi_su_dung";
            public const string ID_NHA = "ip_id_nha";
            public const string ID_TAI_SAN_KHAC = "ip_id_tai_san_khac";
            public const string ID_DAT = "ip_id_dat";
            public const string ID_OTO = "ip_id_oto";
        }
        public class LOAI_BAO_CAO
        {
            public const string DVSD = "DVSD";
            public const string DVCQ = "DVCQ";
            public const string BLD = "BLD";
        }
        public class LOAI_TAI_SAN
        {
            public const string TREN_500 = "TSK_TREN_500";
            public const string DUOI_500 = "TSK_DUOI_500";
            public const string TAI_SAN_KHAC = "TAI_SAN_KHAC";
        }
        public class TRANG_THAI
        {
            public const string KE_KHAI = "KE_KHAI";
            public const string DE_NGHI_XU_LY = "DE_NGHI_XU_LY";
        }
    }

    public class ID_USER_GROUP
    {
        public const decimal TESTER = 1;
        public const decimal TONG_CUC = 2;
        public const decimal ADMIN = 5;

    }

    public class ID_KHAC
    {
        public const decimal DIEU_CHUYEN_NOI_BO = 640;
    }

    public class SESSION
    {
        public const string UserFullName = "UserFullName";
        public const string UserName = "UserName";
        public const string UserID = "UserID";

        public const string AccounLoginYN = "AccounLoginYN";
        public const string UserQuyen = "user_quyen";
        //public const string QuyenGV = "QuyenGV";
        public const string Allow2DeleteDataYN = "Allow2DeleteDataYN";
    }

    public class MA_LOAI_TU_DIEN
    {
        public const string DIA_DIEM_QUAN_LY = "DIA_DIEM_QUAN_LY";
        public const string DON_VI_TINH = "DON_VI_TINH";
        public const string LOAI_DON_VI = "LOAI_DON_VI";
        public const string PHAN_LOAI_TAI_SAN = "PHAN_LOAI_TAI_SAN";
        public const string PHAN_QUYEN = "PHAN_QUYEN";
        public const string TRANG_THAI_DAT = "TRANG_THAI_DAT";
        public const string TRANG_THAI_NHA = "TRANG_THAI_NHA";
        public const string TRANG_THAI_OTO = "TRANG_THAI_OTO";
        public const string TRANG_THAI_TAI_SAN_KHAC = "TRANG_THAI_TAI_SAN_KHAC";
        public const string LOAI_HINH_DON_VI = "LOAI_HINH_DON_VI";
        public const string LOAI_BAO_CAO = "LOAI_BAO_CAO";
        public const string TINH_TRANG_TAI_SAN = "TINH_TRANG_TAI_SAN";
        public const string LY_DO_TANG_GIAM_TS = "LY_DO_TANG_GIAM_TS";
    }

    public class ID_TRANG_THAI_DAT
    {
        public const decimal DE_NGHI_XU_LY = 594;
        public const decimal DA_THANH_LY = 595;
        public const decimal DA_DIEU_CHUYEN = 596;
        public const decimal DANG_SU_DUNG = 597;
        public const decimal DIEU_CHUYEN_NOI_BO = 640;
    }

    public class TRANG_THAI_DAT
    {
        public const string DE_NGHI_XU_LY = "594";
        public const string DA_THANH_LY = "595";
        public const string DA_DIEU_CHUYEN = "596";
        public const string DANG_SU_DUNG = "597";
        public const string DIEU_CHUYEN_NOI_BO = "640";
        public const string TAT_CA = "-1";
    }
    public class TRANG_THAI_TAI_SAN_KHAC
    {
        public const string DE_NGHI_XU_LY = "585";
        public const string DA_THANH_LY = "586";
        public const string DA_DIEU_CHUYEN = "587";
        public const string DANG_SU_DUNG = "588";
        public const string DIEU_CHUYEN_NOI_BO = "642";
        public const string TAT_CA = "-1";
    }
    public class ID_TRANG_THAI_NHA
    {
        public const decimal DE_NGHI_XU_LY = 577;
        public const decimal DA_THANH_LY = 578;
        public const decimal DA_DIEU_CHUYEN = 579;
        public const decimal DANG_SU_DUNG = 580;
        public const decimal DIEU_CHUYEN_NOI_BO = 640;
    }

    public class TRANG_THAI_NHA
    {
        public const string DE_NGHI_XU_LY = "577";
        public const string DA_THANH_LY = "578";
        public const string DA_DIEU_CHUYEN = "579";
        public const string DANG_SU_DUNG = "580";
        public const string DIEU_CHUYEN_NOI_BO = "641";
        public const string TAT_CA = "-1";
    }

    public class ID_TRANG_THAI_OTO
    {
        public const decimal DE_NGHI_XU_LY = 581;
        public const decimal DA_THANH_LY = 582;
        public const decimal DA_DIEU_CHUYEN = 583;
        public const decimal DANG_SU_DUNG = 584;
        public const decimal DIEU_CHUYEN_NOI_BO = 641;
    }

    public class ID_LOAI_DON_VI
    {
        public const decimal BO_TINH = 574;
        public const decimal DV_CHU_QUAN = 575;
        public const decimal DV_SU_DUNG = 576;
    }

    public class LEVEL_MODE
    {
        public const decimal BO_TINH = 3;
        public const decimal DV_CHU_QUAN = 2;
        public const decimal DV_SU_DUNG = 1;
    }
    public class ID_LOAI_TAI_SAN
    {
        public const decimal DAT = 1;
        public const decimal NHA = 2;
        public const decimal OTO = 3;
        public const decimal TAI_SAN_KHAC = 4;
        public const decimal TAI_SAN_KHAC_LON_HON_500 = 8;
        public const decimal TAI_SAN_KHAC_NHO_HON_500 = 9;
    }

    public class LOAI_USER_QUYEN
    {
        public const decimal ADMIN = 5;
        public const decimal CAN_BO_CHU_QUAN = 3;
        public const decimal CAN_BO_TONG_CUC = 4;
        public const decimal GROUP30 = 7;

    }
    public class ID_TRANG_THAI_TAI_SAN_KHAC
    {
        public const decimal DE_NGHI_XU_LY = 585;
        public const decimal DA_THANH_LY = 586;
        public const decimal DA_DIEU_CHUYEN = 587;
        public const decimal DANG_SU_DUNG = 588;
        public const decimal DIEU_CHUYEN_NOI_BO = 642;
    }

    public class ID_TINH_TRANG
    {
        public const decimal TOT = 611;
        public const decimal XAU = 612;
    }

    public class ID_LOAI_HINH_DON_VI
    {
        public const decimal CO_QUAN_NHA_NUOC_HC = 598;
        public const decimal CO_QUAN_NHA_NUOC_KHAC = 601;
        public const decimal DON_VI_SU_NGHIEP_CTCTC = 605;
        public const decimal DON_VI_SU_NGHIEP_GIAO_DUC = 599;
        public const decimal DON_VI_SU_NGHIEP_TCTC = 604;
        public const decimal TO_CHUC_CT = 600;
        public const decimal TO_CHUC_CTXH = 607;
        public const decimal TO_CHUC_CTXHNN = 608;
        public const decimal TO_CHUC_XH = 609;
        public const decimal TO_CHUC_XH_NN = 610;
    }

    public class TEN_LOAI_HINH_DON_VI
    {
        public const string CO_QUAN_NHA_NUOC_HC = "CO_QUAN_NHA_NUOC_HC";
        public const string CO_QUAN_NHA_NUOC_KHAC = "CO_QUAN_NHA_NUOC_KHAC";
        public const string DON_VI_SU_NGHIEP_CTCTC = "DON_VI_SU_NGHIEP_CTCTC";
        public const string DON_VI_SU_NGHIEP_GIAO_DUC = "DON_VI_SU_NGHIEP_GIAO_DUC";
        public const string DON_VI_SU_NGHIEP_TCTC = "DON_VI_SU_NGHIEP_TCTC";
        public const string TO_CHUC_CT = "TO_CHUC_CT";
        public const string TO_CHUC_CTXH = "TO_CHUC_CTXH";
        public const string TO_CHUC_CTXHNN = "TO_CHUC_CTXHNN";
        public const string TO_CHUC_XH = "TO_CHUC_XH";
        public const string TO_CHUC_XH_NN = "TO_CHUC_XH_NN";
    }

    public class ID_LY_DO_TANG_GIAM_TAI_SAN
    {
        public const decimal CAI_TAO_NANG_CAP = 638;
        public const decimal DIEU_CHUYEN = 636;
        public const decimal SUA_CHUA_LON = 639;
        public const decimal THANH_LY = 633;
        public const decimal TRANG_CAP_MUA_MOI = 637;
    }

    public class ID_DON_VI
    {
        public const decimal BO_TINH_KHAC = 245;
        public const decimal DON_VI_CHU_QUAN_KHAC = 248;
    }
}
