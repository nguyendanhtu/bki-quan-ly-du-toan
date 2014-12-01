<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f206_nhap_uy_nhiem_chi_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.f206_nhap_uy_nhiem_chi_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>
	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
				<tr>
					<td class="cssPageTitleBG">
						<asp:Label ID="m_lbl_title_nhap_uy_nhiem_chi" runat="server" Text="Nhập ủy nhiệm chi - Nguồn Quỹ bảo trì" CssClass="cssPageTitle"></asp:Label>

					</td>
				</tr>

				<tr>
					<td>
						<asp:Panel ID="m_pnl_thong_tin_thong_tin_uy_nhiem_chi" GroupingText="Thông tin ủy nhiệm chi" runat="server" ForeColor="Blue">
							<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
								<tr>
									<td colspan="2">
										<asp:Label ID="m_lbl_mess_master" runat="server" CssClass="cssManField"></asp:Label></td>
								</tr>
								<tr>
									<td style="width: 10%" align="right">
										<span class="cssManField">Đơn vị trả tiền</span>
									</td>
									<td style="width: 30%">
										<asp:Label ID="m_lbl_don_vi_tra_tien" runat="server" CssClass="cssManField" ForeColor="Blue"></asp:Label>
									</td>
									<td style="width: 15%"></td>
									<td style="width: 20%"></td>
								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Địa chỉ</span>
									</td>
									<td>
										<asp:Label ID="m_lbl_dia_chi" runat="server" CssClass="cssManField" ForeColor="Blue"></asp:Label>
									</td>

								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Số UNC</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_so_unc" runat="server" placeholder="59Qtu" CssClass="cssTextBox" Width="40%"></asp:TextBox>
										<asp:DropDownList ID="m_ddl_unc" Visible="false" runat="server" Width="41%"
											OnSelectedIndexChanged="m_ddl_unc_SelectedIndexChanged" AutoPostBack="true">
										</asp:DropDownList>
										<asp:Button ID="m_cmd_chon_unc" runat="server" Text="Chọn UNC"
											CssClass="cssButton" Width="98px" Height="24px"
											OnClick="m_cmd_chon_unc_Click" />
									</td>
									<td align="right">
										<span class="cssManField">Ngày tháng</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_ngay_thang" runat="server" placeholder="dd/mm/yyyy" CssClass="cssTextBox" Width="40%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Tại kho bạc Nhà nước (NH)</span>
									</td>
									<td>
										<asp:Label ID="m_lbl_tai_kho_bac_nha_nuoc" runat="server" CssClass="cssManField" ForeColor="Blue"></asp:Label>
									</td>
								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Mã TKKT</span>
									</td>
									<td>
										<asp:Label ID="m_lbl_ma_tkkt" runat="server" CssClass="cssManField" ForeColor="Blue"></asp:Label>
										<span class="cssManField">&nbsp;&nbsp; Mã ĐVQHNS:</span>
										<asp:Label ID="m_lbl_ma_dvqhns" runat="server" CssClass="cssManField" ForeColor="Blue"></asp:Label>
									</td>
									<td align="right"><span class="cssManField">&nbsp;&nbsp; Mã CTMT, DA và HTCT:</span></td>
									<td>
										<asp:TextBox ID="m_txt_ma_ctmt_da_htct" Width="40%" runat="server" CssClass="cssTextBox"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td></td>
									<td>
										<asp:Button ID="m_cmd_luu_unc" runat="server" Text="Lưu UNC" CssClass="cssButton" Width="98px" Height="24px"
											OnClick="m_cmd_luu_unc_Click" />
										<asp:Button ID="m_cmd_nhap_moi_unc" runat="server" Text="Nhập mới UNC" CssClass="cssButton" Width="98px" Height="24px"
											OnClick="m_cmd_nhap_moi_unc_Click" />
										<asp:HiddenField ID="m_hdf_id_dm_uy_nhiem_chi" runat="server" />
										<asp:HiddenField ID="m_hdf_form_mode" runat="server" />
									</td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>
				<tr>
					<td>
						<asp:Panel ID="m_pnl_Khoan_thanh_toan" GroupingText="Khoản thanh toán" runat="server" ForeColor="Blue">
							<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
								<tr>
									<td colspan="4">
										<asp:Label ID="m_lbl_mess_detail" runat="server" CssClass="cssManField"></asp:Label></td>
								</tr>
								<tr>
									<td></td>
									<td>
										<asp:RadioButton ID="m_rdb_chi_thuong_xuyen" runat="server" CssClass="cssManField" ForeColor="Blue" Text="Chi thường xuyên"
											GroupName="loai" Checked="true" OnCheckedChanged="m_rdb_chi_thuong_xuyen_CheckedChanged" AutoPostBack="true" />
										<asp:RadioButton ID="m_rdb_chi_khong_thuong_xuyen" runat="server" CssClass="cssManField" AutoPostBack="true"
											ForeColor="Blue" Text="Chi không thường xuyên" GroupName="loai" OnCheckedChanged="m_rdb_chi_khong_thuong_xuyen_CheckedChanged" />
									</td>
								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Nội dung</span>
									</td>
									<td colspan="1">

										<asp:DropDownList ID="m_ddl_quoc_lo" runat="server" CssClass="cssDorpdownlist" Width="89.5%"
											AutoPostBack="true" OnSelectedIndexChanged="m_ddl_quoc_lo_SelectedIndexChanged">
										</asp:DropDownList>
										<asp:DropDownList ID="m_ddl_du_an" runat="server" CssClass="cssDorpdownlist" Width="89.5%"
											AutoPostBack="true" OnSelectedIndexChanged="m_ddl_du_an_SelectedIndexChanged">
										</asp:DropDownList>

									</td>
								</tr>

								<tr>
									<td align="right" style="width: 10%">
										<span class="cssManField">Số tiền nộp thuế</span>
									</td>
									<td style="width: 30%">
										<asp:TextBox ID="m_txt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="40%"></asp:TextBox>
									</td>
									<td align="right" style="width: 15%">
										<span class="cssManField">Số tiền thanh toán cho đơn vị hưởng</span>
									</td>
									<td style="width: 20%">
										<asp:TextBox ID="m_txt_so_tien_thanh_toan_cho_dv_huong" runat="server" CssClass="cssTextBox" Width="40%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td align="right">
										<span class="cssManField">Ghi chú</span>
									</td>
									<td colspan="1">
										<asp:TextBox ID="m_txt_ghi_chu" runat="server" TextMode="MultiLine" CssClass="cssTextBox" Width="89%" placeholder="Ghi rõ nội dung thanh toán"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td></td>
									<td>
										<asp:Button ID="m_cmd_ctx_insert" Text="Thêm" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											OnClick="m_cmd_ctx_insert_Click" />
										<asp:Button ID="m_cmd_ctx_update" Text="Cập nhật" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											OnClick="m_cmd_ctx_update_Click" />
										<asp:Button ID="m_cmd_ctx_cancel" Text="Xóa trắng" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											OnClick="m_cmd_ctx_cancel_Click" />
										<asp:HiddenField ID="m_hdf_id_gd_uy_nhiem_chi" runat="server" />
										<asp:HiddenField ID="m_hdf_id_du_an_cong_trinh" runat="server" />
									</td>
								</tr>
								<tr>
									<td colspan="3">
										<asp:Label ID="m_lbl_mess_grid" runat="server" CssClass="cssManField"></asp:Label></td>
								</tr>
								<tr>
									<td></td>
									<td colspan="3" align="left">
										<asp:GridView ID="m_grv" runat="server" AllowPaging="True" AutoGenerateColumns="false"
											CssClass="cssGrid" Width="60%" CellPadding="0" ForeColor="#333333"
											AllowSorting="True" PageSize="20" ShowHeader="true"
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
												<asp:BoundField DataField="display" HeaderText="Nội dung" />
												<asp:TemplateField HeaderText="Tổng số tiền" ItemStyle-HorizontalAlign="Right">
													<ItemTemplate>
														<asp:Label ID="m_lbl_tong_so_tien_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#CIPConvert.ToStr(Eval("tong_so_tien"),"#,###,##") %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Số tiền nộp thuế" ItemStyle-HorizontalAlign="Right">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_nop_thue_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#CIPConvert.ToStr(Eval("SO_TIEN_NOP_THUE"),"#,###,##") %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Số tiền thanh toán cho đơn vị hưởng" ItemStyle-HorizontalAlign="Right">
													<ItemTemplate>
														<asp:Label ID="m_lbl_so_tien_thanh_toan_cho_don_vi_huong_grid" runat="server"
															CssClass="cssManField" ForeColor="Blue"
															Text='<%#CIPConvert.ToStr(Eval("SO_TIEN_NOP_THUE"),"#,###,##") %>'></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:BoundField DataField="noi_dung" HeaderText="Ghi chú" />
											</Columns>
										</asp:GridView>
									</td>
								</tr>
							</table>
						</asp:Panel>
					</td>
				</tr>

			</table>
			<table cellspacing="0" cellpadding="2" style="width: 99%;" class="cssTable" border="0">
				<tr>
					<td colspan="3">
						<asp:Panel ID="m_pnl_trong_do" runat="server" GroupingText="Trong đó">
							<table cellspacing="0" cellpadding="2" style="width: 100%;" border="0">
								<tr>
									<td colspan="6">
										<asp:Label ID="m_lbl_mess_info_unc" runat="server" CssClass="cssManField"></asp:Label>
									</td>
								</tr>
								<tr>
									<td>NỘP THUẾ</td>
									<td colspan="5" align="right">
										<asp:Button ID="m_cmd_save_info_unc" Text="Lưu thông tin" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											OnClick="m_cmd_save_info_unc_Click" />
										<asp:HyperLink ID="m_cmd_print" runat="server" CssClass="cssButton" Height="24px" Width="98px"
											Target="_blank" Text="Xem bản in" Visible="false">
										</asp:HyperLink>
									</td>
								</tr>
								<tr>
									<td colspan="1">
										<span class="cssManField">Tên đơn vị (Người nộp thuế):  </span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_nt_ten_don_vi" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 10%">
										<span class="cssManField">Mã số thuế:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_nt_ma_so_thue" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã NDKT:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_nt_ma_ndkt" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã chương:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_nt_ma_chuong" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Cơ quan quản lý thu:</span>
									</td>
									<td colspan="3">
										<asp:TextBox ID="m_txt_nt_co_quan_quan_ly_thu" runat="server" CssClass="cssTextBox" Width="92.2%"></asp:TextBox>
									</td>
									<td>
										<span class="cssManField">Mã CQ thu:</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_nt_ma_cq_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">KBNN hạch toán thu:</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_nt_kbnn_hach_toan_thu" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Số tiền nộp thuế (ghi bằng chữ):</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_nt_so_tien_nop_thue" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>THANH TOÁN CHO ĐƠN VỊ HƯỞNG</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Đơn vị nhận tiền:</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_ttdvh_don_vi_nhan_tien" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Mã ĐVQHNS:</span>
									</td>
									<td>
										<asp:TextBox ID="m_txt_ttdvh_ma_dvqhns" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td>
										<span class="cssManField">Địa chỉ:</span>
									</td>
									<td colspan="3">
										<asp:TextBox ID="m_txt_ttdvh_dia_chi" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td style="width: 10%">
										<span class="cssManField">Tài khoản:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ttdvh_tai_khoan" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Mã CTMT, DA, và HTCT:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ttdvh_ma_ctmt_da_htct" runat="server" CssClass="cssTextBox" Width="80%"></asp:TextBox>
									</td>
									<td style="width: 5%">
										<span class="cssManField">Tại KBNN:</span>
									</td>
									<td style="width: 10%">
										<asp:TextBox ID="m_txt_ttdvh_tai_kbnn" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
								<tr>
									<td>
										<span class="cssManField">Số tiền thanh toán cho đơn vị hưởng (ghi bằng chữ):</span>
									</td>
									<td colspan="5">
										<asp:TextBox ID="m_txt_ttdvh_so_tien_thanh_toan" runat="server" CssClass="cssTextBox" Width="100%"></asp:TextBox>
									</td>
								</tr>
							</table>
						</asp:Panel>


					</td>

				</tr>
			</table>

		</ContentTemplate>
		<Triggers>
			<%--<asp:PostBackTrigger ControlID="m_cmd_print" />--%>
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


