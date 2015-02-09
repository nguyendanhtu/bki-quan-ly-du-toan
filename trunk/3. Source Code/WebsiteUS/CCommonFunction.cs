using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace WebUS
{
	public static class CCommonFunction
	{
		public static decimal get_money_number(object ip_str_so_tien)
		{
			decimal op_dc_so_tien = 0;
			if (ip_str_so_tien == DBNull.Value)
			{
				op_dc_so_tien = 0;
			}
			else op_dc_so_tien = CIPConvert.ToDecimal(ip_str_so_tien);
			return op_dc_so_tien;
		}

	}
}
