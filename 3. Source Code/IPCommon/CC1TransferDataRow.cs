// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using C1.Win.C1FlexGrid;

namespace IP.Core.IPCommon
{
	public class CC1TransferDataRow : ITransferDataRow
	{
		private C1FlexGrid m_fg;
		private Hashtable m_htbColMapping;
		private ArrayList m_arrCol;
		private DataRow m_dr;
		
		public CC1TransferDataRow(C1FlexGrid i_fg, Hashtable i_htbColMapping, DataRow i_drPrototype)
		{
			m_fg = i_fg;
			m_htbColMapping = i_htbColMapping;
			m_dr = i_drPrototype;
			BuildArrCol();
		}
		private void BuildArrCol()
		{
			m_arrCol = new ArrayList();
			object v_obj = null;
			string v_strColName = "";
			int v_iColNumber = 0;
			ITransferDataCell v_oTransData;
			CTransferFactory v_oCreate = new CTransferFactory();
			
			foreach (object tempLoopVar_v_obj in m_htbColMapping.Keys)
			{
				v_obj = tempLoopVar_v_obj;
				v_strColName = System.Convert.ToString(v_obj);
				v_iColNumber = System.Convert.ToInt32(m_htbColMapping[v_strColName]);
				m_arrCol.Add(v_oCreate.CreateTransferObject(m_fg, 
					v_iColNumber, m_dr, v_strColName));
			}
		}
		
		public void GridRow2DataRow(int i_Row, DataRow i_drDest)
		{
			object v_obj = null;
			ITransferDataCell v_CellTrans = default(ITransferDataCell);
			foreach (object tempLoopVar_v_obj in m_arrCol)
			{
				v_obj = tempLoopVar_v_obj;
				v_CellTrans = (ITransferDataCell) v_obj;
				v_CellTrans.Cell2Data(i_Row, i_drDest);
			}
		}
		
		public void DataRow2GridRow(DataRow i_drSource, int i_Row)
		{
			object v_obj = null;
			ITransferDataCell v_CellTrans = default(ITransferDataCell);
			foreach (object tempLoopVar_v_obj in m_arrCol)
			{
				v_obj = tempLoopVar_v_obj;
				v_CellTrans = (ITransferDataCell) v_obj;
				v_CellTrans.Data2Cell(i_drSource, i_Row);
			}
		}
		
		public Hashtable getHastableMapping()
		{
			return m_htbColMapping;
		}
	}
}
