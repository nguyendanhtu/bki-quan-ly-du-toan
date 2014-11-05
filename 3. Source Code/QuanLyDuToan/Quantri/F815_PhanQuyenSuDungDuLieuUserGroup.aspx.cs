using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPData;
using IP.Core.IPUserService;
using WebDS.CDBNames;
using WebDS;
using IP.Core.IPCommon;
using WebUS;
public partial class QuantriF815_PhanQuyenSuDungDuLieuUserGroup : System.Web.UI.Page
{
    #region Members
    US_HT_NGUOI_SU_DUNG m_us_user = new US_HT_NGUOI_SU_DUNG();
    DS_HT_NGUOI_SU_DUNG m_ds_user = new DS_HT_NGUOI_SU_DUNG();
    #endregion

    #region Data Structures

    #endregion

    #region Private Methods

    protected void Page_Load(object sender, EventArgs e)
    {
        try {
            
            if (!this.IsPostBack) {
               
                load_cbo_user_group();
                load_cbo_ds_don_vi_chua_duoc_su_dung();
                load_cbo_ds_don_vi_duoc_su_dung();
            }    
            
        }catch(Exception v_e){
            this.Response.Write(v_e.ToString());
        }

    }
    

    private void load_cbo_user_group()
    {
        try
        {
            US_HT_USER_GROUP v_us_user_group = new US_HT_USER_GROUP();
            DS_HT_USER_GROUP v_ds_user_group = new DS_HT_USER_GROUP();
            v_us_user_group.FillDataset(v_ds_user_group, " ORDER BY " +HT_USER_GROUP.USER_GROUP_NAME);
            m_cbo_user_group.DataSource = v_ds_user_group.HT_USER_GROUP;
            m_cbo_user_group.DataTextField = HT_USER_GROUP.USER_GROUP_NAME;
            m_cbo_user_group.DataValueField = CM_DM_LOAI_TD.ID;
            m_cbo_user_group.DataBind();
        }
        catch (Exception v_e)
        {
            throw v_e;
        }
    }
    private void load_cbo_ds_don_vi_chua_duoc_su_dung()
    {
       
            US_DM_DON_VI v_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_don_vi = new DS_DM_DON_VI();

            v_us_don_vi.FillDataset(
                CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
                , false
                , v_ds_don_vi);



            m_lst_don_vi.DataSource = v_ds_don_vi.DM_DON_VI;
            m_lst_don_vi.DataTextField = DM_DON_VI.TEN_DON_VI;
            m_lst_don_vi.DataValueField = DM_DON_VI.ID;
            m_lst_don_vi.DataBind();
       
    }
    private void load_cbo_ds_don_vi_duoc_su_dung()
    {
      
            US_DM_DON_VI v_us_don_vi = new US_DM_DON_VI();
            DS_DM_DON_VI v_ds_don_vi = new DS_DM_DON_VI();

            v_us_don_vi.FillDataset(
                CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue)
                , true
                , v_ds_don_vi);

            m_lst_don_vi_user_group.DataSource = v_ds_don_vi.DM_DON_VI;
            m_lst_don_vi_user_group.DataTextField = DM_DON_VI.TEN_DON_VI;
            m_lst_don_vi_user_group.DataValueField = DM_DON_VI.ID;
            m_lst_don_vi_user_group.DataBind();
       
    }
    private void update_quyen_su_dung_du_lieu()
    {
        try
        {
            m_lbl_mess.Text = "";
            string v_str_id_chuc_nangs = "";
            foreach (ListItem ltTemp in this.m_lst_don_vi_user_group.Items)
            {

                v_str_id_chuc_nangs += ltTemp.Value + ",";
            }
            US_HT_QUAN_HE_SU_DUNG_DU_LIEU v_us_quan_he_sd_du_lieu = new US_HT_QUAN_HE_SU_DUNG_DU_LIEU();
            v_us_quan_he_sd_du_lieu.update_quyen_group(CIPConvert.ToDecimal(m_cbo_user_group.SelectedValue),v_str_id_chuc_nangs);
            m_lbl_mess.Text ="Cập nhật quyền sử dụng chức năng cho nhóm thành công";
        }
        catch (Exception v_e)
        {
            m_lbl_mess.Text = "Lỗi trong quá trình cập nhật bản ghi.";
            throw v_e;
        }
    }

    #endregion

    //
    //
    // events
    //
    //

   
    protected void m_cmd_right_Click(object sender, ImageClickEventArgs e)
    {
        try
        {
            while (m_lst_don_vi.Items.Count > 0 && m_lst_don_vi.SelectedItem != null)
            {
                ListItem selectedItem = m_lst_don_vi.SelectedItem;
                selectedItem.Selected = false;
                m_lst_don_vi_user_group.Items.Add(selectedItem);
                m_lst_don_vi.Items.Remove(selectedItem);
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
            foreach (ListItem ltTemp in this.m_lst_don_vi.Items)
            {
                this.m_lst_don_vi_user_group.Items.Add(ltTemp);
            }
            this.m_lst_don_vi.Items.Clear();
            

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
            while (m_lst_don_vi_user_group.Items.Count > 0 && m_lst_don_vi_user_group.SelectedItem != null)
            {
                ListItem selectedItem = m_lst_don_vi_user_group.SelectedItem;
                selectedItem.Selected = false;
                m_lst_don_vi.Items.Add(selectedItem);
                m_lst_don_vi_user_group.Items.Remove(selectedItem);
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
            foreach (ListItem ltTemp in this.m_lst_don_vi_user_group.Items)
            {
                this.m_lst_don_vi.Items.Add(ltTemp);
            }
            this.m_lst_don_vi_user_group.Items.Clear();


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
            m_lbl_mess.Text = "";
            update_quyen_su_dung_du_lieu();

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
            load_cbo_ds_don_vi_chua_duoc_su_dung();
            load_cbo_ds_don_vi_duoc_su_dung();

        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(this, v_e);
        }
    }
}