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
                set_default_input();
                load_data_to_grid();
            }
        }

        private void load_data_to_grid() {
            //0. tính cột "tổng kế hoạch"
            string str_tu_ngay = m_txt_tu_ngay.Text;
            string str_den_ngay = m_txt_den_ngay.Text;
            DataTable v_dt_bao_cao = new DataTable();
            DataSet v_ds = new DataSet();
            DataTable v_dt = new DataTable();
            v_ds.Tables.Add(v_dt);
            v_ds.AcceptChanges();
            US_GD_CHI_TIET_GIAO_VON v_us = new US_GD_CHI_TIET_GIAO_VON();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime(str_tu_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime(str_den_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,c_configuration.TAT_CA
                , c_configuration.TAT_CA);
            for (int i = 0; i < v_ds.Tables[0].Columns.Count; i++)
            {
                v_dt_bao_cao.Columns.Add(v_ds.Tables[0].Columns[i].ColumnName);
            }
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                var row = v_dt_bao_cao.NewRow();
                for (int j = 0; j <  v_ds.Tables[0].Columns.Count; j++)
                {
                    row[j] = v_ds.Tables[0].Rows[i][j];
                }
                v_dt_bao_cao.Rows.Add(row);
            }
            
            //1. tính "kế hoạch chính thức",các cột "kế hoạch bổ sung"
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime(str_tu_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime(str_den_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,c_configuration.TAT_CA
                ,c_configuration.GIAO_DAU_NAM);
            GhepThemCot(v_dt_bao_cao,v_ds.Tables[0],"ChinhThuc");
            List<decimal> v_lst_ds_qd = getDanhSachQDBS();
            foreach (var item in v_lst_ds_qd)
            {
                v_ds.Clear();
                v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_kh_qbt"
                ,v_ds
                ,CIPConvert.ToDatetime(str_tu_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,CIPConvert.ToDatetime(str_den_ngay,c_configuration.DEFAULT_DATETIME_FORMAT)
                ,item
                ,c_configuration.GIAO_BO_SUNG);
                GhepThemCot(v_dt_bao_cao,v_ds.Tables[0], "QD"+item.ToString());
            }
            //2. tính cột số dư năm trước chuyên sang
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_nam_truoc_chuyen_sang"
                , v_ds
                , CIPConvert.ToDatetime(str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDatetime(str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                , c_configuration.TAT_CA);
            GhepThemCot(v_dt_bao_cao, v_ds.Tables[0],"SoDu");
            //3. tính cột "tổng giao vốn", các cột "giao vốn theo các quyết định"
            v_ds.Clear();
            v_us.FillDatasetWithProcedure(
                "pr_520_lay_tong_tien_giao_von_qbt"
                , v_ds
                , CIPConvert.ToDatetime(str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                , CIPConvert.ToDatetime(str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                , c_configuration.TAT_CA);
            GhepThemCot(v_dt_bao_cao, v_ds.Tables[0], "TongVon");

            v_lst_ds_qd = getDanhSachQDGiaoVon();
            foreach (var item in v_lst_ds_qd)
            {
                v_ds.Clear();
                v_us.FillDatasetWithProcedure(
                    "pr_520_lay_tong_tien_giao_von_qbt"
                    , v_ds
                    , CIPConvert.ToDatetime(str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                    , CIPConvert.ToDatetime(str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
                    , item);
                GhepThemCot(v_dt_bao_cao, v_ds.Tables[0], "QD"+item.ToString());
            }
            //4. tính cột "Tổng cấp vốn + tổng số dư"
            tinhTongCapVonSoDu();
            veGridView(v_dt_bao_cao);
            m_grv_bao_cao_giao_von.DataSource = v_dt_bao_cao;
            m_grv_bao_cao_giao_von.DataBind();
        }

        private void veGridView(DataTable ip_dt)
        {
            for (int i = 2; i < ip_dt.Columns.Count; i++)
            {
                BoundField bfield = new BoundField();
                switch (ip_dt.Columns[i].ColumnName)
                {
                    case "Column1":
                        bfield.HeaderText = "Tổng KH giao";
                        bfield.ItemStyle.CssClass = "keHoachClass";
                        break;
                    case "SoDu":
                        bfield.HeaderText = "Số dư năm trước chuyển sang";
                        bfield.ItemStyle.CssClass = "soDuClass";
                        break;
                    case "ChinhThuc":
                        bfield.HeaderText = "KH giao chính thức " + CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT).Year.ToString();
                        bfield.ItemStyle.CssClass = "keHoachClass";
                        break;
                    case "TongVon":
                        bfield.HeaderText = "Tổng KP cấp";
                        bfield.ItemStyle.CssClass = "giaoVonClass";
                        break;
                    default:
                        var qd = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(ip_dt.Columns[i].ColumnName.Substring(2)));
                        bfield.HeaderText = qd.strSO_QUYET_DINH;
                        if (qd.dcID_LOAI_QUYET_DINH == 648)
                        {
                            bfield.ItemStyle.CssClass = "giaoVonClass";
                        }
                        else
                        {
                            bfield.ItemStyle.CssClass = "keHoachClass";
                        }
                        break;
                }
                
                bfield.DataField = ip_dt.Columns[i].ColumnName;
                bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
                bfield.HtmlEncode = false;
                m_grv_bao_cao_giao_von.Columns.Add(bfield);
            }
        }

        private void tinhTongCapVonSoDu()
        {
            return;
        }

        private List<decimal> getDanhSachQDGiaoVon()
        {

            DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT);
            DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text,c_configuration.DEFAULT_DATETIME_FORMAT);
            List<decimal> v_lst = new List<decimal>();
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            v_us.FillDatasetByLoaiQD(v_ds,v_dat_tu_ngay,v_dat_den_ngay,c_configuration.GIAO_VON, -1);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                v_lst.Add(CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][DM_QUYET_DINH.ID].ToString()));
            }
            return v_lst;
        }

        private List<decimal> getDanhSachQDBS()
        {
            List<decimal> v_lst = new List<decimal>();
            DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT);
            DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT);
            US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
            DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
            v_us.FillDatasetByLoaiQD(v_ds, v_dat_tu_ngay, v_dat_den_ngay, c_configuration.GIAO_KE_HOACH, c_configuration.GIAO_BO_SUNG);
            for (int i = 0; i < v_ds.Tables[0].Rows.Count; i++)
            {
                v_lst.Add(CIPConvert.ToDecimal(v_ds.Tables[0].Rows[i][DM_QUYET_DINH.ID].ToString()));
            }
            return v_lst;
        }

        private void GhepThemCot(DataTable v_dt_bao_cao, DataTable dataTable, string ip_str_column_name)
        {
            v_dt_bao_cao.Columns.Add(ip_str_column_name);
            for (int i = 0; i < v_dt_bao_cao.Rows.Count; i++)
            {
                v_dt_bao_cao.Rows[i][v_dt_bao_cao.Columns.Count - 1] = dataTable.Rows[i][2].ToString();
            }
        }

        protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
        {
            xoaCotDong();
            load_data_to_grid();
        }

        private void set_default_input()
        {
            m_txt_tu_ngay.Text = (new DateTime(DateTime.Now.Year, 1, 1)).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
            m_txt_den_ngay.Text = (DateTime.Now.Date).ToString(c_configuration.DEFAULT_DATETIME_FORMAT);
        }

        private void xoaCotDong()
        {
            var v_count_column = m_grv_bao_cao_giao_von.Columns.Count;
            for (int i = v_count_column - 1; i >= 1; i--)
            {
                m_grv_bao_cao_giao_von.Columns.RemoveAt(i);
            }
        }

        protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
        {
            WinformReport.export_gridview_2_excel(
            m_grv_bao_cao_giao_von
            , "BaoCaoTheoDoiGiaoVon.xls"
            );
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            //base.VerifyRenderingInServerForm(control);
        }
    }
}