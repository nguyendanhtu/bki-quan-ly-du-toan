using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPUserService;
using WebDS;
using WebUS;
using IP.Core.IPData;
using WebDS.CDBNames;

public partial class Account_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        load_data_grid("");
    }

    #region Members
    //private US_DM_DAT m_us_dm_dat = new US_DM_DAT();
    string m_str_id_checked = "";
    #endregion

    #region Private Methods

    private void load_data_grid(string ip_str_tu_khoa)
    {
        //DS_DM_DAT v_ds_dm_dat = new DS_DM_DAT();

        //if (ip_str_tu_khoa.Equals(String.Empty))
        //{
        //    m_us_dm_dat.FillDataset(v_ds_dm_dat);
        //}
        //else
        //{
        //    CStoredProc v_cstore = new CStoredProc("pr_DM_DAT_Search");
        //    v_cstore.addNVarcharInputParam("@TU_KHOA", ip_str_tu_khoa);
        //    v_cstore.fillDataSetByCommand(m_us_dm_dat, v_ds_dm_dat);
        //}
        //m_grv_danh_sach_nha.DataSource = v_ds_dm_dat.DM_DAT;
        //m_grv_danh_sach_nha.DataBind();
    }
    
    private void cong_viec_thuc_hien_khi_check(decimal ip_dc_id_rows_checked)
    {
        // nếu thực hiện việc khác thì vào đây sửa 2 dòng dưới
        m_str_id_checked += CIPConvert.ToStr(ip_dc_id_rows_checked);
        m_str_id_checked += ", ";
    }
    
    #endregion
    
    #region Events
    /// <summary>
    /// Sự kiện này sẽ: lấy ID của các checkbox được check trên lưới và hiển thị lên màn hình
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void m_cmd_hien_thi_id_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (GridViewRow row in m_grv_danh_sach_nha.Rows)
            {
                bool v_ch;
                CheckBox v_checkbox = (CheckBox)row.FindControl("chkItem");
                if (v_checkbox != null)
                {
                    // Nếu checkbox của dòng này được checked thì ta thực hiện 1 số công việc sau
                    if (v_checkbox.Checked)
                    {
                        // Chỗ này là công việc cần thực hiện khi checkbox đc checkded
                        cong_viec_thuc_hien_khi_check(CIPConvert.ToDecimal(v_checkbox.ToolTip));
                    }
                }
            }
            m_str_id_checked.Trim().Substring(0, m_str_id_checked.Length - 1);
            // Hiển thị các ID được checked ra màn hình
            Response.Write(m_str_id_checked);
        }
        catch (Exception v_e)
        {
            CSystemLog_301.ExceptionHandle(v_e);
        }
    }
    #endregion
}