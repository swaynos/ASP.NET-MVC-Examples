var Index = {};
$(document).ready(function () {
    Index.EnableButton(Index.ButtonCallback);
});
Index.EnableButton = function (buttonCallback) {
    $('.getJson').click(buttonCallback);
};
Index.ButtonCallback = function (event) {
    $this = $(this);
    url = $this.attr('data-url');
    $.ajax({
        url: url,
        dataType: 'json',
        success: function (data) {
            // You can do whatever you want with your data here.
            var html = 'Data =<br />';
            html += 'Count: ' + data.Count + '<br />';
            html += '"' + data.Bar + data.Foo + '"';
            Index.OutputData(html);
        },
        error: function (jqXHR, textStatus, errorThrown) {
            // jqXHR.responseText is the stringified Json object
            var exception = JSON.parse(jqXHR.responseText); // parse the Json string into an object
            
            // Do whatever you want with your exception here.
            var html = 'Exception =<br/>'
            html += 'Message: ' + exception.message + '<br />';
            html += 'Stack Trace: ' + exception.stackTrace;
            Index.OutputData(html);
        }
    });
};
Index.OutputData = function (html) {
    $('#data').html(html);
};