import React, { Component } from "react";
import { Map, GoogleApiWrapper, Marker } from "google-maps-react";

export class GMap extends Component {
  state = {
    map: {}
  };

  handleMapReady = (mapPros, map) => {
    this.calculateAndDisplayRoute(map);
    this.setState({
      map: map
    });
  };

  calculateAndDisplayRoute(map) {
    const { coordinates } = this.props;
    const directionsService = new window.google.maps.DirectionsService();
    const directionsDisplay = new window.google.maps.DirectionsRenderer();
    directionsDisplay.setMap(null);
    directionsDisplay.setMap(map);

    if (coordinates.length <= 1) return;

    let origin;
    if (coordinates.length === 2)
      origin = { lat: coordinates[0].lat, lng: coordinates[0].lng };
    else origin = { lat: coordinates[2].lat, lng: coordinates[2].lng };

    const destination = {
      lat: coordinates[1].lat,
      lng: coordinates[1].lng
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
          console.log("chegou aqui");
          directionsDisplay.setDirections(response);
        } else {
          window.alert("Directions request failed due to " + status);
        }
      }
    );
  }

  handleClick = () => {
    this.calculateAndDisplayRoute(this.state.map);
  };

  
  render() {
    const { coordinates } = this.props;

    const containerStyle = {
      position: 'relative',  
      width: '100%',
      height: '100%'
    }
    return (
      <div className="mapa">
        <Map
          google={this.props.google}
          zoom={14}
          initialCenter={this.props.initialCenter}
          onReady={this.handleMapReady}
          coordinates={coordinates}
          style={containerStyle}
        >
          {coordinates.map((coord, index) => (
            <Marker
              key={index}
              position={{
                lat: coord.lat,
                lng: coord.lng
              }}
              onClick={() => console.log("pin end " + 0)}
            />
          ))}
        </Map>
        <button onClick={this.handleClick}>adasdasd</button>
      </div>
    );
  }
}

export default GoogleApiWrapper({
  apiKey: "AIzaSyA0QwxquhAjg-VKIAaY17JrOdy4EtXumVE"
})(GMap);
