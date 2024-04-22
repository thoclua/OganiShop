var CateProduct = {
    Init: function () {
        CateProduct.LoadDataToDataTable();
        CateProduct.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi').off('click').on('click', function () {
            CateProduct.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            CateProduct.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-san-pham').off('click').on('click', function () {

            var name = $('#inputName').val();
            var description = $('#description').val();
            var price = $('#price').val();
            var categoryId = $('#CategoryId').val();
            var quantity = $('#quantity').val();
            var image = $('#image').val();
            var id = $(this).attr('sp-id');

            var product = {
                Name: name,
                Description: description,
                Price: price,
                CategoryId: parseInt(categoryId),
                Quantity: quantity,
                Image: image,
                Id: id 
            }
            // alert(product);
             //debugger
            CateProduct.Savee(product);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update').modal('hide');
        })
        $('.dele-te').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            CateProduct.Deletee(_id);
        })
        $('.btn-upload-single-image').off('change').on('change', function () {
            var formData = new FormData();
            var file = $(this).get(0).files[0];
            formData.append(file.name, file);
            CateProduct.UploadSingleImage(formData);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/Product/DataTableAjaxRespone",
                "type": "POST"
            },
            "columns": [
                { "data": "id", "name": "id" },
                { "data": "name", "name": "Name" },
                { "data": "description", "name": "Description" },
                { "data": "price", "name": "Price" },
                { "data": "category.categoryName", "name": "CategoryId" },
                { "data": "quantity", "name": "Quantity" },
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
                CateProduct.RegisterEvent();

            },
            "drawCallback": function (settings) {
                CateProduct.RegisterEvent();

            }
        });
        CateProduct.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/Product/CreateOrUpdate?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update').modal('show');
            CateProduct.RegisterEvent();
        })
    },
    Savee: function (product) {
        $.post('/Product/Save', product, function (response) {
            $('#create-or-update').modal('hide');
            alert(response.message);
            CateProduct.ReloadDataTable();
            CateProduct.RegisterEvent();
        })
    },
    Deletee: function (id) {
        $.get('/Product/Delete?id=' + id, function (response) {
            alert(response.message);
            CateProduct.ReloadDataTable();
            CateProduct.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        CateProduct.RegisterEvent();
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
                CateProduct.RegisterEvent();
            }
        })
    }

}
CateProduct.Init();