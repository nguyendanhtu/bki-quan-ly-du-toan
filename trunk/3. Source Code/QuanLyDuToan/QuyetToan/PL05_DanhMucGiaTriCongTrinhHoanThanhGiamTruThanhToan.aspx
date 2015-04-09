<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL05_DanhMucGiaTriCongTrinhHoanThanhGiamTruThanhToan.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL05_DanhMucGiaTriCongTrinhHoanThanhGiamTruThanhToan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/linq.js"></script>
	<script src="../Scripts/jquery.linq.js"></script>
	<script src="../Scripts/UI/PL05.js"></script>
	<script src="../Scripts/jquery.bpopup.js"></script>
	<script type="text/javascript">
		var lstPL04=<%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_pl04
			 .Select(x => new { x.ID
				 ,x.ID_DON_VI
				 ,x.NAM
				 ,x.TEN_LOAI_NHIEM_VU
				 ,x.TT,x.CONG_THUC
				 ,x.CONG_TRINH
				 ,x.DU_AN
				 ,x.GHI_CHU
				 ,x.GIA_TRI_CTHT_DA_QUYET_TOAN_LK_DEN_NAM_BAO_CAO
				 ,x.GIA_TRI_CTHT_NAM_NAY
				 ,x.GIA_TRI_CTHT_NAM_TRUOC_CON_NO_CHUYEN_NAM_NAY
				 ,x.GIA_TRI_DE_NGHI_QUYET_TOAN_TRONG_NAM
				 ,x.GIA_TRI_DU_TOAN_CONG_TRINH_DUOC_DUYET})
			 .ToList())%>;
		
	</script>
	<style>
		.cbo {
			width: 250px;
		}

		th {
			text-align: center !important;
			background: white;
			border-color: #ddd;
		}

		.format_so_tien, .str_money {
			text-align: right;
			width: 150px;
		}

		#ThongTinChung {
			background-color: white;
			display: none;
		}

		#tbl_pl05 > thead > tr > th {
			border: 1px solid #000;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<asp:DropDownList ID="m_cbo_nam" runat="server" ClientIDMode="Static">
		<asp:ListItem Value="2014" Text="2014"></asp:ListItem>
	</asp:DropDownList>
	<table style="width: 1000px; margin: auto" id="tbl_pl05" class="table table-bordered" id_don_vi="<%=lst_pl05.FirstOrDefault().ID_DON_VI %>">
		<thead>
			<tr>
				<th>TT</th>
				<th>Nội dung</th>
				<th style="width: 100px">Giá trị khối lượng công trình hoàn thành trong năm</th>
				<th style="width: 100px">Giá trị khối lượng được quyết toán</th>
				<th style="width: 100px">Giá trị giảm trừ thanh toán </th>
				<th>Ghi chú</th>
				<th rowspan="2" style="width: 150px">
					<input type="button" value="Thêm mới" class="btn btn-sm btn-primary" onclick="PL05.addItem()" /></th>
			</tr>
			<tr>
				<th>1</th>
				<th>2</th>
				<th>3</th>
				<th>4</th>
				<th>5=3-4</th>
				<th>6</th>
			</tr>
		</thead>
		<tbody>
			<%int CongTrinhIndex = 0; %>
			<%foreach (var cong_trinh in lst_pl05.Select(x => x.CONG_TRINH.Trim()).Distinct().ToList())%>
			<%{
		 CongTrinhIndex++; int DuAnIndex = 0;%>
			<tr style="font-weight: bold">
				<td class="text-center"><%=CongTrinhIndex %></td>
				<td><%=cong_trinh %></td>
				<td class=" GTKLCTHTTN str_money" ma_so="<%=DuAnIndex %>">
					<%=lst_pl05.Where(x=>x.CONG_TRINH==cong_trinh)
									.Select(x=>x.I_GTKLCTHTTN
									+x.II_GTKLCTHTTN
									+x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN
									+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN
									+x.V_GTKLCTHTTN).Sum() %></td>
				<td class=" GTKLDQT str_money" ma_so="<%=DuAnIndex %>">
					<%=lst_pl05.Where(x=>x.CONG_TRINH==cong_trinh)
									.Select(x=>x.I_GTKLDQT
									+x.II_GTKLDQT
									+x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT
									+x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT
									+x.V_GTKLDQT).Sum() %>
				</td>
				<td class="GTGTTT str_money str_money" ma_so="<%=DuAnIndex %>">
					<%=lst_pl05.Where(x=>x.CONG_TRINH==cong_trinh)
									.Select(x=>x.I_GTKLCTHTTN
									+x.II_GTKLCTHTTN
									+x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN
									+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN
									+x.V_GTKLCTHTTN).Sum() 
						-
						lst_pl05.Where(x=>x.CONG_TRINH==cong_trinh)
									.Select(x=>x.I_GTKLDQT
									+x.II_GTKLDQT
									+x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT
									+x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT
									+x.V_GTKLDQT).Sum()
					
					%></td>
				<td></td>
			</tr>
			<%foreach (var gd in lst_pl05.Where(x => x.CONG_TRINH == cong_trinh).ToList())%>
			<%{
		 DuAnIndex++;
			%>

			<tr style="font-weight: bold">
				<td class="text-center"><%=CongTrinhIndex.ToString()+"."+DuAnIndex.ToString() %></td>
				<td id="Td1"><%=lst_pl05.FirstOrDefault(x=>x.ID==gd.ID).DU_AN %></td>
				<td class=" GTKLCTHTTN str_money" ma_so="<%=DuAnIndex*1000+1 %>" ma_so_parent="<%=CongTrinhIndex %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.I_GTKLCTHTTN
									+x.II_GTKLCTHTTN
									+x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN
									+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN
									+x.V_GTKLCTHTTN).Sum() %></td>
				<td class=" GTKLDQT str_money" ma_so="<%=DuAnIndex*1000+1 %>" ma_so_parent="<%=DuAnIndex*1000 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.I_GTKLDQT
									+x.II_GTKLDQT
									+x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT
									+x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT
									+x.V_GTKLDQT).Sum() %>
				</td>
				<td class="GTGTTT str_money str_money" ma_so="<%=DuAnIndex*1000+1 %>" ma_so_parent="<%=DuAnIndex*1000 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.I_GTKLCTHTTN
									+x.II_GTKLCTHTTN
									+x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN
									+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN
									+x.V_GTKLCTHTTN).Sum() 
						-
						lst_pl05.Where(x=>x.CONG_TRINH==gd.CONG_TRINH)
									.Select(x=>x.I_GTKLDQT
									+x.II_GTKLDQT
									+x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT
									+x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT
									+x.V_GTKLDQT).Sum()
					
					%></td>
				<td rowspan="13">
					<textarea rows="13" class="form-control" style="height: 100%"></textarea>
				</td>
				<td rowspan="13" class="text-center">
					<input type="button" class="btn btn-sm btn-primary" value="Sửa" onclick="PL05.editItem(this,'<%=gd.ID%>','<%=gd.TEN_LOAI_NHIEM_VU.Trim()%>','<%=gd.CONG_TRINH.Trim()%>','<%=gd.DU_AN.Trim()%>')" />
					<input type="button" class="btn btn-sm btn-danger" value="Xoá" onclick="PL05.deleteItem('<%=gd.ID%>')" />
				</td>
			</tr>
			<tr style="font-weight: bold">
				<td class="text-center" id_gd="<%=gd.ID %>">I</td>
				<td>Chi phí xây lắp sau thuế</td>
				<td class="str_money I_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.I_GTKLCTHTTN).Sum() %>
				</td>
				<td class="str_money I_GTKLDQT"><%=lst_pl05.Where(x=>x.CONG_TRINH==gd.CONG_TRINH)
									.Select(x=>x.I_GTKLDQT).Sum() %>
				</td>
				<td class="GTGTTT str_money str_money" ma_so="<%=DuAnIndex*1000+2 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.I_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.CONG_TRINH==gd.CONG_TRINH)
									.Select(x=>x.I_GTKLDQT).Sum() 
					%>
				</td>
				<td></td>
			</tr>
			<tr style="font-weight: bold">
				<td class="text-center" id_gd="<%=gd.ID %>">II</td>
				<td>Chi phí quản lý dự án</td>
				<td class="str_money GTKLCTHTTN II_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.II_GTKLCTHTTN).Sum() %></td>
				<td class="str_money II_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.II_GTKLDQT).Sum() %></td>
				<td class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.II_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.CONG_TRINH==gd.CONG_TRINH)
									.Select(x=>x.II_GTKLDQT).Sum() 
					%>
				</td>
				<td></td>
			</tr>
			<tr style="font-weight: bold">
				<td class="text-center" id_gd="<%=gd.ID %>">III</td>
				<td>Chi phí tư vấn xây dựng</td>
				<td class=" III_GTKLCTHTTN str_money" ma_so="<%=DuAnIndex*1000+4 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN).Sum() %></td>
				<td class=" III_GTKLDQT str_money" ma_so="<%=DuAnIndex*1000+4 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT).Sum() %></td>
				<td class="GTGTTT str_money str_money" ma_so="<%=DuAnIndex*1000+4 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>"><%=
					lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLCTHTTN
									+x.III_2_GTKLCTHTTN
									+x.III_3_GTKLCTHTTN).Sum()
					-
					lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLDQT
									+x.III_2_GTKLDQT
									+x.III_3_GTKLDQT).Sum()
				%></td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">1</td>
				<td>Chi phí khảo sát thiết kế lập báo cáo KTKT</td>
				<td class="str_money III_1_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLCTHTTN).Sum() %></td>
				<td class="str_money III_1_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLDQT).Sum() %></td>
				<td class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLCTHTTN).Sum()
					-
					lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_1_GTKLDQT).Sum()

					%></td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">2</td>
				<td>Chi phí lựa chọn nhà thầu thi công</td>
				<td class="str_money III_2_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_2_GTKLCTHTTN).Sum() %></td>
				<td class="str_money III_2_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_2_GTKLDQT).Sum() %></td>
				<td class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_2_GTKLCTHTTN).Sum()
					-
					lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_2_GTKLDQT).Sum()

					%>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">3</td>
				<td>Chi phí giám sát xây dựng</td>
				<td class="str_money III_3_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_3_GTKLCTHTTN).Sum() %></td>
				<td class="str_money III_3_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_3_GTKLDQT).Sum() %></td>
				<td class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_3_GTKLCTHTTN).Sum()
					-
					lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.III_3_GTKLDQT).Sum()

					%>
				</td>
				<td></td>
			</tr>
			<tr style="font-weight: bold">
				<td class="text-center" id_gd="<%=gd.ID%>">IV</td>
				<td id_gd="<%=gd.ID%>">Chi phí khác</td>
				<td id_gd="<%=gd.ID%>" class=" IV_GTKLCTHTTN str_money" ma_so="<%=DuAnIndex*1000+8 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN).Sum() %>
				</td>
				<td id_gd="<%=gd.ID%>" class=" IV_GTKLDQT str_money" ma_so="<%=DuAnIndex*1000+8 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT).Sum() %>
				</td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money str_money" ma_so="<%=DuAnIndex*1000+8 %>" ma_so_parent="<%=DuAnIndex*1000+1 %>">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_1_GTKLCTHTTN
									+x.IV_2_GTKLCTHTTN
									+x.IV_3_GTKLCTHTTN
									+x.IV_4_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_1_GTKLDQT
									+x.IV_2_GTKLDQT
									+x.IV_3_GTKLDQT
									+x.IV_4_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">1</td>
				<td>Lệ phí thẩm định báo cáo KTKT</td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_1_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_1_GTKLCTHTTN).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_1_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_1_GTKLDQT).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money" ma_so="<%=DuAnIndex*1000+9 %>" ma_so_parent="9">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_1_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_1_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">2</td>
				<td>Chi phí đảm bảo giao thông</td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_2_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_2_GTKLCTHTTN).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_2_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_2_GTKLDQT).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money" ma_so="<%=DuAnIndex*1000+10 %>" ma_so_parent="9">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_2_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_2_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">3</td>
				<td>Chi phí Thẩm tra, phê duyệt quyết toán</td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_3_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_3_GTKLCTHTTN).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_3_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_3_GTKLDQT).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_3_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_3_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>
			<tr>
				<td class="text-center" id_gd="<%=gd.ID %>">4</td>
				<td>Chi phí Kiểm toán </td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_4_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_4_GTKLCTHTTN).Sum()%></td>
				<td id_gd="<%=gd.ID%>" class="str_money IV_4_GTKLDQT"><%= lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_4_GTKLDQT).Sum()%></td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.IV_4_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.IV_4_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>
			<tr style="font-weight: bold">
				<td class="text-center" id_gd="<%=gd.ID %>">V</td>
				<td>Dự phòng </td>
				<td id_gd="<%=gd.ID%>" class="str_money V_GTKLCTHTTN"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.V_GTKLCTHTTN).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="str_money V_GTKLDQT"><%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.V_GTKLDQT).Sum() %></td>
				<td id_gd="<%=gd.ID%>" class="GTGTTT str_money">
					<%=lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>+x.V_GTKLCTHTTN).Sum()
						-
						lst_pl05.Where(x=>x.ID==gd.ID)
									.Select(x=>x.V_GTKLDQT).Sum()
					%>
				</td>
				<td></td>
			</tr>

			<%}%>
			<%}%>
		</tbody>

	</table>

	<div id="ThongTinChung" class="popup" style="width: 80%" id_giao_dich="-1">
		<h4 id="detail-title"></h4>

		<div class="popup-content">
			<table style="width: 900px; margin: auto" id="tblDetail">
				<thead>
					<tr>
						<th>TT</th>
						<th>Nội dung</th>
						<th style="width: 100px">Giá trị khối lượng công trình hoàn thành trong năm</th>
						<th style="width: 100px">Giá trị khối lượng được quyết toán</th>
						<th style="width: 100px">Giá trị giảm trừ thanh toán </th>
						<th>Ghi chú</th>
					</tr>
					<tr>
						<th>1</th>
						<th>2</th>
						<th>3</th>
						<th>4</th>
						<th>5=3-4</th>
						<th>6</th>
					</tr>
					<tr>
						<th colspan="6">
							<select id="m_cbo_loai_nhiem_vu" class="cbo"></select>
							<select id="m_cbo_cong_trinh" class="cbo"></select>
							<select id="m_cbo_du_an" class="cbo"></select>
						</th>
					</tr>
				</thead>
				<tbody>
					<tr style="font-weight: bold">
						<td>1</td>
						<td id="cong_trinh"></td>
						<td class=" GTKLCTHTTN str_money" ma_so="1">0</td>
						<td class=" GTKLDQT str_money" ma_so="1">0</td>
						<td class="GTGTTT str_money str_money" ma_so="1">0</td>
						<td></td>
					</tr>
					<tr style="font-weight: bold">
						<td>1.1</td>
						<td id="du_an"></td>
						<td class=" GTKLCTHTTN str_money" ma_so="<%=1+1 %>" ma_so_parent="<%=1 %>">0</td>
						<td class=" GTKLDQT str_money" ma_so="<%=1+1 %>" ma_so_parent="<%=1 %>">0</td>
						<td class="GTGTTT str_money str_money" ma_so="<%=1+1 %>" ma_so_parent="<%=1 %>">0</td>
						<td rowspan="13">
							<textarea rows="13"></textarea>
						</td>
					</tr>
					<tr style="font-weight: bold">
						<td>I</td>
						<td>Chi phí xây lắp sau thuế</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+2 %>" ma_so_parent="<%=1+1 %>" id="I_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" id="I_GTKLDQT" ma_so="<%=1+2 %>" ma_so_parent="<%=1+1 %>" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+2 %>" ma_so_parent="<%=1+1 %>"></td>
						<td></td>
					</tr>
					<tr style="font-weight: bold">
						<td>II</td>
						<td>Chi phí quản lý dự án</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+3 %>" ma_so_parent="<%=1+1 %>" id="II_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+3 %>" ma_so_parent="<%=1+1 %>" id="II_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+3 %>" ma_so_parent="<%=1+1 %>"></td>
						<td></td>
					</tr>
					<tr style="font-weight: bold">
						<td>III</td>
						<td>Chi phí tư vấn xây dựng</td>
						<td class=" GTKLCTHTTN str_money" ma_so="<%=1+4 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td class=" GTKLDQT str_money" ma_so="<%=1+4 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td class="GTGTTT str_money str_money" ma_so="<%=1+4 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td></td>
					</tr>
					<tr>
						<td>1</td>
						<td>Chi phí khảo sát thiết kế lập báo cáo KTKT</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+5 %>" ma_so_parent="5" id="III_1_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+5 %>" ma_so_parent="5" id="III_1_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+5 %>" ma_so_parent="5"></td>
						<td></td>
					</tr>
					<tr>
						<td>2</td>
						<td>Chi phí lựa chọn nhà thầu thi công</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+6 %>" ma_so_parent="5" id="III_2_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+6 %>" ma_so_parent="5" id="III_2_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+6 %>" ma_so_parent="5"></td>
						<td></td>
					</tr>
					<tr>
						<td>3</td>
						<td>Chi phí giám sát xây dựng</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+7 %>" ma_so_parent="5" id="III_3_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+7 %>" ma_so_parent="5" id="III_3_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+7 %>" ma_so_parent="5"></td>
						<td></td>
					</tr>
					<tr style="font-weight: bold">
						<td>IV</td>
						<td>Chi phí khác</td>
						<td class=" GTKLCTHTTN str_money" ma_so="<%=1+8 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td class=" GTKLDQT str_money" ma_so="<%=1+8 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td class="GTGTTT str_money str_money" ma_so="<%=1+8 %>" ma_so_parent="<%=1+1 %>">0</td>
						<td></td>
					</tr>
					<tr>
						<td>1</td>
						<td>Lệ phí thẩm định báo cáo KTKT</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+9 %>" ma_so_parent="9" id="IV_1_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+9 %>" ma_so_parent="9" id="IV_1_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+9 %>" ma_so_parent="9"></td>
						<td></td>
					</tr>
					<tr>
						<td>2</td>
						<td>Chi phí đảm bảo giao thông</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+10 %>" ma_so_parent="9" id="IV_2_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+10 %>" ma_so_parent="9" id="IV_2_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+10 %>" ma_so_parent="9"></td>
						<td></td>
					</tr>
					<tr>
						<td>3</td>
						<td>Chi phí Thẩm tra, phê duyệt quyết toán</td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+11 %>" ma_so_parent="9" id="IV_3_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+11 %>" ma_so_parent="9" id="IV_3_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+11 %>" ma_so_parent="9"></td>
						<td></td>
					</tr>
					<tr>
						<td>4</td>
						<td>Chi phí Kiểm toán </td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+12 %>" ma_so_parent="9" id="IV_4_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+12 %>" ma_so_parent="9" id="IV_4_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+12 %>" ma_so_parent="9"></td>
						<td></td>
					</tr>
					<tr style="font-weight: bold">
						<td>V</td>
						<td>Dự phòng </td>
						<td>
							<input type="text" class=" GTKLCTHTTN form-control format_so_tien" ma_so="<%=1+13 %>" ma_so_parent="<%=1+1 %>" id="V_GTKLCTHTTN" />
						</td>
						<td>
							<input type="text" class="GTKLDQT form-control format_so_tien" ma_so="<%=1+13 %>" ma_so_parent="<%=1+1 %>" id="V_GTKLDQT" /></td>
						<td class="GTGTTT str_money" ma_so="<%=1+13 %>" ma_so_parent="<%=1+1 %>"></td>
						<td></td>
					</tr>
				</tbody>
				<tfoot>
					<tr class="text-center" style="height: 100px">
						<td colspan="6">
							<input type="button" class="btn btn-primary" value="Lưu dữ liệu" onclick="PL05.updateGiaoDich()" />
							<input type="button" class="btn btn-default" value="Huỷ thao tác" onclick="PL05.cancel()" /></td>
					</tr>
				</tfoot>
			</table>
		</div>
	</div>

</asp:Content>
