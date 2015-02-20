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
using IP.Core.IPCommon;
using IP.Core.IPCommon.CommonMsgNumber;


//Dieu khien edit tai cho flexgrid
namespace IP.Core.IPSystemAdmin
{
	public class CC1InplaceEdittingController
	{
		
#region Member
		protected e_CC1InplaceEdittingMode m_e_mode;
		protected C1FlexGrid m_fg;
		private bool m_b_update_when_row_changed;
		
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
		
		
		protected bool m_b_commit_successful;
#endregion
		
		public CC1InplaceEdittingController(C1FlexGrid i_fg)
		{
			m_fg = i_fg;
			m_e_mode = e_CC1InplaceEdittingMode.none;
			m_b_update_when_row_changed = true;
			m_b_commit_successful = false;
			m_fg.BeforeRowColChange += catch_m_fg_before_row_col_change;
			m_fg.Leave += catch_m_fg_leave;
		}
		
public bool is_updated_when_row_changed
		{
			get
			{
				return m_b_update_when_row_changed;
			}
			set
			{
				m_b_update_when_row_changed = value;
			}
		}
		
public bool is_editting
		{
			get
			{
				return m_e_mode != e_CC1InplaceEdittingMode.none;
			}
		}
		
public e_CC1InplaceEdittingMode editting_mode
		{
			get
			{
				return m_e_mode;
			}
		}
		
		public virtual void StartInsert()
		{
			Debug.Assert((m_e_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_e_mode == e_CC1InplaceEdittingMode.insert_mode), 
				"FlexGrid co mode update hoac delete khi goi startInsert");
			if (m_fg.FinishEditing())
			{
				if (m_e_mode == e_CC1InplaceEdittingMode.none)
				{
					CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
					if (BeforeInsertEvent != null)
						BeforeInsertEvent(this, v_obj_even_arg);
					if (v_obj_even_arg.continue_editting)
					{
						m_e_mode = e_CC1InplaceEdittingMode.insert_mode;
						m_b_commit_successful = false;
					}
					else
					{
						CancelEdit();
					}
				}
			}
		}
		
		public virtual void StartUpdate()
		{
			Debug.Assert((m_e_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_e_mode == e_CC1InplaceEdittingMode.update_mode) 
				|| (m_e_mode == e_CC1InplaceEdittingMode.insert_mode), 
				"FlexGrid co mode delete khi goi startUpdate");
			if (m_e_mode == e_CC1InplaceEdittingMode.none)
			{
				CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
				if (BeforeUpdateEvent != null)
					BeforeUpdateEvent(this, v_obj_even_arg);
				if (v_obj_even_arg.continue_editting)
				{
					m_e_mode = e_CC1InplaceEdittingMode.update_mode;
					m_b_commit_successful = false;
				}
				else
				{
					CancelEdit();
				}
			}
		}
		
		public virtual void StartDelete()
		{
			if (m_fg.Rows.Count == m_fg.Rows.Fixed)
			{
				return ;
			}
			//Ket thuc trang thai edit cua grid
			if (!m_fg.FinishEditing())
			{
				return;
			}
			//confirm user
			if (!BaseMessages.MsgBox_Confirm(eConfirmMsg.Sure_to_delete.ToString()))
			{
				return;
			}
			
			if (m_e_mode == e_CC1InplaceEdittingMode.none)
			{
				CC1InplaceEdittingEventArgs v_obj_even_arg = new CC1InplaceEdittingEventArgs(true);
				if (BeforeDeleteEvent != null)
					BeforeDeleteEvent(this, v_obj_even_arg);
				if (v_obj_even_arg.continue_editting)
				{
					m_e_mode = e_CC1InplaceEdittingMode.delete_mode;
					m_b_commit_successful = false;
					m_fg.BeforeRowColChange -= catch_m_fg_before_row_col_change;
					CommitEdit();
					m_fg.BeforeRowColChange += catch_m_fg_before_row_col_change;
				}
				else
				{
					CancelEdit();
				}
			}
			else
			{
				if (m_e_mode == e_CC1InplaceEdittingMode.insert_mode)
				{
					this.CancelEdit();
				}
				else
				{
					if (m_e_mode == e_CC1InplaceEdittingMode.update_mode)
					{
						this.CancelEdit();
						this.StartDelete();
					}
				}
			}
		}
		
		public virtual void CancelEdit()
		{
			m_fg.BeforeRowColChange -= catch_m_fg_before_row_col_change;
			EventArgs v_obj_even_arg = new EventArgs();
			switch (m_e_mode)
			{
				case e_CC1InplaceEdittingMode.insert_mode:
					if (OnCancelInsertEvent != null)
						OnCancelInsertEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.update_mode:
					if (OnCancelUpdateEvent != null)
						OnCancelUpdateEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.delete_mode:
					if (OnCancelDeleteEvent != null)
						OnCancelDeleteEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.none:
					break;
			}
			m_e_mode = e_CC1InplaceEdittingMode.none;
			m_fg.BeforeRowColChange += catch_m_fg_before_row_col_change;
		}
		
		public virtual void CommitEdit()
		{
			CancelEventArgs v_e = new CancelEventArgs(false);
			CommitEdit_when_RowColChange(v_e);
		}
		
		protected virtual void CommitEdit_when_RowColChange(CancelEventArgs e)
		{
			CC1InplaceEdittingOnEventArgs v_obj_even_arg = new CC1InplaceEdittingOnEventArgs(e_CC1_inplace_editting_next_action.success_and_change_to_none_status);
			switch (m_e_mode)
			{
				case e_CC1InplaceEdittingMode.insert_mode:
					if (OnInsertEvent != null)
						OnInsertEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.update_mode:
					if (OnUpdateEvent != null)
						OnUpdateEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.delete_mode:
					if (OnDeleteEvent != null)
						OnDeleteEvent(this, v_obj_even_arg);
					break;
				case e_CC1InplaceEdittingMode.none:
					break;
			}
			process_after_raise_on_event(v_obj_even_arg, e);
		}
		
		protected virtual void process_after_raise_on_event(CC1InplaceEdittingOnEventArgs i_obj_event_arg, CancelEventArgs i_obj_cancel_arg)
		{
			switch (i_obj_event_arg.next_action)
			{
				case e_CC1_inplace_editting_next_action.cancel_editting:
					CancelEdit();
					break;
				case e_CC1_inplace_editting_next_action.success_and_change_to_none_status:
					m_b_commit_successful = true;
					m_e_mode = e_CC1InplaceEdittingMode.none;
					break;
				case e_CC1_inplace_editting_next_action.continue_editting:
					i_obj_cancel_arg.Cancel = true;
					break;
			}
		}
		
		protected virtual void catch_m_fg_before_row_col_change(object sender, C1.Win.C1FlexGrid.RangeEventArgs e)
		{
			if ((m_b_update_when_row_changed) && (e.NewRange.r1 != e.OldRange.r1))
			{
				CancelEventArgs v_e = new CancelEventArgs(false);
				CommitEdit_when_RowColChange(v_e);
				e.Cancel = v_e.Cancel;
			}
		}
		
		protected virtual void catch_m_fg_leave(object sender, System.EventArgs e)
		{
			CommitEdit();
		}
	} //END CLASS DEFINITION CC1InplaceEdittingController
}
