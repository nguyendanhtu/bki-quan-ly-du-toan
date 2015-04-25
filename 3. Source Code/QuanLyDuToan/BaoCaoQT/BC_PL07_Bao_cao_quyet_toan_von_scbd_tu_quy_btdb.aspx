<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL07_Bao_cao_quyet_toan_von_scbd_tu_quy_btdb.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL07_Bao_cao_quyet_toan_von_scbd_tu_quy_btdb" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        #tblPL07 > thead > tr > th {
			border: 1px solid #000;
		}
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
     <h3 class="h3 text-center">PL07 -BÁO CÁO QUYẾT TOÁN VỐN SCĐB TỪ NGUỒN QUỸ BTĐB TW</h3>
    <div class="control text-center">
        <span class="lb" style="font-weight: 300; font-size: medium">Năm</span>
        &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_chon_nam" runat="server" Width="80px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_chon_nam_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <br />

    <table id="tblPL07" class="table table-hover " style="margin: auto;width:<%=(lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2)*65+950%>px" id="tblPL04">
		<thead style="vertical-align: middle">
			<tr>
				<th rowspan="2">TT</th>
				<th rowspan="2" style="width:250px">Công trinh hạng mục</th>
				<th colspan="<%=lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2 %>" style="width:<%=(lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO!=WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
							.Select(x => new { x.DM_QUYET_DINH.NGAY_THANG, x.DM_QUYET_DINH.SO_QUYET_DINH })
							.Distinct()			
							.ToList().Count+2)*65%>px">Kế hoạch được giao trong năm</th>
				<th rowspan="2">Giá trị dự toán công trình được duyệt</th>
				<th colspan="3">Giá trị công trình hoàn thành</th>
				<th rowspan="2">Giá trị đề nghị quyết toán trong năm</th>
				<th rowspan="2">Giá trị CTHT đã quyết toán LK đến năm báo cáo </th>
				<th rowspan="2">Giá trị CTHT chuyển năm sau QT</th>
				<th rowspan="2">Kế hoạch còn dư cuối năm</th>
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

				<%
                    string strIndexSum = "" + (index + 4);
                    strIndexSum += "=";
                    for (int j = 0; j < index+1; j++)
                    {
                        if (j <= index + 1)
                        {
                            strIndexSum += (j + index) + "+";
                        }
                    }
                    strIndexSum += "...";
				%>
				<th><%=strIndexSum%></th>
				<th><%=index+5 %></th>
				<th><%=index+6 %></th>
				<th><%=index+7 %></th>
				<th><%=index+8 %>=<%=index+6 %>+<%=index+7 %></th>
				<th><%=index+9 %></th>
				<th><%=index+10 %></th>
				<th><%=index+11 %>=<%=index+8 %>-<%=index+9 %></th>
				<th><%=index+12 %>=<%=index+10 %>-<%=index+11 %></th>
			</tr>
		</thead>
		<tbody>
            <%decimal STT_don_vi = 1;%>
            <%--Theo don vi --%>
            <%foreach (var donvi in lst_don_vi.OrderBy(x => x.TEN_DON_VI).ToList())
            { %>
            <tr style="font-weight: bold">
                <%-- 1. STT --%>
                <td class="text-center"><%=STT_don_vi++ %></td>
                <%-- 2. Ten Don vi --%>
                <td class="text-left"><%=donvi.TEN_DON_VI %></td>
                <%-- 3. Ke hoach nam truoc chuyen sang --%>
                <td class='text-right str_money'>
					<%=lst_giao_kh
						.Where(x=>x.ID_DON_VI == donvi.ID_DON_VI)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
					%>
				</td>
                <%-- 4. Cot cac quyet dinh --%>
                <%foreach (var qd in lst_giao_kh
                              .Where(x => x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO != WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH)
                              .OrderBy(x => x.DM_QUYET_DINH.NGAY_THANG)
                              .Select(x => x.DM_QUYET_DINH.ID)
                              .Distinct()
                              .ToList())%>
				<%{%>
				<td class='text-right str_money'><%=lst_giao_kh
						.Where(x=>x.ID_QUYET_DINH== qd	&& x.ID_DON_VI == donvi.ID_DON_VI)
						.Select(x=>x.SO_TIEN_QUY_BT)
						.ToList()
						.Sum()
				%></td>
				<%}%>
                <%-- 5. Cot Quyet dinh dieu chinh cuoi cung --%>
				<td class='text-right str_money QDDCCC'>
					<%=lst_giao_kh
						.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH&&x.ID_DON_VI == donvi.ID_DON_VI)
						.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.ToList()
						.Sum()
					%>
				</td>
                 <%-- 6. Gia tri cong trinh duoc duyet --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI == donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							.ToList().Sum()%></td>
                <%-- 7. Gia tri cong trinh hoan thanh - Nam truoc con no chuyen sang --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
                             <%-- 8. GTCTHT - Nam Nay --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY)
							.ToList().Sum()%></td>
                <%-- 9. CTCTHT - Cong --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							.ToList().Sum()%></td>
                <%-- 10. DTDNQTTN --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
                <%-- 11. GTCTHTDQTLKDNBC --%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							.ToList().Sum()%></td>
                <%-- 12. GTCTHTCNSQT--%>
				<td class='text-right str_money'><%= lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
                <%-- 13. KHCDCN --%>
				<td class='text-right str_money'><%=
						lst_giao_kh
							.Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								&&x.ID_DON_VI==donvi.ID_DON_VI
								)
							.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
							.ToList()
							.Sum()
						- lst_PL04
							.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							.ToList().Sum()%></td>
            </tr>
                <!--Loai nhiem vu-->
			    <%int classIndex = 0; %>
			    <%int LnvIndex = 0; %>
			    <%int CtIndex = 0; %>
			    <%foreach (var ten_loai_nhiem_vu in lst_PL04.Select(x => new { x.TEN_LOAI_NHIEM_VU, x.TT }).OrderBy(x => x.TT).Distinct().ToList()) %>
			    <%{%>
			    <%LnvIndex++; %>
			    <tr style="font-weight:500">
                    <%-- 1. STT --%>
				    <td class="text-center"><%=ten_loai_nhiem_vu.TT%></td>
                    <%-- 2. Ten Don vi --%>
				    <td><%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU%></td>
                     <%-- 3. Ke hoach nam truoc chuyen sang --%>
				    <td class='text-right str_money'>
					    <%=lst_giao_kh
						    .Where(x=>x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
							    )
						    .Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						    .ToList()
						    .Sum()
					    %>
				    </td>
                    <%-- 4. Cot cac quyet dinh --%>
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
                    <%-- 5. Cot Quyet dinh dieu chinh cuoi cung --%>
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
                    <%-- 6. Gia tri cong trinh duoc duyet --%>
				    <td class='text-right str_money GTDTCTDD <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET)
							    .ToList().Sum()%></td>
                    <%-- 7. Gia tri cong trinh hoan thanh - Nam truoc con no chuyen sang --%>
				    <td class='text-right str_money GTCTHTNTCNCNN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							    .ToList().Sum()%></td>
                    <%-- 8. GTCTHT - Nam Nay --%>
				    <td class='text-right str_money GTCTHTNN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_CTHT_NAM_NAY)
							    .ToList().Sum()%></td>
                    <%-- 9. CTCTHT - Cong --%>
				    <td class='text-right str_money cong <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY)
							    .ToList().Sum()%></td>
                    <%-- 10. DTDNQTTN --%>
				    <td class='text-right str_money DTDNQTTN <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							    .ToList().Sum()%></td>
                    <%-- 11. GTCTHTDQTLKDNBC --%>
				    <td class='text-right str_money GTCTHTDQTLKDNBC <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO)
							    .ToList().Sum()%></td>
                    <%-- 12. GTCTHTCNSQT--%>
				    <td class='text-right str_money GTCTHTCNSQT <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%= lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_CTHT_NAM_NAY+x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY-x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							    .ToList().Sum()%></td>
                    <%-- 13. KHCDCN --%>
				    <td class='text-right str_money KHCDCN  <%=ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.Replace(" ","") %>' ma_so="<%="lnv_"+LnvIndex %>"><%=
						    lst_giao_kh
							    .Where(x=>x.DM_QUYET_DINH.ID_LOAI_QUYET_DINH_GIAO==WebUS.ID_LOAI_GIAO_DICH.DIEU_CHINH
								    &&x.CM_DM_TU_DIEN.TEN.ToUpper()==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU.ToUpper()
								    )
							    .Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
							    .ToList()
							    .Sum()
						    - lst_PL04
							    .Where(x=>x.TEN_LOAI_NHIEM_VU==ten_loai_nhiem_vu.TEN_LOAI_NHIEM_VU)
							    .Select(x=>x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM)
							    .ToList().Sum()%></td>
				    <td></td>
			    </tr>
			   
			    <%}%>
            <%}%>
		</tbody>
		<tfoot>
		</tfoot>
	</table>

</asp:Content>
