import React, { useEffect, useState } from "react";
import "./App.css";
import GMap from "./components/GMap";
import FormInput from "./components/FormInput";
import { API_PATH } from "./services/api";

import "./global.css";
import "./App.css";
import "./Sidebar.css";
//import LocationSearchInput from './components/LocationSearchInput';
import './Main.css'

function App() {
  const [latitude, setLatitude] = useState("");
  const [longitude, setLongitude] = useState("");
  const [routes, setRoutes] = useState("");
  const [coordinates, setCoordinates] = React.useState([
    { lat: -23.4278807, lng: -51.90907379999999 },
    { lat: -23.4220372, lng: -51.9329162 }
  ]);

  function loadSavedRoutes() {
    const username = "admin";
    const password = "password";

    const headers = new Headers();
    headers.set("Authorization", "Basic " + btoa(username + ":" + password));

    fetch(API_PATH + "/api/routes", {
      method: "GET",
      headers: headers
    })
      .then(res => res.json())
      .then(res => {
        if (!res.message) {
          setRoutes(res);
        }
      })
      .catch(() => {
        console.log("Erro");
      });
  }

  useEffect(() => {
    loadSavedRoutes();

    navigator.geolocation.getCurrentPosition(
      position => {
        const { latitude, longitude } = position.coords;

        setLatitude(latitude);
        setLongitude(longitude);
      },
      err => {
        console.log(err);
      },
      {
        timeout: 30000
      }
    );
  }, []);

  /*const routes = [{
    id: 1,
    start: { id: 1, latitude: -23.4275806, longitude: -51.9077211 },
    end: { id: 2, latitude: -23.4285806, longitude: -51.9177211 }
  },
  {
    id: 2,
    start: { id: 3, latitude: -23.4185806, longitude: -51.8977211 },
    end: { id: 4, latitude: -23.4175806, longitude: -51.9277211 }
  }];*/

  const route = {
    id: 1,
    start: { id: 1, latitude: -23.4275806, longitude: -51.9077211 },
    end: { id: 2, latitude: -23.4285806, longitude: -51.9177211 }
  };

  return (
    <div id="app">
      <aside>
        <strong>Rotas</strong>
        <FormInput coordinates={coordinates} setCoordinates={setCoordinates} />
      </aside>
      <main>
        <GMap
          routes={routes}
          route={route}
          initialCenter={{
            lat: latitude,
            lng: longitude
          }}
          coordinates={coordinates}
          setCoordinates={setCoordinates}
        />
      </main>
    </div>
  );
}

export default App;
