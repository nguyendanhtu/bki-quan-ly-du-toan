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
    
    public partial class HT_NGUOI_SU_DUNG
    {
        public HT_NGUOI_SU_DUNG()
        {
            this.DM_DAT = new HashSet<DM_DAT>();
            this.DM_DAT1 = new HashSet<DM_DAT>();
            this.DM_DAT_HISTORY = new HashSet<DM_DAT_HISTORY>();
            this.DM_DAT_HISTORY1 = new HashSet<DM_DAT_HISTORY>();
            this.DM_NHA = new HashSet<DM_NHA>();
            this.DM_NHA1 = new HashSet<DM_NHA>();
            this.DM_NHA_HISTORY = new HashSet<DM_NHA_HISTORY>();
            this.DM_NHA_HISTORY1 = new HashSet<DM_NHA_HISTORY>();
            this.DM_OTO = new HashSet<DM_OTO>();
            this.DM_OTO1 = new HashSet<DM_OTO>();
            this.DM_OTO_HISTORY = new HashSet<DM_OTO_HISTORY>();
            this.DM_OTO_HISTORY1 = new HashSet<DM_OTO_HISTORY>();
            this.DM_TAI_SAN_KHAC = new HashSet<DM_TAI_SAN_KHAC>();
            this.DM_TAI_SAN_KHAC1 = new HashSet<DM_TAI_SAN_KHAC>();
            this.DM_TAI_SAN_KHAC_HISTORY = new HashSet<DM_TAI_SAN_KHAC_HISTORY>();
            this.DM_TAI_SAN_KHAC_HISTORY1 = new HashSet<DM_TAI_SAN_KHAC_HISTORY>();
            this.GD_KHAU_HAO = new HashSet<GD_KHAU_HAO>();
            this.GD_KHAU_HAO1 = new HashSet<GD_KHAU_HAO>();
            this.GD_TANG_GIAM_TAI_SAN = new HashSet<GD_TANG_GIAM_TAI_SAN>();
            this.GD_TANG_GIAM_TAI_SAN1 = new HashSet<GD_TANG_GIAM_TAI_SAN>();
            this.HT_QUYEN_USER = new HashSet<HT_QUYEN_USER>();
        }
    
        public decimal ID { get; set; }
        public string TEN_TRUY_CAP { get; set; }
        public string TEN { get; set; }
        public string MAT_KHAU { get; set; }
        public System.DateTime NGAY_TAO { get; set; }
        public string NGUOI_TAO { get; set; }
        public string TRANG_THAI { get; set; }
        public string BUILT_IN_YN { get; set; }
        public Nullable<decimal> ID_USER_GROUP { get; set; }
        public Nullable<decimal> ID_TRAINING_PROJECT { get; set; }
    
        public virtual ICollection<DM_DAT> DM_DAT { get; set; }
        public virtual ICollection<DM_DAT> DM_DAT1 { get; set; }
        public virtual ICollection<DM_DAT_HISTORY> DM_DAT_HISTORY { get; set; }
        public virtual ICollection<DM_DAT_HISTORY> DM_DAT_HISTORY1 { get; set; }
        public virtual ICollection<DM_NHA> DM_NHA { get; set; }
        public virtual ICollection<DM_NHA> DM_NHA1 { get; set; }
        public virtual ICollection<DM_NHA_HISTORY> DM_NHA_HISTORY { get; set; }
        public virtual ICollection<DM_NHA_HISTORY> DM_NHA_HISTORY1 { get; set; }
        public virtual ICollection<DM_OTO> DM_OTO { get; set; }
        public virtual ICollection<DM_OTO> DM_OTO1 { get; set; }
        public virtual ICollection<DM_OTO_HISTORY> DM_OTO_HISTORY { get; set; }
        public virtual ICollection<DM_OTO_HISTORY> DM_OTO_HISTORY1 { get; set; }
        public virtual ICollection<DM_TAI_SAN_KHAC> DM_TAI_SAN_KHAC { get; set; }
        public virtual ICollection<DM_TAI_SAN_KHAC> DM_TAI_SAN_KHAC1 { get; set; }
        public virtual ICollection<DM_TAI_SAN_KHAC_HISTORY> DM_TAI_SAN_KHAC_HISTORY { get; set; }
        public virtual ICollection<DM_TAI_SAN_KHAC_HISTORY> DM_TAI_SAN_KHAC_HISTORY1 { get; set; }
        public virtual ICollection<GD_KHAU_HAO> GD_KHAU_HAO { get; set; }
        public virtual ICollection<GD_KHAU_HAO> GD_KHAU_HAO1 { get; set; }
        public virtual ICollection<GD_TANG_GIAM_TAI_SAN> GD_TANG_GIAM_TAI_SAN { get; set; }
        public virtual ICollection<GD_TANG_GIAM_TAI_SAN> GD_TANG_GIAM_TAI_SAN1 { get; set; }
        public virtual HT_USER_GROUP HT_USER_GROUP { get; set; }
        public virtual ICollection<HT_QUYEN_USER> HT_QUYEN_USER { get; set; }
    }
}
