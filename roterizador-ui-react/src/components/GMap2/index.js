import React, { Component } from 'react';
import { Map, GoogleApiWrapper } from 'google-maps-react';

const mapStyles = {
  width: '100%',
  height: '100%'
};

export class GMap2 extends Component {
  render() {
    return (
      <Map
        google={this.props.google}
        zoom={14}
        style={mapStyles}
        initialCenter={{
          lat: -23.4275806,
          lng: -51.9077211
        }}
      />
    );
  }
}

export default GoogleApiWrapper({
  apiKey: 'AIzaSyA0QwxquhAjg-VKIAaY17JrOdy4EtXumVE'
})(GMap2);