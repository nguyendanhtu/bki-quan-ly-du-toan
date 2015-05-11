<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="QT_QBT_GRID_PL01.ascx.cs" Inherits="QuanLyDuToan.UserControls.QT_QBT_GRID_PL01" %>
<table class=' table table-hover' id='tblPL01' style='width: 900px; margin: auto'>
				<thead>
					<tr class='text-center'>
						<th class='col-sm-1' style='height: 50px;'>Mã số</th>
						<th class='col-sm-3'>Nội dung chi</th>
						<th class='col-sm-1'>Số báo cáo</th>
						<th class='col-sm-1'>Số xét duyệt</th>
						<%--<th class='col-sm-1'>Công thức</th>--%>
						<th class='col-sm-1 thao_tac'>
							<input type='button' class='btn btn-sm btn-success' value='Lưu dữ liệu' onclick='PL01.luu_du_lieu()' /></th>
					</tr>
				</thead>
				<tbody>
					<%foreach (var item in lst_pl01)
	   { %>
					<tr>
						<td class='col-sm-1 text-center'>
							<span class=' ma_so <%= item.MA_SO %>'><%= item.MA_SO %></span>
						</td>
						<td class='col-sm-3'>
							<strong class='ma_so_parent <%= item.MA_SO_PARENT %>'><%= item.CHI_TIEU %></strong>
						</td>
						<td class='col-sm-1'>
							<input type='text' id_giao_dich='<%=item.ID %>' class='form-control format_so_tien so_bao_cao <%= formatClass(item.MA_SO) %>' value='<%= item.SO_BAO_CAO %>' />
						</td>
						<td class='col-sm-1'>
							<input type='text' class='form-control  format_so_tien so_xet_duyet <%=formatClass(item.MA_SO) %>' value='<%= item.SO_XET_DUYET %>' />
						</td>
						<%--<td class='col-sm-1 text-center'>
					<span class=' ma_so <%= item.MA_SO %> cong_thuc' ><%=formatCongThuc( item.CONG_THUC) %></span>
				</td>--%>
						<td class='col-sm-1 text-center thao_tac'>
							<input type='button' class='btn btn-sm btn-success cap_nhat' value='Đã cập nhật' onclick='PL01.cap_nhat(this)' style="display:none"/>
						</td>
					</tr>
					<%} %>
				</tbody>
			</table>