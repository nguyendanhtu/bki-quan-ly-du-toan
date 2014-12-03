<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F620_bao_cao_giao_von.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F620_bao_cao_giao_von" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div style="margin:0px auto;width:600px;height:1px;">
        <div style="float:left; width:300px;">
            <asp:label runat="server" text="Từ ngày"></asp:label>
            <asp:TextBox ID="m_txt_tu_ngay" runat="server"></asp:TextBox>
        </div>
        <div style="float:left; width:300px;">
            <asp:label runat="server" text="Đến ngày"></asp:label>
            <asp:TextBox ID="m_txt_den_ngay" runat="server"></asp:TextBox>
        </div>
    </div>
    <div style="margin:30px auto;width:600px;height:50px;">
        <asp:label runat="server" text="Nhập số quyết định"></asp:label>
        <asp:TextBox ID="m_txt_so_quyet_dinh" runat="server"></asp:TextBox>
        <asp:Button ID="m_cmd_tim_kiem" runat="server" Text="Tìm" OnClick="m_cmd_tim_kiem_Click" />
    </div>
    <asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
					CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
					AllowSorting="True" PageSize="60"
					EmptyDataText="Không có dữ liệu phù hợp" EnableModelValidation="True">
        <Columns>
            <asp:BoundField DataField="SO_QUYET_DINH" HeaderText="Quyết định" />
            <asp:BoundField DataField="NGAY_THANG" HeaderText="Ngày quyết định" />
            <asp:BoundField DataField="NOI_DUNG" HeaderText="Nội dung" />
            <asp:BoundField DataField="TEN_DU_AN_CONG_TRINH" HeaderText="Dự án" />
            <asp:BoundField DataField="LOAI_QUYET_DINH" HeaderText="Loại quyết định" />
            <asp:BoundField DataField="LOAI_DU_AN_CONG_TRINH" HeaderText="Loại dự án - công trình" />
            <asp:BoundField DataField="SO_TIEN" HeaderText="Số tiền" />
        </Columns>
    </asp:GridView>
</asp:Content>
