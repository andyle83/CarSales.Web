import * as actionTypes from '../actions/actionTypes';

const initialState = {
    vehicleTypes: [],
    vehicleType: {},
    error: "",
};

const vehicleTypeReducer = (state, action) => {
    state = state || initialState;

    switch (action.type) {
        
        case actionTypes.GET_VEHICLE_TYPE_LIST:
            return { 
                ...state, 
                loading: true,
                error: null
            };

        case actionTypes.GET_VEHICLE_TYPE_LIST_SUCCESS:
            return {
                ...state,
                vehicleTypes: action?.vehicleTypes,
                loading: false,
                error: null
            };
        
        case actionTypes.GET_VEHICLE_TYPE_LIST_FAILURE:
            return {
                ...state,
                loading: false,
                error: action?.error?.message
            }

        case actionTypes.GET_VEHICLE_TYPE_DETAILS:
            return { 
                ...state, 
                vehicleType: action?.vehicleType,
                loading: true,
                error: null 
            };

        default:
            return state;
    }
};

export default vehicleTypeReducer;