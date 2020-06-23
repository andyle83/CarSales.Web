import * as types from './actionTypes';

// Get vehicle type actions
export function getVehicleTypeList() {
    return {
        type: types.GET_VEHICLE_TYPE_LIST
    };
}

export function getVehicleTypeListSuccess(vehicleTypes) {
    return {
        type: types.GET_VEHICLE_TYPE_LIST_SUCCESS,
        vehicleTypes,
    };
}

export function getVehicleTypeListFailure(error) {
    return {
        type: types.GET_VEHICLE_TYPE_LIST_FAILURE,
        error,
    };
}

// Get vehicle type details action
export function getVehicleTypedDetails() {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS
    }
}

export function getVehicleTypedDetailsSuccess(vehicleType) {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS,
        vehicleType,
    };
}

export function getVehicleTypedDetailsFailure(error) {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS,
        error: error,
    };
}