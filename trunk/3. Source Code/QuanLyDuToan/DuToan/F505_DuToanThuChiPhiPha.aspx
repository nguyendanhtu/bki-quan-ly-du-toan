<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F505_DuToanThuChiPhiPha.aspx.cs" Inherits="QuanLyDuToan.DuToan.F505_DuToanThuChiPhiPha" %>
<%@ Import Namespace="QuanLyDuToan.App_Code" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/F505.js"></script>
	<script src="../Scripts/jquery.bpopup.js"></script>
	<style type="text/css">
		#ThongTinChung {
			background-color: white;
			display: none;
		}

		.form-control {
			background-color: white;
		}
		#F505{
			border: 1px solid #000;
		}
		.text-bold {
			font-weight:bolder;
			font-style:italic;
		}
	</style>
	<script type="text/javascript">
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<div class="row">
		<div class="col-sm-12">
			<div class="col-sm-4 text-right">
				<label>Chọn quyết định</label>
			</div>
			<div class="col-sm-4">
				<select id="m_ddl_quyet_dinh" style="width: 400px">
					<%foreach (var qd in m_lst_quyet_dinh)%>
					<%{%>
					<option value="<%=qd.ID %>"><%=qd.SO_QUYET_DINH+" "+qd.NOI_DUNG %></option>
					<%}%>
				</select>
			</div>
			<div class="col-sm-4">
				<input type="button" value="Lưu dữ liệu" style="width: 150px" class="btn btn-sm btn-primary" />
			</div>
		</div>
		<div class="col-sm-12">
			<table style="width: 900px; margin: auto" class="table table-hover" id="F505">
				<thead>
					<tr  style="height:60px">
						<th>TT</th>
						<th>Hạng mục</th>
						<th>Kinh phí giao</th>
						<th>Thao tác</th>
					</tr>
				</thead>
				<tbody>
					<%foreach (var gd in m_lst_du_toan_thu_chi_phi_pha

											)%>
					<%{%>
					<tr>
						<td>
							<input type="text" class="form-control tt text-center <%= gd.IS_FIX? "text-bold":"" %>" value="<%=gd.TT %>" style="width:50px" />
						</td>
						<td style="width:550px">
							<input type="text" value="<%=gd.HANG_MUC %>" class="hang_muc form-control <%= gd.IS_FIX? "text-bold":"" %>" style="width:500px;height:50px;word-break:break-word"  />
							<button type="button" title="Thêm hạng mục con" class="glyphicon glyphicon-plus btn btn-xs btn-success " onclick='F505.addSubItem(this,<%=gd.MA_SO%>)' style="margin-left:10px;vertical-align: top;
  margin-top: 13px;"></button>
						</td>
						<td >
							<input type="text" class="text-right form-control kinh_phi_giao <%= gd.IS_FIX? "text-bold":"" %>" value="<%=gd.KINH_PHI_GIAO_KH %>" style="width:150px" /></td>
						<td class="text-center" style="width:150px">
							
							<%if (m_lst_du_toan_thu_chi_phi_pha
									.Where(x => x.MA_SO_PARENT == gd.MA_SO || gd.MA_SO_PARENT == null).ToList()
									.Count() == 0 && gd.IS_FIX == false)%>
							<%{%>
							<input type="button" value="Xoá" class="btn btn-sm btn-danger" onclick='F505.deleteItem(this,<%=gd.ID%>)' />
							<%}%>
							<input type="button" value="Cập nhật" class="btn btn-sm btn-primary" onclick="F505.saveItem(this,<%=gd.ID%>)" />
							
						</td>
					</tr>
					<%}%>
				</tbody>
				<tfoot></tfoot>
			</table>
		</div>

	</div>
	<div id="ThongTinChung" class="popup" style="width: 700px; display: none" id_giao_dich="-1" ma_so_parent="-1">
		<h4 id="detail-title" class="text-center" style="border-bottom: 1px solid black; font-weight: bolder">Cập nhật hạng mục thu chi phí phà</h4>

		<div class="popup-content" style="margin:30px">
			<div class="col-sm-12">
				<div class="col-sm-1">
					<input type="text" id="tt" style="width: 50px" class="form-control" placeholder="TT" />
				</div>
				<div class="col-sm-8">
					<input type="text" id="hang_muc" class="form-control" style="width: 100%" placeholder="Hạng mục" />
				</div>
				<div class="col-sm-3">
					<input type="text" id="kinh_phi_giao" class="form-control" placeholder="Kinh phí đã giao" />
				</div>
			</div>
			<br />
			<br />
			<div class="col-sm-12 text-center" style="margin-bottom:30px">
				<input type="button" class="btn btn-sm btn-success" value="Cập nhật" onclick="F505.insertItem()" />
				<input type="button" class="btn btn-sm btn-default" value="Huỷ thao tác" onclick="F505.cancel()" />
			</div>
		</div>
	</div>
</asp:Content>

