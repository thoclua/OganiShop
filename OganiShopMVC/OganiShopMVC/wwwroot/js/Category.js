var CategoryProduct = {
    Init: function () {
        CategoryProduct.LoadDataToDataTable();
        CategoryProduct.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi-cate').off('click').on('click', function () {
            CategoryProduct.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat-cate').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            CategoryProduct.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-cate').off('click').on('click', function () {


            var categoryname = $('#title').val();

            var id = $(this).attr('sp-id');

            var productcategory = {

                CategoryName: categoryname,

                Id: id
            }
            // alert(product);
            CategoryProduct.Saveee(productcategory);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update-cate').modal('hide');
        })
        $('.dele-te-cate').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            CategoryProduct.Deleteee(_id);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/Category/DataTableAjaxRespone",
                "type": "POST"
            },
            "columns": [
                { "data": "id", "name": "id" },
                { "data": "categoryName", "name": "categoryName" },
                {
                    "data": "id", "render": function (data) {
                        return `
                                                <div class="btn-group" role="group" aria-label="Basic example">
                                                                 
                                                                  <a href="javascript:void(0)" sp-id=${data} class="btn btn-warning cap-nhat-cate">Cập nhật</a>
                                                                  <a href="javascript:void(0)" sp-id=${data} class="btn btn-danger dele-te-cate">Xóa</a>
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
                CategoryProduct.RegisterEvent();

            },
            "drawCallback": function (settings) {
                CategoryProduct.RegisterEvent();

            }
        });
        CategoryProduct.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/Category/CreateOrUpDateCategory?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update-cate').modal('show');
            CategoryProduct.RegisterEvent();
        })
    },
    Saveee: function (productcategory) {
        $.post('/Category/Save', productcategory, function (response) {
            $('#create-or-update-cate').modal('hide');
            alert(response.message);
            CategoryProduct.ReloadDataTable();
            CategoryProduct.RegisterEvent();
        })
    },
    Deleteee: function (id) {
        $.get('/Category/Delete?id=' + id, function (response) {
            alert(response.message);
            CategoryProduct.ReloadDataTable();
            CategoryProduct.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        CategoryProduct.RegisterEvent();
    },

}
CategoryProduct.Init();