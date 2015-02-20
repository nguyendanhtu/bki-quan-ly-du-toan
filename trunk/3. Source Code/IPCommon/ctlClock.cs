// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;
//using System.Drawing.Color;



namespace IP.Core.IPCommon
{
	public class ctlClock : System.Windows.Forms.UserControl
	{
		
		
		private System.Drawing.Color colFColor;
		private System.Drawing.Color colBColor;
#region  Windows Form Designer generated code
		
		public ctlClock()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			
		}
		
		//UserControl1 overrides dispose to clean up the component list.
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
		internal System.Windows.Forms.Timer Timer1;
		internal System.Windows.Forms.Label lblDisplay;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.lblDisplay = new System.Windows.Forms.Label();
			this.Timer1 = new System.Windows.Forms.Timer(this.components);
			this.Timer1.Tick += new System.EventHandler(this.Timer1_Tick);
			this.SuspendLayout();
			//
			//lblDisplay
			//
			this.lblDisplay.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.lblDisplay.ForeColor = System.Drawing.Color.Red;
			this.lblDisplay.Location = new System.Drawing.Point(2, 2);
			this.lblDisplay.Name = "lblDisplay";
			this.lblDisplay.Size = new System.Drawing.Size(118, 20);
			this.lblDisplay.TabIndex = 0;
			this.lblDisplay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			//
			//Timer1
			//
			this.Timer1.Enabled = true;
			this.Timer1.Interval = 1000;
			//
			//ctlClock
			//
			this.BackColor = System.Drawing.Color.WhiteSmoke;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblDisplay});
			this.Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.ForeColor = System.Drawing.Color.Red;
			this.Name = "ctlClock";
			this.Size = new System.Drawing.Size(122, 24);
			this.ResumeLayout(false);
			
		}
		
#endregion
		
		
public System.Drawing.Color ClockBackColor
		{
			get
			{
				return colBColor;
			}
			set
			{
				colBColor = value;
				lblDisplay.BackColor = colBColor;
			}
		}
		
public System.Drawing.Color ClockForeColor
		{
			get
			{
				return colFColor;
			}
			set
			{
				colFColor = value;
				lblDisplay.ForeColor = colFColor;
			}
		}
		
		protected virtual void Timer1_Tick(System.Object sender, System.EventArgs e)
		{
			lblDisplay.Text = Strings.Format(DateTime.Now, "hh:mm:ss");
		}
		
	}
	
	
}
