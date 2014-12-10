<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F410_bao_cao_tinh_hinh_giao_von.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F410_bao_cao_tinh_hinh_giao_von" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
    <style type="text/css">
        .cssGrid tr td
        {
            padding: 0px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;" class="cssTable" border="0">
                <tr>
                    <td colspan="4" style="text-align: center">
                        <span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
                        <p>
                            <br />
                            <span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
                            <br />
                            <br />
                            <span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIAO VỐN THEO ĐƠN VỊ <%=DateTime.Now.Year.ToString() %></span>
                            <br />
                            <br />
                            <span style="font-weight: bold">Từ ngày
							<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
                            <span>&nbsp; Đến ngày
							<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
                        </p>
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
                        <asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="false"
                            CssClass="cssGrid" Width="80%" CellPadding="0" ForeColor="Black"
                            AllowSorting="True" PageSize="60" ShowHeader="true"
                            EmptyDataText="Không có dữ liệu phù hợp">

                            <Columns>
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--								<asp:BoundField DataField="STT" HeaderText="STT" HeaderStyle-Width="2%" />--%>
                                <asp:BoundField DataField="NHIEM_VU_CHI" HeaderText="Nhiệm vụ chi" HeaderStyle-Width="250px" />
                                <asp:BoundField DataField="TONG_KH" HeaderText="Tổng kế hoạch" HeaderStyle-Width="150px" DataFormatString="N"/>
                                <asp:BoundField DataField="TONG_VON_QBT" HeaderText="Tổng vốn quỹ bảo trì" HeaderStyle-Width="150px" />
                                <asp:BoundField DataField="TONG_VON_NS" HeaderText="Tổng vốn ngân sách" HeaderStyle-Width="150px" />
                                <asp:BoundField DataField="KH_NAM_TRUOC_CHUYEN_SANG" HeaderText="Số tiền năm trước chuyển sang" HeaderStyle-Width="150px" />
                                <asp:BoundField DataField="TONG_VON" HeaderText="Tổng vốn" HeaderStyle-Width="150px" />

                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
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


