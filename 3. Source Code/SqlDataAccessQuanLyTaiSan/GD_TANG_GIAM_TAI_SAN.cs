//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SqlDataAccessQuanLyTaiSan
{
    using System;
    using System.Collections.Generic;
    
    public partial class GD_TANG_GIAM_TAI_SAN
    {
        public decimal ID { get; set; }
        public string MA_PHIEU { get; set; }
        public decimal ID_NGUOI_LAP { get; set; }
        public decimal ID_NGUOI_DUYET { get; set; }
        public System.DateTime NGAY_DUYET { get; set; }
        public System.DateTime NGAY_TANG_GIAM_TAI_SAN { get; set; }
        public decimal ID_LOAI_TAI_SAN { get; set; }
        public decimal ID_TAI_SAN { get; set; }
        public string TANG_GIA_TRI_TAI_SAN_YN { get; set; }
        public decimal GIA_TRI_NGUYEN_GIA_TANG_GIAM { get; set; }
        public Nullable<decimal> DIEN_TICH { get; set; }
        public decimal ID_LY_DO_TANG_GIAM { get; set; }
    
        public virtual CM_DM_TU_DIEN CM_DM_TU_DIEN { get; set; }
        public virtual DM_LOAI_TAI_SAN DM_LOAI_TAI_SAN { get; set; }
        public virtual HT_NGUOI_SU_DUNG HT_NGUOI_SU_DUNG { get; set; }
        public virtual HT_NGUOI_SU_DUNG HT_NGUOI_SU_DUNG1 { get; set; }
    }
}