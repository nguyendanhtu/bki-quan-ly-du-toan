<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="tudm.aspx.cs" Inherits="QuanLyDuToan.Test.tudm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<style type="text/css">
		.loai_nhiem_vu, .loai_khoan, .cong_trinh {
			font-weight: bold;
		}
	</style>
	<script src="../Scripts/jquery.linq.js"></script>
	<script src="../Scripts/UI/F104_test.js"></script>
	<script src="../Scripts/linq.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

	<table style="width: 100%; border: 1px solid black" class="table table-hover" id="F104">
		
	</table>

</asp:Content>
