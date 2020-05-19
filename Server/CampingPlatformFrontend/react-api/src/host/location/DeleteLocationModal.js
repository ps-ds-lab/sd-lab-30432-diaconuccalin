import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';

import { getToken } from '../../utils/Common';

function DeleteLocationModal({ locationID: locationid, ...rest }) {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const deleteLocation = () => {
      const requestOptions = {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + getToken()
          }
        };
    
        fetch('http://localhost:5000/api/locations/' + locationid, requestOptions)
          .then(response => response.json())
          .then(data => this.setState({ postId: data.id }))
          .catch(err => console.log(err));
        
        handleClose();
        window.location.href = "/";
    };
  
    return (
      <>
        <button type="button" class="btn btn-danger mr-1 mt-2" onClick={handleShow} >Delete</button>
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Delete Confirmation</Modal.Title>
          </Modal.Header>
          <Modal.Body>Are you sure that you want to delete this location?</Modal.Body>
          <Modal.Footer>
            <button type="button" class="btn btn-danger mr-1 mt-2" onClick={deleteLocation} >Delete</button>
            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={handleClose} >Cancel</button>
          </Modal.Footer>
        </Modal>
      </>
    );
}

export default DeleteLocationModal;