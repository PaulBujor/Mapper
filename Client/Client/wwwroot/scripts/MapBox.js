var map;
var _dotNetReference;
var currentTemporaryMarker;



window.mapBoxFunctions = {
    reportPlace: function (placeId) {
        _dotNetReference.invokeMethodAsync('ReportPlace', parseInt(placeId));

    },
    modifyHref: function (placeId) {
        document.getElementById("replacehere").href = "/place/" + placeId;
    },
    addReviewLite: function (rating) {
        for (i = 1; i <= rating; i++)
        {
            document.getElementById("star" + i).className += " checked";
        }

    },
    initMapBox: function (dotNetReference) {
        mapboxgl.accessToken = 'pk.eyJ1IjoiZ2xhZDFvIiwiYSI6ImNraDBzZ2RzMDAxOXcycXJybjBlc2FoYzIifQ.6aVRcqBFu8dA_JC8yVsboA';
        _dotNetReference = dotNetReference;

        map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/outdoors-v11',
            center: [10.7522579808184, 56.03891165651774],
            zoom: 6
        });

        map.on("click", function (e) {
            console.log(e.lngLat);
            _dotNetReference.invokeMethodAsync('MapClickAsync', e.lngLat.toArray()[0], e.lngLat.toArray()[1]);
        });
    },

    addMarker: function (longitude, latitude, placeTitle, placeDescription, placeId) {

        var buttonReportHTML = "<button type='button' onclick='mapBoxFunctions.reportPlace(document.getElementById(\"placeId\").innerHTML)' class='btn btn-outline-danger btn-sm' style='position: absolute; right: 0; bottom: 0; margin: 5px;'> Report </button>";
        var buttonDetailsHTML = "<a id = 'replacehere' href = '#'><button onclick='mapBoxFunctions.modifyHref(document.getElementById(\"placeId\").innerHTML)' type='button' class='btn btn-outline-info btn-sm' style='position: absolute; left: 0; bottom: 0; margin: 5px;'> Comment & Review </button></a>";
        var ratingHTML = "<span id='star1' class='fa fa-star fa-2x'></span><span id='star2' class='fa fa-star fa-2x'></span><span id='star3' class='fa fa-star fa-2x'></span><span id='star4' class='fa fa-star fa-2x'></span><span id='star5' class='fa fa-star fa-2x'></span>";

        var popup = new mapboxgl.Popup({ className: "popup-marker" }).setHTML(
            "<div><div><h5>" + placeTitle + "</h5>" + "<div style = 'float: right;'>" + ratingHTML + "</div>"+ "</div><a id= 'placeId' style = 'display: none;'>" + placeId + "</a>" + "<h6>Category</h6>" + "</div></br><div><a>" + placeDescription + "</a></div>" + buttonReportHTML + buttonDetailsHTML
        );

        popup.on("open", function () {
            _dotNetReference.invokeMethodAsync('GetPlaceDetails', parseInt(placeId));
        });

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
    }

}