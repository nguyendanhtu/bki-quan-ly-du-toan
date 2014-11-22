using System;
using System.Collections.Generic;

using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using WebUS;
using WebDS;
using WebDS.CDBNames;

public partial class DuToan_f209_giao_von_ns : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            set_inital_form_load();
        }
    }

    private void load_data_to_ddl_chuong()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.CHUONG+" order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_chuong.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_chuong.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_chuong.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_chuong.DataBind();
        m_ddl_chuong.Items.Insert(0, new ListItem("---Chọn Chương---", "-1"));
    }
    private void load_data_to_ddl_loai()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.LOAI + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_loai.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_loai.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_loai.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_loai.DataBind();
        m_ddl_loai.Items.Insert(0, new ListItem("---Chọn Loại---", "-1"));
    }
    private void load_data_to_ddl_khoan()
    {
        if (m_ddl_loai.SelectedValue == "-1" | m_ddl_loai.SelectedValue == "" | m_ddl_loai.SelectedValue == null)
        {
            m_ddl_khoan.Items.Clear();
            return;
        }
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();

        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, 
            "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.KHOAN 
            +" and id_cha="+m_ddl_loai.SelectedValue
            + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_khoan.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_khoan.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_khoan.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_khoan.DataBind();
        m_ddl_khoan.Items.Insert(0, new ListItem("---Chọn Khoản---", "-1"));
    }
    private void load_data_to_ddl_muc()
    {
        US_DM_CHUONG_LOAI_KHOAN_MUC v_us_dm_chuong_loai_khoan_muc = new US_DM_CHUONG_LOAI_KHOAN_MUC();
        DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds_dm_chuong_loai_khoan_muc = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
        v_us_dm_chuong_loai_khoan_muc.FillDataset(v_ds_dm_chuong_loai_khoan_muc, "where id_loai=" + ID_CHUONG_LOAI_KHOAN_MUC.MUC + " order by ma_so");
        for (int i = 0; i < v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC.Count; i++)
        {
            v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN] =
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.MA_SO] + " " +
                v_ds_dm_chuong_loai_khoan_muc.Tables[0].Rows[i][DM_CHUONG_LOAI_KHOAN_MUC.TEN];
            v_ds_dm_chuong_loai_khoan_muc.AcceptChanges();
        }

        m_ddl_muc.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
        m_ddl_muc.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
        m_ddl_muc.DataSource = v_ds_dm_chuong_loai_khoan_muc.DM_CHUONG_LOAI_KHOAN_MUC;
        m_ddl_muc.DataBind();
        m_ddl_muc.Items.Insert(0, new ListItem("---Chọn Mục---", "-1"));
    }

    private void set_inital_form_load()
    {
        load_data_to_ddl_chuong();
        load_data_to_ddl_loai();
        load_data_to_ddl_khoan();
        load_data_to_ddl_muc();
    }
    protected void m_ddl_loai_SelectedIndexChanged(object sender, EventArgs e)
    {
        load_data_to_ddl_khoan();
    }
}