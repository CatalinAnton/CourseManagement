import { takeLatest, put, call } from 'redux-saga/effects'
import { SEARCH } from './search.constants'
import { search } from './search.dataservice'
import { setCourses } from '../courses/courses.actions'

function * searchSaga (action) {
  const { term, resolve, reject } = action.payload
  const response = yield call(search, term)
  if (response.status === 200) {
    yield put(setCourses(response.data))
    resolve && resolve()
  } else {
    reject && reject()
  }
}

export default function * root () {
  yield takeLatest(SEARCH, searchSaga)
}
