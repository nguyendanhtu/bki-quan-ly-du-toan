<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f603_dm_du_an.aspx.cs" Inherits="DuToan_f603_dm_du_an" %>

<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_title" runat="server" Text="Cập nhật thông tin dự án, quốc lộ" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true"
                            ValidationGroup="m_vlg_nha" />
                        <asp:Label ID="m_lbl_error" runat="server" CssClass="cssManField" />
                    </td>
                </tr>
                <tr>
                    <td align="right" style="width: 30%">
                        <span class="cssManField">Loại</span>
                    </td>
                    <td style="width: 70%">
                        <asp:RadioButton ID="m_rdb_quoc_lo" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Quốc lộ" GroupName="loai" Checked="true" />
                        <asp:RadioButton ID="m_rdb_khac" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Khác" GroupName="loai" />
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Tên quốc lộ, dự án</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_ten_du_an" runat="server" Width="80%" CssClass="cssTextBox" placeholder="Xây cầu xyz"></asp:TextBox></td>
                </tr>
                <tr>

                    <td align="right">
                        <span class="cssManField">Ghi chú</span>
                    </td>
                    <td>
                        <asp:TextBox ID="TextBox1" runat="server" Width="80%" CssClass="cssTextBox" placehoder=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="m_cmd_insert" Text="Thêm mới" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                        <asp:Button ID="m_cmd_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                        <asp:Button ID="m_cmd_cancel" Text="Xoá trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />

                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_grid_title" runat="server" Text="Danh sách dự án, quốc lộ" CssClass="cssPageTitle"></asp:Label>
                        <span class="expand-collapse-text"></span>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="4" align="center">
                        <asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
                            CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                            AllowSorting="True" PageSize="30" ShowHeader="true"
                            EmptyDataText="Không có dữ liệu phù hợp">
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
                                <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField DataField="ten_don_vi" HeaderText="Đơn vị" />
                                <asp:BoundField DataField="ten_du_an" HeaderText="Tên dự án, công trình" />
                                <asp:BoundField DataField="ghi_chu" HeaderText="Ghi chú" />
                            </Columns>
                        </asp:GridView>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
        <Triggers>
            <%--<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />--%>
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

