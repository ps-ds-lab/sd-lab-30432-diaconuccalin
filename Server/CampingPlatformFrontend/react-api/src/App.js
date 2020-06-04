import React, { Component } from 'react';
import { BrowserRouter, Switch } from 'react-router-dom';
import Modal from 'react-bootstrap/Modal';
import * as signalR from '@microsoft/signalr';

import Welcome from './Welcome';
import Login from './login/Login';
import PrivateRoute from './utils/PrivateRoute';
import PublicRoute from './utils/PublicRoute';
import { getUser, removeUserSession } from './utils/Common';
import Guests from './guest/Guests';
import Hosts from './host/Hosts';
import CreateHost from './host/CreateHost';
import DetailsHost from './host/DetailsHost';
import EditHost from './host/EditHost';
import CreateLocation from './host/CreateLocation';
import Home from './Home';
import HostRegister from './register/HostRegister';
import GuestRegister from './register/GuestRegister';
import DetailsLocation from './host/location/DetailsLocation';
import EditLocation from './host/location/EditLocation';
import EditGuest from './guest/EditGuest';
import EditAdmin from './EditAdmin';
import Account from './Account';
import DetailsGuest from './guest/DetailGuest.js';
import Locations from './host/location/Locations';

class App extends Component {
  state = {
    user : getUser(),
    show : false,
    locationId : null
  }

  componentDidMount() {
    var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/notifications",
    {
      skipNegotiation: true,
      transport: signalR.HttpTransportType.WebSockets
    }).build();

    const eu = this;

    connection.on("ReceiveNotification", function (message) {
      if(getUser().role === "Host") {
        const jsonMessage = JSON.parse(message);

        if(jsonMessage.hostId === getUser().id) {
          eu.handleShow(jsonMessage.locationId);
        }
      }
    });
  
    connection.start()
    .catch(function (err) {
      return console.error(err.toString());
    });
  }
  
  handleClose() {
    this.setState({ show : false });
  }

  handleShow(locationId) {
    this.setState( {locationId: locationId });
    this.setState( { show : true });
  }

  handleRedirect() {
    window.location.href = "hosts/locationDetail?id=" + this.state.locationId;
  }

  render(){
  return (
    <div className="App">
      <BrowserRouter>
        <div>
          
          <header>
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
              <div class="container">
                <a class="navbar-brand" href={this.state.user ? "/" : "/welcome"}>Camping Platform</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                  <ul class="navbar-nav">
                      <li class="nav-item">
                        <div class="nav-link text-dark">{this.state.user ? "Hello, " : ""}<a class="text-dark" href={this.state.user ? "/account" : ""}>{this.state.user ? this.state.user.firstname : ""}</a>{this.state.user ? "!" : ""}</div>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link text-dark" onClick={removeUserSession} href={this.state.user ? "/welcome" : "/login"}>{this.state.user ? 'Logout' : 'Login'}</a>
                      </li>
                  </ul>
                </div>
              </div>
            </nav>
          </header>

          <Modal show={this.state.show} onHide={this.handleClose.bind(this)} id="notificationModal">
            <Modal.Header closeButton>
                <Modal.Title>Request notification</Modal.Title>
            </Modal.Header>
            <Modal.Body>You have a new request for one of your locations! 
            </Modal.Body>
            <Modal.Footer>
                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={this.handleRedirect.bind(this)} >Check request</button>
                <button type="button" class="btn btn-secondary mr-1 mt-2" onClick={this.handleClose.bind(this)} >Dismiss</button>
            </Modal.Footer>
          </Modal>

          <Switch>
            <PublicRoute path="/welcome" component={Welcome} />
            <PublicRoute path="/login" component={Login} />
            <PublicRoute path="/hostRegister" component={HostRegister} />
            <PublicRoute path="/guestRegister" component={GuestRegister} />

            <PrivateRoute path="/editAccount" component={this.state.user ? this.state.user.role==="Host" ? EditHost : this.state.user.role==="Guest" ? EditGuest : EditAdmin : Welcome} />
            <PrivateRoute path="/account" component={Account} />
            <PrivateRoute path="/newLocation" component={CreateLocation} />
            <PrivateRoute exact path="/" component={Home} />
            <PrivateRoute path="/guests/detail" component={DetailsGuest} />
            <PrivateRoute path="/guests/edit" component={EditGuest} />
            <PrivateRoute path="/guests" component={Guests} />
            <PrivateRoute path="/locationDetail" component={DetailsLocation} />
            <PrivateRoute path="/hosts/locationDetail" component={DetailsLocation} />
            <PrivateRoute path="/hosts/locationEdit" component={EditLocation} />
            <PrivateRoute path="/hosts/detail" component={DetailsHost} />
            <PrivateRoute path="/hosts/create" component={CreateHost} />
            <PrivateRoute path="/hosts/edit" component={EditHost} />
            <PrivateRoute path="/hosts" component={Hosts} />
            <PrivateRoute path="/locations" component={Locations} />
            <PrivateRoute path="/guestDetails" component={DetailsGuest} />
          </Switch>
          
          <footer class="border-top footer text-muted">
            <div class="container">
              © 2020 - CampingPlatform
            </div>
          
          </footer>
        </div>
      </BrowserRouter>
    </div>
  );}
}
 
export default App;