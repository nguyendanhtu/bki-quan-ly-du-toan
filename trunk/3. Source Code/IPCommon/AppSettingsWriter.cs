// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Xml;
//using System.Reflection.Assembly;

//NHIỆM VỤ CỦA CLASS
//   đọc và viết file config
//
//




namespace IP.Core.IPCommon
{
	public class AppSettingsWriter
	{
#region MEMBERS
		private string m_configFileName;
		private XmlDocument m_document;
#endregion
		
#region CONSTANTS
		private const string C_DOUBLE_QUOTE = "\u0022";
#endregion
		
#region public interface
		public AppSettingsWriter()
		{
			System.Reflection.Assembly v_asmy = default(System.Reflection.Assembly);
			string v_tempName = "";
			v_asmy = System.Reflection.Assembly.GetEntryAssembly();
			v_tempName = v_asmy.Location;
			
			m_configFileName = v_tempName + ".config";
			m_document = new XmlDocument();
			m_document.Load(m_configFileName);
		}
		
		public void writeValue(string i_Key, string i_Value)
		{
			
			string v_Query = "";
			XmlNode v_Node = default(XmlNode);
			XmlNode v_Root = default(XmlNode);
			XmlNode v_Key_Attribute = default(XmlNode);
			XmlNode v_Value_Attribute = default(XmlNode);
			
			v_Query = "/configuration/appSettings/add[@key=" + C_DOUBLE_QUOTE + i_Key + C_DOUBLE_QUOTE + "]";
			v_Node = m_document.DocumentElement.SelectSingleNode(v_Query);
			if (!(v_Node == null)) // neu co not nay roi thi doc no ra va set gia tri
			{
				v_Node.Attributes.GetNamedItem("value").Value = i_Value;
			}
			else // neu chua co thi tao ra
			{
				v_Node = m_document.CreateNode(XmlNodeType.Element, "add", "");
				
				v_Key_Attribute = m_document.CreateNode(XmlNodeType.Attribute, "key", "");
				v_Key_Attribute.Value = i_Key;
				v_Node.Attributes.SetNamedItem(v_Key_Attribute);
				
				v_Value_Attribute = m_document.CreateNode(XmlNodeType.Attribute, "value", "");
				v_Value_Attribute.Value = i_Value;
				v_Node.Attributes.SetNamedItem(v_Value_Attribute);
				
				v_Query = "/configuration/appSettings";
				v_Root = m_document.DocumentElement.SelectSingleNode(v_Query);
				if (!(v_Root == null))
				{
					v_Root.AppendChild(v_Node);
				}
				else
				{
					throw (new InvalidOperationException("Khong doc duoc file config"));
				}
			}
			
		}
		
		public void SaveFile()
		{
			m_document.Save(m_configFileName);
		}
#endregion
	}
	
	
	
}
