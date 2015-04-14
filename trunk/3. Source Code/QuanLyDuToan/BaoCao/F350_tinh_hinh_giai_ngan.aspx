<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F350_tinh_hinh_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F350_tinh_hinh_giai_ngan" %>

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
		}

		th {
			text-align: center !important;
			background: #ddd;
			border-color: #000;
		}

		.boxControl {
			float: left;
			width: 50%;
			height: 90px;
		}

		.height30 {
			height: 30px;
		}

		.lb {
			width: 100px;
			float: left;
			text-align: right;
			line-height: 20px;
		}

		.control {
			width: 240px;
			float: left;
		}

			.control select, input {
				width: 91px;
				/*margin-left: 5px;*/
			}

		.filter {
			width: 552px !important;
			margin-left: 10px;
		}

		.divBoxControl {
			width: 51%;
			margin: 0px auto;
		}

		#main_table tr td {
			border-top: 0px;
		}

		table {
			border: 1px solid black !important;
		}

		.a0 {
			color: maroon !important;
			font-weight: bold;
			pointer-events: none;
			cursor: default;
		}

		select {
			width: 220px !important;
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
				m.set("<nam>", yyyy);
				m.set("<donvi>", m_ddl_don_vi.selectedOptions[0].innerHTML);
				m.set("<tu_ngay>", m_txt_tu_ngay.value);
				m.set("<den_ngay>", m_txt_den_ngay.value);
				getData("TPL_F350", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);

				$('#double-scroll').doubleScroll();
				$("#<%=m_ddl_loai_nv.ClientID%>").select2();
    			$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
    			$("#<%=m_ddl_du_an.ClientID%>").select2();
    			$("#<%=m_ddl_don_vi.ClientID%>").select2();
    			$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
    			$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
    		}
		}
		$(document).ready(function () {
			var m = new Map();
			var today = new Date();
			var mm = today.getMonth() + 1; //January is 0!
			var yyyy = today.getFullYear();
			m.set("<nam>", yyyy);
			m.set("<donvi>", m_ddl_don_vi.selectedOptions[0].innerHTML);
			m.set("<tu_ngay>", m_txt_tu_ngay.value);
			m.set("<den_ngay>", m_txt_den_ngay.value);
			getData("TPL_F350", "m_grv", "Bao_cao_tong_hop_tinh_hinh_giai_ngan", m);

			$('#double-scroll').doubleScroll();
			$("#<%=m_ddl_loai_nv.ClientID%>").select2();
			$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
			$("#<%=m_ddl_du_an.ClientID%>").select2();
			$("#<%=m_ddl_don_vi.ClientID%>").select2();
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
						<%--		<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />--%>
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString() %></span>
						<br />
						<br />
						<span style="font-weight: bold">ĐƠN VỊ:
                            <asp:DropDownList runat="server" ClientIDMode="Static" ID="m_ddl_don_vi" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged"></asp:DropDownList>
						</span>
						<br />
						<br />
						<div class="divBoxControl height30">
							<div class="lb">Tìm kiếm:</div>
							<div class="control">
								<asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="filter form-control"></asp:TextBox>
							</div>
						</div>
						<div style="width: 680px; margin: 0px auto">
							<div class="boxControl" style="width: 340px; margin-left: 13px;">
								<div class="height30">
									<div class="lb">Loại nhiệm vụ</div>
									<div class="control">
										<asp:DropDownList ID="m_ddl_loai_nv" runat="server" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_loai_nv_SelectedIndexChanged"></asp:DropDownList>
									</div>
								</div>
								<div class="height30">
									<div class="lb">Công trình</div>
									<div class="control">
										<asp:DropDownList ID="m_ddl_cong_trinh" runat="server" AutoPostBack="True" CssClass="selec2" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged"></asp:DropDownList>
									</div>
								</div>
								<div class="height30">
									<div class="lb">Dự án</div>
									<div class="control">
										<asp:DropDownList ID="m_ddl_du_an" runat="server" CssClass="selec2"></asp:DropDownList>
									</div>
								</div>

							</div>
							<div class="boxControl" style="width: 301px; margin-left: 26px;">
								<div class="height30">
									<div class="lb" style="margin-right: 0px; width: 90px; margin-top: 6px;">Từ ngày</div>
									<div id="datetimepicker1" class="input-group date datepicker" style="width: 200px;">
										<asp:TextBox ClientIDMode="Static" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-start" Height="30px" Width="164px"></asp:TextBox>
										<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
										</span>
									</div>
								</div>
								<div class="height30" style="margin-top: 6px;">
									<div class="lb" style="margin-right: 0px; width: 90px; margin-top: 6px;">Đến ngày</div>
									<div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
										<asp:TextBox ClientIDMode="Static" ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-end" Height="30px" Width="164px"></asp:TextBox>
										<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
										</span>
									</div>
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
						<asp:Button ID="m_cmd_xuat_excel" Visible="false" Text="Xuất file excel" OnClick="m_cmd_xuat_excel_Click" runat="server" CssClass="btn btn-sm btn-primary" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<div style="width: 1200px; margin: 0px auto;" id="double-scroll">
							<asp:GridView ClientIDMode="Static" ID="m_grv" runat="server" AutoGenerateColumns="False"
								CssClass="cssGrid" Width="2500px" CellPadding="0" ForeColor="Black"
								AllowSorting="True" PageSize="60"
								EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_RowCreated" EnableModelValidation="True" HeaderStyle-CssClass="HeaderStyle">

								<Columns>
									<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="(a)" HeaderStyle-Width="2%" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# getSTT(Eval(GRID_GIAI_NGAN.NOI_DUNG).ToString()) %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" Width="2%" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Center" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(b)" HeaderStyle-Width="150px" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" Width="150px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Left" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(0)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<%#Eval(RPT_BC_TINH_HINH_GIAI_NGAN.TONG_SO_KM, "{0:#.###}")%>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(1)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F157.ToString()%><%# format_link_to_chi_tiet(
                                                    Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"N") %>"
												title="Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(2)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F157.ToString()%><%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                   ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"Y") %>"
												title="Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(3)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(4)=(1)+(2)+(3)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												<%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS))
												+ format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG))
												, "#,###") %>
                                            </font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F257.ToString()%><%# format_link_to_chi_tiet_trong_thang(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                   ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"N") %>"
												title="Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(6)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F257.ToString()%><%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                   ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC)
													,"N") %>"
												title="Xem chi tiết">
												<%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												, "#,###") %>
											</a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(7)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(8)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<%--  <font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)) , "#,###")
											%></font>--%>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												<%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG))
												, "#,###") %>
                                            </font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9) = (6) + (8)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<%-- <font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG) )
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %></font>--%>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												 <%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												+ format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG))
												, "#,###") %>
                                             </font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(10)" HeaderStyle-Height="10px">
										<ItemTemplate>

											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F357.ToString()%><%# format_link_to_chi_tiet_trong_thang(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"N") %>"
												title="Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(11)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F357.ToString()%><%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                  ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"N") %>"
												title="Xem chi tiết">
												 <%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												, "#,###") %>
											</a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(12)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F357.ToString()%><%# format_link_to_chi_tiet_trong_thang(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                  ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"Y") %>"
												title="Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%></a>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(13)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<a class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href="<%#FormInfo.FormName.F357.ToString()%><%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_LOAI_NHIEM_VU)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CONG_TRINH_KHOAN)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DU_AN_MUC_TIEU_MUC) 
													,"Y") %>'"
												title="Xem chi tiết">
												 <%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG))
												, "#,###") %>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>

									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(14) = (11) + (13)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												 <%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												+ format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG))
												, "#,###") %>

											</font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>

									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(15) = (6+8) - (11+13)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												 <%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												+ format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG))
												-(format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG))
												+ format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG)))
												, "#,###") %>
											</font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(16) = (1) + (3) - (6)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												<%# CIPConvert.ToStr( 
												format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS))
												-(format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG)))
												, "#,###") %>
											</font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(17) = (2) - (8)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'>
												<%# CIPConvert.ToStr( 
												 format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS))
												-(format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG)))
												, "#,###") %>
											</font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(18)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%#CCommonFunction.getMoney_string_format(CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN))) %></font>
										</ItemTemplate>
										<HeaderStyle Height="10px" HorizontalAlign="Center" />
										<ItemStyle HorizontalAlign="Right" Width="120px" />
									</asp:TemplateField>
									<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(19)" HeaderStyle-Height="10px">
										<ItemTemplate>
											<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CCommonFunction.getMoney_string_format( CCommonFunction.getMoney_number(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.SO_CHUA_GN))) %></font>
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
