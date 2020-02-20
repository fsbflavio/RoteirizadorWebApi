import React, { useEffect, useState } from "react";
import "./App.css";
import GMap from "./components/GMap";
import { FormInput } from "./components/FormInput";
import loadSavedRoutes from "./services/loadSavedRoutes";

import "./global.css";
import "./App.css";
import "./Sidebar.css";
import "./Main.css";

function App() {
  const [latitude, setLatitude] = useState("");
  const [longitude, setLongitude] = useState("");
  const [globalMap, setMap] = useState("");
  const [coordinates, setCoordinates] = React.useState([]);
  const [propsRoute, setpropsRoute] = React.useState({});
  
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

  return (
    <div id="app">
      <aside>
        <strong>Rotas</strong>
        <FormInput
          coordinates={coordinates}
          setCoordinates={setCoordinates}
          propsRoute={propsRoute}
          map={globalMap}
          setMap={setMap}
          setpropsRoute={setpropsRoute}
        />
      </aside>
      <main>
        <GMap
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
