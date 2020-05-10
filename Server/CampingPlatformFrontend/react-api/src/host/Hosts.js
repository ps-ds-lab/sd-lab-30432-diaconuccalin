import React, { Component } from 'react';

import { getToken } from '../utils/Common';
import DeleteHostModal from './DeleteHostModal';

class Hosts extends Component {
    state = {
        hosts: [],
        token: getToken()
    }

    componentDidMount() {
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/hosts', requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ hosts: data })
        })
        .catch(console.log)
    }

    loadDetails(id) {
        window.location.href = "/hosts/detail?id=" + id;
    }

    render() {
        return(
            <div class="container">
                <div class="row">
                    <div class="col">
                        <h1>Hosts</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <a href="/hosts/create">Create new</a>
                    </div>
                </div>
                <br></br>
                {this.state.hosts.map((host) => (
                    <div class = "card mb-4">
                        <div class = "card-body">
                            <h5 class="card-title">{host.id}</h5>
                            <h6 class="card-subtitle mb-2 text-muted">{host.dateOfBirth}</h6>
                            <p class="card-text">{host.telephoneNumber}</p>
                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>this.loadDetails(host.id)} >Details</button>
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