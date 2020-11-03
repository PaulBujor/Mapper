var map;
var _dotNetHelper;

window.mapBoxFunctions = {
    initMapBox: function (dotNetHelper) {
        mapboxgl.accessToken = 'pk.eyJ1IjoiZ2xhZDFvIiwiYSI6ImNraDBzZ2RzMDAxOXcycXJybjBlc2FoYzIifQ.6aVRcqBFu8dA_JC8yVsboA';
        _dotNetHelper = dotNetHelper
        map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11'
        });
        map.on("click", function (e) {
            console.log(e.lngLat.toArray()[0]);
            _dotNetHelper.ivokeMethodAsync('MapClickedAsync', e.lngLat.toArray()[0], e.lngLat.toArray()[0]);
            
        });
    },
    addMarker: function (longitude, latitude) {
        var marker = new mapboxgl.Marker()
            .setLngLat([longitude, latitude])
            .addTo(map);
    }
}