import React from 'react';
import { getToken } from './utils/Common';
import DeleteHostModal from './DeleteHostModal';

class EditHost extends React.Component {
    state = {
        host: [],
        token: getToken(),
        phoneNo: '',
        bd: '',
        photoLoc: '',
    }

    componentDidMount() {
        var queryString = this.props.location.search;
        let params = new URLSearchParams(queryString);
        let id = params.get("id");
        
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/hosts/' + id, requestOptions)
        .then(res => res.json())
        .then((data) => {
            var date = data.dateOfBirth.substring(0, 10)
            this.setState({ host: data, phoneNo: data.telephoneNumber, bd: date, photoLoc: data.profilePictureLocation });
        })
        .catch(console.log)
    }

    handlePhoneChange(event) {
        this.setState({phoneNo: event.target.value})
    }

    handleBirthdayChange(event) {
        this.setState({bd: event.target.value})
    }

    handleLocationChange(event) {
        this.setState({photoLoc: event.target.value})
    }

    updateData() {
        var dob = document.getElementById("dob").value;
        var phone = document.getElementById("phone").value;
        var picLoc = document.getElementById("picLoc").value;

        const requestOptions = {
            method: 'PUT',
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
        
        fetch('http://localhost:5000/api/Hosts/' + this.state.host.id, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }))
            .catch(err => console.log(err));
    }

    render() {
        return(
        <div class="container">
            <h1>Edit</h1>
            <h4>Host</h4>
            <div class="row">
                <div class="col-md-4">
                    <form onSubmit={ this.updateData.bind(this) } action='/hosts' >
                        <div class="form-group">
                            <label>Date of birth</label>
                            <input class="form-control" type="date" id="dob" value={this.state.bd} onChange={this.handleBirthdayChange.bind(this)} />
                        </div>
                        <div class="form-group">
                            <label>Telephone number</label>
                            <input class="form-control" type="tel" id="phone" value={this.state.phoneNo} onChange={this.handlePhoneChange.bind(this)} />
                        </div>
                        <div class="form-group">
                            <label>Profile picture location</label>
                            <input class="form-control" id="picLoc" value={this.state.photoLoc} onChange={this.handleLocationChange.bind(this)} />
                        </div>
                        <div class="form-group">
                            <input type="submit" value="Update" class="btn btn-primary mr-1 mt-2" />
                            <DeleteHostModal hostID={ this.state.host.id }/>
                        </div>
                    </form>
                </div>
            </div>
        </div>
        )
    }
}

export default EditHost;