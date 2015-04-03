<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL03_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh" %>

<%@ Import Namespace="Framework.Extensions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style>
		#tblPL03 > thead > tr > th {
			border: 1px solid #000;
		}
		.form-control, .format_so_tien {
			width: 90px;
			text-align: right;
			padding: 3px 2px;
			font-size: 11px;
		}
		.text-right {
			width: 90px;
		}
	</style>
	<script src="../Scripts/UI/PL03.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table class="table table-hover" id="tblPL03" style="width:1200px; margin:auto">
		<thead>
			<tr>
				<th rowspan="2">TT</th>
				<th rowspan="2">Nội dung</th>
				<th colspan="3">Số kiến nghị của</th>
				<th colspan="3">Số đã nộp trả Quỹ BTĐB TW trong năm nay</th>
				<th colspan="3">Số còn phải nộp Quỹ BTĐB TW</th>
				<th rowspan="3"><input type="button" class="btn btn-sm btn-primary" value="Cập nhật" style="height:70px"
					onclick="PL03.updateAll()" /></th>
			</tr>
			<tr>
				<th>Tống số</th>
				<th>Kiểm toán Nhà nước</th>
				<th>Cơ quan tài chính</th>
				<th>Tống số</th>
				<th>Kiểm toán Nhà nước</th>
				<th>Cơ quan tài chính</th>
				<th>Tống số</th>
				<th>Kiểm toán Nhà nước</th>
				<th>Cơ quan tài chính</th>
			</tr>
			<tr>
				<th>A</th>
				<th>B</th>
				<th>1=2+3</th>
				<th>2</th>
				<th>3</th>
				<th>4=5+6</th>
				<th>5</th>
				<th>6</th>
				<th>7=8+9</th>
				<th>8=2-5</th>
				<th>9=3-6</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var gd in lst_pl03)%>
			<%{%>
			<tr>
				<td class="text-center"><%=gd.TT %></td>
				<td class="noi_dung" id_giao_dich="<%=gd.ID %>"><%=gd.NOI_DUNG %></td>
				<td class="SKNTong str_money text-right"  ma_so="<%=gd.MA_SO %>">
					<%=(gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH.HasValue?gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH:0)
					 +(gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC:0)%>
				</td>
				<td>
					<input type="text" value="<%=gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC %>"
						 class="form-control SKNKTNN format_so_tien input_control" ma_so="<%=gd.MA_SO %>" ma_so_parent="<%=gd.MA_SO_PARENT %>" /></td>
				<td>
					<input type="text" value="<%=gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH %>"
						 class="form-control SKNCQTC format_so_tien input_control" ma_so="<%=gd.MA_SO %>" ma_so_parent="<%=gd.MA_SO_PARENT %>" /></td>
				<td class="SDNTong str_money text-right"  ma_so="<%=gd.MA_SO %>">
					<%=(gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH.HasValue?gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH:0)
						+(gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC:0)%>
				</td>
				<td>
					<input type="text" value="<%=gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC %>" 
						 class="form-control SDNKTNN format_so_tien input_control" ma_so="<%=gd.MA_SO %>" ma_so_parent="<%=gd.MA_SO_PARENT %>" /></td>
				<td>
					<input type="text" value="<%=gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH %>"
						 class="form-control SDNCQTC format_so_tien input_control"  ma_so="<%=gd.MA_SO %>" ma_so_parent="<%=gd.MA_SO_PARENT %>" /></td>
				<td class="SCPNTong str_money  text-right"  ma_so="<%=gd.MA_SO %>">
					<%=(gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC:0)
					 -(gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC:0)
					+
					(gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH.HasValue?gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH:0)
					 -(gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH.HasValue?gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH:0)%>
				</td>
				<td class="SCPNKTNN str_money  text-right"  ma_so="<%=gd.MA_SO %>">
					<%=(gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC:0)
					 -(gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC.HasValue?gd.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC:0)%>
				</td>
				<td class="SCPNCQTC str_money  text-right"  ma_so="<%=gd.MA_SO %>">
					<%=(gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH.HasValue?gd.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH:0)
					 -(gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH.HasValue?gd.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH:0)%>
				</td>
				<td class="text-center">
					<input type="button" value="Đã cập nhật" class="btn btn-sm btn-success cap_nhat" onclick="PL03.updateGiaoDich(this)" />
				</td>
			</tr>
			<%}%>
		</tbody>
	</table>

</asp:Content>
