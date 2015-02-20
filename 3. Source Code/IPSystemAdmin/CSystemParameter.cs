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
using IP.Core.IPException;
using IP.Core.IPData;
using IP.Core.IPUserService;

//NHIỆM VỤ CỦA CLASS
//
//
// đọc các tham số hệ thống
//
//
//
// Intend: lam 4 class de dinh nghia ma tham so moi de dang hon
// Nhung no lai khong strong type khi goi -> doi de sua sau



namespace IP.Core.IPSystemAdmin
{
	public class CSystemParameter
	{
#region PUBLIC INTERFACE
		//Public Shared Function getParamValue(ByVal i_tham_so As SystemParamKey, _
		//                                      ByVal i_phan_he As SubSystemKey) As String
		//    ' ININITALIZATION
		//    If Not m_initialized Then
		//        Initialize()
		//        m_initialized = True
		//    End If
		//    'SEARCH DATA
		//    Try
		//        Dim v_ma_tham_so As String = get_ma_tham_so(i_tham_so)
		//        Dim v_ma_phan_he As String = phan_he.getMa(i_phan_he)
		//        Return get_gia_tri_tham_so(v_ma_phan_he, v_ma_tham_so)
		//    Catch v_e As Exception
		//        Debug.Assert(False, "Không đúng tên dữ liệu, kiểm tra lại xem - csung")
		//    End Try
		//End Function
		
		
		
		
		public static string get_quan_tri_ht_para_value(eSystemAdminSysParaEnum i_eMa_tham_so)
		{
			// ININITALIZATION
			if (!m_initialized)
			{
				Initialize();
				m_initialized = true;
			}
			//SEARCH DATA
			try
			{
				string v_ma_tham_so = CSystemAdminSystemParameter.get_ma_tham_so(i_eMa_tham_so);
				string v_ma_phan_he = PHAN_HE.getMa(SubSystemKey.QUAN_TRI_HE_THONG);
				return get_gia_tri_tham_so(v_ma_phan_he, v_ma_tham_so);
			}
			catch (Exception)
			{
				Debug.Assert(false, "Không đúng tên dữ liệu, kiểm tra lại xem - csung");
			}
			return "";
		}
		
		
#endregion
		
#region CONSTANTS
		
#endregion
		
#region DATA STRUCTURES
		
		public enum SystemParamKey
		{
			SO_GIO_SANG = 0,
			SO_GIO_CHIEU = 1,
			SO_GIO_TOI = 2,
			DIEM_TRUNG_BINH = 3,
			THI_LAI_MAX = 4,
			NAM_KE_TOAN = 5
		}
		
#endregion
		
#region MEMBERS
		private static DS_HT_THAM_SO_HE_THONG m_ds_tham_so;
		private static Hashtable m_ma_tham_so_list;
		private static bool m_initialized = false;
#endregion
		
#region EVENT HANDLERS
		
#endregion
		
#region PRIVATES
		private static void InitializeMaThamSo()
		{
			m_ma_tham_so_list = new Hashtable();
			m_ma_tham_so_list.Add(SystemParamKey.SO_GIO_CHIEU, "SO_GIO_CHIEU");
			m_ma_tham_so_list.Add(SystemParamKey.SO_GIO_SANG, "SO_GIO_SANG");
			m_ma_tham_so_list.Add(SystemParamKey.SO_GIO_TOI, "SO_GIO_TOI");
			m_ma_tham_so_list.Add(SystemParamKey.DIEM_TRUNG_BINH, "DIEM_TRUNG_BINH");
			m_ma_tham_so_list.Add(SystemParamKey.THI_LAI_MAX, "THI_LAI_MAX");
			m_ma_tham_so_list.Add(SystemParamKey.NAM_KE_TOAN, "NAM_KE_TOAN");
		}
		
		private static void Initialize()
		{
			try
			{
				InitializeMaThamSo();
				m_ds_tham_so = new DS_HT_THAM_SO_HE_THONG();
				US_HT_THAM_SO_HE_THONG v_us = new US_HT_THAM_SO_HE_THONG();
				v_us.FillDataset(m_ds_tham_so);
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_handler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_handler.showErrorMessage();
				Debug.Assert(true, "Không khởi tạo được tham số HT - csung");
			}
		}
		
		private static string get_ma_tham_so(SystemParamKey i_tham_so)
		{
			string v_result = "";
			try
			{
				v_result = Convert.ToString(m_ma_tham_so_list[i_tham_so]);
			}
			catch
			{
				Debug.Assert(true, "Không có tham số như vậy");
			}
			return v_result;
		}
		
		private static string get_gia_tri_tham_so(string i_ma_phan_he, string i_ma_tham_so)
		{
			try
			{
				string v_sqlFilter = "";
				v_sqlFilter = "PHAN_HE = " + "\'" + i_ma_phan_he + "\'";
				v_sqlFilter += " and MA_THAM_SO = " + "\'" + i_ma_tham_so + "\'";
				DataView v_dv = m_ds_tham_so.HT_THAM_SO_HE_THONG.DefaultView;
				v_dv.RowFilter = v_sqlFilter;
				DataRowView v_drv = default(DataRowView);
				string v_result = "";
				foreach (DataRowView tempLoopVar_v_drv in v_dv)
				{
					v_drv = tempLoopVar_v_drv;
					v_result = CNull.RowNVLString(v_drv.Row, "GIA_TRI", "");
				}
				return v_result;
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
				Debug.Assert(true, "Không tìm thấy tham số, kiểm tra lại");
			}
			return "";
		}
#endregion
		
#region INNER CLASSES
		
#endregion
		
	}
	
	
	
}
