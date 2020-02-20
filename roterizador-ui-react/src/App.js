import React, { useEffect, useState } from "react";
import "./App.css";
import GMap from "./components/GMap";
import FormInput from "./components/FormInput";
import { API_PATH } from "./services/api";

import "./global.css";
import "./App.css";
import "./Sidebar.css";
import './Main.css'

function App() {
  const [latitude, setLatitude] = useState("");
  const [longitude, setLongitude] = useState("");
  const [routes, setRoutes] = useState("");
  const [globalMap, setMap] = useState("");
  const [coordinates, setCoordinates] = React.useState([]);

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

  const route = {
    id: 1,
    start: { id: 1, latitude: -23.4275806, longitude: -51.9077211 },
    end: { id: 2, latitude: -23.4285806, longitude: -51.9177211 }
  };

  return (
    <div id="app">
      <aside>
        <strong>Rotas</strong>
        <FormInput coordinates={coordinates} setCoordinates={setCoordinates} map={globalMap} setMap={setMap} />
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
          map={globalMap} 
          setMap={setMap}
        />
      </main>
    </div>
  );
}

export default App;
