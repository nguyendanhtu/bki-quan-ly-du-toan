<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F811_QuanLyChucNang.aspx.cs" Inherits="QuanLyDuToan.Quantri.F811_QuanLyChucNang" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<script>
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {
				$(".cssDorpdownlist").select2();
			}
		}
		$(document).ready(function () {
			$(".cssDorpdownlist").select2();
		});
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<table id="main_table" cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable table" border="0">
		<tr>
			<td class="cssPageTitleBG" colspan="3">
				<asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle"
					Text="Quản lý các chức năng của hệ thống" />
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
				<asp:Label ID="lbl_content" CssClass="cssManField" runat="server"
					Text="Tên chức năng" />
			</td>
			<td style="width: 30%;">
				<asp:TextBox ID="m_txt_ten_chuc_nang" CssClass="cssTable form-control" CausesValidation="false"
					runat="server" Width="320px" />
				&nbsp;
                <asp:RequiredFieldValidator ID="m_ct_noi_dung" runat="server"
					ControlToValidate="m_txt_ten_chuc_nang" ErrorMessage="Bạn phải nhập tên chức năng" Text="*" />
			</td>
			<td style="width: 5%;">&nbsp;</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lbl_loai_hop_dong" CssClass="cssManField" runat="server"
					Text="URL của chức năng" AccessKey="L" />
			</td>
			<td align="left">
				<asp:TextBox ID="m_txt_url_form" CssClass="form-control" Width="320px" runat="server">
				</asp:TextBox>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lbl_ma_don_vi_tinh" CssClass="cssManField" runat="server"
					Text="Chức năng cha" />
			</td>
			<td align="left">
				<asp:DropDownList ID="m_cbo_chuc_nang_cha" runat="server" Width="320px"
					OnSelectedIndexChanged="m_cbo_chuc_nang_cha_SelectedIndexChanged" CssClass="cssDorpdownlist form-control" AutoPostBack="true">
				</asp:DropDownList>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lbl_ma_don_vi_tinh0" CssClass="cssManField" runat="server"
					Text="Vị trí" />
			</td>
			<td align="left">
				<asp:TextBox ID="m_txt_vi_tri" runat="server" Width="20%" CssClass="form-control">
				</asp:TextBox>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lbl_ma_tan_xuat1" CssClass="cssManField" runat="server"
					Text="Được sử dụng YN?" />
			</td>
			<td align="left">
				<asp:RadioButtonList ID="m_rdl_su_dung_yn" runat="server"
					RepeatDirection="Horizontal" Width="117px">
					<asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
					<asp:ListItem Value="N">Không</asp:ListItem>
				</asp:RadioButtonList>
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td style="text-align: right;">
				<asp:Label ID="lbl_ma_tan_xuat0" CssClass="cssManField" runat="server"
					Text="Được hiển thị YN?" />
			</td>
			<td colspan="2" style="text-align: left">
            <asp:RadioButtonList ID="m_rdl_hien_thi_yn" runat="server"
				RepeatDirection="Horizontal" Width="117px">
				<asp:ListItem Value="Y" Selected="True">Có</asp:ListItem>
				<asp:ListItem Value="N">Không</asp:ListItem>
			</asp:RadioButtonList>
			</td>
		</tr>

		<tr>
			<td></td>
			<td colspan="2" align="left">
				<asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="btn btn-sm btn-success"
					runat="server" Text="Tạo mới(c)"
					OnClick="m_cmd_tao_moi_Click" />&nbsp;
			<asp:Button ID="m_cmd_cap_nhat" AccessKey="u"
				runat="server" CssClass="btn btn-sm btn-success" Text="Cập nhật(u)"
				OnClick="m_cmd_cap_nhat_Click" />&nbsp;
			<asp:Button ID="m_cmd_cancel" AccessKey="r" CssClass="btn btn-sm btn-default" runat="server"
				Text="Xóa trắng(r)" OnClick="m_cmd_cancel_Click" />
				<asp:HiddenField ID="hdf_id" runat="server" Value="" />
			</td>
		</tr>
		<tr>
			<td class="cssPageTitleBG" colspan="3">
				<asp:Label ID="Label11" runat="server" CssClass="cssPageTitle"
					Text="Danh sách các chức năng của hệ thống" />
			</td>
		</tr>
		<tr>
			<td align="left">
				<asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
			</td>
			<td>&nbsp;</td>
		</tr>
		<tr>
			<td align="right">
				<asp:Label ID="lbl_ghi_chu0" CssClass="cssManField" runat="server"
					Text="Chức năng cấp 1" />
			</td>
			<td>
				<asp:DropDownList ID="m_cbo_chuc_nang_cap_1" runat="server" Width="320px"
					AutoPostBack="True" CssClass="cssDorpdownlist"
					OnSelectedIndexChanged="m_cbo_chuc_nang_cap_1_SelectedIndexChanged" />
			</td>
		</tr>
		<tr>
			<td colspan="1" class="cssManField" align="right">
				<span>Từ khoá:</span>
			</td>
			<td>
				<asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="form-control" Style="width: 250px" />
				<asp:Button ID="m_cmd_tim_kiem" runat="Server" CssClass="btn btn-sm btn-primary" CausesValidation="false"
					Text="Tìm kiếm" OnClick="m_cmd_tim_kiem_Click" />
			</td>

		</tr>
		<tr>
			<td align="center" colspan="3" valign="top">&nbsp;
           
        <asp:GridView ID="m_grv_dm_chuc_nang_he_thong" AllowPaging="True"
			PageSize="20"
			runat="server" AutoGenerateColumns="False"
			Width="100%" DataKeyNames="ID"
			CellPadding="4"
			ForeColor="#333333"
			AllowSorting="True"
			CssClass="cssGrid"
			PagerSettings-Position="TopAndBottom"
			OnPageIndexChanging="m_grv_dm_chuc_nang_he_thong_PageIndexChanging"
			OnRowDeleting="m_grv_dm_chuc_nang_he_thong_RowDeleting"
			OnSelectedIndexChanging="m_grv_dm_chuc_nang_he_thong_SelectedIndexChanging">
			<AlternatingRowStyle BackColor="White" />
			<Columns>
				<asp:TemplateField HeaderText="Xóa" HeaderStyle-Height="50px">
					<ItemTemplate>
						<asp:LinkButton ID="lbt_delete" runat="server" CausesValidation="false"
							CommandName="Delete" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
						</asp:LinkButton>
					</ItemTemplate>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Sửa">
					<ItemTemplate>
						<asp:LinkButton ID="lbt_update" runat="server" CausesValidation="false"
							CommandName="Select" ToolTip="Sửa">
                     <img alt="Sửa" src="../Images/Button/edit.png" />
						</asp:LinkButton>
					</ItemTemplate>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
					<ItemTemplate><%# Container.DataItemIndex + 1 %></ItemTemplate>
					<ItemStyle HorizontalAlign="Center"></ItemStyle>
				</asp:TemplateField>
				<asp:BoundField DataField="TEN_CHUC_NANG" HeaderText="Tên chức năng" ItemStyle-HorizontalAlign="Left"></asp:BoundField>
				<asp:TemplateField HeaderText="Tên chức năng cha">
					<ItemTemplate><%# Eval("CHUC_NANG_PARENT_ID")%></ItemTemplate>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:TemplateField>
				<asp:BoundField DataField="URL_FORM" ItemStyle-HorizontalAlign="Left"
					HeaderText="URL của chức năng"></asp:BoundField>
				<asp:BoundField DataField="VI_TRI" HeaderText="Vị trí"
					ItemStyle-HorizontalAlign="Center"></asp:BoundField>
				<asp:TemplateField HeaderText="Được sử dụng YN">
					<ItemTemplate><%# mapping_yn(Eval("TRANG_THAI_YN"))%></ItemTemplate>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:TemplateField>
				<asp:TemplateField HeaderText="Được hiển thị YN">
					<ItemTemplate><%# mapping_yn(Eval("HIEN_THI_YN"))%></ItemTemplate>
					<ItemStyle HorizontalAlign="Left"></ItemStyle>
				</asp:TemplateField>
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


