import React from 'react';

import { getToken } from '../utils/Common';

class CreateHost extends React.Component {
    state = {
        token: getToken()
    }

    sendData = () => {
        var dob = document.getElementById("dob").value;
        var phone = document.getElementById("phone").value;
        var picLoc = document.getElementById("picLoc").value;

        const requestOptions = {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + this.state.token
            },
            body: JSON.stringify({
                "dateOfBirth": String(dob) + "T00:00:00",
                "telephoneNumber": phone,
                "profilePictureLocation": picLoc
            })
        };
        
        fetch('http://localhost:5000/api/Hosts', requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }));
    }

    render() {
        return (
            <div class="container">
                <h1>Create</h1>
                <h4>Host</h4>
                <div class="row">
                    <div class="col-md-4">
                        <form onSubmit={this.sendData} action='/hosts' >
                            <div class="form-group">
                                <label>Date of birth</label>
                                <input class="form-control" type="date" id="dob" />
                            </div>
                            <div class="form-group">
                                <label>Telephone number</label>
                                <input class="form-control" type="tel" id="phone" />
                            </div>
                            <div class="form-group">
                                <label>Profile picture location</label>
                                <input class="form-control" id="picLoc" />
                            </div>
                            <div class="form-group">
                                <input type="submit" value="Create" class="btn btn-primary" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        );
    }
}

export default CreateHost;