import React from 'react';

import Col from 'react-bootstrap/Col';
import Row from 'react-bootstrap/Row';

const styles = {
    row: {
        marginTop: 10,
        marginBottom: 20,
    }
};  

const Header = ({ title }) => {
  return (
    <Row style={styles.row}>
        <Col sm="auto">
            <h4>{title}</h4>
        </Col>
    </Row>
  )
};

export default Header;