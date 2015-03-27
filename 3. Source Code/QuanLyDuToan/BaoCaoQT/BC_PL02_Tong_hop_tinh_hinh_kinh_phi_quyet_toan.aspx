<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL02_Tong_hop_tinh_hinh_kinh_phi_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL02_Tong_hop_tinh_hinh_kinh_phi_quyet_toan" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
            }
        })
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">TỔNG HỢP TÌNH HÌNH KINH PHÍ VÀ QUYẾT TOÁN CHI QŨY BẢO TRÌ ĐƯỜNG BỘ NĂM 2014</h3>
    <table class="col-sm-12 table table-hover">

        <thead>
            <tr class="text-center">
                <th>Mã số</th>
                <th>Chỉ tiêu</th>
                <%foreach (var don_vi in lst_don_vi.OrderBy(x=>x.TEN_DON_VI
)) {%>
                <th class="col-sm-1 text-center"><span><%=don_vi.TEN_DON_VI%></span></th>
                <%}%>
            </tr>
        </thead>
        <tbody>

            <%foreach (var item in lst_PL01.Select(x => new { ChiTieu = x.CHI_TIEU, MaSo = x.MA_SO }).Distinct().ToList()) {%>
            <tr>
                <td class="col-sm-1 text-center">
                    <span class=" ma_so <%= item.MaSo %>"><%= item.MaSo %></span>
                </td>
                <td class="col-sm-3">
                    <strong class="ma_so_parent <%= item.ChiTieu %>"><%= item.ChiTieu %></strong>
                </td>
                <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <td style="text-align:right">
                    <span class="so_tien"><%=lst_PL01.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_BAO_CAO).FirstOrDefault() %></span>
                </td>
                <%}%>
            </tr>
            <%}%>


        </tbody>
    </table>
</asp:Content>
