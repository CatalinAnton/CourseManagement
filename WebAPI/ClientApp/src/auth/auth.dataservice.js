import { API } from '../common'

export const register = user => API.POST('https://localhost:5009/api/users', user).toJson()
export const doLogin = user => API.POST('https://localhost:5009/api/sessions', user).toJson()
export const doLogout = () => API.DELETE('https://localhost:5009/api/sessions').toJson()
