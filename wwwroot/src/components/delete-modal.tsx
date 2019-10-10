import React from 'react';
import { DeleteModalProps } from '../types/index';
import { connect } from 'react-redux';
import { Modal } from 'react-bootstrap';
import { UnderConstruction } from './under-construction';


export const DisconnectedDeleteModal = (props: DeleteModalProps) => {
    return (
        <Modal {...props} aria-labelledby="delete-modal-title">
            <Modal.Header closeButton closeLabel="Close delete modal">
                <Modal.Title id="delete-modal-title">Are you sure you want to delete?</Modal.Title>
            </Modal.Header>
            <Modal.Body>
                <UnderConstruction pageName="DeleteModal"/>
            </Modal.Body>
        </Modal>
    );
}

export const DeleteModal = DisconnectedDeleteModal;