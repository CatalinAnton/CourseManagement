import { takeLatest, put, call } from 'redux-saga/effects'
import { REGISTER, DO_LOGIN, DO_LOGOUT } from './auth.constants'
import { setAuthentifiedState } from './auth.actions'
import { register, doLogin, doLogout } from './auth.dataservice'
import { API } from '../common'

function * registerSaga (action) {
  const {
    email,
    password,
    firstName,
    lastName,
    role,
    resolve,
    reject
  } = action.payload
  try {
    const response = yield call(register, {
      email,
      password,
      firstName,
      lastName,
      role
    })
    if (response.status === 200) {
      resolve && resolve()
    } else {
      reject && reject()
    }
  } catch (error) {
    console.log('Saga error', error)
    reject && reject()
  }
}

function * doLoginSaga (action) {
  const { email, password, resolve, reject } = action.payload
  try {
    const response = yield call(doLogin, { email, password })
    if (response.status === 200) {
      console.log(response)
      yield put(
        setAuthentifiedState({
          authentified: true,
          token: response.data.authorization
        })
      )
      API.setHeader('Authorization', response.data.authorization)
      resolve && resolve()
    } else {
      reject && reject()
    }
  } catch (error) {
    console.log('Saga error', error)
    reject && reject()
  }
}

function * doLogoutSaga (action) {
  const { resolve, reject } = action.payload
  const response = yield call(doLogout)
  if (response.status === 200) {
    yield put(setAuthentifiedState({ authentified: false, token: '' }))
    API.setHeader('Authorization', '')
    resolve && resolve()
  } else {
    reject && reject()
  }
}

export default function * root () {
  yield takeLatest(REGISTER, registerSaga)
  yield takeLatest(DO_LOGIN, doLoginSaga)
  yield takeLatest(DO_LOGOUT, doLogoutSaga)
}
