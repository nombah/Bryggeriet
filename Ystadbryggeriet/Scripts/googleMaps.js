
 google.maps.event.addDomListener(window, 'load', init);
 var myLatlng = new google.maps.LatLng(55.4285283, 13.8177522);
    function init() {
        var mapOptions = {
            zoom: 17,
            center: myLatlng, 
            scrollwheel: false,
            draggable: false,
            styles: [
    {
        "featureType": "landscape",
        "stylers": [
            {
                "saturation": -100
            },
            {
                "lightness": 60
            }
        ]
    },
    {
        "featureType": "road.local",
        "stylers": [
            {
                "saturation": -100
            },
            {
                "lightness": 40
            },
            {
                "visibility": "on"
            }
        ]
    },
    {
        "featureType": "transit",
        "stylers": [
            {
                "saturation": -100
            },
            {
                "visibility": "simplified"
            }
        ]
    },
    {
        "featureType": "administrative.province",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "water",
        "stylers": [
            {
                "visibility": "on"
            },
            {
                "lightness": 30
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#ef8c25"
            },
            {
                "lightness": 40
            }
        ]
    },
    {
        "featureType": "road.highway",
        "elementType": "geometry.stroke",
        "stylers": [
            {
                "visibility": "off"
            }
        ]
    },
    {
        "featureType": "poi.park",
        "elementType": "geometry.fill",
        "stylers": [
            {
                "color": "#b6c54c"
            },
            {
                "lightness": 40
            },
            {
                "saturation": -40
            }
        ]
    },
    {}
]
        };
        var mapElement = document.getElementById('mapdiv');
        var map = new google.maps.Map(mapElement, mapOptions);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            optimized: false,
            icon: 'http://www.slongrad.com/era/theme/img/mapicon.png'
        });     
    }