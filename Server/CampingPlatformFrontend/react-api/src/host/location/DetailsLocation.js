import React from 'react';

import { getToken, getUser } from '../../utils/Common';
import DeleteLocationModal from './DeleteLocationModal';
import InquireLocationModal from '../../guest/InquireLocationModal'
import DetailsGuestModal from '../../guest/DetailsGuestModal'

const isAccepted = (guestRequest) => guestRequest.accepted === true;

class DetailsLocation extends React.Component {
    state = {
        location: [],
        guestRequests: [],
        token: getToken(),
        found: false
    }

    componentDidMount() {
        var queryString = this.props.location.search;
        let params = new URLSearchParams(queryString);
        let id = params.get("id");
        
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/locations/' + id, requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ location: data });

            fetch('http://localhost:5000/api/guestRequests/getByLocation/' + this.state.location.id, requestOptions)
            .then(res => res.json())
            .then((data) => {
                data.forEach(element => {
                    fetch('http://localhost:5000/api/users/' + element.guestId, requestOptions)
                    .then(res => res.json())
                    .then((data2) => {
                        element.firstName = data2.firstName;
                        element.lastName = data2.lastName;
                        element.user = data2;

                        fetch('http://localhost:5000/api/guests/' + data2.correspondingID, requestOptions)
                        .then(res => res.json())
                        .then((data3) => {
                            element.guest = data3;
                            this.setState({ guestRequests : data });
                        })
                    })
                    .catch(console.log);
                    
                    if(getUser().role === "Guest" && element.guestId === getUser().id) {
                        this.setState({ found: true });
                    }
                });
            })
            .catch(console.log);
        })
        .catch(console.log)
    }

    render() {
        if(getUser().role === "Host") {
            return(
                <div class="container">
                    <h1>Location details</h1><br/>
                    <p class="card-text"><b>Maximum number of guests:</b> {this.state.location.maxNoGuests}</p>
                    <p class="card-text"><b>Available days:</b> {this.state.location.days && this.state.location.days.includes("FRI") ? "Friday " : ""}{this.state.location.days && this.state.location.days.includes("SAT") ? "Saturday " : ""}{this.state.location.days && this.state.location.days.includes("SUN") ? "Sunday" : ""}</p>
                    <p class="card-text"><b>Address:</b> {this.state.location.physicalAddress}</p>
                    <p class="card-text"><b>Description:</b> {this.state.location.description}</p>
    
                    <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/locationEdit?id=" + this.state.location.id}>Edit</button>
                    <DeleteLocationModal locationID={ this.state.location.id }/>

                    <br/><br/><br/>
                    <p class="card-text"><b>Requests for this location:</b></p>
                    {this.state.guestRequests.map((element) => (
                        <p class="card-text">
                            <DetailsGuestModal guestRequestId={element.id} user={element.user} guest={element.guest} accepted={element.accepted}/>
                            {element.firstName} {element.lastName}
                        </p>
                    ))}
                </div>
            )
        } else if(getUser().role === "Guest") {
            return(
                <div class="container">
                    <h1>Location details</h1><br/>
                    <p class="card-text"><b>Maximum number of guests:</b> {this.state.location.maxNoGuests}</p>
                    <p class="card-text"><b>Available days:</b> {this.state.location.days && this.state.location.days.includes("FRI") ? "Friday " : ""}{this.state.location.days && this.state.location.days.includes("SAT") ? "Saturday " : ""}{this.state.location.days && this.state.location.days.includes("SUN") ? "Sunday" : ""}</p>
                    <p class="card-text"><b>Address:</b> {this.state.location.physicalAddress}</p>
                    <p class="card-text"><b>Description:</b> {this.state.location.description}</p>
                    
                    <InquireLocationModal locationID={ this.state.location.id } disabled={ this.state.found ? "true" : "false" }/>
                    
                    <br/><br/><br/>
                    <p class="card-text"><b>Attending guests:</b></p>
                    {this.state.guestRequests.filter(isAccepted).map((element) => (
                        <p class="card-text">{element.firstName} {element.lastName}</p>
                    ))}
                </div>
            )
        }
    }
}

export default DetailsLocation;