<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f604_dm_quyet_dinh.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.f604_dm_quyet_dinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style>
 	label {
    		display: table-cell;
    	}
	 .HeaderStyle {
            background: #ddd;
            border-color: #000;
        }
    </style>
	<script>
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {
				$("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            }
		}
		$(document).ready(function () {
			$("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
	</script>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" cellspacing="0" cellpadding="2" style="width: 950px ;margin:auto" class="cssTable table" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_title" runat="server" Text="Cập nhật thông tin quyết định" CssClass="cssPageTitle"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
							ValidationGroup="m_vlg_nha" />
						<asp:Label ID="m_lbl_error" runat="server" CssClass="cssManField" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="text-align: right; width: 30%">
						<span>Loại quyết định</span>
					</td>
					<td id="td_radio" style="width: 70%">
						<asp:RadioButton ID="m_rdb_giao_ke_hoach" runat="server" CssClass=" radio-inline"   Text="Giao kế hoạch" GroupName="loai" Checked="true" AutoPostBack="true" OnCheckedChanged="m_rdb_giao_ke_hoach_CheckedChanged" />
						<asp:RadioButton ID="m_rdb_giao_von" runat="server" CssClass=" radio-inline"   Text="Giao vốn" GroupName="loai" AutoPostBack="true" OnCheckedChanged="m_rdb_giao_von_CheckedChanged" />
					</td>
				</tr>
				<tr>
					<td style="text-align: right">
						<asp:Label ID="m_lbl_loai_quyet_dinh_giao" runat="server" Text="Loại"></asp:Label></td>
					<td>
						<asp:RadioButton ID="m_rdb_loai_quyet_dinh_giao_dau_nam" cssclass="radio-inline" runat="server" Text="Đầu năm" GroupName="loai_quyet_dinh_giao" Checked="true" />
						<asp:RadioButton ID="m_rdb_loai_quyet_dinh_giao_bo_sung" runat="server" cssclass="radio-inline" Text="Bổ sung" GroupName="loai_quyet_dinh_giao" />
						<asp:RadioButton ID="m_rdb_loai_quyet_dinh_giao_dieu_chinh" runat="server" cssclass="radio-inline" Text="Điều chỉnh" GroupName="loai_quyet_dinh_giao" />
					</td>
				</tr>
				<tr>
					<td style="text-align: right">
						<span>Số quyết định</span>
					</td>
					<td>
						<asp:TextBox ID="m_txt_so_quyet_dinh" runat="server" Width="50%" CssClass="cssTextBox form-control" placeholder="Nhập số quyết định"></asp:TextBox></td>
				</tr>
				<tr>

					<td align="right">
						<span>Nội dung</span>
					</td>
					<td>
						<asp:TextBox ID="m_txt_noi_dung" runat="server" Width="50%" CssClass="cssTextBox form-control" placehoder="Nhập nội dung quyết định"></asp:TextBox></td>
				</tr>
				<tr>
					<td align="right">
						<span>Ngày tháng</span>
					</td>
					<td>
						<div id="datetimepicker1" class="input-group date datepicker" style="width: 210px;">
							<asp:TextBox ID="m_txt_ngay_thang" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px"></asp:TextBox>
							<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
					</td>
				</tr>
				<tr>
					<td></td>
					<td>
						<asp:Button ID="m_cmd_insert" Text="Thêm quyết định" runat="server" CssClass="btn btn-success btn-sm" OnClick="m_cmd_insert_Click" />
						<asp:Button ID="m_cmd_update" Text="Cập nhật" runat="server" CssClass="btn btn-success btn-sm" OnClick="m_cmd_update_Click" />
						<asp:Button ID="m_cmd_cancel" Text="Xoá trắng" runat="server" CssClass="btn btn-sm btn-default" OnClick="m_cmd_cancel_Click" />
						<asp:HiddenField ID="m_hdf_form_mode" runat="server" />
						<asp:HiddenField ID="m_hdf_id_quyet_dinh" runat="server" />
					</td>
				</tr>
			</table>
			
			<table cellspacing="0" cellpadding="2" style="width: 950px ;margin:auto" class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_grid_title" runat="server" Text="Danh sách quyết định" CssClass="cssPageTitle"></asp:Label>
						
					</td>
				</tr>
				
				<tr>
					<td colspan="4" align="center">
						<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
							CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
							AllowSorting="True" PageSize="30" ShowHeader="true"
							EmptyDataText="Không có dữ liệu phù hợp"
							OnRowCommand="m_grv_RowCommand" HeaderStyle-CssClass="HeaderStyle">
							<%--<AlternatingRowStyle BackColor="White" />
							<EditRowStyle BackColor="#7C6F57" />
							<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
							<PagerSettings Position="TopAndBottom" />
							<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
							<RowStyle BackColor="#E3EAEB" />--%>
							<SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
								ForeColor="#333333"></SelectedRowStyle>
							<Columns>

								<asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="3%" HeaderStyle-Height="70px">
									<ItemTemplate>
										<asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
											CommandName="Xoa" ToolTip="Xóa" OnClientClick='<%#get_delete_client_script(Eval("so_don_vi").ToString()) %>'>
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
													
										</asp:LinkButton>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="3%">
									<ItemTemplate>
										<asp:LinkButton ID="m_lbl_update" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
											CommandName="Sua" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
													
										</asp:LinkButton>
									</ItemTemplate>
									<ItemStyle HorizontalAlign="Center"></ItemStyle>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center"  HeaderStyle-Width="3%">
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:BoundField DataField="so_quyet_dinh" HeaderText="Số quyết định" />
								<asp:BoundField DataField="noi_dung" HeaderText="Nội dung" />
								<%--<asp:BoundField DataField="loai" HeaderText="Loại" />--%>
								<asp:BoundField DataField="ngay_thang" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày tháng"  ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
								<asp:BoundField DataField="so_don_vi" HeaderText="Số đơn vị đã nhập dữ liệu" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Center"  HeaderStyle-HorizontalAlign="Center" />
							</Columns>
						</asp:GridView>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
			<%--<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />--%>
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


