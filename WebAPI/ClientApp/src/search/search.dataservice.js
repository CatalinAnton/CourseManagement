import { API } from '../common'

export const search = term => API.GET(`https://localhost:5003/api/courses/search/${term}`).toJson()
