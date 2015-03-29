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

		.scroll {
			max-height: 60px;
			overflow: auto;
		}
	</style>
	<script type="text/javascript">
		var idChuong =<%= ID_CHUONG_LOAI_KHOAN_MUC.CHUONG.ToString()%> +"";
		var idLoai =<%= ID_CHUONG_LOAI_KHOAN_MUC.LOAI.ToString()%> +"";
		var idKhoan =<%= ID_CHUONG_LOAI_KHOAN_MUC.KHOAN.ToString()%> +"";
		var idMuc =<%= ID_CHUONG_LOAI_KHOAN_MUC.MUC.ToString()%> +"";
		var idTieuMuc =<%=ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC.ToString()%> +"";
		var IdDonVi=<%=lst_pl02[0].ID_DON_VI%>+"";
		var Nam=<%=lst_pl02[0].NAM%>+"";
		var strLDC_I=<%="\'"+lst_NDC[0]+"\'"%>;
		var strLDC_II=<%="\'"+lst_NDC[1]+"\'"%>;
		var m_lst_clkm = <%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_clkm)%>;
		
	</script>
	<script src="../Scripts/UI/PL02.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table class='table table-hover scroll' style='width: 900px; margin: auto' id='tbl'>
		<thead style='vertical-align: middle;'>
			<tr class='text-center'>
				<th rowspan='2' class='clkm'>Loại</th>
				<th rowspan='2' class='clkm'>Khoản</th>
				<th rowspan='2' class='clkm'>Mục</th>
				<th rowspan='2' class='clkm'>Tiểu mục</th>
				<th rowspan='2'  style='width: 300px'>Nội dung chi</th>
				<th colspan='3'>Tổng cộng</th>
				<th rowspan='2' style='width:160px'>Thao tác</th>
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
						<input type='radio' checked='checked' name='loai_NDC' id='I' />I. Kinh phí năm quyết toán năm nay:</label>
					<br />
					<label>
						<input type='radio' name='loai_NDC' id='II' />II. KP năm trước chưa QT, quyết toán năm nay</label>
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
				<td class='text-right'>
					<input type='text' id='txt_so_bao_cao' value='0' class='so_tien format_so_tien text-right' /></td>
				<td class='text-right'>
					<input type='text' id='txt_so_xet_duyet' value='0' class='so_tien format_so_tien  text-right' /></td>
				<td class='text-right'><span id='lbl_chenh_lech' class='so_tien'>0</span></td>
				<td class='text-center'>
					<input type='button' id='btnCapNhat' class='btn btn-sm btn-success' value='Cập nhật' onclick='gdPL02.update()' />
					<input type='button' id='Button1' class='btn btn-sm btn-default' value='Xoá trắng' onclick='gdPL02.cancel()' />
				</td>
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
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td></td>
			</tr>
			<!--Loai-->
			<%foreach (var ma_loai in lst_pl02
										.Where(x => x.LOAI == loai_ndc)
										.Select(x => x.MA_LOAI)
										.Distinct()
										.OrderBy(x => x)
										.ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td class='text-center'><%=ma_loai %></td>
				<td></td>
				<td></td>
				<td></td>
				<td><%=lst_clkm
							.Where(x=>x.MaSo==ma_loai)
							.Select(x=>x.Ten)
							.FirstOrDefault() %></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td></td>
			</tr>
			<!--Khoan-->
			<%foreach (var ma_khoan in lst_pl02
									 .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_KHOAN)
									 .Distinct()
									 .OrderBy(x => x)
									 .ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td></td>
				<td class='text-center'><%=ma_khoan %></td>
				<td></td>
				<td></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_khoan).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td></td>
			</tr>
			<!--Muc-->
			<%foreach (var ma_muc in lst_pl02
									 .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
									 .Select(x => x.MA_MUC)
									 .Distinct()
									 .OrderBy(x => x)
									 .ToList())%>
			<%{%>
			<tr style='font-weight: bold'>
				<td></td>
				<td></td>
				<td class='text-center'><%=ma_muc %></td>
				<td></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_muc).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => x.SO_XET_DUYET)
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc)
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td></td>
			</tr>
			<!--Tieu Muc-->
			<%foreach (var ma_tieu_muc in lst_pl02
							 .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc).OrderBy(x => x.MA_TIEU_MUC)
							 .ToList())%>
			<%{%>
			<tr>
				<td></td>
				<td></td>
				<td></td>
				<td class='text-center'><span class='ma_tieu_muc' ma_loai='<%=ma_loai %>' ma_khoan='<%=ma_khoan %>' ma_muc='<%=ma_muc %>' id_giao_dich='<%=ma_tieu_muc.ID %>' loai='<%=loai_ndc %>'><%=ma_tieu_muc.MA_TIEU_MUC %></span></td>
				<td><%=lst_clkm.Where(x=>x.MaSo==ma_tieu_muc.MA_TIEU_MUC.Trim()).Select(x=>x.Ten).FirstOrDefault() %></td>
				<td class='text-right '><span class='so_bao_cao str_money'><%=ma_tieu_muc.SO_BAO_CAO %></span></td>
				<td class='text-right '><span class='so_xet_duyet str_money'><%=ma_tieu_muc.SO_XET_DUYET %></span></td>
				<td class='text-right '><span class='str_money'><%=ma_tieu_muc.SO_BAO_CAO - ma_tieu_muc.SO_XET_DUYET%></span></td>
				<td class='text-center'>
					<input type='button' value='Sửa thông tin' class='btn btn-sm btn-primary' onclick='gdPL02.editItem(this)' />
					<input type='button' value='Xoá' class='btn btn-sm btn-danger' onclick='gdPL02.deleteItem(this)'  />
				</td>
			</tr>
			<%}%>
			<%}%>
			<%}%>
			<%}%>
			<%}%>
			<tr style='font-weight: bold; font-style: italic'>
				<td></td>
				<td></td>
				<td></td>
				<td></td>
				<td>Tổng cộng</td>
				<td class='text-right str_money'><%=lst_pl02
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum()%></td>
				<td class='text-right str_money'><%=lst_pl02
							.Select(x => (x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td class='text-right  str_money'><%=lst_pl02
							.Select(x => (x.SO_BAO_CAO-x.SO_XET_DUYET))
							.ToList()
							.Sum()%></td>
				<td></td>
			</tr>
		</tbody>
		<tfoot>
		</tfoot>
	</table>
</asp:Content>
