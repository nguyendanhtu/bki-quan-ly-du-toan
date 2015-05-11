<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QT_QBT_GRID_PL04.ascx.cs" Inherits="QuanLyDuToan.UserControls.QT_QBT_GRID_PL04" %>
<table class="table table-hover " style=" width: <%=(lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2)*88+1074%>px"
			id="tblPL04">
			<thead style="vertical-align: middle">
				<tr>
					<th rowspan="2" class="tt">TT</th>
					<th rowspan="2" class="cong_trinh_hang_muc">Công trinh hạng mục</th>
					<% int v_col_num= lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count;
		//if (v_col_num==0)
		//{
		//	v_col_num = 1;
			
		//}%>
					<th colspan="<%=v_col_num+2 %>"
						style="width: <%=(lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2)*65%>px">Kế hoạch được giao trong năm</th>
					<th rowspan="2" class="gia_tri">Giá trị dự toán công trình được duyệt</th>
					<th colspan="3" class="gia_tri">Giá trị công trình hoàn thành</th>
					<th rowspan="2" class="gia_tri">Giá trị đề nghị quyết toán trong năm</th>
					<th rowspan="2" class="gia_tri">Giá trị CTHT đã quyết toán LK đến năm báo cáo </th>
					<th rowspan="2" class="gia_tri">Giá trị CTHT chuyển năm sau QT</th>
					<th rowspan="2" class="gia_tri">Kế hoạch còn dư cuối năm</th>
					<th rowspan="3" style="width: 100px">
						<input type="button" class="btn btn-primary btn-sm" style="height: 77px" value="Cập nhật" onclick="gdPL04.updateAll()" /></th>
				</tr>
				<tr>
					<th class="gia_tri">Kế hoạch năm trước chưa chi hết chuyển sang</th>
					<%foreach (var qd in lst_giao_kh
							.Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()
							.ToList())%>
					<%{%>
					<th class="gia_tri"><%="Quyết định số "+qd.SO_QUYET_DINH +" ngày "+IP.Core.IPCommon.CIPConvert.ToStr( qd.NGAY_THANG,"dd/MM/yyyy")%></th>
					<%}%>
					<th class="gia_tri">Quyết định điều chỉnh cuối cùng </th>
					<th class="gia_tri">Giá trị CTHT năm trước còn nợ chuyển năm nay</th>
					<th class="gia_tri">Giá trị CTHT năm nay</th>
					<th class="gia_tri">Cộng</th>
				</tr>
				<tr>
					<th>1</th>
					<th>2</th>
					<th class="gia_tri">3</th>
					<%int index = 0;
	   for (index = 0; index < lst_giao_kh
					  .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
					  .OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
					  .Select(x => x.DM_QUYET_DINH.SO_QUYET_DINH)
					  .Distinct()
					  .ToList().Count - 1
					  ; index++)%>
					<%{%>
					<th class="gia_tri"><%=index+4 %></th>
					<%}%>
					<%if(v_col_num!=0) 
						{%>
					<th class="gia_tri"><%=index+4 %></th>
					<%}%>
					<%
						string strIndexSum = "" + (index + 5);
						strIndexSum += "=";
						for (int j = 0; j < 3; j++)
						{
							if (j <= index + 1)
							{
								strIndexSum += (j + 3) + "+";
							}
						}
						strIndexSum += "...";
					%>
					<th class="gia_tri"><%=strIndexSum%></th>
					<th class="gia_tri"><%=index+6 %></th>
					<th class="gia_tri"><%=index+7 %></th>
					<th class="gia_tri"><%=index+8 %></th>
					<th class="gia_tri"><%=index+9 %>=<%=index+7 %>+<%=index+8 %></th>
					<th class="gia_tri"><%=index+10 %></th>
					<th class="gia_tri"><%=index+11 %></th>
					<th class="gia_tri"><%=index+12 %>=<%=index+9 %>-<%=index+10 %></th>
					<th class="gia_tri"><%=index+13 %>=<%=index+5 %>-<%=index+10 %></th>
				</tr>
			</thead>
			<tbody>
				<!--Loai nhiem vu-->
				<%int classIndex = 0; %>
				<%int LnvIndex = 0; %>
				<%int CtIndex = 0; %>
				<%foreach (var ten_loai_nhiem_vu in lst_pl04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).OrderBy(x => x.TT).Distinct().ToList()) %>
				<%{%>
				<%LnvIndex++; %>
				<tr style="font-weight: bold">
					<td class="text-center tt"><%=ten_loai_nhiem_vu.TT%></td>
					<td class="cong_trinh_hang_muc"><%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%></td>
					<td class='text-right str_money gia_tri'>
						<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
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
					<td class='text-right str_money gia_tri'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH==qd	&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper())
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
					%></td>
					<%}%>
					<td class='text-right str_money QDDCCC gia_tri'>
						<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
					</td>
					<td class='text-right str_money GTDTCTDD gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
					<td class='text-right str_money GTCTHTNTCNCNN gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
					<td class='text-right str_money GTCTHTNN gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%></td>
					<td class='text-right str_money cong gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
					<td class='text-right str_money DTDNQTTN gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td class='text-right str_money GTCTHTDQTLKDNBC gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
					<td class='text-right str_money GTCTHTCNSQT gia_tri <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td class='text-right str_money KHCDCN gia_tri  <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%=
						lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
								)
							.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
							.ToList()
							.Sum()
						- lst_pl04
							.Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td style="width:100px"></td>
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
					<td ><%=cong_trinh%></td>
					<td class='text-right str_money %>'>
						<%=lst_giao_kh
						.Where(x=>x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()==cong_trinh.ToUpper()
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
							&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()==cong_trinh.Trim().ToUpper()
							&&x.DM_QUYET_DINH.ID==qd
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
					%></td>
					<%}%>
					<td class='text-right str_money QDDCCC'>
						<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.ToUpper()==cong_trinh.ToUpper()
							)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
						%>
					</td>
					<td class='text-right str_money lnv GTDTCTDD gia_tri <%= ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","")%>' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%= lst_pl04
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
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
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
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td class='text-right str_money' ma_so="<%="ct_"+CtIndex %>" ma_so_parent="<%="lnv_"+LnvIndex %>"><%=
						lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
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
						.Where(x=>x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()==cong_trinh.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim().ToUpper()==du_an.DU_AN.Trim().ToUpper()
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
						.Where(x=>x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()==cong_trinh.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim().ToUpper()==du_an.DU_AN.Trim().ToUpper()
							&&x.DM_QUYET_DINH.ID==qd
							)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
					%></td>
					<%}%>
					<td class='text-right str_money QDDCCC <%=classIndex %>'>
						<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
							&&x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN.Trim().ToUpper()==cong_trinh.Trim().ToUpper()
							&&x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN.Trim().ToUpper()==du_an.DU_AN.Trim().ToUpper()
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
							class="so_tien form-control input_control format_so_tien  GiaTriDuToanCongTrinhDuocDuyet GTDTCTDD <%=classIndex %> <%=cong_trinh.Replace(" ","").Replace(",","")%> da" ma_so_parent='<%="ct_"+CtIndex %>' />

					</td>
					<td class='text-right'>
						<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%>"
							class="so_tien form-control input_control format_so_tien GTCTHTNTCNCNN GiaTriCTHTNamTruocConNoChuyenSangNamNay <%=classIndex %>" ma_so_parent='<%="ct_"+CtIndex %>' />
					</td>
					<td class='text-right '>
						<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%>"
							class="so_tien form-control input_control format_so_tien GTCTHTNN  GiaTriCTHTNamNay <%=classIndex %>" ma_so_parent='<%="ct_"+CtIndex %>' />
					</td>
					<td class='text-right'>
						<span class='str_money cong  <%=classIndex %>' ma_so_parent='<%="ct_"+CtIndex %>'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%>
						</span></td>
					<td class='text-right '>
						<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%>"
							class="so_tien form-control input_control format_so_tien DTDNQTTN GiaTriDeNghiQuyetToanTrongNam <%=classIndex %>" ma_so_parent='<%="ct_"+CtIndex %>' />

					</td>
					<td class='text-right'>
						<input type="text" value="<%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%>"
							class="so_tien form-control input_control format_so_tien GiaTriCTHTDaQuyetToanLKDenNamBaoCao GTCTHTDQTLKDNBC <%=classIndex %>" ma_so_parent='<%="ct_"+CtIndex %>' />

					</td>
					<td class='text-right str_money GTCTHTCNSQT <%=classIndex %>'><%=lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_CTHT_NAM_NAY + x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY - x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td class='text-right str_money KHCDCN <%=classIndex %>'><%=0 - lst_pl04
							.Where(x => x.TEN_LOAI_NHIEM_VU == ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU 
								&& x.CONG_TRINH == cong_trinh 
								&& x.ID == du_an.ID)
							.Select(x => x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
					<td class="text-center">
						<input type="button" class="btn btn-sm btn-success cap_nhat" value="Đã cập nhật" onclick="gdPL04.update(this)" style="display:none" />
					</td>
				</tr>
				<%}%>
				<%}%>
				<%}%>
			</tbody>
			<tfoot>
			</tfoot>
		</table>