import React, { useState } from "react";
import PlacesAutocomplete from "react-places-autocomplete";

import getCoordenatesFromAddress from '../../services/getCoordenatesFromAddress';

export default function LocationSearchInput({ coordinates, setCoordinates, label, index }) {
  const [address, setAddress] = useState(label.address);


  const handleSelect = async value => {
    const latLng = await getCoordenatesFromAddress(value);
    setAddress(value);
    setCoordinates([...coordinates.slice(0, index), latLng, ...coordinates.slice(index + 1, coordinates.length)]);
  };

  return (
    <div className="input-block">
      <label htmlFor="start_pin">{label.label}</label>

      <PlacesAutocomplete
        value={address}
        onChange={setAddress}
        onSelect={handleSelect}
      >
        {({ getInputProps, suggestions, getSuggestionItemProps, loading }) => (
          <div>
            <input
              {...getInputProps({ placeholder: "Digite um endereço" })}
              required
            />

            <div>
              {loading ? <div>...loading</div> : null}

              {suggestions.map((suggestion, index) => {
                const style = {
                  backgroundColor: suggestion.active ? "#41b6e6" : "#fff"
                };

                return (
                  <div
                    {...getSuggestionItemProps(suggestion, { style })} key={index}>
                    {suggestion.description}
                  </div>
                );
              })}
            </div>
          </div>
        )}
      </PlacesAutocomplete>
    </div>
  );
}
