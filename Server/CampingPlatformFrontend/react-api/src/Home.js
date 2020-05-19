import React from 'react';

import { getUser, getToken } from './utils/Common';
import DeleteLocationModal from './host/location/DeleteLocationModal'

class Welcome extends React.Component {
    state = {
        user : getUser(),
        locations : null
    }

    componentDidMount() {
        if(this.state.user.role === "Host") {
            const requestOptions = {
                method: 'GET',
                headers: {
                    'Content-Type': 'application/json',
                    'Authorization': 'Bearer ' + getToken()
                }
            };

            fetch('http://localhost:5000/api/locations/getByHost/' + this.state.user.id, requestOptions)
            .then(res => res.json())
            .then((data) => {
                this.setState({ locations : data });
            })
            .catch(console.log);
        }
    }

    render() {
    if(this.state.locations === null || this.state.locations.length === 0) {
        return (
            <div class="container align-middle">
                <main role="main" class="pb-3">
                    <div class="text-center">
                        <h1 class="display-4">Welcome</h1>
                    </div>
                    <div class="text-center mt-4 mb-4">
                        It looks like you don't have a location registered yet. <br/>
                        Would you like to register a new location now?
                    </div>
                    <div class="text-center">
                        <a href="/newLocation"><button class="btn btn-primary">Create new location</button></a>
                    </div>
                </main>
            </div>
        );
    } else {
        return (
            <div class="container">
                <div class="row">
                    <div class="col">
                        <h1>Your Locations</h1>
                    </div>
                </div>
                <div class="row">
                    <div class="col">
                        <a href="/newLocation">Create new</a>
                    </div>
                </div>
                <br></br>
                {this.state.locations.map((location) => (
                    <div class = "card mb-4">
                        <div class = "card-body">
                            <p class="card-text"><b>Maximum number of guests:</b> {location.maxNoGuests}</p>
                            <p class="card-text"><b>Available days:</b> {location.days && location.days.includes("FRI") ? "Friday " : ""}{location.days && location.days.includes("SAT") ? "Saturday " : ""}{location.days && location.days.includes("SUN") ? "Sunday" : ""}</p>
                            <p class="card-text"><b>Address:</b> {location.physicalAddress}</p>
                            <p class="card-text"><b>Description:</b> {location.description}</p>

                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/locationDetail?id=" + location.id} >Details</button>
                            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/locationEdit?id=" + location.id}>Edit</button>
                            <DeleteLocationModal locationID={ location.id }/>
                        </div>
                    </div>
                ))}
                <br></br>
            </div>
        )
    }
    }
}

export default Welcome;