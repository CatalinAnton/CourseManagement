import { takeLatest, put, call } from 'redux-saga/effects'
import { GET_COURSES, POST_COURSE } from './courses.constants'
import { setCourses } from './courses.actions'
import { getCourses, postCourse } from './courses.dataservice'

function* getCoursesSaga(action) {
  const { resolve, reject } = action.payload
  const response = yield call(getCourses)
  if (response.status === 200) {
    yield put(setCourses(response.data))
    resolve && resolve()
  } else {
    reject && reject()
  }
}

function* postCourseSaga(action) {
  const { course, resolve, reject } = action.payload
  const response = yield call(postCourse, course)
  if (response.status === 200) {
    resolve && resolve()
  } else {
    reject && reject()
  }
}

export default function* courses() {
  yield takeLatest(GET_COURSES, getCoursesSaga)
  yield takeLatest(POST_COURSE, postCourseSaga)
}
