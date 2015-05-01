<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tudm.aspx.cs" Inherits="QuanLyDuToan.Test.tudm" %>
	<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
		<style type="text/css">
			.loai_nhiem_vu, .loai_khoan, .cong_trinh {
				font-weight: bold;
			}
	
			.form-control {
				width: 100%;
				font-size: 11px;
				background-color: white;
			}
		</style>
		<script src="../Scripts/jquery.linq.js"></script>
		<%--<script src="../Scripts/UI/F104_test.js"></script>--%>
			<script src="../Scripts/linq.js"></script>
			<script type="text/javascript">
				var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
				var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
				var m_str_nguon_ns="<%=m_str_nguon%>";
			</script>
			<script src="../Scripts/UI/F404.js"></script>
	</asp:Content>
	<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
		<div class="col-sm-12 cssPageTitleBG">
			<label id="m_lbl_title" class="cssPageTitle"></label>
		</div>
		<div class="col-sm-12">
			<div class="col-sm-4">
				<select id="m_ddl_don_vi"></select>
			</div>
			<div class="col-sm-4">
				<input type="text" id="m_txt_ngay_thang" placeholder="dd/MM/yyyy" runat="server" class="date-start  datepicker" />
			</div>
			<div class="col-sm-4">
				<input type="button" class="btn btn-sm btn-primary" value="Tải dữ liệu" />
			</div>
		</div>
		<div class="col-sm-12">
			<table style="width: 100%; border: 1px solid black" class="table table-hover" id="F404">
				<thead>
					<tr>
						<th>Nhiệm vụ chi</th>
						<th style="width: 100px" class="qbt">Giá trị thực hiện đã nghiệm thu A-B</th>
						<th style="width: 100px" class="ns">Giá trị thực hiện đã nghiệm thu A-B</th>
					</tr>
				</thead>
				<tbody>
					<!--Tong cong-->
					<tr style="font-weight: bold">
						<td class="text-center " id_giao_dich="-1" ma_so="0" ma_so_parent="-1">
							<!--Nhiem vu chi-->Tổng cộng</td>
						<td class="qbt">
							<!--Giá trị thực hiện đã nghiệm thu A-B-->
							<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd.Select(x=>Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU))
						.Sum() %>" />
						</td>
						<td class="ns">
							<!--Giá trị thực hiện đã nghiệm thu A-B-->
							<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Select(x=>Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU_NS))
						.Sum() %>" />
						</td>
					</tr>
					<%var lst_lnv=m_lst_gd .Select(x=>new { ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU , TEN = x.CM_DM_TU_DIEN.TEN , GHI_CHU = x.CM_DM_TU_DIEN.GHI_CHU }) .Distinct() .OrderBy(x => x.GHI_CHU) .ToList();%>
						<%foreach (var lnv in lst_lnv)%>
							<%{%>
								<!--Level 1: Loai nhiem vu-->
								<tr class="loai_nhiem_vu">
									<td id_giao_dich="-1" class="lnv" ma_so_parent="0" ma_so="<%=lnv.ID_LOAI_NHIEM_VU %>">
										<!--Nhiem vu chi-->
										<%=lnv.GHI_CHU+ " - "+lnv.TEN %>
									</td>
									<td class="qbt">
										<!--Giá trị thực hiện đã nghiệm thu A-B-->
										<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
						 .Sum() %>" />
									</td>
									<td class="ns">
										<!--Giá trị thực hiện đã nghiệm thu A-B-->
										<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
						 .Sum() %>" />
									</td>
								</tr>
								<%var lst_cong_trinh=m_lst_gd .Where(x=>x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_CONG_TRINH != null) .Select(x => new { ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU , ID_CONG_TRINH = x.ID_CONG_TRINH , TEN_CONG_TRINH = x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN }) .Distinct() .OrderBy(x =>
									x.TEN_CONG_TRINH) .ToList(); %>
									<!--Level 2: Cong trinh--->
									<%foreach (var cong_trinh in lst_cong_trinh)%>
										<%{%>
											<tr class="cong_trinh">
												<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+" "+cong_trinh.ID_CONG_TRINH %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
													<!--Nhiem vu chi-->
													<%=cong_trinh.TEN_CONG_TRINH %>
												</td>
												<td class="qbt">
													<!--Giá trị thực hiện đã nghiệm thu A-B-->
													<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
								.Sum()%>" />
												</td>
												<td class="ns">
													<!--Giá trị thực hiện đã nghiệm thu A-B-->
													<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
								.Sum()%>" />
												</td>
											</tr>
											<%var lst_du_an=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_CONG_TRINH == cong_trinh.ID_CONG_TRINH) .OrderBy(x => x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN) .ToList(); %>
												<%foreach (var du_an in lst_du_an)%>
													<%{%>
														<!--Level 3: Du an-->
														<tr class="du_an" id_giao_dich="<%=du_an.ID %>">
															<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString()+du_an.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString() %>">
																<!--Nhiem vu chi-->
																<%="---" +du_an.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN %>
															</td>
															<td class="qbt">
																<!--Giá trị thực hiện đã nghiệm thu A-B-->
																<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=du_an.SO_TIEN_DA_NGHIEM_THU%>" />
															</td>
															<td class="ns">
																<!--Giá trị thực hiện đã nghiệm thu A-B-->
																<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=du_an.SO_TIEN_DA_NGHIEM_THU_NS%>" />
															</td>
														</tr>
														<%}%>
															<%}%>
																<%var lst_khoan=m_lst_gd .Where(x=>x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN != null) .Select(x => new { ID_KHOAN = x.ID_KHOAN , TEN_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.TEN , MA_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO , TEN_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.TEN
																	, MA_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO }) .Distinct() .OrderBy(x => x.MA_KHOAN) .ToList(); %>
																	<%foreach (var khoan in lst_khoan)%>
																		<%{%>
																			<!--Level 2: Loai Khoan-->
																			<tr class="loai_khoan">
																				<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+" "+khoan.ID_KHOAN %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
																					<!--Nhiem vu chi-->
																					<%="Loại " +khoan.MA_LOAI+ " - "+khoan.MA_KHOAN %>
																				</td>
																				<td class="qbt">
																					<!--Giá trị thực hiện đã nghiệm thu A-B-->
																					<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
								.Sum()%>" />
																				</td>
																				<td class="ns">
																					<!--Giá trị thực hiện đã nghiệm thu A-B-->
																					<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
								.Sum()%>" />
																				</td>
																			</tr>
																			<%var lst_muc=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN == khoan.ID_KHOAN && x.ID_TIEU_MUC == null) .OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO) .ToList();%> .ToList(); %>
																				<%foreach (var muc in lst_muc)%>
																					<%{%>
																						<!--Level 3: Muc-->
																						<tr class="muc" id_giao_dich="<%=muc.ID %>">
																							<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
																								<!--Nhiem vu chi-->
																								<%="---Mục " +muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO+ ": "+muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.TEN %>
																							</td>
																							<td class="qbt">
																								<!--Giá trị thực hiện đã nghiệm thu A-B-->
																								<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=muc.SO_TIEN_DA_NGHIEM_THU%>" />
																							</td>
																							<td class="ns">
																								<!--Giá trị thực hiện đã nghiệm thu A-B-->
																								<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=muc.SO_TIEN_DA_NGHIEM_THU_NS%>" />
																							</td>
																						</tr>
																						<%}%>
																							<%var lst_tieu_muc=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN == khoan.ID_KHOAN && x.ID_TIEU_MUC != null) .OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO) .ToList();%>
																								<!--Level 3: Tieu muc-->
																								<%foreach (var tieu_muc in lst_tieu_muc)%>
																									<%{%>
																										<tr class="tieu_muc" id_giao_dich="<%=tieu_muc.ID %>">
																											<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+tieu_muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
																												<!--Nhiem vu chi-->
																												<%="---Mục " +tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO + ", Tiểu mục "+tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO+ ": " +tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.TEN %>
																											</td>
																											<td class="qbt">
																												<!--Giá trị thực hiện đã nghiệm thu A-B-->
																												<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=tieu_muc.SO_TIEN_DA_NGHIEM_THU%>" />
																											</td>
																											<td class="ns">
																												<!--Giá trị thực hiện đã nghiệm thu A-B-->
																												<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=tieu_muc.SO_TIEN_DA_NGHIEM_THU_NS%>" />
																											</td>
																										</tr>
																										<%}%>
																											<%}%>
																												<%}%>
				</tbody>
				<tfoot>
					<tr>
						<td colspan="3" class="text-center">
							<input type="button" class="btn btn-sm btn-success" id="m_cmd_luu_du_lieu" value="Lưu dữ liệu" />
							<input type="button" class="btn btn-sm btn-default" id="m_cmd_huy_thao_tac" value="Huỷ thao tác" />
						</td>
					</tr>
				</tfoot>
			</table>
		</div>
	</asp:Content>