using IP.Core.IPCommon;
using QuanLyDuToan.App_Code;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.BaoCao
{
	public partial class F357_giai_ngan_theo_uy_nhiem_chi : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				if (Request.QueryString["ip_nguon_ns"] != null)
				{
					if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
					{
						m_lbl_nguon.Text = " - NGUỒN NGÂN SÁCH ";
					}
					else m_lbl_nguon.Text = " - QUỸ BẢO TRÌ ";
				}
				else m_lbl_nguon.Text = " - QUỸ BẢO TRÌ ";
				WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
				//load ngay thang mac dinh
				DateTime v_dat_now = DateTime.Now;
				DateTime v_dat_dau_nam = v_dat_now.AddDays(-v_dat_now.Day + 1);
				v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
				m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_nam, "dd/MM/yyyy");
				m_txt_den_ngay.Text = CIPConvert.ToStr(v_dat_now, "dd/MM/yyyy");

				//load ngay thang theo link
				if (Request.QueryString["ip_dat_tu_ngay"] != null)
				{
					m_txt_tu_ngay.Text = Request.QueryString["ip_dat_tu_ngay"];
				}
				if (Request.QueryString["ip_dat_den_ngay"] != null)
				{
					m_txt_den_ngay.Text = Request.QueryString["ip_dat_den_ngay"];
				}
				load_data_2_ddl();
				load_data_to_grid();
			}
		}

		private void load_data_to_grid()
		{
			try
			{
				decimal v_dc_id_don_vi = CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue);
				//if (Request.QueryString["ip_dc_id_don_vi"] != null)
				//{
				//	v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
				//}
				
				DataSet v_ds = new DataSet();
				DataTable v_dt = new DataTable();
				v_ds.Tables.Add(v_dt);
				v_ds.AcceptChanges();
				v_ds.EnforceConstraints = false;
				string v_str_is_nguon_ns = "N";
				if (Request.QueryString["ip_nguon_ns"] != null)
				{
					if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
					{
						v_str_is_nguon_ns = "Y";
					}
				}
				decimal v_dc_dc_du_an = CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue.Trim() == "" ? "-1" : m_ddl_du_an.SelectedValue.Trim());
				new US_V_GD_GIAI_NGAN_QBT().FillData2DatasetGiaiNgan(
					v_ds,
					CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
					CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT),
					v_dc_id_don_vi,
					CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue.Trim() == "" ? "-1" : m_ddl_loai_nv.SelectedValue.Trim()),
					CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue.Trim() == "" ? "-1" : m_ddl_cong_trinh.SelectedValue.Trim()),
					CIPConvert.ToDecimal(m_ddl_du_an.SelectedValue.Trim() == "" ? "-1" : m_ddl_du_an.SelectedValue.Trim()),
					m_txt_tim_kiem.Text.Trim(),
					v_str_is_nguon_ns,
					CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue),
					"pr_F357_giai_ngan_theo_uy_nhiem_chi");
				
				m_grv.DataSource = v_ds.Tables[0];
				if (CIPConvert.ToDecimal(m_ddl_quyet_dinh.SelectedValue) == -1)
				{
					BoundField field = (BoundField)this.m_grv.Columns[1];
					field.DataField = "Tổng cộng";
					//field.DataField = "tong_tien_qd";
				}
				else
				{
					BoundField field = (BoundField)this.m_grv.Columns[1];
					field.DataField = "tong_tien_qd";
				}
				m_grv.DataBind();
			}
			catch (Exception ex)
			{
				CSystemLog_301.ExceptionHandle(this, ex);
			}

		}

		private void load_data_2_ddl_loai_nv()
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			decimal v_dc_id_loai_nhiem_vu = -1;
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			if (Request.QueryString["ip_dc_id_loai_nhiem_vu"] != null)
			{
				v_dc_id_loai_nhiem_vu = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_loai_nhiem_vu"]);
			}
			decimal v_id_dc_id_du_an = -1;
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_id_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
			}
			//m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(v_id_dc_id_du_an);
			App_Code.WebformControls.load_data_to_ddl_loai_nhiem_vu(m_ddl_loai_nv);
			m_ddl_loai_nv.SelectedValue = CIPConvert.ToStr(v_dc_id_loai_nhiem_vu);
			//load cong trinh theo loai nhiem vu
			App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_cong_trinh, v_dc_id_don_vi);
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, v_dc_id_don_vi);
		}

		private void load_data_2_ddl()
		{
			load_data_2_ddl_don_vi();
			load_data_2_ddl_loai_nv();
			load_data_to_ddl_quyet_dinh();
			//load ddl cong trinh
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			decimal v_id_dc_id_cong_trinh = -1;
			if (Request.QueryString["ip_dc_id_cong_trinh"] != null)
			{
				v_id_dc_id_cong_trinh = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_cong_trinh"]);
			}
			m_ddl_cong_trinh.SelectedValue = CIPConvert.ToStr(v_id_dc_id_cong_trinh);
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, v_dc_id_don_vi);
			//load ddl du an
			decimal v_id_dc_id_du_an = -1;
			if (Request.QueryString["ip_dc_id_du_an"] != null)
			{
				v_id_dc_id_du_an = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_du_an"]);
			}
			m_ddl_du_an.SelectedValue = CIPConvert.ToStr(v_id_dc_id_du_an);
		}

		private void load_data_to_ddl_quyet_dinh()
		{
			bool v_str_nguon_ns = false;
			if (Request.QueryString["ip_nguon_ns"] != null)
				if (Request.QueryString["ip_nguon_ns"].ToString().Equals("Y"))
				{
					v_str_nguon_ns = true;
				}

			WebformControls.load_data_to_cbo_dm_uy_nhiem_chi(
				m_ddl_quyet_dinh
				, CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy")
				, CIPConvert.ToDatetime(m_txt_den_ngay.Text, "dd/MM/yyyy")
				, v_str_nguon_ns
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue)
                , "-----Tổng-----");
			//US_DM_GIAI_NGAN v_us = new US_DM_GIAI_NGAN();
			//DS_DM_GIAI_NGAN v_ds = new DS_DM_GIAI_NGAN();
			//v_us.FillDataset(v_ds,
			//	" where ID_DON_VI = " + m_ddl_don_vi.SelectedValue);// + 
			////" and NGAY_THANG >= " + m_txt_tu_ngay.Text +
			////" and NGAY_THANG <= " + m_txt_den_ngay.Text);
			//m_ddl_quyet_dinh.DataSource = v_ds.DM_GIAI_NGAN;
			//m_ddl_quyet_dinh.DataValueField = DM_GIAI_NGAN.ID;
			//m_ddl_quyet_dinh.DataTextField = DM_GIAI_NGAN.SO_UNC;
			//m_ddl_quyet_dinh.DataBind();
			//m_ddl_quyet_dinh.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
		}

		private void load_data_2_ddl_don_vi()
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			if (Request.QueryString["ip_dc_id_don_vi"] != null)
			{
				v_dc_id_don_vi = CIPConvert.ToDecimal(Request.QueryString["ip_dc_id_don_vi"]);
			}
			WebformControls.load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(v_dc_id_don_vi, m_ddl_don_vi);
		}

		protected void m_ddl_loai_nv_SelectedIndexChanged(object sender, EventArgs e)
		{
			App_Code.WebformControls.load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
				CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue)
				, m_ddl_cong_trinh
				, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));

			m_ddl_cong_trinh_SelectedIndexChanged(null, null);
		}

		protected void m_ddl_cong_trinh_SelectedIndexChanged(object sender, EventArgs e)
		{
			App_Code.WebformControls.load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(CIPConvert.ToDecimal(m_ddl_cong_trinh.SelectedValue), CIPConvert.ToDecimal(m_ddl_loai_nv.SelectedValue), m_ddl_du_an, CIPConvert.ToDecimal(m_ddl_don_vi.SelectedValue));
		}

		protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
		{
			load_data_to_grid();
		}

		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			US_DM_DON_VI v_us = new US_DM_DON_VI(Person.get_id_don_vi());
			WebformReport.export_gridview_2_excel(
			m_grv
			, "[" + v_us.strTEN_DON_VI + "]BaoCaoTinhHinhGiaiNgan.xls"
			);
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}

		protected void m_txt_tu_ngay_TextChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_quyet_dinh();
		}

		protected void m_txt_den_ngay_TextChanged(object sender, EventArgs e)
		{
			load_data_to_ddl_quyet_dinh();
		}

		protected void m_ddl_quyet_dinh_SelectedIndexChanged(object sender, EventArgs e)
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
				load_data_to_ddl_quyet_dinh();
				m_ddl_quyet_dinh_SelectedIndexChanged(null, null);
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
	}
}