function replaceAll(find, replace, str) {
    return str.replace(new RegExp(find, 'g'), replace);
}

function getData(template, id_table, str_file_name, m) {
    jQuery.get('../Template/' + template + '.txt', function (data) {
        data = data.replace("<replace-table>", $('#' + id_table).html());
        //data = replaceAll('<th', '<th style="color:white; background-color:blue;" ', data);
        m.forEach(function (item, key, mapObj) {
            data = data.replace(key.toString(), item.toString());
        });
        LoadButton(str_file_name, data);
    });
}

function LoadButton(str_file_name, content) {
    Downloadify.create('downloadify', {
        filename: function () {
            return str_file_name + ".xls";//document.getElementById('filename').value;
        },
        data: function () {
            return content;//document.getElementById('txt_area').value;
        },
        onComplete: function () { alert('Báo cáo đã được lưu trên máy tính của bạn!'); },
        onCancel: function () { alert('Bạn vừa hủy thao tác lưu lại báo cáo'); },
        onError: function () { alert('Nội dung trong báo cáo không được bỏ trống!'); },
        swf: '../Downloadify/media/downloadify.swf',
        downloadImage: '../Downloadify/images/download.png',
        width: 100,
        height: 30,
        transparent: true,
        append: false
    });
}