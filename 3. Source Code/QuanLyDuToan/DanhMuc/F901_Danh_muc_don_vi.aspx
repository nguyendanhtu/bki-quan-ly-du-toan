<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F901_Danh_muc_don_vi.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F901_Danh_muc_don_vi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.style1 {
			height: 24px;
		}

		.form-control {
			display: inline-block;
		}
	</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" cellspacing="0" cellpadding="2" style="width: 900px; margin: auto" class="cssTable table" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="6">
						<asp:Label ID="m_lbl_title" runat="server" CssClass="cssManField" ForeColor="White" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
							ValidationGroup="m_vlg_dm_don_vi" />
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
					</td>
				</tr>
				<tr>
					<td align="right" style="width: 25%">
						<span class="cssManField">Mã đơn vị:</span>
					</td>
					<td style="width: 35%">
						<asp:TextBox ID="m_txt_ma_don_vi" CssClass="cssTextBox form-control" runat="server" MaxLength="25"
							placeholder="Nhập mã đơn vị" Width="300px" />
					</td>
					<td style="width: 40%">
						<asp:RequiredFieldValidator runat="Server" ID="m_rfv_ma_don_vi" Text="(*)" ControlToValidate="m_txt_ma_don_vi"
							ErrorMessage="Bạn phải nhập Mã Đơn Vị!" ValidationGroup="m_vlg_dm_don_vi"></asp:RequiredFieldValidator>
					</td>
					<%--<td align="right" style="width: 15%">
                        <span class="cssManField">Loại đơn vị:</span>
                    </td>
                    <td style="width: 34%">
                        <asp:DropDownList ID="m_cbo_loai_don_vi" class="cssDorpdownlist" runat="server" Width="91%" />
                    </td>
                    <td style="width: 1%">
                    </td>--%>
				</tr>
				<tr>
					<td align="right">
						<span class="cssManField">Tên đơn vị:</span>
					</td>
					<td>
						<asp:TextBox ID="m_txt_ten_don_vi" CssClass="cssTextBox form-control" runat="server" MaxLength="50"
							placeholder="Nhập tên đơn vị" Width="300px" />
					</td>
					<td style="width: 1%">
						<asp:RequiredFieldValidator ID="m_rfv_ten_don_vi" runat="Server" ControlToValidate="m_txt_ten_don_vi"
							ValidationGroup="m_vlg_dm_don_vi" ErrorMessage="Bạn phải nhập Tên Đơn Vị!" Text="(*)"></asp:RequiredFieldValidator>
					</td>
					<%--<td align="right">
                        <asp:Label ID="m_lbl_don_vi_cap_tren" class="cssManField" runat="Server" Text="Đơn vị cấp trên"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_don_vi_cap_tren" runat="server" Width="91%" CssClass="cssDorpdownlist"
                            AutoPostBack="true" />
                    </td>
                    <td style="width: 1%">
                    </td>--%>
				</tr>
				<%--<tr>
                    <td align="right">
                        <span class="cssManField">Loại hình đơn vị:</span>
                    </td>
                    <td>
                        <asp:DropDownList ID="m_cbo_loai_hinh_don_vi" runat="server" Width="91%" CssClass="cssDorpdownlist"
                            AutoPostBack="false" />
                    </td>
                </tr>--%>
				<tr>
					<td></td>
					<td style="text-align:left" colspan="3">
						<asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="btn btn-sm btn-success" runat="server"
							Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                        <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="btn btn-sm btn-success" runat="server"
							Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                        <asp:Button ID="m_cmd_xoa_trang" AccessKey="r" CssClass="btn btn-sm" runat="server"
							Text="Xóa trắng(r)" OnClick="m_cmd_xoa_trang_Click" />
					</td>
				</tr>
			</table>
			<table cellspacing="0" cellpadding="2" style="width: 900px; margin: auto; border:1px solid gray" class="table" >
				<tr>
					<td class="cssPageTitleBG" colspan="6">
						<asp:Label ID="m_lbl_thong_tin_don_vi" runat="server" CssClass="cssManField" ForeColor="White" />
					</td>
				</tr>
				<tr>
					<td align="left" colspan="2">
						<asp:Label ID="m_lbl_thong_bao" runat="server" CssClass="cssManField" />
					</td>
					
				</tr>
				<tr>
					<td style="width: 25%"></td>
					<td style="text-align: left;">
						<asp:TextBox ID="m_txt_tim_kiem" runat="server" Width="200px" CssClass="cssTextBox form-control"></asp:TextBox>
						&nbsp;
                        <asp:Button ID="m_cmd_tim_kiem" runat="server" Text="Tìm kiếm" CssClass="btn btn-sm btn-primary"
							CausesValidation="false" OnClick="m_cmd_tim_kiem_Click" />
						<asp:HiddenField ID="m_hdf_id_don_vi" runat="server" Visible="False" />
						<asp:HiddenField ID="m_hdf_form_mode" runat="server" Visible="False" />
					</td>
				</tr>
				<tr>
					<td style="width: 100%" colspan="2">
						<asp:GridView ID="m_grv_dm_don_vi" runat="server" 
							AutoGenerateColumns="False"
							 Width="100%"
							DataKeyNames="ID" 
							AllowPaging="True" 
							PageSize="30" 
							CellPadding="4" 
							ForeColor="#333333"
							CssClass="cssGrid"
							OnRowDeleting="m_grv_dm_don_vi_RowDeleting" OnPageIndexChanging="m_grv_dm_don_vi_PageIndexChanging" 
							HeaderStyle-Height="30px"
							HeaderStyle-BackColor="#ddd"
							HeaderStyle-ForeColor="Black"
							OnRowUpdating="m_grv_dm_don_vi_RowUpdating">
							<PagerSettings Position="TopAndBottom" />
							<AlternatingRowStyle BackColor="White" />
							<Columns>
								<asp:TemplateField HeaderText="Xóa" ItemStyle-Width="4%" >
									<ItemTemplate>
										<asp:LinkButton ID="m_lbt_delete" runat="server" CommandName="Delete" ToolTip="Xóa"
											OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img src="../Images/Button/deletered.png" alt="Delete" />
										</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:CommandField SelectText="Sửa" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center"
									Visible="False">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:CommandField>
								<asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="4%">
									<ItemTemplate>
										<asp:LinkButton ToolTip="Sửa" ID="m_lbt_edit" CommandName="Update" runat="server">

                                <img src="../Images/Button/edit.png" alt="Update" align="middle"/>
                                        

										</asp:LinkButton>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="4%">
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateField>
								<asp:BoundField DataField="MA_DON_VI" ItemStyle-HorizontalAlign="Left" HeaderText="Mã đơn vị">
									<ItemStyle HorizontalAlign="Left" Width="180px" />
								</asp:BoundField>
								<asp:BoundField DataField="TEN_DON_VI" HeaderText="Tên đơn vị"></asp:BoundField>
								<%-- <asp:TemplateField HeaderText="Loại hình đơn vị">
                                    <ItemTemplate>
                                        <%#get_ten_loai_hinh_don_vi(Eval("LOAI_HINH_DON_VI").ToString())%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Đơn vị cấp trên">
                                    <ItemTemplate>
                                        <%#get_ten_don_vi_cap_tren(Eval("ID_DON_VI_CAP_TREN"))%>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
								<asp:CommandField DeleteText="Xóa" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center"
									Visible="False">
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:CommandField>
							</Columns>
							<EditRowStyle BackColor="#7C6F57" />
							<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<%--<HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />--%>
							<PagerStyle CssClass="GridViewPagerStyle" HorizontalAlign="Center" />
							<RowStyle BackColor="#E3EAEB" />
							<SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
								ForeColor="#333333"></SelectedRowStyle>
						</asp:GridView>
					</td>
				</tr>
			</table>
		</ContentTemplate>
	</asp:UpdatePanel>
</asp:Content>

