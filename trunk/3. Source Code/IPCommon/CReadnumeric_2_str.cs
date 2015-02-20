// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class CRead
	{
		
		
		public static string ChuyenSo(string i_str_gia_tri_so)
		{
			string[] so = new string[] {"không", "một", "hai", "ba", "bốn", "lăm", "sáu", "bảy", "tám", "chín", "mười"};
			string[] hang = new string[] {"trăm", "nghìn", "triệu", "tỷ"};
			ArrayList @void = new ArrayList();
			byte i = 0;
			long du = 0;
			long thuong = 0;
			bool kt1 = false;
			string ch = "";
			long v_l_value_of_string = 0;
			string s = "";
			i = (byte) 0;
			if (!Information.IsNumeric(i_str_gia_tri_so))
			{
				return "";
			}
			@void.Clear();
			v_l_value_of_string = (long) (Conversion.Val(i_str_gia_tri_so));
			ch = (v_l_value_of_string).ToString();
			i_str_gia_tri_so = chuan_hoa_chuoi_so(ch);
			
			s = "";
			if (v_l_value_of_string >= 0 && v_l_value_of_string <= 10)
			{
				if (v_l_value_of_string == 5)
				{
					s = "năm";
				}
				else
				{
					s = so[v_l_value_of_string];
				}
				
				@void.Add(v_l_value_of_string);
			}
			else
			{
				while (v_l_value_of_string != 0)
				{
					i++;
					du = v_l_value_of_string % 10;
					thuong = v_l_value_of_string / 10;
					if (i % 3 == 1 && du == 0 && thuong % 10 > 1)
					{
						s = "Mươi" + " " + s;
						@void.Add(21);
					}
					else if (i % 3 == 1 && du == 0 && thuong % 10 == 0)
					{
						kt1 = false;
					}
					else if (i % 3 == 1 && du != 0 && thuong != 0 && thuong % 10 == 0)
					{
						s = "linh" + " " + so[du] + " " + s;
						@void.Add(du);
						@void.Add(26);
						kt1 = true;
					}
					else if (i % 3 == 1 && du != 0)
					{
						if (thuong % 10 > 1)
						{
							if (du == 1)
							{
								s = "mươi" + " " + "mốt" + " " + s;
								@void.Add(20);
								@void.Add(21);
							}
							else
							{
								s = "mươi" + " " + so[du] + " " + s;
								@void.Add(du);
								@void.Add(21);
							}
						}
						else
						{
							if (du == 5 && thuong == 0)
							{
								s = "năm" + " " + s;
								@void.Add(5);
							}
							else
							{
								s = so[du] + " " + s;
								@void.Add(du);
							}
						}
						kt1 = true;
					}
					else if (i % 3 == 2 && du != 0 && thuong != 0 && thuong % 10 == 0)
					{
						if (du > 1 && du != 5)
						{
							s = so[0] + " " + hang[0] + " " + so[du] + " " + s;
							@void.Add(du);
							@void.Add(22);
							@void.Add(0);
						}
						else if (du == 5)
						{
							s = so[0] + " " + hang[0] + " " + "năm" + " " + s;
							@void.Add(5);
							@void.Add(22);
							@void.Add(0);
						}
						else
						{
							s = so[0] + " " + hang[0] + " " + so[10] + " " + s;
							@void.Add(10);
							@void.Add(22);
							@void.Add(0);
						}
						kt1 = false;
					}
					else if (i % 3 == 2 && du != 0 && thuong != 0)
					{
						if (du > 1 && du != 5)
						{
							s = hang[0] + " " + so[du] + " " + s;
							@void.Add(du);
							@void.Add(22);
						}
						else if (du == 5)
						{
							s = hang[0] + " " + "năm" + " " + s;
							@void.Add(5);
							@void.Add(22);
						}
						else
						{
							s = hang[0] + " " + so[10] + " " + s;
							@void.Add(10);
							@void.Add(22);
						}
					}
					else if (i % 3 == 2 && du == 0 && thuong % 10 != 0)
					{
						s = hang[0] + " " + s;
						@void.Add(22);
					}
					else if (i % 3 == 2 && du == 0 && thuong != 0 && thuong % 10 == 0 && kt1 == true)
					{
						s = so[0] + " " + hang[0] + " " + s;
						@void.Add(22);
						@void.Add(0);
						kt1 = false;
					}
					else if (i % 3 == 2 && du != 0 && thuong == 0)
					{
						if (du > 1 && du != 5)
						{
							s = so[du] + " " + s;
							@void.Add(du);
						}
						else if (du == 5)
						{
							s = "năm" + " " + s;
							@void.Add(5);
						}
						else
						{
							s = so[10] + " " + s;
							@void.Add(10);
						}
					}
					else if (i % 3 == 0 && du != 0 && thuong != 0 && thuong % 1000 != 0)
					{
						if (du == 5)
						{
							s = hang[i / 3] + " " + "năm" + " " + s;
							@void.Add(5);
						}
						else
						{
							s = hang[i / 3] + " " + so[du] + " " + s;
							@void.Add(du);
						}
						@void.Add(22 + i / 3);
					}
					else if (i % 3 == 0 && du == 0 && thuong % 1000 != 0)
					{
						s = hang[i / 3] + " " + s;
						@void.Add(22 + i / 3);
					}
					else if (i % 3 == 0 && du != 0)
					{
						if (du == 5)
						{
							s = "năm" + " " + s;
							@void.Add(5);
						}
						else
						{
							s = so[du] + " " + s;
							@void.Add(du);
						}
					}
					v_l_value_of_string = thuong;
				}
			}
			if (s.Length > 0)
			{
				s = System.Convert.ToString(s.Substring(0, 1).ToUpper() + s.Substring(1));
			}
			return s + " đồng";
			
			
			
		}
		private static string chuan_hoa_chuoi_so(string i_str_chuoi_so)
		{
			//example : 1234->1.234
			int v_i_count = 0;
			string v_str_result = i_str_chuoi_so;
			v_i_count = v_str_result.Length;
			v_i_count = v_i_count - 3;
			while (v_i_count > 0)
			{
				v_str_result = v_str_result.Insert(v_i_count, ".");
				v_i_count = v_i_count - 3;
			}
			return v_str_result;
		}
	}
}
