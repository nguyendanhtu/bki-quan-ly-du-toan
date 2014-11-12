<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="F407_bao_cao_tinh_hinh_giai_ngan.aspx.cs" Inherits="DuToan_F407_bao_cao_tinh_hinh_giai_ngan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .auto-style1 {
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <asp:Label ID="m_lbl_tinh_hinh_giai_ngan" runat="server" Text="Tình hình giải ngân" CssClass="cssPageTitle"></asp:Label>
                <span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td style="width: 35%" align="right">
                <span class="cssManField">Từ ngày</span>
            </td>
            <td style="width: 15%" align="right">
                <asp:TextBox ID="m_txt_ngay_bat_dau" runat="server" CssClass="cssTextBox" Width="80%" placeholder="dd/mm/yyyy"></asp:TextBox>
            </td>
            <td style="width: 10%" align="center">
                <span class="cssManField">Đến ngày</span>
            </td>
            <td style="width: 40%">
                <asp:TextBox ID="m_txt_ngay_ket_thuc" runat="server" CssClass="cssTextBox" Width="30%" placeholder="dd/mm/yyyy"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="auto-style1"></td>
            <td align="right" class="auto-style1">
                <asp:Button ID="m_cmd_tao_bao_cao" Text="Tạo Báo Cáo" runat="server" CssClass="cssButton" Height="24px" Width="100px" /></td>
            <td class="auto-style1"></td>
            <td class="auto-style1">
                <asp:Button ID="m_cmd_xuat_excel" Text="Xuất Excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" /></td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="4">
                <asp:Label ID="m_lbl_chi_tiet_bao_cao" runat="server" Text="Chi tiết báo cáo" CssClass="cssPageTitle"></asp:Label>
                <span class="expand-collapse-text"></span>
            </td>
        </tr>
        <tr>
            <td colspan="4" align="center">
                <asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                    CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                    AllowSorting="True" PageSize="30" ShowHeader="true"
                    EmptyDataText="Không có dữ liệu phù hợp" >
                    <AlternatingRowStyle BackColor="White" />
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                    <PagerSettings Position="TopAndBottom" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                    <Columns>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="75px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Nội dung" HeaderStyle-Width="15%" HeaderStyle-Height="75px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField  HeaderStyle-Width="15%" HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;height: 100%; color: white">
                                    <tr>
                                        <td colspan="3">Kế hoạc dự toán được chi cả năm</td>
                                    </tr>
                                    <tr>
                                        <td style="width:33% ; text-align= center">Quỹ BTĐB</td>
                                        <td style="width:33% ; text-align= center">Ngân sách</td>
                                        <td style="width:33% ; text-align= center">Cộng</td>
                                    </tr>
                                </table>
                                 <ItemTemplate>
                            </HeaderTemplate>
                            <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 33%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("QUY_BTDB", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%; border-right: 1px solid gray">
                                                        <%# Eval("NGAN_SACH", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 33%">
                                                        <%# Eval("CONG", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Khối lượng thực hiện" HeaderStyle-Width="6%" HeaderStyle-Height="75px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                            </asp:TemplateField>
                        
                            <asp:TemplateField  HeaderStyle-Width="20%" HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%; color: white">
                                    <tr>
                                        <td colspan="4">Kinh phí đã nhận</td>
                                    </tr>
                                    <tr>
                                        <td colspan="2">Từ quỹ bảo trì</td>
                                        <td colspan="2">Từ ngân sách</td>
                                    </tr>
                                    <tr>
                                        <td style="width:25%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:25%; text-align:center">
                                            Lũy kế từ đầu năm</td>
                                        <td style="width:25%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:25%; text-align:center">
                                            Lũy kế từ đầu năm</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                                <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 25%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: 1px solid gray">
                                                        <%# Eval("LUY_KE_TU_DAU_NAM", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 25%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td >
                                                        <%# Eval("LUY_KE_TU_DAU_NAM", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderStyle-Width="30%" HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%; color: white">
                                    <tr>
                                        <td colspan="6">Kinh phí đã thanh toán</td>
                                    </tr>
                                    <tr>
                                        <td colspan="3">Quỹ BTĐB</td>
                                        <td colspan="3">Ngân sách</td>
                                    </tr>
                                    <tr>
                                        <td style="width:16.6%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:16.7%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:16.7%; text-align:center">
                                            Lũy kế từ đầu năm</td>
                                                <td style="width:16.6%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:16.7%; text-align:center">
                                            Trong tháng</td>
                                        <td style="width:16.7%; text-align:center">
                                            Lũy kế từ đầu năm</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                                <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 16.6%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 16.7%; border-right: 1px solid gray">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 16.7%;border-right: 1px solid gray" height="40px">
                                                        <%# Eval("LUY_KE_TU_DAU_NAM", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 16.6%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 16.7%; border-right: 1px solid gray">
                                                        <%# Eval("TRONG_THANG", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 16.7%" >
                                                        <%# Eval("LUY_KE_TU_DAU_NAM", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                        </asp:TemplateField>
                         <asp:TemplateField  HeaderStyle-Width="20%" HeaderStyle-Height="75px">
                            <HeaderTemplate>
                                <table border="1" cellspacing="0" cellpadding="3" width="100%" style="border-collapse: collapse;
                                                height: 100%; color: white">
                                    <tr>
                                        <td colspan="2">Kinh phí còn được nhận</td>
                                    </tr>
                                    <tr>
                                        <td style="width:50%;text-align:center">Từ Quỹ bảo trì</td>
                                        <td style="width:50%;text-align:center">Từ ngân sách</td>
                                    </tr>
                                </table>
                            </HeaderTemplate>
                             <HeaderStyle CssClass="" />
                                        <ItemTemplate>
                                            <table border="0" cellspacing="0" cellpadding="2" width="100%" style="border-collapse: collapse;
                                                text-align: right">
                                                <tr>
                                                    <td style="width: 50%; border-right: 1px solid gray" height="40px">
                                                        <%# Eval("TU_QUY_BAO_TRI", "{0:#,###}")%>
                                                    </td>
                                                    <td style="width: 50%;">
                                                        <%# Eval("TU_NGAN_SACH", "{0:#,###}")%>
                                                    </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Khối lượng còn nợ nhà thầu" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="4%" HeaderStyle-Height="75px">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Ghi chú" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Content>

