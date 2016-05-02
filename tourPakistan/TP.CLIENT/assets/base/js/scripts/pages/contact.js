// CONTACT MAP

var PageContact = function() {

	var _init = function() {

		var mapbg = new GMaps({
			div: '#gmapbg',
			lat: 31.5703595,
			lng: 74.30962939999995,
			scrollwheel: false
		});


		mapbg.addMarker({
		    lat: 31.5703595,
		    lng: 74.30962939999995,
			title: 'Punjab University College of Information Technology',
			infoWindow: {
			    content: '<h3>PUCIT - Punjab University College of Information Technology</h3><p>Tour Pakistan &copy</p>'
			}
		});
	}

    return {
        //main function to initiate the module
        init: function() {

            _init();

        }

    };
}();

$(document).ready(function() {
    PageContact.init();
});