import React, { useState } from 'react';
import axios from 'axios';

import { setUserSession } from '../utils/Common'

function Login(props) {
    const username = useFormInput('');
    const password = useFormInput('');
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleLogin = () => {
        setError(null);
        setLoading(true);
        axios
            .post('http://localhost:5000/api/users/authenticate',
                {username: username.value,
                password: password.value })
            .then(response => {
                setLoading(false);
                setUserSession(response.data.token, response.data);
            })
            .catch(error => {
                setLoading(false);
                setError("Something went wrong. Please try again later.");
            });
    }

    return (
        <div class="container">
            <h1>Login</h1>
            <div class="row">
                <div class = "col-2">
                    Username<br />
                    <input type="text" class="form-control mb-2" {...username} autoComplete="new-password" />
                </div>
            </div>
            <div class="row">
                <div class="col-2">
                    Password<br />
                    <input type="password" class="form-control" {...password} autoComplete="new-password" />
                </div>
            </div>
            {error && <><small style={{ color: 'red' }}>{error}</small><br /></>}<br />
            <button type="button" class="btn btn-primary mr-1" onClick={handleLogin} disabled={loading} >{loading ? 'Loading...' : 'Login'}</button>
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

export default Login;