<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F256_bao_cao_giao_von.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F256_bao_cao_giao_von" %>
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
		    <span style="font-weight: bold">BÁO CÁO GIAO VỐN</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
            <span> Từ ngày: </span><asp:textbox runat="server" id="m_txt_tu_ngay" style="width:200px; text-align:right"></asp:textbox>
            <span> Đến ngày: </span><asp:textbox runat="server" id="m_txt_den_ngay" style="width:200px; text-align:right"></asp:textbox>
            <asp:button cssclass="btn" runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click"/>
        </div>
        <div style="width:800px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="NHIEM_VU_CHI" HeaderText="<br />Nhiệm vụ chi <br /> (1)" HtmlEncode="False" />
                    <asp:BoundField DataField="TONG_KH" HeaderText="<br />Tổng số kế hoạch <br /> (2)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG_VON_QBT" HeaderText="Kinh phí <br />quỹ bảo trì <br /> (3)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG_VON_NS" HeaderText="Kinh phí <br />ngân sách <br /> (4)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG_VON" HeaderText="<br />Tổng <br /> (5) = (3) + (4)" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                </Columns>

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button cssclas="btn" runat="server" Text="Xuất excel" id="m_cmd_xuat_excel" OnClick="m_cmd_xuat_excel_Click"></asp:Button>
        </div>
    </ContentTemplate>
        </asp:UpdatePanel>
	<asp:updateprogress id="updateprogress1" runat="server">
		<progresstemplate>
			<div class="cssloadwapper">
				<div class="cssloadcontent">
					<img src="../images/loadingbar.gif" alt="" />
					<p>
						đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</progresstemplate>
	</asp:updateprogress>
</asp:Content>
