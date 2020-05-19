import React from 'react';

import { getToken } from '../../utils/Common';
import DeleteLocationModal from './DeleteLocationModal';

class DetailsLocation extends React.Component {
    state = {
        location: [],
        token: getToken()
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
        })
        .catch(console.log)
    }

    render() {
        return(
            <div class="container">
                <h1>Location details</h1><br/>
                <p class="card-text"><b>Maximum number of guests:</b> {this.state.location.maxNoGuests}</p>
                <p class="card-text"><b>Available days:</b> {this.state.location.days && this.state.location.days.includes("FRI") ? "Friday " : ""}{this.state.location.days && this.state.location.days.includes("SAT") ? "Saturday " : ""}{this.state.location.days && this.state.location.days.includes("SUN") ? "Sunday" : ""}</p>
                <p class="card-text"><b>Address:</b> {this.state.location.physicalAddress}</p>
                <p class="card-text"><b>Description:</b> {this.state.location.description}</p>

                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>window.location.href = "/hosts/locationEdit?id=" + this.state.location.id}>Edit</button>
                <DeleteLocationModal locationID={ this.state.location.id }/>
            </div>
        )
    }
}

export default DetailsLocation;