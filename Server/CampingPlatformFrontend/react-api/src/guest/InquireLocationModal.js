import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import axios from 'axios';
import { getUser, getToken } from '../utils/Common';
import * as signalR from '@microsoft/signalr';

function InquireLocationModal({ locationID: locationid, disabled, ...rest }) {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const inquireLocation = () => {
        axios
            .post('http://localhost:5000/api/guestRequests',
                {
                    guestId: getUser().id,
                    locationId: locationid
                },
                { 'headers':
                    { 'Authorization' : 'Bearer ' + getToken() }})
            .then(response => {
                axios.get("http://localhost:5000/api/locations/" + locationid,
                { 'headers':
                    { 'Authorization' : 'Bearer ' + getToken() }})
                .then(response2 => {
                    var connection = new signalR.HubConnectionBuilder().withUrl("http://localhost:5000/notifications",
                    {
                        skipNegotiation: true,
                        transport: signalR.HttpTransportType.WebSockets
                    }).build();

                    var packet = {
                        hostId: response2.data.hostId,
                        locationId: response2.data.id
                    }

                    connection.start().then(function () {
                        connection.invoke("SendNotification", JSON.stringify(packet)).catch(function (err) {
                          return console.error(err.toString());
                        });
                        
                        handleClose();
                        window.location.href = "/";
                      }).catch(function (err) {
                        return console.error(err.toString());
                    });
                })
                .catch(error => {
                    console.log(error);
                })
            })
            .catch(error => {
                console.log(error);
            });
    };
  
    return (
      <>
        <button type="button" class={disabled === "true" ? "btn btn-primary mr-1 mt-2 disabled" : "btn btn-primary mr-1 mt-2"} onClick={disabled === "true" ? handleClose : handleShow} id="sendInquire">{disabled === "true" ? "You have already solicited this place" : "I would like to stay in this place"}</button>
  
        <Modal show={show} onHide={handleClose}>
            <Modal.Header closeButton>
                <Modal.Title>Request confirmation</Modal.Title>
            </Modal.Header>
            <Modal.Body>If you confirm the request, we will send the information you provided about yourself (your full name, your profile picture and the description you provided about yourself).<br/><br/>
                If the host that owns the location accepts, they will also get access to your contact information (email and telephone number) 
                and you will get access to their information (name, telephone number and email address).<br/><br/>
                From that point on, it is your responsibility to contact each other and to establish further details about your accomodation.
            </Modal.Body>
            <Modal.Footer>
                <button type="button" class="btn btn-primary mr-1 mt-2" onClick={inquireLocation} >Confirm request</button>
                <button type="button" class="btn btn-secondary mr-1 mt-2" onClick={handleClose} >Cancel</button>
            </Modal.Footer>
        </Modal>
      </>
    );
}

export default InquireLocationModal;