import React, { useState } from 'react';
//import SearchBar from '../SearchBar';

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
                <input
                    name="start_pin"
                    id="start_pin"
                    required
                    value={start_pin}
                    onChange={e => setStartPin(e.target.value)} />
            </div>

            <div className="input-block">
                <label htmlFor="end_pin">Parada:</label>
                <input
                    name="end_pin"
                    id="end_pin"
                    required
                    value={end_pin}
                    onChange={e => setEndPin(e.target.value)} />
            </div>
            

            <button type="submit">Roterizar</button>
        </form>
    );
}

export default FormInput;