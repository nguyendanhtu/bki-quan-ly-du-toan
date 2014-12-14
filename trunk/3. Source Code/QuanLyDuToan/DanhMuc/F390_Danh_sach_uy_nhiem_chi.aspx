<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F390_Danh_sach_uy_nhiem_chi.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F390_Danh_sach_uy_nhiem_chi" %>
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
		    <span style="font-weight: bold">DANH SÁCH ỦY NHIỆM CHI</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
            <span> Từ ngày: </span><asp:textbox runat="server" id="m_txt_tu_ngay" style="width:200px; text-align:right"></asp:textbox>
            <span> Đến ngày: </span><asp:textbox runat="server" id="m_txt_den_ngay" style="width:200px; text-align:right"></asp:textbox>
            <asp:button runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem"/>
        </div>
        <div style="width:800px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:BoundField HeaderText="Số quyết định" HtmlEncode="False" >
                    <ItemStyle Width="200px" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Nội dung" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="200px" />
                    </asp:BoundField>
                </Columns>

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button runat="server" Text="Xuất excel" id="m_cmd_xuat_excel"></asp:Button>
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
