import React from 'react'

const Hosts = ({ hosts }) => {
    return (
        <div>
            <center><h1>Hosts</h1></center>
            {hosts.map((host) => (
                <div class = "card">
                    <div class = "card-body">
                        <h5 class="card-title">{host.id}</h5>
                        <h6 class="card-subtitle mb-2 text-muted">{host.dateOfBirth}</h6>
                        <p class="card-text">{host.telephoneNumber}</p>
                    </div>
                </div>
            ))}
        </div>
    )
};

export default Hosts