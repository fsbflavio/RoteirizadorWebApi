import {API_PATH} from './api';

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
          //setRoutes(res);
        }
      })
      .catch(() => {
        console.log("Erro");
      });
  }

  export default loadSavedRoutes;