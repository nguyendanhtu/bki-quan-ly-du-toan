// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports



namespace IP.Core.IPCommon
{
	public class CListOfDataFromDB
	{
		private Hashtable m_hashtable;
		public CListOfDataFromDB(DataSet ip_ds, string ip_key_name = "ID", string ip_value_name = "TEN")
		{
			Debug.Assert(!(ip_ds == null), "CSUNG: DS NOT FILLED");
			Debug.Assert(!(ip_ds.Tables.Count == 0), "CSUNG: DS NOT FILLED");
			
			try
			{
				m_hashtable = new Hashtable();
				int v_i = 0;
				
				for (v_i = 0; v_i <= ip_ds.Tables[0].Rows.Count - 1; v_i++)
				{
					
					Debug.Assert(!ip_ds.Tables[0].Rows[v_i].IsNull(ip_key_name), "Csung: Key khong nulll duoc");
					if (ip_ds.Tables[0].Rows[v_i].IsNull(ip_value_name))
					{
						m_hashtable.Add(ip_ds.Tables[0].Rows[v_i][ip_key_name], null);
					}
					else
					{
						m_hashtable.Add(ip_ds.Tables[0].Rows[v_i][ip_key_name], 
							ip_ds.Tables[0].Rows[v_i][ip_value_name]);
					}
					
				}
			}
			catch (Exception v_e)
			{
				Debug.Assert(false, "csung khong biet: " + v_e.Message);
			}
			
		}
		
public object this[object ip_key]
		{
			get
			{
				return m_hashtable[ip_key];
			}
		}
		
		
	}
	
}
