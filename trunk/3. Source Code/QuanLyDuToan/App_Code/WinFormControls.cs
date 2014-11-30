using System;
using System.Web.SessionState;
using System.Web;

using WebDS;
using WebUS;
using WebUS;
using WebDS.CDBNames;
using QltsForm;
using IP.Core.IPCommon;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPData.DBNames;

using System.Web.UI.WebControls;
using System.Data;
using WebDS.CDBNames;


namespace IP.Core.WinFormControls
{
	/// <summary>
	/// Summary description for ApplicationControls.
	/// </summary>
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
		public static void get_cout_grid_row(Label ip_lbl_name, string ip_str_default_text, int ip_int_count_row)
		{
			ip_lbl_name.Text = ip_str_default_text + " (Có " + ip_int_count_row + " bản ghi)";
		}
		public static void load_data_to_cbo_dm_uy_nhiem_chi(DropDownList op_ddl)
		{
			US_DM_UY_NHIEM_CHI v_us = new WebUS.US_DM_UY_NHIEM_CHI();
			DS_DM_UY_NHIEM_CHI v_ds = new DS_DM_UY_NHIEM_CHI();
			v_us.FillDataset(v_ds, "where id_don_vi=" + Person.get_id_don_vi() + " order by ngay_thang desc");
			for (int i = 0; i < v_ds.DM_UY_NHIEM_CHI.Count; i++)
			{
				v_ds.Tables[0].Rows[i][DM_UY_NHIEM_CHI.SO_UNC] =
				   CIPConvert.ToStr(v_ds.Tables[0].Rows[i][DM_UY_NHIEM_CHI.NGAY_THANG], "dd/MM/yyyy") + " " + v_ds.Tables[0].Rows[i][DM_UY_NHIEM_CHI.SO_UNC];
				v_ds.AcceptChanges();
			}
			op_ddl.DataTextField = DM_UY_NHIEM_CHI.SO_UNC;
			op_ddl.DataValueField = DM_UY_NHIEM_CHI.ID;
			op_ddl.DataSource = v_ds.DM_UY_NHIEM_CHI;
			op_ddl.DataBind();
			op_ddl.Items.Insert(0, new ListItem("---Chọn UNC---", "-1"));
		}
		public static void load_data_to_cbo_quyet_dinh_by_loai_quyet_dinh(
			LOAI_QUYET_DINH ip_loai_quyet_dinh
			, DropDownList op_ddl_quyet_dinh)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			DS_GD_QUYET_DINH v_ds = new DS_GD_QUYET_DINH();
			US_GD_QUYET_DINH v_us = new US_GD_QUYET_DINH();
			string v_str_querry = "";
			if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.GIAO_VON)
				v_str_querry = "where id_don_vi=" + v_dc_id_don_vi + " and id_loai_quyet_dinh= " + ID_LOAI_QUYET_DINH.GIAO_VON;
			else if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.GIAO_KE_HOACH)
				v_str_querry = "where id_don_vi=" + v_dc_id_don_vi + " and id_loai_quyet_dinh= " + ID_LOAI_QUYET_DINH.GIAO_KE_HOACH;
			else if (ip_loai_quyet_dinh == LOAI_QUYET_DINH.TAT_CA)
				v_str_querry = "where id_don_vi=" + v_dc_id_don_vi;
			v_str_querry += " order by ngay_thang desc";
			v_us.FillDataset(v_ds, v_str_querry);
			for (int v = 0; v < v_ds.GD_QUYET_DINH.Count; v++)
			{
				v_ds.Tables[0].Rows[v][GD_QUYET_DINH.NOI_DUNG] =
					v_ds.Tables[0].Rows[v][GD_QUYET_DINH.SO_QUYET_DINH] + " " + v_ds.Tables[0].Rows[v][GD_QUYET_DINH.NOI_DUNG];
				v_ds.AcceptChanges();
			}
			op_ddl_quyet_dinh.DataTextField = GD_QUYET_DINH.NOI_DUNG;
			op_ddl_quyet_dinh.DataValueField = GD_QUYET_DINH.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.GD_QUYET_DINH;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem("---Chọn quyết định---", "-1"));
		}
		public static void load_data_to_cbo_du_an_cong_trinh(
			LOAI_DU_AN ip_loai_du_an
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_DU_AN_CONG_TRINH v_ds = new DS_DM_DU_AN_CONG_TRINH();
			US_DM_DU_AN_CONG_TRINH v_us = new US_DM_DU_AN_CONG_TRINH();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			string v_str_data_default = "";
			string v_str_querry = "";
			if (ip_loai_du_an == LOAI_DU_AN.QUOC_LO)
			{
				v_str_querry = "where id_loai_du_an_cong_trinh= " + ID_LOAI_DU_AN.QUOC_LO;
				v_str_data_default = "---Chọn quốc lộ---";
			}
			else if (ip_loai_du_an == LOAI_DU_AN.KHAC)
			{
				v_str_querry = "where id_don_vi=" + v_dc_id_don_vi + " and id_loai_du_an_cong_trinh= " + ID_LOAI_DU_AN.KHAC;
				v_str_data_default = "---Chọn dự án---";
			}
			v_us.FillDataset(v_ds, v_str_querry);
			op_ddl_quyet_dinh.DataTextField = DM_DU_AN_CONG_TRINH.TEN_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataValueField = DM_DU_AN_CONG_TRINH.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

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
			US_GD_GIAO_KH v_us = new WebUS.US_GD_GIAO_KH();
			op_dc_so_tien = v_us.getTongTienKH(Person.get_id_don_vi(), v_dat_dau_nam, v_dat_cuoi_nam, ip_str_is_nguon_ns_yn, ip_dc_id_loai_du_an);
			return op_dc_so_tien;
		}
		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_kh(LOAI_DU_AN ip_loai_du_an
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, string ip_str_tu_khoa
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_DU_AN_CONG_TRINH v_ds = new DS_DM_DU_AN_CONG_TRINH();
			US_DM_DU_AN_CONG_TRINH v_us = new US_DM_DU_AN_CONG_TRINH();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			decimal v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.QUOC_LO;
			string v_str_data_default = "";
			if (ip_loai_du_an == LOAI_DU_AN.QUOC_LO)
			{
				v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.QUOC_LO;
				v_str_data_default = "---Chọn quốc lộ---";
			}
			else if (ip_loai_du_an == LOAI_DU_AN.KHAC)
			{
				v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.KHAC;
				v_str_data_default = "---Chọn dự án---";
			}
			v_ds.EnforceConstraints = false;
			v_ds.Clear();
			v_us.getDuAnCongTrinhGiaoKHByDate(v_ds
				, v_dc_id_don_vi
				, v_dc_id_loai_cong_trinh
				, ip_dat_tu_ngay
				, ip_dat_den_ngay
				, ip_str_tu_khoa);
			op_ddl_quyet_dinh.DataTextField = DM_DU_AN_CONG_TRINH.TEN_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataValueField = DM_DU_AN_CONG_TRINH.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

		}
		public static void load_data_to_cbo_du_an_cong_trinh_from_giao_von(LOAI_DU_AN ip_loai_du_an
			, DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay
			, string ip_str_tu_khoa
			, DropDownList op_ddl_quyet_dinh)
		{
			DS_DM_DU_AN_CONG_TRINH v_ds = new DS_DM_DU_AN_CONG_TRINH();
			US_DM_DU_AN_CONG_TRINH v_us = new US_DM_DU_AN_CONG_TRINH();
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			decimal v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.QUOC_LO;
			string v_str_data_default = "";
			if (ip_loai_du_an == LOAI_DU_AN.QUOC_LO)
			{
				v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.QUOC_LO;
				v_str_data_default = "---Chọn quốc lộ---";
			}
			else if (ip_loai_du_an == LOAI_DU_AN.KHAC)
			{
				v_dc_id_loai_cong_trinh = ID_LOAI_DU_AN.KHAC;
				v_str_data_default = "---Chọn dự án---";
			}
			v_us.getDuAnCongTrinhGiaoVonByDate(v_ds
				, v_dc_id_don_vi
				, v_dc_id_loai_cong_trinh
				, ip_dat_tu_ngay
				, ip_dat_den_ngay
				, ip_str_tu_khoa);
			op_ddl_quyet_dinh.DataTextField = DM_DU_AN_CONG_TRINH.TEN_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataValueField = DM_DU_AN_CONG_TRINH.ID;
			op_ddl_quyet_dinh.DataSource = v_ds.DM_DU_AN_CONG_TRINH;
			op_ddl_quyet_dinh.DataBind();
			op_ddl_quyet_dinh.Items.Insert(0, new ListItem(v_str_data_default, "-1"));

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
			DateTime ip_dat_tu_ngay
			, DateTime ip_dat_den_ngay)
		{
			decimal v_dc_id_don_vi = Person.get_id_don_vi();
			US_DM_DON_VI v_us = new WebUS.US_DM_DON_VI();
			CStoredProc v_sp = new CStoredProc("pr_get_chuong_loai_khoan_muc_tieu_muc_giao_von");
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


		#endregion

		#region Public Interfaces
		public enum eTAT_CA
		{
			YES,
			NO
		}

		public enum eLOAI_TU_DIEN
		{
			TRANG_THAI_DAT
				,
			TRANG_THAI_NHA
				,
			TRANG_THAI_OTO
				,
			TRANG_THAI_TAI_SAN_KHAC
				,
			LOAI_HINH_DON_VI
				,
			PHAN_LOAI_TAI_SAN
				,
			LOAI_BAO_CAO
				,
			TINH_TRANG_TAI_SAN
				, LY_DO_TANG_GIAM_TS
		}

		public enum eLOAI_TANG_GIAM_TAI_SAN
		{
			TANG_TAI_SAN
			, GIAM_TAI_SAN
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
			 eLOAI_TU_DIEN ip_e_trang_thai_tai_san
			, eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_trang_thai)
		{

			US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
			string v_str_loai_trang_thai = "";
			switch (ip_e_trang_thai_tai_san)
			{
				case eLOAI_TU_DIEN.TRANG_THAI_DAT:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_DAT;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_NHA:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_NHA;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_OTO:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_OTO;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC;
					break;
				case eLOAI_TU_DIEN.LOAI_HINH_DON_VI:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LOAI_HINH_DON_VI;
					break;
				case eLOAI_TU_DIEN.PHAN_LOAI_TAI_SAN:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.PHAN_LOAI_TAI_SAN;
					break;
				case eLOAI_TU_DIEN.LOAI_BAO_CAO:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LOAI_BAO_CAO;
					break;
				case eLOAI_TU_DIEN.TINH_TRANG_TAI_SAN:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TINH_TRANG_TAI_SAN;
					break;
				case eLOAI_TU_DIEN.LY_DO_TANG_GIAM_TS:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LY_DO_TANG_GIAM_TS;
					break;
			}
			v_us_dm_tu_dien.fill_tu_dien_cung_loai_ds(
				v_str_loai_trang_thai
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

		public static void load_data_to_cbo_trang_thai_tang_giam(
			 eLOAI_TU_DIEN ip_e_trang_thai_tai_san
			, eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_trang_thai)
		{
			US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
			string v_str_loai_trang_thai = "";
			switch (ip_e_trang_thai_tai_san)
			{
				case eLOAI_TU_DIEN.TRANG_THAI_DAT:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_DAT;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_NHA:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_NHA;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_OTO:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_OTO;
					break;
				case eLOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC:
					v_str_loai_trang_thai = MA_LOAI_TU_DIEN.TRANG_THAI_TAI_SAN_KHAC;
					break;
			}

			string v_str_query = "WHERE GHI_CHU LIKE N'%2%'"
				+ " AND ID_LOAI_TU_DIEN IN"
				+ " (SELECT ID FROM CM_DM_LOAI_TD WHERE MA_LOAI = '" + v_str_loai_trang_thai + "')";

			v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, v_str_query);
			ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
			ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
			ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
			ip_obj_cbo_trang_thai.DataBind();
			if (ip_e_tat_ca == eTAT_CA.YES)
			{
				ip_obj_cbo_trang_thai.Items.Insert(0, new ListItem(CONST_QLDB.TAT_CA, CONST_QLDB.ID_TAT_CA.ToString()));
			}
		}

		public static void load_data_to_cbo_ly_do_tang_giam(
			eLOAI_TU_DIEN ip_e_trang_thai_tai_san
			, eLOAI_TANG_GIAM_TAI_SAN ip_e_loai
			, DropDownList ip_obj_cbo_trang_thai)
		{
			US_CM_DM_TU_DIEN v_us_dm_tu_dien = new US_CM_DM_TU_DIEN();
			DS_CM_DM_TU_DIEN v_ds_dm_tu_dien = new DS_CM_DM_TU_DIEN();
			string v_str_loai_trang_thai = MA_LOAI_TU_DIEN.LY_DO_TANG_GIAM_TS;
			string v_str_loai_tg = "";

			switch (ip_e_loai)
			{
				case eLOAI_TANG_GIAM_TAI_SAN.GIAM_TAI_SAN:
					v_str_loai_tg = "G";
					break;
				case eLOAI_TANG_GIAM_TAI_SAN.TANG_TAI_SAN:
					v_str_loai_tg = "T";
					break;
			}

			string v_str_query = "WHERE GHI_CHU LIKE N'%" + v_str_loai_tg + "%'"
				+ " AND ID_LOAI_TU_DIEN IN"
				+ " (SELECT ID FROM CM_DM_LOAI_TD WHERE MA_LOAI = '" + v_str_loai_trang_thai + "')";

			v_us_dm_tu_dien.FillDataset(v_ds_dm_tu_dien, v_str_query);
			ip_obj_cbo_trang_thai.DataSource = v_ds_dm_tu_dien.CM_DM_TU_DIEN;
			ip_obj_cbo_trang_thai.DataTextField = CM_DM_TU_DIEN.TEN;
			ip_obj_cbo_trang_thai.DataValueField = CM_DM_TU_DIEN.ID;
			ip_obj_cbo_trang_thai.DataBind();

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

		public static void load_data_to_cbo_don_vi_su_dung(

			string ip_str_id_don_vi_chu_quan
			, string ip_str_id_bo_tinh
			 , eTAT_CA ip_e_tat_ca
			, DropDownList ip_obj_cbo_dv_su_dung)
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

			decimal v_dc_id_don_vi_chu_quan = CIPConvert.ToDecimal(ip_str_id_don_vi_chu_quan);
			decimal v_dc_id_bo_tinh = CIPConvert.ToDecimal(ip_str_id_bo_tinh);
			v_us_dm_don_vi.FillDataset(
				v_ds_dm_don_vi
				, ID_LOAI_DON_VI.DV_SU_DUNG

				, v_dc_id_don_vi_chu_quan
				, v_dc_id_bo_tinh
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
