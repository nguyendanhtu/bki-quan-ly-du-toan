<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="f205_nhap_giao_ke_hoach_qbt.aspx.cs" Inherits="QuanLyDuToan.DuToan.f205_nhap_giao_ke_hoach_qbt" %>

<%@ Import Namespace="IP.Core.IPCommon" %>
<%@ Import Namespace="WebDS.CDBNames" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style>
        .align_right {
            text-align:right;
        }

        .lbl {
            width: 180px;
            float: left;
            margin-top: 5px;
        }

        .ctr {
            width: 260px;
            float: left;
            margin-top: 5px;
        }

        input[type="text"] {
            width: 180px !important;
            border: 1px solid #C9BDAB;
        }

        select {
            width: 184px !important;
            border: 1px solid #C9BDAB;
        }
    </style>
    <script type="text/javascript">
        function pageLoad(sender, args) {
            if (args.get_isPartialLoad()) {
                function xoaDauPhay(str) {
                    str2 = "";
                    str += "";
                    for (i = 0; i < str.length; i++) {
                        if (!isNaN(str[i])) {
                            str2 += str[i];
                        }
                    }
                    return str2;
                }

                function formatString(str) {
                    var index = 0;
                    var count_comma = 0;
                    var str2 = "";
                    for (i = str.length - 1; i >= 0; i--) {
                        if (!isNaN(str[i])) {
                            str2 = str[i] + str2;
                            index += 1;
                            if (index % 3 == 0 && index != str.length - count_comma) {
                                str2 = "," + str2;
                            }
                        }
                        else {
                            count_comma += 1;
                        }
                    }
                    return str2;
                }

                function tinhTong(str1, str2) {
                    if ((str1 + "").length == 0) {
                        str1 = "0";
                    }
                    if ((str2 + "").length == 0) {
                        str2 = "0";
                    }
                    return formatString((parseFloat(xoaDauPhay(str1)) + parseFloat(xoaDauPhay(str2))).toString());
                }
                var isChecked = $('#<%=chiTheoQuocLoDuAn.ClientID%>').attr('checked') ? true : false;
                if (isChecked == true) {
                    $("#group_qlda").show();
                    $("#group_lkm").hide();
                }
                else {
                    $("#group_qlda").hide();
                    $("#group_lkm").show();
                }
                $("#m_cmd_chon_quyet_dinh_co_san").click(function () {
                    $("#group_standard").hide();
                    $("#group_advanced").show();
                    $("#m_cmd_them_quyet_dinh_khac").show();
                    $("#<%=m_cmd_them_moi_quyet_dinh.ClientID%>").hide();
                    $(this).hide();
                });

                $("#m_cmd_them_quyet_dinh_khac").click(function () {
                    $("#group_standard").show();
                    $("#group_advanced").hide();
                    $("#m_cmd_chon_quyet_dinh_co_san").show();
                    $("#<%=m_cmd_them_moi_quyet_dinh.ClientID%>").show();
                    $(this).hide();
                });

                $("#<%=chiTheoQuocLoDuAn.ClientID%>").click(function () {
                    $("#group_qlda").show();
                    $("#group_lkm").hide();
                    $("#<%=m_ddl_loai_nhiem_vu.ClientID%>").show();
                        $("#<%=m_ddl_loai_nhiem_vu_lkm.ClientID%>").hide();
                });
                $("#<%=chiTheoLoaiKhoanMuc.ClientID%>").click(function () {
                    $("#group_qlda").hide();
                    $("#group_lkm").show();
                    $("#<%=m_ddl_loai_nhiem_vu.ClientID%>").hide();
                    $("#<%=m_ddl_loai_nhiem_vu_lkm.ClientID%>").show();
                });
                $("#<%=m_txt_kinh_phi_nam_truoc_chuyen_sang.ClientID%>").keyup(function () {
                    $(this).val(formatString($(this).val()));
                    document.getElementById("m_lbl_tong_chi_ktx").innerHTML = tinhTong($(this).val(), $("#<%=m_txt_kinh_phi_quy_bao_tri.ClientID%>").val());
                });

                $("#<%=m_txt_kinh_phi_quy_bao_tri.ClientID%>").keyup(function () {
                    $(this).val(formatString($(this).val()));
                    document.getElementById("m_lbl_tong_chi_ktx").innerHTML = tinhTong($(this).val(), $("#<%=m_txt_kinh_phi_nam_truoc_chuyen_sang.ClientID%>").val());
                });
            }
        }
        $(document).ready(function () {
            function xoaDauPhay(str) {
                str2 = "";
                str += "";
                for (i = 0; i < str.length; i++) {
                    if (!isNaN(str[i])) {
                        str2 += str[i];
                    }
                }
                return str2;
            }

            function formatString(str) {
                var index = 0;
                var count_comma = 0;
                var str2 = "";
                for (i = str.length - 1; i >= 0; i--) {
                    if (!isNaN(str[i])) {
                        str2 = str[i] + str2;
                        index += 1;
                        if (index % 3 == 0 && index != str.length - count_comma) {
                            str2 = "," + str2;
                        }
                    }
                    else {
                        count_comma += 1;
                    }
                }
                return str2;
            }

            function tinhTong(str1, str2) {
                if ((str1 + "").length == 0) {
                    str1 = "0";
                }
                if ((str2 + "").length == 0) {
                    str2 = "0";
                }
                return formatString((parseFloat(xoaDauPhay(str1)) + parseFloat(xoaDauPhay(str2))).toString());
            }
            var isChecked = $('#<%=chiTheoQuocLoDuAn.ClientID%>').attr('checked') ? true : false;
            if (isChecked == true) {
                $("#group_qlda").show();
                $("#group_lkm").hide();
            }
            else {
                $("#group_qlda").hide();
                $("#group_lkm").show();
            }

            $("#m_cmd_chon_quyet_dinh_co_san").click(function () {
                $("#group_standard").hide();
                $("#group_advanced").show();
                $("#m_cmd_them_quyet_dinh_khac").show();
                $("#<%=m_cmd_them_moi_quyet_dinh.ClientID%>").hide();
                $(this).hide();
            });

            $("#m_cmd_them_quyet_dinh_khac").click(function () {
                $("#group_standard").show();
                $("#group_advanced").hide();
                $("#m_cmd_chon_quyet_dinh_co_san").show();
                $("#<%=m_cmd_them_moi_quyet_dinh.ClientID%>").show();
                $(this).hide();
            });

            $("#<%=chiTheoQuocLoDuAn.ClientID%>").click(function () {
                $("#group_qlda").show();
                $("#group_lkm").hide();
                $("#<%=m_ddl_loai_nhiem_vu.ClientID%>").show();
                $("#<%=m_ddl_loai_nhiem_vu_lkm.ClientID%>").hide();
            });
            $("#<%=chiTheoLoaiKhoanMuc.ClientID%>").click(function () {
                $("#group_qlda").hide();
                $("#group_lkm").show();
                $("#<%=m_ddl_loai_nhiem_vu.ClientID%>").hide();
                $("#<%=m_ddl_loai_nhiem_vu_lkm.ClientID%>").show();
            });

            $("#<%=m_txt_kinh_phi_nam_truoc_chuyen_sang.ClientID%>").keyup(function () {
                $(this).val(formatString($(this).val()));
                document.getElementById("m_lbl_tong_chi_ktx").innerHTML = tinhTong($(this).val(), $("#<%=m_txt_kinh_phi_quy_bao_tri.ClientID%>").val());
            });

            $("#<%=m_txt_kinh_phi_quy_bao_tri.ClientID%>").keyup(function () {
                $(this).val(formatString($(this).val()));
                document.getElementById("m_lbl_tong_chi_ktx").innerHTML = tinhTong($(this).val(), $("#<%=m_txt_kinh_phi_nam_truoc_chuyen_sang.ClientID%>").val());
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div style="width: 1300px; height: 700px; border: 1px solid #C9BDAB">
                <div style="width: 1280px; height: 40px; background-color: #007acf; margin: 3px auto;">
                </div>
                <div style="width: 1280px; height: 650px; margin: 3px auto;">
                    <div style="width: 510px; height: 650px; float: left;">
                        <fieldset>
                            <legend>Thông tin chung</legend>
                            <div class="lbl">Loại quyết định (*)</div>
                            <div class="ctr">
                                <asp:RadioButton ID="m_rdb_kh_dau_nam" runat="server" Text="KH đầu năm" GroupName="loai" Checked="true" />
                                <asp:RadioButton ID="m_rdb_bo_sung" runat="server" Text="Bổ sung" GroupName="loai" />
                                <asp:RadioButton ID="m_rdb_dieu_chinh" runat="server" Text="Điều chỉnh" GroupName="loai" />
                            </div>
                            <div id="group_standard">
                                <div class="lbl">Số QĐ (*)</div>
                                <div class="ctr">
                                    <asp:TextBox ID="m_txt_so_qd" runat="server" CssClass="cssTextBox" Width="150px"></asp:TextBox>
                                </div>
                                <div class="lbl">Ngày tháng (*)</div>
                                <div class="ctr">
                                    <asp:TextBox ID="m_txt_ngay_thang" runat="server" CssClass="cssTextBox" Width="150px" placeholder="dd/MM/yyyy"></asp:TextBox>
                                </div>
                                <div class="lbl">Nội dung (*)</div>
                                <div class="ctr">
                                    <asp:TextBox ID="m_txt_noi_dung" runat="server" CssClass="cssTextBox" TextMode="MultiLine" Rows="3" Width="100%" placeholder="Vd: 371/QĐ-BGTVT"></asp:TextBox>
                                </div>
                            </div>
                            <div id="group_advanced" style="display: none">
                                <div class="lbl">Số QĐ (*)</div>
                                <div class="ctr" style="height: 22px;">
                                    <asp:DropDownList ID="m_ddl_so_qd" runat="server" Width="176px" OnSelectedIndexChanged="m_ddl_so_qd_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                            </div>
                            <div style="text-align: center; margin-top: 10px;">
                                <input type="button" id="m_cmd_chon_quyet_dinh_co_san" value="Chọn quyết định có sẵn" />
                                <input type="button" id="m_cmd_them_quyet_dinh_khac" value="Thêm quyết định khác" style="display: none;" />
                                <asp:Button ID="m_cmd_them_moi_quyet_dinh" Text="Thêm mới quyết định" runat="server" OnClick="m_cmd_them_moi_quyet_dinh_Click" />
                                <asp:Button ID="m_cmd_cho_them_qd" Text="Thêm mới quyết định khác" runat="server" OnClick="m_cmd_cho_them_qd_Click" Visible="false"/>
                            </div>
                        </fieldset>
                        <fieldset>
                            <legend>Chi tiết quyết định</legend>
                            <div class="lbl">Chi theo (*)</div>
                            <div class="ctr">
                                <asp:RadioButton ID="chiTheoQuocLoDuAn" runat="server" Text="Theo Quốc lộ/dự án" GroupName="chitheo" Checked="true" /><br />
                                <asp:RadioButton ID="chiTheoLoaiKhoanMuc" runat="server" Text="Theo Loại khoản mục" GroupName="chitheo" />
                            </div>
                            <div id="group_qlda" style="">
                                <div class="lbl">Loại nhiệm vụ (*)</div>
                                <div class="ctr">
                                    <asp:DropDownList ID="m_ddl_loai_nhiem_vu" runat="server" Width="176px" OnSelectedIndexChanged="m_ddl_loai_nhiem_vu_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Công trình/Quốc lộ (*)</div>
                                <div style="height: 20px; width:190px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_cong_trinh_quoc_lo" runat="server" Width="176px" AutoPostBack="True" OnSelectedIndexChanged="m_ddl_cong_trinh_quoc_lo_SelectedIndexChanged"></asp:DropDownList>
                                    <asp:TextBox id="m_txt_cong_trinh" runat="server" Visible="false"></asp:TextBox>
                                </div>
                                <div style="height:20px; float:left;margin-top: 3px;">
                                    <asp:Button ID="m_cmd_them_cong_trinh_block" runat="server" Text="Thêm công trình" Width="110px" OnClick="m_cmd_them_cong_trinh_block_Click"/>
                                    <asp:Button ID="m_cmd_them_cong_trinh" runat="server" Text="Chọn công trình" Width="110px" Visible="false" OnClick="m_cmd_them_cong_trinh_Click"/>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Tên dự án (*)</div>
                                <div style="height: 20px; width:190px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_du_an" runat="server" Width="176px"></asp:DropDownList>
                                    <asp:TextBox ID="m_txt_ten_du_an" runat="server" CssClass="cssTextBox" Width="150px" Visible="false"></asp:TextBox>
                                </div>
                                <div style="height:20px; float:left;margin-top: 3px;">
                                    <asp:Button ID="m_cmd_them_du_an_block" runat="server" Text="Thêm dự án" Width="110px" OnClick="m_cmd_them_du_an_block_Click"/>
                                    <asp:Button ID="m_cmd_them_du_an" runat="server" Text="Chọn dự án" Width="110px" Visible="false" OnClick="m_cmd_them_du_an_Click"/>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">(*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:RadioButton ID="m_rad_thuong_xuyen" runat="server" Text="Thường xuyên" GroupName="txktx" Checked="true" />
                                    <asp:RadioButton ID="m_rad_khong_thuong_xuyen" runat="server" Text="Không thường xuyên" GroupName="txktx" />
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Số km</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:TextBox ID="m_txt_so_km" runat="server" CssClass="cssTextBox align_right" Width="150px" Text="0"></asp:TextBox>
                                </div>
                            </div>
                            <div id="group_lkm" style="display: none;">
                                <div class="lbl">Loại nhiệm vụ (*)</div>
                                <div class="ctr">
                                    <asp:DropDownList ID="m_ddl_loai_nhiem_vu_lkm" runat="server" Width="176px"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Chương (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_chuong" runat="server" Width="176px"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Loai (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_loai" runat="server" Width="176px" OnSelectedIndexChanged="m_ddl_loai_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Khoản (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_khoan" runat="server" Width="176px"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Mục (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_muc" runat="server" Width="176px" OnSelectedIndexChanged="m_ddl_muc_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Tiểu mục (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:DropDownList ID="m_ddl_tieu_muc" runat="server" Width="176px"></asp:DropDownList>
                                </div>
                            </div>
                            <div>
                                <div style="clear: both; height: 20px;" class="lbl">Kinh phí năm trước chuyển sang</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:TextBox ID="m_txt_kinh_phi_nam_truoc_chuyen_sang" runat="server" CssClass="cssTextBox align_right" Width="150px" value="0"></asp:TextBox>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Kinh phí Quỹ bảo trì (*)</div>
                                <div style="height: 20px;" class="ctr">
                                    <asp:TextBox ID="m_txt_kinh_phi_quy_bao_tri" runat="server" CssClass="cssTextBox align_right" Width="150px" value="0"></asp:TextBox>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Tổng</div>
                                <div style="height: 20px;position: relative;" class="ctr">
                                    <label style="text-align: right;position: absolute;right: 75px;" id="m_lbl_tong_chi_ktx">0</label>
                                </div>
                                <div style="clear: both; height: 20px;" class="lbl">Ghi chú</div>
                                <div style="height: 70px;" class="ctr">
                                    <asp:TextBox ID="m_txt_ghi_chu" TextMode="MultiLine" runat="server" Rows="4" CssClass="cssTextBox" Width="100%"></asp:TextBox>
                                </div>
                            </div>
                            <div style="text-align: center; clear: both;">
                                <asp:Button ID="m_cmd_ghi_chi_tiet_qd" Text="Ghi dữ liệu" runat="server" OnClick="m_cmd_ghi_chi_tiet_qd_Click" />
                            </div>
                            <div style="text-align: center; clear: both;">
                                <asp:Label ID="m_lbl_mess_grid" runat="server"></asp:Label>
                            </div>
                        </fieldset>
                    </div>
                    <div style="width: 765px; height: 650px; float: left; margin-left: 5px;">
                        Quyết định số:
                        <asp:Label ID="m_lbl_grid_so_quyet_dinh" runat="server" Font-Bold="true"></asp:Label>
                        ngày
                        <asp:Label ID="m_lbl_grid_ngay" runat="server" Font-Bold="true"></asp:Label>
                        về việc
                        <asp:Label ID="m_lbl_grid_ve_viec" runat="server" Font-Bold="true"></asp:Label>
                        <br />
                        Tổng kinh phí: <asp:Label ID="m_lbl_grid_tong_tien" runat="server" Font-Bold="false" CssClass="cssManField"></asp:Label>đ
                <asp:GridView ID="m_grv" runat="server" AllowPaging="false" AutoGenerateColumns="False"
                    CssClass="cssGrid" Width="100%" CellPadding="0" ForeColor="#333333"
                    AllowSorting="True" PageSize="30" ShowHeader="true"
                    DataKeyNames="ID"
                    EmptyDataText="Không có dữ liệu phù hợp"
                    OnPageIndexChanging="m_grv_PageIndexChanging"
                    OnRowDataBound="m_grv_RowDataBound">

                    <Columns>
                        <asp:TemplateField HeaderText="Xóa" HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbl_delete" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                                    CommandName="Xoa" ToolTip="Xóa" OnClientClick="return confirm ('Bạn có thực sự muốn xóa bản ghi này?')">
                     <img alt="Xóa" src="../Images/Button/deletered.png" />
													
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Sửa" HeaderStyle-Width="2%">
                            <ItemTemplate>
                                <asp:LinkButton ID="m_lbl_update" runat="server" CausesValidation="false" CommandArgument='<%#Eval("ID")%>'
                                    CommandName="Sua" ToolTip="Sửa">
                     <img alt="Xóa" src="../Images/Button/edit.png" />
													
                                </asp:LinkButton>
                            </ItemTemplate>
                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                        </asp:TemplateField>
                        <asp:BoundField DataField="NOI_DUNG" HeaderText="Nhiệm vụ chi" />


                        <asp:TemplateField HeaderText="Kinh phí năm trước chuyển sang" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="m_lbl_so_tien_nam_truoc_chuyen_sang_grid" runat="server"
                                    Text='<%#format_so_tien(Eval(GRID_GIAO_KH.NTCT).ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kinh phí Ngân sách" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="m_lbl_so_tien_ngan_sach_grid" runat="server"
                                    Text='<%#format_so_tien(Eval(GRID_GIAO_KH.NS).ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Kinh phí Quỹ bảo trì" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="m_lbl_so_tien_quy_bao_tri_grid" runat="server"
                                    Text='<%#format_so_tien(Eval(GRID_GIAO_KH.QUY).ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Tổng" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="100px">
                            <ItemTemplate>
                                <asp:Label ID="m_lbl_tong_so_tien" runat="server"
                                    Text='<%#format_so_tien(Eval(GRID_GIAO_KH.TONG).ToString()) %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>
                    </div>
                </div>
            </div>
            <asp:HiddenField ID="m_hdf_id_quyet_dinh" runat="server" />
            <asp:HiddenField ID="m_hdf_id_giao_kh" runat="server" />
            <asp:HiddenField ID="m_hdf_bool_them_cong_trinh" runat="server" value="N" />
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
