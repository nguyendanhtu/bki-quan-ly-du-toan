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

       th 
        {
            text-align:center !important;
            background: #ddd;
            border-color: #000;
        }
        
        .lb {
	        width:100px; 
            float:left;
            text-align:right;
            line-height:20px;
        }

        .a1000{
            color:maroon !important;
            font-weight:bold;
            pointer-events: none;
            cursor: default;
        }
    </style>
    <script src="../Scripts/jquery.doubleScroll.js"></script>
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('#double-scroll').doubleScroll();
                $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
                $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
            $('#double-scroll').doubleScroll();
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
            <table id="main_table" style="width: 1300px;" class="cssTable table" border="0">
                <tr>
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
                    
                    
                    <td colspan="4" >
                        <div style="margin:0 auto; width:300px !important">
                                <div class="height30" style="margin-top: 10px;">
                             <div class="lb" style="margin-right:23px">Từ ngày</div>
                               <div id="datetimepicker1" class="input-group date" style="width: 200px;">
                                  <asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox date-start" Height="30px" Width="164px"></asp:TextBox>
                                   <span class="input-group-addon">
                                       <span class="glyphicon-calendar glyphicon"></span>
                                   </span>
                              </div>
                        </div>
                        <div class="height30" style="margin-top: 10px;">
				            <div class="lb" style="margin-right:23px">Đến ngày</div>
                                  <div id="datetimepicker2" class="input-group date" style="width: 200px;">
                                  <asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox  date-start" Height="30px" Width="164px"></asp:TextBox>
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
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" cssclass="btn" />
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" OnClick="m_cmd_xuat_excel_Click" runat="server" cssclass="btn" Enabled="False" />
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
                        <div style="width:1200px;margin:20px auto;" id="double-scroll">
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
                                    <ItemStyle HorizontalAlign="Center"/>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="(b)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<a style="color:#027;" class='a<%# Eval(GRID_GIAI_NGAN.ID)%>' href='<%# get_query_string(Eval(GRID_GIAI_NGAN.ID_DON_VI).ToString())%>' title"Xem chi tiết"><%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%></a>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Left"/>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(1)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(2)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(c)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(3) = (1) + (2)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>					
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(4)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(6)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(7)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(5) + (7)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG) )
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>	
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(8)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(10)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(11)"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG, "{0:#,##0}")%></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px" />
								</asp:TemplateField>								
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="(9) + (11)"  HeaderStyle-Height="10px">									
                                    <ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                                + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)), "#,###") %></font>
									</ItemTemplate>
								    <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>
                                								
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(5+7) - (9+11)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)) 
                                            + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))) 
                                            - (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                            + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)))  , "#,###") %></font>
									 </ItemTemplate>
                                     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
                                </asp:TemplateField>
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(12) = (1) + (c) - (5)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr(format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT)) 
                                                        + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NAM_TRUOC_CHUYEN_SANG)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)), "#,###") %></font>
									 </ItemTemplate>
                                     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px" />
                                </asp:TemplateField>
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(13) = (2) - (7)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %></font>
									 </ItemTemplate>
								     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>		
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.GIA_TRI_THUC_HIEN)) , "#,###") %></font>	
									 </ItemTemplate>
								     <HeaderStyle Height="10px" HorizontalAlign="Center"/>
                                     <ItemStyle HorizontalAlign="Right" Width="120px"/>
								</asp:TemplateField>	
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <font class='a<%# Eval(GRID_GIAI_NGAN.ID)%>'><%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.SO_CHUA_GN)) , "#,###") %></font>
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
