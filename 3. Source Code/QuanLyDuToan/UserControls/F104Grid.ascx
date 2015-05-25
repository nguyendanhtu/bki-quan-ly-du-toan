<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="F104Grid.ascx.cs" Inherits="QuanLyDuToan.UserControls.F104Grid" %>

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
		<!--Tong cong-->
		<tr style="font-weight: bold">
			<td>
				<!--Thao tac-->

			</td>
			<td class="text-center " id_giao_dich="-1" ma_so="0" ma_so_parent="-1">
				<!--Nhiem vu chi-->
				Tổng cộng
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right "
					value="<%=m_lst_gd.Select(x=>Convert.ToDecimal(x.GHI_CHU_2))
						.Sum() %>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.TONG_MUC_DAU_TU)
						.Sum() %>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.THOI_GIAN_THUC_HIEN)
						.Sum() %>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						.Sum() %>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS)
						.Sum() %>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.SO_TIEN_NS)
						.Sum() %>" />
			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.SO_TIEN_QUY_BT)
						.Sum() %>" />
			</td>
			<td>
				<!--Tong-->
				<input type="text" class="grid_tong form-control text-right format_so_tien"
					value="<%=m_lst_gd.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
										+ x.SO_TIEN_NS
										+ x.SO_TIEN_QUY_BT)
						.Sum() %>" />
			</td>
		</tr>
		<%var lst_lnv = m_lst_gd
							   .Select(x => new
							   {
								   ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU
								   ,
								   TEN = x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.TEN
								   ,
								   GHI_CHU = x.CM_DM_TU_DIEN_LOAI_NHIEM_VU.GHI_CHU

							   })
							   .Distinct()
							   .OrderBy(x => x.GHI_CHU)
							   .ToList();%>
		<%foreach (var lnv in lst_lnv)%>
		<%{%>
		<!--Level 1: Loai nhiem vu-->
		<tr class="loai_nhiem_vu">
			<td>
				<!--Thao tac-->

			</td>
			<td id_giao_dich="-1" class="lnv" ma_so_parent="0" ma_so="<%=lnv.ID_LOAI_NHIEM_VU %>">
				<!--Nhiem vu chi-->
				<%=lnv.GHI_CHU+" - "+lnv.TEN %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>Convert.ToDecimal(x.GHI_CHU_2))
						 .Sum() %>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.TONG_MUC_DAU_TU)
						 .Sum() %>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.THOI_GIAN_THUC_HIEN)
						 .Sum() %>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
						 .Sum() %>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS)
						 .Sum() %>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_NS)
						 .Sum() %>" />
			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_QUY_BT)
						 .Sum() %>" />
			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%= m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
									+x.SO_TIEN_NS
									+x.SO_TIEN_QUY_BT)
						 .Sum()%>" />
			</td>
		</tr>
		<%var lst_cong_trinh = m_lst_gd
									.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU
										 && x.ID_CONG_TRINH != null)
									.Select(x => new
									{
										ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU
										,
										ID_CONG_TRINH = x.ID_CONG_TRINH
										,
										TEN_CONG_TRINH = x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN
									})
									.Distinct()
									.OrderBy(x => x.TEN_CONG_TRINH)
									.ToList(); %>
		<!--Level 2: Cong trinh--->
		<%foreach (var cong_trinh in lst_cong_trinh)%>
		<%{%>
		<tr class="cong_trinh">
			<td>
				<!--Thao tac-->

			</td>
			<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+""+cong_trinh.ID_CONG_TRINH %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
				<!--Nhiem vu chi-->
				<%=cong_trinh.TEN_CONG_TRINH %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=> Convert.ToDecimal(x.GHI_CHU_2))
								.Sum()%>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.TONG_MUC_DAU_TU)
								.Sum()%>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.THOI_GIAN_THUC_HIEN)
								.Sum()%>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
								.Sum()%>" />

			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS)
								.Sum()%>" />

			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_NS)
								.Sum()%>" />

			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_QUY_BT)
								.Sum()%>" />

			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
										+x.SO_TIEN_NS
										+x.SO_TIEN_QUY_BT)
								.Sum()%>" />

			</td>
		</tr>
		<%var lst_du_an = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU
												&& x.ID_CONG_TRINH == cong_trinh.ID_CONG_TRINH)
									.OrderBy(x => x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN)
									.ToList(); %>
		<%foreach (var du_an in lst_du_an)%>
		<%{%>
		<!--Level 3: Du an-->
		<tr class="du_an" id_giao_dich="<%=du_an.ID %>">
			<td style='width: 90px' class='text-center delete'>
				<!--Thao tac-->
				<input type='button' class='xoa_giao_dich btn btn-xs btn-danger private_don_vi' value='Xoá' onclick='F104.deleteGiaoDich(<%=du_an.ID%>)' />
				<input type='button' class='sua_giao_dich btn btn-xs btn-primary' value='Sửa' onclick='F104.editGiaoDich(<%=du_an.ID%>)' />
			</td>
			<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString()+du_an.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString() %>">
				<!--Nhiem vu chi-->
				<%="---"+du_an.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right"
					value="<%=du_an.GHI_CHU_2%>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=du_an.TONG_MUC_DAU_TU%>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=du_an.THOI_GIAN_THUC_HIEN%>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=du_an.SO_TIEN_NAM_TRUOC_CHUYEN_SANG %>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=du_an.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS %>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=du_an.SO_TIEN_NS %>" />
			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=du_an.SO_TIEN_QUY_BT %>" />
			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%=du_an.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
						+du_an.SO_TIEN_NS
						+du_an.SO_TIEN_QUY_BT%>" />

			</td>
		</tr>
		<%}%>

		<%}%>
		<%var lst_khoan = m_lst_gd
									.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU
										&& x.ID_KHOAN != null)
									.Select(x => new
									{
										ID_KHOAN = x.ID_KHOAN
										,
										TEN_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.TEN
										,
										MA_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO
										,
										TEN_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.TEN
										,
										MA_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
									})
									.Distinct()
									.OrderBy(x => x.MA_KHOAN)
									.ToList(); %>
		<%foreach (var khoan in lst_khoan)%>
		<%{%>
		<!--Level 2: Loai Khoan-->
		<tr class="loai_khoan">
			<td>
				<!--Thao tac-->

			</td>
			<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+""+khoan.ID_KHOAN %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
				<!--Nhiem vu chi-->
				<%="Loại "+khoan.MA_LOAI+" - "+khoan.MA_KHOAN %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>Convert.ToDecimal(x.GHI_CHU_2))
								.Sum()%>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.TONG_MUC_DAU_TU)
								.Sum()%>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.THOI_GIAN_THUC_HIEN)
								.Sum()%>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG)
								.Sum()%>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS)
								.Sum()%>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_NS)
								.Sum()%>" />

			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_QUY_BT)
								.Sum()%>" />

			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
										+x.SO_TIEN_NS
										+x.SO_TIEN_QUY_BT)
								.Sum()%>" />
			</td>
		</tr>
		<%var lst_muc = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU
											 && x.ID_KHOAN == khoan.ID_KHOAN
											 && x.ID_TIEU_MUC == null)
									.OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO)
									.ToList();%>
									.ToList(); %>
			<%foreach (var muc in lst_muc)%>
		<%{%>
		<!--Level 3: Muc-->
		<tr class="muc" id_giao_dich="<%=muc.ID %>">
			<td style='width: 90px' class='text-center delete'>
				<!--Thao tac-->
				<input type='button' class='xoa_giao_dich btn btn-xs btn-danger private_don_vi' value='Xoá' onclick='F104.deleteGiaoDich(<%=muc.ID%>)' />
				<input type='button' class='sua_giao_dich btn btn-xs btn-primary' value='Sửa' onclick='F104.editGiaoDich(<%=muc.ID%>)' />
			</td>
			<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
				<!--Nhiem vu chi-->
				<%="---Mục "+muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO+": "+muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.TEN %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right"
					value="<%=0 %>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=muc.TONG_MUC_DAU_TU%>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=muc.THOI_GIAN_THUC_HIEN%>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG %>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS %>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=muc.SO_TIEN_NS %>" />
			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=muc.SO_TIEN_QUY_BT %>" />
			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%=muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
						+muc.SO_TIEN_NS
						+muc.SO_TIEN_QUY_BT %>" />
			</td>
		</tr>
		<%}%>
		<%var lst_tieu_muc = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU
											 && x.ID_KHOAN == khoan.ID_KHOAN
											 && x.ID_TIEU_MUC != null)
									.OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO)
									.ToList();%>
		<!--Level 3: Tieu muc-->
		<%foreach (var tieu_muc in lst_tieu_muc)%>
		<%{%>
		<tr class="tieu_muc" id_giao_dich="<%=tieu_muc.ID %>">
			<td style='width: 90px' class='text-center delete'>
				<!--Thao tac-->
				<input type='button' class='xoa_giao_dich btn btn-xs btn-danger private_don_vi' value='Xoá' onclick='F104.deleteGiaoDich(<%=tieu_muc.ID%>)' />
				<input type='button' class='sua_giao_dich btn btn-xs btn-primary' value='Sửa' onclick='F104.editGiaoDich(<%=tieu_muc.ID%>)' />
			</td>
			<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+tieu_muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
				<!--Nhiem vu chi-->
				<%="---Mục "+tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO
						 +", Tiểu mục "+tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO+": "
						 +tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.TEN %>
			</td>
			<td>
				<!--Chieu dai tuyen-->
				<input type="text" class="so_km form-control text-right"
					value="<%=0 %>" />
			</td>
			<td>
				<!--Tong muc dau tu-->
				<input type="text" class="tong_muc_dau_tu form-control text-right format_so_tien"
					value="<%=tieu_muc.TONG_MUC_DAU_TU%>" />
			</td>
			<td>
				<!--Thoi gian thuc hien-->
				<input type="text" class="thoi_gian_thuc_hien form-control text-right format_so_tien"
					value="<%=tieu_muc.THOI_GIAN_THUC_HIEN%>" />
			</td>
			<td class="qbt">
				<!--Kinh phi nam truoc chuyen sang QBT-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_qbt form-control text-right format_so_tien"
					value="<%=tieu_muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG %>" />
			</td>
			<td class="ns">
				<!--Kinh phi nam truoc chuyen sang NS-->
				<input type="text" class="kinh_phi_nam_truoc_chuyen_sang_ns form-control text-right format_so_tien"
					value="<%=tieu_muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG_NS %>" />
			</td>
			<td>
				<!--Kinh phi ngan sach-->
				<input type="text" class="kinh_phi_ngan_sach form-control text-right format_so_tien"
					value="<%=tieu_muc.SO_TIEN_NS %>" />
			</td>
			<td>
				<!--Kinh phi quy bao tri-->
				<input type="text" class="kinh_phi_quy_bao_tri form-control text-right format_so_tien"
					value="<%=tieu_muc.SO_TIEN_QUY_BT %>" />
			</td>
			<td>
				<!--Tong cong-->
				<input type="text" class="grid_tong form-control text-right"
					value="<%=tieu_muc.SO_TIEN_NAM_TRUOC_CHUYEN_SANG
					 +tieu_muc.SO_TIEN_NS
					 +tieu_muc.SO_TIEN_QUY_BT%>" />
			</td>
		</tr>
		<%}%>
		<%}%>
		<%}%>
	<%--</tbody>
</table>--%>

