<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F816_ghi_log_qldt.aspx.cs" Inherits="QuanLyDuToan.Quantri.F816_ghi_log_qldt" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<link href="../Styles/jquery.dataTables.min.css" rel="stylesheet" />
	<script src="../Scripts/jquery.dataTables.js"></script>
	<script type="text/javascript">
		$(document).ready(function () {
			$('#m_tbl').dataTable({

				"sPaginationType": "full_numbers",
				"iDisplayLength": 20,
				"bServerSide": false,
				"bProcessing": true,
				"bSort": false,
				"bAutoWidth": false,
				"bInfo": true,
				"sDom": '<"top"f>rt<"bottom"ip>',
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
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table class="table table-hover" id="m_tbl" style="margin:auto">
		<thead>
			<tr>
				<th>User</th>
				<th>Thời gian</th>
				<th>Hành động</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var item in lst_history)%>
			<%{%>
			<tr>
				<td><%var v_ht_nsd = lst_nguoi_su_dung
					.Where(x => x.ID == item.ID_NGUOI_SU_DUNG)
					.FirstOrDefault(); %>
					<%=v_ht_nsd.TEN_TRUY_CAP +" - " +v_ht_nsd.HT_USER_GROUP.USER_GROUP_NAME%></td>
				<td><%=item.THOI_GIAN %></td>
				<td><%=item.HANH_DONG %></td>
			</tr>
			<%}%>
		</tbody>
		<tfoot></tfoot>
	</table>
</asp:Content>
