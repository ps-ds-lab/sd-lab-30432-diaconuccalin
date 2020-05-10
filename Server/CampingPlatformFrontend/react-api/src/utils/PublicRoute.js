import React from 'react';
import { Route, Redirect } from 'react-router-dom';

import { getToken } from '../utils/Common';

function PublicRoute({ component: Component, ...rest }) {
    return (
        <Route
            {...rest}
            render={(props) => !getToken() ? <Component {...props} /> : <Redirect to={{ pathname: props.history.goBack() }} />}
        />
    )
}

export default PublicRoute;