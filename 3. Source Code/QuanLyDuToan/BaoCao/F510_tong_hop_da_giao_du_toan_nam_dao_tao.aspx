<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="F510_tong_hop_da_giao_du_toan_nam_dao_tao.aspx.cs" Inherits="QuanLyDuToan.BaoCao.F510_tong_hop_da_giao_du_toan_nam_dao_tao" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
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
		    <span style="font-weight: bold">TỔNG HỢP ĐÃ GIAO DỰ TOÁN NĂM <asp:Label runat="server" Text="Label" ID="m_lbl_nam"></asp:Label> - ĐÀO TẠO (490-498; 490-497; 490-501)</span>
        </div>
        <div style="color:black; text-align:center; margin-top:20px;">
            <span>Từ khóa tìm kiếm: </span><asp:textbox runat="server" id="m_txt_tu_khoa_tim_kiem" style="width:200px;"></asp:textbox>
            <span> Từ ngày: </span><asp:textbox runat="server" id="m_txt_tu_ngay" style="width:200px;text-align:right"></asp:textbox>
            <span> Đến ngày: </span><asp:textbox runat="server" id="m_txt_den_ngay" style="width:200px; text-align:right"></asp:textbox>
            <asp:button runat="server" text="Tìm kiếm" id="m_cmd_tim_kiem"/>
        </div>
        <div style="width:1200px; margin:20px auto;">
            <asp:gridview runat="server" id="m_grv_bao_cao_giao_von" style="width:100%; margin-right: 0px;" AutoGenerateColumns="False" EnableModelValidation="True" OnRowCreated="m_grv_bao_cao_giao_von_RowCreated" OnRowDataBound="m_grv_bao_cao_giao_von_RowDataBound">
                <Columns>
                    <asp:BoundField DataField="A" HeaderText="STT" HtmlEncode="False" ShowHeader="False" >
                    <ItemStyle HorizontalAlign="Center" Height="90px" Width="15px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="B" HeaderText="Nội dung" HtmlEncode="False">
                    <ItemStyle />
                    </asp:BoundField>
                    <asp:BoundField DataField="C" HeaderText="Tổng số đã giao" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="D" HeaderText="Tổng số" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="E" HeaderText="Txuyên" HtmlEncode="False" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="F" HeaderText="KTxuyên" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="G" HeaderText="CMMTQG" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="H" HeaderText="Tsố" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="I" HeaderText="Chi TX" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="J" HeaderText="Chi KTX" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="K" HeaderText="Tsố" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="L" HeaderText="Chi TX" DataFormatString="{0:N0}">
                    <ItemStyle HorizontalAlign="Right" Width="90px" />
                    </asp:BoundField>
                </Columns>

            </asp:gridview>
        </div>
        <div style="text-align:center">
            <asp:Button runat="server" Text="Xuất excel" id="m_cmd_xuat_excel"></asp:Button>
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
