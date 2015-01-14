using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.BaoCao
{
    public partial class F157_bao_cao_giao_kh_quy_bt_theo_qd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            m_grv.DataSource = new List<String>();
            m_grv.DataBind();
        }
    }
}