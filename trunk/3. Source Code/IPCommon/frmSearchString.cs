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
	public class frmSearchString : System.Windows.Forms.Form, ISearchForm
	{
		
#region  Windows Form Designer generated code
		
		public frmSearchString()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			CControlFormat.setFormStyle(this);
			this.CenterToParent();
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
		internal System.Windows.Forms.TextBox m_txtPattern;
		internal System.Windows.Forms.Label m_lblSearchInfo;
		internal System.Windows.Forms.CheckBox m_chkCaseSensitive;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton m_rbStartWith;
		internal System.Windows.Forms.RadioButton m_rbContain;
		internal System.Windows.Forms.CheckBox m_chkSearchAsYouType;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.m_txtPattern = new System.Windows.Forms.TextBox();
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(frmSearch_KeyDown);
			this.m_txtPattern.TextChanged += new System.EventHandler(this.m_txtPattern_TextChanged);
			this.m_txtPattern.KeyDown += new System.Windows.Forms.KeyEventHandler(this.m_txtPattern_KeyDown);
			this.m_lblSearchInfo = new System.Windows.Forms.Label();
			this.m_rbStartWith = new System.Windows.Forms.RadioButton();
			this.m_rbContain = new System.Windows.Forms.RadioButton();
			this.m_chkCaseSensitive = new System.Windows.Forms.CheckBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.m_chkSearchAsYouType = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			//
			//m_txtPattern
			//
			this.m_txtPattern.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txtPattern.ForeColor = System.Drawing.SystemColors.Highlight;
			this.m_txtPattern.Location = new System.Drawing.Point(1, 0);
			this.m_txtPattern.Name = "m_txtPattern";
			this.m_txtPattern.Size = new System.Drawing.Size(347, 22);
			this.m_txtPattern.TabIndex = 0;
			this.m_txtPattern.Text = "";
			//
			//m_lblSearchInfo
			//
			this.m_lblSearchInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lblSearchInfo.ForeColor = System.Drawing.Color.OrangeRed;
			this.m_lblSearchInfo.Location = new System.Drawing.Point(0, 90);
			this.m_lblSearchInfo.Name = "m_lblSearchInfo";
			this.m_lblSearchInfo.Size = new System.Drawing.Size(350, 18);
			this.m_lblSearchInfo.TabIndex = 4;
			//
			//m_rbStartWith
			//
			this.m_rbStartWith.Location = new System.Drawing.Point(8, 36);
			this.m_rbStartWith.Name = "m_rbStartWith";
			this.m_rbStartWith.TabIndex = 1;
			this.m_rbStartWith.Text = "Bắt đầu bằng";
			//
			//m_rbContain
			//
			this.m_rbContain.Checked = true;
			this.m_rbContain.Location = new System.Drawing.Point(8, 58);
			this.m_rbContain.Name = "m_rbContain";
			this.m_rbContain.TabIndex = 2;
			this.m_rbContain.TabStop = true;
			this.m_rbContain.Text = "Có chứa ";
			//
			//m_chkCaseSensitive
			//
			this.m_chkCaseSensitive.Location = new System.Drawing.Point(147, 30);
			this.m_chkCaseSensitive.Name = "m_chkCaseSensitive";
			this.m_chkCaseSensitive.Size = new System.Drawing.Size(201, 24);
			this.m_chkCaseSensitive.TabIndex = 3;
			this.m_chkCaseSensitive.Text = "Phân biệt chữ  hoa/thường";
			//
			//GroupBox1
			//
			this.GroupBox1.Location = new System.Drawing.Point(3, 22);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(115, 63);
			this.GroupBox1.TabIndex = 4;
			this.GroupBox1.TabStop = false;
			//
			//m_chkSearchAsYouType
			//
			this.m_chkSearchAsYouType.Location = new System.Drawing.Point(147, 60);
			this.m_chkSearchAsYouType.Name = "m_chkSearchAsYouType";
			this.m_chkSearchAsYouType.Size = new System.Drawing.Size(201, 24);
			this.m_chkSearchAsYouType.TabIndex = 5;
			this.m_chkSearchAsYouType.Text = "Tìm sau từng ký tự";
			//
			//frmSearchString
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(350, 108);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.m_chkSearchAsYouType, this.m_chkCaseSensitive, this.m_rbContain, this.m_rbStartWith, this.m_lblSearchInfo, this.m_txtPattern, this.GroupBox1});
			this.Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSearchString";
			this.Text = "Ctrl + F = tìm từ đầu; F3= tìm từ vị trí tiếp theo";
			this.ResumeLayout(false);
			
		}
		
#endregion
		
		ISearchable m_frmSearch;
		SearchType m_currentSearchType = SearchType.fromStart;
		
		public void displaySearch(ISearchable i_form2Search)
		{
			m_frmSearch = i_form2Search;
			this.ShowDialog();
		}
		
		private void startSearch(SearchType i_searchtype)
		{
			m_currentSearchType = i_searchtype;
			if (m_frmSearch == null)
			{
				return;
			}
			if (m_txtPattern.Text == "")
			{
				m_lblSearchInfo.Text = "Không có điều kiện để tìm";
				return;
			}
			m_lblSearchInfo.Text = "Không tìm thấy";
			try
			{
				StringSearchPattern v_newStringSearchPattern = new StringSearchPattern(m_txtPattern.Text, m_rbStartWith.Checked, m_chkCaseSensitive.Checked);
				m_lblSearchInfo.Text = "Đang tìm kiếm ...";
				if (m_frmSearch.startSearch(v_newStringSearchPattern, i_searchtype))
				{
					m_lblSearchInfo.Text = "Tìm thấy";
				}
				else
				{
					m_lblSearchInfo.Text = "Không tìm thấy";
				}
			}
			catch
			{
				m_lblSearchInfo.Text = "Không tìm thấy";
			}
		}
		
		private void frmSearch_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					this.Close();
					e.Handled = true;
					break;
				case Keys.F3:
					startSearch(SearchType.fromNextRow);
					e.Handled = true;
					break;
				case Keys.F:
					if (e.Control)
					{
						startSearch(SearchType.fromStart);
						e.Handled = true;
					}
					else
					{
						e.Handled = false;
					}
					break;
			}
		}
		
		private void m_txtPattern_TextChanged(object sender, System.EventArgs e)
		{
			m_lblSearchInfo.Text = "";
			if (m_chkSearchAsYouType.Checked)
			{
				startSearch(SearchType.fromStart);
			}
		}
		
		
		private void m_txtPattern_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				startSearch(m_currentSearchType);
			}
		}
		
		private class StringSearchPattern : IFoundCondition
		{
			
#region Nhiệm vụ của Class
			// Dùng để tìm các dữ liệu
			//
			//
#endregion
			
			private string m_pattern;
			private bool m_startWith;
			private bool m_caseSensitive;
			
			public StringSearchPattern(string i_strPattern, bool i_startWith, bool i_caseSensitive)
			{
				
				Debug.Assert(i_strPattern != "", "Sao không có condition thế này");
				m_caseSensitive = i_caseSensitive;
				m_startWith = i_startWith;
				m_pattern = i_strPattern;
			}
			
			public bool MatchThePattern(object i_Data2Compare)
			{
				try
				{
					string v_strData = System.Convert.ToString(i_Data2Compare);
					string v_pattern = "";
					
					if (!m_caseSensitive)
					{
						v_strData = v_strData.ToLower();
						v_pattern = m_pattern.ToLower();
					}
					
					if (m_startWith)
					{
						return v_strData.IndexOf(v_pattern) == 0;
					}
					else
					{
						return v_strData.IndexOf(v_pattern) >= 0;
					}
				}
				catch
				{
					return false;
				}
			}
		}
		
	}
	
}
