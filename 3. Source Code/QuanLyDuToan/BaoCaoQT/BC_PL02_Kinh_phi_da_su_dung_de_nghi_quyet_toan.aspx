<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BC_PL02_Kinh_phi_da_su_dung_de_nghi_quyet_toan.aspx.cs" Inherits="QuanLyDuToan.BaoCaoQT.BC_PL02_Kinh_phi_da_su_dung_de_nghi_quyet_toan" %>

<%@ Import Namespace="SQLDataAccess" %>
<%@ Import Namespace="WebUS" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .table > thead > tr > th {
            vertical-align: middle;
            border-bottom: 2px solid #ddd;
        }

        .clkm {
            width: 50px;
        }

        .so_tien {
            width: 80px;
        }

        .header-wrap {
            position: fixed;
            height: 200px;
            top: 0;
            width: 100%;
            z-index: 100;
        }

        #tblPL02 > thead > tr > th {
            border: 1px solid #000;
        }

        .so_tien {
            text-align: right;
        }

        #tblPL02 {
            background-color: white;
        }
    </style>
    <script src="../Scripts/jquery.doubleScroll.js"></script>
    <script src="../Scripts/fixHeader.js"></script>
    <script type="text/javascript">
        $(document).ready(function () {
            var lst = $('.so_tien');
            for (var i = 0; i < lst.length; i++) {
                $(lst[i]).text(formatString($(lst[i]).text()));
            }
            $("#<%=m_ddl_chon_nam.ClientID%>").select2();
        })

        $('#tblPL02').scrollbarTable();
        $('#double-scroll').doubleScroll();

        var idChuong =<%= ID_CHUONG_LOAI_KHOAN_MUC.CHUONG.ToString()%> +"";
                var idLoai =<%= ID_CHUONG_LOAI_KHOAN_MUC.LOAI.ToString()%> +"";
        var idKhoan =<%= ID_CHUONG_LOAI_KHOAN_MUC.KHOAN.ToString()%> +"";
        var idMuc =<%= ID_CHUONG_LOAI_KHOAN_MUC.MUC.ToString()%> +"";
        var idTieuMuc =<%=ID_CHUONG_LOAI_KHOAN_MUC.TIEU_MUC.ToString()%> +"";
        var m_lst_clkm = <%= Newtonsoft.Json.JsonConvert.SerializeObject(lst_clkm)%>;
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <h3 class="h3 text-center">PL02 - KINH PHÍ ĐÃ SỬ DỤNG ĐỀ NGHỊ QUYẾT TOÁN</h3>
    <div class="height30" style="margin: 0 auto;">
        <div class="control text-center">
            <span class="lb" style="font-weight: 300; font-size: medium">Năm</span>
            &nbsp;&nbsp;&nbsp;
            <asp:DropDownList ID="m_ddl_chon_nam" runat="server" Width="80px" AutoPostBack="True" CssClass="select2" OnSelectedIndexChanged="m_ddl_chon_nam_SelectedIndexChanged"></asp:DropDownList>
        </div>
    </div>
    <br />
    <div style="width: 1200px; margin: 0px auto" id="double-scroll">
        <table class='table table-hover table-bordered' style='width: 1200px; margin: auto' id="tblPL02">
            <thead style='vertical-align: middle'>
                <tr class='text-center'>
                    <th rowspan='2' class='clkm'>Loại</th>
                    <th rowspan='2' class='clkm'>Khoản</th>
                    <th rowspan='2' class='clkm'>Mục</th>
                    <th rowspan='2' class='clkm'>Tiểu mục</th>
                    <th rowspan='2' style='width: 200px'>Nội dung chi</th>
                    <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                      {%>
                    <th class="col-sm-1 text-center"><span><%=dvct%></span></th>
                    <%foreach (var don_vi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <th class="col-sm-1 text-center"><span><%=don_vi.TEN_DON_VI%></span></th>
                    <%}%>
                    <%}%>
                </tr>
            </thead>
            <tbody>
                <%foreach (var loai_ndc in lst_NDC)%>
                <%{%>
                <tr style='font-weight: bold; font-style: italic'>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td><%=loai_ndc %></td>

                    <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                      {%>
                    <td class="so_tien"><%=lst_pl02
							    .Where(x => x.LOAI==loai_ndc&&x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                    <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <td class="so_tien"><%=lst_pl02
							    .Where(x => x.LOAI==loai_ndc&&x.ID_DON_VI==donvi.ID_DON_VI)
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                    <%} %>
                    <% }%>
                </tr>
                <!--Loai-->

                <%foreach (var ma_loai in lst_pl02
                                        .Where(x => x.LOAI == loai_ndc)
                                        .Select(x => x.MA_LOAI)
                                        .Distinct()
                                        .ToList())%>
                <%{%>
                <tr style='font-weight: bold'>
                    <td><%=ma_loai %></td>
                    <td></td>
                    <td></td>
                    <td></td>
                    <td><%=lst_clkm
							.Where(x=>x.MaSo==ma_loai)
							.Select(x=>x.Ten)
							.FirstOrDefault() %></td>
                    <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                      {%>
                    <td class="so_tien"><%=lst_pl02
                                .Where(x => x.LOAI==loai_ndc&&x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                    <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <td class="so_tien"><%=lst_pl02
							.Where(x => x.MA_LOAI == ma_loai&&x.LOAI==loai_ndc&&x.ID_DON_VI == donvi.ID_DON_VI)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>

                    <%} %>
                    <%} %>
                </tr>
                <!--Khoan-->
                <%foreach (var ma_khoan in lst_pl02
                                     .Where(x => x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                     .Select(x => x.MA_KHOAN)
                                     .Distinct()
                                     .ToList())%>
                <%{%>
                <tr style='font-weight: bold'>
                    <td></td>
                    <td><%=ma_khoan %></td>
                    <td></td>
                    <td></td>
                    <td><%=lst_clkm.Where(x=>x.MaSo==ma_khoan).Select(x=>x.Ten).FirstOrDefault() %></td>
                    <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                      {%>
                    <td class="so_tien"><%=lst_pl02
                                .Where(x => x.LOAI==loai_ndc&&x.MA_KHOAN==ma_khoan&&x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                    <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <td class="so_tien"><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.LOAI==loai_ndc&&x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
                    <%} %>
                    <%} %>
                </tr>
                <!--Muc-->
                <%foreach (var ma_muc in lst_pl02
                                     .Where(x => x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                                     .Select(x => x.MA_MUC)
                                     .Distinct()
                                     .ToList())%>
                <%{%>
                <tr style='font-weight: bold'>
                    <td></td>
                    <td></td>
                    <td><%=ma_muc %></td>
                    <td></td>
                    <td><%=lst_clkm.Where(x=>x.MaSo==ma_muc).Select(x=>x.Ten).FirstOrDefault() %></td>
                    <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                      {%>
                    <td class="so_tien"><%=lst_pl02
                                .Where(x => x.LOAI==loai_ndc&&x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai&&x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                    <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                      {%>
                    <td class="so_tien"><%=lst_pl02
							.Where(x => x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.LOAI==loai_ndc&&x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x => x.SO_BAO_CAO)
							.ToList()
							.Sum()%></td>
                    <%} %>
                    <%} %>
                    <%foreach (var ma_tieu_muc in lst_pl02
                             .Where(x => x.MA_MUC == ma_muc && x.MA_KHOAN == ma_khoan && x.MA_LOAI == ma_loai && x.LOAI == loai_ndc)
                             .Select(x => x.MA_TIEU_MUC)
                             .Distinct()
                             .ToList())%>
                    <%{%>
                    <tr>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td><%=ma_tieu_muc %></td>
                        <td><%=lst_clkm.Where(x=>x.MaSo==ma_tieu_muc).Select(x=>x.Ten).FirstOrDefault() %></td>
                        <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                          {%>
                        <td class="so_tien"><%=lst_pl02
                                .Where(x => x.LOAI==loai_ndc&& x.MA_KHOAN == ma_khoan&&x.MA_LOAI==ma_loai&&x.MA_MUC==ma_muc&&x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                        <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                          {%>
                        <td class="so_tien"><%=lst_pl02
                            .Where(x=>x.ID_DON_VI==donvi.ID_DON_VI&&x.MA_TIEU_MUC==ma_tieu_muc).Distinct()
                            .Select(x=>x.SO_BAO_CAO)
                            .ToList()
                            .Sum() %></td>
                        <%} %>
                        <%} %>
                    </tr>
                    <%}%>
                    <%}%>
                    <%}%>
                    <%}%>
                    <%}%>
                    <tr style='font-weight: bold; font-style: italic"'>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td></td>
                        <td>Tổng cộng</td>
                        <%foreach (var dvct in new String[] { "Sở GTVT", "Cục QLĐB", "Ban QLDA" })
                          {%>
                        <td class="so_tien"><%=lst_pl02
                                .Where(x => x.DM_DON_VI.TEN_DON_VI.Contains(dvct.Split(' ')[0]))
							    .Select(x => (x.SO_BAO_CAO))
							    .ToList()
							    .Sum()%></td>
                        <%foreach (var donvi in lst_don_vi.Where(x => x.TEN_DON_VI.Contains(dvct.Split(' ')[0])).OrderBy(x => x.TEN_DON_VI))
                          {%>
                        <td class="so_tien"><%=lst_pl02.Where(x=>x.ID_DON_VI==donvi.ID_DON_VI)
							.Select(x => (x.SO_BAO_CAO))
							.ToList()
							.Sum()%></td>
                        <%} %>
                        <%} %>
                    </tr>
            </tbody>
            <tfoot>
            </tfoot>
        </table>
    </div>
</asp:Content>
