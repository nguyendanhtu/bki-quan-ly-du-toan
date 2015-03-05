﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F356_bao_cao_giai_ngan.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F356_bao_cao_giai_ngan" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <div style="text-align:center;">
            <span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
		    <br />
		    <span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
		    <br />
		    <br />
		    <span style="font-weight: bold">BÁO CÁO GIẢI NGÂN</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
            <span> Từ ngày: </span><asp:textbox runat="server" id="m_txt_tu_ngay" style="width:200px;text-align:right"></asp:textbox>
            <span> Đến ngày: </span><asp:textbox runat="server" id="m_txt_den_ngay" style="width:200px; text-align:right"></asp:textbox>
            <asp:button runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click"/>
        </div>
        <div style="width:920px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giai_ngan" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="NHIEM_VU_CHI" HeaderText="<br />Nhiệm vụ chi <br /> (1)" HtmlEncode="False" />
                    <asp:BoundField DataField="TONG_SO_KE_HOACH" HeaderText="<br />Tổng số kế hoạch <br /> (2)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="<br />Tổng số vốn giao <br /> (3)" HtmlEncode="False" DataField="TONG_SO_VON_GIAO" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px"/>
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_TIEN_QUY_BT" HeaderText="Kinh phí thanh toán &lt;br /&gt;quỹ bảo trì &lt;br /&gt; (4)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_TIEN_NS" HeaderText="Kinh phí thanh toán&lt;br /&gt;ngân sách &lt;br /&gt; (5)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG" HeaderText="&lt;br /&gt;Tổng &lt;br /&gt; (6) = (4) + (5)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                </Columns>
                <AlternatingRowStyle BackColor="White" />
						
            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button cssclass="btn" runat="server" Text="Xuất file excel" id="m_cmd_xuat_excel" OnClick="m_cmd_xuat_excel_Click"></asp:Button>
        </div>
    </ContentTemplate>
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
