<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F601_bao_cao_tinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F601_bao_cao_tinh_hinh_giai_ngan" %>

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
			<table style="width: 150%;" class="cssTable" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM <%=DateTime.Now.Year.ToString() %></span>
						<br />
						<span style="font-weight: bold">Từ ngày
							<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
						<span>&nbsp; Đến ngày
							<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>

				<tr>

					<td colspan="4" style="text-align: center">
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="false"
							CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60" ShowHeader="true"
							EmptyDataText="Không có dữ liệu phù hợp">

							<Columns>
								<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
								</asp:TemplateField>

								<asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị" HeaderStyle-Width="20%" />
								<asp:TemplateField ItemStyle-HorizontalAlign="Right">
									<HeaderTemplate>
										<table style="width: 100%;" border="0">
											<tr>
												<td colspan="3" style="border-bottom: 1px #b0b0d9 solid">Kế hoạch (dự toán) được chi cả năm</td>
											</tr>
											<tr>
												<td style="width: 30%; border-right: 1px solid #b0b0d9">Từ quỹ bảo trì</td>
												<td style="width: 30%; border-right: 1px solid #b0b0d9">Từ Ngân sách</td>
												<td style="width: 40%">Tổng số</td>
											</tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
											<tr>
												<td style="width: 30%; height: 40px; border-right: 1px solid #b0b0d9" class="cssGridCellTable" align="right"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT).ToString()) %></td>
												<td style="width: 30%; height: 40px; border-right: 1px solid #b0b0d9" class="cssGridCellTable" align="right"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS).ToString()) %></td>
												<td style="width: 40%; height: 40px;" align="right"><%#format_so_tien(Eval("KH_TONG_SO").ToString()) %></td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right">
									<HeaderTemplate>
										<table cellspacing="0" cellpadding="" style="width: 100%;" border="0">
											<tr>
												<td colspan="4" style="border-bottom: 1px #b0b0d9 solid">Kinh phí đã nhận</td>
											</tr>
											<tr>
												<td style="width: 50%; border-bottom: 1px solid #b0b0d9; border-right: 1px solid #b0b0d9" colspan="2">Từ quỹ bảo trì</td>
												<td style="width: 50%; border-bottom: 1px solid #b0b0d9" colspan="2">Từ Ngân sách</td>
											</tr>
											<tr>
												<td style="width: 25%; border-right: 1px solid #b0b0d9">Trong tháng</td>
												<td style="width: 25%; border-right: 1px solid #b0b0d9; border-right: 1px solid #b0b0d9">Luỹ kế từ đầu năm</td>
												<td style="width: 25%; border-right: 1px solid #b0b0d9">Trong tháng</td>
												<td style="width: 25%">Luỹ kế từ đầu năm</td>
											</tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<table style="width: 100%;" border="0">
											<tr>
												<td style="width: 25%; height: 40px; border-right: 1px solid #b0b0d9" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG).ToString()) %></td>
												<td style="width: 25%; height: 100%; border-right: 1px solid #b0b0d9" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE).ToString()) %></td>
												<td style="width: 25%; height: 100%; border-right: 1px solid #b0b0d9" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG).ToString()) %></td>
												<td style="width: 25%; height: 100%;" align="right" class="cssGridCellTable"><%#format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE).ToString()) %></td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right">
									<HeaderTemplate>
										<table style="width: 100%;" border="0">
											<tr>
												<td colspan="4" style="border-bottom: 1px #b0b0d9 solid">Kinh phí đã thanh toán, giải ngân</td>
											</tr>
											<tr>
												<td style="width: 50%; border-bottom: 1px solid #b0b0d9; border-right: 1px solid #b0b0d9" colspan="2">Quỹ bảo trì</td>
												<td style="width: 50%; border-bottom: 1px solid #b0b0d9" colspan="2">Ngân sách</td>
											</tr>
											<tr>
												<td style="width: 25%; border-right: 1px solid #b0b0d9">Trong tháng</td>
												<td style="width: 25%; border-right: 1px solid #b0b0d9; border-right: 1px solid #b0b0d9">Luỹ kế từ đầu năm</td>
												<td style="width: 25%; border-right: 1px solid #b0b0d9">Trong tháng</td>
												<td style="width: 25%">Luỹ kế từ đầu năm</td>
											</tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<table style="width: 100%;" border="0">
											<tr>
												<td style="width: 25%; height: 40px; border-right: 1px solid #b0b0d9; text-align: right" class="cssGridCellTable"><%#format_so_tien(Eval("TT_QBT_TRONG_THANG").ToString()) %></td>
												<td style="width: 25%; height: 100%; border-right: 1px solid #b0b0d9; text-align: right" class="cssGridCellTable"><%#format_so_tien(Eval("TT_QBT_LUY_KE").ToString()) %></td>
												<td style="width: 25%; height: 100%; border-right: 1px solid #b0b0d9; text-align: right" class="cssGridCellTable"><%#format_so_tien(Eval("TT_NS_TRONG_THANG").ToString()) %></td>
												<td style="width: 25%; height: 100%; text-align: right" class="cssGridCellTable"><%#format_so_tien(Eval("TT_NS_LUY_KE").ToString()) %></td>
											</tr>
										</table>
									</ItemTemplate>
								</asp:TemplateField>

								<asp:TemplateField HeaderText="Kinh phí chưa GN" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate><%#format_so_tien(Eval("KINH_PHI_CGN").ToString()) %></ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right">
									<HeaderTemplate>
										<table style="width: 100%; border-collapse:collapse" border="0">
											<tr>
												<td colspan="2" style="border-bottom: 1px #b0b0d9 solid">Kinh phí còn được nhận</td>
											</tr>
											<tr>
												<td style="width: 50%;  border-right: 1px solid #b0b0d9">Quỹ bảo trì</td>
												<td style="width: 50%; ">Ngân sách</td>
											</tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<table style="width: 100%;" border="0">
											<tr>
												<td style="width: 50%; border-right: 1px solid #b0b0d9;height:40px"><%#format_so_tien(Eval("KINH_PHI_QBT_CON_DUOC_NHAN").ToString()) %></td>
												<td style="width: 50%;height:40px"><%#format_so_tien(Eval("KINH_PHI_NS_CON_DUOC_NHAN").ToString()) %></td>
											</tr>
										</table>
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


