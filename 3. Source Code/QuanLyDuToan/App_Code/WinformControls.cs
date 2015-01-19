using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using WebDS;
using WebDS.CDBNames;
using WebUS;

namespace QuanLyDuToan.App_Code
{
	public class WinFormControls
	{
		public WinFormControls()
		{
			//
			// TODO: Add constructor logic here
			//

		}

		#region Data Structures
		public enum LOAI_QUYET_DINH
		{
			GIAO_VON = 0,
			GIAO_KE_HOACH = 1,
			TAT_CA = 2
		}

		public enum LOAI_DU_AN
		{
			QUOC_LO = 0,
			KHAC = 1,
		}
		#endregion

		#region Quan ly du toan

		#region LoadDropDownList

		public static void load_data_to_ddl_chuong_loai_khoan_muc(

		  DropDownList op_ddl)
		{
			US_DM_CHUONG_LOAI_KHOAN_MUC v_us = new US_DM_CHUONG_LOAI_KHOAN_MUC();
			DS_DM_CHUONG_LOAI_KHOAN_MUC v_ds = new DS_DM_CHUONG_LOAI_KHOAN_MUC();
			v_us.FillDataset(v_ds);


			op_ddl.DataTextField = DM_CHUONG_LOAI_KHOAN_MUC.TEN;
			op_ddl.DataValueField = DM_CHUONG_LOAI_KHOAN_MUC.ID;
			op_ddl.DataSource = v_ds.DM_CHUONG_LOAI_KHOAN_MUC;
			op_ddl.DataBind();
		}

		public static void load_data_to_ddl_quoc_lo_cong_trinh(
			DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, decimal ip_dc_id_don_Vi
			, decimal ip_dc_id_loai_nhiem_vu
			, DropDownList op_ddl)
		{
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			CStoredProc v_sp = new IP.Core.IPUserService.CStoredProc("pr_DM_CONG_TRINH_DU_AN_GOI_THAU_get_ds_giao_von");
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_Vi);
			v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
			v_sp.fillDataSetByCommand(v_us, v_ds);
			op_ddl.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl.DataBind();
		}

		//public static void load_data_to_ddl_ten_du_an(
		//	DateTime ip_dat_tu_ngay
		//	, DateTime ip_dat_den_ngay
		//	, decimal ip_dc_id_don_Vi
		//	, decimal ip_dc_id_du_an_cong_trinh
		//	, decimal ip_dc_id_loai_nhiem_vu
		//	, DropDownList op_ddl) {
		//	US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
		//	DataSet op_ds = new DataSet();
		//	DataTable op_dt = new DataTable();
		//	op_ds.Tables.Add(op_dt);
		//	CStoredProc v_sp = new IP.Core.IPUserService.CStoredProc("pr_gd_giao_von_get_ten_du_an");
		//	v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
		//	v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
		//	v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_Vi);
		//	v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
		//	v_sp.addDecimalInputParam("@ip_dc_id_du_an_cong_trinh", ip_dc_id_du_an_cong_trinh);
		//	v_sp.fillDataSetByCommand(v_us, op_ds);
		//	//op_ddl.DataTextField = GD_CHI_TIET_GIAO_VON.te;
		//	//op_ddl.DataValueField = GD_CHI_TIET_GIAO_VON.TEN_DU_AN;
		//	op_ddl.DataSource = op_ds.Tables[0];
		//	op_ddl.DataBind();
		//}
		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_kh(LOAI_DU_AN ip_loai_du_an
		, DropDownList op_ddl_quyet_dinh)
		{

			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			string v_str_data_default = "";
			if (ip_loai_du_an == LOAI_DU_AN.QUOC_LO)
			{
				v_str_data_default = "---Chọn quốc lộ---";
			}
			else if (ip_loai_du_an == LOAI_DU_AN.KHAC)
			{
				v_str_data_default = "---Chọn dự án---";
			}
			v_ds.EnforceConstraints = false;
			v_ds.Clear();
			op_ddl_quyet_dinh.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl_quyet_dinh.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

		}

		public static void load_data_to_cbo_cong_trinh_theo_loai_nhiem_vu(
			decimal ip_id_loai_nhiem_vu, DropDownList op_ddl_cong_trinh, decimal ip_dc_id_don_vi)
		{
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			string v_str_data_default = "---Chọn công trình---";

			v_ds.EnforceConstraints = false;
			v_ds.Clear();

			v_us.loadDanhMucCongTrinhTheoNhiemVu(v_ds, ip_dc_id_don_vi, ip_id_loai_nhiem_vu);

			op_ddl_cong_trinh.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl_cong_trinh.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl_cong_trinh.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl_cong_trinh.DataBind();
			op_ddl_cong_trinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
		}

		public static void load_data_to_cbo_du_an_theo_cong_trinh_va_loai_nhiem_vu(decimal ip_id_cong_trinh,
			decimal ip_id_loai_nhiem_vu, DropDownList ddl, decimal ip_dc_id_don_vi)
		{
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			string v_str_data_default = "---Chọn dự án---";

			v_ds.EnforceConstraints = false;
			v_ds.Clear();

			v_us.loadDanhMucDuanTheoCongTrinhVaLoaiNhiemVu(v_ds, ip_dc_id_don_vi, ip_id_cong_trinh, ip_id_loai_nhiem_vu);

			ddl.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			ddl.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			ddl.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			ddl.DataBind();
			ddl.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
		}
		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_von(LOAI_DU_AN ip_dc_id_loai_du_an
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			string v_str_data_default = "";
			v_ds.EnforceConstraints = false;

			op_ddl_quyet_dinh.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl_quyet_dinh.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

		}

		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_von1(decimal ip_dc_id_loai_du_an
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			string v_str_data_default = "";
			v_ds.EnforceConstraints = false;
			if (ip_dc_id_loai_du_an != -1)
			{
				v_str_data_default = "---Chọn quốc lộ---";
				v_us.FillDataset(v_ds, " WHERE ID_LOAI = " + ip_dc_id_loai_du_an);
			}
			else
			{
				v_str_data_default = "---Chọn dự án---";
				v_us.FillDataset(v_ds);
			}
			op_ddl_quyet_dinh.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl_quyet_dinh.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

		}

		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_von2(decimal ip_dc_id_loai_du_an, decimal ip_dc_id_cha
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			string v_str_data_default = "---Chọn dự án---";
			v_ds.EnforceConstraints = false;
			if (ip_dc_id_loai_du_an != -1)
			{
				v_str_data_default = "---Chọn dự án---";
				v_us.FillDataset(v_ds, " WHERE ID_LOAI = " + ip_dc_id_loai_du_an + " AND ID_CHA = " + ip_dc_id_cha);
			}
			//else {
			//	v_str_data_default = "---Chọn dự án---";
			//	v_us.FillDataset(v_ds, " WHERE ID_CHA = " + ip_dc_id_cha);
			//}
			op_ddl_quyet_dinh.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl_quyet_dinh.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
		}
		public static void load_data_to_cbo_dm_uy_nhiem_chi(DropDownList op_ddl, bool ip_b_is_nguon_ns, decimal ip_dc_id_don_vi)
		{
			US_DM_GIAI_NGAN v_us = new WebUS.US_DM_GIAI_NGAN();
			DS_DM_GIAI_NGAN v_ds = new DS_DM_GIAI_NGAN();
			string v_str_is_nguon_ns = "N";
			if (ip_b_is_nguon_ns) v_str_is_nguon_ns = "Y";
			v_us.FillDataset(v_ds, "where id_don_vi=" + ip_dc_id_don_vi + " and is_nguon_ns_yn ='" + v_str_is_nguon_ns + "' order by ngay_thang desc");
			for (int i = 0; i < v_ds.DM_GIAI_NGAN.Count; i++)
			{
				v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.SO_UNC] =
				   CIPConvert.ToStr(v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.NGAY_THANG], "dd/MM/yyyy") + " " + v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.SO_UNC];
				v_ds.AcceptChanges();
			}
			op_ddl.DataTextField = DM_GIAI_NGAN.SO_UNC;
			op_ddl.DataValueField = DM_GIAI_NGAN.ID;
			op_ddl.DataSource = v_ds.DM_GIAI_NGAN;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem("---Chọn UNC---", "-1"));
		}
		public static void load_data_to_cbo_dm_uy_nhiem_chi(
			DropDownList op_ddl
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, bool ip_b_is_nguon_ns
			, decimal ip_dc_id_don_vi
			, string ip_str_text_tat_ca)
		{
			US_DM_GIAI_NGAN v_us = new WebUS.US_DM_GIAI_NGAN();
			DS_DM_GIAI_NGAN v_ds = new DS_DM_GIAI_NGAN();
			string v_str_is_nguon_ns = "N";
			if (ip_b_is_nguon_ns) v_str_is_nguon_ns = "Y";
			v_us.get_dm_uy_nhiem_chi_by_don_vi_va_ngay_thang(v_ds
				, ip_dc_id_don_vi
				, ip_dat_tu_ngay
				, ip_dat_den_ngay
				, v_str_is_nguon_ns);
			for (int i = 0; i < v_ds.DM_GIAI_NGAN.Count; i++)
			{
				v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.SO_UNC] =
				   CIPConvert.ToStr(v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.NGAY_THANG], "dd/MM/yyyy") + " " + v_ds.Tables[0].Rows[i][DM_GIAI_NGAN.SO_UNC];
				v_ds.AcceptChanges();
			}
			op_ddl.DataTextField = DM_GIAI_NGAN.SO_UNC;
			op_ddl.DataValueField = DM_GIAI_NGAN.ID;
			op_ddl.DataSource = v_ds.DM_GIAI_NGAN;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem(ip_str_text_tat_ca, "-1"));
		}
		public static void load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(
			LOAI_QUYET_DINH ip_loai_quyet_dinh
			, DropDownList op_ddl_quyet_dinh)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			DS_DM_QUYET_DINH v_ds = new DS_DM_QUYET_DINH();
			US_DM_QUYET_DINH v_us = new US_DM_QUYET_DINH();
			string v_str_querry = "";
			if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.GIAO_VON)
				v_str_querry = "where "// id_don_vi=" + v_dc_id_don_vi 
					+ "  id_loai_quyet_dinh= " + ID_LOAI_QUYET_DINH.GIAO_VON;
			else if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.GIAO_KE_HOACH)
				v_str_querry = "where "//id_don_vi=" + v_dc_id_don_vi 
					+ " id_loai_quyet_dinh= " + ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
			else if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.TAT_CA)
				v_str_querry = "where";// id_don_vi=" + v_dc_id_don_vi;
			v_str_querry += " order by ngay_thang desc";
			v_us.FillDataset(v_ds, v_str_querry);
			for (int v = 0; v < v_ds.DM_QUYET_DINH.Count; v++)
			{
				v_ds.Tables[0].Rows[v][DM_QUYET_DINH.NOI_DUNG] =
					v_ds.Tables[0].Rows[v][DM_QUYET_DINH.SO_QUYET_DINH] + " " + v_ds.Tables[0].Rows[v][DM_QUYET_DINH.NOI_DUNG];
				v_ds.AcceptChanges();
			}
			op_ddl_quyet_dinh.DataTextField = DM_QUYET_DINH.NOI_DUNG;
			op_ddl_quyet_dinh.DataValueField = DM_QUYET_DINH.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_QUYET_DINH;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem("---Chọn quyết định---", "-1"));
		}
		/// <summary>
		/// Đưa danh sách tất cả các đơn vị vào DropDownList
		/// </summary>
		/// <param name="?"></param>
		/// <param name="ip_e_tat_ca"></param>
		/// <param name="ip_obj_cbo_dv_su_dung"></param>
		public static void load_data_to_cbo_don_vi_su_dung(
			  eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_dv_su_dung)
		{



			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
			DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();


			v_us_dm_don_vi.FillDataset_Load_data_to_grid_danh_muc_don_vi(
				v_ds_dm_don_vi
				, ID_LOAI_DON_VI.DV_SU_DUNG
				, v_str_user_name);

			DataView v_dv_don_vi_su_dung = v_ds_dm_don_vi.DM_DON_VI.DefaultView;
			v_dv_don_vi_su_dung.Sort = DM_DON_VI.TEN_DON_VI + " ASC";

			ip_obj_cbo_dv_su_dung.DataSource = v_dv_don_vi_su_dung.ToTable();
			ip_obj_cbo_dv_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
			ip_obj_cbo_dv_su_dung.DataValueField = DM_DON_VI.ID;
			ip_obj_cbo_dv_su_dung.DataBind();

			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_dv_su_dung.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}
		}


		/// <summary>
		/// Load danh sách các quyết định theo các tiêu chí vào DropDownList đơn vị
		/// </summary>
		/// <param name="ip_dc_id_don_vi"></param>
		/// <param name="ip_dc_id_loai_nhiem_vu"></param>
		/// <param name="ip_dc_id_cong_trinh"></param>
		/// <param name="ip_dc_id_du_an"></param>
		/// <param name="ip_dat_tu_ngay"></param>
		/// <param name="ip_dat_den_ngay"></param>
		/// <param name="ip_str_tu_khoa"></param>
		/// <param name="ip_e_tat_ca"></param>
		/// <param name="ip_obj_cbo_quyet_dinh"></param>
		public static void load_data_to_cbo_quyet_dinh(
		   decimal ip_dc_id_don_vi
			, decimal ip_dc_id_loai_nhiem_vu
			, decimal ip_dc_id_cong_trinh
			, decimal ip_dc_id_du_an
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, string ip_str_tu_khoa
			, eTAT_CA ip_e_tat_ca
			, string ip_str_proc
			, DropDownList ip_obj_cbo_quyet_dinh)
		{



			US_DM_QUYET_DINH v_us_dm_quyet_dinh = new US_DM_QUYET_DINH();
			DS_DM_QUYET_DINH v_ds_dm_quyet_dinh = new DS_DM_QUYET_DINH();
			DataSet v_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_ds.Tables.Add(v_dt);

			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();

			v_ds_dm_quyet_dinh.EnforceConstraints = false;
			v_us_dm_quyet_dinh.get_ds_quyet_dinh(
				v_ds
				, ip_dc_id_don_vi
			, ip_dc_id_loai_nhiem_vu
			, ip_dc_id_cong_trinh
			, ip_dc_id_du_an
			, ip_dat_tu_ngay
			, ip_dat_den_ngay
			, ip_str_tu_khoa
			, ip_str_proc);

			DataView v_dv_quyet_dinh = v_ds.Tables[0].DefaultView;
			//v_dv_quyet_dinh.Sort = DM_QUYET_DINH.SO_QUYET_DINH + " ASC";


			ip_obj_cbo_quyet_dinh.DataSource = v_dv_quyet_dinh.ToTable();
			ip_obj_cbo_quyet_dinh.DataTextField = DM_QUYET_DINH.SO_QUYET_DINH;
			ip_obj_cbo_quyet_dinh.DataValueField = DM_QUYET_DINH.ID;
			ip_obj_cbo_quyet_dinh.DataBind();

			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_quyet_dinh.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}
		}


		public static void load_data_to_cbo_cong_trinh_du_an(
		  decimal ip_dc_id_don_vi
			, decimal ip_id_cong_trinh
		   , decimal ip_dc_id_loai_nhiem_vu
		   , eTAT_CA ip_e_tat_ca
		   , DropDownList ip_obj_cbo_cong_trinh_du_an_goi_thau)
		{



			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us_dm_cong_trinh_du_an_goi_thau = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds_dm_cong_trinh_du_an_goi_thau = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();

			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();


			v_us_dm_cong_trinh_du_an_goi_thau.loadDanhMucDuanTheoCongTrinhVaLoaiNhiemVu(
				v_ds_dm_cong_trinh_du_an_goi_thau

				, ip_dc_id_don_vi
				, ip_id_cong_trinh
			, ip_dc_id_loai_nhiem_vu);

			DataView v_dv_quyet_dinh = v_ds_dm_cong_trinh_du_an_goi_thau.DM_CONG_TRINH_DU_AN_GOI_THAU.DefaultView;
			v_dv_quyet_dinh.Sort = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN + " ASC";

			ip_obj_cbo_cong_trinh_du_an_goi_thau.DataSource = v_dv_quyet_dinh.ToTable();
			ip_obj_cbo_cong_trinh_du_an_goi_thau.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			ip_obj_cbo_cong_trinh_du_an_goi_thau.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			ip_obj_cbo_cong_trinh_du_an_goi_thau.DataBind();

			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_cong_trinh_du_an_goi_thau.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}
		}

		public static void load_data_to_ddl_loai_nhiem_vu_unc(
			DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, decimal ip_dc_id_don_Vi
			, DropDownList op_ddl)
		{
			US_CM_DM_TU_DIEN v_us = new IP.Core.IPUserService.US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
			CStoredProc v_sp = new IP.Core.IPUserService.CStoredProc("pr_cm_dm_tu_dien_get_loai_nhiem_vu_unc");
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_Vi);
			v_sp.fillDataSetByCommand(v_us, v_ds);
			op_ddl.DataTextField = CM_DM_TU_DIEN.TEN;
			op_ddl.DataValueField = CM_DM_TU_DIEN.ID;
			op_ddl.DataSource = v_ds.CM_DM_TU_DIEN;
			op_ddl.DataBind();
		}

		//public static void load_data_to_ddl_quoc_lo_cong_trinh(
		//	DateTime ip_dat_tu_ngay
		//	, DateTime ip_dat_den_ngay
		//	, decimal ip_dc_id_don_Vi
		//	, decimal ip_dc_id_loai_nhiem_vu
		//	, DropDownList op_ddl)
		//{
		//	US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
		//	DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
		//	CStoredProc v_sp = new IP.Core.IPUserService.CStoredProc("pr_DM_CONG_TRINH_DU_AN_GOI_THAU_get_ds_giao_von");
		//	v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
		//	v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
		//	v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_Vi);
		//	v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
		//	v_sp.fillDataSetByCommand(v_us, v_ds);
		//	op_ddl.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
		//	op_ddl.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
		//	op_ddl.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
		//	op_ddl.DataBind();
		//}

		public static void load_data_to_ddl_ten_du_an(
			DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, decimal ip_dc_id_don_Vi
			, decimal ip_dc_id_du_an_cong_trinh
			, decimal ip_dc_id_loai_nhiem_vu
			, DropDownList op_ddl)
		{
			US_DM_CONG_TRINH_DU_AN_GOI_THAU v_us = new US_DM_CONG_TRINH_DU_AN_GOI_THAU();
			DS_DM_CONG_TRINH_DU_AN_GOI_THAU v_ds = new DS_DM_CONG_TRINH_DU_AN_GOI_THAU();
			CStoredProc v_sp = new IP.Core.IPUserService.CStoredProc("pr_get_ds_du_an_from_giao_von");
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_Vi);
			v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
			v_sp.addDecimalInputParam("@ip_dc_id_du_an_cong_trinh", ip_dc_id_du_an_cong_trinh);
			v_sp.fillDataSetByCommand(v_us, v_ds);
			op_ddl.DataTextField = DM_CONG_TRINH_DU_AN_GOI_THAU.TEN;
			op_ddl.DataValueField = DM_CONG_TRINH_DU_AN_GOI_THAU.ID;
			op_ddl.DataSource = v_ds.DM_CONG_TRINH_DU_AN_GOI_THAU;
			op_ddl.DataBind();
		}

		#endregion

		public static void load_data_to_ddl_don_vi_get_list_don_vi_duoc_xem_du_lieu(decimal ip_dc_id_don_vi, DropDownList op_ddl)
		{
			DS_DM_DON_VI v_ds = new DS_DM_DON_VI();
			US_DM_DON_VI v_us = new US_DM_DON_VI();
			v_us.load_danh_sach_don_vi_X_duoc_xem_du_lieu(ip_dc_id_don_vi, v_ds);
			op_ddl.DataValueField = DM_DON_VI.ID;
			op_ddl.DataTextField = DM_DON_VI.TEN_DON_VI;
			op_ddl.DataSource = v_ds.DM_DON_VI;
			op_ddl.DataBind();
		}

		public static DateTime get_dau_nam_form_date(DateTime ip_dat)
		{
			DateTime v_dat_dau_nam = ip_dat.AddDays(-ip_dat.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			return v_dat_dau_nam;
		}
		public static DateTime get_cuoi_nam_form_date(DateTime ip_dat)
		{
			DateTime v_dat_dau_nam = ip_dat.AddDays(-ip_dat.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			return v_dat_dau_nam.AddYears(1);
		}

		public static decimal get_so_tien(string ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_dc_so_tien = 0;
			}
			else if (ip_str_so_tien.Trim().Equals("0"))
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien.Replace(",", "").Replace(".", ""));
			return op_dc_so_tien;
		}
		public static void get_cout_grid_row(Label ip_lbl_name, string ip_str_default_text, int ip_int_count_row)
		{
			ip_lbl_name.Text = ip_str_default_text + " (Có " + ip_int_count_row + " bản ghi)";
		}



		public static void load_data_to_ddl_loai_nhiem_vu(DropDownList op_ddl)
		{
			US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
			v_us.FillDataset(v_ds, "where " + CM_DM_TU_DIEN.ID_LOAI_TU_DIEN + "=" + ID_LOAI_TU_DIEN.LOAI_NHIEM_VU +
				"order by " + CM_DM_TU_DIEN.GHI_CHU);
			string v_str_data_default = "---Chọn loại nhiệm vụ---";

			for (int i = 0; i < v_ds.CM_DM_TU_DIEN.Count; i++)
			{
				v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN] = v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.GHI_CHU].ToString() + " - " +
					v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN];
				v_ds.AcceptChanges();
			}
			op_ddl.DataTextField = CM_DM_TU_DIEN.TEN;
			op_ddl.DataValueField = CM_DM_TU_DIEN.ID;
			op_ddl.DataSource = v_ds.CM_DM_TU_DIEN;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
		}
		public static void load_data_to_ddl_loai_nhiem_vu(DropDownList op_ddl, bool ip_b_is_nguon_ns, bool ip_b_is_chi_du_an)
		{
			/*
			 * Tác dụng: Load dữ liệu Loại nhiệm vụ theo điều kiện sau:
				 * 1. Nguồn Quỹ BT
				 * - Chi Dự án: Dữ liệu A - Bảo dưỡng..., B - Sửa chữa định kỳ, C -.., D -..., E - ..., F - Văn phòng cục
				 * - Chi theo CLKM: như Chi Dự án, mặc định chọn F - Văn phòng Cục  
				 * 2. Nguồn Ngân Sách
				 * - Chi Dự án: A - ..., B - ..., C -..., D - ..., E - ..., F - ...
				 * - Chi theo CLKM: I - Thu, chi, nộp ngân sách phí, lệ phí; II - Dự toán chi ngân sách nhà nước; 
				 * Mặc định chọn II và không cho chọn option khác
			 * Giải pháp:
				 * 1. Fill data vào dataset theo điều kiện trên
				 * 2. Convert lại dữ liệu: ghép tên: Sửa chữa thường xuyên, ghi chú: A -> A - Sửa chữa thường xuyên
				 * 3. Fill data vào dropdownlist
				 * 4. Đặt giá trị mặc định cho dropdownlist
			 */
			US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();

			//1. Fill data vào dataset
			if (ip_b_is_chi_du_an)//Chi Dự án
			{
				v_us.FillDataset(v_ds, "where " + CM_DM_TU_DIEN.ID_LOAI_TU_DIEN + "=" + ID_LOAI_TU_DIEN.LOAI_NHIEM_VU +
				"order by " + CM_DM_TU_DIEN.GHI_CHU);
			}
			else//Chi theo CLKM - Chương Loại Khoản Mục
			{
				if (!ip_b_is_nguon_ns)//Nguồn Quỹ BT
				{
					v_us.FillDataset(v_ds, "where " + CM_DM_TU_DIEN.ID_LOAI_TU_DIEN + "=" + ID_LOAI_TU_DIEN.LOAI_NHIEM_VU +
				"order by " + CM_DM_TU_DIEN.GHI_CHU);
				}
				else//Nguồn Ngân sách
				{
					v_us.FillDataset(v_ds, "where " + CM_DM_TU_DIEN.ID_LOAI_TU_DIEN + "=" + ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS +
				"order by " + CM_DM_TU_DIEN.GHI_CHU);
				}

			}

			//2. Convert dữ liệu
			string v_str_data_default = "---Chọn loại nhiệm vụ---";

			for (int i = 0; i < v_ds.CM_DM_TU_DIEN.Count; i++)
			{
				v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN] = v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.GHI_CHU].ToString() + " - " +
					v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN];
				v_ds.AcceptChanges();
			}
			//3. Fill dữ liệu vào dropdownlist
			op_ddl.DataTextField = CM_DM_TU_DIEN.TEN;
			op_ddl.DataValueField = CM_DM_TU_DIEN.ID;
			op_ddl.DataSource = v_ds.CM_DM_TU_DIEN;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
			op_ddl.Enabled = true;
			//4. Đặt giá trị mặc định cho dropdownlist
			if (!ip_b_is_chi_du_an)//Chi theo CLKM
				if (!ip_b_is_nguon_ns)//Nguồn Quỹ BT
				{
					op_ddl.SelectedValue = ID_LOAI_NHIEM_VU.VAN_PHONG_CUC.ToString();
				}
				else
				{
					op_ddl.SelectedValue = ID_LOAI_NHIEM_VU_NS.DU_TOAN_CHI_NS_NN.ToString();
					op_ddl.Enabled = false;
				}
		}
		public static void load_data_to_ddl_loai_nhiem_vu_ns(DropDownList op_ddl)
		{
			US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds = new DS_CM_DM_TU_DIEN();
			v_us.FillDataset(v_ds, "where " + CM_DM_TU_DIEN.ID_LOAI_TU_DIEN + "=" + ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS +
				"order by " + CM_DM_TU_DIEN.GHI_CHU);
			string v_str_data_default = "---Chọn loại nhiệm vụ---";

			for (int i = 0; i < v_ds.CM_DM_TU_DIEN.Count; i++)
			{
				v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN] = v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.GHI_CHU].ToString() + " - " +
					v_ds.Tables[0].Rows[i][CM_DM_TU_DIEN.TEN];
				v_ds.AcceptChanges();
			}
			op_ddl.DataTextField = CM_DM_TU_DIEN.TEN;
			op_ddl.DataValueField = CM_DM_TU_DIEN.ID;
			op_ddl.DataSource = v_ds.CM_DM_TU_DIEN;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem(v_str_data_default, "-1"));
		}

		public static decimal getTongTienKH(
			DateTime ip_dat_ngay_thang
			, string ip_str_is_nguon_ns_yn
			, decimal ip_dc_id_loai_du_an)
		{
			decimal op_dc_so_tien = 0;
			DateTime v_dat_dau_nam = ip_dat_ngay_thang;
			v_dat_dau_nam = v_dat_dau_nam.AddDays(-v_dat_dau_nam.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			DateTime v_dat_cuoi_nam = v_dat_dau_nam.AddYears(1);
			US_GD_CHI_TIET_GIAO_KH v_us = new WebUS.US_GD_CHI_TIET_GIAO_KH();
			//op_dc_so_tien = v_us.getTongTienKH(Person.get_id_don_vi(), v_dat_dau_nam, v_dat_cuoi_nam, ip_str_is_nguon_ns_yn, ip_dc_id_loai_du_an);
			return op_dc_so_tien;
		}



		public static DataSet get_dataset_muc_tieu_muc_giao_kh(
			DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			US_DM_DON_VI v_us = new WebUS.US_DM_DON_VI();
			CStoredProc v_sp = new CStoredProc("pr_get_chuong_loai_khoan_muc_tieu_muc_giao_kh");
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", v_dc_id_don_vi);
			DataSet op_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_dt.Columns.Add("ID_MIX");
			v_dt.Columns.Add("DISPLAY");
			op_ds.Tables.Add(v_dt);
			op_ds.AcceptChanges();
			v_sp.fillDataSetByCommand(v_us, op_ds);
			return op_ds;
		}
		public static DataSet get_dataset_muc_tieu_muc_giao_von(
			decimal ip_dc_id_loai_nhiem_vu
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			,decimal ip_dc_id_don_vi)
		{
			US_DM_DON_VI v_us = new WebUS.US_DM_DON_VI();
			CStoredProc v_sp = new CStoredProc("pr_get_chuong_loai_khoan_muc_tieu_muc_giao_von");
			v_sp.addDatetimeInputParam("@ip_dat_den_ngay", ip_dat_den_ngay);
			v_sp.addDatetimeInputParam("@ip_dat_tu_ngay", ip_dat_tu_ngay);
			v_sp.addDecimalInputParam("@ip_dc_id_don_vi", ip_dc_id_don_vi);
			v_sp.addDecimalInputParam("@ip_dc_id_loai_nhiem_vu", ip_dc_id_loai_nhiem_vu);
			DataSet op_ds = new DataSet();
			DataTable v_dt = new DataTable();
			v_dt.Columns.Add("ID_MIX");
			v_dt.Columns.Add("DISPLAY");
			op_ds.Tables.Add(v_dt);
			op_ds.AcceptChanges();
			v_sp.fillDataSetByCommand(v_us, op_ds);
			return op_ds;
		}


		#endregion

		#region Public Interfaces
		public enum eTAT_CA
		{
			YES,
			NO
		}

		public enum eLOAI_TU_DIEN
		{

			LOAI_NHIEM_VU
				,
			LOAI_HINH_DON_VI
				,

			LOAI_BAO_CAO


		}



		public static void load_data_to_cbo_loai_hinh_don_vi(
			eLOAI_TU_DIEN ip_e_trang_thai_tai_san
		   , eTAT_CA ip_e_tat_ca
		   , DropDownList ip_obj_cbo_trang_thai)
		{

			US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
			string v_str_loai_trang_thai = "";
			v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LOAI_HINH_DON_VI;
			v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
				v_str_loai_trang_thai
				, CM_DM_TU_DIEN.GHI_CHU
				, v_ds_dm_tu_dien);
			ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
			ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
			ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.MA_TU_DIEN;
			ip_obj_cbo_trang_thai.DataBind();
			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}

		}

		public static void load_data_to_cbo_tu_dien(
			 string ip_str_ma_loai_tu_dien
			, eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_trang_thai)
		{

			US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();

			v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
				ip_str_ma_loai_tu_dien
				, CM_DM_TU_DIEN.GHI_CHU
				, v_ds_dm_tu_dien);

			ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
			ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
			ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
			ip_obj_cbo_trang_thai.DataBind();
			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}

		}



		public static void load_data_to_cbo_don_vi_chu_quan(
			string ip_str_id_bo_tinh
			, eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_dv_chu_quan)
		{
			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
			DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

			if (ip_str_id_bo_tinh.Length == 0)
			{
				ip_obj_cbo_dv_chu_quan.Items.Clear();
				return;
			}

			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
			decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
			v_us_dm_don_vi.FillDataset(
				v_ds_dm_don_vi
				, ID_LOAI_DON_VI.DV_CHU_QUAN

				, v_dc_id_bo_tinh
				, CONST_QLDB.ID_TAT_CA
				, v_str_user_name);

			ip_obj_cbo_dv_chu_quan.DataSource = v_ds_dm_don_vi.DM_DON_VI;
			ip_obj_cbo_dv_chu_quan.DataTextField = DM_DON_VI.TEN_DON_VI;
			ip_obj_cbo_dv_chu_quan.DataValueField = DM_DON_VI.ID;
			ip_obj_cbo_dv_chu_quan.DataBind();
			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_dv_chu_quan.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}

		}

		public static void load_data_to_cbo_bo_tinh(
			 eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_bo_tinh)
		{

			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
			DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

			//v_us_dm_don_vi.FillDataset(v_ds_dm_don_vi, "where ID_LOAI_DON_VI = " + ID_LOAI_DON_VI.BO_TINH);
			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
			v_us_dm_don_vi.FillDataset(
				v_ds_dm_don_vi
				, ID_LOAI_DON_VI.BO_TINH

				, CONST_QLDB.ID_TAT_CA
				, CONST_QLDB.ID_TAT_CA
				, v_str_user_name);

			ip_obj_cbo_bo_tinh.DataSource = v_ds_dm_don_vi.DM_DON_VI;
			ip_obj_cbo_bo_tinh.DataTextField = DM_DON_VI.TEN_DON_VI;
			ip_obj_cbo_bo_tinh.DataValueField = DM_DON_VI.ID;
			ip_obj_cbo_bo_tinh.DataBind();
			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_bo_tinh.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}

		}

		public static void load_data_to_cbo_don_vi_su_dung_theo_loai_hinh(
			string ip_str_loai_hinh_don_vi
			, string ip_str_id_don_vi_chu_quan
			, string ip_str_id_bo_tinh
			 , eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_dv_su_dung
			)
		{
			if (ip_str_id_bo_tinh.Length == 0)
			{
				ip_obj_cbo_dv_su_dung.Items.Clear();
				return;
			}
			if (ip_str_id_don_vi_chu_quan.Length == 0)
			{
				ip_obj_cbo_dv_su_dung.Items.Clear();
				return;
			}

			US_DM_DON_VI v_us_dm_don_vi = new US_DM_DON_VI();
			DS_DM_DON_VI v_ds_dm_don_vi = new DS_DM_DON_VI();

			string v_str_user_name = HttpContext.Current.Session[SESSION.UserName].ToString();
			if (!Person.check_session_valid()) return;
			decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
			decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
			v_us_dm_don_vi.FillDataset(
				v_ds_dm_don_vi
				, ID_LOAI_DON_VI.DV_SU_DUNG
				, v_dc_id_don_vi_chu_quan
				, v_dc_id_bo_tinh
				, ip_str_loai_hinh_don_vi
				, v_str_user_name);
			DataView v_dv_don_vi_su_dung = v_ds_dm_don_vi.DM_DON_VI.DefaultView;
			v_dv_don_vi_su_dung.Sort = DM_DON_VI.TEN_DON_VI + " ASC";

			ip_obj_cbo_dv_su_dung.DataSource = v_dv_don_vi_su_dung.ToTable();
			ip_obj_cbo_dv_su_dung.DataTextField = DM_DON_VI.TEN_DON_VI;
			ip_obj_cbo_dv_su_dung.DataValueField = DM_DON_VI.ID;
			ip_obj_cbo_dv_su_dung.DataBind();

			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_dv_su_dung.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}
		}

		#endregion
	}
}