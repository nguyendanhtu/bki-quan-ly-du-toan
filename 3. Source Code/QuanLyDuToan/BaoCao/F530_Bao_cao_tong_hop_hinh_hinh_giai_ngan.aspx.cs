using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using QuanLyDuToan.App_Code;
using System.Data;
using SQLDataAccess;



namespace QuanLyDuToan.BaoCao
{
	public partial class F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan : System.Web.UI.Page
	{
		public class GroupDonVi
		{
			public string groupKey { get; set; }
			public string groupText { get; set; }

			public GroupDonVi(string groupKey, string groupText)
			{
				this.groupKey = groupKey;
				this.groupText = groupText;
			}

		}

		#region Public Functions
		public string gen_query_string(string ip_str_id_don_vi)
		{
			return "";
				//FormInfo.FormName.F350
				//+ "?" + FormInfo.QueryString.ID_DON_VI + "= "
				//+ ip_str_id_don_vi
				//+ "&" + FormInfo.QueryString.TU_NGAY + "="
				//+ m_txt_tu_ngay.Text
				//+ "&" + FormInfo.QueryString.DEN_NGAY + "="
				//+ m_txt_den_ngay.Text;
		}
		#endregion

		#region Member
		public DateTime m_dat_tu_ngay;
		public DateTime m_dat_den_ngay;
		public DateTime m_dat_dau_nam;
		public List<DM_DON_VI> m_lst_don_vi;
		public List<GroupDonVi> m_lst_group_by;
		public List<DM_DON_VI> m_lst_don_vi_group_by;


		public List<SQLDataAccess.GD_CHI_TIET_GIAO_KH> m_lst_giao_kh;
		public List<SQLDataAccess.GD_CHI_TIET_GIAO_VON> m_lst_giao_von;
		public List<SQLDataAccess.GD_CHI_TIET_GIAI_NGAN> m_lst_giai_ngan;
		public List<SQLDataAccess.GD_KHOI_LUONG> m_lst_khoi_luong;
		#endregion

		#region Private Method
		
		private void load_data_to_grid()
		{
			m_dat_tu_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
			m_dat_den_ngay = CIPConvert.ToDatetime(m_txt_tu_ngay.Text, "dd/MM/yyyy");
			m_dat_dau_nam = WebUS.CCommonFunction.getDate_dau_nam_from_date(m_dat_tu_ngay);

			BKI_QLDTEntities db = new BKI_QLDTEntities();
			m_lst_don_vi = db.DM_DON_VI
							.ToList()
							.OrderBy(x => x.TEN_DON_VI)
							.ToList();

			m_lst_group_by = new List<GroupDonVi>{
							new GroupDonVi("cục quản lý đường bộ I.","Cục QLĐB I")
							,new GroupDonVi("cục quản lý đường bộ II.","Cục QLĐB II")
							,new GroupDonVi("cục quản lý đường bộ III.","Cục QLĐB III")
							,new GroupDonVi("cục quản lý đường bộ IV.","Cục QLĐB IV")
			};

			m_lst_don_vi_group_by = new List<SQLDataAccess.DM_DON_VI>();

			m_lst_giao_kh = db.GD_CHI_TIET_GIAO_KH
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giao_von = db.GD_CHI_TIET_GIAO_VON
								.Where(x => x.DM_QUYET_DINH.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_QUYET_DINH.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_giai_ngan = db.GD_CHI_TIET_GIAI_NGAN
								.Where(x => x.DM_GIAI_NGAN.NGAY_THANG >= m_dat_dau_nam
											&& x.DM_GIAI_NGAN.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
			m_lst_khoi_luong = db.GD_KHOI_LUONG
								.Where(x => x.NGAY_THANG >= m_dat_dau_nam
											&& x.NGAY_THANG <= m_dat_den_ngay)
								.ToList();
		}
		private bool check_validate_input_data_is_ok()
		{
			if (!CValidateTextBox.IsValid(m_txt_tu_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập Từ ngày, dạng dd/MM/yyyy";
				m_txt_tu_ngay.Focus();
				return false;
			}
			if (!CValidateTextBox.IsValid(m_txt_den_ngay, DataType.DateType, allowNull.NO))
			{
				m_lbl_mess.Text = "Bạn phải nhập Đến ngày, dạng dd/MM/yyyy";
				m_txt_den_ngay.Focus();
				return false;
			}
			return true;
		}
		private void export_excel()
		{
			//WebformReport.export_gridview_2_excel(
			// m_grv
			// , FormInfo.ExportExcelReportName.F530
			// );
		}
		private void set_inital_form_load()
		{
			//Đặt giá trị mặc định cho control khi chưa được chọn
			DateTime v_dat_dau_thang = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
			m_txt_tu_ngay.Text = CIPConvert.ToStr(v_dat_dau_thang, "dd/MM/yyyy");
			m_txt_den_ngay.Text = CIPConvert.ToStr(DateTime.Now, "dd/MM/yyyy");
			load_data_to_grid();
		}
		#endregion

		#region Event
		protected void Page_Load(object sender, EventArgs e)
		{
			m_lbl_mess.Text = "";
			if (!IsPostBack)
			{
				set_inital_form_load();
			}
		}

		protected void m_cmd_xem_bao_cao_Click(object sender, EventArgs e)
		{
			try
			{
				if (check_validate_input_data_is_ok())
				{
					load_data_to_grid();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}
		protected void m_cmd_xuat_excel_Click(object sender, EventArgs e)
		{
			try
			{
				if (check_validate_input_data_is_ok())
				{
					export_excel();
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(this, v_e);
			}
		}

		public override void VerifyRenderingInServerForm(Control control)
		{
			//base.VerifyRenderingInServerForm(control);
		}



		
		#endregion
	}
}