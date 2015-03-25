﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="PL01_tong_hop_kinh_phi.aspx.cs" Inherits="QuanLyDuToan.QuyetToan.PL01_tong_hop_kinh_phi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script src="../Scripts/UI/PL01.js"></script>
	<%--<script src="../Scripts/BigInt.js"></script>--%>
	<style>
		.format_so_tien {
		text-align:right;
		}
	</style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
	<table class="col-sm-12 table table-hover">
		<thead>
			<tr class="text-center">
				<th class="col-sm-1" style="height: 50px;">Ma so</th>
				<th class="col-sm-3">Noi dung chi</th>
				<th class="col-sm-1">So bao cao</th>
				<th class="col-sm-1">So xet duyet</th>
				<th class="col-sm-1" style="display:none">Thao tac</th>
			</tr>
		</thead>
		<tbody>
			<%foreach (var item in lst_pl01)
	 { %>
			<tr>
				<td class="col-sm-1 text-center">
					<span class=" ma_so <%= item.MA_SO %>"><%= item.MA_SO %></span>
				</td>
				<td class="col-sm-3">
					<strong class="ma_so_parent <%= item.MA_SO_PARENT %>"><%= item.CHI_TIEU %></strong>
				</td>
				<td class="col-sm-1">
					<input type="text" class="form-control format_so_tien so_bao_cao <%= item.MA_SO %>" value="<%= item.SO_BAO_CAO %>" />
				</td>
				<td class="col-sm-1">
					<input type="text" class="form-control  format_so_tien so_xet_duyet <%= item.MA_SO %>" value="<%= item.SO_XET_DUYET %>" />
				</td>
				<td class="col-sm-1" style="display:none">
					<input type="button" class="btn btn-sm btn-success" value="Cap nhat" />
				</td>
			</tr>
			<%} %>
		</tbody>
	</table>
</asp:Content>
