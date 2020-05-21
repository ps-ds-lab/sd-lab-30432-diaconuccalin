import React, { Component } from 'react';

import { getToken } from '../utils/Common';
import DeleteGuestModal from './DeleteGuestModal';

const isGuest = (user) => user.role === "Guest";

class Guests extends Component {
    state = {
        users: [],
        token: getToken()
    }

    componentDidMount() {
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/users', requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ users: data })
        })
        .catch(console.log)
    }

    render() {
        return(
            <div class="container">
                <div class="row">
                    <div class="col">
                        <h1>Guests</h1>
                    </div>
                </div>
                <br></br>
                {this.state.users.filter(isGuest).map((guest) => (
                    <div class = "card mb-4">
                        <div class = "card-body">
                            <h5 class="card-title">{guest.firstName} {guest.lastName}</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Username: {guest.username}</h6>
                            <h6 class="card-subtitle mb-2 text-dark">Email: {guest.email}</h6>
                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/guests/detail?id=" + guest.id} >Details</button>
                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/guests/edit?id=" + guest.id}>Edit</button>
                            <DeleteGuestModal guestID={ guest.id }/>
                        </div>
                    </div>
                ))}
                <br></br>
            </div>
        );
    }
}

export default Guests;