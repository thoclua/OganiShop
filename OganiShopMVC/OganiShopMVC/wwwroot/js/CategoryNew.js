var CategoryNew = {
    Init: function () {
        CategoryNew.LoadDataToDataTable();
        CategoryNew.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi-cate').off('click').on('click', function () {
            CategoryNew.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat-cate').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            CategoryNew.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-cate').off('click').on('click', function () {


            var categoryname = $('#title').val();

            var id = $(this).attr('sp-id');

            var newcategory = {

                CategoryName: categoryname,

                Id: id
            }
            // alert(product);
            CategoryNew.Saveee(newcategory);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update-cate').modal('hide');
        })
        $('.dele-te-cate').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            CategoryNew.Deleteee(_id);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/CategoryNew/DataTableAjaxRespone",
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
                CategoryNew.RegisterEvent();

            },
            "drawCallback": function (settings) {
                CategoryNew.RegisterEvent();

            }
        });
        CategoryNew.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/CategoryNew/CreateOrUpDateCategory?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update-cate').modal('show');
            CategoryNew.RegisterEvent();
        })
    },
    Saveee: function (newcategory) {
        $.post('/CategoryNew/Save', newcategory, function (response) {
            $('#create-or-update-cate').modal('hide');
            alert(response.message);
            CategoryNew.ReloadDataTable();
            CategoryNew.RegisterEvent();
        })
    },
    Deleteee: function (id) {
        $.get('/CategoryNew/Delete?id=' + id, function (response) {
            alert(response.message);
            CategoryNew.ReloadDataTable();
            CategoryNew.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        CategoryNew.RegisterEvent();
    },

}
CategoryNew.Init();