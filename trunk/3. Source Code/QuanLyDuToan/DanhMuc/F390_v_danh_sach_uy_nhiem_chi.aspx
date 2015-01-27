<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F390_v_danh_sach_uy_nhiem_chi.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F390_v_danh_sach_uy_nhiem_chi" %>

<%@ Import Namespace="WebDS.CDBNames" %>
<%@ Import Namespace="IP.Core.IPCommon" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
	<script>
		function pageLoad(sender, args) {
		    if (args.get_isPartialLoad()) {
		        var m = new Map();
		        var today = new Date();
		        var mm = today.getMonth() + 1; //January is 0!
		        var yyyy = today.getFullYear();
		        m.set("<year>", yyyy);
		        m.set("<month>", mm);
		        m.set("<tu_ngay>", m_txt_tu_ngay.value);
		        m.set("<den_ngay>", m_txt_den_ngay.value);
		        getData("TPL_F390", "m_grv_bao_cao_giao_von", "Danh_sach_quyet_dinh_uy_nhiem_chi", m);

				$("#<%=m_ddl_don_vi.ClientID%>").select2();
				$(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
				var v_lst = $('.link206');
				for (var i = 0; i < v_lst.length; i++) {
					v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                    }
					$("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
                		var v_lst = $('.link206');
                		for (var i = 0; i < v_lst.length; i++) {
                			v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                        }
            });
				}
			}
	    $(document).ready(function () {
	        var m = new Map();
	        var today = new Date();
	        var mm = today.getMonth() + 1; //January is 0!
	        var yyyy = today.getFullYear();
	        m.set("<year>", yyyy);
	        m.set("<month>", mm);
	        m.set("<tu_ngay>", m_txt_tu_ngay.value);
	        m.set("<den_ngay>", m_txt_den_ngay.value);
	        getData("TPL_F390", "m_grv_bao_cao_giao_von", "Danh_sach_quyet_dinh_uy_nhiem_chi", m);

			$("#<%=m_ddl_don_vi.ClientID%>").select2();
				$(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
				var v_lst = $('.link206');
				for (var i = 0; i < v_lst.length; i++) {
					v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                }
            	$("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
            		var v_lst = $('.link206');
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
			<div style="width: 1100px; margin: auto; border: 1px solid">


				<div style="text-align: center;margin-bottom:-33px">
					<span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
					<br />
					<span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
					<br />
					<br />
					<span style="font-weight: bold">DANH SÁCH QUYẾT ĐỊNH ỦY NHIỆM CHI</span>
					<br />
					Đơn vị <asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" Width="200px"></asp:DropDownList>
				</div>
				<div style="color: black; text-align: left; margin: 50px">
					<table style="margin:50px auto; margin-top:20px; padding-top:">
						<tr style="height:59px">
							<td>Từ khóa tìm kiếm </td>
							<td colspan="4">
								<asp:TextBox runat="server" ID="m_txt_tu_khoa_tim_kiem" CssClass="form-control" Width="439px"></asp:TextBox>
								</td>
						</tr>
                        <tr>
							<td  style="text-align:right">Từ ngày </td>
							<td style="text-align:left">
								<asp:TextBox ClientIDMode="Static" runat="server" CssClass="form-control" ID="m_txt_tu_ngay" Style="width: 164px; text-align: right"></asp:TextBox></td>
							<td style="width:32px"></td>
							<td>Đến ngày </td>
							<td style="text-align:left">
								<asp:TextBox ClientIDMode="Static" runat="server" ID="m_txt_den_ngay" CssClass="form-control" Style="width: 164px; text-align: right"></asp:TextBox></td>
						</tr>
						<tr>
							<td style="height:10px"></td>
						</tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <div style="margin:0px auto;width: 400px;">
                                    <div style="width: 100px; margin: 0px auto;float: left;margin-left:195px">
                                        <asp:Button Width="91px" runat="server" CssClass="btn btn-primary btn-sm" Text="Tìm kiếm" ID="Button1" OnClick="m_cmd_tim_kiem_Click" />
                                    </div>
                                    <div id="downloadify" style="width: 100px; margin: 0px auto;float: left;">
				                        You must have Flash 10 installed to download this file.
			                        </div>
                                    <asp:Button runat="server" Visible="false" Text="Xuất excel" CssClass="btn btn-sm btn-primary" ID="m_cmd_xuat_excel" OnClick="m_cmd_xuat_excel_Click"></asp:Button>
                                </div>
                            </td>
                        </tr>
						
					</table>


					<div>


						<div style="text-align: center">
							<asp:Label ID="m_lbl_mess" runat="server" CssClass="cssManField"></asp:Label>
							<br />
							<asp:Label ID="m_lbl_info" runat="server" CssClass="cssManField"></asp:Label>
							<br />

						</div>
				<div style="width: 800px; margin: 20px auto;">
					<asp:GridView ClientIDMode="Static" runat="server" ID="m_grv_bao_cao_giao_von" Style="width: 100%;" AutoGenerateColumns="False" EnableModelValidation="True">
						<Columns>
							<asp:TemplateField HeaderText="Số UNC" ItemStyle-Width="150px">
								<ItemTemplate>
									<a class="link206" href='../DuToan/F304_nhap_giai_ngan_theo_unc.aspx?ip_dc_id_dm_giai_ngan=<%#Eval("ID") %>&ip_nguon_ns=<%#Eval("IS_NGUON_NS_YN") %>'
										title="Xem chi tiết"><%#  Eval("SO_UNC") %></a>
								</ItemTemplate>
							</asp:TemplateField>

							<asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center">
								<ItemStyle HorizontalAlign="Center" Width="150px"  />
							</asp:BoundField>
							<asp:BoundField HeaderText="Nguồn ngân sách" HtmlEncode="False" DataField="NGUON_NS_YN">
								<ItemStyle HorizontalAlign="Left" />
							</asp:BoundField>
							<asp:BoundField DataField="SO_TIEN_NOP_THUE" HeaderText="Số tiền nộp thuế" DataFormatString="{0:N0}">
								<ItemStyle HorizontalAlign="Right" Width="120px" />
							</asp:BoundField>
							<asp:BoundField DataField="SO_TIEN_TT_CHO_DV_HUONG" HeaderText="Số tiền thanh toán cho đơn vị hưởng" DataFormatString="{0:N0}">
								<ItemStyle HorizontalAlign="Right" Width="120px" />
							</asp:BoundField>
							<asp:TemplateField HeaderText="Tổng tiền" ItemStyle-HorizontalAlign="Right">
								<ItemTemplate><%#CIPConvert.ToStr(Eval("TONG_TIEN"),"#,###,##") %></ItemTemplate>
							</asp:TemplateField>
						</Columns>

					</asp:GridView>
				</div>
				
			</div>
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
