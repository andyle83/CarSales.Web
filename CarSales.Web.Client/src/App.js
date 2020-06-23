import React from 'react';
import {
  BrowserRouter as Router,
  Switch,
  Route,
} from "react-router-dom";

import Container from 'react-bootstrap/Container';
import VehicleType from './views/VehicleType/VehicleType';
import Vehicle from './views/Vehicle/Vehicle';
import Header from './components/Header/Header';

const styles = {
  container: {
      paddingLeft: 50,
      paddingRight: 50,
      paddingTop: 20,
  }
};

function App() {
  return (
    <Router>
      <Container fluid style={styles.container}>     
        <Header title="CarSales Simple App"  />

        {/* Look through its children and render matched one */}
        <Switch>
          <Route exact path="/">
            <VehicleType/>
          </Route>
          <Route path="/vehicletype">
            <VehicleType/>
          </Route>
          <Route path="/vehicle">
            <Vehicle />
          </Route>
        </Switch>

      </Container>
    </Router>
  );
}

export default App;
