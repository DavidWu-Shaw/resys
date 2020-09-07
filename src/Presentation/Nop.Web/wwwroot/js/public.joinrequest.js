
var JoinRequest = {
    loadWaiting: false,

    init: function (options) {
    },

    sendRequest: function (url, vendorId) {
        var params = {
            vendorId: vendorId
        }

        $.ajax({
            url: url,
            type: "post",
            data: params,
            cache: false
        })
        .done(function (response) {

        })
        .fail(function (xhr, ajaxOptions, thrownError) {
            // Error
            DisplayError(xhr, thrownError);
        });

    },
}