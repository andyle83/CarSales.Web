import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Table from 'react-bootstrap/Table'
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';

import { Pen, Trash  } from 'react-bootstrap-icons';

export default function Vehicle() {

  const dispatch = useDispatch();
  const vehicleType = useSelector(state => state.types?.vehicleType);
  const vehicles = vehicleType?.vehicles;

  const [doors, setDoors] = useState(2);
  const [wheels, setWheels] = useState(4);
  const [model, setModel] = useState('');
  const [make, setMake] = useState('');
  
  const handleDoorsChange = (event) => {
    setDoors(event?.target?.value);
  }

  const handleWheelsChange = (event) => {
    setWheels(event?.target?.value);
  }

  const handleModelChange = (event) => {
    setModel(event?.target?.value);
  }

  const handleMakeChange = (event) => {
    setMake(event?.target?.value);
  }

  const isValid = doors > 0 && wheels > 1 && model.length > 1 && make.length > 1;

  return (
    <>
    <Row>
      <Col sm="auto">
        <p><b>Create / Update Vehicle</b></p>
        <Form>
          <Form.Row>
          <Form.Group as={Col} md={4} controlId="doors">
            <Form.Label htmlFor="doorsInput">Doors</Form.Label>
            <Form.Control type="text" id="doorsInput" value={doors} onChange={handleDoorsChange} placeholder="2"/>
            <Form.Text id="doorsHelpBlock" muted>
              Must be greater than 1
            </Form.Text>
          </Form.Group>

          <Form.Group as={Col} md={8} controlId="make">
            <Form.Label htmlFor="makeInput">Make</Form.Label>
            <Form.Control type="text" id="makeInput" value={make} onChange={handleMakeChange} placeholder="Toyota"/>
          </Form.Group>
          </Form.Row>

          <Form.Row>
          <Form.Group as={Col} md={4} controlId="wheels">
            <Form.Label htmlFor="wheelsInput">Wheels</Form.Label>
            <Form.Control type="text" id="wheelsInput" value={wheels} onChange={handleWheelsChange} placeholder="4" />
            <Form.Text id="wheelsHelpBlock" muted>
              Must be greater than 2
            </Form.Text>
          </Form.Group>

          <Form.Group as={Col} md={8} controlId="model">
            <Form.Label htmlFor="modelInput">Model</Form.Label>
            <Form.Control type="text" id="modelInput" value={model} onChange={handleModelChange} placeholder="Vios 2020" />
          </Form.Group>
          </Form.Row>

          <Button variant="dark" type="submit" disabled={!isValid}>
            Create Vehicle
          </Button>
          <hr />
        </Form>
      </Col>
    </Row>
    <Row>
      <Col sm="auto">
        <p><b>Vehicle List</b></p>
        {
          (vehicles && (vehicles.length > 0)) 
          ? (<Table striped bordered hover>
              <thead>
                <tr>
                  <th>#</th>
                  <th>Doors</th>
                  <th>Wheels</th>
                  <th>Model</th>
                  <th>Make</th>
                  <th colSpan="2">Update / Delete</th>
                </tr>
              </thead>
              <tbody>
                {vehicles.map(({id, doors, wheels, model, make}) => (
                  <tr key={id}>
                    <td>{id}</td>
                    <td>{doors}</td>
                    <td>{wheels}</td>
                    <td>{model}</td>
                    <td>{make}</td>
                    <td align="center"><Pen/></td>
                    <td align="center"><Trash/></td>
                  </tr>
                  ))}
              </tbody>
            </Table>
          ) : (
            <Alert key="noVehicleFound" variant="warning">Not found any vehicle</Alert>
          )
        }
      </Col>
    </Row>
    </>
  )
}