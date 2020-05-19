import React from 'react';

import { getToken, getUser } from '../../utils/Common';
import DeleteLocationModal from './DeleteLocationModal';

class EditLocation extends React.Component {
    state = {
        location: [],
        token: getToken(),
        maxNo: '',
        days: '',
        address: '',
        description: '',
        friday: false,
        saturday: false,
        sunday: false
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
            this.setState({ location: data, maxNo: data.maxNoGuests, days: data.days, address: data.physicalAddress, description: data.description });

            if(this.state.days != null) {
                if(this.state.days.includes("FRI")) {
                    this.setState({friday: true});
                }
                if(this.state.days.includes("SAT")) {
                    this.setState({saturday: true});
                }
                if(this.state.days.includes("SUN")) {
                    this.setState({sunday: true});
                }
            }
        })
        .catch(console.log)
    }

    handleMaxNoChange(event) { this.setState({maxNo: event.target.value}) }
    handleAddressChange(event) { this.setState({address: event.target.value}) }
    handleDescriptionChange(event) { this.setState({description: event.target.value}) }
    handleFridayChange(event) { this.setState({friday: event.target.checked}) }
    handleSaturdayChange(event) { this.setState({saturday: event.target.checked}) }
    handleSundayChange(event) { this.setState({sunday: event.target.checked}) }

    updateData() {
        var maxNo = document.getElementById("maxNo").value;
        var address = document.getElementById("address").value;
        var description = document.getElementById("description").value;

        var days = '';
        if(document.getElementById("friday").checked) {
            days = days.concat('FRI ');
        }
        if(document.getElementById("saturday").checked) {
            days = days.concat("SAT ");
        }
        if(document.getElementById("sunday").checked) {
            days = days.concat("SUN");
        }

        const requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.state.token
            },
            body: JSON.stringify({
                hostId: getUser().id,
                maxNoGuests: parseInt(maxNo),
                physicalAddress: address,
                description: description,
                days: days
            })
        };
        
        fetch('http://localhost:5000/api/Locations/' + this.state.location.id, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }))
            .catch(err => console.log(err));
    }

    render() {
        return(
        <div class="container">
            <form onSubmit={ this.updateData.bind(this) } action='/' >
                <div class="row justify-content-center align-items-center mb-2">
                    <div class = "col-4">
                        <h1>Edit Location</h1>
                    </div>
                </div>
                <div class="row justify-content-center align-items-center mb-2">
                    <div class = "col-4">
                        Maximum number of guests<br />
                        <input type="number" class="form-control" id="maxNo" value={this.state.maxNo} onChange={this.handleMaxNoChange.bind(this)}/>
                    </div>
                </div>
                <div class="row justify-content-center align-items-center mb-2">
                    <div class = "col-4">
                        Available days<br />
                        <div class="form-check form-check-inline">
                            <input id="friday" name="friday" type="checkbox" checked={this.state.friday} onChange={this.handleFridayChange.bind(this)}/>
                            <label class="form-check-label" for="friday">Friday</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input id="saturday" name="saturday" type="checkbox" checked={this.state.saturday} onChange={this.handleSaturdayChange.bind(this)}/>
                            <label class="form-check-label" for="saturday">Saturday</label>
                        </div>
                        <div class="form-check form-check-inline">
                            <input id="sunday" name="sunday" type="checkbox" checked={this.state.sunday} onChange={this.handleSundayChange.bind(this)}/>
                            <label class="form-check-label" for="sunday">Sunday</label>
                        </div>
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Physical address<br />
                        <textarea class="form-control mb-2" style={{resize: "none"}} id="address" value={this.state.address} onChange={this.handleAddressChange.bind(this)}/>
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Location description<br />
                        <textarea class="form-control mb-2" rows="5" style={{resize: "none"}} id="description" value={this.state.description} onChange={this.handleDescriptionChange.bind(this)}/>
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Location pictures<br />
                        <input type="file" class="form-control-file mb-2" />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        <input type="submit" value="Update" class="btn btn-primary mr-1 mt-2" />
                        <DeleteLocationModal locationID={ this.state.location.id }/>
                    </div>
                </div>
            </form>            
        </div>
        )
    }
}

export default EditLocation;