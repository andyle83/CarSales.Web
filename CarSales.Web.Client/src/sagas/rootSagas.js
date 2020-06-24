import { fork, all } from 'redux-saga/effects';
import { vehicleTypeWatcherSagas } from './vehicleTypeSagas';
import { vehicleWatcherSags } from './vehicleSagas';

export default function* rootSaga() {
    yield all([
        fork(vehicleTypeWatcherSagas),
        fork(vehicleWatcherSags)
    ]);
}
