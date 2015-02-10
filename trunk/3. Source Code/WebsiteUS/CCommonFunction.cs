using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebUS
{
	public class CParaQueryString
	{
		public string strName;
		public string strValue;

		public CParaQueryString(string ip_strName, string ip_strValue)
		{
			strName=ip_strName;
			strValue=ip_strValue;
		}
	}
	public class CCommonFunction
	{
		
		public static string genQueryString(string ip_str_form, CParaQueryString[] ip_arr_para)
		{
			/*Mục đích: Trả về chuỗi query string
			 vd: genQueryString("F157",CParaQueryString[]
			 * {
			 *	new CParaQueryString("ip_dc_id_don_vi","5")
			 *	,new CParaQueryString("ip_str_nguon_ns","N")
			 * }
			 * Kết quả: F157?ip_dc_id_don_vi=5&ip_str_nguon_ns=N
			 */
			string op_str_query_string = ip_str_form+"?";
			for (int i = 0; i < ip_arr_para.Length; i++)
			{
				op_str_query_string+="&"+ip_arr_para[i].strName+"="+ip_arr_para[i].strValue;
			}
			return op_str_query_string;
		}
		public static decimal getMoney_number(object ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien == DBNull.Value)
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
			return op_dc_so_tien;
		}

		public static string getMoney_string_format(string ip_str_so_tien)
		{
			/*Return string Money with format #,###,##*/
			string op_str_so_tien = "";
			if (ip_str_so_tien.Trim().Equals("") | ip_str_so_tien.Trim().Equals("-1"))
			{
				op_str_so_tien = "";
			}
			else op_str_so_tien = CIPConvert.ToStr(CIPConvert.ToDecimal(ip_str_so_tien), "#,###,##");
			return op_str_so_tien;
		}

		public static DateTime getDate_dau_nam_from_date(DateTime ip_dat)
		{
			DateTime v_dat_dau_nam = ip_dat.AddDays(-ip_dat.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			return v_dat_dau_nam;
		}

		public static DateTime getDate_cuoi_nam_form_date(DateTime ip_dat)
		{
			DateTime v_dat_dau_nam = ip_dat.AddDays(-ip_dat.Day + 1);
			v_dat_dau_nam = v_dat_dau_nam.AddMonths(-v_dat_dau_nam.Month + 1);
			return v_dat_dau_nam.AddYears(1);
		}
	}
}
