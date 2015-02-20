// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using System.ComponentModel;
using C1.Win.C1FlexGrid;
using IP.Core.IPUserService;
using IP.Core.IPCommon;
using IP.Core.IPException;


namespace IP.Core.IPSystemAdmin
{
	public class CC1InplaceEdittingAutoAddRowAndUpdateDBController
	{
		
#region Member
		private US_Object m_us_cur;
		private DataSet m_ds_source;
		private C1FlexGrid m_fg;
		private ITransferDataRow m_obj_transfer;
		private e_CC1InplaceEditting_NewRowPosition m_e_new_row_position;
		private CC1InplaceEdittingController m_obj_edit_controller;
		
		//Insert event
		public delegate void BeforeInsertHandler(object sender, CC1InplaceEdittingEventArgs e);
		private BeforeInsertHandler BeforeInsertEvent;
		public event BeforeInsertHandler BeforeInsert
		{
			add
			{
				BeforeInsertEvent = (BeforeInsertHandler) System.Delegate.Combine(BeforeInsertEvent, value);
			}
			remove
			{
				BeforeInsertEvent = (BeforeInsertHandler) System.Delegate.Remove(BeforeInsertEvent, value);
			}
		}
		
		
		public delegate void OnInsertHandler(object sender, CC1InplaceEdittingOnEventArgs e);
		private OnInsertHandler OnInsertEvent;
		public event OnInsertHandler OnInsert
		{
			add
			{
				OnInsertEvent = (OnInsertHandler) System.Delegate.Combine(OnInsertEvent, value);
			}
			remove
			{
				OnInsertEvent = (OnInsertHandler) System.Delegate.Remove(OnInsertEvent, value);
			}
		}
		
		
		public delegate void OnCancelInsertHandler(object sender, EventArgs e);
		private OnCancelInsertHandler OnCancelInsertEvent;
		public event OnCancelInsertHandler OnCancelInsert
		{
			add
			{
				OnCancelInsertEvent = (OnCancelInsertHandler) System.Delegate.Combine(OnCancelInsertEvent, value);
			}
			remove
			{
				OnCancelInsertEvent = (OnCancelInsertHandler) System.Delegate.Remove(OnCancelInsertEvent, value);
			}
		}
		
		
		//Update event
		public delegate void BeforeUpdateHandler(object sender, CC1InplaceEdittingEventArgs e);
		private BeforeUpdateHandler BeforeUpdateEvent;
		public event BeforeUpdateHandler BeforeUpdate
		{
			add
			{
				BeforeUpdateEvent = (BeforeUpdateHandler) System.Delegate.Combine(BeforeUpdateEvent, value);
			}
			remove
			{
				BeforeUpdateEvent = (BeforeUpdateHandler) System.Delegate.Remove(BeforeUpdateEvent, value);
			}
		}
		
		
		public delegate void OnUpdateHandler(object sender, CC1InplaceEdittingOnEventArgs e);
		private OnUpdateHandler OnUpdateEvent;
		public event OnUpdateHandler OnUpdate
		{
			add
			{
				OnUpdateEvent = (OnUpdateHandler) System.Delegate.Combine(OnUpdateEvent, value);
			}
			remove
			{
				OnUpdateEvent = (OnUpdateHandler) System.Delegate.Remove(OnUpdateEvent, value);
			}
		}
		
		
		public delegate void OnCancelUpdateHandler(object sender, EventArgs e);
		private OnCancelUpdateHandler OnCancelUpdateEvent;
		public event OnCancelUpdateHandler OnCancelUpdate
		{
			add
			{
				OnCancelUpdateEvent = (OnCancelUpdateHandler) System.Delegate.Combine(OnCancelUpdateEvent, value);
			}
			remove
			{
				OnCancelUpdateEvent = (OnCancelUpdateHandler) System.Delegate.Remove(OnCancelUpdateEvent, value);
			}
		}
		
		
		//Delete event
		public delegate void BeforeDeleteHandler(object sender, CC1InplaceEdittingEventArgs e);
		private BeforeDeleteHandler BeforeDeleteEvent;
		public event BeforeDeleteHandler BeforeDelete
		{
			add
			{
				BeforeDeleteEvent = (BeforeDeleteHandler) System.Delegate.Combine(BeforeDeleteEvent, value);
			}
			remove
			{
				BeforeDeleteEvent = (BeforeDeleteHandler) System.Delegate.Remove(BeforeDeleteEvent, value);
			}
		}
		
		
		public delegate void OnDeleteHandler(object sender, CC1InplaceEdittingOnEventArgs e);
		private OnDeleteHandler OnDeleteEvent;
		public event OnDeleteHandler OnDelete
		{
			add
			{
				OnDeleteEvent = (OnDeleteHandler) System.Delegate.Combine(OnDeleteEvent, value);
			}
			remove
			{
				OnDeleteEvent = (OnDeleteHandler) System.Delegate.Remove(OnDeleteEvent, value);
			}
		}
		
		
		public delegate void OnCancelDeleteHandler(object sender, EventArgs e);
		private OnCancelDeleteHandler OnCancelDeleteEvent;
		public event OnCancelDeleteHandler OnCancelDelete
		{
			add
			{
				OnCancelDeleteEvent = (OnCancelDeleteHandler) System.Delegate.Combine(OnCancelDeleteEvent, value);
			}
			remove
			{
				OnCancelDeleteEvent = (OnCancelDeleteHandler) System.Delegate.Remove(OnCancelDeleteEvent, value);
			}
		}
		
		
#endregion
		
#region public interface
public bool is_editting
		{
			get
			{
				return m_obj_edit_controller.is_editting;
			}
		}
		
public e_CC1InplaceEdittingMode editting_mode
		{
			get
			{
				return m_obj_edit_controller.editting_mode;
			}
		}
		
		public CC1InplaceEdittingAutoAddRowAndUpdateDBController(C1FlexGrid i_fg, US_Object i_us_obj, DataSet i_ds_source, ITransferDataRow i_obj_transfer)
		{
			m_fg = i_fg;
			m_us_cur = i_us_obj;
			m_ds_source = i_ds_source;
			m_obj_transfer = i_obj_transfer;
			m_obj_edit_controller = new CC1InplaceEdittingController(m_fg);
			m_e_new_row_position = e_CC1InplaceEditting_NewRowPosition.next_row;
			
			m_fg.StartEdit += this.catch_fg_StartEdit;
			
			m_obj_edit_controller.BeforeUpdate += m_obj_edit_controller_BeforeUpdate;
			m_obj_edit_controller.OnUpdate += m_obj_edit_controller_OnUpdate;
			m_obj_edit_controller.OnCancelUpdate += m_obj_edit_controller_OnCancelUpdate;
			
			m_obj_edit_controller.BeforeInsert += m_obj_edit_controller_BeforeInsert;
			m_obj_edit_controller.OnInsert += m_obj_edit_controller_OnInsert;
			m_obj_edit_controller.OnCancelInsert += m_obj_edit_controller_OnCancelInsert;
			
			m_obj_edit_controller.BeforeDelete += m_obj_edit_controller_BeforeDelete;
			m_obj_edit_controller.OnDelete += m_obj_edit_controller_OnDelete;
			m_obj_edit_controller.OnCancelDelete += m_obj_edit_controller_OnCancelDelete;
		}
		
		public CC1InplaceEdittingAutoAddRowAndUpdateDBController(C1FlexGrid i_fg, 
			US_Object i_us_obj, 
			DataSet i_ds_source, 
			ITransferDataRow i_obj_transfer, 
			e_CC1InplaceEditting_NewRowPosition i_e_new_row_position) : this(i_fg, i_us_obj, i_ds_source, i_obj_transfer)
		{
			m_e_new_row_position = i_e_new_row_position;
		}
		
		public virtual void StartInsert()
		{
			Debug.Assert((m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.insert_mode), 
				"FlexGrid co mode update hoac delete khi goi startInsert");
			if (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none)
			{
				m_us_cur.ClearAllFields();
				CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
				if (BeforeInsertEvent != null)
					BeforeInsertEvent(this, v_obj_even_arg);
				if (v_obj_even_arg.continue_editting)
				{
					//Them hang vao grid
					//If (m_fg.Rows.Count = m_fg.Rows.Fixed) Then
					//    m_fg.Rows.Add()
					//    m_fg.Focus()
					//    m_fg.Row = m_fg.Rows.Count - 1
					//    m_fg.Col = m_fg.Cols.Fixed
					//Else
					//    Dim v_i_new_grid_row As Integer = m_fg.Row + 1
					//    m_fg.Rows.Insert(v_i_new_grid_row)
					//    m_fg.Focus()
					//    m_fg.Row = v_i_new_grid_row
					//    m_fg.Col = m_fg.Cols.Fixed
					//    m_fg.ShowCell(v_i_new_grid_row, m_fg.Col)
					//End If
					int v_i_new_grid_row = get_new_row_position();
					m_fg.Rows.Insert(v_i_new_grid_row);
					m_fg.ShowCell(v_i_new_grid_row, m_fg.Col);
					m_fg.Focus();
					m_fg.Row = v_i_new_grid_row;
					m_fg.Col = m_fg.Cols.Fixed;
					m_obj_edit_controller.StartInsert();
				}
				else
				{
					CancelEdit();
				}
			}
		}
		
		public virtual void StartUpdate()
		{
			Debug.Assert((m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.update_mode) 
				|| (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.insert_mode), 
				"FlexGrid co mode delete khi goi startUpdate");
			if (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none)
			{
				m_us_cur.ClearAllFields();
				CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
				if (BeforeUpdateEvent != null)
					BeforeUpdateEvent(this, v_obj_even_arg);
				if (v_obj_even_arg.continue_editting)
				{
					m_obj_edit_controller.StartUpdate();
				}
				else
				{
					CancelEdit();
				}
			}
		}
		
		public virtual void StartDelete()
		{
			Debug.Assert((m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.delete_mode), 
				"FlexGrid co mode insert hoac update khi goi startDelete");
			if (m_obj_edit_controller.editting_mode == e_CC1InplaceEdittingMode.none)
			{
				m_us_cur.ClearAllFields();
				CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
				if (BeforeDeleteEvent != null)
					BeforeDeleteEvent(this, v_obj_even_arg);
				if (v_obj_even_arg.continue_editting)
				{
					m_obj_edit_controller.StartDelete();
					//RemoveHandler m_fg.BeforeRowColChange, AddressOf catch_m_fg_before_row_col_change
					CommitEdit();
					//AddHandler m_fg.BeforeRowColChange, AddressOf catch_m_fg_before_row_col_change
				}
				else
				{
					CancelEdit();
				}
			}
		}
		
		public void CommitEdit()
		{
			m_obj_edit_controller.CommitEdit();
		}
		
		public void CancelEdit()
		{
			switch (m_obj_edit_controller.editting_mode)
			{
				case e_CC1InplaceEdittingMode.insert_mode:
					break;
				case e_CC1InplaceEdittingMode.update_mode:
					break;
				case e_CC1InplaceEdittingMode.delete_mode:
					break;
				case e_CC1InplaceEdittingMode.none:
					break;
			}
			m_us_cur.Rollback();
			m_obj_edit_controller.CancelEdit();
		}
#endregion
		
#region private method
		
		private int get_new_row_position()
		{
			int v_i_new_grid_row = 0;
			if (m_fg.Rows.Count == m_fg.Rows.Fixed)
			{
				v_i_new_grid_row = m_fg.Rows.Fixed;
				return v_i_new_grid_row;
			}
			
			switch (m_e_new_row_position)
			{
				case e_CC1InplaceEditting_NewRowPosition.next_row:
					v_i_new_grid_row = m_fg.Row + 1;
					break;
				case e_CC1InplaceEditting_NewRowPosition.last_row:
					v_i_new_grid_row = m_fg.Rows.Count;
					break;
				default:
					Debug.Assert(false, "CC1InplaceEditting chua implement kieu new row position nay");
					break;
			}
			
			return v_i_new_grid_row;
		}
		
		private void catch_fg_StartEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
		{
			try
			{
				if (!CGridUtils.IsThere_Any_NonFixed_Row(m_fg))
				{
					return;
				}
				if (!CGridUtils.isValid_NonFixed_RowIndex(m_fg, m_fg.Row))
				{
					return;
				}
				StartUpdate();
			}
			catch (Exception v_e)
			{
				e.Cancel = true;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void grid_2_us_object(US_Object i_us_object, int i_grid_row)
		{
			DataRow v_dr_cur = default(DataRow);
			v_dr_cur = (DataRow) (m_fg.Rows[i_grid_row].UserData);
			i_us_object.DataRow2Me(v_dr_cur);
		}
		
		private void us_object_2_grid(US_Object i_us_object, int i_grid_row)
		{
			if (m_fg.Rows[i_grid_row].UserData == null)
			{
				m_fg.Rows[i_grid_row].UserData = m_ds_source.Tables[0].NewRow();
			}
			DataRow v_dr_but_toan = (DataRow) (m_fg.Rows[i_grid_row].UserData);
			i_us_object.Me2DataRow(v_dr_but_toan);
			m_obj_transfer.DataRow2GridRow(v_dr_but_toan, i_grid_row);
		}
		
		private void restored_old_grid_data(int i_grid_row)
		{
			DataRow v_dr_cur = (DataRow) (m_fg.Rows[i_grid_row].UserData);
			m_obj_transfer.DataRow2GridRow(v_dr_cur, i_grid_row);
		}
		
		private void m_obj_edit_controller_BeforeUpdate(object sender, CC1InplaceEdittingEventArgs e)
		{
			try
			{
				int v_i_grid_row = m_fg.Row;
				m_us_cur.ClearAllFields();
				grid_2_us_object(m_us_cur, v_i_grid_row);
				m_us_cur.BeginTransaction();
				if (m_us_cur.isUpdatable())
				{
					e.continue_editting = true;
				}
			}
			catch (Exception v_e)
			{
				m_us_cur.Rollback();
				e.continue_editting = false;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_OnUpdate(object sender, CC1InplaceEdittingOnEventArgs e)
		{
			try
			{
				m_us_cur.Update();
				CC1InplaceEdittingOnEventArgs v_e = new CC1InplaceEdittingOnEventArgs(e_CC1_inplace_editting_next_action.success_and_change_to_none_status);
				if (OnUpdateEvent != null)
					OnUpdateEvent(this, v_e);
				if (v_e.next_action == e_CC1_inplace_editting_next_action.success_and_change_to_none_status)
				{
					m_us_cur.CommitTransaction();
					us_object_2_grid(m_us_cur, m_fg.Row);
					e.next_action = e_CC1_inplace_editting_next_action.success_and_change_to_none_status;
				}
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
				e.next_action = e_CC1_inplace_editting_next_action.continue_editting;
			}
		}
		
		private void m_obj_edit_controller_OnCancelUpdate(object sender, EventArgs e)
		{
			try
			{
				m_us_cur.Rollback();
				//Dua du lieu cu len grid
				restored_old_grid_data(m_fg.Row);
				if (OnCancelUpdateEvent != null)
					OnCancelUpdateEvent(this, new EventArgs());
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_BeforeInsert(object sender, CC1InplaceEdittingEventArgs e)
		{
			try
			{
				m_us_cur.BeginTransaction();
				e.continue_editting = true;
			}
			catch (Exception v_e)
			{
				e.continue_editting = false;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_OnInsert(object sender, CC1InplaceEdittingOnEventArgs e)
		{
			try
			{
				CC1InplaceEdittingOnEventArgs v_e = new CC1InplaceEdittingOnEventArgs(e_CC1_inplace_editting_next_action.success_and_change_to_none_status);
				m_us_cur.Insert();
				if (OnInsertEvent != null)
					OnInsertEvent(this, v_e);
				if (v_e.next_action == e_CC1_inplace_editting_next_action.success_and_change_to_none_status)
				{
					m_us_cur.CommitTransaction();
					us_object_2_grid(m_us_cur, m_fg.Row);
				}
			}
			catch (Exception v_e)
			{
				e.next_action = e_CC1_inplace_editting_next_action.continue_editting;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_OnCancelInsert(object sender, EventArgs e)
		{
			try
			{
				m_fg.Rows.Remove(m_fg.Row);
				if (OnCancelDeleteEvent != null)
					OnCancelDeleteEvent(this, new System.EventArgs());
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_BeforeDelete(object sender, CC1InplaceEdittingEventArgs e)
		{
			try
			{
				int v_i_grid_row = m_fg.Row;
				grid_2_us_object(m_us_cur, v_i_grid_row);
				m_us_cur.BeginTransaction();
				if (m_us_cur.isUpdatable())
				{
					e.continue_editting = true;
				}
			}
			catch (Exception v_e)
			{
				m_us_cur.Rollback();
				e.continue_editting = false;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_OnDelete(object sender, CC1InplaceEdittingOnEventArgs e)
		{
			try
			{
				CC1InplaceEdittingOnEventArgs v_e = new CC1InplaceEdittingOnEventArgs(e_CC1_inplace_editting_next_action.success_and_change_to_none_status);
				m_us_cur.Delete();
				if (OnDeleteEvent != null)
					OnDeleteEvent(this, v_e);
				if (v_e.next_action == e_CC1_inplace_editting_next_action.success_and_change_to_none_status)
				{
					m_us_cur.CommitTransaction();
					m_fg.Rows.Remove(m_fg.Row);
				}
			}
			catch (Exception v_e)
			{
				e.next_action = e_CC1_inplace_editting_next_action.continue_editting;
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
		
		private void m_obj_edit_controller_OnCancelDelete(object sender, EventArgs e)
		{
			try
			{
				m_us_cur.Rollback();
				if (OnCancelDeleteEvent != null)
					OnCancelDeleteEvent(this, new EventArgs());
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_objErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_objErrHandler.showErrorMessage();
			}
		}
#endregion
		
		
	}
	
}
