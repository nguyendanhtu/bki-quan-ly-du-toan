// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports


namespace IP.Core.IPCommon
{
	public class frmIcons : System.Windows.Forms.Form
	{
		
#region  Windows Form Designer generated code
		
		public frmIcons()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			
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
		internal System.Windows.Forms.ImageList m_imgListOfIcons;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmIcons));
			this.m_imgListOfIcons = new System.Windows.Forms.ImageList(this.components);
			//
			//m_imgListOfIcons
			//
			this.m_imgListOfIcons.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.m_imgListOfIcons.ImageSize = new System.Drawing.Size(16, 16);
			this.m_imgListOfIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("m_imgListOfIcons.ImageStream"));
			this.m_imgListOfIcons.TransparentColor = System.Drawing.Color.Transparent;
			//
			//frmIcons
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(219, 34);
			this.Name = "frmIcons";
			this.Text = "frmIcons";
			
		}
		
#endregion
		
	}
	
}
