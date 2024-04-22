var Slide = {
    Init: function () {
        Slide.LoadDataToDataTable();
        Slide.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi').off('click').on('click', function () {
            Slide.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            Slide.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-san-pham').off('click').on('click', function () {

            var silde_Code = $('#inputName').val();
            var slide_Value = $('#image').val();
            var id = $(this).attr('sp-id');

            var slide = {
                Silde_Code: silde_Code,
                Slide_Value: slide_Value,
                Id: id
            }
            // alert(product);
            //debugger
            Slide.Savee(slide);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update').modal('hide');
        })
        $('.dele-te').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            Slide.Deletee(_id);
        })
        $('.btn-upload-single-image').off('change').on('change', function () {
            var formData = new FormData();
            var file = $(this).get(0).files[0];
            formData.append(file.name, file);
            Slide.UploadSingleImage(formData);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/Slide/DataTableAjaxRespone",
                "type": "POST"
            },
            "columns": [
                { "data": "id", "name": "id" },
                { "data": "silde_Code", "name": "Silde_Code" },
                {
                    "data": "slide_Value", "name": "Slide_Value", "render": function (data) {
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
                Slide.RegisterEvent();

            },
            "drawCallback": function (settings) {
                Slide.RegisterEvent();

            }
        });
        Slide.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/Slide/CreateOrUpdate?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update').modal('show');
            Slide.RegisterEvent();
        })
    },
    Savee: function (slide) {
        $.post('/Slide/Save', slide, function (response) {
            $('#create-or-update').modal('hide');
            alert(response.message);
            Slide.ReloadDataTable();
            Slide.RegisterEvent();
        })
    },
    Deletee: function (id) {
        $.get('/Slide/Delete?id=' + id, function (response) {
            alert(response.message);
            Slide.ReloadDataTable();
            Slide.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        Slide.RegisterEvent();
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
                Slide.RegisterEvent();
            }
        })
    }

}
Slide.Init();