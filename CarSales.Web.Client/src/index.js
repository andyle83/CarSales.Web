import React from 'react';
import ReactDOM from 'react-dom';
import { Provider } from 'react-redux';

import configureStore from './reducers/configStore';
import { getVehicleTypeList } from './actions/actions';
import App from './App';

import './index.css';

// Create Store
const store = configureStore();

// Load data from server
store.dispatch(getVehicleTypeList());

ReactDOM.render(
  <Provider store={store}>
    <App />
  </Provider>,
  document.getElementById('root')
);
