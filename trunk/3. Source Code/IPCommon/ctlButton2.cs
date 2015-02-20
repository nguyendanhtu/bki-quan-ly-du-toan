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
	public class ctlButton2 : System.Windows.Forms.UserControl
	{
		
#region  Windows Form Designer generated code
		
		public ctlButton2()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			
		}
		
		//UserControl overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		//Required by the Windows Form Designer
		private System.ComponentModel.Container components = null;
		
		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal System.Windows.Forms.Button Button1;
		internal System.Windows.Forms.Button Button2;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.Button1 = new System.Windows.Forms.Button();
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button1_KeyDown);
			this.Button2 = new System.Windows.Forms.Button();
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button2.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Button2_KeyDown);
			this.SuspendLayout();
			//
			//Button1
			//
			this.Button1.BackColor = System.Drawing.SystemColors.ControlLight;
			this.Button1.Location = new System.Drawing.Point(2, 2);
			this.Button1.Name = "Button1";
			this.Button1.Size = new System.Drawing.Size(138, 26);
			this.Button1.TabIndex = 0;
			this.Button1.Text = "Cập nhận (Ctrl - C)";
			//
			//Button2
			//
			this.Button2.BackColor = System.Drawing.SystemColors.ControlLight;
			this.Button2.Location = new System.Drawing.Point(142, 2);
			this.Button2.Name = "Button2";
			this.Button2.Size = new System.Drawing.Size(138, 26);
			this.Button2.TabIndex = 1;
			this.Button2.Text = "Hủy bỏ (Esc)";
			//
			//ctlButton2
			//
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Button2, this.Button1});
			this.Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.ForeColor = System.Drawing.Color.Navy;
			this.Name = "ctlButton2";
			this.Size = new System.Drawing.Size(284, 30);
			this.ResumeLayout(false);
			
		}
		
#endregion
		
#region Các định nghĩa
		public enum TT_NUT
		{
			i_BO_QUA = 0,
			i_CHAP_NHAN = 1,
			i_THOAT = 2
		}
		
#endregion
		private DialogResult v_DialogResult2;
		public delegate void ClickMeEventHandler();
		private ClickMeEventHandler ClickMeEvent;
		
		public event ClickMeEventHandler ClickMe
		{
			add
			{
				ClickMeEvent = (ClickMeEventHandler) System.Delegate.Combine(ClickMeEvent, value);
			}
			remove
			{
				ClickMeEvent = (ClickMeEventHandler) System.Delegate.Remove(ClickMeEvent, value);
			}
		}
		
		
		
		// Declares the property.
		
public DialogResult v_Button
		{
			get
			{
				return v_DialogResult2;
			}
			set
			{
				value = v_DialogResult2;
			}
		}
		
		private void Button1_Click(System.Object sender, System.EventArgs e)
		{
			v_DialogResult2 = DialogResult.OK;
			if (ClickMeEvent != null)
				ClickMeEvent();
		}
		
		private void Button2_Click(object sender, System.EventArgs e)
		{
			v_DialogResult2 = DialogResult.Cancel;
			if (ClickMeEvent != null)
				ClickMeEvent();
		}
		
		private void Button1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.Control & e.KeyCode == Keys.C)
			{
				v_DialogResult2 = DialogResult.OK;
				if (ClickMeEvent != null)
					ClickMeEvent();
			}
		}
		
		private void Button2_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Escape)
			{
				v_DialogResult2 = DialogResult.Cancel;
				if (ClickMeEvent != null)
					ClickMeEvent();
			}
		}
	}
	
}
