// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPUserService;
using IP.Core.IPData;
using IP.Core.IPException;
using IP.Core.IPCommon;




namespace IP.Core.IPSystemAdmin
{
	public class f102_TuDien_DE : System.Windows.Forms.Form
	{
		
#region  Windows Form Designer generated code
		
		public f102_TuDien_DE()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			
			//Add any initialization after the InitializeComponent() call
			formatControls();
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
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtMaTuDien;
		internal System.Windows.Forms.TextBox txtTenNgan;
		internal System.Windows.Forms.TextBox txtTen;
		internal System.Windows.Forms.Button m_cmdChapNhan;
		internal System.Windows.Forms.Button m_cmdHuyBo;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			this.Label1 = new System.Windows.Forms.Label();
			base.Load += new System.EventHandler(f101_TuDien_DE_Load);
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(f101_TuDien_DE_KeyDown);
			this.Label2 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.txtMaTuDien = new System.Windows.Forms.TextBox();
			this.txtTenNgan = new System.Windows.Forms.TextBox();
			this.txtTen = new System.Windows.Forms.TextBox();
			this.m_cmdChapNhan = new System.Windows.Forms.Button();
			this.m_cmdChapNhan.Click += new System.EventHandler(this.m_cmdChapNhan_Click);
			this.m_cmdHuyBo = new System.Windows.Forms.Button();
			this.m_cmdHuyBo.Click += new System.EventHandler(this.m_cmdHuyBo_Click);
			this.SuspendLayout();
			//
			//Label1
			//
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label1.Location = new System.Drawing.Point(-16, 2);
			this.Label1.Name = "Label1";
			this.Label1.Size = new System.Drawing.Size(90, 23);
			this.Label1.TabIndex = 0;
			this.Label1.Text = "Mã từ điển:";
			this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//Label2
			//
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label2.Location = new System.Drawing.Point(-32, 24);
			this.Label2.Name = "Label2";
			this.Label2.Size = new System.Drawing.Size(108, 24);
			this.Label2.TabIndex = 1;
			this.Label2.Text = "Tên ngắn:";
			this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//Label3
			//
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Label3.Location = new System.Drawing.Point(-32, 56);
			this.Label3.Name = "Label3";
			this.Label3.Size = new System.Drawing.Size(108, 24);
			this.Label3.TabIndex = 2;
			this.Label3.Text = "Tên:";
			this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			//
			//txtMaTuDien
			//
			this.txtMaTuDien.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtMaTuDien.Location = new System.Drawing.Point(88, 4);
			this.txtMaTuDien.MaxLength = 15;
			this.txtMaTuDien.Name = "txtMaTuDien";
			this.txtMaTuDien.Size = new System.Drawing.Size(128, 22);
			this.txtMaTuDien.TabIndex = 3;
			//
			//txtTenNgan
			//
			this.txtTenNgan.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtTenNgan.Location = new System.Drawing.Point(88, 32);
			this.txtTenNgan.MaxLength = 50;
			this.txtTenNgan.Name = "txtTenNgan";
			this.txtTenNgan.Size = new System.Drawing.Size(336, 22);
			this.txtTenNgan.TabIndex = 4;
			//
			//txtTen
			//
			this.txtTen.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.txtTen.Location = new System.Drawing.Point(88, 64);
			this.txtTen.MaxLength = 250;
			this.txtTen.Multiline = true;
			this.txtTen.Name = "txtTen";
			this.txtTen.Size = new System.Drawing.Size(336, 104);
			this.txtTen.TabIndex = 5;
			//
			//m_cmdChapNhan
			//
			this.m_cmdChapNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_cmdChapNhan.Location = new System.Drawing.Point(160, 176);
			this.m_cmdChapNhan.Name = "m_cmdChapNhan";
			this.m_cmdChapNhan.Size = new System.Drawing.Size(130, 28);
			this.m_cmdChapNhan.TabIndex = 6;
			this.m_cmdChapNhan.Text = "&Chấp nhận";
			//
			//m_cmdHuyBo
			//
			this.m_cmdHuyBo.Font = new System.Drawing.Font("Microsoft Sans Serif", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.m_cmdHuyBo.Location = new System.Drawing.Point(296, 176);
			this.m_cmdHuyBo.Name = "m_cmdHuyBo";
			this.m_cmdHuyBo.Size = new System.Drawing.Size(130, 28);
			this.m_cmdHuyBo.TabIndex = 7;
			this.m_cmdHuyBo.Text = "&Hủy bỏ";
			//
			//f102_TuDien_DE
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(426, 207);
			this.Controls.Add(this.m_cmdHuyBo);
			this.Controls.Add(this.m_cmdChapNhan);
			this.Controls.Add(this.txtTen);
			this.Controls.Add(this.txtTenNgan);
			this.Controls.Add(this.txtMaTuDien);
			this.Controls.Add(this.Label3);
			this.Controls.Add(this.Label2);
			this.Controls.Add(this.Label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "f102_TuDien_DE";
			this.Text = "M102 - Cập nhật từ điển";
			this.ResumeLayout(false);
			this.PerformLayout();
			
		}
		
#endregion
		
#region Các thuộc tính riêng
		private IPConstants.DataEntryFormMode m_FormMode;
		private US_CM_DM_TU_DIEN m_USTuDien;
		private DialogResult m_DialogResult;
#endregion
		
#region Public interface
		public DialogResult InsertObj(US_CM_DM_TU_DIEN i_objTuDien)
		{
			m_FormMode = IPConstants.DataEntryFormMode.InsertDataState;
			m_USTuDien = i_objTuDien;
			this.ShowDialog();
			return m_DialogResult;
		}
		
		public DialogResult UpdateObj(US_CM_DM_TU_DIEN i_objTuDien)
		{
			m_FormMode = IPConstants.DataEntryFormMode.UpdateDataState;
			m_USTuDien = i_objTuDien;
			this.ShowDialog();
			return m_DialogResult;
		}
#endregion
		
#region Private method
		private void formatControls()
		{
			CControlFormat.setFormStyle(this);
			this.KeyPreview = true;
			CControlFormat.setButtonStyle(this.m_cmdChapNhan, CControlFormat.ButtonStyle.OkButtonStyle);
			CControlFormat.setButtonStyle(this.m_cmdHuyBo, CControlFormat.ButtonStyle.CancelButtonStyle);
			
		}
		private bool CheckValidate()
		{
			if (!CValidateTextBox.IsValid(txtMaTuDien, DataType.StringType, allowNull.NO))
			{
				return false;
			}
			if (!CValidateTextBox.IsValid(this.txtTenNgan, DataType.StringType, allowNull.NO))
			{
				return false;
			}
			return true;
		}
		
		private void Form2USObj(US_CM_DM_TU_DIEN i_objUS)
		{
			i_objUS.strMA_TU_DIEN = txtMaTuDien.Text;
			i_objUS.strTEN = txtTen.Text;
			i_objUS.strTEN_NGAN = txtTenNgan.Text;
			i_objUS.strGHI_CHU = "";
		}
		
		private void USObj2Form(US_CM_DM_TU_DIEN i_objUS)
		{
			txtMaTuDien.Text = i_objUS.strMA_TU_DIEN;
			txtTenNgan.Text = i_objUS.strTEN_NGAN;
			txtTen.Text = i_objUS.strTEN;
		}
		
#endregion
		
		
		private void f101_TuDien_DE_Load(System.Object sender, System.EventArgs e)
		{
			m_DialogResult = DialogResult.Cancel;
			if (m_FormMode == IPConstants.DataEntryFormMode.InsertDataState)
			{
			}
			else if (m_FormMode == IPConstants.DataEntryFormMode.UpdateDataState)
			{
				this.USObj2Form(m_USTuDien);
			}
		}
		
		private void m_cmdHuyBo_Click(System.Object sender, System.EventArgs e)
		{
			this.Close();
		}
		
		
		private void m_cmdChapNhan_Click(System.Object sender, System.EventArgs e)
		{
			if (!this.CheckValidate())
			{
				return;
			}
			
			this.Form2USObj(m_USTuDien);
			try
			{
				if (m_FormMode == IPConstants.DataEntryFormMode.InsertDataState)
				{
					m_USTuDien.Insert();
				}
				else if (m_FormMode == IPConstants.DataEntryFormMode.UpdateDataState)
				{
					m_USTuDien.Update();
				}
				m_DialogResult = DialogResult.OK;
				this.Close();
			}
			catch (Exception v_e)
			{
				CDBExceptionHandler v_ErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_ErrHandler.setErrorMsg(CDBExceptionHandler.DBErrorIndex.NoParentFound, "Không tìm thấy loại từ điển");
				v_ErrHandler.showErrorMessage();
			}
		}
		
		private void f101_TuDien_DE_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				switch (e.KeyCode)
				{
					case Keys.Escape:
						this.Close();
						break;
					case Keys.C:
						if (e.Alt)
						{
							m_cmdChapNhan_Click(sender, e);
						}
						break;
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
	}
	
}
