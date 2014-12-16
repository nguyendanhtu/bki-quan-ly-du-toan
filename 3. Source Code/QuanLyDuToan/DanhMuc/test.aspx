<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="test.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table style="width:900px;margin:auto">
		<tr>
			<td>Tên đơn vị</td>
			<td><asp:DropDownList ID="m_ddl_ten_don_vi" Width="200px" runat="server"></asp:DropDownList></td>
			<td></td>
			<td></td>
		</tr>
		<tr>
			<td></td>
			<td></td>
			<td></td>
			<td></td>
		</tr>
	</table>
</asp:Content>
