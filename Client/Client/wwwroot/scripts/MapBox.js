var map;
var _dotNetReference;
var currentTemporaryMarker;

window.mapBoxFunctions = {
    initMapBox: function (dotNetReference) {
        mapboxgl.accessToken = 'pk.eyJ1IjoiZ2xhZDFvIiwiYSI6ImNraDBzZ2RzMDAxOXcycXJybjBlc2FoYzIifQ.6aVRcqBFu8dA_JC8yVsboA';
        _dotNetReference = dotNetReference;

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

    setTemporaryMarker: function (longitude, latitude) {
        if (currentTemporaryMarker == null)
            currentTemporaryMarker = new mapboxgl.Marker({ color: "#32a852" });

        currentTemporaryMarker.setLngLat([longitude, latitude])
            .setDraggable(true)
            .addTo(map);

        currentTemporaryMarker.on("dragend", function (e) {
            _dotNetReference.invokeMethodAsync('UpdateCoordinates', currentTemporaryMarker.getLngLat().toArray()[0], currentTemporaryMarker.getLngLat().toArray()[1]);
        });
    },

    removeTemporaryMarker: function () {
        currentTemporaryMarker.remove();
    }
}