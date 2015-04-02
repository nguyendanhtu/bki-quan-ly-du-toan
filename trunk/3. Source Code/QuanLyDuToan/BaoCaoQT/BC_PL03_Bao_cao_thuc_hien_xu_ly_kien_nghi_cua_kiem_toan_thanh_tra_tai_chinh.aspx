<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh" %>

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
    <h3 class="h3 text-center">PL03 -BÁO CÁO THỰC HIỆN XỬ LÝ KIẾN NGHỊ CỦA KIỂM TOÁN, THANH TRA, TÀI CHÍNH NĂM 2014</h3>
    <h4 class="h4 text-center"><i>(Dùng cho đơn vị dự toán: cấp I, cấp II và cấp III)</i></h4>
    <table class="col-sm-12 table table-hover">

        <thead>
            <tr class="text-center">
                <th>TT</th>
                <th>Nội dung</th>
                <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <th class="col-sm-1 text-center"><span><%=don_vi.TEN_DON_VI%></span></th>
                <%}%>
            </tr>
        </thead>
        <tbody>

            <%foreach (var item in lst_PL03.Select(x => new { NoiDung = x.NOI_DUNG, MaSo = x.MA_SO, TT = x.TT }).Distinct().ToList()) {%>
            <tr>
                <%--   <td class="col-sm-1 text-center">
                    <span class=" ma_so <%= item.MaSo %>"><%= item.MaSo %></span>
                </td>--%>
                <td class="col-sm-1 text-center">
                    <span class=" tt <%= item.TT %>"><%= item.TT %></span>
                </td>
                <% string noi_dung; if (item.TT != null) { noi_dung = item.TT + "- " + item.NoiDung; }
                   else { noi_dung = item.TT + " " + item.NoiDung; }%>
                <td class="col-sm-3">
                    <strong class="ma_so_parent <%=item.NoiDung%>"><%=noi_dung%></strong>
                </td>
                <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <td style="text-align: right">
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_NHA_NUOC).FirstOrDefault() %></span>
                </td>
                <%}%>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
