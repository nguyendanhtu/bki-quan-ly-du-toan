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
using IP.Core.IPCommon;

//NHIỆM VỤ CỦA CLASS:
//
//  - là class chứa template method cho in-place editing
//
//
//


namespace IP.Core.IPUserService
{
	public class CGridRowUpdate2DB
	{
		
#region MEMBERS
		private bool m_isRowEditing = false;
		private CSaveTrangThai1DongCuaGrid m_oCSaveTrangThai1DongCuaGrid;
		private System.Data.SqlClient.SqlTransaction m_trans;
		private object m_usObject;
		private C1FlexGrid m_fg;
		private int m_current_row;
		
#endregion
		
		
#region Public interface
		
		public CGridRowUpdate2DB(object i_usObject)
		{
			Debug.Assert(!(i_usObject == null), "e, sao khong khoi tao -csung");
			m_usObject = i_usObject;
		}
		
		public void handle_StartEdit(C1FlexGrid i_c1fg, 
			RowColEventArgs e)
		{
			if (m_isRowEditing)
			{
				return;
			}
			if (GridRow2Me_4_IsUpdatableEvent != null)
				GridRow2Me_4_IsUpdatableEvent(i_c1fg, e.Row, m_usObject);
			m_fg = i_c1fg;
			m_current_row = e.Row;
			BeginTran();
			bool v_isUpdatable = default(bool);
			if (CheckIsUpdatableEvent != null)
				CheckIsUpdatableEvent(m_trans, m_usObject, ref v_isUpdatable);
			if (v_isUpdatable)
			{
				m_isRowEditing = true;
				m_oCSaveTrangThai1DongCuaGrid = new CSaveTrangThai1DongCuaGrid(i_c1fg, e.Row);
			}
			else
			{
				BaseMessages.MsgBox_Warning(15);
				Rollback();
				e.Cancel = true;
			}
		}
		
		public void handle_CancelRowEditing()
		{
			if (!m_isRowEditing)
			{
				return;
			}
			m_isRowEditing = false;
			m_oCSaveTrangThai1DongCuaGrid.UndoTrangThai1Dong();
			this.Rollback();
		}
		
		
		public void handle_BeforeRowColChange(C1FlexGrid i_c1fg, RangeEventArgs e)
		{
			if (e.OldRange.r1 == e.NewRange.r1 & e.OldRange.r2 == e.NewRange.r2)
			{
				return;
			}
			if (!m_isRowEditing)
			{
				return;
			}
			
			Update2DB(i_c1fg, ref e.Cancel);
		}
		
		
		public void handle_FormClosing(C1FlexGrid i_c1fg, System.ComponentModel.CancelEventArgs e, ref bool o_formShouldStayOpened)
		{
			o_formShouldStayOpened = false;
			if (!m_isRowEditing)
			{
				return;
			}
			DialogResult v_UserAction = BaseMessages.MsgBox_YES_NO_CANCEL(17);
			switch (v_UserAction)
			{
				case DialogResult.No:
					Rollback();
					m_oCSaveTrangThai1DongCuaGrid.UndoTrangThai1Dong();
					m_isRowEditing = false;
					return;
				case DialogResult.Cancel:
					e.Cancel = true;
					o_formShouldStayOpened = true;
					break;
				case DialogResult.OK:
					
					System.Boolean temp_eCancel = e.Cancel;
					Update2DB(i_c1fg, ref temp_eCancel);
					e.Cancel = temp_eCancel;
					o_formShouldStayOpened = e.Cancel;
					break;
			}
		}
		
		public delegate void Update_withoutCommitHandler(System.Data.SqlClient.SqlTransaction i_trans, object i_usObject, ref bool o_isSucceeded, ref string o_errorMessage2Display);
		private Update_withoutCommitHandler Update_withoutCommitEvent;
		public event Update_withoutCommitHandler Update_withoutCommit
		{
			add
			{
				Update_withoutCommitEvent = (Update_withoutCommitHandler) System.Delegate.Combine(Update_withoutCommitEvent, value);
			}
			remove
			{
				Update_withoutCommitEvent = (Update_withoutCommitHandler) System.Delegate.Remove(Update_withoutCommitEvent, value);
			}
		}
		
		public delegate void CheckIsUpdatable_handler(System.Data.SqlClient.SqlTransaction i_trans, object i_usObject, ref bool o_IsUpdatable);
		private CheckIsUpdatable_handler CheckIsUpdatableEvent;
		public event CheckIsUpdatable_handler CheckIsUpdatable
		{
			add
			{
				CheckIsUpdatableEvent = (CheckIsUpdatable_handler) System.Delegate.Combine(CheckIsUpdatableEvent, value);
			}
			remove
			{
				CheckIsUpdatableEvent = (CheckIsUpdatable_handler) System.Delegate.Remove(CheckIsUpdatableEvent, value);
			}
		}
		
		public delegate void GridRow2Me_4_IsUpdatable_Handler(C1FlexGrid i_c1fg, int i_row, object i_UsObject);
		private GridRow2Me_4_IsUpdatable_Handler GridRow2Me_4_IsUpdatableEvent;
		public event GridRow2Me_4_IsUpdatable_Handler GridRow2Me_4_IsUpdatable
		{
			add
			{
				GridRow2Me_4_IsUpdatableEvent = (GridRow2Me_4_IsUpdatable_Handler) System.Delegate.Combine(GridRow2Me_4_IsUpdatableEvent, value);
			}
			remove
			{
				GridRow2Me_4_IsUpdatableEvent = (GridRow2Me_4_IsUpdatable_Handler) System.Delegate.Remove(GridRow2Me_4_IsUpdatableEvent, value);
			}
		}
		
		public delegate void GridRow2Me_4_Update_Handler(C1FlexGrid i_c1fg, int i_row, object i_UsObject);
		private GridRow2Me_4_Update_Handler GridRow2Me_4_UpdateEvent;
		public event GridRow2Me_4_Update_Handler GridRow2Me_4_Update
		{
			add
			{
				GridRow2Me_4_UpdateEvent = (GridRow2Me_4_Update_Handler) System.Delegate.Combine(GridRow2Me_4_UpdateEvent, value);
			}
			remove
			{
				GridRow2Me_4_UpdateEvent = (GridRow2Me_4_Update_Handler) System.Delegate.Remove(GridRow2Me_4_UpdateEvent, value);
			}
		}
		
		public delegate void Data2GridRow_AfterCommit_Handler(C1FlexGrid i_c1fg, int i_row, object i_UsObject);
		private Data2GridRow_AfterCommit_Handler Data2GridRow_AfterEditEvent;
		public event Data2GridRow_AfterCommit_Handler Data2GridRow_AfterEdit
		{
			add
			{
				Data2GridRow_AfterEditEvent = (Data2GridRow_AfterCommit_Handler) System.Delegate.Combine(Data2GridRow_AfterEditEvent, value);
			}
			remove
			{
				Data2GridRow_AfterEditEvent = (Data2GridRow_AfterCommit_Handler) System.Delegate.Remove(Data2GridRow_AfterEditEvent, value);
			}
		}
		
		
#endregion
		
#region Privates
		public void Update2DB(C1FlexGrid i_c1fg, ref bool eCancel)
		{
			
			if (GridRow2Me_4_UpdateEvent != null)
				GridRow2Me_4_UpdateEvent(i_c1fg, i_c1fg.Row, m_usObject);
			bool v_IsSucceeded = false;
			string v_errMsg = "";
			if (Update_withoutCommitEvent != null)
				Update_withoutCommitEvent(m_trans, m_usObject, ref v_IsSucceeded, ref v_errMsg);
			if (v_IsSucceeded)
			{
				m_isRowEditing = false;
				this.Commit();
				if (Data2GridRow_AfterEditEvent != null)
					Data2GridRow_AfterEditEvent(m_fg, m_current_row, m_usObject);
				return;
			}
			
			//if failed to update to db
			string v_msg_ask = v_errMsg + Microsoft.VisualBasic.Constants.vbCrLf + BaseMessages.GetMsg(16);
			if (BaseMessages.MsgBox_Confirm(v_msg_ask))
			{
				eCancel = true;
			}
			else
			{
				m_isRowEditing = false;
				m_oCSaveTrangThai1DongCuaGrid.UndoTrangThai1Dong();
				Rollback();
			}
		}
		
#endregion
		
#region Must Override
		//Protected MustOverride Sub GridRow2Me_4_IsUpdatable(ByVal i_c1fg As C1FlexGrid, ByVal i_row As Integer)
		//Protected MustOverride Sub GridRow2Me_4_Update(ByVal i_c1fg As C1FlexGrid, ByVal i_row As Integer)
		//Protected MustOverride Sub Update_withoutCommit(ByVal i_trans As SqlClient.SqlTransaction, _
		//                                                ByRef o_isSucceeded As Boolean)
		//Protected MustOverride Function IsUpdatable(ByVal i_trans As SqlClient.SqlTransaction) As Boolean
		
		
#endregion
		
#region Overridable
		protected void Rollback()
		{
			m_trans.Rollback();
		}
		protected void Commit()
		{
			m_trans.Commit();
			
		}
		
		protected void BeginTran()
		{
			US_Object v_us = new US_Object();
			m_trans = v_us.BeginTransaction();
		}
		
#endregion
		
		
	}
	
	
}
