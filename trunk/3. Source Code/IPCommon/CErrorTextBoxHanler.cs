using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
using System.Windows.Forms;
using System.Drawing;

namespace IP.Core.IPCommon
{
	public class CErrorTextBoxHandler
	{

		private const int C_ERROR_CONTROL_IMAGE_INDEX = 14;
		private System.Drawing.Color C_BACKCOLOR_ERROR; // VBConversions Note: Initial value cannot be assigned here since it is non-static.  Assignment has been moved to the class constructors.
		private TextBox m_txtBox;
		private Form m_form;
		private System.Drawing.Color m_old_backcolor_of_txtBox;

		private CErrorTextBoxHandler(TextBox i_txtBox)
		{
			// VBConversions Note: Non-static class variable initialization is below.  Class variables cannot be initially assigned non-static values in C#.
			C_BACKCOLOR_ERROR = System.Drawing.Color.Pink;

			m_txtBox = i_txtBox;
			m_txtBox.Tag = this;
			m_form = i_txtBox.FindForm();
			addErrorMark();
			try
			{
				m_txtBox.Focus();
				m_txtBox.TextChanged += handle_changed;
				m_txtBox.Leave += handle_leave;
			}
			catch (Exception)
			{
				m_form.KeyDown += keydown_in_form;
			}
		}

		private void removeErrorMarkandHandlers()
		{
			removeErrorMark();
			m_txtBox.TextChanged -= handle_changed;
			m_txtBox.Leave -= handle_leave;
			m_form.KeyDown -= keydown_in_form;
			m_txtBox.Tag = null;
		}

		private void handle_changed(object sender, System.EventArgs e)
		{
			removeErrorMarkandHandlers();
		}

		private void handle_leave(object sender, System.EventArgs e)
		{
			removeErrorMarkandHandlers();
		}

		private void keydown_in_form(object sender, KeyEventArgs e)
		{
			removeErrorMarkandHandlers();
		}


		private void addErrorMark()
		{
			m_old_backcolor_of_txtBox = m_txtBox.BackColor;
			m_txtBox.BackColor = this.C_BACKCOLOR_ERROR;
		}

		private void removeErrorMark()
		{
			m_txtBox.BackColor = m_old_backcolor_of_txtBox;
		}


		private static PictureBox getPictureBox(int i_height, int i_width)
		{
			PictureBox v_pictureBox = new PictureBox();
			v_pictureBox.Image = IPImages.getImageResource(C_ERROR_CONTROL_IMAGE_INDEX);
			v_pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
			v_pictureBox.Size = new Size(i_width, i_height);
			return v_pictureBox;
		}

		private void addPB(PictureBox i_picturebox, int i_top, int i_left)
		{
			i_picturebox.Top = i_top;
			i_picturebox.Left = i_left;
			i_picturebox.BringToFront();
			m_txtBox.FindForm().Controls.Add(i_picturebox);
		}

		public static void markAsErrorTxtBox(TextBox i_txtBox)
		{
			CErrorTextBoxHandler v_err = new CErrorTextBoxHandler(i_txtBox);
		}
	}

}
