<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F520_theo_doi_tinh_hinh_giao_von_qbt.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F520_theo_doi_tinh_hinh_giao_von_qbt" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
	<ContentTemplate>
        <div>
                <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" AutoGenerateColumns="False" EnableModelValidation="True">
                    <Columns>
                        <asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị" HtmlEncode="False" >
                        <HeaderStyle Width="200px" CssClass="pinned thpinned"/>
                        <ItemStyle Width="200px" CssClass="pinned"/>
                        </asp:BoundField>
                    </Columns>
                </asp:gridview>
            </div>
            <div>
                <asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" runat="server" cssclass="btn" />
                <asp:Button ID="m_cmd_xuat_excel" Text="Xuất excel" runat="server" cssclass="btn" Enabled="true" />
            </div>
        </ContentTemplate>
	<Triggers>
			<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
	</Triggers>
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
