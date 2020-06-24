import * as types from './actionTypes';
import * as vehicles from './actionVehicles';

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
export function getVehicleTypedDetails(id) {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS,
        id,
    }
}

export function getVehicleTypedDetailsSuccess(vehicleType) {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS_SUCCESS,
        vehicleType,
    };
}

export function getVehicleTypedDetailsFailure(error) {
    return {
        type: types.GET_VEHICLE_TYPE_DETAILS_FAILURE,
        error,
    };
}

// Create a new vehicle
export function createVehicle(vehicle) {
    return {
        type: vehicles.CREATE_VEHICLE,
        vehicle,
    };
}

export function createVehicleSuccess(vehicle) {
    return {
        type: vehicles.CREATE_VEHICLE_SUCCESS,
        vehicle,
    };
}

export function createVehicleFailure(error) {
    return {
        type: vehicles.CREATE_VEHICLE_FAILURE,
        error,
    };
}