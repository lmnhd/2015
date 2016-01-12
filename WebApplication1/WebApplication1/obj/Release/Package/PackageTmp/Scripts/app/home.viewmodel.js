function HomeViewModel(app, dataModel) {
    var self = this;
    var obj = $.parseJSON($('#dataobj').text());

    window.alldata = obj;
    for (var i = 0; i < window.alldata.videos.length; i++) {
        var vid = window.alldata.videos[i];
        vid.thumbnail = vid.ThumbnailsList[0];
    }
    self.resetView = function (maincontainer) {
        if (!maincontainer) {
            self.toggleTitleContent(true);
        }
        
        $('#mixtapes').hide();
        $('#page-container').hide();
        $('#content-area').show();
        $('#content-area-wrapper').show();
        $('#sidebar-events').show().addClass('hide-for-small');
        $('#recent-posts').show();
        $('#skrollr-body').show();
        $('#top-bar-container').show();
        $('#video-player-container').hide();
    }
    self.showPage = function(callback) {
        self.toggleTitleContent(false);
        $('#page-container').show();
        $('#content-area-wrapper').hide();
        $('#video-player-container').hide();
        $('#video-inner-container').empty().html('<div id="ytdiv"></div>');
        $('#sidebar-events').hide().removeClass('hide-for-small');
        $('#recent-posts').hide();
        $('#skrollr-body').show();
        $(window).scrollTo(0);
        if (callback) {
            callback();
        }
    }
         self.albums = ko.observableArray(window.alldata.albums);
        self.mixtapes = ko.observableArray(window.alldata.mixtapes);
        self.events = ko.observableArray(window.alldata.events);
        self.newses = ko.observableArray(window.alldata.newses);
        self.instagrams = ko.observableArray(window.alldata.instagrams);
        self.videos = ko.observableArray(window.alldata.videos);
        self.tracks = ko.observableArray(window.alldata.tracks);
        self.artistGlobal = ko.observable(window.alldata.globals);

        self.myHometown = ko.observable("");

    Sammy(function () {
        this.disable_push_state = true;
        this.get('#home', function () {
            //$('#body-wrap').show();
            self.resetView();
            $(window).scrollTo(0);


            // Make a call to the protected Web API by passing in a Bearer Authorization Header
            //$.ajax({
            //    method: 'get',
            //    url: app.dataModel.userInfoUrl,
            //    contentType: "application/json; charset=utf-8",
            //    headers: {
            //        'Authorization': 'Bearer ' + app.dataModel.getAccessToken()
            //    },
            //    success: function (data) {
            //        self.myHometown('Your Hometown is : ' + data.hometown);
            //    }
            //});
        });
        this.get('/', function () { this.app.runRoute('get', '#home'); });

        this.get('#view/:id', function() {
            var id = this.params['id'];

            $(window).scrollTo($('#' + id));
        });

        this.get('#/playvideo/:id', function() {

            try {
                $('#content-area').hide();
                $('#sidebar-events').hide().removeClass('hide-for-small');
                $('#skrollr-body').hide();
                window.YouTubePlayer.playVideo(this.params['id']);
                $('#video-player-container').show();
                $('#video-inner-container').fitVids();
                self.toggleTitleContent(false);
                $('#top-bar-container').hide();
                $('#photo-container').hide();
                $(window).scrollTo($('#video-player-container'));
            } catch (e) {
                this.app.runRoute('get', '#home');
            }
            
        });

        this.get('#/stopvideo', function() {
            self.resetView();
        });
        //this.get('#/menu', function() {
        //    return false;
        //});
        this.get('#/mixtape/:id', function () {
            self.toggleTitleContent(false);
            $('#mixtapes').show();
            var id = this.params['id'];
            $('#sidebar-events').hide().removeClass('hide-for-small');
            $('#content-area-wrapper').toggle('fold', function () {
                if (id != 0) {
                    $(window).scrollTo($('#' + id));
                } else {
                    $(window).scrollTo(0);
                }
                
            });

            
            
           

        });
        this.get('#/downloadmt/:id', function() {
            var id = this.params['id'];
            var mt = {};
            for (var i = 0; i < window.alldata.mixtapes.length; i++) {
                var temp = window.alldata.mixtapes[i];
                if (temp.Id == id) {
                    mt = temp;
                }
                dust.render('download-mixtape-tpl', mt, function (err, out) {
                    $('#inner-content').empty().html(
                   out
                   );
                    $('#page-header').text('Download ' + mt.Title);

                    self.showPage();
                });
               
                

            }
        });

        this.get('#/page/:page', function() {
            var page = this.params['page'];
            var obj = {};
            var tpl = '';
            var header = '';
            var result;
            //$('#inner-content').empty().html('');

            switch (page) {
                case 'events':
                    obj = window.alldata;
                    tpl = 'events-page-tpl';
                    header = 'Events';
                    break;
                case 'book':
                    obj = window.alldata;
                    tpl = 'booking-page-tpl';
                    break;
                case 'tracks':
                    obj = window.alldata;
                    tpl = 'tracks-page-tpl';
                    header = 'Tracks';
                    break;
                case 'mixtapes':
                    obj = window.alldata;
                    tpl = 'mixtapes-page-tpl';
                    header = "MixTape's";
                    break;
                case 'videos':
                    obj = window.alldata;
                    tpl = 'video-list-tpl';
                    header = "Video's";
                    break;
                case 'news':
                    obj = window.alldata;
                    tpl = 'news-page-tpl';
                    header = "News";
                    break;
                case 'gmbfamily':
                    break;
                case 'fans':
                    break;
                



                
                default:
                    return;
            }
            
          
            if (tpl != '') {
                dust.render(tpl, obj, function (err, out) {
                    result = out;
                });
                $('#inner-content').fadeOut('1000', function() {
                    $('#inner-content').empty().html(
                        result
                    );
                    $('#page-header').text(header);
                    self.showPage(function() {
                        $('#inner-content').fadeIn('1000');
                    });
                    
                });

            }
           
           
            
            
        });
       
       
        //});
    });

    self.toggleTitleContent = function (on) {
        if (on) {
            $('.title-content').show();
            $('.title-content-mobile').show();
            $('.social-bar').show();
        } else {
            $('.title-content').hide();
            $('.title-content-mobile').hide();
            $('.social-bar').hide();
        }
       


    }
    return self;
}

app.addViewModel({
    name: "Home",
    bindingMemberName: "home",
    factory: HomeViewModel
});
