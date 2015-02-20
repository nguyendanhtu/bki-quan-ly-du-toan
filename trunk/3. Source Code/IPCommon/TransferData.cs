// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using C1.Win.C1FlexGrid;
//using ip.Core.IPCommon;
	
	
	namespace IP.Core.IPCommon
	{
		public interface ITransferDataRow
		{
			void GridRow2DataRow(int i_Row, DataRow i_drDest);
		void DataRow2GridRow(DataRow i_drSource, int i_Row);
		Hashtable getHastableMapping();
	}
	
	public interface ITransferDataCell
	{
		void Data2Cell(DataRow i_drSource, int i_Row);
		void Cell2Data(int i_Row, DataRow i_drDest);
	}
	
	public class CTransferObjectData : ITransferDataCell
	{
		C1FlexGrid m_fg;
		int m_ColNumber;
		string m_strColName;
		
		public CTransferObjectData(C1FlexGrid i_fg, int i_ColNumber, 
			string i_strColName)
		{
			m_fg = i_fg;
			m_ColNumber = i_ColNumber;
			m_strColName = i_strColName;
		}
		
		void ITransferDataCell.Data2Cell(DataRow i_drSource, int i_Row)
		{
			this.imp_Data2Cell(i_drSource, i_Row);
		}
		
		public void imp_Data2Cell(DataRow i_drSource, int i_Row)
		{
			try
			{
				if (!i_drSource.IsNull(m_strColName))
				{
					m_fg[i_Row, m_ColNumber] = i_drSource[m_strColName];
				}
				else
				{
					m_fg[i_Row, m_ColNumber] = null;
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " - tuanqt");
			}
		}
		
		void ITransferDataCell.Cell2Data(int i_Row, DataRow i_drDest)
		{
			this.imp_Cell2Data(i_Row, i_drDest);
		}
		
		public void imp_Cell2Data(int i_Row, DataRow i_drDest)
		{
			try
			{
				if (m_fg[i_Row, m_ColNumber] == null)
				{
					i_drDest[m_strColName] = System.DBNull.Value;
				}
				else
				{
					i_drDest[m_strColName] = m_fg[i_Row, m_ColNumber];
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " - tuanqt");
			}
		}
		
	}
	
	public class CTransferYNData : ITransferDataCell
	{
		C1FlexGrid m_fg;
		int m_ColNumber;
		string m_strColName;
		
		public CTransferYNData(C1FlexGrid i_fg, int i_ColNumber, 
			string i_strColName)
		{
			m_fg = i_fg;
			m_ColNumber = i_ColNumber;
			m_strColName = i_strColName;
		}
		
		void ITransferDataCell.Data2Cell(DataRow i_drSource, int i_Row)
		{
			this.imp_Data2Cell(i_drSource, i_Row);
		}
		
		public void imp_Data2Cell(DataRow i_drSource, int i_Row)
		{
			try
			{
				if (!i_drSource.IsNull(m_strColName))
				{
					m_fg[i_Row, m_ColNumber] = CUtil.YN2Boolean(System.Convert.ToString(i_drSource[m_strColName]));
				}
				else
				{
					m_fg[i_Row, m_ColNumber] = null;
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " hoac col trong grid khong phai boolean - tuanqt");
			}
		}
		
		void ITransferDataCell.Cell2Data(int i_Row, DataRow i_drDest)
		{
			this.imp_Cell2Data(i_Row, i_drDest);
		}
		
		public void imp_Cell2Data(int i_Row, DataRow i_drDest)
		{
			try
			{
				if (m_fg[i_Row, m_ColNumber] == null)
				{
					i_drDest[m_strColName] = System.DBNull.Value;
				}
				else
				{
					i_drDest[m_strColName] = CUtil.Boolean2YN(System.Convert.ToBoolean(m_fg[i_Row, m_ColNumber]));
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " hoac col trong grid khong phai boolean - tuanqt");
			}
		}
	}
	
	public class CTransferDateData : ITransferDataCell
	{
		C1FlexGrid m_fg;
		int m_ColNumber;
		string m_strColName;
		
		public CTransferDateData(C1FlexGrid i_fg, int i_ColNumber, 
			string i_strColName)
		{
			m_fg = i_fg;
			m_ColNumber = i_ColNumber;
			m_strColName = i_strColName;
		}
		
		void ITransferDataCell.Data2Cell(DataRow i_drSource, int i_Row)
		{
			this.imp_Data2Cell(i_drSource, i_Row);
		}
		
		public void imp_Data2Cell(DataRow i_drSource, int i_Row)
		{
			try
			{
				if (!i_drSource.IsNull(m_strColName))
				{
					if (m_fg.Cols[m_ColNumber].DataType.ToString() == "System.String")
					{
						m_fg[i_Row, m_ColNumber] = Strings.Format(i_drSource[m_strColName], CDateTime.GetDateFormatString());
					}
					else
					{
						m_fg[i_Row, m_ColNumber] = i_drSource[m_strColName];
					}
				}
				else
				{
					m_fg[i_Row, m_ColNumber] = null;
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " hoac col trong grid khong phai date - tuanqt");
			}
		}
		
		public void Cell2Data(int i_Row, DataRow i_drDest)
		{
			try
			{
				if (m_fg[i_Row, m_ColNumber] == null)
				{
					i_drDest[m_strColName] = System.DBNull.Value;
				}
				else
				{
					if (m_fg.Cols[m_ColNumber].DataType.ToString() == "System.String")
					{
						i_drDest[m_strColName] = CDateTime.Str2Date(System.Convert.ToString(m_fg[i_Row, m_ColNumber]));
					}
					else
					{
						i_drDest[m_strColName] = m_fg[i_Row, m_ColNumber];
					}
					
				}
			}
			catch (Exception)
			{
				Debug.Assert(false, "Sai kieu cua datarow roi vi khong co col " + m_strColName + " hoac col trong grid khong phai date - tuanqt");
			}
		}
		
	}
	
	public class CTransferFactory
	{
		public ITransferDataCell CreateTransferObject(C1FlexGrid i_fg, int i_Col, DataRow 
			i_drDataRow, string i_strColName)
		{
			Debug.Assert(!(i_fg.Cols[i_Col].DataType == null), "Chua gan kieu cho cot cua grid - tuanqt");
			if ((string) (i_fg.Cols[i_Col].DataType.ToString()) == "System.Boolean")
			{
				return new CTransferYNData(i_fg, i_Col, i_strColName);
			}
			else
			{
				if (i_drDataRow.Table.Columns[i_strColName].DataType == typeof(DateTime))
				{
					return new CTransferDateData(i_fg, i_Col, i_strColName);
				}
				else
				{
					return new CTransferObjectData(i_fg, i_Col, i_strColName);
				}
			}
		}
		
	}
}
