var New = {
    Init: function () {
        New.LoadDataToDataTable();
        New.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi').off('click').on('click', function () {
            New.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            New.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-san-pham').off('click').on('click', function () {

            var title = $('#inputName').val();
            var description = $('#description').val(); 
            var categoryNewId = $('#CategoryNewId').val();
            var image = $('#image').val();
            var id = $(this).attr('sp-id');

            var news = {
                Title: title,
                Description: description,
                CategoryNewId: parseInt(categoryNewId),
                Image: image,
                Id: id
            }
            // alert(product);
            //debugger
            New.Savee(news);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update').modal('hide');
        })
        $('.dele-te').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            New.Deletee(_id);
        })
        $('.btn-upload-single-image').off('change').on('change', function () {
            var formData = new FormData();
            var file = $(this).get(0).files[0];
            formData.append(file.name, file);
            New.UploadSingleImage(formData);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/New/DataTableAjaxRespone",
                "type": "POST"
            },
            "columns": [
                { "data": "id", "name": "id" },
                { "data": "title", "name": "Title" },
                { "data": "description", "name": "Description" },
                { "data": "categoryNew.categoryName", "name": "CategoryNewId" },
                {
                    "data": "image", "name": "Image", "render": function (data) {
                        return `<img src="${data}" class="img-full-width">`;
                    }
                },
                {
                    "data": "id", "render": function (data) {
                        return `
                                                <div class="btn-group" role="group" aria-label="Basic example">
                                                                 
                                                                  <a href="javascript:void(0)" sp-id=${data} class="btn btn-warning cap-nhat">Cập nhật</a>
                                                                  <a href="javascript:void(0)" sp-id=${data} class="btn btn-danger dele-te">Xóa</a>
                                                </div>

                                    `
                    }
                }

            ],
            "searching": true,
            'searchDelay': 500,
            'search': {
                'regex': false
            },
            "paging": true,
            "initComplete": function () {
                New.RegisterEvent();

            },
            "drawCallback": function (settings) {
                New.RegisterEvent();

            }
        });
        New.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/New/CreateOrUpdate?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update').modal('show');
            New.RegisterEvent();
        })
    },
    Savee: function (news) {
        $.post('/New/Save', news, function (response) {
            $('#create-or-update').modal('hide');
            alert(response.message);
            New.ReloadDataTable();
            New.RegisterEvent();
        })
    },
    Deletee: function (id) {
        $.get('/New/Delete?id=' + id, function (response) {
            alert(response.message);
            New.ReloadDataTable();
            New.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        New.RegisterEvent();
    },
    UploadSingleImage: function (formData) {
        $.ajax({
            url: "/UploadFiles/UploadSingleFile",
            type: "POST",
            data: formData,
            contentType: false,
            processData: false,
            success: function (response) {
                var urlFile = "/uploads/" + response;
                alert(urlFile);
                $('#image').val(urlFile);
                $('#show-upload-single-image').attr('src', urlFile);
                New.RegisterEvent();
            }
        })
    }

}
New.Init();