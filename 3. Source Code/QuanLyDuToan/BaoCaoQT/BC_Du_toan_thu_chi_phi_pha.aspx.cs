using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
namespace QuanLyDuToan.BaoCaoQT
{
    public partial class BC_Du_toan_thu_chi_phi_pha : System.Web.UI.Page
    {
        #region Public Function
        #endregion

        #region Data Member
        public List<GD_DU_TOAN_THU_CHI_PHI_PHA> lst_gd_phi_pha;
        public List<decimal?> lst_nam;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public List<Pha> lst_pha;
        public decimal ini_nam = CIPConvert.ToDecimal(DateTime.Now.Year);
        #endregion

        #region Data Structure
        public class ItemPL01
        {
            public string MaSo;
            public string ChiTieu;
        }
        public class ItemBaoCaoDonVi
        {
            public decimal? ID_DON_VI;
            public string TEN_DON_VI;
        }
        public class Pha
        {
            public decimal? ID_PHA;
            public string TEN_PHA;
        }
        public class LoaiMa
        {
            public const string DU_TOAN_THU = "10000";
            public const string DU_TOAN_CHI = "20000";
            public const string CHI_THUONG_XUYEN = "21000";
            public const string CHI_KHONG_THUONG_XUYEN = "22000";
            public const string QUY_KHEN_THUONG = "23000";
            public const string CHENH_LECH_THU_CHI = "30000";
        }
        #endregion

        #region Private Method
        private void load_data()
        {
            decimal v_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_gd_phi_pha = db.GD_DU_TOAN_THU_CHI_PHI_PHA
                                        .Where(x => x.NAM == v_dc_nam)
                                        .ToList();

                lst_don_vi = db.GD_DU_TOAN_THU_CHI_PHI_PHA
                                        .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                        .Distinct()
                                        .ToList();
                lst_pha = db.GD_DU_TOAN_THU_CHI_PHI_PHA
                                        .Select(x => new Pha { ID_PHA = x.ID_PHA, TEN_PHA = x.DM_PHA.PHA })
                                        .Distinct()
                                        .ToList();
            }
        }
        private void load_ddl_chon_nam()
        {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_nam = db.GD_DU_TOAN_THU_CHI_PHI_PHA
                                            .Where(x=>x.NAM != null)
                                            .Select(x => x.NAM )
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
        private void set_initial_form_load()
        {

            load_ddl_chon_nam();

        }

        #endregion

        #region Event

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                set_initial_form_load();
                load_data();
            }
        }

        protected void m_ddl_chon_nam_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                load_data();
            }

            catch (Exception v_e)
            {

                CSystemLog_301.ExceptionHandle(this, v_e);
            }

        }

        #endregion
    }
}