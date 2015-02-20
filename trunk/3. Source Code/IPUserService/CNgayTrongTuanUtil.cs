// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPException;




namespace IP.Core.IPUserService
{
	public class CNgayTrongTuanUtil
	{
		
#region DataStructures
		
		public enum Enum_NgayTrongTuan
		{
			THU_HAI = 0,
			THU_BA = 1,
			THU_TU = 2,
			THU_NAM = 3,
			THU_SAU = 4,
			THU_BAY = 5,
			CHU_NHAT = 6
		}
		
		
#endregion
		
#region Private
		private static void Initialize_NgayTrongTuan()
		{
			try
			{
				US_HT_NGAY_TRONG_TUAN v_us_ht_ngay_trong_tuan = new US_HT_NGAY_TRONG_TUAN();
				DS_HT_NGAY_TRONG_TUAN v_ds_ngaytrongtuan = new DS_HT_NGAY_TRONG_TUAN();
				v_us_ht_ngay_trong_tuan.FillDataset(v_ds_ngaytrongtuan);
				m_View_NgayTrongTuan = new DataView(v_ds_ngaytrongtuan.HT_NGAY_TRONG_TUAN);
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_handler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_handler.showErrorMessage();
			}
			
		}
		
		private static string getMaNgay(Enum_NgayTrongTuan i_ngay)
		{
			string v_result = "";
			switch (i_ngay)
			{
				case Enum_NgayTrongTuan.CHU_NHAT:
					v_result = MA_NGAY_TRONG_TUAN.CHU_NHAT;
					break;
				case Enum_NgayTrongTuan.THU_HAI:
					v_result = MA_NGAY_TRONG_TUAN.THU_HAI;
					break;
				case Enum_NgayTrongTuan.THU_BA:
					v_result = MA_NGAY_TRONG_TUAN.THU_BA;
					break;
				case Enum_NgayTrongTuan.THU_TU:
					v_result = MA_NGAY_TRONG_TUAN.THU_TU;
					break;
				case Enum_NgayTrongTuan.THU_NAM:
					v_result = MA_NGAY_TRONG_TUAN.THU_NAM;
					break;
				case Enum_NgayTrongTuan.THU_SAU:
					v_result = MA_NGAY_TRONG_TUAN.THU_SAU;
					break;
				case Enum_NgayTrongTuan.THU_BAY:
					v_result = MA_NGAY_TRONG_TUAN.THU_BAY;
					break;
			}
			return v_result;
		}
#endregion
		
#region Members
		private static DataView m_View_NgayTrongTuan;
		private static bool m_Initialized = false;
#endregion
		
#region PUBLIC INTERFACE
		
		public static US_HT_NGAY_TRONG_TUAN getNgayTrongTuan(Enum_NgayTrongTuan i_ngay)
		{
			try
			{
				if (!m_Initialized)
				{
					Initialize_NgayTrongTuan();
					m_Initialized = true;
				}
				m_View_NgayTrongTuan.RowFilter = "Ma =" + "\'" + getMaNgay(i_ngay) + "\'";
				DataRowView v_drv = default(DataRowView);
				US_HT_NGAY_TRONG_TUAN v_us_result = new US_HT_NGAY_TRONG_TUAN();
				foreach (DataRowView tempLoopVar_v_drv in m_View_NgayTrongTuan)
				{
					v_drv = tempLoopVar_v_drv;
					v_us_result.DataRow2Me(v_drv.Row);
				}
				return v_us_result;
			}
			catch
			{
				Debug.Assert(false, "Không lấy được ngày - csung ");
			}
			return default(US_HT_NGAY_TRONG_TUAN);
		}
		
		
#endregion
		
#region Inner Classes
		private class MA_NGAY_TRONG_TUAN
		{
			
			public const string CHU_NHAT = "CHU_NHAT";
			public const string THU_BA = "THU_BA";
			public const string THU_BAY = "THU_BAY";
			public const string THU_HAI = "THU_HAI";
			public const string THU_NAM = "THU_NAM";
			public const string THU_SAU = "THU_SAU";
			public const string THU_TU = "THU_TU";
		}
		
		
		
#endregion
	}
	
	
}
