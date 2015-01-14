<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f204_nhap_giao_ke_hoach_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.f204_nhap_giao_ke_hoach_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
        
     </style>
    <script type="text/javascript">
		function tinhTongChiTx() {
			var so_tien_ntcs = parseInt(document.getElementById("<%=m_txt_so_tien_nam_truoc_chuyen_sang.ClientID%>").value.split(',').join('').split('.').join(''));
			var so_tien_qbt = parseInt(document.getElementById('<%=m_txt_so_tien.ClientID%>').value.split(',').join('').split('.').join(''));
			m_lbl_tong_chi_ktx.innerHTML = getFormatedNumberString(so_tien_qbt + so_tien_ntcs);
		}
		$(document).ready(function () {

			$("#<%=m_txt_so_tien.ClientID%>").bind({
				blur: function () { tinhTongChiTx(); }
			});
			$("#<%=m_txt_so_tien_nam_truoc_chuyen_sang.ClientID%>").bind({
				blur: function () { tinhTongChiTx(); }
			});
		    $('.select2').select2();
		    $("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
		});
		function pageLoad(sender, args) {
			if (args.get_isPartialLoad()) {

				$("#<%=m_txt_so_tien.ClientID%>").bind({
					blur: function () { tinhTongChiTx(); }
				});
				$("#<%=m_txt_so_tien_nam_truoc_chuyen_sang.ClientID%>").bind({
					blur: function () {tinhTongChiTx(); }
				});
			    $('.select2').select2();
			    $("#<%=m_txt_ngay_thang.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
			}
		}

	</script>
	<style type="text/css">
		.cssFontBold {
			font-weight: bold;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<%--<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>--%>
			<table id="main_table" style="width: 1100px; margin: auto" class="cssTable table" border="0">
				<tr>
					<td class="cssPageTitleBG" colspan="4" style="text-align: center">
						<asp:Label ID="m_lbl_title" runat="server" Width="100%" Text="Nhập giao kế hoạch - Nguồn Quỹ bảo trì" CssClass="cssPageTitle" Font-Bold="true"></asp:Label>
					</td>
				</tr>
				<tr>
					<td colspan="2" valign="top" style="width: 420px">
						<table class="cssTable table" style="width: 100%">
							<tr>
								<td colspan="4">
									<asp:Panel ID="m_pnl_thong_tin_ve_qd_giao_ke_hoach" GroupingText="Thông tin chung" runat="server">
										<table class="table bordertop0" style="width: 100%;" border="0">
											<tr>
												<td colspan="2">
													<asp:Label ID="m_lbl_mess_qd" runat="server" CssClass="cssManField"></asp:Label>
												</td>
											</tr>
											<tr>
												<td style="text-align: right"><span>Loại quyết định (*)</span></td>
												<td colspan="3">
													<asp:RadioButton ID="m_rdb_kh_dau_nam" style="margin-left: 10px;" cssclass="radio-inline" runat="server" Text="KH đầu năm" GroupName="loai" Checked="true" AutoPostBack="true" />
													<asp:RadioButton ID="m_rdb_bo_sung" cssclass="radio-inline" runat="server" Text="Bổ sung" GroupName="loai" AutoPostBack="true" />
													<asp:RadioButton ID="m_rdb_dieu_chinh" cssclass="radio-inline" runat="server" Text="Điều chỉnh" GroupName="loai" AutoPostBack="true" />
													<asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
												</td>
											</tr>
											<tr>
												<td style="width: 40%; text-align: right">
													<span>Số QĐ (*)</span>
												</td>
												<td style="width: 35%">
													<asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="form-control" Width="150px" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
													<asp:DropDownList ID="m_ddl_quyet_dinh" CssClass="select2" runat="server" Width="155px" Visible="false" OnSelectedIndexChanged="m_ddl_quyet_dinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>

												</td>
												<td style="width: 25%; text-align: right">
													<asp:Button ID="m_cmd_chon_qd_da_nhap" CssClass="btn" Text="Chọn QĐ" OnClick="m_cmd_chon_qd_da_nhap_Click" runat="server" /></td>
												<%--<td style="width: 20%"></td>--%>
											</tr>
											<tr>
												<td style="text-align: right"><span>Ngày tháng (*)</span></td>
												<td>
													 <div id="datetimepicker1" class="input-group date datepicker" style="width: 210px;">
                                                         <asp:TextBox ID="m_txt_ngay_thang" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox form-control  date-start" Height="30px" Width="164px"></asp:TextBox>
                                                         <span class="input-group-addon"><span class="glyphicon-calendar glyphicon"></span>
                                                         </span>
                                                    </div>
												</td>
											</tr>
											<tr>
												<td style="text-align: right"><span>Nội dung (*)</span></td>
												<td colspan="3">
													<asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox form-control" TextMode="MultiLine" Rows="3" Width="100%" ></asp:TextBox>
												</td>
											</tr>
											<tr>
												<td></td>
												<td colspan="2" style="text-align: center">
													<asp:Button ID="m_cmd_luu_qd" CssClass="btn" Text="Lưu QĐ" runat="server" OnClick="m_cmd_luu_qd_Click" />
													<asp:Button ID="m_cmd_nhap_qd_moi" CssClass="btn" Text="Nhập QĐ mới" runat="server" OnClick="m_cmd_nhap_qd_moi_Click" />
													<asp:HiddenField ID="m_hdf_id_quyet_dinh" runat="server" />
													<asp:HiddenField ID="m_hdf_form_mode" runat="server" />
											</tr>
										</table>
									</asp:Panel>
								</td>
							</tr>
							<tr>
								<td>
									<asp:Panel ID="m_pnl" runat="server" GroupingText="Chi tiết quyết định">
										<table class="table"style="width: 100%;" border="0">
											<tr>
												<td colspan="3">
													<asp:Label ID="m_lbl_mess_detail" CssClass="cssManField" runat="server"></asp:Label>
												</td>
											</tr>
											<tr>
												<td style="text-align:right">Chi theo (*)</td>
												<td colspan="2">
													<asp:RadioButton ID="m_rdb_theo_quoc_lo" cssclass="radio-inline" Checked="true"  runat="server" Text="Theo Quốc lộ/dự án" GroupName="chi_theo" AutoPostBack="true" OnCheckedChanged="m_rdb_theo_quoc_lo_CheckedChanged" />
													<br />
													<asp:RadioButton ID="m_rdb_theo_chuong_loai_khoan_muc" cssclass="radio-inline" AutoPostBack="true" OnCheckedChanged="m_rdb_theo_chuong_loai_khoan_muc_CheckedChanged" runat="server" Text="Theo Loại khoản mục" GroupName="chi_theo" />
												</td>
											</tr>
											<tr>
												<td style="text-align: right">Loại nhiệm vụ (*)</td>
												<td colspan="2">
													<asp:DropDownList ID="m_ddl_loai_nhiem_vu" cssclass="select2" runat="server" Width="190px"></asp:DropDownList>
												</td>
											</tr>
											
											<asp:Panel ID="m_pnl_cong_trinh" runat="server">
												<tr>
													<td style="text-align: right">Công trình /Quốc lộ (*)</td>
													<td style="text-align: left">
														<asp:TextBox ID="m_txt_quoc_lo" runat="server" CssClass="cssTextBox form-control" Visible="false" Width="150px"></asp:TextBox>
														<asp:DropDownList ID="m_ddl_cong_trinh" runat="server" CssClass="select2" Width="155px" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
													</td>
													<td>
														<asp:Button ID="m_cmd_them_quoc_lo" CssClass="btn" Style="width: 80px" Text="Nhập mới" OnClick="m_cmd_them_quoc_lo_Click" runat="server" />
														<asp:Button ID="m_cmd_chon_quoc_lo" CssClass="btn" Style="width: 80px" Text="Chọn" Visible="false" OnClick="m_cmd_chon_quoc_lo_Click" runat="server" />
													</td>
												</tr>
												<tr>
													<td style="text-align: right">Tên dự án (*)</td>
													<td style="text-align: left">
														<asp:TextBox ID="m_txt_du_an" runat="server" CssClass="cssTextBox form-control" Visible="false" Width="150px"></asp:TextBox>
														<asp:DropDownList ID="m_ddl_du_an" runat="server" CssClass="select2" Width="155px" AutoPostBack="true"></asp:DropDownList>
													</td>
													<td>
														<asp:Button ID="m_cmd_chon_du_an" CssClass="btn" Style="width: 80px" Text="Chọn" Visible="false" OnClick="m_cmd_chon_du_an_Click" runat="server" />
														<asp:Button ID="m_cmd_them_du_an" CssClass="btn" Style="width: 80px" Text="Nhập mới" OnClick="m_cmd_them_du_an_Click" runat="server" />
													</td>
												</tr>
											</asp:Panel>
											<asp:Panel ID="m_pnl_chuong_loai_khoan_muc" runat="server">
												<tr>
													<td style="text-align: right">
														<span>Chương</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_chuong" cssclass="select2 cssDorpdownlist" runat="server" Width="176px" ></asp:DropDownList>
													</td>
												</tr>
												<tr>
													<td style="text-align: right">Loại (*)</span></td>

													<td>
														<asp:DropDownList ID="m_ddl_loai" cssclass="select2 cssDorpdownlist" Width="176px" runat="server" 
															OnSelectedIndexChanged="m_ddl_loai_SelectedIndexChanged" AutoPostBack="true">
														</asp:DropDownList>
													</td>

												</tr>
												<tr>
													<td style="text-align:right">
														<span>Khoản (*)</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_khoan" cssclass="select2 cssDorpdownlist" Width="176px" runat="server" ></asp:DropDownList>
													</td>
												</tr>
												<tr>
													<td style="text-align:right">
														<span>Mục (*)</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_muc" cssclass="select2 cssDorpdownlist" Width="176px" runat="server" OnSelectedIndexChanged="m_ddl_muc_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
													</td>
												</tr>
												<tr>

													<td style="text-align:right">
														<span>Tiểu mục</span>
													</td>
													<td>
														<asp:DropDownList ID="m_ddl_tieu_muc" cssclass="select2 cssDorpdownlist" Width="176px" runat="server">
														</asp:DropDownList>
													</td>
												</tr>
												<tr>
													<td style="text-align:right">
														<span>Nội dung dự toán (*)</span>
													</td>
													<td>
														<asp:TextBox ID="m_txt_noi_dung_du_toan" placehorder="Nội dung dự toán" CssClass="form-control" Width="176px" runat="server">
														</asp:TextBox>
													</td>
												</tr>
												<tr>
													<td style="text-align:right">
														<span>Loại</span>
													</td>
													<td>
														<asp:RadioButton ID="m_rdb_chi_thuong_xuyen" CssClass="radio-inline" runat="server" Text="Chi thường xuyên/tự chủ" GroupName="loai_chi" Checked="true" /><br />
														<asp:RadioButton ID="m_rdb_chi_khong_thuong_xuyen"  CssClass="radio-inline" runat="server" Text="Chi không thường xuyên/tự chủ" GroupName="loai_chi" />
													</td>
												</tr>
											</asp:Panel>
											<tr>
												<td style="text-align: right">
													<span>Kinh phí năm trước chuyển sang</span>
												</td>
												<td colspan="2" style="text-align: left">
													<asp:TextBox ID="m_txt_so_tien_nam_truoc_chuyen_sang" runat="server" CssClass="csscurrency" Style="text-align: right" Text="0" Width="170px" AutoPostBack="false"></asp:TextBox>(đ)
												</td>
											</tr>
											<tr>
												<td style="text-align: right">
													<asp:Label ID="m_lbl_so_tien" runat="server" Text="Kinh phí Quỹ bảo trì (*)"></asp:Label>
												</td>
												<td colspan="2">
													<asp:TextBox ID="m_txt_so_tien" runat="server" CssClass="csscurrency" Text="0" Style="text-align: right" Width="170px"></asp:TextBox>(đ)
												</td>
											</tr>
											<tr>
												<td style="width: 30%; text-align: right">
													<span>Tổng</span>
												</td>
												<td colspan="2" style="width: 70%">
													<label style="text-align: right" id="m_lbl_tong_chi_ktx">0</label>
												</td>
											</tr>
											<tr>
												<td style="text-align: right">
													<span>Ghi chú</span>
												</td>
												<td colspan="2">
													<asp:TextBox ID="m_txt_ghi_chu" TextMode="MultiLine" runat="server" Rows="4" CssClass="cssTextBox form-control" Width="100%"></asp:TextBox>
												</td>
											</tr>
											<tr>

												<td colspan="3" style="text-align: center">
													<asp:Button ID="m_cmd_insert" CssClass="btn" Text="Ghi dữ liệu" runat="server" OnClick="m_cmd_insert_Click" />
													<asp:Button ID="m_cmd_update" CssClass="btn" Text="Cập nhật" runat="server" OnClick="m_cmd_update_Click" />
													<asp:Button ID="m_cmd_cancel" CssClass="btn" Text="Huỷ thao tác" runat="server" OnClick="m_cmd_cancel_Click" />
													<asp:HiddenField ID="m_hdf_id_du_an" runat="server" />
												</td>
											</tr>
											<tr>
												<td colspan="3">
													<asp:Label ID="m_lbl_mess_grid" runat="server"></asp:Label>
												</td>
											</tr>
										</table>
									</asp:Panel>
								</td>
							</tr>
						</table>
					</td>
					<td colspan="2" style="vertical-align: top; width: 680px">
						<table style="width: 100%">
							<tr>
								<td>Quyết định số:
									<asp:Label ID="m_lbl_grid_so_quyet_dinh" runat="server" Font-Bold="true"></asp:Label>
									ngày
									<asp:Label ID="m_lbl_grid_ngay" runat="server" Font-Bold="true"></asp:Label>
									về việc
									<asp:Label ID="m_lbl_grid_ve_viec" runat="server" Font-Bold="true"></asp:Label>
									<br />
									Tổng kinh phí:
									<asp:Label ID="m_lbl_grid_tong_tien" runat="server" Font-Bold="false" CssClass="cssManField"></asp:Label>
									đ

								</td>
							</tr>
							<tr>
								<td>
									<asp:GridView ID="m_grv" runat="server" AllowPaging="false" AutoGenerateColumns="False"
										CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
										AllowSorting="True" PageSize="30" ShowHeader="true"
										DataKeyNames="ID"
										EmptyDataText="Không có dữ liệu phù hợp"
										OnRowCommand="m_grv_RowCommand"
										OnPageIndexChanging="m_grv_PageIndexChanging"
										OnRowDataBound="m_grv_RowDataBound">

										<Columns>
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
											<asp:BoundField DataField="NOI_DUNG" HeaderText="Nhiệm vụ chi" />


											<asp:TemplateField HeaderText="Kinh phí năm trước chuyển sang" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:Label ID="m_lbl_so_tien_nam_truoc_chuyen_sang_grid" runat="server"
														Text='<%#format_so_tien(Eval(GRID_GIAO_KH.NTCT).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Kinh phí Ngân sách" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server"
														Text='<%#format_so_tien(Eval(GRID_GIAO_KH.NS).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Kinh phí Quỹ bảo trì" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server"
														Text='<%#format_so_tien(Eval(GRID_GIAO_KH.QUY).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
												<ItemTemplate>
													<asp:Label ID="m_lbl_tong_so_tien" runat="server"
														Text='<%#format_so_tien(Eval(GRID_GIAO_KH.TONG).ToString()) %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>

										</Columns>
									</asp:GridView>
								</td>
							</tr>
						</table>
					</td>
				</tr>

			</table>
		<%--</ContentTemplate>
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
	</asp:UpdateProgress>--%>
</asp:Content>


