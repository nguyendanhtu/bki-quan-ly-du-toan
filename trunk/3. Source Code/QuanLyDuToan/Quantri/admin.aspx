<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="QuanLyDuToan.Quantri.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="../Styles/jquery.dataTables.min.css" rel="stylesheet" />
	<script src="../Scripts/jquery.fixedheadertable.min.js"></script>
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery.dataTables.js")%>'></script>
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery.dataTables.sorting.js")%>'></script>
	<script type="text/javascript">
		$(document).ready(function () {
			var table = $('#m_grv').dataTable({

				"sPaginationType": "full_numbers",
				"iDisplayLength": 15,
				"bServerSide": false,
				"bProcessing": true,
				"bSort": false,
				"bAutoWidth": false,
				"bInfo": true,
				"sDom": 'T<"clear"><"top"fip>rt<"bottom">',
				"bFilter": true,
				"bLengthChange": true,
				"oLanguage": {
					"sSearch": "Tìm kiếm: ",
					"sEmptyTable": "Không có dữ liệu phù hợp!",
					"sInfo": "Có _TOTAL_ bản ghi (Trang hiện tại: từ _START_ đến _END_)",
					"sInfoFiltered": " - Có tất cả _MAX_ bản ghi",
					"oPaginate": {
						"sPrevious": "Trang trước",
						"sNext": "Trang tiếp",
						"sFirst": "Trang đầu",
						"sLast": "Trang cuối"
					},
					"sProcessing": "Đang tải dữ liệu!"
				}
			});
			new $.fn.dataTable.FixedHeader(table);
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div style="width: 100%">
		<div>
			<div>
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
			</div>
		</div>
		<div>
			<div style="display: inline">
				<asp:RadioButton ID="m_rdb_excute" runat="server" Text="Excute" GroupName="pr" Checked="true" />
				<asp:RadioButton ID="m_rdb_tim_proc" runat="server" Text="Tìm procedure" GroupName="pr" />
				<asp:RadioButton ID="m_rdb_tim_view" runat="server" Text="Tìm view" GroupName="pr" />
				<asp:TextBox ID="m_txt_convert_encoding" runat="server" PlaceHolder="Convert Encoding to text"></asp:TextBox>
				<asp:Button ID="m_cmd_convert" runat="server" CssClass="cssGoogleButton" Text="Convert" OnClick="m_cmd_convert_Click" />
			</div>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-6">
				<asp:TextBox ID="m_txt_command" runat="server" TextMode="MultiLine" Width="95%" Height="120px"></asp:TextBox>
			</div>
			<div class="col-sm-6">
				<div class="col-sm-2">
					<asp:Button ID="m_cmd_excute" runat="server" OnClick="m_cmd_excute_Click" Text="Excute" Height="120px" CssClass="btn btn-success btn-sm" Width="80px" />
				</div>
				<div class="col-sm-10">
					<asp:TextBox ID="m_txt_lst_command" runat="server" TextMode="MultiLine" Width="100%" Height="120px"></asp:TextBox>
				</div>


			</div>
		</div>
		<div>
			<%if (m_ds.Tables.Count > 0)%>
			<%{%>
			<table id="m_grv" class="table table-hover" style="border: 1px solid black">
				<thead>
					<tr style="height: 60px">
						<%foreach (System.Data.DataColumn col in m_ds.Tables[0].Columns)%>
						<%{%>
						<th style="border: 1px solid black"><%=col.ColumnName %></th>
						<%}%>
					</tr>
				</thead>
				<tbody>
					<%foreach (System.Data.DataRow dr in m_ds.Tables[0].Rows)%>
					<%{%>
					<tr>
						<%foreach (System.Data.DataColumn col in m_ds.Tables[0].Columns)%>
						<%{%>
						<td style="border-right: 1px solid #ddd"><%=dr[col.ColumnName] %></td>
						<%}%>
					</tr>
					<%}%>
				</tbody>
				<tfoot></tfoot>
			</table>
			<%} %>


			<div></div>
		</div>
	</div>
</asp:Content>
