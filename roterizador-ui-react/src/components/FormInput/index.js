import React, { useState } from 'react';
import LocationSearchInput from '../LocationSearchInput';

function FormInput({ onSubmit }) {
    const [start_pin, setStartPin] = useState('');
    const [end_pin, setEndPin] = useState('');
   // const [latitude, setLatitude] = useState('');
    //const [longitude, setLongitude] = useState('');

    async function handleSubmit(e) {
        e.preventDefault();

        await onSubmit({
            start_pin,
            end_pin,
           // latitude,
           // longitude,
        });

        setStartPin('');
        setEndPin('');
    }

    return (
        <form onSubmit={handleSubmit}>
            <div className="input-block">
                <label htmlFor="start_pin">Origem:</label>
                <LocationSearchInput/>
            </div>

            <div className="input-block">
                <label htmlFor="end_pin">Parada:</label>
                <LocationSearchInput/>
            </div>
            
            

            <button type="submit">Roterizar</button>
        </form>
    );
}

export default FormInput;