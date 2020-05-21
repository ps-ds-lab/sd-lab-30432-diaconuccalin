import React, { useState } from 'react';
import Modal from 'react-bootstrap/Modal';

import { getToken, removeUserSession } from './utils/Common';

function DeleteAdminModal({ adminID: adminid, ...rest }) {
    const [show, setShow] = useState(false);
  
    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const deleteAdmin = () => {
      const requestOptions = {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + getToken()
          }
        };
    
        fetch('http://localhost:5000/api/Users/' + adminid, requestOptions)
          .then(response => response.json())
          .then(data => this.setState({ postId: data.id }))
          .catch(err => console.log(err));
        
        handleClose();
        removeUserSession();
        window.location.href = "/welcome";
    };
  
    return (
      <>
        <button type="button" class="btn btn-danger mr-1 mt-2" onClick={handleShow} >Delete Account</button>
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Delete Confirmation</Modal.Title>
          </Modal.Header>
          <Modal.Body>Are you sure that you want to delete your account?</Modal.Body>
          <Modal.Footer>
            <button type="button" class="btn btn-danger mr-1 mt-2" onClick={deleteAdmin} >Delete Account</button>
            <button type="button" class="btn btn-primary mr-1 mt-2" onClick={handleClose} >Cancel</button>
          </Modal.Footer>
        </Modal>
      </>
    );
}

export default DeleteAdminModal;