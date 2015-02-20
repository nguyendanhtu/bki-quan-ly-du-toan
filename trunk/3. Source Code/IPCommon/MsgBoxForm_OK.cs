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
		public class MsgBoxForm_OK : System.Windows.Forms.Form
		{
#region Khai báo biến
			const int c_MaxStringLength = 80;
			const int c_MinStringLength = 10;
			const int c_MinFormWidth = 100;
			const int c_MaxFormWidth = 600;
			const int c_CharaterWidth = 7;
			const int c_FormLabelDiffHeight = 100;
			const int c_LabelLineHeight = 16;
			const int c_FormLabelDiffWidth = 100;
			private System.Drawing.Font c_Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular);
			private System.Windows.Forms.DialogResult m_Result;
#endregion
#region  Windows Form Designer generated code
			
			public MsgBoxForm_OK()
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
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				this.components = new System.ComponentModel.Container();
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MsgBoxForm_OK));
				this.CtlMsgButton = new System.Windows.Forms.Button();
				this.CtlMsgButton.Click += new System.EventHandler(this.CtlMsgButton_Click);
				this.PicIcon = new System.Windows.Forms.PictureBox();
				this.LabMsg = new System.Windows.Forms.Label();
				this.MsgIcons = new System.Windows.Forms.ImageList(this.components);
				this.SuspendLayout();
				//
				//CtlMsgButton
				//
				this.CtlMsgButton.DialogResult = System.Windows.Forms.DialogResult.OK;
				this.CtlMsgButton.Font = new System.Drawing.Font("Tahoma", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.CtlMsgButton.ForeColor = System.Drawing.Color.Blue;
				this.CtlMsgButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.CtlMsgButton.Location = new System.Drawing.Point(97, 56);
				this.CtlMsgButton.Name = "CtlMsgButton";
				this.CtlMsgButton.Size = new System.Drawing.Size(105, 24);
				this.CtlMsgButton.TabIndex = 0;
				this.CtlMsgButton.Text = "Đồng ý";
				//
				//PicIcon
				//
				this.PicIcon.Image = (System.Drawing.Image) (resources.GetObject("PicIcon.Image"));
				this.PicIcon.Location = new System.Drawing.Point(12, 10);
				this.PicIcon.Name = "PicIcon";
				this.PicIcon.Size = new System.Drawing.Size(44, 41);
				this.PicIcon.TabIndex = 1;
				this.PicIcon.TabStop = false;
				//
				//LabMsg
				//
				this.LabMsg.Font = new System.Drawing.Font("Arial", (float) (9.75F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.LabMsg.Location = new System.Drawing.Point(64, 16);
				this.LabMsg.Name = "LabMsg";
				this.LabMsg.Size = new System.Drawing.Size(206, 32);
				this.LabMsg.TabIndex = 2;
				this.LabMsg.Text = "Cộng hoà xã hội chủ nghĩa";
				//
				//MsgIcons
				//
				this.MsgIcons.ImageSize = new System.Drawing.Size(32, 32);
				this.MsgIcons.ImageStream = (System.Windows.Forms.ImageListStreamer) (resources.GetObject("MsgIcons.ImageStream"));
				this.MsgIcons.TransparentColor = System.Drawing.Color.Transparent;
				//
				//MsgBoxForm_OK
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
				this.CancelButton = this.CtlMsgButton;
				this.ClientSize = new System.Drawing.Size(278, 92);
				this.Controls.Add(this.LabMsg);
				this.Controls.Add(this.PicIcon);
				this.Controls.Add(this.CtlMsgButton);
				this.Font = new System.Drawing.Font("Arial", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
				this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
				this.Name = "MsgBoxForm_OK";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "MsgBoxForm_OK";
				this.ResumeLayout(false);
				
			}
			
#endregion
			
#region Format form
			private void SetWidthHeightForm(string i_strMsg)
			{
				long v_MsgLength = i_strMsg.Length;
				long v_NumOfLine = 1;
				long v_LabelWidth = 0;
				if (v_MsgLength > c_MaxStringLength)
				{
					v_NumOfLine = (long) ((double) System.Convert.ToInt32(v_MsgLength / c_MaxStringLength) + 1);
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
			
			public System.Windows.Forms.DialogResult Display(string i_strMsg, string i_titleMsg, MessageForms.Msgs.MsgIconType i_IconType)
			{
				SetWidthHeightForm(i_strMsg);
				FormatFormMsg(i_titleMsg, this.CtlMsgButton);
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
				return m_Result;
			}
			
			private void FormatFormMsg(string i_TitleMsg, System.Windows.Forms.Control i_Button)
			{
				try
				{
					int v_FormHeight = this.Height;
					int v_FormWidth = this.Width;
					int v_FormTop = this.Top;
					int v_FormLeft = this.Left;
					int v_ButtonWidth = i_Button.Width;
					int v_ButtonHeight = i_Button.Height;
					int v_ButtonLeft = System.Convert.ToInt32((double) (v_FormWidth - v_ButtonWidth) / 2);
					int v_buttonTop = v_FormHeight - v_ButtonHeight - 35;
					this.Text = i_TitleMsg;
					i_Button.Top = v_buttonTop;
					i_Button.Left = v_ButtonLeft;
				}
				catch
				{
					
				}
			}
#endregion
			internal System.Windows.Forms.Button CtlMsgButton;
			private void CtlMsgButton_Click(object sender, System.EventArgs e)
			{
				m_Result = System.Windows.Forms.DialogResult.OK;
				this.Close();
			}
			
			protected override void OnKeyDown(System.Windows.Forms.KeyEventArgs e)
			{
				switch (e.KeyCode)
				{
					case System.Windows.Forms.Keys.D:
						m_Result = System.Windows.Forms.DialogResult.OK;
						this.Close();
						break;
				}
				
			}
		}
	}
}
