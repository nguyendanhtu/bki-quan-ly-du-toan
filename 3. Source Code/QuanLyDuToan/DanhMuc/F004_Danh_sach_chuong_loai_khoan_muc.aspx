<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F004_Danh_sach_chuong_loai_khoan_muc.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F004_Danh_sach_chuong_loai_khoan_muc" %>
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
		    <span style="font-weight: bold">DANH SÁCH CHƯƠNG LOẠI KHOẢN MỤC</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
            <asp:button cssclass="btn" runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click"/>
        </div>
        <div style="width:800px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True" OnDataBound="m_grv_bao_cao_giao_von_DataBound">
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
                    <asp:BoundField DataField="TEN_LOAI_CLM" >
                    <ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MA_SO" HeaderText="Mã số chương - loại - mục">
                    <ItemStyle HorizontalAlign="Right" VerticalAlign="Top" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TEN" HeaderText="Chương - loại - mục" HtmlEncode="False" >
                    <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Width="240px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="MA_SO_KTM" HeaderText="Mã số khoản - tiểu mục" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Right" Width="100px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TEN_KTM" HeaderText="Khoản - tiểu mục" HtmlEncode="False">
                    <ItemStyle HorizontalAlign="Left" Width="240px" />
                    </asp:BoundField>
                </Columns>

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button runat="server" Text="Xuất file excel" id="m_cmd_xuat_excel"></asp:Button>
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
