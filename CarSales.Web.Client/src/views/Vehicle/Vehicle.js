import React from 'react';
import { useSelector, useDispatch } from 'react-redux';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Table from 'react-bootstrap/Table'
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';

import { Pen, Trash  } from 'react-bootstrap-icons';

export default function Vehicle() {

  const dispatch = useDispatch();
  const vehicleType = useSelector(state => state.types?.vehicleType);
  const vehicles = vehicleType?.vehicles;

  
  return (
    <>
    <Row>
      <Col sm="auto">
        <Form>
          <Form.Row>
          <Form.Group as={Col} md={4} controlId="doors">
            <Form.Label htmlFor="doorsInput">Doors</Form.Label>
            <Form.Control type="text" id="doorsInput" placeholder="2" />
          </Form.Group>

          <Form.Group as={Col} md={6} controlId="make">
            <Form.Label htmlFor="makeInput">Make</Form.Label>
            <Form.Control type="text" id="makeInput" placeholder="Toyota" />
          </Form.Group>
          </Form.Row>

          <Form.Row>
          <Form.Group as={Col} md={4} controlId="wheels">
            <Form.Label htmlFor="wheelsInput">Wheels</Form.Label>
            <Form.Control type="text" id="wheelsInput" placeholder="4" />
          </Form.Group>

          <Form.Group as={Col} md={6} controlId="model">
            <Form.Label htmlFor="modelInput">Model</Form.Label>
            <Form.Control type="text" id="modelInput" placeholder="Vios 2020" />
          </Form.Group>
          </Form.Row>

          <Button variant="dark" type="submit">
            Create Vehicle
          </Button>
          <hr />
        </Form>
      </Col>
    </Row>
    <Row>
      <Col sm="auto">
        <p>Vehicle List</p>
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
            <p>Could not found any vehicles</p>
          )
        }
      </Col>
    </Row>
    </>
  )
}