import { fork, all } from 'redux-saga/effects';
import { vehicleTypeWatcherSagas } from './vehicleTypeSagas';

export default function* rootSaga() {
    yield all([
        fork(vehicleTypeWatcherSagas)
    ]);
}
