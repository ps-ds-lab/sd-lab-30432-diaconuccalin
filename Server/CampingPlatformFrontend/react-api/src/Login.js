import React, { useState } from 'react';
import axios from 'axios';
import { setUserSession } from './utils/Common'

function Login(props) {
    const username = useFormInput('');
    const password = useFormInput('');
    const [error, setError] = useState(null);
    const [loading, setLoading] = useState(false);

    const handleLogin = () => {
        setError(null);
        setLoading(true);
        axios.post('http://localhost:5000/api/users/authenticate', {username: username.value, password: password.value }).then(response => {
            setLoading(false);
            console.log(response);
            console.log(response.data);
            setUserSession(response.data.token, response.data);
            window.location.reload();
            props.history.goBack();
        }).catch(error => {
            setLoading(false);
            setError("Something went wrong. Please try again later.");
        });
    }

    return (
        <div class="container">
            Login<br /><br />
            <div>
                Username<br />
                <input type="text" {...username} autoComplete="new-password" />
            </div>
            <div style={{ marginTop: 10 }}>
                Password<br />
                <input type="password" {...password} autoComplete="new-password" />
            </div>
            {error && <><small style={{ color: 'red' }}>{error}</small><br /></>}<br />
            <input type="button" value={loading ? 'Loading...' : 'Login'} onClick={handleLogin} disabled={loading} /><br />
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