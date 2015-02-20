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
	public class frmSearchDate : System.Windows.Forms.Form, ISearchForm
	{
		
		ISearchable m_frmSearch;
		
		public void displaySearch(ISearchable i_form2Search)
		{
			m_frmSearch = i_form2Search;
			this.ShowDialog();
		}
		
		
#region  Windows Form Designer generated code
		
		public frmSearchDate()
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
		internal System.Windows.Forms.Label m_lblSearchInfo;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.RadioButton m_rbLargerOrEqual;
		internal System.Windows.Forms.RadioButton m_rbLesserOrEqual;
		internal System.Windows.Forms.RadioButton m_rbEqual;
		internal System.Windows.Forms.RadioButton m_rbLarger;
		internal System.Windows.Forms.RadioButton m_rbLesser;
		internal System.Windows.Forms.TextBox m_txtDate2Search;
		internal System.Windows.Forms.Label Label1;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.m_txtDate2Search = new System.Windows.Forms.TextBox();
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(frmSearch_KeyDown);
			this.m_txtDate2Search.TextChanged += new System.EventHandler(this.m_txtNumber2Search_TextChanged);
			this.m_lblSearchInfo = new System.Windows.Forms.Label();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.m_rbLesser = new System.Windows.Forms.RadioButton();
			this.m_rbLarger = new System.Windows.Forms.RadioButton();
			this.m_rbLesserOrEqual = new System.Windows.Forms.RadioButton();
			this.m_rbLargerOrEqual = new System.Windows.Forms.RadioButton();
			this.m_rbEqual = new System.Windows.Forms.RadioButton();
			this.Label1 = new System.Windows.Forms.Label();
			this.GroupBox1.SuspendLayout();
			this.SuspendLayout();
			//
			//m_txtDate2Search
			//
			this.m_txtDate2Search.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txtDate2Search.Name = "m_txtDate2Search";
			this.m_txtDate2Search.Size = new System.Drawing.Size(174, 22);
			this.m_txtDate2Search.TabIndex = 0;
			this.m_txtDate2Search.Text = "";
			//
			//m_lblSearchInfo
			//
			this.m_lblSearchInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lblSearchInfo.Location = new System.Drawing.Point(0, 111);
			this.m_lblSearchInfo.Name = "m_lblSearchInfo";
			this.m_lblSearchInfo.Size = new System.Drawing.Size(356, 22);
			this.m_lblSearchInfo.TabIndex = 1;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.m_rbLesser, this.m_rbLarger, this.m_rbLesserOrEqual, this.m_rbLargerOrEqual, this.m_rbEqual});
			this.GroupBox1.Location = new System.Drawing.Point(0, 26);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(356, 84);
			this.GroupBox1.TabIndex = 2;
			this.GroupBox1.TabStop = false;
			//
			//m_rbLesser
			//
			this.m_rbLesser.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_rbLesser.Location = new System.Drawing.Point(76, 38);
			this.m_rbLesser.Name = "m_rbLesser";
			this.m_rbLesser.Size = new System.Drawing.Size(44, 24);
			this.m_rbLesser.TabIndex = 4;
			this.m_rbLesser.Text = "<";
			//
			//m_rbLarger
			//
			this.m_rbLarger.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_rbLarger.Location = new System.Drawing.Point(76, 16);
			this.m_rbLarger.Name = "m_rbLarger";
			this.m_rbLarger.Size = new System.Drawing.Size(44, 24);
			this.m_rbLarger.TabIndex = 3;
			this.m_rbLarger.Text = ">";
			//
			//m_rbLesserOrEqual
			//
			this.m_rbLesserOrEqual.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_rbLesserOrEqual.Location = new System.Drawing.Point(14, 60);
			this.m_rbLesserOrEqual.Name = "m_rbLesserOrEqual";
			this.m_rbLesserOrEqual.Size = new System.Drawing.Size(44, 24);
			this.m_rbLesserOrEqual.TabIndex = 2;
			this.m_rbLesserOrEqual.Text = "<=";
			//
			//m_rbLargerOrEqual
			//
			this.m_rbLargerOrEqual.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_rbLargerOrEqual.Location = new System.Drawing.Point(14, 38);
			this.m_rbLargerOrEqual.Name = "m_rbLargerOrEqual";
			this.m_rbLargerOrEqual.Size = new System.Drawing.Size(44, 24);
			this.m_rbLargerOrEqual.TabIndex = 1;
			this.m_rbLargerOrEqual.Text = ">=";
			//
			//m_rbEqual
			//
			this.m_rbEqual.Checked = true;
			this.m_rbEqual.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_rbEqual.Location = new System.Drawing.Point(14, 16);
			this.m_rbEqual.Name = "m_rbEqual";
			this.m_rbEqual.Size = new System.Drawing.Size(44, 24);
			this.m_rbEqual.TabIndex = 0;
			this.m_rbEqual.TabStop = true;
			this.m_rbEqual.Text = "=";
			//
			//Label1
			//
			this.Label1.Location = new System.Drawing.Point(188, 2);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(96, 19);
			this.Label1.TabIndex = 3;
			this.Label1.Text = "ngày/tháng/năm";
			//
			//frmSearchDate
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(356, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1, this.GroupBox1, this.m_lblSearchInfo, this.m_txtDate2Search});
			this.Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "frmSearchDate";
			this.Text = "Ctrl+F=tìm kiếm từ đầu; F3 = tìm từ vị trí tiếp theo";
			this.GroupBox1.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
#endregion
		
		
		
		private void startSearch(SearchType i_searchtype)
		{
			if (m_frmSearch == null)
			{
				return;
			}
			if (m_txtDate2Search.Text == "")
			{
				m_lblSearchInfo.Text = "Không có điều kiện để tìm";
				return;
			}
			// tạo điều kiện tìm kiếm
			DateTime v_DateTime2Search = default(DateTime);
			try
			{
				v_DateTime2Search = Str2Date(m_txtDate2Search.Text);
			}
			catch
			{
				m_lblSearchInfo.Text = "Không có ngày hợp lệ để tìm";
				return;
			}
			m_lblSearchInfo.Text = "Không tìm thấy";
			try
			{
				DateSearchType v_DateTimeCompareType = default(DateSearchType);
				if (m_rbEqual.Checked)
				{
					v_DateTimeCompareType = DateSearchType.Equal_DateTime;
				}
				else if (m_rbLarger.Checked)
				{
					v_DateTimeCompareType = DateSearchType.Larger_DateTime;
				}
				else if (m_rbLargerOrEqual.Checked)
				{
					v_DateTimeCompareType = DateSearchType.LargerOrEqual_DateTime;
				}
				else if (m_rbLesser.Checked)
				{
					v_DateTimeCompareType = DateSearchType.Lesser_DateTime;
				}
				else if (m_rbLesserOrEqual.Checked)
				{
					v_DateTimeCompareType = DateSearchType.LesserOrEqual_DateTime;
				}
				
				DateSearchPattern v_DateTimeSearchPattern = new DateSearchPattern(v_DateTime2Search, v_DateTimeCompareType);
				m_lblSearchInfo.Text = "Đang tìm kiếm ...";
				if (m_frmSearch.startSearch(v_DateTimeSearchPattern, i_searchtype))
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
		
		
		
		//Chuyển từ xâu sang ngày với định dạng cho trước
		private DateTime Str2Date(string i_strDate, string i_strFormat = "dd/MM/yyyy")
		{
			System.Globalization.CultureInfo v_format = new System.Globalization.CultureInfo("vi-VN", true);
			System.DateTime v_myDateTime = default(System.DateTime);
			
			v_myDateTime = System.DateTime.ParseExact(i_strDate, i_strFormat, v_format);
			return v_myDateTime;
		}
		
		
		public enum DateSearchType
		{
			Equal_DateTime = 0,
			LesserOrEqual_DateTime = 1,
			LargerOrEqual_DateTime = 2,
			Lesser_DateTime = 3,
			Larger_DateTime = 4
		}
		
		private class DateSearchPattern : IFoundCondition
		{
			
#region Nhiệm vụ của Class
			// Dùng để tìm các dữ liệu
			//
			//
#endregion
			
			private DateTime m_DateTime2Search;
			private DateSearchType m_DateSearchType;
			
			public DateSearchPattern(DateTime i_DateTime2Search, DateSearchType i_searchType)
			{
				m_DateTime2Search = i_DateTime2Search;
				m_DateSearchType = i_searchType;
			}
			
			public bool MatchThePattern(object i_Data2Compare)
			{
				try
				{
					DateTime v_DateTimeData = System.Convert.ToDateTime(i_Data2Compare);
					switch (m_DateSearchType)
					{
						case DateSearchType.Equal_DateTime:
							return v_DateTimeData == m_DateTime2Search;
						case DateSearchType.LargerOrEqual_DateTime:
							return v_DateTimeData >= m_DateTime2Search;
						case DateSearchType.LesserOrEqual_DateTime:
							return v_DateTimeData <= m_DateTime2Search;
						case DateSearchType.Larger_DateTime:
							return v_DateTimeData > m_DateTime2Search;
						case DateSearchType.Lesser_DateTime:
							return v_DateTimeData < m_DateTime2Search;
					}
				}
				catch
				{
					return false;
				}
				return default(bool);
			}
			
		}
		
		private void m_txtNumber2Search_TextChanged(System.Object sender, System.EventArgs e)
		{
			m_lblSearchInfo.Text = "";
		}
	}
	
}
