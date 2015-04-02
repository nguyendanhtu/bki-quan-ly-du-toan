using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
namespace QuanLyDuToan.BaoCaoQT {
    public partial class BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh : System.Web.UI.Page {
        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_PL03;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_cuc;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_so;
        public List<GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH> lst_ban;
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
        #endregion

        #region Private Method

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
                     SO_KIEN_NGHI_CO_QUAN_NHA_NUOC = lst_PL03
                          .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN") && y.MA_SO == x.MA_SO)
                     .Select(y => y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC).ToList().Sum()
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
                     SO_KIEN_NGHI_CO_QUAN_NHA_NUOC = lst_PL03
                          .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && y.MA_SO == x.MA_SO)
                     .Select(y => y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC).ToList().Sum()
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
                        SO_KIEN_NGHI_CO_QUAN_NHA_NUOC = lst_PL03
                             .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC") && y.MA_SO == x.MA_SO)
                        .Select(y => y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC == null ? 0 : y.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC).ToList().Sum()
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
                using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                    lst_PL03 = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
                                            .Where(x => x.NAM == 2014)
                                            .ToList();

                    lst_don_vi = db.GD_PL03_THUC_HIEN_XU_LY_KIEN_NGHI_CUA_KIEM_TOAN_THANH_TRA_TAI_CHINH
                                            .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                            .Distinct()
                                            .ToList();
                    //add list cuc
                    add_list_cuc();

                    //add list so
                    add_list_so();

                    //add list ban
                    add_list_ban();

                    //add list grid
                    add_list_grid();

                }

            }
        }

        #endregion
    }
}