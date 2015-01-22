<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F157_giao_ke_hoach_theo_quyet_dinh.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F157_giao_ke_hoach_theo_quyet_dinh" %>
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

    	.control {
    		width: 240px;
    		float: left;
    	}

    	.control1 {
    		width: 240px;
    		float: left;
    	}

    	.control select {
    		width: 220px !important;
    	}

    	.control1 select {
    		width: 203px !important;
    	}

    	.filter {
    		width: 567px !important;
    		margin-left: 10px;
    	}

    	#main_table tr td {
    		border-top: 0px;
    	}


    	.csscurrency {
    		text-align: right !important;
    	}
    </style>
    <script>
    	function pageLoad(sender, args) {
    		if (args.get_isPartialLoad()) {
    			$("#<%=m_ddl_loai_nv.ClientID%>").select2();
    			$("#<%=m_ddl_don_vi.ClientID%>").select2();
            	$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            	$("#<%=m_ddl_du_an.ClientID%>").select2();
            	$("#<%=m_ddl_quyet_dinh.ClientID%>").select2();
            	$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            	$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            	$("#quyet_dinh").appendTo(".header_quyet_dinh");
            	m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
                if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
            		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F190_Danh_sach_quyet_dinh_giao_ke_hoach.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#m_ddl_don_vi").val());
                }
                else {
                	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/f204_nhap_giao_ke_hoach_qbt.aspx?ip_nguon_ns=N&ip_dc_id_quyet_dinh=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                }

				$("#<%=m_ddl_quyet_dinh.ClientID%>").on('change', function () {
            		m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
                	if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
                		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F190_Danh_sach_quyet_dinh_giao_ke_hoach.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#m_ddl_don_vi").val());
                    }
                    else {
                    	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/f204_nhap_giao_ke_hoach_qbt.aspx?ip_nguon_ns=N&ip_dc_id_quyet_dinh=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                    }
                });


			}
		}
		$(document).ready(function () {
			$("#<%=m_ddl_loai_nv.ClientID%>").select2();
        	$("#<%=m_ddl_don_vi.ClientID%>").select2();
        	$("#<%=m_ddl_cong_trinh.ClientID%>").select2();
        	$("#<%=m_ddl_du_an.ClientID%>").select2();
        	$("#<%=m_ddl_quyet_dinh.ClientID%>").select2();
        	$("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        	$("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        	$("#quyet_dinh").appendTo(".header_quyet_dinh");
        	m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
            if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
        		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F190_danh_sach_quyet_dinh_giao_kh.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#m_ddl_don_vi").val());
            }
            else {
            	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F104_nhap_du_toan_ke_hoach.aspx?ip_nguon_ns=N&ip_dc_id_quyet_dinh=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
            }

        	$("#<%=m_ddl_quyet_dinh.ClientID%>").on('change', function () {
        		m_anchor_so_quyet_dinh.innerHTML = $("#<%=m_ddl_quyet_dinh.ClientID%> option:selected").text();
            	if ($("#<%=m_ddl_quyet_dinh.ClientID%>").val().toString() == "-1") {
            		$("#m_anchor_so_quyet_dinh").attr("href", "../DanhMuc/F190_danh_sach_quyet_dinh_giao_kh.aspx?ip_dat_tu_ngay=" + $("#<%=m_txt_tu_ngay.ClientID%>").val() + "&ip_dat_den_ngay=" + $("#<%=m_txt_den_ngay.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#m_ddl_don_vi").val());
                }
                else {
                	$("#m_anchor_so_quyet_dinh").attr("href", "../DuToan/F104_nhap_du_toan_ke_hoach.aspx?ip_nguon_ns=N&ip_dc_id_quyet_dinh=" + $("#<%=m_ddl_quyet_dinh.ClientID%>").val() + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val());
                }
            });


        })
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
							<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIAO KẾ HOẠCH QUỸ BẢO TRÌ <%=DateTime.Now.Year.ToString() %></span>
							<br />
                            <asp:DropDownList ClientIDMode="Static" ID="m_ddl_don_vi" runat="server" Width="180px" AutoPostBack="True" cssclass="select2"></asp:DropDownList>
                        </p>
						<div style="width:70%; margin:0px auto;" class="height30">
                            <div class="lb">Tìm kiếm:</div>
                            <div class="control"><asp:TextBox ID="m_txt_tim_kiem" runat="server" CssClass="filter"></asp:TextBox></div>
                        </div>
                        <div style="width:70%; margin:0px auto">
                            <div class="boxControl">
                                <div class="height30">
                                    <div class="lb">Loại nhiệm vụ</div>
                                    <div class="control"><asp:DropDownList ID="m_ddl_loai_nv" runat="server" Width="100px" AutoPostBack="True" cssclass="select2" OnSelectedIndexChanged="m_ddl_loai_nv_SelectedIndexChanged"></asp:DropDownList></div>
                                </div>
                                <div class="height30">
                                    <div class="lb">Công trình</div>
                                    <div class="control"><asp:DropDownList ID="m_ddl_cong_trinh" runat="server" Width="100px" AutoPostBack="True" cssclass="selec2" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged"></asp:DropDownList></div>
                                </div>
                                <div class="height30">
                                    <div class="lb">Dự án</div>
                                    <div class="control"><asp:DropDownList ID="m_ddl_du_an" runat="server" Width="100px" cssclass="selec2"></asp:DropDownList></div>
                                </div>

                            </div>
                            <div class="boxControl">
                                <div class="height30">
                                   <div class="lb" style="margin-right:30px">Từ ngày</div>
                                    <div id="datetimepicker1" class="input-group date datepicker" style="width: 200px;">
                                        <asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px" OnTextChanged="m_txt_tu_ngay_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="height30" style="margin-bottom: 5px;">
							        <div class="lb" style="margin-right:30px">Đến ngày</div>
                                    <div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
                                        <asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control date-end" Height="30px" Width="164px" OnTextChanged="m_txt_den_ngay_TextChanged" AutoPostBack="true"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div
                                 <div class="height30">
							        <div class="lb" style="margin-right:34px">Quyết định</div>
                                     <div class="control1" style="width: 203px !important;">
                                         <asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" cssclass="select2" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
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
						<asp:Button CssClass="btn btn-sm btn-primary" ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" runat="server" OnClick="m_cmd_xem_bao_cao_Click" />
						<asp:Button CssClass="btn btn-sm btn-success" ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" OnClick="m_cmd_xuat_excel_Click" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" ></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4" style="margin: auto" align="center">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
							CssClass="cssGrid table" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60"
							EmptyDataText="Không có dữ liệu phù hợp"
							
							HeaderStyle-Height="65px" RowStyle-Height="28px" EnableModelValidation="True">

							<Columns>
							    <asp:BoundField HeaderText="Nội dung" HeaderStyle-HorizontalAlign="Center" HeaderStyle-VerticalAlign="Middle" DataField="noi_dung" HtmlEncode="false"	>
                                <HeaderStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField DataField="tong_tien_theo_qd" DataFormatString="{0:N0}">
                                <HeaderStyle HorizontalAlign="Center" CssClass="header_quyet_dinh" Width="30%" />
                                <ItemStyle HorizontalAlign="Right" />
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
