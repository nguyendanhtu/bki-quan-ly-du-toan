// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;

//Nhiệm vụ của Class:
// Goal: thực hiện tìm kiếm trên các cột của C1, FlexGrid
//
//
namespace IP.Core.IPCommon
{
	public class CSearchInColumnOfFlexGrid : ISearchable
	{
		
#region Data Structures
		private enum GridDataType2Search
		{
			Text_Data,
			DateTime_Data,
			Numeric_Data
		}
#endregion
		
#region Variables
		private GridDataType2Search m_dataType2Search;
		private ISearchForm m_searchForm;
		private Form m_dataForm;
		private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
		private int m_col2Search;
#endregion
		
#region PUBLIC INTERFACES
		
		public CSearchInColumnOfFlexGrid(C1.Win.C1FlexGrid.C1FlexGrid i_fg, 
			int i_col, Form 
			i_dataForm)
		{
			
			Debug.Assert(!(i_fg == null), "Chửa khởi tạo Grid");
			Debug.Assert(i_col >= i_fg.Cols.Fixed, "Column index quá bé");
			Debug.Assert(i_col <= i_fg.Cols.Count - 1, "Column index quá lớn");
			
			
			m_fg = i_fg;
			m_col2Search = i_col;
			
			if (i_fg.Rows.Count == i_fg.Rows.Fixed)
			{
				return; // khong co du lieu de search
			}
			
			if (i_fg.Cols[i_col].DataType == System.Type.GetType("System.String"))
			{
				m_dataType2Search = GridDataType2Search.Text_Data;
				m_searchForm = new frmSearchString(); // day la form de ma search
			}
			else if (i_fg.Cols[i_col].DataType == System.Type.GetType("System.Double") || i_fg.Cols[i_col].DataType == System.Type.GetType("System.Decimal"))
			{
				m_dataType2Search = GridDataType2Search.Numeric_Data;
				m_searchForm = new frmSearchNumeric();
			}
			else if (i_fg.Cols[i_col].DataType == System.Type.GetType("System.DateTime"))
			{
				m_dataType2Search = GridDataType2Search.DateTime_Data;
				m_searchForm = new frmSearchDate();
			}
			else
			{
				Debug.Assert(false, "Loại dữ liệu của column không tìm được");
			}
		}
		
		private void displaySearchForm()
		{
			if (!m_fg.Cols[m_col2Search].Visible)
			{
				return;
			}
			m_searchForm.displaySearch(this);
		}
		
		public bool startSearch(IFoundCondition i_SearchConditionObject, SearchType i_searchtype)
		{
			if (m_fg.Rows.Count <= m_fg.Rows.Fixed)
			{
				return false;
			}
			
			try
			{
				bool v_found = false;
				int v_i = 1;
				if (i_searchtype == SearchType.fromNextRow)
				{
					v_i = m_fg.Row + 1;
				}
				
				if (v_i > m_fg.Rows.Count - 1) // o qua hang cuoi roi
				{
					return false;
				}
				
				while (!v_found && v_i <= m_fg.Rows.Count - 1)
				{
					if (i_SearchConditionObject.MatchThePattern(m_fg[v_i, m_col2Search]))
					{
						v_found = true;
					}
					else
					{
						v_i++;
					}
				}
				if (v_found)
				{
					m_fg.Row = v_i;
					m_fg.ShowCell(m_fg.Row, m_col2Search);
				}
				return v_found;
			}
			catch (Exception)
			{
				return false;
			}
		}
		
		public static void display_Search_in_CurrentColumn(C1.Win.C1FlexGrid.C1FlexGrid i_fg, Form i_dataForm)
		{
			
			Debug.Assert(!(i_fg == null), "Chửa khởi tạo Grid - Csung");
			if (i_fg.Cols[i_fg.Col].DataType == System.Type.GetType("System.Boolean"))
			{
				return;
			}
			if (!(i_fg.Editor == null))
			{
				return;
			}
			bool v_bAcceptedDataType = IsAcceptedDataType(i_fg.Cols[i_fg.Col].DataType);
			Debug.Assert(v_bAcceptedDataType, "Datatype của column không tìm kiếm được - Csung ");
			if (!i_fg.Cols[i_fg.Col].Visible)
			{
				return; // column khong nhin thay
			}
			if (i_fg.Rows.Count == i_fg.Rows.Fixed)
			{
				return; // khong co data
			}
			
			CSearchInColumnOfFlexGrid v_search = new CSearchInColumnOfFlexGrid(i_fg, i_fg.Col, i_dataForm);
			v_search.displaySearchForm();
		}
		
		private static bool IsAcceptedDataType(System.Type i_dataType)
		{
			return i_dataType == System.Type.GetType("System.String") || i_dataType == System.Type.GetType("System.Double") || i_dataType == System.Type.GetType("System.Decimal") || i_dataType == System.Type.GetType("System.DateTime");
		}
		
#endregion
		
	}
	
}
