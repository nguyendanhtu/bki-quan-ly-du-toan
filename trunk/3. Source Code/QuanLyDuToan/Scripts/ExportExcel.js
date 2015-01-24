function getData(template, id_table, str_file_name) {
    jQuery.get('../Template/' + template + '.txt', function (data) {
        var v_content = data.replace('<replace-table>', $('#' + id_table).html());
        LoadButton(str_file_name, v_content);
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
        onComplete: function () { alert('Your File Has Been Saved!'); },
        onCancel: function () { alert('You have cancelled the saving of this file.'); },
        onError: function () { alert('You must put something in the File Contents or there will be nothing to save!'); },
        swf: '../Downloadify/media/downloadify.swf',
        downloadImage: '../Downloadify/images/download.png',
        width: 100,
        height: 30,
        transparent: true,
        append: false
    });
}