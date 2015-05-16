<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL03_Bao_cao_thuc_hien_xu_ly_kien_nghi_cua_kiem_toan_thanh_tra_tai_chinh" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <script src="../Scripts/jquery.doubleScroll.js"></script>
    <script src="../Scripts/fixHeader.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var lstClassNotVisible = ['.so_ktnc', '.so_tong', '.ban_ktnc', '.ban_tong'];
            for (var i = 0; i < lstClassNotVisible.length; i++) {
                $(lstClassNotVisible[i]).css('display', 'none');
            }
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
            }
            $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            $('#tblPL03').scrollbarTable();
            $('#double-scroll').doubleScroll();
        })
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                $("#<%=m_ddl_chon_nam.ClientID%>").select2();
            }
            var lstClassNotVisible = ['.so_ktnc', '.so_tong', '.ban_ktnc', '.ban_tong'];
            for (var i = 0; i < lstClassNotVisible.length; i++) {
                $(lstClassNotVisible[i]).css('display', 'none');
            }
        }

    </script>
    <style>
        .so_ktnc, .so_tong, .ban_ktnc, .ban_tong {
            display: none;
        }

        #tblPL03 > thead > tr > th {
            border: 1px solid #000;
        }

        .so_tien {
            text-align: right;
        }

        #tblPL03 {
            background-color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">PL03 -BÁO CÁO THỰC HIỆN XỬ LÝ KIẾN NGHỊ CỦA KIỂM TOÁN, THANH TRA, TÀI CHÍNH</h3>
    <div class="control text-center">
        <span class="lb" style="font-weight: 300; font-size: medium">Năm</span>
        &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_chon_nam" runat="server" Width="80px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_chon_nam_SelectedIndexChanged"></asp:DropDownList>
    </div>
    <h4 class="h4 text-center"><i>(Dùng cho đơn vị dự toán: cấp I, cấp II và cấp III)</i></h4>
    <div style="width:1200px; margin:0px auto">
    <div id="double-scroll" width: 1200px">
        <table class="table-hover table-bordered cssTable" style="width:<%=width%>px" id="tblPL03">
            <thead style="border: 2px; border-radius: initial; border-bottom-color: black; border-bottom-style: double">
                <tr class="text-center">
                    <th rowspan="2" style="width:50px">TT</th>
                    <th style="width: 200px" rowspan="2">Nội dung</th>
                    <th colspan="3" style="width:300px">Số kiến nghị của</th>
                    <th colspan="3" style="width:300px">Số đã nộp trả Quỹ BTĐB TW trong năm nay</th>
                    <th colspan="3" style="width:300px">Số còn phải nộp Quỹ BTĐB TW</th>
                    <%foreach (var dvct in LoaiDonVi)
                      {%>
                    <th colspan="3" class="col-sm-1 text-center" style="width:300px"><span><%=dvct%></span></th>
                    <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <th colspan="1" class="col-sm-1 text-center" style="width:100px"><span><%=don_vi.TEN_DON_VI%></span></th>
                    <%} %>
                    <%} %>
                </tr>
                <tr>

                    <%-- Header số kiến nghị của --%>
                    <th style="width:100px">Tổng số</th>
                    <th style="width:100px">Kiểm toán nhà nước</th>
                    <th style="width:100px">Cơ quan nhà nước</th>
                    <%-- Header Số đã nộp trả Quỹ BTĐB TW trong năm nay --%>
                    <th style="width:100px">Tổng số</th>
                    <th style="width:100px">Kiểm toán nhà nước</th>
                    <th style="width:100px">Cơ quan nhà nước</th>
                    <%-- Header Số còn phải nộp Quỹ BTĐB TW --%>
                    <th style="width:100px">Tổng số</th>
                    <th style="width:100px">Kiểm toán nhà nước</th>
                    <th style="width:100px">Cơ quan nhà nước</th>
                    <%-- Header các đơn vị --%>
                    <%foreach (var dvct in LoaiDonVi)
                      {%>
                    <th class="col-sm-1 text-center" style="width:100px"><span>Tổng số</span></th>
                    <th class="col-sm-1 text-center" style="width:100px"><span>Kiểm toán nhà nước</span></th>
                    <th class="col-sm-1 text-center" style="width:100px"><span>Cơ quan tài chính</span></th>
                    <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <th class="col-sm-1 text-center <%=genClassCSS(don_vi.TEN_DON_VI,"tong")%>" style="width:100px"><span>Tổng số</span></th>
                    <th class="col-sm-1 text-center <%=genClassCSS(don_vi.TEN_DON_VI,"ktnc")%>" style="width:100px"><span>Kiểm toán nhà nước</span></th>
                    <th class="col-sm-1 text-center <%=genClassCSS(don_vi.TEN_DON_VI,"cqtc")%>" style="width:100px"><span>Cơ quan tài chính</span></th>
                    <%} %>
                    <%} %>
                </tr>
            </thead>
            <tbody>
                <%foreach (var item in lst_PL03.Select(x => new { NoiDung = x.NOI_DUNG, MaSo = x.MA_SO, TT = x.TT }).Distinct().ToList())
                  {%>
                <tr>
                    <%-- 1) Gen columns TT & Noi Dung --%>
                    <td class="col-sm-1 text-center" style="width:50px">
                        <span class=" tt <%= item.TT %>"><%= item.TT %></span>
                    </td>
                    <% string noi_dung; if (item.TT != null) { noi_dung = item.TT + "- " + item.NoiDung; }
                       else { noi_dung = item.TT + " " + item.NoiDung; }%>
                    <td class="col-sm-3" style="width:200px">
                        <strong class="ma_so_parent <%=item.NoiDung%>"><%=noi_dung%></strong>
                    </td>
                    <%-- 2) Gen columns Số kiến nghị --%>
                    <%-- a) Tổng số --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH+x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                    </td>
                    <%-- b) Kiểm toám nhà nước --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                    </td>
                    <%-- c) Cơ quan tài chính --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).Sum()%></span>
                    </td>
                    <%-- 3) Gen columns  Số đã nộp trả Quỹ BTĐB TW trong năm nay --%>
                    <%-- a) Tổng số --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH==null?0:x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH+x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                    </td>
                    <%-- b) Kiểm toám nhà nước --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC==null?0:x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                    </td>
                    <%-- c) Cơ quan tài chính --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH==null?0:x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH).Sum()%></span>
                    </td>
                    <%-- 4) Gen columns Số còn phải nộp Quỹ BTĐB TW --%>
                    <%-- a) Tổng số --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>(x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC-x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC)+(x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH-x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH)).Sum()%></span>
                    </td>
                    <%-- b) Kiểm toám nhà nước --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC-x.SO_DA_NOP_TRA_KIEM_TOAN_NHA_NUOC).Sum()%></span>
                    </td>
                    <%-- c) Cơ quan tài chính --%>
                    <td class="text-right" style="width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.NAM==m_dc_nam&&x.ID_DON_VI==x.DM_DON_VI.ID&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH-x.SO_DA_NOP_TRA_CO_QUAN_TAI_CHINH).Sum()%></span>
                    </td>
                    <%-- 5) Gen columns theo tổng loại đơn vị chỉ tính theo số kiến nghị --%>
                    <%foreach (var dvct in LoaiDonVi)
                      {%>
                    <%-- a) Tổng số --%>
                    <td style="text-align: right; width:100px">
                        <span class="so_tien" ><%=lst_PL03.Where(x=>x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0])&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH+x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).ToList().Sum() %></span>
                    </td>
                    <%-- b) Kiểm toám nhà nước --%>
                    <td style="text-align: right; width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0])&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).ToList().Sum() %></span>
                    </td>
                    <%-- c) Cơ quan tài chính --%>
                    <td style="text-align: right; width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0])&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).ToList().Sum() %></span>
                    </td>

                    <%-- 6) Gen columns theo đơn vị chỉ tính theo số kiến nghị --%>
                    <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI)
)
                      {%>
                    <%--a) Tổng số --%>
                    <td class="<%=genClassCSS(don_vi.TEN_DON_VI,"tong")%>" style="text-align: right; width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH+x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).FirstOrDefault() %></span>
                    </td>
                    <%-- b) Kiểm toám nhà nước --%>
                    <td class="<%=genClassCSS(don_vi.TEN_DON_VI,"ktnc")%>" style="text-align: right;  width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_KIEM_TOAN_NHA_NUOC).FirstOrDefault() %></span>
                    </td>
                    <%-- c) Cơ quan tài chính --%>
                    <td class="<%=genClassCSS(don_vi.TEN_DON_VI,"cqtc")%>" style="text-align: right;  width:100px">
                        <span class="so_tien"><%=lst_PL03.Where(x=>x.ID_DON_VI==don_vi.ID_DON_VI&&x.MA_SO==item.MaSo).Select(x=>x.SO_KIEN_NGHI_CO_QUAN_TAI_CHINH).FirstOrDefault() %></span>
                    </td>
                    <%}%>
                    <%}%>
                </tr>
                <%}%>
            </tbody>
        </table>
    </div>
        </div>
</asp:Content>
