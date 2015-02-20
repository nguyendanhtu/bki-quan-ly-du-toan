// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPCommon
{
	public class IPImages
	{
		private frmIcons m_frmForm;
		private IPImages()
		{
			m_frmForm = new frmIcons();
		}
		
		private System.Drawing.Image getImage(int i_imgIndex)
		{
			Debug.Assert(i_imgIndex >= 0 & i_imgIndex <= m_frmForm.m_imgListOfIcons.Images.Count - 1, 
				" ta: khoong co image voi index =  " + i_imgIndex.ToString());
			return m_frmForm.m_imgListOfIcons.Images[i_imgIndex];
		}
		
		private static IPImages m_IPImages;
		
		public static System.Drawing.Image getImageResource(int i_imgIndex)
		{
			if (m_IPImages == null)
			{
				m_IPImages = new IPImages();
			}
			return m_IPImages.getImage(i_imgIndex);
		}
	}
	
}
