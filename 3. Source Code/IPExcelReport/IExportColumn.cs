// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using C1.Win.C1FlexGrid;
using Excel;


namespace IP.Core.IPExcelReport
{
	public interface IExportColumn
	{
		void Export();
		void ExportWithoutFixedRows();
	}
	
	public class CExportColumnFactory
	{
		private C1FlexGrid m_fg;
		private Worksheet m_objWorkSheet;
		
		public CExportColumnFactory(C1FlexGrid i_fg, Excel.Worksheet i_objWorkSheet)
		{
			m_fg = i_fg;
			m_objWorkSheet = i_objWorkSheet;
		}
		
		public IExportColumn CreateExportColumn(int i_iGridCol, int i_iSheetCol, int i_iSheetStartRow)
		{
			CObjectExportColumn v_objExportCol = new CObjectExportColumn(m_fg, m_objWorkSheet, i_iGridCol, i_iSheetCol, i_iSheetStartRow);
			return v_objExportCol;
		}
	}
	
	public class CObjectExportColumn : IExportColumn
	{
		
		private C1FlexGrid m_fg;
		private Worksheet m_objWorkSheet;
		private int m_iGridCol;
		private int m_iSheetCol;
		private int m_iSheetStartRow;
		
		public CObjectExportColumn(C1FlexGrid i_fg, Excel.Worksheet i_objWorkSheet, int i_iGridCol, int i_iSheetCol, int i_iSheetStartRow)
		{
			m_fg = i_fg;
			m_objWorkSheet = i_objWorkSheet;
			m_iGridCol = i_iGridCol;
			m_iSheetCol = i_iSheetCol;
			m_iSheetStartRow = i_iSheetStartRow;
		}
		
		public void Export()
		{
			int v_iGridRow = 0;
			int v_iSheetRow = m_iSheetStartRow;
			for (v_iGridRow = 0; v_iGridRow <= m_fg.Rows.Count - 1; v_iGridRow++)
			{
				if (m_fg.Rows[v_iGridRow].Visible == true)
				{
					m_objWorkSheet.Cells[v_iSheetRow, m_iSheetCol] = 
						m_fg[v_iGridRow, m_iGridCol];
					v_iSheetRow++;
				}
				
			}
			DrawGrid(m_fg.Rows.Count - 1);
		}
		
		public void ExportWithoutFixedRows()
		{
			int v_iGridRow = 0;
			int v_iFixedRow = m_fg.Rows.Fixed;
			int v_iSheetRow = m_iSheetStartRow;
			for (v_iGridRow = v_iFixedRow; v_iGridRow <= m_fg.Rows.Count - 1; v_iGridRow++)
			{
				if (m_fg.Rows[v_iGridRow].Visible == true)
				{
					m_objWorkSheet.Cells[v_iSheetRow, m_iSheetCol] = 
						m_fg[v_iGridRow, m_iGridCol];
					v_iSheetRow++;
				}
			}
			if (m_fg.Rows.Count == 2)
			{
				DrawGrid(m_fg.Rows.Count - v_iFixedRow);
			}
			else
			{
				DrawGrid(m_fg.Rows.Count - 1 - v_iFixedRow);
			}
		}
		
		private void DrawGrid(int i_total_row)
		{
			Excel.Range v_obj_sel = default(Excel.Range);
			v_obj_sel = m_objWorkSheet.Range[m_objWorkSheet.Cells[m_iSheetStartRow, m_iSheetCol], m_objWorkSheet.Cells[m_iSheetStartRow + i_total_row, m_iSheetCol]];
			//v_obj_sel.Select()
			
			v_obj_sel.Borders[XlBordersIndex.xlDiagonalDown].LineStyle = XlLineStyle.xlLineStyleNone;
			v_obj_sel.Borders[XlBordersIndex.xlDiagonalUp].LineStyle = XlLineStyle.xlLineStyleNone;
			
			Excel.Border with_1 = v_obj_sel.Borders[XlBordersIndex.xlEdgeLeft];
			with_1.LineStyle = XlLineStyle.xlContinuous;
			with_1.Weight = XlBorderWeight.xlThin;
			with_1.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
			
			Excel.Border with_2 = v_obj_sel.Borders[XlBordersIndex.xlEdgeTop];
			with_2.LineStyle = XlLineStyle.xlContinuous;
			with_2.Weight = XlBorderWeight.xlThin;
			with_2.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
			
			Excel.Border with_3 = v_obj_sel.Borders[XlBordersIndex.xlEdgeBottom];
			with_3.LineStyle = XlLineStyle.xlContinuous;
			with_3.Weight = XlBorderWeight.xlThin;
			with_3.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
			
			Excel.Border with_4 = v_obj_sel.Borders[XlBordersIndex.xlEdgeRight];
			with_4.LineStyle = XlLineStyle.xlContinuous;
			with_4.Weight = XlBorderWeight.xlThin;
			with_4.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
			
			Excel.Border with_5 = v_obj_sel.Borders[XlBordersIndex.xlInsideHorizontal];
			with_5.LineStyle = XlLineStyle.xlContinuous;
			with_5.Weight = XlBorderWeight.xlThin;
			with_5.ColorIndex = XlColorIndex.xlColorIndexAutomatic;
			//m_objWorkSheet.Range(m_objWorkSheet.Cells(1, 1) _
			//                                   , m_objWorkSheet.Cells(1, 1)).Select()
		}
		
	}
	
	
	
}
