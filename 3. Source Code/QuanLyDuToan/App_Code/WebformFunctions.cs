using IP.Core.IPCommon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace QuanLyDuToan.App_Code
{
	#region Object
	public class CellInfoHeader
	{
		public int RowSpan;
		public int ColumnSpan;
		public string Text;

		public CellInfoHeader(string Text, int RowSpan, int ColumnSpan)
		{
			this.Text = Text;
			this.RowSpan = RowSpan;
			this.ColumnSpan = ColumnSpan;
		}
	}
	public enum FORM_MODE { THEM, SUA, XOA }
	public enum eGridItem
	{
		EditItem
		, FooterItem
	}
	#endregion

	public class WebformFunctions
	{
		public WebformFunctions() { }

		public static FORM_MODE get_form_mode(HiddenField ip_hdf_form_mode)
		{
			if (ip_hdf_form_mode.Value.Equals(FORM_MODE.THEM.ToString()))
			{
				return FORM_MODE.THEM;
			}
			if (ip_hdf_form_mode.Value.Equals(FORM_MODE.SUA.ToString()))
			{
				return FORM_MODE.SUA;
			}
			if (ip_hdf_form_mode.Value.Equals(FORM_MODE.XOA.ToString()))
			{
				return FORM_MODE.XOA;
			}
			return FORM_MODE.THEM;
		}

		public static void set_form_mode(FORM_MODE ip_form_mode, HiddenField op_hdf_form_mode)
		{
			op_hdf_form_mode.Value = ip_form_mode.ToString();
		}

		public static T getValue_from_query_string<T>(
			System.Web.UI.Page ip_form
			, string ip_str_query_string
			, object ip_obj_default_value)
		{
			if (ip_form.Request.QueryString[ip_str_query_string] != null)
			{
				switch (typeof(T).Name.ToUpper())
				{
					case "DATETIME":
						return (T)((object)CIPConvert.ToDatetime(ip_form.Request.QueryString[ip_str_query_string], "dd/MM/yyyy"));
					case "DECIMAL":
						return (T)((object)CIPConvert.ToDecimal(ip_form.Request.QueryString[ip_str_query_string]));
					case "STRING":
						return (T)((object)CIPConvert.ToStr(ip_form.Request.QueryString[ip_str_query_string]));
					default:
						break;
				}
			}
			return (T)ip_obj_default_value;
		}

		public static T getControl_in_template<T>(
			GridView ip_grv
			, string ip_str_control_name
			, int ip_i_row_index
			, eGridItem ip_eGrid_item
			)
		{
			System.Web.UI.Control v_control = new Control();
			switch (ip_eGrid_item)
			{
				case eGridItem.EditItem:
					v_control = ip_grv.Rows[ip_i_row_index].FindControl(ip_str_control_name);
					break;
				case eGridItem.FooterItem:
					v_control = ip_grv.FooterRow.FindControl(ip_str_control_name);
					break;
				default:
					break;
			}

			return (T)(object)v_control;
		}

		public static TableHeaderCell getHeaderCell(
			string ip_str_text
			, HorizontalAlign ip_horizontal_align
			, int ip_i_row_span
			, int ip_i_col_span
			, string ip_str_css_class)
		{
			TableHeaderCell v_hc = new TableHeaderCell();
			v_hc.Text = ip_str_text;
			v_hc.HorizontalAlign = HorizontalAlign.Center;
			v_hc.RowSpan = ip_i_row_span;
			v_hc.ColumnSpan = ip_i_col_span;
			v_hc.CssClass = ip_str_css_class;
			return v_hc;
		}

		public static void addHeaderRow_to_grid_view(
			GridView op_grv
			, int ip_i_row_number
			, string ip_str_const_css_class
			, CellInfoHeader[] ip_arr_cell_header)
		{
			GridViewRow v_gvr = new GridViewRow(
				ip_i_row_number
				, 0
				, DataControlRowType.Header
				, DataControlRowState.Insert);
			for (int i = 0; i < ip_arr_cell_header.Length; i++)
			{
				TableHeaderCell v_hc = new TableHeaderCell();
				v_hc.Text = ip_arr_cell_header[i].Text;
				v_hc.HorizontalAlign = HorizontalAlign.Center;
				v_hc.RowSpan = ip_arr_cell_header[i].RowSpan;
				v_hc.ColumnSpan = ip_arr_cell_header[i].ColumnSpan;
				v_hc.CssClass = ip_str_const_css_class;
				v_gvr.Cells.Add(v_hc);
			}
			op_grv.Controls[0].Controls.AddAt(ip_i_row_number, v_gvr);

		}
	}
}