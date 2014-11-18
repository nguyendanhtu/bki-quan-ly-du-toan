using System.Collections.Generic;
using System.Web;
using WebUS;
using IP.Core.IPCommon;
using WebDS;
using IP.Core.IPData;
using IP.Core.IPUserService;

/// <summary>
/// Summary description for Employee
/// </summary>
public class Person
{
    public int ID;
    public string Name;

    public Person()
    {
    }

    public static decimal get_user_id()
    {
        object v_obj_id = HttpContext.Current.Session[SESSION.UserID];
        return CIPConvert.ToDecimal(v_obj_id);
    }

    public static decimal get_id_don_vi()
    {
        US_DM_DON_VI v_us = new US_DM_DON_VI();
        DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
        System.Data.SqlClient.SqlCommand v_cmd=new System.Data.SqlClient.SqlCommand();
        v_cmd.CommandType=System.Data.CommandType.Text;
        v_cmd.CommandText = @"SELECT
                                dv.*
                                FROM 
                                HT_USER_GROUP ug,
                                dm_don_vi dv,
                                ht_nguoi_su_dung nsd
                                WHERE 
                                ug.[DESCRIPTION] LIKE N'%'+dv.TEN_DON_VI+'%'
                                AND ug.id	=nsd.ID_USER_GROUP
                                and nsd.id=" + Person.get_user_id();
        v_us.FillDatasetByCommand(v_ds, v_cmd);
        decimal v_dc_id_don_vi = 0;
        if (v_ds.DM_DON_VI.Count > 0)
            v_dc_id_don_vi = CIPConvert.ToDecimal(v_ds.Tables[0].Rows[0][WebDS.CDBNames.DM_DON_VI.ID]);
        return v_dc_id_don_vi;
    }
    public static string get_user_name()
    {
        object v_obj_username = HttpContext.Current.Session[SESSION.UserName];
        return v_obj_username.ToString();
    }

    public static bool check_session_valid()
    {
        return HttpContext.Current.Session[SESSION.UserID] != null;
    }

    public static bool Allow2DeleteData()
    {
        return HttpContext.Current.Session[SESSION.Allow2DeleteDataYN].ToString() == "Y";
    }
    public static string get_chuc_nang()
    {

        return CIPConvert.ToStr(HttpContext.Current.Request.Url.PathAndQuery).Replace("/QuanLyDuToan/", "");
    }
    public static string get_chuc_nang_without_query()
    {
        return CIPConvert.ToStr(HttpContext.Current.Request.Url.AbsolutePath).Replace("/QuanLyDuToan/", "");
    }
    public static bool check_user_have_menu()
    {

        object v_obj_id_user_login = HttpContext.Current.Session[SESSION.UserID];
        if (v_obj_id_user_login == null) return false;
        else
        {
            if (get_chuc_nang_without_query() == "Default.aspx") return true;
            if (get_chuc_nang_without_query().Contains("MessageError.aspx")) return true;


            if (CIPConvert.ToDecimal(v_obj_id_user_login) == -1)
            {
                return false;
            }
            else
            {
                DS_HT_NGUOI_SU_DUNG v_ds_ht_nguoi_su_dung = new DS_HT_NGUOI_SU_DUNG();
                US_HT_NGUOI_SU_DUNG v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG();
                v_us_ht_nguoi_su_dung.FillDataset(v_ds_ht_nguoi_su_dung, "where id = " + v_obj_id_user_login.ToString());
                if (v_ds_ht_nguoi_su_dung.HT_NGUOI_SU_DUNG.Count < 1) return false;
                v_us_ht_nguoi_su_dung = new US_HT_NGUOI_SU_DUNG(CIPConvert.ToDecimal(v_obj_id_user_login));
                US_HT_USER_GROUP v_us_ht_user_group = new US_HT_USER_GROUP(v_us_ht_nguoi_su_dung.dcID_USER_GROUP);
                US_HT_QUYEN_GROUP v_us_ht_quyen_group = new US_HT_QUYEN_GROUP();
                DS_HT_QUYEN_GROUP v_ds_ht_quyen_group = new DS_HT_QUYEN_GROUP();
                v_us_ht_quyen_group.FillDataset(v_ds_ht_quyen_group, "where id_user_group = " + v_us_ht_user_group.dcID +
                    " and id_quyen in (select id from ht_chuc_nang where url_form like N'%" + get_chuc_nang() + "%' and trang_thai_yn ='Y' and hien_thi_yn='Y')");
                if (v_ds_ht_quyen_group.HT_QUYEN_GROUP.Count < 1)
                {
                    v_ds_ht_quyen_group.Clear();
                    v_us_ht_quyen_group.FillDataset(v_ds_ht_quyen_group, "where id_user_group = " + v_us_ht_user_group.dcID +
                    " and id_quyen in (select id from ht_chuc_nang where url_form like N'%" + get_chuc_nang_without_query() + "%' and trang_thai_yn ='Y' and hien_thi_yn='Y')");
                    if (v_ds_ht_quyen_group.HT_QUYEN_GROUP.Count < 1) return false;
                };
            }

        }
        return true;
    }
    public static string check_menu()
    {
        object v_obj_user_quyen = HttpContext.Current.Session[SESSION.UserQuyen];
        US_HT_CHUC_NANG v_us_ht_chuc_nang = new US_HT_CHUC_NANG(CIPConvert.ToDecimal(v_obj_user_quyen));
        return v_us_ht_chuc_nang.strTEN_CHUC_NANG;
    }

}
