<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="F290_danh_sach_quyet_dinh_giao_von.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F290_danh_sach_quyet_dinh_giao_von" %>

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
                getData("TPL_F290", "m_grv", "Bao_cao_quyet_dinh_giao_von", m);

                $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
                var v_lst = $('.link405');
                for (var i = 0; i < v_lst.length; i++) {
                    v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
                }
                $("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
                    var v_lst = $('.link405');
                    for (var i = 0; i < v_lst.length; i++) {
                        v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
			        }
                });
                $(".select2").select2();

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
            getData("TPL_F290", "m_grv", "Bao_cao_quyet_dinh_giao_von", m);

            $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
            $(".select2").select2();
            var v_lst = $('.link405');
            for (var i = 0; i < v_lst.length; i++) {
                v_lst[i].href = v_lst[i].href + "&ip_dc_id_don_vi=" + $("#<%=m_ddl_don_vi.ClientID%>").val();
            }
            $("#<%=m_ddl_don_vi.ClientID%>").on('change', function () {
                var v_lst = $('.link405');
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
            <div style="text-align: center; margin-bottom: -33px">
				<br />
                <span style="font-weight: bold">DANH SÁCH QUYẾT ĐỊNH GIAO VỐN</span>
                <br />
                Đơn vị
                <asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" AutoPostBack="true"
                    OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" Width="200px"></asp:DropDownList>
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
							<td style="width:100px;text-align:right">Đến ngày </td>
							<td style="text-align:left">
								<asp:TextBox ClientIDMode="Static" runat="server" ID="m_txt_den_ngay" CssClass="form-control" Style="width: 175px; text-align: right"></asp:TextBox></td>
						</tr>
						<tr>
							<td style="height:10px"></td>
						</tr>
                        <tr>
                            <td colspan="4" style="text-align: center">
                                <div style="margin:0px auto;width: 400px;">
                                    <div style="width: 100px; margin: 0px auto;float: left;margin-left:136px">
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
							<asp:Label ID="m_lbl_info" runat="server" CssClass="cssManField"></asp:Label>
						</div>
						<div style="width: 900px; margin: auto;">
							<asp:GridView ClientIDMode="Static" runat="server" ID="m_grv" Style="width: 100%;" AutoGenerateColumns="False"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Số quyết định" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <a class="link405" href='../DuToan/F204_nhap_giao_von_QBT.aspx?ip_dc_id_quyet_dinh=<%#Eval("ID") %>'
                                    title="Xem chi tiết"><%#  Eval("SO_QUYET_DINH") %></a>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG"
                            DataFormatString="{0:d}"  ItemStyle-HorizontalAlign="Center">
                            <ItemStyle HorizontalAlign="Center" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị" Visible="False">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QBT" HeaderText="Số tiền Quỹ bảo trì" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NS" HeaderText="Số tiền Ngân sách" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TONG" HeaderText="Tổng tiền" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                    </Columns>

                </asp:GridView>
						</div>
						<div style="text-align: center">
							<br />
							
						</div>
						<div>
							<asp:TextBox ID="m_txt_so_quyet_dinh" runat="server" Visible="False"></asp:TextBox>
							<asp:TextBox ID="m_txt_ngay_thang" runat="server" Visible="False"></asp:TextBox>
							<asp:TextBox ID="m_txt_noi_dung" runat="server" Visible="False"></asp:TextBox>
							<asp:DropDownList ID="m_ddl_loai_quyet_dinh_giao" runat="server" Visible="False"></asp:DropDownList>
						</div>
						
					</div>
		</ContentTemplate>
            <%--<span>Từ khóa tìm kiếm: </span>
            <asp:TextBox runat="server" ID="m_txt_tu_khoa_tim_kiem" Style="width: 200px;"></asp:TextBox>
            <span>Từ ngày: </span>
            <asp:TextBox runat="server" CssClass="datepicker" ID="m_txt_tu_ngay" Style="width: 150px;
                text-align: right"></asp:TextBox>
            <span>Đến ngày: </span>
            <asp:TextBox runat="server" ID="m_txt_den_ngay" CssClass="datepicker" Style="width: 150px;
                text-align: right"></asp:TextBox>
            <asp:Button runat="server" CssClass="btn" Text="Tìm kiếm" ID="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click" />
            </div>
			<div style="width: 1160px; margin: 20px auto;">
                <asp:GridView runat="server" ID="m_grv" Style="width: 100%;" AutoGenerateColumns="False"
                    EnableModelValidation="True">
                    <Columns>
                        <asp:TemplateField HeaderText="Số quyết định" ItemStyle-Width="150px">
                            <ItemTemplate>
                                <a class="link405" href='../DuToan/F204_nhap_giao_von_QBT.aspx?ip_dc_id_quyet_dinh=<%#Eval("ID") %>'
                                    title="Xem chi tiết"><%#  Eval("SO_QUYET_DINH") %></a>
                            </ItemTemplate>
                            <ItemStyle Width="150px" />
                        </asp:TemplateField>
                        <asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
                            <ItemStyle HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG"
                            DataFormatString="{0:d}">
                            <ItemStyle HorizontalAlign="Right" Width="150px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị" Visible="False">
                            <ItemStyle Width="200px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="QBT" HeaderText="Số tiền Quỹ bảo trì" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="NS" HeaderText="Số tiền Ngân sách" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="TONG" HeaderText="Tổng tiền" DataFormatString="{0:N0}">
                            <ItemStyle HorizontalAlign="Right" Width="120px" />
                        </asp:BoundField>
                    </Columns>

                </asp:GridView>
            </div>
            <div style="text-align: center">
                <asp:Button CssClass="btn btn-primary btn-sm" runat="server" Text="Xuất excel" ID="m_cmd_xuat_excel"
                    OnClick="m_cmd_xuat_excel_Click"></asp:Button>
            </div>
        </ContentTemplate>--%>
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
