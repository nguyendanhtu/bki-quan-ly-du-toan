<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F620_bao_cao_giao_von.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F620_bao_cao_giao_von" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<table style="width: 99%;" class="cssTable" border="0">
		<tr>
			<td class="cssPageTitleBG" colspan="4">
				<asp:Label ID="m_lbl_title" runat="server" Text="Báo cáo tình hình giải ngân" CssClass="cssPageTitle"></asp:Label>
			</td>
		</tr>
		<tr>
			<td colspan="4">
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
			</td>
		</tr>
		<tr>
			<td style="width: 15%" align="right">
				<span class="cssManField">Từ ngày</span>
			</td>
			<td style="width: 35%">
				<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="60%"></asp:TextBox>
			</td>
			<td style="width: 15%" align="right">
				<span class="cssManField">Đến ngày</span>
			</td>
			<td style="width: 35%">
				<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="60%"></asp:TextBox>

			</td>
		</tr>
		<tr>
			<td></td>
			<td>
				<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
				<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
			</td>
		</tr>
	</table>
</asp:Content>
