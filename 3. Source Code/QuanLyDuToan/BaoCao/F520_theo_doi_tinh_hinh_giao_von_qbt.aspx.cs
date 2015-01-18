using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebDS;
using WebDS.CDBNames;
using WebUS;
using IP.Core.IPCommon;

namespace QuanLyDuToan.BaoCao
{
    public partial class F520_theo_doi_tinh_hinh_giao_von_qbt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                load_data_2_grid();
            }
        }

        private void load_data_2_grid() {
            //0. tính cột "tổng kế hoạch"
            DataTable v_dt_bao_cao = new DataTable();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_GD_CHI_TIET_GIAO_VON v_us = new US_GD_CHI_TIET_GIAO_VON();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime("01/01/2014",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime("01/01/2015",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,-1
                ,-1);
            v_dt_bao_cao = v_ds.Tables[0];
            //1. tính "kế hoạch chính thức",các cột "kế hoạch bổ sung"
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime("01/01/2014",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime("01/01/2015",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,11
                ,652);
            GhepThemCot(v_dt_bao_cao,v_ds.Tables[0]);
            List<decimal> v_lst_ds_qd = getDanhSachQDBS();
            foreach (var item in v_lst_ds_qd)
            {
                v_ds.Clear();
                v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime("01/01/2014",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime("01/01/2015",c_configuration.DEFAULT_DATETIME_FORMAT)
                ,item
                ,653);
                GhepThemCot(v_dt_bao_cao,v_ds.Tables[0]);
            }
            //2. tính cột số dư năm trước chuyên sang
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_nam_truoc_chuyen_sang"
                , v_ds
                , CIPConvert.ToDatetime("01/01/2014", c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDatetime("01/01/2015", c_configuration.DEFAULT_DATETIME_FORMAT)
                , -1);
            GhepThemCot(v_dt_bao_cao, v_ds.Tables[0]);
            //3. tính cột "tổng giao vốn", các cột "giao vốn theo các quyết định"
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_von_qbt"
                , v_ds
                , CIPConvert.ToDatetime("01/01/2014", c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDatetime("01/01/2015", c_configuration.DEFAULT_DATETIME_FORMAT)
                , -1);
            GhepThemCot(v_dt_bao_cao, v_ds.Tables[0]);

            v_lst_ds_qd = getDanhSachQDGiaoVon();
            foreach (var item in v_lst_ds_qd)
            {
                v_ds.Clear();
                v_us.FillDatasetWithProcedure(
                    "pr_520_lay_tong_tien_giao_von_qbt"
                    , v_ds
                    , CIPConvert.ToDatetime("01/01/2014", c_configuration.DEFAULT_DATETIME_FORMAT)
                    , CIPConvert.ToDatetime("01/01/2015", c_configuration.DEFAULT_DATETIME_FORMAT)
                    , item);
                GhepThemCot(v_dt_bao_cao, v_ds.Tables[0]);
            }
            //4. tính cột "Tổng cấp vốn + tổng số dư"
            tinhTongCapVonSoDu();
        }

        private void tinhTongCapVonSoDu()
        {
            return;
        }

        private List<decimal> getDanhSachQDGiaoVon()
        {
            List<decimal> v_lst = new List<decimal>();
            v_lst.Add(12);
            v_lst.Add(13);
            v_lst.Add(14);
            return v_lst;
        }

        private List<decimal> getDanhSachQDBS()
        {
            List<decimal> v_lst = new List<decimal>();
            v_lst.Add(79);
            v_lst.Add(94);
            v_lst.Add(104);
            return v_lst;
        }

        private void GhepThemCot(DataTable v_dt_bao_cao, DataTable dataTable)
        {
            v_dt_bao_cao.Columns.Add("column"+v_dt_bao_cao.Columns.Count.ToString());//dataTable.Columns[2].ColumnName);
            for (int i = 0; i < v_dt_bao_cao.Rows.Count; i++)
            {
                v_dt_bao_cao.Rows[i][v_dt_bao_cao.Columns.Count - 1] = dataTable.Rows[i][2];
            }
        }
    }
}