<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F530_Bao_cao_tong_hop_hinh_hinh_giai_ngan" %>

<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="QuanLyDuToan.App_Code" %>
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
			font-style: italic;
			font-weight: bold;
			pointer-events: none;
			cursor: default;
		}

		.a2000 {
			color: black !important;
			font-style: italic;
			font-weight: bold;
			pointer-events: none;
			cursor: default;
		}

		table > thead {
			border: 1px black solid;
		}

		table > tbody {
			border: 1px black solid;
		}

		table > thead > tr > th {
			vertical-align: middle;
			border-right: 1px solid black;
		}


		.text-right {
			width: 120px;
		}

		.datepicker {
			z-index: 999999 !important;
		}
	</style>
	<script src="../Scripts/jquery.doubleScroll.js"></script>
	<script src="../Scripts/fixHeader.js"></script>

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
				//getData("TPL_F530", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);


				$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
				$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
				$('#m_grv').each(function () {
					$(this).prepend('<thead></thead>')
					$(this).find('thead').append($(this).find("tr:eq(0)"));
					$(this).find('thead').append($(this).find("tr:eq(1)"));
					$(this).find('thead').append($(this).find("tr:eq(2)"));
					$(this).find('thead').append($(this).find("tr:eq(3)"));
				});
			}
		}


	</script>
	<script type="text/javascript">
		$(document).ready(function () {
			var m = new Map();
			var today = new Date();
			var mm = today.getMonth() + 1; //January is 0!
			var yyyy = today.getFullYear();
			m.set("<year>", yyyy);
			m.set("<month>", mm);
			m.set("<tu_ngay>", m_txt_tu_ngay.value);
			m.set("<den_ngay>", m_txt_den_ngay.value);
			//getData("TPL_F530", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);

			$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
			$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

			$('#m_grv').each(function () {
				$(this).prepend('<thead></thead>')
				$(this).find('thead').append($(this).find("tr:eq(0)"));
				$(this).find('thead').append($(this).find("tr:eq(1)"));
				$(this).find('thead').append($(this).find("tr:eq(2)"));
				$(this).find('thead').append($(this).find("tr:eq(3)"));
			});

			$('table#m_grv').scrollbarTable();
			$('#double-scroll').doubleScroll();
		});
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>--%>

	<%--<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>--%>
	<table id="main_table" style="width: 1200px; margin: auto" class="cssTable table" border="0">
		<tr>
			<td colspan="4" style="text-align: center">

				<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString()%></span>
			</td>
		</tr>
		<tr>
			<td colspan="4">
				<div style="margin: 0 auto; width: 700px !important">
					<div style="margin-top: 10px; width: 700px !important;">
						<div class="lb" style="margin-right: 23px; float: left">Từ ngày</div>
						<div id="datetimepicker1" class="input-group date" style="width: 200px; float: left">
							<asp:TextBox ClientIDMode="Static" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-start " Height="30px" Width="164px"></asp:TextBox>
							<span class="input-group-addon">
								<span class="glyphicon-calendar glyphicon"></span>
							</span>
						</div>
						<div class="lb" style="margin-right: 23px; float: left">Đến ngày</div>
						<div id="datetimepicker2" class="input-group date" style="width: 200px; float: left">
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
					<%--<div id="downloadify" style="width: 100px; margin: 0px auto; float: left;">
						You must have Flash 10 installed to download this file.
					</div>--%>
					<asp:Button ID="m_cmd_xuat_excel" Text="Xuất file excel" OnClick="m_cmd_xuat_excel_Click" runat="server" CssClass="btn btn-sm btn-success" />
				</div>

			</td>
		</tr>
		<tr>
			<td colspan="4">
				<div class="outer">
					<div style="width: 1200px; margin: auto;" id="double-scroll">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False" ClientIDMode="Static"
							Width="3900px" class="table-striped" CellPadding="0" ForeColor="Black" AllowSorting="True" PageSize="60"
							EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_RowCreated" EnableModelValidation="True">

							<Columns>
								<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="1" HeaderStyle-Height="10px" HeaderStyle-CssClass="pinned thpinned" ItemStyle-CssClass=" pinned" ItemStyle-Width="25px" HeaderStyle-Width="25px">
									<ItemTemplate>
										<%#getSTT(Eval(GRID_GIAI_NGAN.NOI_DUNG).ToString()) %>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Center" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="2" HeaderStyle-Height="10px" HeaderStyle-CssClass="pinned thpinned" ItemStyle-CssClass=" pinned" ItemStyle-Width="222px" HeaderStyle-Width="222px">
									<ItemTemplate>
										<a style="color: #027;" class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href='<%# gen_query_string(Eval(GRID_GIAI_NGAN.ID_DON_VI).ToString())%>' title="Xem chi tiết"><%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%></a>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Left" Width="222px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="3" HeaderStyle-Height="10px" ItemStyle-Width="80px" HeaderStyle-Width="55px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%#Eval(RPT_BC_TINH_HINH_GIAI_NGAN.TONG_SO_KM,"{0:#.###}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="80px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="4" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_QBT, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="5" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="6=4+5" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_QBT))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT)), "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="7" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_NS, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="8" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="9=7+8" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_NS))
														+CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)), "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="10=6+9" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_QBT))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))
												+		CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_NS))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)), "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>

								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="11" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="12" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG)), "#,###") %>
											</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="13" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="14" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG)), "#,###") %>
											</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="15=12+14" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												+		CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG)), "#,###") %>

										</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="16" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="17" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG)), "#,###") %>
											</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="18" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="19" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)), "#,###") %>
											</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="20=17+19" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG))
												+		CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)), "#,###") %>

										</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="21=12-17" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG))), "#,###") %>

										</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="22=14-19" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# 
														CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG))), "#,###") %>

										</font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="23=21+22" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%#CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG)))
												+
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)))
												, "#,###") %>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="24=6-12" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( 
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_QBT))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))), "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="25=9-19" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_NS))
														+CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG))), "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="26=24+25" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_QBT))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG)))
												+
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NTCS_NS))
														+CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS))
												-		(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)))
													   
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="27" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_QBT))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="28" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_NS))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="29=27+28" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_QBT))
												+		CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_QBT))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="30=27-17" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_QBT))
												-		
														(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG)))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="31=28-19" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_NS))
												-		
														(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="32=30+31" HeaderStyle-Height="10px" HeaderStyle-Width="120px">
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
											<%# CIPConvert.ToStr(  
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_QBT))
												-		
														(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG)))
												+
														CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN_NS))
												-		
														(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_LUY_KE))
                                                +		CCommonFunction.getMoney_number( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)))
													   , "#,###") %></font>
									</ItemTemplate>
									<HeaderStyle Height="10px" HorizontalAlign="Center" />
									<ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
							</Columns>

						</asp:GridView>
					</div>
				</div>
			</td>
		</tr>
	</table>
	<%--</ContentTemplate>
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
	</asp:UpdateProgress>--%>
</asp:Content>
