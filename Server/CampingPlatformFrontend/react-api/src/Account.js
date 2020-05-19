import React from 'react';

import { getUser, getToken } from './utils/Common';
import DeleteHostModal from './host/DeleteHostModal';

class Account extends React.Component {
    state = {
        user: getUser(),
        host: [],
        token: getToken()
    }

    componentDidMount() {
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/hosts/' + this.state.user.correspondingID, requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ host: data });
        })
        .catch(console.log)
    }

    render() {
        return(
            <div class="container">
                <h1>Details</h1>
                <div class = "card">
                    <div class = "card-body">
                        <h5 class="card-title">{this.state.user.firstname} {this.state.user.lastname}</h5>
                        <h6 class="card-subtitle mb-2 text-muted">Username: {this.state.user.username}</h6>
                        <div class="card-text">Email: {this.state.user.email}</div><br/>
                        <div class="card-text">Phone number: {this.state.host.telephoneNumber}</div><br/>
                        <div class="card-text">Date of birth: {this.state.host.dateOfBirth}</div><br/>
                    </div>
                </div>
                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={ ()=>window.location.href = "/editAccount?id=" + this.state.user.id } >Edit</button>
                <DeleteHostModal hostID={ this.state.user.id }/>
            </div>
        )
    }
}

export default Account;