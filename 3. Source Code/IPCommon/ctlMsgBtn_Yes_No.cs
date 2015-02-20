// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	namespace MessageForms
	{
		public class MsgBtn_Yes_No : System.Windows.Forms.UserControl
		{
#region Nhiệm vụ
			//*************************************************************************
			//Định nghĩa một Control gồm ba nút "Yes", "No", "Cancel"
			//Event: ClickMe
			//Output: Yes,No,Cancel
			//*************************************************************************
#endregion
			
#region Khai báo biến
			private System.Windows.Forms.DialogResult m_Result;
			private System.Drawing.Font c_Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular);
#endregion
			
#region  Windows Form Designer generated code
			
			public MsgBtn_Yes_No()
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
			internal System.Windows.Forms.Button BtnDongY;
			internal System.Windows.Forms.Button BtnKhongDongY;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.BtnDongY = new System.Windows.Forms.Button();
				this.BtnDongY.Click += new System.EventHandler(this.BtnDongY_Click);
				base.Load += new System.EventHandler(MsgBtn_Yes_No_Load);
				this.BtnKhongDongY = new System.Windows.Forms.Button();
				this.BtnKhongDongY.Click += new System.EventHandler(this.BtnKhongDongY_Click);
				this.SuspendLayout();
				//
				//BtnDongY
				//
				this.BtnDongY.Location = new System.Drawing.Point(9, 6);
				this.BtnDongY.Name = "BtnDongY";
				this.BtnDongY.Size = new System.Drawing.Size(92, 25);
				this.BtnDongY.TabIndex = 0;
				this.BtnDongY.Text = "Đồng ý";
				//
				//BtnKhongDongY
				//
				this.BtnKhongDongY.Location = new System.Drawing.Point(111, 6);
				this.BtnKhongDongY.Name = "BtnKhongDongY";
				this.BtnKhongDongY.Size = new System.Drawing.Size(92, 25);
				this.BtnKhongDongY.TabIndex = 1;
				this.BtnKhongDongY.Text = "Không đồng ý";
				//
				//MsgBtn_Yes_No
				//
				this.Controls.AddRange(new System.Windows.Forms.Control[] {this.BtnKhongDongY, this.BtnDongY});
				this.Name = "MsgBtn_Yes_No";
				this.Size = new System.Drawing.Size(210, 38);
				this.ResumeLayout(false);
				
			}
			
#endregion
#region Public Interface
public System.Windows.Forms.DialogResult ClickResult
			{
				get
				{
					return m_Result;
				}
				set
				{
					
				}
			}
#endregion
			
#region Control Event
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
			
#endregion
			
#region Các hành động của control
			private void BtnDongY_Click(System.Object sender, System.EventArgs e)
			{
				m_Result = System.Windows.Forms.DialogResult.Yes;
				if (ClickMeEvent != null)
					ClickMeEvent();
			}
			
			private void BtnKhongDongY_Click(System.Object sender, System.EventArgs e)
			{
				m_Result = System.Windows.Forms.DialogResult.No;
				if (ClickMeEvent != null)
					ClickMeEvent();
			}
			
#endregion
			
			private void MsgBtn_Yes_No_Load(System.Object sender, System.EventArgs e)
			{
				this.BtnDongY.Font = c_Font;
				this.BtnKhongDongY.Font = c_Font;
			}
		}
	}
}
