import { takeLatest, takeEvery, put, call } from 'redux-saga/effects'
import { GET_RESOURCES, POST_RESOURCE } from './resources.constants'
import { setResources } from './resources.actions'
import { getResources, postResource } from './resources.dataservice'

function * getResourcesSaga (action) {
  const { courseId, resolve, reject } = action.payload
  const response = yield call(getResources, courseId)
  if (response.status === 200) {
    yield put(setResources(courseId, response.data))
    resolve && resolve()
  } else {
    reject && reject()
  }
}

function * postResourceSaga (action) {
  const { resource, resolve, reject } = action.payload
  const response = yield call(postResource, resource)
  if (response.status === 200) {
    resolve && resolve()
  } else {
    reject && reject()
  }
}

export default function * resources () {
  yield takeEvery(GET_RESOURCES, getResourcesSaga)
  yield takeLatest(POST_RESOURCE, postResourceSaga)
}
