<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL04_danh_muc_cong_trinh_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL04_danh_muc_cong_trinh_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL04.js"></script>
	<style type="text/css">
		#tblPL04 > thead > tr > th {
			border: 1px solid #000;
		}

		.so_tien {
			width: 80px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<table class="table table-hover " style="margin: auto" id="tblPL04">
		<thead style="vertical-align: middle">
			<tr>
				<th rowspan="2">TT</th>
				<th rowspan="2" style="width: 200px">Công trinh hạng mục</th>
				<th colspan="3">Kế hoạch được giao trong năm</th>
				<th rowspan="2">Giá trị dự toán công trình được duyệt</th>
				<th colspan="3">Giá trị công trình hoàn thành</th>
				<th rowspan="2">Giá trị đề nghị quyết toán trong năm</th>
				<th rowspan="2">Giá trị CTHT đã quyết toán LK đến năm báo cáo </th>
				<th rowspan="2">Giá trị CTHT chuyển năm sau QT</th>
				<th rowspan="2">Kế hoạch còn dư cuối năm</th>
				<th rowspan="3">Thao tác</th>
			</tr>
			<tr>
				<th>Kế hoạch năm trước chưa chi hết chuyển sang</th>
				<th>Theo Quyết định số x</th>
				<th>Quyết định điều chỉnh cuối cùng </th>
				<th>Giá trị CTHT năm trước còn nợ chuyển năm nay</th>
				<th>Giá trị CTHT năm nay</th>
				<th>Cộng</th>
			</tr>
			<tr>
				<th>1</th>
				<th>2</th>
				<th>3</th>
				<th>4</th>
				<th>5=3+4</th>
				<th>6</th>
				<th>7</th>
				<th>8</th>
				<th>9=7+8</th>
				<th>10</th>
				<th>11</th>
				<th>12=9-10</th>
				<th>13=5-10</th>
			</tr>
			<tr>
				<th></th>
				<th>
					<input type="text" id="txtCongTrinh" list="lstCongTrinh" class="form-control" placeholder="Công trình" />
					<datalist id="lstCongTrinh">
						<%foreach (var cong_trinh in lst_pl04.Select(x => x.CONG_TRINH).Distinct().OrderBy(x => x).ToList())%>
						<%{%>
						<option><%=cong_trinh %></option>
						<%}%>
					</datalist>
					<input type="text" id="txtDuAn" class="form-control" placeholder="Dự án" />
				</th>
				<th>
					<input type="text" id="txtKeHoachNamTruocChuaChiHetChuyenSang" class="so_tien" />
				</th>
				<th>
					<input type="text" id="Text1"  class="so_tien giaoKH" />
				</th>
				<th>
					<input type="text" id="txtQuyetDinhDieuChinhCuoiCung"  class="so_tien giaoKH" />
				</th>
				<th>
					<input type="text" id="txtGiaTriDuToanCongTrinhDuocDuyet" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTNamTruocConNoChuyenSangNamNay" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTNamNay" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtCong" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriDeNghiQuyetToanTrongNam" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTDaQuyetToanLKDenNamBaoCao" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTChuyenNamSauQT" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtKeHoachConDuCuoiNam" class="so_tien" />
				</th>
				<th>
					<input type="button" id="btnCapNhat" class="btn btn-sm btn-success" value="Cập nhật" />
					<input type="button" id="btnCancel" class="btn btn-sm btn-default" value="Huỷ" style="width: 74px" />
				</th>
			</tr>
		</thead>
		<tbody>
			<!--Loai nhiem vu-->
			<%foreach (var ten_loai_nhiem_vu in lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).Distinct().ToList()) %>
			<%{%>
			<tr style="font-weight: bold">
				<td><%=ten_loai_nhiem_vu.TT%></td>
				<td><%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money GiaTriDeNghiQuyetToanTrongNam'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money GiaTriCTHTDaQuyetToanLKDenNamBaoCao'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=0 - lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td></td>
			</tr>
			<!--Cong trinh-->
			<%int i = 1; %>
			<%foreach (var cong_trinh in lst_pl04.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
											.Select(x => x.CONG_TRINH)
											.Distinct()
											.OrderBy(x => x)
											.ToList())%>
			<%{%>
			<tr style="font-weight: bold">
				<td><%=i++%></td>
				<td><%=cong_trinh%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%=0%></td>
				<td class='text-right str_money'><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=0 - lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td></td>
			</tr>
			<%foreach (var du_an in lst_pl04.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh)
											.Select(x => new { x.DU_AN ,x.ID})
											.Distinct()
											.OrderBy(x => x.DU_AN)
											.ToList())%>
			<%{%>
			<!--Du an-->
			<tr>
				<td>-</td>
				<td><span class="du_an" 
					cong_trinh="<%=cong_trinh%>"
					ten_loai_nhiem_vu="<%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%>"
					id_giao_dich="<%=du_an.ID %>"
					><%=du_an.DU_AN%></span></td>
				<td class='text-right str_money KeHoachNamTruocChuaChiHetChuyenSang'><%=0%></td>
				<td class='text-right str_money giaoKH'><%=0%></td>
				<td class='text-right str_money QuyetDinhDieuChinhCuoiCung'><%=0%></td>
				<td class='text-right str_money GiaTriDuToanCongTrinhDuocDuyet'><%= lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money GiaTriCTHTNamTruocConNoChuyenSangNamNay'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money GiaTriCTHTNamNay'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY - x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=0 - lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU && x.CONG_TRINH == cong_trinh && x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class="text-center">
					<input type="button" class="btn btn-sm btn-primary" value="Sửa" /></td>
			</tr>
			<%}%>
			<%}%>
			<%}%>
		</tbody>
		<tfoot>
		</tfoot>
	</table>
</asp:Content>
