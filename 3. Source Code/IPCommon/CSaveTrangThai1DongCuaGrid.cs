// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPCommon
{
	public class CSaveTrangThai1DongCuaGrid
	{
		private ArrayList m_GiaTriCuaDong; // c�c cell trong d�ng
		private object m_rowUserData; //user data
		private C1.Win.C1FlexGrid.C1FlexGrid m_fg;
		private int m_row_saved;
		
		public CSaveTrangThai1DongCuaGrid(C1.Win.C1FlexGrid.C1FlexGrid i_c1fg, 
			int i_Row)
		{
			Debug.Assert(i_c1fg.Rows.Count > i_c1fg.Rows.Fixed, "Khong co du lieu - mtv");
			Debug.Assert(i_Row >= i_c1fg.Rows.Fixed & i_Row < i_c1fg.Rows.Count, "Dong sai roi - mtv");
			
			m_GiaTriCuaDong = new ArrayList();
			
			int v_iColIndex = 0;
			for (v_iColIndex = 0; v_iColIndex <= i_c1fg.Cols.Count - 1; v_iColIndex++)
			{
				m_GiaTriCuaDong.Add(i_c1fg[i_Row, v_iColIndex]);
			}
			m_fg = i_c1fg;
			m_row_saved = i_Row;
			m_rowUserData = i_c1fg.Rows[i_Row].UserData;
		}
		
		public void UndoTrangThai1Dong(C1.Win.C1FlexGrid.C1FlexGrid i_c1fg, 
			int i_Row)
		{
			Debug.Assert(i_c1fg.Rows.Count > i_c1fg.Rows.Fixed, "Khong co du lieu - mtv");
			Debug.Assert(i_Row >= i_c1fg.Rows.Fixed & i_Row < i_c1fg.Rows.Count, "Dong sai roi - mtv");
			int v_iColIndex = 0;
			for (v_iColIndex = 0; v_iColIndex <= i_c1fg.Cols.Count - 1; v_iColIndex++)
			{
				i_c1fg[i_Row, v_iColIndex] = m_GiaTriCuaDong[v_iColIndex];
			}
			i_c1fg.Rows[i_Row].UserData = m_rowUserData;
		}
		
		
		public void UndoTrangThai1Dong()
		{
			Debug.Assert(!(m_fg == null), "Chua save thi khong undo duoc - csung");
			int v_iColIndex = 0;
			for (v_iColIndex = 0; v_iColIndex <= m_fg.Cols.Count - 1; v_iColIndex++)
			{
				m_fg[m_row_saved, v_iColIndex] = m_GiaTriCuaDong[v_iColIndex];
			}
			m_fg.Rows[m_row_saved].UserData = m_rowUserData;
		}
	}
	
}
