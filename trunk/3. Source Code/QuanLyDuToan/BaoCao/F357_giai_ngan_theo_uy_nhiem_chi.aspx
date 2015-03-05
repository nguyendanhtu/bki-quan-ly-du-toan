<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F357_giai_ngan_theo_uy_nhiem_chi.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F357_giai_ngan_theo_uy_nhiem_chi" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.cssGrid tr td {
			padding: 0px;
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

		.control1 {
			width: 240px;
			float: left;
		}

			.control1 select {
				width: 203px !important;
			}

		.control {
			width: 240px;
			float: left;
		}

			.control select {
				width: 220px !important;
			}

		.filter {
			width: 567px !important;
			margin-left: 10px;
		}

		#main_table tr td {
			border-top: 0px;
		}

		table {
			border: 1px solid black !important;
		}

		th {
			border-top: 1px solid black !important;
		}

		.csscurrency {
			text-align: right !important;
		}
	</style>
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
		        getData("TPL_F357", "m_grv", "Bao_cao_tinh_hinh_giai_ngan_theo_uy_nhiem_chi", m);

				$("#<%=m_ddl_loai_nv.ClientID%>").select2();
            	$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            	$("#<%=m_ddl_du_an.ClientID%>").select2();
            	$("#<%=m_ddl_don_vi.ClientID%>").select2();
            	$("#<%=m_ddl_quyet_dinh.ClientID%>").select2();
            	$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            	$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            	$("#quyet_dinh").appendTo(".header_quyet_dinh");
            	m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
                if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
                	$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F390_v_danh_sach_uy_nhiem_chi.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val());
                }
                else {
                	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F304_nhap_giai_ngan_theo_unc.aspx?ip_nguon_ns=N&ip_dc_id_dm_giai_ngan=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                }
				$("#<%=m_ddl_quyet_dinh.ClientID%>").on('change', function () {
            		m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
                	if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
                		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F390_v_danh_sach_uy_nhiem_chi.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val());
                    }
                    else {
                		$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F304_nhap_giai_ngan_theo_unc.aspx?ip_nguon_ns=N&ip_dc_id_dm_giai_ngan=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                    }
                });
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
	        getData("TPL_F357", "m_grv", "Bao_cao_tinh_hinh_giai_ngan_theo_uy_nhiem_chi", m);

			$("#<%=m_ddl_loai_nv.ClientID%>").select2();
        	$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
			$("#<%=m_ddl_du_an.ClientID%>").select2();
			$("#<%=m_ddl_don_vi.ClientID%>").select2();
        	$("#<%=m_ddl_quyet_dinh.ClientID%>").select2();
        	$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        	$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        	$("#quyet_dinh").appendTo(".header_quyet_dinh");
        	m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
            if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
            	$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F390_v_danh_sach_uy_nhiem_chi.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val());
            }
            else {
            	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F304_nhap_giai_ngan_theo_unc.aspx?ip_nguon_ns=N&ip_dc_id_dm_giai_ngan=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
            }
        	$("#<%=m_ddl_quyet_dinh.ClientID%>").on('change', function () {
        		m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
            	if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
            		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F390_v_danh_sach_uy_nhiem_chi.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val());
                }
                else {
            		$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F304_nhap_giai_ngan_theo_unc.aspx?ip_nguon_ns=N&ip_dc_id_dm_giai_ngan=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                }
            });
        });
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" style="width: 1000px; margin: auto;" class="cssTable table">
				<thead>
					<tr>
						<td colspan="4" style="text-align: center">
							<p>
								<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN THEO UỶ NHIỆM CHI <%=DateTime.Now.Year.ToString() %>
									<asp:Label ID="m_lbl_nguon" runat="server" Font-Bold="true"></asp:Label></span>
								<br />
								<asp:DropDownList ID="m_ddl_don_vi" runat="server" Width="180px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged"></asp:DropDownList>
							</p>
							<div style="width: 70%; margin: 0px auto;" class="height30">
								<div class="lb">Tìm kiếm:</div>
								<div class="control">
									<asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="filter form-control"></asp:TextBox></div>
							</div>
							<div style="width: 70%; margin: 0px auto">
								<div class="boxControl">
									<div class="height30">
										<div class="lb">Loại nhiệm vụ</div>
										<div class="control">
											<asp:DropDownList ID="m_ddl_loai_nv" runat="server" Width="100px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_loai_nv_SelectedIndexChanged"></asp:DropDownList></div>
									</div>
									<div class="height30">
										<div class="lb">Công trình</div>
										<div class="control">
											<asp:DropDownList ID="m_ddl_cong_trinh" runat="server" Width="100px" AutoPostBack="True" CssClass="selec2" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged"></asp:DropDownList></div>
									</div>
									<div class="height30">
										<div class="lb">Dự án</div>
										<div class="control">
											<asp:DropDownList ID="m_ddl_du_an" runat="server" Width="100px" CssClass="selec2"></asp:DropDownList></div>
									</div>

								</div>
								<div class="boxControl">
									<div class="height30">
										<div class="lb" style="margin: 9px 0px 0px 24px">Từ ngày</div>
										<div id="datetimepicker1" class="input-group date datepicker" style="width: 200px;">
											<asp:TextBox ClientIDMode="Static" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px" OnTextChanged="m_txt_tu_ngay_TextChanged" AutoPostBack="true"></asp:TextBox>
											<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
											</span>
										</div>
									</div>
									<div class="height30" style="margin-bottom: 5px;">
										<div class="lb" style="margin: 9px 0px 0px 24px">Đến ngày</div>
										<div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
											<asp:TextBox ClientIDMode="Static" ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control date-end" Height="30px" Width="164px" OnTextChanged="m_txt_den_ngay_TextChanged" AutoPostBack="true"></asp:TextBox>
											<span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
											</span>
										</div>
									</div>
									<div class="height30">
										<div class="lb" style="margin: 3px 4px 0px 24px">Chọn UNC</div>
										<div class="control1" style="width: 203px !important;">
											<asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" CssClass="select2" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
										</div>
									</div>
								</div>
							</div>
						</td>
					</tr>
				</thead>
				<tbody>
					<tr>

						<td colspan="4" style="text-align: center">
							<div style="margin:0px auto;width: 200px;">
                            <div style="width: 100px; margin: 0px auto;float: left;">
						        <asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" CssClass="btn btn-sm btn-primary" />
						    </div>
                            <div id="downloadify" style="width: 100px; margin: 0px auto;float: left;">
				                You must have Flash 10 installed to download this file.
			                </div>
                        </div>
							<asp:Button Visible="false" CssClass="btn btn-sm btn-primary"  ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" OnClick="m_cmd_xuat_excel_Click" />
						</td>
					</tr>
					<tr>
						<td colspan="4">
							<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
						</td>
					</tr>
					<tr>
						<td colspan="4" style="margin: auto" align="center">
							<asp:GridView ClientIDMode="Static" ID="m_grv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
								CssClass="cssGrid table" CellPadding="0" ForeColor="Black"
								AllowSorting="True" PageSize="60"
								EmptyDataText="Không có dữ liệu phù hợp"
								HeaderStyle-Height="65px" RowStyle-Height="28px" EnableModelValidation="True">

								<Columns>
									<asp:BoundField HeaderText="Nội dung" DataField="noi_dung" HtmlEncode="false">
										<HeaderStyle HorizontalAlign="Center" />
									</asp:BoundField>
									<asp:BoundField DataField="tong_tien_qd" DataFormatString="{0:N0}">
										<HeaderStyle HorizontalAlign="Center" CssClass="header_quyet_dinh" />
										<ItemStyle HorizontalAlign="Right" Width="30%" />
									</asp:BoundField>
								</Columns>

								<HeaderStyle Height="65px" />
								<RowStyle Height="28px" />
							</asp:GridView>
						</td>
					</tr>
				</tbody>
			</table>
			<div id="quyet_dinh">
				<a id="m_anchor_so_quyet_dinh">Xem chi tiết quyết định</a>
			</div>
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
