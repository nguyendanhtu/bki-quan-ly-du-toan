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
    
    public partial class DM_THONG_TIN_DON_VI
    {
        public decimal ID { get; set; }
        public Nullable<decimal> ID_DON_VI { get; set; }
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
    
        public virtual DM_DON_VI DM_DON_VI { get; set; }
    }
}