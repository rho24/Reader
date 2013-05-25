$(function() {
    // Fluid layout doesn't seem to support 100% height; manually set it
    $(window).resize(function () {
        var viewportHeight = $(window).height() - $(".top-navbar").height() - 100;
        
        $('.viewport').height(viewportHeight);
    });
    $(window).resize();

});