<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F003_DanhMucChuongLoaiKhoanMucTieuMuc.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F003_DanhMucChuongLoaiKhoanMucTieuMuc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">
	<table>
		<tr>
			<td class="col-sm-2">Ban muon nhap?</td>
			<td class="col-sm-5">
				<asp:RadioButton ID="m_rdb_chuong" Text="Chuong" runat="server" GroupName="clkm" />
				<asp:RadioButton ID="m_rdb_loai" Text="Loai" runat="server" GroupName="clkm" />
				<asp:RadioButton ID="m_rdb_khoan" Text="Khoan" runat="server" GroupName="clkm" />
				<asp:RadioButton ID="m_rdb_muc" Text="Muc" runat="server" GroupName="clkm" />
				<asp:RadioButton ID="m_rdb_tieu_muc" Text="Tieu muc" runat="server" GroupName="clkm" />
			</td>
			<td class="col-sm-5"></td>
		</tr>
		<tr>
			<td id="lblParent"></td>
			<td>
				<input type="text" id="txtParent" /></td>
			<td id="lblParentContent"></td>
		</tr>
		<tr>
			<td id="Child"></td>
			<td>
				<input type="text" id="txtChild" /></td>
			<td>
				<input type="text" id="txtChildContent" /></td>
		</tr>
	</table>
	<asp:DropDownList ID="m_ddl_loai_chuong_loai_khoan_muc" runat="server"></asp:DropDownList>
	<asp:GridView ID="m_grv" runat="server"></asp:GridView>
</asp:Content>
