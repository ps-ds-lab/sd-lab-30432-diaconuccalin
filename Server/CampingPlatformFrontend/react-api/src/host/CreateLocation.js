import React, { useState } from 'react';
import axios from 'axios';

import { getToken, getUser } from '../utils/Common'

function CreateLocation() {
    const guestNo = useFormInput('');
    const address = useFormInput('');
    const description = useFormInput('');

    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleCreate = () => {
        setError(null);
        setLoading(true);
        var days = "";

        if(document.getElementById("friday").checked === true) {
            days = "FRI ";
        }
        if(document.getElementById("saturday").checked === true) {
            days = days.concat("SAT ");
        }
        if(document.getElementById("sunday").checked === true) {
            days = days.concat("SUN ");
        }

        axios
            .post('http://localhost:5000/api/locations',
                {
                    hostId: getUser().id,
                    maxNoGuests: parseInt(guestNo.value),
                    physicalAddress: address.value,
                    description: description.value,
                    days: days
                },
                { 'headers':
                    { 'Authorization' : 'Bearer ' + getToken() }})
            .then(response => {
                setLoading(false);
                window.location.href='/';
            })
            .catch(error => {
                setLoading(false);
                setError("Something went wrong. Please try again later.");
            });
    }

    return (
    <div class="container align-middle">
        <form>
        <div class="row justify-content-center align-items-center mb-2">
            <h1>Create new location</h1>
        </div>
        <div class="row justify-content-center align-items-center mb-2">
            <div class = "col-4">
                Maximum number of guests<br />
                <input type="number" class="form-control" {...guestNo} />
            </div>
        </div>
        <div class="row justify-content-center align-items-center mb-2">
            <div class = "col-4">
                Available days<br />
                <div class="form-check form-check-inline">
                    <input id="friday" name="friday" type="checkbox" />
                    <label class="form-check-label" for="friday">Friday</label>
                </div>
                <div class="form-check form-check-inline">
                    <input id="saturday" name="saturday" type="checkbox" />
                    <label class="form-check-label" for="saturday">Saturday</label>
                </div>
                <div class="form-check form-check-inline">
                    <input id="sunday" name="sunday" type="checkbox" />
                    <label class="form-check-label" for="sunday">Sunday</label>
                </div>
            </div>
        </div>
        <div class="row justify-content-center align-items-center">
            <div class="col-4">
                Physical address<br />
                <textarea class="form-control mb-2" style={{resize: "none"}} {...address}/>
            </div>
        </div>
        <div class="row justify-content-center align-items-center">
            <div class="col-4">
                Location description<br />
                <textarea class="form-control mb-2" rows="5" style={{resize: "none"}} {...description}/>
            </div>
        </div>
        <div class="row justify-content-center align-items-center">
            <div class="col-4">
                Location pictures<br />
                <input type="file" class="form-control-file mb-2" />
            </div>
        </div>
        <div class="row justify-content-center align-items-center">
            {error && <><small style={{ color: 'red' }}>{error}</small><br /></>}<br />
        </div>
        <div class="row justify-content-center align-items-center">
                <div class="col-4">
                <button type="button" class="btn btn-primary mr-1" onClick={handleCreate} disabled={loading} >{loading ? 'Loading...' : 'Create'}</button>
                </div>
        </div>
        </form>
    </div>
    );
}

const useFormInput = initialValue => {
    const [value, setValue] = useState(initialValue);

    const handleChange = e => {
        setValue(e.target.value);
    }
    return {
        value,
        onChange: handleChange
    }
}

export default CreateLocation;