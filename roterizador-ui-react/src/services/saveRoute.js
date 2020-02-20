import {API_PATH} from './api';

function saveRoute( coordinates ) {
        const username = "admin";
        const password = "password";

        const headers = new Headers();
        headers.set("Authorization", "Basic " + btoa(username + ":" + password));
        headers.set("Content-Type", "application/json");

        fetch(API_PATH + "/api/routes", {
            method: "POST",
            headers: headers,
            body: JSON.stringify({
                descricao: "nome da rota 2",
                coordinates: [
                    {
                        longitude: coordinates[0].lat,
                        latitude: coordinates[0].lng
                    },
                    {
                        longitude: coordinates[1].lat,
                        latitude: coordinates[1].lng
                    }
                ]
            })
        })
            .then(res => res.json())
            .then(res => {
                if (!res.message) {
                }
            })
            .catch(() => {
                console.log("Erro");
            });
    }

    export default saveRoute;