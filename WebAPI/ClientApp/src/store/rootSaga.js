import { all } from 'redux-saga/effects'
import * as Auth from '../auth'
import * as Courses from '../courses'
import * as Resources from '../resources'
import * as Search from '../search'

export default function * rootSaga () {
  yield all([Auth.saga(), Courses.saga(), Resources.saga(), Search.saga()])
}
