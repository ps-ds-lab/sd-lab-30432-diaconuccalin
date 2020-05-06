import React from 'react';
import { BrowserRouter, Switch, Route } from 'react-router-dom';
 
import Home from './Home';
import Login from './login/Login';
import PrivateRoute from './login/PrivateRoute';
import PublicRoute from './login/PublicRoute';
import { getUser, removeUserSession } from './login/Common';
import Guests from './guest/Guests';
import Hosts from './host/Hosts';
import CreateHost from './host/CreateHost';
import DetailsHost from './host/DetailsHost';
import EditHost from './host/EditHost';

function App() { 
  const user = getUser();

  return (
    <div className="App">
      <BrowserRouter>
        <div>
          
          <header>
            <nav class="navbar navbar-expand-sm navbar-toggleable-sm navbar-light bg-white border-bottom box-shadow mb-3">
              <div class="container">
                <a class="navbar-brand" href="/">Camping Platform</a>
                <button class="navbar-toggler" type="button" data-toggle="collapse" data-target=".navbar-collapse" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
                  <span class="navbar-toggler-icon"></span>
                </button>
                <div class="navbar-collapse collapse d-sm-inline-flex flex-sm-row-reverse">
                  <ul class="navbar-nav">
                      <li class="nav-item">
                        <div class="nav-link text-dark">{user ? "Hello, " + user.firstname + "!" : ""}</div>
                      </li>
                      <li class="nav-item">
                        <a class="nav-link text-dark" onClick={removeUserSession} href={user ? "/" : "/login"}>{user ? 'Logout' : 'Login'}</a>
                      </li>
                  </ul>
                  <ul class="navbar-nav flex-grow-1">
                    <li class="nav-item">
                      <a class="nav-link text-dark" href="/guests">Guests</a>
                    </li>
                    <li class="nav-item">
                      <a class="nav-link text-dark" href="/hosts">Hosts</a>
                    </li>
                  </ul>
                </div>
              </div>
            </nav>
          </header>

          <Switch>
            <Route exact path="/" component={Home} />
            
            <PublicRoute path="/login" component={Login} />

            <PrivateRoute path="/guests" component={Guests} />
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