<%@ Page Title="" Language="C#"  EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F256_bao_cao_giao_von_quy_bt_theo_qd.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F256_bao_cao_giao_von_quy_bt_theo_qd" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssGrid tr td {
			padding: 0px;
           
		}
        .cssGrid
        {
            width:962px;
        }
        
       
         .boxControl {
            margin:0 auto;
	       width:423px;
            height:60px;
        }

	    .lb {
	        width:100px; 
            float:left;
            text-align:right;
            line-height:20px;
        }
          #main_table tr td
        {
            border-top:0px;
        }
         table 
         {
             border:1px solid black !important;
         }
		 .cssGrid tr td {
			padding: 0px;
            text-align:left;
		}

	    .boxControl {
	        float:left;
            width:50%; 
            height:90px;
        }

	    .height30 {
	        height:30px;
        }
	    .csscurrency {
	        text-align:right !important;
        }
	   
      

	    .control {
	        width:240px; 
            float:left;
        }

	    .control select
         {
	        width:220px !important;
             }
         
        .filter{
	        width:567px !important;
            margin-left:10px;    
        }
         #main_table tr td
        {
            border-top:0px;
        }
         table 
         {
             border:1px solid black !important;
         }
	</style>
    <script src="../Scripts/jquery.doubleScroll.js"></script>
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#double-scroll').doubleScroll();
                $("#<%=m_ddl_loai_nv.ClientID%>").select2();
                $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
                $("#<%=m_ddl_du_an.ClientID%>").select2();
                $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
                $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
            $('#double-scroll').doubleScroll();
            $("#<%=m_ddl_loai_nv.ClientID%>").select2();
            $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            $("#<%=m_ddl_du_an.ClientID%>").select2();
            $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" style="width: 1000px; margin: auto" class="cssTable table" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<p>
							<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIAO VỐN <%=DateTime.Now.Year.ToString() %></span>
							<br />
							<asp:Label ID="m_lbl_don_vi" runat="server" ForeColor="Black" Font-Bold="true"></asp:Label>
							<br />
							 <div style="width:70%; margin:0 auto;" class="height30">
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
                                        <asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div>
                                <div class="height30">
							        <div class="lb" style="margin-right:30px">Đến ngày</div>
                                    <div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
                                        <asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control date-end" Height="30px" Width="164px"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div>
                            </div>
                        </div>	
						</p>
					</td>
				</tr>


				<tr>

					<td colspan="4" style="text-align: center">
						<asp:Button cssclass="btn" ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" />
						<asp:Button cssclass="btn" ID="m_cmd_xuat_excel" Text="Xuất file excel" OnClick="m_cmd_xuat_excel_Click" runat="server" />
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4" style="margin: auto;" align="center">
                        <div style="width: 970px; margin: 0px auto;" id="double-scroll">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="true"
							UseAccessibleHeader="true" DataKeyNames="ID"
							CssClass="cssGrid" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60" ShowHeader="true" AllowPaging="false"
							EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_OnRowCreated"
							OnRowDataBound="m_grv_RowDataBound"
							HeaderStyle-Height="65px" RowStyle-Height="28px">
                          
							<Columns>
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


