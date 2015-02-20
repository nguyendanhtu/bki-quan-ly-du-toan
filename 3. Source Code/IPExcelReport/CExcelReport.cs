using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
using C1.Win.C1FlexGrid;
using System.IO;
using Excel;
using System.Threading;

namespace IP.Core.IPExcelReport
{
	public class CExcelReport
	{
		private const string c_ReportTemplatesDir = "Reports\\Templates\\";
		private const string c_ReportOutputDir = "Reports\\Output\\";

		protected string m_strOutputPath = "";
		protected string m_strTemplatesPath = "";

		private string m_strTemplateFileNameWithPath;
		private int m_iSheetStartRow;
		private int m_iSheetStartCol;

		private Excel.Application m_objExcelApp;
		private Excel.Worksheet m_objExcelWorksheet;
		private bool m_init_successful;
		private bool m_b_haved_show;
		private bool m_b_set_style = true;

		public Hashtable FindAndReplaceCollection;

		public CExcelReport(string i_strTemplateFileWithoutPath, int i_iSheetStartRow, int i_iSheetStartCol)
		{
			InitPaths();
			m_strTemplateFileNameWithPath = m_strTemplatesPath + i_strTemplateFileWithoutPath;
			m_iSheetStartCol = i_iSheetStartCol;
			m_iSheetStartRow = i_iSheetStartRow;
			m_objExcelApp = new Excel.Application();
			FindAndReplaceCollection = new Hashtable();
			m_init_successful = false;
			m_b_haved_show = false;
			init_excel();
		}
		public CExcelReport(string i_str_TemplateFilePath)
		{
			InitPaths();
			m_strTemplateFileNameWithPath = i_str_TemplateFilePath;
			m_init_successful = false;
			m_b_haved_show = false;
			m_init_successful = true;
		}
		public void SetVisibleStyle4Node()
		{
			m_b_set_style = true;
		}

		public void SetInvisibleStyle4Node()
		{
			m_b_set_style = false;

		}
		public string GetOutputFileNameWithPath()
		{
			string v_strRandomName = "";
			VBMath.Randomize();
			v_strRandomName = m_strOutputPath + "~" + System.Convert.ToString((long)(VBMath.Rnd() * 1000000000000)) + ".xls";
			return v_strRandomName;
		}
		public int GetCountRow()
		{
			try
			{
				m_objExcelApp = new Excel.Application();
				System.Globalization.CultureInfo oldCI =
					System.Threading.Thread.CurrentThread.CurrentCulture;
				System.Threading.Thread.CurrentThread.CurrentCulture =
					new System.Globalization.CultureInfo("en-US");
				m_objExcelApp.Workbooks.Open(m_strTemplateFileNameWithPath, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
				m_objExcelApp.Workbooks[1].Worksheets.Select(1);
				m_objExcelWorksheet = (Excel.Worksheet)(m_objExcelApp.Workbooks[1].Worksheets[1]);
				return m_objExcelWorksheet.UsedRange.Rows.Count;
			}
			catch (Exception v_e)
			{
				throw (v_e);
			}
		}
		public void Export2Grid(C1FlexGrid i_fg, int i_iSheetStartRow, int i_iSheetCol, int i_iGridCol)
		{
			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				m_objExcelApp = new Excel.Application();
				m_objExcelApp.Workbooks.Open(m_strTemplateFileNameWithPath, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
				m_objExcelApp.Workbooks[1].Worksheets.Select(1);
				m_objExcelWorksheet = (Excel.Worksheet)(m_objExcelApp.Workbooks[1].Worksheets[1]);
				int v_iGridRow = 0;
				for (v_iGridRow = i_fg.Rows.Fixed; v_iGridRow <= i_fg.Rows.Count - 1; v_iGridRow++)
				{
					i_fg[v_iGridRow, i_iGridCol] = m_objExcelWorksheet.Cells[i_iSheetStartRow + v_iGridRow - i_fg.Rows.Fixed, i_iSheetCol];//.Value
				}
				m_objExcelApp.Workbooks.Close();
				m_objExcelApp.Quit();
				Unmount();


			}
			catch (Exception v_e)
			{
				m_objExcelApp.Workbooks.Close();
				m_objExcelApp.Quit();
				Unmount();
				throw (v_e);
			}
		}
		public void Export2Excel(C1FlexGrid i_fg, int i_iFromGridCol, int i_iToGridCol, bool i_b_show = true)
		{
			try
			{
				if (!m_init_successful)
				{
					return;
				}
				CExportColumnFactory v_objFact = new CExportColumnFactory(i_fg, m_objExcelWorksheet);
				IExportColumn v_objExpCol = default(IExportColumn);
				int v_iGridCol = 0;
				int v_iNumberOfCol = 0;
				int v_iVisibleColsCount = 0;
				int v_iCount = 0;
				// Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
				Range v_obj_range = m_objExcelWorksheet.Range[m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol], m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol]];
				for (v_iCount = i_fg.Rows.Fixed; v_iCount <= i_fg.Rows.Count - 2; v_iCount++)
				{
					v_obj_range.EntireRow.Insert(Excel.XlDirection.xlDown, null);
				}
				for (v_iGridCol = i_iFromGridCol; v_iGridCol <= i_iToGridCol; v_iGridCol++)
				{
					if (i_fg.Cols[v_iGridCol].Visible)
					{
						v_objExpCol = v_objFact.CreateExportColumn(v_iGridCol, m_iSheetStartCol + v_iNumberOfCol, m_iSheetStartRow);
						v_iNumberOfCol++;
						v_objExpCol.Export();
						v_iVisibleColsCount++;
					}
				}
				if (m_b_set_style)
				{
					setStyle4Node(i_fg, v_iVisibleColsCount);
				}
				m_iSheetStartRow = m_iSheetStartRow + i_fg.Rows.Count;

				if (i_b_show)
				{
					m_objExcelApp.Visible = true;
					Unmount();
				}
			}
			catch (Exception v_e)
			{
				m_objExcelApp.Workbooks.Close();
				Unmount();
				throw (v_e);
			}
		}

		public void ChangeSheetExported(int i_sheet_index)
		{
			m_objExcelApp.Workbooks[1].Worksheets.Select(i_sheet_index);
			m_objExcelWorksheet = (Excel.Worksheet)(m_objExcelApp.Workbooks[1].Worksheets[i_sheet_index]);
		}
		public void Export2ExcelWithoutFixedRows(C1FlexGrid i_fg, int i_iFromGridCol, int i_iToGridCol, bool i_b_show)
		{
			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				if (!m_init_successful)
				{
					return;
				}
				CExportColumnFactory v_objFact = new CExportColumnFactory(i_fg, m_objExcelWorksheet);
				IExportColumn v_objExpCol = default(IExportColumn);
				int v_iGridCol = 0;
				int v_iNumberOfCol = 0;
				int v_iVisibleColsCount = 0;
				int v_iCount = 0;
				// Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
				Range v_obj_range = m_objExcelWorksheet.Range[m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol], m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol]];
				for (v_iCount = i_fg.Rows.Fixed; v_iCount <= i_fg.Rows.Count - 2; v_iCount++)
				{
					v_obj_range.EntireRow.Insert(Excel.XlDirection.xlDown, null);
				}
				for (v_iGridCol = i_iFromGridCol; v_iGridCol <= i_iToGridCol; v_iGridCol++)
				{
					if (i_fg.Cols[v_iGridCol].Visible)
					{
						v_objExpCol = v_objFact.CreateExportColumn(v_iGridCol, m_iSheetStartCol + v_iNumberOfCol, m_iSheetStartRow);
						v_iNumberOfCol++;
						v_objExpCol.ExportWithoutFixedRows();
						v_iVisibleColsCount++;

					}
				}
				if (m_b_set_style)
				{
					setStyle4Node(i_fg, v_iVisibleColsCount);
				}
				m_iSheetStartRow = m_iSheetStartRow + i_fg.Rows.Count;
				if (i_b_show)
				{
					m_objExcelApp.Visible = true; //Not Display Excel
					string v_strFilenameWithPath = "";
					v_strFilenameWithPath = m_strOutputPath + System.Convert.ToString((long)(VBMath.Rnd() * 1000000000000));
					try
					{
						m_objExcelApp.SaveWorkspace(v_strFilenameWithPath);
					}
					catch
					{
						//m_objExcelApp.Workbooks.Close()
						Unmount();
						return;
					}

					//m_objExcelApp.Workbooks.Close()
					Unmount();
				}
			}
			catch (Exception v_e)
			{
				m_objExcelApp.Workbooks.Close();
				Unmount();
				throw (v_e);
			}



		}
		public void GotoExportPosition(int i_iSheetStartRow, int i_iSheetCol)
		{
			m_iSheetStartRow = i_iSheetStartRow;
			m_iSheetStartCol = i_iSheetCol;
		}
		public void AddFindAndReplaceItem(object i_obj_find, object i_obj_replace)
		{
			this.FindAndReplaceCollection.Add(i_obj_find, i_obj_replace);
		}

		public void FindAndReplace(bool i_b_show)
		{
			try
			{
				if (!m_init_successful)
				{
					return;
				}
				string v_str_replace = "";
				foreach (string v_str_find in this.FindAndReplaceCollection.Keys)
				{
					v_str_replace = System.Convert.ToString(this.FindAndReplaceCollection[v_str_find].ToString());
					m_objExcelWorksheet.Cells.Replace(What: v_str_find, Replacement: v_str_replace);
					if (!m_b_haved_show)
					{
						m_objExcelApp.Visible = true;
						m_b_haved_show = true;
					}
				}
				if (i_b_show)
				{
					m_objExcelApp.Visible = true;
					Unmount();
				}
			}
			catch (Exception v_e)
			{
				m_objExcelApp.Workbooks.Close();
				Unmount();
				throw (v_e);
			}
		}

		private void init_excel()
		{
			string v_strFileName = "";
			v_strFileName = GetOutputFileNameWithPath();
			if (!CopyFileSuccess(v_strFileName))
			{
				return;
			}
			m_objExcelApp.Workbooks.Open(v_strFileName, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
			m_objExcelApp.Workbooks[1].Worksheets.Select(1);
			m_objExcelWorksheet = (Excel.Worksheet)(m_objExcelApp.Workbooks[1].Worksheets[1]);
			m_init_successful = true;

		}

		//Tra ve xem co copy thanh cong hay khong
		private bool CopyFileSuccess(string i_strFileDest)
		{
			try
			{
				FileInfo v_objFileInfo = new FileInfo(m_strTemplateFileNameWithPath);
				Debug.Assert(v_objFileInfo.Exists, "Khong co file template nay - tuanqt");
				v_objFileInfo.CopyTo(i_strFileDest);
				return true;
			}
			catch (Exception)
			{
				return false;
			}
		}

		private void InitPaths()
		{
			m_strOutputPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + c_ReportOutputDir;
			m_strTemplatesPath = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + c_ReportTemplatesDir;
		}

		private void Unmount()
		{
			m_objExcelWorksheet = null;
			m_objExcelApp = null;


		}

		private void setStyle4Node(C1.Win.C1FlexGrid.C1FlexGrid i_fg, int i_VisibleColsCount)
		{
			int v_iGridRow = 0;

			//Cap nhat style cho row la node
			Excel.Range v_obj_sel = default(Excel.Range);
			int v_iFixedRow = i_fg.Rows.Fixed;
			for (v_iGridRow = i_fg.Rows.Fixed; v_iGridRow <= i_fg.Rows.Count - 1; v_iGridRow++)
			{
				if (i_fg.Rows[v_iGridRow].IsNode)
				{
					v_obj_sel = m_objExcelWorksheet.Range[m_objExcelWorksheet.Cells[m_iSheetStartRow + v_iGridRow - v_iFixedRow, m_iSheetStartCol], m_objExcelWorksheet.Cells[m_iSheetStartRow + v_iGridRow - v_iFixedRow, m_iSheetStartCol + i_VisibleColsCount - 1]];
					Excel.Interior with_1 = v_obj_sel.Interior;
					with_1.ColorIndex = 36 + i_fg.Rows[v_iGridRow].Node.Level;
					with_1.Pattern = XlPattern.xlPatternSolid;
					Excel.Font with_2 = v_obj_sel.Font;
					with_2.Bold = true;
				}
			}
		}

		public void Export2DatasetDSPhongThi(System.Data.DataSet i_DataSet, string i_TableName, int i_iSheetStartRow)
		{
			try
			{
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				m_objExcelApp = new Excel.Application();
				m_objExcelApp.Workbooks.Open(m_strTemplateFileNameWithPath, null, null, null, null, null, null, null, null, null, null, null, null, null, null);
				m_objExcelApp.Workbooks[1].Worksheets.Select(1);
				m_objExcelWorksheet = (Excel.Worksheet)(m_objExcelApp.Workbooks[1].Worksheets[1]);
				int i_iExcelRow = 0;
				bool v_bol_stop = false;
				while (!v_bol_stop)
				{
					int i_iExcelCol = 0;
					System.Data.DataRow v_iDataRow = default(System.Data.DataRow);
					v_iDataRow = i_DataSet.Tables[i_DataSet.Tables[i_TableName].TableName].NewRow();
					v_iDataRow[i_iExcelCol] = i_iExcelCol + 1;
					for (i_iExcelCol = 0; i_iExcelCol <= i_DataSet.Tables[i_TableName].Columns.Count - 2; i_iExcelCol++)
					{
						if (!object.ReferenceEquals(m_objExcelWorksheet.Cells[i_iExcelRow + i_iSheetStartRow, 4]/*.Value()*/, null))
						{
							if (!(m_objExcelWorksheet.Cells[i_iExcelRow + i_iSheetStartRow, i_iExcelCol + 1]/*.Value()*/ == null))
							{
								v_iDataRow[i_iExcelCol + 1] = m_objExcelWorksheet.Cells[i_iExcelRow + i_iSheetStartRow, i_iExcelCol + 1]/*.Value()*/;
							}
						}
						else
						{
							v_bol_stop = true;
						}
					}
					if (!v_bol_stop)
					{
						i_DataSet.Tables[i_TableName].Rows.InsertAt(v_iDataRow, i_iExcelRow);
						i_iExcelRow++;
					}
				}
				m_objExcelApp.DisplayAlerts = false;
				m_objExcelApp.Workbooks.Close();
				m_objExcelApp.DisplayAlerts = true;
				m_objExcelApp.Quit();
				Unmount();
			}
			catch (Exception v_e)
			{
				m_objExcelApp.DisplayAlerts = false;
				m_objExcelApp.Workbooks.Close();
				m_objExcelApp.DisplayAlerts = true;
				m_objExcelApp.Quit();
				Unmount();
				throw (v_e);
			}
		}
		public void OpenExcelFile()
		{
			try
			{
				//m_objExcelApp = New Excel.Application
				//m_objExcelApp.Visible = True
				//m_objExcelApp.Workbooks.Open(m_strTemplatesPath & m_strTemplateFileNameWithPath)
				//m_objExcelApp.Workbooks(1).Worksheets.Select(1)
				//m_objExcelWorksheet = CType(m_objExcelApp.Workbooks(1).Worksheets(1), Excel.Worksheet)
				//m_objExcelApp.Workbooks.Close()
				Process.Start(m_strTemplatesPath + m_strTemplateFileNameWithPath);

			}
			catch (Exception v_e)
			{

				throw (v_e);
			}
		}
		//Huytd
		public void Export2ExcelWithoutFixedRows_saveDialog(string str_file_name, C1FlexGrid i_fg, int i_iFromGridCol, int i_iToGridCol, bool i_b_show)
		{
			try
			{
				SaveFileDialog saveFileDialog = new SaveFileDialog();

				saveFileDialog.Filter = "Execl files (*.xls)|*.xls";

				saveFileDialog.FilterIndex = 0;

				saveFileDialog.RestoreDirectory = true;

				saveFileDialog.CreatePrompt = true;

				saveFileDialog.Title = "Export Excel File To";
				System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
				if (!m_init_successful)
				{
					return;
				}
				CExportColumnFactory v_objFact = new CExportColumnFactory(i_fg, m_objExcelWorksheet);
				IExportColumn v_objExpCol = default(IExportColumn);
				int v_iGridCol = 0;
				int v_iNumberOfCol = 0;
				int v_iVisibleColsCount = 0;
				int v_iCount = 0;
				// Chen 1 so dong trong Excel tuong ung voi so Ban ghi can insert
				Range v_obj_range = m_objExcelWorksheet.Range[m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol], m_objExcelWorksheet.Cells[m_iSheetStartRow + 1, m_iSheetStartCol]];
				v_iCount = i_fg.Rows.Fixed;
				while (v_iCount <= i_fg.Rows.Count - 2)
				{
					v_obj_range.EntireRow.Insert(Excel.XlDirection.xlDown, null);
					System.Math.Max(System.Threading.Interlocked.Increment(ref v_iCount), v_iCount - 1);
				}
				v_iGridCol = i_iFromGridCol;
				while (v_iGridCol <= i_iToGridCol)
				{
					if (i_fg.Cols[v_iGridCol].Visible)
					{
						v_objExpCol = v_objFact.CreateExportColumn(v_iGridCol, m_iSheetStartCol + v_iNumberOfCol, m_iSheetStartRow);
						v_iNumberOfCol++;
						v_objExpCol.ExportWithoutFixedRows();

						v_iVisibleColsCount++;
					}
					System.Math.Max(System.Threading.Interlocked.Increment(ref v_iGridCol), v_iGridCol - 1);
				}
				if (m_b_set_style)
				{
					setStyle4Node(i_fg, v_iVisibleColsCount);
				}
				m_iSheetStartRow = m_iSheetStartRow + i_fg.Rows.Count;
				if (i_b_show)
				{
					if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
					{
						m_objExcelApp.Visible = true;
						//Not Display Excel
						string v_strFilenameWithPath = "";
						v_strFilenameWithPath = str_file_name;
						m_objExcelApp.SaveWorkspace(v_strFilenameWithPath);
						//m_objExcelApp.Workbooks.Close()
						Unmount();
					}
				}
			}
			catch (Exception v_e)
			{
				m_objExcelApp.Workbooks.Close();
				Unmount();
				throw (v_e);
			}



		}
	}

}
