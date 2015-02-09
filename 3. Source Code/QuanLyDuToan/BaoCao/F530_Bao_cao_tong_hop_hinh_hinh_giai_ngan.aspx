<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="WebUS" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.cssGrid tr td {
			padding: 0px;
		}

		.HeaderStyle {
			background: #ddd;
			border-color: #000;
			text-align: center;
		}

		th {
			text-align: center !important;
			background: #ddd;
			border-color: #000;
		}

		.lb {
			width: 100px;
			float: left;
			text-align: right;
			line-height: 20px;
		}

		.a1000 {
			color: maroon !important;
			font-weight: bold;
			pointer-events: none;
			cursor: default;
		}
	</style>
	<script src="../Scripts/jquery.doubleScroll.js"></script>
	<script>
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {
				var m = new Map();
				var today = new Date();
				var mm = today.getMonth() + 1; //January is 0!
				var yyyy = today.getFullYear();
				m.set("<year>", yyyy);
				m.set("<month>", mm);
				m.set("<tu_ngay>", m_txt_tu_ngay.value);
				m.set("<den_ngay>", m_txt_den_ngay.value);
				getData("TPL_F530", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);

				$('#double-scroll').doubleScroll();
				$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
				$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

			}
		}
		$(document).ready(function () {
			var m = new Map();
			var today = new Date();
			var mm = today.getMonth() + 1; //January is 0!
			var yyyy = today.getFullYear();
			m.set("<year>", yyyy);
			m.set("<month>", mm);
			m.set("<tu_ngay>", m_txt_tu_ngay.value);
			m.set("<den_ngay>", m_txt_den_ngay.value);
			getData("TPL_F530", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);

			$('#double-scroll').doubleScroll();
			$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" style="width: 1300px;" class="cssTable table" border="0">
				<tr>
					<td colspan="4" style="text-align: center">

						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString()%></span>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<div style="margin: 0 auto; width: 350px !important">
							<div class="height30" style="margin-top: 10px;">
								<div class="lb" style="margin-right: 23px">Từ ngày</div>
								<div id="datetimepicker1" class="input-group date" style="width: 200px;">
									<asp:TextBox ClientIDMode="Static" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-start" Height="30px" Width="164px"></asp:TextBox>
									<span class="input-group-addon">
										<span class="glyphicon-calendar glyphicon"></span>
									</span>
								</div>
							</div>
							<div class="height30" style="margin-top: 10px;">
								<div class="lb" style="margin-right: 23px">Đến ngày</div>
								<div id="datetimepicker2" class="input-group date" style="width: 200px;">
									<asp:TextBox ClientIDMode="Static" ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox  date-start" Height="30px" Width="164px"></asp:TextBox>
									<span class="input-group-addon">
										<span class="glyphicon-calendar glyphicon"></span>
									</span>
								</div>
							</div>
						</div>
					</td>

				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>

				<tr>

					<td colspan="4" style="text-align: center">
						<div style="margin: 0px auto; width: 200px;">
							<div style="width: 100px; margin: 0px auto; float: left;">
								<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" CssClass="btn btn-sm btn-primary" />
							</div>
							<div id="downloadify" style="width: 100px; margin: 0px auto; float: left;">
								You must have Flash 10 installed to download this file.
							</div>
						</div>
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" OnClick="m_cmd_xuat_excel_Click" runat="server" CssClass="btn btn-sm btn-primary" Visible="false" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<div style="width: 1200px; margin: 20px auto;" id="double-scroll">
							<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
								CssClass="cssGrid" Width="2600px" CellPadding="0" ForeColor="Black"
								AllowSorting="True" PageSize="60"
								EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_RowCreated" EnableModelValidation="True">

								<Columns>
									<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="(a)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<%# Container.DataItemIndex + 1 %>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Center" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(b)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a style="color: #027;" class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href='<%# get_query_string(Eval(GRID_GIAI_NGAN.ID_DON_VI).ToString())%>' title="Xem chi tiết"><%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(0)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<%#Eval(RPT_BC_TINH_HINH_GIAI_NGAN.TONG_SO_KM, "{0:#,##0}")%>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(1)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(2)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(c)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(3) = (1) + (2)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(4)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(6)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(7)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5) + (7)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE) )
                                                + CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE)), "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(8)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(10)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(11)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9) + (11)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE)) 
                                                +  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE)), "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>

									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5+7) - (9+11)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( ( CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE)) 
                                            +  CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))) 
                                            - ( CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE)) 
                                            +  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE)))  , "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(12) = (1) + (c) - (5)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT)) 
                                                        +  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG)) 
                                                        -  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE)), "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(13) = (2) - (7)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)) 
                                                        -  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE)), "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN)) , "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.SO_CHUA_GN)) , "#,###") %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
								</Columns>

							</asp:GridView>
						</div>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
			<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
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
