// VBConversions Note: VB project level imports
using System.Collections;
using System;
using System.Diagnostics;
using Microsoft.VisualBasic;
using System.Data;
// End of VB project level imports

using System.Runtime.Serialization;
using System.Xml;

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version: 1.1.4322.573
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------




namespace IP.Core.IPCommon
{
	[Serializable(), 
	System.ComponentModel.DesignerCategoryAttribute("code"), 
	System.Diagnostics.DebuggerStepThrough(), 
	System.ComponentModel.ToolboxItem(true)]public class DatasetMsg : DataSet
	{
		
		private MessageDataTable tableMessage;
		
		public DatasetMsg()
		{
			this.InitClass();
			System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
			this.Tables.CollectionChanged += schemaChangedHandler;
			this.Relations.CollectionChanged += schemaChangedHandler;
		}
		
		protected DatasetMsg(SerializationInfo info, StreamingContext context)
		{
			string strSchema = System.Convert.ToString(info.GetValue("XmlSchema", typeof(System.String)));
			if (!((strSchema) == null))
			{
				DataSet ds = new DataSet();
				ds.ReadXmlSchema(new XmlTextReader(new System.IO.StringReader(strSchema)));
				if (!((ds.Tables["Message"]) == null))
				{
					this.Tables.Add(new MessageDataTable(ds.Tables["Message"]));
				}
				this.DataSetName = ds.DataSetName;
				this.Prefix = ds.Prefix;
				this.Namespace = ds.Namespace;
				this.Locale = ds.Locale;
				this.CaseSensitive = ds.CaseSensitive;
				this.EnforceConstraints = ds.EnforceConstraints;
				this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
				this.InitVars();
			}
			else
			{
				this.InitClass();
			}
			this.GetSerializationData(info, context);
			System.ComponentModel.CollectionChangeEventHandler schemaChangedHandler = new System.ComponentModel.CollectionChangeEventHandler(this.SchemaChanged);
			this.Tables.CollectionChanged += schemaChangedHandler;
			this.Relations.CollectionChanged += schemaChangedHandler;
		}
		
[System.ComponentModel.Browsable(false), 
System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)]public MessageDataTable Message
		{
			get
			{
				return this.tableMessage;
			}
		}
		
		public override DataSet Clone()
		{
			DatasetMsg cln = (DatasetMsg) (base.Clone());
			cln.InitVars();
			return cln;
		}
		
		protected override bool ShouldSerializeTables()
		{
			return false;
		}
		
		protected override bool ShouldSerializeRelations()
		{
			return false;
		}
		
		protected override void ReadXmlSerializable(XmlReader reader)
		{
			this.Reset();
			DataSet ds = new DataSet();
			ds.ReadXml(reader);
			if (!((ds.Tables["Message"]) == null))
			{
				this.Tables.Add(new MessageDataTable(ds.Tables["Message"]));
			}
			this.DataSetName = ds.DataSetName;
			this.Prefix = ds.Prefix;
			this.Namespace = ds.Namespace;
			this.Locale = ds.Locale;
			this.CaseSensitive = ds.CaseSensitive;
			this.EnforceConstraints = ds.EnforceConstraints;
			this.Merge(ds, false, System.Data.MissingSchemaAction.Add);
			this.InitVars();
		}
		
		protected override System.Xml.Schema.XmlSchema GetSchemaSerializable()
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream();
			this.WriteXmlSchema(new XmlTextWriter(stream, null));
			stream.Position = 0;
			return System.Xml.Schema.XmlSchema.Read(new XmlTextReader(stream), null);
		}
		
		internal void InitVars()
		{
			this.tableMessage = (MessageDataTable) (this.Tables["Message"]);
			if (!((this.tableMessage) == null))
			{
				this.tableMessage.InitVars();
			}
		}
		
		private void InitClass()
		{
			this.DataSetName = "DatasetMsg";
			this.Prefix = "";
			this.Namespace = "http://tempuri.org/DatasetMsg.xsd";
			this.Locale = new System.Globalization.CultureInfo("en-US");
			this.CaseSensitive = false;
			this.EnforceConstraints = true;
			this.tableMessage = new MessageDataTable();
			this.Tables.Add(this.tableMessage);
		}
		
		private bool ShouldSerializeMessage()
		{
			return false;
		}
		
		private void SchemaChanged(object sender, System.ComponentModel.CollectionChangeEventArgs e)
		{
			if (e.Action == System.ComponentModel.CollectionChangeAction.Remove)
			{
				this.InitVars();
			}
		}
		
		public delegate void MessageRowChangeEventHandler(object sender, MessageRowChangeEvent e);
		
		[System.Diagnostics.DebuggerStepThrough()]public class MessageDataTable : DataTable, System.Collections.IEnumerable
		{
			
			private DataColumn columnMessage;
			
			private DataColumn columnID;
			
			internal MessageDataTable() : base("Message")
			{
				this.InitClass();
			}
			
			internal MessageDataTable(DataTable table) : base(table.TableName)
			{
				if (table.CaseSensitive != table.DataSet.CaseSensitive)
				{
					this.CaseSensitive = table.CaseSensitive;
				}
				if (table.Locale.ToString() != table.DataSet.Locale.ToString())
				{
					this.Locale = table.Locale;
				}
				if (table.Namespace != table.DataSet.Namespace)
				{
					this.Namespace = table.Namespace;
				}
				this.Prefix = table.Prefix;
				this.MinimumCapacity = table.MinimumCapacity;
				this.DisplayExpression = table.DisplayExpression;
			}
			
[System.ComponentModel.Browsable(false)]public int Count
			{
				get
				{
					return this.Rows.Count;
				}
			}
			
internal DataColumn MessageColumn
			{
				get
				{
					return this.columnMessage;
				}
			}
			
internal DataColumn IDColumn
			{
				get
				{
					return this.columnID;
				}
			}
			
public MessageRow this[int index]
			{
				get
				{
					return ((MessageRow) (this.Rows[index]));
				}
			}
			
			private MessageRowChangeEventHandler MessageRowChangedEvent;
			public event MessageRowChangeEventHandler MessageRowChanged
			{
				add
				{
					MessageRowChangedEvent = (MessageRowChangeEventHandler) System.Delegate.Combine(MessageRowChangedEvent, value);
				}
				remove
				{
					MessageRowChangedEvent = (MessageRowChangeEventHandler) System.Delegate.Remove(MessageRowChangedEvent, value);
				}
			}
			
			
			private MessageRowChangeEventHandler MessageRowChangingEvent;
			public event MessageRowChangeEventHandler MessageRowChanging
			{
				add
				{
					MessageRowChangingEvent = (MessageRowChangeEventHandler) System.Delegate.Combine(MessageRowChangingEvent, value);
				}
				remove
				{
					MessageRowChangingEvent = (MessageRowChangeEventHandler) System.Delegate.Remove(MessageRowChangingEvent, value);
				}
			}
			
			
			private MessageRowChangeEventHandler MessageRowDeletedEvent;
			public event MessageRowChangeEventHandler MessageRowDeleted
			{
				add
				{
					MessageRowDeletedEvent = (MessageRowChangeEventHandler) System.Delegate.Combine(MessageRowDeletedEvent, value);
				}
				remove
				{
					MessageRowDeletedEvent = (MessageRowChangeEventHandler) System.Delegate.Remove(MessageRowDeletedEvent, value);
				}
			}
			
			
			private MessageRowChangeEventHandler MessageRowDeletingEvent;
			public event MessageRowChangeEventHandler MessageRowDeleting
			{
				add
				{
					MessageRowDeletingEvent = (MessageRowChangeEventHandler) System.Delegate.Combine(MessageRowDeletingEvent, value);
				}
				remove
				{
					MessageRowDeletingEvent = (MessageRowChangeEventHandler) System.Delegate.Remove(MessageRowDeletingEvent, value);
				}
			}
			
			
			public void AddMessageRow(MessageRow row)
			{
				this.Rows.Add(row);
			}
			
			public MessageRow AddMessageRow(string Message, long ID)
			{
				MessageRow rowMessageRow = (MessageRow) (this.NewRow());
				rowMessageRow.ItemArray = new object[] {Message, ID};
				this.Rows.Add(rowMessageRow);
				return rowMessageRow;
			}
			
			public System.Collections.IEnumerator GetEnumerator()
			{
				return this.Rows.GetEnumerator();
			}
			
			public override DataTable Clone()
			{
				MessageDataTable cln = (MessageDataTable) (base.Clone());
				cln.InitVars();
				return cln;
			}
			
			protected override DataTable CreateInstance()
			{
				return new MessageDataTable();
			}
			
			internal void InitVars()
			{
				this.columnMessage = this.Columns["Message"];
				this.columnID = this.Columns["ID"];
			}
			
			private void InitClass()
			{
				this.columnMessage = new DataColumn("Message", typeof(System.String), null, System.Data.MappingType.Element);
				this.Columns.Add(this.columnMessage);
				this.columnID = new DataColumn("ID", typeof(System.Int64), null, System.Data.MappingType.Element);
				this.Columns.Add(this.columnID);
				this.columnMessage.AllowDBNull = false;
				this.columnID.AllowDBNull = false;
			}
			
			public MessageRow NewMessageRow()
			{
				return ((MessageRow) (this.NewRow()));
			}
			
			protected override DataRow NewRowFromBuilder(DataRowBuilder builder)
			{
				return new MessageRow(builder);
			}
			
			protected override System.Type GetRowType()
			{
				return typeof(MessageRow);
			}
			
			protected override void OnRowChanged(DataRowChangeEventArgs e)
			{
				base.OnRowChanged(e);
				if (!((this.MessageRowChangedEvent) == null))
				{
					if (MessageRowChangedEvent != null)
						MessageRowChangedEvent(this, new MessageRowChangeEvent(((MessageRow) e.Row), e.Action));
				}
			}
			
			protected override void OnRowChanging(DataRowChangeEventArgs e)
			{
				base.OnRowChanging(e);
				if (!((this.MessageRowChangingEvent) == null))
				{
					if (MessageRowChangingEvent != null)
						MessageRowChangingEvent(this, new MessageRowChangeEvent(((MessageRow) e.Row), e.Action));
				}
			}
			
			protected override void OnRowDeleted(DataRowChangeEventArgs e)
			{
				base.OnRowDeleted(e);
				if (!((this.MessageRowDeletedEvent) == null))
				{
					if (MessageRowDeletedEvent != null)
						MessageRowDeletedEvent(this, new MessageRowChangeEvent(((MessageRow) e.Row), e.Action));
				}
			}
			
			protected override void OnRowDeleting(DataRowChangeEventArgs e)
			{
				base.OnRowDeleting(e);
				if (!((this.MessageRowDeletingEvent) == null))
				{
					if (MessageRowDeletingEvent != null)
						MessageRowDeletingEvent(this, new MessageRowChangeEvent(((MessageRow) e.Row), e.Action));
				}
			}
			
			public void RemoveMessageRow(MessageRow row)
			{
				this.Rows.Remove(row);
			}
		}
		
		[System.Diagnostics.DebuggerStepThrough()]public class MessageRow : DataRow
		{
			
			private MessageDataTable tableMessage;
			
			internal MessageRow(DataRowBuilder rb) : base(rb)
			{
				this.tableMessage = (MessageDataTable) this.Table;
			}
			
public string Message
			{
				get
				{
					return System.Convert.ToString(this[this.tableMessage.MessageColumn]);
				}
				set
				{
					this[this.tableMessage.MessageColumn] = value;
				}
			}
			
public long ID
			{
				get
				{
					return ((long) (this[this.tableMessage.IDColumn]));
				}
				set
				{
					this[this.tableMessage.IDColumn] = value;
				}
			}
		}
		
		[System.Diagnostics.DebuggerStepThrough()]public class MessageRowChangeEvent : EventArgs
		{
			
			private MessageRow eventRow;
			
			private DataRowAction eventAction;
			
			public MessageRowChangeEvent(MessageRow row, DataRowAction action)
			{
				this.eventRow = row;
				this.eventAction = action;
			}
			
public MessageRow Row
			{
				get
				{
					return this.eventRow;
				}
			}
			
public DataRowAction Action
			{
				get
				{
					return this.eventAction;
				}
			}
		}
	}
	
}