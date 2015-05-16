using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.BaoCaoQT {
    public partial class BC_PL02_Tong_hop_tinh_hinh_kinh_phi_quyet_toan : System.Web.UI.Page {

        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_PL01;
        public List<decimal?> lst_nam;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_cuc;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_so;
        public List<GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI> lst_ban;
        public decimal ini_nam = CIPConvert.ToDecimal(DateTime.Now.Year);
        //width table
        public decimal with_table = 400;
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
        private void load_data() {
            decimal v_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                lst_PL01 = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                        .Where(x => x.NAM == v_dc_nam)
                                        .ToList();
                lst_don_vi = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                        .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                        .Distinct()
                                        .ToList();
                with_table = with_table + 120 * lst_don_vi.Count;
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
        private void load_ddl_chon_nam() {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                lst_nam = db.GD_PL01_TONG_HOP_TINH_HINH_KINH_PHI_VA_QUYET_TOAN_CHI
                                            .Select(x => x.NAM)
                                            .Distinct()
                                            .OrderByDescending(x => x)
                                            .ToList();
            }
            //kiểm tra có dữ liệu trong database không
            if (lst_nam.Count < 1)
            {
                lst_nam.Add(CIPConvert.ToDecimal(DateTime.Now.Year));
            }
            m_ddl_chon_nam.DataSource = lst_nam;
            m_ddl_chon_nam.DataBind();
        }
        private void set_initial_form_load() {

            load_ddl_chon_nam();

        }
        private void add_list_ban() {
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
                     DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "BAN QLDA", ID = 30000 }

                 })
                 .ToList();
            }
        }

        private void add_list_so() {
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
                         .Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && y.MA_SO == x.MA_SO)
                     .Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                     ,
                     DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "SỞ GTVT", ID = 20000 }
                 })
                 .ToList();
            }
        }

        private void add_list_cuc() {
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
                        ,
                        DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "Cục QLĐB", ID = 10000 }
                    })
                    .ToList();
            }
        }

        private void add_list_grid() {

            if (lst_cuc != null) {
                lst_PL01.AddRange(lst_cuc);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 10000, TEN_DON_VI = "CỤC QLĐB" });
                with_table = with_table + 120;
            }
            if (lst_so != null) {
                lst_PL01.AddRange(lst_so);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 20000, TEN_DON_VI = "SỞ GTVT" });
                with_table = with_table + 120;
            }
            if (lst_ban != null) {
                lst_PL01.AddRange(lst_ban);
                lst_don_vi.Add(new ItemBaoCaoDonVi { ID_DON_VI = 30000, TEN_DON_VI = "BAN QLDA" });
                with_table = with_table + 120;
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