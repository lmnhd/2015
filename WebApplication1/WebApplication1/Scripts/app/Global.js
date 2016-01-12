$(document).ready(function () {

    var tag = document.createElement('script');

    tag.src = "https://www.youtube.com/iframe_api";
    var firstScriptTag = document.getElementsByTagName('script')[0];
    firstScriptTag.parentNode.insertBefore(tag, firstScriptTag);

    $(document).foundation();
    //var scene = document.getElementById('scene');
    //var parallax = new Parallax(scene);
    //var s = skrollr.init();

    //$(function () {
    //    $('#main-content').vegas({
    //        slides: [
    //            { src: '/Images/10256562_684664624903577_5448769002805416086_n.jpg' },
    //            { src: '/Images/10444008_742269199143119_2190446012713046297_n.jpg' },
    //            { src: '/Images/1622860_646259208744119_1795766345_n.jpg' },
    //            { src: '/Images/1969209_754370034599702_6887770789921767149_n.jpg' },
    //            { src: '/Images/RicoBanner.jpg' },
    //            { src: '/Images/onstage_1.jpg'}
    //        ],
    //        overlay: "/Scripts/vegas/overlays/09.png",
    //        transition: 'random'
    //    });


    //});

    $(window).scroll(function () {


        var top = $(window).scrollTop();
        var bar = $('#top-bar');
        //if (top > 500) {
           
        //    bar.css("height","40px");
        //} else {
        //    bar.css("height", "100px");
        //}
    });

    $('.music-tile-container').hide();
    //$('.video-tile-container').hide();
    //$('.news-tile-container').hide();
    //$('#content-area').hide();
    //$('#sidebar-events').hide().removeClass('hide-for-small');
    //$('#skrollr-body').hide();

    //$('#image-overlay').toggle('slide');
    $('#skrollr-body').fadeIn(3000, function () {
       // $('.red-overlay').fadeIn(1000,function() {
            //$('#image-overlay').toggle('slide');
       // });
    });


    window.dusttpl.registerAll();

    $('#sidebar-events').css('height', $('#content-area').height());


// var buildingTemplate = dust.compile($("#building-list-item-template").html(), "tpl");

    // load the compiled template into the dust template cache
    //dust.loadSource(buildingTemplate);

    //$('#main-content').css('height', 'auto');
})