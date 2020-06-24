import React, { useState } from 'react';
import { useSelector, useDispatch } from 'react-redux';
import { useHistory } from 'react-router-dom';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';

import { getVehicleTypedDetails } from '../../actions/actions';

function VehicleType() {
  const history = useHistory();
  const dispatch = useDispatch();
  const vehicleTypes = useSelector(state => state.types?.vehicleTypes);

  const [isValid, setIsValid] = useState(true);
  const [vehicleTypeId, setVehicleTypeId] = useState(0);

  const handleSelect = (event) => {
    const id = parseInt(event.target?.value);
    
    if (!isNaN(id)) {
      setVehicleTypeId(id);
    }
  }

  const handleSubmit = (event) => {
    event.preventDefault();

    if (vehicleTypeId === 0) {
      setIsValid(false);
    } else {
      // fetch vehicle list belong to type
      dispatch(getVehicleTypedDetails(vehicleTypeId))

      // move to vehicle type, with existing list and form
      history.push(`/vehicle/`);
    }
  }

  return (
    <>
      <Row>
        <Col sm="auto">
          <Form inline onSubmit={handleSubmit}>
            <Form.Control as="select" style={{ paddingLeft: 0, marginRight: 20, marginTop: 20 }} onChange={handleSelect}>
              <option value="0">Select Vehicle Type</option>
              {vehicleTypes.map((type) => (
                  <option key={type.id} value={type.id}>
                      {type.name}
                  </option>
              ))}
            </Form.Control>
            <Button variant="dark" style={{ marginTop: 20 }} type="submit">
              Create Vehicle
            </Button>
          </Form>
        </Col>
      </Row>
      {!isValid &&
        (<Row style={{ marginTop: 20 }}>
          <Col sm="auto">
            <Alert variant="danger" onClose={() => setIsValid(true)} dismissible>
              Select a vehicle type from the list
            </Alert>
          </Col> 
        </Row>)}
    </>
  );
}

export default VehicleType;
