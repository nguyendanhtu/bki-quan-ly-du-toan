// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using C1.Win.C1FlexGrid;
using System.Windows.Forms;



namespace IP.Core.IPCommon
{
	public class CGridUtils
	{
		
		
#region public
		public static void MakeSoTT(int i_col, C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			Debug.Assert(i_col >= 0 & i_col <= i_fg.Cols.Count - 1, "Chi so cot khong co -MTV ");
			int v_RowIndex = 0;
			int v_i_stt = 1;
			for (v_RowIndex = i_fg.Rows.Fixed; v_RowIndex <= i_fg.Rows.Count - 1; v_RowIndex++)
			{
				i_fg[v_RowIndex, i_col] = v_i_stt;
				v_i_stt++;
			}
		}
		
		public static void MakeSoTTByLevelofRow(int i_colSTT, C1.Win.C1FlexGrid.C1FlexGrid i_fg, int i_Level, bool i_restartSTT_WhenLevel_isChanged)
		{
			int v_iRowIndex = 0;
			int v_iCurrLevel;
			int v_iSTT = 1;
			for (v_iRowIndex = i_fg.Rows.Fixed; v_iRowIndex <= i_fg.Rows.Count - 1; v_iRowIndex++)
			{
				
				if (i_fg.Rows[v_iRowIndex].Node.Level == i_Level)
				{
					i_fg[v_iRowIndex, i_colSTT] = v_iSTT;
					v_iSTT++;
				}
				else if (i_restartSTT_WhenLevel_isChanged)
				{
					v_iSTT = 1;
				}
			}
		}
		
		public static void MakeSoTTofRowNotIsNode(int i_colSTT, 
			C1.Win.C1FlexGrid.C1FlexGrid i_fg, 
			bool i_restartSTT_WhenLevel_isChanged)
		{
			int v_iRowIndex = 0;
			int v_iSTT = 1;
			for (v_iRowIndex = i_fg.Rows.Fixed; v_iRowIndex <= i_fg.Rows.Count - 1; v_iRowIndex++)
			{
				if (i_fg.Rows[v_iRowIndex].IsNode == true)
				{
					if (i_restartSTT_WhenLevel_isChanged)
					{
						v_iSTT = 1;
					}
				}
				else
				{
					i_fg[v_iRowIndex, i_colSTT] = v_iSTT;
					v_iSTT++;
				}
			}
		}
		
		public static void AllowEditingCols(int i_FromCol, int i_ToCol, C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			Debug.Assert(i_FromCol >= i_fg.Cols.Fixed, "FromCol < Cot nho nhat cua Grid -MTV ");
			Debug.Assert(i_ToCol <= i_fg.Cols.Count - 1, "ToCol > tong so cot cua grid -MTV ");
			Debug.Assert(i_FromCol <= i_ToCol, "FromCol phai nho hon ToCol -MTV ");
			int v_ColIndex = 0;
			for (v_ColIndex = i_FromCol; v_ColIndex <= i_ToCol; v_ColIndex++)
			{
				i_fg.Cols[v_ColIndex].AllowEditing = true;
			}
		}
		
		public static void DisAllowEditingCols(int i_FromCol, int i_ToCol, C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			Debug.Assert(i_FromCol >= i_fg.Cols.Fixed, "FromCol < Cot nho nhat cua Grid -MTV ");
			Debug.Assert(i_ToCol <= i_fg.Cols.Count - 1, "ToCol > tong so cot cua grid -MTV ");
			Debug.Assert(i_FromCol <= i_ToCol, "FromCol phai nho hon ToCol -MTV ");
			int v_ColIndex = 0;
			for (v_ColIndex = i_FromCol; v_ColIndex <= i_ToCol; v_ColIndex++)
			{
				i_fg.Cols[v_ColIndex].AllowEditing = false;
			}
		}
		
		public static void HideCols(int i_FromCol, int i_ToCol, C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			Debug.Assert(i_FromCol >= i_fg.Cols.Fixed, "FromCol < Cot nho nhat cua Grid -MTV ");
			Debug.Assert(i_ToCol <= i_fg.Cols.Count - 1, "ToCol > tong so cot cua grid -MTV ");
			Debug.Assert(i_FromCol <= i_ToCol, "FromCol phai nho hon ToCol -MTV ");
			int v_ColIndex = 0;
			for (v_ColIndex = i_FromCol; v_ColIndex <= i_ToCol; v_ColIndex++)
			{
				i_fg.Cols[v_ColIndex].Visible = false;
			}
		}
		
		public static void ShowCols(int i_FromCol, int i_ToCol, C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			Debug.Assert(i_FromCol >= i_fg.Cols.Fixed, "FromCol < Cot nho nhat cua Grid -MTV ");
			Debug.Assert(i_ToCol <= i_fg.Cols.Count - 1, "ToCol > tong so cot cua grid -MTV ");
			Debug.Assert(i_FromCol <= i_ToCol, "FromCol phai nho hon ToCol -MTV ");
			int v_ColIndex = 0;
			for (v_ColIndex = i_FromCol; v_ColIndex <= i_ToCol; v_ColIndex++)
			{
				i_fg.Cols[v_ColIndex].Visible = true;
			}
		}
		
		public static bool isValidColIndex(C1.Win.C1FlexGrid.C1FlexGrid i_fg, 
			int i_col)
		{
			return i_col >= 0 & i_col <= i_fg.Cols.Count - 1;
		}
		
		public static bool isValid_NonFixed_RowIndex(C1.Win.C1FlexGrid.C1FlexGrid i_fg, 
			int i_row)
		{
			
			if (i_fg.Rows.Count == 0)
			{
				return false;
			}
			return i_row >= i_fg.Rows.Fixed & i_row <= i_fg.Rows.Count - 1;
		}
		
		public static bool IsThere_Any_NonFixed_Row(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			return i_fg.Rows.Count > i_fg.Rows.Fixed;
		}
		
		public static void ClearDataInGrid(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			if (i_fg.Rows.Count == i_fg.Rows.Fixed)
			{
				return;
			}
			i_fg.Rows.Count = i_fg.Rows.Fixed;
		}
		
		public static void stand_on_TopLeft_Cell(C1FlexGrid i_fg)
		{
			if (!IsThere_Any_NonFixed_Row(i_fg))
			{
				return;
			}
			bool v_visible_column_found = false;
			int v_first_visible_column_Index = i_fg.Cols.Fixed;
			while (v_first_visible_column_Index <= i_fg.Cols.Count - 1)
			{
				if (i_fg.Cols[v_first_visible_column_Index].Visible)
				{
					v_visible_column_found = true;
					break;
				}
				v_first_visible_column_Index++;
			}
			
			if (v_visible_column_found)
			{
				i_fg.Row = i_fg.Rows.Fixed;
				i_fg.Col = v_first_visible_column_Index;
			}
		}
		
		public static void AddTree_Toogle_Handlers(C1FlexGrid i_fg)
		{
			i_fg.KeyDown += grid_KeydownEnter_In_Tree;
			i_fg.DoubleClick += grid_DoubleClick;
		}
		
		public static void AddSearch_Handlers(C1FlexGrid i_fg)
		{
			i_fg.KeyDown += grid_Keydown_Search;
		}
		
		/// -----------------------------------------------------------------------------
		/// <summary>
		/// Thêm chức năng Save cho grid
		/// </summary>
		/// <param name="i_fg"></param>
		/// <remarks>
		/// Thường được gọi tại format control
		/// </remarks>
		/// <history>
		/// 	[tund]	26/04/2006	Created
		/// </history>
		/// -----------------------------------------------------------------------------
		public static void AddSave_Excel_Handlers(C1FlexGrid i_fg)
		{
			i_fg.KeyDown += grid_Keydown_Save;
			add_PopUp_Menu(i_fg);
			
		}
		
		public static void SetCellImage(System.Drawing.Image i_image, C1FlexGrid i_fg, int i_row, int i_col)
		{
			
			Debug.Assert(i_col >= i_fg.Cols.Fixed & 
				i_col <= i_fg.Cols.Count - 1 & 
				i_row >= i_fg.Rows.Fixed & i_row <= i_fg.Rows.Count - 1, "Invalid cell range-csung");
			
			CellRange v_cellrange = i_fg.GetCellRange(i_row, i_col);
			v_cellrange.Image = i_image;
		}
		
		public static void Dataset2C1Grid(DataSet i_ds, C1FlexGrid i_fg, ITransferDataRow i_oTransfer)
		{
			Debug.Assert(!(i_ds == null), "Chua khoi tao Dataset - tuanqt");
			Debug.Assert(!(i_fg == null), "Chua khoi tao fg - tuanqt");
			Debug.Assert(!(i_oTransfer == null), "Chua khoi tao transfer object - tuanqt");
			int v_i_cur_row = i_fg.Row;
			i_fg.Rows.Count = i_fg.Rows.Fixed;
			if (i_ds.Tables[0].Rows.Count > 0)
			{
				int v_iRowIndex = i_fg.Rows.Fixed;
				DataRow v_dr = default(DataRow);
				foreach (DataRow tempLoopVar_v_dr in i_ds.Tables[0].Rows)
				{
					v_dr = tempLoopVar_v_dr;
					i_fg.Rows.Add();
					i_fg.Rows[v_iRowIndex].UserData = v_dr;
					i_oTransfer.DataRow2GridRow(v_dr, v_iRowIndex);
					v_iRowIndex++;
				}
				
				// add column name
				Hashtable v_hst = new Hashtable();
				v_hst = i_oTransfer.getHastableMapping();
				object v_obj = null;
				string v_strColName = "";
				int v_iColNumber = 0;
				foreach (object tempLoopVar_v_obj in v_hst.Keys)
				{
					v_obj = tempLoopVar_v_obj;
					v_strColName = System.Convert.ToString(v_obj);
					v_iColNumber = System.Convert.ToInt32(v_hst[v_strColName]);
					i_fg.Cols[v_iColNumber].UserData = v_strColName;
					
				}
				
				if (i_fg.Rows.Count > v_i_cur_row)
				{
					i_fg.Row = v_i_cur_row;
				}
				else
				{
					i_fg.Row = i_fg.Rows.Count - 1;
				}
			}
		}
		
		public static void WrapWordInOneCell(C1FlexGrid i_fg, int i_iRow, int i_iCol)
		{
			C1.Win.C1FlexGrid.CellStyle v_csCellStyle;
			v_csCellStyle = i_fg.GetCellStyleDisplay(i_iRow, i_iCol);
			v_csCellStyle.WordWrap = true;
		}
		
		public static void SetFocusOnOneCell(C1FlexGrid i_fg, int i_iRow, int i_iCol)
		{
			i_fg.Select(i_iRow, i_iCol);
			i_fg.ShowCell(i_iRow, i_iCol);
		}
		
		public static void setTreeLevelOfRow(C1.Win.C1FlexGrid.C1FlexGrid i_fg, int i_row, int i_level)
		{
			i_fg.Rows[i_row].IsNode = true;
			i_fg.Rows[i_row].Node.Level = i_level;
		}
		
		public static void FillColumnWithString(int i_col, C1.Win.C1FlexGrid.C1FlexGrid i_fg, string i_strValue)
		{
			Debug.Assert(i_col >= i_fg.Cols.Fixed & i_col <= i_fg.Cols.Count - 1, "Chi so cot khong co -MTV ");
			int v_RowIndex = 0;
			for (v_RowIndex = i_fg.Rows.Fixed; v_RowIndex <= i_fg.Rows.Count - 1; v_RowIndex++)
			{
				i_fg[v_RowIndex, i_col] = i_strValue;
			}
		}
#endregion
		
#region PRIVATES
		private static void grid_Keydown_Save(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.S & e.Control)
			{
				C1.Win.C1FlexGrid.C1FlexGrid v_fg = (C1.Win.C1FlexGrid.C1FlexGrid) sender;
				System.Windows.Forms.SaveFileDialog dlgSave = new System.Windows.Forms.SaveFileDialog();
				
				
				dlgSave.Filter = "Excel Files |*.xls";
				dlgSave.FileName = "FMSTemplateFile.xls";
				if (dlgSave.ShowDialog() == DialogResult.OK)
				{
					v_fg.SaveExcel(dlgSave.FileName, "OutPut", FileFlags.IncludeFixedCells);
					//v_fg.SaveGrid(dlgSave.FileName, FileFormatEnum.TextTab, True, System.Text.Encoding.Unicode)
				}
				
			}
		}
		public static void add_PopUp_Menu(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			//1. create context mnu
			System.Windows.Forms.ContextMenu v_context_mnu = new System.Windows.Forms.ContextMenu();
			System.Windows.Forms.MenuItem v_mnu_save_image = new System.Windows.Forms.MenuItem();
			v_context_mnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {v_mnu_save_image});
			v_mnu_save_image.Index = 0;
			v_mnu_save_image.Text = "Save Excel";
			v_mnu_save_image.Click += grid_PopUp_Save;
			//2. Add to grid
			i_fg.ContextMenu = v_context_mnu;
		}
		public static void grid_PopUp_Save(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem v_mnu_save_image = (System.Windows.Forms.MenuItem) sender;
			System.Windows.Forms.ContextMenu v_context_mnu = (System.Windows.Forms.ContextMenu) v_mnu_save_image.Parent;
			C1.Win.C1FlexGrid.C1FlexGrid v_fg = (C1.Win.C1FlexGrid.C1FlexGrid) v_context_mnu.SourceControl;
			
			System.Windows.Forms.SaveFileDialog dlgSave = new System.Windows.Forms.SaveFileDialog();
			dlgSave.Filter = "Excel Files |*.xls";
			dlgSave.FileName = "FMSTemplateFile.xls";
			if (dlgSave.ShowDialog() == DialogResult.OK)
			{
				v_fg.SaveExcel(dlgSave.FileName, "OutPut", FileFlags.IncludeFixedCells);
				//v_fg.SaveGrid(dlgSave.FileName, FileFormatEnum.TextTab, True, System.Text.Encoding.Unicode)
			}
		}
		private static void grid_DoubleClick(object sender, EventArgs e)
		{
			C1FlexGrid v_fg = (C1.Win.C1FlexGrid.C1FlexGrid) sender;
			if (v_fg.Tree.Column == v_fg.Col)
			{
				ToggleNodeState(v_fg);
			}
		}
		
		
		
		private static void grid_KeydownEnter_In_Tree(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			C1.Win.C1FlexGrid.C1FlexGrid v_fg = (C1.Win.C1FlexGrid.C1FlexGrid) sender;
			if (e.KeyCode == System.Windows.Forms.Keys.Enter)
			{
				ToggleNodeState(v_fg);
			}
		}
		
		private static void grid_Keydown_Search(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == System.Windows.Forms.Keys.F & e.Control)
			{
				C1.Win.C1FlexGrid.C1FlexGrid v_fg = (C1.Win.C1FlexGrid.C1FlexGrid) sender;
				startSearchForm(v_fg, v_fg.FindForm());
			}
		}
		
		private static void ToggleNodeState(C1FlexGrid i_fg)
		{
			//if in edit mode , no work
			if (!((i_fg.Editor) == null))
			{
				return;
			}
			// if the current row is not a node, no work
			Row v_row = i_fg.Rows[i_fg.Row];
			if (!v_row.IsNode)
			{
				return;
			}
			// toggle collapsed state
			v_row.Node.Collapsed = !v_row.Node.Collapsed;
		}
		
		private static void startSearchForm(C1FlexGrid i_fg, Form i_form)
		{
			CSearchInColumnOfFlexGrid.display_Search_in_CurrentColumn(i_fg, i_form);
		}
#endregion
		
	}
	
}
