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
    public partial class BC_PL05_Danh_muc_giam_tru_quyet_toan : System.Web.UI.Page
    {
        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN> lst_PL05;
        public List<decimal?> lst_nam;
        public List<ItemBaoCaoDonVi> lst_don_vi;
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
        #endregion

        #region Private Method
        private void load_data()
        {
            decimal v_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_PL05 = db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN
                                        .Where(x => x.NAM == v_dc_nam)
                                        .ToList();

                lst_don_vi = db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN
                                        .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                        .Distinct()
                                        .ToList();
            }
        }
        private void load_ddl_chon_nam()
        {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_nam = db.GD_PL05_DANH_MUC_CONG_TRINH_HOAN_THANH_GIAM_TRU_THANH_TOAN
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