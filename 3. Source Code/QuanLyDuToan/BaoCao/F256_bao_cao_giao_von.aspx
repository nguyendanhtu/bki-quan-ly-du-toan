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
            <asp:button runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem"/>
        </div>
        <div style="width:800px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField DataField="NHIEM_VU_CHI" HeaderText="<br />Nhiệm vụ chi <br /> (1)" HtmlEncode="False" />
                    <asp:BoundField DataField="TONG_SO_KE_HOACH" HeaderText="<br />Tổng số kế hoạch <br /> (2)" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_TIEN_QUY_BT" HeaderText="Kinh phí <br />quỹ bảo trì <br /> (3)" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="SO_TIEN_NS" HeaderText="Kinh phí <br />ngân sách <br /> (4)" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TONG" HeaderText="<br />Tổng <br /> (5) = (3) + (4)" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                </Columns>

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button runat="server" Text="Xuất excel" id="m_cmd_xuat_excel"></asp:Button>
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
