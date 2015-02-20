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
using IP.Core.IPException;
using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPBusinessService;
using IP.Core.IPData.DBNames;




namespace IP.Core.IPSystemAdmin
{
	public class f101_Dang_Nhap : System.Windows.Forms.Form
	{

		#region Nhiệm vụ của class
		//***************************************************
		//* LOGIN - vào hệ thống   & setup application context
		//*
		//***************************************************
		#endregion

		#region  Windows Form Designer generated code

		public f101_Dang_Nhap()
		{

			//This call is required by the Windows Form Designer.
			InitializeComponent();

			//Add any initialization after the InitializeComponent() call
			FormatForm();

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
		internal System.Windows.Forms.Panel Panel1;
		internal SIS.Controls.Button.SiSButton m_btnCancel;
		internal SIS.Controls.Button.SiSButton m_btnOK;
		internal System.Windows.Forms.TextBox m_txtMatKhau;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.TextBox m_txtTenTruyNhap;
		internal System.Windows.Forms.ImageList ImageList;
		internal System.Windows.Forms.GroupBox GroupBox1;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Panel Panel2;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			base.Load += new System.EventHandler(f101_Dang_Nhap_Load);
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(f101_Dang_Nhap_KeyDown);
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f101_Dang_Nhap));
			this.Panel1 = new System.Windows.Forms.Panel();
			this.m_btnOK = new SIS.Controls.Button.SiSButton();
			this.ImageList = new System.Windows.Forms.ImageList(this.components);
			this.m_btnCancel = new SIS.Controls.Button.SiSButton();
			this.m_txtMatKhau = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.m_txtTenTruyNhap = new System.Windows.Forms.TextBox();
			this.GroupBox1 = new System.Windows.Forms.GroupBox();
			this.GroupBox1.Enter += new System.EventHandler(this.GroupBox1_Enter);
			this.Panel2 = new System.Windows.Forms.Panel();
			this.Label3 = new System.Windows.Forms.Label();
			this.Panel1.SuspendLayout();
			this.GroupBox1.SuspendLayout();
			this.Panel2.SuspendLayout();
			this.SuspendLayout();
			//
			//Panel1
			//
			this.Panel1.BackColor = System.Drawing.Color.Maroon;
			this.Panel1.Controls.Add(this.m_btnOK);
			this.Panel1.Controls.Add(this.m_btnCancel);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel1.Location = new System.Drawing.Point(3, 123);
			this.Panel1.Name = "Panel1";
			this.Panel1.Padding = new System.Windows.Forms.Padding(3);
			this.Panel1.Size = new System.Drawing.Size(296, 36);
			this.Panel1.TabIndex = 4;
			//
			//m_btnOK
			//
			this.m_btnOK.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.m_btnOK.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
			this.m_btnOK.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
			this.m_btnOK.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_btnOK.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btnOK.ImageIndex = 1;
			this.m_btnOK.ImageList = this.ImageList;
			this.m_btnOK.Location = new System.Drawing.Point(119, 3);
			this.m_btnOK.Name = "m_btnOK";
			this.m_btnOK.Size = new System.Drawing.Size(86, 30);
			this.m_btnOK.TabIndex = 0;
			this.m_btnOK.Text = "Đăng nhập";
			//
			//ImageList
			//
			this.ImageList.ImageStream = (System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream"));
			this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
			this.ImageList.Images.SetKeyName(0, "");
			this.ImageList.Images.SetKeyName(1, "");
			//
			//m_btnCancel
			//
			this.m_btnCancel.AdjustImageLocation = new System.Drawing.Point(0, 0);
			this.m_btnCancel.BtnShape = SIS.Controls.Button.emunType.BtnShape.Rectangle;
			this.m_btnCancel.BtnStyle = SIS.Controls.Button.emunType.XPStyle.Default;
			this.m_btnCancel.Dock = System.Windows.Forms.DockStyle.Right;
			this.m_btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
			this.m_btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.m_btnCancel.ImageIndex = 0;
			this.m_btnCancel.ImageList = this.ImageList;
			this.m_btnCancel.Location = new System.Drawing.Point(205, 3);
			this.m_btnCancel.Name = "m_btnCancel";
			this.m_btnCancel.Size = new System.Drawing.Size(88, 30);
			this.m_btnCancel.TabIndex = 1;
			this.m_btnCancel.Text = "&Thoát";
			//
			//m_txtMatKhau
			//
			this.m_txtMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txtMatKhau.Location = new System.Drawing.Point(114, 77);
			this.m_txtMatKhau.MaxLength = 12;
			this.m_txtMatKhau.Name = "m_txtMatKhau";
			this.m_txtMatKhau.PasswordChar = global::Microsoft.VisualBasic.Strings.ChrW(42);
			this.m_txtMatKhau.Size = new System.Drawing.Size(98, 20);
			this.m_txtMatKhau.TabIndex = 3;
			//
			//Label2
			//
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.Label2.Location = new System.Drawing.Point(49, 77);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(60, 21);
			this.Label2.TabIndex = 2;
			this.Label2.Text = "Mật khẩu:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//Label1
			//
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.Label1.Location = new System.Drawing.Point(25, 47);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(84, 20);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Tên truy nhập:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//m_txtTenTruyNhap
			//
			this.m_txtTenTruyNhap.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_txtTenTruyNhap.Location = new System.Drawing.Point(114, 47);
			this.m_txtTenTruyNhap.MaxLength = 12;
			this.m_txtTenTruyNhap.Name = "m_txtTenTruyNhap";
			this.m_txtTenTruyNhap.Size = new System.Drawing.Size(147, 20);
			this.m_txtTenTruyNhap.TabIndex = 1;
			//
			//GroupBox1
			//
			this.GroupBox1.Controls.Add(this.m_txtTenTruyNhap);
			this.GroupBox1.Controls.Add(this.Label1);
			this.GroupBox1.Controls.Add(this.m_txtMatKhau);
			this.GroupBox1.Controls.Add(this.Label2);
			this.GroupBox1.Controls.Add(this.Panel1);
			this.GroupBox1.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.GroupBox1.Location = new System.Drawing.Point(0, 8);
			this.GroupBox1.Name = "GroupBox1";
			this.GroupBox1.Size = new System.Drawing.Size(302, 162);
			this.GroupBox1.TabIndex = 0;
			this.GroupBox1.TabStop = false;
			this.GroupBox1.Text = "Đăng nhập - Hệ thống iZA";
			//
			//Panel2
			//
			this.Panel2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
			this.Panel2.Controls.Add(this.Label3);
			this.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.Panel2.Location = new System.Drawing.Point(0, 165);
			this.Panel2.Name = "Panel2";
			this.Panel2.Size = new System.Drawing.Size(302, 40);
			this.Panel2.TabIndex = 1;
			//
			//Label3
			//
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.25F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.ForeColor = System.Drawing.Color.Maroon;
			this.Label3.Location = new System.Drawing.Point(8, 10);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(286, 20);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Designed by BKIndex Group, 3T Corp.Ltd";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//f101_Dang_Nhap
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.Maroon;
			this.ClientSize = new System.Drawing.Size(302, 205);
			this.Controls.Add(this.GroupBox1);
			this.Controls.Add(this.Panel2);
			this.Font = new System.Drawing.Font("Microsoft Sans Serif", (float)(8.0F));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "f101_Dang_Nhap";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "M001-Đăng nhập";
			this.Panel1.ResumeLayout(false);
			this.GroupBox1.ResumeLayout(false);
			this.GroupBox1.PerformLayout();
			this.Panel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		#region PUBLIC INTERFACES
		public void displayLogin(ref CLoginInformation_302 o_Information, ref 
			DialogResult o_LoginResult)
		{
			//*********************************************************************
			//* Hiện thị cửa sổ đăng nhập vào hệ thống
			//* Trả lại kết quả tùy theo kết quả đăng nhập. Có hai loại
			//* - Thành công : o_LoginResult = DialogResult.OK
			//* - Không thành công : o_LoginResult = DialogResult.Cancel
			//*********************************************************************
			this.DialogResult = DialogResult.Cancel;
			//Hiện thị cửa sổ
			this.ShowDialog();
			o_LoginResult = this.DialogResult;
			if (o_LoginResult == DialogResult.OK)
			{
				//phai lap trinh
				o_Information = new CLoginInformation_302(m_us_user);
			}

		}
		#endregion

		#region Data Structure

		#endregion

		#region Members
		private string m_strUserName;
		private US_HT_NGUOI_SU_DUNG m_us_user = new US_HT_NGUOI_SU_DUNG();
		#endregion

		#region Private methods
		private void FormatForm()
		{
			// CControlFormat.setFormStyle(Me)
			this.ShowInTaskbar = true;
		}
		private bool ValidLogonData()
		{
			if (!CValidateTextBox.IsValid(this.m_txtTenTruyNhap, DataType.StringType, allowNull.NO, false))
			{
				BaseMessages.MsgBox_Warning(19);
				return false;
			}

			if (!CValidateTextBox.IsValid(this.m_txtMatKhau, DataType.StringType, allowNull.NO, false))
			{
				BaseMessages.MsgBox_Warning(20);
				return false;
			}



			return true;
		}
		private void Form2UsObject()
		{
			m_us_user.strTEN_TRUY_CAP = m_txtTenTruyNhap.Text.Trim();
			//m_us_user.strMAT_KHAU = m_txtMatKhau.Text.Trim
			m_us_user.strMAT_KHAU = CIPConvert.Encoding(m_txtMatKhau.Text.Trim());
		}
		private bool SubmitLogonIsOK()
		{
			//*********************************************************************
			//*  1. Kiểm tra các trường trên màn hình
			//*  2. Kiểm tra xem password, tên, nhóm có đúng không
			//*  3. Trả lại kết quả
			//*********************************************************************
			if (!ValidLogonData())
			{
				return false;
			}
			US_HT_NGUOI_SU_DUNG v_us_user = new US_HT_NGUOI_SU_DUNG();
			US_HT_NGUOI_SU_DUNG.LogonResult v_logonResult = default(US_HT_NGUOI_SU_DUNG.LogonResult);
			Form2UsObject();
			m_us_user.check_user(m_us_user.strTEN_TRUY_CAP, m_us_user.strMAT_KHAU, ref v_logonResult);
			bool v_loginSucceeded = false;

			if (v_logonResult == IP.Core.IPUserService.US_HT_NGUOI_SU_DUNG.LogonResult.WrongPassword_OR_Name)
			{
				BaseMessages.MsgBox_Warning(18);
			}
			else if (v_logonResult == US_HT_NGUOI_SU_DUNG.LogonResult.User_Is_Locked)
			{
				BaseMessages.MsgBox_Warning(21);
			}
			else if (v_logonResult == US_HT_NGUOI_SU_DUNG.LogonResult.OK_Login_Succeeded)
			{
				v_loginSucceeded = true;
			} //should never happen, stop if get there
			else
			{
				Debug.Assert(false);
			}
			if (v_loginSucceeded)
			{
				return true;
			}
			else
			{
				return false;
			}
			return true;

		}


		private void setInitialFormLoad()
		{
		}
		#endregion
		//
		//    EVENTS HANDER
		//
		private void f101_Dang_Nhap_Load(object sender, System.EventArgs e)
		{
			this.KeyPreview = true;
			try
			{
				setInitialFormLoad();
				// Dim v_settingReader As New System.Configuration.AppSettingsReader
				//  Me.m_strMaDonVi = v_settingReader.GetValue("MA_DON_VI", System.Type.GetType("System.String")).ToString()
				//  Me.m_strMaHeThongDangNhap = v_settingReader.GetValue("MA_HE_THONG", System.Type.GetType("System.String")).ToString(
				// LoadUserGroup()
				m_btnOK.Click += m_btnOK_Click;
				m_btnCancel.Click += m_btnCancel_Click;
			}
			catch (System.Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}



		private void m_btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			//**********************************************************************
			//*  Thoát ra không vào hệ thống nữa
			//********************************************************************
			try
			{
				this.DialogResult = DialogResult.Cancel;
				this.Close();

			}
			catch (Exception ex)
			{
				CSystemLog_301.ExceptionHandle(ex);
			}

		}


		private void m_btnOK_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				if (SubmitLogonIsOK())
				{
					this.DialogResult = DialogResult.OK;
					this.Close();
				}
			}
			catch (Exception ex)
			{
				CSystemLog_301.ExceptionHandle(ex);
			}
		}

		private void f101_Dang_Nhap_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				switch (e.KeyCode)
				{
					case Keys.Enter:
						this.m_btnOK_Click(sender, e);
						break;
					case Keys.Escape:
						this.m_btnCancel_Click(sender, e);
						break;
				}
			}
			catch (Exception ex)
			{
				CSystemLog_301.ExceptionHandle(ex);
			}
		}

		private void GroupBox1_Enter(System.Object sender, System.EventArgs e)
		{

		}
	}
}
