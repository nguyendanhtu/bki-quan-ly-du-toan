<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F801_bao_cao_giao_von_theo_qd.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F801_bao_cao_giao_von_theo_qd" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssGrid tr td {
			padding: 0px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table cellspacing="0" cellpadding="2" style="width: 900px; margin: auto"
				class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_title" runat="server" Text="Báo cáo Giao vốn theo quyết định" CssClass="cssPageTitle"></asp:Label>
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
					<td colspan="4" style="text-align:center"><span class="cssManField">Số quyết định&nbsp;&nbsp;</span>
						<asp:TextBox ID="m_txt_so_quyet_dinh" runat="server" placeholder="Số quyết định"></asp:TextBox>
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
					<td colspan="4">
						<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="false"
							CssClass="cssGrid" Width="900px" CellPadding="0" ForeColor="#333333"
							AllowSorting="True" PageSize="60" ShowHeader="true"
							EmptyDataText="Không có dữ liệu phù hợp">
							<AlternatingRowStyle BackColor="White" />
							<EditRowStyle BackColor="#7C6F57" />
							<FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
							<HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
							<PagerSettings Position="TopAndBottom" />
							<PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
							<RowStyle BackColor="#E3EAEB" />
							<SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
								ForeColor="#333333"></SelectedRowStyle>
							<Columns>
								<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
								</asp:TemplateField>

								<asp:BoundField DataField="SO_QUYET_DINH" HeaderText="Số QĐ" HeaderStyle-Width="150px" />
								<asp:BoundField DataField="TEN_DU_AN_CONG_TRINH" HeaderText="Tên dự án/quốc lộ" HeaderStyle-Width="300px" />
								<asp:TemplateField HeaderText="Số tiền" HeaderStyle-Width="100px" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_so_tien_grid" runat="server" CssClass="cssManField" ForeColor="Blue"
											Text='<%#format_so_tien( Eval(RPT_BAO_CAO_GIAO_VON_THEO_QD.TONG_TIEN_DACT_THEO_QD).ToString()) %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
							</Columns>
						</asp:GridView>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
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


