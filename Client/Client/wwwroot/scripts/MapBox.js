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

    addMarker: function (longitude, latitude, placeTitle, placeDescription) {
        
        var popup = new mapboxgl.Popup({ offset: 25 }).setText(
            "Title:\n" + placeTitle + "\nDescription:\n" + placeDescription
        );

        // create DOM element for the marker -- add styling to marker el.id or el.className
        var el = document.createElement('div');
        el.id = 'marker';

        var marker = new mapboxgl.Marker()
            .setLngLat([longitude, latitude])
            .setPopup(popup)
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
    },




}