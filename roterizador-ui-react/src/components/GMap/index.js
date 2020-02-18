import React, { Component } from 'react';
import GoogleMapReact from 'google-map-react';
import { Marker } from 'google-maps-react';

const AnyReactComponent = ({ text }) => <div>{text}</div>;

class GMap extends Component {
  static defaultProps = {
    center: {
      lat: -23.4275806,
      lng: -51.9077211
    },
    zoom: 14
  };

  render() {
    return (
      // Important! Always set the container height explicitly
      <div style={{ height: '100vh', width: '100%' }}>
        <GoogleMapReact
          bootstrapURLKeys={{ key: 'AIzaSyA0QwxquhAjg-VKIAaY17JrOdy4EtXumVE',
          language: 'pt-br' }}
          defaultCenter={this.props.center}
          defaultZoom={this.props.zoom}
        >
          <Marker
            lat={-23.4275806}
            lng={-51.9077211}
          />
        </GoogleMapReact>
      </div>
    );
  }
}

export default GMap;