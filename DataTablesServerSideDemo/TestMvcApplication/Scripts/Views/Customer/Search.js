var Customer = {
    Search: {
        DefaultPageLength: 25
    }
};
$(document).ready(function () {
    $.extend($.fn.dataTableExt.oStdClasses, Customer.Search.DataTableExtensions);
    $.extend($.fn.dataTableExt.oJUIClasses, Customer.Search.DataTableExtensions);
    $('.dataTable').dataTable(Customer.Search.GetDataTableParameters());
});
Customer.Search.GetDataTableParameters = function () {
    return {
        // parameters that are useful before data is sent
        "bServerSide": true,
        "sAjaxSource": $('#SearchResults').data('AjaxSource'),
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
        "fnServerParams": function (aoData) {
            aoData.push({
                "name" : "LastModifiedDateStart",
                "value" : $('#Model_LastModifiedDateStart').val()
            });
            aoData.push({
                "name": "LastModifiedDateEnd",
                "value": $('#Model_LastModifiedDateEnd').val()
            });
            aoData.push({
                "name": "CompanyName",
                "value": $('#Model_CompanyName').val()
            });
        },
        // parameters that are useful once data is returned
        "bAutoWidth": false,
        "bJQueryUI": true,
        "aLengthMenu": [[Customer.Search.DefaultPageLength, 50, 100], [Customer.Search.DefaultPageLength, 50, 100]],
        "iDisplayLength": Customer.Search.DefaultPageLength,
        "fnRowCallback": Customer.Search.DataTableRowCallback,
        "sPaginationType": "full_numbers",
        "oLanguage": {
            "oPaginate": {
                "sNext": ">",
                "sPrevious": "<"
            }
        }
    }
};
Customer.Search.DataTableRowCallback = function (nRow, aData, iDisplayIndex, iDisplayIndexFull) {
    var tds = $(nRow).find('td');

    // custom html for the email
    $(tds[6]).html('<a href="mailto:' + aData[6] + '"><span class="glyphicon-envelope" ></span></a>').addClass("center");;

    // Filter down to the specific columns
    tds.splice(2, 1); // remove 3rd element
    tds.splice(4, 2); // now remove the 5th, and 6th elements (originally 6th, and 7th)

    // append the responsive css
    tds.addClass("hidden-xs");

    return nRow;
    // note: code should be changed to leverage associative arrays to make code legible
};
Customer.Search.DataTableExtensions = {
    "sFilter": "pull-right ",
    "sLength": "pull-left ",
    "sInfo": "pull-left ",
    "sPaging": "pull-right "
};

Customer.Search.AjaxError = function (jqXHR, textStatus, errorThrown) {
    console.log(jqXHR.responseText);
};