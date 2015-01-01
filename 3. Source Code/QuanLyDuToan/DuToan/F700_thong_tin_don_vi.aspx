<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F700_thong_tin_don_vi.aspx.cs" Inherits="QuanLyDuToan.DuToan.F700_thong_tin_don_vi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table style="width:500px; margin: auto">
		<tr>
			<td colspan="2">
				<p style="font-weight:bold;color:blue">Xin vui lòng nhập đầy đủ những thông tin dưới đây. Những thông tin này sẽ được hệ thống sử dụng để phục vụ quá trình Lập Uỷ nhiệm chi.</p>
			</td>
		</tr>
		<tr>
			<td colspan="2"><asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label></td>
		</tr>
		<tr>
			<td>Địa chỉ: </td>
			<td><asp:TextBox ID="m_txt_dia_chi" runat="server" Width="400px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Kho bạc: </td>
			<td><asp:TextBox ID="m_txt_kho_bac" runat="server" Width="400px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Mã TKKT Quỹ BT: </td>
			<td><asp:TextBox ID="m_txt_ma_tkkt_quy_bao_tri" runat="server" Width="150px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Mã TKKT Nguồn NS: </td>
			<td><asp:TextBox ID="m_txt_ma_tkkt_nguon_ns" runat="server" Width="150px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Mã ĐVQHNS: </td>
			<td><asp:TextBox ID="m_txt_ma_dvqhns" runat="server" Width="150px"></asp:TextBox></td>
		</tr>
		<tr>
			<td colspan="2" style="text-align:center">
				<asp:Button ID="m_cmd_save" runat="server" Text="Lưu dữ liệu" OnClick="m_cmd_save_Click" />
			</td>
		</tr>
	</table>
</asp:Content>
