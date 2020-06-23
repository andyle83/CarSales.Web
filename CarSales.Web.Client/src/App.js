import React, { useState } from 'react';
import { useSelector } from 'react-redux';

import Container from 'react-bootstrap/Container';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Form from 'react-bootstrap/Form';
import Button from 'react-bootstrap/Button';
import Alert from 'react-bootstrap/Alert';

const styles = {
  container: {
      paddingLeft: 50,
      paddingRight: 50,
      paddingTop: 20,
  },
  row: {
      marginTop: 20,
  }
};

function App() {
  const [type, setType] = useState(0);
  const [alert, setAlert] = useState(false);
  const vehicleTypes = useSelector(state => state.types?.vehicleTypes);

  const handleSelect = (event) => {
    const v = parseInt(event.target?.value);
    
    if (!isNaN(v)) {
      setType(v);
    }
  }

  const handleSubmit = (event) => {
    event.preventDefault();
    if (type === 0) {
      setAlert(true);
    }
  }

  return (
    <Container fluid style={styles.container}>
      <Row style={styles.row}>
        <Col sm="auto">
          <h4>CarSales Simple App</h4>
        </Col>
      </Row>
      <Row style={styles.row}>
        <Col sm="auto">
          <Form inline onSubmit={handleSubmit}>
            <Form.Control as="select" style={{ paddingLeft: 0, marginRight: 20 }} onChange={handleSelect}>
              <option value="0">Select Vehicle Type</option>
              {vehicleTypes.map((type) => (
                  <option key={type.id} value={type.id}>
                      {type.name}
                  </option>
              ))}
            </Form.Control>
            <Button variant="primary" type="submit">
              Create Vehicle
            </Button>
          </Form>
        </Col>
      </Row>
      {alert &&
        (<Row style={styles.row}>
          <Col sm="auto">
            <Alert variant="danger" onClose={() => setAlert(false)} dismissible>
              Select a vehicle type from the list
            </Alert>
          </Col> 
        </Row>)
      }
  </Container>
  );
}

export default App;
