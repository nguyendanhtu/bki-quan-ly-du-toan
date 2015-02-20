// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPCommon;


namespace IP.Core.IPSystemAdmin
{
	public class f996_license : System.Windows.Forms.Form
	{
		
#region  Windows Form Designer generated code
		
		public f996_license()
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
		internal System.Windows.Forms.ImageList ImageList;
		internal System.Windows.Forms.Panel m_pnl_out_place_dm;
		internal System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Label label4;
		internal SIS.Controls.Button.SiSButton m_cmd_tro_ve;
		internal System.Windows.Forms.PictureBox pictureBox1;
		internal System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Label label2;
		internal System.Windows.Forms.Label label3;
		internal System.Windows.Forms.Label label6;
		internal System.Windows.Forms.Label label7;
		internal System.Windows.Forms.LinkLabel linkLabel1;
		internal System.Windows.Forms.GroupBox GroupBox2;
		internal System.Windows.Forms.GroupBox m_grp_so_dang_ky;
		internal System.Windows.Forms.TextBox m_txt_box5;
		internal System.Windows.Forms.TextBox m_txt_box4;
		internal System.Windows.Forms.TextBox m_txt_box3;
		internal System.Windows.Forms.TextBox m_txt_box2;
		internal System.Windows.Forms.TextBox m_txt_box1;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(f101_Dang_Nhap_Load);
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(f996_license));
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.m_pnl_out_place_dm = new System.Windows.Forms.Panel();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.m_cmd_tro_ve = new SIS.Controls.Button.SiSButton();
			this.m_cmd_tro_ve.Click += new System.EventHandler(this.m_cmd_tro_ve_Click);
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.GroupBox2 = new System.Windows.Forms.GroupBox();
			this.m_grp_so_dang_ky = new System.Windows.Forms.GroupBox();
			this.m_txt_box5 = new System.Windows.Forms.TextBox();
			this.m_txt_box4 = new System.Windows.Forms.TextBox();
			this.m_txt_box3 = new System.Windows.Forms.TextBox();
			this.m_txt_box2 = new System.Windows.Forms.TextBox();
			this.m_txt_box1 = new System.Windows.Forms.TextBox();
			this.m_pnl_out_place_dm.SuspendLayout();
			this.m_grp_so_dang_ky.SuspendLayout();
			this.SuspendLayout();
			//
			//ImageList
			//
			this.ImageList.ImageSize = new System.Drawing.Size(16, 16);
			this.ImageList.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("ImageList.ImageStream"));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			//
			//m_pnl_out_place_dm
			//
			this.m_pnl_out_place_dm.Controls.Add(this.label5);
			this.m_pnl_out_place_dm.Controls.Add(this.label4);
			this.m_pnl_out_place_dm.Controls.Add(this.m_cmd_tro_ve);
			this.m_pnl_out_place_dm.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_pnl_out_place_dm.DockPadding.All = 4;
			this.m_pnl_out_place_dm.Location = new System.Drawing.Point(0, 269);
			this.m_pnl_out_place_dm.Name = "m_pnl_out_place_dm";
			this.m_pnl_out_place_dm.Size = new System.Drawing.Size(544, 48);
			this.m_pnl_out_place_dm.TabIndex = 7;
			//
			//label5
			//
			this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font = new System.Drawing.Font("Times New Roman", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label5.ForeColor = System.Drawing.Color.Red;
			this.label5.Location = new System.Drawing.Point(4, 24);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(432, 20);
			this.label5.TabIndex = 1;
			this.label5.Text = "Bản quyền của I4U Group.";
			//
			//label4
			//
			this.label4.Dock = System.Windows.Forms.DockStyle.Top;
			this.label4.Font = new System.Drawing.Font("Times New Roman", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label4.Location = new System.Drawing.Point(4, 4);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(432, 20);
			this.label4.TabIndex = 0;
			this.label4.Text = "Sản phẩm này nằm trong bộ sản phẩm ứng dụng dành cho Công ty chứng khoán";
			//
			//m_cmd_tro_ve
			//
			this.m_cmd_tro_ve.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.m_cmd_tro_ve.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
			this.m_cmd_tro_ve.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
			this.m_cmd_tro_ve.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_cmd_tro_ve.Font = new System.Drawing.Font("Times New Roman", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_cmd_tro_ve.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_cmd_tro_ve.ImageIndex = 0;
			this.m_cmd_tro_ve.ImageList = this.ImageList;
			this.m_cmd_tro_ve.Location = new System.Drawing.Point(436, 4);
			this.m_cmd_tro_ve.Name = "m_cmd_tro_ve";
			this.m_cmd_tro_ve.Size = new System.Drawing.Size(104, 40);
			this.m_cmd_tro_ve.TabIndex = 2;
			this.m_cmd_tro_ve.Text = "OK [Esc]";
			//
			//pictureBox1
			//
			this.pictureBox1.BackColor = System.Drawing.SystemColors.HighlightText;
			this.pictureBox1.BackgroundImage = (System.Drawing.Image) (resources.GetObject("pictureBox1.BackgroundImage"));
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(168, 269);
			this.pictureBox1.TabIndex = 63;
			this.pictureBox1.TabStop = false;
			//
			//label1
			//
			this.label1.Dock = System.Windows.Forms.DockStyle.Top;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (27.75F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label1.Location = new System.Drawing.Point(168, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(376, 48);
			this.label1.TabIndex = 0;
			this.label1.Text = "I4U Group";
			//
			//label2
			//
			this.label2.Dock = System.Windows.Forms.DockStyle.Top;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (14.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label2.Location = new System.Drawing.Point(168, 48);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(376, 32);
			this.label2.TabIndex = 1;
			this.label2.Text = "Auction Manager";
			//
			//label3
			//
			this.label3.Dock = System.Windows.Forms.DockStyle.Top;
			this.label3.ForeColor = System.Drawing.Color.Red;
			this.label3.Location = new System.Drawing.Point(168, 80);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(376, 24);
			this.label3.TabIndex = 2;
			this.label3.Text = "Version 2.0";
			//
			//label6
			//
			this.label6.Font = new System.Drawing.Font("Times New Roman", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label6.Location = new System.Drawing.Point(192, 112);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(328, 24);
			this.label6.TabIndex = 4;
			this.label6.Text = "Liên hệ: Nguyễn Danh Tú";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			//label7
			//
			this.label7.Font = new System.Drawing.Font("Times New Roman", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.label7.Location = new System.Drawing.Point(192, 136);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(328, 24);
			this.label7.TabIndex = 5;
			this.label7.Text = "Di động: 0904 257 115";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			//
			//linkLabel1
			//
			this.linkLabel1.Font = new System.Drawing.Font("Times New Roman", (float) (9.0F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.linkLabel1.Location = new System.Drawing.Point(192, 160);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(328, 24);
			this.linkLabel1.TabIndex = 69;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "Email: tu_nguyendanh@yahoo.com";
			//
			//GroupBox2
			//
			this.GroupBox2.Location = new System.Drawing.Point(176, 104);
			this.GroupBox2.Name = "GroupBox2";
			this.GroupBox2.Size = new System.Drawing.Size(360, 8);
			this.GroupBox2.TabIndex = 3;
			this.GroupBox2.TabStop = false;
			//
			//m_grp_so_dang_ky
			//
			this.m_grp_so_dang_ky.Controls.Add(this.m_txt_box5);
			this.m_grp_so_dang_ky.Controls.Add(this.m_txt_box4);
			this.m_grp_so_dang_ky.Controls.Add(this.m_txt_box3);
			this.m_grp_so_dang_ky.Controls.Add(this.m_txt_box2);
			this.m_grp_so_dang_ky.Controls.Add(this.m_txt_box1);
			this.m_grp_so_dang_ky.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.m_grp_so_dang_ky.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (8.25F), System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_grp_so_dang_ky.Location = new System.Drawing.Point(172, 200);
			this.m_grp_so_dang_ky.Name = "m_grp_so_dang_ky";
			this.m_grp_so_dang_ky.Size = new System.Drawing.Size(368, 64);
			this.m_grp_so_dang_ky.TabIndex = 6;
			this.m_grp_so_dang_ky.TabStop = false;
			this.m_grp_so_dang_ky.Text = "  Số đăng ký   ";
			//
			//m_txt_box5
			//
			this.m_txt_box5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txt_box5.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txt_box5.Location = new System.Drawing.Point(295, 25);
			this.m_txt_box5.MaxLength = 4;
			this.m_txt_box5.Name = "m_txt_box5";
			this.m_txt_box5.Size = new System.Drawing.Size(64, 22);
			this.m_txt_box5.TabIndex = 4;
			this.m_txt_box5.Text = "";
			this.m_txt_box5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			//m_txt_box4
			//
			this.m_txt_box4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txt_box4.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txt_box4.Location = new System.Drawing.Point(223, 25);
			this.m_txt_box4.MaxLength = 4;
			this.m_txt_box4.Name = "m_txt_box4";
			this.m_txt_box4.Size = new System.Drawing.Size(64, 22);
			this.m_txt_box4.TabIndex = 3;
			this.m_txt_box4.Text = "";
			this.m_txt_box4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			//m_txt_box3
			//
			this.m_txt_box3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txt_box3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txt_box3.Location = new System.Drawing.Point(151, 25);
			this.m_txt_box3.MaxLength = 4;
			this.m_txt_box3.Name = "m_txt_box3";
			this.m_txt_box3.Size = new System.Drawing.Size(64, 22);
			this.m_txt_box3.TabIndex = 2;
			this.m_txt_box3.Text = "";
			this.m_txt_box3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			//m_txt_box2
			//
			this.m_txt_box2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txt_box2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txt_box2.Location = new System.Drawing.Point(79, 25);
			this.m_txt_box2.MaxLength = 4;
			this.m_txt_box2.Name = "m_txt_box2";
			this.m_txt_box2.Size = new System.Drawing.Size(64, 22);
			this.m_txt_box2.TabIndex = 1;
			this.m_txt_box2.Text = "";
			this.m_txt_box2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			//m_txt_box1
			//
			this.m_txt_box1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.m_txt_box1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txt_box1.Location = new System.Drawing.Point(7, 25);
			this.m_txt_box1.MaxLength = 4;
			this.m_txt_box1.Name = "m_txt_box1";
			this.m_txt_box1.Size = new System.Drawing.Size(64, 22);
			this.m_txt_box1.TabIndex = 0;
			this.m_txt_box1.Text = "";
			this.m_txt_box1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			//
			//f996_license
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.White;
			this.ClientSize = new System.Drawing.Size(544, 317);
			this.Controls.Add(this.m_grp_so_dang_ky);
			this.Controls.Add(this.GroupBox2);
			this.Controls.Add(this.linkLabel1);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.m_pnl_out_place_dm);
			this.Name = "f996_license";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "F996 - License";
			this.m_pnl_out_place_dm.ResumeLayout(false);
			this.m_grp_so_dang_ky.ResumeLayout(false);
			this.ResumeLayout(false);
			
		}
		
#endregion
		
#region Public Interface
		public void display(int i_mode)
		{
			m_e_form_mode = (eFormMode) i_mode;
			this.ShowDialog();
		}
#endregion
		
#region Data Structures
		private enum eFormMode
		{
			LicenseYes = 0,
			LicenseNo = 1
		}
#endregion
		
#region Members
		eFormMode m_e_form_mode = new eFormMode();
#endregion
		
#region Private Methods
		private void init_form()
		{
			m_txt_box1.Text = "";
			m_txt_box2.Text = "";
			m_txt_box3.Text = "";
			m_txt_box4.Text = "";
			m_txt_box5.Text = "";
		}
#endregion
		
		private void f101_Dang_Nhap_Load(object sender, System.EventArgs e)
		{
			try
			{
				init_form();
				if (m_e_form_mode == eFormMode.LicenseYes)
				{
					m_grp_so_dang_ky.Visible = false;
				}
				else
				{
					m_grp_so_dang_ky.Visible = true;
				}
			}
			catch (System.Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		private void m_cmd_tro_ve_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				this.Close();
			}
			catch (System.Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
	}
	
}
