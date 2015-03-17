using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;
namespace QuanLyDuToan.Quantri
{
	public partial class F810_PhanQuyenUserGroup : System.Web.UI.Page
	{
		#region Members
		US_HT_NGUOI_SU_DUNG m_us_user = new US_HT_NGUOI_SU_DUNG();
		DS_HT_NGUOI_SU_DUNG m_ds_user = new DS_HT_NGUOI_SU_DUNG();
		#endregion

		#region Data Structures

		#endregion

		#region Private Methods
		public string get_mapping_ten_chuc_nang(decimal i_dc_id_chuc_nang)
		{
			string v_str_chuc_nang = "";
			US_HT_CHUC_NANG v_us = new US_HT_CHUC_NANG(i_dc_id_chuc_nang);
			v_str_chuc_nang = v_us.strTEN_CHUC_NANG;
			return v_str_chuc_nang;
		}

		private void load_data_to_ddl_user_group()
		{

			US_HT_USER_GROUP v_us_user_group = new US_HT_USER_GROUP();
			DS_HT_USER_GROUP v_ds_user_group = new DS_HT_USER_GROUP();
			v_us_user_group.FillDataset(v_ds_user_group, "order by " + HT_USER_GROUP.USER_GROUP_NAME);
			m_cbo_user_group.DataSource = v_ds_user_group.HT_USER_GROUP;
			m_cbo_user_group.DataTextField = HT_USER_GROUP.USER_GROUP_NAME;
			m_cbo_user_group.DataValueField = CM_DM_LOAI_TD.ID;
			m_cbo_user_group.DataBind();

		}
		private void load_data_to_ddl_chuc_nang_phan_mem()
		{

			US_HT_CHUC_NANG v_us_chuc_nang = new US_HT_CHUC_NANG();
			DS_HT_CHUC_NANG v_ds_chuc_nang = new DS_HT_CHUC_NANG();
			v_ds_chuc_nang.EnforceConstraints = false;
			v_us_chuc_nang.FillDatasetFillFullTreeChucNang(
								"Y"
								, CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
								, "N"
								, v_ds_chuc_nang
								);
			m_lst_chuc_nang.DataSource = v_ds_chuc_nang.HT_CHUC_NANG;
			m_lst_chuc_nang.DataTextField = HT_CHUC_NANG.TEN_CHUC_NANG;
			m_lst_chuc_nang.DataValueField = HT_CHUC_NANG.ID;
			m_lst_chuc_nang.DataBind();

		}
		private void load_data_to_ddl_chuc_nang_phan_mem_user()
		{

			US_HT_CHUC_NANG v_us_chuc_nang = new US_HT_CHUC_NANG();
			DS_HT_CHUC_NANG v_ds_chuc_nang = new DS_HT_CHUC_NANG();
			v_ds_chuc_nang.EnforceConstraints = false;
			v_us_chuc_nang.FillDatasetFillFullTreeChucNang(
								"Y"
								, CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
								, "Y"
								, v_ds_chuc_nang
								);

			m_lst_chuc_nang_user.DataSource = v_ds_chuc_nang.HT_CHUC_NANG;
			m_lst_chuc_nang_user.DataTextField = HT_CHUC_NANG.TEN_CHUC_NANG;
			m_lst_chuc_nang_user.DataValueField = HT_CHUC_NANG.ID;
			m_lst_chuc_nang_user.DataBind();

		}

		private void update_quyen_chuc_nang()
		{
			string v_str_id_chuc_nangs = "";
			foreach (ListItem item in this.m_lst_chuc_nang_user.Items) v_str_id_chuc_nangs += item.Value + ",";
			US_HT_QUYEN_GROUP v_us_quyen_group = new US_HT_QUYEN_GROUP();
			v_us_quyen_group.update_quyen_group(
								CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
								, v_str_id_chuc_nangs
								);
			m_lbl_mess.Text = "Cập nhật quyền sử dụng chức năng cho nhóm thành công";
		}

		#endregion

		#region Events
		protected void Page_Load(object sender, EventArgs e)
		{
			try
			{
				m_lbl_mess.Text = "";
				if (!this.IsPostBack)
				{
					load_data_to_ddl_user_group();
					load_data_to_ddl_chuc_nang_phan_mem();
					load_data_to_ddl_chuc_nang_phan_mem_user();
				}

			}
			catch (Exception v_e)
			{
				this.Response.Write(v_e.ToString());
			}

		}
		protected void m_cmd_right_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				while (m_lst_chuc_nang.Items.Count > 0 && m_lst_chuc_nang.SelectedItem != null)
				{
					ListItem selectedItem = m_lst_chuc_nang.SelectedItem;
					selectedItem.Selected = false;
					m_lst_chuc_nang_user.Items.Add(selectedItem);
					m_lst_chuc_nang.Items.Remove(selectedItem);
				}

			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}

		protected void m_cmd_right_all_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				foreach (ListItem item in this.m_lst_chuc_nang.Items)
				{
					this.m_lst_chuc_nang_user.Items.Add(item);
				}
				this.m_lst_chuc_nang.Items.Clear();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_cmd_left_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				while (m_lst_chuc_nang_user.Items.Count > 0 && m_lst_chuc_nang_user.SelectedItem != null)
				{
					ListItem selectedItem = m_lst_chuc_nang_user.SelectedItem;
					selectedItem.Selected = false;
					m_lst_chuc_nang.Items.Add(selectedItem);
					m_lst_chuc_nang_user.Items.Remove(selectedItem);
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}

		}
		protected void m_cmd_left_all_Click(object sender, ImageClickEventArgs e)
		{
			try
			{
				foreach (ListItem item in this.m_lst_chuc_nang_user.Items)
				{
					this.m_lst_chuc_nang.Items.Add(item);
				}
				this.m_lst_chuc_nang_user.Items.Clear();


			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_cap_nhat_Click(object sender, EventArgs e)
		{
			try
			{
				update_quyen_chuc_nang();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cbo_user_group_SelectedIndexChanged(object sender, EventArgs e)
		{
			try
			{
				load_data_to_ddl_chuc_nang_phan_mem();
				load_data_to_ddl_chuc_nang_phan_mem_user();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		#endregion

	}
}