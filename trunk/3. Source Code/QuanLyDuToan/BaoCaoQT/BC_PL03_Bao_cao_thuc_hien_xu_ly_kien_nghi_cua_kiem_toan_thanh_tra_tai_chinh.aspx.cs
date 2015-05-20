using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using IP.Core.IPCommon;
namespace QuanLyDuToan.BaoCaoQT {
    public partial class BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh : System.Web.UI.Page {
        #region Public Function
        public string genClassCSS(string ip_str_ten_don_vi, string ip_str_para) {
            string result = "";
            string v_str_loai_don_vi = ip_str_ten_don_vi.Split(' ')[0].ToUpper();
            if (v_str_loai_don_vi=="SỞ") {
                result += "so_";
            }
            if (v_str_loai_don_vi == "CỤC" || v_str_loai_don_vi == "CHI") {
                result += "cuc_";
            }
            if (v_str_loai_don_vi == "BAN") {
                result += "ban_";
            }

            return result + ip_str_para;
        }
        #endregion

        #region Data Member
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_PL03;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<decimal?> lst_nam;
        public decimal m_dc_nam;
        public decimal width = 1150;
        public string class_cuc;
        public decimal colspan;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_cuc;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_so;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_ban;
        public string[] LoaiDonVi = { LoaiDonvi.SO, LoaiDonvi.CUC, LoaiDonvi.BAN };
        #endregion

        #region Data Structure
        public class ItemPL03 {
            public string MaSo;
            public string NoiDung;
            public string TT;
        }
        public class ItemBaoCaoDonVi {
            public decimal? ID_DON_VI;
            public string TEN_DON_VI;
        }
        public class LoaiDonvi {
            public const string SO = "Sở GTVT";
            public const string CUC = "Cục QLĐB";
            public const string BAN = "Ban QLDA";
        }
        #endregion

        #region Private Method
        private void load_data() {
            m_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            BKI_QLDTEntities db = new BKI_QLDTEntities();
            lst_PL03 = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
                                    .Where(x => x.NAM == m_dc_nam)
                                    .ToList();

            lst_don_vi = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
                                    .Where(x => x.NAM == m_dc_nam)
                                    .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                    .Distinct()
                                    .ToList();
            tinh_width();
        }

        private void tinh_width()
        {
                decimal count_cuc = lst_don_vi.Where(x => x.TEN_DON_VI.ToUpper().Contains("CỤC QLDB")).ToList().Count;
                width = width + count_cuc * 300 + 300;
                decimal count_chi_cuc = lst_don_vi.Where(x => x.TEN_DON_VI.ToUpper().Contains("CHI CỤC")).ToList().Count;
                width = width + count_chi_cuc * 300;
                decimal count_so = lst_don_vi.Where(x => x.TEN_DON_VI.ToUpper().Contains("SỞ GTVT")).ToList().Count;
                width = width + count_so * 100 + 300;
                decimal count_ban = lst_don_vi.Where(x => x.TEN_DON_VI.ToUpper().Contains("BAN QLDA")).ToList().Count;
                width = width + count_ban * 100 + 300;
        }
        private void load_ddl_chon_nam() {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                lst_nam = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                            .Select(x => x.NAM)
                                            .Distinct()
                                            .OrderByDescending(x => x)
                                            .ToList();
            }
            m_ddl_chon_nam.DataSource = lst_nam;
            m_ddl_chon_nam.DataBind();
        }

        private void set_initial_form_load() {
            load_ddl_chon_nam();
        }

        private void add_list_ban() {
            if (lst_PL03.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("BAN")).ToList().Count > 0) {
                lst_ban = lst_PL03
                 .Where(x => x.ID_DON_VI == lst_PL03[0].ID_DON_VI)
                 .Select(x => new GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH {
                     ID = 30000
                     ,
                     ID_DON_VI = 30000
                     ,
                     MA_SO = x.MA_SO
                     ,
                     MA_SO_PARENT = x.MA_SO_PARENT
                     ,
                     CAP = x.CAP
                     ,
                     NOI_DUNG = x.NOI_DUNG
                     ,
                     NAM = x.NAM
                     ,
                     TT = x.TT
                     ,
                     SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC = lst_PL03
                         .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN") && y.MA_SO == x.MA_SO)
                         .Select(y => y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).ToList().Sum()
                     ,
                     SO_KIEN_NGHI_CO_QUAN_TAI_CHINH = lst_PL03
                          .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN") && y.MA_SO == x.MA_SO)
                     .Select(y => y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).ToList().Sum()
                     ,
                     DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "BAN QLDA", ID = 30000 }

                 })
                 .ToList();

            }
        }

        private void add_list_so() {
            if (lst_PL03.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("SỞ")).ToList().Count > 0) {
                lst_so = lst_PL03
                 .Where(x => x.ID_DON_VI == lst_PL03[0].ID_DON_VI)
                 .Select(x => new GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH {
                     ID = 20000
                     ,
                     ID_DON_VI = 20000
                     ,
                     MA_SO = x.MA_SO
                     ,
                     MA_SO_PARENT = x.MA_SO_PARENT
                     ,
                     CAP = x.CAP
                     ,
                     NOI_DUNG = x.NOI_DUNG
                     ,
                     NAM = x.NAM
                     ,
                     TT = x.TT
                     ,
                     SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC = lst_PL03
                         .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && y.MA_SO == x.MA_SO)
                         .Select(y => y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).ToList().Sum()
                     ,
                     SO_KIEN_NGHI_CO_QUAN_TAI_CHINH = lst_PL03
                          .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && y.MA_SO == x.MA_SO)
                     .Select(y => y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).ToList().Sum()
                     ,
                     DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "SỞ GTVT", ID = 20000 }
                 })
                 .ToList();

            }
        }

        private void add_list_cuc() {
            if (lst_PL03.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("CỤC")).ToList().Count > 0) {
                lst_cuc = lst_PL03
                    .Where(x => x.ID_DON_VI == lst_PL03[0].ID_DON_VI)
                    .Select(x => new GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH {
                        ID = 10000
                        ,
                        ID_DON_VI = 10000
                        ,
                        MA_SO = x.MA_SO
                        ,
                        MA_SO_PARENT = x.MA_SO_PARENT
                        ,
                        CAP = x.CAP
                        ,
                        NOI_DUNG = x.NOI_DUNG
                        ,
                        NAM = x.NAM
                        ,
                        TT = x.TT
                        ,
                        SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC = lst_PL03
                            .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC") && y.MA_SO == x.MA_SO)
                            .Select(y => y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).ToList().Sum()
                        ,
                        SO_KIEN_NGHI_CO_QUAN_TAI_CHINH = lst_PL03
                             .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC") && y.MA_SO == x.MA_SO)
                        .Select(y => y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).ToList().Sum()
                        ,
                        DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "Cục QLĐB", ID = 10000 }
                    })
                    .ToList();

            }
        }

        private void add_list_grid() {

            if (lst_cuc != null) {
                lst_PL03.AddRange(lst_cuc);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 10000, TEN_DON_VI = "CỤC QLĐB" });
            }
            if (lst_so != null) {
                lst_PL03.AddRange(lst_so);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 20000, TEN_DON_VI = "SỞ GTVT" });
            }
            if (lst_ban != null) {
                lst_PL03.AddRange(lst_ban);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 30000, TEN_DON_VI = "BAN QLDA" });
            }
        }
        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                set_initial_form_load();
                load_data();
            }
        }

      
        protected void m_ddl_chon_nam_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                load_data();
            }

            catch (Exception v_e) {

                CSystemLog_301.ExceptionHandle(this, v_e);
            }

        }



        #endregion
    }
}