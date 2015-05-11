using SQLDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;

namespace QuanLyDuToan.BaoCaoQT
{
    public partial class BC_PL07_Bao_cao_quyet_toan_von_scbd_tu_quy_btdb : System.Web.UI.Page
    {
        #region Public Function
        #endregion

        #region Data Member
        public List<GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN> lst_PL04;
        public List<decimal?> lst_nam;
        public decimal m_nam;
        public List<GD_CHI_TIET_GIAO_KH> lst_giao_kh;
        public List<ItemBaoCaoDonVi> lst_don_vi;
        #endregion

        #region Data Structure
        public class ItemBaoCaoDonVi
        {
            public decimal? ID_DON_VI;
            public string TEN_DON_VI;
        }
        #endregion

        #region Private Method
        private void load_data()
        {
            load_ddl_chon_nam();
            m_nam = CIPConvert.ToDecimal(m_ddl_chon_nam.SelectedValue);
            BKI_QLDTEntities db = new BKI_QLDTEntities();
            lst_PL04 = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                           .Where(x=>x.NAM == m_nam)
                           .ToList();
            lst_don_vi = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                                      .Select(x => new ItemBaoCaoDonVi { ID_DON_VI = x.DM_DON_VI.ID  , TEN_DON_VI = x.DM_DON_VI.TEN_DON_VI })
                                      .Distinct()
                                      .ToList();
            lst_giao_kh = db.GD_CHI_TIET_GIAO_KH.Where(x =>x.DM_QUYET_DINH.NGAY_THANG.Year == m_nam).ToList();
        }
        private void load_ddl_chon_nam()
        {
            //lấy dữ liệu từ DB vào list
            using (BKI_QLDTEntities db = new BKI_QLDTEntities())
            {
                lst_nam = db.GD_PL04_DANH_MUC_CONG_TRINH_QUYET_TOAN
                                            .Where(x=> x.NAM != null)
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
        #endregion

        #region Event
        protected void Page_Load(object sender, EventArgs e)
        {
            load_data();
           
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