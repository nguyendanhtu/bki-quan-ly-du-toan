//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SQLDataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class DM_DON_VI
    {
        public DM_DON_VI()
        {
            this.DM_CONG_TRINH_DU_AN_GOI_THAU = new HashSet<DM_CONG_TRINH_DU_AN_GOI_THAU>();
            this.DM_DON_VI1 = new HashSet<DM_DON_VI>();
            this.DM_THONG_TIN_DON_VI = new HashSet<DM_THONG_TIN_DON_VI>();
            this.DM_GIAI_NGAN = new HashSet<DM_GIAI_NGAN>();
            this.GD_CHI_TIET_GIAO_KH = new HashSet<GD_CHI_TIET_GIAO_KH>();
            this.GD_CHI_TIET_GIAO_VON = new HashSet<GD_CHI_TIET_GIAO_VON>();
            this.GD_KHOI_LUONG = new HashSet<GD_KHOI_LUONG>();
            this.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI = new HashSet<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI>();
            this.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN = new HashSet<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN>();
            this.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH = new HashSet<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH>();
            this.DM_QUYET_DINH = new HashSet<DM_QUYET_DINH>();
            this.GD_CHI_TIET_GIAI_NGAN = new HashSet<GD_CHI_TIET_GIAI_NGAN>();
            this.HT_QUAN_HE_SU_DUNG_DU_LIEU = new HashSet<HT_QUAN_HE_SU_DUNG_DU_LIEU>();
            this.HT_USER_GROUP = new HashSet<HT_USER_GROUP>();
            this.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN = new HashSet<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN>();
            this.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN = new HashSet<GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN>();
            this.GD_DU_TOAN_THU_CHI_PHI_PHA = new HashSet<GD_DU_TOAN_THU_CHI_PHI_PHA>();
        }
    
        public decimal ID { get; set; }
        public string MA_DON_VI { get; set; }
        public string TEN_DON_VI { get; set; }
        public string LOAI_HINH_DON_VI { get; set; }
        public decimal ID_LOAI_DON_VI { get; set; }
        public Nullable<decimal> ID_DON_VI_CAP_TREN { get; set; }
        public Nullable<decimal> STT { get; set; }
        public Nullable<decimal> LEVEL_MODE { get; set; }
    
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN { get; set; }
        public virtual ICollection<DM_CONG_TRINH_DU_AN_GOI_THAU> DM_CONG_TRINH_DU_AN_GOI_THAU { get; set; }
        public virtual ICollection<DM_DON_VI> DM_DON_VI1 { get; set; }
        public virtual DM_DON_VI DM_DON_VI2 { get; set; }
        public virtual ICollection<DM_THONG_TIN_DON_VI> DM_THONG_TIN_DON_VI { get; set; }
        public virtual ICollection<DM_GIAI_NGAN> DM_GIAI_NGAN { get; set; }
        public virtual ICollection<GD_CHI_TIET_GIAO_KH> GD_CHI_TIET_GIAO_KH { get; set; }
        public virtual ICollection<GD_CHI_TIET_GIAO_VON> GD_CHI_TIET_GIAO_VON { get; set; }
        public virtual ICollection<GD_KHOI_LUONG> GD_KHOI_LUONG { get; set; }
        public virtual ICollection<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI { get; set; }
        public virtual ICollection<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN { get; set; }
        public virtual ICollection<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH { get; set; }
        public virtual ICollection<DM_QUYET_DINH> DM_QUYET_DINH { get; set; }
        public virtual ICollection<GD_CHI_TIET_GIAI_NGAN> GD_CHI_TIET_GIAI_NGAN { get; set; }
        public virtual ICollection<HT_QUAN_HE_SU_DUNG_DU_LIEU> HT_QUAN_HE_SU_DUNG_DU_LIEU { get; set; }
        public virtual ICollection<HT_USER_GROUP> HT_USER_GROUP { get; set; }
        public virtual ICollection<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN { get; set; }
        public virtual ICollection<GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN> GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN { get; set; }
        public virtual ICollection<GD_DU_TOAN_THU_CHI_PHI_PHA> GD_DU_TOAN_THU_CHI_PHI_PHA { get; set; }
    }
}
