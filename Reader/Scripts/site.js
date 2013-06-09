$(function() {
    // Fluid layout doesn't seem to support 100% height; manually set it
    $(window).resize(function () {
        var viewportHeight = $(window).height() - $(".top-navbar").height() - 100;
        
        $('.viewport').height(viewportHeight);
    });
    $(window).resize();

    // Proxy created on the fly          
    var notifier = $.connection.notificationHub;

    // Declare a function on the chat hub so the server can invoke it          
    notifier.client.Message = function (message) {
        $('<div class="alert alert-info"><button type="button" class="close" data-dismiss="alert">&times;</button>' + message + '</div>').prependTo($('#page-body'));
    };

    // Start the connection
    $.connection.hub.start();
});