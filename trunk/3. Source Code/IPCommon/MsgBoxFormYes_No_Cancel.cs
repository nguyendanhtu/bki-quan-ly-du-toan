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
		public class MsgBoxFormYes_No_Cancel : System.Windows.Forms.Form
		{
			
#region Khai báo biến
			const int c_MaxStringLength = 80;
			const int c_MinStringLength = 40;
			const int c_MinFormWidth = 100;
			const int c_MaxFormWidth = 600;
			const int c_CharaterWidth = 6;
			const int c_FormLabelDiffHeight = 100;
			const int c_LabelLineHeight = 16;
			const int c_FormLabelDiffWidth = 100;
			private System.Windows.Forms.DialogResult m_MsgResult;
			private System.Drawing.Font c_Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular);
			
#endregion
			
#region Public Interface
			public System.Windows.Forms.DialogResult Display(string i_strMsg, string i_TitleMsg, MessageForms.Msgs.MsgIconType i_IconType)
			{
				SetWidthHeightForm(i_strMsg);
				FormatFormMsg(i_TitleMsg, m_PanelCtrl);
				switch (i_IconType)
				{
					case MessageForms.Msgs.MsgIconType.ErrorIcon:
						PicIcon.Image = this.MsgIcons.Images[System.Convert.ToInt32(MessageForms.Msgs.MsgIconType.ErrorIcon)];
						break;
					case MessageForms.Msgs.MsgIconType.InfomationIcon:
						PicIcon.Image = this.MsgIcons.Images[System.Convert.ToInt32(MessageForms.Msgs.MsgIconType.InfomationIcon)];
						break;
					case MessageForms.Msgs.MsgIconType.QuestionIcon:
						PicIcon.Image = this.MsgIcons.Images[System.Convert.ToInt32(MessageForms.Msgs.MsgIconType.QuestionIcon)];
						break;
					case MessageForms.Msgs.MsgIconType.WarningIcon:
						PicIcon.Image = this.MsgIcons.Images[System.Convert.ToInt32(MessageForms.Msgs.MsgIconType.WarningIcon)];
						break;
				}
				this.ShowDialog();
				return m_MsgResult;
			}
#endregion
			
#region Windows Form Designer generated code
			
			public MsgBoxFormYes_No_Cancel()
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
			internal System.Windows.Forms.ImageList MsgIcons;
			internal System.Windows.Forms.Label LabMsg;
			internal System.Windows.Forms.PictureBox PicIcon;
			//Friend WithEvents CtlMsgButton As MessageForms.MsgBoxFormYes_No_Cancel
			internal System.Windows.Forms.Panel m_PanelCtrl;
			internal System.Windows.Forms.Button m_cmdDongY;
			internal System.Windows.Forms.Button m_cmdKhongDongY;
			internal System.Windows.Forms.Button m_cmdHuyBo;
			internal System.Windows.Forms.ImageList ImageList;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MsgBoxFormYes_No_Cancel));
				this.MsgIcons = new System.Windows.Forms.ImageList(this.components);
				this.PicIcon = new System.Windows.Forms.PictureBox();
				this.LabMsg = new System.Windows.Forms.Label();
				this.m_PanelCtrl = new System.Windows.Forms.Panel();
				this.m_cmdHuyBo = new System.Windows.Forms.Button();
				this.m_cmdHuyBo.Click += new System.EventHandler(this.m_cmdHuyBo_Click);
				this.m_cmdKhongDongY = new System.Windows.Forms.Button();
				this.m_cmdKhongDongY.Click += new System.EventHandler(this.m_cmdKhongDongY_Click);
				this.m_cmdDongY = new System.Windows.Forms.Button();
				this.m_cmdDongY.Click += new System.EventHandler(this.m_cmdDongY_Click);
				this.ImageList = new System.Windows.Forms.ImageList(this.components);
				this.m_PanelCtrl.SuspendLayout();
				this.SuspendLayout();
				//
				//MsgIcons
				//
				this.MsgIcons.ImageSize = new System.Drawing.Size(32, 32);
				this.MsgIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("MsgIcons.ImageStream"));
				this.MsgIcons.TransparentColor = System.Drawing.Color.Transparent;
				//
				//PicIcon
				//
				this.PicIcon.Location = new System.Drawing.Point(8, 8);
				this.PicIcon.Name = "PicIcon";
				this.PicIcon.Size = new System.Drawing.Size(50, 39);
				this.PicIcon.TabIndex = 2;
				this.PicIcon.TabStop = false;
				//
				//LabMsg
				//
				this.LabMsg.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.LabMsg.Location = new System.Drawing.Point(70, 12);
				this.LabMsg.Name = "LabMsg";
				this.LabMsg.Size = new System.Drawing.Size(162, 35);
				this.LabMsg.TabIndex = 3;
				this.LabMsg.Text = "Label1";
				//
				//m_PanelCtrl
				//
				this.m_PanelCtrl.Controls.Add(this.m_cmdHuyBo);
				this.m_PanelCtrl.Controls.Add(this.m_cmdKhongDongY);
				this.m_PanelCtrl.Controls.Add(this.m_cmdDongY);
				this.m_PanelCtrl.Location = new System.Drawing.Point(24, 68);
				this.m_PanelCtrl.Name = "m_PanelCtrl";
				this.m_PanelCtrl.Size = new System.Drawing.Size(329, 44);
				this.m_PanelCtrl.TabIndex = 5;
				//
				//m_cmdHuyBo
				//
				this.m_cmdHuyBo.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.m_cmdHuyBo.ForeColor = System.Drawing.Color.Blue;
				this.m_cmdHuyBo.Location = new System.Drawing.Point(220, 8);
				this.m_cmdHuyBo.Name = "m_cmdHuyBo";
				this.m_cmdHuyBo.Size = new System.Drawing.Size(105, 24);
				this.m_cmdHuyBo.TabIndex = 2;
				this.m_cmdHuyBo.Text = "&Huỷ bỏ";
				//
				//m_cmdKhongDongY
				//
				this.m_cmdKhongDongY.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.m_cmdKhongDongY.ForeColor = System.Drawing.Color.Blue;
				this.m_cmdKhongDongY.Location = new System.Drawing.Point(112, 8);
				this.m_cmdKhongDongY.Name = "m_cmdKhongDongY";
				this.m_cmdKhongDongY.Size = new System.Drawing.Size(105, 24);
				this.m_cmdKhongDongY.TabIndex = 1;
				this.m_cmdKhongDongY.Text = "&Không đồng ý";
				//
				//m_cmdDongY
				//
				this.m_cmdDongY.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.m_cmdDongY.ForeColor = System.Drawing.Color.Blue;
				this.m_cmdDongY.Location = new System.Drawing.Point(4, 8);
				this.m_cmdDongY.Name = "m_cmdDongY";
				this.m_cmdDongY.Size = new System.Drawing.Size(105, 24);
				this.m_cmdDongY.TabIndex = 0;
				this.m_cmdDongY.Text = "&Đồng ý";
				//
				//ImageList
				//
				this.ImageList.ImageSize = new System.Drawing.Size(16, 16);
				this.ImageList.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("ImageList.ImageStream"));
				this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
				//
				//MsgBoxFormYes_No_Cancel
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(366, 128);
				this.Controls.Add(this.m_PanelCtrl);
				this.Controls.Add(this.LabMsg);
				this.Controls.Add(this.PicIcon);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
				this.Name = "MsgBoxFormYes_No_Cancel";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Form3";
				this.m_PanelCtrl.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			
#endregion
			
#region Format form
			private void SetWidthHeightForm(string i_strMsg)
			{
				long v_MsgLength = i_strMsg.Length;
				int v_NumOfLine = 1;
				int v_LabelWidth = 0;
				if (v_MsgLength > c_MaxStringLength)
				{
					v_NumOfLine = System.Convert.ToInt32((double) v_MsgLength / c_MaxStringLength) + 1;
					v_LabelWidth = c_MaxStringLength * c_CharaterWidth;
				}
				else if (v_MsgLength < c_MinStringLength)
				{
					v_LabelWidth = c_MinStringLength * c_CharaterWidth;
				}
				else
				{
					v_LabelWidth = System.Convert.ToInt32(v_MsgLength * c_CharaterWidth);
				}
				int v_FormWidth = v_LabelWidth + c_FormLabelDiffWidth;
				int v_LabelHeight = c_LabelLineHeight * v_NumOfLine;
				int v_FormHeight = v_LabelHeight + c_FormLabelDiffHeight;
				this.Width = System.Convert.ToInt32(v_FormWidth);
				this.Height = System.Convert.ToInt32(v_FormHeight);
				LabMsg.Width = System.Convert.ToInt32(v_LabelWidth);
				LabMsg.Height = System.Convert.ToInt32(v_LabelHeight);
				LabMsg.Text = i_strMsg;
				LabMsg.Font = c_Font;
			}
			
			
			private void FormatFormMsg(string i_TitleMsg, System.Windows.Forms.Control i_Button)
			{
				int v_FormHeight = this.Height;
				int v_FormWidth = this.Width;
				int v_FormTop = this.Top;
				int v_FormLeft = this.Left;
				int v_ButtonWidth = i_Button.Width;
				int v_ButtonHeight = i_Button.Height;
				int v_ButtonLeft = System.Convert.ToInt32((double) (v_FormWidth - v_ButtonWidth) / 2);
				int v_buttonTop = v_FormHeight - v_ButtonHeight - 25;
				this.Text = i_TitleMsg;
				i_Button.Top = v_buttonTop;
				i_Button.Left = v_ButtonLeft;
			}
#endregion
			
			
			
#region Private methode
			private void DongForm()
			{
				this.Close();
			}
#endregion
			
#region Events handler
			private void m_cmdDongY_Click(System.Object sender, System.EventArgs e)
			{
				m_MsgResult = System.Windows.Forms.DialogResult.Yes;
				DongForm();
			}
			
			private void m_cmdKhongDongY_Click(System.Object sender, System.EventArgs e)
			{
				m_MsgResult = System.Windows.Forms.DialogResult.No;
				DongForm();
			}
			
			private void m_cmdHuyBo_Click(System.Object sender, System.EventArgs e)
			{
				m_MsgResult = System.Windows.Forms.DialogResult.Cancel;
				DongForm();
			}
			protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
			{
				switch (e.KeyCode)
				{
					case System.Windows.Forms.Keys.D:
						if (e.Alt)
						{
							m_MsgResult = System.Windows.Forms.DialogResult.Yes;
							DongForm();
						}
						break;
					case System.Windows.Forms.Keys.K:
						if (e.Alt)
						{
							m_MsgResult = System.Windows.Forms.DialogResult.No;
							DongForm();
						}
						break;
					case System.Windows.Forms.Keys.H:
						if (e.Alt)
						{
							m_MsgResult = System.Windows.Forms.DialogResult.Cancel;
							DongForm();
						}
						break;
				}
			}
			
#endregion
			
		}
		
	}
}
