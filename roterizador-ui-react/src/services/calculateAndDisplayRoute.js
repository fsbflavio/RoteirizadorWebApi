function calculateAndDisplayRoute(map, coordinates) {
    const directionsService = new window.google.maps.DirectionsService();
    const directionsDisplay = new window.google.maps.DirectionsRenderer();
    directionsDisplay.setMap(null);
    directionsDisplay.setMap(map);

    if (coordinates.length <= 1) return;

    const origin = {
        lat: coordinates[0].lat,
        lng: coordinates[0].lng
      };

    const destination = {
      lat: coordinates[coordinates.length -1].lat,
      lng: coordinates[coordinates.length -1].lng
    };

    directionsService.route(
      {
        origin: origin,
        destination: destination,

        //waypoints: waypoints,
        travelMode: "DRIVING"
      },
      (response, status) => {
        if (status === "OK") {
          directionsDisplay.setDirections(response);
        } else {
          window.alert("Directions request failed due to " + status);
        }
      }
    );
  }

export default calculateAndDisplayRoute;