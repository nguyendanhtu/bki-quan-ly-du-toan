<%@ Page Title="" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeFile="F101_Dictionary.aspx.cs" Inherits="DanhMuc_Dictionary" %>
<%@ Register Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31BF3856AD364E35"
    TagPrefix="asp" %>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <table cellspacing="0" cellpadding="2" style="width: 100%;" class="cssTable" border="0">
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="lblUser" runat="server" CssClass="cssPageTitle" Text="Danh mục từ điển hệ thống" />
            </td>
        </tr>
        <tr>
            <td colspan="3">
                <asp:ValidationSummary ID="vdsCategory" runat="server" CssClass="cssManField" Font-Bold="true" />
                <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField" />
            </td>
        </tr>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <asp:Label ID="Label4" CssClass="cssManField" runat="server" Text="Loại từ điển" />
            </td>
            <td style="width: 30%;">
                <asp:DropDownList ID="m_cbo_loai_tu_dien" runat="server" Width="264px" CssClass="cssDorpdownlist" />
            </td>
            <td style="width: 5%;">
                <asp:CustomValidator ID="m_cvt_loai_tu_dien" runat="server" ControlToValidate="m_cbo_loai_tu_dien"
                    ErrorMessage="Bạn phải chọn Loại từ điển" Display="Static" Text="*" />
            </td>
        </tr>
        <tr>
            <td align="right" style="width: 15%;">
                <asp:Label ID="lblFullName" CssClass="cssManField" runat="server" Text="Mã từ điển" />
            </td>
            <td style="width: 30%;">
                <asp:TextBox ID="m_txt_ma_tu_dien" CssClass="cssTextBox" runat="server" MaxLength="64"
                    Width="96%" />
            </td>
            <td style="width: 5%;">
                <asp:CustomValidator ID="m_ctv_ma_tu_dien" runat="server" ControlToValidate="m_txt_ma_tu_dien"
                    ErrorMessage="Bạn phải nhập Mã từ điển" Display="Static" Text="*" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAnswer0" runat="server" CssClass="cssManField" Text="Tên ngắn" />
            </td>
            <td align="left">
                <asp:TextBox ID="m_txt_ten_ngan" AccessKey="m" runat="server" CssClass="cssTextBox"
                    Width="96%" />
            </td>
            <td>
                <asp:CustomValidator ID="m_ctv_ten_tu_ngan" runat="server" ControlToValidate="m_txt_ten_ngan"
                    ErrorMessage="Bạn phải nhập Tên ngắn" Display="Static" Text="*" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblAnswer" runat="server" CssClass="cssManField" Text="Tên" />
            </td>
            <td align="left">
                <asp:TextBox ID="m_txt_ten" AccessKey="m" runat="server" CssClass="cssTextBox" Width="96%" />
            </td>
            <td>
                <asp:CustomValidator ID="m_ctv_ten" runat="server" ControlToValidate="m_txt_ten"
                    ErrorMessage="Bạn phải nhập Tên" Display="Static" Text="*" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="m_lbl_ghi_chu" runat="server" CssClass="cssManField" Text="Ghi Chú" />
            </td>
            <td align="left">
                <asp:TextBox ID="m_txt_ghi_chu" AccessKey="m" runat="server" CssClass="cssTextBox"
                    Width="96%" TextMode="MultiLine" Height="52px" />
            </td>
        </tr>
        <tr>
            <td align="right">
                &nbsp;
            </td>
            <td valign="top" colspan="2">
                <asp:HiddenField ID="m_hdf_id_dm_tu_dien" runat="server" Visible="False" />
            </td>
        </tr>
        <tr>
            <td>
            </td>
            <td colspan="2" align="left">
                <asp:Button ID="m_cmd_tao_moi" AccessKey="c" CssClass="cssButton" runat="server"
                    Width="98px" Height="24px" Text="Tạo mới(c)" OnClick="m_cmd_tao_moi_Click" />&nbsp;
                <asp:Button ID="m_cmd_cap_nhat" AccessKey="u" CssClass="cssButton" runat="server"
                    Width="98px" Height="24px" Text="Cập nhật(u)" OnClick="m_cmd_cap_nhat_Click" />&nbsp;
                <asp:Button ID="btnCancel" AccessKey="r" CssClass="cssButton" runat="server" Width="98px"
                    Height="24px" Text="Xóa trắng(r)" OnClick="btnCancel_Click" />
            </td>
        </tr>
        <tr>
            <td class="cssPageTitleBG" colspan="3">
                <asp:Label ID="Label11" runat="server" CssClass="cssPageTitle" Text="Danh sách từ điển hệ thống" />
            </td>
        </tr>
        <tr>
            <td align="left">
                <asp:Label ID="m_lbl_thong_bao" Visible="false" runat="server" CssClass="cssManField" />
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="Label5" CssClass="cssManField" runat="server" Text="Loại từ điển" />
            </td>
            <td>
                <asp:DropDownList ID="m_cbo_loai_tu_dien_grv" runat="server" Width="264px" AutoPostBack="True"
                    OnSelectedIndexChanged="m_cbo_loai_tu_dien_grv_SelectedIndexChanged" />
            </td>
        </tr>
        <tr>
            <td align="center" colspan="3" style="height: 450px;" valign="top">
                <asp:GridView ID="m_grv_dm_tu_dien" runat="server" AutoGenerateColumns="False" Width="100%"
                    DataKeyNames="ID" OnRowDeleting="m_grv_dm_tu_dien_RowDeleting" OnSelectedIndexChanging="m_grv_dm_tu_dien_SelectedIndexChanging"
                    CellPadding="4" ForeColor="#333333" GridLines="Both" CssClass="cssGrid">
                    <AlternatingRowStyle BackColor="White" />
                    <Columns>
                        <asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center">
                            <ItemTemplate>
                                <%# Container.DataItemIndex + 1 %></ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ID_LOAI_TU_DIEN" HeaderText="Loại từ điển" Visible="False">
                            <ItemStyle HorizontalAlign="Left" Width="4%"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="MA_TU_DIEN" ItemStyle-HorizontalAlign="Center" HeaderText="Mã từ điển">
                            <ItemStyle HorizontalAlign="Left"></ItemStyle>
                        </asp:BoundField>
                        <asp:BoundField DataField="TEN_NGAN" HeaderText="Tên ngắn" />
                        <asp:BoundField DataField="TEN" HeaderText="Tên" />
                        <asp:BoundField DataField="GHI_CHU" ItemStyle-HorizontalAlign="Center" HeaderText="Ghi chú">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:BoundField>
                        <asp:CommandField HeaderText="Xóa" DeleteText="Xóa" ShowDeleteButton="True" ItemStyle-HorizontalAlign="Center" ButtonType="Image" DeleteImageUrl="../Images/Button/deletered.png">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>  
                        </asp:CommandField>
                        <asp:CommandField HeaderText="Sửa" SelectText="Sửa" ShowSelectButton="True" ItemStyle-HorizontalAlign="Center" ButtonType="Image" SelectImageUrl="../Images/Button/edit.png">
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:CommandField>
                    </Columns>
                    <EditRowStyle BackColor="#7C6F57" />
                    <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                    <HeaderStyle BackColor="#810c15" Font-Bold="True" ForeColor="White" />
                    <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                    <RowStyle BackColor="#E3EAEB" />
                    <SelectedRowStyle CssClass="cssSelectedRow" BackColor="#C5BBAF" Font-Bold="True"
                        ForeColor="#333333"></SelectedRowStyle>
                </asp:GridView>
            </td>
        </tr>
    </table>
                </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    <asp:UpdateProgress ID="Updateprogress1" runat="server">
        <ProgressTemplate>
            <div class="cssLoadWapper">
                <div class="cssLoadContent">
                    <img src="../Images/loadingBar.gif" alt="" />
                    <p>
                        Đang gửi yêu cầu, hãy đợi ...</p>
                </div>
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
</asp:Content>
