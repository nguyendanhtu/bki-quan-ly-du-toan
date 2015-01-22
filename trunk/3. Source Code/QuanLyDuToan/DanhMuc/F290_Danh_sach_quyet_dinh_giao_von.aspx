<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F290_danh_sach_quyet_dinh_giao_von.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F290_danh_sach_quyet_dinh_giao_von" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
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
        <div style="text-align:center;">
            <span style="font-weight: bold">CỘNG HOÀ XÃ HỘI CHỦ NGHĨA VIỆT NAM</span>
		    <br />
		    <span style="font-weight: bold">Độc lập - Tự do - Hạnh Phúc</span>
		    <br />
		    <br />
		    <span style="font-weight: bold">DANH SÁCH QUYẾT ĐỊNH GIAO VỐN</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <tr>
									<td style="text-align: right">Đơn vị:</td>
									<td colspan="2">
										<asp:DropDownList ID="m_ddl_don_vi" CssClass="select2" runat="server" AutoPostBack="true" OnSelectedIndexChanged="m_ddl_don_vi_SelectedIndexChanged" Width="200px"></asp:DropDownList></td>
                </tr>
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
           <span>Từ ngày: </span>
		   <asp:TextBox runat="server" CssClass="datepicker" ID="m_txt_tu_ngay" Style="width: 150px; text-align: right"></asp:TextBox>
			<span>Đến ngày: </span>
			<asp:TextBox runat="server" ID="m_txt_den_ngay" CssClass="datepicker"  Style="width: 150px; text-align: right"></asp:TextBox>
            <asp:button runat="server" cssclass="btn" text="Tìm kiếm" id="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click"/>
        </div>
        <div style="width:1160px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Số quyết định" ItemStyle-Width="150px">
							<ItemTemplate>
							<a class="link405" href='../DuToan/F204_nhap_giao_von_QBT.aspx?ip_dc_id_quyet_dinh=<%#Eval("ID") %>'
                                            title"Xem chi tiết"><%#  Eval("SO_QUYET_DINH") %></a>
								</ItemTemplate>
						    <ItemStyle Width="150px" />
						</asp:TemplateField>
                    <asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG" DataFormatString="{0:d}">
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

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button CssClass="btn" runat="server" Text="Xuất excel" id="m_cmd_xuat_excel"></asp:Button>
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
