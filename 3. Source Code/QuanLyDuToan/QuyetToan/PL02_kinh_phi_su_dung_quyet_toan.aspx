<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL02_kinh_phi_su_dung_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL02_kinh_phi_su_dung_quyet_toan" %>

<%@ Import Namespace="SQLDataAccess" %>
<%@ Import Namespace="WebUS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style>
		.table > thead > tr > th {
			vertical-align: middle;
			border-bottom: 2px solid #ddd;
		}

		.clkm {
			width: 50px;
		}

		.so_tien {
			width: 80px;
		}

		.header-wrap {
			position: fixed;
			height: 200px;
			top: 0;
			width: 100%;
			z-index: 100;
		}
	</style>
	<script type="text/javascript">
		var idChuong =<%= ID_CHUONG_LOAI_KHOAN_MUC.CHUONG.ToString()%> +"";
		var idLoai =<%= ID_CHUONG_LOAI_KHOAN_MUC.LOAI.ToString()%> +"";
		var idKhoan =<%= ID_CHUONG_LOAI_KHOAN_MUC.KHOAN.ToString()%> +"";
		var idMuc =<%= ID_CHUONG_LOAI_KHOAN_MUC.MUC.ToString()%> +"";
		var idTieuMuc =<%=ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC.ToString()%> +"";
		var m_lst_clkm = <%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_clkm)%>;
		
	</script>
	<script src="../Scripts/UI/PL02.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<input type="button" value="Cập nhật" class="btn btn-sm btn-success" onclick="cap_nhat()" />
	<table class='table table-hover' style='width: 900px; margin: auto' id="tbl">
		<thead style='vertical-align: middle' class="header-wrap">
			<tr class='text-center'>
				<th rowspan='2' class='clkm'>Loại</th>
				<th rowspan='2' class='clkm'>Khoản</th>
				<th rowspan='2' class='clkm'>Mục</th>
				<th rowspan='2' class='clkm'>Tiểu mục</th>
				<th rowspan='2' style='width: 200px'>Nội dung chi</th>
				<th colspan='3'>Tổng cộng</th>
			</tr>
			<tr class='text-center'>
				<th rowspan='1' colspan='1' class='so_tien'>Số báo cáo</th>
				<th rowspan='1' colspan='1' class='so_tien'>Số phê duyệt</th>
				<th rowspan='1' colspan='1' class='so_tien'>Chênh lệch</th>
			</tr>
			<tr>
				<td>Nhập mới</td>
				<td></td>
				<td></td>
				<td></td>
				<td>
					<label>
						<input type='radio' checked="checked" name='loai_NDC' />I. Kinh phí năm quyết toán năm nay:</label>
					<br />
					<label>
						<input type='radio' name='loai_NDC' />II. KP năm trước chưa QT, quyết toán năm nay</label>
					<br />
				</td>
			</tr>
			<tr>
				<td>
					<input type='text' id='txt_loai' class='clkm' /></td>
				<td>
					<input type='text' id='txt_khoan' class='clkm' /></td>
				<td>
					<input type='text' id='txt_muc' class='clkm' /></td>
				<td>
					<input type='text' id='txt_tieu_muc' class='clkm' /></td>
				<td>
					<span id='lbl_noi_dung_chi' style='width: 100%'></span>
				</td>
				<td>
					<input type='text' id='txt_so_bao_cao' class='so_tien' /></td>
				<td>
					<input type='text' id='txt_so_xet_duyet' class='so_tien' /></td>
				<td><span id='lbl_chenh_lech' class='so_tien'>0</span></td>
			</tr>
		</thead>
		<tbody>
			<%foreach (var loai_ndc in lst_NDC)%>
			<%{%>
			<tr style='font-weight: bold; font-style: italic'>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td><%=loai_ndc %></td>
				<td><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
			</tr>
			<!--Loai-->
			<%foreach (var ma_loai in lst_pl02
										.Where(x => x.LOAI == loai_ndc)
										.Select(x => x.MA_LOAI)
										.Distinct()
										.ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td><%=ma_loai %></td>
				<td></td>
				<td></td>
				<td></td>
				<td><%=lst_clkm
							.Where(x=>x.MaSo==ma_loai)
							.Select(x=>x.Ten)
							.FirstOrDefault() %></td>
				<td><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
			</tr>
			<!--Khoan-->
			<%foreach (var ma_khoan in lst_pl02
									 .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_KHOAN)
									 .Distinct()
									 .ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td></td>
				<td><%=ma_khoan %></td>
				<td></td>
				<td></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_khoan).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
			</tr>
			<!--Muc-->
			<%foreach (var ma_muc in lst_pl02
									 .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_MUC)
									 .Distinct()
									 .ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td></td>
				<td></td>
				<td><%=ma_muc %></td>
				<td></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_muc).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
			</tr>
			<!--Tieu Muc-->
			<%foreach (var ma_tieu_muc in lst_pl02
							 .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
							 .ToList())%>
			<%{%>
			<tr>
				<td></td>
				<td></td>
				<td></td>
				<td><%=ma_tieu_muc.MA_TIEU_MUC %></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_tieu_muc.MA_TIEU_MUC).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td><%=ma_tieu_muc.SO_BAO_CAO %></td>
				<td><%=ma_tieu_muc.SO_XET_DUYET %></td>
				<td><%=ma_tieu_muc.SO_BAO_CAO - ma_tieu_muc.SO_XET_DUYET%></td>
			</tr>
			<%}%>
			<%}%>
			<%}%>
			<%}%>
			<%}%>
			<tr style='font-weight: bold; font-style: italic"'>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>Tổng cộng</td>
				<td><%=lst_pl02
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Select(x => (x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td><%=lst_pl02
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
			</tr>
		</tbody>
		<tfoot>
		</tfoot>
	</table>
</asp:Content>
