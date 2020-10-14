import React, { Component } from "react";
import { Map, GoogleApiWrapper, Marker } from "google-maps-react";
import calculateAndDisplayRoute from "../../services/calculateAndDisplayRoute";

export class GMap extends Component {
  state = {
    map: {}
  };

  handleMapReady = (mapPros, map) => {
    calculateAndDisplayRoute(map, this.props.coordinates);
    this.setState({
      map: map
    });
    const {setMap} = this.props ;
    setMap(map);
  };

  handleClick = () => {
    calculateAndDisplayRoute(this.state.map, this.props.coordinates);
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
      </div>
    );
  }
}

export default GoogleApiWrapper({
  apiKey:`${process.env.REACT_APP_GDRIVE_TOKEN}`
})(GMap);
