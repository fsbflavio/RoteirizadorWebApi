import React, { useState } from "react";

import { LocationSearchInput } from "./";
import calculateAndDisplayRoute from "../../services/calculateAndDisplayRoute";
import saveRoute from "../../services/saveRoute";

function FormInput({
  coordinates,
  setCoordinates,
  propsRoute,
  setpropsRoute,
  map
}) {
  const [labels, setlabels] = useState(["Origem", "Parada"]);

  async function handleSubmit(e) {
    e.preventDefault();

    saveRoute(coordinates);
    calculateAndDisplayRoute(map, coordinates, setpropsRoute);
  }

  function handlerAddParada(text) {
    setlabels([...labels, text]);
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

export default FormInput;
