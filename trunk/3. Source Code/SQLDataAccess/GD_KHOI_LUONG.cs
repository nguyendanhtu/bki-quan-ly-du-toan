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
    
    public partial class GD_KHOI_LUONG
    {
        public decimal ID { get; set; }
        public Nullable<System.DateTime> NGAY_THANG { get; set; }
        public Nullable<decimal> ID_DON_VI { get; set; }
        public decimal ID_LOAI_NHIEM_VU { get; set; }
        public Nullable<decimal> ID_CONG_TRINH { get; set; }
        public Nullable<decimal> ID_DU_AN { get; set; }
        public Nullable<decimal> SO_TIEN_DA_NGHIEM_THU { get; set; }
        public Nullable<decimal> SO_TIEN_CHUA_GIAI_NGAN { get; set; }
        public string GHI_CHU_1 { get; set; }
        public string GHI_CHU_2 { get; set; }
        public string GHI_CHU_3 { get; set; }
        public string GHI_CHU_4 { get; set; }
        public Nullable<decimal> SO_TIEN_DA_NGHIEM_THU_NS { get; set; }
    
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN { get; set; }
        public virtual DM_CONG_TRINH_DU_AN_GOI_THAU DM_CONG_TRINH_DU_AN_GOI_THAU { get; set; }
        public virtual DM_CONG_TRINH_DU_AN_GOI_THAU DM_CONG_TRINH_DU_AN_GOI_THAU1 { get; set; }
        public virtual DM_DON_VI DM_DON_VI { get; set; }
    }
}
