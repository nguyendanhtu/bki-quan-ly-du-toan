<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F004_Danh_sach_chuong_loai_khoan_muc.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F004_Danh_sach_chuong_loai_khoan_muc" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<div style="text-align: center;">
				<br />
				<span style="font-weight: bold">DANH SÁCH CHƯƠNG LOẠI KHOẢN MỤC</span>
			</div>
			<div style="color: black; text-align: center; margin-top: 20px;">
				<span>Từ khóa tìm kiếm: </span>
				<asp:TextBox runat="server" ID="m_txt_tu_khoa_tim_kiem" CssClass="form-control" Style="width: 200px;"></asp:TextBox>
				<asp:Button CssClass="btn btn-sm btn-primary" runat="server" Text="Tìm kiếm" ID="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click" />
			</div>
			<div style="width: 800px; margin: 20px auto;">
				<asp:GridView
					runat="server"
					ID="m_grv_bao_cao_giao_von"
					Style="width: 100%;"
					AutoGenerateColumns="False"
					EnableModelValidation="True"
					CssClass="cssGrid"
					OnDataBound="m_grv_bao_cao_giao_von_DataBound">
					<AlternatingRowStyle BackColor="White" />

					<Columns>
						<asp:BoundField DataField="TEN_LOAI_CLM">
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Top" />
						</asp:BoundField>
						<asp:BoundField DataField="MA_SO" HeaderText="Mã số chương - loại - mục">
							<ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Width="100px" />
						</asp:BoundField>
						<asp:BoundField DataField="TEN" HeaderText="Chương - loại - mục" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="240px" />
						</asp:BoundField>
						<asp:BoundField DataField="MA_SO_KTM" HeaderText="Mã số khoản - tiểu mục" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Center" Width="100px" />
						</asp:BoundField>
						<asp:BoundField DataField="TEN_KTM" HeaderText="Khoản - tiểu mục" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Left" Width="240px" />
						</asp:BoundField>
					</Columns>

				</asp:GridView>
			</div>
			<div style="text-align: center">
				<asp:Button runat="server" CssClass="btn btn-sm btn-primary" Text="Xuất file excel" ID="m_cmd_xuat_excel"></asp:Button>
			</div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress ID="updateprogress1" runat="server">
		<ProgressTemplate>
			<div class="cssloadwapper">
				<div class="cssloadcontent">
					<img src="../images/loadingbar.gif" alt="" />
					<p>
						đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
