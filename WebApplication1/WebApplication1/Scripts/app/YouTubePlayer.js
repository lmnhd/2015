window.YouTubePlayer = (function() {
    var YouTubePlayer = {};

    var ytplayer;
    var ytPlayerReady = false;
    var playing = false;

    function onYouTubeIframeAPIReady() {
        ytPlayerReady = true;
    }

    YouTubePlayer.playVideo = function playVideo(id) {
        
        ytplayer = new YT.Player('ytdiv', {
            height: '480',
            width: '853',
            videoId: id,
            events: {
                'onReady': onPlayerReady,
                'onStateChange': onPlayerStateChange
            }
        });
    }
    YouTubePlayer.stopVideo = function stopVideo() {
        if (playing) {
            stopVid();
            playing = false;
        }
    }

    function onPlayerReady(event) {
        event.target.playVideo();
    }

    function onPlayerStateChange() {

    }

    function stopVid() {
        ytplayer.stopVideo();
        ytplayer.clearVideo();
        ytplayer = null;
    }

    return YouTubePlayer;
})();