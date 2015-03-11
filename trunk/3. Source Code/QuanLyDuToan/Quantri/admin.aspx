<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="admin.aspx.cs" Inherits="QuanLyDuToan.Quantri.admin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery.dataTables.js")%>'></script>
	<script type="text/javascript" src='<%=ResolveClientUrl("~/Scripts/jquery.dataTables.sorting.js")%>'></script>
	<script type="text/javascript">
		$(function () {
			$("#m_grv").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
		});
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {
				$('#m_grv').dataTable({

					"sPaginationType": "full_numbers",
					"iDisplayLength": 200,
					"bServerSide": false,
					"bProcessing": true,
					"bSort": false,
					"bAutoWidth": false,
					"bInfo": true,
					"sDom": 'T<"clear"><"top"fip>rt<"bottom"ip>',
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
			}
		}
		$(document).ready(function () {
			//$('#m_grv').dataTable({

			//	"sPaginationType": "full_numbers",
			//	"iDisplayLength": 200,
			//	"bServerSide": false,
			//	"bProcessing": true,
			//	"bSort": false,
			//	"bAutoWidth": false,
			//	"bInfo": true,
			//	"sDom": 'T<"clear"><"top"fip>rt<"bottom"ip>',
			//	"bFilter": true,
			//	"bLengthChange": true,
			//	"oLanguage": {
			//		"sSearch": "Tìm kiếm: ",
			//		"sEmptyTable": "Không có dữ liệu phù hợp!",
			//		"sInfo": "Có _TOTAL_ bản ghi (Trang hiện tại: từ _START_ đến _END_)",
			//		"sInfoFiltered": " - Có tất cả _MAX_ bản ghi",
			//		"oPaginate": {
			//			"sPrevious": "Trang trước",
			//			"sNext": "Trang tiếp",
			//			"sFirst": "Trang đầu",
			//			"sLast": "Trang cuối"
			//		},
			//		"sProcessing": "Đang tải dữ liệu!"
			//	}
			//});
		})
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div width="100%">
		<div>
			<div>
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
			</div>
		</div>
		<div>
			<div>
				<asp:RadioButton ID="m_rdb_excute" runat="server" Text="Excute" GroupName="pr" Checked="true" />
				<asp:RadioButton ID="m_rdb_tim_proc" runat="server" Text="Tìm procedure" GroupName="pr" />
				<asp:RadioButton ID="m_rdb_tim_view" runat="server" Text="Tìm view" GroupName="pr" />
				<asp:TextBox ID="m_txt_convert_encoding" runat="server" PlaceHolder="Convert Encoding to text"></asp:TextBox>
				<asp:Button ID="m_cmd_convert" runat="server" CssClass="cssGoogleButton" Text="Convert" OnClick="m_cmd_convert_Click" />
			</div>
		</div>
		<div>
			<div class=".col-sm-6">
				<asp:TextBox ID="m_txt_command" runat="server" TextMode="MultiLine" Width="80%" Height="120px"></asp:TextBox>
			</div>
			<div  class=".col-sm-6">
				<asp:Button ID="m_cmd_excute" runat="server" OnClick="m_cmd_excute_Click" Text="Excute" Height="120px" Width="80px" />
			</div>
		</div>
		<div>
			<asp:GridView ID="m_grv" ClientIDMode="Static" runat="server" AutoGenerateColumns="true" PagerStyle-HorizontalAlign="Center"
				CssClass="GridViewStyle" CellPadding="8">
				<PagerSettings Position="TopAndBottom" />
				<AlternatingRowStyle BackColor="White" />
				<FooterStyle CssClass="GridViewFooterStyle" />
				<RowStyle CssClass="GridViewRowStyle" />
				<SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
				<PagerStyle CssClass="GridViewPagerStyle" />
				<AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
				<HeaderStyle CssClass="GridViewHeaderStyle" />
			</asp:GridView>
			<div></div>
		</div>
	</div>
</asp:Content>
