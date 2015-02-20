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
		public class MsgButtonYes_No_Cancel : System.Windows.Forms.UserControl
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
			
			public MsgButtonYes_No_Cancel()
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
			internal System.Windows.Forms.Button BtnBoQua;
			internal System.Windows.Forms.Button BtnKhongDongY;
			internal System.Windows.Forms.Button BtnDongY;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.BtnBoQua = new System.Windows.Forms.Button();
				this.BtnBoQua.Click += new System.EventHandler(this.BtnBoQua_Click);
				base.Load += new System.EventHandler(MsgButtonYes_No_Cancel_Load);
				this.BtnKhongDongY = new System.Windows.Forms.Button();
				this.BtnKhongDongY.Click += new System.EventHandler(this.BtnKhongDongY_Click);
				this.BtnDongY = new System.Windows.Forms.Button();
				this.BtnDongY.Click += new System.EventHandler(this.BtnDongY_Click);
				this.SuspendLayout();
				//
				//BtnBoQua
				//
				this.BtnBoQua.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.BtnBoQua.Location = new System.Drawing.Point(208, 4);
				this.BtnBoQua.Name = "BtnBoQua";
				this.BtnBoQua.Size = new System.Drawing.Size(92, 25);
				this.BtnBoQua.TabIndex = 5;
				this.BtnBoQua.Text = "Huỷ bỏ";
				//
				//BtnKhongDongY
				//
				this.BtnKhongDongY.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.BtnKhongDongY.Location = new System.Drawing.Point(106, 4);
				this.BtnKhongDongY.Name = "BtnKhongDongY";
				this.BtnKhongDongY.Size = new System.Drawing.Size(92, 25);
				this.BtnKhongDongY.TabIndex = 4;
				this.BtnKhongDongY.Text = "Không đồng ý";
				//
				//BtnDongY
				//
				this.BtnDongY.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.BtnDongY.Location = new System.Drawing.Point(4, 4);
				this.BtnDongY.Name = "BtnDongY";
				this.BtnDongY.Size = new System.Drawing.Size(92, 25);
				this.BtnDongY.TabIndex = 3;
				this.BtnDongY.Text = "Đồng ý";
				//
				//MsgButtonYes_No_Cancel
				//
				this.Controls.AddRange(new System.Windows.Forms.Control[] {this.BtnBoQua, this.BtnKhongDongY, this.BtnDongY});
				this.Name = "MsgButtonYes_No_Cancel";
				this.Size = new System.Drawing.Size(306, 33);
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
			
			private void BtnBoQua_Click(System.Object sender, System.EventArgs e)
			{
				m_Result = System.Windows.Forms.DialogResult.Cancel;
				if (ClickMeEvent != null)
					ClickMeEvent();
			}
#endregion
			
			
			private void MsgButtonYes_No_Cancel_Load(System.Object sender, System.EventArgs e)
			{
				this.BtnBoQua.Font = c_Font;
				this.BtnDongY.Font = c_Font;
				this.BtnKhongDongY.Font = c_Font;
			}
		}
	}
}
