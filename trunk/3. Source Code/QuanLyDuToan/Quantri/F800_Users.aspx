<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F800_Users.aspx.cs" Inherits="QuanLyDuToan.Quantri.F800_Users" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<script>
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {

				$(".cssDorpdownlist").select2();

			}
		}
		$(document).ready(function () {
			$(".cssDorpdownlist").select2();

		}
		   )
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<table id="main_table" cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable table" border="0">
		<tr>
			<td class="cssPageTitleBG" colspan="3">
				<asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Quản lý người dùng" />
			</td>
		</tr>
		<tr>
			<td colspan="3">
				<asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 15%;">
				<asp:Label ID="Label4" CssClass="cssManField" runat="server" Text="Nhóm người dùng" />
			</td>
			<td style="width: 30%;">
				<asp:DropDownList ID="m_cbo_user_group" runat="server" Width="264px" CssClass="cssDorpdownlist form-control"
					AutoPostBack="true" OnSelectedIndexChanged="m_cbo_loai_tu_dien_SelectedIndexChanged" />
			</td>
			<td style="width: 5%;">
				<asp:CustomValidator ID="m_cvt_loai_tu_dien" runat="server" ControlToValidate="m_cbo_user_group"
					ErrorMessage="Bạn phải chọn Nhóm người dùng" Display="Static" Text="*" />
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 15%;">
				<asp:Label ID="lblFullName0" CssClass="cssManField" runat="server" Text="Họ và tên người dùng(*)" />
			</td>
			<td style="width: 30%;">
				<asp:TextBox ID="m_txt_ho_va_ten" CssClass="cssTextBox form-control" runat="server" MaxLength="25"
					Width="200px" />
			</td>
			<td style="width: 5%;">
				<asp:CustomValidator ID="m_ctv_ma_tu_dien0" runat="server" ControlToValidate="m_txt_ho_va_ten"
					ErrorMessage="Bạn phải nhập Họ và tên người dùng" Display="Static" Text="*" />
			</td>
		</tr>
		<tr>
			<td align="right" style="width: 15%;">
				<asp:Label ID="lblFullName" CssClass="cssManField" runat="server" Text="Tên đăng nhập(*)" />
			</td>
			<td style="width: 30%;">
				<asp:TextBox ID="m_txt_ten_dang_nhap" CssClass="cssTextBox form-control" runat="server" MaxLength="25"
					Width="200px" />
			</td>
			<td style="width: 5%;">
				<asp:CustomValidator ID="m_ctv_ma_tu_dien" runat="server" ControlToValidate="m_txt_ten_dang_nhap"
					ErrorMessage="Bạn phải nhập Tên đăng nhập" Display="Static" Text="*" />
			</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lblAnswer0" runat="server" CssClass="cssManField" Text="Mật khẩu(*)" />
			</td>
			<td align="left">
				<asp:TextBox ID="m_txt_mat_khau" CssClass="form-control" AccessKey="m" runat="server" Width="200px" TextMode="Password" />
			</td>
			<td>
				<asp:CustomValidator ID="m_ctv_ten_tu_ngan" runat="server" ControlToValidate="m_txt_mat_khau"
					ErrorMessage="Mật khẩu không được để trống!" Display="Static" Text="*" />
				<asp:CompareValidator ID="m_ctv_mat_khau" runat="server" ControlToCompare="m_txt_mat_khau"
					ControlToValidate="m_txt_mat_khau_go_lai" ErrorMessage="Mật khẩu và Nhập lại mật khẩu phải giống nhau">*</asp:CompareValidator>
			</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lblAnswer" runat="server" CssClass="cssManField" Text="Nhập lại mật khẩu(*)" />
			</td>
			<td align="left">
				<asp:TextBox ID="m_txt_mat_khau_go_lai" CssClass="form-control" AccessKey="m" runat="server" Width="200px"
					TextMode="Password" />
			</td>
			<td>
				<asp:CustomValidator ID="m_ctv_mk_go_lai" runat="server" ControlToValidate="m_txt_mat_khau_go_lai"
					ErrorMessage="Mật khẩu không được để trống, ít nhất 5 ký tự" Display="Static"
					Text="*" />
			</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="m_lbl_ghi_chu" runat="server" CssClass="cssManField" Text="Tài khoản bị khóa?" />
			</td>
			<td align="left">
				<asp:CheckBox ID="m_chk_lock_yn" runat="server" />
			</td>
		</tr>
		<tr>
			<td></td>
			<td colspan="2" align="left">
				<asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="btn btn-sm btn-success" runat="server"
					Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="btn btn-sm btn-success" runat="server"
					Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="btn btn-sm btn-default" runat="server"
					Text="Xóa trắng(r)" OnClick="btnCancel_Click" />
				<asp:HiddenField ID="m_hdf_id_user_group" runat="server" Visible="False" />
				<asp:HiddenField ID="m_hdf_pw" runat="server" Visible="False" />
			</td>
		</tr>
		<tr>
			<td class="cssPageTitleBG" colspan="3">
				<asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" Text="Danh sách người dùng" />
			</td>
		</tr>
		<tr>
			<td align="left">
				<asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
			</td>
			<td>&nbsp;
			</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="Label5" CssClass="cssManField" runat="server" Text="Nhóm người dùng" />
			</td>
			<td>
				<asp:DropDownList ID="m_cbo_user_group_on_grid" runat="server" Width="264px" CssClass="cssDorpdownlist" AutoPostBack="True"
					OnSelectedIndexChanged="m_cbo_loai_tu_dien_grv_SelectedIndexChanged" />
			</td>
		</tr>
		<tr>
			<td align="center" colspan="3" valign="top">
				<asp:GridView ID="m_grv_dm_tu_dien"
					runat="server"
					AutoGenerateColumns="False"
					Width="80%"
					DataKeyNames="ID"
					OnRowDeleting="m_grv_dm_tu_dien_RowDeleting"
					OnSelectedIndexChanging="m_grv_dm_tu_dien_SelectedIndexChanging"
					CellPadding="4"
					ForeColor="#333333"
					CssClass="cssGrid"
					EmptyDataText="Không có dữ liệu phù hợp!">
					<AlternatingRowStyle BackColor="White" />
					<Columns>
						<asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" HeaderStyle-Height="50px" ItemStyle-HorizontalAlign="Center"
							ButtonType="Image" DeleteImageUrl="../Images/Button/deletered.png" HeaderText="Xóa">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:CommandField>
						<asp:CommandField SelectText="Sửa" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"
							ButtonType="Image" SelectImageUrl="../Images/Button/edit.png" HeaderText="Sửa">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:CommandField>
						<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
							<ItemTemplate>
								<%# Container.DataItemIndex + 1 %>
							</ItemTemplate>
							<HeaderStyle Width="50px" />
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:TemplateField>
						<asp:BoundField DataField="ID_USER_GROUP" HeaderText="Nhóm người dùng" Visible="False">
							<ItemStyle HorizontalAlign="Left" Width="4%"></ItemStyle>
						</asp:BoundField>
						<asp:BoundField DataField="TEN" ItemStyle-HorizontalAlign="Center" HeaderText="Họ và tên người dùng">
							<ItemStyle HorizontalAlign="Left"></ItemStyle>
						</asp:BoundField>
						<asp:BoundField DataField="TEN_TRUY_CAP" HeaderText="Tên đăng nhập" />
						<asp:BoundField DataField="MAT_KHAU" HeaderText="Mật khẩu" Visible="False" />
						<asp:BoundField DataField="TRANG_THAI" ItemStyle-HorizontalAlign="Center" HeaderText="Trạng thái tài khoản (O: Bình thường, 1: Bị khóa)">
							<ItemStyle HorizontalAlign="Center"></ItemStyle>
						</asp:BoundField>

					</Columns>
					<EditRowStyle BackColor="#7C6F57" />
					<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />

					<PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
					<RowStyle BackColor="#E3EAEB" />
					<SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
						ForeColor="#333333"></SelectedRowStyle>
				</asp:GridView>
			</td>
		</tr>
	</table>
</asp:Content>

