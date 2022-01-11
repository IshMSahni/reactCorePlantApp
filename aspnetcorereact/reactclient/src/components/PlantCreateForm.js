
import React, { useState } from "react";
import Constants from "../utilities/Constants";

export default function PlantCreateForm(props) {
    const initialFormData = Object.freeze({
        name: "Plant",
        content: "about plant x"
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
        const plantToCreate = {
            plantId: 0,
            name: formData.name,
            content: formData.content,
            wateringStatus: formData.wateringStatus
        };
        const url = Constants.API_URL_CREATE_PLANT;
        fetch(url, {
            method: 'POST', headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(plantToCreate)
        })
            .then(response => response.json())
            .then(responseFromServer => { console.log(responseFromServer); })
            .catch((error) => {
                console.log(error);
                alert(error);
            });
            props.onPlantCreated(plantToCreate);
};

return (
        <form className="w-100 px-5">
            <h1 className="mt-5">Create new plant</h1>
            <div className="mt-5">
                <label className="h3 form-label">Plant name</label>
                <input value={formData.name} name="title" type="text" className="form-control" onChange={handleChange}></input>
            </div>

            <div className="mt-4">
                <label className="h3 form-label">Plant content</label>
                <input value={formData.content} name="content" type="text" className="form-control" onChange={handleChange}></input>
            </div>
            <button onClick={handleSubmit} className="btn btn-dark btn-lg w-100 mt-5">Submit</button>
            <button onClick={() => props.onPlantCreated(null)} className="btn btn-secondary btn-lg w-100 mt-3">Cancel</button>
        </form>
);

}
