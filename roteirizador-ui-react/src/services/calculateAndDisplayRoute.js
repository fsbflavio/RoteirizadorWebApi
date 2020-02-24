function calculateAndDisplayRoute(map, coordinates, setpropsRoute) {
  const directionsService = new window.google.maps.DirectionsService();
  const directionsDisplay = new window.google.maps.DirectionsRenderer();

  directionsDisplay.setMap(null);
  directionsDisplay.setMap(map);

  if (coordinates.length <= 1) return;

  const waypoints = coordinates.map(coord => ({
    location: { lat: coord.lat, lng: coord.lng },
    stopover: true
  }));

  const origin = waypoints.shift().location;
  const destination = waypoints.pop().location;

  directionsService.route(
    {
      origin: origin,
      destination: destination,

      waypoints: waypoints,
      travelMode: "DRIVING"
    },
    (response, status) => {
      if (status === "OK") {
        directionsDisplay.setDirections(response);
        setpropsRoute({
          distancia: response.routes[0].legs.reduce(
            (soma, distancia) => soma + distancia.distance.value,
            0
          ),
          tempo: response.routes[0].legs.reduce(
            (soma, tempo) => soma + tempo.duration.value,
            0
          )
        });
      } else {
        window.alert("Directions request failed due to " + status);
      }
    }
  );
}

export default calculateAndDisplayRoute;
