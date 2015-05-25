<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F104_nhap_du_toan.aspx.cs" Inherits="QuanLyDuToan.DuToan.F104_nhap_du_toan" %>

<%@ Import Namespace="WebUS" %>
<%@ Import Namespace="DBClassModel" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.col-sm-12 {
			padding-right: 0px !important;
		}

		.table > thead > tr > th {
			border: 1px black solid;
			vertical-align: middle;
			/*border-bottom: 1px solid black;*/
			/*border-top: 1px solid black;*/
		}

		.table > tbody > tr > td {
			border-right: 1px #ddd solid;
		}

		.form-control {
			width: 100%;
			font-size: 11px;
			background-color: white;
		}

		pre {
			height: 31px;
			padding: 5px;
			border-radius: 1px;
		}

		#toolQuyetDinh {
			background-color: white;
			display: none;
		}

		.loai_nhiem_vu, .loai_khoan, .cong_trinh {
			font-weight: bold;
		}
	</style>
	<script src="../Scripts/jquery.bpopup.js"></script>
	<script src="../Scripts/linq.js"></script>
	<script src="../Scripts/jquery.linq.js"></script>
	<script src="../Scripts/UI/F104.js"></script>
	<script type="text/javascript">
		
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_lst_clkm=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_clkm)%>;
		var m_lst_ct_da_gt=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_ct_da_gt)%>;
		var m_lst_quyet_dinh=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_quyet_dinh)%>;
		var m_lst_loai_nhiem_vu=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_loai_nhiem_vu)%>;
		var LOAI_NHIEM_VU_QBT=<%=ID_LOAI_TU_DIEN.LOAI_NHIEM_VU%>;
		var LOAI_NHIEM_VU_NS=<%=ID_LOAI_TU_DIEN.LOAI_NHIEM_VU_NS%>;
		var KH_DAU_NAM=<%=ID_LOAI_GIAO_DICH.KH_DAU_NAM%>;
		var BO_SUNG=<%=ID_LOAI_GIAO_DICH.BO_SUNG%>;
		var DIEU_CHINH=<%=ID_LOAI_GIAO_DICH.DIEU_CHINH%>;
		var ID_CONG_TRINH=<%=ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.CONG_TRINH%>;
		var ID_DU_AN=<%=ID_LOAI_CONG_TRINH_DU_AN_GOI_THAU.DU_AN%>;
		var ID_CHUONG=<%=ID_CHUONG_LOAI_KHOAN_MUC.CHUONG%>;
		var ID_LOAI=<%=ID_CHUONG_LOAI_KHOAN_MUC.LOAI%>;
		var ID_KHOAN=<%=ID_CHUONG_LOAI_KHOAN_MUC.KHOAN%>;
		var ID_MUC=<%=ID_CHUONG_LOAI_KHOAN_MUC.MUC%>;
		var ID_TIEU_MUC=<%=ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC%>;
		var m_lst_gd=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_gd)%>;
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
		var m_str_nguon_ns="<%=m_str_nguon%>";
		
	</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server" ClientIDMode="Static">
	<div style="width: 1250px; margin: auto">
		<div class="col-sm-12" style="border: 1px solid #ddd; width: 100%">
			<div style="border: 1px solid #ddd; padding: 0px; width: 385px; display: block; float: left">
				<div class="col-sm-12">
					<div class="col-sm-12">
						<pre>Thông tin chung</pre>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Đơn vị</div>
						<div class="col-sm-8">
							<select id="m_ddl_don_vi" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Quyết định</div>
						<div class="col-sm-8">
							<select id="m_ddl_quyet_dinh" style="width: 210px"></select>
							<button type="button" id="toolButton" class="btn btn-xs btn-primary glyphicon glyphicon-cog" onclick="F104.openTool()"></button>
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Loại quyết định</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_loai_quyet_dinh" class="form-control" style="width: 100%" disabled="disabled" />
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Ngày tháng</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_ngay_thang" class="form-control" style="width: 100%" disabled="disabled" />
						</div>
						<div class="col-sm-2"></div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Nội dung</div>
						<div class="col-sm-8">
							<textarea id="m_txt_noi_dung" rows="2" class="form-control" style="width: 100%; background-color: #eee;" disabled="disabled"></textarea>
						</div>
					</div>
				</div>
				<div class="col-sm-12">
					<div class="col-sm-12">
						<pre>Chi tiết theo Quyết định</pre>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">
							Chi theo(*)
						</div>
						<div class="col-sm-8">
							<span class="radio-inline nguon_quy_bao_tri">
								<label>
									<input type="radio" name="chi_theo" id="m_rdb_theo_du_an" checked="checked" />Theo dự án</label></span>
							<span class="radio-inline" style="margin-left: 0px">
								<label>
									<input type="radio" name="chi_theo" id="m_rdb_theo_muc_luc_ngan_sach" />Theo mục lục ngân sách</label></span>
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Loại nhiệm vụ(*)</div>
						<div class="col-sm-8">
							<select id="m_ddl_loai_nhiem_vu" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_du_an">
						<div class="col-sm-4 text-right">Công trình/Quốc lộ(*)</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_cong_trinh" class="form-control" placeholder="Nhập mới hoặc tìm kiếm Công trình/Quốc lộ..." style="width: 100%; background-color: white" list="dtl_cong_trinh" />
							<datalist id="dtl_cong_trinh"></datalist>
						</div>
					</div>
					<div class="col-sm-12 theo_du_an">
						<div class="col-sm-4 text-right">Dự án(*)</div>
						<div class="col-sm-8">
							<textarea id="m_txt_du_an" rows="3" class="form-control" placeholder="Nhập mới hoặc tìm kiếm Dự án..." style="width: 100%; background-color: white;">
								</textarea>

							<datalist id="dtl_du_an"></datalist>
						</div>
					</div>
					<div class="col-sm-12 theo_du_an">
						<div class="col-sm-4 text-right">Tổng mức đầu tư(*)</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_tong_muc_dau_tu" value="0" class="form-control  format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12 theo_du_an">
						<div class="col-sm-4 text-right" style="font-size:11px">Thời gian thực hiện(*)</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_thoi_gian_thuc_hien" value="0" class="form-control  format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Chương</div>
						<div class="col-sm-8">
							<select id="m_ddl_chuong" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Loại</div>
						<div class="col-sm-8">
							<select id="m_ddl_loai" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Khoản</div>
						<div class="col-sm-8">
							<select id="m_ddl_khoan" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Mục</div>
						<div class="col-sm-8">
							<select id="m_ddl_muc" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Tiểu mục</div>
						<div class="col-sm-8">
							<select id="m_ddl_tieu_muc" style="width: 100%"></select>
						</div>
					</div>
					<div class="col-sm-12 theo_muc_luc_ngan_sach">
						<div class="col-sm-4 text-right">Nội dung dự toán(*)</div>
						<div class="col-sm-8">
							<input type="text" class="form-control" id="m_txt_noi_dung_du_toan" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12 nguon_ngan_sach">
						<div class="col-sm-4 text-right">
							Loại chi
						</div>
						<div class="col-sm-8">
							<span class="radio-inline muc_luc_ngan_sach ">
								<label>
									<input type="radio" name="loai_chi" id="m_rdb_chi_thuong_xuyen" checked="checked" />Chi thường xuyên</label></span>
							<span class="radio-inline" style="margin-left: 0px">
								<label>
									<input type="radio" name="loai_chi" id="m_rdb_chi_khong_thuong_xuyen" />Chi không thường xuyên</label></span>
						</div>
					</div>
					<div class="col-sm-12 theo_du_an nguon_quy_bao_tri">
						<div class="col-sm-4 text-right">Chiều dài tuyến (km)</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_chieu_dai_tuyen" value="0" class="form-control text-right" style="width: 100%" placeholder="vd: 1120.25" title="vd: 1120.25" />
						</div>
					</div>
					<!--Kinh phi nam truoc chuyen sang QBT-->
					<div class="col-sm-12 qbt" id="div_kinh_phi_nam_truoc_chuyen_sang">
						<div class="col-sm-4 text-right">KP năm trước CS</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_kinh_phi_nam_truoc_chuyen_sang_qbt" value="0" class="form-control   format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<!--Kinh phi nam truoc chuyen sang NS-->
					<div class="col-sm-12 ns" id="div1">
						<div class="col-sm-4 text-right">KP năm trước CS</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_kinh_phi_nam_truoc_chuyen_sang_ns" value="0" class="form-control   format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12 nguon_quy_bao_tri" id="div_kinh_phi_quy_bao_tri">
						<div class="col-sm-4 text-right">KP Quỹ bảo trì</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_kinh_phi_quy_bao_tri" value="0" class="form-control   format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12 nguon_ngan_sach">
						<div class="col-sm-4 text-right">KP Ngân sách</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_kinh_phi_ngan_sach" value="0" class="form-control  format_so_tien text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Tổng</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_tong" value="0" class="form-control text-right" style="width: 100%" />
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right">Ghi chú</div>
						<div class="col-sm-8">
							<input type="text" id="m_txt_ghi_chu" style="word-break: break-word; vertical-align: top; height: 80px; width: 100%" class="form-control" />
						</div>
					</div>
					<div class="col-sm-12">
						<div class="col-sm-4 text-right"></div>
						<div class="col-sm-8" style="padding-top: 12px">
							<input type="button" id="m_cmd_ghi_du_lieu" value="Ghi dữ liệu" class="btn btn-sm btn-success private_don_vi" onclick="F104.insertGiaoDich()" />
							<input type="button" id="m_cmd_huy_thao_tac" value="Huỷ thao tác" class="btn btn-sm btn-default" onclick="F104.cancel()" />
						</div>
					</div>
				</div>
			</div>
			<div style="border: 1px solid #ddd; padding-right: 0px; width: 860px; display: block; float: left">
				<%--<div class="col-sm-12">
					<pre>Quyết định số: <label id="m_lbl_quyet_dinh_so"></label> ngày <label id="m_lbl_ngay"></label> về việc <label id="m_lbl_ve_viec"></label> </pre>
				</div>--%>
				<div class="col-sm-12">
					<table style="width: 100%; border: 1px solid black" class="table table-hover" id="F104">
						<thead>
							<tr>
								<th rowspan="2" style="width: 90px">
									<input type="button" value="Lưu dữ liệu" class="btn btn-success btn-sm private_don_vi" style="height: 60px" onclick="F104.updateAll()" />
								</th>
								<th rowspan="2">Nhiệm vụ chi</th>
								<th rowspan="2" style="width: 50px">Chiều dài tuyến (km)</th>
								<th rowspan="2" style="width: 100px">Tổng mức đầu tư/Tổng dự toán</th>
								<th rowspan="2" style="width: 50px">Thời gian thực hiện</th>
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
						<tbody>
						</tbody>
						<tfoot></tfoot>
					</table>
				</div>
			</div>
		</div>
	</div>
	<div class="cssLoadWapper" style="display: none; z-index: 99999999" id="loading">
		<div class="cssLoadContent">
			<img src="../Images/loadingBar.gif" alt="" />
			<p>
				Đang gửi yêu cầu, hãy đợi ...
			</p>
		</div>
	</div>
	<div id='toolQuyetDinh' class='popup' style='width: 700px; display: none; z-index: 1000' id_giao_dich='-1' ma_so_parent='-1'>
		<h4 id='detail-title' class='text-center' style='border-bottom: 1px solid black; font-weight: bolder'>Sao chép danh sách dự án/Công trình (Khoản/Mục) từ Quyết định khác</h4>

		<div class='popup-content' style='margin: 30px'>
			<div class='col-sm-12 row'>
				<div class="col-sm-2 text-center">
					<label>Từ Quyết định:</label>
				</div>
				<div class="col-sm-4">
					<select id="m_ddl_quyet_dinh_1" style="width: 100%;"></select>
				</div>
				<div class="col-sm-2 text-center">
					<label>Sang quyết định:</label>
				</div>
				<div class="col-sm-4">
					<select id="m_ddl_quyet_dinh_2" style="width: 100%;"></select>
				</div>
			</div>

			<div class='col-sm-12 text-center' style='margin-bottom: 30px; margin-top: 20px'>
				<input type="button" id="m_cmd_thuc_hien_sao_chep" class="btn btn-sm btn-primary" value="Thực hiện" onclick="F104.excuteTool()" />
				<input type='button' class='btn btn-sm btn-default' value='Huỷ thao tác' onclick='F104.closeTool()' />
			</div>
		</div>
	</div>
</asp:Content>
