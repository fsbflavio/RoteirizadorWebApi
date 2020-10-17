import {
    geocodeByAddress,
    getLatLng
} from "react-places-autocomplete";

export default async function getCoordenatesFromAddress(address) {
    const results = await geocodeByAddress(address);
    const latLng = await getLatLng(results[0]);

    return latLng;
}