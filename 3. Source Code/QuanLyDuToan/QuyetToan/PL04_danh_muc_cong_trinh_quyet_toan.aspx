<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL04_danh_muc_cong_trinh_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL04_danh_muc_cong_trinh_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL04.js"></script>
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
	<script type="text/javascript">
		var MaxRecord =<%=lst_pl04.Count%> +'';
		var MaxLNV =<%=lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).OrderBy(x=>x.TT).Distinct().ToList().Count%> +'';
		var MaxCT =<%=lst_pl04.Select(x => new { x.CONG_TRINH, x.TEN_LOAI_NHIEM_VU}).Distinct().ToList().Count%> +'';
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<table class="table table-hover " style="margin: auto" id="tblPL04">
		<thead style="vertical-align: middle">
			<tr>
				<th rowspan="2">TT</th>
				<th rowspan="2" style="width: 200px">Công trinh hạng mục</th>
				<th colspan="<%=lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2 %>">Kế hoạch được giao trong năm</th>
				<th rowspan="2">Giá trị dự toán công trình được duyệt</th>
				<th colspan="3">Giá trị công trình hoàn thành</th>
				<th rowspan="2">Giá trị đề nghị quyết toán trong năm</th>
				<th rowspan="2">Giá trị CTHT đã quyết toán LK đến năm báo cáo </th>
				<th rowspan="2">Giá trị CTHT chuyển năm sau QT</th>
				<th rowspan="2">Kế hoạch còn dư cuối năm</th>
				<th rowspan="3" style="width: 100px"><input type="button" class="btn btn-primary btn-sm" style="height:77px" value="Cập nhật" onclick="gdPL04.updateAll()" /></th>
			</tr>
			<tr>
				<th>Kế hoạch năm trước chưa chi hết chuyển sang</th>
				<%foreach (var qd in lst_giao_kh
							.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()
							.ToList())%>
				<%{%>
				<th><%="Quyết định số "+qd.SO_QUYET_DINH +" ngày "+IP.Core.IPCommon.CIPConvert.ToStr( qd.NGAY_THANG,"dd/MM/yyyy")%></th>
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
					 .Select(x => x.DM_QUYET_DINH.SO_QUYET_DINH)
					 .Distinct()
					 .ToList().Count - 1
					 ; index++)%>
				<%{%>
				<th><%=index+4 %></th>
				<%}%>
				<th><%=index+4 %></th>
				<%
					string strIndexSum = "" + (index + 5);
					strIndexSum += "=";
					for (int j = 0; j < 4; j++)
					{
						if (j <= index + 1)
						{
							strIndexSum += (j + 3) + "+";
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
				<th><%=index+12 %>=<%=index+9 %>-<%=index+10 %></th>
				<th><%=index+13 %>=<%=index+5 %>-<%=index+10 %></th>
			</tr>
		</thead>
		<tbody>
			<!--Loai nhiem vu-->
			<%int classIndex = 0; %>
			<%int LnvIndex=0; %>
			<%int CtIndex=0; %>
			<%foreach (var ten_loai_nhiem_vu in lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).OrderBy(x=>x.TT).Distinct().ToList()) %>
			<%{%>
			<%LnvIndex++; %>
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
				<%foreach (var qd in lst_giao_kh
							  .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							  .OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
							  .Select(x => x.DM_QUYET_DINH.ID)
							  .Distinct()
							  .ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd	&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper())
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
				%></td>
				<%}%>
				<td class='text-right str_money QDDCCC'>
					<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
					%>
				</td>
				<td class='text-right str_money GTDTCTDD <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTNTCNCNN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTNN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money cong <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money DTDNQTTN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTDQTLKDNBC <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTCNSQT <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money KHCDCN  <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%=
						lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
								)
							.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
							.ToList()
							.Sum()
						- lst_pl04
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
			<%CtIndex++; %>
			<tr style="font-weight: bold">
				<td class="text-center"><%=i++%></td>
				<td><%=cong_trinh%></td>
				<td class='text-right str_money %>'>
					<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
					%>
				</td>
				<%foreach (var qd in lst_giao_kh
							  .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							  .OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
							  .Select(x => x.DM_QUYET_DINH.ID)
							  .Distinct()
							  .ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
				%></td>
				<%}%>
				<td class='text-right str_money QDDCCC'>
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
				<td class='text-right str_money lnv GTDTCTDD <%= ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","")%>' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTNTCNCNN' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTNN' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money cong' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
				<td class='text-right str_money DTDNQTTN' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money GTCTHTDQTLKDNBC' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
				<td class='text-right str_money' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU&&x.CONG_TRINH==cong_trinh)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=
						lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
								&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
								)
							.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
							.ToList()
							.Sum()
						- lst_pl04
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
			<%{
		 classIndex++;%>
			<!--Du an-->
			<tr>
				<td class="text-center">-</td>
				<td><span class="du_an"
					cong_trinh="<%=cong_trinh%>"
					ten_loai_nhiem_vu="<%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%>"
					id_giao_dich="<%=du_an.ID %>"><%=du_an.DU_AN%></span></td>
				<td class='text-right str_money KeHoachNamTruocChuaChiHetChuyenSang <%=classIndex %>'>
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
							.OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
							.Select(x => x.DM_QUYET_DINH.ID)
							.Distinct()
							.ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd
							&&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.ToUpper()==du_an.DU_AN.ToUpper()
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
				%></td>
				<%}%>
				<td class='text-right str_money QDDCCC <%=classIndex %>'>
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
				<td class='text-right '>
					<input type="text" value="<%= lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%>"
						class="so_tien form-control input_control format_so_tien  GiaTriDuToanCongTrinhDuocDuyet GTDTCTDD <%=classIndex %> <%=cong_trinh.Replace(" ","").Replace(",","")%> da" ma_so_parent='<%="ct_"+CtIndex %>'/>

				</td>
				<td class='text-right'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%>"
						class="so_tien form-control input_control format_so_tien GTCTHTNTCNCNN GiaTriCTHTNamTruocConNoChuyenSangNamNay <%=classIndex %>"  ma_so_parent='<%="ct_"+CtIndex %>'/>
				</td>
				<td class='text-right '>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%>"
						class="so_tien form-control input_control format_so_tien GTCTHTNN  GiaTriCTHTNamNay <%=classIndex %>"  ma_so_parent='<%="ct_"+CtIndex %>'/>
				</td>
				<td class='text-right'>
					<span class='str_money cong  <%=classIndex %>'   ma_so_parent='<%="ct_"+CtIndex %>'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%>
					</span></td>
				<td class='text-right '>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%>"
						class="so_tien form-control input_control format_so_tien DTDNQTTN GiaTriDeNghiQuyetToanTrongNam <%=classIndex %>"  ma_so_parent='<%="ct_"+CtIndex %>'/>

				</td>
				<td class='text-right'>
					<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%>"
						class="so_tien form-control input_control format_so_tien GiaTriCTHTDaQuyetToanLKDenNamBaoCao GTCTHTDQTLKDNBC <%=classIndex %>"  ma_so_parent='<%="ct_"+CtIndex %>'/>

				</td>
				<td class='text-right str_money GTCTHTCNSQT <%=classIndex %>'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY - x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class='text-right str_money KHCDCN <%=classIndex %>'><%=0 - lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
				<td class="text-center">
					<input type="button" class="btn btn-sm btn-success cap_nhat" value="Đã cập nhật" onclick="gdPL04.update(this)" />
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
