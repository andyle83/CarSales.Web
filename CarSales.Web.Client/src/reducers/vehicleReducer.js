import * as actionVehicles from '../actions/actionVehicles';

const initialState = {
    vehicle: {},
    loading: false,
    error: "",
};

const vehicleReducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {

        case actionVehicles.CREATE_VEHICLE:
            return {
                ...state, 
                loading: true,
                error: null
            };

        case actionVehicles.CREATE_VEHICLE_SUCCESS:
            return {
                ...state,
                vehicle: action?.vehicle,
                loading: false,
                error: null
            };

        case actionVehicles.CREATE_VEHICLE_FAILURE:
            return {
                ...state,
                loading: false,
                error: action?.error?.message
            }

        default:
            return state;
    }
};

export default vehicleReducer;