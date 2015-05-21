<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="F505Grid.ascx.cs" Inherits="QuanLyDuToan.UserControls.F505Grid" %>
<table style='width: auto; margin: auto' class='table table-hover' id='F505'>
				<thead>
					<tr style='height: 60px'>
						<th>TT</th>
						<th>Hạng mục</th>
						<th class="giao_kh thuc_hien">Kinh phí giao</th>
						<th class="giao_kh">Phân bổ Quý I </th>
						<th class="giao_kh">Phân bổ Quý II </th>
						<th class="giao_kh">Phân bổ Quý III </th>
						<th class="giao_kh">Phân bổ Quý IV </th>
						<th class="thuc_hien">Thực hiện Quý I </th>
						<th class="thuc_hien">Thực hiện Quý II </th>
						<th class="thuc_hien">Thực hiện Quý III </th>
						<th class="thuc_hien">Thực hiện Quý IV </th>
						<th>
							<input type='button' value='Lưu dữ liệu' style='width: 120px; height: 44px;' onclick='F505.saveAllData()' class='btn btn-sm btn-primary' /></th>
					</tr>
				</thead>
				<tbody>
					<%foreach (var gd in m_lst_du_toan_thu_chi_phi_pha)%>
					<%{%>
					<tr  id_giao_dich="<%=gd.ID %>" loai="data"  >
						<td>
							<!--TT-->
							<input type='text' class='form-control tt text-center' value='<%=gd.TT %>' style='width: 50px' />
						</td>
						<td style='width: 550px; text-align:right'>
							<!--Hang muc-->
							<input type='text' value='<%=gd.HANG_MUC %>' class='hang_muc form-control' style='width: <%=500-(gd.MA_SO.Length-5)/3*15%>px; height: 50px; word-break: break-word' />
							<button type='button' title='Thêm hạng mục con' class='glyphicon glyphicon-plus btn btn-xs btn-success giao_kh ' onclick='F505.addSubItem(this,<%=gd.MA_SO%>)' style='margin-left: 10px; vertical-align: top; margin-top: 13px;'>
							</button>
						</td>
						<td class="giao_kh thuc_hien">
							<!--Kinh phi giao-->
							<input type='text' class='text-right form-control kinh_phi_giao format_so_tien ' value='<%=gd.KINH_PHI_GIAO_KH %>'  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="giao_kh">
							<!--Phan bo Quy I-->
							<input type="text" class="text-right form-control phan_bo_quy_i format_so_tien" value="<%=gd.PHAN_BO_QUI_I %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="giao_kh">
							<!--Phan bo Quy II-->
							<input type="text" class="text-right form-control phan_bo_quy_ii format_so_tien" value="<%=gd.PHAN_BO_QUY_II %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="giao_kh">
							<!--Phan bo Quy III-->
							<input type="text" class="text-right form-control phan_bo_quy_iii format_so_tien" value="<%=gd.PHAN_BO_QUY_III %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="giao_kh">
							<!--Phan bo Quy IV-->
							<input type="text" class="text-right form-control phan_bo_quy_iv format_so_tien" value="<%=gd.PHAN_BO_QUY_IV %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="thuc_hien">
							<!--Thuc hien Quy I-->
							<input type="text" class="text-right form-control thuc_hien_quy_i format_so_tien" value="<%=gd.KLTH_QUY_I %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="thuc_hien">
							<!--Thuc hien Quy II-->
							<input type="text" class="text-right form-control thuc_hien_quy_ii format_so_tien" value="<%=gd.KLTH_QUY_II %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="thuc_hien">
							<!--Thuc hien Quy III-->
							<input type="text" class="text-right form-control thuc_hien_quy_iii format_so_tien" value="<%=gd.KLTH_QUY_III %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class="thuc_hien">
							<!--Thuc hien Quy IV-->
							<input type="text" class="text-right form-control thuc_hien_quy_iv format_so_tien" value="<%=gd.KLTH_QUY_IV %>"  ma_so='<%=gd.MA_SO %>' ma_so_parent='<%=gd.MA_SO_PARENT %>'/>
						</td>
						<td class='text-center' style='width: 150px'>
							<!--Thao tac-->
							<%if (m_lst_du_toan_thu_chi_phi_pha
									.Where(x => x.MA_SO_PARENT == gd.MA_SO || gd.MA_SO_PARENT == null).ToList()
									.Count() == 0 && gd.IS_FIX == false)%>
							<%{%>
							<input type='button' value='Xoá' class='btn btn-sm btn-danger' onclick='F505.deleteItem(this,<%=gd.ID%>)' />
							<%}%>
							<input type='button' style='display: none' value='Cập nhật' class='btn btn-sm btn-primary cap_nhat' onclick='F505.saveItem(this,<%=gd.ID%>)' />

						</td>
					</tr>
					<%}%>
				</tbody>
				<tfoot></tfoot>
			</table>
