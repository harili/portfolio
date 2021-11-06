$(document).ready(function () {
    ui.controller.pageLoad();
    $(window).on('hashchange', function (e) {
        ui.controller.pageLoad(window.location.hash);
    });
});

var ui = {
    controller: {
        page: {}
    }
};

ui.controller.pageLoad = function (hash = null) {
    if (hash === null) {
        console.log("y'a r", hash);
        hash = window.location.hash;
        if (hash.length < 2 || hash[0] !== "#") {
            hash = $("ul.nav-pills li a").first().attr("href");
        }
    }
    if (hash.length > 2 && hash[0] === "#") {
        console.log("ici", hash);
        $("ul.nav-pills li a").removeClass("active");
        $.get(hash.substring(1), function (data) {

            ui.controller.page = null;
            $("#page-container").html(data);

            var linkItem = $("ul.nav-pills li a[href='" + hash + "']");
            linkItem.addClass("active");
        });
    }
};
ui.controller.pageInit = function () {
};
ui.controller.pageInitAfter = function (hash) {
};

ui.controller.pageDestroy = function () {
    ui.controller.pageDestroyContent();
    ui.controller.page = null;
};

ui.controller.isValidHash = function (hash) {
    return RegExp(/^#(\/[a-z0-9%-°.]+)+$/).test(hash);
};

ui.controller.urlRewrite = function (url) {
    return url.normalize("NFD").replace(/[\u0300-\u036f]/g, "").toLowerCase().replace(/ /g, '-').replace(/'/g, '').replace(/&/g, 'et');
};