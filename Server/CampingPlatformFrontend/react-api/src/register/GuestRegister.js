import React, { useState } from 'react';
import axios from 'axios';

function GuestRegister() {
    const username = useFormInput('');
    const password = useFormInput('');
    const firstName = useFormInput('');
    const lastName = useFormInput('');
    const email = useFormInput('');
    const phone = useFormInput('');
    const dob = useFormInput('');
    const profilePic = useFormInput('');
    const description = useFormInput('');

    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleRegister = () => {
        setError(null);
        setLoading(true);

        axios
            .post('http://localhost:5000/api/Guests',
                {
                    dateOfBirth: dob.value + "T00:00:00",
                    telephoneNumber: phone.value,
                    profilePictureLocation: profilePic.value,
                    description: description.value
                })
            .then(response => {
                const cId = response.data.id;

                axios
                    .post('http://localhost:5000/api/users/registerGuest',
                    {
                        firstName: firstName.value,
                        lastName: lastName.value,
                        email: email.value,
                        username: username.value,
                        password: password.value,
                        correspondingID: cId
                    })
                    .then(response => {
                        setLoading(false);
                        window.location.href='/';
                    })
                    .catch(error => {
                        setLoading(false);
                        setError("Something went wrong. Please try again later.");
                    });
            })
            .catch(error => {
                setLoading(false);
                setError("Something went wrong. Please try again later.");
            });
    }

    return (
        <div class="container align-middle">
            <div class="row justify-content-center align-items-center mb-4">
                <h1>Create Guest Account</h1>
            </div>
            <div class="row justify-content-center align-items-center mb-2">
                <div class = "col-4">
                    Username<br />
                    <input type="text" class="form-control" {...username} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Password<br />
                    <input type="password" class="form-control mb-4" {...password} />
                </div>
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
                <div class="col-4">
                    Telephone number<br />
                    <input type="text" class="form-control mb-2" {...phone} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Date of birth<br />
                    <input type="date" class="form-control mb-4" {...dob} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Profile picture<br />
                    <input type="file" class="form-control-file mb-2" {...profilePic} />
                </div>
            </div>
            <div class="row justify-content-center align-items-center">
                <div class="col-4">
                    Tell us about yourself<br />
                    <textarea class="form-control mb-2" rows="5" style={{resize: "none"}} {...description}/>
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