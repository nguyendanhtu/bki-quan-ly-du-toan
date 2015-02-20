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
	public class CForm_Escape_Keydown_Handler
	{
		private Form m_fForm;
		
		public CForm_Escape_Keydown_Handler(Form i_fForm)
		{
			m_fForm = i_fForm;
		}
		
		public void HandleEscapeKeydown()
		{
			m_fForm.KeyDown += m_fForm_KeyDown;
		}
		
		private void m_fForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			switch (e.KeyCode)
			{
				case Keys.Escape:
					m_fForm.Close();
					break;
			}
		}
	}
	
}
