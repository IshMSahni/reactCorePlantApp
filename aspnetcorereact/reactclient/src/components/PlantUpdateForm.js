
import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function PlantUpdateForm(props) {
    const initialFormData = Object.freeze({
        name: props.plant.name,
        content: props.plant.content,
        lastWatered: props.plant.lastWatered
    });

    const [formData, setFormData] = useState(initialFormData);


    const handleChange = (e) => {
        setFormData({
            ...formData,
            [e.target.name]: e.target.value,
        });
    };

    const handleSubmit = (e) => {
        e.preventDefault();
        const plantToUpdate = {
            plantId: props.plant.plantId,
            name: formData.name,
            content: formData.content,
            lastWatered: props.plant.lastWatered
        };

        var date = new Date();
        var value = date.toJSON();
        const url = `${Constants.API_URL_UPDATE_PLANT}/${props.plantId}/${value};`;
        fetch(url, { method: 'GET' })
      .then(response => response.json())
      .then(plantsFromServer => {})
      .catch((error) => {
        console.log(error);
        alert(error);
      })
    };

    return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Update plant </h1>
            <div className="mt-5">
                <label className="h3 form-label">Plant name</label>
                <input value={formData.name} name="title" type="text" className="form-control" onChange={handleChange}></input>
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Plant content</label>
                <input value={formData.content} name="content" type="text" className="form-control" onChange={handleChange}></input>
            </div>

            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPlantUpdated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
    );

}
