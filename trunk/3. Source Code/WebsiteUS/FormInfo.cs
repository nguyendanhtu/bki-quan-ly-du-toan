using System;
using System.Collections.Generic;
using System.Text;

namespace WebUS
{
	public class FormInfo
	{

		public class QueryString
		{
			public const string ID_DON_VI = "ip_dc_id_don_vi";
			public const string TU_NGAY = "ip_dat_tu_ngay";
			public const string DEN_NGAY = "ip_dat_den_ngay";
			public const string ID_LOAI_NHIEM_VU = "ip_dc_id_loai_nhiem_vu";
			public const string ID_CONG_TRINH = " ip_dc_id_cong_trinh";
			public const string ID_DU_AN = "ip_dc_id_du_an";
			public const string NGUON_NGAN_SACH = "ip_nguon_ns";
			public const string ID_GIAI_NGAN = "ip_dc_id_dm_giai_ngan";
			public static string ID_QUYET_DINH = "ip_dc_id_quyet_dinh";
		}

		public class FormName
		{
			public const string F350 = "F350_tinh_hinh_giai_ngan.aspx";
			public const string F157 = "F157_giao_ke_hoach_theo_quyet_dinh.aspx";
			public const string F257 = "F257_giao_von_theo_quyet_dinh.aspx";
			public const string F357 = "F357_giai_ngan_theo_uy_nhiem_chi.aspx";
		}

		public class FormRedirect
		{
			public const string F600 = "~/ChucNang/F600_print_unc_qbt.aspx";
		}


		public class ExportExcelReportName
		{
			public const string F530 = "BaoCaoTinhHinhGiaiNganCacDonVi.xls";
			public const string F350 = "BaoCaoTinhHinhGiaiNgan.xls";
			public const string F157 = "BaoCaoTinhHinhGiaoKeHoach.xls";
			public const string F257 = "BaoCaoTinhHinhGiaoVon.xls";
			public const string F357 = "BaoCaoTinhHinhGiaiNgan.xls";
			public const string F190 = "BaoCaoGiaoKeHoachTheoQuyetDinh.xls";
			public const string F290 = "BaoCaoGiaoVonTheoQuyetDinh.xls";
			public const string F390 = "BaoCaoGiaiNganTheoUyNhiemChi.xls";

		}
	}
}
