import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';
import axios from 'axios';

import { getToken } from '../utils/Common';

function DetailsGuestModal({ user, guest, guestRequestId, accepted, ...rest }) {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const handleAccept = () => {
        const requestOptions = {
            method: 'PUT',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + getToken()
              }
            };
        
            fetch('http://localhost:5000/api/GuestRequests/markAccepted/' + guestRequestId, requestOptions)
              .then(response => response.json())
              .then(data => this.setState({ postId: data.id }))
              .catch(err => console.log(err));
            
            handleClose();
    };

    const handleReject = () => {
      axios
        .delete('http://localhost:5000/api/GuestRequests/' + guestRequestId,
        {}, { 'headers':
        { 'Authorization' : 'Bearer ' + getToken() }})
        .then(response => {
           window.location.reload();
        })
        .catch(error => {});
        
        handleClose();
    }
  
    return (
      <>
        <button type="button" class="btn btn-primary mr-2 mt-2" onClick={handleShow} >Details</button>
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Guest Details</Modal.Title>
          </Modal.Header>
          <Modal.Body>
                    <div class = "card-body">
                        <h5 class="card-title">{user ? user.firstName : ""} {user ? user.lastName : ""}</h5>
                        <div class="card-text">Email: {user ? user.email : ""}</div>
                        <div class="card-text">Phone number: {guest ? guest.telephoneNumber : ""}</div>
                        <div class="card-text">Date of birth: {guest ? guest.dateOfBirth : ""}</div>
                        <div class="card-text">Description: {guest ? guest.description : ""}</div>
                    </div>
          </Modal.Body>
          <Modal.Footer>
            <button type="button" class={accepted === true ? "btn btn-success mr-1 mt-2 disabled" : "btn btn-success mr-1 mt-2"} onClick={accepted === true ? "" : handleAccept}>{accepted === true ? "Already accepted" : "Accept"}</button>
            <button type="button" class={accepted === true ? "btn btn-danger mr-1 mt-2 disabled" : "btn btn-danger mr-1 mt-2"} onClick={accepted === true ? "" : handleReject} >Reject</button>
          </Modal.Footer>
        </Modal>
      </>
    );
}

export default DetailsGuestModal;