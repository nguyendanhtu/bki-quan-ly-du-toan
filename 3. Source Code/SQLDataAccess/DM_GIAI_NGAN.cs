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
    
    public partial class DM_GIAI_NGAN
    {
        public DM_GIAI_NGAN()
        {
            this.GD_CHI_TIET_GIAI_NGAN = new HashSet<GD_CHI_TIET_GIAI_NGAN>();
        }
    
        public decimal ID { get; set; }
        public decimal ID_DON_VI { get; set; }
        public System.DateTime NGAY_THANG { get; set; }
        public string SO_UNC { get; set; }
        public string IS_NGUON_NS_YN { get; set; }
        public string MA_DVQHNS { get; set; }
        public string MA_CTMT_DA_HTCT { get; set; }
        public string NT_TEN_DON_VI { get; set; }
        public string NT_MA_SO_THUE { get; set; }
        public string NT_MA_NDKT { get; set; }
        public string NT_MA_CHUONG { get; set; }
        public string NT_CQ_QL_THU { get; set; }
        public string NT_MA_CQ_THU { get; set; }
        public string NT_KBNN_HACH_TOAN_KHOAN_THU { get; set; }
        public string NT_SO_TIEN_NOP_THUE { get; set; }
        public string TTDVH_DON_VI_NHAN_TIEN { get; set; }
        public string TTDVH_MA_DVQHNS { get; set; }
        public string TTDVH_DIA_CHI { get; set; }
        public string TTDVH_TAI_KHOAN { get; set; }
        public string TTDVH_MA_CTMT_DA_VA_HTCT { get; set; }
        public string TTDVH_KHO_BAC { get; set; }
        public string TTDVH_SO_TIEN { get; set; }
        public string THUC_CHI_YN { get; set; }
        public string TAM_UNG_YN { get; set; }
        public string UNG_TRUOC_DU_DK_THANH_TOAN_YN { get; set; }
        public string UNG_TRUOC_CHUA_DU_DK_THANH_TOAN_YN { get; set; }
        public string CHUYEN_KHOAN_YN { get; set; }
        public string TIEN_MAT_YN { get; set; }
        public string MA_CAP_NS { get; set; }
        public string SO_CKC_HDK { get; set; }
        public string SO_CKC_HDTH { get; set; }
        public string TEN_CTMT_DA { get; set; }
        public string NGUOI_NHAN_TIEN_CMND_SO { get; set; }
        public string NGUOI_NHAN_TIEN_CAP_NGAY { get; set; }
        public string NGUOI_NHAN_TIEN_NOI_CAP { get; set; }
        public string MA_TKKT { get; set; }
    
        public virtual DM_DON_VI DM_DON_VI { get; set; }
        public virtual ICollection<GD_CHI_TIET_GIAI_NGAN> GD_CHI_TIET_GIAI_NGAN { get; set; }
    }
}
