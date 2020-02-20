import React from 'react';
import LocationSearchInput from '../LocationSearchInput';
import calculateAndDisplayRoute from "../../services/calculateAndDisplayRoute";

function FormInput({ coordinates, setCoordinates, map, onSubmit }) {
    
    function handleClick () {
        setCoordinates([]);
        calculateAndDisplayRoute(map, coordinates);
      };
    
    async function handleSubmit(e) {
        e.preventDefault();

        //save in bd

    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="input-block">
                <label htmlFor="start_pin">Origem:</label>
                <LocationSearchInput coordinates={coordinates} setCoordinates={setCoordinates}/>
            </div>

            <div className="input-block">
                <label htmlFor="end_pin">Parada:</label>
                <LocationSearchInput coordinates={coordinates} setCoordinates={setCoordinates}/>
            </div>

            <button type="submit" onClick={handleClick} >Roterizar</button>
        </form>
    );
}

export default FormInput;