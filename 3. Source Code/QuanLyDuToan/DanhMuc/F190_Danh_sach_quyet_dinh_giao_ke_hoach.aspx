<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F190_Danh_sach_quyet_dinh_giao_ke_hoach.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F190_Danh_sach_quyet_dinh_giao_ke_hoach" %>
<%@ Import Namespace="WebDS.CDBNames"  %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<div style="text-align: center;">
				<%--<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
				<br />
				<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
				<br />
				<br />--%>
				<span style="font-weight: bold">DANH SÁCH QUYẾT ĐỊNH GIAO KẾ HOẠCH</span>
			</div>
			<div style="color: black; text-align: center; margin-top: 20px;">
				
				<span>Từ ngày: </span>
				<asp:TextBox runat="server" ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy"  Style="width: 100px; text-align: right"></asp:TextBox>
				<span>Đến ngày: </span>
				<asp:TextBox runat="server" ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" Style="width: 100px; text-align: right"></asp:TextBox>
				<br />
				<br />
				<span>Từ khóa tìm kiếm: </span>
				<asp:TextBox runat="server" ID="m_txt_tu_khoa_tim_kiem" Style="width: 200px;"></asp:TextBox>

			</div>
			<div style="text-align: center">
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
				<br />
				<asp:Label ID="m_lbl_info" runat="server" CssClass="cssManField"></asp:Label>
				<br />
				<asp:Button runat="server" Text="Tìm kiếm" ID="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click" />
				<asp:Button runat="server" Text="Xuất excel" ID="m_cmd_xuat_excel" OnClick="m_cmd_xuat_excel_Click"></asp:Button>
			</div>
			<div style="width: 800px; margin: 20px auto;">
				<asp:GridView runat="server" ID="m_grv_bao_cao_giao_von" Style="width: 100%;" AutoGenerateColumns="False" EnableModelValidation="True">
					<Columns>
						<asp:BoundField HeaderText="Số quyết định" HtmlEncode="False" DataField="SO_QUYET_DINH">
							<ItemStyle Width="150px" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG"  DataFormatString="{0:dd/MM/yyyy}" >
							<ItemStyle HorizontalAlign="Right" Width="150px" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:TemplateField HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Right" >
							<ItemTemplate><%#CIPConvert.ToStr(Eval("TONG_TIEN"),"#,###,##") %></ItemTemplate>
						</asp:TemplateField>
					</Columns>

				</asp:GridView>
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
