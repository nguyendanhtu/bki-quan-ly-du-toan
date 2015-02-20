// VBConversions Note: VB project level imports
using System;
using System.Drawing;
using System.Diagnostics;
using System.Data;
using Microsoft.VisualBasic;
using System.Collections;
using System.Windows.Forms;
// End of VB project level imports

using IP.Core.IPException;
using IP.Core.IPCommon;
using IP.Core.IPData;
using IP.Core.IPUserService;
using IP.Core.IPData.DBNames;



namespace IP.Core.IPSystemAdmin
{
	public class f100_TuDien : System.Windows.Forms.Form, I_IPDataMaintainForm
	{
		
#region  Windows Form Designer generated code
		
		public f100_TuDien()
		{
			
			//This call is required by the Windows Form Designer.
			InitializeComponent();
			
			//Add any initialization after the InitializeComponent() call
			formatControls();
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
		internal System.Windows.Forms.Splitter Splitter1;
		internal System.Windows.Forms.Panel Panel1;
		internal System.Windows.Forms.ComboBox m_cboLoaiTDFilter;
		internal System.Windows.Forms.Label m_lblInfo;
		internal C1.Win.C1FlexGrid.C1FlexGrid m_fg;
		internal System.Windows.Forms.Label m_lblFilter;
		[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(f100_TuDien));
			this.Splitter1 = new System.Windows.Forms.Splitter();
			base.KeyDown += new System.Windows.Forms.KeyEventHandler(f100_TuDien_KeyDown);
			base.Load += new System.EventHandler(f100_TuDien_Load);
			this.Panel1 = new System.Windows.Forms.Panel();
			this.m_lblFilter = new System.Windows.Forms.Label();
			this.m_cboLoaiTDFilter = new System.Windows.Forms.ComboBox();
			this.m_cboLoaiTDFilter.SelectedIndexChanged += new System.EventHandler(this.m_cboLoaiTDFilter_SelectedIndexChanged);
			this.m_lblInfo = new System.Windows.Forms.Label();
			this.m_fg = new C1.Win.C1FlexGrid.C1FlexGrid();
			this.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize) this.m_fg).BeginInit();
			this.SuspendLayout();
			//
			//Splitter1
			//
			this.Splitter1.Location = new System.Drawing.Point(0, 0);
			this.Splitter1.Name = "Splitter1";
			this.Splitter1.Size = new System.Drawing.Size(4, 493);
			this.Splitter1.TabIndex = 9;
			this.Splitter1.TabStop = false;
			//
			//Panel1
			//
			this.Panel1.Controls.Add(this.m_lblFilter);
			this.Panel1.Controls.Add(this.m_cboLoaiTDFilter);
			this.Panel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.Panel1.Location = new System.Drawing.Point(4, 0);
			this.Panel1.Name = "Panel1";
			this.Panel1.Size = new System.Drawing.Size(768, 32);
			this.Panel1.TabIndex = 11;
			//
			//m_lblFilter
			//
			this.m_lblFilter.Location = new System.Drawing.Point(8, 11);
			this.m_lblFilter.Name = "m_lblFilter";
			this.m_lblFilter.Size = new System.Drawing.Size(80, 16);
			this.m_lblFilter.TabIndex = 12;
			this.m_lblFilter.Text = "Lọc theo loại";
			//
			//m_cboLoaiTDFilter
			//
			this.m_cboLoaiTDFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.m_cboLoaiTDFilter.Location = new System.Drawing.Point(104, 8);
			this.m_cboLoaiTDFilter.Name = "m_cboLoaiTDFilter";
			this.m_cboLoaiTDFilter.Size = new System.Drawing.Size(585, 22);
			this.m_cboLoaiTDFilter.TabIndex = 11;
			//
			//m_lblInfo
			//
			this.m_lblInfo.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.m_lblInfo.Location = new System.Drawing.Point(4, 469);
			this.m_lblInfo.Name = "m_lblInfo";
			this.m_lblInfo.Size = new System.Drawing.Size(768, 24);
			this.m_lblInfo.TabIndex = 12;
			this.m_lblInfo.Text = "F3 : thêm ; F4 : sửa; ESC : thoát";
			//
			//m_fg
			//
			this.m_fg.ColumnInfo = resources.GetString("m_fg.ColumnInfo");
			this.m_fg.Dock = System.Windows.Forms.DockStyle.Fill;
			this.m_fg.ExtendLastCol = true;
			this.m_fg.Location = new System.Drawing.Point(4, 32);
			this.m_fg.Name = "m_fg";
			this.m_fg.Size = new System.Drawing.Size(768, 437);
			this.m_fg.Styles = new C1.Win.C1FlexGrid.CellStyleCollection(resources.GetString("m_fg.Styles"));
			this.m_fg.TabIndex = 13;
			//
			//f100_TuDien
			//
			this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
			this.ClientSize = new System.Drawing.Size(772, 493);
			this.Controls.Add(this.m_fg);
			this.Controls.Add(this.m_lblInfo);
			this.Controls.Add(this.Panel1);
			this.Controls.Add(this.Splitter1);
			this.Font = new System.Drawing.Font("Tahoma", (float) (9.0F), System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, System.Convert.ToByte(0));
			this.Name = "f100_TuDien";
			this.Text = "M100 - Từ điển";
			this.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize) this.m_fg).EndInit();
			this.ResumeLayout(false);
			
		}
		
#endregion
		
#region Data structure
		private enum ColNumber
		{
			ID = 1,
			TEN_OUTLINE = 2,
			MA_TU_DIEN = 3,
			TEN = 4
		}
		
		private enum TreeLevel
		{
			LOAI_TU_DIEN = 0,
			GIA_TRI_TU_DIEN = 1
		}
		
		private enum eformMode
		{
			LOAD_TAT_CA_LOAI_TD = 0,
			THEO_LOAI_TD = 1
		}
		private const decimal ALL_SELECTED = -1;
#endregion
		
#region Class Members
		private bool m_LoaiTuDien_CouldBe_Changed = true;
		private string m_MaLoaiTuDien_Fixed;
		private DS_CM_DM_LOAI_TD m_ds_loai_tu_dien;
		private DS_CM_DM_TU_DIEN m_ds_tu_dien;
		private decimal m_dc_id_laoi_td;
		private eformMode m_eformMode = eformMode.LOAD_TAT_CA_LOAI_TD;
		
#endregion
		
		
		
		
#region PRIVATE
		
		// VBConversions Note: Former VB static variables moved to class level because they aren't supported in C#.
		private CListOfDataFromDB getTenLoaiTuDien_v_objTenLoaiHSTable = default(CListOfDataFromDB);
		
		private string getTenLoaiTuDien(decimal i_dcIDLoaiTD)
		{
			// static CListOfDataFromDB v_objTenLoaiHSTable = default(CListOfDataFromDB); VBConversions Note: Static variable moved to class level and renamed getTenLoaiTuDien_v_objTenLoaiHSTable. Local static variables are not supported in C#.
			if (getTenLoaiTuDien_v_objTenLoaiHSTable == null)
			{
				getTenLoaiTuDien_v_objTenLoaiHSTable = new CListOfDataFromDB(this.m_ds_loai_tu_dien, "ID", "TEN_LOAI");
			}
			return Convert.ToString(getTenLoaiTuDien_v_objTenLoaiHSTable[i_dcIDLoaiTD]);
		}
		
		private bool isMaTuDienRow(int i_row)
		{
			return m_fg.Rows[i_row].Node.Level == (int) TreeLevel.GIA_TRI_TU_DIEN;
		}
		
		private void setLevelOfRow(TreeLevel i_level, int i_grid_row_index)
		{
			m_fg.Rows[i_grid_row_index].IsNode = true;
			m_fg.Rows[i_grid_row_index].Node.Level = (int) i_level;
			
		}
		
		
		private void TuDienDataRow_2_GridRow(DataRow i_dr_tu_dien, int i_grid_row_index)
		{
			m_fg[i_grid_row_index, System.Convert.ToInt32(ColNumber.ID)] = CNull.RowNVLDecimal(i_dr_tu_dien, "ID", 0);
			m_fg[i_grid_row_index, System.Convert.ToInt32(ColNumber.MA_TU_DIEN)] = CNull.RowNVLString(i_dr_tu_dien, "MA_TU_DIEN", "");
			m_fg[i_grid_row_index, System.Convert.ToInt32(ColNumber.TEN)] = CNull.RowNVLString(i_dr_tu_dien, "TEN", "");
			m_fg[i_grid_row_index, System.Convert.ToInt32(ColNumber.TEN_OUTLINE)] = CNull.RowNVLString(i_dr_tu_dien, "TEN_NGAN", "");
			m_fg.Rows[i_grid_row_index].UserData = i_dr_tu_dien;
			setLevelOfRow(TreeLevel.GIA_TRI_TU_DIEN, i_grid_row_index);
		}
		
		
		
		private void loadData_fromDB_toDatasets()
		{
			US_CM_DM_TU_DIEN v_us_tu_dien = new US_CM_DM_TU_DIEN();
			try
			{
				v_us_tu_dien.BeginTransaction();
				this.m_ds_tu_dien = new DS_CM_DM_TU_DIEN();
				v_us_tu_dien.FillDataset(m_ds_tu_dien);
				
				US_CM_DM_LOAI_TD v_us_loai_tu_dien = new US_CM_DM_LOAI_TD();
				v_us_loai_tu_dien.UseTransOfUSObject(v_us_tu_dien);
				this.m_ds_loai_tu_dien = new DS_CM_DM_LOAI_TD();
				v_us_loai_tu_dien.FillDataset(m_ds_loai_tu_dien);
				
				v_us_tu_dien.CommitTransaction();
			}
			catch (Exception v_e)
			{
				v_us_tu_dien.Rollback();
				CDBExceptionHandler v_handler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_handler.showErrorMessage();
			}
		}
		
		private void loadCBO_LoaiTD()
		{
			try
			{
				m_cboLoaiTDFilter.SelectedIndexChanged -= m_cboLoaiTDFilter_SelectedIndexChanged;
				ArrayList v_arrlist = new ArrayList();
				DataRow v_dr_all = this.m_ds_loai_tu_dien.CM_DM_LOAI_TD.NewRow();
				if (this.m_LoaiTuDien_CouldBe_Changed)
				{
					//v_arrlist.Add(v_dr_all)
					//v_dr_all("TEN_LOAI") = "Tất cả các loại"
					//v_dr_all("ID") = ALL_SELECTED
					//Dim v_datarow As DataRow
					//For Each v_datarow In Me.m_ds_loai_tu_dien.CM_DM_LOAI_TD
					//    v_arrlist.Add(v_datarow)
					//Next
					
					
					
					/////////////////////////////////Nguoi tao : hiendv
					DataRow v_datarow = this.m_ds_loai_tu_dien.CM_DM_LOAI_TD.NewRow();
					v_arrlist.Add(v_dr_all);
					v_dr_all["TEN_LOAI"] = "Phòng ban Topica";
					v_dr_all["ID"] = 11;
					////////////////////////////////
					
					
					
				}
				else // chỉ được 1 loại duy nhất
				{
					DataView v_dv = new DataView(m_ds_loai_tu_dien.CM_DM_LOAI_TD);
					v_dv.RowFilter = "MA_LOAI = " + "\'" + this.m_MaLoaiTuDien_Fixed + "\'";
					DataRowView v_drv = default(DataRowView);
					foreach (DataRowView tempLoopVar_v_drv in v_dv)
					{
						v_drv = tempLoopVar_v_drv;
						v_arrlist.Add(v_drv.Row);
					}
				}
				m_cboLoaiTDFilter.DataSource = v_arrlist;
				m_cboLoaiTDFilter.ValueMember = "ID";
				m_cboLoaiTDFilter.DisplayMember = "TEN_LOAI";
				
				m_cboLoaiTDFilter.SelectedIndex = 0;
				this.m_cboLoaiTDFilter_SelectedIndexChanged(m_cboLoaiTDFilter, null);
				
			}
			catch (Exception V_E)
			{
				CSystemLog_301.ExceptionHandle(V_E);
			}
			finally
			{
				m_cboLoaiTDFilter.SelectedIndexChanged += m_cboLoaiTDFilter_SelectedIndexChanged;
			}
		}
		
		private void formatControls()
		{
			CControlFormat.setFormStyle(this);
			
			this.KeyPreview = true;
			m_fg.AllowEditing = false;
			CControlFormat.setC1FlexFormat(m_fg);
			m_fg.ExtendLastCol = true;
			CGridUtils.AddSearch_Handlers(m_fg);
			CGridUtils.AddTree_Toogle_Handlers(m_fg);
			m_fg.Tree.Column = (int) ColNumber.TEN_OUTLINE;
			m_fg.Tree.Style = C1.Win.C1FlexGrid.TreeStyleFlags.SimpleLeaf;
			
		}
		
		
#endregion
		
#region PUBLIC INTERFACE
		public void displayDataMaintain(object i_constraintObject)
		{
			try
			{
				if (i_constraintObject == null)
				{
					this.m_LoaiTuDien_CouldBe_Changed = true;
				}
				else
				{
					m_MaLoaiTuDien_Fixed = System.Convert.ToString(i_constraintObject);
					this.m_LoaiTuDien_CouldBe_Changed = false;
				}
				f100_TuDien_Load(this, null);
				this.ShowDialog();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		public void display_by_Loai_TD(decimal i_dc_loai_TD)
		{
			try
			{
				f100_TuDien_Load(this, null);
				m_dc_id_laoi_td = i_dc_loai_TD;
				m_eformMode = eformMode.THEO_LOAI_TD;
				this.ShowDialog();
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		
		private void loadData_fromDatasets_toGrid(decimal i_dcID_loai_TD)
		{
			try
			{
				m_fg.Redraw = false;
				CGridUtils.ClearDataInGrid(m_fg);
				//FILTER LOAI TU DIEN
				string v_strFilterLTD = " 1 = 1 ";
				if (i_dcID_loai_TD != ALL_SELECTED)
				{
					v_strFilterLTD = "ID = " + i_dcID_loai_TD.ToString();
				}
				DataView v_dvLoaiTD = new DataView(this.m_ds_loai_tu_dien.CM_DM_LOAI_TD, 
					v_strFilterLTD, 
					"ID", DataViewRowState.CurrentRows);
				
				int v_iGridRowIndex = 0;
				DataRowView v_drvLTD = default(DataRowView);
				foreach (DataRowView tempLoopVar_v_drvLTD in v_dvLoaiTD)
				{
					v_drvLTD = tempLoopVar_v_drvLTD;
					decimal v_dcIDLoaiTD = CNull.RowNVLDecimal(v_drvLTD.Row, "ID", 0);
					m_fg.Rows.Count++;
					v_iGridRowIndex = m_fg.Rows.Count - 1;
					LoaiTD_2_GridRow(v_dcIDLoaiTD, v_iGridRowIndex);
					
					
					string v_strSort = "ID_LOAI_TU_DIEN, MA_TU_DIEN";
					DataView v_dvTuDien = new DataView(this.m_ds_tu_dien.CM_DM_TU_DIEN, 
						"ID_LOAI_TU_DIEN =" + System.Convert.ToString(v_dcIDLoaiTD), 
						v_strSort, 
						DataViewRowState.CurrentRows);
					DataRowView v_drvTuDien = default(DataRowView);
					foreach (DataRowView tempLoopVar_v_drvTuDien in v_dvTuDien)
					{
						v_drvTuDien = tempLoopVar_v_drvTuDien;
						m_fg.Rows.Count++;
						v_iGridRowIndex = m_fg.Rows.Count - 1;
						this.TuDienDataRow_2_GridRow(v_drvTuDien.Row, v_iGridRowIndex);
					}
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
			finally
			{
				m_fg.Redraw = true;
			}
		}
		
		private void LoaiTD_2_GridRow(decimal i_dcIDLoaiTD, int i_iGridRowIndex)
		{
			m_fg[i_iGridRowIndex, System.Convert.ToInt32(ColNumber.ID)] = i_dcIDLoaiTD;
			m_fg[i_iGridRowIndex, System.Convert.ToInt32(ColNumber.TEN_OUTLINE)] = this.getTenLoaiTuDien(i_dcIDLoaiTD);
			this.setLevelOfRow(TreeLevel.LOAI_TU_DIEN, i_iGridRowIndex);
			C1.Win.C1FlexGrid.CellRange v_cellrange = m_fg.GetCellRange(i_iGridRowIndex, System.Convert.ToInt32(ColNumber.TEN_OUTLINE));
			v_cellrange.Style = m_fg.Styles["BOLDSTYLE"];
		}
		
		private void addNewGiaTriTuDien()
		{
			decimal v_dcIDLoaiTD = new decimal();
			if (this.isMaTuDienRow(m_fg.Row))
			{
				US_CM_DM_TU_DIEN v_usTD = new US_CM_DM_TU_DIEN();
				DataRow v_drTD = (DataRow) (m_fg.Rows[m_fg.Row].UserData);
				v_usTD.DataRow2Me(v_drTD);
				v_dcIDLoaiTD = v_usTD.dcID_LOAI_TU_DIEN;
			}
			else
			{
				v_dcIDLoaiTD = Convert.ToDecimal(m_fg[m_fg.Row, System.Convert.ToInt32(ColNumber.ID)]);
			}
			US_CM_DM_TU_DIEN v_usTuDien = new US_CM_DM_TU_DIEN();
			v_usTuDien.dcID_LOAI_TU_DIEN = v_dcIDLoaiTD;
			f102_TuDien_DE v_CalledForm = new f102_TuDien_DE();
			if (v_CalledForm.InsertObj(v_usTuDien) == DialogResult.OK)
			{
				//add new row to dataset
				DataRow v_drTuDien = this.m_ds_tu_dien.CM_DM_TU_DIEN.NewRow();
				v_usTuDien.Me2DataRow(v_drTuDien);
				this.m_ds_tu_dien.CM_DM_TU_DIEN.Rows.Add(v_drTuDien);
				//add new ro to grid
				int v_iNewGridRowIndex = m_fg.Row + 1;
				m_fg.Rows.Insert(v_iNewGridRowIndex);
				this.TuDienDataRow_2_GridRow(v_drTuDien, v_iNewGridRowIndex);
			}
		}
		
		private void updateGiaTriTuDien()
		{
			if (!this.isMaTuDienRow(m_fg.Row))
			{
				return;
			}
			DataRow v_drTuDien = (DataRow) (m_fg.Rows[m_fg.Row].UserData);
			US_CM_DM_TU_DIEN v_usTuDien = new US_CM_DM_TU_DIEN();
			v_usTuDien.DataRow2Me(v_drTuDien);
			try
			{
				f102_TuDien_DE v_CalledForm = new f102_TuDien_DE();
				
				
				if (v_CalledForm.UpdateObj(v_usTuDien) == DialogResult.OK)
				{
					v_usTuDien.Me2DataRow(v_drTuDien);
					this.TuDienDataRow_2_GridRow(v_drTuDien, m_fg.Row);
				}
				
				
			}
			catch (System.Exception v_e)
			{
				
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		private void xoaGiaTriTuDien()
		{
			if (!this.isMaTuDienRow(m_fg.Row))
			{
				return;
			}
			if (BaseMessages.askUser_DataCouldBeDeleted(8) == BaseMessages.IsDataCouldBeDeleted.ShouldNotBeDeleted)
			{
				return;
			}
			DataRow v_drTuDien = (DataRow) (m_fg.Rows[m_fg.Row].UserData);
			US_CM_DM_TU_DIEN v_usTuDien = new US_CM_DM_TU_DIEN();
			v_usTuDien.DataRow2Me(v_drTuDien);
			try
			{
				v_usTuDien.BeginTransaction();
				//If v_usTuDien.isUpdatable() Then
				v_usTuDien.Delete();
				m_fg.Rows.Remove(m_fg.Row);
				//End If
				v_usTuDien.CommitTransaction();
			}
			catch (System.Exception v_e)
			{
				v_usTuDien.Rollback();
				CDBExceptionHandler v_ErrHandler = new CDBExceptionHandler(v_e, new CDBClientDBExceptionInterpret());
				v_ErrHandler.showErrorMessage();
			}
		}
		
		
#endregion
		//
		// ENVENT HANDLERS
		//
		private void f100_TuDien_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			try
			{
				switch (e.KeyCode)
				{
					case Keys.Escape:
						this.Close();
						break;
					case Keys.F3:
						addNewGiaTriTuDien();
						break;
					case Keys.F4:
						updateGiaTriTuDien();
						break;
				}
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		private void f100_TuDien_Load(object sender, System.EventArgs e)
		{
			try
			{
				this.loadData_fromDB_toDatasets();
				this.loadCBO_LoaiTD();
				CGridUtils.stand_on_TopLeft_Cell(m_fg);
				if (!this.m_LoaiTuDien_CouldBe_Changed)
				{
					this.m_lblFilter.Visible = false;
					m_lblFilter.Top = -100;
					this.m_cboLoaiTDFilter.Visible = false;
					m_cboLoaiTDFilter.Top = -100;
				}
				
				if (m_eformMode == eformMode.THEO_LOAI_TD)
				{
					m_cboLoaiTDFilter.SelectedValue = m_dc_id_laoi_td;
					m_cboLoaiTDFilter.Enabled = false;
				}
				
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
		
		private void m_cboLoaiTDFilter_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			try
			{
				loadData_fromDatasets_toGrid(Convert.ToDecimal(m_cboLoaiTDFilter.SelectedValue));
			}
			catch (Exception v_e)
			{
				CSystemLog_301.ExceptionHandle(v_e);
			}
		}
	}
}
