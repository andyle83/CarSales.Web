import React from 'react';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';
import Alert from 'react-bootstrap/Alert';

const styles = {
    row: {
        marginTop: 10,
        marginBottom: 15
    }
};  

const Status = ({ isError, message }) => {
  return (
    <Row style={styles.row}>
        <Col sm="auto">
            <Alert variant={isError ?  "danger" : "success"}>{message}</Alert>
        </Col>
    </Row>
  )
};

export default Status;