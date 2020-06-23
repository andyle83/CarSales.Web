import * as types from '../actions/actionTypes';
import { call, put } from 'redux-saga/effects';
import { takeEvery } from 'redux-saga/effects';
import { vehicleTypeService } from '../services/VehicleTypeService';
import * as actions from '../actions/actions';

function* getVehicleTypeListAsync() {
    try {
        const vehicleTypes = yield call(vehicleTypeService.getVehicleTypeListAsync);
        yield put(actions.getVehicleTypeListSuccess(vehicleTypes));
    } catch (error) {
        yield put(actions.getVehicleTypeListFailure(error));
    }
}

function* getVehicleTypeDetails(action) {
    const id = action.id;

    try {
        const vehicleType = yield call(vehicleTypeService.getVehicleTypeDetailsAsync, id);
        yield put(actions.getVehicleTypedDetailsSuccess(vehicleType));
    } catch (error) {
        yield put(actions.getVehicleTypedDetailsFailure(error));
    }
}

// Create watchers that listen to sagas
export function* vehicleTypeWatcherSagas() {
    yield takeEvery(types.GET_VEHICLE_TYPE_LIST, getVehicleTypeListAsync);
    yield takeEvery(types.GET_VEHICLE_TYPE_DETAILS, getVehicleTypeDetails);
}