using IP.Core.IPCommon;
using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebUS;

namespace QuanLyDuToan.BaoCaoQT {
    public partial class BC_PL02_Kinh_phi_da_su_dung_de_nghi_quyet_toan : System.Web.UI.Page {
        #region Public Function
        public string formatClass(string className) {
            if (string.IsNullOrEmpty(className)) return "";
            return className.ToString().Replace('.', '_');
        }
        public string formatCongThuc(string className) {
            if (string.IsNullOrEmpty(className)) return "";
            return className.ToString().Replace('|', '\0');
        }

        #endregion

        #region Data Structures
        public class ItemCLKM {
            public string MaSo;
            public string Ten;
            public decimal? IdLoai;
            public string MaSoParent;
        }
        public class ItemBaoCaoDonVi {
            public decimal? ID_DON_VI;
            public string TEN_DON_VI;
        }
        public class LoaiDonVi
        {
            public const string SO = "Sở GTVT";
            public const string CUC = "Cục QLDB";
            public const string BAN = "Ban QLDA";
        }
        #endregion

        #region Members
        public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_pl02;
        public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_cuc;
        public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_so;
        public List<GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN> lst_ban;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<ItemCLKM> lst_clkm;
        public List<string> lst_NDC;
        public List<decimal?> lst_nam;

        #endregion

        #region Private Methods
        private void load_data()
        {
            lst_NDC = new List<string>();
            lst_NDC.Add("I. Kinh phí năm quyết toán năm nay:");
            lst_NDC.Add("II. KP năm trước chưa QT, quyết toán năm nay");
            decimal v_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            //get list ...
            BKI_QLDTEntities db = new BKI_QLDTEntities();
            //Lay len bao cao PL02 nam 2014
            lst_pl02 = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
                        .Where(x => x.NAM == v_dc_nam)
                        .ToList();
            //Lay danh sach Chuong Loai khoan muc
            var lst_dm_clkm = db.DM_CHUONG_LOAI_KHOAN_MUC.ToList();
            lst_clkm = db
                .DM_CHUONG_LOAI_KHOAN_MUC
                .Select(x => new
                ItemCLKM {
                    MaSo = x.MA_SO
                             ,
                    Ten = x.TEN
                             ,
                    IdLoai = x.ID_LOAI
                             ,
                    MaSoParent = x.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
                })
                .ToList();

            //Lay danh sach don vi de gen header
            load_ten_don_vi(db, 2014);
        }
        public string genGrid() {
            string result = "";
            result += @"<table class='table table-hover' style='width:900px; margin:auto'>
						<thead style='vertical-align: middle'>
							<tr class='text-center'>
								<th rowspan='2' class='clkm'>Loại</th>
								<th rowspan='2' class='clkm'>Khoản</th>
								<th rowspan='2' class='clkm'>Mục</th>
								<th rowspan='2' class='clkm'>Tiểu mục</th>
								<th rowspan='2' style='width:200px'>Nội dung chi</th>
								<th colspan='3'>Tổng cộng</th>
							</tr>
							<tr class='text-center'>
								<th rowspan='1' colspan='1' class='so_tien'>Số báo cáo</th>
								<th rowspan='1' colspan='1'  class='so_tien'>Số phê duyệt</th>
								<th rowspan='1' colspan='1'  class='so_tien'>Chênh lệch</th>
							</tr>
							<tr>
								<td>Nhập mới</td>
								<td></td>
								<td></td>
								<td></td>
								<td><label><input type='radio' name='loai_NDC' />I. Kinh phí năm quyết toán năm nay:</label>
									<br />
									<label><input type='radio'  name='loai_NDC' />II. KP năm trước chưa QT, quyết toán năm nay</label>
									<br /></td>
							</tr>
							<tr>
								<td><input type='text' id='txt_loai' class='clkm'/></td>
								<td><input type='text' id='txt_khoan'  class='clkm'/></td>
								<td><input type='text' id='txt_muc'  class='clkm'/></td>
								<td><input type='text' id='txt_tieu_muc'  class='clkm'/></td>
								<td><span id='lbl_noi_dung_chi'  style='width:100%'></span></td>
								<td><input type='text' id='txt_so_bao_cao'  class='so_tien'/></td>
								<td><input type='text' id='txt_so_xet_duyet'  class='so_tien'/></td>
								<td><span id='lbl_chenh_lech' class='so_tien'>0</span></td>
							</tr>
						</thead>
						<tbody>";
            foreach (var loai_ndc in lst_NDC) {
                result += @"
							<tr style='font-weight:bold; font-style:italic'>
								<td></td>
								<td></td>
								<td></td>
								<td></td>
								<td>" + loai_ndc + @"</td>
								<td>" + lst_pl02
                                .Where(x => x.LOAI == loai_ndc)
                                .Select(x => (x.SO_BAO_CAO))
                                .ToList()
                                .Sum() + @"</td>
								<td>" + lst_pl02
                                .Where(x => x.LOAI == loai_ndc)
                                .Select(x => (x.SO_XET_DUYET))
                                .ToList()
                                .Sum() + @"</td>
								<td>" + lst_pl02
                                .Where(x => x.LOAI == loai_ndc)
                                .Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
                                .ToList()
                                .Sum() + @"</td>
							</tr>
							<!--Loai-->";
                foreach (var ma_loai in lst_pl02
                                        .Where(x => x.LOAI == loai_ndc)
                                        .Select(x => x.MA_LOAI)
                                        .Distinct()
                                        .ToList()) {
                    result +=
                @"<tr style='font-weight: bold'>
								<td>" + ma_loai + @"</td>
								<td></td>
								<td></td>
								<td></td>
								<td>" + lst_clkm
                                        .Where(x => x.MaSo == ma_loai)
                                        .Select(x => x.Ten)
                                        .FirstOrDefault() + @"</td>
								<td>" + lst_pl02
                                        .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                        .Select(x => x.SO_BAO_CAO)
                                        .ToList()
                                        .Sum() + @"</td>
								<td>" + lst_pl02
                                        .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                        .Select(x => x.SO_XET_DUYET)
                                        .ToList()
                                        .Sum() + @"</td>
								<td>" + lst_pl02
                                        .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                        .Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
                                        .ToList()
                                        .Sum() + @"</td>
							</tr>
						<!--Khoan-->";
                    foreach (var ma_khoan in lst_pl02
                                     .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                     .Select(x => x.MA_KHOAN)
                                     .Distinct()
                                     .ToList()) {
                        result +=
                        @"<tr style='font-weight: bold'>
							<td></td>
							<td>" + ma_khoan + @"</td>
							<td></td>
							<td></td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_khoan).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + lst_pl02
                                                    .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                                    .Select(x => x.SO_BAO_CAO)
                                                    .ToList()
                                                    .Sum() + @"</td>
							<td>" + lst_pl02
                                                    .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                                    .Select(x => x.SO_XET_DUYET)
                                                    .ToList()
                                                    .Sum() + @"</td>
							<td>" + lst_pl02
                                                    .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                                    .Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
                                                    .ToList()
                                                    .Sum() + @"</td>
						</tr>
						<!--Muc-->";
                        foreach (var ma_muc in lst_pl02
                                     .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                     .Select(x => x.MA_MUC)
                                     .Distinct()
                                     .ToList()) {
                            result +=
                            @"<tr style='font-weight: bold'>
							<td></td>
							<td></td>
							<td>" + ma_muc + @"</td>
							<td></td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_muc).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + lst_pl02
                                                            .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
                                                            .Select(x => x.SO_BAO_CAO)
                                                            .ToList()
                                                            .Sum() + @"</td>
							<td>" + lst_pl02
                                                            .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
                                                            .Select(x => x.SO_XET_DUYET)
                                                            .ToList()
                                                            .Sum() + @"</td>
							<td>" + lst_pl02
                                                            .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.MA_MUC == ma_muc && x.LOAI == loai_ndc)
                                                            .Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
                                                            .ToList()
                                                            .Sum() + @"</td>
						</tr>
						<!--Tieu Muc-->";
                            foreach (var ma_tieu_muc in lst_pl02
                             .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                             .ToList()) {
                                result +=
                        @"<tr>
							<td></td>
							<td></td>
							<td></td>
							<td>" + ma_tieu_muc.MA_TIEU_MUC + @"</td>
							<td>" + lst_clkm.Where(x => x.MaSo == ma_tieu_muc.MA_TIEU_MUC).Select(x => x.Ten).FirstOrDefault() + @"</td>
							<td>" + ma_tieu_muc.SO_BAO_CAO + @"</td>
							<td>" + ma_tieu_muc.SO_XET_DUYET + @"</td>
							<td>" + (ma_tieu_muc.SO_BAO_CAO - ma_tieu_muc.SO_XET_DUYET) + @"</td>
						</tr>";
                            }
                        }
                    }
                }
            }
            result +=
                        @"<tr style='font-weight:bold; font-style:italic'>
							<td></td>
							<td></td>
							<td></td>
							<td></td>
							<td>Tổng cộng</td>
							<td>" + lst_pl02
                                        .Select(x => (x.SO_BAO_CAO))
                                        .ToList()
                                        .Sum() + @"</td>
							<td>" + lst_pl02
                                        .Select(x => (x.SO_XET_DUYET))
                                        .ToList()
                                        .Sum() + @"</td>
							<td>" + lst_pl02
                                        .Select(x => (x.SO_BAO_CAO - x.SO_XET_DUYET))
                                        .ToList()
                                        .Sum() + @"</td>
						</tr>
					</tbody>
					<tfoot>
					</tfoot>
				</table>";
            return result;
        }
        public string getLoaiCLKM(object ip_obj_id_loai) {
            decimal v_dc_id_loai = Convert.ToDecimal(ip_obj_id_loai);
            if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.CHUONG) {
                return "C";
            }
            else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.KHOAN) {
                return "K";
            }
            else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.LOAI) {
                return "L";
            }
            else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.MUC) {
                return "M";
            }
            else if (v_dc_id_loai == ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC) {
                return "TM";
            }
            return "C";
        }
        private void load_ddl_chon_nam() { 
            using (BKI_QLDTEntities db = new BKI_QLDTEntities()) {
                lst_nam = db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
                                            .Where(x=>x.NAM!=null)
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
        private void load_ten_don_vi(BKI_QLDTEntities ip_db, decimal ip_dc_nam) {
            lst_don_vi = ip_db.GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN
                                    .Where(x => x.NAM == ip_dc_nam)
                                    .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                    .Distinct()
                                    .ToList();
        }
        private void load_lst_ban(BKI_QLDTEntities db) {
            if (lst_pl02.Where(x => x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN")).ToList().Count() > 0) {
                lst_ban = lst_pl02.Where(x => x.ID_DON_VI == lst_pl02[0].ID_DON_VI)
                    .Select(x => new GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN {
                        ID = 10000,
                        MA_LOAI = x.MA_LOAI,
                        MA_KHOAN = x.MA_KHOAN,
                        MA_MUC = x.MA_MUC,
                        MA_TIEU_MUC = x.MA_TIEU_MUC,
                        NOI_DUNG_CHI = x.NOI_DUNG_CHI,
                        NHOM = x.NHOM,
                        LOAI = x.LOAI,
                        ID_DON_VI = x.ID_DON_VI,
                        NAM = x.NAM,
                        SO_XET_DUYET = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN")).Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                                      ,
                        SO_BAO_CAO = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("BAN")).Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                                      ,
                        DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "BAN QLDA", ID = 10000 }

                    }).ToList();

            }
        }

        private void load_lst_so(BKI_QLDTEntities db) { 
            if (lst_pl02.Where(x => x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ")).ToList().Count() > 0) {
                lst_so = lst_pl02.Where(x => x.ID_DON_VI == lst_pl02[0].ID_DON_VI)
                    .Select(x => new GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN {
                        ID = 10000,
                        MA_LOAI = x.MA_LOAI,
                        MA_KHOAN = x.MA_KHOAN,
                        MA_MUC = x.MA_MUC,
                        MA_TIEU_MUC = x.MA_TIEU_MUC,
                        NOI_DUNG_CHI = x.NOI_DUNG_CHI,
                        NHOM = x.NHOM,
                        LOAI = x.LOAI,
                        ID_DON_VI = x.ID_DON_VI,
                        NAM = x.NAM,
                        SO_XET_DUYET = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && x.LOAI == y.LOAI && x.MA_KHOAN == y.MA_KHOAN && x.MA_LOAI == y.MA_LOAI && x.MA_MUC == y.MA_MUC && x.MA_TIEU_MUC == y.MA_TIEU_MUC).Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                                      ,
                        SO_BAO_CAO = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("SỞ") && x.LOAI == y.LOAI && x.MA_KHOAN == y.MA_KHOAN && x.MA_LOAI == y.MA_LOAI && x.MA_MUC == y.MA_MUC && x.MA_TIEU_MUC == y.MA_TIEU_MUC).Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                                      ,
                        DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "SỞ GTVT", ID = 20000 }

                    }).ToList();

            }
        }

        private void load_lst_cuc(BKI_QLDTEntities db) {
            if (lst_pl02.Where(x => x.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC")).ToList().Count() > 0) {
                lst_cuc = lst_pl02.Where(x => x.ID_DON_VI == lst_pl02[0].ID_DON_VI)
                    .Select(x => new GD_PL02_KINH_PHI_DA_SU_DUNG_DE_NGHI_QUYET_TOAN {
                        ID = 10000,
                        MA_LOAI = x.MA_LOAI,
                        MA_KHOAN = x.MA_KHOAN,
                        MA_MUC = x.MA_MUC,
                        MA_TIEU_MUC = x.MA_TIEU_MUC,
                        NOI_DUNG_CHI = x.NOI_DUNG_CHI,
                        NHOM = x.NHOM,
                        LOAI = x.LOAI,
                        ID_DON_VI = x.ID_DON_VI,
                        NAM = x.NAM,
                        SO_XET_DUYET = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC")).Select(y => y.SO_XET_DUYET == null ? 0 : y.SO_XET_DUYET).ToList().Sum()
                                      ,
                        SO_BAO_CAO = lst_pl02.Where(y => y.DM_DON_VI.TEN_DON_VI.ToUpper().Contains("CỤC")).Select(y => y.SO_BAO_CAO == null ? 0 : y.SO_BAO_CAO).ToList().Sum()
                                      ,
                        DM_DON_VI = new DM_DON_VI { TEN_DON_VI = "CỤC QLĐB", ID = 30000 }

                    }).ToList();

            }
        }


        #endregion

        #region Events
        protected void Page_Load(object sender, EventArgs e) {
            load_ddl_chon_nam();
            load_data();
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