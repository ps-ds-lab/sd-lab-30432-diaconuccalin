import React from 'react';
import { getToken } from './utils/Common';
import { loadEdit } from './HostsCommands';
import DeleteHostModal from './DeleteHostModal';

class DetailsHost extends React.Component {
    state = {
        host: [],
        token: getToken()
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
            this.setState({ host: data });
        })
        .catch(console.log)
    }

    render() {
        return(
            <div class="container">
                <h1>Details</h1>
                <h4>{this.state.host.id}</h4>
                <div class = "card">
                    <div class = "card-body">
                        <h5 class="card-title">{this.state.host.id}</h5>
                        <h6 class="card-subtitle mb-2 text-muted">{this.state.host.dateOfBirth}</h6>
                        <p class="card-text">{this.state.host.telephoneNumber}</p>        
                    </div>
                </div>
                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={()=>loadEdit(this.state.host.id)} >Edit</button>
                <DeleteHostModal hostID={ this.state.host.id }/>
            </div>
        )
    }
}

export default DetailsHost;