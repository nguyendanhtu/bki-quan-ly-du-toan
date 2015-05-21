<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F404_nhap_khoi_luong.aspx.cs" Inherits="QuanLyDuToan.DuToan.F404_nhap_khoi_luong" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
		.cssFontBold {
			font-weight: bold;
		}

		.text-middle {
			margin-top: 7px;
		}

		.form-control {
			width: 100%;
			font-size: 11px;
			background-color: white;
		}

		.loai_nhiem_vu, .loai_khoan, .cong_trinh {
			font-weight: bold;
		}
		#F404 > thead > tr > th {
			border: 1px solid #000;
		}

		#F404 > tbody > tr > td {
			border-right: 1px solid #ddd;
		}

		#F404 {
			border-left: 1px solid #ddd;
			border-bottom: 1px solid #ddd;
		}
	</style>
	<script src="../Scripts/linq.js"></script>
	<script src="../Scripts/jquery.linq.js"></script>
	<script type="text/javascript">
		var m_dc_id_don_vi=<%=m_dc_id_don_vi%>;
		var m_lst_don_vi=<%= Newtonsoft.Json.JsonConvert.SerializeObject(m_lst_don_vi)%>;
		var m_str_nguon_ns="<%=m_str_nguon%>";
		var m_str_now='<%=DateTime.Now.Year%>';
	</script>
	<script src="../Scripts/UI/F404.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<div style="width: 1200px; margin: auto">

		<div class="col-sm-12 cssPageTitleBG">
			<label id="m_lbl_title" class="cssPageTitle"></label>
		</div>

		<div class="col-sm-12">
			<div style="width: 800px; margin: auto">
				<div class="col-sm-12">
					<div class="col-sm-1 text-right text-middle">Đơn vị</div>
					<div class="col-sm-3">
						<select id="m_ddl_don_vi" style="width: 200px"></select>
					</div>
					<div class="col-sm-2 text-right text-middle">Năm</div>
					<div class="col-sm-5">
						<input type="text" id="m_txt_nam" placeholder="vd: 2015" runat="server" class="form-control" style="width: 50px" value='<%# DateTime.Now.Year%>' />
						<select id="m_ddl_thang" style="width: 100px" runat="server">
							<option value='1'>Tháng 1</option>
							<option value='2'>Tháng 2</option>
							<option value='3'>Tháng 3</option>
							<option value='4'>Tháng 4</option>
							<option value='5'>Tháng 5</option>
							<option value='6'>Tháng 6</option>
							<option value='7'>Tháng 7</option>
							<option value='8'>Tháng 8</option>
							<option value='9'>Tháng 9</option>
							<option value='10'>Tháng 10</option>
							<option value='11'>Tháng 11</option>
							<option value='12'>Tháng 12</option>
						</select>
						<span class="radio-inline">
							<label>

								<input type="radio" name="ky_bao_cao" id="m_rdb_ky_1" checked="checked" />Kỳ 1</label>
							</span>
						<span class="radio-inline">
							<label>
								<input type="radio" name="ky_bao_cao" id="m_rdb_ky_2" />Kỳ 2
							</label>
							</span>
						
					</div>
					<div class="col-sm-1">
						<input type="button" class="btn btn-sm btn-primary" value="Tải dữ liệu" onclick="F404.reloadGrid()" />
					</div>
				</div>
			</div>
		</div>
		<div class="col-sm-12">
			<table style="width: 900px; margin: auto; border: 1px solid black" class="table table-hover" id="F404">
				<thead>
					<tr>
						<th>Nhiệm vụ chi</th>
						<th style="width: 100px" class="qbt">Phát sinh trong kỳ báo cáo</th>
						<th style="width: 100px" class="ns">Phát sinh trong kỳ báo cáo</th>
						<th style="width: 100px">Lũy kế đến trước kỳ báo cáo</th>
						<th style="width: 100px" class="qbt">Nhu cầu vốn kỳ kế tiếp</th>
					</tr>
				</thead>
				<tbody>
				</tbody>
				<tfoot>
					<tr>
						<td colspan="3" class="text-center">
							<input type="button" class="btn btn-sm btn-success private_don_vi" id="m_cmd_luu_du_lieu" value="Lưu dữ liệu" onclick="F404.updateAll()" />
							<input type="button" class="btn btn-sm btn-default" id="m_cmd_huy_thao_tac" value="Huỷ thao tác" onclick="F404.reloadGrid()" />
						</td>
					</tr>
				</tfoot>
			</table>
		</div>
		<div class="cssLoadWapper" style="display: none; z-index: 99999999" id="loading">
			<div class="cssLoadContent">
				<img src="../Images/loadingBar.gif" alt="" />
				<p>
					Đang gửi yêu cầu, hãy đợi ...
				</p>
			</div>
		</div>
	</div>
</asp:Content>


