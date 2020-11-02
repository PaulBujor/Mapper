window.mapBoxFunctions = {
    initMapBox: function () {
        mapboxgl.accessToken = 'pk.eyJ1IjoiZ2xhZDFvIiwiYSI6ImNraDBzZ2RzMDAxOXcycXJybjBlc2FoYzIifQ.6aVRcqBFu8dA_JC8yVsboA';
        var map = new mapboxgl.Map({
            container: 'map',
            style: 'mapbox://styles/mapbox/streets-v11'
        });
    }
}