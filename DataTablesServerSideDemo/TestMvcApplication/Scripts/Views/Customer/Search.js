var Customer = {
    Search: {},
    DefaultPageLength: 25
};
$(document).ready(function () {
    $('.dataTable').dataTable(Customer.Search.DataTableParameters);
});
Customer.Search.DataTableParameters = {
    // ToDo: finish and clean this up.
    "bServerSide": true,
    "sAjaxSource": $('#SearchResults').attr('data-AjaxSource'),
    "bProcessing": true,
    "fnServerData": function (sSource, aoData, fnCallback, oSettings) {
        oSettings.jqXHR = $.ajax({
            "dataType": 'json',
            "type": "GET",
            "url": sSource,
            "data": aoData,
            "success": fnCallback,
            "error": Customer.Search.AjaxError
        });
    },
    "iDisplayLength": Customer.DefaultPageLength,
    "bAutoWidth": false,
    "aLengthMenu": [[Customer.DefaultPageLength, 50, 100], [Customer.DefaultPageLength, 50, 100]]
};
Customer.Search.AjaxError = function (jqXHR, textStatus, errorThrown) {
    console.log(jqXHR.responseText);
}