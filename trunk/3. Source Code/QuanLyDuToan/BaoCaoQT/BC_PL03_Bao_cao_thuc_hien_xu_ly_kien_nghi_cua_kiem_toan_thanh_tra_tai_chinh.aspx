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
    <table class="table table-hover" style="width: 2000px">

        <thead>
            <tr class="text-center">
                <th>TT</th>
                <th style="width: 150px">Nội dung</th>
                <th colspan="3">Số kiến nghị của</th>
                <th colspan="3">Số đã nộp trả Quỹ BTĐB TW trong năm nay</th>
                <th colspan="3">Số còn phải nộp Quỹ BTĐB TW</th>
                <%foreach (var dvct in LoaiDonVi) {%>
                <th colspan="3" class="col-sm-1 text-center"><span><%=dvct%></span></th>
                <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI)) {%>
                <th colspan="3" class="col-sm-1 text-center"><span><%=don_vi.TEN_DON_VI%></span></th>
                <%} %>
                <%} %>
                <%--                <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <th class="col-sm-1 text-center"><span><%=don_vi.TEN_DON_VI%></span></th>
                <%}%>--%>
            </tr>
            <tr>
                <th></th>
                <th></th>
                <%-- Header số kiến nghị của --%>
                <th>Tổng số</th>
                <th>Kiểm toán nhà nước</th>
                <th>Cơ quan nhà nước</th>
                <%-- Header Số đã nộp trả Quỹ BTĐB TW trong năm nay --%>
                <th>Tổng số</th>
                <th>Kiểm toán nhà nước</th>
                <th>Cơ quan nhà nước</th>
                <%-- Header Số còn phải nộp Quỹ BTĐB TW --%>
                <th>Tổng số</th>
                <th>Kiểm toán nhà nước</th>
                <th>Cơ quan nhà nước</th>
                <%-- Header các đơn vị --%>
                <%foreach (var dvct in LoaiDonVi) {%>
                <th class="col-sm-1 text-center"><span>Tổng số</span></th>
                <th class="col-sm-1 text-center"><span>Kiểm toán nhà nước</span></th>
                <th class="col-sm-1 text-center"><span>Cơ quan tài chính</span></th>
                <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI)) {%>
                <th class="col-sm-1 text-center"><span>Tổng số</span></th>
                <th class="col-sm-1 text-center"><span>Kiểm toán nhà nước</span></th>
                <th class="col-sm-1 text-center"><span>Cơ quan tài chính</span></th>
                <%} %>
                <%} %>
                <%-- <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <th class="col-sm-1 text-center"><span>Cơ quan tài chính</span></th>
                <%}%>--%>
            </tr>
        </thead>
        <tbody>
            <%foreach (var item in lst_PL03.Select(x => new { NoiDung = x.NOI_DUNG, MaSo = x.MA_SO, TT = x.TT }).Distinct().ToList()) {%>
            <tr>
                <%-- 1) Gen columns TT & Noi Dung --%>
                <td class="col-sm-1 text-center">
                    <span class=" tt <%= item.TT %>"><%= item.TT %></span>
                </td>
                <% string noi_dung; if (item.TT != null) { noi_dung = item.TT + "- " + item.NoiDung; }
                   else { noi_dung = item.TT + " " + item.NoiDung; }%>
                <td class="col-sm-3">
                    <strong class="ma_so_parent <%=item.NoiDung%>"><%=noi_dung%></strong>
                </td>
                <%-- 2) Gen columns Số kiến nghị --%>
                <%-- a) Tổng số --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH+x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                </td>
                <%-- b) Kiểm toám nhà nước --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                </td>
                <%-- c) Cơ quan tài chính --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).Sum()%></span>
                </td>
                <%-- 3) Gen columns  Số đã nộp trả Quỹ BTĐB TW trong năm nay --%>
                <%-- a) Tổng số --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH+x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                </td>
                <%-- b) Kiểm toám nhà nước --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                </td>
                <%-- c) Cơ quan tài chính --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH).Sum()%></span>
                </td>
                <%-- 4) Gen columns Số còn phải nộp Quỹ BTĐB TW --%>
                <%-- a) Tổng số --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>(x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC-x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC)+(x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH-x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH)).Sum()%></span>
                </td>
                <%-- b) Kiểm toám nhà nước --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC-x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                </td>
                <%-- c) Cơ quan tài chính --%>
                <td>
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==2014&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH-x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH).Sum()%></span>
                </td>
                <%-- 5) Gen columns các đơn vị --%>
                <%foreach (var don_vi in lst_don_vi.OrderBy(x => x.TEN_DON_VI
)) {%>
                <td style="text-align: right">
                    <span class="so_tien"><%=lst_PL03.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).FirstOrDefault() %></span>
                </td>
                <%}%>
            </tr>
            <%}%>
        </tbody>
    </table>
</asp:Content>
