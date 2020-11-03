var map;
var _dotNetReference

window.mapBoxFunctions = {
    initMapBox: function (dotNetReference) {
        mapboxgl.accessToken = 'pk.eyJ1IjoiZ2xhZDFvIiwiYSI6ImNraDBzZ2RzMDAxOXcycXJybjBlc2FoYzIifQ.6aVRcqBFu8dA_JC8yVsboA';
        _dotNetReference = dotNetReference
        map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/outdoors-v11'
        });
        map.on("click", function (e) {
            _dotNetReference.invokeMethodAsync('MapClickAsync', e.lngLat.toArray()[0], e.lngLat.toArray()[1]);
        });
    },
    addMarker: function (longitude, latitude) {
        var marker = new mapboxgl.Marker()
            .setLngLat([longitude, latitude])
            .addTo(map);
    },
    addTemporaryMarker: function (longitude, latitude) {
        var marker = new mapboxgl.Marker({ color: "#32a852"})
            .setLngLat([longitude, latitude])
            .addTo(map);
    }
}