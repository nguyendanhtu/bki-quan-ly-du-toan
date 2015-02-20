using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;

using IP.Core.IPCommon;
using IP.Core.IPException;
using IP.Core.IPUserService;
//NHIỆM VỤ CỦA CLASS
//
//
// Lấy các description của 1 loại từ điển
// Phục vụ cho điền dữ liệu
//
//
namespace IP.Core.IPSystemAdmin
{
	public class CDictionaryDesc
	{

		CListOfDataFromDB m_list_of_desc;
		public CDictionaryDesc(string strLoaiTuDien, System.Data.SqlClient.SqlTransaction i_trans = null)
		{

			US_CM_DM_TU_DIEN v_us = new US_CM_DM_TU_DIEN();
			if (!(i_trans == null))
			{
				v_us.SetTransaction(i_trans);
			}
			IP.Core.IPData.DS_CM_DM_TU_DIEN v_ds = v_us.getLoaiTuDienDS(strLoaiTuDien);
			m_list_of_desc = new CListOfDataFromDB(v_ds, "MA_TU_DIEN", "TEN_NGAN");
		}

		public string getDesc(string strMaTuDien)
		{
			return Convert.ToString(m_list_of_desc[strMaTuDien]);
		}

	}

}
