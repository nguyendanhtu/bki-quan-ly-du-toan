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
    
    public partial class GD_CHI_TIET_GIAO_VON
    {
        public decimal ID { get; set; }
        public decimal ID_DON_VI { get; set; }
        public decimal ID_QUYET_DINH { get; set; }
        public Nullable<decimal> ID_CONG_TRINH { get; set; }
        public Nullable<decimal> SO_TIEN_QUY_BT { get; set; }
        public Nullable<decimal> SO_TIEN_NS { get; set; }
        public Nullable<decimal> ID_CHUONG { get; set; }
        public Nullable<decimal> ID_KHOAN { get; set; }
        public Nullable<decimal> ID_MUC { get; set; }
        public string GHI_CHU { get; set; }
        public Nullable<decimal> ID_TIEU_MUC { get; set; }
        public Nullable<decimal> ID_DU_AN { get; set; }
        public Nullable<decimal> ID_LOAI_NHIEM_VU { get; set; }
        public string GHI_CHU_1 { get; set; }
        public string GHI_CHU_2 { get; set; }
        public string GHI_CHU_3 { get; set; }
        public string GHI_CHU_4 { get; set; }
    
        public virtual DM_CHUONG_LOAI_KHOAN_MUC DM_CHUONG_LOAI_KHOAN_MUC { get; set; }
        public virtual DM_CHUONG_LOAI_KHOAN_MUC DM_CHUONG_LOAI_KHOAN_MUC1 { get; set; }
        public virtual DM_CHUONG_LOAI_KHOAN_MUC DM_CHUONG_LOAI_KHOAN_MUC2 { get; set; }
        public virtual DM_CHUONG_LOAI_KHOAN_MUC DM_CHUONG_LOAI_KHOAN_MUC3 { get; set; }
        public virtual DM_CONG_TRINH_DU_AN_GOI_THAU DM_CONG_TRINH_DU_AN_GOI_THAU { get; set; }
        public virtual DM_CONG_TRINH_DU_AN_GOI_THAU DM_CONG_TRINH_DU_AN_GOI_THAU1 { get; set; }
        public virtual DM_DON_VI DM_DON_VI { get; set; }
        public virtual DM_QUYET_DINH DM_QUYET_DINH { get; set; }
    }
}