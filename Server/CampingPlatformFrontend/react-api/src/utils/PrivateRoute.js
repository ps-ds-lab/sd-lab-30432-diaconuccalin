import React from 'react';
import { Route, Redirect, useHistory } from 'react-router-dom';

import { getToken } from '../utils/Common';

function PrivateRoute({ component: Component, path: Path, ...rest }) {
    const history = useHistory();
    const token = getToken();
    
    const storeToReload = () => {
        history.push(Path);
    }

    if(!token) storeToReload();

    return (
        <Route
            {...rest}
            render={(props) => token ? <Component {...props} /> : <Redirect to={{ pathname: '/login', state: { from: props.location } }} />}
        />
    );
}

export default PrivateRoute;