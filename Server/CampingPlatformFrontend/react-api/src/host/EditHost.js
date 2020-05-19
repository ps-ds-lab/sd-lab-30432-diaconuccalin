import React from 'react';

import { getToken, setUserSession, removeUserSession, getUser } from '../utils/Common';

class EditHost extends React.Component {
    state = {
        host: [],
        user: [],
        token: getToken(),
        phoneNo: '',
        bd: '',
        firstName: '',
        lastName: '',
        username: '',
        email: ''
    }

    componentDidMount() {
        var queryString = this.props.location.search;
        let params = new URLSearchParams(queryString);
        let id = params.get("id");
        
        const requestOptions = {
            headers: { 'Authorization': 'Bearer ' + this.state.token }
        };

        fetch('http://localhost:5000/api/users/' + id, requestOptions)
        .then(res => res.json())
        .then((data) => {
            this.setState({ user: data, email: data.email, firstName: data.firstName, lastName: data.lastName, username: data.username })
            
            fetch('http://localhost:5000/api/hosts/' + data.correspondingID, requestOptions)
            .then(res => res.json())
            .then((data) => {
                var date = data.dateOfBirth.substring(0, 10);
                this.setState({ host: data, phoneNo: data.telephoneNumber, bd: date, photoLoc: data.profilePictureLocation });
            })
            .catch(console.log)
        })
        .catch(console.log)
    }

    handlePhoneChange(event) { this.setState({phoneNo: event.target.value}); }
    handleBirthdayChange(event) { this.setState({bd: event.target.value}) }
    handleLocationChange(event) { this.setState({photoLoc: event.target.value}) }
    handleFirstNameChange(event) { this.setState({firstName: event.target.value}) }
    handleLastNameChange(event) { this.setState({lastName: event.target.value}) }
    handleEmailChange(event) { this.setState({email: event.target.value}) }
    handleUsernameChange(event) { this.setState({username: event.target.value}) }

    updateData() {
        var fn = document.getElementById("firstName").value;
        var ln = document.getElementById("lastName").value;
        var un = document.getElementById("username").value;
        var em = document.getElementById("email").value;
        var tn = document.getElementById("phone").value;
        var db = document.getElementById("dob").value;

        var user = getUser();
        user.email = em;
        user.firstname = fn;
        user.lastname = ln;
        user.username = un;
        removeUserSession();
        setUserSession(user.token, user, user.role, user.id);
        
        const requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + getToken()
            },
            body: JSON.stringify({
                dateOfBirth: db + "T00:00:00",
                telephoneNumber: tn,
                profilePictureLocation: ""
            })
        };

        fetch('http://localhost:5000/api/Hosts/' + this.state.host.id, requestOptions)
            .then(response => response.json())
            .then(data => this.setState({ postId: data.id }))
            .catch(err => console.log(err));
        
        
        const requestOptions2 = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + getToken()
            },
            body: JSON.stringify({
                email: em,
                firstName: fn,
                lastName: ln,
                username: un
            })
        };
        
        fetch('http://localhost:5000/api/Users/' + this.state.user.id, requestOptions2)
            .then(response => response.json())
            .then(data => {
                this.setState({ postId: data.id });
            })
            .catch(err => console.log(err));
    }

    render() {
        return(
        <div class="container">
            <form onSubmit={ this.updateData.bind(this) } action="/account"  >
            <div class="container align-middle">
                <div class="row justify-content-center align-items-center mb-2">
                    <h1>Edit Host Account</h1>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class = "col-2">
                        First name<br />
                        <input type="text" class="form-control mb-2" id="firstName" value={this.state.firstName} onChange={this.handleFirstNameChange.bind(this)} />
                    </div>
                    <div class = "col-2">
                        Last name<br />
                        <input type="text" class="form-control mb-2" id="lastName" value={this.state.lastName} onChange={this.handleLastNameChange.bind(this)} />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center mb-2">
                    <div class = "col-4">
                        Username<br />
                        <input type="text" class="form-control" id="username" value={this.state.username} onChange={this.handleUsernameChange.bind(this)} />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Email<br />
                        <input type="text" class="form-control mb-2" id="email" value={this.state.email} onChange={this.handleEmailChange.bind(this)} />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Telephone number<br />
                        <input type="text" class="form-control mb-2" id="phone" value={this.state.phoneNo} onChange={this.handlePhoneChange.bind(this)} />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        Date of birth<br />
                        <input type="date" class="form-control mb-2" id="dob" value={this.state.bd} onChange={this.handleBirthdayChange.bind(this)} />
                    </div>
                </div>
                <div class="row justify-content-center align-items-center">
                    <div class="col-4">
                        <input type="submit" value="Update" class="btn btn-primary mr-1 mt-2" />
                    </div>
                </div>
            </div>
            </form>
        </div>
        )
    }
}

export default EditHost;