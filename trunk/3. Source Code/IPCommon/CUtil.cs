// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Windows.Forms;

//Nhiệm vụ của ... file
//Định nghĩa các interface, datatype, ... dùng chung
//


namespace IP.Core.IPCommon
{
	public interface I_IPDataMaintainForm
	{
		// Interface mà data maintain form sẽ phải thực hiện
		// Thì mới có thể gọi được từ form Select
		void displayDataMaintain(object i_constraintObject);
	}
	
	public enum SelectAction_byUser
	{
		Canceled_by_User = 12,
		Submited_by_User = 56
	}
	
	
	public enum DataType
	{
		NumberType = 0,
		StringType = 1,
		DateType = 2
	}
	
	public class CUtil
	{
		//Hàm kiểm tra ô Textbox có hợp lệ hay không
		public static bool IsValidTextbox(TextBox i_txtCtrl, DataType i_DataType, bool i_AllowNull)
		{
			
			//Kiem tra dieu kien rong
			if (i_txtCtrl.Text == "")
			{
				if (!i_AllowNull)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			
			//Trong truong hop khac rong
			string v_strText = "";
			v_strText = i_txtCtrl.Text;
			switch (i_DataType)
			{
				case DataType.NumberType:
					return IsValidNumber(v_strText, false);
				case DataType.DateType:
					return CDateTime.isValidDateString(v_strText, CDateTime.GetDateFormatString());
				case DataType.StringType:
					return true;
			}
			return default(bool);
		}
		
		//Hàm kiểm tra xâu đưa vào có phải là số
		public static bool IsValidNumber(string i_strNumber, bool i_AllowNull = false)
		{
			if (i_strNumber == null || i_strNumber == "")
			{
				if (!i_AllowNull)
				{
					return false;
				}
				else
				{
					return true;
				}
			}
			
			//Trong truong hop xau khac rong
			try
			{
				double v_Number;
				v_Number = double.Parse(i_strNumber);
				//Khong co exception => so hop le
				return true;
			}
			catch (Exception)
			{
				//co exception => so khong hop le
				return false;
			}
		}
		
		//Hàm chuyển từ xâu ra số, Nếu là chuỗi rỗng thì trả về giá trị mặc định
		public static decimal Str2Number(string i_strNumber, decimal i_DefaultValue = 0)
		{
			if (i_strNumber == null || i_strNumber == "")
			{
				return i_DefaultValue;
			}
			else
			{
				return System.Convert.ToDecimal(i_strNumber);
			}
		}
		
		//Chuyển từ Boolean sang Y_N
		public static string Boolean2YN(bool i_bBoolean)
		{
			if (i_bBoolean)
			{
				return "Y";
			}
			else
			{
				return "N";
			}
		}
		//Chuyển từ Y_N sang Boolean
		public static bool YN2Boolean(string i_strYN)
		{
			if (i_strYN.ToUpper() == "Y")
			{
				return true;
			}
			else
			{
				if (i_strYN == "N")
				{
					return false;
				}
				else
				{
					Debug.Assert(false);
					//Nếu chương trình bị dừng ở đây
					//thì chuỗi truyền vào là không hợp lệ
				}
			}
			return default(bool);
		}
		
		//Expand or Collapse tree
		public static void ExpandOrCloseTreeView(TreeView i_trvTree)
		{
			//***************************************************************
			//* Đóng mở Node cho Treeview
			//***************************************************************
			TreeNode v_Node = i_trvTree.SelectedNode;
			if (v_Node.IsExpanded)
			{
				v_Node.Collapse();
			}
			else
			{
				v_Node.Expand();
			}
		}
		
		public static object getKeyOfHashtable(Hashtable i_HashTable, decimal i_Value)
		{
			object v_Key = null;
			foreach (object tempLoopVar_v_Key in i_HashTable.Keys)
			{
				v_Key = tempLoopVar_v_Key;
				if (System.Convert.ToDecimal(i_HashTable[v_Key]) == i_Value)
				{
					return v_Key;
				}
			}
			return null;
		}
		
		public static void Swap2RowsOfGrid(C1.Win.C1FlexGrid.C1FlexGrid i_fg, int 
			i_Row1, int i_Row2, int i_STTCol)
		{
			int v_iTempRow = 0;
			decimal v_Temp = new decimal();
			if (i_Row1 == i_Row2)
			{
				return;
			}
			//Phai luon dam bao i_Row1 < i_Row2
			if (i_Row1 > i_Row2)
			{
				//Dao gia tri cho i_row1 va i_row2
				v_iTempRow = i_Row2;
				i_Row2 = i_Row1;
				i_Row1 = v_iTempRow;
			}
			
			//Doi vi tri hai hang
			i_fg.Rows.Move(i_Row1, i_Row2);
			i_fg.Rows.Move(i_Row2 - 1, i_Row1);
			//v_iTempRow = i_fg.Rows.Count
			//i_fg.Rows.Add()
			//i_fg.Rows.Move(i_Row2, i_Row1)
			//i_fg.Rows.Move(i_Row1, i_Row2)
			//i_fg.Rows.Move(v_iTempRow, i_Row1)
			v_Temp = System.Convert.ToDecimal(i_fg[i_Row2, i_STTCol]);
			i_fg[i_Row2, i_STTCol] = System.Convert.ToDecimal(i_fg[i_Row1, i_STTCol]);
			i_fg[i_Row1, i_STTCol] = v_Temp;
			//i_fg.Rows.Count -= 1
		}
		
		public static void BindDatasource2Cbo(ComboBox i_cbo, DataTable i_tbl, string i_strDisplayField, string i_strValueField)
		{
			i_cbo.DataSource = null;
			i_cbo.Items.Clear();
			i_cbo.Text = "";
			i_cbo.DataSource = i_tbl;
			i_cbo.DisplayMember = i_strDisplayField;
			i_cbo.ValueMember = i_strValueField;
		}
	}
	
	public class CSelectedData
	{
		// Class
		public decimal dcID;
		//Public Property dcID() As Decimal
		//    Get
		//        Return m_dcID
		//    End Get
		//    Set(ByVal Value As Decimal)
		//        m_dcID = Value
		//    End Set
		//End Property
		
		public string strMa;
		
		public string strTen;
		
public object this[string name]
		{
			get
			{
				switch (name)
				{
					case "ID":
						return dcID;
					case "TEN":
						return strTen;
				}
				return null;
			}
			set
			{
				switch (name)
				{
					case "ID":
						dcID = System.Convert.ToDecimal(value);
						break;
					case "TEN":
						strTen = System.Convert.ToString(value);
						break;
				}
			}
		}
		
	}
	
	
}
