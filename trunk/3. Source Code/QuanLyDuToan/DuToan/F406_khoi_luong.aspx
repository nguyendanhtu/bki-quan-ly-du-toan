﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F406_khoi_luong.aspx.cs" Inherits="QuanLyDuToan.DuToan.F406_khoi_luong" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssFontBold
         {
			font-weight: bold;
		}
	</style>
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $('.select2').select2();
                $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
            $('.select2').select2();
            $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" style="width: 900px; margin: auto" class="cssTable table" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4">
						<asp:Label ID="m_lbl_title" runat="server" Width="100%" Text="Nhập Giao vốn - Nguồn Quỹ bảo trì" CssClass="cssPageTitle"></asp:Label>
					</td>
				</tr>

				<tr>
					<td colspan="2">
						<asp:Label ID="m_lbl_mess_qd" runat="server" CssClass="cssManField"></asp:Label>
					</td>
				</tr>
				<tr>
					<td style="width: 20%; text-align: right">Loại nhiệm vụ</td>
					<td>
						<asp:DropDownList ID="m_ddl_loai_nhiem_vu" runat="server" CssClass="select2" Width="250px">
						</asp:DropDownList>
					</td>
				</tr>
				<tr>

					<td style="text-align: right">
						<span>Ngày tháng</span>
					</td>
					<td>
						<asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox datepicker" Width="100px" placeholder="dd/MM/yyyy"></asp:TextBox>
						<asp:Button ID="m_cmd_xem_khoi_luong" CssClass="btn" runat="server" Text="Tải dữ liệu" OnClick="m_cmd_xem_khoi_luong_Click" />
					</td>
				</tr>

				<tr>
					<td colspan="2">
						<table style="width: 99%;" border="0">
							<tr>
								<td colspan="2">
									<asp:Label ID="m_lbl_mess_detail" CssClass="cssManField" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td colspan="3" style="text-align: center">
									<asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
								</td>
							</tr>
							<tr>
								<td colspan="4">
									<asp:Label ID="m_lbl_mess_grid" CssClass="cssManField" runat="server"></asp:Label>
								</td>
							</tr>
							<tr>
								<td colspan="3">
									<asp:GridView ID="m_grv" runat="server" AllowPaging="false" AutoGenerateColumns="False"
										CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
										AllowSorting="True" PageSize="30" ShowHeader="true"
										DataKeyNames="ID"
										EmptyDataText="Không có dữ liệu phù hợp"
										OnRowCommand="m_grv_RowCommand"
										OnPageIndexChanging="m_grv_PageIndexChanging"
										OnRowDataBound="m_grv_RowDataBound"
										HeaderStyle-Height="70px">
										<Columns>
											<asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%" Visible="false">
												<ItemTemplate>
													<asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
														CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
													</asp:LinkButton>
												</ItemTemplate>
												<ItemStyle HorizontalAlign="Center"></ItemStyle>
											</asp:TemplateField>
											<asp:BoundField DataField="NOI_DUNG" HeaderText="Nhiệm vụ chi" />
											<asp:TemplateField HeaderText="Kế hoạch chi" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:Label ID="m_lbl_so_tien_ke_hoach_grid" runat="server" Style="text-align: right"
														Text='<%#format_so_tien(Eval(GRID_GIAO_VON.KE_HOACH_CHI).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Giá trị thực hiện đã nghiệm thu A-B" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:TextBox ID="m_txt_so_tien_ngan_sach_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
														Text='<%#format_so_tien(Eval(GRID_GIAO_VON.QUY).ToString()) %>' Visible='<%# !visible_label_so_tien(Eval("ID").ToString()) %>'></asp:TextBox>
													<asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
														Visible='<%# visible_label_so_tien(Eval("ID").ToString()) %>' Text='<%#format_so_tien(Eval(GRID_GIAO_VON.NS).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Số chưa giải ngân cho nhà thầu theo ng/thu A-B" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:TextBox ID="m_txt_so_tien_quy_bao_tri_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
														Visible='<%# !visible_label_so_tien(Eval("ID").ToString()) %>'
														Text='<%#format_so_tien(Eval(GRID_GIAO_VON.NS).ToString()) %>'></asp:TextBox>
													<asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server" Style="text-align: right" CssClass="csscurrency"
														Visible='<%# visible_label_so_tien(Eval("ID").ToString()) %>'
														Text='<%#format_so_tien(Eval(GRID_GIAO_VON.QUY).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<%-- <asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="m_lbl_so_tien_tong_grid" runat="server" Style="text-align: right"
                                                                        Text='<%#format_so_tien(Eval(GRID_GIAO_VON.TONG).ToString()) %>'></asp:Label>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>--%>
											<%-- <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
                                                                <ItemTemplate>
                                                                    <asp:LinkButton ID="m_link_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                                                                        CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
                                                                    </asp:LinkButton>
                                                                </ItemTemplate>
                                                                <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                            </asp:TemplateField>--%>
										</Columns>
									</asp:GridView>
								</td>
							</tr>
							<tr>
								<td colspan="3" style="text-align: center">
									<asp:Button ID="m_cmd_cap_nhat" runat="server" CssClass="btn"  Text="Ghi dữ liệu" OnClick="m_cmd_cap_nhat_Click" />
									<asp:Button ID="m_cmd_xoa_trang" runat="server" CssClass="btn" Text="Huỷ thao tác" OnClick="m_cmd_xoa_trang_Click" />
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			</div>
                            
						
					</td>
				</tr>
			</table>

		</ContentTemplate>
		<Triggers>
			<%--<asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />--%>
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

