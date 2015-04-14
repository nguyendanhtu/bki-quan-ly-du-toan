<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F700_thong_tin_don_vi.aspx.cs" Inherits="QuanLyDuToan.DuToan.F700_thong_tin_don_vi" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table id="main_table" class="table" style="width:500px; margin: auto">
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
			<td><asp:TextBox ID="m_txt_dia_chi" cssclass="form-control" runat="server" Width="400px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Kho bạc: </td>
			<td><asp:TextBox ID="m_txt_kho_bac" cssclass="form-control" runat="server" Width="400px"></asp:TextBox></td>
		</tr>
		<tr>
			<td>Mã TKKT Quỹ BT: </td>
			<td>
				<asp:TextBox ID="m_txt_ma_tkkt_quy_bao_tri" placeholder="Mã TKKT Quỹ bảo trì 1" cssclass="form-control" runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_quy_bao_tri_2" placeholder="Mã TKKT Quỹ bảo trì 2" cssclass="form-control" runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_quy_bao_tri_3" placeholder="Mã TKKT Quỹ bảo trì 3" cssclass="form-control" runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_quy_bao_tri_4" placeholder="Mã TKKT Quỹ bảo trì 4" cssclass="form-control" runat="server" Width="150px"></asp:TextBox>

			</td>
		</tr>
		<tr>
			<td>Mã TKKT Nguồn NS: </td>
			<td>
				<asp:TextBox ID="m_txt_ma_tkkt_nguon_ns" placeholder="Mã TKKT Ngân sách 1" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_nguon_ns_2" placeholder="Mã TKKT Ngân sách 2" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_nguon_ns_3" placeholder="Mã TKKT Ngân sách 3" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_tkkt_nguon_ns_4" placeholder="Mã TKKT Ngân sách 4" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
			</td>
		</tr>
		<tr>
			<td>Mã ĐVQHNS: </td>
			<td><asp:TextBox ID="m_txt_ma_dvqhns"  placeholder="Mã ĐVQHNS 1" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_dvqhns_1"  placeholder="Mã ĐVQHNS 2" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
				<asp:TextBox ID="m_txt_ma_dvqhns_2"  placeholder="Mã ĐVQHNS 3" cssclass="form-control"  runat="server" Width="150px"></asp:TextBox>
			</td>
		</tr>
		
		<tr>
			<td></td>
			<td colspan="1" style="text-align:left">
				<asp:Button ID="m_cmd_save" cssclass="btn btn-sm btn-success"  runat="server" Text="Lưu dữ liệu" OnClick="m_cmd_save_Click" />
			</td>
		</tr>
	</table>
</asp:Content>
