<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F603_bao_cao_giao_ke_hoach.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F603_bao_cao_giao_ke_hoach" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
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
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất file excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_xuat_excel_Click" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
							CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
							AllowSorting="True" PageSize="60"
							EmptyDataText="Không có dữ liệu phù hợp" EnableModelValidation="True">
							
							<Columns>

								<asp:BoundField DataField="SO_QUYET_DINH" HeaderText="Số QĐ" HeaderStyle-Width="20%" >
<HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundField>
								<asp:BoundField DataField="TEN_DU_AN_CONG_TRINH" HeaderText="Tên dự án/quốc lộ" HeaderStyle-Width="20%" >
<HeaderStyle Width="20%"></HeaderStyle>
                                </asp:BoundField>
								<asp:BoundField DataField="SO_TIEN" HeaderText="Tổng tiền" HeaderStyle-Width="20%" DataFormatString="{0:N0}" >
							
<HeaderStyle Width="20%"></HeaderStyle>
                                <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
								<asp:BoundField DataField="TEN" HeaderText="Loại" HeaderStyle-Width="20%" >
								<HeaderStyle Width="20%" />
                                </asp:BoundField>
							
							</Columns>
						</asp:GridView>
					</td>
				</tr>
			</table>
</asp:Content>
