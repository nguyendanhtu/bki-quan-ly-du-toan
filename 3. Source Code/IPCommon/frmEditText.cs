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
	public class frmEditText : System.Windows.Forms.Form
	{
		
		private int m_Left;
		private int m_Top;
		private bool m_Under;
		private string m_strTitle;
		
#region  Windows Form Designer generated code
		
		public frmEditText()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			this.KeyPreview = true;
		}
		
		//Form overrides dispose to clean up the component list.
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
		internal System.Windows.Forms.TextBox m_txtContent;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.m_txtContent = new System.Windows.Forms.TextBox();
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(frmEditText_KeyDown);
			this.m_txtContent.Enter += new System.EventHandler(this.m_txtContent_Enter);
			base.Load += new System.EventHandler(frmEditText_Load);
			this.SuspendLayout();
			//
			//m_txtContent
			//
			this.m_txtContent.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_txtContent.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txtContent.Multiline = true;
			this.m_txtContent.Name = "m_txtContent";
			this.m_txtContent.Size = new System.Drawing.Size(450, 262);
			this.m_txtContent.TabIndex = 0;
			this.m_txtContent.Text = "";
			//
			//frmEditText
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(450, 262);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.m_txtContent});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmEditText";
			this.Text = "Alt+S = save; ESC = cancel - chú ý cho ví dụ";
			this.ResumeLayout(false);
			
		}
		
#endregion
		
		private string m_strEdit;
		
		
		public void editText(ref string io_strEdit, int i_Left = -1, int i_Top = -1, string i_strTitle = "Ghi chú")
		{
			m_strEdit = io_strEdit;
			m_Left = i_Left;
			m_Top = i_Top;
			
			m_strTitle = i_strTitle;
			
			this.ShowDialog();
			io_strEdit = m_strEdit;
		}
		
		
		private void frmEditText_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					break;
				case Keys.S:
					if (e.Alt || e.Control)
					{
						m_strEdit = m_txtContent.Text;
						e.Handled = true;
						this.Close();
					}
					break;
			}
		}
		
		
		
		private void m_txtContent_Enter(object sender, System.EventArgs e)
		{
			m_txtContent.Select(m_txtContent.Text.Length, 0);
		}
		
		
		private void frmEditText_Load(object sender, System.EventArgs e)
		{
			m_txtContent.Text = m_strEdit;
			if (m_Top > 0)
			{
				this.Top = m_Top;
				this.Left = m_Left;
			}
			else
			{
				this.CenterToParent();
			}
			this.Text = m_strTitle + " - Alt+S = save; ESC = cancel";
		}
	}
	
}
