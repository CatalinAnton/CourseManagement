import { takeLatest, put, call } from 'redux-saga/effects'
import { GET_RESOURCES, POST_RESOURCE } from './resources.constants'
import { setResources } from './resources.actions'
import { getResources, postResource } from './resources.dataservice'

function* getResourcesSaga(action) {
  const { resolve, reject } = action.payload
  const response = yield call(getResources)
  if (response.status === 200) {
    let resources = {}
    response.data.forEach(item => {
      resources[item.CourseId] = item
    })
    yield put(setResources(resources))
    resolve && resolve()
  } else {
    reject && reject()
  }
}

function* postResourceSaga(action) {
  const { resource, resolve, reject } = action.payload
  const response = yield call(postResource, resource)
  if (response.status === 200) {
    resolve && resolve()
  } else {
    reject && reject()
  }
}

export default function* resources() {
  yield takeLatest(GET_RESOURCES, getResourcesSaga)
  yield takeLatest(POST_RESOURCE, postResourceSaga)
}
