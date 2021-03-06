import React, { useState } from 'react';
import { Link } from 'react-router-dom';
import { useSelector, useDispatch } from 'react-redux';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Table from 'react-bootstrap/Table'
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';

import { Pen, Trash  } from 'react-bootstrap-icons';

import { createVehicle } from '../../actions/actions';
import Status from '../../components/Status/Status';

export default function Vehicle() {
  const dispatch = useDispatch();
  const vehicleType = useSelector(state => state.types?.vehicleType);
  const error = useSelector(state => state.vehicles?.error);

  const [doors, setDoors] = useState(2);
  const [wheels, setWheels] = useState(4);
  const [model, setModel] = useState('');
  const [make, setMake] = useState('');

  const vehicles = vehicleType?.vehicles;
  const typeId = vehicleType?.id;

  const isInputValid = doors >= 0 && wheels > 1 && model.length > 1 && make.length > 1;
  const isVehicleTypeValid = !isNaN(typeId) && typeId > 0;
  const isValid = isVehicleTypeValid && isInputValid;
  
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

  const handleSubmit = (event) => {
    event.preventDefault();

    if (isValid) {
      // create new vehicle
      dispatch(createVehicle({ typeId, doors, wheels, model, make }));
    }
  }

  return (
    <>
    <Row>
      <Col sm="auto">
        {error && <Status message={error} isError={(error.length > 0)} />}
        <p><b>Create / Update Vehicle</b></p>
        <Form onSubmit={handleSubmit}>
          <Form.Row>
          <Form.Group as={Col} md={4}>
            <Form.Label htmlFor="doorsInput">Doors</Form.Label>
            <Form.Control type="text" id="doorsInput" value={doors} onChange={handleDoorsChange} placeholder="2" disabled={!isVehicleTypeValid} />
          </Form.Group>

          <Form.Group as={Col} md={8}>
            <Form.Label htmlFor="makeInput">Make</Form.Label>
            <Form.Control type="text" id="makeInput" value={make} onChange={handleMakeChange} placeholder="Toyota" disabled={!isVehicleTypeValid} />
          </Form.Group>
          </Form.Row>

          <Form.Row>
          <Form.Group as={Col} md={4}>
            <Form.Label htmlFor="wheelsInput">Wheels</Form.Label>
            <Form.Control type="text" id="wheelsInput" value={wheels} onChange={handleWheelsChange} placeholder="4" disabled={!isVehicleTypeValid} />
            <Form.Text id="wheelsHelpBlock" muted>
              Must be greater than 2
            </Form.Text>
          </Form.Group>

          <Form.Group as={Col} md={8}>
            <Form.Label htmlFor="modelInput">Model</Form.Label>
            <Form.Control type="text" id="modelInput" value={model} onChange={handleModelChange} placeholder="Vios 2020" disabled={!isVehicleTypeValid} />
          </Form.Group>
          </Form.Row>

          <Form.Row>
            <Button variant="dark" type="submit" disabled={!isValid} style={{ marginRight: 10 }}>
              Create Vehicle
            </Button>
            {!isVehicleTypeValid && <Link style={{color: 'red'}} to="/">[*] Need to select a vehicle type !</Link>}
          </Form.Row>
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
                {vehicles.map(({id, doors, wheels, model, make}, index) => (
                  <tr key={id}>
                    <td>{index + 1}</td>
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