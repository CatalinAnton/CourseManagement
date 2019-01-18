import { all } from 'redux-saga/effects'
import * as Auth from '../auth'
import * as Courses from '../courses'
import * as Resources from '../resources'

export default function * rootSaga () {
  yield all([Auth.saga(), Courses.saga(), Resources.saga()])
}
