import React from 'react';
import { BrowserRouter, Switch } from 'react-router-dom';
 
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
import Account from './Account';

function App() { 
  const user = getUser();

  return (
    <div className="App">
      <BrowserRouter>
        <div>
          
          <header>
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
              <div class="container">
                <a class="navbar-brand" href={user ? "/" : "/welcome"}>Camping Platform</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                  <ul class="navbar-nav">
                      <li class="nav-item">
                        <div class="nav-link text-dark">{user ? "Hello, " : ""}<a class="text-dark" href={user ? "/account" : ""}>{user ? user.firstname : ""}</a>{user ? "!" : ""}</div>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link text-dark" onClick={removeUserSession} href={user ? "/welcome" : "/login"}>{user ? 'Logout' : 'Login'}</a>
                      </li>
                  </ul>
                </div>
              </div>
            </nav>
          </header>

          <Switch>
            <PublicRoute path="/welcome" component={Welcome} />
            <PublicRoute path="/login" component={Login} />
            <PublicRoute path="/hostRegister" component={HostRegister} />
            <PublicRoute path="/guestRegister" component={GuestRegister} />

            <PrivateRoute path="/editAccount" component={EditHost} />
            <PrivateRoute path="/account" component={Account} />
            <PrivateRoute path="/newLocation" component={CreateLocation} />
            <PrivateRoute exact path="/" component={Home} />
            <PrivateRoute path="/guests" component={Guests} />
            <PrivateRoute path="/hosts/locationDetail" component={DetailsLocation} />
            <PrivateRoute path="/hosts/locationEdit" component={EditLocation} />
            <PrivateRoute path="/hosts/detail" component={DetailsHost} />
            <PrivateRoute path="/hosts/create" component={CreateHost} />
            <PrivateRoute path="/hosts/edit" component={EditHost} />
            <PrivateRoute path="/hosts" component={Hosts} />
          </Switch>
          
          <footer class="border-top footer text-muted">
            <div class="container">
              © 2020 - CampingPlatform
            </div>
          
          </footer>
        </div>
      </BrowserRouter>
    </div>
  );
}
 
export default App;