﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F401_bao_cao_tra_cuu_uy_nhiem_chi.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F401_bao_cao_tra_cuu_uy_nhiem_chi" %>

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
			<table style="width: 100%;" class="cssTable" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH ỦY NHIỆM CHI <%=DateTime.Now.Year.ToString() %></span>
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

								<asp:BoundField DataField="SO_UNC" HeaderText="Số UNC" HeaderStyle-Width="20%" />
                                <asp:BoundField DataField="NGAY_THANG" HeaderText="Ngày" HeaderStyle-Width="300px" />
							    <asp:BoundField DataField="SO_TIEN_QUY_BT" HeaderText="Số tiền Quỹ bảo trì" HeaderStyle-Width="150px" />
                                <asp:BoundField DataField="SO_TIEN_NS" HeaderText="Số tiền Ngân sách" HeaderStyle-Width="150px" />			
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

