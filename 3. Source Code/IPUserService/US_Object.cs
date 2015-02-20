// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPBusinessService;



namespace IP.Core.IPUserService
{
	public class US_Object
	{
		protected DataSet pm_objDS; 
		protected DataRow pm_objDR;
		protected string pm_strTableName;
		protected BS_Object pm_objBS = new BS_Object();
		
		//Điền dữ liệu vào DataSet theo chuỗi điều kiện tương ứng
		//Chú ý: chuỗi điều kiện i_strDieuKien phải bắt đầu bằng từ WHERE
		public virtual void FillDataset(DataSet i_objDS, 
			string i_strDieuKien)
		{
			pm_objBS.FillDataset(i_objDS, pm_strTableName, i_strDieuKien);
		}
		
		//Điền dữ liệu vào DataSet không có điều kiện
		public virtual void FillDataset(DataSet i_objDS)
		{
			pm_objBS.FillDataset(i_objDS, pm_strTableName, "");
		}
		
		//Điền dữ liệu vào DataSet theo một sqlcommand tương ứng
		public virtual void FillDatasetByCommand(DataSet i_objDS, 
			System.Data.SqlClient.SqlCommand i_selectCmd)
		{
			pm_objBS.FillDatasetByCommand(i_objDS, i_selectCmd);
		}
		
		public virtual void Update()
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			DataRow v_DRTemp = default(DataRow);
			pm_objDS.EnforceConstraints = false;
			v_DRTemp = getRowClone(pm_objDR);
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			pm_objBS.Update(pm_objDS, pm_strTableName);
		}
		public virtual void Update_CoGhiLog(decimal i_dc_nguoi_dung_id, string i_str_ten_tham_so)
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			DataRow v_DRTemp = default(DataRow);
			pm_objDS.EnforceConstraints = false;
			v_DRTemp = getRowClone(pm_objDR);
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			pm_objBS.Update_GhiLog(pm_objDS, pm_strTableName, i_dc_nguoi_dung_id, i_str_ten_tham_so);
		}
		
		public virtual void Insert()
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			//Them vao dataset
			//Dim v_ipcommonObj As New BS_Object
			DataRow v_DRTemp = default(DataRow);
			//Me.pm_objDR.Item("ID") = v_ipcommonObj.getObjectID()
			v_DRTemp = getRowClone(pm_objDR);
			pm_objDS.EnforceConstraints = false;
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
				//pm_objDS.Tables(pm_strTableName).Rows.Clear()
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			this.pm_objDR["ID"] = pm_objBS.Insert(pm_objDS, pm_strTableName);
		}
		public virtual void Insert_CoGhiLog(decimal i_dc_nguoi_dung_id, string i_str_ten_tham_so)
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			//Them vao dataset
			//Dim v_ipcommonObj As New BS_Object
			DataRow v_DRTemp = default(DataRow);
			//Me.pm_objDR.Item("ID") = v_ipcommonObj.getObjectID()
			v_DRTemp = getRowClone(pm_objDR);
			pm_objDS.EnforceConstraints = false;
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
				//pm_objDS.Tables(pm_strTableName).Rows.Clear()
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			this.pm_objDR["ID"] = pm_objBS.Insert_GhiLog(pm_objDS, pm_strTableName, i_dc_nguoi_dung_id, i_str_ten_tham_so);
		}
		public virtual void Insert(ref decimal op_dc_id, decimal i_dc_nguoi_dung, string i_str_ten_tham_so)
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			//Them vao dataset
			//Dim v_ipcommonObj As New BS_Object
			DataRow v_DRTemp = default(DataRow);
			//Me.pm_objDR.Item("ID") = v_ipcommonObj.getObjectID()
			v_DRTemp = getRowClone(pm_objDR);
			pm_objDS.EnforceConstraints = false;
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
				//pm_objDS.Tables(pm_strTableName).Rows.Clear()
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			this.pm_objDR["ID"] = pm_objBS.Insert_GhiLog(pm_objDS, pm_strTableName, i_dc_nguoi_dung, i_str_ten_tham_so);
			op_dc_id = CIPConvert.ToDecimal(this.pm_objDR["ID"]);
		}
		
		public virtual void Delete()
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			DataRow v_DRTemp = default(DataRow);
			pm_objDS.EnforceConstraints = false;
			v_DRTemp = getRowClone(pm_objDR);
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
			}
			
			pm_objDS.Tables[pm_strTableName].Rows.InsertAt(v_DRTemp, 0);
			pm_objBS.Delete(pm_objDS, pm_strTableName);
		}
		
		public virtual void DeleteByID(decimal i_dcID)
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			pm_objBS.DeleteByID(pm_objDS, pm_strTableName, i_dcID);
		}
		public virtual void DeleteByID_CoGhiLog(decimal i_dcID, decimal i_dc_nguoi_dung_id, string i_str_ten_tham_so)
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			pm_objBS.DeleteByID_GhiLog(pm_objDS, pm_strTableName, i_dcID, i_dc_nguoi_dung_id, i_str_ten_tham_so);
		}
		
		public virtual void Me2DataRow(DataRow i_objDR)
		{
			int v_i = 0;
			for (v_i = 0; v_i <= pm_objDR.Table.Columns.Count - 1; v_i++)
			{
				i_objDR[getColName(v_i)] = pm_objDR[getColName(v_i)];
			}
		}
		
		public virtual void DataRow2Me(DataRow i_objDR)
		{
			int v_i = 0;
			for (v_i = 0; v_i <= pm_objDR.Table.Columns.Count - 1; v_i++)
			{
				pm_objDR[getColName(v_i)] = i_objDR[getColName(v_i)];
			}
		}
		
		public virtual bool isUpdatable()
		{
			//Tên bảng phải khác rỗng nếu không thì chết luôn
			if (pm_strTableName == null || pm_strTableName.Length == 0)
			{
				Debug.Assert(false);
			}
			DataRow v_DRTemp = default(DataRow);
			
			v_DRTemp = getRowClone(pm_objDR);
			if (pm_objDS.Tables[pm_strTableName].Rows.Count >= 1)
			{
				pm_objDS.Tables[pm_strTableName].Rows.RemoveAt(0);
			}
			pm_objDS.Tables[pm_strTableName].Rows.Add(v_DRTemp);
			return pm_objBS.isUpdatable(pm_objDS, pm_strTableName);
		}
		
		public virtual void PrepareUpdate()
		{
			bool v_b_is_updatable = isUpdatable();
		}
		
		public virtual System.Data.SqlClient.SqlTransaction BeginTransaction()
		{
			return pm_objBS.BeginTransaction();
		}
		
		public virtual void CommitTransaction()
		{
			pm_objBS.CommitTransaction();
		}
		
		public virtual void Rollback()
		{
			pm_objBS.Rollback();
		}
		
		protected internal virtual void ExecCommand(System.Data.SqlClient.SqlCommand i_cmd)
		{
			pm_objBS.ExecCommand(i_cmd);
		}
		
		public virtual System.Data.SqlClient.SqlTransaction GetTransaction()
		{
			return pm_objBS.getTransaction();
		}
		
		public virtual void SetTransaction(System.Data.SqlClient.SqlTransaction i_Trans)
		{
			pm_objBS.setTransaction(i_Trans);
		}
		
		public virtual void UseTransOfUSObject(US_Object i_usObject)
		{
			pm_objBS.setTransaction(i_usObject.GetTransaction());
		}
		
		public void setSavePoint(string i_str_save_point_name)
		{
			Debug.Assert(pm_objBS.HaveTransaction, "Chi duoc dat SavePoint khi US_Object co transaction - tuanqt");
			pm_objBS.setSavePoint(i_str_save_point_name);
		}
		
		public void rollbackToSavePoint(string i_str_save_point_name)
		{
			Debug.Assert(pm_objBS.HaveTransaction, "Chi duoc dat SavePoint khi US_Object co transaction - tuanqt");
			pm_objBS.rollbackToSavePoint(i_str_save_point_name);
		}
		
		public virtual bool is_having_transaction()
		{
			return pm_objBS.HaveTransaction;
		}
		
		public virtual void CopyData2USObject(US_Object i_usObject)
		{
			Debug.Assert(!(i_usObject == null), "phai khoi tao doi tuong truoc khi copy data vao no - tuanqt");
			try
			{
				i_usObject.DataRow2Me(pm_objDR);
			}
			catch
			{
				Debug.Assert(false, "Copy vao doi tuong us khac kieu roi - tuanqt");
			}
		}
		
		public virtual void ClearAllFields()
		{
			int v_i = 0;
			for (v_i = 0; v_i <= pm_objDS.Tables[pm_strTableName].Columns.Count - 1; v_i++)
			{
				pm_objDR[getColName(v_i)] = Convert.DBNull;
			}
		}
		
		protected DataRow getRowClone(DataRow i_objDR)
		{
			DataRow v_Row = pm_objDS.Tables[pm_strTableName].NewRow();
			int v_i = 0;
			for (v_i = 0; v_i <= pm_objDS.Tables[pm_strTableName].Columns.Count - 1; v_i++)
			{
				v_Row[getColName(v_i)] = i_objDR[getColName(v_i)];
			}
			return v_Row;
		}
		
		protected string getColName(int i_Index)
		{
			return pm_objDS.Tables[pm_strTableName].Columns[i_Index].ColumnName;
		}
	}
	
}
