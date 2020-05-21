import React, { Component } from 'react';

import { getToken } from '../utils/Common';
import DeleteHostModal from './DeleteHostModal';

const isHost = (user) => user.role === "Host";

class Hosts extends Component {
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

    //<button type="button" class="btn btn-primary mr-4 mt-2" onClick={()=>window.location.href = "/locations?id=" + host.id} >Locations</button>
    
    render() {
        return(
            <div class="container">
                <div class="row">
                    <div class="col">
                        <h1>Hosts</h1>
                    </div>
                </div>
                <br></br>
                {this.state.users.filter(isHost).map((host) => (
                    <div class = "card mb-4">
                        <div class = "card-body">
                            <h5 class="card-title">{host.firstName} {host.lastName}</h5>
                            <h6 class="card-subtitle mb-2 text-muted">Username: {host.username}</h6>
                            <h6 class="card-subtitle mb-2 text-dark">Email: {host.email}</h6>

                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/detail?id=" + host.id} >Details</button>
                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/edit?id=" + host.id}>Edit</button>
                            <DeleteHostModal hostID={ host.id }/>
                        </div>
                    </div>
                ))}
                <br></br>
            </div>
        );
    }
}

export default Hosts;