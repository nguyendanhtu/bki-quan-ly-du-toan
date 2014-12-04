<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f204_nhap_giao_ke_hoach_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.f204_nhap_giao_ke_hoach_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<%--<script type="text/javascript">
        $(document).ready(function () {
            function tinhTongChiTx() {
                var so_tien_ns = parseInt(document.getElementById('<%=m_txt_ctx_so_tien_ns.ClientID%>').value);
                var so_tien_qbt = parseInt(document.getElementById('<%=m_txt_ctx_so_tien_qbt.ClientID%>').value);
                m_lbl_tong_chi_tx.innerHTML = so_tien_ns + so_tien_qbt;
            }

            function tinhTongChiKtx() {
                var so_tien_ns = parseInt(document.getElementById('<%=m_txt_cktx_so_tien_ns.ClientID%>').value);
                var so_tien_qbt = parseInt(document.getElementById('<%=m_txt_cktx_so_tien_qbt.ClientID%>').value);
                m_lbl_tong_chi_ktx.innerHTML = so_tien_ns + so_tien_qbt;
            }

            $("#<%=m_txt_ctx_so_tien_ns.ClientID%>").change(function () {
                tinhTongChiTx();
            });

            $("#<%=m_txt_ctx_so_tien_qbt.ClientID%>").change(function () {
                tinhTongChiTx();
            });

            $("#<%=m_txt_cktx_so_tien_ns.ClientID%>").change(function () {
                tinhTongChiKtx();
            });

            $("#<%=m_txt_cktx_so_tien_qbt.ClientID%>").change(function () {
                tinhTongChiKtx();
            });
        });
    </script>--%>
	<style type="text/css">
		.cssTextBox {
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table cellspacing="0" cellpadding="2" style="width: 900px; margin: auto" class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_title" runat="server" Text="Nhập giao kế hoạch - Nguồn Quỹ bảo trì" CssClass="cssPageTitle"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="4">
						<asp:Panel ID="m_pnl_thong_tin_ve_qd_giao_ke_hoach" GroupingText="Thông tin chung" runat="server">
							<table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
								<tr>
									<td colspan="2">
										<asp:Label ID="m_lbl_mess_qd" runat="server" CssClass="cssManField"></asp:Label>
									</td>
								</tr>
								<tr>
									<td style="width: 15%" align="right">
										<span class="cssManField">Số QĐ</span>
									</td>
									<td style="width: 85%" align="left">
										<asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="cssTextBox" Width="20%"></asp:TextBox>
										<asp:DropDownList ID="m_ddl_quyet_dinh" runat="server" Width="21%" Visible="false" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
										<asp:Button ID="m_cmd_chon_qd_da_nhap" Text="Chọn QĐ" OnClick="m_cmd_chon_qd_da_nhap_Click" runat="server" CssClass="cssButton" Height="24px" Width="98px" />
									</td>
								</tr>
								<tr>
									<td align="right"><span class="cssManField">Nội dung</span></td>
									<td align="left">
										<asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" Width="50%" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td align="right"><span class="cssManField">Ngày tháng</span></td>
									<td align="left">
										<asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox" Width="20%" placeholder="dd/MM/yyyy"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td></td>
									<td colspan="1" align="left">
										<asp:Button ID="m_cmd_luu_qd" Text="Lưu QĐ" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_luu_qd_Click" />
										<asp:Button ID="m_cmd_nhap_qd_moi" Text="Nhập QĐ mới" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_nhap_qd_moi_Click" />
										<asp:HiddenField ID="m_hdf_id_quyet_dinh" runat="server" />
										<asp:HiddenField ID="m_hdf_form_mode" runat="server" />
									</td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Panel ID="m_pnl" runat="server" GroupingText="Nội dung chi tiết">
							<table cellspacing="0" cellpadding="2" style="width: 99%;" border="0">
								<tr>
									<td colspan="2">
										<asp:Label ID="m_lbl_mess_detail" runat="server" CssClass="cssManField"></asp:Label>
									</td>
								</tr>
								<tr>
								
									<td colspan="2" style="text-align:center">
										<asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" CssClass="cssManField" ForeColor="Blue" Text="KH đầu năm" GroupName="loai" Checked="true" AutoPostBack="true" OnCheckedChanged="m_rdb_kh_dau_nam_CheckedChanged" />
										<asp:RadioButton ID="m_rdb_bo_sung" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Bổ sung" GroupName="loai" AutoPostBack="true" OnCheckedChanged="m_rdb_bo_sung_CheckedChanged" />
										<asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Điều chỉnh" GroupName="loai" AutoPostBack="true" OnCheckedChanged="m_rdb_dieu_chinh_CheckedChanged" />
										<asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
									</td>
								</tr>
								<tr>
									<td style="width:50%">
										<asp:Panel ID="m_pnl_chi_thuong_xuyen" runat="server" GroupingText="Chi thường xuyên">
											<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
												<tr>
													<td style="width: 30%;text-align:right">
														<span class="cssManField">Tuyến quốc lộ</span>
													</td>
													<td style="width: 70%">
														<asp:DropDownList ID="m_ddl_tuyen_quoc_lo" runat="server" Width="100%"></asp:DropDownList>
														<asp:Button ID="m_cmd_them_ql" Text="Thêm QL" runat="server" CssClass="cssButton" Height="24px" Width="98px" Visible="false"/>

													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Kinh phí năm trước chuyển sang</span>
													</td>
													<td style="text-align: left">
														<asp:TextBox ID="m_txt_ctx_so_tien_nam_truoc_chuyen_sang" runat="server" CssClass="cssTextBox" Style="text-align: right" Text="0" Width="100px" AutoPostBack="false"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="width: 30%; text-align: right">
														<span class="cssManField">Kinh phí ngân sách </span>
														&nbsp;</td>
													<td style="width: 70%; text-align: left">
														<asp:TextBox ID="m_txt_ctx_so_tien_ns" runat="server" Style="text-align: right" CssClass="cssTextBox" Text="0" Width="100px" AutoPostBack="false"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Kinh phí quỹ bảo trì</span>
													</td>
													<td style="text-align: left">
														<asp:TextBox ID="m_txt_ctx_so_tien_qbt" runat="server" CssClass="cssTextBox" Style="text-align: right" Text="0" Width="100px" AutoPostBack="false"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Tổng </span>
														&nbsp;</td>
													<td>
														<label class="cssManField" style="text-align: right" id="m_lbl_tong_chi_tx">0</label>
													</td>
												</tr>
												<tr>
													<td style="width: 30%;text-align:right">
														<span class="cssManField">Ghi chú</span>
													</td>
													<td style="width: 70%">
														<asp:TextBox ID="m_txt_ctx_noi_dung" TextMode="MultiLine" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
													</td>
												</tr>
												<tr>

													<td colspan="2" align="center">
														<asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_insert_Click" />
														<asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_update_Click" />
														<asp:Button ID="m_cmd_ctx_delete" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_ctx_cancel_Click" />
														<asp:HiddenField ID="m_hdf_id_quoc_lo" runat="server" />
													</td>
												</tr>
											</table>
										</asp:Panel>
									</td>
									<td style="width: 50%">
										<asp:Panel ID="m_pnl_chi_khong_thuong_xuyen" runat="server" GroupingText="Chi không thường xuyên">
											<table style="width: 99%;" border="0">
												<tr>
													<td style="width: 30%; text-align: right">
														<span class="cssManField">Tên dự án</span>
													</td>
													<td style="width: 70%">
														<asp:TextBox ID="m_txt_ten_du_an" runat="server" CssClass="cssTextBox" placeholder="Dự án a" Width="105px"></asp:TextBox>
														<asp:DropDownList ID="m_ddl_du_an" runat="server" Width="150px" Visible="false" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_du_an_SelectedIndexChanged"></asp:DropDownList>
														<asp:Button ID="m_cmd_chon_du_an" runat="server" Text="Chọn DA" ToolTip="Chọn dự án" OnClick="m_cmd_chon_du_an_Click"/>
														<asp:Button ID="m_cmd_chon_quoc_lo" runat="server" Text="Chọn QL" ToolTip="Chọn quốc lộ" OnClick="m_cmd_chon_quoc_lo_Click"/>

													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Kinh phí năm trước chuyển sang</span>
													</td>
													<td style="text-align: left">
														<asp:TextBox ID="m_txt_cktx_so_tien_nam_truoc_chuyen_sang" runat="server" CssClass="cssTextBox" Style="text-align: right" Text="0" Width="100px" AutoPostBack="false"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Số tiền ngân sách</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_cktx_so_tien_ns" runat="server" Text="0" Style="text-align: right" CssClass="cssTextBox" Width="100px"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Số tiền quỹ bảo trì</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_cktx_so_tien_qbt" runat="server" CssClass="cssTextBox" Text="0" Style="text-align: right" Width="100px"></asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="width: 30%; text-align: right">
														<span class="cssManField">Tổng</span>
													</td>
													<td style="width: 70%">
														<label class="cssManField" style="text-align: right" id="m_lbl_tong_chi_ktx">0</label>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">
														<span class="cssManField">Ghi chú</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_cktx_noi_dung" TextMode="MultiLine" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
													</td>
												</tr>
												<tr>

													<td colspan="2" style="text-align: center">
														<asp:Button ID="m_cmd_cktx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_insert_Click" />
														<asp:Button ID="m_cmd_cktx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_update_Click" />
														<asp:Button ID="m_cmd_cktx_cancel" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px" OnClick="m_cmd_cktx_cancel_Click" />
														<asp:HiddenField ID="m_hdf_id_du_an" runat="server" />
													</td>
												</tr>
											</table>
										</asp:Panel>
									</td>
								</tr>
								<tr>
									<td colspan="2">
										<asp:Label ID="m_lbl_mess_grid" runat="server" CssClass="cssManField"></asp:Label>
									</td>
								</tr>
								<tr>
									<td colspan="2" align="center">
										<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="False"
											CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
											AllowSorting="True" PageSize="30" ShowHeader="true"
											DataKeyNames="ID"
											EmptyDataText="Không có dữ liệu phù hợp"
											OnRowCommand="m_grv_RowCommand"
											OnPageIndexChanging="m_grv_PageIndexChanging"
											OnRowDataBound="m_grv_RowDataBound">
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
												<asp:TemplateField HeaderText="STT" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="2%" HeaderStyle-Height="40px">
													<ItemTemplate>
														<%# Container.DataItemIndex + 1 %>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
													<ItemTemplate>
														<asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
															CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
														</asp:LinkButton>
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="2%">
													<ItemTemplate>
														<asp:LinkButton ID="m_lbl_update" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
															CommandName="Sua" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
														</asp:LinkButton>
													</ItemTemplate>
													<ItemStyle HorizontalAlign="Center"></ItemStyle>
												</asp:TemplateField>
												<asp:BoundField DataField="display" HeaderText="Công trình, dự án" />

												<asp:TemplateField HeaderText="Kinh phí năm trước chuyển sang" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_nam_truoc_chuyen_sang_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_NAM_TRUOC_CHUYEN_SANG).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Kinh phí Ngân sách" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_NS).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Kinh phí Quỹ bảo trì" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval(V_GD_GIAO_KH.SO_TIEN_QUY_BT).ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
													<ItemTemplate>
														<asp:Label ID="m_lbl_tong_so_tien" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#format_so_tien(Eval("TONG").ToString()) %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="ghi_chu" HeaderText="Ghi chú" />
												<asp:BoundField DataField="ten" HeaderText="Loại" />

											</Columns>
										</asp:GridView>
									</td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
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


