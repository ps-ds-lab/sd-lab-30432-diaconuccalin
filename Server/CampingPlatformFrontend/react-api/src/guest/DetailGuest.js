import React from 'react';

import { getToken } from '../utils/Common';
import DeleteGuestModal from './DeleteGuestModal';

class DetailGuest extends React.Component {
    state = {
        user: [],
        guest: [],
        token: getToken()
    }

    componentDidMount() {
        var queryString = this.props.location.search;
        let params = new URLSearchParams(queryString);
        let id = params.get("id");
        
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/users/' + id, requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ user: data });
            
            fetch('http://localhost:5000/api/guests/' + this.state.user.correspondingID, requestOptions)
            .then(res => res.json())
            .then((data) => {
                this.setState({ guest: data });
            })
            .catch(console.log)
        })
        .catch(console.log)
    }

    render() {
        return(
            <div class="container">
                <h1>Details</h1>
                <div class = "card">
                    <div class = "card-body">
                        <h5 class="card-title">{this.state.user.firstName} {this.state.user.lastName}</h5>
                        <h6 class="card-subtitle mb-2 text-muted">Username: {this.state.user.username}</h6>
                        <div class="card-text">Email: {this.state.user.email}</div>
                        <div class="card-text">Phone number: {this.state.guest.telephoneNumber}</div>
                        <div class="card-text">Date of birth: {this.state.guest.dateOfBirth}</div>
                    </div>
                </div>
                
                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={ ()=>window.location.href = "/guests/edit?id=" + this.state.user.id } >Edit</button>
                <DeleteGuestModal guestID={ this.state.user.id }/>
            </div>
        )
    }
}

export default DetailGuest;