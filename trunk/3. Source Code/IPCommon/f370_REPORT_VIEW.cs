// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;
using CrystalDecisions.Shared;
using CrystalDecisions.CrystalReports;
using CrystalDecisions.CrystalReports.Engine;


///''import crystal

namespace IP.Core.IPCommon
{
	public class f370_REPORT_VIEW : System.Windows.Forms.Form
	{
		
#region  Windows Form Designer generated code
		
		public f370_REPORT_VIEW()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			this.formatform();
			
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
		internal CrystalDecisions.Windows.Forms.CrystalReportViewer m_crvVIEW_REPORT;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.m_crvVIEW_REPORT = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
			this.SuspendLayout();
			//
			//m_crvVIEW_REPORT
			//
			this.m_crvVIEW_REPORT.ActiveViewIndex = -1;
			this.m_crvVIEW_REPORT.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_crvVIEW_REPORT.Location = new System.Drawing.Point(0, 0);
			this.m_crvVIEW_REPORT.Name = "m_crvVIEW_REPORT";
			this.m_crvVIEW_REPORT.ReportSource = null;
			this.m_crvVIEW_REPORT.ShowRefreshButton = false;
			this.m_crvVIEW_REPORT.Size = new System.Drawing.Size(790, 531);
			this.m_crvVIEW_REPORT.TabIndex = 0;
			//
			//f370_REPORT_VIEW
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(790, 531);
			this.Controls.Add(this.m_crvVIEW_REPORT);
			this.Name = "f370_REPORT_VIEW";
			this.Text = "M370 - In báo cáo";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.ResumeLayout(false);
			
		}
		
#endregion
		
		
#region  MEMBERS
		
#endregion
		
#region Public interface
		
		public void show_Report(DataTable i_dt, 
			string i_strPath, ParameterFields i_pfParameterFields = null)
		{
			ReportDocument v_crsReport = new ReportDocument();
			v_crsReport.Load(i_strPath);
			v_crsReport.SetDataSource(i_dt);
			if (!(i_pfParameterFields == null))
			{
				m_crvVIEW_REPORT.ParameterFieldInfo = i_pfParameterFields;
			}
			m_crvVIEW_REPORT.ReportSource = v_crsReport;
			
			this.ShowDialog();
		}
		
#endregion
		
#region PRIVATE METHODS
		private void formatform()
		{
			//CControlFormat.setFormStyle(Me)
			this.KeyPreview = true;
		}
#endregion
		
	}
	
}
