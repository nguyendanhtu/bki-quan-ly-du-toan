<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="F404Grid.ascx.cs" Inherits="QuanLyDuToan.UserControls.F404Grid" %>
<%--<div class="col-sm-12">
			<table style="width: 100%; border: 1px solid black" class="table table-hover" id="F404">
				<thead>
					<tr>
						<th>Nhiệm vụ chi</th>
						<th style="width: 100px" class="qbt">Giá trị thực hiện đã nghiệm thu A-B</th>
						<th style="width: 100px" class="ns">Giá trị thực hiện đã nghiệm thu A-B</th>
					</tr>
				</thead>
				<tbody>--%>
<!--Tong cong-->
<%if (m_lst_gd != null)%>
<%{%>


<tr style="font-weight: bold">
	<td class="text-center " id_giao_dich="-1" ma_so="0" ma_so_parent="-1">
		<!--Nhiem vu chi-->
		Tổng cộng</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu Quy bao tri A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd.Select(x=>Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU))
						.Sum() %>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu Ngan sach A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Select(x=>Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU_NS))
						.Sum() %>" />
	</td>
	<td class="text-right">
		<label class="so_tien"><%=m_lst_gd_luy_ke.Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=m_lst_gd.Sum(x=>Convert.ToDecimal(x.NHU_CAU_VON_KY_TIEP_THEO))%>" />
	</td>
</tr>
<%var lst_lnv = m_lst_gd.Select(x => new { ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU, TEN = x.CM_DM_TU_DIEN.TEN, GHI_CHU = x.CM_DM_TU_DIEN.GHI_CHU }).Distinct().OrderBy(x => x.GHI_CHU).ToList();%>
<%foreach (var lnv in lst_lnv)%>
<%{%>
<!--Level 1: Loai nhiem vu-->
<tr class="loai_nhiem_vu">
	<td id_giao_dich="-1" class="lnv" ma_so_parent="0" ma_so="<%=lnv.ID_LOAI_NHIEM_VU %>">
		<!--Nhiem vu chi-->
		<%=lnv.GHI_CHU+ " - "+lnv.TEN %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
						 .Sum() %>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
						 .Sum() %>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=m_lst_gd
						 .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU)
						 .Sum(x=>x.NHU_CAU_VON_KY_TIEP_THEO) %>" />
	</td>
</tr>
<%var lst_cong_trinh = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_CONG_TRINH != null).Select(x => new { ID_LOAI_NHIEM_VU = x.ID_LOAI_NHIEM_VU, ID_CONG_TRINH = x.ID_CONG_TRINH, TEN_CONG_TRINH = x.DM_CONG_TRINH_DU_AN_GOI_THAU_CONG_TRINH.TEN }).Distinct().OrderBy(x =>
									x.TEN_CONG_TRINH).ToList(); %>
<!--Level 2: Cong trinh--->
<%foreach (var cong_trinh in lst_cong_trinh)%>
<%{%>
<tr class="cong_trinh">
	<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+""+cong_trinh.ID_CONG_TRINH %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
		<!--Nhiem vu chi-->
		<%=cong_trinh.TEN_CONG_TRINH %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
								.Sum()%>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
								.Sum()%>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
                          &&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
									&&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH)
								.Sum(x=>x.NHU_CAU_VON_KY_TIEP_THEO)%>" />
	</td>
</tr>
<%var lst_du_an = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_CONG_TRINH == cong_trinh.ID_CONG_TRINH).OrderBy(x => x.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN).ToList(); %>
<%foreach (var du_an in lst_du_an)%>
<%{%>
<!--Level 3: Du an-->
<tr class="du_an" id_giao_dich="<%=du_an.ID %>">
	<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString()+du_an.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+cong_trinh.ID_CONG_TRINH.ToString() %>">
		<!--Nhiem vu chi-->
		<%="---" +du_an.DM_CONG_TRINH_DU_AN_GOI_THAU_DU_AN.TEN %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=du_an.SO_TIEN_DA_NGHIEM_THU%>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=du_an.SO_TIEN_DA_NGHIEM_THU_NS%>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
                          &&x.ID_CONG_TRINH==cong_trinh.ID_CONG_TRINH
                          &&x.ID_DU_AN==du_an.ID_DU_AN)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=du_an.NHU_CAU_VON_KY_TIEP_THEO%>" />
	</td>
</tr>
<%}%>
<%}%>
<%var lst_khoan = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN != null).Select(x => new
  {
	  ID_KHOAN = x.ID_KHOAN,
	  TEN_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.TEN,
	  MA_KHOAN = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.MA_SO,
	  TEN_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.TEN
	  ,
	  MA_LOAI = x.DM_CHUONG_LOAI_KHOAN_MUC_KHOAN.DM_CHUONG_LOAI_KHOAN_MUC_PARENT.MA_SO
  }).Distinct().OrderBy(x => x.MA_KHOAN).ToList(); %>
<%foreach (var khoan in lst_khoan)%>
<%{%>
<!--Level 2: Loai Khoan-->
<tr class="loai_khoan">
	<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU+""+khoan.ID_KHOAN %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU %>">
		<!--Nhiem vu chi-->
		<%="Loại " +khoan.MA_LOAI+ " - "+khoan.MA_KHOAN %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU)
								.Sum()%>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Select(x=>x.SO_TIEN_DA_NGHIEM_THU_NS)
								.Sum()%>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
                          &&x.ID_KHOAN==khoan.ID_KHOAN)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=m_lst_gd.Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
										&&x.ID_KHOAN==khoan.ID_KHOAN)
								.Sum(x=>x.NHU_CAU_VON_KY_TIEP_THEO)%>" />
	</td>
</tr>
<%var lst_muc = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN == khoan.ID_KHOAN && x.ID_TIEU_MUC == null).OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO).ToList();%> .ToList(); %>
																				<%foreach (var muc in lst_muc)%>
<%{%>
<!--Level 3: Muc-->
<tr class="muc" id_giao_dich="<%=muc.ID %>">
	<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
		<!--Nhiem vu chi-->
		<%="---Mục " +muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO+ ": "+muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.TEN %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=muc.SO_TIEN_DA_NGHIEM_THU%>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=muc.SO_TIEN_DA_NGHIEM_THU_NS%>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
                          &&x.ID_KHOAN==khoan.ID_KHOAN
                          &&x.ID_MUC==muc.ID_MUC)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=muc.NHU_CAU_VON_KY_TIEP_THEO%>" />
	</td>
</tr>
<%}%>
<%var lst_tieu_muc = m_lst_gd.Where(x => x.ID_LOAI_NHIEM_VU == lnv.ID_LOAI_NHIEM_VU && x.ID_KHOAN == khoan.ID_KHOAN && x.ID_TIEU_MUC != null).OrderBy(x => x.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO).ToList();%>
<!--Level 3: Tieu muc-->
<%foreach (var tieu_muc in lst_tieu_muc)%>
<%{%>
<tr class="tieu_muc" id_giao_dich="<%=tieu_muc.ID %>">
	<td ma_so="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString()+tieu_muc.ID.ToString() %>" ma_so_parent="<%=lnv.ID_LOAI_NHIEM_VU.ToString()+khoan.ID_KHOAN.ToString() %>">
		<!--Nhiem vu chi-->
		<%="---Mục " +tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_MUC.MA_SO + ", Tiểu mục "+tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.MA_SO+ ": " +tieu_muc.DM_CHUONG_LOAI_KHOAN_MUC_TIEU_MUC.TEN %>
	</td>
	<td class="qbt">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_qbt form-control text-right format_so_tien" value="<%=tieu_muc.SO_TIEN_DA_NGHIEM_THU%>" />
	</td>
	<td class="ns">
		<!--Giá trị thực hiện đã nghiệm thu A-B-->
		<input type="text" class="gia_tri_thuc_hien_ns form-control text-right format_so_tien" value="<%=tieu_muc.SO_TIEN_DA_NGHIEM_THU_NS%>" />
	</td>
	<td class="text-right">
		<label class="so_tien">
			<%=m_lst_gd_luy_ke
                   .Where(x=>x.ID_LOAI_NHIEM_VU==lnv.ID_LOAI_NHIEM_VU
                          &&x.ID_KHOAN==khoan.ID_KHOAN
                          &&x.ID_TIEU_MUC==tieu_muc.ID_TIEU_MUC)
                   .Select(x=> Convert.ToDecimal(x.SO_TIEN_DA_NGHIEM_THU + x.SO_TIEN_DA_NGHIEM_THU_NS)).Sum() %></label>
	</td>
	<td class="qbt">
		<!--Nhu cau von ky tiep theo-->
		<input type="text" class="nhu_cau_von_ky_tiep_theo form-control text-right format_so_tien" value="<%=tieu_muc.NHU_CAU_VON_KY_TIEP_THEO%>" />
	</td>
</tr>
<%}%>
<%}%>
<%}%>
<%--</tbody>
				<tfoot>
					<tr>
						<td colspan="3" class="text-center">
							<input type="button" class="btn btn-sm btn-success" id="m_cmd_luu_du_lieu" value="Lưu dữ liệu" />
							<input type="button" class="btn btn-sm btn-default" id="m_cmd_huy_thao_tac" value="Huỷ thao tác" />
						</td>
					</tr>
				</tfoot>
			</table>
		</div>--%>
<%}%>