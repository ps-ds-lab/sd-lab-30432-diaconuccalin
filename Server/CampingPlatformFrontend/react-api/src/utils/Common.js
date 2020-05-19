export const getUser = () => {
    const userStr = sessionStorage.getItem('user');
    if(userStr) { return JSON.parse(userStr);}
    else return null;
}

export const getToken = () => {
    return sessionStorage.getItem('token') || null;
}

export const getUserType = () => {
    return sessionStorage.getItem('userType');
}

export const getId = () => {
    return sessionStorage.getItem('id');
}

export const removeUserSession = () => {
    sessionStorage.removeItem('token');
    sessionStorage.removeItem('user');
    sessionStorage.removeItem('userType');
    sessionStorage.removeItem('id');
}

export const setUserSession = (token, user, userType, id) => {
    sessionStorage.setItem('token', token);
    sessionStorage.setItem('user', JSON.stringify(user));
    sessionStorage.setItem('userType', userType);
    sessionStorage.setItem('id', id);
    window.location.reload();
}