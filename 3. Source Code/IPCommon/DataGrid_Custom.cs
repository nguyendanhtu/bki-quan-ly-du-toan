// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;

namespace IP.Core.IPCommon
{
	public class DataGrid_Custom : System.Windows.Forms.DataGrid
	{
		
		//Widnows designer generated code omitted.
		public delegate void DeleteRowEventHandler(object sender, DeleteRowEventArgs e);
		private DeleteRowEventHandler DeleteRowEvent;
		public event DeleteRowEventHandler DeleteRow
		{
			add
			{
				DeleteRowEvent = (DeleteRowEventHandler) System.Delegate.Combine(DeleteRowEvent, value);
			}
			remove
			{
				DeleteRowEvent = (DeleteRowEventHandler) System.Delegate.Remove(DeleteRowEvent, value);
			}
		}
		
		
		public delegate void OutPlaceUpdateRowEventHandler(object sender, OutPlaceUpdateEventArgs e);
		private OutPlaceUpdateRowEventHandler OutPlaceUpdateRowEvent;
		public event OutPlaceUpdateRowEventHandler OutPlaceUpdateRow
		{
			add
			{
				OutPlaceUpdateRowEvent = (OutPlaceUpdateRowEventHandler) System.Delegate.Combine(OutPlaceUpdateRowEvent, value);
			}
			remove
			{
				OutPlaceUpdateRowEvent = (OutPlaceUpdateRowEventHandler) System.Delegate.Remove(OutPlaceUpdateRowEvent, value);
			}
		}
		
		
		public delegate void OutPlaceInsertRowEventHandler(object sender, OutPlaceInsertEventArgs e);
		private OutPlaceInsertRowEventHandler OutPlaceInsertRowEvent;
		public event OutPlaceInsertRowEventHandler OutPlaceInsertRow
		{
			add
			{
				OutPlaceInsertRowEvent = (OutPlaceInsertRowEventHandler) System.Delegate.Combine(OutPlaceInsertRowEvent, value);
			}
			remove
			{
				OutPlaceInsertRowEvent = (OutPlaceInsertRowEventHandler) System.Delegate.Remove(OutPlaceInsertRowEvent, value);
			}
		}
		
		
		public delegate void CellValidatedHandler(object sender, RowColChangedEventArgs e);
		private CellValidatedHandler CellValidatedEvent;
		public event CellValidatedHandler CellValidated
		{
			add
			{
				CellValidatedEvent = (CellValidatedHandler) System.Delegate.Combine(CellValidatedEvent, value);
			}
			remove
			{
				CellValidatedEvent = (CellValidatedHandler) System.Delegate.Remove(CellValidatedEvent, value);
			}
		}
		
		
		public delegate void Custom_KeydownHandler(object sender, EventArgs e);
		private Custom_KeydownHandler Custom_KeydownEvent;
		public event Custom_KeydownHandler Custom_Keydown
		{
			add
			{
				Custom_KeydownEvent = (Custom_KeydownHandler) System.Delegate.Combine(Custom_KeydownEvent, value);
			}
			remove
			{
				Custom_KeydownEvent = (Custom_KeydownHandler) System.Delegate.Remove(Custom_KeydownEvent, value);
			}
		}
		
		
		private int m_OldCol = -1;
		private int m_OldRow = -1;
		private string m_OldValue = "";
		private int m_NewCol;
		private int m_NewRow;
		
		//binding datatable ,form
		private Form m_Form;
		private DataTable m_Table;
		private DataView m_View;
		private CurrencyManager m_CurMan;
		
		public void SetBinding(Form i_Form, DataTable i_Table)
		{
			m_Form = i_Form;
			m_Table = i_Table;
			m_Table.RowDeleted += m_Table_RowDeleted;
			DataView v_View = default(DataView);
			v_View = m_Table.DefaultView;
			v_View.AllowNew = false;
			this.SetDataBinding(v_View, "");
			m_View = v_View;
			m_CurMan = (CurrencyManager) (m_Form.BindingContext[v_View]);
		}
		
		public void SetBindingWithView(Form i_Form, DataView i_View)
		{
			m_Form = i_Form;
			m_Table = i_View.Table;
			m_Table.RowDeleted += m_Table_RowDeleted;
			i_View.AllowNew = false;
			this.SetDataBinding(i_View, "");
			m_View = i_View;
			m_CurMan = (CurrencyManager) (m_Form.BindingContext[i_View]);
		}
		
		//Tra ve hang hien tai
		public DataRow getCurrentRow()
		{
			return m_View[m_CurMan.Position].Row;
		}
		
		//Tra ve CurMan
		public CurrencyManager getCurrencyManager()
		{
			return m_CurMan;
		}
		
		//Tra ve View duoc binding
		public DataView getBindingView()
		{
			return m_View;
		}
		
		//Bat su kien da xoa hang cua m_Table
		private void m_Table_RowDeleted(object sender, System.Data.DataRowChangeEventArgs e)
		{
			m_Table.AcceptChanges();
			m_CurMan.Refresh();
			this.Focus();
		}
		
		protected override bool ProcessCmdKey(ref System.Windows.Forms.Message msg, System.Windows.Forms.Keys keyData)
		{
			int v_KeyCode = msg.WParam.ToInt32();
			
			if (v_KeyCode == System.Convert.ToInt32(Keys.Delete))
			{
				//If the whole row is selected when Delete key is pressed, prompt the User.
				if (this.IsSelected(this.CurrentCell.RowNumber))
				{
					if (!this.DeleteRowAllowed())
					{
						return true;
					}
				}
			}
			else if (v_KeyCode == System.Convert.ToInt32(Keys.F4))
			{
				OutPlaceUpdate();
				return true;
			}
			else if (v_KeyCode == System.Convert.ToInt32(Keys.F3))
			{
				OutPlaceInsert();
				return true;
			}
			else if (v_KeyCode == System.Convert.ToInt32(Keys.F5))
			{
				if (!this.DeleteRowAllowed())
				{
					return true;
				}
			}
			else
			{
				RaiseCustom_Keydown();
			}
			
			return base.ProcessCmdKey(ref msg, keyData);
		}
		
		private void RaiseCustom_Keydown()
		{
			EventArgs v_e = new EventArgs();
			if (Custom_KeydownEvent != null)
				Custom_KeydownEvent(this, v_e);
		}
		
		private void OutPlaceUpdate()
		{
			OutPlaceUpdateEventArgs e = new OutPlaceUpdateEventArgs();
			e.Row = this.getCurrentRow();
			if (OutPlaceUpdateRowEvent != null)
				OutPlaceUpdateRowEvent(this, e);
			if (!e.Cancel)
			{
				m_Table.AcceptChanges();
				m_CurMan.Refresh();
			}
			else
			{
				m_Table.RejectChanges();
			}
			this.Focus();
			this.CurrentRowIndex = this.CurrentCell.RowNumber;
		}
		
		private void OutPlaceInsert()
		{
			OutPlaceInsertEventArgs e = new OutPlaceInsertEventArgs();
			if (OutPlaceInsertRowEvent != null)
				OutPlaceInsertRowEvent(this, e);
			if (!e.Cancel)
			{
				DataRow v_row = m_Table.NewRow();
				CopyRow(e.Row, v_row);
				m_Table.Rows.InsertAt(v_row, e.Position);
				m_Table.AcceptChanges();
				m_CurMan.Refresh();
				this.Focus();
				this.CurrentCell = new DataGridCell(e.Position, 0);
			}
		}
		
		private DataRow CopyRow(DataRow i_FromRow, DataRow i_ToRow)
		{
			DataColumn v_Col = default(DataColumn);
			foreach (DataColumn tempLoopVar_v_Col in i_FromRow.Table.Columns)
			{
				v_Col = tempLoopVar_v_Col;
				i_ToRow[v_Col.ColumnName] = i_FromRow[v_Col.ColumnName];
			}
			return default(DataRow);
		}
		
		private bool DeleteRowAllowed()
		{
			DeleteRowEventArgs e = new DeleteRowEventArgs();
			if (DeleteRowEvent != null)
				DeleteRowEvent(this, e);
			if (e.Cancel)
			{
				return false; //Cannot Delete
			}
			else
			{
				this.getCurrentRow().Delete();
				return true; //Deletion allowed
			}
		}
		
		protected override void OnCurrentCellChanged(System.EventArgs e)
		{
			m_NewRow = this.CurrentCell.RowNumber;
			m_NewCol = this.CurrentCell.ColumnNumber;
			if (m_NewRow != m_OldRow | m_NewCol != m_OldCol)
			{
				if (!isCellChangedAllow())
				{
					this.CurrentCell = new DataGridCell(m_OldRow, m_OldCol);
					return;
				}
				m_OldRow = m_NewRow;
				m_OldCol = m_NewCol;
				m_OldValue = System.Convert.ToString(this[m_OldRow, m_OldCol].ToString());
			}
		}
		
		private bool isCellChangedAllow()
		{
			RowColChangedEventArgs e = new RowColChangedEventArgs();
			//Neu la lan dau tien thi khong kiem tra
			if ((m_OldRow == -1) && (m_OldCol == -1))
			{
				return true;
			}
			
			e.Col = m_OldCol;
			e.Row = m_OldRow;
			
			if (CellValidatedEvent != null)
				CellValidatedEvent(this, e);
			
			if (e.Cancel)
			{
				return false; //Cannot changed
			}
			else
			{
				return true; //Changed
			}
		}
		
	}
	
	public class DeleteRowEventArgs : EventArgs
	{
		private bool _Cancel;
		
		public DeleteRowEventArgs()
		{
			_Cancel = true;
		}
public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
	}
	
	public class OutPlaceUpdateEventArgs : EventArgs
	{
		private bool _Cancel;
		
		public OutPlaceUpdateEventArgs()
		{
			_Cancel = true;
		}
public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
		
		private DataRow m_DataRow;
public DataRow Row
		{
			get
			{
				return m_DataRow;
			}
			set
			{
				m_DataRow = value;
			}
		}
		
	}
	
	public class OutPlaceInsertEventArgs : EventArgs
	{
		private bool _Cancel;
		
		public OutPlaceInsertEventArgs()
		{
			_Cancel = true;
		}
public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
		
		private int m_Position;
public int Position
		{
			get
			{
				return m_Position;
			}
			set
			{
				m_Position = value;
			}
		}
		
		private DataRow m_DataRow;
public DataRow Row
		{
			get
			{
				return m_DataRow;
			}
			set
			{
				m_DataRow = value;
			}
		}
	}
	
	public class RowColChangedEventArgs : EventArgs
	{
		private bool _Cancel;
		
		public RowColChangedEventArgs()
		{
			_Cancel = false;
		}
public bool Cancel
		{
			get
			{
				return _Cancel;
			}
			set
			{
				_Cancel = value;
			}
		}
		
		private int m_row;
public int Row
		{
			get
			{
				return m_row;
			}
			set
			{
				m_row = value;
			}
		}
		
		private int m_col;
public int Col
		{
			get
			{
				return m_col;
			}
			set
			{
				m_col = value;
			}
		}
	}
}
