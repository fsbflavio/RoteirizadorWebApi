import React, { useState, useEffect } from "react";
import { GoogleApiWrapper} from "google-maps-react";

import { LocationSearchInput } from "./";
import calculateAndDisplayRoute from "../../services/calculateAndDisplayRoute";
//import saveRoute from "../../services/saveRoute";

function FormInput({
  coordinates,
  setCoordinates,
  propsRoute,
  setpropsRoute,
  map
}) {
  const [labels, setlabels] = useState([]);

  useEffect(() => {
    let initAdresses = [{ label: "Origem", address: "" }, { label: "Parada", address: "" }];
    const url = new URL(window.location.href);
    if (url.search.includes("?adresses/")) {
      const addressesUrl = url.search.replace("?adresses/", "");
      const enderecos = addressesUrl.split("/")

      const lab = enderecos.map((endereco, index) => {
        if (index === 0)
        {
          return { label: "Origem", address: endereco }
        }

        return { label: "Parada", address: endereco }
      });

      console.log(lab);
      initAdresses = lab;
      //setlabels(lab);
    }
    setlabels(initAdresses);

  }, []);

  async function handleSubmit(e) {
    e.preventDefault();

    //saveRoute(coordinates);
    calculateAndDisplayRoute(map, coordinates, setpropsRoute);
  }

  function handlerAddParada(text) {
    setlabels([...labels, { label: text, address: "" }]);
  }

  return (
    <>
      <form onSubmit={handleSubmit}>
        {labels.map((label, index) => (
          <LocationSearchInput
            coordinates={coordinates}
            setCoordinates={setCoordinates}
            label={label}
            index={index}
            key={index}
          />
        ))}

        <div className="buttons">
          <button type="submit">Roterizar</button>

          <button type="button" onClick={() => handlerAddParada("Parada")}>
            +
          </button>
        </div>
      </form>
      {propsRoute.distancia && (
        <div className="atributos-rotas">
          <span> <b>Distância: </b>{(propsRoute.distancia / 1000).toFixed(2)} km </span>
          <span> <b>Tempo Estimado: </b>{(propsRoute.tempo / 3600).toFixed(2)} horas </span>
        </div>
      )}
    </>
  );
}

//export default FormInput;
export default GoogleApiWrapper({
  apiKey:`${process.env.REACT_APP_GDRIVE_TOKEN}`
})(FormInput);