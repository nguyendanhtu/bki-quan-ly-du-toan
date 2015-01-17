<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F290_Danh_sach_quyet_dinh_giao_von.aspx.cs" Inherits="QuanLyDuToan.DanhMuc.F290_Danh_sach_quyet_dinh_giao_von" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script>
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
               
                $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });

            }
        }
        $(document).ready(function () {
         
            $(".datepicker").datepicker({ format: 'dd/mm/yyyy' });
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
		   <asp:TextBox runat="server" CssClass="datepicker" ID="m_txt_tu_ngay" Style="width: 200px; text-align: right"></asp:TextBox>
			<span>Đến ngày: </span>
			<asp:TextBox runat="server" ID="m_txt_den_ngay" CssClass="datepicker"  Style="width: 200px; text-align: right"></asp:TextBox>
            <asp:button runat="server" cssclass="btn" text="Tìm kiếm" id="m_cmd_tim_kiem" OnClick="m_cmd_tim_kiem_Click"/>
        </div>
        <div style="width:1160px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv" style="width:100%;" AutoGenerateColumns="False" EnableModelValidation="True">
                <Columns>
                    <asp:TemplateField HeaderText="Số quyết định" ItemStyle-Width="150px">
							<ItemTemplate>
							<a href='../DuToan/F405_giao_von_qbt.aspx?ip_dc_id_quyet_dinh=<%#Eval("ID") %>'
                                            title"Xem chi tiết"><%#  Eval("SO_QUYET_DINH") %></a>
								</ItemTemplate>
						</asp:TemplateField>
                    <asp:BoundField HeaderText="Nội dung" HtmlEncode="False" DataField="NOI_DUNG">
                    <ItemStyle HorizontalAlign="Left" />
                    </asp:BoundField>
                    <asp:BoundField HeaderText="Ngày tháng" HtmlEncode="False" DataField="NGAY_THANG" DataFormatString="{0:d}">
                    <ItemStyle HorizontalAlign="Right" Width="150px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="TEN_DON_VI" HeaderText="Đơn vị">
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
            <asp:Button runat="server" Text="Xuất excel" id="m_cmd_xuat_excel"></asp:Button>
        </div>
    </ContentTemplate>
        </asp:UpdatePanel>
	<asp:updateprogress id="updateprogress1" runat="server">
		<progresstemplate>
			<div class="cssloadwapper">
				<div class="cssloadcontent">
					<img src="../images/loadingbar.gif" alt="" />
					<p>
						đang gửi yêu cầu, hãy đợi ...
					</p>
				</div>
			</div>
		</progresstemplate>
	</asp:updateprogress>
</asp:Content>
