import * as vehicles from '../actions/actionVehicles';
import { call, put } from 'redux-saga/effects';
import { takeEvery } from 'redux-saga/effects';
import { vehicleService } from '../services/VehicleService';
import { vehicleTypeService } from '../services/VehicleTypeService';
import * as actions from '../actions/actions';

function* createVehicle(action) {
    const vehicle = action.vehicle;

    try {
        const result = yield call(vehicleService.createVehicleAsync,vehicle);
        yield put(actions.createVehicleSuccess(result));

        // update vehicle list
        const vehicleType = yield call(vehicleTypeService.getVehicleTypeDetailsAsync, vehicle.typeId);
        yield put(actions.getVehicleTypedDetailsSuccess(vehicleType));
    } catch (error) {
        yield put(actions.createVehicleFailure(error));
    }
}

// Create watchers that listen to sagas
export function* vehicleWatcherSags() {
    yield takeEvery(vehicles.CREATE_VEHICLE, createVehicle);
}