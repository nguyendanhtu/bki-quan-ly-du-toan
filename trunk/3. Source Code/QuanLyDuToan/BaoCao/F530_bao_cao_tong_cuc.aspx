<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F530_bao_cao_tong_cuc.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F530_bao_cao_tong_cuc" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .cssGrid tr td
        {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server">
	</asp:scriptmanager>

    <asp:updatepanel id="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table style="width: 100%;" class="cssTable" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString() %></span>
					</td>
				</tr>
                <tr>
                    <td style="width: 200px;"></td>
                    <td>
                        <span style="font-weight: bold" >Loại đơn vị
                        <asp:DropDownList id="m_cbo_loai_don_vi" Width="200px" runat="server"></asp:DropDownList></span>
                    </td>
                    <td colspan="2">
						<span style="font-weight: bold">Từ ngày
							<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
						<span>&nbsp; Đến ngày
							<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
					</td>
				</tr>
                <tr>
                    <td></td>
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
								<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
									<HeaderTemplate>
										<table border="1" cellspacing="0" cellpadding="2" height="100%" width="100%" style="border-collapse: collapse;
                                            color: black">
												<tr align="center"><td>STT</td></tr>
												<tr align="center"><td>a</td></tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
									<HeaderTemplate>
										<table border="1" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            color: black" >
												<tr align="center"><td>Nội Dung</td></tr>
												<tr align="center"><td>b</td></tr>
										</table>
									</HeaderTemplate>
									<ItemTemplate>
										 <%# Eval("NOI_DUNG")%>
									</ItemTemplate>
								</asp:TemplateField>								
								<asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2"  height="100%" width="100%" style="border-collapse: collapse;
                                            color: black">
                                            <tr>
                                                <td colspan="4" style="height: 50px; text-align: center">
                                                    Kế hoạch ( dự toán) được chi cả năm
                                                </td>
                                            </tr>
                                            <tr>
                                                <td style="text-align: center">
                                                    Từ quỹ bảo trì
                                                </td>
                                                <td style="text-align: center">
                                                    Từ ngân sách
                                                </td>
												<td style="text-align: center">
                                                    Số dư năm trước chuyển sang
                                                </td>
												<td style="text-align: center">
                                                    Tổng số
                                                </td>
                                            </tr>
											<tr>
												<td style="width: 25%;">1</td>
												<td style="width: 25%;">2</td>
												<td style="width: 25%;">c</td>
												<td style="width: 25%;">3=1+2</td>
											</tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse; text-align: right">
                                            <td style="width: 25%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 25%;height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 25%;height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, "{0:#,##0}")%>
                                            </td>
											<td style="width: 25%; ">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, "{0:#,##0}")%>
                                            </td>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            color: black">
                                            <tr>
                                                <td colspan="5" style="height: 50px; text-align: center">
                                                    Kinh phí đã nhận
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    Từ quỹ bảo trì
                                                </td>
                                                <td colspan="2" style="text-align: center">
                                                    Từ Ngân sách
                                                </td>
												<td rowspan="2" style="text-align: center">
                                                    Tổng số
                                                </td>												
                                            </tr>
											<tr>
												<td>Trong tháng</td>
												<td>Luỹ kễ từ đầu năm</td>
												<td>Trong tháng</td>
												<td>Luỹ kễ từ đầu năm</td>
											</tr>
											<tr>
												<td style="width: 20%;">4</td>
												<td style="width: 20%;">5</td>
												<td style="width: 20%;">6</td>
												<td style="width: 20%;">7</td>
												<td style="width: 20%;">5+7</td>
											</tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            text-align: right">
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%>
                                            </td>
											<td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE, "{0:#,##0}")%>
                                            </td>
											<td style="width: 20%;">
                                                <%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE) )
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE)), "#,###") %>
                                            </td>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:TemplateField HeaderStyle-Width="25%" HeaderStyle-Height="110px">
                                    <HeaderTemplate>
                                        <table border="1" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            color: black">
                                            <tr>
                                                <td colspan="5" style="height: 50px; text-align: center">
                                                    Kinh phí đã thanh toán, giải ngân
                                                </td>
                                            </tr>
                                            <tr>
                                                <td colspan="2" style="text-align: center">
                                                    Từ quỹ bảo trì
                                                </td>
                                                <td colspan="2" style="text-align: center">
                                                    Từ Ngân sách
                                                </td>
												<td rowspan="2" style="text-align: center">
                                                    Tổng số
                                                </td>												
                                            </tr>
											<tr>
												<td>Trong tháng</td>
												<td>Luỹ kễ từ đầu năm</td>
												<td>Trong tháng</td>
												<td>Luỹ kễ từ đầu năm</td>
											</tr>
											<tr>
												<td style="width: 20%;">8</td>
												<td style="width: 20%;">9</td>
												<td style="width: 20%;">10</td>
												<td style="width: 20%;">11</td>
												<td style="width: 20%;">9 + 11</td>
											</tr>
                                        </table>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <table border="0" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            text-align: right">
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE, "{0:#,##0}")%>
                                            </td>
                                            <td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%>
                                            </td>
											<td style="width: 20%; height: 30px;border-right: 1px solid gray;">
                                                <%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE, "{0:#,##0}")%>
                                            </td>
											<td style="width: 20%; ">
                                                <%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE)) 
                                                + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE)), "#,###") %>
                                            </td>
                                        </table>
                                    </ItemTemplate>
                                </asp:TemplateField>
								<asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px" >
									 <HeaderTemplate>
										<table border="1" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            color: black">
												<tr align="center"><td>Kinh phí chưa GN</td></tr>
												<tr align="center"><td>(5+7)-(9+11)</td></tr>
										</table>
									 </HeaderTemplate>
									 <ItemTemplate>
										<%# CIPConvert.ToStr( (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE)) 
                                            + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))) 
                                            - (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE)) 
                                            + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE)))  , "#,###") %>
									 </ItemTemplate>
                                    </asp:TemplateField>
									 <asp:TemplateField  ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px" >
									 <HeaderTemplate>
										<table border="1" cellspacing="0" cellpadding="2" height="100%"  width="100%" style="border-collapse: collapse;
                                            color: black">
												<tr align="center" rowspan="2"><td colspan="2">Kinh phí chưa GN</td></tr>
												<tr align="center"><td>Từ quỹ bảo trì</td><td>Từ Ngân sách</td></tr>
												<tr align="center"><td>12=1+c-5</td><td>13=2-7</td></tr>
										</table>
									 </HeaderTemplate>
									 <ItemTemplate>
										 <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
												text-align: right">												
												<td style="width: 25%;height: 30px;border-right: 1px solid gray;">
													<%# CIPConvert.ToStr(format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT)) 
                                                        + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE)), "#,###") %>
												</td>
												<td style="width: 25%;">
													<%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE)), "#,###") %>
												</td>
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
	</asp:updatepanel>
    <asp:updateprogress id="UpdateProgress1" runat="server">
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
	</asp:updateprogress>
</asp:Content>
