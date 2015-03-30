﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;

namespace QuanLyDuToan.BaoCaoQT {
    public partial class BC_PL02_Tong_hop_tinh_hinh_kinh_phi_quyet_toan : System.Web.UI.Page {

        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_PL01;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_cuc;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_so;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_ban;
        #endregion

        #region Data Structure
        public class ItemPL01 {
            public string MaSo;
            public string ChiTieu;
        }
        public class ItemBaoCaoDonVi {
            public decimal? ID_DON_VI;
            public string TEN_DON_VI;
        }
        #endregion

        #region Private Method
        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                    lst_PL01 = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                            .Where(x => x.NAM == 2014)
                                            .ToList();

                    lst_don_vi = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                            .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                            .Distinct()
                                            .ToList();

                    if (lst_PL01.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("CỤC")).ToList().Count > 0) {
                        lst_cuc = lst_PL01
                            .Where(x => x.ID_DON_VI == lst_PL01[0].ID_DON_VI)
                            .Select(x => new GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI {
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
                                CONG_THUC = x.CONG_THUC
                                ,
                                NAM = x.NAM
                                ,
                                CHI_TIEU = x.CHI_TIEU
                                ,
                                SO_XET_DUYET = lst_PL01.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC") && y.MA_SO == x.MA_SO).Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                                ,
                                SO_BAO_CAO = lst_PL01.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC") && y.MA_SO == x.MA_SO).Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                                ,DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "Cục QLĐB", ID = 10000 }
                            })
                            .ToList();
                       
                    }

                    if (lst_PL01.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("SỞ")).ToList().Count > 0) {
                        lst_so = lst_PL01
                         .Where(x => x.ID_DON_VI == lst_PL01[0].ID_DON_VI)
                         .Select(x => new GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI {
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
                             CONG_THUC = x.CONG_THUC
                             ,
                             NAM = x.NAM
                             ,
                             CHI_TIEU = x.CHI_TIEU
                                 ,
                             SO_XET_DUYET = lst_PL01.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && y.MA_SO == x.MA_SO).Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                             ,
                             SO_BAO_CAO = lst_PL01
                                 .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ")&&y.MA_SO==x.MA_SO)
                             .Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                             ,
                             DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "SỞ GTVT", ID = 20000 }
                         })
                         .ToList();
                        
                    }

                    if (lst_PL01.Where(x => x.DM_DON_VI.TEN_DON_VI.ToString().ToUpper().Contains("BAN")).ToList().Count > 0) {
                        lst_ban = lst_PL01
                         .Where(x => x.ID_DON_VI == lst_PL01[0].ID_DON_VI)
                         .Select(x => new GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI {
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
                             CONG_THUC = x.CONG_THUC
                             ,
                             NAM = x.NAM
                             ,
                             CHI_TIEU = x.CHI_TIEU
                             ,
                             SO_XET_DUYET = lst_PL01
                                 .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN") && y.MA_SO == x.MA_SO)
                                 .Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                             ,
                             SO_BAO_CAO = lst_PL01
                                  .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN") && y.MA_SO == x.MA_SO)
                             .Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                             ,
                             DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "CỤC QLĐB", ID = 30000 }

                         })
                         .ToList();
                        
                    }
                    if (lst_cuc!=null) {
                        lst_PL01.AddRange(lst_cuc);
                        lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 10000, TEN_DON_VI = "CỤC QLĐB" });
                    }
                    if (lst_so!=null) {
                        lst_PL01.AddRange(lst_so);
                        lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 20000, TEN_DON_VI = "SỞ GTVT" });
                    }
                    if (lst_ban != null) {
                        lst_PL01.AddRange(lst_ban);
                        lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 30000, TEN_DON_VI = "BAN QLDA" });
                    }
                    
                    
                }

            }
        }

        #endregion

    }
}