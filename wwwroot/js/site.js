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
        hash = window.location.hash;

        if (hash.length < 2 || hash[0] !== "#") {
            hash = $("ul.nav-pills li a").first().attr("href");
        }
    }
    if (hash.length > 1 && hash[0] === "#") {
        $("ul.nav-pills li a").removeClass("active");
        $.get(hash.substring(1), function (data) {
            console.log(data);
            ui.controller.page = null;
            $("#page-container").html(data);
            ui.controller.pageInit();
            ui.controller.pageInitAfter(hash);

            var linkItem = $("ul.nav-pills li a[href='" + hash + "']");
            linkItem.parent().addClass("active");
            if (linkItem.hasClass("menu-link-sub")) {
                var linkContainer = linkIt
                linkContainer.parent().addClass("open"); em.parent().par
                if ($("body").hasClass("mobile-view-activated"))
                    $("body").removeClass("mobile-nav-on").addClass("blur"); ent();
                linkContainer.show();
            }
        });
    }
};
ui.controller.pageInit = function () {
};
ui.controller.pageInitAfter = function (hash) {
};
ui.controller.custom.pageInitAfter = function (hash) {
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