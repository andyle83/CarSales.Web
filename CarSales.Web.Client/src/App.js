import React from 'react';
import Container from 'react-bootstrap/Container';
import Button from 'react-bootstrap/Button';
import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

function App() {
  return (
    <Container>
    <Row className="row">
      <Col xs={5}>
        <h1>CarSales Vehicle List</h1>
        <Button>New Vehicle</Button>
      </Col>
    </Row>
  </Container>
  );
}

export default App;
