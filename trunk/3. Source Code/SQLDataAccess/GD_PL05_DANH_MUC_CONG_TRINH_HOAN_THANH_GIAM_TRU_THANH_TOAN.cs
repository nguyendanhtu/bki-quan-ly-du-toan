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
    
    public partial class GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN
    {
        public decimal ID { get; set; }
        public string STT { get; set; }
        public string TEN_LOAI_NHIEM_VU { get; set; }
        public string CONG_TRINH { get; set; }
        public string DU_AN { get; set; }
        public Nullable<decimal> ID_DON_VI { get; set; }
        public Nullable<decimal> NAM { get; set; }
        public Nullable<decimal> I_GTKLCTHTTN { get; set; }
        public Nullable<decimal> I_GTKLDQT { get; set; }
        public Nullable<decimal> II_GTKLCTHTTN { get; set; }
        public Nullable<decimal> II_GTKLDQT { get; set; }
        public Nullable<decimal> III_1_GTKLCTHTTN { get; set; }
        public Nullable<decimal> III_1_GTKLDQT { get; set; }
        public Nullable<decimal> III_2_GTKLCTHTTN { get; set; }
        public Nullable<decimal> III_2_GTKLDQT { get; set; }
        public Nullable<decimal> III_3_GTKLCTHTTN { get; set; }
        public Nullable<decimal> III_3_GTKLDQT { get; set; }
        public Nullable<decimal> IV_1_GTKLCTHTTN { get; set; }
        public Nullable<decimal> IV_1_GTKLDQT { get; set; }
        public Nullable<decimal> IV_2_GTKLCTHTTN { get; set; }
        public Nullable<decimal> IV_2_GTKLDQT { get; set; }
        public Nullable<decimal> IV_3_GTKLCTHTTN { get; set; }
        public Nullable<decimal> IV_3_GTKLDQT { get; set; }
        public Nullable<decimal> IV_4_GTKLCTHTTN { get; set; }
        public Nullable<decimal> IV_4_GTKLDQT { get; set; }
        public Nullable<decimal> V_GTKLCTHTTN { get; set; }
        public Nullable<decimal> V_GTKLDQT { get; set; }
    
        public virtual DM_DON_VI DM_DON_VI { get; set; }
    }
}