<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F390_Danh_sach_uy_nhiem_chi.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F390_Danh_sach_uy_nhiem_chi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
        <script>
            function pageLoad(sender, args) {
                if (args.get_isPartialLoad())
                {
                    $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
                }
            }
            $(document).ready(function ()
            {
                $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
            }
           )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<div style="text-align: center;">
				<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
				<br />
				<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
				<br />
				<br />
				<span style="font-weight: bold">DANH SÁCH ỦY NHIỆM CHI</span>
			</div>
			<div style="color: black; text-align: center; margin-top: 20px;">
				<span>Từ khóa tìm kiếm: </span>
				<asp:TextBox runat="server" ID="m_txt_tu_khoa_tim_kiem" Style="width: 200px;"></asp:TextBox>
				<span>Từ ngày: </span>
				<asp:TextBox runat="server" CssClass="datepicker" ID="m_txt_tu_ngay" Style="width: 200px; text-align: right"></asp:TextBox>
				<span>Đến ngày: </span>
				<asp:TextBox runat="server" ID="m_txt_den_ngay" CssClass="datepicker"  Style="width: 200px; text-align: right"></asp:TextBox>
				<asp:Button runat="server" CssClass="btn" Text="Tìm kiếm" ID="m_cmd_tim_kiem" onClick="m_cmd_tim_kiem_Click"/>
			</div>
			<div style="width: 800px; margin: 20px auto;">
				<asp:GridView runat="server" ID="m_grv_bao_cao_giao_von" Style="width: 100%;" AutoGenerateColumns="true" EnableModelValidation="True">
					<Columns>
<%--						<asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Right" Width="200px" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Số quyết định" HtmlEncode="False">
							<ItemStyle Width="200px" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Nguồn" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Số tiền" HtmlEncode="False">
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>--%>
					</Columns>

				</asp:GridView>
			</div>
			<div style="text-align: center">
				<asp:Button runat="server" Text="Xuất excel" ID="m_cmd_xuat_excel"></asp:Button>
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
