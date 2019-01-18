import { REGISTER, DO_LOGIN, SET_AUTHENTIFIED_STATE, DO_LOGOUT } from './auth.constants'

export const register = ({ email, password, firstName, lastName, role }, resolve, reject) => ({
  type: REGISTER,
  payload: { email, password, firstName, lastName, role, resolve, reject }
})

export const doLogin = ({ email, password }, resolve, reject) => ({
  type: DO_LOGIN,
  payload: { email, password, resolve, reject }
})

export const setAuthentifiedState = ({ authentified, token }) => ({
  type: SET_AUTHENTIFIED_STATE,
  payload: { authentified, token }
})

export const doLogout = (_, resolve, reject) => ({
  type: DO_LOGOUT,
  payload: { resolve, reject }
})