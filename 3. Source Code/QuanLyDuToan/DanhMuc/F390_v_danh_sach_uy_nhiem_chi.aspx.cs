using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPException;
using WebDS;
using WebUS;
using WebDS.CDBNames;
using QuanLyDuToan.App_Code;
using System.Data;
using IP.Core.IPUserService;
using IP.Core.IPData;



namespace QuanLyDuToan.DanhMuc
{
	public partial class F390_v_danh_sach_uy_nhiem_chi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
				m_lbl_mess.Text = "";
                if (!IsPostBack)
                {
                    if (Request.QueryString["ip_dat_tu_ngay"] != null)
                    {
                        m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_tu_ngay.Text = CIPConvert.ToStr(WebformControls.get_dau_nam_form_date(DateTime.Now), "dd/MM/yyyy");
                    }
                    if (Request.QueryString["ip_dat_den_ngay"] != null)
                    {
                        m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"].ToString();
                    }
                    else
                    {
                        m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
                    }
                    WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(Person.get_id_don_vi(), m_ddl_don_vi);
                    load_data_to_grid();
                }
            }
            catch (Exception v_e)
            {
                this.Response.Write(v_e.ToString());
            }
        }
        #region Members
        
        #endregion
        #region Private Methods
        private void set_inital_form_mode()
        {
            
        }
        private bool check_validate_is_ok()
        {

            return true;
        }
        private void load_data_to_grid()
        {
          
            if (!check_validate_is_ok()) return;

            DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
            DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy");
            US_V_DM_GIAI_NGAN v_us = new US_V_DM_GIAI_NGAN();
            DS_V_DM_GIAI_NGAN v_ds = new DS_V_DM_GIAI_NGAN();
            v_ds.EnforceConstraints = false;
            v_us.FillDatasetByProc(
                v_ds,
                CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
                CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue),
                m_txt_tu_khoa_tim_kiem.Text
                );
			
			//Chi ro Uy nhiem chi la thuoc nguon nao
			for (int i = 0; i < v_ds.V_DM_GIAI_NGAN.Count; i++)
			{
				if (v_ds.Tables[0].Rows[i][V_DM_GIAI_NGAN.IS_NGUON_NS_YN].ToString().Equals(STR_NGUON.NGAN_SACH))
					v_ds.Tables[0].Rows[i]["NGUON_NS_YN"] = "Nguồn Ngân sách";
				else v_ds.Tables[0].Rows[i]["NGUON_NS_YN"] = "Nguồn Quỹ bảo trì";
			}
			v_ds.AcceptChanges();
            m_grv_bao_cao_giao_von.DataSource = v_ds.V_DM_GIAI_NGAN;
            m_grv_bao_cao_giao_von.DataBind();

        }
        #endregion
        //
        //Events
        protected void m_cmd_tim_kiem_Click(object sender, EventArgs e)
        {
            try
            {
                load_data_to_grid();
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
                load_data_to_grid();
            }
            catch (Exception v_e)
            {
                CSystemLog_301.ExceptionHandle(this, v_e);
            }
        }
		private void export_excel()
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
			WebformReport.export_gridview_2_excel(
			m_grv_bao_cao_giao_von, "[" + v_us.strTEN_DON_VI + "]BaoCaoGiaiNganTheoUyNhiemChi.xls");
		}
		/* Để Xuất file excel
		 * 1. Dùng 
		 * WinformReport.export_gridview_2_excel(
			m_grv
			, "TenBaoCao.xls"
			);
		 * 2. Thêm 
		 * <Triggers>
			 <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
		</Triggers>
		 * Trong aspx
		 * 3. Thêm hàm VerifyRenderingInServerForm
		*/
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				export_excel();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		protected void m_grv_bao_cao_giao_von_RowCommand(object sender, GridViewCommandEventArgs e)
		{
			try
			{
				if (e.CommandName.ToUpper()=="XOA")
				{
					US_DM_GIAI_NGAN v_us_dm_giai_ngan = new US_DM_GIAI_NGAN();
					if (v_us_dm_giai_ngan.deleteAllDataOfUNC(CIPConvert.ToDecimal(e.CommandArgument)))
					{
						m_lbl_mess.Text = "Bạn đã xoá Uỷ nhiệm chi thành công";
						load_data_to_grid();
					}
					else m_lbl_mess.Text = "Đã có lỗi trong quá trình thực hiện, bạn hãy thực hiện lại thao tác";

					
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
    }
} 