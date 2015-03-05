<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F410_bao_cao_tinh_hinh_giao_von.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F410_bao_cao_tinh_hinh_giao_von" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="Server">
	<style type="text/css">
        .cssGrid tr td
        {
            padding: 0px;
        }
    </style>
     function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $("#<%=m_ddl_loai_nv.ClientID%>").select2();
                $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
                $("#<%=m_ddl_du_an.ClientID%>").select2();
                $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
                $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
               
            }
        }
        $(document).ready(function () 
        {
            $("#<%=m_ddl_loai_nv.ClientID%>").select2();
            $("#<%=m_ddl_cong_trinh.ClientID%>").select2();
            $("#<%=m_ddl_du_an.ClientID%>").select2();
            $("#<%=m_txt_tu_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
            $("#<%=m_txt_den_ngay.ClientID%>").datepicker({ format: 'dd/mm/yyyy' });
        }
       )
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="Server">
	<asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>

	<asp:UpdatePanel ID="UpdatePanel1" runat="server">
		<ContentTemplate>
			<table id="main_table" style="width: 900px;margin:auto;" class="cssTable table" border="0">
				<tr>
					<td colspan="4" style="text-align: center">
						<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
						<br />
						<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
						<br />
						<br />
						<span style="font-weight: bold">BÁO CÁO TÌNH HÌNH GIAO VỐN THEO ĐƠN VỊ <%=DateTime.Now.Year.ToString() %></span>
						<br />
                        <span>&nbsp;Tìm kiếm:
                            <asp:TextBox ID="m_txt_tim_kiem" runat="server"></asp:TextBox>
                        <br />
                        <span>&nbsp;Loại nhiệm vụ</span>
                            <asp:DropDownList ID="m_ddl_loai_nv" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_loai_nv_SelectedIndexChanged"></asp:DropDownList></span>
                        <span>&nbsp; Công trình
                            <asp:DropDownList ID="m_ddl_cong_trinh" runat="server" Width="100px" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_cong_trinh_SelectedIndexChanged"></asp:DropDownList></span>
                        <span>&nbsp; Dự án
                            <asp:DropDownList ID="m_ddl_du_an" runat="server" Width="100px"></asp:DropDownList></span>
                        <br />
						<span style="font-weight: bold">Từ ngày
							<asp:TextBox ID="m_txt_tu_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
                            <span>&nbsp; Đến ngày
							<asp:TextBox ID="m_txt_den_ngay" placeholder="dd/MM/yyyy" runat="server" CssClass="cssTextBox" Width="100px"></asp:TextBox></span>
                        </p>
                    </td>
                </tr>
                <tr>
                    <td colspan="4">
                        <asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
                    </td>
                </tr>

                <tr>

					<td colspan="4" style="text-align: center">
						<asp:Button ID="m_cmd_xem_bao_cao" Text="Xem báo cáo" OnClick="m_cmd_xem_bao_cao_Click" runat="server" />
						<asp:Button ID="m_cmd_xuat_excel" Text="Xuất file excel" runat="server" OnClick="m_cmd_xuat_excel_Click"/>
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:GridView ID="m_grv" runat="server" AutoGenerateColumns="false" DataKeyNames="ID"
							CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="Black"
							AllowSorting="True" PageSize="60" ShowHeader="true" AllowPaging="false"
							EmptyDataText="Không có dữ liệu phù hợp"
							OnRowDataBound="m_grv_RowDataBound">
							<Columns>
								<asp:BoundField DataField="NHIEM_VU_CHI" HeaderText="Nhiệm vụ chi" HtmlEncode="false" HeaderStyle-Width="300px" />
								<asp:TemplateField HeaderText="Tổng kế hoạch" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_grid_tong_kh" runat="server" 
											Text='<%#CIPConvert.ToStr(get_so_tien(Eval(RPT_BAO_CAO_GIAO_VON.TONG_KH).ToString()),"#,###,##") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField HeaderText="Tổng vốn quỹ bảo trì" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_grid_tong_qbt" runat="server" 
											Text='<%#CIPConvert.ToStr(get_so_tien(Eval(RPT_BAO_CAO_GIAO_VON.TONG_VON_QBT).ToString()),"#,###,##") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField  HeaderText="Tổng vốn ngân sách" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_grid_tong_ns" runat="server" 
											Text='<%#CIPConvert.ToStr(get_so_tien(Eval(RPT_BAO_CAO_GIAO_VON.TONG_VON_NS).ToString()),"#,###,##") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField  HeaderText="Số tiền năm trước chuyển sang" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_grid_tong_kh" runat="server" 
											Text='<%#CIPConvert.ToStr(get_so_tien(Eval(RPT_BAO_CAO_GIAO_VON.KH_NAM_TRUOC_CHUYEN_SANG).ToString()),"#,###,##") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>
								<asp:TemplateField  HeaderText="Tổng vốn" ItemStyle-HorizontalAlign="Right">
									<ItemTemplate>
										<asp:Label ID="m_lbl_grid_tong_von" runat="server" 
											Text='<%#CIPConvert.ToStr(get_so_tien(Eval(RPT_BAO_CAO_GIAO_VON.TONG_VON).ToString()),"#,###,##") %>'></asp:Label>
									</ItemTemplate>
								</asp:TemplateField>

							</Columns>
                           
						</asp:GridView>
					</td>
				</tr>
			</table>
		</ContentTemplate>
		<Triggers>
			 <asp:PostBackTrigger ControlID="m_cmd_xuat_excel" />
		</Triggers>
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


