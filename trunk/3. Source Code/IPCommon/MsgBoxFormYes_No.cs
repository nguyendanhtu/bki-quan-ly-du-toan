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
		public class MsgBoxForm_Yes_No : System.Windows.Forms.Form
		{
#region Khai báo biến
			const int c_MaxStringLength = 80;
			const int c_MinStringLength = 23;
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
			public System.Windows.Forms.DialogResult Display(string i_strMsg, string i_titleMsg, MessageForms.Msgs.MsgIconType i_IconType)
			{
				SetWidthHeightForm(i_strMsg);
				FormatFormMsg(i_titleMsg, this.m_PanelCtrl);
				m_MsgResult = System.Windows.Forms.DialogResult.No;
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
			
#region  Windows Form Designer generated code
			
			public MsgBoxForm_Yes_No()
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
			internal System.Windows.Forms.Label LabMsg;
			internal System.Windows.Forms.ImageList MsgIcons;
			internal System.Windows.Forms.PictureBox PicIcon;
			internal System.Windows.Forms.Panel m_PanelCtrl;
			internal System.Windows.Forms.Button m_cmdDongY;
			internal System.Windows.Forms.Button m_KhongDongY;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MsgBoxForm_Yes_No));
				this.PicIcon = new System.Windows.Forms.PictureBox();
				this.LabMsg = new System.Windows.Forms.Label();
				this.MsgIcons = new System.Windows.Forms.ImageList(this.components);
				this.m_PanelCtrl = new System.Windows.Forms.Panel();
				this.m_cmdDongY = new System.Windows.Forms.Button();
				this.m_cmdDongY.Click += new System.EventHandler(this.m_cmdDongY_Click);
				this.m_KhongDongY = new System.Windows.Forms.Button();
				this.m_KhongDongY.Click += new System.EventHandler(this.m_KhongDongY_Click);
				this.m_PanelCtrl.SuspendLayout();
				this.SuspendLayout();
				//
				//PicIcon
				//
				this.PicIcon.Location = new System.Drawing.Point(12, 10);
				this.PicIcon.Name = "PicIcon";
				this.PicIcon.Size = new System.Drawing.Size(49, 40);
				this.PicIcon.TabIndex = 1;
				this.PicIcon.TabStop = false;
				//
				//LabMsg
				//
				this.LabMsg.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.LabMsg.Location = new System.Drawing.Point(72, 14);
				this.LabMsg.Name = "LabMsg";
				this.LabMsg.Size = new System.Drawing.Size(162, 35);
				this.LabMsg.TabIndex = 2;
				this.LabMsg.Text = "Label1";
				//
				//MsgIcons
				//
				this.MsgIcons.ImageSize = new System.Drawing.Size(32, 32);
				this.MsgIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("MsgIcons.ImageStream"));
				this.MsgIcons.TransparentColor = System.Drawing.Color.Transparent;
				//
				//m_PanelCtrl
				//
				this.m_PanelCtrl.Controls.Add(this.m_cmdDongY);
				this.m_PanelCtrl.Controls.Add(this.m_KhongDongY);
				this.m_PanelCtrl.Location = new System.Drawing.Point(5, 61);
				this.m_PanelCtrl.Name = "m_PanelCtrl";
				this.m_PanelCtrl.Size = new System.Drawing.Size(243, 42);
				this.m_PanelCtrl.TabIndex = 4;
				//
				//m_cmdDongY
				//
				this.m_cmdDongY.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.m_cmdDongY.ForeColor = System.Drawing.Color.Blue;
				this.m_cmdDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.m_cmdDongY.Location = new System.Drawing.Point(6, 8);
				this.m_cmdDongY.Name = "m_cmdDongY";
				this.m_cmdDongY.Size = new System.Drawing.Size(98, 24);
				this.m_cmdDongY.TabIndex = 0;
				this.m_cmdDongY.Text = "&Đồng ý";
				//
				//m_KhongDongY
				//
				this.m_KhongDongY.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.m_KhongDongY.ForeColor = System.Drawing.Color.Blue;
				this.m_KhongDongY.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.m_KhongDongY.Location = new System.Drawing.Point(120, 8);
				this.m_KhongDongY.Name = "m_KhongDongY";
				this.m_KhongDongY.Size = new System.Drawing.Size(112, 24);
				this.m_KhongDongY.TabIndex = 1;
				this.m_KhongDongY.Text = "&Không đồng ý";
				//
				//MsgBoxForm_Yes_No
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(322, 104);
				this.Controls.Add(this.m_PanelCtrl);
				this.Controls.Add(this.LabMsg);
				this.Controls.Add(this.PicIcon);
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
				this.KeyPreview = true;
				this.Name = "MsgBoxForm_Yes_No";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "MsgBox_Yes_No_Form";
				this.m_PanelCtrl.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			
#endregion
			
#region Format form
			private void SetWidthHeightForm(string i_strMsg)
			{
				long v_MsgLength = i_strMsg.Length;
				int v_NumOfLine = 1;
				long v_LabelWidth = 0;
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
					v_LabelWidth = System.Convert.ToInt64(v_MsgLength * c_CharaterWidth);
				}
				long v_FormWidth = System.Convert.ToInt64(v_LabelWidth + c_FormLabelDiffWidth);
				long v_LabelHeight = c_LabelLineHeight * v_NumOfLine;
				long v_FormHeight = System.Convert.ToInt64(v_LabelHeight + c_FormLabelDiffHeight);
				this.Width = System.Convert.ToInt32(v_FormWidth);
				this.Height = System.Convert.ToInt32(v_FormHeight);
				LabMsg.Width = System.Convert.ToInt32(v_LabelWidth);
				LabMsg.Height = System.Convert.ToInt32(v_LabelHeight);
				LabMsg.Font = c_Font;
				LabMsg.Text = i_strMsg;
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
			
#region  Private methode
			//Private Sub CtlMsgButton_ClickMe() Handles CtlMsgButton.ClickMe
			//    m_MsgResult = CtlMsgButton.ClickResult
			//    Me.Close()
			//End Sub
			
			//Private Sub MsgBoxForm_Yes_No_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
			
			//End Sub
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
			
			private void m_KhongDongY_Click(System.Object sender, System.EventArgs e)
			{
				m_MsgResult = System.Windows.Forms.DialogResult.No;
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
						
				}
			}
#endregion
			
		}
	}
}
