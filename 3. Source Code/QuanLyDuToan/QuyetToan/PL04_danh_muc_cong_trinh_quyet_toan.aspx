<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL04_danh_muc_cong_trinh_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL04_danh_muc_cong_trinh_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL04.js"></script>
	<%--<script src="../Scripts/jquery.dataTables.js"></script>
	<script src="../Scripts/jquery.fixedheadertable.min.js"></script>--%>
	<style type="text/css">
		#tblPL04 > thead > tr > th {
			border: 1px solid #000;
		}

		.so_tien {
			width: 85px;
			text-align: right;
		}

		body {
			font-family: "Helvetica Neue", Helvetica, Arial, sans-serif;
			font-size: 11px;
		}

		.form-control {
			/* display: block; */
			padding: 3px 2px;
			font-size: 11px;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<table class="table table-hover " style="margin: auto" id="tblPL04">
		<thead style="vertical-align: middle">
			<tr>
				<th rowspan="2">TT</th>
				<th rowspan="2" style="width: 200px">Công trinh hạng mục</th>
				<th colspan="<%=lst_giao_kh.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH).ToList().Count+2 %>">Kế hoạch được giao trong năm</th>
				<th rowspan="2">Giá trị dự toán công trình được duyệt</th>
				<th colspan="3">Giá trị công trình hoàn thành</th>
				<th rowspan="2">Giá trị đề nghị quyết toán trong năm</th>
				<th rowspan="2">Giá trị CTHT đã quyết toán LK đến năm báo cáo </th>
				<th rowspan="2">Giá trị CTHT chuyển năm sau QT</th>
				<th rowspan="2">Kế hoạch còn dư cuối năm</th>
				<th rowspan="3" style="width: 100px">Thao tác</th>
			</tr>
			<tr>
				<th>Kế hoạch năm trước chưa chi hết chuyển sang</th>
				<%foreach (var qd in lst_giao_kh.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH).OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG).ToList())%>
				<%{%>
				<th><%="Quyết định số "+qd.DM_QUYET_DINH.SO_QUYET_DINH +" ngày "+IP.Core.IPCommon.CIPConvert.ToStr( qd.DM_QUYET_DINH.NGAY_THANG,"dd/MM/yyyy")%></th>
				<%}%>
				<th>Quyết định điều chỉnh cuối cùng </th>
				<th>Giá trị CTHT năm trước còn nợ chuyển năm nay</th>
				<th>Giá trị CTHT năm nay</th>
				<th>Cộng</th>
			</tr>
			<tr>
				<th>1</th>
				<th>2</th>
				<th>3</th>
				<%int index = 0;
	  for (index = 0; index < lst_giao_kh
					 .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
					 .OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
					 .ToList().Count - 1
					 ; index++)%>
				<%{%>
				<th><%=index+4 %></th>
				<%}%>
				<th><%=index+4 %></th>
				<%
					string strIndexSum = "" + (index + 5);
					strIndexSum += "=";
					for (int j = 0; j <4; j++)
					{
						if (j<=index)
						{
							strIndexSum += (j+4)+"+";
						}
					}
					strIndexSum += "...";
				%>
				<th><%=strIndexSum%></th>
				<th><%=index+6 %></th>
				<th><%=index+7 %></th>
				<th><%=index+8 %></th>
				<th><%=index+9 %>=<%=index+7 %>+<%=index+8 %></th>
				<th><%=index+10 %></th>
				<th><%=index+11 %></th>
				<th><%=index+11 %>=<%=index+9 %>-<%=index+10 %></th>
				<th><%=index+12 %>=<%=index+5 %>-<%=index+10 %></th>
			</tr>
			<tr>
				<th></th>
				<th>
					<select class="form-control" style="width: 100%" id="LoaiNhiemVu">
						<%foreach (var lnv in lst_loai_nhiem_vu)%>
						<%{%>
						<option value="<%=lnv.Value %>"><%=lnv.Ten %></option>
						<%}%>
					</select>
					<input type="text" id="txtCongTrinh" class="form-control" list="lstCongTrinh" style="width: 100%" placeholder="Công trình" />
					<datalist id="lstCongTrinh">
						<%foreach (var cong_trinh in lst_pl04.Select(x => x.CONG_TRINH).Distinct().OrderBy(x => x).ToList())%>
						<%{%>
						<option><%=cong_trinh %></option>
						<%}%>
					</datalist>
					<textarea id="txtDuAn" class="form-control" rows="3" style="width: 100%" placeholder="Dự án"></textarea>
				</th>
				<th>
					<span id="lblKeHoachNamTruocChuaChiHetChuyenSang" class="so_tien"></span>
				</th>
				<%for (int i = 0; i < lst_giao_kh.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH).OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG).ToList().Count; i++)%>
				<%{%>
				<th>
					<span id="Text1" class="so_tien giaoKH"></span>
				</th>
				<%}%>
				<th>
					<span id="lblQuyetDinhDieuChinhCuoiCung" class="so_tien giaoKH"></span>
				</th>
				<th>
					<input type="text" id="txtGiaTriDuToanCongTrinhDuocDuyet" class="so_tien form-control format_so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTNamTruocConNoChuyenSangNamNay" class="so_tien form-control format_so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTNamNay" class="so_tien form-control format_so_tien" />
				</th>
				<th>
					<span id="lblCong" class="so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriDeNghiQuyetToanTrongNam" class="so_tien form-control format_so_tien" />
				</th>
				<th>
					<input type="text" id="txtGiaTriCTHTDaQuyetToanLKDenNamBaoCao" class="so_tien form-control format_so_tien" />
				</th>
				<th>
					<span id="lblGiaTriCTHTChuyenNamSauQT" class="so_tien"></span>
				</th>
				<th>
					<span id="lblKeHoachConDuCuoiNam" class="so_tien"></span>
				</th>
				<th>
					<input type="button" id="btnCapNhat" class="btn btn-sm btn-success" value="Cập nhật" />
					<input type="button" id="btnCancel" class="btn btn-sm btn-default" value="Huỷ" style="width: 74px" onclick="gdPL04.cancel()" />
				</th>
			</tr>
		</thead>
		<tbody>
			<!--Loai nhiem vu-->
			<%foreach (var ten_loai_nhiem_vu in lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).Distinct().ToList()) %>
			<%{%>
			<tr style="font-weight: bold">
				<td class="text-center"><%=ten_loai_nhiem_vu.TT%></td>
				<td><%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%></td>
				<td class='text-right str_money'>
					<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
				<%foreach (var qd in lst_giao_kh.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH).OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG).ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd.DM_QUYET_DINH.ID	&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper())
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
						%></td>
				<%}%>
				<td class='text-right str_money'>
					<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
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
				<td class='text-right str_money'><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_mone'><%=lst_pl04
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
				<td class="text-center"><%=i++%></td>
				<td><%=cong_trinh%></td>
				<td class='text-right str_money'>
					<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
				<%foreach (var qd in lst_giao_kh.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH).OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG).ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd.DM_QUYET_DINH.ID	
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
						%></td>
				<%}%>
				<td class='text-right str_money'>
					<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
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
											.Select(x => new { x.DU_AN, x.ID })
											.Distinct()
											.OrderBy(x => x.DU_AN)
											.ToList())%>
			<%{%>
			<!--Du an-->
			<tr>
				<td class="text-center">-</td>
				<td><span class="du_an"
					cong_trinh="<%=cong_trinh%>"
					ten_loai_nhiem_vu="<%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%>"
					id_giao_dich="<%=du_an.ID %>"><%=du_an.DU_AN%></span></td>
				<td class='text-right str_money KeHoachNamTruocChuaChiHetChuyenSang'>
					<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.ToUpper()==du_an.DU_AN.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
				<%foreach (var qd in lst_giao_kh
							.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG).ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd.DM_QUYET_DINH.ID	
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.ToUpper()==du_an.DU_AN.ToUpper()
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
						%></td>
				<%}%>
				<td class='text-right str_money QuyetDinhDieuChinhCuoiCung'>
					<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.ToUpper()==du_an.DU_AN.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
				</td>
				<td class='text-right  GiaTriDuToanCongTrinhDuocDuyet'>
					<input type="text" value="<%= lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%>" class="so_tien form-control format_so_tien" />

				</td>
				<td class='text-right  GiaTriCTHTNamTruocConNoChuyenSangNamNay'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%>" class="so_tien form-control format_so_tien" />
				</td>
				<td class='text-right  GiaTriCTHTNamNay'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%>" class="so_tien form-control format_so_tien" />
				</td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right   GiaTriDeNghiQuyetToanTrongNam'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%>" class="so_tien form-control format_so_tien" />

				</td>
				<td class='text-right str_moneyy GiaTriCTHTDaQuyetToanLKDenNamBaoCao'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%>" class="so_tien form-control format_so_tien" />

				</td>
				<td class='text-right str_money'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY - x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money'><%=0 - lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.DU_AN == du_an.DU_AN)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class="text-center">
					<input type="button" class="btn btn-sm btn-primary" value="Sửa" onclick="gdPL04.editItem(this)" />
					<input type="button" class="btn btn-sm btn-danger" value="Xoá" onclick="gdPL04.deleteItem(this)" />
				</td>
			</tr>
			<%}%>
			<%}%>
			<%}%>
		</tbody>
		<tfoot>
		</tfoot>
	</table>
</asp:Content>
