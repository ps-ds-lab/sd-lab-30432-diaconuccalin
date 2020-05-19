import React, { useState } from 'react';
import axios from 'axios';

function GuestRegister() {
    const firstName = useFormInput('');
    const lastName = useFormInput('');
    const email = useFormInput('');
    const username = useFormInput('');
    const password = useFormInput('');

    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleRegister = () => {
        setError(null);
        setLoading(true);
        axios
            .post('http://localhost:5000/api/users/registerGuest',
                {
                    firstName: firstName.value,
                    lastName: lastName.value,
                    email: email.value,
                    username: username.value,
                    password: password.value
                })
            .then(response => {
                setLoading(false);
                window.location.href='/welcome';
            })
            .catch(error => {
                setLoading(false);
                setError("Something went wrong. Please try again later.");
            });
    }

    return (
        <div class="container align-middle">
            <div class="row justify-content-center align-items-center">
                <h1>Create Guest Account</h1>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class = "col-2">
                    First name<br />
                    <input type="text" class="form-control mb-2" {...firstName} />
                </div>
                <div class = "col-2">
                    Last name<br />
                    <input type="text" class="form-control mb-2" {...lastName} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Email<br />
                    <input type="text" class="form-control mb-2" {...email} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class = "col-4">
                    Username<br />
                    <input type="text" class="form-control mb-2" {...username} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Password<br />
                    <input type="password" class="form-control mb-4" {...password} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                {error && <><small style={{ color: 'red' }}>{error}</small><br /></>}<br />
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    <button type="button" class="btn btn-primary mr-1" onClick={handleRegister} disabled={loading} >{loading ? 'Loading...' : 'Register'}</button>
                </div>
            </div>
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

export default GuestRegister;