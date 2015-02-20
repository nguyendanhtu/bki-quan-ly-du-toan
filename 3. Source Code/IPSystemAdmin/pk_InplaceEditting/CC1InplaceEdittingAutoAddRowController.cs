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
using IP.Core.IPCommon.CommonMsgNumber;


namespace IP.Core.IPSystemAdmin
{
	public class CC1InplaceEdittingAutoAddRowController : CC1InplaceEdittingController
	{
		
#region Members
		private ITransferDataRow m_obj_trans;
		private e_CC1InplaceEditting_NewRowPosition m_e_new_row_position;
#endregion
		
#region public interface
		public CC1InplaceEdittingAutoAddRowController(C1FlexGrid i_fg, ITransferDataRow i_obj_trans) : base(i_fg)
		{
			m_obj_trans = i_obj_trans;
			m_e_new_row_position = e_CC1InplaceEditting_NewRowPosition.next_row;
		}
		
		public CC1InplaceEdittingAutoAddRowController(C1FlexGrid i_fg, ITransferDataRow i_obj_trans, 
			e_CC1InplaceEditting_NewRowPosition i_e_new_row_position) : this(i_fg, i_obj_trans)
		{
			m_e_new_row_position = i_e_new_row_position;
		}
		
		public override void StartInsert()
		{
			Debug.Assert(this.editting_mode != e_CC1InplaceEdittingMode.delete_mode, "FlexGrid khong duoc co mode delete khi goi startInsert tuanqt");
			if (!m_fg.FinishEditing())
			{
				return;
			}
			
			if ((this.editting_mode == e_CC1InplaceEdittingMode.none) 
				|| (m_fg.Rows.Count == m_fg.Rows.Fixed))
			{
				//Them hang vao grid
				int v_i_new_grid_row = get_new_row_position();
				m_fg.Rows.Insert(v_i_new_grid_row);
				m_fg.ShowCell(v_i_new_grid_row, m_fg.Col);
				m_fg.Focus();
				m_fg.Row = v_i_new_grid_row;
				m_fg.Col = m_fg.Cols.Fixed;
				
				base.StartInsert();
			}
			else
			{
				//Dang o che do insert hay update thi commitedit
				if ((this.editting_mode == e_CC1InplaceEdittingMode.insert_mode) 
					|| (this.editting_mode == e_CC1InplaceEdittingMode.update_mode))
				{
					if (BaseMessages.MsgBox_Confirm(eConfirmMsg.Sure_to_update.ToString()))
					{
						this.CommitEdit();
						//Neu commit thanh cong thi goi lai startinsert
						//Khi goi lai thi mode cua edit controller da ve mode none
						if (m_b_commit_successful)
						{
							this.StartInsert();
						}
						else
						{
							//Neu khong thanh cong thi thoat khoi start insert
						}
					}
					else
					{
						this.CancelEdit();
					}
				}
			}
		}
		
		public override void CancelEdit()
		{
			if (m_fg.Rows.Count == m_fg.Rows.Fixed)
			{
				return ;
			}
			if (!(m_fg.Editor == null))
			{
				//Grid dang o che do edit thi huy bo noi dung dang edit
				m_fg.FinishEditing(false);
			}
			m_fg.BeforeRowColChange -= this.catch_m_fg_before_row_col_change;
			switch (this.editting_mode)
			{
				case e_CC1InplaceEdittingMode.insert_mode:
					m_fg.Rows.Remove(m_fg.Row);
					break;
				case e_CC1InplaceEdittingMode.update_mode:
					restore_grid_row(m_fg.Row);
					break;
				case e_CC1InplaceEdittingMode.delete_mode:
					break;
				case e_CC1InplaceEdittingMode.none:
					break;
			}
			m_fg.BeforeRowColChange += this.catch_m_fg_before_row_col_change;
			base.CancelEdit();
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
		
		protected override void process_after_raise_on_event(CC1InplaceEdittingOnEventArgs i_obj_event_arg, CancelEventArgs i_obj_cancel_arg)
		{
			m_fg.BeforeRowColChange -= this.catch_m_fg_before_row_col_change;
			switch (i_obj_event_arg.next_action)
			{
				case e_CC1_inplace_editting_next_action.cancel_editting:
					CancelEdit();
					break;
				case e_CC1_inplace_editting_next_action.success_and_change_to_none_status:
					if (m_e_mode == e_CC1InplaceEdittingMode.delete_mode)
					{
						m_fg.Rows.Remove(m_fg.Row);
					}
					m_b_commit_successful = true;
					m_e_mode = e_CC1InplaceEdittingMode.none;
					break;
				case e_CC1_inplace_editting_next_action.continue_editting:
					i_obj_cancel_arg.Cancel = true;
					break;
			}
			m_fg.BeforeRowColChange += this.catch_m_fg_before_row_col_change;
		}
		
		private void restore_grid_row(int i_grid_row)
		{
			Debug.Assert(!(m_fg.Rows[i_grid_row].UserData == null), "Chua gan DataRow vao userdata cua gridrow tuanqt");
			DataRow v_dr_source = (DataRow) (m_fg.Rows[i_grid_row].UserData);
			m_obj_trans.DataRow2GridRow(v_dr_source, i_grid_row);
		}
#endregion
		
	}
}
