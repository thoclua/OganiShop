var Config = {
    Init: function () {
        Config.LoadDataToDataTable();
        Config.RegisterEvent();
    },
    RegisterEvent: function () {
        $('#btn-tao-moi-cate').off('click').on('click', function () {
            Config.CreateOrUpdatePartialView(0);
        })
        $('.cap-nhat-cate').off('click').on('click', function () {
            var sp_id = $(this).attr('sp-id');
            Config.CreateOrUpdatePartialView(sp_id);
        })
        $('#btn-save-cate').off('click').on('click', function () {


            var config_code = $('#config_code').val();
            var config_value = $('#config_value').val();

            var id = $(this).attr('sp-id');

            var config = {
                Config_Code: config_code,
                Config_Value: config_value,
                Id: id
            }
            // alert(product);
            Config.Saveee(config);
        })
        $('.button-close').off('click').on('click', function () {
            $('#create-or-update-cate').modal('hide');
        })
        $('.dele-te-cate').off('click').on('click', function () {
            var _id = $(this).attr('sp-id');
            Config.Deleteee(_id);
        })
    },



    LoadDataToDataTable: function () {
        $('#datatable').DataTable({
            "serverSide": true,
            "ajax": {
                "url": "/Config/DataTableAjaxRespone",
                "type": "POST"
            },
            "columns": [
                { "data": "id", "name": "id" },
                { "data": "config_Code", "name": "Config_Code" },
                { "data": "config_Value", "name": "Config_Value" },
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
                Config.RegisterEvent();

            },
            "drawCallback": function (settings) {
                Config.RegisterEvent();

            }
        });
        Config.RegisterEvent();
    },
    CreateOrUpdatePartialView: function (id) {
        //debugger
        var url = '/Config/CreateOrUpDateConfig?Id=' + id;
        console.log(url);
        $.get(url, function (response) {
            // debugger
            $('#container-create-or-update').html('').html(response);
            $('#create-or-update-cate').modal('show');
            Config.RegisterEvent();
        })
    },
    Saveee: function (config) {
        $.post('/Config/Save', config, function (response) {
            $('#create-or-update-cate').modal('hide');
            alert(response.message);
            Config.ReloadDataTable();
            Config.RegisterEvent();
        })
    },
    Deleteee: function (id) {
        $.get('/Config/Delete?id=' + id, function (response) {
            alert(response.message);
            Config.ReloadDataTable();
            Config.RegisterEvent();
        })
    },
    ReloadDataTable: function () {
        var table = $('#datatable').DataTable();
        table.ajax.reload(null, false);
        Config.RegisterEvent();
    },

}
Config.Init();