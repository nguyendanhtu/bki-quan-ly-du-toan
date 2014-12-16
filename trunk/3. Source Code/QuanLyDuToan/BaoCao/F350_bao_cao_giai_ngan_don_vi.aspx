﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F350_bao_cao_giai_ngan_don_vi.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F350_bao_cao_giai_ngan_don_vi" %>

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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
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
                        <span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIẢI NGÂN CÁC NGUỒN VỐN NĂM  <%=DateTime.Now.Year.ToString() %></span>
                        <br />
                        <span style="font-weight: bold">ĐƠN VỊ: <asp:Label runat="server" Text="Label" ID="m_txt_ten_don_vi"></asp:Label></span>
                        <br />                        
                        <span>&nbsp;Tìm kiếm:
                            <asp:TextBox ID="m_txt_tim_kiem" runat="server"></asp:TextBox>
                        <br />
                        <span>&nbsp;Loại nhiệm vụ</span>
                            <asp:DropDownList ID="m_ddl_loai_nv" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_loai_nv_SelectedIndexChanged"></asp:DropDownList></span>
                        <span>&nbsp; Công trình
                            <asp:DropDownList ID="m_ddl_cong_trinh" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged"></asp:DropDownList></span>
                        <span>&nbsp; Dự án
                            <asp:DropDownList ID="m_ddl_du_an" runat="server" Width="100px"></asp:DropDownList></span>
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
                        <asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" OnClick="m_cmd_xuat_excel_Click" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="false"
							CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60" ShowHeader="true"
							EmptyDataText="Không có dữ liệu phù hợp" OnRowCreated="m_grv_RowCreated">

							<Columns>
								<asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderText="a" HeaderStyle-Width="2%" HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Container.DataItemIndex + 1 %>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField ItemStyle-HorizontalAlign="Left" HeaderText="b" HeaderStyle-Width="150px" HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(GRID_GIAI_NGAN.NOI_DUNG)%>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="1"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<a href="F156_bao_cao_giao_kh_quy_bt_theo_qd.aspx<%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.STT)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CHA)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID) ) %>"" 
                                            title"Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT, "{0:#,##0}")%></a>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="2"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>                                
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="3=1+2"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>					
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="4"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="5"  HeaderStyle-Height="10px">									
									<ItemTemplate>
                                        <a href="F256_bao_cao_giao_von_quy_bt_theo_qd.aspx<%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.STT)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CHA)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID) ) %>"" 
                                            title"Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG, "{0:#,##0}")%></a>										
									</ItemTemplate>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="6"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="7"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>	
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="5+7"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# CIPConvert.ToStr( format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_LUY_KE) )
                                                + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_LUY_KE)), "#,###") %>
									</ItemTemplate>
								</asp:TemplateField>	
								<asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="8"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="9"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<a href="F356_bao_cao_giai_ngan_quy_bt_theo_dm.aspx<%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.STT)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CHA)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID) ) %>"" 
                                            title"Xem chi tiết"><%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="10"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TRONG_THANG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="11"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<%# Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG, "{0:#,##0}")%>
									</ItemTemplate>
								</asp:TemplateField>
                                <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderText="9+11"  HeaderStyle-Height="10px">									
									<ItemTemplate>
										<a href="F356_bao_cao_giai_ngan_quy_bt_theo_dm.aspx<%# format_link_to_chi_tiet(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.REPORT_LEVEL)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_DON_VI)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.STT)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID_CHA)
                                                    ,Eval(RPT_BC_TINH_HINH_GIAI_NGAN.ID) ) %>"" 
                                            title"Xem chi tiết"><%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                                + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)), "#,###") %>
									</ItemTemplate>
								</asp:TemplateField>
                                								
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="(5+7)-(9+11)" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<%# CIPConvert.ToStr( (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)) 
                                            + format_so_tien( Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG))) 
                                            - (format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_QBT_TONG)) 
                                            + format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DTT_NS_TONG)))  , "#,###") %>
									 </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="12=1-5" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										<%# CIPConvert.ToStr(format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_QBT))  
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_QBT_TONG)), "#,###") %>
									 </ItemTemplate>
                                </asp:TemplateField>
								<asp:TemplateField  ItemStyle-HorizontalAlign="Right" HeaderText="13=2-7" HeaderStyle-Height="10px" >									
									 <ItemTemplate>
										 <%# CIPConvert.ToStr( format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.KH_NS)) 
                                                        - format_so_tien(Eval(RPT_BC_TINH_HINH_GIAI_NGAN.DN_NS_TONG)), "#,###") %>						
									 </ItemTemplate>
								</asp:TemplateField>		                               				                                
							</Columns>
						</asp:GridView>
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