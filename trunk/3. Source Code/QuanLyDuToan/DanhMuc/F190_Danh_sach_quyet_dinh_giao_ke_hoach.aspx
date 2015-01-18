﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F190_Danh_sach_quyet_dinh_giao_ke_hoach.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F190_Danh_sach_quyet_dinh_giao_ke_hoach" %>

<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
               
                $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
                var v_lst = $('.link204');
                for (var i = 0; i < v_lst.length; i++) {
                    v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
            }
            $("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
                    var v_lst = $('.link204');
                    for (var i = 0; i < v_lst.length; i++) {
                        v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                }
            });
            }
        }
        $(document).ready(function () {
           
            $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
            var v_lst = $('.link204');
            for (var i = 0; i < v_lst.length; i++)
            {
                v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
            }
            $("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
                var v_lst = $('.link204');
                for (var i = 0; i < v_lst.length; i++) {
                    v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                }
            });
        }
       )
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
	</asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<div style="text-align: center;">
				<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
				<br />
				<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
				<br />
				<br />
				<span style="font-weight: bold">DANH SÁCH QUYẾT ĐỊNH GIAO KẾ HOẠCH</span>
			</div>
			<div style="color: black; text-align: center; margin-top: 20px;">
                <tr>
									<td style="text-align: right">Đơn vị:</td>
									<td colspan="2">
										<asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" Width="200px">

										</asp:DropDownList>

									</td>
                </tr>
				<span>Từ khóa tìm kiếm: </span>
				<asp:TextBox  runat="server" ID="m_txt_tu_khoa_tim_kiem" Style="width: 200px;"></asp:TextBox>
				<span>Từ ngày: </span>
				<asp:TextBox runat="server" CssClass="datepicker" ID="m_txt_tu_ngay" Style="width: 200px; text-align: right"></asp:TextBox>
				<span>Đến ngày: </span>
				<asp:TextBox runat="server" ID="m_txt_den_ngay" CssClass="datepicker"  Style="width: 200px; text-align: right"></asp:TextBox>
				<asp:Button runat="server" CssClass="btn" Text="Tìm kiếm" ID="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click" />
			</div>
			<div style="text-align: center">
				<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
				<br />
				<asp:Label ID="m_lbl_info" runat="server" CssClass="cssManField"></asp:Label>
				<br />

			</div>
			<div style="width: 800px; margin: 20px auto;">
				<asp:GridView runat="server" ID="m_grv_bao_cao_giao_von" Style="width: 100%;" AutoGenerateColumns="False" EnableModelValidation="True">
					<Columns>
						<asp:TemplateField HeaderText="Số quyết định" ItemStyle-Width="150px">
							<ItemTemplate>
							<a class="link204" href='../DuToan/f204_nhap_giao_ke_hoach_qbt.aspx?ip_dc_id_quyet_dinh=<%#Eval("ID") %>'
                                            title"Xem chi tiết"><%#  Eval("SO_QUYET_DINH") %></a>
								</ItemTemplate>
						</asp:TemplateField>
						
						<asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG" DataFormatString="{0:dd/MM/yyyy}">
							<ItemStyle HorizontalAlign="Right" Width="150px" />
						</asp:BoundField>
						<asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
							<ItemStyle HorizontalAlign="Left" />
						</asp:BoundField>
                        <asp:BoundField DataField="QBT" HeaderText="Số tiền Quỹ bảo trì" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="NS" HeaderText="Số tiền Ngân sách" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="120px" />
                    </asp:BoundField>
						<asp:TemplateField HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Right">
							<ItemTemplate><%#CIPConvert.ToStr(Eval("TONG"),"#,###,##") %></ItemTemplate>
						</asp:TemplateField>
					</Columns>

				</asp:GridView>
			</div>
			<div style="text-align: center">
				<asp:Button runat="server" Text="Xuất excel" ID="m_cmd_xuat_excel" OnClick="m_cmd_xuat_excel_Click"></asp:Button>
			</div>
            <div>
                <asp:TextBox ID="m_txt_so_quyet_dinh" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="m_txt_ngay_thang" runat="server" Visible="False"></asp:TextBox>
                <asp:TextBox ID="m_txt_noi_dung" runat="server" Visible="False"></asp:TextBox>
                <asp:DropDownList ID="m_ddl_loai_quyet_dinh_giao" runat="server" Visible="False"></asp:DropDownList>
            </div>
            <div>
                <asp:Button runat="server" Text="Thêm quyết định" ID="m_cmd_insert" OnClick="m_cmd_insert_Click" Visible="False"></asp:Button>
            </div>
		</ContentTemplate>
	</asp:UpdatePanel>
	<asp:UpdateProgress ID="UpdateProgress1" runat="server">
		<ProgressTemplate>
			<div class="cssLoadWapper">
				<div class="cssLoadContent">
					<img src="../Images/loadingBar.gif" alt="" />
					<p>
						Đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</ProgressTemplate>
	</asp:UpdateProgress>
</asp:Content>
