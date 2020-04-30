import React, { Component } from 'react';

class Hosts extends Component {
    state = {
        hosts: []
    }

    componentDidMount() {
        fetch('http://localhost:5000/api/hosts')
        .then(res => res.json())
        .then((data) => {
            this.setState({ hosts: data })
        })
        .catch(console.log)
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
                        <a href="\createHost">Create new</a>
                    </div>
                </div>
                <br></br>
                {this.state.hosts.map((host) => (
                    <div class = "card">
                        <div class = "card-body">
                            <h5 class="card-title">{host.id}</h5>
                            <h6 class="card-subtitle mb-2 text-muted">{host.dateOfBirth}</h6>
                            <p class="card-text">{host.telephoneNumber}</p>
                            <a href="\">Details</a> <a href="\">Edit</a> <a href="\">Delete</a>
                        </div>
                    </div>
                ))}
            </div>
        );
    }
}

export default Hosts;