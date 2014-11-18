<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true" CodeFile="f604_dm_quyet_dinh.aspx.cs" Inherits="DanhMuc_f604_dm_quyet_dinh" %>

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
                        <asp:Label ID="m_lbl_title" runat="server" Text="Cập nhật thông tin quyết định" CssClass="cssPageTitle"></asp:Label>
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
                        <span class="cssManField">Loại quyết định</span>
                    </td>
                    <td style="width: 70%">
                        <asp:RadioButton ID="m_rdb_giao_ke_hoach" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Giao kế hoạch" GroupName="loai" Checked="true" />
                        <asp:RadioButton ID="m_rdb_giao_von" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Giao vốn" GroupName="loai" />
                    </td>

                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Số quyết định</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_so_quyet_dinh" runat="server" Width="50%" CssClass="cssTextBox" placeholder=""></asp:TextBox></td>
                </tr>
                <tr>

                    <td align="right">
                        <span class="cssManField">Nội dung</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_noi_dung" runat="server" Width="80%" CssClass="cssTextBox" placehoder=""></asp:TextBox></td>
                </tr>
                <tr>
                    <td align="right">
                        <span class="cssManField">Ngày tháng</span>
                    </td>
                    <td>
                        <asp:TextBox ID="m_txt_ngay_thang" runat="server" Width="50%" CssClass="cssTextBox" placeholder="dd/mm/yyyy"></asp:TextBox></td>
                </tr>
                <tr>
                    <td></td>
                    <td>
                        <asp:Button ID="m_cmd_insert" Text="Thêm quyết định" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                        <asp:Button ID="m_cmd_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
                        <asp:Button ID="m_cmd_cancel" Text="Xoá trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" />

                    </td>
                </tr>
            </table>
            <table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
                <tr>
                    <td class="cssPageTitleBG" colspan="4">
                        <asp:Label ID="m_lbl_grid_title" runat="server" Text="Danh sách quyết định" CssClass="cssPageTitle"></asp:Label>
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
                                <asp:BoundField DataField="so_quyet_dinh" HeaderText="Đơn vị" />
                                <asp:BoundField DataField="noi_dung" HeaderText="Nội dung" />
                                <%--<asp:BoundField DataField="loai" HeaderText="Loại" />--%>
                                <asp:BoundField DataField="ngay_thang" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ngày tháng" />
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

