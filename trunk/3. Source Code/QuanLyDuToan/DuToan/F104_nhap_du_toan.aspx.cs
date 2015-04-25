using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SQLDataAccess;
using QuanLyDuToan.App_Code;
using WebDS;
using WebUS;
using Framework.Extensions;
using IP.Core.IPCommon;
using System.Data;

namespace QuanLyDuToan.DuToan
{
	public partial class F104_nhap_du_toan : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			BKI_QLDTEntities db = new BKI_QLDTEntities();
			
			load_data_to_lst_don_vi(db);
			load_data_to_lst_clkm(db);
			load_data_to_lst_quyet_dinh(db);
			load_data_to_lst_ct_da_gt(db);
			load_data_to_lst_loai_nhiem_vu(db);
			load_data_to_lst_giao_kh(db);
			load_data_to_lst_gd(db);

			m_str_nguon=WebformFunctions.getValue_from_query_string<string>(
								this
								, FormInfo.QueryString.NGUON_NGAN_SACH
								, STR_NGUON.QUY_BAO_TRI
								);
			m_dc_id_don_vi = Person.get_id_don_vi();
		}

		#region Public Functions
		public string genClassCSS(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT == "-1")
			{
				//tong
				v_str_op = "tong ";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = " lnv "+ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID==-1)
			{
				//cong trinh
				v_str_op = " ct " + ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = "da " + ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSo(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "0";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op =ip_gd.REPORT_LEVEL+ ip_gd.STT;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT+ip_gd.ID;
			}
			return v_str_op;
		}
		public string genMaSoParent(pr_F104_nhap_du_toan_ke_hoach_Result ip_gd)
		{
			string v_str_op = "";
			if (ip_gd.STT.Trim().Equals("-1"))
			{
				//tong
				v_str_op = "";
			}
			else if (Int32.Parse(ip_gd.STT) < -999)
			{
				//loai nhiem vu
				v_str_op = "0";
			}
			else if (ip_gd.ID == -1)
			{
				//cong trinh
				v_str_op = ip_gd.REPORT_LEVEL;
			}
			else
			{
				//du an
				v_str_op = ip_gd.REPORT_LEVEL + ip_gd.STT;
			}
			return v_str_op;
		}
		#endregion

		#region Members
		public List<DBClassModel.DM_CHUONG_LOAI_KHOAN_MUC> m_lst_clkm;
		public List<DBClassModel.DM_CONG_TRINH_DU_AN_GOI_THAU> m_lst_ct_da_gt;
		public List<DBClassModel.DM_QUYET_DINHs> m_lst_quyet_dinh;
		public List<pr_F104_nhap_du_toan_ke_hoach_Result> m_lst_giao_kh;
		public List<DBClassModel.GD_CHI_TIET_GIAO_KH> m_lst_gd;
		public List<DBClassModel.DM_DON_VI> m_lst_don_vi;
		public List<DBClassModel.CM_DM_TU_DIEN> m_lst_loai_nhiem_vu;
		public string m_str_nguon;
		public decimal m_dc_id_don_vi;
		public decimal m_dc_id_quyet_dinh;
		#endregion

		#region Private Methods
		private void set_initial_form_load()
		{

		}
		private void load_data_to_lst_loai_nhiem_vu(BKI_QLDTEntities ip_db)
		{
			m_lst_loai_nhiem_vu = ip_db
				.CM_DM_TU_DIEN
				.Where(x => x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU
						|| x.ID_LOAI_TU_DIEN == ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS)
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.CM_DM_TU_DIEN>())
				.ToList();
		}
		private void load_data_to_lst_don_vi(BKI_QLDTEntities ip_db)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(v_dc_id_don_vi, v_ds);
			m_lst_don_vi = v_ds.Tables[0].ToList<DBClassModel.DM_DON_VI>()
				.ToList();
		}

		private void load_data_to_lst_clkm(BKI_QLDTEntities ip_db)
		{
			m_lst_clkm = ip_db
				.DM_CHUONG_LOAI_KHOAN_MUC
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.DM_CHUONG_LOAI_KHOAN_MUC>())
				.ToList();
		}
		private void load_data_to_lst_quyet_dinh(BKI_QLDTEntities ip_db)
		{
			m_lst_quyet_dinh = ip_db
				.DM_QUYET_DINH.OrderByDescending(x => x.NGAY_THANG)
				.Where(x => x.ID_LOAI_QUYET_DINH == ID_LOAI_QUYET_DINH.GIAO_KE_HOACH)
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.DM_QUYET_DINH>())
				.Select(x => new DBClassModel.DM_QUYET_DINHs
				{
					ID = x.ID,
					ID_DON_VI = x.ID_DON_VI,
					SO_QUYET_DINH = x.SO_QUYET_DINH,
					NOI_DUNG = x.NOI_DUNG,
					NGAY_THANG = x.NGAY_THANG,
					str_NGAY_THANG = CIPConvert.ToStr(x.NGAY_THANG, "dd/MM/yyyy"),
					ID_LOAI_QUYET_DINH = x.ID_LOAI_QUYET_DINH,
					ID_LOAI_QUYET_DINH_GIAO = x.ID_LOAI_QUYET_DINH_GIAO
				})
				.ToList();
		}
		private void load_data_to_lst_ct_da_gt(BKI_QLDTEntities ip_db)
		{
			m_lst_ct_da_gt = ip_db.DM_CONG_TRINH_DU_AN_GOI_THAU
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.DM_CONG_TRINH_DU_AN_GOI_THAU>())
				.ToList();
		}
		private void load_data_to_lst_giao_kh(BKI_QLDTEntities ip_db)
		{
			decimal v_dc_id_don_vi = 103;
			decimal v_dc_id_quyet_dinh = 198;
			string v_str_is_nguon_ns = "N";
			decimal v_id_dc_reported_user = Person.get_user_id();
			US_GRID_GIAO_KH v_us = new US_GRID_GIAO_KH();
			DataSet v_ds = new DataSet();
			v_ds.Tables.Add(new DataTable());
			v_ds.AcceptChanges();
			if (Request.QueryString["ip_nguon_ns"] == "Y")
			{
				v_str_is_nguon_ns = "Y";
			}

			//ip_db.pr_F104_nhap_du_toan_ke_hoach(
			//				v_dc_id_quyet_dinh
			//				, v_str_is_nguon_ns
			//				, v_id_dc_reported_user
			//				, v_dc_id_don_vi);





			v_us.get_grid_giao_kh_qbt(v_ds
				, v_dc_id_quyet_dinh
				, v_str_is_nguon_ns
				, v_id_dc_reported_user
				, v_dc_id_don_vi);
			m_lst_giao_kh = v_ds.Tables[0]
							.AsEnumerable()
							.Select(x => new pr_F104_nhap_du_toan_ke_hoach_Result
							{
								ID = (x.IsNull("ID") ? -1 : CIPConvert.ToDecimal(x["ID"])),
								ID_CHA = (x.IsNull("ID_CHA") ? -1 : CIPConvert.ToDecimal(x["ID_CHA"])),
								ID_DON_VI = (x.IsNull("ID_DON_VI") ? -1 : CIPConvert.ToDecimal(x["ID_DON_VI"])),
								ID_REPORTED_USER = (x.IsNull("ID_REPORTED_USER") ? -1 : CIPConvert.ToDecimal(x["ID_REPORTED_USER"])),
								NOI_DUNG = x["NOI_DUNG"].ToString(),
								NS = (x.IsNull("NS") ? 0 : CIPConvert.ToDecimal(x["NS"])),
								NTCT = (x.IsNull("NTCT") ? 0 : CIPConvert.ToDecimal(x["NTCT"])),
								QUY = (x.IsNull("QUY") ? 0 : CIPConvert.ToDecimal(x["QUY"])),
								REPORT_LEVEL = x["REPORT_LEVEL"].ToString(),
								So_KM = (x.IsNull("So_KM") ? 0 : CIPConvert.ToDecimal(x["So_KM"])),
								STT = x["STT"].ToString(),
								TONG = (x.IsNull("TONG") ? 0 : CIPConvert.ToDecimal(x["TONG"])),
							})
							.ToList();
		}

		private void load_data_to_lst_gd(BKI_QLDTEntities ip_db)
		{
			decimal v_dc_id_don_vi = 103;
			decimal v_dc_id_quyet_dinh = 198;
			string v_str_is_nguon_ns = "N";
			m_lst_gd = ip_db.GD_CHI_TIET_GIAO_KH
				.Where(x => x.ID_DON_VI == v_dc_id_don_vi
					&& x.ID_QUYET_DINH == v_dc_id_quyet_dinh)
				.ToList()
				.Select(x => x.CopyAs<DBClassModel.GD_CHI_TIET_GIAO_KH>())
				.ToList();
		}
		#endregion
	}
}