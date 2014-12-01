<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F601_bao_cao_tinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F601_bao_cao_tinh_hinh_giai_ngan" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssGrid tr td {
			padding:0px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
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
				<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
			</td>
		</tr>
		<tr>
			<td colspan="4" align="center">
				<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="false"
					CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
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
						
						<asp:BoundField DataField="NOI_DUNG" HeaderText="Nội dung" HeaderStyle-Width="20%" />
						<asp:TemplateField ItemStyle-HorizontalAlign="Right">
							<HeaderTemplate>
								<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
									<tr>
										<td colspan="3" style="border-bottom:1px gray solid">Kế hoạch (dự toán) được chi cả năm</td>
									</tr>
									<tr>
										<td style="width: 30%;border-right:1px solid gray">Từ quỹ bảo trì</td>
										<td style="width: 30%;border-right:1px solid gray">Từ Ngân sách</td>
										<td style="width: 40%">Tổng số</td>
									</tr>
								</table>
							</HeaderTemplate>
							<ItemTemplate>
								<table cellspacing="0" cellpadding="2" style="width: 100%;"  border="0">
									<tr>
										<td style="width: 30%;height:40px;border-right:1px solid gray" class="cssGridCellTable" align="right"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT).ToString()) %></td>
										<td style="width: 30%;height:40px;border-right:1px solid gray" class="cssGridCellTable" align="right"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS).ToString()) %></td>
										<td style="width: 40%;height:40px;border-right:1px solid gray"  align="right"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG).ToString()) %></td>
									</tr>
								</table>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField ItemStyle-HorizontalAlign="Right">
							<HeaderTemplate>
								<table cellspacing="0" cellpadding="" style="width: 100%;" border="0">
									<tr>
										<td colspan="4" style="border-bottom:1px gray solid">Kinh phí đã nhận</td>
									</tr>
									<tr>
										<td style="width: 50%; border-bottom:1px solid gray;border-right:1px solid gray" colspan="2" >Từ quỹ bảo trì</td>
										<td style="width: 50%; border-bottom:1px solid gray" colspan="2">Từ Ngân sách</td>
									</tr>
									<tr>
										<td style="width: 25%;border-right:1px solid gray">Trong tháng</td>
										<td style="width: 25%;border-right:1px solid gray;border-right:1px solid gray">Luỹ kế từ đầu năm</td>
										<td style="width: 25%;border-right:1px solid gray">Trong tháng</td>
										<td style="width: 25%">Luỹ kế từ đầu năm</td>
									</tr>
								</table>
							</HeaderTemplate>
							<ItemTemplate>
								<table cellspacing="0" cellpadding="" style="width: 100%;"border="0">
									<tr>
										<td style="width: 25%;height:40px;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE).ToString()) %></td>
									</tr>
								</table>
							</ItemTemplate>
						</asp:TemplateField>
						<asp:TemplateField ItemStyle-HorizontalAlign="Right">
							<HeaderTemplate>
								<table cellspacing="0" cellpadding="" style="width: 100%;" border="0">
									<tr>
										<td colspan="4" style="border-bottom:1px gray solid">Kinh phí đã thanh toán, giải ngân</td>
									</tr>
									<tr>
										<td style="width: 50%; border-bottom:1px solid gray;border-right:1px solid gray" colspan="2" >Quỹ bảo trì</td>
										<td style="width: 50%; border-bottom:1px solid gray" colspan="2">Ngân sách</td>
									</tr>
									<tr>
										<td style="width: 25%;border-right:1px solid gray">Trong tháng</td>
										<td style="width: 25%;border-right:1px solid gray;border-right:1px solid gray">Luỹ kế từ đầu năm</td>
										<td style="width: 25%;border-right:1px solid gray">Trong tháng</td>
										<td style="width: 25%">Luỹ kế từ đầu năm</td>
									</tr>
								</table>
							</HeaderTemplate>
							<ItemTemplate>
								<table cellspacing="0" cellpadding="" style="width: 100%;"border="0">
									<tr>
										<td style="width: 25%;height:40px;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG).ToString()) %></td>
										<td style="width: 25%;height:100%;border-right:1px solid gray" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE).ToString()) %></td>
									</tr>
								</table>
							</ItemTemplate>
						</asp:TemplateField>
					</Columns>
				</asp:GridView>
			</td>
		</tr>
	</table>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
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


