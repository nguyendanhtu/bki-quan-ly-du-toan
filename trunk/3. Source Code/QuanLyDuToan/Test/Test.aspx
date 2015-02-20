<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Test.aspx.cs" Inherits="QuanLyDuToan.Test.Test" %>

<%@ Register Src="~/UC_Message.ascx" TagPrefix="uc1" TagName="UC_Message" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/knockout-3.2.0.js"></script>
	<script src="../Scripts/UI/Test.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<uc1:UC_Message runat="server" id="m_uc_message" />
	<asp:Button ID="m_cmd_mess_click" runat="server" Text="Click me to show mess" OnClick="m_cmd_mess_click_Click" />
	<table  data-bind="visible: HT_NGUOI_SU_DUNGs().length > 0">
		<thead>
			<tr>
				<th>ID</th>
				<th>Tên truy cập</th>
				<th>Tên</th>
				<th>Mật khẩu</th>
			</tr>
		</thead>
		<tbody data-bind="foreach: HT_NGUOI_SU_DUNGs">
			<tr>
				<td><input data-bind="value: ID" /></td>
				<td><input data-bind="value: TEN_TRUY_CAP" /></td>
				<td><input data-bind="value: TEN" /></td>
				<td><input data-bind="value: MAT_KHAU" /></td>
			</tr>
		</tbody>
	</table>
</asp:Content>
