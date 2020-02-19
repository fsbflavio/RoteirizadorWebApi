import React, { Component } from 'react';
import { Map, GoogleApiWrapper, Marker } from 'google-maps-react';

export class GMap extends Component {
  constructor(props) {
    super(props);
    this.handleMapReady = this.handleMapReady.bind(this);
  }

  displayMarkersStart = (routes) => {
    return routes.map((route, index) => {
      return <Marker key={route.id} id={route.id}
        position={{
          lat: route.start.latitude,
          lng: route.start.longitude
        }}
        onClick={() => console.log("pin start " + route.id)} />
    });
  }

  displayMarkersEnd = (routes) => {
    return routes.map((route, index) => {
      return <Marker key={route.id} id={route.id}
        position={{
          lat: route.end.latitude,
          lng: route.end.longitude
        }}
        onClick={() => console.log("pin end " + route.id)} />
    });
  }

  handleMapReady(mapProps, map) {
    this.calculateAndDisplayRoute(map);
  }

  calculateAndDisplayRoute(map) {
    const directionsService = new window.google.maps.DirectionsService();
    const directionsDisplay = new window.google.maps.DirectionsRenderer();
    directionsDisplay.setMap(map);

    const route = this.props.route;

    if (route == null)
      return;

    const origin = { lat: route.start.latitude, lng: route.start.longitude };
    const destination = { lat: route.end.latitude, lng: route.end.longitude };

    directionsService.route({
      origin: origin,
      destination: destination,

      //waypoints: waypoints,
      travelMode: 'DRIVING'
    }, (response, status) => {
      if (status === 'OK') {
        directionsDisplay.setDirections(response);
      } else {
        window.alert('Directions request failed due to ' + status);
      }
    });
  }

  render() {
    return (
      <Map
        google={this.props.google}
        zoom={14}
        initialCenter={this.props.initialCenter}
        onReady={this.handleMapReady}
      >
      </Map>
    );
  }
}

export default GoogleApiWrapper({
  apiKey: 'AIzaSyA0QwxquhAjg-VKIAaY17JrOdy4EtXumVE'
})(GMap);