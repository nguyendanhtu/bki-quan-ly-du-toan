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
	public interface IControlerControl
	{
		bool CanUseControl(string ip_strFormName, string ip_strControlName, string ip_strControlType);
	}
	
	public class CControlFormat
	{
		
#region Nhiệm vụ của class
		//*******************************************************************
		// Class này dùng để format các control dùng trong ứng dụng eSchool
		//*******************************************************************
#endregion
		
#region Constants declaration
		private const string C_FontName = "Tahoma";
		private const double C_FormFontSize = 8.0F;
#endregion
		
#region Data structures
		public enum ButtonStyle
		{
			
			ExitButtonStyle,
			CancelButtonStyle,
			OkButtonStyle,
			
			SmallFunctionButtonStyle,
			MediumFunctionButtonStyle,
			LongFunctionButtonStyle,
			FreeFunctionButtonStyle
		}
		
		public enum LabelStyle
		{
			Title_Info,
			HighLight_Info,
			Additional_Info,
			Prompt_Info
		}
#endregion
		
#region Private services
		private static System.Drawing.Font getRegularFont()
		{
			return new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
		}
		
		private static System.Drawing.Color getRegularForeColor()
		{
			return System.Drawing.Color.Black;
		}
		
		private static System.Drawing.Color getSpecialForeColor()
		{
			return System.Drawing.Color.Maroon;
		}
		
		private static System.Drawing.Color getRegularBackColor()
		{
			return System.Drawing.Color.White;
		}
		
		private static System.Drawing.Font getBoldFont()
		{
			return new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
		}
		
		private static void i_form_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.F1)
			{
				System.Diagnostics.Process.Start(System.Windows.Forms.Application.StartupPath + "\\HELP\\help.chm");
			}
			
		}
		
		private static void formatControlInForms(
			string ip_str_form_name, IControlerControl i_objControlerControl, System.Windows.Forms.Control ip_control)
		{
			
			//If (ip_control.ToString().IndexOf("SIS.Controls.Button.SiSButton") >= 0) Then
			//    If (i_objControlerControl.CanUseControl(ip_str_form_name, ip_control.Name, "") = False) Then
			//        ip_control.Visible = False
			//        ip_control.Enabled = False
			//    End If
			//End If
			if (ip_control is Label)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getSpecialForeColor();
				ip_control.BackColor = getRegularBackColor();
			}
			else if (ip_control is TextBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is GroupBox)
			{
				ip_control.Font = getBoldFont();
				ip_control.ForeColor = getSpecialForeColor();
				ip_control.BackColor = getRegularBackColor();
			}
			else if (ip_control is ComboBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is CheckBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is DateTimePicker)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is Button)
			{
				ip_control.Font = getBoldFont();
				ip_control.ForeColor = getSpecialForeColor();
				if (i_objControlerControl.CanUseControl(ip_str_form_name, ip_control.Name, "") == false)
				{
					ip_control.Visible = false;
					ip_control.Enabled = false;
				}
			}
			else if (ip_control is DateTimePicker)
			{
				((DateTimePicker) ip_control).CalendarForeColor = getRegularForeColor();
				((DateTimePicker) ip_control).CalendarTitleForeColor = getRegularForeColor();
				((DateTimePicker) ip_control).CalendarTrailingForeColor = getRegularForeColor();
			}
			else if (ip_control is MenuStrip)
			{
				ToolStripMenuItem v_obj_tool_strip = default(ToolStripMenuItem);
				foreach (ToolStripMenuItem tempLoopVar_v_obj_tool_strip in ((MenuStrip) ip_control).Items)
				{
					v_obj_tool_strip = tempLoopVar_v_obj_tool_strip;
					formatToolStripMenuItem(ip_str_form_name, i_objControlerControl, v_obj_tool_strip);
				}
			}
			if (ip_control is TabControl)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			
			System.Windows.Forms.Control v_control = default(System.Windows.Forms.Control);
			foreach (System.Windows.Forms.Control tempLoopVar_v_control in ip_control.Controls)
			{
				v_control = tempLoopVar_v_control;
				formatControlInForms(ip_str_form_name, i_objControlerControl, v_control);
			}
			
		}
		
		private static void formatControlInForms(
			string ip_str_form_name, System.Windows.Forms.Control ip_control)
		{
			
			//If (ip_control.ToString().IndexOf("SIS.Controls.Button.SiSButton") >= 0) Then
			//    If (i_objControlerControl.CanUseControl(ip_str_form_name, ip_control.Name, "") = False) Then
			//        ip_control.Visible = False
			//        ip_control.Enabled = False
			//    End If
			//End If
			if (ip_control is Label)
			{
				if (ip_control.Font.Size < 15)
				{
					ip_control.Font = getRegularFont();
				}
				ip_control.ForeColor = getSpecialForeColor();
				ip_control.BackColor = getRegularBackColor();
			}
			else if (ip_control is TextBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is GroupBox)
			{
				ip_control.Font = getBoldFont();
				ip_control.ForeColor = getSpecialForeColor();
				ip_control.BackColor = getRegularBackColor();
			}
			else if (ip_control is ComboBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is CheckBox)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is DateTimePicker)
			{
				ip_control.Font = getRegularFont();
				ip_control.ForeColor = getRegularForeColor();
			}
			else if (ip_control is Button)
			{
				ip_control.Font = getBoldFont();
				ip_control.ForeColor = getSpecialForeColor();
				//If (i_objControlerControl.CanUseControl(ip_str_form_name, ip_control.Name, "") = False) Then
				//    ip_control.Visible = False
				//    ip_control.Enabled = False
				//End If
				//ElseIf TypeOf ip_control Is DateTimePicker Then
				//    CType(ip_control, DateTimePicker).CalendarForeColor = getRegularForeColor()
				//    CType(ip_control, DateTimePicker).CalendarTitleForeColor = getRegularForeColor()
				//    CType(ip_control, DateTimePicker).CalendarTrailingForeColor = getRegularForeColor()
				//    'ElseIf TypeOf ip_control Is MenuStrip Then
				//    '    Dim v_obj_tool_strip As ToolStripMenuItem
				//    '    'For Each v_obj_tool_strip In CType(ip_control, MenuStrip).Items
				//    '    '    formatToolStripMenuItem(ip_str_form_name, i_objControlerControl, v_obj_tool_strip)
				//    '    'Next
				//    'End If
				//    If TypeOf ip_control Is TabControl Then
				//        ip_control.Font = getRegularFont()
				//        ip_control.ForeColor = getRegularForeColor()
				//    End If
				
				System.Windows.Forms.Control v_control = default(System.Windows.Forms.Control);
				foreach (System.Windows.Forms.Control tempLoopVar_v_control in ip_control.Controls)
				{
					v_control = tempLoopVar_v_control;
					formatControlInForms(ip_str_form_name, v_control);
				}
			}
		}
		
		private static void formatToolStripMenuItem(
			string ip_str_form_name, IControlerControl i_objControlerControl, System.Windows.Forms.ToolStripMenuItem ip_obj_toolstripMenuItem)
		{
			if (i_objControlerControl.CanUseControl(ip_str_form_name, ip_obj_toolstripMenuItem.Name, "") == false)
			{
				//v_obj_tool_strip.Visible = False
				ip_obj_toolstripMenuItem.Enabled = false;
			}
			else
			{
				
				ToolStripMenuItem v_obj_tool_strip = default(ToolStripMenuItem);
				foreach (ToolStripMenuItem tempLoopVar_v_obj_tool_strip in ip_obj_toolstripMenuItem.DropDownItems)
				{
					v_obj_tool_strip = tempLoopVar_v_obj_tool_strip;
					formatToolStripMenuItem(ip_str_form_name, i_objControlerControl, v_obj_tool_strip);
					
				}
			}
			
			
			
			
		}
#endregion
		
#region Public interface
		
		public static void setFormStyle(Form i_form, IControlerControl i_objControlerControl, IPFormStyle i_form_style = IPFormStyle.DialogForm)
		{
			try
			{
				i_form.KeyDown += i_form_KeyDown;
				
				System.Windows.Forms.Control v_Control;
				i_form.KeyPreview = true;
				Form with_1 = i_form;
				//.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
				with_1.BackColor = getRegularBackColor();
				with_1.Font = getRegularFont();
				with_1.ForeColor = getRegularForeColor();
				switch (i_form_style)
				{
					case IPFormStyle.DialogForm:
						with_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
						with_1.MaximizeBox = false;
						with_1.MinimizeBox = false;
						with_1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						with_1.ShowInTaskbar = true;
						break;
						
					case IPFormStyle.DockableTopForm:
						with_1.FormBorderStyle = FormBorderStyle.Sizable;
						with_1.MaximizeBox = true;
						with_1.MinimizeBox = true;
						with_1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						with_1.ShowInTaskbar = false;
						break;
					default:
						break;
						
				}
				
				//.ResumeLayout(False)
				//Tund sửa ngày 11/06/2008
				formatControlInForms(i_form.Name, i_objControlerControl, i_form);
				
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, i_form.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
			}
			finally
			{
				
			}
		}
		public static void setFormStyle(Form i_form, IPFormStyle i_form_style = IPFormStyle.DialogForm)
		{
			try
			{
				i_form.KeyDown += i_form_KeyDown;
				
				System.Windows.Forms.Control v_Control;
				i_form.KeyPreview = true;
				Form with_1 = i_form;
				//.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
				with_1.BackColor = getRegularBackColor();
				with_1.Font = getRegularFont();
				with_1.ForeColor = getRegularForeColor();
				switch (i_form_style)
				{
					case IPFormStyle.DialogForm:
						with_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
						with_1.MaximizeBox = false;
						with_1.MinimizeBox = false;
						with_1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						with_1.ShowInTaskbar = true;
						break;
						
					case IPFormStyle.DockableTopForm:
						with_1.FormBorderStyle = FormBorderStyle.Sizable;
						with_1.MaximizeBox = true;
						with_1.MinimizeBox = true;
						with_1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
						with_1.ShowInTaskbar = false;
						break;
					default:
						break;
						
				}
				
				//.ResumeLayout(False)
				//Tund sửa ngày 11/06/2008
				formatControlInForms(i_form.Name, i_form);
				
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, i_form.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
			}
			finally
			{
				
			}
		}
		public static void setFormStyle(Form i_form)
		{
			//***************************************************
			// Dùng để set các property của Form ngoại trừ frmMain
			//***************************************************
			i_form.KeyDown += i_form_KeyDown;
			
			try
			{
				System.Windows.Forms.Control v_Control = default(System.Windows.Forms.Control);
				i_form.KeyPreview = true;
				Form with_1 = i_form;
				//.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
				with_1.BackColor = getRegularBackColor();
				with_1.Font = getRegularFont();
				with_1.ForeColor = getRegularForeColor();
				with_1.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
				with_1.MaximizeBox = false;
				with_1.MinimizeBox = false;
				with_1.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				with_1.ShowInTaskbar = false;
				//.ResumeLayout(False)
				//TA sửa ngày 29/12/2003
				foreach (System.Windows.Forms.Control tempLoopVar_v_Control in with_1.Controls)
				{
					v_Control = tempLoopVar_v_Control;
					if (v_Control is Label)
					{
						v_Control.Font = getRegularFont();
						v_Control.ForeColor = getRegularForeColor();
						v_Control.BackColor = getRegularBackColor();
					}
					else if (v_Control is TextBox)
					{
						v_Control.Font = getRegularFont();
						v_Control.ForeColor = getRegularForeColor();
					}
					else if (v_Control is GroupBox)
					{
						v_Control.Font = getRegularFont();
						v_Control.ForeColor = getRegularForeColor();
						v_Control.BackColor = getRegularBackColor();
					}
					else if (v_Control is DataGrid_Custom)
					{
						v_Control.Font = getRegularFont();
					}
					else if (v_Control is ComboBox)
					{
						v_Control.Font = getRegularFont();
						v_Control.ForeColor = getRegularForeColor();
					}
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, i_form.Text, MessageBoxButtons.OKCancel, MessageBoxIcon.Stop);
			}
			finally
			{
				
			}
		}
		
		public static void setDataGridFormat(DataGrid i_datagrid)
		{
			//***************************************************
			// Dùng để set các property của DataGrid
			//***************************************************
			DataGrid with_1 = i_datagrid;
			with_1.AlternatingBackColor = System.Drawing.Color.OldLace;
			with_1.BackColor = System.Drawing.Color.OldLace;
			with_1.BackgroundColor = System.Drawing.Color.Tan;
			with_1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			with_1.CaptionBackColor = System.Drawing.Color.SaddleBrown;
			with_1.CaptionForeColor = System.Drawing.Color.OldLace;
			with_1.FlatMode = true;
			with_1.Font = new System.Drawing.Font(C_FontName, (float) C_FormFontSize);
			with_1.ForeColor = System.Drawing.Color.DarkSlateGray;
			with_1.GridLineColor = System.Drawing.Color.Tan;
			with_1.HeaderBackColor = System.Drawing.Color.Wheat;
			with_1.HeaderFont = new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Bold);
			with_1.HeaderForeColor = System.Drawing.Color.SaddleBrown;
			with_1.LinkColor = System.Drawing.Color.DarkSlateBlue;
			with_1.ParentRowsBackColor = System.Drawing.Color.OldLace;
			with_1.ParentRowsForeColor = System.Drawing.Color.DarkSlateGray;
			with_1.SelectionBackColor = System.Drawing.Color.SlateGray;
			with_1.SelectionForeColor = System.Drawing.Color.White;
		}
		
		public static void setC1FlexFormat(C1.Win.C1FlexGrid.Classic.C1FlexGridClassic i_fg)
		{
			//***************************************************
			// Dùng để set các property của C1FlexGridClassic
			//***************************************************
			C1.Win.C1FlexGrid.Classic.C1FlexGridClassic with_1 = i_fg;
			//Tund sửa ngày 8/12/2004
			with_1.KeyActionTab = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
			with_1.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.MoveAcross;
			with_1.AllowBigSelection = false;
			with_1.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
			with_1.BackColor = System.Drawing.SystemColors.Window;
			with_1.BackColorAlternate = System.Drawing.SystemColors.Window;
			with_1.BackColorBkg = System.Drawing.SystemColors.AppWorkspace;
			with_1.BackColorFixed = System.Drawing.SystemColors.Control;
			with_1.BackColorSel = System.Drawing.SystemColors.Highlight;
			with_1.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse;
			with_1.ExplorerBar = C1.Win.C1FlexGrid.Classic.ExplorerBarSettings.flexExSortShowAndMove;
			with_1.ExtendLastCol = false;
			with_1.ForeColor = System.Drawing.SystemColors.WindowText;
			with_1.ForeColorFixed = System.Drawing.SystemColors.Highlight;
			with_1.ForeColorSel = System.Drawing.SystemColors.HighlightText;
			with_1.GridColor = System.Drawing.SystemColors.Control;
			with_1.GridColorFixed = System.Drawing.SystemColors.ControlDark;
			with_1.MergeCells = C1.Win.C1FlexGrid.Classic.MergeSettings.flexMergeOutline;
			with_1.OutlineBar = C1.Win.C1FlexGrid.Classic.OutlineBarSettings.flexOutlineBarSimple;
			with_1.SheetBorder = System.Drawing.SystemColors.WindowText;
			with_1.TreeColor = System.Drawing.Color.DarkGray;
			with_1.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionFree;
		}
		
		public static void setC1FixedRowsFormat(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			//***************************************************
			// Dùng để set các property của C1FlexGrid
			//***************************************************
			C1.Win.C1FlexGrid.C1FlexGrid with_1 = i_fg;
			with_1.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Free;
			with_1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
			with_1.BackColor = System.Drawing.SystemColors.Window;
			with_1.ExtendLastCol = false;
			with_1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.Solid;
			with_1.ForeColor = System.Drawing.SystemColors.WindowText;
			with_1.Font = new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Regular);
			with_1.Styles.Fixed.Font = new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Bold);
			with_1.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
			with_1.Styles.Fixed.ForeColor = System.Drawing.SystemColors.Highlight;
			with_1.Styles.EmptyArea.BackColor = with_1.BackColor;
			with_1.Styles.EmptyArea.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
			with_1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell;
		}
		
		public static void setC1FlexFormat(C1.Win.C1FlexGrid.C1FlexGrid i_fg)
		{
			//***************************************************
			// Dùng để set các property của C1FlexGrid
			//***************************************************
			C1.Win.C1FlexGrid.C1FlexGrid with_1 = i_fg;
			with_1.AllowEditing = false;
			with_1.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
			with_1.BackColor = System.Drawing.SystemColors.Window;
			//.Dock = System.Windows.Forms.DockStyle.Fill
			with_1.ExtendLastCol = false;
			with_1.ForeColor = System.Drawing.Color.Black;
			with_1.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.Complete;
			with_1.Font = new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Regular);
			with_1.Styles.Fixed.Font = new System.Drawing.Font(C_FontName, (float) C_FormFontSize, System.Drawing.FontStyle.Bold);
			with_1.Styles.Fixed.TextAlign = C1.Win.C1FlexGrid.TextAlignEnum.CenterCenter;
			with_1.Styles.Fixed.ForeColor = System.Drawing.Color.White;
			with_1.Styles.Fixed.BackColor = System.Drawing.Color.Maroon;
			with_1.Styles.Alternate.BackColor = System.Drawing.Color.FromArgb(System.Convert.ToByte(241), System.Convert.ToByte(252), System.Convert.ToByte(218));
			with_1.Styles.EmptyArea.BackColor = with_1.BackColor;
			with_1.Styles.EmptyArea.Border.Style = C1.Win.C1FlexGrid.BorderStyleEnum.None;
			with_1.Styles["subtotal0"].BackColor = System.Drawing.Color.DarkKhaki;
			with_1.Styles["subtotal0"].ForeColor = System.Drawing.Color.Maroon;
			with_1.Rows[0].Height = 2 * i_fg.Rows.DefaultSize;
			with_1.Styles["Fixed"].WordWrap = true;
		}
		
		public static void setTreeview(TreeView i_Treeview)
		{
			
			TreeView with_1 = i_Treeview;
			with_1.BackColor = System.Drawing.SystemColors.Info;
			with_1.Font = getRegularFont();
			with_1.ForeColor = getRegularForeColor();
		}
		
		
		
		public static void setButtonStyle(System.Windows.Forms.Button i_Button, ButtonStyle 
			i_ButtonStyle)
		{
			i_Button.Font = getRegularFont();
			i_Button.Height = 25;
			i_Button.Width = 130;
			i_Button.BackColor = System.Drawing.Color.LightYellow;
			i_Button.ForeColor = getRegularForeColor();
			
			switch (i_ButtonStyle)
			{
				case ButtonStyle.CancelButtonStyle:
					i_Button.Text = "Hủy bỏ (ESC)";
					break;
				case ButtonStyle.ExitButtonStyle:
					i_Button.Text = "Thoát (ESC)";
					break;
				case ButtonStyle.OkButtonStyle:
					i_Button.Text = "Chấp nhận (Alt+C)";
					break;
				case ButtonStyle.FreeFunctionButtonStyle:
					break;
					
				case ButtonStyle.LongFunctionButtonStyle:
					i_Button.Width = 200;
					break;
				case ButtonStyle.MediumFunctionButtonStyle:
					i_Button.Width = 160;
					break;
				case ButtonStyle.SmallFunctionButtonStyle:
					i_Button.Width = 130;
					break;
			}
		}
		
		
		public static void setLabelStyle(Label i_lbl, 
			LabelStyle i_labelStyle)
		{
			System.Drawing.Font v_Font = getRegularFont();
			System.Drawing.Color v_ForeColor = getRegularForeColor();
			switch (i_labelStyle)
			{
				case LabelStyle.Title_Info:
					v_Font = getBoldFont();
					v_ForeColor = System.Drawing.Color.Blue;
					break;
				case LabelStyle.HighLight_Info:
					v_Font = getBoldFont();
					v_ForeColor = System.Drawing.Color.Blue;
					break;
				case LabelStyle.Additional_Info:
					break;
					
				case LabelStyle.Prompt_Info:
					i_lbl.Text = i_lbl.Text + System.Environment.NewLine;
					i_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
					break;
			}
			i_lbl.Font = v_Font;
			i_lbl.ForeColor = v_ForeColor;
		}
#endregion
		
		
		
		
	}
	
	public enum IPFormStyle
	{
		DockableTopForm,
		DialogForm,
		MessageForm,
		FlashForm
	}
	
	
	
}
