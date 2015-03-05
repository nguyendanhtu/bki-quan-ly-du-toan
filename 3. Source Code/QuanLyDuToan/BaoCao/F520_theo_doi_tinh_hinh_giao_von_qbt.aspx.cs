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
using QuanLyDuToan.App_Code;

namespace QuanLyDuToan.BaoCao
{
	public partial class F520_theo_doi_tinh_hinh_giao_von_qbt : System.Web.UI.Page
	{

		#region Public Function
		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}
		#endregion

		#region Data Member
		List<decimal> m_lst_ds_qd;
		#endregion

		#region Data Structure
		#endregion

		#region Private Method

		private List<decimal> getDanhSachQDGiaoVon()
		{

			DateTime v_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT);
			DateTime v_dat_den_ngay = CIPConvert.ToDatetime(m_txt_den_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT);
			List<decimal> v_lst = new List<decimal>();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
			v_us.FillDatasetByLoaiQD(v_ds, v_dat_tu_ngay, v_dat_den_ngay, c_configuration.GIAO_VON, -1);
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

		private void load_data_to_col_tong_ke_hoach(US_GD_CHI_TIET_GIAO_VON ip_us
													, DataSet ip_ds
													, DataTable ip_dt
													, String ip_str_tu_ngay
													, String ip_str_den_ngay)
		{
			ip_us.FillDatasetWithProcedure(
				"pr_F520_lay_tong_tien_giao_kh_qbt"
				, ip_ds
				, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, c_configuration.TAT_CA
				, c_configuration.TAT_CA);
			for (int i = 0; i < ip_ds.Tables[0].Columns.Count; i++)
			{
				ip_dt.Columns.Add(ip_ds.Tables[0].Columns[i].ColumnName);
			}
			for (int i = 0; i < ip_ds.Tables[0].Rows.Count; i++)
			{
				var row = ip_dt.NewRow();
				for (int j = 0; j < ip_ds.Tables[0].Columns.Count; j++)
				{
					row[j] = ip_ds.Tables[0].Rows[i][j];
				}
				ip_dt.Rows.Add(row);
			}
		}

		private void load_data_to_col_ke_hoach_chinh_thuc_or_bo_sung(US_GD_CHI_TIET_GIAO_VON ip_us
																	, DataSet ip_ds
																	, DataTable ip_dt
																	, String ip_str_tu_ngay
																	, String ip_str_den_ngay)
		{
			ip_ds.Clear();
			ip_us.FillDatasetWithProcedure(
				"pr_F520_lay_tong_tien_giao_von_qbt"
				, ip_ds
				, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, c_configuration.TAT_CA
				, c_configuration.GIAO_DAU_NAM);
			GhepThemCot(ip_dt, ip_ds.Tables[0], "ChinhThuc");
			List<decimal> v_lst_ds_qd = getDanhSachQDBS();
			foreach (var item in v_lst_ds_qd)
			{
				ip_ds.Clear();
				ip_us.FillDatasetWithProcedure(
				"pr_F520_lay_tong_tien_nam_truoc_chuyen_sang"
				, ip_ds
				, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, item
				, c_configuration.GIAO_BO_SUNG);
				GhepThemCot(ip_dt, ip_ds.Tables[0], "QD" + item.ToString());
			}
		}

		private void load_data_to_col_so_du_nam_truoc_chuyen_sang(US_GD_CHI_TIET_GIAO_VON ip_us
																	, DataSet ip_ds
																	, DataTable ip_dt
																	, String ip_str_tu_ngay
																	, String ip_str_den_ngay)
		{
			ip_ds.Clear();
			ip_us.FillDatasetWithProcedure(
				"pr_F520_lay_tong_tien_nam_truoc_chuyen_sang"
				, ip_ds
				, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, c_configuration.TAT_CA);
			GhepThemCot(ip_dt, ip_ds.Tables[0], "SoDu");
		}

		private void load_data_to_col_tong_giao_von_and_giao_von_theo_quyet_dinh(US_GD_CHI_TIET_GIAO_VON ip_us
																				, DataSet ip_ds
																				, DataTable ip_dt
																				, String ip_str_tu_ngay
																				, String ip_str_den_ngay)
		{
			ip_ds.Clear();
			ip_us.FillDatasetWithProcedure(
				"pr_F520_lay_tong_tien_giao_von_qbt"
				, ip_ds
				, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
				, c_configuration.TAT_CA);
			GhepThemCot(ip_dt, ip_ds.Tables[0], "TongVon");

			m_lst_ds_qd = getDanhSachQDGiaoVon();
			foreach (var item in m_lst_ds_qd)
			{
				ip_ds.Clear();
				ip_us.FillDatasetWithProcedure(
					"pr_F520_lay_tong_tien_giao_von_qbt"
					, ip_ds
					, CIPConvert.ToDatetime(ip_str_tu_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
					, CIPConvert.ToDatetime(ip_str_den_ngay, c_configuration.DEFAULT_DATETIME_FORMAT)
					, item);
				GhepThemCot(ip_dt, ip_ds.Tables[0], "QD" + item.ToString());
			}
		}

		private void load_data_to_grid()
		{
			string v_str_tu_ngay = m_txt_tu_ngay.Text;
			string v_str_den_ngay = m_txt_den_ngay.Text;
			DataTable v_dt_bao_cao = new DataTable();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);
			v_ds.AcceptChanges();
			US_GD_CHI_TIET_GIAO_VON v_us_gd_chi_tiet_giao_von = new US_GD_CHI_TIET_GIAO_VON();
			//0. tính cột "tổng kế hoạch"
			load_data_to_col_tong_ke_hoach(v_us_gd_chi_tiet_giao_von
											, v_ds, v_dt_bao_cao
											, v_str_tu_ngay
											, v_str_den_ngay);
			//1. tính "kế hoạch chính thức",các cột "kế hoạch bổ sung"
			load_data_to_col_ke_hoach_chinh_thuc_or_bo_sung(v_us_gd_chi_tiet_giao_von
															, v_ds
															, v_dt_bao_cao
															, v_str_tu_ngay
															, v_str_den_ngay);
			//2. tính cột số dư năm trước chuyên sang
			load_data_to_col_so_du_nam_truoc_chuyen_sang(v_us_gd_chi_tiet_giao_von
														, v_ds
														, v_dt_bao_cao
														, v_str_tu_ngay
														, v_str_den_ngay);
			//3. tính cột "tổng giao vốn", các cột "giao vốn theo các quyết định"
			load_data_to_col_tong_giao_von_and_giao_von_theo_quyet_dinh(v_us_gd_chi_tiet_giao_von
																		, v_ds
																		, v_dt_bao_cao
																		, v_str_tu_ngay
																		, v_str_den_ngay);
			//4. tính cột "Tổng cấp vốn + tổng số dư"
			tinhTongCapVonSoDu();
			//5. Load data to grid
			draw_GridView(v_dt_bao_cao);
			m_grv_bao_cao_giao_von.DataSource = v_dt_bao_cao;
			m_grv_bao_cao_giao_von.DataBind();
		}

		private void tinhTongCapVonSoDu()
		{
			return;
		}

		private void GhepThemCot(DataTable v_dt_bao_cao, DataTable dataTable, string ip_str_column_name)
		{
			v_dt_bao_cao.Columns.Add(ip_str_column_name);
			for (int i = 0; i < v_dt_bao_cao.Rows.Count; i++)
			{
				v_dt_bao_cao.Rows[i][v_dt_bao_cao.Columns.Count - 1] = dataTable.Rows[i][2].ToString();
			}
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

		private void draw_GridView(DataTable ip_dt)
		{
			for (int i = 2; i < ip_dt.Columns.Count; i++)
			{
				BoundField bfield = new BoundField();
				
				switch (ip_dt.Columns[i].ColumnName)
				{
					case "Column1":
						bfield.HeaderText = "Tổng KH giao";
						bfield.HeaderStyle.CssClass = "hiddenCell";
						//bfield.ItemStyle.CssClass = "HeaderStyle"; //TuDM sua, bo mau sac o luoi
						break;
					case "SoDu":
						bfield.HeaderText = "Số dư năm trước chuyển sang";
						//bfield.ItemStyle.CssClass = "HeaderStyle";
						bfield.HeaderStyle.CssClass = "hiddenCell";
						break;
					case "ChinhThuc":
						bfield.HeaderText = "KH giao chính thức " + CIPConvert.ToDatetime(m_txt_tu_ngay.Text, c_configuration.DEFAULT_DATETIME_FORMAT).Year.ToString();
						bfield.HeaderStyle.CssClass = "hiddenCell";
						//bfield.ItemStyle.CssClass = "HeaderStyle";
						break;
					case "TongVon":
						bfield.HeaderText = "Tổng cộng";
						//bfield.ItemStyle.CssClass = "HeaderStyle";
						break;
					default:
						var qd = new US_DM_QUYET_DINH(CIPConvert.ToDecimal(ip_dt.Columns[i].ColumnName.Substring(2)));
						bfield.HeaderText = qd.strSO_QUYET_DINH;
						if (qd.dcID_LOAI_QUYET_DINH == 648)
						{
							//bfield.ItemStyle.CssClass = "HeaderStyle";
						}
						else
						{
							// bfield.ItemStyle.CssClass = "HeaderStyle";
						}
						break;
				}

				bfield.DataField = ip_dt.Columns[i].ColumnName;
				bfield.ItemStyle.HorizontalAlign = HorizontalAlign.Right;
				bfield.HtmlEncode = false;
				m_grv_bao_cao_giao_von.Columns.Add(bfield);
			}
		}
		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
			if (!IsPostBack)
			{
				set_default_input();
				load_data_to_grid();
			}
		}
		protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
		{
			xoaCotDong();
			load_data_to_grid();
		}
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			WebformReport.export_gridview_2_excel(
			m_grv_bao_cao_giao_von
			, "BaoCaoTheoDoiGiaoVon.xls"
			);
		}
		#endregion

		protected void m_grv_bao_cao_giao_von_RowCreated(object sender, GridViewRowEventArgs e)
		{
			//Tao header cua grid
			const string v_c_str_header_css_class = "HeaderStyle";
			if (e.Row.RowType == DataControlRowType.Header) // If header created
			{
				GridView v_grv = (GridView)sender;
				//Tao dong 1

				WebformFunctions.addHeaderRow_to_grid_view(v_grv
				, 0
				, v_c_str_header_css_class
				, new CellInfoHeader[] { 
						new CellInfoHeader("STT",2,1)
						,new CellInfoHeader("Đơn vị",2,1)
						,new CellInfoHeader("Tổng KH giao",2,1)
						,new CellInfoHeader("KH giao chính thức "+CCommonFunction.getDate_dau_nam_from_date(CIPConvert.ToDatetime(m_txt_tu_ngay.Text,"dd/MM/yyyy")).Year,2,1)
						,new CellInfoHeader("Số dư năm trước chuyển sang",2,1)
						,new CellInfoHeader("Kinh phí đã cấp",1,m_lst_ds_qd.Count+1)
						
				});
			}
		}
	}
}