<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F256_bao_cao_giao_von_quy_bt_theo_qd.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F256_bao_cao_giao_von_quy_bt_theo_qd" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssGrid tr td {
			padding: 0px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table style="width: 1000px; margin: auto" class="cssTable" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<p>
							<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIAO KẾ HOẠCH <%=DateTime.Now.Year.ToString() %></span>
							<br />
							<br />
							<span style="font-weight: bold">Từ ngày
							<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
							<span style="font-weight: bold">&nbsp; Đến ngày
							<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
						</p>
					</td>
				</tr>


				<tr>

					<td colspan="4" style="text-align: center">
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" />
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4" style="margin: auto;" align="center">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="true"
							UseAccessibleHeader="true" DataKeyNames="ID"
							CssClass="cssGrid" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60" ShowHeader="true" AllowPaging="false"
							EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_OnRowCreated"
							OnRowDataBound="m_grv_RowDataBound"
							HeaderStyle-Height="65px" RowStyle-Height="28px">

							<Columns>
							</Columns>
						</asp:GridView>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
		</Triggers>
	</asp:UpdatePanel>

	<asp:UpdateProgress ID="UpdateProgress1" runat="server">
		<ProgressTemplate>
			<div class="cssLoadWapper">
				<div class="cssLoadContent">
					<img src="../Images/loadingBar.gif" alt="" />
					<p>
						Đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>


