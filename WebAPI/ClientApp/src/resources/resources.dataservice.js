import { API } from '../common'

export const getResources = () => API.GET('https://localhost:5005/api/resourses').toJson()
export const postResource = resource => API.POST('https://localhost:5005/api/resourses', resource)
