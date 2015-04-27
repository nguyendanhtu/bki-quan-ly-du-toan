<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TableGiaoKH.ascx.cs" Inherits="QuanLyDuToan.UserControls.TableGiaoKH" %>
<%--<table style="width: 100%; border: 1px solid black" class="table table-hover" id="F104">
	<thead>
		<tr>
			<th rowspan="2" style="width: 90px">
				<input type="button" value="Lưu dữ liệu" class="btn btn-success btn-sm private_don_vi" style="height: 60px" onclick="F104.updateAll()" />
			</th>
			<th rowspan="2">Nhiệm vụ chi</th>
			<th rowspan="2" style="width: 50px">Chiều dài tuyến (km)</th>
			<th rowspan="1" style="width: 100px">Kinh phí năm trước chuyển sang</th>
			<th rowspan="1" style="width: 100px">Kinh phí Ngân sách</th>
			<th rowspan="1" style="width: 100px">Kinh phí Quỹ bảo trì</th>
			<th rowspan="1" style="width: 100px">Tổng</th>
		</tr>
		<tr>
			<th>(1)</th>
			<th>(2)</th>
			<th>(3)</th>
			<th>(4)=(1)+(2)+(3))</th>
		</tr>
	</thead>
	<tbody>--%>
		<%foreach (var gd in m_lst_gd)%>
		<%{%>
		<tr style='<%=(gd.ID==-1?"font-weight:bold": "")%>'>
			<!--Xoá-->
			<td style='width: 90px' class='text-center delete'>
				<%if (gd.ID != -1)%>
				<%{%>
				<input type='button' class='xoa_giao_dich btn btn-xs btn-danger private_don_vi' value='Xoá' onclick='F104.deleteGiaoDich(<%=gd.ID%>)' />
				<%}%>

				<%if (gd.ID != -1)%>
				<%{%>
				<input type='button' class='sua_giao_dich btn btn-xs btn-primary' value='Sửa' onclick='F104.editGiaoDich(<%=gd.ID%>)' />
				<%}%>
			</td>
			<!--Nhiem vu chi-->
			<td ma_so='<%=genMaSo(gd) %>' id_giao_dich='<%=gd.ID %>' ma_so_parent='<%=genMaSoParent(gd) %>' class='lnv'>
				<%=gd.NOI_DUNG %>
			</td>
			<!--Chiều dài tuyến-->
			<td class='text-right' style='width: 50px'>
				<input type='text' class='so_km form-control text-right' value='<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.So_KM,"#,##0.##") %>' />
			</td>
			<!--Kinh phi Nam truoc chuyen sang-->
			<td class='text-right' style='width: 100px'>
				<%--<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.NTCT,'#,##0.##') %>--%>
				<input type='text' class='kinh_phi_nam_truoc_chuyen_sang form-control text-right format_so_tien' value='<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.NTCT,"#,##0.##") %>' />
			</td>
			<!--Kinh phi Ngan sach-->
			<td class='text-right' style='width: 100px'>
				<input type='text' class='kinh_phi_ngan_sach form-control text-right format_so_tien' value='<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.NS,"#,##0.##") %>' />
			</td>
			<!--Kinh phi Quy bao tri-->
			<td class='text-right' style='width: 100px'>
				<input type='text' class='kinh_phi_quy_bao_tri form-control text-right format_so_tien' value='<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.QUY,"#,##0.##") %>' />
			</td>
			<!--Tổng-->
			<td class='text-right' style='width: 100px'>
				<input type='text' class='grid_tong form-control text-right' value='<%=IP.Core.IPCommon.CIPConvert.ToStr(gd.TONG,"#,##0.##") %>' />
			</td>
		</tr>
		<%}%>
	<%--</tbody>
	<tfoot></tfoot>
</table>--%>
