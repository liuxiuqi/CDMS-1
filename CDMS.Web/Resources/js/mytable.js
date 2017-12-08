
layui.define(['jquery', 'table'], function (exports) {
    var $ = layui.jquery, table = layui.table;

    function myTable(o) {
        var tableId = 'myTable';
        var defaults = {
            id: tableId,
            elem: '#' + tableId,
            url: '',
            method: 'post',
            tr_click_checkable: true,
            page: true,
            limit: 10,
            limits: [10, 20, 30]
        };
        this.option = $.extend({}, defaults, o || {});
    }

    myTable.prototype.set = function (o) {

    }

    myTable.prototype.render = function () {

    }

    exports('mytable');
});