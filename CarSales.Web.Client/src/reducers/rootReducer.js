import { combineReducers } from 'redux';
import types from './vehicleTypeReducer';
import vehicles from './vehicleReducer';

const rootReducer = combineReducers({
    types,
    vehicles
});

export default rootReducer;