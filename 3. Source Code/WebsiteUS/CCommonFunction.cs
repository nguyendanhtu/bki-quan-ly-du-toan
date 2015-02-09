using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebUS
{
	public class CCommonFunction
	{
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
