using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.QuyetToan
{
    public partial class PL04_Danh_muc_giam_tru_quyet_toan_don_vi : System.Web.UI.Page
    {
        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_PL04;
        public List<decimal?> lst_nam;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        public decimal m_dc_id_don_vi = 91;
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
            public decimal? ID_DON_VI {set; get;}
            public string TEN_DON_VI { set; get; }
        }
        #endregion

        #region Private Method
        private void load_data()
        {
            decimal v_dc_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            //decimal v_dc_id_don_vi = 241;
            m_dc_id_don_vi = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_PL04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                                        .Where(x => x.NAM == v_dc_nam && x.ID_DON_VI == m_dc_id_don_vi)
                                        .ToList();
            }
        }
        private void load_ddl_chon_nam()
        {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_nam = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                                            .Where(x=>x.ID_DON_VI== m_dc_id_don_vi)
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
        private void load_ddl_don_vi()
        {
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {

                lst_don_vi = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                                        .Where(x=>x.ID_DON_VI!=null)
                                        .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID, TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                        .Distinct()
                                        .ToList();
            }

            m_ddl_don_vi.DataValueField = "ID_DON_VI";
            m_ddl_don_vi.DataTextField = "TEN_DON_VI";
            m_ddl_don_vi.DataSource = lst_don_vi;
            m_ddl_don_vi.SelectedIndex = -1;
            m_ddl_don_vi.DataBind();
        }
        private void set_initial_form_load()
        {
            load_ddl_don_vi();
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
        protected void m_ddl_don_vi_SelectedIndexChanged(object sender, EventArgs e)
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