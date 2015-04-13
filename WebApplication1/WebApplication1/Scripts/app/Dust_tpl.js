window.dusttpl = (function() {
    var dusttpl = {};

    dusttpl.register = function register(template_id, name) {

        var template = dust.compile($("#" + template_id).html(), name);

        // load the compiled template into the dust template cache
        dust.loadSource(template);
    }

    dusttpl.registerAll = function registerAll() {

        var tags = $('script[type="text/x-template"');
        $(tags).each(function(index, value) {
            var name = $(value).attr('id');
            var template = dust.compile($(value).html(), name);
            dust.loadSource(template);
        });
    }
    return dusttpl;
})();