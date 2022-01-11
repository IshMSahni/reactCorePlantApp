import { render } from "@testing-library/react";
import React, { useState } from "react";
import Constants from "./utilities/Constants";
import PlantCreateForm from "./components/PlantCreateForm";
import PlantUpdateForm from "./components/PlantUpdateForm";

export default function App() {
  var count = 0;
  const [plants, setPlants] = useState([]);
  const [showingCreateNewPlantForm, setShowingCreateNewPlantForm] = useState(false);
  const [plantCurrentlyBringUpdated, setPlantCurrentlyBeingUpdated] = useState(null);
  function getPlants() {
    const url = Constants.API_URL_GET_ALL_PLANTS;
    fetch(url, {method:'GET'})
      .then(response => response.json())
      .then(plantsFromServer => { setPlants(plantsFromServer); })
      .catch((error) => {
        console.log(error);
        alert(error);
      })
  }
  return (
    <div className="container">
      <div className="row min-vh-100">
        <div className="col d-flex flex-column justify-content-center align-items-center ">
          {(showingCreateNewPlantForm === false && plantCurrentlyBringUpdated === null) && (
            <div>
              <h1>ShipVista watering platform!</h1>
              <div className="mt-5">
                <button onClick={getPlants} className="btn btn-dark btn-lg w-100">Get plants from server</button>
                <button onClick={() => setShowingCreateNewPlantForm(true)} className="btn btn-secondary btn-lg w-100 mt-4">Add new plants</button>
              </div>
            </div>
          )}

          {(plants.length > 0 && showingCreateNewPlantForm === false && plantCurrentlyBringUpdated === null) && renderPlantsTable()}
          {showingCreateNewPlantForm && <PlantCreateForm onPlantCreated={onPlantCreated} />}
          {plantCurrentlyBringUpdated !== null && <PlantUpdateForm plant={plantCurrentlyBringUpdated} onPlantUpdated={onPlantUpdated} />}
        </div>
      </div>
    </div>
  );
  function renderPlantsTable() {
    return (
      <div className="table-responsive mt-5">
        <table className="table table-bordered border-dark">
          <thead>
            <tr>
              <th scope="col">
                PlantId (PK)
              </th>
              <th scope="col">
                Name
              </th>
              <th scope="col">
                Content
              </th>
              <th scope="col">
                Watering Status
              </th>
              <th scope="col">
                Watered?
              </th>
            </tr>
          </thead>
          <tbody>
            {plants.map((plant) => (

              <tr key={plant.plantId}>
                <th scope="row">{plant.plantId}</th>
                <td>{plant.name}</td>
                <td>{plant.content}</td>
                <td>{plant.wateringStatus.toString()} </td>

                <td>{wateringStatusCheck(plant.wateringStatus, plant)}
                </td>


              </tr>
            ))}
          </tbody>
        </table>

        <button onClick={() => setPlants([])} className="btn btn-dark btn-lg w-100"> Empty plants array</button>
      </div>
    );
  }


  function wateringStatusCheck(wateringStatus, plant) {
    var date = new Date();
    var value = date.toJSON();
    const url = `${Constants.API_URL_UPDATE_PLANT}/${plant.plantId}/${value}`;
    fetch(url, { method: 'GET' })
      .then(response => (console.log(response)))
      .catch((error) => {
        console.log(error);
        alert(error);
      });
      if (!wateringStatus) {
        return (
          <div>
            <button onClick={() => waterPlant(plant, true)} className="btn btn-dark btn-lg mx-3 my-3">Water</button>
            <button onClick={() => { waterPlant(plant, false) }} className="btn btn-secondary btn-lg">Stop</button></div>
        );
      } else {
        return (<div>Yes</div>);
      }
  }



  function waterPlant(plant, check) {
    var timeleft = 10 - count;
    var downloadTimer = setInterval(function () {
      if (timeleft <= 0) {

        clearInterval(downloadTimer);
        count = 0;
        waterPlant(plant, false);

      }
      if (check) {
        timeleft -= 1;
      } else {
        count = timeleft;
      }
    }, 1000);
  }

  function onPlantCreated(createdPlant) {
    setShowingCreateNewPlantForm(false);
    if (createdPlant === null) {
      return;
    }

    alert(`Plant Created: ${createdPlant.name},`);
    getPlants();
  }

  function onPlantUpdated(updatedPlant) {
    setPlantCurrentlyBeingUpdated(null);
    if (updatedPlant === null) {
      return;
    }
    let plantsCopy = [...plants];

    const index = plantsCopy.findIndex((plantsCopyPlant, currentIndex) => {
      if (plantsCopyPlant.plantId === updatedPlant.plantId) {
        return true;
      }
    });

    if (index !== -1) {
      plantsCopy[index] = updatedPlant;
    }

    setPlants(plantsCopy);

    alert(`Plant updated ${updatedPlant.name}`);
  }
}
