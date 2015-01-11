<%@ Page Title="" Language="C#" EnableEventValidation="false" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F530_bao_cao_tong_cuc.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F530_bao_cao_tong_cuc" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
        .cssGrid tr td
        {
            padding: 0px;
        }

        .HeaderStyle
        {
            background: #ddd;
            border-color: #000;
            text-align:center;
        }

        th {
            text-align:center !important;
        }
        .boxControl {
	        float:left;
            width:400px; 
            height:90px;
            margin:0 auto;
        }
        lb {
	        width:100px; 
            float:left;
            text-align:right;
            line-height:20px;
        }
    </style>
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
               
                $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
                $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
           
            $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:scriptmanager id="ScriptManager1" runat="server">
	</asp:scriptmanager>

    <asp:updatepanel id="UpdatePanel1" runat="server">
		<ContentTemplate>
<<<<<<< .mine			<table id="main_table" style="width: 1970px;" class="cssTable table" border="0">
=======			<table style="width: 1300px;" class="cssTable" border="0">
>>>>>>> .theirs				<tr>
					<td colspan="4" style="text-align: center">
						<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString()%></span>
					</td>
				</tr>
                <tr>
                    <%--<td style="width: 200px;"></td>
                    <td style="display: none;">
                        <span style="font-weight: bold" >Loại đơn vị
                        <asp:DropDownList id="m_cbo_loai_don_vi" Width="200px" runat="server"></asp:DropDownList></span>
                    </td>--%>
                    <td style="width:34%;"></td>
                    <td  style="text-align:center;width: 222px;">
                                <div class="height30">
                                   <div class="lb" style="margin-right:30px">Từ ngày</div>
                                    <div id="datetimepicker1" class="input-group date datepicker" style="width: 200px;">
                                        <asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div>
                        </td>
                        <td style="text-align:center;width: 222px;">
                                <div class="height30">
							        <div class="lb" style="margin-right:30px">Đến ngày</div>
                                    <div id="datetimepicker2" class="input-group date datepicker" style="width: 200px;">
                                        <asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control date-end" Height="30px" Width="164px"></asp:TextBox>
                                        <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                        </span>
                                    </div>
                                </div>
                           
				         </td>
                     <td></td>
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
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" cssclass="btn" />
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" OnClick="m_cmd_xuat_excel_Click" runat="server" cssclass="btn" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
                        <div style="width:1200px;overflow-y:hidden; margin:20px auto;">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="False"
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
								<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(b)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<a style="color:#027;" href='<%# get_query_string(Eval(GRID_GIAI_NGAN.ID_DON_VI).ToString())%>' title"Xem chi tiết"><%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%></a>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Left" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(1)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(2)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(c)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(3) = (1) + (2)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>					
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(4)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(6)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(7)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5) + (7)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG) )
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(8)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(10)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(11)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
<<<<<<< .mine                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9+11)"  HeaderStyle-Height="10px">									
=======                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9) + (11)"  HeaderStyle-Height="10px">									
>>>>>>> .theirs									<ItemTemplate>
										<%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                                + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)), "#,###") %>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                								
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(5+7) - (9+11)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<%# CIPConvert.ToStr( (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)) 
                                            + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))) 
                                            - (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                            + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)))  , "#,###") %>
									 </ItemTemplate>
                                     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(12) = (1) + (c) - (5)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<%# CIPConvert.ToStr(format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT)) 
                                                        + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)), "#,###") %>
									 </ItemTemplate>
                                     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
                                </asp:TemplateField>
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(13) = (2) - (7)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %>						
									 </ItemTemplate>
								     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>		
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN)) , "#,###") %>						
									 </ItemTemplate>
								     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.SO_CHUA_GN)) , "#,###") %>						
									 </ItemTemplate>
								     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
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
